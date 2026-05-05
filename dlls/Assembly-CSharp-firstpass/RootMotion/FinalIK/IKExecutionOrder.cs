using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B3 RID: 179
	public class IKExecutionOrder : MonoBehaviour
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x00020A0B File Offset: 0x0001EC0B
		private bool animatePhysics
		{
			get
			{
				return !(this.animator == null) && this.animator.updateMode == AnimatorUpdateMode.AnimatePhysics;
			}
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00020A2C File Offset: 0x0001EC2C
		private void Start()
		{
			for (int i = 0; i < this.IKComponents.Length; i++)
			{
				this.IKComponents[i].enabled = false;
			}
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00020A5A File Offset: 0x0001EC5A
		private void Update()
		{
			if (this.animatePhysics)
			{
				return;
			}
			this.FixTransforms();
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00020A6B File Offset: 0x0001EC6B
		private void FixedUpdate()
		{
			this.fixedFrame = true;
			if (this.animatePhysics)
			{
				this.FixTransforms();
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00020A84 File Offset: 0x0001EC84
		private void LateUpdate()
		{
			if (!this.animatePhysics || this.fixedFrame)
			{
				for (int i = 0; i < this.IKComponents.Length; i++)
				{
					this.IKComponents[i].GetIKSolver().Update();
				}
				this.fixedFrame = false;
			}
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00020AD0 File Offset: 0x0001ECD0
		private void FixTransforms()
		{
			for (int i = 0; i < this.IKComponents.Length; i++)
			{
				if (this.IKComponents[i].fixTransforms)
				{
					this.IKComponents[i].GetIKSolver().FixTransforms();
				}
			}
		}

		// Token: 0x040004C4 RID: 1220
		[Tooltip("The IK components, assign in the order in which you wish to update them.")]
		public IK[] IKComponents;

		// Token: 0x040004C5 RID: 1221
		[Tooltip("Optional. Assign it if you are using 'Animate Physics' as the Update Mode.")]
		public Animator animator;

		// Token: 0x040004C6 RID: 1222
		private bool fixedFrame;
	}
}
