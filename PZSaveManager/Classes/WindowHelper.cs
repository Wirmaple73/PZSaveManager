using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;

namespace PZSaveManager.Classes
{
	public static class WindowHelper
	{
		public static bool IsInForeground()
			=> Process.GetCurrentProcess().MainWindowHandle == NativeMethods.GetForegroundWindow();

		public static bool IsInForeground(string processName)
		{
			var processes = Process.GetProcessesByName(processName);
			return processes.Length > 0 && processes[0].MainWindowHandle == NativeMethods.GetForegroundWindow();
		}

		public static void FlashIfMinimized()
		{
			if (!IsInForeground())
			{
				SystemSounds.Beep.Play();
				NativeMethods.FlashWindow(Process.GetCurrentProcess().MainWindowHandle);
			}
		}

		public static class Buttons
		{
			public static void SetEnabled(IntPtr windowHandle, WindowButton button, bool enabled) =>
				NativeMethods.EnableMenuItem(NativeMethods.GetSystemMenu(windowHandle, false), (uint)button, enabled ? 0u : 1u);

			public static void DisableCloseButton(IntPtr windowHandle) => SetEnabled(windowHandle, WindowButton.Close, false);

			public enum WindowButton
			{
				Close = 0xF060,
				Maximize = 0xF030,
				Minimize = 0xF020
			}
		}

		public static class TaskbarProgress
		{
			private static readonly ITaskbarList3 Taskbar = (ITaskbarList3)new TaskbarInstance();

			private static int progress = 0;
			private static TaskbarState state = TaskbarState.Normal;

			static TaskbarProgress()
			{
				if (Environment.OSVersion.Version < new Version(6, 1))
					throw new PlatformNotSupportedException("Taskbar progress is not supported on operating systems older than Windows 7.");
			}

			public static TaskbarState State
			{
				get => state;
				set
				{
					state = value;
					Taskbar.SetProgressState(Process.GetCurrentProcess().MainWindowHandle, value);
				}
			}

			public static int Progress
			{
				get => progress;
				set
				{
					if (value < 0 || value > 100)
						throw new ArgumentOutOfRangeException(nameof(Progress));

					progress = value;

					if (State != TaskbarState.Normal)
						State = TaskbarState.Normal;

					Taskbar.SetProgressValue(Process.GetCurrentProcess().MainWindowHandle, (ulong)value, 100);
				}
			}

			public static void Finish()
			{
				Progress = 0;
				State = TaskbarState.NoProgress;
			}

			public enum TaskbarState
			{
				NoProgress = 0,
				Indeterminate = 0x1,
				Normal = 0x2,
				Error = 0x4,
				Paused = 0x8
			}

			#region COM interop
			[ComImport, Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
			private interface ITaskbarList3
			{
				void HrInit();
				void AddTab(IntPtr hwnd);
				void DeleteTab(IntPtr hwnd);
				void ActivateTab(IntPtr hwnd);
				void SetActiveAlt(IntPtr hwnd);

				void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

				void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);
				void SetProgressState(IntPtr hwnd, TaskbarState state);
			}

			[ComImport, Guid("56fdf344-fd6d-11d0-958a-006097c9a090"), ClassInterface(ClassInterfaceType.None)]
			private class TaskbarInstance { }
			#endregion
		}
	}
}
