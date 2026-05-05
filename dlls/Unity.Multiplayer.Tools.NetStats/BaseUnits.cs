using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000038 RID: 56
	internal readonly struct BaseUnits
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00004FC7 File Offset: 0x000031C7
		internal sbyte BytesExponent { get; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00004FCF File Offset: 0x000031CF
		internal sbyte SecondsExponent { get; }

		// Token: 0x06000150 RID: 336 RVA: 0x00004FD7 File Offset: 0x000031D7
		public BaseUnits(sbyte bytesExponent = 0, sbyte secondsExponent = 0)
		{
			this.BytesExponent = bytesExponent;
			this.SecondsExponent = secondsExponent;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004FE7 File Offset: 0x000031E7
		public BaseUnits WithSeconds(sbyte seconds)
		{
			return new BaseUnits(this.BytesExponent, seconds);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004FF5 File Offset: 0x000031F5
		public bool Equals(BaseUnits other)
		{
			return this.BytesExponent == other.BytesExponent && this.SecondsExponent == other.SecondsExponent;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00005018 File Offset: 0x00003218
		public override bool Equals(object obj)
		{
			if (obj is BaseUnits)
			{
				BaseUnits other = (BaseUnits)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000503D File Offset: 0x0000323D
		public override int GetHashCode()
		{
			return (int)((byte)this.BytesExponent) << 8 | (int)((byte)this.SecondsExponent);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00005050 File Offset: 0x00003250
		internal sbyte GetExponent(BaseUnit unit)
		{
			if (unit == BaseUnit.Byte)
			{
				return this.BytesExponent;
			}
			if (unit != BaseUnit.Second)
			{
				throw new ArgumentException(string.Format("Unhandled BaseUnit {0}", unit));
			}
			return this.SecondsExponent;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00005080 File Offset: 0x00003280
		internal ValueTuple<string, string> NumeratorAndDenominatorDisplayStrings
		{
			get
			{
				string item = "";
				string item2 = "";
				for (BaseUnit baseUnit = BaseUnit.Byte; baseUnit < (BaseUnit)2; baseUnit++)
				{
					sbyte exponent = this.GetExponent(baseUnit);
					if (exponent > 0)
					{
						BaseUnits.<get_NumeratorAndDenominatorDisplayStrings>g__AddUnit|14_0(baseUnit, exponent, ref item);
					}
					else if (exponent < 0)
					{
						BaseUnits.<get_NumeratorAndDenominatorDisplayStrings>g__AddUnit|14_0(baseUnit, Math.Abs(exponent), ref item2);
					}
				}
				return new ValueTuple<string, string>(item, item2);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000050D8 File Offset: 0x000032D8
		internal string DisplayString
		{
			get
			{
				ValueTuple<string, string> numeratorAndDenominatorDisplayStrings = this.NumeratorAndDenominatorDisplayStrings;
				string item = numeratorAndDenominatorDisplayStrings.Item1;
				string item2 = numeratorAndDenominatorDisplayStrings.Item2;
				return item + ((item2 == "") ? "" : ("/" + item2));
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000511D File Offset: 0x0000331D
		public override string ToString()
		{
			return this.DisplayString;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00005140 File Offset: 0x00003340
		[CompilerGenerated]
		internal static void <get_NumeratorAndDenominatorDisplayStrings>g__AddUnit|14_0(BaseUnit unit, sbyte exponent, ref string str)
		{
			str += unit.GetSymbol();
			if (exponent <= 1)
			{
				return;
			}
			if (exponent >= 100)
			{
				str += BaseUnits.k_Superscripts[(int)(exponent / 100)].ToString();
				exponent %= 100;
			}
			if (exponent >= 10)
			{
				str += BaseUnits.k_Superscripts[(int)(exponent / 10)].ToString();
				exponent %= 10;
			}
			str += BaseUnits.k_Superscripts[(int)(exponent / 10)].ToString();
		}

		// Token: 0x04000060 RID: 96
		private static readonly char[] k_Superscripts = new char[]
		{
			'⁰',
			'¹',
			'²',
			'³',
			'⁴',
			'⁵',
			'⁶',
			'⁷',
			'⁸',
			'⁹'
		};
	}
}
