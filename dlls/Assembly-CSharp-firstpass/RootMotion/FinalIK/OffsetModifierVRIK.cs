using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000134 RID: 308
	public abstract class OffsetModifierVRIK : MonoBehaviour
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060009D3 RID: 2515 RVA: 0x0003D786 File Offset: 0x0003B986
		protected float deltaTime
		{
			get
			{
				return Time.time - this.lastTime;
			}
		}

		// Token: 0x060009D4 RID: 2516
		protected abstract void OnModifyOffset();

		// Token: 0x060009D5 RID: 2517 RVA: 0x0003D794 File Offset: 0x0003B994
		protected virtual void Start()
		{
			base.StartCoroutine(this.Initiate());
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0003D7A3 File Offset: 0x0003B9A3
		private IEnumerator Initiate()
		{
			while (this.ik == null)
			{
				yield return null;
			}
			IKSolverVR solver = this.ik.solver;
			solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.ModifyOffset));
			this.lastTime = Time.time;
			yield break;
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0003D7B4 File Offset: 0x0003B9B4
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
			if (this.deltaTime <= 0f)
			{
				return;
			}
			if (this.ik == null)
			{
				return;
			}
			this.weight = Mathf.Clamp(this.weight, 0f, 1f);
			this.OnModifyOffset();
			this.lastTime = Time.time;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0003D821 File Offset: 0x0003BA21
		protected virtual void OnDestroy()
		{
			if (this.ik != null)
			{
				IKSolverVR solver = this.ik.solver;
				solver.OnPreUpdate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPreUpdate, new IKSolver.UpdateDelegate(this.ModifyOffset));
			}
		}

		// Token: 0x04000916 RID: 2326
		[Tooltip("The master weight")]
		public float weight = 1f;

		// Token: 0x04000917 RID: 2327
		[Tooltip("Reference to the VRIK component")]
		public VRIK ik;

		// Token: 0x04000918 RID: 2328
		private float lastTime;
	}
}
