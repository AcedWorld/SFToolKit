using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x020003A5 RID: 933
	[Serializable]
	public class vDamage
	{
		// Token: 0x060012B6 RID: 4790 RVA: 0x00062FBC File Offset: 0x000611BC
		public vDamage()
		{
			this.damageValue = 15f;
			this.staminaBlockCost = 5f;
			this.staminaRecoveryDelay = 1f;
			this.hitReaction = true;
		}

		// Token: 0x060012B7 RID: 4791 RVA: 0x0006301F File Offset: 0x0006121F
		public vDamage(int value)
		{
			this.damageValue = (float)value;
			this.hitReaction = true;
		}

		// Token: 0x060012B8 RID: 4792 RVA: 0x00063060 File Offset: 0x00061260
		public vDamage(int value, bool ignoreReaction)
		{
			this.damageValue = (float)value;
			this.hitReaction = !ignoreReaction;
			if (ignoreReaction)
			{
				this.recoil_id = -1;
				this.reaction_id = -1;
			}
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x000630C0 File Offset: 0x000612C0
		public vDamage(vDamage damage)
		{
			this.damageValue = damage.damageValue;
			this.staminaBlockCost = damage.staminaBlockCost;
			this.staminaRecoveryDelay = damage.staminaRecoveryDelay;
			this.ignoreDefense = damage.ignoreDefense;
			this.activeRagdoll = damage.activeRagdoll;
			this.sender = damage.sender;
			this.receiver = damage.receiver;
			this.recoil_id = damage.recoil_id;
			this.reaction_id = damage.reaction_id;
			this.damageType = damage.damageType;
			this.hitPosition = damage.hitPosition;
			this.senselessTime = damage.senselessTime;
			this.force = damage.force;
		}

		// Token: 0x060012BA RID: 4794 RVA: 0x00063198 File Offset: 0x00061398
		public void ReduceDamage(float damageReduction)
		{
			int num = (int)(this.damageValue - this.damageValue * damageReduction / 100f);
			this.damageValue = (float)num;
		}

		// Token: 0x0400187F RID: 6271
		[Tooltip("Apply damage to the Character Health")]
		public float damageValue = 15f;

		// Token: 0x04001880 RID: 6272
		[Tooltip("How much stamina the target will lost when blocking this attack")]
		public float staminaBlockCost = 5f;

		// Token: 0x04001881 RID: 6273
		[Tooltip("How much time the stamina of the target will wait to recovery")]
		public float staminaRecoveryDelay = 1f;

		// Token: 0x04001882 RID: 6274
		[Tooltip("Apply damage even if the Character is blocking")]
		public bool ignoreDefense;

		// Token: 0x04001883 RID: 6275
		[Tooltip("Activated Ragdoll when hit the Character")]
		public bool activeRagdoll;

		// Token: 0x04001884 RID: 6276
		[vHideInInspector("activeRagdoll", false)]
		[Tooltip("Time to keep Ragdoll active")]
		public float senselessTime;

		// Token: 0x04001885 RID: 6277
		[HideInInspector]
		public Transform sender;

		// Token: 0x04001886 RID: 6278
		[HideInInspector]
		public Transform receiver;

		// Token: 0x04001887 RID: 6279
		[HideInInspector]
		public Vector3 hitPosition;

		// Token: 0x04001888 RID: 6280
		public bool hitReaction = true;

		// Token: 0x04001889 RID: 6281
		[HideInInspector]
		public int recoil_id;

		// Token: 0x0400188A RID: 6282
		[HideInInspector]
		public int reaction_id;

		// Token: 0x0400188B RID: 6283
		public string damageType;

		// Token: 0x0400188C RID: 6284
		[HideInInspector]
		public Vector3 force;
	}
}
