using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000131 RID: 305
	public abstract class OffsetModifier : MonoBehaviour
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x0003D429 File Offset: 0x0003B629
		protected float deltaTime
		{
			get
			{
				return Time.time - this.lastTime;
			}
		}

		// Token: 0x060009C2 RID: 2498
		protected abstract void OnModifyOffset();

		// Token: 0x060009C3 RID: 2499 RVA: 0x0003D437 File Offset: 0x0003B637
		protected virtual void Start()
		{
			base.StartCoroutine(this.Initiate());
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0003D446 File Offset: 0x0003B646
		private IEnumerator Initiate()
		{
			while (this.ik == null)
			{
				yield return null;
			}
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.ModifyOffset));
			this.lastTime = Time.time;
			yield break;
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0003D458 File Offset: 0x0003B658
		private void ModifyOffset()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.weight <= 0f)
			{
				return;
			}
			if (this.ik == null)
			{
				return;
			}
			this.weight = Mathf.Clamp(this.weight, 0f, 1f);
			if (this.deltaTime <= 0f)
			{
				return;
			}
			this.OnModifyOffset();
			this.lastTime = Time.time;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0003D4C8 File Offset: 0x0003B6C8
		protected void ApplyLimits(OffsetModifier.OffsetLimits[] limits)
		{
			foreach (OffsetModifier.OffsetLimits offsetLimits in limits)
			{
				offsetLimits.Apply(this.ik.solver.GetEffector(offsetLimits.effector), base.transform.rotation);
			}
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0003D510 File Offset: 0x0003B710
		protected virtual void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverFullBodyBiped solver = this.ik.solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.ModifyOffset));
			}
		}

		// Token: 0x04000905 RID: 2309
		[Tooltip("The master weight")]
		public float weight = 1f;

		// Token: 0x04000906 RID: 2310
		[Tooltip("Reference to the FBBIK component")]
		public FullBodyBipedIK ik;

		// Token: 0x04000907 RID: 2311
		protected float lastTime;

		// Token: 0x02000132 RID: 306
		[Serializable]
		public class OffsetLimits
		{
			// Token: 0x060009C9 RID: 2505 RVA: 0x0003D560 File Offset: 0x0003B760
			public void Apply(IKEffector e, Quaternion rootRotation)
			{
				Vector3 vector = Quaternion.Inverse(rootRotation) * e.positionOffset;
				if (this.spring <= 0f)
				{
					if (this.x)
					{
						vector.x = Mathf.Clamp(vector.x, this.minX, this.maxX);
					}
					if (this.y)
					{
						vector.y = Mathf.Clamp(vector.y, this.minY, this.maxY);
					}
					if (this.z)
					{
						vector.z = Mathf.Clamp(vector.z, this.minZ, this.maxZ);
					}
				}
				else
				{
					if (this.x)
					{
						vector.x = this.SpringAxis(vector.x, this.minX, this.maxX);
					}
					if (this.y)
					{
						vector.y = this.SpringAxis(vector.y, this.minY, this.maxY);
					}
					if (this.z)
					{
						vector.z = this.SpringAxis(vector.z, this.minZ, this.maxZ);
					}
				}
				e.positionOffset = rootRotation * vector;
			}

			// Token: 0x060009CA RID: 2506 RVA: 0x0003D685 File Offset: 0x0003B885
			private float SpringAxis(float value, float min, float max)
			{
				if (value > min && value < max)
				{
					return value;
				}
				if (value < min)
				{
					return this.Spring(value, min, true);
				}
				return this.Spring(value, max, false);
			}

			// Token: 0x060009CB RID: 2507 RVA: 0x0003D6A8 File Offset: 0x0003B8A8
			private float Spring(float value, float limit, bool negative)
			{
				float num = value - limit;
				float num2 = num * this.spring;
				if (negative)
				{
					return value + Mathf.Clamp(-num2, 0f, -num);
				}
				return value - Mathf.Clamp(num2, 0f, num);
			}

			// Token: 0x04000908 RID: 2312
			[Tooltip("The effector type (this is just an enum)")]
			public FullBodyBipedEffector effector;

			// Token: 0x04000909 RID: 2313
			[Tooltip("Spring force, if zero then this is a hard limit, if not, offset can exceed the limit.")]
			public float spring;

			// Token: 0x0400090A RID: 2314
			[Tooltip("Which axes to limit the offset on?")]
			public bool x;

			// Token: 0x0400090B RID: 2315
			[Tooltip("Which axes to limit the offset on?")]
			public bool y;

			// Token: 0x0400090C RID: 2316
			[Tooltip("Which axes to limit the offset on?")]
			public bool z;

			// Token: 0x0400090D RID: 2317
			[Tooltip("The limits")]
			public float minX;

			// Token: 0x0400090E RID: 2318
			[Tooltip("The limits")]
			public float maxX;

			// Token: 0x0400090F RID: 2319
			[Tooltip("The limits")]
			public float minY;

			// Token: 0x04000910 RID: 2320
			[Tooltip("The limits")]
			public float maxY;

			// Token: 0x04000911 RID: 2321
			[Tooltip("The limits")]
			public float minZ;

			// Token: 0x04000912 RID: 2322
			[Tooltip("The limits")]
			public float maxZ;
		}
	}
}
