using System;

namespace Invector.vCharacterController
{
	// Token: 0x020003F3 RID: 1011
	public interface vIAnimatorMoveReceiver
	{
		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06001469 RID: 5225
		// (set) Token: 0x0600146A RID: 5226
		bool enabled { get; set; }

		// Token: 0x0600146B RID: 5227
		void OnAnimatorMoveEvent();
	}
}
