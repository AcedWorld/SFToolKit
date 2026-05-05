using System;
using UnityEngine;
using UnityEngine.Audio;

namespace CafofoStudio
{
	// Token: 0x020001CE RID: 462
	public interface ISoundSubElement
	{
		// Token: 0x06000C49 RID: 3145
		void InitializeAudioSources(GameObject parent, AudioMixerGroup outputMixer);

		// Token: 0x06000C4A RID: 3146
		void CalculateIntensity(float intensity, float volumeMultiplier);

		// Token: 0x06000C4B RID: 3147
		void SetOutputMixerGroup(AudioMixerGroup overrideOutputMixer);

		// Token: 0x06000C4C RID: 3148
		void Play();

		// Token: 0x06000C4D RID: 3149
		void Stop();
	}
}
