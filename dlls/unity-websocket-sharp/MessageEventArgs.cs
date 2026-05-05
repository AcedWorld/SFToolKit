using System;

namespace UnityWebSocketSharp
{
	// Token: 0x02000011 RID: 17
	internal class MessageEventArgs : EventArgs
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x000047AC File Offset: 0x000029AC
		internal MessageEventArgs(WebSocketFrame frame)
		{
			this._opcode = frame.Opcode;
			this._rawData = frame.PayloadData.ApplicationData;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000047D1 File Offset: 0x000029D1
		internal MessageEventArgs(Opcode opcode, byte[] rawData)
		{
			if ((long)rawData.Length > (long)PayloadData.MaxLength)
			{
				throw new WebSocketException(CloseStatusCode.TooBig);
			}
			this._opcode = opcode;
			this._rawData = rawData;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000047FC File Offset: 0x000029FC
		internal Opcode Opcode
		{
			get
			{
				return this._opcode;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00004804 File Offset: 0x00002A04
		public string Data
		{
			get
			{
				this.setData();
				return this._data;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00004812 File Offset: 0x00002A12
		public bool IsBinary
		{
			get
			{
				return this._opcode == Opcode.Binary;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000BA RID: 186 RVA: 0x0000481D File Offset: 0x00002A1D
		public bool IsPing
		{
			get
			{
				return this._opcode == Opcode.Ping;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00004829 File Offset: 0x00002A29
		public bool IsText
		{
			get
			{
				return this._opcode == Opcode.Text;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00004834 File Offset: 0x00002A34
		public byte[] RawData
		{
			get
			{
				this.setData();
				return this._rawData;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004844 File Offset: 0x00002A44
		private void setData()
		{
			if (this._dataSet)
			{
				return;
			}
			if (this._opcode == Opcode.Binary)
			{
				this._dataSet = true;
				return;
			}
			string data;
			if (this._rawData.TryGetUTF8DecodedString(out data))
			{
				this._data = data;
			}
			this._dataSet = true;
		}

		// Token: 0x0400003F RID: 63
		private string _data;

		// Token: 0x04000040 RID: 64
		private bool _dataSet;

		// Token: 0x04000041 RID: 65
		private Opcode _opcode;

		// Token: 0x04000042 RID: 66
		private byte[] _rawData;
	}
}
