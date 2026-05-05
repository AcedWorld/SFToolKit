using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200014E RID: 334
	public class MechSpider : MonoBehaviour
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00040CC8 File Offset: 0x0003EEC8
		// (set) Token: 0x06000A3A RID: 2618 RVA: 0x00040CD0 File Offset: 0x0003EED0
		public Vector3 velocity { get; private set; }

		// Token: 0x06000A3B RID: 2619 RVA: 0x00040CD9 File Offset: 0x0003EED9
		private void Start()
		{
			this.lastPosition = base.transform.position;
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00040CEC File Offset: 0x0003EEEC
		private void Update()
		{
			this.velocity = (base.transform.position - this.lastPosition) / Time.deltaTime;
			this.lastPosition = base.transform.position;
			Vector3 legsPlaneNormal = this.GetLegsPlaneNormal();
			Quaternion lhs = Quaternion.FromToRotation(base.transform.up, legsPlaneNormal);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, lhs * base.transform.rotation, Time.deltaTime * this.rootRotationSpeed);
			Vector3 a = Vector3.Project(this.GetLegCentroid() + base.transform.up * this.height * this.scale - base.transform.position, base.transform.up);
			base.transform.position += a * Time.deltaTime * (this.rootPositionSpeed * this.scale);
			if (Physics.Raycast(base.transform.position + base.transform.up * this.raycastHeight * this.scale, -base.transform.up, out this.rootHit, this.raycastHeight * this.scale + this.raycastDistance * this.scale, this.raycastLayers))
			{
				this.rootHit.distance = this.rootHit.distance - (this.raycastHeight * this.scale + this.minHeight * this.scale);
				if (this.rootHit.distance < 0f)
				{
					Vector3 b = base.transform.position - base.transform.up * this.rootHit.distance;
					base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * this.rootPositionSpeed * this.scale);
				}
			}
			this.sine += Time.deltaTime * this.breatheSpeed;
			if (this.sine >= 6.2831855f)
			{
				this.sine -= 6.2831855f;
			}
			float d = Mathf.Sin(this.sine) * this.breatheMagnitude * this.scale;
			Vector3 b2 = base.transform.up * d;
			this.body.transform.position = base.transform.position + b2;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00040F9C File Offset: 0x0003F19C
		private Vector3 GetLegCentroid()
		{
			Vector3 vector = Vector3.zero;
			float d = 1f / (float)this.legs.Length;
			for (int i = 0; i < this.legs.Length; i++)
			{
				vector += this.legs[i].position * d;
			}
			return vector;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00040FF0 File Offset: 0x0003F1F0
		private Vector3 GetLegsPlaneNormal()
		{
			Vector3 vector = base.transform.up;
			if (this.legRotationWeight <= 0f)
			{
				return vector;
			}
			float t = 1f / Mathf.Lerp((float)this.legs.Length, 1f, this.legRotationWeight);
			for (int i = 0; i < this.legs.Length; i++)
			{
				Vector3 vector2 = this.legs[i].position - (base.transform.position - base.transform.up * this.height * this.scale);
				Vector3 up = base.transform.up;
				Vector3 fromDirection = vector2;
				Vector3.OrthoNormalize(ref up, ref fromDirection);
				Quaternion quaternion = Quaternion.FromToRotation(fromDirection, vector2);
				quaternion = Quaternion.Lerp(Quaternion.identity, quaternion, t);
				vector = quaternion * vector;
			}
			return vector;
		}

		// Token: 0x040009B1 RID: 2481
		public LayerMask raycastLayers;

		// Token: 0x040009B2 RID: 2482
		public float scale = 1f;

		// Token: 0x040009B3 RID: 2483
		public Transform body;

		// Token: 0x040009B4 RID: 2484
		public MechSpiderLeg[] legs;

		// Token: 0x040009B5 RID: 2485
		public float legRotationWeight = 1f;

		// Token: 0x040009B6 RID: 2486
		public float rootPositionSpeed = 5f;

		// Token: 0x040009B7 RID: 2487
		public float rootRotationSpeed = 30f;

		// Token: 0x040009B8 RID: 2488
		public float breatheSpeed = 2f;

		// Token: 0x040009B9 RID: 2489
		public float breatheMagnitude = 0.2f;

		// Token: 0x040009BA RID: 2490
		public float height = 3.5f;

		// Token: 0x040009BB RID: 2491
		public float minHeight = 2f;

		// Token: 0x040009BC RID: 2492
		public float raycastHeight = 10f;

		// Token: 0x040009BD RID: 2493
		public float raycastDistance = 5f;

		// Token: 0x040009BF RID: 2495
		private Vector3 lastPosition;

		// Token: 0x040009C0 RID: 2496
		private Vector3 defaultBodyLocalPosition;

		// Token: 0x040009C1 RID: 2497
		private float sine;

		// Token: 0x040009C2 RID: 2498
		private RaycastHit rootHit;
	}
}
