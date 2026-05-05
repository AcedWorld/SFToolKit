using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200004A RID: 74
	[AddComponentMenu("Scripts/RootMotion.Dynamics/PuppetMaster/Behaviours/BehaviourTemplate")]
	public class BehaviourTemplate : BehaviourBase
	{
		// Token: 0x060001F6 RID: 502 RVA: 0x0000B9BE File Offset: 0x00009BBE
		protected override string GetTypeSpring()
		{
			return "BehaviourTemplate";
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000B9C5 File Offset: 0x00009BC5
		protected override void OnInitiate()
		{
			this.centerOfMass.Initiate(this, this.groundLayers);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000223E File Offset: 0x0000043E
		protected override void OnActivate()
		{
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000223E File Offset: 0x0000043E
		public override void OnReactivate()
		{
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000223E File Offset: 0x0000043E
		protected override void OnDeactivate()
		{
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000B9D9 File Offset: 0x00009BD9
		protected override void OnFixedUpdate(float deltaTime)
		{
			if (this.centerOfMass.angle > this.loseBalanceAngle)
			{
				this.onLoseBalance.Trigger(this.puppetMaster, true);
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000223E File Offset: 0x0000043E
		protected override void OnLateUpdate(float deltaTime)
		{
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000BA00 File Offset: 0x00009C00
		protected override void OnMuscleHitBehaviour(MuscleHit hit)
		{
			bool enabled = base.enabled;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000BA00 File Offset: 0x00009C00
		protected override void OnMuscleCollisionBehaviour(MuscleCollision m)
		{
			bool enabled = base.enabled;
		}

		// Token: 0x040001BF RID: 447
		private const string typeSpring = "BehaviourTemplate";

		// Token: 0x040001C0 RID: 448
		public SubBehaviourCOM centerOfMass;

		// Token: 0x040001C1 RID: 449
		public LayerMask groundLayers;

		// Token: 0x040001C2 RID: 450
		public BehaviourBase.PuppetEvent onLoseBalance;

		// Token: 0x040001C3 RID: 451
		public float loseBalanceAngle = 60f;
	}
}
