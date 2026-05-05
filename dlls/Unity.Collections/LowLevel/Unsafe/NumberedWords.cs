using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000EA RID: 234
	[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
	public struct NumberedWords
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x0001D04C File Offset: 0x0001B24C
		// (set) Token: 0x06000938 RID: 2360 RVA: 0x0001D059 File Offset: 0x0001B259
		private int LeadingZeroes
		{
			get
			{
				return this.Suffix >> 29 & 7;
			}
			set
			{
				this.Suffix &= 536870911;
				this.Suffix |= (value & 7) << 29;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000939 RID: 2361 RVA: 0x0001D080 File Offset: 0x0001B280
		// (set) Token: 0x0600093A RID: 2362 RVA: 0x0001D08E File Offset: 0x0001B28E
		private int PositiveNumericSuffix
		{
			get
			{
				return this.Suffix & 536870911;
			}
			set
			{
				this.Suffix &= -536870912;
				this.Suffix |= (value & 536870911);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x0001D0B6 File Offset: 0x0001B2B6
		private bool HasPositiveNumericSuffix
		{
			get
			{
				return this.PositiveNumericSuffix != 0;
			}
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0001D0C4 File Offset: 0x0001B2C4
		[NotBurstCompatible]
		private string NewString(char c, int count)
		{
			char[] array = new char[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = c;
			}
			return new string(array, 0, count);
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0001D0F0 File Offset: 0x0001B2F0
		[NotBurstCompatible]
		public unsafe int ToFixedString<T>(ref T result) where T : IUTF8Bytes, INativeList<byte>
		{
			int i = this.PositiveNumericSuffix;
			int leadingZeroes = this.LeadingZeroes;
			WordStorage.Instance.GetFixedString<T>(this.Index, ref result);
			if (i == 0 && leadingZeroes == 0)
			{
				return 0;
			}
			byte* ptr = stackalloc byte[(UIntPtr)17];
			int j = 17;
			while (i > 0)
			{
				ptr[--j] = (byte)(48 + i % 10);
				i /= 10;
			}
			while (leadingZeroes-- > 0)
			{
				ptr[--j] = 48;
			}
			byte* ptr2 = result.GetUnsafePtr() + result.Length;
			result.Length += 17 - j;
			while (j < 17)
			{
				*(ptr2++) = ptr[j++];
			}
			return 0;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0001D1AC File Offset: 0x0001B3AC
		[NotBurstCompatible]
		public override string ToString()
		{
			FixedString512Bytes fixedString512Bytes = default(FixedString512Bytes);
			this.ToFixedString<FixedString512Bytes>(ref fixedString512Bytes);
			return fixedString512Bytes.ToString();
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0001D1D7 File Offset: 0x0001B3D7
		private bool IsDigit(byte b)
		{
			return b >= 48 && b <= 57;
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0001D1E8 File Offset: 0x0001B3E8
		[NotBurstCompatible]
		public void SetString<T>(ref T value) where T : IUTF8Bytes, INativeList<byte>
		{
			int num = value.Length;
			while (num > 0 && this.IsDigit(value[num - 1]))
			{
				num--;
			}
			int num2 = num;
			while (num2 < value.Length && value[num2] == 48)
			{
				num2++;
			}
			int num3 = num2 - num;
			if (num3 > 7)
			{
				int num4 = num3 - 7;
				num += num4;
				num3 -= num4;
			}
			this.PositiveNumericSuffix = 0;
			int num5 = 0;
			for (int i = num2; i < value.Length; i++)
			{
				num5 *= 10;
				num5 += (int)(value[i] - 48);
			}
			if (num5 <= 536870911)
			{
				this.PositiveNumericSuffix = num5;
			}
			else
			{
				num = value.Length;
				num3 = 0;
			}
			this.LeadingZeroes = num3;
			T t = value;
			int length = t.Length;
			if (num != t.Length)
			{
				t.Length = num;
			}
			this.Index = WordStorage.Instance.GetOrCreateIndex<T>(ref t);
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0001D314 File Offset: 0x0001B514
		[NotBurstCompatible]
		public void SetString(string value)
		{
			FixedString512Bytes fixedString512Bytes = value;
			this.SetString<FixedString512Bytes>(ref fixedString512Bytes);
		}

		// Token: 0x04000336 RID: 822
		private int Index;

		// Token: 0x04000337 RID: 823
		private int Suffix;

		// Token: 0x04000338 RID: 824
		private const int kPositiveNumericSuffixShift = 0;

		// Token: 0x04000339 RID: 825
		private const int kPositiveNumericSuffixBits = 29;

		// Token: 0x0400033A RID: 826
		private const int kMaxPositiveNumericSuffix = 536870911;

		// Token: 0x0400033B RID: 827
		private const int kPositiveNumericSuffixMask = 536870911;

		// Token: 0x0400033C RID: 828
		private const int kLeadingZeroesShift = 29;

		// Token: 0x0400033D RID: 829
		private const int kLeadingZeroesBits = 3;

		// Token: 0x0400033E RID: 830
		private const int kMaxLeadingZeroes = 7;

		// Token: 0x0400033F RID: 831
		private const int kLeadingZeroesMask = 7;
	}
}
