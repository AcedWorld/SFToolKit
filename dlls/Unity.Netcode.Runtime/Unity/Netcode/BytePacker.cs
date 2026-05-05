using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000FD RID: 253
	public static class BytePacker
	{
		// Token: 0x06000712 RID: 1810 RVA: 0x0001D4E0 File Offset: 0x0001B6E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static void WriteValuePacked<[IsUnmanaged] TEnum>(FastBufferWriter writer, TEnum value) where TEnum : struct, ValueType, Enum
		{
			TEnum tenum = value;
			int num = sizeof(TEnum);
			switch (num)
			{
			case 1:
				BytePacker.WriteValuePacked(writer, *(byte*)(&tenum));
				return;
			case 2:
				BytePacker.WriteValuePacked(writer, *(short*)(&tenum));
				return;
			case 3:
				break;
			case 4:
				BytePacker.WriteValuePacked(writer, *(int*)(&tenum));
				return;
			default:
				if (num != 8)
				{
					return;
				}
				BytePacker.WriteValuePacked(writer, *(long*)(&tenum));
				break;
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x0001D53E File Offset: 0x0001B73E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, float value)
		{
			BytePacker.WriteValueBitPacked(writer, BytePacker.ToUint<float>(value));
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0001D54C File Offset: 0x0001B74C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, double value)
		{
			BytePacker.WriteValueBitPacked(writer, BytePacker.ToUlong<double>(value));
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0001D55A File Offset: 0x0001B75A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, byte value)
		{
			writer.WriteByteSafe(value);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0001D564 File Offset: 0x0001B764
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, sbyte value)
		{
			writer.WriteByteSafe((byte)value);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0001D570 File Offset: 0x0001B770
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, bool value)
		{
			writer.WriteValueSafe<bool>(value, default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0001D58F File Offset: 0x0001B78F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, short value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0001D598 File Offset: 0x0001B798
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, ushort value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0001D598 File Offset: 0x0001B798
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, char c)
		{
			BytePacker.WriteValueBitPacked(writer, (ushort)c);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0001D5A1 File Offset: 0x0001B7A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, int value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0001D5AA File Offset: 0x0001B7AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, uint value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x0001D5B3 File Offset: 0x0001B7B3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, ulong value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x0001D5BC File Offset: 0x0001B7BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, long value)
		{
			BytePacker.WriteValueBitPacked(writer, value);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0001D5C5 File Offset: 0x0001B7C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, Ray ray)
		{
			BytePacker.WriteValuePacked(writer, ray.origin);
			BytePacker.WriteValuePacked(writer, ray.direction);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0001D5E1 File Offset: 0x0001B7E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, Ray2D ray2d)
		{
			BytePacker.WriteValuePacked(writer, ray2d.origin);
			BytePacker.WriteValuePacked(writer, ray2d.direction);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0001D5FD File Offset: 0x0001B7FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, Color color)
		{
			BytePacker.WriteValuePacked(writer, color.r);
			BytePacker.WriteValuePacked(writer, color.g);
			BytePacker.WriteValuePacked(writer, color.b);
			BytePacker.WriteValuePacked(writer, color.a);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0001D62F File Offset: 0x0001B82F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, Color32 color)
		{
			BytePacker.WriteValuePacked(writer, color.r);
			BytePacker.WriteValuePacked(writer, color.g);
			BytePacker.WriteValuePacked(writer, color.b);
			BytePacker.WriteValuePacked(writer, color.a);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0001D661 File Offset: 0x0001B861
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, Vector2 vector2)
		{
			BytePacker.WriteValuePacked(writer, vector2.x);
			BytePacker.WriteValuePacked(writer, vector2.y);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0001D67B File Offset: 0x0001B87B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, Vector3 vector3)
		{
			BytePacker.WriteValuePacked(writer, vector3.x);
			BytePacker.WriteValuePacked(writer, vector3.y);
			BytePacker.WriteValuePacked(writer, vector3.z);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0001D6A1 File Offset: 0x0001B8A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, Vector4 vector4)
		{
			BytePacker.WriteValuePacked(writer, vector4.x);
			BytePacker.WriteValuePacked(writer, vector4.y);
			BytePacker.WriteValuePacked(writer, vector4.z);
			BytePacker.WriteValuePacked(writer, vector4.w);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0001D6D3 File Offset: 0x0001B8D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, Quaternion rotation)
		{
			BytePacker.WriteValuePacked(writer, rotation.x);
			BytePacker.WriteValuePacked(writer, rotation.y);
			BytePacker.WriteValuePacked(writer, rotation.z);
			BytePacker.WriteValuePacked(writer, rotation.w);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0001D708 File Offset: 0x0001B908
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteValuePacked(FastBufferWriter writer, string s)
		{
			BytePacker.WriteValuePacked(writer, (uint)s.Length);
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				BytePacker.WriteValuePacked(writer, s[i]);
			}
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x0001D741 File Offset: 0x0001B941
		public static void WriteValueBitPacked(FastBufferWriter writer, short value)
		{
			BytePacker.WriteValueBitPacked(writer, (ushort)Arithmetic.ZigZagEncode((long)value));
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0001D754 File Offset: 0x0001B954
		public static void WriteValueBitPacked(FastBufferWriter writer, ushort value)
		{
			if (value > 16383)
			{
				if (!writer.TryBeginWriteInternal(3))
				{
					throw new OverflowException("Writing past the end of the buffer");
				}
				writer.WriteByte(3);
				writer.WriteValue<ushort>(value, default(FastBufferWriter.ForPrimitives));
				return;
			}
			else
			{
				value = (ushort)(value << 2);
				int usedByteCount = BitCounter.GetUsedByteCount((uint)value);
				if (!writer.TryBeginWriteInternal(usedByteCount))
				{
					throw new OverflowException("Writing past the end of the buffer");
				}
				writer.WritePartialValue<int>((int)(value | (ushort)usedByteCount), usedByteCount, 0);
				return;
			}
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0001D7C8 File Offset: 0x0001B9C8
		public static void WriteValueBitPacked(FastBufferWriter writer, int value)
		{
			BytePacker.WriteValueBitPacked(writer, (uint)Arithmetic.ZigZagEncode((long)value));
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0001D7D8 File Offset: 0x0001B9D8
		public static void WriteValueBitPacked(FastBufferWriter writer, uint value)
		{
			if (value > 536870911U)
			{
				if (!writer.TryBeginWriteInternal(5))
				{
					throw new OverflowException("Writing past the end of the buffer");
				}
				writer.WriteByte(5);
				writer.WriteValue<uint>(value, default(FastBufferWriter.ForPrimitives));
				return;
			}
			else
			{
				value <<= 3;
				int usedByteCount = BitCounter.GetUsedByteCount(value);
				if (!writer.TryBeginWriteInternal(usedByteCount))
				{
					throw new OverflowException("Writing past the end of the buffer");
				}
				writer.WritePartialValue<uint>(value | (uint)usedByteCount, usedByteCount, 0);
				return;
			}
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0001D84A File Offset: 0x0001BA4A
		public static void WriteValueBitPacked(FastBufferWriter writer, long value)
		{
			BytePacker.WriteValueBitPacked(writer, Arithmetic.ZigZagEncode(value));
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0001D858 File Offset: 0x0001BA58
		public static void WriteValueBitPacked(FastBufferWriter writer, ulong value)
		{
			if (value > 1152921504606846975UL)
			{
				if (!writer.TryBeginWriteInternal(9))
				{
					throw new OverflowException("Writing past the end of the buffer");
				}
				writer.WriteByte(9);
				writer.WriteValue<ulong>(value, default(FastBufferWriter.ForPrimitives));
				return;
			}
			else
			{
				value <<= 4;
				int usedByteCount = BitCounter.GetUsedByteCount(value);
				if (!writer.TryBeginWriteInternal(usedByteCount))
				{
					throw new OverflowException("Writing past the end of the buffer");
				}
				writer.WritePartialValue<ulong>(value | (ulong)usedByteCount, usedByteCount, 0);
				return;
			}
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0001D8D4 File Offset: 0x0001BAD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static uint ToUint<[IsUnmanaged] T>(T value) where T : struct, ValueType
		{
			uint* ptr = (uint*)(&value);
			return *ptr;
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x0001D8E8 File Offset: 0x0001BAE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe static ulong ToUlong<[IsUnmanaged] T>(T value) where T : struct, ValueType
		{
			ulong* ptr = (ulong*)(&value);
			return *ptr;
		}

		// Token: 0x04000310 RID: 784
		public const ushort BitPackedUshortMax = 32767;

		// Token: 0x04000311 RID: 785
		public const short BitPackedShortMax = 16383;

		// Token: 0x04000312 RID: 786
		public const short BitPackedShortMin = -16384;

		// Token: 0x04000313 RID: 787
		public const uint BitPackedUintMax = 1073741823U;

		// Token: 0x04000314 RID: 788
		public const int BitPackedIntMax = 536870911;

		// Token: 0x04000315 RID: 789
		public const int BitPackedIntMin = -536870912;

		// Token: 0x04000316 RID: 790
		public const ulong BitPackedULongMax = 2305843009213693951UL;

		// Token: 0x04000317 RID: 791
		public const long BitPackedLongMax = 1152921504606846975L;

		// Token: 0x04000318 RID: 792
		public const long BitPackedLongMin = -1152921504606846976L;
	}
}
