using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CafofoStudio
{
	// Token: 0x020001D1 RID: 465
	[Serializable]
	public class SoundSubElementSample : ISoundSubElement
	{
		// Token: 0x06000C60 RID: 3168 RVA: 0x0004C628 File Offset: 0x0004A828
		public void InitializeAudioSources(GameObject parent, AudioMixerGroup outputMixer)
		{
			this.mParentGO = parent;
			this.mOutputMixer = outputMixer;
			this.audioSourcePool = new List<AudioSource>();
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x0004C644 File Offset: 0x0004A844
		public void CalculateIntensity(float intensity, float volumeMultiplier)
		{
			float num = Mathf.Lerp(this.minSampleFrequency, this.maxSampleFrequency, intensity);
			float num2 = Mathf.Lerp(this.minSampleFrequency + this.minSampleFrequencyDelta, this.maxSampleFrequency + this.maxSampleFrequencyDelta, intensity);
			float num3 = Random.Range(1f / num, 1f / num2);
			this.nextSampleCountdown = num3;
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x0004C6A0 File Offset: 0x0004A8A0
		public void UpdateSampleTimer(float intensity, float volumeMultiplier)
		{
			if (this.isPlaying && intensity > 0f)
			{
				this.nextSampleCountdown -= Time.deltaTime;
				if (this.nextSampleCountdown <= 0f)
				{
					this.PlayAnySample(volumeMultiplier);
					this.CalculateIntensity(intensity, volumeMultiplier);
				}
			}
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x0004C6E0 File Offset: 0x0004A8E0
		private void PlayAnySample(float volumeMultiplier)
		{
			AudioSource audioSource = this.GetAudioSource();
			audioSource.panStereo = Random.Range(-1f, 1f);
			audioSource.clip = this.audioClips[Random.Range(0, this.audioClips.Count)];
			audioSource.volume = Random.Range(0.2f, 1f) * volumeMultiplier;
			audioSource.Play();
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0004C748 File Offset: 0x0004A948
		private AudioSource GetAudioSource()
		{
			int num = 0;
			foreach (AudioSource audioSource in this.audioSourcePool)
			{
				if (!audioSource.isPlaying)
				{
					this.audioSourcePool.RemoveAt(num);
					this.audioSourcePool.Add(audioSource);
					return audioSource;
				}
				num++;
			}
			AudioSource audioSource2 = this.mParentGO.AddComponent<AudioSource>();
			audioSource2.outputAudioMixerGroup = this.mOutputMixer;
			audioSource2.playOnAwake = false;
			this.audioSourcePool.Add(audioSource2);
			return audioSource2;
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x0004C7F0 File Offset: 0x0004A9F0
		public void SetOutputMixerGroup(AudioMixerGroup overrideOutputMixer)
		{
			this.mOutputMixer = overrideOutputMixer;
			foreach (AudioSource audioSource in this.audioSourcePool)
			{
				audioSource.outputAudioMixerGroup = overrideOutputMixer;
			}
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0004C848 File Offset: 0x0004AA48
		public void Play()
		{
			this.isPlaying = true;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0004C851 File Offset: 0x0004AA51
		public void Stop()
		{
			this.isPlaying = false;
		}

		// Token: 0x04000CB5 RID: 3253
		[SerializeField]
		private List<AudioClip> audioClips;

		// Token: 0x04000CB6 RID: 3254
		[Tooltip("How many times per second a sample should play at most")]
		public float maxSampleFrequency;

		// Token: 0x04000CB7 RID: 3255
		[Tooltip("How much the max frequency can randomize.")]
		public float maxSampleFrequencyDelta;

		// Token: 0x04000CB8 RID: 3256
		[Tooltip("How many times per second a sample should play at least.")]
		public float minSampleFrequency;

		// Token: 0x04000CB9 RID: 3257
		[Tooltip("How much the min frequency can randomize.")]
		public float minSampleFrequencyDelta;

		// Token: 0x04000CBA RID: 3258
		private float nextSampleCountdown;

		// Token: 0x04000CBB RID: 3259
		private List<AudioSource> audioSourcePool;

		// Token: 0x04000CBC RID: 3260
		private bool isPlaying;

		// Token: 0x04000CBD RID: 3261
		private GameObject mParentGO;

		// Token: 0x04000CBE RID: 3262
		private AudioMixerGroup mOutputMixer;
	}
}
