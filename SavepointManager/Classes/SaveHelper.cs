using NHotkey;
using NHotkey.WindowsForms;
using SavepointManager.Properties;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;

namespace SavepointManager.Classes
{
	public static class SaveHelper
	{
		public const int DefaultAutosaveInterval = 10;  // in minutes
		private const int HotkeySpamThreshold = 50;

		private const string SaveBind = "Save";
		private const string AbortSaveBind = "AbortSave";
		private const string DummyBind = "Dummy";

		private static readonly Stopwatch HotkeyTimer = Stopwatch.StartNew();
		private static readonly TimeSpan HotkeyCooldown = TimeSpan.FromMilliseconds(300);
		private static readonly SoundPlayer SpamPlayer = new();

		private static readonly SoundEffect[] SpamEffects = { SoundEffect.Spam1, SoundEffect.Spam2, SoundEffect.Spam3, SoundEffect.Spam4, SoundEffect.Spam5, SoundEffect.Spam6 };

		private static System.Timers.Timer autosaveTimer = new();
		private static CancellationTokenSource token = new();
		private static uint hotkeySpamCounter = 0;

		private static bool IsLastHotkeyCoolingDown => HotkeyTimer.Elapsed < HotkeyCooldown;

		static SaveHelper() => SpamPlayer.PlaybackStopped += SpamPlayer_PlaybackStopped;

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
				Logger.Log($"The hotkey {key} is not available: {ex.Message} (Windows error code: {Marshal.GetLastWin32Error()})", LogSeverity.Error);
				return false;
			}

			return true;
		}

		public static bool UpdateHotkeys()
		{
			UnbindAll();

			return RegisterHotkey(Settings.Default.SaveHotkey, SaveBind, "manual save", (s, e) => PerformSave(Save.ManualSaveDescription)) &&
				   RegisterHotkey(Settings.Default.AbortSaveHotkey, AbortSaveBind, "abort save", (s, e) => AbortSave());


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

		public static void Dispose()
		{
			SpamPlayer.PlaybackStopped -= SpamPlayer_PlaybackStopped;

			SpamPlayer.Dispose();
			autosaveTimer.Dispose();
			token.Dispose();
		}

		private static void PerformSave(string description)
		{
			if (IsLastHotkeyCoolingDown)
			{
				RecordHotkeyCooldown();
				return;
			}

			HotkeyTimer.Restart();
			Logger.Log($"{description} has been requested.", LogSeverity.Info);

			if (!Save.IsSaveInProgress)
			{
				token = new();
				World.SaveActiveWorld(description, token);
			}
			else
			{
				Logger.Log($"Another save is already in progress.", LogSeverity.Warning);
				SpamPlayer.PlaySaveEffect(SoundEffect.AlreadySaving);
			}
		}

		private static void AbortSave()
		{
			if (IsLastHotkeyCoolingDown)
			{
				RecordHotkeyCooldown();
				return;
			}

			HotkeyTimer.Restart();

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

		private static void RecordHotkeyCooldown()
		{
			Logger.Log("Hotkey was just triggered recently. Ignoring key press.", LogSeverity.Info);

			if (++hotkeySpamCounter % HotkeySpamThreshold == 0)
			{
				// We do a little bit of trolling
				Logger.Log("Please stop being a tryhard.", LogSeverity.Warning);

				SoundPlayer.Shared.Stop();
				SoundPlayer.Shared.IsPlaybackAllowed = false;

				const int SoundBoostAmount = 30;

				// Play the spam sound effect 30% louder than the sound volume, capping it at 100%
				int volume = Math.Min(Settings.Default.SoundVolume + SoundBoostAmount, 100);

				SpamPlayer.PlaySaveEffect(SpamEffects[Random.Shared.Next(SpamEffects.Length)], volume);
				HotkeyTimer.Restart();
			}
		}

		private static void AutosaveTimer_Elapsed(object? sender, ElapsedEventArgs e)
			=> PerformSave(Save.AutosaveDescription);

		private static void SpamPlayer_PlaybackStopped(object? sender, NAudio.Wave.StoppedEventArgs e)
			=> SoundPlayer.Shared.IsPlaybackAllowed = true;
	}
}
