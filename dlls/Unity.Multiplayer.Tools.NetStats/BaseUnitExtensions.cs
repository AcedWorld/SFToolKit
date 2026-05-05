using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000037 RID: 55
	internal static class BaseUnitExtensions
	{
		// Token: 0x0600014D RID: 333 RVA: 0x00004F9B File Offset: 0x0000319B
		public static string GetSymbol(this BaseUnit unit)
		{
			if (unit == BaseUnit.Byte)
			{
				return "B";
			}
			if (unit != BaseUnit.Second)
			{
				throw new ArgumentException(string.Format("Unhandled BaseUnit {0}", unit));
			}
			return "s";
		}
	}
}
