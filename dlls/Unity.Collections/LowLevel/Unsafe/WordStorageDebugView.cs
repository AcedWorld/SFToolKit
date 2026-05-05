using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000E3 RID: 227
	[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
	internal sealed class WordStorageDebugView
	{
		// Token: 0x06000920 RID: 2336 RVA: 0x0001CBA7 File Offset: 0x0001ADA7
		public WordStorageDebugView(WordStorage wordStorage)
		{
			this.m_wordStorage = wordStorage;
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x0001CBB8 File Offset: 0x0001ADB8
		public FixedString128Bytes[] Table
		{
			get
			{
				FixedString128Bytes[] array = new FixedString128Bytes[this.m_wordStorage.Entries];
				for (int i = 0; i < this.m_wordStorage.Entries; i++)
				{
					this.m_wordStorage.GetFixedString<FixedString128Bytes>(i, ref array[i]);
				}
				return array;
			}
		}

		// Token: 0x04000325 RID: 805
		private WordStorage m_wordStorage;
	}
}
