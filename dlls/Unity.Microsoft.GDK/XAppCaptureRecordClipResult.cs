using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000023 RID: 35
	[MovedFrom("Unity.GameCore")]
	public class XAppCaptureRecordClipResult
	{
		// Token: 0x060002A8 RID: 680 RVA: 0x00008CE6 File Offset: 0x00006EE6
		internal XAppCaptureRecordClipResult(XAppCaptureRecordClipResult interop)
		{
			this.interop = interop;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00008CF5 File Offset: 0x00006EF5
		public XAppCaptureRecordClipResult()
		{
			this.interop = default(XAppCaptureRecordClipResult);
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00008D09 File Offset: 0x00006F09
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00008D16 File Offset: 0x00006F16
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

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00008D24 File Offset: 0x00006F24
		// (set) Token: 0x060002AD RID: 685 RVA: 0x00008D31 File Offset: 0x00006F31
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

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060002AE RID: 686 RVA: 0x00008D3F File Offset: 0x00006F3F
		// (set) Token: 0x060002AF RID: 687 RVA: 0x00008D4C File Offset: 0x00006F4C
		public long StartTime
		{
			get
			{
				return this.interop.startTime;
			}
			set
			{
				this.interop.startTime = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00008D5A File Offset: 0x00006F5A
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00008D67 File Offset: 0x00006F67
		public uint DurationInMs
		{
			get
			{
				return this.interop.durationInMs;
			}
			set
			{
				this.interop.durationInMs = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00008D75 File Offset: 0x00006F75
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x00008D82 File Offset: 0x00006F82
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

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00008D90 File Offset: 0x00006F90
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x00008D9D File Offset: 0x00006F9D
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

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x00008DAB File Offset: 0x00006FAB
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x00008DB8 File Offset: 0x00006FB8
		public XAppCaptureVideoEncoding Encoding
		{
			get
			{
				return this.interop.encoding;
			}
			set
			{
				this.interop.encoding = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00008DC6 File Offset: 0x00006FC6
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00008DD3 File Offset: 0x00006FD3
		public uint StartTimePreciseOffsetHns
		{
			get
			{
				return this.interop.startTimePreciseOffsetHns;
			}
			set
			{
				this.interop.startTimePreciseOffsetHns = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00008DE1 File Offset: 0x00006FE1
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00008DEE File Offset: 0x00006FEE
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

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00008DFC File Offset: 0x00006FFC
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00008E09 File Offset: 0x00007009
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

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00008E17 File Offset: 0x00007017
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00008E24 File Offset: 0x00007024
		[Obsolete("Please use StartTime instead, (UnityUpgradable) -> StartTime", true)]
		public long startTime
		{
			get
			{
				return this.interop.startTime;
			}
			set
			{
				this.interop.startTime = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00008E32 File Offset: 0x00007032
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00008E3F File Offset: 0x0000703F
		[Obsolete("Please use DurationInMs instead, (UnityUpgradable) -> DurationInMs", true)]
		public uint durationInMs
		{
			get
			{
				return this.interop.durationInMs;
			}
			set
			{
				this.interop.durationInMs = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00008E4D File Offset: 0x0000704D
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00008E5A File Offset: 0x0000705A
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

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00008E68 File Offset: 0x00007068
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00008E75 File Offset: 0x00007075
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

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00008E83 File Offset: 0x00007083
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00008E90 File Offset: 0x00007090
		[Obsolete("Please use Encoding instead, (UnityUpgradable) -> Encoding", true)]
		public XAppCaptureVideoEncoding encoding
		{
			get
			{
				return this.interop.encoding;
			}
			set
			{
				this.interop.encoding = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00008E9E File Offset: 0x0000709E
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00008EAB File Offset: 0x000070AB
		[Obsolete("Please use StartTimePreciseOffsetHns instead, (UnityUpgradable) -> StartTimePreciseOffsetHns", true)]
		public uint startTimePreciseOffsetHns
		{
			get
			{
				return this.interop.startTimePreciseOffsetHns;
			}
			set
			{
				this.interop.startTimePreciseOffsetHns = value;
			}
		}

		// Token: 0x040000B6 RID: 182
		internal XAppCaptureRecordClipResult interop;
	}
}
