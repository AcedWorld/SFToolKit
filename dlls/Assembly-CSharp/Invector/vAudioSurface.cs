using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Invector
{
	// Token: 0x0200033D RID: 829
	public class vAudioSurface : ScriptableObject
	{
		// Token: 0x0600110D RID: 4365 RVA: 0x0005C887 File Offset: 0x0005AA87
		public vAudioSurface()
		{
			this.audioClips = new List<AudioClip>();
			this.TextureOrMaterialNames = new List<string>();
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x0005C8BC File Offset: 0x0005AABC
		public virtual void SpawnSurfaceEffect(FootStepObject footStepObject)
		{
			if (this.randomSource == null)
			{
				this.randomSource = new vFisherYatesRandom();
			}
			if (footStepObject.spawnSoundEffect)
			{
				this.PlaySound(footStepObject);
			}
			if (footStepObject.spawnParticleEffect && this.particleObject && footStepObject.ground && this.stepLayer.ContainsLayer(footStepObject.ground.gameObject.layer))
			{
				this.SpawnParticle(footStepObject);
			}
			if (footStepObject.spawnStepMarkEffect && this.useStepMark)
			{
				this.StepMark(footStepObject);
			}
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x0005C948 File Offset: 0x0005AB48
		protected virtual void PlaySound(FootStepObject footStepObject)
		{
			if (this.audioClips == null || this.audioClips.Count == 0)
			{
				return;
			}
			AudioSource audioSource = null;
			if (this.audioSource != null)
			{
				audioSource = Object.Instantiate<AudioSource>(this.audioSource, footStepObject.sender.position, Quaternion.identity);
			}
			if (this.audioSource && this.audioMixerGroup != null)
			{
				audioSource.outputAudioMixerGroup = this.audioMixerGroup;
			}
			int index = this.randomSource.Next(this.audioClips.Count);
			audioSource.PlayOneShot(this.audioClips[index], footStepObject.volume);
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x0005C9ED File Offset: 0x0005ABED
		protected virtual void SpawnParticle(FootStepObject footStepObject)
		{
			Object.Instantiate<GameObject>(this.particleObject, footStepObject.sender.position, footStepObject.sender.rotation).transform.SetParent(vObjectContainer.root, true);
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x0005CA20 File Offset: 0x0005AC20
		protected virtual void StepMark(FootStepObject footStep)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(footStep.sender.transform.position + new Vector3(0f, 0.25f, 0f), Vector3.down, out raycastHit, 1f, this.stepLayer) && this.stepMark)
			{
				Quaternion lhs = Quaternion.FromToRotation(footStep.sender.up, raycastHit.normal);
				GameObject gameObject = Object.Instantiate<GameObject>(this.stepMark, raycastHit.point, lhs * footStep.sender.rotation);
				gameObject.transform.SetParent(vObjectContainer.root, true);
				Object.Destroy(gameObject, this.timeToDestroy);
			}
		}

		// Token: 0x040016EC RID: 5868
		public AudioSource audioSource;

		// Token: 0x040016ED RID: 5869
		public AudioMixerGroup audioMixerGroup;

		// Token: 0x040016EE RID: 5870
		public List<string> TextureOrMaterialNames;

		// Token: 0x040016EF RID: 5871
		public List<AudioClip> audioClips;

		// Token: 0x040016F0 RID: 5872
		public GameObject particleObject;

		// Token: 0x040016F1 RID: 5873
		private vFisherYatesRandom randomSource = new vFisherYatesRandom();

		// Token: 0x040016F2 RID: 5874
		public bool useStepMark;

		// Token: 0x040016F3 RID: 5875
		[vHideInInspector("useStepMark", false)]
		public GameObject stepMark;

		// Token: 0x040016F4 RID: 5876
		[vHideInInspector("useStepMark", false)]
		public LayerMask stepLayer;

		// Token: 0x040016F5 RID: 5877
		[vHideInInspector("useStepMark", false)]
		public float timeToDestroy = 5f;
	}
}
