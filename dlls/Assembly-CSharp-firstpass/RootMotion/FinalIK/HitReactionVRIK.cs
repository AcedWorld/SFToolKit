using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000127 RID: 295
	public class HitReactionVRIK : OffsetModifierVRIK
	{
		// Token: 0x06000996 RID: 2454 RVA: 0x0003C678 File Offset: 0x0003A878
		protected override void OnModifyOffset()
		{
			HitReactionVRIK.PositionOffset[] array = this.positionOffsets;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Apply(this.ik, this.offsetCurves, this.weight);
			}
			HitReactionVRIK.RotationOffset[] array2 = this.rotationOffsets;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Apply(this.ik, this.offsetCurves, this.weight);
			}
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0003C6E4 File Offset: 0x0003A8E4
		public void Hit(Collider collider, Vector3 force, Vector3 point)
		{
			if (this.ik == null)
			{
				Debug.LogError("No IK assigned in HitReaction");
				return;
			}
			foreach (HitReactionVRIK.PositionOffset positionOffset in this.positionOffsets)
			{
				if (positionOffset.collider == collider)
				{
					positionOffset.Hit(force, this.offsetCurves, point);
				}
			}
			foreach (HitReactionVRIK.RotationOffset rotationOffset in this.rotationOffsets)
			{
				if (rotationOffset.collider == collider)
				{
					rotationOffset.Hit(force, this.offsetCurves, point);
				}
			}
		}

		// Token: 0x040008C7 RID: 2247
		public AnimationCurve[] offsetCurves;

		// Token: 0x040008C8 RID: 2248
		[Tooltip("Hit points for the FBBIK effectors")]
		public HitReactionVRIK.PositionOffset[] positionOffsets;

		// Token: 0x040008C9 RID: 2249
		[Tooltip(" Hit points for bones without an effector, such as the head")]
		public HitReactionVRIK.RotationOffset[] rotationOffsets;

		// Token: 0x02000128 RID: 296
		[Serializable]
		public abstract class Offset
		{
			// Token: 0x17000115 RID: 277
			// (get) Token: 0x06000999 RID: 2457 RVA: 0x0003C77F File Offset: 0x0003A97F
			// (set) Token: 0x0600099A RID: 2458 RVA: 0x0003C787 File Offset: 0x0003A987
			private protected float crossFader { protected get; private set; }

			// Token: 0x17000116 RID: 278
			// (get) Token: 0x0600099B RID: 2459 RVA: 0x0003C790 File Offset: 0x0003A990
			// (set) Token: 0x0600099C RID: 2460 RVA: 0x0003C798 File Offset: 0x0003A998
			private protected float timer { protected get; private set; }

			// Token: 0x17000117 RID: 279
			// (get) Token: 0x0600099D RID: 2461 RVA: 0x0003C7A1 File Offset: 0x0003A9A1
			// (set) Token: 0x0600099E RID: 2462 RVA: 0x0003C7A9 File Offset: 0x0003A9A9
			private protected Vector3 force { protected get; private set; }

			// Token: 0x0600099F RID: 2463 RVA: 0x0003C7B4 File Offset: 0x0003A9B4
			public virtual void Hit(Vector3 force, AnimationCurve[] curves, Vector3 point)
			{
				if (this.length == 0f)
				{
					this.length = this.GetLength(curves);
				}
				if (this.length <= 0f)
				{
					Debug.LogError("Hit Point WeightCurve length is zero.");
					return;
				}
				if (this.timer < 1f)
				{
					this.crossFader = 0f;
				}
				this.crossFadeSpeed = ((this.crossFadeTime > 0f) ? (1f / this.crossFadeTime) : 0f);
				this.CrossFadeStart();
				this.timer = 0f;
				this.force = force;
			}

			// Token: 0x060009A0 RID: 2464 RVA: 0x0003C84C File Offset: 0x0003AA4C
			public void Apply(VRIK ik, AnimationCurve[] curves, float weight)
			{
				float num = Time.time - this.lastTime;
				this.lastTime = Time.time;
				if (this.timer >= this.length)
				{
					return;
				}
				this.timer = Mathf.Clamp(this.timer + num, 0f, this.length);
				if (this.crossFadeSpeed > 0f)
				{
					this.crossFader = Mathf.Clamp(this.crossFader + num * this.crossFadeSpeed, 0f, 1f);
				}
				else
				{
					this.crossFader = 1f;
				}
				this.OnApply(ik, curves, weight);
			}

			// Token: 0x060009A1 RID: 2465
			protected abstract float GetLength(AnimationCurve[] curves);

			// Token: 0x060009A2 RID: 2466
			protected abstract void CrossFadeStart();

			// Token: 0x060009A3 RID: 2467
			protected abstract void OnApply(VRIK ik, AnimationCurve[] curves, float weight);

			// Token: 0x040008CA RID: 2250
			[Tooltip("Just for visual clarity, not used at all")]
			public string name;

			// Token: 0x040008CB RID: 2251
			[Tooltip("Linking this hit point to a collider")]
			public Collider collider;

			// Token: 0x040008CC RID: 2252
			[Tooltip("Only used if this hit point gets hit when already processing another hit")]
			[SerializeField]
			private float crossFadeTime = 0.1f;

			// Token: 0x040008D0 RID: 2256
			private float length;

			// Token: 0x040008D1 RID: 2257
			private float crossFadeSpeed;

			// Token: 0x040008D2 RID: 2258
			private float lastTime;
		}

		// Token: 0x02000129 RID: 297
		[Serializable]
		public class PositionOffset : HitReactionVRIK.Offset
		{
			// Token: 0x060009A5 RID: 2469 RVA: 0x0003C8F8 File Offset: 0x0003AAF8
			protected override float GetLength(AnimationCurve[] curves)
			{
				float num = (curves[this.forceDirCurveIndex].keys.Length != 0) ? curves[this.forceDirCurveIndex].keys[curves[this.forceDirCurveIndex].length - 1].time : 0f;
				float min = (curves[this.upDirCurveIndex].keys.Length != 0) ? curves[this.upDirCurveIndex].keys[curves[this.upDirCurveIndex].length - 1].time : 0f;
				return Mathf.Clamp(num, min, num);
			}

			// Token: 0x060009A6 RID: 2470 RVA: 0x0003C98C File Offset: 0x0003AB8C
			protected override void CrossFadeStart()
			{
				HitReactionVRIK.PositionOffset.PositionOffsetLink[] array = this.offsetLinks;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CrossFadeStart();
				}
			}

			// Token: 0x060009A7 RID: 2471 RVA: 0x0003C9B8 File Offset: 0x0003ABB8
			protected override void OnApply(VRIK ik, AnimationCurve[] curves, float weight)
			{
				Vector3 a = ik.transform.up * base.force.magnitude;
				Vector3 vector = curves[this.forceDirCurveIndex].Evaluate(base.timer) * base.force + curves[this.upDirCurveIndex].Evaluate(base.timer) * a;
				vector *= weight;
				HitReactionVRIK.PositionOffset.PositionOffsetLink[] array = this.offsetLinks;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Apply(ik, vector, base.crossFader);
				}
			}

			// Token: 0x040008D3 RID: 2259
			[Tooltip("Offset magnitude in the direction of the hit force")]
			public int forceDirCurveIndex;

			// Token: 0x040008D4 RID: 2260
			[Tooltip("Offset magnitude in the direction of character.up")]
			public int upDirCurveIndex = 1;

			// Token: 0x040008D5 RID: 2261
			[Tooltip("Linking this offset to the VRIK position offsets")]
			public HitReactionVRIK.PositionOffset.PositionOffsetLink[] offsetLinks;

			// Token: 0x0200012A RID: 298
			[Serializable]
			public class PositionOffsetLink
			{
				// Token: 0x060009A9 RID: 2473 RVA: 0x0003CA62 File Offset: 0x0003AC62
				public void Apply(VRIK ik, Vector3 offset, float crossFader)
				{
					this.current = Vector3.Lerp(this.lastValue, offset * this.weight, crossFader);
					ik.solver.AddPositionOffset(this.positionOffset, this.current);
				}

				// Token: 0x060009AA RID: 2474 RVA: 0x0003CA99 File Offset: 0x0003AC99
				public void CrossFadeStart()
				{
					this.lastValue = this.current;
				}

				// Token: 0x040008D6 RID: 2262
				[Tooltip("The FBBIK effector type")]
				public IKSolverVR.PositionOffset positionOffset;

				// Token: 0x040008D7 RID: 2263
				[Tooltip("The weight of this effector (could also be negative)")]
				public float weight;

				// Token: 0x040008D8 RID: 2264
				private Vector3 lastValue;

				// Token: 0x040008D9 RID: 2265
				private Vector3 current;
			}
		}

		// Token: 0x0200012B RID: 299
		[Serializable]
		public class RotationOffset : HitReactionVRIK.Offset
		{
			// Token: 0x060009AC RID: 2476 RVA: 0x0003CAA8 File Offset: 0x0003ACA8
			public override void Hit(Vector3 force, AnimationCurve[] curves, Vector3 point)
			{
				base.Hit(force, curves, point);
				if (this.rigidbody == null)
				{
					this.rigidbody = this.collider.GetComponent<Rigidbody>();
				}
				Vector3 b = (this.rigidbody != null) ? this.rigidbody.worldCenterOfMass : this.collider.transform.position;
				this.comAxis = Vector3.Cross(force, point - b);
			}

			// Token: 0x060009AD RID: 2477 RVA: 0x0003CB1C File Offset: 0x0003AD1C
			protected override float GetLength(AnimationCurve[] curves)
			{
				if (curves[this.curveIndex].keys.Length == 0)
				{
					return 0f;
				}
				return curves[this.curveIndex].keys[curves[this.curveIndex].length - 1].time;
			}

			// Token: 0x060009AE RID: 2478 RVA: 0x0003CB5C File Offset: 0x0003AD5C
			protected override void CrossFadeStart()
			{
				HitReactionVRIK.RotationOffset.RotationOffsetLink[] array = this.offsetLinks;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CrossFadeStart();
				}
			}

			// Token: 0x060009AF RID: 2479 RVA: 0x0003CB88 File Offset: 0x0003AD88
			protected override void OnApply(VRIK ik, AnimationCurve[] curves, float weight)
			{
				if (this.collider == null)
				{
					Debug.LogError("No collider assigned for a HitPointBone in the HitReaction component.");
					return;
				}
				if (this.rigidbody == null)
				{
					this.rigidbody = this.collider.GetComponent<Rigidbody>();
				}
				if (this.rigidbody != null)
				{
					Quaternion offset = Quaternion.AngleAxis(curves[this.curveIndex].Evaluate(base.timer) * weight, this.comAxis);
					HitReactionVRIK.RotationOffset.RotationOffsetLink[] array = this.offsetLinks;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].Apply(ik, offset, base.crossFader);
					}
				}
			}

			// Token: 0x040008DA RID: 2266
			[Tooltip("The angle to rotate the bone around its rigidbody's world center of mass")]
			public int curveIndex;

			// Token: 0x040008DB RID: 2267
			[Tooltip("Linking this hit point to bone(s)")]
			public HitReactionVRIK.RotationOffset.RotationOffsetLink[] offsetLinks;

			// Token: 0x040008DC RID: 2268
			private Rigidbody rigidbody;

			// Token: 0x040008DD RID: 2269
			private Vector3 comAxis;

			// Token: 0x0200012C RID: 300
			[Serializable]
			public class RotationOffsetLink
			{
				// Token: 0x060009B1 RID: 2481 RVA: 0x0003CC29 File Offset: 0x0003AE29
				public void Apply(VRIK ik, Quaternion offset, float crossFader)
				{
					this.current = Quaternion.Lerp(this.lastValue, Quaternion.Lerp(Quaternion.identity, offset, this.weight), crossFader);
					ik.solver.AddRotationOffset(this.rotationOffset, this.current);
				}

				// Token: 0x060009B2 RID: 2482 RVA: 0x0003CC65 File Offset: 0x0003AE65
				public void CrossFadeStart()
				{
					this.lastValue = this.current;
				}

				// Token: 0x040008DE RID: 2270
				[Tooltip("Reference to the bone that this hit point rotates")]
				public IKSolverVR.RotationOffset rotationOffset;

				// Token: 0x040008DF RID: 2271
				[Tooltip("Weight of rotating the bone")]
				[Range(0f, 1f)]
				public float weight;

				// Token: 0x040008E0 RID: 2272
				private Quaternion lastValue = Quaternion.identity;

				// Token: 0x040008E1 RID: 2273
				private Quaternion current = Quaternion.identity;
			}
		}
	}
}
