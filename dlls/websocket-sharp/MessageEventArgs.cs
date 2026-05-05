using System;

namespace WebSocketSharp
{
	// Token: 0x02000003 RID: 3
	public class MessageEventArgs : EventArgs
	{
		// Token: 0x0600006B RID: 107 RVA: 0x000045EE File Offset: 0x000027EE
		internal MessageEventArgs(WebSocketFrame frame)
		{
			this._opcode = frame.Opcode;
			this._rawData = frame.PayloadData.ApplicationData;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004618 File Offset: 0x00002818
		internal MessageEventArgs(Opcode opcode, byte[] rawData)
		{
			bool flag = (long)rawData.Length > (long)PayloadData.MaxLength;
			if (flag)
			{
				throw new WebSocketException(CloseStatusCode.TooBig);
			}
			this._opcode = opcode;
			this._rawData = rawData;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00004654 File Offset: 0x00002854
		internal Opcode Opcode
		{
			get
			{
				return this._opcode;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000466C File Offset: 0x0000286C
		public string Data
		{
			get
			{
				this.setData();
				return this._data;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600006F RID: 111 RVA: 0x0000468C File Offset: 0x0000288C
		public bool IsBinary
		{
			get
			{
				return this._opcode == Opcode.Binary;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000046A8 File Offset: 0x000028A8
		public bool IsPing
		{
			get
			{
				return this._opcode == Opcode.Ping;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000046C4 File Offset: 0x000028C4
		public bool IsText
		{
			get
			{
				return this._opcode == Opcode.Text;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000046E0 File Offset: 0x000028E0
		public byte[] RawData
		{
			get
			{
				this.setData();
				return this._rawData;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004700 File Offset: 0x00002900
		private void setData()
		{
			bool dataSet = this._dataSet;
			if (!dataSet)
			{
				bool flag = this._opcode == Opcode.Binary;
				if (flag)
				{
					this._dataSet = true;
				}
				else
				{
					string data;
					bool flag2 = this._rawData.TryGetUTF8DecodedString(out data);
					if (flag2)
					{
						this._data = data;
					}
					this._dataSet = true;
				}
			}
		}

		// Token: 0x04000004 RID: 4
		private string _data;

		// Token: 0x04000005 RID: 5
		private bool _dataSet;

		// Token: 0x04000006 RID: 6
		private Opcode _opcode;

		// Token: 0x04000007 RID: 7
		private byte[] _rawData;
	}
}
