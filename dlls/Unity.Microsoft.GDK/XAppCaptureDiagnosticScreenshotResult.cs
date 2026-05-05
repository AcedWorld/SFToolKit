using System;
using System.Collections.Generic;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000020 RID: 32
	[MovedFrom("Unity.GameCore")]
	public class XAppCaptureDiagnosticScreenshotResult
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000278 RID: 632 RVA: 0x00008A04 File Offset: 0x00006C04
		// (set) Token: 0x06000279 RID: 633 RVA: 0x00008A0C File Offset: 0x00006C0C
		public XAppCaptureScreenshotFile[] Files { get; set; }

		// Token: 0x0600027A RID: 634 RVA: 0x00008A18 File Offset: 0x00006C18
		internal XAppCaptureDiagnosticScreenshotResult(XAppCaptureDiagnosticScreenshotResult interop)
		{
			List<XAppCaptureScreenshotFile> list = new List<XAppCaptureScreenshotFile>();
			int num = 0;
			while ((long)num < interop.fileCount)
			{
				XAppCaptureScreenshotFile item = new XAppCaptureScreenshotFile(interop.files[num]);
				list.Add(item);
				num++;
			}
			this.Files = list.ToArray();
		}
	}
}
