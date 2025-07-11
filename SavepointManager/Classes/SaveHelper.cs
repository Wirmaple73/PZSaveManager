using NHotkey;
using NHotkey.WindowsForms;
using SavepointManager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SavepointManager.Classes
{
	public static class SaveHelper
	{
		public const int DefaultAutosaveInterval = 10;  // in minutes

		private const string SaveBind = "Save";
		private const string AbortSaveBind = "AbortSave";
		private const string DummyBind = "Dummy";

		private static System.Timers.Timer AutosaveTimer = new();

		private static CancellationTokenSource token = new();

		private static void PerformSave(string description)
		{
			Logger.Log($"{description} has been requested.", LogSeverity.Info);

			if (!Save.IsSaveInProgress)
			{
				token = new();
				World.SaveActiveWorld(description, token);
			}
			else
			{
				Logger.Log("Another save is already in progress. Canceling save.", LogSeverity.Warning);
				SoundPlayer.PlaySaveSound(SystemSounds.Hand);
			}
		}

		private static void AbortSave()
		{
			if (Save.IsSaveInProgress)
			{
				token.Cancel();
				Logger.Log("Save cancellation has been requested.", LogSeverity.Info);
			}
			else
			{
				Logger.Log("No pending save has been found.", LogSeverity.Info);
			}
		}

		private static void AutosaveTimer_Elapsed(object? sender, ElapsedEventArgs e)
			=> PerformSave(Save.AutosaveDescription);

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

			// Update the save key
			var saveKey = GetKeyFromString(Settings.Default.SaveHotkey);

			if (saveKey.IsErroneous)
				return false;
			
			if (saveKey.Key is null)  // The user has disabled manual save
				return true;

			if (IsHotkeyAvailable(saveKey.Key.Value))
			{
				HotkeyManager.Current.AddOrReplace(SaveBind, saveKey.Key.Value, (s, e) => PerformSave(Save.ManualSaveDescription));
				Logger.Log($"Successfully binded {saveKey.Key.Value} to 'manual save'.", LogSeverity.Info);
			}
			else
			{
				return false;
			}

			// Update the abort key
			var abortKey = GetKeyFromString(Settings.Default.AbortSaveHotkey);

			if (abortKey.IsErroneous)
				return false;

			if (abortKey.Key is null)
				return true;

			if (IsHotkeyAvailable(abortKey.Key.Value))
			{
				HotkeyManager.Current.AddOrReplace(AbortSaveBind, abortKey.Key.Value, (s, e) => AbortSave());
				Logger.Log($"Successfully binded {abortKey.Key.Value} to 'abort save'.", LogSeverity.Info);
			}
			else
			{
				return false;
			}

			return true;
		}

		public static void UpdateAutosaveTimer()
		{
			AutosaveTimer.Elapsed -= AutosaveTimer_Elapsed;
			AutosaveTimer.Stop();

			if (Settings.Default.EnableAutosave)
			{
				if (Settings.Default.AutosaveInterval <= 0)
				{
					Settings.Default.AutosaveInterval = DefaultAutosaveInterval;
					Logger.Log($"The auto-save interval was invalid and has been reset.", LogSeverity.Warning);
				}

				AutosaveTimer = new()
				{
					Interval = Settings.Default.AutosaveInterval * 60_000  // Convert minutes to milliseconds
				};

				AutosaveTimer.Elapsed += AutosaveTimer_Elapsed;
				AutosaveTimer.Start();

				Logger.Log($"Auto-save has been enabled (interval: {Settings.Default.AutosaveInterval} minutes).", LogSeverity.Info);
			}
			else
			{
				Logger.Log("Auto-save is disabled by the user.", LogSeverity.Info);
			}
		}

		public static void UnbindAll()
		{
			Logger.Log("All hotkeys have been unbinded.", LogSeverity.Info);

			HotkeyManager.Current.Remove(SaveBind);
			HotkeyManager.Current.Remove(AbortSaveBind);
		}

		public static (Keys? Key, bool IsErroneous) GetKeyFromString(string keyString)
		{
			if (keyString.Length > 0 && keyString != "None")
				return Enum.TryParse(keyString, true, out Keys key) ? (key, false) : (null, true);

			return (null, false);
		}
	}
}
