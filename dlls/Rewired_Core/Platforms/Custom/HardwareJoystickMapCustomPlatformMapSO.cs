using System;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired.Platforms.Custom
{
	// Token: 0x0200023A RID: 570
	[Serializable]
	public abstract class HardwareJoystickMapCustomPlatformMapSO : ScriptableObject
	{
		// Token: 0x06001A26 RID: 6694 RVA: 0x00015544 File Offset: 0x00013744
		public virtual bool Matches(Guid hardwareTypeGuid)
		{
			return !(this.hardwareJoystickMap == null) && this.hardwareJoystickMap.Guid == hardwareTypeGuid;
		}

		// Token: 0x06001A27 RID: 6695
		public abstract HardwareJoystickMap.Platform GetPlatformMap();

		// Token: 0x04000ED2 RID: 3794
		[Tooltip("The joystick to which this platform map belongs. This must be assigned a HardwareJoystickMap (controller definition).")]
		public HardwareJoystickMap hardwareJoystickMap;
	}
}
