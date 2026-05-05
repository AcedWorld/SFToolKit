using System;

namespace Rewired.Platforms.Custom
{
	// Token: 0x02000237 RID: 567
	[Serializable]
	public class HardwareJoystickMapCustomPlatformMapSimpleBase : HardwareJoystickMapCustomPlatformMap<HardwareJoystickMapCustomPlatformMapSimpleBase.MatchingCriteria>
	{
		// Token: 0x06001A1F RID: 6687 RVA: 0x0001550F File Offset: 0x0001370F
		protected override object CreateInstance()
		{
			return new HardwareJoystickMapCustomPlatformMapSimpleBase();
		}

		// Token: 0x02000238 RID: 568
		[Serializable]
		public new sealed class MatchingCriteria : HardwareJoystickMapCustomPlatformMap.MatchingCriteria
		{
			// Token: 0x06001A21 RID: 6689 RVA: 0x0001551E File Offset: 0x0001371E
			protected override object CreateInstance()
			{
				return new HardwareJoystickMapCustomPlatformMapSimpleBase.MatchingCriteria();
			}
		}
	}
}
