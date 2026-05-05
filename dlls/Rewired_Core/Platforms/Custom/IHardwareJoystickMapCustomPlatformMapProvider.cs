using System;
using Rewired.Data.Mapping;

namespace Rewired.Platforms.Custom
{
	// Token: 0x0200022E RID: 558
	public interface IHardwareJoystickMapCustomPlatformMapProvider
	{
		// Token: 0x060019D9 RID: 6617
		HardwareJoystickMap.Platform GetPlatformMap(int customPlatformId, Guid hardwareTypeGuid);
	}
}
