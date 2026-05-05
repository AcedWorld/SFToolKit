using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000100 RID: 256
	public struct FastBufferReader : IDisposable
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x0001E0A9 File Offset: 0x0001C2A9
		public unsafe int Position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->Position;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x0001E0B6 File Offset: 0x0001C2B6
		public unsafe int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.Handle->Length;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x0001E0C3 File Offset: 0x0001C2C3
		public bool IsInitialized
		{
			get
			{
				return this.Handle != null;
			}
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0001E0D2 File Offset: 0x0001C2D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void CommitBitwiseReads(int amount)
		{
			this.Handle->Position += amount;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0001E0E4 File Offset: 0x0001C2E4
		private unsafe static FastBufferReader.ReaderHandle* CreateHandle(byte* buffer, int length, int offset, Allocator copyAllocator, Allocator internalAllocator)
		{
			FastBufferReader.ReaderHandle* ptr;
			if (copyAllocator == Allocator.None)
			{
				ptr = (FastBufferReader.ReaderHandle*)UnsafeUtility.Malloc((long)sizeof(FastBufferReader.ReaderHandle), UnsafeUtility.AlignOf<byte>(), internalAllocator);
				ptr->BufferPointer = buffer;
				ptr->Position = offset;
			}
			else
			{
				ptr = (FastBufferReader.ReaderHandle*)UnsafeUtility.Malloc((long)(sizeof(FastBufferReader.ReaderHandle) + length), UnsafeUtility.AlignOf<byte>(), copyAllocator);
				UnsafeUtility.MemCpy((void*)(ptr + 1), (void*)(buffer + offset), (long)length);
				ptr->BufferPointer = (byte*)(ptr + 1);
				ptr->Position = 0;
			}
			ptr->Length = length;
			ptr->Allocator = ((copyAllocator == Allocator.None) ? internalAllocator : copyAllocator);
			return ptr;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0001E16C File Offset: 0x0001C36C
		public unsafe FastBufferReader(NativeArray<byte> buffer, Allocator copyAllocator, int length = -1, int offset = 0, Allocator internalAllocator = Allocator.Temp)
		{
			this.Handle = FastBufferReader.CreateHandle((byte*)buffer.GetUnsafePtr<byte>(), (length == -1) ? buffer.Length : length, offset, copyAllocator, internalAllocator);
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0001E194 File Offset: 0x0001C394
		public unsafe FastBufferReader(ArraySegment<byte> buffer, Allocator copyAllocator, int length = -1, int offset = 0)
		{
			if (copyAllocator == Allocator.None)
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
			this.Handle = FastBufferReader.CreateHandle(buffer2, (length == -1) ? buffer.Count : length, offset, copyAllocator, Allocator.Temp);
			array = null;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0001E1F0 File Offset: 0x0001C3F0
		public unsafe FastBufferReader(byte[] buffer, Allocator copyAllocator, int length = -1, int offset = 0)
		{
			if (copyAllocator == Allocator.None)
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
				this.Handle = FastBufferReader.CreateHandle(buffer2, (length == -1) ? buffer.Length : length, offset, copyAllocator, Allocator.Temp);
			}
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0001E240 File Offset: 0x0001C440
		public unsafe FastBufferReader(byte* buffer, Allocator copyAllocator, int length, int offset = 0, Allocator internalAllocator = Allocator.Temp)
		{
			this.Handle = FastBufferReader.CreateHandle(buffer, length, offset, copyAllocator, internalAllocator);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0001E254 File Offset: 0x0001C454
		public FastBufferReader(FastBufferWriter writer, Allocator copyAllocator, int length = -1, int offset = 0, Allocator internalAllocator = Allocator.Temp)
		{
			this.Handle = FastBufferReader.CreateHandle(writer.GetUnsafePtr(), (length == -1) ? writer.Length : length, offset, copyAllocator, internalAllocator);
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0001E27B File Offset: 0x0001C47B
		public FastBufferReader(FastBufferReader reader, Allocator copyAllocator, int length = -1, int offset = 0, Allocator internalAllocator = Allocator.Temp)
		{
			this.Handle = FastBufferReader.CreateHandle(reader.GetUnsafePtr(), (length == -1) ? reader.Length : length, offset, copyAllocator, internalAllocator);
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0001E2A2 File Offset: 0x0001C4A2
		public unsafe void Dispose()
		{
			UnsafeUtility.Free((void*)this.Handle, this.Handle->Allocator);
			this.Handle = null;
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0001E2C2 File Offset: 0x0001C4C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void Seek(int where)
		{
			this.Handle->Position = Math.Min(this.Length, where);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0001E0D2 File Offset: 0x0001C2D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void MarkBytesRead(int amount)
		{
			this.Handle->Position += amount;
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0001E2DB File Offset: 0x0001C4DB
		public BitReader EnterBitwiseContext()
		{
			return new BitReader(this);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0001E2E8 File Offset: 0x0001C4E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool TryBeginRead(int bytes)
		{
			return this.Handle->Position + bytes <= this.Handle->Length;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0001E308 File Offset: 0x0001C508
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool TryBeginReadValue<[IsUnmanaged] T>(in T value) where T : struct, ValueType
		{
			int num = sizeof(T);
			return this.Handle->Position + num <= this.Handle->Length;
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0001E2E8 File Offset: 0x0001C4E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe bool TryBeginReadInternal(int bytes)
		{
			return this.Handle->Position + bytes <= this.Handle->Length;
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0001E33C File Offset: 0x0001C53C
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

		// Token: 0x0600076B RID: 1899 RVA: 0x0001E386 File Offset: 0x0001C586
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtr()
		{
			return this.Handle->BufferPointer;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0001E393 File Offset: 0x0001C593
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe byte* GetUnsafePtrAtCurrentPosition()
		{
			return this.Handle->BufferPointer + this.Handle->Position;
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0001E3AC File Offset: 0x0001C5AC
		public void ReadNetworkSerializable<T>(out T value) where T : INetworkSerializable, new()
		{
			value = Activator.CreateInstance<T>();
			BufferSerializer<BufferSerializerReader> serializer = new BufferSerializer<BufferSerializerReader>(new BufferSerializerReader(this));
			value.NetworkSerialize<BufferSerializerReader>(serializer);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0001E3E4 File Offset: 0x0001C5E4
		public void ReadNetworkSerializable<T>(out T[] value) where T : INetworkSerializable, new()
		{
			int num;
			this.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			value = new T[num];
			for (int i = 0; i < num; i++)
			{
				this.ReadNetworkSerializable<T>(out value[i]);
			}
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0001E424 File Offset: 0x0001C624
		public void ReadNetworkSerializable<[IsUnmanaged] T>(out NativeArray<T> value, Allocator allocator) where T : struct, ValueType, INetworkSerializable
		{
			int num;
			this.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			value = new NativeArray<T>(num, allocator, NativeArrayOptions.ClearMemory);
			for (int i = 0; i < num; i++)
			{
				T value2;
				this.ReadNetworkSerializable<T>(out value2);
				value[i] = value2;
			}
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0001E46C File Offset: 0x0001C66C
		public void ReadNetworkSerializableInPlace<T>(ref T value) where T : INetworkSerializable
		{
			BufferSerializer<BufferSerializerReader> serializer = new BufferSerializer<BufferSerializerReader>(new BufferSerializerReader(this));
			value.NetworkSerialize<BufferSerializerReader>(serializer);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0001E498 File Offset: 0x0001C698
		public unsafe void ReadValue(out string s, bool oneByteChars = false)
		{
			uint totalWidth;
			this.ReadValue<uint>(out totalWidth, default(FastBufferWriter.ForPrimitives));
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

		// Token: 0x06000772 RID: 1906 RVA: 0x0001E514 File Offset: 0x0001C714
		public unsafe void ReadValueSafe(out string s, bool oneByteChars = false)
		{
			if (!this.TryBeginReadInternal(4))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			uint num;
			this.ReadValue<uint>(out num, default(FastBufferWriter.ForPrimitives));
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

		// Token: 0x06000773 RID: 1907 RVA: 0x0001E5C0 File Offset: 0x0001C7C0
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

		// Token: 0x06000774 RID: 1908 RVA: 0x0001E610 File Offset: 0x0001C810
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadByte(out byte value)
		{
			int bufferPointer = this.Handle->BufferPointer;
			FastBufferReader.ReaderHandle* handle = this.Handle;
			int position = handle->Position;
			handle->Position = position + 1;
			value = *(bufferPointer + position);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0001E640 File Offset: 0x0001C840
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

		// Token: 0x06000776 RID: 1910 RVA: 0x0001E683 File Offset: 0x0001C883
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadBytes(byte* value, int size, int offset = 0)
		{
			UnsafeUtility.MemCpy((void*)(value + offset), (void*)(this.Handle->BufferPointer + this.Handle->Position), (long)size);
			this.Handle->Position += size;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0001E6B8 File Offset: 0x0001C8B8
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

		// Token: 0x06000778 RID: 1912 RVA: 0x0001E70C File Offset: 0x0001C90C
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

		// Token: 0x06000779 RID: 1913 RVA: 0x0001E740 File Offset: 0x0001C940
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

		// Token: 0x0600077A RID: 1914 RVA: 0x0001E774 File Offset: 0x0001C974
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void ReadUnmanaged<[IsUnmanaged] T>(out T value) where T : struct, ValueType
		{
			fixed (T* ptr = &value)
			{
				byte* value2 = (byte*)ptr;
				this.ReadBytes(value2, sizeof(T), 0);
			}
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0001E798 File Offset: 0x0001C998
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void ReadUnmanagedSafe<[IsUnmanaged] T>(out T value) where T : struct, ValueType
		{
			fixed (T* ptr = &value)
			{
				byte* value2 = (byte*)ptr;
				this.ReadBytesSafe(value2, sizeof(T), 0);
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0001E7BC File Offset: 0x0001C9BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void ReadUnmanaged<[IsUnmanaged] T>(out T[] value) where T : struct, ValueType
		{
			int num;
			this.ReadUnmanaged<int>(out num);
			int size = num * sizeof(T);
			value = new T[num];
			T[] array;
			T* ptr;
			if ((array = value) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte* value2 = (byte*)ptr;
			this.ReadBytes(value2, size, 0);
			array = null;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0001E80C File Offset: 0x0001CA0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void ReadUnmanagedSafe<[IsUnmanaged] T>(out T[] value) where T : struct, ValueType
		{
			int num;
			this.ReadUnmanagedSafe<int>(out num);
			int size = num * sizeof(T);
			value = new T[num];
			T[] array;
			T* ptr;
			if ((array = value) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte* value2 = (byte*)ptr;
			this.ReadBytesSafe(value2, size, 0);
			array = null;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0001E85C File Offset: 0x0001CA5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void ReadUnmanaged<[IsUnmanaged] T>(out NativeArray<T> value, Allocator allocator) where T : struct, ValueType
		{
			int num;
			this.ReadUnmanaged<int>(out num);
			int size = num * sizeof(T);
			value = new NativeArray<T>(num, allocator, NativeArrayOptions.ClearMemory);
			byte* unsafePtr = (byte*)value.GetUnsafePtr<T>();
			this.ReadBytes(unsafePtr, size, 0);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0001E8A0 File Offset: 0x0001CAA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe void ReadUnmanagedSafe<[IsUnmanaged] T>(out NativeArray<T> value, Allocator allocator) where T : struct, ValueType
		{
			int num;
			this.ReadUnmanagedSafe<int>(out num);
			int size = num * sizeof(T);
			value = new NativeArray<T>(num, allocator, NativeArrayOptions.ClearMemory);
			byte* unsafePtr = (byte*)value.GetUnsafePtr<T>();
			this.ReadBytesSafe(unsafePtr, size, 0);
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0001E8E1 File Offset: 0x0001CAE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<T>(out T value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.ReadNetworkSerializable<T>(out value);
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x0001E8EA File Offset: 0x0001CAEA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<T>(out T[] value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.ReadNetworkSerializable<T>(out value);
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0001E8E1 File Offset: 0x0001CAE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<T>(out T value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.ReadNetworkSerializable<T>(out value);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0001E8EA File Offset: 0x0001CAEA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<T>(out T[] value, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : INetworkSerializable, new()
		{
			this.ReadNetworkSerializable<T>(out value);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0001E8F3 File Offset: 0x0001CAF3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out NativeArray<T> value, Allocator allocator, FastBufferWriter.ForNetworkSerializable unused = default(FastBufferWriter.ForNetworkSerializable)) where T : struct, ValueType, INetworkSerializable
		{
			this.ReadNetworkSerializable<T>(out value, allocator);
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0001E8FD File Offset: 0x0001CAFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<[IsUnmanaged] T>(out T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.ReadUnmanaged<T>(out value);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0001E906 File Offset: 0x0001CB06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<[IsUnmanaged] T>(out T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.ReadUnmanaged<T>(out value);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0001E90F File Offset: 0x0001CB0F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<[IsUnmanaged] T>(out NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			if (typeof(INetworkSerializable).IsAssignableFrom(typeof(T)))
			{
				NetworkVariableSerialization<NativeArray<T>>.Serializer.ReadWithAllocator(this, out value, allocator);
				return;
			}
			this.ReadUnmanaged<T>(out value, allocator);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0001E947 File Offset: 0x0001CB47
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueTemp<[IsUnmanaged] T>(out NativeArray<T> value, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			if (typeof(INetworkSerializable).IsAssignableFrom(typeof(T)))
			{
				NetworkVariableSerialization<NativeArray<T>>.Serializer.ReadWithAllocator(this, out value, Allocator.Temp);
				return;
			}
			this.ReadUnmanaged<T>(out value, Allocator.Temp);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0001E97F File Offset: 0x0001CB7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out T value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.ReadUnmanagedSafe<T>(out value);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0001E988 File Offset: 0x0001CB88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out T[] value, FastBufferWriter.ForStructs unused = default(FastBufferWriter.ForStructs)) where T : struct, ValueType, INetworkSerializeByMemcpy
		{
			this.ReadUnmanagedSafe<T>(out value);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0001E991 File Offset: 0x0001CB91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out NativeArray<T> value, Allocator allocator, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			if (typeof(INetworkSerializable).IsAssignableFrom(typeof(T)))
			{
				NetworkVariableSerialization<NativeArray<T>>.Serializer.ReadWithAllocator(this, out value, allocator);
				return;
			}
			this.ReadUnmanagedSafe<T>(out value, allocator);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0001E9C9 File Offset: 0x0001CBC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafeTemp<[IsUnmanaged] T>(out NativeArray<T> value, FastBufferWriter.ForGeneric unused = default(FastBufferWriter.ForGeneric)) where T : struct, ValueType
		{
			if (typeof(INetworkSerializable).IsAssignableFrom(typeof(T)))
			{
				NetworkVariableSerialization<NativeArray<T>>.Serializer.ReadWithAllocator(this, out value, Allocator.Temp);
				return;
			}
			this.ReadUnmanagedSafe<T>(out value, Allocator.Temp);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0001E8FD File Offset: 0x0001CAFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<[IsUnmanaged] T>(out T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.ReadUnmanaged<T>(out value);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0001E906 File Offset: 0x0001CB06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<[IsUnmanaged] T>(out T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.ReadUnmanaged<T>(out value);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0001E97F File Offset: 0x0001CB7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out T value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.ReadUnmanagedSafe<T>(out value);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0001E988 File Offset: 0x0001CB88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out T[] value, FastBufferWriter.ForPrimitives unused = default(FastBufferWriter.ForPrimitives)) where T : struct, ValueType, IComparable, IConvertible, IComparable<T>, IEquatable<T>
		{
			this.ReadUnmanagedSafe<T>(out value);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0001E8FD File Offset: 0x0001CAFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<[IsUnmanaged] T>(out T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.ReadUnmanaged<T>(out value);
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0001E906 File Offset: 0x0001CB06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<[IsUnmanaged] T>(out T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.ReadUnmanaged<T>(out value);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0001E97F File Offset: 0x0001CB7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out T value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.ReadUnmanagedSafe<T>(out value);
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0001E988 File Offset: 0x0001CB88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out T[] value, FastBufferWriter.ForEnums unused = default(FastBufferWriter.ForEnums)) where T : struct, ValueType, Enum
		{
			this.ReadUnmanagedSafe<T>(out value);
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0001EA01 File Offset: 0x0001CC01
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector2 value)
		{
			this.ReadUnmanaged<Vector2>(out value);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0001EA0A File Offset: 0x0001CC0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector2[] value)
		{
			this.ReadUnmanaged<Vector2>(out value);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0001EA13 File Offset: 0x0001CC13
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector3 value)
		{
			this.ReadUnmanaged<Vector3>(out value);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0001EA1C File Offset: 0x0001CC1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector3[] value)
		{
			this.ReadUnmanaged<Vector3>(out value);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0001EA25 File Offset: 0x0001CC25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector2Int value)
		{
			this.ReadUnmanaged<Vector2Int>(out value);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001EA2E File Offset: 0x0001CC2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector2Int[] value)
		{
			this.ReadUnmanaged<Vector2Int>(out value);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0001EA37 File Offset: 0x0001CC37
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector3Int value)
		{
			this.ReadUnmanaged<Vector3Int>(out value);
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0001EA40 File Offset: 0x0001CC40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector3Int[] value)
		{
			this.ReadUnmanaged<Vector3Int>(out value);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001EA49 File Offset: 0x0001CC49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector4 value)
		{
			this.ReadUnmanaged<Vector4>(out value);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001EA52 File Offset: 0x0001CC52
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Vector4[] value)
		{
			this.ReadUnmanaged<Vector4>(out value);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001EA5B File Offset: 0x0001CC5B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Quaternion value)
		{
			this.ReadUnmanaged<Quaternion>(out value);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001EA64 File Offset: 0x0001CC64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Quaternion[] value)
		{
			this.ReadUnmanaged<Quaternion>(out value);
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0001EA6D File Offset: 0x0001CC6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Color value)
		{
			this.ReadUnmanaged<Color>(out value);
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0001EA76 File Offset: 0x0001CC76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Color[] value)
		{
			this.ReadUnmanaged<Color>(out value);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0001EA7F File Offset: 0x0001CC7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Color32 value)
		{
			this.ReadUnmanaged<Color32>(out value);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0001EA88 File Offset: 0x0001CC88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Color32[] value)
		{
			this.ReadUnmanaged<Color32>(out value);
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0001EA91 File Offset: 0x0001CC91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Ray value)
		{
			this.ReadUnmanaged<Ray>(out value);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001EA9A File Offset: 0x0001CC9A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Ray[] value)
		{
			this.ReadUnmanaged<Ray>(out value);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0001EAA3 File Offset: 0x0001CCA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Ray2D value)
		{
			this.ReadUnmanaged<Ray2D>(out value);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001EAAC File Offset: 0x0001CCAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(out Ray2D[] value)
		{
			this.ReadUnmanaged<Ray2D>(out value);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0001EAB5 File Offset: 0x0001CCB5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector2 value)
		{
			this.ReadUnmanagedSafe<Vector2>(out value);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0001EABE File Offset: 0x0001CCBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector2[] value)
		{
			this.ReadUnmanagedSafe<Vector2>(out value);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0001EAC7 File Offset: 0x0001CCC7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector3 value)
		{
			this.ReadUnmanagedSafe<Vector3>(out value);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0001EAD0 File Offset: 0x0001CCD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector3[] value)
		{
			this.ReadUnmanagedSafe<Vector3>(out value);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0001EAD9 File Offset: 0x0001CCD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector2Int value)
		{
			this.ReadUnmanagedSafe<Vector2Int>(out value);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0001EAE2 File Offset: 0x0001CCE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector2Int[] value)
		{
			this.ReadUnmanagedSafe<Vector2Int>(out value);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0001EAEB File Offset: 0x0001CCEB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector3Int value)
		{
			this.ReadUnmanagedSafe<Vector3Int>(out value);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x0001EAF4 File Offset: 0x0001CCF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector3Int[] value)
		{
			this.ReadUnmanagedSafe<Vector3Int>(out value);
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0001EAFD File Offset: 0x0001CCFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector4 value)
		{
			this.ReadUnmanagedSafe<Vector4>(out value);
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0001EB06 File Offset: 0x0001CD06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Vector4[] value)
		{
			this.ReadUnmanagedSafe<Vector4>(out value);
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0001EB0F File Offset: 0x0001CD0F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Quaternion value)
		{
			this.ReadUnmanagedSafe<Quaternion>(out value);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0001EB18 File Offset: 0x0001CD18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Quaternion[] value)
		{
			this.ReadUnmanagedSafe<Quaternion>(out value);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0001EB21 File Offset: 0x0001CD21
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Color value)
		{
			this.ReadUnmanagedSafe<Color>(out value);
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0001EB2A File Offset: 0x0001CD2A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Color[] value)
		{
			this.ReadUnmanagedSafe<Color>(out value);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0001EB33 File Offset: 0x0001CD33
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Color32 value)
		{
			this.ReadUnmanagedSafe<Color32>(out value);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0001EB3C File Offset: 0x0001CD3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Color32[] value)
		{
			this.ReadUnmanagedSafe<Color32>(out value);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0001EB45 File Offset: 0x0001CD45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Ray value)
		{
			this.ReadUnmanagedSafe<Ray>(out value);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0001EB4E File Offset: 0x0001CD4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Ray[] value)
		{
			this.ReadUnmanagedSafe<Ray>(out value);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0001EB57 File Offset: 0x0001CD57
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Ray2D value)
		{
			this.ReadUnmanagedSafe<Ray2D>(out value);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0001EB60 File Offset: 0x0001CD60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe(out Ray2D[] value)
		{
			this.ReadUnmanagedSafe<Ray2D>(out value);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0001EB6C File Offset: 0x0001CD6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<[IsUnmanaged] T>(out T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int num;
			this.ReadUnmanaged<int>(out num);
			T t = Activator.CreateInstance<T>();
			t.Length = num;
			value = t;
			this.ReadBytes(value.GetUnsafePtr(), num, 0);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0001EBB0 File Offset: 0x0001CDB0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int num;
			this.ReadUnmanagedSafe<int>(out num);
			T t = Activator.CreateInstance<T>();
			t.Length = num;
			value = t;
			this.ReadBytesSafe(value.GetUnsafePtr(), num, 0);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0001EBF4 File Offset: 0x0001CDF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafeInPlace<[IsUnmanaged] T>(ref T value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int num;
			this.ReadUnmanagedSafe<int>(out num);
			value.Length = num;
			this.ReadBytesSafe(value.GetUnsafePtr(), num, 0);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0001EC2C File Offset: 0x0001CE2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadValueSafe<[IsUnmanaged] T>(out NativeArray<T> value, Allocator allocator) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int num;
			this.ReadUnmanagedSafe<int>(out num);
			value = new NativeArray<T>(num, allocator, NativeArrayOptions.ClearMemory);
			T* unsafePtr = (T*)value.GetUnsafePtr<T>();
			for (int i = 0; i < num; i++)
			{
				this.ReadValueSafeInPlace<T>(ref unsafePtr[(IntPtr)i * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)], default(FastBufferWriter.ForFixedStrings));
			}
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0001EC84 File Offset: 0x0001CE84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void ReadValueSafeTemp<[IsUnmanaged] T>(out NativeArray<T> value) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int num;
			this.ReadUnmanagedSafe<int>(out num);
			value = new NativeArray<T>(num, Allocator.Temp, NativeArrayOptions.ClearMemory);
			T* unsafePtr = (T*)value.GetUnsafePtr<T>();
			for (int i = 0; i < num; i++)
			{
				this.ReadValueSafeInPlace<T>(ref unsafePtr[(IntPtr)i * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)], default(FastBufferWriter.ForFixedStrings));
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0001ECDC File Offset: 0x0001CEDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueSafe<[IsUnmanaged] T>(out T[] value, FastBufferWriter.ForFixedStrings unused = default(FastBufferWriter.ForFixedStrings)) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int num;
			this.ReadUnmanagedSafe<int>(out num);
			value = new T[num];
			for (int i = 0; i < num; i++)
			{
				this.ReadValueSafeInPlace<T>(ref value[i], default(FastBufferWriter.ForFixedStrings));
			}
		}

		// Token: 0x04000319 RID: 793
		internal unsafe FastBufferReader.ReaderHandle* Handle;

		// Token: 0x02000101 RID: 257
		internal struct ReaderHandle
		{
			// Token: 0x0400031A RID: 794
			internal unsafe byte* BufferPointer;

			// Token: 0x0400031B RID: 795
			internal int Position;

			// Token: 0x0400031C RID: 796
			internal int Length;

			// Token: 0x0400031D RID: 797
			internal Allocator Allocator;
		}
	}
}
