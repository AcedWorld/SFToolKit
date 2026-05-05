using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x020003E5 RID: 997
	public interface vICharacter : vIHealthController, vIDamageReceiver
	{
		// Token: 0x1700037F RID: 895
		// (get) Token: 0x060013C8 RID: 5064
		OnActiveRagdoll onActiveRagdoll { get; }

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x060013C9 RID: 5065
		Animator animator { get; }

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x060013CA RID: 5066
		bool isCrouching { get; }

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x060013CB RID: 5067
		// (set) Token: 0x060013CC RID: 5068
		bool ragdolled { get; set; }

		// Token: 0x060013CD RID: 5069
		void EnableRagdoll();

		// Token: 0x060013CE RID: 5070
		void ResetRagdoll();
	}
}
