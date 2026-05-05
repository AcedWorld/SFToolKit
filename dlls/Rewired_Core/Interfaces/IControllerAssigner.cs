using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001F2 RID: 498
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface IControllerAssigner
	{
		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06001917 RID: 6423
		// (set) Token: 0x06001918 RID: 6424
		bool enabled { get; set; }

		// Token: 0x06001919 RID: 6425
		bool CanHandleAssignment(ControllerType controllerType, Controller controller);

		// Token: 0x0600191A RID: 6426
		void AssignController(ControllerType controllerType, Controller controller);
	}
}
