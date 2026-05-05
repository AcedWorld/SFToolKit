using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000FE RID: 254
	public static class ByteUnpacker
	{
		// Token: 0x06000730 RID: 1840 RVA: 0x0001D8FC File Offset: 0x0001BAFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void ReadValuePacked<[IsUnmanaged] TEnum>(FastBufferReader reader, out TEnum value) where TEnum : struct, ValueType, Enum
		{
			int num = sizeof(TEnum);
			switch (num)
			{
			case 1:
			{
				byte b;
				ByteUnpacker.ReadValuePacked(reader, out b);
				value = *(TEnum*)(&b);
				return;
			}
			case 2:
			{
				short num2;
				ByteUnpacker.ReadValuePacked(reader, out num2);
				value = *(TEnum*)(&num2);
				return;
			}
			case 3:
				break;
			case 4:
			{
				int num3;
				ByteUnpacker.ReadValuePacked(reader, out num3);
				value = *(TEnum*)(&num3);
				return;
			}
			default:
				if (num == 8)
				{
					long num4;
					ByteUnpacker.ReadValuePacked(reader, out num4);
					value = *(TEnum*)(&num4);
					return;
				}
				break;
			}
			throw new InvalidOperationException("Enum is a size that cannot exist?!");
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0001D998 File Offset: 0x0001BB98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out float value)
		{
			uint value2;
			ByteUnpacker.ReadValueBitPacked(reader, out value2);
			value = ByteUnpacker.ToSingle<uint>(value2);
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0001D9B8 File Offset: 0x0001BBB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out double value)
		{
			ulong value2;
			ByteUnpacker.ReadValueBitPacked(reader, out value2);
			value = ByteUnpacker.ToDouble<ulong>(value2);
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0001D9D5 File Offset: 0x0001BBD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out byte value)
		{
			reader.ReadByteSafe(out value);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x0001D9E0 File Offset: 0x0001BBE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out sbyte value)
		{
			byte b;
			reader.ReadByteSafe(out b);
			value = (sbyte)b;
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0001D9FC File Offset: 0x0001BBFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out bool value)
		{
			reader.ReadValueSafe<bool>(out value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0001DA1A File Offset: 0x0001BC1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out short value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0001DA23 File Offset: 0x0001BC23
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out ushort value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0001DA2C File Offset: 0x0001BC2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out char c)
		{
			ushort num;
			ByteUnpacker.ReadValueBitPacked(reader, out num);
			c = (char)num;
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x0001DA44 File Offset: 0x0001BC44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out int value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0001DA4D File Offset: 0x0001BC4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out uint value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0001DA56 File Offset: 0x0001BC56
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out ulong value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0001DA5F File Offset: 0x0001BC5F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out long value)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out value);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0001DA68 File Offset: 0x0001BC68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out Ray ray)
		{
			Vector3 origin;
			ByteUnpacker.ReadValuePacked(reader, out origin);
			Vector3 direction;
			ByteUnpacker.ReadValuePacked(reader, out direction);
			ray = new Ray(origin, direction);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0001DA94 File Offset: 0x0001BC94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out Ray2D ray2d)
		{
			Vector2 origin;
			ByteUnpacker.ReadValuePacked(reader, out origin);
			Vector2 direction;
			ByteUnpacker.ReadValuePacked(reader, out direction);
			ray2d = new Ray2D(origin, direction);
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0001DABE File Offset: 0x0001BCBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out Color color)
		{
			color = default(Color);
			ByteUnpacker.ReadValuePacked(reader, out color.r);
			ByteUnpacker.ReadValuePacked(reader, out color.g);
			ByteUnpacker.ReadValuePacked(reader, out color.b);
			ByteUnpacker.ReadValuePacked(reader, out color.a);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0001DAF7 File Offset: 0x0001BCF7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out Color32 color)
		{
			color = default(Color32);
			ByteUnpacker.ReadValuePacked(reader, out color.r);
			ByteUnpacker.ReadValuePacked(reader, out color.g);
			ByteUnpacker.ReadValuePacked(reader, out color.b);
			ByteUnpacker.ReadValuePacked(reader, out color.a);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0001DB30 File Offset: 0x0001BD30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out Vector2 vector2)
		{
			vector2 = default(Vector2);
			ByteUnpacker.ReadValuePacked(reader, out vector2.x);
			ByteUnpacker.ReadValuePacked(reader, out vector2.y);
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0001DB51 File Offset: 0x0001BD51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out Vector3 vector3)
		{
			vector3 = default(Vector3);
			ByteUnpacker.ReadValuePacked(reader, out vector3.x);
			ByteUnpacker.ReadValuePacked(reader, out vector3.y);
			ByteUnpacker.ReadValuePacked(reader, out vector3.z);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0001DB7E File Offset: 0x0001BD7E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out Vector4 vector4)
		{
			vector4 = default(Vector4);
			ByteUnpacker.ReadValuePacked(reader, out vector4.x);
			ByteUnpacker.ReadValuePacked(reader, out vector4.y);
			ByteUnpacker.ReadValuePacked(reader, out vector4.z);
			ByteUnpacker.ReadValuePacked(reader, out vector4.w);
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x0001DBB7 File Offset: 0x0001BDB7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ReadValuePacked(FastBufferReader reader, out Quaternion rotation)
		{
			rotation = default(Quaternion);
			ByteUnpacker.ReadValuePacked(reader, out rotation.x);
			ByteUnpacker.ReadValuePacked(reader, out rotation.y);
			ByteUnpacker.ReadValuePacked(reader, out rotation.z);
			ByteUnpacker.ReadValuePacked(reader, out rotation.w);
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0001DBF0 File Offset: 0x0001BDF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void ReadValuePacked(FastBufferReader reader, out string s)
		{
			uint totalWidth;
			ByteUnpacker.ReadValuePacked(reader, out totalWidth);
			s = "".PadRight((int)totalWidth);
			int length = s.Length;
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				for (int i = 0; i < length; i++)
				{
					ByteUnpacker.ReadValuePacked(reader, out ptr[i]);
				}
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0001DC4C File Offset: 0x0001BE4C
		public static void ReadValueBitPacked(FastBufferReader reader, out short value)
		{
			ushort num;
			ByteUnpacker.ReadValueBitPacked(reader, out num);
			value = (short)Arithmetic.ZigZagDecode((ulong)num);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0001DC6C File Offset: 0x0001BE6C
		public unsafe static void ReadValueBitPacked(FastBufferReader reader, out ushort value)
		{
			ushort num = 0;
			byte* ptr = (byte*)(&num);
			byte* unsafePtrAtCurrentPosition = reader.GetUnsafePtrAtCurrentPosition();
			int num2 = (int)(*unsafePtrAtCurrentPosition & 3);
			if (!reader.TryBeginReadInternal(num2))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			reader.MarkBytesRead(num2);
			switch (num2)
			{
			case 1:
				*ptr = *unsafePtrAtCurrentPosition;
				break;
			case 2:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				break;
			case 3:
				*ptr = unsafePtrAtCurrentPosition[1];
				ptr[1] = unsafePtrAtCurrentPosition[2];
				value = num;
				return;
			default:
				throw new InvalidOperationException("Could not read bit-packed value: impossible byte count");
			}
			value = (ushort)(num >> 2);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x0001DCF8 File Offset: 0x0001BEF8
		public static void ReadValueBitPacked(FastBufferReader reader, out int value)
		{
			uint num;
			ByteUnpacker.ReadValueBitPacked(reader, out num);
			value = (int)Arithmetic.ZigZagDecode((ulong)num);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0001DD18 File Offset: 0x0001BF18
		public unsafe static void ReadValueBitPacked(FastBufferReader reader, out uint value)
		{
			uint num = 0U;
			byte* ptr = (byte*)(&num);
			byte* unsafePtrAtCurrentPosition = reader.GetUnsafePtrAtCurrentPosition();
			int num2 = (int)(*unsafePtrAtCurrentPosition & 7);
			if (!reader.TryBeginReadInternal(num2))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			reader.MarkBytesRead(num2);
			switch (num2)
			{
			case 1:
				*ptr = *unsafePtrAtCurrentPosition;
				break;
			case 2:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				break;
			case 3:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				ptr[2] = unsafePtrAtCurrentPosition[2];
				break;
			case 4:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				ptr[2] = unsafePtrAtCurrentPosition[2];
				ptr[3] = unsafePtrAtCurrentPosition[3];
				break;
			case 5:
				*ptr = unsafePtrAtCurrentPosition[1];
				ptr[1] = unsafePtrAtCurrentPosition[2];
				ptr[2] = unsafePtrAtCurrentPosition[3];
				ptr[3] = unsafePtrAtCurrentPosition[4];
				value = num;
				return;
			}
			value = num >> 3;
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0001DDE4 File Offset: 0x0001BFE4
		public static void ReadValueBitPacked(FastBufferReader reader, out long value)
		{
			ulong value2;
			ByteUnpacker.ReadValueBitPacked(reader, out value2);
			value = Arithmetic.ZigZagDecode(value2);
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0001DE04 File Offset: 0x0001C004
		public unsafe static void ReadValueBitPacked(FastBufferReader reader, out ulong value)
		{
			ulong num = 0UL;
			byte* ptr = (byte*)(&num);
			byte* unsafePtrAtCurrentPosition = reader.GetUnsafePtrAtCurrentPosition();
			int num2 = (int)(*unsafePtrAtCurrentPosition & 15);
			if (!reader.TryBeginReadInternal(num2))
			{
				throw new OverflowException("Reading past the end of the buffer");
			}
			reader.MarkBytesRead(num2);
			switch (num2)
			{
			case 1:
				*ptr = *unsafePtrAtCurrentPosition;
				break;
			case 2:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				break;
			case 3:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				ptr[2] = unsafePtrAtCurrentPosition[2];
				break;
			case 4:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				ptr[2] = unsafePtrAtCurrentPosition[2];
				ptr[3] = unsafePtrAtCurrentPosition[3];
				break;
			case 5:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				ptr[2] = unsafePtrAtCurrentPosition[2];
				ptr[3] = unsafePtrAtCurrentPosition[3];
				ptr[4] = unsafePtrAtCurrentPosition[4];
				break;
			case 6:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				ptr[2] = unsafePtrAtCurrentPosition[2];
				ptr[3] = unsafePtrAtCurrentPosition[3];
				ptr[4] = unsafePtrAtCurrentPosition[4];
				ptr[5] = unsafePtrAtCurrentPosition[5];
				break;
			case 7:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				ptr[2] = unsafePtrAtCurrentPosition[2];
				ptr[3] = unsafePtrAtCurrentPosition[3];
				ptr[4] = unsafePtrAtCurrentPosition[4];
				ptr[5] = unsafePtrAtCurrentPosition[5];
				ptr[6] = unsafePtrAtCurrentPosition[6];
				break;
			case 8:
				*ptr = *unsafePtrAtCurrentPosition;
				ptr[1] = unsafePtrAtCurrentPosition[1];
				ptr[2] = unsafePtrAtCurrentPosition[2];
				ptr[3] = unsafePtrAtCurrentPosition[3];
				ptr[4] = unsafePtrAtCurrentPosition[4];
				ptr[5] = unsafePtrAtCurrentPosition[5];
				ptr[6] = unsafePtrAtCurrentPosition[6];
				ptr[7] = unsafePtrAtCurrentPosition[7];
				break;
			case 9:
				*ptr = unsafePtrAtCurrentPosition[1];
				ptr[1] = unsafePtrAtCurrentPosition[2];
				ptr[2] = unsafePtrAtCurrentPosition[3];
				ptr[3] = unsafePtrAtCurrentPosition[4];
				ptr[4] = unsafePtrAtCurrentPosition[5];
				ptr[5] = unsafePtrAtCurrentPosition[6];
				ptr[6] = unsafePtrAtCurrentPosition[7];
				ptr[7] = unsafePtrAtCurrentPosition[8];
				value = num;
				return;
			}
			value = num >> 4;
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0001DFE0 File Offset: 0x0001C1E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static float ToSingle<[IsUnmanaged] T>(T value) where T : struct, ValueType
		{
			float* ptr = (float*)(&value);
			return *ptr;
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0001DFF4 File Offset: 0x0001C1F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static double ToDouble<[IsUnmanaged] T>(T value) where T : struct, ValueType
		{
			double* ptr = (double*)(&value);
			return *ptr;
		}
	}
}
