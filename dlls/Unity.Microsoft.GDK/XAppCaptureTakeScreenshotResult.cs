using System;
using System.Text;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000022 RID: 34
	[MovedFrom("Unity.GameCore")]
	public class XAppCaptureTakeScreenshotResult
	{
		// Token: 0x060002A1 RID: 673 RVA: 0x00008C71 File Offset: 0x00006E71
		internal XAppCaptureTakeScreenshotResult(XAppCaptureTakeScreenshotResult interop)
		{
			this.data = interop;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00008C80 File Offset: 0x00006E80
		public XAppCaptureTakeScreenshotResult()
		{
			this.data = default(XAppCaptureTakeScreenshotResult);
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x00008C94 File Offset: 0x00006E94
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public string LocalId
		{
			get
			{
				return this.data.localId;
			}
			set
			{
				this.data.localId = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00008CAF File Offset: 0x00006EAF
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x00008CBC File Offset: 0x00006EBC
		public XAppCaptureScreenshotFormatFlag AvailableScreenshotFormats
		{
			get
			{
				return this.data.availableScreenshotFormats;
			}
			set
			{
				this.data.availableScreenshotFormats = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00008CCA File Offset: 0x00006ECA
		[Obsolete("XAppScreenshotLocalId will be removed in future releases. Use XAppCaptureTakeScreenshotResult.localId", false)]
		public XAppScreenshotLocalId Id
		{
			get
			{
				return new XAppScreenshotLocalId(Encoding.UTF8.GetBytes(this.data.localId));
			}
		}

		// Token: 0x040000B5 RID: 181
		internal XAppCaptureTakeScreenshotResult data;
	}
}
