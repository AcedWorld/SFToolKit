using System;
using System.Collections;
using System.Collections.Generic;

namespace WebSocketSharp
{
	// Token: 0x0200000C RID: 12
	internal class PayloadData : IEnumerable<byte>, IEnumerable
	{
		// Token: 0x0600010E RID: 270 RVA: 0x0000932B File Offset: 0x0000752B
		internal PayloadData(byte[] data) : this(data, (long)data.Length)
		{
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00009339 File Offset: 0x00007539
		internal PayloadData(byte[] data, long length)
		{
			this._data = data;
			this._length = length;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00009351 File Offset: 0x00007551
		internal PayloadData(ushort code, string reason)
		{
			this._data = code.Append(reason);
			this._length = (long)this._data.Length;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00009378 File Offset: 0x00007578
		internal ushort Code
		{
			get
			{
				return (this._length >= 2L) ? this._data.SubArray(0, 2).ToUInt16(ByteOrder.Big) : 1005;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000112 RID: 274 RVA: 0x000093B0 File Offset: 0x000075B0
		// (set) Token: 0x06000113 RID: 275 RVA: 0x000093C8 File Offset: 0x000075C8
		internal long ExtensionDataLength
		{
			get
			{
				return this._extDataLength;
			}
			set
			{
				this._extDataLength = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000114 RID: 276 RVA: 0x000093D4 File Offset: 0x000075D4
		internal bool HasReservedCode
		{
			get
			{
				return this._length >= 2L && this.Code.IsReserved();
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00009400 File Offset: 0x00007600
		internal string Reason
		{
			get
			{
				bool flag = this._length <= 2L;
				string result;
				if (flag)
				{
					result = string.Empty;
				}
				else
				{
					byte[] bytes = this._data.SubArray(2L, this._length - 2L);
					string text;
					result = (bytes.TryGetUTF8DecodedString(out text) ? text : string.Empty);
				}
				return result;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00009454 File Offset: 0x00007654
		public byte[] ApplicationData
		{
			get
			{
				return (this._extDataLength > 0L) ? this._data.SubArray(this._extDataLength, this._length - this._extDataLength) : this._data;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00009498 File Offset: 0x00007698
		public byte[] ExtensionData
		{
			get
			{
				return (this._extDataLength > 0L) ? this._data.SubArray(0L, this._extDataLength) : WebSocket.EmptyBytes;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000094D0 File Offset: 0x000076D0
		public ulong Length
		{
			get
			{
				return (ulong)this._length;
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000094E8 File Offset: 0x000076E8
		internal void Mask(byte[] key)
		{
			for (long num = 0L; num < this._length; num += 1L)
			{
				checked
				{
					this._data[(int)((IntPtr)num)] = (this._data[(int)((IntPtr)num)] ^ key[(int)((IntPtr)(num % 4L))]);
				}
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00009528 File Offset: 0x00007728
		public IEnumerator<byte> GetEnumerator()
		{
			foreach (byte b in this._data)
			{
				yield return b;
			}
			byte[] array = null;
			yield break;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00009538 File Offset: 0x00007738
		public byte[] ToArray()
		{
			return this._data;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00009550 File Offset: 0x00007750
		public override string ToString()
		{
			return BitConverter.ToString(this._data);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00009570 File Offset: 0x00007770
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000060 RID: 96
		private byte[] _data;

		// Token: 0x04000061 RID: 97
		private long _extDataLength;

		// Token: 0x04000062 RID: 98
		private long _length;

		// Token: 0x04000063 RID: 99
		public static readonly PayloadData Empty = new PayloadData(WebSocket.EmptyBytes, 0L);

		// Token: 0x04000064 RID: 100
		public static readonly ulong MaxLength = 9223372036854775807UL;
	}
}
