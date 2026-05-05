using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200001F RID: 31
	public class XAppCaptureLocalResult
	{
		// Token: 0x06000267 RID: 615 RVA: 0x0000890F File Offset: 0x00006B0F
		internal XAppCaptureLocalResult(XAppCaptureLocalResult interop)
		{
			this._clipHandle = new XAppCaptureLocalStreamHandle(interop.clipHandle);
			this._clipStartTimestamp = new SYSTEMTIME(interop.clipStartTimestamp);
			this.interop = interop;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00008940 File Offset: 0x00006B40
		// (set) Token: 0x06000269 RID: 617 RVA: 0x00008948 File Offset: 0x00006B48
		public XAppCaptureLocalStreamHandle ClipHandle
		{
			get
			{
				return this._clipHandle;
			}
			set
			{
				this._clipHandle = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00008951 File Offset: 0x00006B51
		// (set) Token: 0x0600026B RID: 619 RVA: 0x0000895E File Offset: 0x00006B5E
		public ulong FileSizeInBytes
		{
			get
			{
				return this.interop.fileSizeInBytes;
			}
			set
			{
				this.interop.fileSizeInBytes = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600026C RID: 620 RVA: 0x0000896C File Offset: 0x00006B6C
		// (set) Token: 0x0600026D RID: 621 RVA: 0x00008974 File Offset: 0x00006B74
		public SYSTEMTIME ClipStartTimestamp
		{
			get
			{
				return this._clipStartTimestamp;
			}
			set
			{
				this._clipStartTimestamp = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600026E RID: 622 RVA: 0x0000897D File Offset: 0x00006B7D
		// (set) Token: 0x0600026F RID: 623 RVA: 0x0000898A File Offset: 0x00006B8A
		public ulong DurationInMilliseconds
		{
			get
			{
				return this.interop.durationInMilliseconds;
			}
			set
			{
				this.interop.durationInMilliseconds = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00008998 File Offset: 0x00006B98
		// (set) Token: 0x06000271 RID: 625 RVA: 0x000089A5 File Offset: 0x00006BA5
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

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000272 RID: 626 RVA: 0x000089B3 File Offset: 0x00006BB3
		// (set) Token: 0x06000273 RID: 627 RVA: 0x000089C0 File Offset: 0x00006BC0
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

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000274 RID: 628 RVA: 0x000089CE File Offset: 0x00006BCE
		// (set) Token: 0x06000275 RID: 629 RVA: 0x000089DB File Offset: 0x00006BDB
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

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000276 RID: 630 RVA: 0x000089E9 File Offset: 0x00006BE9
		// (set) Token: 0x06000277 RID: 631 RVA: 0x000089F6 File Offset: 0x00006BF6
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

		// Token: 0x040000B0 RID: 176
		internal XAppCaptureLocalStreamHandle _clipHandle;

		// Token: 0x040000B1 RID: 177
		internal SYSTEMTIME _clipStartTimestamp;

		// Token: 0x040000B2 RID: 178
		internal XAppCaptureLocalResult interop;
	}
}
