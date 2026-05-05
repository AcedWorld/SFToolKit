using System;
using Unity.Networking.Transport;

namespace Unity.Netcode.Transports.UTP
{
	// Token: 0x02000124 RID: 292
	internal class BatchedReceiveQueue
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x00022F00 File Offset: 0x00021100
		public bool IsEmpty
		{
			get
			{
				return this.m_Length <= 0;
			}
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00022F10 File Offset: 0x00021110
		public unsafe BatchedReceiveQueue(DataStreamReader reader)
		{
			this.m_Data = new byte[reader.Length];
			byte[] array;
			byte* data;
			if ((array = this.m_Data) == null || array.Length == 0)
			{
				data = null;
			}
			else
			{
				data = &array[0];
			}
			reader.ReadBytes(data, reader.Length);
			array = null;
			this.m_Offset = 0;
			this.m_Length = reader.Length;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00022F78 File Offset: 0x00021178
		public unsafe void PushReader(DataStreamReader reader)
		{
			if (this.m_Data.Length - (this.m_Offset + this.m_Length) < reader.Length)
			{
				if (this.m_Length > 0)
				{
					Array.Copy(this.m_Data, this.m_Offset, this.m_Data, 0, this.m_Length);
				}
				this.m_Offset = 0;
				while (this.m_Data.Length - this.m_Length < reader.Length)
				{
					Array.Resize<byte>(ref this.m_Data, this.m_Data.Length * 2);
				}
			}
			byte[] array;
			byte* ptr;
			if ((array = this.m_Data) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			reader.ReadBytes(ptr + this.m_Offset + this.m_Length, reader.Length);
			array = null;
			this.m_Length += reader.Length;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00023054 File Offset: 0x00021254
		public ArraySegment<byte> PopMessage()
		{
			if (this.m_Length < 4)
			{
				return default(ArraySegment<byte>);
			}
			int num = BitConverter.ToInt32(this.m_Data, this.m_Offset);
			if (this.m_Length - 4 < num)
			{
				return default(ArraySegment<byte>);
			}
			ArraySegment<byte> result = new ArraySegment<byte>(this.m_Data, this.m_Offset + 4, num);
			this.m_Offset += 4 + num;
			this.m_Length -= 4 + num;
			return result;
		}

		// Token: 0x04000381 RID: 897
		private byte[] m_Data;

		// Token: 0x04000382 RID: 898
		private int m_Offset;

		// Token: 0x04000383 RID: 899
		private int m_Length;
	}
}
