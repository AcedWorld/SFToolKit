using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Platforms.Custom;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002D0 RID: 720
	[Serializable]
	public class CustomPlatformHardwareJoystickMapProvider : IHardwareJoystickMapCustomPlatformMapProvider
	{
		// Token: 0x06000F3D RID: 3901 RVA: 0x00051B60 File Offset: 0x0004FD60
		public HardwareJoystickMap.Platform GetPlatformMap(int customPlatformId, Guid hardwareTypeGuid)
		{
			CustomPlatformHardwareJoystickMapPlatformDataSet platformDataSet = this.GetPlatformDataSet(customPlatformId);
			if (platformDataSet == null)
			{
				return null;
			}
			return CustomPlatformHardwareJoystickMapProvider.GetPlatformMap(platformDataSet, hardwareTypeGuid);
		}

		// Token: 0x06000F3E RID: 3902 RVA: 0x00051B88 File Offset: 0x0004FD88
		private CustomPlatformHardwareJoystickMapPlatformDataSet GetPlatformDataSet(int customPlatformId)
		{
			int count = this.platformJoystickDataSets.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.platformJoystickDataSets[i] != null && this.platformJoystickDataSets[i].platformType == (CustomPlatformType)customPlatformId)
				{
					return this.platformJoystickDataSets[i].dataSet;
				}
			}
			return null;
		}

		// Token: 0x06000F3F RID: 3903 RVA: 0x00051BE4 File Offset: 0x0004FDE4
		private static HardwareJoystickMap.Platform GetPlatformMap(CustomPlatformHardwareJoystickMapPlatformDataSet platformDataSet, Guid hardwareTypeGuid)
		{
			if (platformDataSet == null || platformDataSet.platformMaps == null)
			{
				return null;
			}
			int count = platformDataSet.platformMaps.Count;
			for (int i = 0; i < count; i++)
			{
				if (platformDataSet.platformMaps[i] != null && platformDataSet.platformMaps[i].Matches(hardwareTypeGuid))
				{
					return platformDataSet.platformMaps[i].GetPlatformMap();
				}
			}
			return null;
		}

		// Token: 0x040013EF RID: 5103
		public List<CustomPlatformHardwareJoystickMapProvider.PlatformDataSet> platformJoystickDataSets;

		// Token: 0x020002D1 RID: 721
		[Serializable]
		public class PlatformDataSet
		{
			// Token: 0x040013F0 RID: 5104
			public CustomPlatformType platformType;

			// Token: 0x040013F1 RID: 5105
			public CustomPlatformHardwareJoystickMapPlatformDataSet dataSet;
		}
	}
}
