using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001A6 RID: 422
	public class PlanetaryGravity : MonoBehaviour
	{
		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0004828F File Offset: 0x0004648F
		private Rigidbody r
		{
			get
			{
				if (this._r == null)
				{
					this._r = base.GetComponent<Rigidbody>();
				}
				return this._r;
			}
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x000482B1 File Offset: 0x000464B1
		private void FixedUpdate()
		{
			if (this.r != null && this.r.gameObject.activeInHierarchy && !this.r.isKinematic)
			{
				this.ApplyGravity(this.r);
			}
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x000482EC File Offset: 0x000464EC
		private void ApplyGravity(Rigidbody r)
		{
			r.useGravity = false;
			Vector3 a = this.planet.transform.position - r.position;
			float sqrMagnitude = a.sqrMagnitude;
			float d = Mathf.Sqrt(sqrMagnitude);
			r.AddForce(a / d * 6.672E-11f * (this.planet.mass / sqrMagnitude) * Time.fixedDeltaTime, ForceMode.VelocityChange);
		}

		// Token: 0x04000B93 RID: 2963
		public Planet planet;

		// Token: 0x04000B94 RID: 2964
		private const float G = 6.672E-11f;

		// Token: 0x04000B95 RID: 2965
		private Rigidbody _r;
	}
}
