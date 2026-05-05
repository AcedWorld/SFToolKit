using System;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000AA RID: 170
	public static class FragmentationStageParameterExtensions
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x0000F86C File Offset: 0x0000DA6C
		public static ref NetworkSettings WithFragmentationStageParameters(this NetworkSettings settings, int payloadCapacity = 4096)
		{
			FragmentationUtility.Parameters parameters = new FragmentationUtility.Parameters
			{
				PayloadCapacity = payloadCapacity
			};
			settings.AddRawParameterStruct<FragmentationUtility.Parameters>(ref parameters);
			return ref settings;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000F894 File Offset: 0x0000DA94
		public static FragmentationUtility.Parameters GetFragmentationStageParameters(this NetworkSettings settings)
		{
			FragmentationUtility.Parameters result;
			if (!settings.TryGet<FragmentationUtility.Parameters>(out result))
			{
				result.PayloadCapacity = 4096;
			}
			return result;
		}
	}
}
