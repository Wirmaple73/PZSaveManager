using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public static class WindowHelper
	{
		// Snatched from https://stackoverflow.com/a/24187171/18954775
		public static class TaskbarProgress
		{
			private static readonly ITaskbarList3 Taskbar = (ITaskbarList3)new TaskbarInstance();
			private static readonly bool IsUserInTheStoneAge = Environment.OSVersion.Version < new Version(6, 1);

			private static int progress = 0;
			private static TaskbarState state = TaskbarState.Normal;

			public static TaskbarState State
			{
				get => state;
				set
				{
					if (IsUserInTheStoneAge)
						return;

					state = value;
					Taskbar.SetProgressState(Process.GetCurrentProcess().MainWindowHandle, value);
				}
			}

			public static int Progress
			{
				get => progress;
				set
				{
					if (IsUserInTheStoneAge)
						return;

					if (progress < 0 || progress > 100)
						throw new ArgumentOutOfRangeException(nameof(Progress), "Progress must be between 0 and 100, inclusive.");

					if (State != TaskbarState.Normal)
						State = TaskbarState.Normal;

					progress = value;
					Taskbar.SetProgressValue(Process.GetCurrentProcess().MainWindowHandle, (ulong)value, 100);
				}
			}

			public static void FinishProgress()
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

			#region P/Invoke boilerplate
			[ComImport()]
			[Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
			[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
			private interface ITaskbarList3
			{
				// ITaskbarList
				[PreserveSig]
				void HrInit();
				[PreserveSig]
				void AddTab(IntPtr hwnd);
				[PreserveSig]
				void DeleteTab(IntPtr hwnd);
				[PreserveSig]
				void ActivateTab(IntPtr hwnd);
				[PreserveSig]
				void SetActiveAlt(IntPtr hwnd);

				// ITaskbarList2
				[PreserveSig]
				void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

				// ITaskbarList3
				[PreserveSig]
				void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);
				[PreserveSig]
				void SetProgressState(IntPtr hwnd, TaskbarState state);
			}

			[ComImport()]
			[Guid("56fdf344-fd6d-11d0-958a-006097c9a090")]
			[ClassInterface(ClassInterfaceType.None)]
			private class TaskbarInstance
			{
			}
			#endregion
		}

		public static bool IsInForeground()
			=> Process.GetCurrentProcess().MainWindowHandle == GetForegroundWindow();

		public static bool IsInForeground(string processName)
		{
			var processes = Process.GetProcessesByName(processName);
			return processes.Length > 0 && processes[0].MainWindowHandle == GetForegroundWindow();
		}

		public static void FlashIfMinimized()
		{
			if (!IsInForeground())
			{
				SystemSounds.Beep.Play();
				FlashWindowEx(ref FlashInfo);
			}
		}

		#region More P/Invoke boilerplate
		private static FLASHWINFO FlashInfo = new()
		{
			cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO))),
			hwnd = Process.GetCurrentProcess().MainWindowHandle,
			dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG,
			uCount = uint.MaxValue,
			dwTimeout = 0
		};

		[StructLayout(LayoutKind.Sequential)]
		private struct FLASHWINFO
		{
			public uint cbSize;
			public IntPtr hwnd;
			public uint dwFlags;
			public uint uCount;
			public uint dwTimeout;
		}

		[DllImport("user32.dll")]
		private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		private const uint FLASHW_ALL = 3;         // Flash both caption and taskbar button
		private const uint FLASHW_TIMERNOFG = 12;  // Flash until window comes to foreground
		#endregion
	}
}
