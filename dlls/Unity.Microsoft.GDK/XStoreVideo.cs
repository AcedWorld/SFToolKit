using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200017A RID: 378
	[MovedFrom("Unity.GameCore")]
	public class XStoreVideo
	{
		// Token: 0x06000921 RID: 2337 RVA: 0x0000E5F3 File Offset: 0x0000C7F3
		internal XStoreVideo(XStoreVideo interop)
		{
			this._interop = interop;
			this._previewImage = new XStoreImage(this._interop.previewImage);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0000E618 File Offset: 0x0000C818
		public XStoreVideo()
		{
			this._interop = default(XStoreVideo);
			this._previewImage = new XStoreImage();
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x0000E637 File Offset: 0x0000C837
		// (set) Token: 0x06000924 RID: 2340 RVA: 0x0000E655 File Offset: 0x0000C855
		internal XStoreVideo interop
		{
			get
			{
				this._interop.previewImage = this._previewImage.interop;
				return this._interop;
			}
			set
			{
				this._interop = value;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0000E65E File Offset: 0x0000C85E
		// (set) Token: 0x06000926 RID: 2342 RVA: 0x0000E66B File Offset: 0x0000C86B
		public string Uri
		{
			get
			{
				return this._interop.uri;
			}
			set
			{
				this._interop.uri = value;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x0000E679 File Offset: 0x0000C879
		// (set) Token: 0x06000928 RID: 2344 RVA: 0x0000E686 File Offset: 0x0000C886
		public uint Height
		{
			get
			{
				return this._interop.height;
			}
			set
			{
				this._interop.height = value;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x0000E694 File Offset: 0x0000C894
		// (set) Token: 0x0600092A RID: 2346 RVA: 0x0000E6A1 File Offset: 0x0000C8A1
		public uint Width
		{
			get
			{
				return this._interop.width;
			}
			set
			{
				this._interop.width = value;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x0000E6AF File Offset: 0x0000C8AF
		// (set) Token: 0x0600092C RID: 2348 RVA: 0x0000E6BC File Offset: 0x0000C8BC
		public string Caption
		{
			get
			{
				return this._interop.caption;
			}
			set
			{
				this._interop.caption = value;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x0000E6CA File Offset: 0x0000C8CA
		// (set) Token: 0x0600092E RID: 2350 RVA: 0x0000E6D7 File Offset: 0x0000C8D7
		public string VideoPurposeTag
		{
			get
			{
				return this._interop.videoPurposeTag;
			}
			set
			{
				this._interop.videoPurposeTag = value;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0000E6E5 File Offset: 0x0000C8E5
		// (set) Token: 0x06000930 RID: 2352 RVA: 0x0000E6ED File Offset: 0x0000C8ED
		public XStoreImage PreviewImage
		{
			get
			{
				return this._previewImage;
			}
			set
			{
				this._interop.previewImage = value.interop;
				this._previewImage = value;
			}
		}

		// Token: 0x04000533 RID: 1331
		internal XStoreVideo _interop;

		// Token: 0x04000534 RID: 1332
		internal XStoreImage _previewImage;
	}
}
