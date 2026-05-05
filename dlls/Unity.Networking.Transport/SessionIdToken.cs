using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport
{
	// Token: 0x02000077 RID: 119
	[StructLayout(LayoutKind.Explicit)]
	internal struct SessionIdToken : IEquatable<SessionIdToken>, IComparable<SessionIdToken>
	{
		// Token: 0x06000212 RID: 530 RVA: 0x0000B6D3 File Offset: 0x000098D3
		public static bool operator ==(SessionIdToken lhs, SessionIdToken rhs)
		{
			return lhs.Compare(rhs) == 0;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000B6E0 File Offset: 0x000098E0
		public static bool operator !=(SessionIdToken lhs, SessionIdToken rhs)
		{
			return lhs.Compare(rhs) != 0;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000B6ED File Offset: 0x000098ED
		public bool Equals(SessionIdToken other)
		{
			return this.Compare(other) == 0;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000B6F9 File Offset: 0x000098F9
		public int CompareTo(SessionIdToken other)
		{
			return this.Compare(other);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000B702 File Offset: 0x00009902
		public override bool Equals(object other)
		{
			return other != null && this == (SessionIdToken)other;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000B71C File Offset: 0x0000991C
		public unsafe override int GetHashCode()
		{
			fixed (byte* ptr = &this.Value.FixedElementField)
			{
				byte* ptr2 = ptr;
				int num = 0;
				for (int i = 0; i < 8; i++)
				{
					num = (num * 31 ^ (int)ptr2[i]);
				}
				return num;
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000B754 File Offset: 0x00009954
		private unsafe int Compare(SessionIdToken other)
		{
			fixed (byte* ptr = &this.Value.FixedElementField)
			{
				void* ptr2 = (void*)ptr;
				return UnsafeUtility.MemCmp(ptr2, (void*)(&other.Value.FixedElementField), 8L);
			}
		}

		// Token: 0x0400018D RID: 397
		public const int k_Length = 8;

		// Token: 0x0400018E RID: 398
		[FixedBuffer(typeof(byte), 8)]
		[FieldOffset(0)]
		public SessionIdToken.<Value>e__FixedBuffer Value;

		// Token: 0x02000078 RID: 120
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 8)]
		public struct <Value>e__FixedBuffer
		{
			// Token: 0x0400018F RID: 399
			public byte FixedElementField;
		}
	}
}
