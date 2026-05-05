using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CafofoStudio
{
	// Token: 0x020001D0 RID: 464
	[Serializable]
	public class SoundSubElementLoop : ISoundSubElement
	{
		// Token: 0x06000C5A RID: 3162 RVA: 0x0004C460 File Offset: 0x0004A660
		public void InitializeAudioSources(GameObject parent, AudioMixerGroup outputMixer)
		{
			this.loopAudioSources = new List<AudioSource>();
			foreach (AudioClip clip in this.audioClips)
			{
				AudioSource audioSource = parent.AddComponent<AudioSource>();
				audioSource.clip = clip;
				audioSource.loop = true;
				audioSource.playOnAwake = false;
				audioSource.outputAudioMixerGroup = outputMixer;
				this.loopAudioSources.Add(audioSource);
			}
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0004C4E8 File Offset: 0x0004A6E8
		public void CalculateIntensity(float intensity, float volumeMultiplier)
		{
			float num = intensity * (float)this.loopAudioSources.Count;
			for (int i = 0; i < this.loopAudioSources.Count; i++)
			{
				this.loopAudioSources[i].volume = Mathf.Clamp01(num - (float)i) * volumeMultiplier;
			}
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x0004C538 File Offset: 0x0004A738
		public void SetOutputMixerGroup(AudioMixerGroup overrideOutputMixer)
		{
			if (this.loopAudioSources != null)
			{
				for (int i = 0; i < this.loopAudioSources.Count; i++)
				{
					this.loopAudioSources[i].outputAudioMixerGroup = overrideOutputMixer;
				}
			}
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x0004C578 File Offset: 0x0004A778
		public void Play()
		{
			if (this.loopAudioSources != null)
			{
				foreach (AudioSource audioSource in this.loopAudioSources)
				{
					audioSource.Play();
				}
			}
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x0004C5D0 File Offset: 0x0004A7D0
		public void Stop()
		{
			if (this.loopAudioSources != null)
			{
				foreach (AudioSource audioSource in this.loopAudioSources)
				{
					audioSource.Stop();
				}
			}
		}

		// Token: 0x04000CB3 RID: 3251
		[SerializeField]
		private List<AudioClip> audioClips;

		// Token: 0x04000CB4 RID: 3252
		private List<AudioSource> loopAudioSources;
	}
}
