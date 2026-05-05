using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200021B RID: 539
	internal struct XblPresenceDeviceRecord
	{
		// Token: 0x06000DD1 RID: 3537 RVA: 0x000110FB File Offset: 0x0000F2FB
		internal T[] GetTitleRecords<T>(Func<XblPresenceTitleRecord, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblPresenceTitleRecord>(this.titleRecords, this.titleRecordsCount, ctor);
		}

		// Token: 0x04000779 RID: 1913
		internal readonly XblPresenceDeviceType deviceType;

		// Token: 0x0400077A RID: 1914
		private readonly IntPtr titleRecords;

		// Token: 0x0400077B RID: 1915
		private readonly SizeT titleRecordsCount;
	}
}
