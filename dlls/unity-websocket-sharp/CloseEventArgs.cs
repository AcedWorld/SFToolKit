using System;

namespace UnityWebSocketSharp
{
	// Token: 0x02000004 RID: 4
	internal class CloseEventArgs : EventArgs
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		internal CloseEventArgs(PayloadData payloadData, bool clean)
		{
			this._payloadData = payloadData;
			this._clean = clean;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020D6 File Offset: 0x000002D6
		public ushort Code
		{
			get
			{
				return this._payloadData.Code;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020E3 File Offset: 0x000002E3
		public string Reason
		{
			get
			{
				return this._payloadData.Reason;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020F0 File Offset: 0x000002F0
		public bool WasClean
		{
			get
			{
				return this._clean;
			}
		}

		// Token: 0x04000004 RID: 4
		private bool _clean;

		// Token: 0x04000005 RID: 5
		private PayloadData _payloadData;
	}
}
