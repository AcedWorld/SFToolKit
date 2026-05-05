using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000160 RID: 352
	[MovedFrom("Unity.GameCore")]
	public class XPackageFeature
	{
		// Token: 0x06000870 RID: 2160 RVA: 0x0000DD19 File Offset: 0x0000BF19
		internal XPackageFeature(XPackageFeature interop)
		{
			this._interop = interop;
			this._storeIds = InteropHelpers.MarshalStringArrayAnsi(interop.storeIds, interop.storeIdCount);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0000DD3F File Offset: 0x0000BF3F
		public XPackageFeature()
		{
			this._interop = default(XPackageFeature);
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x0000DD53 File Offset: 0x0000BF53
		// (set) Token: 0x06000873 RID: 2163 RVA: 0x0000DD60 File Offset: 0x0000BF60
		public string Id
		{
			get
			{
				return this._interop.id;
			}
			set
			{
				this._interop.id = value;
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0000DD6E File Offset: 0x0000BF6E
		// (set) Token: 0x06000875 RID: 2165 RVA: 0x0000DD7B File Offset: 0x0000BF7B
		public string DisplayName
		{
			get
			{
				return this._interop.displayName;
			}
			set
			{
				this._interop.displayName = value;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0000DD89 File Offset: 0x0000BF89
		// (set) Token: 0x06000877 RID: 2167 RVA: 0x0000DD96 File Offset: 0x0000BF96
		public string Tags
		{
			get
			{
				return this._interop.tags;
			}
			set
			{
				this._interop.tags = value;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x0000DDA4 File Offset: 0x0000BFA4
		// (set) Token: 0x06000879 RID: 2169 RVA: 0x0000DDB1 File Offset: 0x0000BFB1
		public bool Hidden
		{
			get
			{
				return this._interop.hidden;
			}
			set
			{
				this._interop.hidden = value;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x0000DDBF File Offset: 0x0000BFBF
		// (set) Token: 0x0600087B RID: 2171 RVA: 0x0000DDC7 File Offset: 0x0000BFC7
		public string[] StoreIds
		{
			get
			{
				return this._storeIds;
			}
			set
			{
				this._storeIds = value;
			}
		}

		// Token: 0x0400050D RID: 1293
		internal XPackageFeature _interop;

		// Token: 0x0400050E RID: 1294
		private string[] _storeIds;
	}
}
