using SavepointManager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public static class SoundPlayer
	{
		public static void PlaySaveSound(SystemSound sound)
		{
			if (Settings.Default.UseSaveSounds)
				sound.Play();
		}
	}
}
