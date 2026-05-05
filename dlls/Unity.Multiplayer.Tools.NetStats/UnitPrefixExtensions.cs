using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200003A RID: 58
	internal static class UnitPrefixExtensions
	{
		// Token: 0x0600015B RID: 347 RVA: 0x000051D0 File Offset: 0x000033D0
		public static string GetSymbol(this MetricPrefix prefix)
		{
			switch (prefix)
			{
			case MetricPrefix.Atto:
				return "a";
			case MetricPrefix.Femto:
				return "f";
			case MetricPrefix.Pico:
				return "p";
			case MetricPrefix.Nano:
				return "n";
			case MetricPrefix.Micro:
				return "μ";
			case MetricPrefix.Milli:
				return "m";
			case MetricPrefix.None:
				return "";
			case MetricPrefix.Kilo:
				return "k";
			case MetricPrefix.Mega:
				return "M";
			case MetricPrefix.Giga:
				return "G";
			case MetricPrefix.Tera:
				return "T";
			case MetricPrefix.Peta:
				return "P";
			case MetricPrefix.Exa:
				return "E";
			default:
				throw new ArgumentException(string.Format("Unhandled {0} {1}", "MetricPrefix", prefix));
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005284 File Offset: 0x00003484
		public static float GetValueFloat(this MetricPrefix prefix)
		{
			switch (prefix)
			{
			case MetricPrefix.Atto:
				return 1E-18f;
			case MetricPrefix.Femto:
				return 1E-15f;
			case MetricPrefix.Pico:
				return 1E-12f;
			case MetricPrefix.Nano:
				return 1E-09f;
			case MetricPrefix.Micro:
				return 1E-06f;
			case MetricPrefix.Milli:
				return 0.001f;
			case MetricPrefix.None:
				return 1f;
			case MetricPrefix.Kilo:
				return 1000f;
			case MetricPrefix.Mega:
				return 1000000f;
			case MetricPrefix.Giga:
				return 1E+09f;
			case MetricPrefix.Tera:
				return 1E+12f;
			case MetricPrefix.Peta:
				return 1E+15f;
			case MetricPrefix.Exa:
				return 1E+18f;
			default:
				throw new ArgumentException(string.Format("Unhandled {0} {1}", "MetricPrefix", prefix));
			}
		}
	}
}
