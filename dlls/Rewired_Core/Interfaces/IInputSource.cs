using System;
using System.Collections.Generic;

namespace Rewired.Interfaces
{
	// Token: 0x020001E5 RID: 485
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IInputSource : IDisposable
	{
		// Token: 0x14000031 RID: 49
		// (add) Token: 0x060018BA RID: 6330
		// (remove) Token: 0x060018BB RID: 6331
		event Action DeviceChangedEvent;

		// Token: 0x060018BC RID: 6332
		void SystemDeviceConnected();

		// Token: 0x060018BD RID: 6333
		void SystemDeviceDisconnected();

		// Token: 0x060018BE RID: 6334
		void Update();

		// Token: 0x060018BF RID: 6335
		void UpdateDevices(UpdateLoopType updateLoop);

		// Token: 0x060018C0 RID: 6336
		void UpdateFinished();

		// Token: 0x060018C1 RID: 6337
		IList<TJoy> GetJoysticks<TJoy>() where TJoy : class;
	}
}
