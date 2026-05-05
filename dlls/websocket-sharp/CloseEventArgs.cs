using System;

namespace WebSocketSharp
{
	// Token: 0x02000004 RID: 4
	public class CloseEventArgs : EventArgs
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00004750 File Offset: 0x00002950
		internal CloseEventArgs(PayloadData payloadData, bool clean)
		{
			this._payloadData = payloadData;
			this._clean = clean;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004768 File Offset: 0x00002968
		internal CloseEventArgs(ushort code, string reason, bool clean)
		{
			this._payloadData = new PayloadData(code, reason);
			this._clean = clean;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00004788 File Offset: 0x00002988
		public ushort Code
		{
			get
			{
				return this._payloadData.Code;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000077 RID: 119 RVA: 0x000047A8 File Offset: 0x000029A8
		public string Reason
		{
			get
			{
				return this._payloadData.Reason;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000047C8 File Offset: 0x000029C8
		public bool WasClean
		{
			get
			{
				return this._clean;
			}
		}

		// Token: 0x04000008 RID: 8
		private bool _clean;

		// Token: 0x04000009 RID: 9
		private PayloadData _payloadData;
	}
}
