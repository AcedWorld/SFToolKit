using System;
using UnityEngine;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x0200040D RID: 1037
	public interface IActionController
	{
		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06001565 RID: 5477
		// (set) Token: 0x06001566 RID: 5478
		bool enabled { get; set; }

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06001567 RID: 5479
		GameObject gameObject { get; }

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06001568 RID: 5480
		Transform transform { get; }

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06001569 RID: 5481
		string name { get; }

		// Token: 0x0600156A RID: 5482
		Type GetType();
	}
}
