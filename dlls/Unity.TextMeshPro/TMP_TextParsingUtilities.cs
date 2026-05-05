using System;

namespace TMPro
{
	// Token: 0x0200006C RID: 108
	public class TMP_TextParsingUtilities
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x00035C0F File Offset: 0x00033E0F
		public static TMP_TextParsingUtilities instance
		{
			get
			{
				return TMP_TextParsingUtilities.s_Instance;
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00035C18 File Offset: 0x00033E18
		public static int GetHashCode(string s)
		{
			int num = 0;
			for (int i = 0; i < s.Length; i++)
			{
				num = ((num << 5) + num ^ (int)TMP_TextParsingUtilities.ToUpperASCIIFast(s[i]));
			}
			return num;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00035C4C File Offset: 0x00033E4C
		public static int GetHashCodeCaseSensitive(string s)
		{
			int num = 0;
			for (int i = 0; i < s.Length; i++)
			{
				num = ((num << 5) + num ^ (int)s[i]);
			}
			return num;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00035C7B File Offset: 0x00033E7B
		public static char ToLowerASCIIFast(char c)
		{
			if ((int)c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-"[(int)c];
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00035C99 File Offset: 0x00033E99
		public static char ToUpperASCIIFast(char c)
		{
			if ((int)c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"[(int)c];
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00035CB7 File Offset: 0x00033EB7
		public static uint ToUpperASCIIFast(uint c)
		{
			if ((ulong)c > (ulong)((long)("-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-".Length - 1)))
			{
				return c;
			}
			return (uint)"-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"[(int)c];
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00035CD7 File Offset: 0x00033ED7
		public static uint ToLowerASCIIFast(uint c)
		{
			if ((ulong)c > (ulong)((long)("-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-".Length - 1)))
			{
				return c;
			}
			return (uint)"-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-"[(int)c];
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00035CF7 File Offset: 0x00033EF7
		public static bool IsHighSurrogate(uint c)
		{
			return c > 55296U && c < 56319U;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00035D0B File Offset: 0x00033F0B
		public static bool IsLowSurrogate(uint c)
		{
			return c > 56320U && c < 57343U;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00035D1F File Offset: 0x00033F1F
		internal static uint ConvertToUTF32(uint highSurrogate, uint lowSurrogate)
		{
			return (highSurrogate - 55296U) * 1024U + (lowSurrogate - 56320U + 65536U);
		}

		// Token: 0x0400053D RID: 1341
		private static readonly TMP_TextParsingUtilities s_Instance = new TMP_TextParsingUtilities();

		// Token: 0x0400053E RID: 1342
		private const string k_LookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-";

		// Token: 0x0400053F RID: 1343
		private const string k_LookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-";
	}
}
