using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000067 RID: 103
	public class XblAchievementProgressChangeEventArgs
	{
		// Token: 0x06000424 RID: 1060 RVA: 0x000098B4 File Offset: 0x00007AB4
		internal XblAchievementProgressChangeEventArgs(XblAchievementProgressChangeEventArgs interopEventArgs)
		{
			this.UpdatedAchievementEntries = InteropHelpers.MarshalArray<XblAchievementProgressChangeEntry, XblAchievementProgressChangeEntry>(interopEventArgs.updatedAchievementEntries, interopEventArgs.entryCount, (XblAchievementProgressChangeEntry entriesInterop) => new XblAchievementProgressChangeEntry(entriesInterop));
			this.EntryCount = (ulong)interopEventArgs.entryCount;
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0000990A File Offset: 0x00007B0A
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x00009912 File Offset: 0x00007B12
		public XblAchievementProgressChangeEntry[] UpdatedAchievementEntries { get; private set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0000991B File Offset: 0x00007B1B
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x00009923 File Offset: 0x00007B23
		public ulong EntryCount { get; private set; }
	}
}
