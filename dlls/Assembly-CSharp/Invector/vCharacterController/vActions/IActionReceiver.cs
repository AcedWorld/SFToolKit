using System;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x0200040E RID: 1038
	public interface IActionReceiver : IActionController
	{
		// Token: 0x0600156B RID: 5483
		void OnReceiveAction(vTriggerGenericAction actionInfo);
	}
}
