using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x02000093 RID: 147
	public struct RelayAllocationId : IEquatable<RelayAllocationId>, IComparable<RelayAllocationId>
	{
		// Token: 0x06000279 RID: 633 RVA: 0x0000DBE8 File Offset: 0x0000BDE8
		public unsafe static RelayAllocationId FromBytePointer(byte* dataPtr, int length)
		{
			if (length != 16)
			{
				Debug.LogError(string.Format("Provided byte array length is invalid, must be {0} but got {1}.", 16, length));
				return default(RelayAllocationId);
			}
			RelayAllocationId result = default(RelayAllocationId);
			UnsafeUtility.MemCpy((void*)(&result.Value.FixedElementField), (void*)dataPtr, 16L);
			return result;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000DC40 File Offset: 0x0000BE40
		public unsafe static RelayAllocationId FromByteArray(byte[] data)
		{
			byte* dataPtr;
			if (data == null || data.Length == 0)
			{
				dataPtr = null;
			}
			else
			{
				dataPtr = &data[0];
			}
			return RelayAllocationId.FromBytePointer(dataPtr, data.Length);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000DC6E File Offset: 0x0000BE6E
		public static bool operator ==(RelayAllocationId lhs, RelayAllocationId rhs)
		{
			return lhs.Compare(rhs) == 0;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000DC7B File Offset: 0x0000BE7B
		public static bool operator !=(RelayAllocationId lhs, RelayAllocationId rhs)
		{
			return lhs.Compare(rhs) != 0;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000DC88 File Offset: 0x0000BE88
		public bool Equals(RelayAllocationId other)
		{
			return this.Compare(other) == 0;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000DC94 File Offset: 0x0000BE94
		public int CompareTo(RelayAllocationId other)
		{
			return this.Compare(other);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000DC9D File Offset: 0x0000BE9D
		public override bool Equals(object other)
		{
			return other != null && this == (RelayAllocationId)other;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000DCB8 File Offset: 0x0000BEB8
		public unsafe override int GetHashCode()
		{
			fixed (byte* ptr = &this.Value.FixedElementField)
			{
				byte* ptr2 = ptr;
				int num = 0;
				for (int i = 0; i < 16; i++)
				{
					num = (num * 31 ^ (int)ptr2[i]);
				}
				return num;
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000DCF0 File Offset: 0x0000BEF0
		private unsafe int Compare(RelayAllocationId other)
		{
			fixed (byte* ptr = &this.Value.FixedElementField)
			{
				void* ptr2 = (void*)ptr;
				return UnsafeUtility.MemCmp(ptr2, (void*)(&other.Value.FixedElementField), 16L);
			}
		}

		// Token: 0x040001F0 RID: 496
		public const int k_Length = 16;

		// Token: 0x040001F1 RID: 497
		[FixedBuffer(typeof(byte), 16)]
		public RelayAllocationId.<Value>e__FixedBuffer Value;

		// Token: 0x02000094 RID: 148
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct <Value>e__FixedBuffer
		{
			// Token: 0x040001F2 RID: 498
			public byte FixedElementField;
		}
	}
}
