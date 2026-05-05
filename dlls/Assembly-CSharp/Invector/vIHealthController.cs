using System;

namespace Invector
{
	// Token: 0x0200036C RID: 876
	public interface vIHealthController : vIDamageReceiver
	{
		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060011B9 RID: 4537
		OnDead onDead { get; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060011BA RID: 4538
		float currentHealth { get; }

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060011BB RID: 4539
		int MaxHealth { get; }

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060011BC RID: 4540
		// (set) Token: 0x060011BD RID: 4541
		bool isDead { get; set; }

		// Token: 0x060011BE RID: 4542
		void AddHealth(int value);

		// Token: 0x060011BF RID: 4543
		void ChangeHealth(int value);

		// Token: 0x060011C0 RID: 4544
		void ChangeMaxHealth(int value);

		// Token: 0x060011C1 RID: 4545
		void ResetHealth(float health);

		// Token: 0x060011C2 RID: 4546
		void ResetHealth();
	}
}
