using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	// Token: 0x02000505 RID: 1285
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeBuffer : IDisposable
	{
		// Token: 0x17000BEE RID: 3054
		// (get) Token: 0x06003449 RID: 13385 RVA: 0x00028218 File Offset: 0x00026418
		public IntPtr Pointer
		{
			get
			{
				return this.SETpeMTVNwWrLcGCPfvuGSFChgcEb;
			}
		}

		// Token: 0x17000BEF RID: 3055
		// (get) Token: 0x0600344A RID: 13386 RVA: 0x00028220 File Offset: 0x00026420
		public int Length
		{
			get
			{
				return this.igHiboncsNlxRPebThUYiHwhsJuM;
			}
		}

		// Token: 0x17000BF0 RID: 3056
		public byte this[int index]
		{
			get
			{
				if (index < 0 || index >= this.igHiboncsNlxRPebThUYiHwhsJuM)
				{
					throw new IndexOutOfRangeException();
				}
				return Marshal.ReadByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, index);
			}
			set
			{
				if (index < 0 || index >= this.igHiboncsNlxRPebThUYiHwhsJuM)
				{
					throw new IndexOutOfRangeException();
				}
				Marshal.WriteByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, index, value);
			}
		}

		// Token: 0x0600344D RID: 13389 RVA: 0x0002826B File Offset: 0x0002646B
		public NativeBuffer(int A_1)
		{
			this.Resize(A_1, false);
		}

		// Token: 0x0600344E RID: 13390 RVA: 0x000B4194 File Offset: 0x000B2394
		public IntPtr GetPointer(int offset = 0)
		{
			if (this.SETpeMTVNwWrLcGCPfvuGSFChgcEb == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			if (offset == 0)
			{
				return this.SETpeMTVNwWrLcGCPfvuGSFChgcEb;
			}
			if (offset < 0 || offset >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			return NativeTools.OffsetIntPtr(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, offset);
		}

		// Token: 0x0600344F RID: 13391 RVA: 0x000B41E8 File Offset: 0x000B23E8
		public string DumpToHexString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < this.igHiboncsNlxRPebThUYiHwhsJuM; i++)
			{
				stringBuilder.Append(this.ReadByte(i).ToString("x2"));
				stringBuilder.Append(" ");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06003450 RID: 13392 RVA: 0x000B423C File Offset: 0x000B243C
		public bool ReadBit(int byteIndex, byte bit)
		{
			if (1 + byteIndex > this.Length || byteIndex < 0)
			{
				throw new ArgumentOutOfRangeException("byteIndex");
			}
			if (bit >= 8)
			{
				throw new ArgumentOutOfRangeException("bit");
			}
			return ((int)Marshal.ReadByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, byteIndex) & 1 << (int)bit) != 0;
		}

		// Token: 0x06003451 RID: 13393 RVA: 0x0002827C File Offset: 0x0002647C
		public byte ReadByte(int startIndex)
		{
			if (1 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex);
		}

		// Token: 0x06003452 RID: 13394 RVA: 0x000282A4 File Offset: 0x000264A4
		public short ReadShort(int startIndex)
		{
			if (2 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt16(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex);
		}

		// Token: 0x06003453 RID: 13395 RVA: 0x000282CC File Offset: 0x000264CC
		public ushort ReadUShort(int startIndex)
		{
			if (2 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ushort)Marshal.ReadInt16(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex);
		}

		// Token: 0x06003454 RID: 13396 RVA: 0x000282F5 File Offset: 0x000264F5
		public int ReadInt(int startIndex)
		{
			if (4 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt32(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex);
		}

		// Token: 0x06003455 RID: 13397 RVA: 0x000282F5 File Offset: 0x000264F5
		public uint ReadUInt(int startIndex)
		{
			if (4 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (uint)Marshal.ReadInt32(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex);
		}

		// Token: 0x06003456 RID: 13398 RVA: 0x0002831D File Offset: 0x0002651D
		public long ReadLong(int startIndex)
		{
			if (8 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt64(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex);
		}

		// Token: 0x06003457 RID: 13399 RVA: 0x0002831D File Offset: 0x0002651D
		public ulong ReadULong(int startIndex)
		{
			if (8 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ulong)Marshal.ReadInt64(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex);
		}

		// Token: 0x06003458 RID: 13400 RVA: 0x00028345 File Offset: 0x00026545
		public float ReadFloat(int startIndex)
		{
			if (4 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new cBnrCZPjrfcGOwVKjgzRdKUFjlmb(Marshal.ReadInt32(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex)).vOriVOiVMJMZPqMMgnyprpRZvQZL;
		}

		// Token: 0x06003459 RID: 13401 RVA: 0x00028377 File Offset: 0x00026577
		public double ReadDouble(int startIndex)
		{
			if (8 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new pOPkOQETOFBKgHwxMIChVNwjNLNl(Marshal.ReadInt64(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex)).TzhpZGnUesCdNoVLFRxREQzvUzLb;
		}

		// Token: 0x0600345A RID: 13402 RVA: 0x000B4288 File Offset: 0x000B2488
		public void Read(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = buffer.Length;
			if (num <= 0)
			{
				throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
			}
			if (numBytesToRead <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
			}
			if (numBytesToRead > num)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
			}
			if (numBytesToRead > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
			}
			if (writeStartIndex >= num)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex + numBytesToRead > num)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
			}
			if (numBytesToRead + readStartIndex > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, buffer, readStartIndex, writeStartIndex, numBytesToRead, true);
		}

		// Token: 0x0600345B RID: 13403 RVA: 0x000B4368 File Offset: 0x000B2568
		public void Read(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
			}
			if (numBytesToRead <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
			}
			if (numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
			}
			if (numBytesToRead > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
			}
			if (writeStartIndex >= bufferLength)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex + numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
			}
			if (numBytesToRead + readStartIndex > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, buffer, readStartIndex, writeStartIndex, numBytesToRead, true);
		}

		// Token: 0x0600345C RID: 13404 RVA: 0x000B4450 File Offset: 0x000B2650
		public int TryReadBytes(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == null || numBytesToRead <= 0)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num == 0)
			{
				return 0;
			}
			if (readStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				return 0;
			}
			if (writeStartIndex >= num)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToRead > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				numBytesToRead = this.igHiboncsNlxRPebThUYiHwhsJuM - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > num)
			{
				numBytesToRead = num - writeStartIndex;
			}
			if (numBytesToRead == 0)
			{
				return 0;
			}
			if (!NativeTools.CopyMemory(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, buffer, readStartIndex, writeStartIndex, numBytesToRead, false))
			{
				return 0;
			}
			return numBytesToRead;
		}

		// Token: 0x0600345D RID: 13405 RVA: 0x000B44D0 File Offset: 0x000B26D0
		public int TryReadBytes(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == IntPtr.Zero || numBytesToRead <= 0)
			{
				return 0;
			}
			if (readStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				return 0;
			}
			if (writeStartIndex >= bufferLength)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToRead > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				numBytesToRead = this.igHiboncsNlxRPebThUYiHwhsJuM - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, buffer, readStartIndex, writeStartIndex, numBytesToRead, false))
			{
				return 0;
			}
			return numBytesToRead;
		}

		// Token: 0x0600345E RID: 13406 RVA: 0x000B4550 File Offset: 0x000B2750
		public void WriteBit(int byteIndex, byte bit, bool value)
		{
			if (1 + byteIndex > this.Length || byteIndex < 0)
			{
				throw new ArgumentOutOfRangeException("byteIndex");
			}
			if (bit >= 8)
			{
				throw new ArgumentOutOfRangeException("bit");
			}
			if (value)
			{
				Marshal.WriteByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, byteIndex, Marshal.ReadByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, byteIndex) | (byte)(1 << (int)bit));
				return;
			}
			Marshal.WriteByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, byteIndex, Marshal.ReadByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, byteIndex) & (byte)(~(byte)(1 << (int)bit)));
		}

		// Token: 0x0600345F RID: 13407 RVA: 0x000283A9 File Offset: 0x000265A9
		public void Write(byte @byte, int startIndex)
		{
			if (1 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteByte(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, @byte);
		}

		// Token: 0x06003460 RID: 13408 RVA: 0x000283D2 File Offset: 0x000265D2
		public void Write(short bytes, int startIndex)
		{
			if (2 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, bytes);
		}

		// Token: 0x06003461 RID: 13409 RVA: 0x000283FB File Offset: 0x000265FB
		public void Write(ushort bytes, int startIndex)
		{
			if (2 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, (short)bytes);
		}

		// Token: 0x06003462 RID: 13410 RVA: 0x00028425 File Offset: 0x00026625
		public void Write(int bytes, int startIndex)
		{
			if (4 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, bytes);
		}

		// Token: 0x06003463 RID: 13411 RVA: 0x00028425 File Offset: 0x00026625
		public void Write(uint bytes, int startIndex)
		{
			if (4 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, (int)bytes);
		}

		// Token: 0x06003464 RID: 13412 RVA: 0x0002844E File Offset: 0x0002664E
		public void Write(long bytes, int startIndex)
		{
			if (8 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, bytes);
		}

		// Token: 0x06003465 RID: 13413 RVA: 0x0002844E File Offset: 0x0002664E
		public void Write(ulong bytes, int startIndex)
		{
			if (8 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, (long)bytes);
		}

		// Token: 0x06003466 RID: 13414 RVA: 0x00028477 File Offset: 0x00026677
		public void Write(float bytes, int startIndex)
		{
			if (4 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, new cBnrCZPjrfcGOwVKjgzRdKUFjlmb(bytes).DtrheSheBzorShiEebSNdIJKUXCKA);
		}

		// Token: 0x06003467 RID: 13415 RVA: 0x000284AA File Offset: 0x000266AA
		public void Write(double bytes, int startIndex)
		{
			if (8 + startIndex > this.igHiboncsNlxRPebThUYiHwhsJuM || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, startIndex, new pOPkOQETOFBKgHwxMIChVNwjNLNl(bytes).BEKEWoRUNKMdqGYKRRQgYFuADhYV);
		}

		// Token: 0x06003468 RID: 13416 RVA: 0x000B45D0 File Offset: 0x000B27D0
		public void Write(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num <= 0)
			{
				throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
			}
			if (numBytesToWrite <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
			}
			if (numBytesToWrite > num)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
			}
			if (numBytesToWrite > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
			}
			if (readStartIndex >= num)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex + numBytesToWrite > num)
			{
				throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
			}
			if (numBytesToWrite + writeStartIndex > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, readStartIndex, writeStartIndex, numBytesToWrite, true);
		}

		// Token: 0x06003469 RID: 13417 RVA: 0x000B46B0 File Offset: 0x000B28B0
		public void Write(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
			}
			if (numBytesToWrite <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
			}
			if (numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
			}
			if (numBytesToWrite > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
			}
			if (readStartIndex >= bufferLength)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex + numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
			}
			if (numBytesToWrite + writeStartIndex > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, readStartIndex, writeStartIndex, numBytesToWrite, true);
		}

		// Token: 0x0600346A RID: 13418 RVA: 0x000B4798 File Offset: 0x000B2998
		public int TryWriteBytes(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				return 0;
			}
			int num = bytes.Length;
			if (num == 0 || numBytesToWrite <= 0 || readStartIndex >= num || writeStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToWrite > num)
			{
				numBytesToWrite = num - readStartIndex;
			}
			if (numBytesToWrite + writeStartIndex > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				numBytesToWrite = this.igHiboncsNlxRPebThUYiHwhsJuM - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, readStartIndex, writeStartIndex, numBytesToWrite, false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		// Token: 0x0600346B RID: 13419 RVA: 0x000B480C File Offset: 0x000B2A0C
		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0 || readStartIndex >= bufferLength || writeStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength - readStartIndex;
			}
			if (numBytesToWrite + writeStartIndex > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				numBytesToWrite = this.igHiboncsNlxRPebThUYiHwhsJuM - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, readStartIndex, writeStartIndex, numBytesToWrite, false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		// Token: 0x0600346C RID: 13420 RVA: 0x000B488C File Offset: 0x000B2A8C
		public int TryFill(byte value, int numBytesToWrite, int writeStartIndex = 0)
		{
			if (numBytesToWrite <= 0 || writeStartIndex >= this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				return 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (numBytesToWrite + writeStartIndex > this.igHiboncsNlxRPebThUYiHwhsJuM)
			{
				numBytesToWrite = this.igHiboncsNlxRPebThUYiHwhsJuM - writeStartIndex;
			}
			if (!NativeTools.FillMemory(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, writeStartIndex, numBytesToWrite, value, false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		// Token: 0x0600346D RID: 13421 RVA: 0x000B48D8 File Offset: 0x000B2AD8
		public bool Resize(int size, bool preserveData)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (this.igHiboncsNlxRPebThUYiHwhsJuM == size)
			{
				return true;
			}
			if (size == 0)
			{
				this.Release();
				return true;
			}
			IntPtr intPtr;
			if (preserveData)
			{
				try
				{
					intPtr = Marshal.AllocHGlobal(size);
					if (intPtr == IntPtr.Zero)
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
				int bytesToCopy = MathTools.Min(size, this.igHiboncsNlxRPebThUYiHwhsJuM);
				if (!NativeTools.CopyMemory(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, intPtr, 0, 0, bytesToCopy, false))
				{
					Marshal.FreeHGlobal(intPtr);
					return false;
				}
				if (size > this.igHiboncsNlxRPebThUYiHwhsJuM)
				{
					NativeTools.FillMemory(intPtr, this.igHiboncsNlxRPebThUYiHwhsJuM, size - this.igHiboncsNlxRPebThUYiHwhsJuM, 0, false);
				}
				this.Release();
			}
			else
			{
				this.Release();
				try
				{
					intPtr = Marshal.AllocHGlobal(size);
					if (intPtr == IntPtr.Zero)
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
				NativeTools.ZeroFillMemory(intPtr, size);
			}
			this.SETpeMTVNwWrLcGCPfvuGSFChgcEb = intPtr;
			this.igHiboncsNlxRPebThUYiHwhsJuM = size;
			return true;
		}

		// Token: 0x0600346E RID: 13422 RVA: 0x000284DD File Offset: 0x000266DD
		public void Clear()
		{
			if (this.igHiboncsNlxRPebThUYiHwhsJuM == 0)
			{
				return;
			}
			NativeTools.ZeroFillMemory(this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, this.igHiboncsNlxRPebThUYiHwhsJuM);
		}

		// Token: 0x0600346F RID: 13423 RVA: 0x000284F9 File Offset: 0x000266F9
		public void Release()
		{
			if (this.SETpeMTVNwWrLcGCPfvuGSFChgcEb != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.Pointer);
				this.SETpeMTVNwWrLcGCPfvuGSFChgcEb = IntPtr.Zero;
			}
			this.igHiboncsNlxRPebThUYiHwhsJuM = 0;
		}

		// Token: 0x06003470 RID: 13424 RVA: 0x000B49DC File Offset: 0x000B2BDC
		public void CopyFrom(NativeBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (this.SETpeMTVNwWrLcGCPfvuGSFChgcEb == IntPtr.Zero)
			{
				return;
			}
			if (other.Pointer == IntPtr.Zero)
			{
				return;
			}
			int bytesToCopy = MathTools.Min(this.igHiboncsNlxRPebThUYiHwhsJuM, other.igHiboncsNlxRPebThUYiHwhsJuM);
			NativeTools.CopyMemory(other.SETpeMTVNwWrLcGCPfvuGSFChgcEb, this.SETpeMTVNwWrLcGCPfvuGSFChgcEb, 0, 0, bytesToCopy, true);
		}

		// Token: 0x06003471 RID: 13425 RVA: 0x000B4A48 File Offset: 0x000B2C48
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Length = ",
				this.igHiboncsNlxRPebThUYiHwhsJuM.ToString(),
				"\nPointer = ",
				this.SETpeMTVNwWrLcGCPfvuGSFChgcEb.ToString(),
				"\n"
			});
		}

		// Token: 0x06003472 RID: 13426 RVA: 0x0002852A File Offset: 0x0002672A
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003473 RID: 13427 RVA: 0x000B4A94 File Offset: 0x000B2C94
		~NativeBuffer()
		{
			this.Dispose(false);
		}

		// Token: 0x06003474 RID: 13428 RVA: 0x00028539 File Offset: 0x00026739
		protected virtual void Dispose(bool disposing)
		{
			if (this.tufBFAdUwzsAQqibuhsxBuoGbZvhc)
			{
				return;
			}
			this.Release();
			this.tufBFAdUwzsAQqibuhsxBuoGbZvhc = true;
		}

		// Token: 0x06003475 RID: 13429 RVA: 0x00028553 File Offset: 0x00026753
		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			if (buffer == null)
			{
				return IntPtr.Zero;
			}
			return buffer.SETpeMTVNwWrLcGCPfvuGSFChgcEb;
		}

		// Token: 0x06003476 RID: 13430 RVA: 0x000B4AC4 File Offset: 0x000B2CC4
		public static bool Copy(NativeBuffer source, NativeBuffer destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (source.igHiboncsNlxRPebThUYiHwhsJuM == 0)
			{
				destination.Release();
				return true;
			}
			return destination.Resize(source.igHiboncsNlxRPebThUYiHwhsJuM, false) && NativeTools.CopyMemory(source.SETpeMTVNwWrLcGCPfvuGSFChgcEb, destination.SETpeMTVNwWrLcGCPfvuGSFChgcEb, 0, 0, source.igHiboncsNlxRPebThUYiHwhsJuM, false);
		}

		// Token: 0x04001BFA RID: 7162
		private IntPtr SETpeMTVNwWrLcGCPfvuGSFChgcEb;

		// Token: 0x04001BFB RID: 7163
		private int igHiboncsNlxRPebThUYiHwhsJuM;

		// Token: 0x04001BFC RID: 7164
		private bool tufBFAdUwzsAQqibuhsxBuoGbZvhc;
	}
}
