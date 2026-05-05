using System;
using Rewired.Data.Mapping;

namespace Rewired.Platforms.Custom
{
	// Token: 0x0200023B RID: 571
	[Serializable]
	public class HardwareJoystickMapCustomPlatformMapSimpleSO : HardwareJoystickMapCustomPlatformMapSO
	{
		// Token: 0x06001A29 RID: 6697 RVA: 0x0001556F File Offset: 0x0001376F
		public override HardwareJoystickMap.Platform GetPlatformMap()
		{
			return this.platformMap;
		}

		// Token: 0x04000ED3 RID: 3795
		public HardwareJoystickMapCustomPlatformMapSimple platformMap;
	}
}
