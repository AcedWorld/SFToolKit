using System;
using System.Runtime.InteropServices;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200015D RID: 349
	[MovedFrom("Unity.GameCore")]
	public class XPackageChunkSelector
	{
		// Token: 0x0600084A RID: 2122 RVA: 0x0000DAE7 File Offset: 0x0000BCE7
		internal XPackageChunkSelector(XPackageChunkSelectorInterop interop)
		{
			this._languageOrTagOrFeature = Marshal.PtrToStringAnsi(interop.languageOrTagOrFeature);
			this.interop = interop;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0000DB07 File Offset: 0x0000BD07
		public XPackageChunkSelector()
		{
			this.interop = default(XPackageChunkSelectorInterop);
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x0000DB1B File Offset: 0x0000BD1B
		// (set) Token: 0x0600084D RID: 2125 RVA: 0x0000DB28 File Offset: 0x0000BD28
		public XPackageChunkSelectorType Type
		{
			get
			{
				return this.interop.type;
			}
			set
			{
				this.interop.type = value;
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x0000DB36 File Offset: 0x0000BD36
		// (set) Token: 0x0600084F RID: 2127 RVA: 0x0000DB3E File Offset: 0x0000BD3E
		public string LanguageTagOrFeature
		{
			get
			{
				return this._languageOrTagOrFeature;
			}
			set
			{
				this._languageOrTagOrFeature = value;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0000DB47 File Offset: 0x0000BD47
		// (set) Token: 0x06000851 RID: 2129 RVA: 0x0000DB54 File Offset: 0x0000BD54
		public uint ChunkId
		{
			get
			{
				return this.interop.chunkId;
			}
			set
			{
				this.interop.chunkId = value;
			}
		}

		// Token: 0x04000508 RID: 1288
		internal XPackageChunkSelectorInterop interop;

		// Token: 0x04000509 RID: 1289
		internal string _languageOrTagOrFeature;
	}
}
