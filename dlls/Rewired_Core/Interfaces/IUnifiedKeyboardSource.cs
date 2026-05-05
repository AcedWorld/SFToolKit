using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001E9 RID: 489
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IUnifiedKeyboardSource
	{
		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x060018D0 RID: 6352
		InputSource inputSource { get; }

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x060018D1 RID: 6353
		HardwareControllerMap_Game hardwareMap { get; }

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x060018D2 RID: 6354
		int buttonCount { get; }

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x060018D3 RID: 6355
		Controller.Extension controllerExtension { get; }

		// Token: 0x060018D4 RID: 6356
		void UpdateInputData(ControllerDataUpdater dataUpdater);

		// Token: 0x060018D5 RID: 6357
		void Clear();
	}
}
