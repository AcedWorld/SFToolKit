using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000F1 RID: 241
	[MovedFrom("Unity.GameCore")]
	public class XblSocialRelationshipResult : IDisposable
	{
		// Token: 0x06000660 RID: 1632 RVA: 0x0000BDE7 File Offset: 0x00009FE7
		internal XblSocialRelationshipResult(XblSocialRelationshipResultHandle interopHandle)
		{
			this.InteropHandle = interopHandle;
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0000BDF8 File Offset: 0x00009FF8
		~XblSocialRelationshipResult()
		{
			this.Dispose(false);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0000BE28 File Offset: 0x0000A028
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0000BE38 File Offset: 0x0000A038
		protected virtual void Dispose(bool disposing)
		{
			if (this._disposed)
			{
				return;
			}
			XblInterop.XblSocialRelationshipResultCloseHandle(this.InteropHandle);
			this.InteropHandle = default(XblSocialRelationshipResultHandle);
			this._disposed = true;
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x0000BE6F File Offset: 0x0000A06F
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x0000BE77 File Offset: 0x0000A077
		internal XblSocialRelationshipResultHandle InteropHandle { get; set; }

		// Token: 0x040003C1 RID: 961
		private bool _disposed;
	}
}
