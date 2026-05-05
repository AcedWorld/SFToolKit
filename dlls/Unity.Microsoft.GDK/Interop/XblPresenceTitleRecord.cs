using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000221 RID: 545
	internal struct XblPresenceTitleRecord
	{
		// Token: 0x06000DDD RID: 3549 RVA: 0x0001121E File Offset: 0x0000F41E
		internal T GetBroadcastRecord<T>(Func<XblPresenceBroadcastRecord, T> ctor) where T : class
		{
			return Converters.PtrToClass<T, XblPresenceBroadcastRecord>(this.broadcastRecord, ctor);
		}

		// Token: 0x04000788 RID: 1928
		internal readonly uint titleId;

		// Token: 0x04000789 RID: 1929
		internal readonly UTF8StringPtr titleName;

		// Token: 0x0400078A RID: 1930
		internal readonly TimeT lastModified;

		// Token: 0x0400078B RID: 1931
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool titleActive;

		// Token: 0x0400078C RID: 1932
		internal readonly UTF8StringPtr richPresenceString;

		// Token: 0x0400078D RID: 1933
		internal readonly XblPresenceTitleViewState viewState;

		// Token: 0x0400078E RID: 1934
		private readonly IntPtr broadcastRecord;
	}
}
