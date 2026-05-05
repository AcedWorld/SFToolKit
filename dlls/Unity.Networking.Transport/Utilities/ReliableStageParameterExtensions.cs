using System;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000AE RID: 174
	public static class ReliableStageParameterExtensions
	{
		// Token: 0x060002B5 RID: 693 RVA: 0x0000F900 File Offset: 0x0000DB00
		public static ref NetworkSettings WithReliableStageParameters(this NetworkSettings settings, int windowSize = 32)
		{
			ReliableUtility.Parameters parameters = new ReliableUtility.Parameters
			{
				WindowSize = windowSize
			};
			settings.AddRawParameterStruct<ReliableUtility.Parameters>(ref parameters);
			return ref settings;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000F928 File Offset: 0x0000DB28
		public static ReliableUtility.Parameters GetReliableStageParameters(this NetworkSettings settings)
		{
			ReliableUtility.Parameters result;
			if (!settings.TryGet<ReliableUtility.Parameters>(out result))
			{
				result.WindowSize = 32;
			}
			return result;
		}
	}
}
