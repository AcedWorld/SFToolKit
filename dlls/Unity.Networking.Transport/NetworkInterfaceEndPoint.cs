using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Networking.Transport.Utilities;

namespace Unity.Networking.Transport
{
	// Token: 0x0200003A RID: 58
	public struct NetworkInterfaceEndPoint : IEquatable<NetworkInterfaceEndPoint>
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00007F9B File Offset: 0x0000619B
		public bool IsValid
		{
			get
			{
				return this.dataLength != 0;
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00007FA6 File Offset: 0x000061A6
		public static bool operator ==(NetworkInterfaceEndPoint lhs, NetworkInterfaceEndPoint rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00007FB0 File Offset: 0x000061B0
		public static bool operator !=(NetworkInterfaceEndPoint lhs, NetworkInterfaceEndPoint rhs)
		{
			return !lhs.Equals(rhs);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00007FBD File Offset: 0x000061BD
		public override bool Equals(object other)
		{
			return this.Equals((NetworkInterfaceEndPoint)other);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00007FCC File Offset: 0x000061CC
		public unsafe override int GetHashCode()
		{
			fixed (byte* ptr = &this.data.FixedElementField)
			{
				byte* ptr2 = ptr;
				int num = 0;
				for (int i = 0; i < this.dataLength; i++)
				{
					num = (num * 31 ^ (int)ptr2[i]);
				}
				return num;
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00008008 File Offset: 0x00006208
		public unsafe bool Equals(NetworkInterfaceEndPoint other)
		{
			if (this.dataLength != other.dataLength && (this.dataLength <= 0 || other.dataLength <= 0))
			{
				return false;
			}
			fixed (byte* ptr = &this.data.FixedElementField)
			{
				void* ptr2 = (void*)ptr;
				return UnsafeUtility.MemCmp(ptr2, (void*)(&other.data.FixedElementField), (long)math.min(this.dataLength, other.dataLength)) == 0;
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00008070 File Offset: 0x00006270
		public unsafe FixedString64Bytes ToFixedString()
		{
			if (!this.IsValid)
			{
				return "Not Valid";
			}
			int num = this.dataLength;
			FixedString64Bytes result = default(FixedString64Bytes);
			if (num == 4)
			{
				ref result.Append((int)this.data.FixedElementField);
				ref result.Append('.');
				ref result.Append((int)(*(ref this.data.FixedElementField + 1)));
				ref result.Append('.');
				ref result.Append((int)(*(ref this.data.FixedElementField + 2)));
				ref result.Append('.');
				ref result.Append((int)(*(ref this.data.FixedElementField + 3)));
				return result;
			}
			FixedString32Bytes fixedString32Bytes = "0x";
			ref result.Append(fixedString32Bytes);
			fixed (byte* ptr = &this.data.FixedElementField)
			{
				byte* ptr2 = ptr;
				for (int i = 0; i < num; i += 2)
				{
					ushort* ptr3 = (ushort*)(ptr2 + i);
					ref result.AppendHex(*ptr3);
				}
			}
			return result;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00008168 File Offset: 0x00006368
		public override string ToString()
		{
			return this.ToFixedString().ToString();
		}

		// Token: 0x040000C8 RID: 200
		public const int k_MaxLength = 56;

		// Token: 0x040000C9 RID: 201
		public int dataLength;

		// Token: 0x040000CA RID: 202
		[FixedBuffer(typeof(byte), 56)]
		public NetworkInterfaceEndPoint.<data>e__FixedBuffer data;

		// Token: 0x0200003B RID: 59
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 56)]
		public struct <data>e__FixedBuffer
		{
			// Token: 0x040000CB RID: 203
			public byte FixedElementField;
		}
	}
}
