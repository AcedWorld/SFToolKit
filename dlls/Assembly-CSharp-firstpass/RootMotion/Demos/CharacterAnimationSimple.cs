using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001BA RID: 442
	public class CharacterAnimationSimple : CharacterAnimationBase
	{
		// Token: 0x06000BDF RID: 3039 RVA: 0x000497FE File Offset: 0x000479FE
		protected override void Start()
		{
			base.Start();
			this.animator = base.GetComponentInChildren<Animator>();
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x00049814 File Offset: 0x00047A14
		public override Vector3 GetPivotPoint()
		{
			if (this.pivotOffset == 0f)
			{
				return base.transform.position;
			}
			return base.transform.position + base.transform.forward * this.pivotOffset;
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x00049860 File Offset: 0x00047A60
		private void Update()
		{
			float num = this.moveSpeed.Evaluate(this.characterController.animState.moveDirection.z);
			this.animator.SetFloat("Speed", num);
			this.characterController.Move(this.characterController.transform.forward * Time.deltaTime * num, Quaternion.identity);
		}

		// Token: 0x04000BFA RID: 3066
		public CharacterThirdPerson characterController;

		// Token: 0x04000BFB RID: 3067
		public float pivotOffset;

		// Token: 0x04000BFC RID: 3068
		public AnimationCurve moveSpeed;

		// Token: 0x04000BFD RID: 3069
		private Animator animator;
	}
}
