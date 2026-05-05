using System;
using System.Collections.Generic;
using UnityEngine;

namespace CafofoStudio
{
	// Token: 0x020001CC RID: 460
	public abstract class AmbienceMixer<P> : MonoBehaviour where P : AmbientPreset
	{
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000C40 RID: 3136
		[SerializeField]
		protected abstract List<SoundElement> elements { get; }

		// Token: 0x06000C41 RID: 3137 RVA: 0x0004BEB8 File Offset: 0x0004A0B8
		private void OnEnable()
		{
			foreach (SoundElement soundElement in this.elements)
			{
				soundElement.InitializeAudioSources(base.gameObject);
			}
			if (this.playOnAwake)
			{
				this.Play();
			}
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x0004BF1C File Offset: 0x0004A11C
		private void Update()
		{
			foreach (SoundElement soundElement in this.elements)
			{
				soundElement.UpdateSampleTimer();
			}
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x0004BF6C File Offset: 0x0004A16C
		public void Play()
		{
			foreach (SoundElement soundElement in this.elements)
			{
				soundElement.Play();
			}
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x0004BFBC File Offset: 0x0004A1BC
		public void Stop()
		{
			foreach (SoundElement soundElement in this.elements)
			{
				soundElement.Stop();
			}
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x0004C00C File Offset: 0x0004A20C
		private void OnDisable()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				Object.Destroy(components[i]);
			}
		}

		// Token: 0x06000C46 RID: 3142
		public abstract void ApplyPreset(P selectedPreset);

		// Token: 0x04000CA8 RID: 3240
		public bool playOnAwake = true;

		// Token: 0x04000CA9 RID: 3241
		[SerializeField]
		public List<P> presets;
	}
}
