using System;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000026 RID: 38
	internal class Chunk
	{
		// Token: 0x060002BC RID: 700 RVA: 0x0000D2F7 File Offset: 0x0000B4F7
		public Chunk(byte[] data)
		{
			this._data = data;
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002BD RID: 701 RVA: 0x0000D306 File Offset: 0x0000B506
		public int ReadLeft
		{
			get
			{
				return this._data.Length - this._offset;
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000D318 File Offset: 0x0000B518
		public int Read(byte[] buffer, int offset, int count)
		{
			int num = this._data.Length - this._offset;
			if (num == 0)
			{
				return 0;
			}
			if (count > num)
			{
				count = num;
			}
			Buffer.BlockCopy(this._data, this._offset, buffer, offset, count);
			this._offset += count;
			return count;
		}

		// Token: 0x040000F1 RID: 241
		private byte[] _data;

		// Token: 0x040000F2 RID: 242
		private int _offset;
	}
}
