using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200003B RID: 59
	internal static class UnitExtensions
	{
		// Token: 0x0600015D RID: 349 RVA: 0x00005338 File Offset: 0x00003538
		internal static BaseUnits GetBaseUnits(this Units units)
		{
			switch (units)
			{
			case Units.None:
				return default(BaseUnits);
			case Units.Bytes:
				return new BaseUnits(1, 0);
			case Units.BytesPerSecond:
				return new BaseUnits(1, -1);
			case Units.Seconds:
				return new BaseUnits(0, 1);
			case Units.Hertz:
				return new BaseUnits(0, -1);
			default:
				throw new ArgumentOutOfRangeException("units", units, null);
			}
		}
	}
}
