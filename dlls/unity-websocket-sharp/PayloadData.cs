using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityWebSocketSharp
{
	// Token: 0x02000013 RID: 19
	internal class PayloadData : IEnumerable<byte>, IEnumerable
	{
		// Token: 0x060000BF RID: 191 RVA: 0x000048A9 File Offset: 0x00002AA9
		internal PayloadData(byte[] data) : this(data, (long)data.Length)
		{
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000048B5 File Offset: 0x00002AB5
		internal PayloadData(byte[] data, long length)
		{
			this._data = data;
			this._length = length;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000048CB File Offset: 0x00002ACB
		internal PayloadData(ushort code, string reason)
		{
			this._data = code.Append(reason);
			this._length = (long)this._data.Length;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x000048EE File Offset: 0x00002AEE
		internal ushort Code
		{
			get
			{
				if (this._length < 2L)
				{
					return 1005;
				}
				return this._data.SubArray(0, 2).ToUInt16(ByteOrder.Big);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00004913 File Offset: 0x00002B13
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x0000491B File Offset: 0x00002B1B
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

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00004924 File Offset: 0x00002B24
		internal bool HasReservedCode
		{
			get
			{
				return this._length >= 2L && this.Code.IsReservedStatusCode();
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00004940 File Offset: 0x00002B40
		internal string Reason
		{
			get
			{
				if (this._length <= 2L)
				{
					return string.Empty;
				}
				string result;
				if (!this._data.SubArray(2L, this._length - 2L).TryGetUTF8DecodedString(out result))
				{
					return string.Empty;
				}
				return result;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00004983 File Offset: 0x00002B83
		public byte[] ApplicationData
		{
			get
			{
				if (this._extDataLength <= 0L)
				{
					return this._data;
				}
				return this._data.SubArray(this._extDataLength, this._length - this._extDataLength);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x000049B4 File Offset: 0x00002BB4
		public byte[] ExtensionData
		{
			get
			{
				if (this._extDataLength <= 0L)
				{
					return WebSocket.EmptyBytes;
				}
				return this._data.SubArray(0L, this._extDataLength);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000049D9 File Offset: 0x00002BD9
		public ulong Length
		{
			get
			{
				return (ulong)this._length;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000049E4 File Offset: 0x00002BE4
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

		// Token: 0x060000CB RID: 203 RVA: 0x00004A1F File Offset: 0x00002C1F
		public IEnumerator<byte> GetEnumerator()
		{
			foreach (byte b in this._data)
			{
				yield return b;
			}
			byte[] array = null;
			yield break;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004A2E File Offset: 0x00002C2E
		public byte[] ToArray()
		{
			return this._data;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004A36 File Offset: 0x00002C36
		public override string ToString()
		{
			return BitConverter.ToString(this._data);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004A43 File Offset: 0x00002C43
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0400004A RID: 74
		private byte[] _data;

		// Token: 0x0400004B RID: 75
		private long _extDataLength;

		// Token: 0x0400004C RID: 76
		private long _length;

		// Token: 0x0400004D RID: 77
		public static readonly PayloadData Empty = new PayloadData(WebSocket.EmptyBytes, 0L);

		// Token: 0x0400004E RID: 78
		public static readonly ulong MaxLength = 9223372036854775807UL;
	}
}
