using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000175 RID: 373
	[MovedFrom("Unity.GameCore")]
	public class XStoreImage
	{
		// Token: 0x060008D9 RID: 2265 RVA: 0x0000E1BA File Offset: 0x0000C3BA
		internal XStoreImage(XStoreImage interop)
		{
			this.interop = interop;
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0000E1C9 File Offset: 0x0000C3C9
		public XStoreImage()
		{
			this.interop = default(XStoreImage);
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x0000E1DD File Offset: 0x0000C3DD
		// (set) Token: 0x060008DC RID: 2268 RVA: 0x0000E1EA File Offset: 0x0000C3EA
		public string Uri
		{
			get
			{
				return this.interop.uri;
			}
			set
			{
				this.interop.uri = value;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x0000E1F8 File Offset: 0x0000C3F8
		// (set) Token: 0x060008DE RID: 2270 RVA: 0x0000E205 File Offset: 0x0000C405
		public uint Height
		{
			get
			{
				return this.interop.height;
			}
			set
			{
				this.interop.height = value;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x060008DF RID: 2271 RVA: 0x0000E213 File Offset: 0x0000C413
		// (set) Token: 0x060008E0 RID: 2272 RVA: 0x0000E220 File Offset: 0x0000C420
		public uint Width
		{
			get
			{
				return this.interop.width;
			}
			set
			{
				this.interop.width = value;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x0000E22E File Offset: 0x0000C42E
		// (set) Token: 0x060008E2 RID: 2274 RVA: 0x0000E23B File Offset: 0x0000C43B
		public string Caption
		{
			get
			{
				return this.interop.caption;
			}
			set
			{
				this.interop.caption = value;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x060008E3 RID: 2275 RVA: 0x0000E249 File Offset: 0x0000C449
		// (set) Token: 0x060008E4 RID: 2276 RVA: 0x0000E256 File Offset: 0x0000C456
		public string ImagePurposeTag
		{
			get
			{
				return this.interop.imagePurposeTag;
			}
			set
			{
				this.interop.imagePurposeTag = value;
			}
		}

		// Token: 0x0400052D RID: 1325
		internal XStoreImage interop;
	}
}
