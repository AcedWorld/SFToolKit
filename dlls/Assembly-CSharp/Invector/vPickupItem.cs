using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000370 RID: 880
	public class vPickupItem : MonoBehaviour
	{
		// Token: 0x060011D6 RID: 4566 RVA: 0x0005F025 File Offset: 0x0005D225
		private void Start()
		{
			this._audioSource = base.GetComponent<AudioSource>();
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x0005F034 File Offset: 0x0005D234
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player") && !this._audioSource.isPlaying)
			{
				Renderer[] componentsInChildren = base.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = false;
				}
				this._audioSource.PlayOneShot(this._audioClip);
				Object.Destroy(base.gameObject, this._audioClip.length);
			}
		}

		// Token: 0x040017AF RID: 6063
		private AudioSource _audioSource;

		// Token: 0x040017B0 RID: 6064
		public AudioClip _audioClip;

		// Token: 0x040017B1 RID: 6065
		public GameObject _particle;
	}
}
