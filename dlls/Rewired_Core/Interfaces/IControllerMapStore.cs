using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001F0 RID: 496
	public interface IControllerMapStore
	{
		// Token: 0x060018FE RID: 6398
		void SaveControllerMap(int playerId, ControllerMap controllerMap);

		// Token: 0x060018FF RID: 6399
		ControllerMap LoadControllerMap(int playerId, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId);
	}
}
