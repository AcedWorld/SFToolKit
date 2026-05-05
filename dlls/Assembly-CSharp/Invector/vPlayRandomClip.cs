using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000397 RID: 919
	[RequireComponent(typeof(AudioSource))]
	public class vPlayRandomClip : MonoBehaviour
	{
		// Token: 0x06001285 RID: 4741 RVA: 0x00061CC8 File Offset: 0x0005FEC8
		private void Start()
		{
			if (!this.audioSource)
			{
				this.audioSource = base.GetComponent<AudioSource>();
			}
			Random.InitState(Random.Range(0, DateTime.Now.Millisecond));
			if (this.playOnStart)
			{
				this.Play();
			}
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x00061D14 File Offset: 0x0005FF14
		public void Play()
		{
			if (this.audioSource)
			{
				int num = Random.Range(0, this.clips.Length - 1);
				if (this.clips.Length != 0)
				{
					this.audioSource.PlayOneShot(this.clips[num]);
				}
			}
		}

		// Token: 0x04001838 RID: 6200
		public AudioClip[] clips;

		// Token: 0x04001839 RID: 6201
		public AudioSource audioSource;

		// Token: 0x0400183A RID: 6202
		public bool playOnStart = true;
	}
}
