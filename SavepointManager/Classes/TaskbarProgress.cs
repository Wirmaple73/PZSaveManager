using System.Runtime.InteropServices;

namespace SavepointManager.Classes
{
	// Snatched from https://stackoverflow.com/a/24187171/18954775
	public class TaskbarProgressReporter
	{
		private static readonly ITaskbarList3 Taskbar = (ITaskbarList3)new TaskbarInstance();
		// private static readonly bool IsTaskbarSupported = Environment.OSVersion.Version >= new Version(6, 1);

		private int progress;
		private TaskbarStates state;

		public IntPtr WindowHandle { get; init; }

		public TaskbarStates State
		{
			get => state;
			set
			{
				state = value;
				Taskbar.SetProgressState(WindowHandle, value);
			}
		}

		public int Progress
		{
			get => progress;
			set
			{
				if (progress < 0 || progress > 100)
					throw new ArgumentOutOfRangeException(nameof(Progress), "Progress must be between 0 and 100, inclusive.");

				progress = value;
				Taskbar.SetProgressValue(WindowHandle, (ulong)value, 100);
			}
		}

		public TaskbarProgressReporter(IntPtr windowHandle) => WindowHandle = windowHandle;

		public enum TaskbarStates
		{
			NoProgress = 0,
			Indeterminate = 0x1,
			Normal = 0x2,
			Error = 0x4,
			Paused = 0x8
		}

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
			void SetProgressState(IntPtr hwnd, TaskbarStates state);
		}

		[ComImport()]
		[Guid("56fdf344-fd6d-11d0-958a-006097c9a090")]
		[ClassInterface(ClassInterfaceType.None)]
		private class TaskbarInstance
		{
		}
	}
}
