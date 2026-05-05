using System;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002C0 RID: 704
	[AddComponentMenu("")]
	public class Bullet : MonoBehaviour
	{
		// Token: 0x06000EE8 RID: 3816 RVA: 0x0004FF24 File Offset: 0x0004E124
		private void Start()
		{
			if (this.lifeTime > 0f)
			{
				this.deathTime = Time.time + this.lifeTime;
				this.die = true;
			}
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x0004FF4C File Offset: 0x0004E14C
		private void Update()
		{
			if (this.die && Time.time >= this.deathTime)
			{
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x0400137E RID: 4990
		public float lifeTime = 3f;

		// Token: 0x0400137F RID: 4991
		private bool die;

		// Token: 0x04001380 RID: 4992
		private float deathTime;
	}
}
