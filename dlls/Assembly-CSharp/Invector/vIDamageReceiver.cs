using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000369 RID: 873
	public interface vIDamageReceiver
	{
		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060011B0 RID: 4528
		OnReceiveDamage onStartReceiveDamage { get; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060011B1 RID: 4529
		OnReceiveDamage onReceiveDamage { get; }

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060011B2 RID: 4530
		Transform transform { get; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060011B3 RID: 4531
		GameObject gameObject { get; }

		// Token: 0x060011B4 RID: 4532
		void TakeDamage(vDamage damage);
	}
}
