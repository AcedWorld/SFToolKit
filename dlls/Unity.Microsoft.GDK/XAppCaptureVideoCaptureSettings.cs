using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000026 RID: 38
	public class XAppCaptureVideoCaptureSettings
	{
		// Token: 0x060002EE RID: 750 RVA: 0x000090AF File Offset: 0x000072AF
		internal XAppCaptureVideoCaptureSettings(XAppCaptureVideoCaptureSettings interop)
		{
			this.interop = interop;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000090BE File Offset: 0x000072BE
		public XAppCaptureVideoCaptureSettings()
		{
			this.interop = default(XAppCaptureVideoCaptureSettings);
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x000090D2 File Offset: 0x000072D2
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x000090DF File Offset: 0x000072DF
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

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x000090ED File Offset: 0x000072ED
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x000090FA File Offset: 0x000072FA
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

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00009108 File Offset: 0x00007308
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00009115 File Offset: 0x00007315
		public ulong MaxRecordTimespanDurationInMs
		{
			get
			{
				return this.interop.maxRecordTimespanDurationInMs;
			}
			set
			{
				this.interop.maxRecordTimespanDurationInMs = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00009123 File Offset: 0x00007323
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x00009130 File Offset: 0x00007330
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

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0000913E File Offset: 0x0000733E
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x0000914B File Offset: 0x0000734B
		public XAppCaptureVideoColorFormat ColorFormat
		{
			get
			{
				return this.interop.colorFormat;
			}
			set
			{
				this.interop.colorFormat = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00009159 File Offset: 0x00007359
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00009166 File Offset: 0x00007366
		public bool IsCaptureByGamesAllowed
		{
			get
			{
				return this.interop.isCaptureByGamesAllowed;
			}
			set
			{
				this.interop.isCaptureByGamesAllowed = value;
			}
		}

		// Token: 0x040000B9 RID: 185
		internal XAppCaptureVideoCaptureSettings interop;
	}
}
