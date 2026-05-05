using System;

namespace WebSocketSharp.Net
{
	// Token: 0x02000035 RID: 53
	internal class Chunk
	{
		// Token: 0x060003A8 RID: 936 RVA: 0x0001701E File Offset: 0x0001521E
		public Chunk(byte[] data)
		{
			this._data = data;
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x00017030 File Offset: 0x00015230
		public int ReadLeft
		{
			get
			{
				return this._data.Length - this._offset;
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00017054 File Offset: 0x00015254
		public int Read(byte[] buffer, int offset, int count)
		{
			int num = this._data.Length - this._offset;
			bool flag = num == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = count > num;
				if (flag2)
				{
					count = num;
				}
				Buffer.BlockCopy(this._data, this._offset, buffer, offset, count);
				this._offset += count;
				result = count;
			}
			return result;
		}

		// Token: 0x04000188 RID: 392
		private byte[] _data;

		// Token: 0x04000189 RID: 393
		private int _offset;
	}
}
