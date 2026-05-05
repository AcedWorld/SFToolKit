using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200002F RID: 47
	internal struct FastBufferWriter : IDisposable
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600010B RID: 267 RVA: 0x000043C9 File Offset: 0x000025C9
		public unsafe int Position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->Position;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600010C RID: 268 RVA: 0x000043D6 File Offset: 0x000025D6
		public unsafe int Capacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->Capacity;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600010D RID: 269 RVA: 0x000043E3 File Offset: 0x000025E3
		public unsafe int MaxCapacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->MaxCapacity;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600010E RID: 270 RVA: 0x000043F0 File Offset: 0x000025F0
		public unsafe int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (this.Handle->Position <= this.Handle->Length)
				{
					return this.Handle->Length;
				}
				return this.Handle->Position;
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00004421 File Offset: 0x00002621
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void CommitBitwiseWrites(int amount)
		{
			this.Handle->Position += amount;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00004434 File Offset: 0x00002634
		public unsafe FastBufferWriter(int size, Allocator allocator, int maxSize = -1)
		{
			this.Handle = (FastBufferWriter.WriterHandle*)UnsafeUtility.Malloc((long)(sizeof(FastBufferWriter.WriterHandle) + size), UnsafeUtility.AlignOf<FastBufferWriter.WriterHandle>(), allocator);
			this.Handle->BufferPointer = (byte*)(this.Handle + 1);
			this.Handle->Position = 0;
			this.Handle->Length = 0;
			this.Handle->Capacity = size;
			this.Handle->Allocator = allocator;
			this.Handle->MaxCapacity = ((maxSize < size) ? size : maxSize);
			this.Handle->BufferGrew = false;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000044C2 File Offset: 0x000026C2
		public unsafe void Dispose()
		{
			if (this.Handle->BufferGrew)
			{
				UnsafeUtility.Free((void*)this.Handle->BufferPointer, this.Handle->Allocator);
			}
			UnsafeUtility.Free((void*)this.Handle, this.Handle->Allocator);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00004504 File Offset: 0x00002704
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void Seek(int where)
		{
			where = Math.Min(where, this.Handle->Capacity);
			if (this.Handle->Position > this.Handle->Length && where < this.Handle->Position)
			{
				this.Handle->Length = this.Handle->Position;
			}
			this.Handle->Position = where;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000456C File Offset: 0x0000276C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void Truncate(int where = -1)
		{
			if (where == -1)
			{
				where = this.Position;
			}
			if (this.Handle->Position > where)
			{
				this.Handle->Position = where;
			}
			if (this.Handle->Length > where)
			{
				this.Handle->Length = where;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000045B9 File Offset: 0x000027B9
		public BitWriter EnterBitwiseContext()
		{
			return new BitWriter(this);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000045C8 File Offset: 0x000027C8
		internal unsafe void Grow(int additionalSizeRequired)
		{
			int i;
			for (i = this.Handle->Capacity * 2; i < this.Position + additionalSizeRequired; i *= 2)
			{
			}
			int num = Math.Min(i, this.Handle->MaxCapacity);
			byte* ptr = (byte*)UnsafeUtility.Malloc((long)num, UnsafeUtility.AlignOf<byte>(), this.Handle->Allocator);
			UnsafeUtility.MemCpy((void*)ptr, (void*)this.Handle->BufferPointer, (long)this.Length);
			if (this.Handle->BufferGrew)
			{
				UnsafeUtility.Free((void*)this.Handle->BufferPointer, this.Handle->Allocator);
			}
			this.Handle->BufferGrew = true;
			this.Handle->BufferPointer = ptr;
			this.Handle->Capacity = num;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00004684 File Offset: 0x00002884
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool TryBeginWrite(int bytes)
		{
			if (this.Handle->Position + bytes > this.Handle->Capacity)
			{
				if (this.Handle->Position + bytes > this.Handle->MaxCapacity)
				{
					return false;
				}
				if (this.Handle->Capacity >= this.Handle->MaxCapacity)
				{
					return false;
				}
				this.Grow(bytes);
			}
			return true;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000046EC File Offset: 0x000028EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool TryBeginWriteValue<[IsUnmanaged] T>(in T value) where T : struct, ValueType
		{
			int num = sizeof(T);
			if (this.Handle->Position + num > this.Handle->Capacity)
			{
				if (this.Handle->Position + num > this.Handle->MaxCapacity)
				{
					return false;
				}
				if (this.Handle->Capacity >= this.Handle->MaxCapacity)
				{
					return false;
				}
				this.Grow(num);
			}
			return true;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000475C File Offset: 0x0000295C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool TryBeginWriteInternal(int bytes)
		{
			if (this.Handle->Position + bytes > this.Handle->Capacity)
			{
				if (this.Handle->Position + bytes > this.Handle->MaxCapacity)
				{
					return false;
				}
				if (this.Handle->Capacity >= this.Handle->MaxCapacity)
				{
					return false;
				}
				this.Grow(bytes);
			}
			return true;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000047C4 File Offset: 0x000029C4
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

		// Token: 0x0600011A RID: 282 RVA: 0x0000480E File Offset: 0x00002A0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return this.Handle->BufferPointer;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000481B File Offset: 0x00002A1B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtrAtCurrentPosition()
		{
			return this.Handle->BufferPointer + this.Handle->Position;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00004834 File Offset: 0x00002A34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWriteSize(string s, bool oneByteChars = false)
		{
			return 4 + s.Length * (oneByteChars ? 1 : 2);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00004848 File Offset: 0x00002A48
		public void WriteNetworkSerializable<T>(in T value) where T : INetworkSerializable
		{
			BufferSerializer<BufferSerializerWriter> serializer = new BufferSerializer<BufferSerializerWriter>(new BufferSerializerWriter(this));
			T t = value;
			t.NetworkSerialize<BufferSerializerWriter>(serializer);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000487C File Offset: 0x00002A7C
		public void WriteNetworkSerializable<T>(INetworkSerializable[] array, int count = -1, int offset = 0) where T : INetworkSerializable
		{
			int num = (count != -1) ? count : (array.Length - offset);
			this.WriteValueSafe<int>(num);
			foreach (INetworkSerializable networkSerializable in array)
			{
				this.WriteNetworkSerializable<INetworkSerializable>(networkSerializable);
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000048BC File Offset: 0x00002ABC
		public unsafe void WriteValue(string s, bool oneByteChars = false)
		{
			uint length = (uint)s.Length;
			this.WriteValue<uint>(length);
			int length2 = s.Length;
			if (oneByteChars)
			{
				for (int i = 0; i < length2; i++)
				{
					this.WriteByte((byte)s[i]);
				}
				return;
			}
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				this.WriteBytes((byte*)ptr, length2 * 2, 0);
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004920 File Offset: 0x00002B20
		public unsafe void WriteValueSafe(string s, bool oneByteChars = false)
		{
			int writeSize = FastBufferWriter.GetWriteSize(s, oneByteChars);
			if (!this.TryBeginWriteInternal(writeSize))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			uint length = (uint)s.Length;
			this.WriteValue<uint>(length);
			int length2 = s.Length;
			if (oneByteChars)
			{
				for (int i = 0; i < length2; i++)
				{
					this.WriteByte((byte)s[i]);
				}
				return;
			}
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				this.WriteBytes((byte*)ptr, length2 * 2, 0);
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000049A4 File Offset: 0x00002BA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWriteSize<[IsUnmanaged] T>(T[] array, int count = -1, int offset = 0) where T : struct, ValueType
		{
			int num = ((count != -1) ? count : (array.Length - offset)) * sizeof(T);
			return 4 + num;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000049C8 File Offset: 0x00002BC8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteValue<[IsUnmanaged] T>(T[] array, int count = -1, int offset = 0) where T : struct, ValueType
		{
			int num = (count != -1) ? count : (array.Length - offset);
			int size = num * sizeof(T);
			this.WriteValue<int>(num);
			fixed (T[] array2 = array)
			{
				T* ptr;
				if (array == null || array2.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = &array2[0];
				}
				byte* value = (byte*)(ptr + (IntPtr)offset * (IntPtr)sizeof(T) / (IntPtr)sizeof(T));
				this.WriteBytes(value, size, 0);
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004A24 File Offset: 0x00002C24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteValueSafe<[IsUnmanaged] T>(T[] array, int count = -1, int offset = 0) where T : struct, ValueType
		{
			int num = (count != -1) ? count : (array.Length - offset);
			int num2 = num * sizeof(T);
			if (!this.TryBeginWriteInternal(num2 + 4))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			this.WriteValue<int>(num);
			fixed (T[] array2 = array)
			{
				T* ptr;
				if (array == null || array2.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = &array2[0];
				}
				byte* value = (byte*)(ptr + (IntPtr)offset * (IntPtr)sizeof(T) / (IntPtr)sizeof(T));
				this.WriteBytes(value, num2, 0);
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004A98 File Offset: 0x00002C98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WritePartialValue<[IsUnmanaged] T>(T value, int bytesToWrite, int offsetBytes = 0) where T : struct, ValueType
		{
			byte* source = (byte*)(&value) + offsetBytes;
			UnsafeUtility.MemCpy((void*)(this.Handle->BufferPointer + this.Handle->Position), (void*)source, (long)bytesToWrite);
			this.Handle->Position += bytesToWrite;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004ADC File Offset: 0x00002CDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteByte(byte value)
		{
			ref byte bufferPointer = ref *this.Handle->BufferPointer;
			FastBufferWriter.WriterHandle* handle = this.Handle;
			int position = handle->Position;
			handle->Position = position + 1;
			*(ref bufferPointer + position) = value;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004B0C File Offset: 0x00002D0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteByteSafe(byte value)
		{
			if (!this.TryBeginWriteInternal(1))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			ref byte bufferPointer = ref *this.Handle->BufferPointer;
			FastBufferWriter.WriterHandle* handle = this.Handle;
			int position = handle->Position;
			handle->Position = position + 1;
			*(ref bufferPointer + position) = value;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004B4E File Offset: 0x00002D4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytes(byte* value, int size, int offset = 0)
		{
			UnsafeUtility.MemCpy((void*)(this.Handle->BufferPointer + this.Handle->Position), (void*)(value + offset), (long)size);
			this.Handle->Position += size;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004B84 File Offset: 0x00002D84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytesSafe(byte* value, int size, int offset = 0)
		{
			if (!this.TryBeginWriteInternal(size))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			UnsafeUtility.MemCpy((void*)(this.Handle->BufferPointer + this.Handle->Position), (void*)(value + offset), (long)size);
			this.Handle->Position += size;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004BD8 File Offset: 0x00002DD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytes(byte[] value, int size = -1, int offset = 0)
		{
			fixed (byte[] array = value)
			{
				byte* value2;
				if (value == null || array.Length == 0)
				{
					value2 = null;
				}
				else
				{
					value2 = &array[0];
				}
				this.WriteBytes(value2, (size == -1) ? value.Length : size, offset);
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004C14 File Offset: 0x00002E14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytesSafe(byte[] value, int size = -1, int offset = 0)
		{
			fixed (byte[] array = value)
			{
				byte* value2;
				if (value == null || array.Length == 0)
				{
					value2 = null;
				}
				else
				{
					value2 = &array[0];
				}
				this.WriteBytesSafe(value2, (size == -1) ? value.Length : size, offset);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004C4D File Offset: 0x00002E4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void CopyTo(FastBufferWriter other)
		{
			other.WriteBytes(this.Handle->BufferPointer, this.Handle->Position, 0);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004C6D File Offset: 0x00002E6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void CopyFrom(FastBufferWriter other)
		{
			this.WriteBytes(other.Handle->BufferPointer, other.Handle->Position, 0);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00004C8C File Offset: 0x00002E8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWriteSize<[IsUnmanaged] T>(in T value) where T : struct, ValueType
		{
			return sizeof(T);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004C94 File Offset: 0x00002E94
		public static int GetWriteSize<[IsUnmanaged] T>() where T : struct, ValueType
		{
			return sizeof(T);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004C9C File Offset: 0x00002E9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteValue<[IsUnmanaged] T>(in T value) where T : struct, ValueType
		{
			int num = sizeof(T);
			fixed (T* ptr = &value)
			{
				T* source = ptr;
				UnsafeUtility.MemCpy((void*)(this.Handle->BufferPointer + this.Handle->Position), (void*)source, (long)num);
			}
			this.Handle->Position += num;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004CE8 File Offset: 0x00002EE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteValueSafe<[IsUnmanaged] T>(in T value) where T : struct, ValueType
		{
			int num = sizeof(T);
			if (!this.TryBeginWriteInternal(num))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			fixed (T* ptr = &value)
			{
				T* source = ptr;
				UnsafeUtility.MemCpy((void*)(this.Handle->BufferPointer + this.Handle->Position), (void*)source, (long)num);
			}
			this.Handle->Position += num;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00004D48 File Offset: 0x00002F48
		public unsafe NativeArray<byte> ToNativeArray(Allocator allocator)
		{
			NativeArray<byte> nativeArray = new NativeArray<byte>(this.Length, allocator, NativeArrayOptions.UninitializedMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<byte>(), (void*)this.GetUnsafePtr(), (long)nativeArray.Length);
			return nativeArray;
		}

		// Token: 0x04000055 RID: 85
		internal unsafe readonly FastBufferWriter.WriterHandle* Handle;

		// Token: 0x02000045 RID: 69
		internal struct WriterHandle
		{
			// Token: 0x04000090 RID: 144
			internal unsafe byte* BufferPointer;

			// Token: 0x04000091 RID: 145
			internal int Position;

			// Token: 0x04000092 RID: 146
			internal int Length;

			// Token: 0x04000093 RID: 147
			internal int Capacity;

			// Token: 0x04000094 RID: 148
			internal int MaxCapacity;

			// Token: 0x04000095 RID: 149
			internal Allocator Allocator;

			// Token: 0x04000096 RID: 150
			internal bool BufferGrew;
		}
	}
}
