using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000017 RID: 23
	internal interface IResettable
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000057 RID: 87
		bool ShouldResetOnDispatch { get; }

		// Token: 0x06000058 RID: 88
		void Reset();
	}
}
