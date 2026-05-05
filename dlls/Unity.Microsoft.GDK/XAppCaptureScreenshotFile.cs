using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000024 RID: 36
	[MovedFrom("Unity.GameCore")]
	public class XAppCaptureScreenshotFile
	{
		// Token: 0x060002CA RID: 714 RVA: 0x00008EB9 File Offset: 0x000070B9
		internal XAppCaptureScreenshotFile(XAppCaptureScreenshotFile interop)
		{
			this.interop = interop;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00008EC8 File Offset: 0x000070C8
		internal XAppCaptureScreenshotFile()
		{
			this.interop = default(XAppCaptureScreenshotFile);
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00008EDC File Offset: 0x000070DC
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00008EE9 File Offset: 0x000070E9
		public string Path
		{
			get
			{
				return this.interop.path;
			}
			set
			{
				this.interop.path = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00008EF7 File Offset: 0x000070F7
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00008F04 File Offset: 0x00007104
		public long FileSize
		{
			get
			{
				return this.interop.fileSize;
			}
			set
			{
				this.interop.fileSize = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x00008F12 File Offset: 0x00007112
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x00008F1F File Offset: 0x0000711F
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

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00008F2D File Offset: 0x0000712D
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00008F3A File Offset: 0x0000713A
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

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00008F48 File Offset: 0x00007148
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00008F55 File Offset: 0x00007155
		[Obsolete("Please use Path instead, (UnityUpgradable) -> Path", true)]
		public string path
		{
			get
			{
				return this.interop.path;
			}
			set
			{
				this.interop.path = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00008F63 File Offset: 0x00007163
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00008F70 File Offset: 0x00007170
		[Obsolete("Please use FileSize instead, (UnityUpgradable) -> FileSize", true)]
		public long fileSize
		{
			get
			{
				return this.interop.fileSize;
			}
			set
			{
				this.interop.fileSize = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00008F7E File Offset: 0x0000717E
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00008F8B File Offset: 0x0000718B
		[Obsolete("Please use Width instead, (UnityUpgradable) -> Width", true)]
		public uint width
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

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00008F99 File Offset: 0x00007199
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00008FA6 File Offset: 0x000071A6
		[Obsolete("Please use Height instead, (UnityUpgradable) -> Height", true)]
		public uint height
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

		// Token: 0x040000B7 RID: 183
		internal XAppCaptureScreenshotFile interop;
	}
}
