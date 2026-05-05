using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200019D RID: 413
	[Serializable]
	public struct SteamInputActionEvent_t
	{
		// Token: 0x04000A68 RID: 2664
		public InputHandle_t controllerHandle;

		// Token: 0x04000A69 RID: 2665
		public ESteamInputActionEventType eEventType;

		// Token: 0x04000A6A RID: 2666
		public SteamInputActionEvent_t.OptionValue m_val;

		// Token: 0x020001EA RID: 490
		[Serializable]
		public struct AnalogAction_t
		{
			// Token: 0x04000AE1 RID: 2785
			public InputAnalogActionHandle_t actionHandle;

			// Token: 0x04000AE2 RID: 2786
			public InputAnalogActionData_t analogActionData;
		}

		// Token: 0x020001EB RID: 491
		[Serializable]
		public struct DigitalAction_t
		{
			// Token: 0x04000AE3 RID: 2787
			public InputDigitalActionHandle_t actionHandle;

			// Token: 0x04000AE4 RID: 2788
			public InputDigitalActionData_t digitalActionData;
		}

		// Token: 0x020001EC RID: 492
		[Serializable]
		[StructLayout(LayoutKind.Explicit)]
		public struct OptionValue
		{
			// Token: 0x04000AE5 RID: 2789
			[FieldOffset(0)]
			public SteamInputActionEvent_t.AnalogAction_t analogAction;

			// Token: 0x04000AE6 RID: 2790
			[FieldOffset(0)]
			public SteamInputActionEvent_t.DigitalAction_t digitalAction;
		}
	}
}
