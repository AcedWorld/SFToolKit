using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x020000CC RID: 204
	[BurstCompatible]
	public struct Unicode
	{
		// Token: 0x0600082C RID: 2092 RVA: 0x00019683 File Offset: 0x00017883
		public static bool IsValidCodePoint(int codepoint)
		{
			return codepoint <= 1114111 && codepoint >= 0;
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00019696 File Offset: 0x00017896
		public static bool NotTrailer(byte b)
		{
			return (b & 192) != 128;
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x000196AC File Offset: 0x000178AC
		public static Unicode.Rune ReplacementCharacter
		{
			get
			{
				return new Unicode.Rune
				{
					value = 65533
				};
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x000196D0 File Offset: 0x000178D0
		public static Unicode.Rune BadRune
		{
			get
			{
				return new Unicode.Rune
				{
					value = 0
				};
			}
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x000196F0 File Offset: 0x000178F0
		public unsafe static ConversionError Utf8ToUcs(out Unicode.Rune rune, byte* buffer, ref int index, int capacity)
		{
			rune = Unicode.ReplacementCharacter;
			if (index + 1 > capacity)
			{
				return ConversionError.Overflow;
			}
			if ((buffer[index] & 128) == 0)
			{
				rune.value = (int)buffer[index];
				index++;
				return ConversionError.None;
			}
			if ((buffer[index] & 224) == 192)
			{
				if (index + 2 > capacity)
				{
					index++;
					return ConversionError.Overflow;
				}
				int num = (int)(buffer[index] & 31);
				num = (num << 6 | (int)(buffer[index + 1] & 63));
				if (num < 128 || Unicode.NotTrailer(buffer[index + 1]))
				{
					index++;
					return ConversionError.Encoding;
				}
				rune.value = num;
				index += 2;
				return ConversionError.None;
			}
			else if ((buffer[index] & 240) == 224)
			{
				if (index + 3 > capacity)
				{
					index++;
					return ConversionError.Overflow;
				}
				int num = (int)(buffer[index] & 15);
				num = (num << 6 | (int)(buffer[index + 1] & 63));
				num = (num << 6 | (int)(buffer[index + 2] & 63));
				if (num < 2048 || !Unicode.IsValidCodePoint(num) || Unicode.NotTrailer(buffer[index + 1]) || Unicode.NotTrailer(buffer[index + 2]))
				{
					index++;
					return ConversionError.Encoding;
				}
				rune.value = num;
				index += 3;
				return ConversionError.None;
			}
			else
			{
				if ((buffer[index] & 248) != 240)
				{
					index++;
					return ConversionError.Encoding;
				}
				if (index + 4 > capacity)
				{
					index++;
					return ConversionError.Overflow;
				}
				int num = (int)(buffer[index] & 7);
				num = (num << 6 | (int)(buffer[index + 1] & 63));
				num = (num << 6 | (int)(buffer[index + 2] & 63));
				num = (num << 6 | (int)(buffer[index + 3] & 63));
				if (num < 65536 || !Unicode.IsValidCodePoint(num) || Unicode.NotTrailer(buffer[index + 1]) || Unicode.NotTrailer(buffer[index + 2]) || Unicode.NotTrailer(buffer[index + 3]))
				{
					index++;
					return ConversionError.Encoding;
				}
				rune.value = num;
				index += 4;
				return ConversionError.None;
			}
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x000198D5 File Offset: 0x00017AD5
		private static bool IsLeadingSurrogate(char c)
		{
			return c >= '\ud800' && c <= '\udbff';
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x000198EC File Offset: 0x00017AEC
		private static bool IsTrailingSurrogate(char c)
		{
			return c >= '\udc00' && c <= '\udfff';
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00019904 File Offset: 0x00017B04
		public unsafe static ConversionError Utf16ToUcs(out Unicode.Rune rune, char* buffer, ref int index, int capacity)
		{
			rune = Unicode.ReplacementCharacter;
			if (index + 1 > capacity)
			{
				return ConversionError.Overflow;
			}
			if (!Unicode.IsLeadingSurrogate(buffer[index]) || index + 2 > capacity)
			{
				rune.value = (int)buffer[index];
				index++;
				return ConversionError.None;
			}
			int num = (int)(buffer[index] & 'Ͽ');
			if (!Unicode.IsTrailingSurrogate(buffer[index + 1]))
			{
				rune.value = (int)buffer[index];
				index++;
				return ConversionError.None;
			}
			num = (num << 10 | (int)(buffer[index + 1] & 'Ͽ'));
			num += 65536;
			rune.value = num;
			index += 2;
			return ConversionError.None;
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x000199B8 File Offset: 0x00017BB8
		public unsafe static ConversionError UcsToUtf8(byte* buffer, ref int index, int capacity, Unicode.Rune rune)
		{
			if (!Unicode.IsValidCodePoint(rune.value))
			{
				return ConversionError.CodePoint;
			}
			if (index + 1 > capacity)
			{
				return ConversionError.Overflow;
			}
			if (rune.value <= 127)
			{
				int num = index;
				index = num + 1;
				buffer[num] = (byte)rune.value;
				return ConversionError.None;
			}
			if (rune.value <= 2047)
			{
				if (index + 2 > capacity)
				{
					return ConversionError.Overflow;
				}
				int num = index;
				index = num + 1;
				buffer[num] = (byte)(192 | rune.value >> 6);
				num = index;
				index = num + 1;
				buffer[num] = (byte)(128 | (rune.value & 63));
				return ConversionError.None;
			}
			else if (rune.value <= 65535)
			{
				if (index + 3 > capacity)
				{
					return ConversionError.Overflow;
				}
				int num = index;
				index = num + 1;
				buffer[num] = (byte)(224 | rune.value >> 12);
				num = index;
				index = num + 1;
				buffer[num] = (byte)(128 | (rune.value >> 6 & 63));
				num = index;
				index = num + 1;
				buffer[num] = (byte)(128 | (rune.value & 63));
				return ConversionError.None;
			}
			else
			{
				if (rune.value > 2097151)
				{
					return ConversionError.Encoding;
				}
				if (index + 4 > capacity)
				{
					return ConversionError.Overflow;
				}
				int num = index;
				index = num + 1;
				buffer[num] = (byte)(240 | rune.value >> 18);
				num = index;
				index = num + 1;
				buffer[num] = (byte)(128 | (rune.value >> 12 & 63));
				num = index;
				index = num + 1;
				buffer[num] = (byte)(128 | (rune.value >> 6 & 63));
				num = index;
				index = num + 1;
				buffer[num] = (byte)(128 | (rune.value & 63));
				return ConversionError.None;
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00019B4C File Offset: 0x00017D4C
		public unsafe static ConversionError UcsToUtf16(char* buffer, ref int index, int capacity, Unicode.Rune rune)
		{
			if (!Unicode.IsValidCodePoint(rune.value))
			{
				return ConversionError.CodePoint;
			}
			if (index + 1 > capacity)
			{
				return ConversionError.Overflow;
			}
			int num;
			if (rune.value < 65536)
			{
				num = index;
				index = num + 1;
				buffer[num] = (char)rune.value;
				return ConversionError.None;
			}
			if (index + 2 > capacity)
			{
				return ConversionError.Overflow;
			}
			int num2 = rune.value - 65536;
			if (num2 >= 1048576)
			{
				return ConversionError.Encoding;
			}
			num = index;
			index = num + 1;
			buffer[num] = (char)(55296 | num2 >> 10);
			num = index;
			index = num + 1;
			buffer[num] = (char)(56320 | (num2 & 1023));
			return ConversionError.None;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00019BF0 File Offset: 0x00017DF0
		public unsafe static ConversionError Utf16ToUtf8(char* utf16Buffer, int utf16Length, byte* utf8Buffer, out int utf8Length, int utf8Capacity)
		{
			utf8Length = 0;
			int i = 0;
			while (i < utf16Length)
			{
				Unicode.Rune rune;
				Unicode.Utf16ToUcs(out rune, utf16Buffer, ref i, utf16Length);
				if (Unicode.UcsToUtf8(utf8Buffer, ref utf8Length, utf8Capacity, rune) == ConversionError.Overflow)
				{
					return ConversionError.Overflow;
				}
			}
			return ConversionError.None;
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x00019C24 File Offset: 0x00017E24
		public unsafe static ConversionError Utf8ToUtf8(byte* srcBuffer, int srcLength, byte* destBuffer, out int destLength, int destCapacity)
		{
			if (destCapacity >= srcLength)
			{
				UnsafeUtility.MemCpy((void*)destBuffer, (void*)srcBuffer, (long)srcLength);
				destLength = srcLength;
				return ConversionError.None;
			}
			destLength = 0;
			int i = 0;
			while (i < srcLength)
			{
				Unicode.Rune rune;
				Unicode.Utf8ToUcs(out rune, srcBuffer, ref i, srcLength);
				if (Unicode.UcsToUtf8(destBuffer, ref destLength, destCapacity, rune) == ConversionError.Overflow)
				{
					return ConversionError.Overflow;
				}
			}
			return ConversionError.None;
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00019C6C File Offset: 0x00017E6C
		public unsafe static ConversionError Utf8ToUtf16(byte* utf8Buffer, int utf8Length, char* utf16Buffer, out int utf16Length, int utf16Capacity)
		{
			utf16Length = 0;
			int i = 0;
			while (i < utf8Length)
			{
				Unicode.Rune rune;
				Unicode.Utf8ToUcs(out rune, utf8Buffer, ref i, utf8Length);
				if (Unicode.UcsToUtf16(utf16Buffer, ref utf16Length, utf16Capacity, rune) == ConversionError.Overflow)
				{
					return ConversionError.Overflow;
				}
			}
			return ConversionError.None;
		}

		// Token: 0x040002E4 RID: 740
		public const int kMaximumValidCodePoint = 1114111;

		// Token: 0x020000CD RID: 205
		[BurstCompatible]
		public struct Rune
		{
			// Token: 0x06000839 RID: 2105 RVA: 0x00019CA0 File Offset: 0x00017EA0
			public Rune(int codepoint)
			{
				this.value = codepoint;
			}

			// Token: 0x0600083A RID: 2106 RVA: 0x00019CAC File Offset: 0x00017EAC
			public static explicit operator Unicode.Rune(char codepoint)
			{
				return new Unicode.Rune
				{
					value = (int)codepoint
				};
			}

			// Token: 0x0600083B RID: 2107 RVA: 0x00019CCA File Offset: 0x00017ECA
			public static bool IsDigit(Unicode.Rune r)
			{
				return r.value >= 48 && r.value <= 57;
			}

			// Token: 0x0600083C RID: 2108 RVA: 0x00019CE8 File Offset: 0x00017EE8
			public int LengthInUtf8Bytes()
			{
				if (this.value < 0)
				{
					return 4;
				}
				if (this.value <= 127)
				{
					return 1;
				}
				if (this.value <= 2047)
				{
					return 2;
				}
				if (this.value <= 65535)
				{
					return 3;
				}
				int num = this.value;
				return 4;
			}

			// Token: 0x040002E5 RID: 741
			public int value;
		}
	}
}
