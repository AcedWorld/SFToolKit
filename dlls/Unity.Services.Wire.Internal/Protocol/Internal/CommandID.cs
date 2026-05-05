using System;

namespace Unity.Services.Wire.Protocol.Internal
{
	// Token: 0x02000006 RID: 6
	internal static class CommandID
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000021B8 File Offset: 0x000003B8
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000021B0 File Offset: 0x000003B0
		public static uint currentId { get; private set; }

		// Token: 0x06000010 RID: 16 RVA: 0x000021BF File Offset: 0x000003BF
		public static uint GenerateNewId()
		{
			return CommandID.currentId += 1U;
		}
	}
}
