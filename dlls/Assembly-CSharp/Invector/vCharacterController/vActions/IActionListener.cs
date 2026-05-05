using System;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x02000412 RID: 1042
	public interface IActionListener : IActionEnterListener, IActionController, IActionExitListener, IActionStayListener
	{
		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x0600156F RID: 5487
		// (set) Token: 0x06001570 RID: 5488
		bool actionEnter { get; set; }

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06001571 RID: 5489
		// (set) Token: 0x06001572 RID: 5490
		bool actionExit { get; set; }

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06001573 RID: 5491
		// (set) Token: 0x06001574 RID: 5492
		bool actionStay { get; set; }

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06001575 RID: 5493
		// (set) Token: 0x06001576 RID: 5494
		bool doingAction { get; set; }
	}
}
