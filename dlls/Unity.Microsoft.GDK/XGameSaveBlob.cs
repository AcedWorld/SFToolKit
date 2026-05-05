using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000127 RID: 295
	[MovedFrom("Unity.GameCore")]
	public class XGameSaveBlob
	{
		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0000CF7A File Offset: 0x0000B17A
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x0000CF82 File Offset: 0x0000B182
		public XGameSaveBlobInfo Info { get; set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0000CF8B File Offset: 0x0000B18B
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x0000CF93 File Offset: 0x0000B193
		public byte[] Data { get; set; }

		// Token: 0x06000774 RID: 1908 RVA: 0x0000CF9C File Offset: 0x0000B19C
		internal XGameSaveBlob(XGameSaveBlobInterop interop)
		{
			this.Info = new XGameSaveBlobInfo(interop.info);
			this.Data = InteropHelpers.MarshalArray<byte>(interop.data, interop.info.size);
		}
	}
}
