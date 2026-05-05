using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200013B RID: 315
	public class Recoil : OffsetModifier
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060009EC RID: 2540 RVA: 0x0003DC97 File Offset: 0x0003BE97
		public bool isFinished
		{
			get
			{
				return Time.time > this.endTime;
			}
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0003DCA6 File Offset: 0x0003BEA6
		public void SetHandRotations(Quaternion leftHandRotation, Quaternion rightHandRotation)
		{
			if (this.handedness == Recoil.Handedness.Left)
			{
				this.primaryHandRotation = leftHandRotation;
			}
			else
			{
				this.primaryHandRotation = rightHandRotation;
			}
			this.handRotationsSet = true;
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0003DCC8 File Offset: 0x0003BEC8
		public void Fire(float magnitude)
		{
			float num = magnitude * Random.value * this.magnitudeRandom;
			this.magnitudeMlp = magnitude + num;
			this.randomRotation = Quaternion.Euler(this.rotationRandom * Random.value);
			Recoil.RecoilOffset[] array = this.offsets;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Start();
			}
			if (Time.time < this.endTime)
			{
				this.blendWeight = 0f;
			}
			else
			{
				this.blendWeight = 1f;
			}
			Keyframe[] keys = this.recoilWeight.keys;
			this.length = keys[keys.Length - 1].time;
			this.endTime = Time.time + this.length;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0003DD80 File Offset: 0x0003BF80
		protected override void OnModifyOffset()
		{
			if (this.aimIK != null)
			{
				this.aimIKAxis = this.aimIK.solver.axis;
			}
			if (!this.initiated && this.ik != null)
			{
				this.initiated = true;
				if (this.headIK != null)
				{
					this.headIK.enabled = false;
				}
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterFBBIK));
				if (this.aimIK != null)
				{
					IKSolverAim solver2 = this.aimIK.solver;
					solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterAimIK));
				}
			}
			if (Time.time >= this.endTime)
			{
				this.rotationOffset = Quaternion.identity;
				return;
			}
			this.blendTime = Mathf.Max(this.blendTime, 0f);
			if (this.blendTime > 0f)
			{
				this.blendWeight = Mathf.Min(this.blendWeight + Time.deltaTime * (1f / this.blendTime), 1f);
			}
			else
			{
				this.blendWeight = 1f;
			}
			float b = this.recoilWeight.Evaluate(this.length - (this.endTime - Time.time)) * this.magnitudeMlp;
			this.w = Mathf.Lerp(this.w, b, this.blendWeight);
			Quaternion quaternion = (this.aimIK != null && this.aimIK.solver.transform != null && !this.aimIKSolvedLast) ? Quaternion.LookRotation(this.aimIK.solver.IKPosition - this.aimIK.solver.transform.position, this.ik.references.root.up) : this.ik.references.root.rotation;
			quaternion = this.randomRotation * quaternion;
			Recoil.RecoilOffset[] array = this.offsets;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Apply(this.ik.solver, quaternion, this.w, this.length, this.endTime - Time.time);
			}
			if (!this.handRotationsSet)
			{
				this.primaryHandRotation = this.primaryHand.rotation;
			}
			this.handRotationsSet = false;
			this.rotationOffset = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(this.randomRotation * this.primaryHandRotation * this.handRotationOffset), this.w);
			this.handRotation = this.rotationOffset * this.primaryHandRotation;
			if (this.twoHanded)
			{
				Vector3 point = Quaternion.Inverse(this.primaryHand.rotation) * (this.secondaryHand.position - this.primaryHand.position);
				this.secondaryHandRelativeRotation = Quaternion.Inverse(this.primaryHand.rotation) * this.secondaryHand.rotation;
				Vector3 a = this.primaryHand.position + this.primaryHandEffector.positionOffset + this.handRotation * point;
				this.secondaryHandEffector.positionOffset += a - (this.secondaryHand.position + this.secondaryHandEffector.positionOffset);
			}
			if (this.aimIK != null && this.aimIKSolvedLast)
			{
				this.aimIK.solver.axis = Quaternion.Inverse(this.ik.references.root.rotation) * Quaternion.Inverse(this.rotationOffset) * this.aimIKAxis;
			}
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0003E170 File Offset: 0x0003C370
		private void AfterFBBIK()
		{
			if (Time.time < this.endTime)
			{
				this.primaryHand.rotation = this.handRotation;
				if (this.twoHanded)
				{
					this.secondaryHand.rotation = this.primaryHand.rotation * this.secondaryHandRelativeRotation;
				}
			}
			if (!this.aimIKSolvedLast && this.headIK != null)
			{
				this.headIK.solver.Update();
			}
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0003E1EC File Offset: 0x0003C3EC
		private void AfterAimIK()
		{
			if (this.aimIKSolvedLast)
			{
				this.aimIK.solver.axis = this.aimIKAxis;
			}
			if (this.aimIKSolvedLast && this.headIK != null)
			{
				this.headIK.solver.Update();
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x0003E23D File Offset: 0x0003C43D
		private IKEffector primaryHandEffector
		{
			get
			{
				if (this.handedness == Recoil.Handedness.Right)
				{
					return this.ik.solver.rightHandEffector;
				}
				return this.ik.solver.leftHandEffector;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x0003E268 File Offset: 0x0003C468
		private IKEffector secondaryHandEffector
		{
			get
			{
				if (this.handedness == Recoil.Handedness.Right)
				{
					return this.ik.solver.leftHandEffector;
				}
				return this.ik.solver.rightHandEffector;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x0003E293 File Offset: 0x0003C493
		private Transform primaryHand
		{
			get
			{
				return this.primaryHandEffector.bone;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x0003E2A0 File Offset: 0x0003C4A0
		private Transform secondaryHand
		{
			get
			{
				return this.secondaryHandEffector.bone;
			}
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x0003E2B0 File Offset: 0x0003C4B0
		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (this.ik != null && this.initiated)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterFBBIK));
				if (this.aimIK != null)
				{
					IKSolverAim solver2 = this.aimIK.solver;
					solver2.OnPostUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver2.OnPostUpdate, new IKSolver.UpdateDelegate(this.AfterAimIK));
				}
			}
		}

		// Token: 0x0400092E RID: 2350
		[Tooltip("Reference to the AimIK component. Optional, only used to getting the aiming direction.")]
		public AimIK aimIK;

		// Token: 0x0400092F RID: 2351
		[Tooltip("Optional head AimIK solver. This solver should only use neck and head bones and have the head as Aim Transform")]
		public AimIK headIK;

		// Token: 0x04000930 RID: 2352
		[Tooltip("Set this true if you are using IKExecutionOrder.cs or a custom script to force AimIK solve after FBBIK.")]
		public bool aimIKSolvedLast;

		// Token: 0x04000931 RID: 2353
		[Tooltip("Which hand is holding the weapon?")]
		public Recoil.Handedness handedness;

		// Token: 0x04000932 RID: 2354
		[Tooltip("Check for 2-handed weapons.")]
		public bool twoHanded = true;

		// Token: 0x04000933 RID: 2355
		[Tooltip("Weight curve for the recoil offsets. Recoil procedure is as long as this curve.")]
		public AnimationCurve recoilWeight;

		// Token: 0x04000934 RID: 2356
		[Tooltip("How much is the magnitude randomized each time Recoil is called?")]
		public float magnitudeRandom = 0.1f;

		// Token: 0x04000935 RID: 2357
		[Tooltip("How much is the rotation randomized each time Recoil is called?")]
		public Vector3 rotationRandom;

		// Token: 0x04000936 RID: 2358
		[Tooltip("Rotating the primary hand bone for the recoil (in local space).")]
		public Vector3 handRotationOffset;

		// Token: 0x04000937 RID: 2359
		[Tooltip("Time of blending in another recoil when doing automatic fire.")]
		public float blendTime;

		// Token: 0x04000938 RID: 2360
		[Space(10f)]
		[Tooltip("FBBIK effector position offsets for the recoil (in aiming direction space).")]
		public Recoil.RecoilOffset[] offsets;

		// Token: 0x04000939 RID: 2361
		[HideInInspector]
		public Quaternion rotationOffset = Quaternion.identity;

		// Token: 0x0400093A RID: 2362
		private float magnitudeMlp = 1f;

		// Token: 0x0400093B RID: 2363
		private float endTime = -1f;

		// Token: 0x0400093C RID: 2364
		private Quaternion handRotation;

		// Token: 0x0400093D RID: 2365
		private Quaternion secondaryHandRelativeRotation;

		// Token: 0x0400093E RID: 2366
		private Quaternion randomRotation;

		// Token: 0x0400093F RID: 2367
		private float length = 1f;

		// Token: 0x04000940 RID: 2368
		private bool initiated;

		// Token: 0x04000941 RID: 2369
		private float blendWeight;

		// Token: 0x04000942 RID: 2370
		private float w;

		// Token: 0x04000943 RID: 2371
		private Quaternion primaryHandRotation = Quaternion.identity;

		// Token: 0x04000944 RID: 2372
		private bool handRotationsSet;

		// Token: 0x04000945 RID: 2373
		private Vector3 aimIKAxis;

		// Token: 0x0200013C RID: 316
		[Serializable]
		public class RecoilOffset
		{
			// Token: 0x060009F8 RID: 2552 RVA: 0x0003E39C File Offset: 0x0003C59C
			public void Start()
			{
				if (this.additivity <= 0f)
				{
					return;
				}
				this.additiveOffset = Vector3.ClampMagnitude(this.lastOffset * this.additivity, this.maxAdditiveOffsetMag);
			}

			// Token: 0x060009F9 RID: 2553 RVA: 0x0003E3D0 File Offset: 0x0003C5D0
			public void Apply(IKSolverFullBodyBiped solver, Quaternion rotation, float masterWeight, float length, float timeLeft)
			{
				this.additiveOffset = Vector3.Lerp(Vector3.zero, this.additiveOffset, timeLeft / length);
				this.lastOffset = rotation * (this.offset * masterWeight) + rotation * this.additiveOffset;
				foreach (Recoil.RecoilOffset.EffectorLink effectorLink in this.effectorLinks)
				{
					solver.GetEffector(effectorLink.effector).positionOffset += this.lastOffset * effectorLink.weight;
				}
			}

			// Token: 0x04000946 RID: 2374
			[Tooltip("Offset vector for the associated effector when doing recoil.")]
			public Vector3 offset;

			// Token: 0x04000947 RID: 2375
			[Tooltip("When firing before the last recoil has faded, how much of the current recoil offset will be maintained?")]
			[Range(0f, 1f)]
			public float additivity = 1f;

			// Token: 0x04000948 RID: 2376
			[Tooltip("Max additive recoil for automatic fire.")]
			public float maxAdditiveOffsetMag = 0.2f;

			// Token: 0x04000949 RID: 2377
			[Tooltip("Linking this recoil offset to FBBIK effectors.")]
			public Recoil.RecoilOffset.EffectorLink[] effectorLinks;

			// Token: 0x0400094A RID: 2378
			private Vector3 additiveOffset;

			// Token: 0x0400094B RID: 2379
			private Vector3 lastOffset;

			// Token: 0x0200013D RID: 317
			[Serializable]
			public class EffectorLink
			{
				// Token: 0x0400094C RID: 2380
				[Tooltip("Type of the FBBIK effector to use")]
				public FullBodyBipedEffector effector;

				// Token: 0x0400094D RID: 2381
				[Tooltip("Weight of using this effector")]
				public float weight;
			}
		}

		// Token: 0x0200013E RID: 318
		[Serializable]
		public enum Handedness
		{
			// Token: 0x0400094F RID: 2383
			Right,
			// Token: 0x04000950 RID: 2384
			Left
		}
	}
}
