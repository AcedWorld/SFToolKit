using System;

namespace Unity.Netcode
{
	// Token: 0x02000118 RID: 280
	internal interface IAnticipationEventReceiver
	{
		// Token: 0x060008D8 RID: 2264
		void SetupForUpdate();

		// Token: 0x060008D9 RID: 2265
		void SetupForRender();
	}
}
