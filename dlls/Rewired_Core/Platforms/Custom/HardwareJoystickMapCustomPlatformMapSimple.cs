using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;

namespace Rewired.Platforms.Custom
{
	// Token: 0x02000239 RID: 569
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public sealed class HardwareJoystickMapCustomPlatformMapSimple : HardwareJoystickMapCustomPlatformMapSimpleBase
	{
		// Token: 0x06001A23 RID: 6691 RVA: 0x0001552D File Offset: 0x0001372D
		public override IList<HardwareJoystickMap.Platform> GetVariants()
		{
			return this.variants;
		}

		// Token: 0x06001A24 RID: 6692 RVA: 0x00015535 File Offset: 0x00013735
		protected override object CreateInstance()
		{
			return new HardwareJoystickMapCustomPlatformMapSimple();
		}

		// Token: 0x04000ED1 RID: 3793
		public HardwareJoystickMapCustomPlatformMapSimpleBase[] variants;
	}
}
