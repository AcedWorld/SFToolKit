using System;
using System.Runtime.CompilerServices;

namespace Unity.Netcode
{
	// Token: 0x020000FF RID: 255
	internal class ByteUtility
	{
		// Token: 0x0600074E RID: 1870 RVA: 0x0001E007 File Offset: 0x0001C207
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static byte ToByte(bool b)
		{
			return (*(&b)) ? 1 : 0;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0001E00D File Offset: 0x0001C20D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool GetBit(byte bitField, ushort bitPosition)
		{
			return ((int)bitField & 1 << (int)bitPosition) != 0;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0001E01A File Offset: 0x0001C21A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void SetBit(ref byte bitField, ushort bitPosition, bool value)
		{
			bitField = (byte)(((int)bitField & ~(1 << (int)bitPosition)) | (int)ByteUtility.ToByte(value) << (int)bitPosition);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0001E00D File Offset: 0x0001C20D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool GetBit(ushort bitField, ushort bitPosition)
		{
			return ((int)bitField & 1 << (int)bitPosition) != 0;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0001E035 File Offset: 0x0001C235
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void SetBit(ref ushort bitField, ushort bitPosition, bool value)
		{
			bitField = (ushort)(((int)bitField & ~(1 << (int)bitPosition)) | (int)ByteUtility.ToByte(value) << (int)bitPosition);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0001E050 File Offset: 0x0001C250
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool GetBit(uint bitField, ushort bitPosition)
		{
			return ((ulong)bitField & (ulong)(1L << (int)(bitPosition & 31))) > 0UL;
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0001E060 File Offset: 0x0001C260
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void SetBit(ref uint bitField, ushort bitPosition, bool value)
		{
			bitField = (uint)(((ulong)bitField & (ulong)(~(1L << (int)(bitPosition & 31)))) | (ulong)((ulong)ByteUtility.ToByte(value) << (int)bitPosition));
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0001E07E File Offset: 0x0001C27E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool GetBit(ulong bitField, ushort bitPosition)
		{
			return (bitField & (ulong)(1L << (int)(bitPosition & 31))) > 0UL;
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0001E08D File Offset: 0x0001C28D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void SetBit(ref ulong bitField, ushort bitPosition, bool value)
		{
			bitField = ((bitField & (ulong)(~(1L << (int)(bitPosition & 31)))) | (ulong)ByteUtility.ToByte(value) << (int)bitPosition);
		}
	}
}
