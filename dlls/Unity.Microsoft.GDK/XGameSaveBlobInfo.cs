using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000126 RID: 294
	[MovedFrom("Unity.GameCore")]
	public class XGameSaveBlobInfo
	{
		// Token: 0x0600076A RID: 1898 RVA: 0x0000CF21 File Offset: 0x0000B121
		internal XGameSaveBlobInfo(XGameSaveBlobInfo interop)
		{
			this.interop = interop;
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0000CF30 File Offset: 0x0000B130
		public XGameSaveBlobInfo()
		{
			this.interop = default(XGameSaveBlobInfo);
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0000CF44 File Offset: 0x0000B144
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x0000CF51 File Offset: 0x0000B151
		public string Name
		{
			get
			{
				return this.interop.name;
			}
			set
			{
				this.interop.name = value;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x0000CF5F File Offset: 0x0000B15F
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x0000CF6C File Offset: 0x0000B16C
		public uint Size
		{
			get
			{
				return this.interop.size;
			}
			set
			{
				this.interop.size = value;
			}
		}

		// Token: 0x0400045B RID: 1115
		internal XGameSaveBlobInfo interop;
	}
}
