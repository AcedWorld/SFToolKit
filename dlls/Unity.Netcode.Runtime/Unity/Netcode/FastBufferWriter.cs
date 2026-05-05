using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000102 RID: 258
	public struct FastBufferWriter : IDisposable
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x0001ED1C File Offset: 0x0001CF1C
		public unsafe int Position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->Position;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x0001ED29 File Offset: 0x0001CF29
		public unsafe int Capacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->Capacity;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x0001ED36 File Offset: 0x0001CF36
		public unsafe int MaxCapacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->MaxCapacity;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060007C6 RID: 1990 RVA: 0x0001ED43 File Offset: 0x0001CF43
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

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x0001ED74 File Offset: 0x0001CF74
		public bool IsInitialized
		{
			get
			{
				return this.Handle != null;
			}
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0001ED83 File Offset: 0x0001CF83
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void CommitBitwiseWrites(int amount)
		{
			this.Handle->Position += amount;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0001ED98 File Offset: 0x0001CF98
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

		// Token: 0x060007CA RID: 1994 RVA: 0x0001EE28 File Offset: 0x0001D028
		public unsafe void Dispose()
		{
			if (this.Handle->BufferGrew)
			{
				UnsafeUtility.Free((void*)this.Handle->BufferPointer, this.Handle->Allocator);
			}
			UnsafeUtility.Free((void*)this.Handle, this.Handle->Allocator);
			this.Handle = null;
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0001EE7C File Offset: 0x0001D07C
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

		// Token: 0x060007CC RID: 1996 RVA: 0x0001EEE4 File Offset: 0x0001D0E4
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

		// Token: 0x060007CD RID: 1997 RVA: 0x0001EF31 File Offset: 0x0001D131
		public BitWriter EnterBitwiseContext()
		{
			return new BitWriter(this);
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0001EF40 File Offset: 0x0001D140
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

		// Token: 0x060007CF RID: 1999 RVA: 0x0001EFFC File Offset: 0x0001D1FC
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

		// Token: 0x060007D0 RID: 2000 RVA: 0x0001F064 File Offset: 0x0001D264
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

		// Token: 0x060007D1 RID: 2001 RVA: 0x0001F0D4 File Offset: 0x0001D2D4
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

		// Token: 0x060007D2 RID: 2002 RVA: 0x0001F13C File Offset: 0x0001D33C
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

		// Token: 0x060007D3 RID: 2003 RVA: 0x0001F188 File Offset: 0x0001D388
		internal unsafe ArraySegment<byte> ToTempByteArray()
		{
			int length = this.Length;
			if (length > FastBufferWriter.s_ByteArrayCache.Length)
			{
				return new ArraySegment<byte>(this.ToArray(), 0, length);
			}
			byte[] array;
			byte* destination;
			if ((array = FastBufferWriter.s_ByteArrayCache) == null || array.Length == 0)
			{
				destination = null;
			}
			else
			{
				destination = &array[0];
			}
			UnsafeUtility.MemCpy((void*)destination, (void*)this.Handle->BufferPointer, (long)length);
			array = null;
			return new ArraySegment<byte>(FastBufferWriter.s_ByteArrayCache, 0, length);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0001F1F1 File Offset: 0x0001D3F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return this.Handle->BufferPointer;
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0001F1FE File Offset: 0x0001D3FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtrAtCurrentPosition()
		{
			return this.Handle->BufferPointer + this.Handle->Position;
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0001F217 File Offset: 0x0001D417
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWriteSize(string s, bool oneByteChars = false)
		{
			return 4 + s.Length * (oneByteChars ? 1 : 2);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0001F22C File Offset: 0x0001D42C
		public void WriteNetworkSerializable<T>(in T value) where T : INetworkSerializable
		{
			BufferSerializer<BufferSerializerWriter> serializer = new BufferSerializer<BufferSerializerWriter>(new BufferSerializerWriter(this));
			T t = value;
			t.NetworkSerialize<BufferSerializerWriter>(serializer);
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0001F260 File Offset: 0x0001D460
		public void WriteNetworkSerializable<T>(T[] array, int count = -1, int offset = 0) where T : INetworkSerializable
		{
			int num = (count != -1) ? count : (array.Length - offset);
			this.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
			foreach (T t in array)
			{
				this.WriteNetworkSerializable<T>(t);
			}
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0001F2AC File Offset: 0x0001D4AC
		public void WriteNetworkSerializable<[IsUnmanaged] T>(NativeArray<T> array, int count = -1, int offset = 0) where T : struct, ValueType, INetworkSerializable
		{
			int num = (count != -1) ? count : (array.Length - offset);
			this.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
			foreach (T t in array)
			{
				this.WriteNetworkSerializable<T>(t);
			}
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0001F320 File Offset: 0x0001D520
		public unsafe void WriteValue(string s, bool oneByteChars = false)
		{
			uint length = (uint)s.Length;
			this.WriteValue<uint>(length, default(FastBufferWriter.ForPrimitives));
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

		// Token: 0x060007DB RID: 2011 RVA: 0x0001F390 File Offset: 0x0001D590
		public unsafe void WriteValueSafe(string s, bool oneByteChars = false)
		{
			int writeSize = FastBufferWriter.GetWriteSize(s, oneByteChars);
			if (!this.TryBeginWriteInternal(writeSize))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			uint length = (uint)s.Length;
			this.WriteValue<uint>(length, default(FastBufferWriter.ForPrimitives));
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

		// Token: 0x060007DC RID: 2012 RVA: 0x0001F420 File Offset: 0x0001D620
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWriteSize<[IsUnmanaged] T>(T[] array, int count = -1, int offset = 0) where T : struct, ValueType
		{
			int num = ((count != -1) ? count : (array.Length - offset)) * sizeof(T);
			return 4 + num;
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0001F444 File Offset: 0x0001D644
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWriteSize<[IsUnmanaged] T>(NativeArray<T> array, int count = -1, int offset = 0) where T : struct, ValueType
		{
			int num = ((count != -1) ? count : (array.Length - offset)) * sizeof(T);
			return 4 + num;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0001F46C File Offset: 0x0001D66C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WritePartialValue<[IsUnmanaged] T>(T value, int bytesToWrite, int offsetBytes = 0) where T : struct, ValueType
		{
			byte* source = (byte*)(&value) + offsetBytes;
			UnsafeUtility.MemCpy((void*)(this.Handle->BufferPointer + this.Handle->Position), (void*)source, (long)bytesToWrite);
			this.Handle->Position += bytesToWrite;
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0001F4B0 File Offset: 0x0001D6B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteByte(byte value)
		{
			ref byte bufferPointer = ref *this.Handle->BufferPointer;
			FastBufferWriter.WriterHandle* handle = this.Handle;
			int position = handle->Position;
			handle->Position = position + 1;
			*(ref bufferPointer + position) = value;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0001F4E0 File Offset: 0x0001D6E0
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

		// Token: 0x060007E1 RID: 2017 RVA: 0x0001F522 File Offset: 0x0001D722
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytes(byte* value, int size, int offset = 0)
		{
			UnsafeUtility.MemCpy((void*)(this.Handle->BufferPointer + this.Handle->Position), (void*)(value + offset), (long)size);
			this.Handle->Position += size;
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0001F558 File Offset: 0x0001D758
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytesSafe(byte* value, int size, int offset = 0)
		{
			if (!this.TryBeginWriteInternal(size))
			{
				throw new OverflowException(string.Format("Writing past the end of the buffer, size is {0} bytes but remaining capacity is {1} bytes", size, this.Handle->Capacity - this.Handle->Position));
			}
			UnsafeUtility.MemCpy((void*)(this.Handle->BufferPointer + this.Handle->Position), (void*)(value + offset), (long)size);
			this.Handle->Position += size;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0001F5D4 File Offset: 0x0001D7D4
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

		// Token: 0x060007E4 RID: 2020 RVA: 0x0001F610 File Offset: 0x0001D810
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytes(NativeArray<byte> value, int size = -1, int offset = 0)
		{
			byte* unsafePtr = (byte*)value.GetUnsafePtr<byte>();
			this.WriteBytes(unsafePtr, (size == -1) ? value.Length : size, offset);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0001F63C File Offset: 0x0001D83C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytes(NativeList<byte> value, int size = -1, int offset = 0)
		{
			byte* unsafePtr = (byte*)value.GetUnsafePtr<byte>();
			this.WriteBytes(unsafePtr, (size == -1) ? value.Length : size, offset);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0001F668 File Offset: 0x0001D868
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

		// Token: 0x060007E7 RID: 2023 RVA: 0x0001F6A4 File Offset: 0x0001D8A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytesSafe(NativeArray<byte> value, int size = -1, int offset = 0)
		{
			byte* unsafePtr = (byte*)value.GetUnsafePtr<byte>();
			this.WriteBytesSafe(unsafePtr, (size == -1) ? value.Length : size, offset);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0001F6D0 File Offset: 0x0001D8D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteBytesSafe(NativeList<byte> value, int size = -1, int offset = 0)
		{
			byte* unsafePtr = (byte*)value.GetUnsafePtr<byte>();
			this.WriteBytesSafe(unsafePtr, (size == -1) ? value.Length : size, offset);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0001F6FA File Offset: 0x0001D8FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void CopyTo(FastBufferWriter other)
		{
			other.WriteBytes(this.Handle->BufferPointer, this.Handle->Position, 0);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0001F71A File Offset: 0x0001D91A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void CopyFrom(FastBufferWriter other)
		{
			this.WriteBytes(other.Handle->BufferPointer, other.Handle->Position, 0);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0001F739 File Offset: 0x0001D939
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWriteSize<[IsUnmanaged] T>(in T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType
		{
			return sizeof(T);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0001F744 File Offset: 0x0001D944
		public static int GetWriteSize<[IsUnmanaged] T>(in T value) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			T t = value;
			return t.Length + 4;
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0001F768 File Offset: 0x0001D968
		public static int GetWriteSize<[IsUnmanaged] T>(in NativeArray<T> value) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int num = 4;
			NativeArray<T> nativeArray = value;
			foreach (T t in nativeArray)
			{
				num += 4 + t.Length;
			}
			return num;
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0001F739 File Offset: 0x0001D939
		public static int GetWriteSize<[IsUnmanaged] T>() where T : struct, ValueType
		{
			return sizeof(T);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0001F7CC File Offset: 0x0001D9CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void WriteUnmanaged<[IsUnmanaged] T>(in T value) where T : struct, ValueType
		{
			fixed (T* ptr = &value)
			{
				byte* value2 = (byte*)ptr;
				this.WriteBytes(value2, sizeof(T), 0);
			}
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0001F7F0 File Offset: 0x0001D9F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void WriteUnmanagedSafe<[IsUnmanaged] T>(in T value) where T : struct, ValueType
		{
			fixed (T* ptr = &value)
			{
				byte* value2 = (byte*)ptr;
				this.WriteBytesSafe(value2, sizeof(T), 0);
			}
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0001F814 File Offset: 0x0001DA14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void WriteUnmanaged<[IsUnmanaged] T>(T[] value) where T : struct, ValueType
		{
			int num = value.Length;
			this.WriteUnmanaged<int>(num);
			fixed (T[] array = value)
			{
				T* ptr;
				if (value == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = &array[0];
				}
				byte* value2 = (byte*)ptr;
				this.WriteBytes(value2, sizeof(T) * value.Length, 0);
			}
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0001F85C File Offset: 0x0001DA5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void WriteUnmanagedSafe<[IsUnmanaged] T>(T[] value) where T : struct, ValueType
		{
			int num = value.Length;
			this.WriteUnmanagedSafe<int>(num);
			fixed (T[] array = value)
			{
				T* ptr;
				if (value == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = &array[0];
				}
				byte* value2 = (byte*)ptr;
				this.WriteBytesSafe(value2, sizeof(T) * value.Length, 0);
			}
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0001F8A4 File Offset: 0x0001DAA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void WriteUnmanaged<[IsUnmanaged] T>(NativeArray<T> value) where T : struct, ValueType
		{
			int length = value.Length;
			this.WriteUnmanaged<int>(length);
			T* unsafePtr = (T*)value.GetUnsafePtr<T>();
			byte* value2 = (byte*)unsafePtr;
			this.WriteBytes(value2, sizeof(T) * value.Length, 0);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0001F8E0 File Offset: 0x0001DAE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void WriteUnmanagedSafe<[IsUnmanaged] T>(NativeArray<T> value) where T : struct, ValueType
		{
			int length = value.Length;
			this.WriteUnmanagedSafe<int>(length);
			T* unsafePtr = (T*)value.GetUnsafePtr<T>();
			byte* value2 = (byte*)unsafePtr;
			this.WriteBytesSafe(value2, sizeof(T) * value.Length, 0);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0001F91C File Offset: 0x0001DB1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<T>(in T value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable
		{
			this.WriteNetworkSerializable<T>(value);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0001F925 File Offset: 0x0001DB25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<T>(T[] value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable
		{
			this.WriteNetworkSerializable<T>(value, -1, 0);
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0001F91C File Offset: 0x0001DB1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<T>(in T value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable
		{
			this.WriteNetworkSerializable<T>(value);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0001F925 File Offset: 0x0001DB25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<T>(T[] value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable
		{
			this.WriteNetworkSerializable<T>(value, -1, 0);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0001F930 File Offset: 0x0001DB30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(in T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.WriteUnmanaged<T>(value);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0001F939 File Offset: 0x0001DB39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.WriteUnmanaged<T>(value);
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0001F942 File Offset: 0x0001DB42
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(NativeArray<T> value, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			if (typeof(INetworkSerializable).IsAssignableFrom(typeof(T)))
			{
				NetworkVariableSerialization<NativeArray<T>>.Serializer.Write(this, ref value);
				return;
			}
			this.WriteUnmanaged<T>(value);
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0001F979 File Offset: 0x0001DB79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(in T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0001F982 File Offset: 0x0001DB82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0001F98B File Offset: 0x0001DB8B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(NativeArray<T> value, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			if (typeof(INetworkSerializable).IsAssignableFrom(typeof(T)))
			{
				NetworkVariableSerialization<NativeArray<T>>.Serializer.Write(this, ref value);
				return;
			}
			this.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0001F930 File Offset: 0x0001DB30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(in T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.WriteUnmanaged<T>(value);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0001F939 File Offset: 0x0001DB39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.WriteUnmanaged<T>(value);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0001F979 File Offset: 0x0001DB79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(in T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0001F982 File Offset: 0x0001DB82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0001F930 File Offset: 0x0001DB30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(in T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.WriteUnmanaged<T>(value);
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0001F939 File Offset: 0x0001DB39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.WriteUnmanaged<T>(value);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0001F979 File Offset: 0x0001DB79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(in T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0001F982 File Offset: 0x0001DB82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.WriteUnmanagedSafe<T>(value);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0001F9C2 File Offset: 0x0001DBC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Vector2 value)
		{
			this.WriteUnmanaged<Vector2>(value);
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0001F9CB File Offset: 0x0001DBCB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Vector2[] value)
		{
			this.WriteUnmanaged<Vector2>(value);
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0001F9D4 File Offset: 0x0001DBD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Vector3 value)
		{
			this.WriteUnmanaged<Vector3>(value);
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0001F9DD File Offset: 0x0001DBDD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Vector3[] value)
		{
			this.WriteUnmanaged<Vector3>(value);
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0001F9E6 File Offset: 0x0001DBE6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Vector2Int value)
		{
			this.WriteUnmanaged<Vector2Int>(value);
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0001F9EF File Offset: 0x0001DBEF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Vector2Int[] value)
		{
			this.WriteUnmanaged<Vector2Int>(value);
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0001F9F8 File Offset: 0x0001DBF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Vector3Int value)
		{
			this.WriteUnmanaged<Vector3Int>(value);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0001FA01 File Offset: 0x0001DC01
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Vector3Int[] value)
		{
			this.WriteUnmanaged<Vector3Int>(value);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0001FA0A File Offset: 0x0001DC0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Vector4 value)
		{
			this.WriteUnmanaged<Vector4>(value);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0001FA13 File Offset: 0x0001DC13
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Vector4[] value)
		{
			this.WriteUnmanaged<Vector4>(value);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0001FA1C File Offset: 0x0001DC1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Quaternion value)
		{
			this.WriteUnmanaged<Quaternion>(value);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0001FA25 File Offset: 0x0001DC25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Quaternion[] value)
		{
			this.WriteUnmanaged<Quaternion>(value);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0001FA2E File Offset: 0x0001DC2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Color value)
		{
			this.WriteUnmanaged<Color>(value);
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0001FA37 File Offset: 0x0001DC37
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Color[] value)
		{
			this.WriteUnmanaged<Color>(value);
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0001FA40 File Offset: 0x0001DC40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Color32 value)
		{
			this.WriteUnmanaged<Color32>(value);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0001FA49 File Offset: 0x0001DC49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Color32[] value)
		{
			this.WriteUnmanaged<Color32>(value);
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0001FA52 File Offset: 0x0001DC52
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Ray value)
		{
			this.WriteUnmanaged<Ray>(value);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0001FA5B File Offset: 0x0001DC5B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Ray[] value)
		{
			this.WriteUnmanaged<Ray>(value);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0001FA64 File Offset: 0x0001DC64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(in Ray2D value)
		{
			this.WriteUnmanaged<Ray2D>(value);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0001FA6D File Offset: 0x0001DC6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Ray2D[] value)
		{
			this.WriteUnmanaged<Ray2D>(value);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0001FA76 File Offset: 0x0001DC76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Vector2 value)
		{
			this.WriteUnmanagedSafe<Vector2>(value);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0001FA7F File Offset: 0x0001DC7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Vector2[] value)
		{
			this.WriteUnmanagedSafe<Vector2>(value);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0001FA88 File Offset: 0x0001DC88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Vector3 value)
		{
			this.WriteUnmanagedSafe<Vector3>(value);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0001FA91 File Offset: 0x0001DC91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Vector3[] value)
		{
			this.WriteUnmanagedSafe<Vector3>(value);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0001FA9A File Offset: 0x0001DC9A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Vector2Int value)
		{
			this.WriteUnmanagedSafe<Vector2Int>(value);
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0001FAA3 File Offset: 0x0001DCA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Vector2Int[] value)
		{
			this.WriteUnmanagedSafe<Vector2Int>(value);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0001FAAC File Offset: 0x0001DCAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Vector3Int value)
		{
			this.WriteUnmanagedSafe<Vector3Int>(value);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0001FAB5 File Offset: 0x0001DCB5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Vector3Int[] value)
		{
			this.WriteUnmanagedSafe<Vector3Int>(value);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0001FABE File Offset: 0x0001DCBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Vector4 value)
		{
			this.WriteUnmanagedSafe<Vector4>(value);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0001FAC7 File Offset: 0x0001DCC7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Vector4[] value)
		{
			this.WriteUnmanagedSafe<Vector4>(value);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0001FAD0 File Offset: 0x0001DCD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Quaternion value)
		{
			this.WriteUnmanagedSafe<Quaternion>(value);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0001FAD9 File Offset: 0x0001DCD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Quaternion[] value)
		{
			this.WriteUnmanagedSafe<Quaternion>(value);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0001FAE2 File Offset: 0x0001DCE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Color value)
		{
			this.WriteUnmanagedSafe<Color>(value);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0001FAEB File Offset: 0x0001DCEB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Color[] value)
		{
			this.WriteUnmanagedSafe<Color>(value);
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x0001FAF4 File Offset: 0x0001DCF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Color32 value)
		{
			this.WriteUnmanagedSafe<Color32>(value);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0001FAFD File Offset: 0x0001DCFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Color32[] value)
		{
			this.WriteUnmanagedSafe<Color32>(value);
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0001FB06 File Offset: 0x0001DD06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Ray value)
		{
			this.WriteUnmanagedSafe<Ray>(value);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0001FB0F File Offset: 0x0001DD0F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Ray[] value)
		{
			this.WriteUnmanagedSafe<Ray>(value);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0001FB18 File Offset: 0x0001DD18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(in Ray2D value)
		{
			this.WriteUnmanagedSafe<Ray2D>(value);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0001FB21 File Offset: 0x0001DD21
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe(Ray2D[] value)
		{
			this.WriteUnmanagedSafe<Ray2D>(value);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0001FB2C File Offset: 0x0001DD2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteValue<[IsUnmanaged] T>(in T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			T t = value;
			int length = t.Length;
			this.WriteUnmanaged<int>(length);
			fixed (T* ptr = &value)
			{
				T* ptr2 = ptr;
				byte* unsafePtr = ptr2->GetUnsafePtr();
				t = value;
				this.WriteBytes(unsafePtr, t.Length, 0);
			}
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0001FB88 File Offset: 0x0001DD88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(T[] value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int i = value.Length;
			this.WriteUnmanaged<int>(i);
			foreach (T t in value)
			{
				this.WriteValue<T>(t, default(FastBufferWriter.ForFixedStrings));
			}
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0001FBCC File Offset: 0x0001DDCC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<[IsUnmanaged] T>(in NativeArray<T> value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			NativeArray<T> nativeArray = value;
			int length = nativeArray.Length;
			this.WriteUnmanaged<int>(length);
			nativeArray = value;
			foreach (T t in nativeArray)
			{
				this.WriteValue<T>(t, default(FastBufferWriter.ForFixedStrings));
			}
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0001FC44 File Offset: 0x0001DE44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(in T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int num = 4;
			T t = value;
			if (!this.TryBeginWriteInternal(num + t.Length))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			this.WriteValue<T>(value, default(FastBufferWriter.ForFixedStrings));
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0001FC8C File Offset: 0x0001DE8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(T[] value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			if (!this.TryBeginWriteInternal(FastBufferWriter.GetWriteSize<T>(value, -1, 0)))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			int i = value.Length;
			this.WriteUnmanaged<int>(i);
			foreach (T t in value)
			{
				this.WriteValue<T>(t, default(FastBufferWriter.ForFixedStrings));
			}
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0001FCEC File Offset: 0x0001DEEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueSafe<[IsUnmanaged] T>(in NativeArray<T> value) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			if (!this.TryBeginWriteInternal(FastBufferWriter.GetWriteSize<T>(value)))
			{
				throw new OverflowException("Writing past the end of the buffer");
			}
			NativeArray<T> nativeArray = value;
			int length = nativeArray.Length;
			this.WriteUnmanaged<int>(length);
			nativeArray = value;
			foreach (T t in nativeArray)
			{
				this.WriteValue<T>(t, default(FastBufferWriter.ForFixedStrings));
			}
		}

		// Token: 0x0400031E RID: 798
		internal unsafe FastBufferWriter.WriterHandle* Handle;

		// Token: 0x0400031F RID: 799
		private static byte[] s_ByteArrayCache = new byte[65535];

		// Token: 0x02000103 RID: 259
		internal struct WriterHandle
		{
			// Token: 0x04000320 RID: 800
			internal unsafe byte* BufferPointer;

			// Token: 0x04000321 RID: 801
			internal int Position;

			// Token: 0x04000322 RID: 802
			internal int Length;

			// Token: 0x04000323 RID: 803
			internal int Capacity;

			// Token: 0x04000324 RID: 804
			internal int MaxCapacity;

			// Token: 0x04000325 RID: 805
			internal Allocator Allocator;

			// Token: 0x04000326 RID: 806
			internal bool BufferGrew;
		}

		// Token: 0x02000104 RID: 260
		public struct ForPrimitives
		{
		}

		// Token: 0x02000105 RID: 261
		public struct ForEnums
		{
		}

		// Token: 0x02000106 RID: 262
		public struct ForStructs
		{
		}

		// Token: 0x02000107 RID: 263
		public struct ForNetworkSerializable
		{
		}

		// Token: 0x02000108 RID: 264
		public struct ForFixedStrings
		{
		}

		// Token: 0x02000109 RID: 265
		public struct ForGeneric
		{
		}
	}
}
