using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000121 RID: 289
	public class HitReaction : OffsetModifier
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x0003C054 File Offset: 0x0003A254
		public bool inProgress
		{
			get
			{
				HitReaction.HitPointEffector[] array = this.effectorHitPoints;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].inProgress)
					{
						return true;
					}
				}
				HitReaction.HitPointBone[] array2 = this.boneHitPoints;
				for (int i = 0; i < array2.Length; i++)
				{
					if (array2[i].inProgress)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0003C0A4 File Offset: 0x0003A2A4
		protected override void OnModifyOffset()
		{
			HitReaction.HitPointEffector[] array = this.effectorHitPoints;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Apply(this.ik.solver, this.weight);
			}
			HitReaction.HitPointBone[] array2 = this.boneHitPoints;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Apply(this.ik.solver, this.weight);
			}
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0003C110 File Offset: 0x0003A310
		public void Hit(Collider collider, Vector3 force, Vector3 point)
		{
			if (this.ik == null)
			{
				Debug.LogError("No IK assigned in HitReaction");
				return;
			}
			foreach (HitReaction.HitPointEffector hitPointEffector in this.effectorHitPoints)
			{
				if (hitPointEffector.collider == collider)
				{
					hitPointEffector.Hit(force, point);
				}
			}
			foreach (HitReaction.HitPointBone hitPointBone in this.boneHitPoints)
			{
				if (hitPointBone.collider == collider)
				{
					hitPointBone.Hit(force, point);
				}
			}
		}

		// Token: 0x040008AD RID: 2221
		[Tooltip("Hit points for the FBBIK effectors")]
		public HitReaction.HitPointEffector[] effectorHitPoints;

		// Token: 0x040008AE RID: 2222
		[Tooltip(" Hit points for bones without an effector, such as the head")]
		public HitReaction.HitPointBone[] boneHitPoints;

		// Token: 0x02000122 RID: 290
		[Serializable]
		public abstract class HitPoint
		{
			// Token: 0x17000111 RID: 273
			// (get) Token: 0x0600097A RID: 2426 RVA: 0x0003C197 File Offset: 0x0003A397
			public bool inProgress
			{
				get
				{
					return this.timer < this.length;
				}
			}

			// Token: 0x17000112 RID: 274
			// (get) Token: 0x0600097B RID: 2427 RVA: 0x0003C1A7 File Offset: 0x0003A3A7
			// (set) Token: 0x0600097C RID: 2428 RVA: 0x0003C1AF File Offset: 0x0003A3AF
			private protected float crossFader { protected get; private set; }

			// Token: 0x17000113 RID: 275
			// (get) Token: 0x0600097D RID: 2429 RVA: 0x0003C1B8 File Offset: 0x0003A3B8
			// (set) Token: 0x0600097E RID: 2430 RVA: 0x0003C1C0 File Offset: 0x0003A3C0
			private protected float timer { protected get; private set; }

			// Token: 0x17000114 RID: 276
			// (get) Token: 0x0600097F RID: 2431 RVA: 0x0003C1C9 File Offset: 0x0003A3C9
			// (set) Token: 0x06000980 RID: 2432 RVA: 0x0003C1D1 File Offset: 0x0003A3D1
			private protected Vector3 force { protected get; private set; }

			// Token: 0x06000981 RID: 2433 RVA: 0x0003C1DC File Offset: 0x0003A3DC
			public virtual void Hit(Vector3 force, Vector3 point)
			{
				if (this.length == 0f)
				{
					this.length = this.GetLength();
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

			// Token: 0x06000982 RID: 2434 RVA: 0x0003C270 File Offset: 0x0003A470
			public void Apply(IKSolverFullBodyBiped solver, float weight)
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
				this.OnApply(solver, weight);
			}

			// Token: 0x06000983 RID: 2435
			protected abstract float GetLength();

			// Token: 0x06000984 RID: 2436
			protected abstract void CrossFadeStart();

			// Token: 0x06000985 RID: 2437
			protected abstract void OnApply(IKSolverFullBodyBiped solver, float weight);

			// Token: 0x040008AF RID: 2223
			[Tooltip("Just for visual clarity, not used at all")]
			public string name;

			// Token: 0x040008B0 RID: 2224
			[Tooltip("Linking this hit point to a collider")]
			public Collider collider;

			// Token: 0x040008B1 RID: 2225
			[Tooltip("Only used if this hit point gets hit when already processing another hit")]
			[SerializeField]
			private float crossFadeTime = 0.1f;

			// Token: 0x040008B5 RID: 2229
			private float length;

			// Token: 0x040008B6 RID: 2230
			private float crossFadeSpeed;

			// Token: 0x040008B7 RID: 2231
			private float lastTime;
		}

		// Token: 0x02000123 RID: 291
		[Serializable]
		public class HitPointEffector : HitReaction.HitPoint
		{
			// Token: 0x06000987 RID: 2439 RVA: 0x0003C31C File Offset: 0x0003A51C
			protected override float GetLength()
			{
				float num = (this.offsetInForceDirection.keys.Length != 0) ? this.offsetInForceDirection.keys[this.offsetInForceDirection.length - 1].time : 0f;
				float min = (this.offsetInUpDirection.keys.Length != 0) ? this.offsetInUpDirection.keys[this.offsetInUpDirection.length - 1].time : 0f;
				return Mathf.Clamp(num, min, num);
			}

			// Token: 0x06000988 RID: 2440 RVA: 0x0003C3A4 File Offset: 0x0003A5A4
			protected override void CrossFadeStart()
			{
				HitReaction.HitPointEffector.EffectorLink[] array = this.effectorLinks;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CrossFadeStart();
				}
			}

			// Token: 0x06000989 RID: 2441 RVA: 0x0003C3D0 File Offset: 0x0003A5D0
			protected override void OnApply(IKSolverFullBodyBiped solver, float weight)
			{
				Vector3 a = solver.GetRoot().up * base.force.magnitude;
				Vector3 vector = this.offsetInForceDirection.Evaluate(base.timer) * base.force + this.offsetInUpDirection.Evaluate(base.timer) * a;
				vector *= weight;
				HitReaction.HitPointEffector.EffectorLink[] array = this.effectorLinks;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Apply(solver, vector, base.crossFader);
				}
			}

			// Token: 0x040008B8 RID: 2232
			[Tooltip("Offset magnitude in the direction of the hit force")]
			public AnimationCurve offsetInForceDirection;

			// Token: 0x040008B9 RID: 2233
			[Tooltip("Offset magnitude in the direction of character.up")]
			public AnimationCurve offsetInUpDirection;

			// Token: 0x040008BA RID: 2234
			[Tooltip("Linking this offset to the FBBIK effectors")]
			public HitReaction.HitPointEffector.EffectorLink[] effectorLinks;

			// Token: 0x02000124 RID: 292
			[Serializable]
			public class EffectorLink
			{
				// Token: 0x0600098B RID: 2443 RVA: 0x0003C470 File Offset: 0x0003A670
				public void Apply(IKSolverFullBodyBiped solver, Vector3 offset, float crossFader)
				{
					this.current = Vector3.Lerp(this.lastValue, offset * this.weight, crossFader);
					solver.GetEffector(this.effector).positionOffset += this.current;
				}

				// Token: 0x0600098C RID: 2444 RVA: 0x0003C4BD File Offset: 0x0003A6BD
				public void CrossFadeStart()
				{
					this.lastValue = this.current;
				}

				// Token: 0x040008BB RID: 2235
				[Tooltip("The FBBIK effector type")]
				public FullBodyBipedEffector effector;

				// Token: 0x040008BC RID: 2236
				[Tooltip("The weight of this effector (could also be negative)")]
				public float weight;

				// Token: 0x040008BD RID: 2237
				private Vector3 lastValue;

				// Token: 0x040008BE RID: 2238
				private Vector3 current;
			}
		}

		// Token: 0x02000125 RID: 293
		[Serializable]
		public class HitPointBone : HitReaction.HitPoint
		{
			// Token: 0x0600098E RID: 2446 RVA: 0x0003C4CC File Offset: 0x0003A6CC
			public override void Hit(Vector3 force, Vector3 point)
			{
				base.Hit(force, point);
				if (this.rigidbody == null)
				{
					this.rigidbody = this.collider.GetComponent<Rigidbody>();
				}
				Vector3 b = (this.rigidbody != null) ? this.rigidbody.worldCenterOfMass : this.collider.transform.position;
				this.comAxis = Vector3.Cross(force, point - b);
			}

			// Token: 0x0600098F RID: 2447 RVA: 0x0003C53F File Offset: 0x0003A73F
			protected override float GetLength()
			{
				if (this.aroundCenterOfMass.keys.Length == 0)
				{
					return 0f;
				}
				return this.aroundCenterOfMass.keys[this.aroundCenterOfMass.length - 1].time;
			}

			// Token: 0x06000990 RID: 2448 RVA: 0x0003C578 File Offset: 0x0003A778
			protected override void CrossFadeStart()
			{
				HitReaction.HitPointBone.BoneLink[] array = this.boneLinks;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CrossFadeStart();
				}
			}

			// Token: 0x06000991 RID: 2449 RVA: 0x0003C5A4 File Offset: 0x0003A7A4
			protected override void OnApply(IKSolverFullBodyBiped solver, float weight)
			{
				Quaternion offset = Quaternion.AngleAxis(this.aroundCenterOfMass.Evaluate(base.timer) * weight, this.comAxis);
				HitReaction.HitPointBone.BoneLink[] array = this.boneLinks;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Apply(solver, offset, base.crossFader);
				}
			}

			// Token: 0x040008BF RID: 2239
			[Tooltip("The angle to rotate the bone around its rigidbody's world center of mass")]
			public AnimationCurve aroundCenterOfMass;

			// Token: 0x040008C0 RID: 2240
			[Tooltip("Linking this hit point to bone(s)")]
			public HitReaction.HitPointBone.BoneLink[] boneLinks;

			// Token: 0x040008C1 RID: 2241
			private Rigidbody rigidbody;

			// Token: 0x040008C2 RID: 2242
			private Vector3 comAxis;

			// Token: 0x02000126 RID: 294
			[Serializable]
			public class BoneLink
			{
				// Token: 0x06000993 RID: 2451 RVA: 0x0003C5F8 File Offset: 0x0003A7F8
				public void Apply(IKSolverFullBodyBiped solver, Quaternion offset, float crossFader)
				{
					this.current = Quaternion.Lerp(this.lastValue, Quaternion.Lerp(Quaternion.identity, offset, this.weight), crossFader);
					this.bone.rotation = this.current * this.bone.rotation;
				}

				// Token: 0x06000994 RID: 2452 RVA: 0x0003C649 File Offset: 0x0003A849
				public void CrossFadeStart()
				{
					this.lastValue = this.current;
				}

				// Token: 0x040008C3 RID: 2243
				[Tooltip("Reference to the bone that this hit point rotates")]
				public Transform bone;

				// Token: 0x040008C4 RID: 2244
				[Tooltip("Weight of rotating the bone")]
				[Range(0f, 1f)]
				public float weight;

				// Token: 0x040008C5 RID: 2245
				private Quaternion lastValue = Quaternion.identity;

				// Token: 0x040008C6 RID: 2246
				private Quaternion current = Quaternion.identity;
			}
		}
	}
}
