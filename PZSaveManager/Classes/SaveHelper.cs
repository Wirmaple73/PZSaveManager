using NHotkey;
using NHotkey.WindowsForms;
using PZSaveManager.Properties;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;

namespace PZSaveManager.Classes
{
	public static class SaveHelper
	{
		public const int DefaultAutosaveInterval = 10;  // in minutes

		private static System.Timers.Timer autosaveTimer = new();
		private static CancellationTokenSource token = new();

        public static void UpdateAutosaveTimer()
		{
			autosaveTimer.Elapsed -= AutosaveTimer_Elapsed;
			autosaveTimer.Stop();

			if (Settings.Default.EnableAutosave)
			{
				if (Settings.Default.AutosaveInterval <= 0)
				{
					Settings.Default.AutosaveInterval = DefaultAutosaveInterval;
					Logger.Log($"The auto-save interval was invalid and has been reset.", LogSeverity.Warning);
				}

				autosaveTimer = new()
				{
					Interval = Settings.Default.AutosaveInterval * 60_000  // Convert minutes to milliseconds
				};

				autosaveTimer.Elapsed += AutosaveTimer_Elapsed;
				autosaveTimer.Start();

				Logger.Log($"Auto-save has been enabled (interval: {Settings.Default.AutosaveInterval} minutes).", LogSeverity.Info);
			}
			else
			{
				Logger.Log("Auto-save is disabled by the user.", LogSeverity.Info);
			}
		}

		private static async Task PerformSave(string description)
		{
			Logger.Log($"{description} has been requested.", LogSeverity.Info);

            if (!Save.IsSaveInProgress)
            {
                token = new();
                await World.SaveActiveWorldAsync(description, token).ConfigureAwait(false);
            }
            else
            {
                Logger.Log("Another save is already in progress.", LogSeverity.Warning);
                SoundPlayer.Shared.PlaySaveEffect(SoundEffect.AlreadySaving);
            }
        }

		private static void AbortSave()
		{
			if (Save.IsSaveInProgress)
			{
				if (Save.IsSaveCancelable)
				{
					token.Cancel();
					Logger.Log("Save cancellation has been requested.", LogSeverity.Info);
				}
				else
				{
					Logger.Log("Save is already uncancellable and couldn't be aborted.", LogSeverity.Warning);
					SoundPlayer.Shared.PlaySaveEffect(SoundEffect.SaveNotCanceled);
				}
			}
			else
			{
				Logger.Log("No pending save has been found.", LogSeverity.Info);
			}
		}

		public static void Dispose()
		{
			autosaveTimer.Dispose();
			token.Dispose();
		}

		private static async void AutosaveTimer_Elapsed(object? sender, ElapsedEventArgs e)
			=> await PerformSave(Save.AutosaveDescription);

		public static class Hotkeys
		{
			private const string SaveBind = "Save";
			private const string AbortSaveBind = "AbortSave";
			private const string DummyBind = "Dummy";

			private const int HotkeyCooldown = 1000;  // in milliseconds
			private static readonly Stopwatch cooldownStopwatch = new();

            public static bool IsHotkeyAvailable(Keys key)
			{
				try
				{
					// The Windows API doesn't directly expose a function to tell if a given key is already registered
					HotkeyManager.Current.AddOrReplace(DummyBind, key, null);
					HotkeyManager.Current.Remove(DummyBind);
				}
				catch (HotkeyAlreadyRegisteredException ex)
				{
					Logger.Log($"The hotkey {key} is not available (Windows error code {Marshal.GetLastWin32Error()})", ex);
					return false;
				}

				return true;
			}

			public static bool UpdateAll()
			{
				UnbindAll();

				return RegisterHotkey(Settings.Default.SaveHotkey, SaveBind, "manual save", static (s, e) =>
				{
					if (!TryProcessHotkey())
						return;

					// Avoid locking the window
                    _ = Task.Run(static async () =>
                    {
                        try
                        {
                            await PerformSave(Save.ManualSaveDescription).ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            Logger.Log($"Manual save failed", ex);
                        }
                    });

                }) && RegisterHotkey(Settings.Default.AbortSaveHotkey, AbortSaveBind, "abort save", static (s, e) =>
				{
                    if (!TryProcessHotkey())
                        return;

                    cooldownStopwatch.Restart();
                    AbortSave();
				});


				static bool TryProcessHotkey()
				{
					if (!cooldownStopwatch.IsRunning)
					{
						cooldownStopwatch.Start();
						return true;
					}

					if (cooldownStopwatch.ElapsedMilliseconds >= HotkeyCooldown)  // If the cooldown is over
					{
						cooldownStopwatch.Restart();
						return true;
					}

                    Logger.Log($"Hotkey was just triggered recently. Ignoring key press.", LogSeverity.Info);
                    return false;
				}

                static bool RegisterHotkey(string hotkeyString, string bindName, string hotkeyFunction, EventHandler<HotkeyEventArgs> handler)
				{
					var (key, isErroneous) = GetKeyByString(hotkeyString);

					if (isErroneous)
						return false;

					if (key is null)  // The user has disabled this hotkey
						return true;

					if (IsHotkeyAvailable(key.Value))
					{
						HotkeyManager.Current.AddOrReplace(bindName, key.Value, handler);
						Logger.Log($"Successfully binded {key.Value} to '{hotkeyFunction}'.", LogSeverity.Info);
					}
					else
					{
						return false;
					}

					return true;
				}
			}

			public static void UnbindAll()
			{
				HotkeyManager.Current.Remove(SaveBind);
				HotkeyManager.Current.Remove(AbortSaveBind);

				Logger.Log("All hotkeys have been unbinded.", LogSeverity.Info);
			}

			public static (Keys? Key, bool IsErroneous) GetKeyByString(string keyString)
			{
				if (keyString.Length > 0 && keyString != "None")
					return Enum.TryParse(keyString, true, out Keys key) ? (key, false) : (null, true);

				return (null, false);
			}
        }
	}
}
