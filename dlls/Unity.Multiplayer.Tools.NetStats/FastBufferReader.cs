using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200002E RID: 46
	internal struct FastBufferReader : IDisposable
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00003C1D File Offset: 0x00001E1D
		public unsafe int Position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->Position;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00003C2A File Offset: 0x00001E2A
		public unsafe int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->Length;
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003C37 File Offset: 0x00001E37
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void CommitBitwiseReads(int amount)
		{
			this.Handle->Position += amount;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00003C4C File Offset: 0x00001E4C
		private unsafe static FastBufferReader.ReaderHandle* CreateHandle(byte* buffer, int length, int offset, Allocator allocator)
		{
			FastBufferReader.ReaderHandle* ptr = null;
			if (allocator == Allocator.None)
			{
				ptr = (FastBufferReader.ReaderHandle*)UnsafeUtility.Malloc((long)(sizeof(FastBufferReader.ReaderHandle) + length), UnsafeUtility.AlignOf<byte>(), Allocator.Temp);
				ptr->BufferPointer = buffer;
				ptr->Position = offset;
			}
			else
			{
				ptr = (FastBufferReader.ReaderHandle*)UnsafeUtility.Malloc((long)(sizeof(FastBufferReader.ReaderHandle) + length), UnsafeUtility.AlignOf<byte>(), allocator);
				UnsafeUtility.MemCpy((void*)(ptr + 1), (void*)(buffer + offset), (long)length);
				ptr->BufferPointer = (byte*)(ptr + 1);
				ptr->Position = 0;
			}
			ptr->Length = length;
			ptr->Allocator = allocator;
			return ptr;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00003CD0 File Offset: 0x00001ED0
		public unsafe FastBufferReader(NativeArray<byte> buffer, Allocator allocator, int length = -1, int offset = 0)
		{
			this.Handle = FastBufferReader.CreateHandle((byte*)buffer.GetUnsafePtr<byte>(), Math.Max(1, (length == -1) ? buffer.Length : length), offset, allocator);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00003CFC File Offset: 0x00001EFC
		public unsafe FastBufferReader(ArraySegment<byte> buffer, Allocator allocator, int length = -1, int offset = 0)
		{
			if (allocator == Allocator.None)
			{
				throw new NotSupportedException("Allocator.None cannot be used with managed source buffers.");
			}
			byte[] array;
			byte* buffer2;
			if ((array = buffer.Array) == null || array.Length == 0)
			{
				buffer2 = null;
			}
			else
			{
				buffer2 = &array[0];
			}
			this.Handle = FastBufferReader.CreateHandle(buffer2, Math.Max(1, (length == -1) ? buffer.Count : length), offset, allocator);
			array = null;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00003D5C File Offset: 0x00001F5C
		public unsafe FastBufferReader(byte[] buffer, Allocator allocator, int length = -1, int offset = 0)
		{
			if (allocator == Allocator.None)
			{
				throw new NotSupportedException("Allocator.None cannot be used with managed source buffers.");
			}
			fixed (byte[] array = buffer)
			{
				byte* buffer2;
				if (buffer == null || array.Length == 0)
				{
					buffer2 = null;
				}
				else
				{
					buffer2 = &array[0];
				}
				this.Handle = FastBufferReader.CreateHandle(buffer2, Math.Max(1, (length == -1) ? buffer.Length : length), offset, allocator);
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00003DB1 File Offset: 0x00001FB1
		public unsafe FastBufferReader(byte* buffer, Allocator allocator, int length, int offset = 0)
		{
			this.Handle = FastBufferReader.CreateHandle(buffer, Math.Max(1, length), offset, allocator);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00003DC9 File Offset: 0x00001FC9
		public FastBufferReader(FastBufferWriter writer, Allocator allocator, int length = -1, int offset = 0)
		{
			this.Handle = FastBufferReader.CreateHandle(writer.GetUnsafePtr(), Math.Max(1, (length == -1) ? writer.Length : length), offset, allocator);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003DF4 File Offset: 0x00001FF4
		public unsafe void Dispose()
		{
			UnsafeUtility.Free((void*)this.Handle, this.Handle->Allocator);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00003E0C File Offset: 0x0000200C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void Seek(int where)
		{
			this.Handle->Position = Math.Min(this.Length, where);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00003E25 File Offset: 0x00002025
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void MarkBytesRead(int amount)
		{
			this.Handle->Position += amount;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00003E37 File Offset: 0x00002037
		public BitReader EnterBitwiseContext()
		{
			return new BitReader(this);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003E44 File Offset: 0x00002044
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool TryBeginRead(int bytes)
		{
			return this.Handle->Position + bytes <= this.Handle->Length;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00003E64 File Offset: 0x00002064
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool TryBeginReadValue<[IsUnmanaged] T>(in T value) where T : struct, ValueType
		{
			int num = sizeof(T);
			return this.Handle->Position + num <= this.Handle->Length;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00003E95 File Offset: 0x00002095
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe bool TryBeginReadInternal(int bytes)
		{
			return this.Handle->Position + bytes <= this.Handle->Length;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00003EB4 File Offset: 0x000020B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte[] ToArray()
		{
			byte[] array2;
			byte[] array = array2 = new byte[this.Length];
			byte* destination;
			if (array == null || array2.Length == 0)
			{
				destination = null;
			}
			else
			{
				destination = &array2[0];
			}
			UnsafeUtility.MemCpy((void*)destination, (void*)this.Handle->BufferPointer, (long)this.Length);
			array2 = null;
			return array;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00003EFE File Offset: 0x000020FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return this.Handle->BufferPointer;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00003F0B File Offset: 0x0000210B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtrAtCurrentPosition()
		{
			return this.Handle->BufferPointer + this.Handle->Position;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00003F24 File Offset: 0x00002124
		public void ReadNetworkSerializable<T>(out T value) where T : INetworkSerializable, new()
		{
			value = Activator.CreateInstance<T>();
			BufferSerializer<BufferSerializerReader> serializer = new BufferSerializer<BufferSerializerReader>(new BufferSerializerReader(this));
			value.NetworkSerialize<BufferSerializerReader>(serializer);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00003F5C File Offset: 0x0000215C
		public void ReadNetworkSerializable<T>(out T[] value) where T : INetworkSerializable, new()
		{
			int num;
			this.ReadValueSafe<int>(out num);
			value = new T[num];
			for (int i = 0; i < num; i++)
			{
				this.ReadNetworkSerializable<T>(out value[i]);
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00003F94 File Offset: 0x00002194
		public unsafe void ReadValue(out string s, bool oneByteChars = false)
		{
			uint totalWidth;
			this.ReadValue<uint>(out totalWidth);
			s = "".PadRight((int)totalWidth);
			int length = s.Length;
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				if (oneByteChars)
				{
					for (int i = 0; i < length; i++)
					{
						byte b;
						this.ReadByte(out b);
						ptr[i] = (char)b;
					}
				}
				else
				{
					this.ReadBytes((byte*)ptr, length * 2, 0);
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004004 File Offset: 0x00002204
		public unsafe void ReadValueSafe(out string s, bool oneByteChars = false)
		{
			if (!this.TryBeginReadInternal(4))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			uint num;
			this.ReadValue<uint>(out num);
			if (!this.TryBeginReadInternal((int)(num * (oneByteChars ? 1U : 2U))))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			s = "".PadRight((int)num);
			int length = s.Length;
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				if (oneByteChars)
				{
					for (int i = 0; i < length; i++)
					{
						byte b;
						this.ReadByte(out b);
						ptr[i] = (char)b;
					}
				}
				else
				{
					this.ReadBytes((byte*)ptr, length * 2, 0);
				}
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000040A4 File Offset: 0x000022A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadValue<[IsUnmanaged] T>(out T[] array) where T : struct, ValueType
		{
			int num;
			this.ReadValue<int>(out num);
			int size = num * sizeof(T);
			array = new T[num];
			T[] array2;
			T* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array2[0];
			}
			byte* value = (byte*)ptr;
			this.ReadBytes(value, size, 0);
			array2 = null;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000040F4 File Offset: 0x000022F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadValueSafe<[IsUnmanaged] T>(out T[] array) where T : struct, ValueType
		{
			if (!this.TryBeginReadInternal(4))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			int num;
			this.ReadValue<int>(out num);
			int num2 = num * sizeof(T);
			if (!this.TryBeginReadInternal(num2))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			array = new T[num];
			T[] array2;
			T* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array2[0];
			}
			byte* value = (byte*)ptr;
			this.ReadBytes(value, num2, 0);
			array2 = null;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000416C File Offset: 0x0000236C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadPartialValue<[IsUnmanaged] T>(out T value, int bytesToRead, int offsetBytes = 0) where T : struct, ValueType
		{
			T t = Activator.CreateInstance<T>();
			void* destination = (void*)((byte*)(&t) + offsetBytes);
			byte* source = this.Handle->BufferPointer + this.Handle->Position;
			UnsafeUtility.MemCpy(destination, (void*)source, (long)bytesToRead);
			this.Handle->Position += bytesToRead;
			value = t;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000041BC File Offset: 0x000023BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadByte(out byte value)
		{
			int bufferPointer = this.Handle->BufferPointer;
			FastBufferReader.ReaderHandle* handle = this.Handle;
			int position = handle->Position;
			handle->Position = position + 1;
			value = *(bufferPointer + position);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000041EC File Offset: 0x000023EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadByteSafe(out byte value)
		{
			if (!this.TryBeginReadInternal(1))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			int bufferPointer = this.Handle->BufferPointer;
			FastBufferReader.ReaderHandle* handle = this.Handle;
			int position = handle->Position;
			handle->Position = position + 1;
			value = *(bufferPointer + position);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000422F File Offset: 0x0000242F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadBytes(byte* value, int size, int offset = 0)
		{
			UnsafeUtility.MemCpy((void*)(value + offset), (void*)(this.Handle->BufferPointer + this.Handle->Position), (long)size);
			this.Handle->Position += size;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004264 File Offset: 0x00002464
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadBytesSafe(byte* value, int size, int offset = 0)
		{
			if (!this.TryBeginReadInternal(size))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			UnsafeUtility.MemCpy((void*)(value + offset), (void*)(this.Handle->BufferPointer + this.Handle->Position), (long)size);
			this.Handle->Position += size;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000042B8 File Offset: 0x000024B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadBytes(ref byte[] value, int size, int offset = 0)
		{
			byte[] array;
			byte* value2;
			if ((array = value) == null || array.Length == 0)
			{
				value2 = null;
			}
			else
			{
				value2 = &array[0];
			}
			this.ReadBytes(value2, size, offset);
			array = null;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000042EC File Offset: 0x000024EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadBytesSafe(ref byte[] value, int size, int offset = 0)
		{
			byte[] array;
			byte* value2;
			if ((array = value) == null || array.Length == 0)
			{
				value2 = null;
			}
			else
			{
				value2 = &array[0];
			}
			this.ReadBytesSafe(value2, size, offset);
			array = null;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004320 File Offset: 0x00002520
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadValue<[IsUnmanaged] T>(out T value) where T : struct, ValueType
		{
			int num = sizeof(T);
			fixed (T* ptr = &value)
			{
				UnsafeUtility.MemCpy((void*)ptr, (void*)(this.Handle->BufferPointer + this.Handle->Position), (long)num);
			}
			this.Handle->Position += num;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000436C File Offset: 0x0000256C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadValueSafe<[IsUnmanaged] T>(out T value) where T : struct, ValueType
		{
			int num = sizeof(T);
			if (!this.TryBeginReadInternal(num))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			fixed (T* ptr = &value)
			{
				UnsafeUtility.MemCpy((void*)ptr, (void*)(this.Handle->BufferPointer + this.Handle->Position), (long)num);
			}
			this.Handle->Position += num;
		}

		// Token: 0x04000054 RID: 84
		internal unsafe readonly FastBufferReader.ReaderHandle* Handle;

		// Token: 0x02000044 RID: 68
		internal struct ReaderHandle
		{
			// Token: 0x0400008C RID: 140
			internal unsafe byte* BufferPointer;

			// Token: 0x0400008D RID: 141
			internal int Position;

			// Token: 0x0400008E RID: 142
			internal int Length;

			// Token: 0x0400008F RID: 143
			internal Allocator Allocator;
		}
	}
}
