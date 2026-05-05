using System;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x0200000F RID: 15
	internal static class NetworkDirectionExtensions
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000022F6 File Offset: 0x000004F6
		public static string DisplayString(this NetworkDirection direction)
		{
			if (direction != NetworkDirection.None)
			{
				return direction.ToString();
			}
			return "";
		}
	}
}
