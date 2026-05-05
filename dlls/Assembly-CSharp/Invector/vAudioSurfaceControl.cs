using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Invector
{
	// Token: 0x0200033E RID: 830
	[RequireComponent(typeof(AudioSource))]
	public class vAudioSurfaceControl : MonoBehaviour
	{
		// Token: 0x06001112 RID: 4370 RVA: 0x0005CAD8 File Offset: 0x0005ACD8
		public void PlayOneShot(AudioClip clip, float volume)
		{
			if (!this.source)
			{
				this.source = base.GetComponent<AudioSource>();
			}
			this.source.volume = volume;
			this.source.PlayOneShot(clip, volume);
			this.isWorking = true;
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0005CB13 File Offset: 0x0005AD13
		private void Update()
		{
			if (this.isWorking && !this.source.isPlaying)
			{
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x1700033A RID: 826
		// (set) Token: 0x06001114 RID: 4372 RVA: 0x0005CB35 File Offset: 0x0005AD35
		public AudioMixerGroup outputAudioMixerGroup
		{
			set
			{
				if (!this.source)
				{
					this.source = base.GetComponent<AudioSource>();
				}
				this.source.outputAudioMixerGroup = value;
			}
		}

		// Token: 0x040016F6 RID: 5878
		private AudioSource source;

		// Token: 0x040016F7 RID: 5879
		private bool isWorking;
	}
}
