using System;
using UnityEngine;

namespace Rewired.Interfaces
{
	// Token: 0x020001E8 RID: 488
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IUnifiedMouseSource
	{
		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x060018C8 RID: 6344
		InputSource inputSource { get; }

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x060018C9 RID: 6345
		HardwareControllerMap_Game hardwareMap { get; }

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x060018CA RID: 6346
		int axisCount { get; }

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x060018CB RID: 6347
		int buttonCount { get; }

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x060018CC RID: 6348
		Vector2 mousePosition { get; }

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x060018CD RID: 6349
		Controller.Extension controllerExtension { get; }

		// Token: 0x060018CE RID: 6350
		void UpdateInputData(ControllerDataUpdater dataUpdater);

		// Token: 0x060018CF RID: 6351
		void Clear();
	}
}
