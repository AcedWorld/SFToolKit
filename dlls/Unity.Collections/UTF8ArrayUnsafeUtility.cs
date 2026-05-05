using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x020000CE RID: 206
	[BurstCompatible]
	public static class UTF8ArrayUnsafeUtility
	{
		// Token: 0x0600083D RID: 2109 RVA: 0x00019D38 File Offset: 0x00017F38
		public unsafe static CopyError Copy(byte* dest, out int destLength, int destUTF8MaxLengthInBytes, char* src, int srcLength)
		{
			if (Unicode.Utf16ToUtf8(src, srcLength, dest, out destLength, destUTF8MaxLengthInBytes) == ConversionError.None)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x00019D4C File Offset: 0x00017F4C
		public unsafe static CopyError Copy(byte* dest, out ushort destLength, ushort destUTF8MaxLengthInBytes, char* src, int srcLength)
		{
			int num;
			bool flag = Unicode.Utf16ToUtf8(src, srcLength, dest, out num, (int)destUTF8MaxLengthInBytes) != ConversionError.None;
			destLength = (ushort)num;
			if (!flag)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00019D70 File Offset: 0x00017F70
		public unsafe static CopyError Copy(byte* dest, out int destLength, int destUTF8MaxLengthInBytes, byte* src, int srcLength)
		{
			int num;
			bool flag = Unicode.Utf8ToUtf8(src, srcLength, dest, out num, destUTF8MaxLengthInBytes) != ConversionError.None;
			destLength = num;
			if (!flag)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00019D94 File Offset: 0x00017F94
		public unsafe static CopyError Copy(byte* dest, out ushort destLength, ushort destUTF8MaxLengthInBytes, byte* src, ushort srcLength)
		{
			int num;
			bool flag = Unicode.Utf8ToUtf8(src, (int)srcLength, dest, out num, (int)destUTF8MaxLengthInBytes) != ConversionError.None;
			destLength = (ushort)num;
			if (!flag)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00019DB6 File Offset: 0x00017FB6
		public unsafe static CopyError Copy(char* dest, out int destLength, int destUCS2MaxLengthInChars, byte* src, int srcLength)
		{
			if (Unicode.Utf8ToUtf16(src, srcLength, dest, out destLength, destUCS2MaxLengthInChars) == ConversionError.None)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00019DC8 File Offset: 0x00017FC8
		public unsafe static CopyError Copy(char* dest, out ushort destLength, ushort destUCS2MaxLengthInChars, byte* src, ushort srcLength)
		{
			int num;
			bool flag = Unicode.Utf8ToUtf16(src, (int)srcLength, dest, out num, (int)destUCS2MaxLengthInChars) != ConversionError.None;
			destLength = (ushort)num;
			if (!flag)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00019DEA File Offset: 0x00017FEA
		public unsafe static FormatError AppendUTF8Bytes(byte* dest, ref int destLength, int destCapacity, byte* src, int srcLength)
		{
			if (destLength + srcLength > destCapacity)
			{
				return FormatError.Overflow;
			}
			UnsafeUtility.MemCpy((void*)(dest + destLength), (void*)src, (long)srcLength);
			destLength += srcLength;
			return FormatError.None;
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00019E0C File Offset: 0x0001800C
		public unsafe static CopyError Append(byte* dest, ref ushort destLength, ushort destUTF8MaxLengthInBytes, byte* src, ushort srcLength)
		{
			int num;
			bool flag = Unicode.Utf8ToUtf8(src, (int)srcLength, dest + destLength, out num, (int)(destUTF8MaxLengthInBytes - destLength)) != ConversionError.None;
			destLength += (ushort)num;
			if (!flag)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00019E38 File Offset: 0x00018038
		public unsafe static CopyError Append(byte* dest, ref ushort destLength, ushort destUTF8MaxLengthInBytes, char* src, int srcLength)
		{
			int num;
			bool flag = Unicode.Utf16ToUtf8(src, srcLength, dest + destLength, out num, (int)(destUTF8MaxLengthInBytes - destLength)) != ConversionError.None;
			destLength += (ushort)num;
			if (!flag)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00019E64 File Offset: 0x00018064
		public unsafe static CopyError Append(char* dest, ref ushort destLength, ushort destUCS2MaxLengthInChars, byte* src, ushort srcLength)
		{
			int num;
			bool flag = Unicode.Utf8ToUtf16(src, (int)srcLength, dest + destLength, out num, (int)(destUCS2MaxLengthInChars - destLength)) != ConversionError.None;
			destLength += (ushort)num;
			if (!flag)
			{
				return CopyError.None;
			}
			return CopyError.Truncation;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00019E94 File Offset: 0x00018094
		public unsafe static int StrCmp(byte* utf8BufferA, int utf8LengthInBytesA, byte* utf8BufferB, int utf8LengthInBytesB)
		{
			int num = 0;
			int num2 = 0;
			UTF8ArrayUnsafeUtility.Comparison comparison;
			do
			{
				Unicode.Rune runeA;
				ConversionError errorA = Unicode.Utf8ToUcs(out runeA, utf8BufferA, ref num, utf8LengthInBytesA);
				Unicode.Rune runeB;
				ConversionError errorB = Unicode.Utf8ToUcs(out runeB, utf8BufferB, ref num2, utf8LengthInBytesB);
				comparison = new UTF8ArrayUnsafeUtility.Comparison(runeA, errorA, runeB, errorB);
			}
			while (!comparison.terminates);
			return comparison.result;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00019EDC File Offset: 0x000180DC
		public unsafe static int StrCmp(char* utf16BufferA, int utf16LengthInCharsA, char* utf16BufferB, int utf16LengthInCharsB)
		{
			int num = 0;
			int num2 = 0;
			UTF8ArrayUnsafeUtility.Comparison comparison;
			do
			{
				Unicode.Rune runeA;
				ConversionError errorA = Unicode.Utf16ToUcs(out runeA, utf16BufferA, ref num, utf16LengthInCharsA);
				Unicode.Rune runeB;
				ConversionError errorB = Unicode.Utf16ToUcs(out runeB, utf16BufferB, ref num2, utf16LengthInCharsB);
				comparison = new UTF8ArrayUnsafeUtility.Comparison(runeA, errorA, runeB, errorB);
			}
			while (!comparison.terminates);
			return comparison.result;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00019F23 File Offset: 0x00018123
		public unsafe static bool EqualsUTF8Bytes(byte* aBytes, int aLength, byte* bBytes, int bLength)
		{
			return UTF8ArrayUnsafeUtility.StrCmp(aBytes, aLength, bBytes, bLength) == 0;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00019F34 File Offset: 0x00018134
		public unsafe static int StrCmp(byte* utf8Buffer, int utf8LengthInBytes, char* utf16Buffer, int utf16LengthInChars)
		{
			int num = 0;
			int num2 = 0;
			UTF8ArrayUnsafeUtility.Comparison comparison;
			do
			{
				Unicode.Rune runeA;
				ConversionError errorA = Unicode.Utf8ToUcs(out runeA, utf8Buffer, ref num, utf8LengthInBytes);
				Unicode.Rune runeB;
				ConversionError errorB = Unicode.Utf16ToUcs(out runeB, utf16Buffer, ref num2, utf16LengthInChars);
				comparison = new UTF8ArrayUnsafeUtility.Comparison(runeA, errorA, runeB, errorB);
			}
			while (!comparison.terminates);
			return comparison.result;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00019F7B File Offset: 0x0001817B
		public unsafe static int StrCmp(char* utf16Buffer, int utf16LengthInChars, byte* utf8Buffer, int utf8LengthInBytes)
		{
			return -UTF8ArrayUnsafeUtility.StrCmp(utf8Buffer, utf8LengthInBytes, utf16Buffer, utf16LengthInChars);
		}

		// Token: 0x020000CF RID: 207
		internal struct Comparison
		{
			// Token: 0x0600084C RID: 2124 RVA: 0x00019F88 File Offset: 0x00018188
			public Comparison(Unicode.Rune runeA, ConversionError errorA, Unicode.Rune runeB, ConversionError errorB)
			{
				if (errorA != ConversionError.None)
				{
					runeA.value = 0;
				}
				if (errorB != ConversionError.None)
				{
					runeB.value = 0;
				}
				if (runeA.value != runeB.value)
				{
					this.result = runeA.value - runeB.value;
					this.terminates = true;
					return;
				}
				this.result = 0;
				this.terminates = (runeA.value == 0 && runeB.value == 0);
			}

			// Token: 0x040002E6 RID: 742
			public bool terminates;

			// Token: 0x040002E7 RID: 743
			public int result;
		}
	}
}
