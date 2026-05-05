using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000028 RID: 40
	internal class ChunkStream
	{
		// Token: 0x060002C8 RID: 712 RVA: 0x0000D76C File Offset: 0x0000B96C
		public ChunkStream(WebHeaderCollection headers)
		{
			this._headers = headers;
			this._chunkSize = -1;
			this._chunks = new List<Chunk>();
			this._saved = new StringBuilder();
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000D798 File Offset: 0x0000B998
		internal int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000D7A0 File Offset: 0x0000B9A0
		internal byte[] EndBuffer
		{
			get
			{
				return this._endBuffer;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002CB RID: 715 RVA: 0x0000D7A8 File Offset: 0x0000B9A8
		internal int Offset
		{
			get
			{
				return this._offset;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002CC RID: 716 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
		public WebHeaderCollection Headers
		{
			get
			{
				return this._headers;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002CD RID: 717 RVA: 0x0000D7B8 File Offset: 0x0000B9B8
		public bool WantsMore
		{
			get
			{
				return this._state < InputChunkState.End;
			}
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000D7C4 File Offset: 0x0000B9C4
		private int read(byte[] buffer, int offset, int count)
		{
			int num = 0;
			int count2 = this._chunks.Count;
			for (int i = 0; i < count2; i++)
			{
				Chunk chunk = this._chunks[i];
				if (chunk != null)
				{
					if (chunk.ReadLeft == 0)
					{
						this._chunks[i] = null;
					}
					else
					{
						num += chunk.Read(buffer, offset + num, count - num);
						if (num == count)
						{
							break;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000D828 File Offset: 0x0000BA28
		private InputChunkState seekCrLf(byte[] buffer, ref int offset, int length)
		{
			int num;
			if (!this._sawCr)
			{
				num = offset;
				offset = num + 1;
				if (buffer[num] != 13)
				{
					ChunkStream.throwProtocolViolation("CR is expected.");
				}
				this._sawCr = true;
				if (offset == length)
				{
					return InputChunkState.DataEnded;
				}
			}
			num = offset;
			offset = num + 1;
			if (buffer[num] != 10)
			{
				ChunkStream.throwProtocolViolation("LF is expected.");
			}
			return InputChunkState.None;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000D880 File Offset: 0x0000BA80
		private InputChunkState setChunkSize(byte[] buffer, ref int offset, int length)
		{
			byte b = 0;
			while (offset < length)
			{
				int num = offset;
				offset = num + 1;
				b = buffer[num];
				if (this._sawCr)
				{
					if (b != 10)
					{
						ChunkStream.throwProtocolViolation("LF is expected.");
						break;
					}
					break;
				}
				else if (b == 13)
				{
					this._sawCr = true;
				}
				else
				{
					if (b == 10)
					{
						ChunkStream.throwProtocolViolation("LF is unexpected.");
					}
					if (!this._gotIt)
					{
						if (b == 32 || b == 59)
						{
							this._gotIt = true;
						}
						else
						{
							this._saved.Append((char)b);
						}
					}
				}
			}
			if (this._saved.Length > 20)
			{
				ChunkStream.throwProtocolViolation("The chunk size is too big.");
			}
			if (b != 10)
			{
				return InputChunkState.None;
			}
			string s = this._saved.ToString();
			try
			{
				this._chunkSize = int.Parse(s, NumberStyles.HexNumber);
			}
			catch
			{
				ChunkStream.throwProtocolViolation("The chunk size cannot be parsed.");
			}
			this._chunkRead = 0;
			if (this._chunkSize == 0)
			{
				this._trailerState = 2;
				return InputChunkState.Trailer;
			}
			return InputChunkState.Data;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000D978 File Offset: 0x0000BB78
		private InputChunkState setTrailer(byte[] buffer, ref int offset, int length)
		{
			while (offset < length && this._trailerState != 4)
			{
				int num = offset;
				offset = num + 1;
				byte b = buffer[num];
				this._saved.Append((char)b);
				if (this._trailerState == 1 || this._trailerState == 3)
				{
					if (b != 10)
					{
						ChunkStream.throwProtocolViolation("LF is expected.");
					}
					this._trailerState++;
				}
				else if (b == 13)
				{
					this._trailerState++;
				}
				else
				{
					if (b == 10)
					{
						ChunkStream.throwProtocolViolation("LF is unexpected.");
					}
					this._trailerState = 0;
				}
			}
			int length2 = this._saved.Length;
			if (length2 > 4196)
			{
				ChunkStream.throwProtocolViolation("The trailer is too long.");
			}
			if (this._trailerState < 4)
			{
				return InputChunkState.Trailer;
			}
			if (length2 == 2)
			{
				return InputChunkState.End;
			}
			this._saved.Length = length2 - 2;
			StringReader stringReader = new StringReader(this._saved.ToString());
			for (;;)
			{
				string text = stringReader.ReadLine();
				if (text == null || text.Length == 0)
				{
					break;
				}
				this._headers.Add(text);
			}
			return InputChunkState.End;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000DA80 File Offset: 0x0000BC80
		private static void throwProtocolViolation(string message)
		{
			throw new WebException(message, null, WebExceptionStatus.ServerProtocolViolation, null);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000DA8C File Offset: 0x0000BC8C
		private void write(byte[] buffer, int offset, int length)
		{
			if (this._state == InputChunkState.End)
			{
				ChunkStream.throwProtocolViolation("The chunks were ended.");
			}
			if (this._state == InputChunkState.None)
			{
				this._state = this.setChunkSize(buffer, ref offset, length);
				if (this._state == InputChunkState.None)
				{
					return;
				}
				this._saved.Length = 0;
				this._sawCr = false;
				this._gotIt = false;
			}
			if (this._state == InputChunkState.Data)
			{
				if (offset >= length)
				{
					return;
				}
				this._state = this.writeData(buffer, ref offset, length);
				if (this._state == InputChunkState.Data)
				{
					return;
				}
			}
			if (this._state == InputChunkState.DataEnded)
			{
				if (offset >= length)
				{
					return;
				}
				this._state = this.seekCrLf(buffer, ref offset, length);
				if (this._state == InputChunkState.DataEnded)
				{
					return;
				}
				this._sawCr = false;
			}
			if (this._state == InputChunkState.Trailer)
			{
				if (offset >= length)
				{
					return;
				}
				this._state = this.setTrailer(buffer, ref offset, length);
				if (this._state == InputChunkState.Trailer)
				{
					return;
				}
				this._saved.Length = 0;
			}
			if (this._state == InputChunkState.End)
			{
				this._endBuffer = buffer;
				this._offset = offset;
				this._count = length - offset;
				return;
			}
			if (offset >= length)
			{
				return;
			}
			this.write(buffer, offset, length);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000DBA4 File Offset: 0x0000BDA4
		private InputChunkState writeData(byte[] buffer, ref int offset, int length)
		{
			int num = length - offset;
			int num2 = this._chunkSize - this._chunkRead;
			if (num > num2)
			{
				num = num2;
			}
			byte[] array = new byte[num];
			Buffer.BlockCopy(buffer, offset, array, 0, num);
			Chunk item = new Chunk(array);
			this._chunks.Add(item);
			offset += num;
			this._chunkRead += num;
			if (this._chunkRead != this._chunkSize)
			{
				return InputChunkState.Data;
			}
			return InputChunkState.DataEnded;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000DC14 File Offset: 0x0000BE14
		internal void ResetChunkStore()
		{
			this._chunkRead = 0;
			this._chunkSize = -1;
			this._chunks.Clear();
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000DC2F File Offset: 0x0000BE2F
		public int Read(byte[] buffer, int offset, int count)
		{
			if (count <= 0)
			{
				return 0;
			}
			return this.read(buffer, offset, count);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000DC40 File Offset: 0x0000BE40
		public void Write(byte[] buffer, int offset, int count)
		{
			if (count <= 0)
			{
				return;
			}
			this.write(buffer, offset, offset + count);
		}

		// Token: 0x040000F8 RID: 248
		private int _chunkRead;

		// Token: 0x040000F9 RID: 249
		private int _chunkSize;

		// Token: 0x040000FA RID: 250
		private List<Chunk> _chunks;

		// Token: 0x040000FB RID: 251
		private int _count;

		// Token: 0x040000FC RID: 252
		private byte[] _endBuffer;

		// Token: 0x040000FD RID: 253
		private bool _gotIt;

		// Token: 0x040000FE RID: 254
		private WebHeaderCollection _headers;

		// Token: 0x040000FF RID: 255
		private int _offset;

		// Token: 0x04000100 RID: 256
		private StringBuilder _saved;

		// Token: 0x04000101 RID: 257
		private bool _sawCr;

		// Token: 0x04000102 RID: 258
		private InputChunkState _state;

		// Token: 0x04000103 RID: 259
		private int _trailerState;
	}
}
