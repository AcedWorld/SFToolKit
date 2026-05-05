using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000029 RID: 41
	internal interface IBackoffStrategy
	{
		// Token: 0x060000A5 RID: 165
		float GetNext();

		// Token: 0x060000A6 RID: 166
		void Reset();
	}
}
