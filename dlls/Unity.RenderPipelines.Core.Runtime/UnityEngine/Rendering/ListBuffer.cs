using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.Rendering
{
	// Token: 0x0200004A RID: 74
	public struct ListBuffer<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0000BF0A File Offset: 0x0000A10A
		internal unsafe T* BufferPtr
		{
			get
			{
				return this.m_BufferPtr;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000285 RID: 645 RVA: 0x0000BF12 File Offset: 0x0000A112
		public unsafe int Count
		{
			get
			{
				return *this.m_CountPtr;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000286 RID: 646 RVA: 0x0000BF1B File Offset: 0x0000A11B
		public int Capacity
		{
			get
			{
				return this.m_Capacity;
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000BF23 File Offset: 0x0000A123
		public unsafe ListBuffer(T* bufferPtr, int* countPtr, int capacity)
		{
			this.m_BufferPtr = bufferPtr;
			this.m_Capacity = capacity;
			this.m_CountPtr = countPtr;
		}

		// Token: 0x1700004C RID: 76
		public unsafe T this[in int index]
		{
			get
			{
				if (index < 0 || index >= this.Count)
				{
					throw new IndexOutOfRangeException(string.Format("Expected a value between 0 and {0}, but received {1}.", this.Count, index));
				}
				return ref this.m_BufferPtr[(IntPtr)index * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000BF8B File Offset: 0x0000A18B
		public unsafe ref T GetUnchecked(in int index)
		{
			return ref this.m_BufferPtr[(IntPtr)index * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000BF9E File Offset: 0x0000A19E
		public unsafe bool TryAdd(in T value)
		{
			if (this.Count >= this.m_Capacity)
			{
				return false;
			}
			this.m_BufferPtr[(IntPtr)this.Count * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)] = value;
			(*this.m_CountPtr)++;
			return true;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000BFDC File Offset: 0x0000A1DC
		public unsafe void CopyTo(T* dstBuffer, int startDstIndex, int copyCount)
		{
			UnsafeUtility.MemCpy((void*)(dstBuffer + (IntPtr)startDstIndex * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)), (void*)this.m_BufferPtr, (long)(UnsafeUtility.SizeOf<T>() * copyCount));
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000BFFC File Offset: 0x0000A1FC
		public unsafe bool TryCopyTo(ListBuffer<T> other)
		{
			if (other.Count + this.Count >= other.m_Capacity)
			{
				return false;
			}
			UnsafeUtility.MemCpy((void*)(other.m_BufferPtr + (IntPtr)other.Count * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)), (void*)this.m_BufferPtr, (long)(UnsafeUtility.SizeOf<T>() * this.Count));
			*other.m_CountPtr += this.Count;
			return true;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000C060 File Offset: 0x0000A260
		public unsafe bool TryCopyFrom(T* srcPtr, int count)
		{
			if (count + this.Count > this.m_Capacity)
			{
				return false;
			}
			UnsafeUtility.MemCpy((void*)(this.m_BufferPtr + (IntPtr)this.Count * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)), (void*)srcPtr, (long)(UnsafeUtility.SizeOf<T>() * count));
			*this.m_CountPtr += count;
			return true;
		}

		// Token: 0x04000191 RID: 401
		private unsafe T* m_BufferPtr;

		// Token: 0x04000192 RID: 402
		private int m_Capacity;

		// Token: 0x04000193 RID: 403
		private unsafe int* m_CountPtr;
	}
}
