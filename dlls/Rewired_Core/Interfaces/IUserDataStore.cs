using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001EF RID: 495
	public interface IUserDataStore
	{
		// Token: 0x060018F4 RID: 6388
		void Save();

		// Token: 0x060018F5 RID: 6389
		void SaveControllerData(int playerId, ControllerType controllerType, int controllerId);

		// Token: 0x060018F6 RID: 6390
		void SaveControllerData(ControllerType controllerType, int controllerId);

		// Token: 0x060018F7 RID: 6391
		void SavePlayerData(int playerId);

		// Token: 0x060018F8 RID: 6392
		void SaveInputBehavior(int playerId, int behaviorId);

		// Token: 0x060018F9 RID: 6393
		void Load();

		// Token: 0x060018FA RID: 6394
		void LoadControllerData(int playerId, ControllerType controllerType, int controllerId);

		// Token: 0x060018FB RID: 6395
		void LoadControllerData(ControllerType controllerType, int controllerId);

		// Token: 0x060018FC RID: 6396
		void LoadPlayerData(int playerId);

		// Token: 0x060018FD RID: 6397
		void LoadInputBehavior(int playerId, int behaviorId);
	}
}
