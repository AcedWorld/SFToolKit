using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000169 RID: 361
	[MovedFrom("Unity.GameCore")]
	public class XPersistentLocalStorageSpaceInfo
	{
		// Token: 0x060008AA RID: 2218 RVA: 0x0000DF33 File Offset: 0x0000C133
		internal XPersistentLocalStorageSpaceInfo(XPersistentLocalStorageSpaceInfo interop)
		{
			this.interop = interop;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0000DF42 File Offset: 0x0000C142
		public XPersistentLocalStorageSpaceInfo()
		{
			this.interop = default(XPersistentLocalStorageSpaceInfo);
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x0000DF56 File Offset: 0x0000C156
		// (set) Token: 0x060008AD RID: 2221 RVA: 0x0000DF63 File Offset: 0x0000C163
		public ulong AvailableFreeBytes
		{
			get
			{
				return this.interop.availableFreeBytes;
			}
			set
			{
				this.interop.availableFreeBytes = value;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x0000DF71 File Offset: 0x0000C171
		// (set) Token: 0x060008AF RID: 2223 RVA: 0x0000DF7E File Offset: 0x0000C17E
		public ulong TotalFreeBytes
		{
			get
			{
				return this.interop.totalFreeBytes;
			}
			set
			{
				this.interop.totalFreeBytes = value;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x0000DF8C File Offset: 0x0000C18C
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x0000DF99 File Offset: 0x0000C199
		public ulong UsedBytes
		{
			get
			{
				return this.interop.usedBytes;
			}
			set
			{
				this.interop.usedBytes = value;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x0000DFA7 File Offset: 0x0000C1A7
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x0000DFB4 File Offset: 0x0000C1B4
		public ulong TotalBytes
		{
			get
			{
				return this.interop.totalBytes;
			}
			set
			{
				this.interop.totalBytes = value;
			}
		}

		// Token: 0x04000512 RID: 1298
		internal XPersistentLocalStorageSpaceInfo interop;
	}
}
