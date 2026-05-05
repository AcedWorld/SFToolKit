using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000152 RID: 338
	public class MechSpiderParticles : MonoBehaviour
	{
		// Token: 0x06000A54 RID: 2644 RVA: 0x0004196F File Offset: 0x0003FB6F
		private void Start()
		{
			this.particles = (ParticleSystem)base.GetComponent(typeof(ParticleSystem));
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0004198C File Offset: 0x0003FB8C
		private void Update()
		{
			float magnitude = this.mechSpiderController.inputVector.magnitude;
			float constant = Mathf.Clamp(magnitude * 50f, 30f, 50f);
			this.particles.emission.rateOverTime = new ParticleSystem.MinMaxCurve(constant);
			this.particles.main.startColor = new Color(this.particles.main.startColor.color.r, this.particles.main.startColor.color.g, this.particles.main.startColor.color.b, Mathf.Clamp(magnitude, 0.4f, 1f));
		}

		// Token: 0x040009E2 RID: 2530
		public MechSpiderController mechSpiderController;

		// Token: 0x040009E3 RID: 2531
		private ParticleSystem particles;
	}
}
