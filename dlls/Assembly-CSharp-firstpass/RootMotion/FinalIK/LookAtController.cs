using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000130 RID: 304
	public class LookAtController : MonoBehaviour
	{
		// Token: 0x060009BB RID: 2491 RVA: 0x0003CED7 File Offset: 0x0003B0D7
		private void Start()
		{
			this.lastPosition = this.ik.solver.IKPosition;
			this.dir = this.ik.solver.IKPosition - this.pivot;
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0003CF10 File Offset: 0x0003B110
		private void LateUpdate()
		{
			if (this.target != this.lastTarget)
			{
				if (this.lastTarget == null && this.target != null && this.ik.solver.IKPositionWeight <= 0f)
				{
					this.lastPosition = this.target.position;
					this.dir = this.target.position - this.pivot;
					this.ik.solver.IKPosition = this.target.position + this.offset;
				}
				else
				{
					this.lastPosition = this.ik.solver.IKPosition;
					this.dir = this.ik.solver.IKPosition - this.pivot;
				}
				this.switchWeight = 0f;
				this.lastTarget = this.target;
			}
			float num = (this.target != null) ? this.weight : 0f;
			this.ik.solver.IKPositionWeight = Mathf.SmoothDamp(this.ik.solver.IKPositionWeight, num, ref this.weightV, this.weightSmoothTime);
			if (this.ik.solver.IKPositionWeight >= 0.999f && num > this.ik.solver.IKPositionWeight)
			{
				this.ik.solver.IKPositionWeight = 1f;
			}
			if (this.ik.solver.IKPositionWeight <= 0.001f && num < this.ik.solver.IKPositionWeight)
			{
				this.ik.solver.IKPositionWeight = 0f;
			}
			if (this.ik.solver.IKPositionWeight <= 0f)
			{
				return;
			}
			this.switchWeight = Mathf.SmoothDamp(this.switchWeight, 1f, ref this.switchWeightV, this.targetSwitchSmoothTime);
			if (this.switchWeight >= 0.999f)
			{
				this.switchWeight = 1f;
			}
			if (this.target != null)
			{
				this.ik.solver.IKPosition = Vector3.Lerp(this.lastPosition, this.target.position + this.offset, this.switchWeight);
			}
			if (this.smoothTurnTowardsTarget != this.lastSmoothTowardsTarget)
			{
				this.dir = this.ik.solver.IKPosition - this.pivot;
				this.lastSmoothTowardsTarget = this.smoothTurnTowardsTarget;
			}
			if (this.smoothTurnTowardsTarget)
			{
				Vector3 b = this.ik.solver.IKPosition - this.pivot;
				this.dir = Vector3.Slerp(this.dir, b, Time.deltaTime * this.slerpSpeed);
				this.dir = Vector3.RotateTowards(this.dir, b, Time.deltaTime * this.maxRadiansDelta, this.maxMagnitudeDelta);
				this.ik.solver.IKPosition = this.pivot + this.dir;
			}
			this.ApplyMinDistance();
			this.RootRotation();
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060009BD RID: 2493 RVA: 0x0003D23A File Offset: 0x0003B43A
		private Vector3 pivot
		{
			get
			{
				return this.ik.transform.position + this.ik.transform.rotation * this.pivotOffsetFromRoot;
			}
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0003D26C File Offset: 0x0003B46C
		private void ApplyMinDistance()
		{
			Vector3 pivot = this.pivot;
			Vector3 b = this.ik.solver.IKPosition - pivot;
			b = b.normalized * Mathf.Max(b.magnitude, this.minDistance);
			this.ik.solver.IKPosition = pivot + b;
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0003D2D0 File Offset: 0x0003B4D0
		private void RootRotation()
		{
			float num = Mathf.Lerp(180f, this.maxRootAngle, this.ik.solver.IKPositionWeight);
			if (num < 180f)
			{
				Vector3 vector = Quaternion.Inverse(this.ik.transform.rotation) * (this.ik.solver.IKPosition - this.pivot);
				float num2 = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
				float angle = 0f;
				if (num2 > num)
				{
					angle = num2 - num;
				}
				if (num2 < -num)
				{
					angle = num2 + num;
				}
				this.ik.transform.rotation = Quaternion.AngleAxis(angle, this.ik.transform.up) * this.ik.transform.rotation;
			}
		}

		// Token: 0x040008F1 RID: 2289
		public LookAtIK ik;

		// Token: 0x040008F2 RID: 2290
		[Header("Target Smoothing")]
		[Tooltip("The target to look at. Do not use the Target transform that is assigned to LookAtIK. Set to null if you wish to stop looking.")]
		public Transform target;

		// Token: 0x040008F3 RID: 2291
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x040008F4 RID: 2292
		public Vector3 offset;

		// Token: 0x040008F5 RID: 2293
		[Tooltip("The time it takes to switch targets.")]
		public float targetSwitchSmoothTime = 0.3f;

		// Token: 0x040008F6 RID: 2294
		[Tooltip("The time it takes to blend in/out of LookAtIK weight.")]
		public float weightSmoothTime = 0.3f;

		// Token: 0x040008F7 RID: 2295
		[Header("Turning Towards The Target")]
		[Tooltip("Enables smooth turning towards the target according to the parameters under this header.")]
		public bool smoothTurnTowardsTarget = true;

		// Token: 0x040008F8 RID: 2296
		[Tooltip("Speed of turning towards the target using Vector3.RotateTowards.")]
		public float maxRadiansDelta = 3f;

		// Token: 0x040008F9 RID: 2297
		[Tooltip("Speed of moving towards the target using Vector3.RotateTowards.")]
		public float maxMagnitudeDelta = 3f;

		// Token: 0x040008FA RID: 2298
		[Tooltip("Speed of slerping towards the target.")]
		public float slerpSpeed = 3f;

		// Token: 0x040008FB RID: 2299
		[Tooltip("The position of the pivot that the look at target is rotated around relative to the root of the character.")]
		public Vector3 pivotOffsetFromRoot = Vector3.up;

		// Token: 0x040008FC RID: 2300
		[Tooltip("Minimum distance of looking from the first bone. Keeps the solver from failing if the target is too close.")]
		public float minDistance = 1f;

		// Token: 0x040008FD RID: 2301
		[Header("RootRotation")]
		[Tooltip("Character root will be rotate around the Y axis to keep root forward within this angle from the look direction.")]
		[Range(0f, 180f)]
		public float maxRootAngle = 45f;

		// Token: 0x040008FE RID: 2302
		private Transform lastTarget;

		// Token: 0x040008FF RID: 2303
		private float switchWeight;

		// Token: 0x04000900 RID: 2304
		private float switchWeightV;

		// Token: 0x04000901 RID: 2305
		private float weightV;

		// Token: 0x04000902 RID: 2306
		private Vector3 lastPosition;

		// Token: 0x04000903 RID: 2307
		private Vector3 dir;

		// Token: 0x04000904 RID: 2308
		private bool lastSmoothTowardsTarget;
	}
}
