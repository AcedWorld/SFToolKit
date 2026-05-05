using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000106 RID: 262
	public abstract class Poser : SolverManager
	{
		// Token: 0x060008CF RID: 2255
		public abstract void AutoMapping();

		// Token: 0x060008D0 RID: 2256 RVA: 0x0000223E File Offset: 0x0000043E
		public virtual void AutoMapping(Transform[] bones)
		{
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00038F58 File Offset: 0x00037158
		public void UpdateManual()
		{
			this.UpdatePoser();
		}

		// Token: 0x060008D2 RID: 2258
		protected abstract void InitiatePoser();

		// Token: 0x060008D3 RID: 2259
		protected abstract void UpdatePoser();

		// Token: 0x060008D4 RID: 2260
		protected abstract void FixPoserTransforms();

		// Token: 0x060008D5 RID: 2261 RVA: 0x00038F60 File Offset: 0x00037160
		protected override void UpdateSolver()
		{
			if (!this.initiated)
			{
				this.InitiateSolver();
			}
			if (!this.initiated)
			{
				return;
			}
			this.UpdatePoser();
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00038F7F File Offset: 0x0003717F
		protected override void InitiateSolver()
		{
			if (this.initiated)
			{
				return;
			}
			this.InitiatePoser();
			this.initiated = true;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00038F97 File Offset: 0x00037197
		protected override void FixTransforms()
		{
			if (!this.initiated)
			{
				return;
			}
			this.FixPoserTransforms();
		}

		// Token: 0x04000819 RID: 2073
		public Transform poseRoot;

		// Token: 0x0400081A RID: 2074
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x0400081B RID: 2075
		[Range(0f, 1f)]
		public float localRotationWeight = 1f;

		// Token: 0x0400081C RID: 2076
		[Range(0f, 1f)]
		public float localPositionWeight;

		// Token: 0x0400081D RID: 2077
		private bool initiated;
	}
}
