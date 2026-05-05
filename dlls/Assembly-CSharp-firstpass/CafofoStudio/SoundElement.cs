using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CafofoStudio
{
	// Token: 0x020001CF RID: 463
	[Serializable]
	public class SoundElement
	{
		// Token: 0x06000C4E RID: 3150 RVA: 0x0004C058 File Offset: 0x0004A258
		public void InitializeAudioSources(GameObject parent)
		{
			foreach (SoundSubElementLoop soundSubElementLoop in this.loopSubElements)
			{
				soundSubElementLoop.InitializeAudioSources(parent, this.overrideOutputMixer);
			}
			foreach (SoundSubElementSample soundSubElementSample in this.sampleSubElements)
			{
				soundSubElementSample.InitializeAudioSources(parent, this.overrideOutputMixer);
			}
			this.CalculateIntensity();
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x0004C0FC File Offset: 0x0004A2FC
		private void CalculateIntensity()
		{
			foreach (SoundSubElementLoop soundSubElementLoop in this.loopSubElements)
			{
				soundSubElementLoop.CalculateIntensity(this.intensity, this.volumeMultiplier);
			}
			foreach (SoundSubElementSample soundSubElementSample in this.sampleSubElements)
			{
				soundSubElementSample.CalculateIntensity(this.intensity, this.volumeMultiplier);
			}
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x0004C1A4 File Offset: 0x0004A3A4
		public void UpdateSampleTimer()
		{
			foreach (SoundSubElementSample soundSubElementSample in this.sampleSubElements)
			{
				soundSubElementSample.UpdateSampleTimer(this.intensity, this.volumeMultiplier);
			}
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x0004C200 File Offset: 0x0004A400
		public void SetIntensity(float intensity)
		{
			this.intensity = Mathf.Clamp01(intensity);
			this.CalculateIntensity();
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0004C214 File Offset: 0x0004A414
		public float GetIntensity()
		{
			return this.intensity;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x0004C21C File Offset: 0x0004A41C
		public void SetVolumeMultiplier(float volumeMultiplier)
		{
			this.volumeMultiplier = Mathf.Clamp01(volumeMultiplier);
			foreach (SoundSubElementLoop soundSubElementLoop in this.loopSubElements)
			{
				soundSubElementLoop.CalculateIntensity(this.intensity, this.volumeMultiplier);
			}
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x0004C284 File Offset: 0x0004A484
		public float GetVolumeMultiplier()
		{
			return this.volumeMultiplier;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0004C28C File Offset: 0x0004A48C
		public void SetOutputMixerGroup(AudioMixerGroup overrideOutputMixer)
		{
			this.overrideOutputMixer = overrideOutputMixer;
			foreach (SoundSubElementLoop soundSubElementLoop in this.loopSubElements)
			{
				soundSubElementLoop.SetOutputMixerGroup(overrideOutputMixer);
			}
			foreach (SoundSubElementSample soundSubElementSample in this.sampleSubElements)
			{
				soundSubElementSample.SetOutputMixerGroup(overrideOutputMixer);
			}
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0004C324 File Offset: 0x0004A524
		public AudioMixerGroup GetOutputMixerGroup()
		{
			return this.overrideOutputMixer;
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x0004C32C File Offset: 0x0004A52C
		public void Play()
		{
			foreach (SoundSubElementLoop soundSubElementLoop in this.loopSubElements)
			{
				soundSubElementLoop.Play();
			}
			foreach (SoundSubElementSample soundSubElementSample in this.sampleSubElements)
			{
				soundSubElementSample.Play();
			}
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x0004C3BC File Offset: 0x0004A5BC
		public void Stop()
		{
			foreach (SoundSubElementLoop soundSubElementLoop in this.loopSubElements)
			{
				soundSubElementLoop.Stop();
			}
			foreach (SoundSubElementSample soundSubElementSample in this.sampleSubElements)
			{
				soundSubElementSample.Stop();
			}
		}

		// Token: 0x04000CAB RID: 3243
		[SerializeField]
		private string soundName;

		// Token: 0x04000CAC RID: 3244
		[SerializeField]
		private AudioMixerGroup overrideOutputMixer;

		// Token: 0x04000CAD RID: 3245
		[SerializeField]
		private float intensity;

		// Token: 0x04000CAE RID: 3246
		[SerializeField]
		private string maxIntensityLabel;

		// Token: 0x04000CAF RID: 3247
		[SerializeField]
		private string minIntensityLabel;

		// Token: 0x04000CB0 RID: 3248
		[SerializeField]
		private float volumeMultiplier = 1f;

		// Token: 0x04000CB1 RID: 3249
		[SerializeField]
		private List<SoundSubElementSample> sampleSubElements;

		// Token: 0x04000CB2 RID: 3250
		[SerializeField]
		private List<SoundSubElementLoop> loopSubElements;
	}
}
