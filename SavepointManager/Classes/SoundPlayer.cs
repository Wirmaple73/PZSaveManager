using NAudio.Wave;
using SavepointManager.Properties;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public class SoundPlayer : IDisposable
	{
		public const int MaxVolume = 100;
		public static readonly SoundPlayer Shared = new();

		public bool IsPlaybackAllowed { get; set; } = true;

		private readonly object playerLock = new();
		private readonly WaveOutEvent OutputDevice = new();

		private WaveFileReader? reader;
		private WaveChannel32? volumeProvider;
		private bool disposed = false;

		public SoundPlayer() => OutputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;

		public void PlaySaveEffect(SoundEffect effect) => PlaySaveEffect(effect, Settings.Default.SoundVolume);

		public void PlaySaveEffect(SoundEffect effect, int volume)
		{
			if (Settings.Default.UseSaveSounds)
				Play(effect, volume);
		}

		public void Play(SoundEffect effect) => Play(effect, Settings.Default.SoundVolume);

		public void Play(SoundEffect effect, int volume)
		{
			lock (playerLock)
			{
				if (!IsPlaybackAllowed)
					return;

				if (volume < 0 || volume > MaxVolume)
					throw new ArgumentOutOfRangeException(nameof(volume), $"Volume must be between 0 and {MaxVolume}, inclusive.");

				OutputDevice.Stop();

				var stream = effect switch
				{
					SoundEffect.Saving => Resources.Saving,
					SoundEffect.AlreadySaving => Resources.AlreadySaving,
					SoundEffect.SaveCanceled => Resources.SaveCanceled,
					SoundEffect.SaveNotCanceled => Resources.SaveNotCanceled,
					SoundEffect.SaveComplete => Resources.SaveComplete,
					SoundEffect.SaveFailure => Resources.SaveFailure,
					SoundEffect.Spam1 => Resources.Spam1,
					SoundEffect.Spam2 => Resources.Spam2,
					SoundEffect.Spam3 => Resources.Spam3,
					SoundEffect.Spam4 => Resources.Spam4,
					SoundEffect.Spam5 => Resources.Spam5,
					SoundEffect.Spam6 => Resources.Spam6,
					_ => throw new ArgumentOutOfRangeException(nameof(effect), "The specified sound effect could not be resolved.")
				};

				reader = new WaveFileReader(stream);
				volumeProvider = new WaveChannel32(reader) { Volume = volume / 100.0f };

				OutputDevice.Init(volumeProvider);
				OutputDevice.Play();
			}
		}

		public void Stop()
		{
			lock (playerLock)
				OutputDevice.Stop();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				OutputDevice.PlaybackStopped -= OutputDevice_PlaybackStopped;

				OutputDevice.Stop();
				OutputDevice.Dispose();

				reader?.Dispose();
				reader = null;

				volumeProvider?.Dispose();
				volumeProvider = null;
			}

			disposed = true;
		}

		private void OutputDevice_PlaybackStopped(object? sender, StoppedEventArgs e) => PlaybackStopped?.Invoke(this, e);

		public event EventHandler<StoppedEventArgs>? PlaybackStopped;

		~SoundPlayer() => Dispose(false);
	}
}
