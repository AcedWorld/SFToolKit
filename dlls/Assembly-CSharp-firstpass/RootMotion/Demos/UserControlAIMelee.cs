using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B7 RID: 439
	public class UserControlAIMelee : UserControlThirdPerson
	{
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x00049434 File Offset: 0x00047634
		private Transform moveTarget
		{
			get
			{
				return this.targetPuppet.puppetMaster.muscles[0].joint.transform;
			}
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x00049454 File Offset: 0x00047654
		protected override void Update()
		{
			float d = this.walkByDefault ? 0.5f : 1f;
			Vector3 vector = this.moveTarget.position - base.transform.position;
			vector.y = 0f;
			float num = (this.state.move != Vector3.zero) ? this.stoppingDistance : (this.stoppingDistance * this.stoppingThreshold);
			this.state.move = ((vector.magnitude > num) ? (vector.normalized * d) : Vector3.zero);
			this.state.lookPos = this.moveTarget.position + base.transform.right * -0.2f;
			if (this.CanAttack())
			{
				this.attackTimer += Time.deltaTime;
			}
			else
			{
				this.attackTimer = 0f;
			}
			this.state.actionIndex = ((this.attackTimer > 0.5f) ? 1 : 0);
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x00049568 File Offset: 0x00047768
		private bool CanAttack()
		{
			if (this.targetPuppet.state == BehaviourPuppet.State.Unpinned)
			{
				return false;
			}
			Vector3 vector = this.state.lookPos - base.transform.position;
			vector = Quaternion.Inverse(base.transform.rotation) * vector;
			return Mathf.Atan2(vector.x, vector.z) * 57.29578f <= 20f && this.state.move == Vector3.zero;
		}

		// Token: 0x04000BED RID: 3053
		public BehaviourPuppet targetPuppet;

		// Token: 0x04000BEE RID: 3054
		public float stoppingDistance = 0.5f;

		// Token: 0x04000BEF RID: 3055
		public float stoppingThreshold = 1.5f;

		// Token: 0x04000BF0 RID: 3056
		private bool isAttacking;

		// Token: 0x04000BF1 RID: 3057
		private float attackTimer;
	}
}
