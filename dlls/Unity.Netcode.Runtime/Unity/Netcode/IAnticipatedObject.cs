using System;

namespace Unity.Netcode
{
	// Token: 0x02000119 RID: 281
	internal interface IAnticipatedObject
	{
		// Token: 0x060008DA RID: 2266
		void Update();

		// Token: 0x060008DB RID: 2267
		void ResetAnticipation();

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060008DC RID: 2268
		NetworkObject OwnerObject { get; }
	}
}
