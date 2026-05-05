using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000031 RID: 49
	public class SolverManager : MonoBehaviour
	{
		// Token: 0x06000125 RID: 293 RVA: 0x00007BE5 File Offset: 0x00005DE5
		public void Disable()
		{
			Debug.Log("IK.Disable() is deprecated. Use enabled = false instead", base.transform);
			base.enabled = false;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void InitiateSolver()
		{
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void UpdateSolver()
		{
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000223E File Offset: 0x0000043E
		protected virtual void FixTransforms()
		{
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007BFE File Offset: 0x00005DFE
		private void OnDisable()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			this.Initiate();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00007C0E File Offset: 0x00005E0E
		private void Start()
		{
			this.Initiate();
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00007C16 File Offset: 0x00005E16
		private bool animatePhysics
		{
			get
			{
				if (this.animator != null)
				{
					return this.animator.updateMode == AnimatorUpdateMode.AnimatePhysics;
				}
				return this.legacy != null && this.legacy.animatePhysics;
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00007C50 File Offset: 0x00005E50
		private void Initiate()
		{
			if (this.componentInitiated)
			{
				return;
			}
			this.FindAnimatorRecursive(base.transform, true);
			this.InitiateSolver();
			this.componentInitiated = true;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00007C75 File Offset: 0x00005E75
		private void Update()
		{
			if (this.skipSolverUpdate)
			{
				return;
			}
			if (this.animatePhysics)
			{
				return;
			}
			if (this.fixTransforms)
			{
				this.FixTransforms();
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00007C98 File Offset: 0x00005E98
		private void FindAnimatorRecursive(Transform t, bool findInChildren)
		{
			if (this.isAnimated)
			{
				return;
			}
			this.animator = t.GetComponent<Animator>();
			this.legacy = t.GetComponent<Animation>();
			if (this.isAnimated)
			{
				return;
			}
			if (this.animator == null && findInChildren)
			{
				this.animator = t.GetComponentInChildren<Animator>();
			}
			if (this.legacy == null && findInChildren)
			{
				this.legacy = t.GetComponentInChildren<Animation>();
			}
			if (!this.isAnimated && t.parent != null)
			{
				this.FindAnimatorRecursive(t.parent, false);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00007D2A File Offset: 0x00005F2A
		private bool isAnimated
		{
			get
			{
				return this.animator != null || this.legacy != null;
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00007D48 File Offset: 0x00005F48
		private void FixedUpdate()
		{
			if (this.skipSolverUpdate)
			{
				this.skipSolverUpdate = false;
			}
			this.updateFrame = true;
			if (this.animatePhysics && this.fixTransforms)
			{
				this.FixTransforms();
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00007D76 File Offset: 0x00005F76
		private void LateUpdate()
		{
			if (this.skipSolverUpdate)
			{
				return;
			}
			if (!this.animatePhysics)
			{
				this.updateFrame = true;
			}
			if (!this.updateFrame)
			{
				return;
			}
			this.updateFrame = false;
			this.UpdateSolver();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00007DA6 File Offset: 0x00005FA6
		public void UpdateSolverExternal()
		{
			if (!base.enabled)
			{
				return;
			}
			this.skipSolverUpdate = true;
			this.UpdateSolver();
		}

		// Token: 0x04000117 RID: 279
		[Tooltip("If true, will fix all the Transforms used by the solver to their initial state in each Update. This prevents potential problems with unanimated bones and animator culling with a small cost of performance. Not recommended for CCD and FABRIK solvers.")]
		public bool fixTransforms = true;

		// Token: 0x04000118 RID: 280
		private Animator animator;

		// Token: 0x04000119 RID: 281
		private Animation legacy;

		// Token: 0x0400011A RID: 282
		private bool updateFrame;

		// Token: 0x0400011B RID: 283
		private bool componentInitiated;

		// Token: 0x0400011C RID: 284
		private bool skipSolverUpdate;
	}
}
