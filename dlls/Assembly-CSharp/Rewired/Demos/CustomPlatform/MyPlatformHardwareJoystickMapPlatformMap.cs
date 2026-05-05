using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Platforms.Custom;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002D7 RID: 727
	public sealed class MyPlatformHardwareJoystickMapPlatformMap : HardwareJoystickMapCustomPlatformMapSO
	{
		// Token: 0x06000F4F RID: 3919 RVA: 0x00051D78 File Offset: 0x0004FF78
		public override HardwareJoystickMap.Platform GetPlatformMap()
		{
			return this.platformMap;
		}

		// Token: 0x040013F8 RID: 5112
		public MyPlatformHardwareJoystickMapPlatformMap.PlatformMap platformMap;

		// Token: 0x020002D8 RID: 728
		[Serializable]
		public class PlatformMapBase : HardwareJoystickMapCustomPlatformMap<MyPlatformHardwareJoystickMapPlatformMap.MatchingCriteria>
		{
			// Token: 0x06000F51 RID: 3921 RVA: 0x00051D88 File Offset: 0x0004FF88
			protected override object CreateInstance()
			{
				return new MyPlatformHardwareJoystickMapPlatformMap.PlatformMapBase();
			}
		}

		// Token: 0x020002D9 RID: 729
		[Serializable]
		public sealed class PlatformMap : MyPlatformHardwareJoystickMapPlatformMap.PlatformMapBase
		{
			// Token: 0x06000F53 RID: 3923 RVA: 0x00051D97 File Offset: 0x0004FF97
			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return this.variants;
			}

			// Token: 0x06000F54 RID: 3924 RVA: 0x00051D9F File Offset: 0x0004FF9F
			protected override object CreateInstance()
			{
				return new MyPlatformHardwareJoystickMapPlatformMap.PlatformMap();
			}

			// Token: 0x040013F9 RID: 5113
			public MyPlatformHardwareJoystickMapPlatformMap.PlatformMapBase[] variants;
		}

		// Token: 0x020002DA RID: 730
		[Serializable]
		public sealed class MatchingCriteria : HardwareJoystickMapCustomPlatformMap.MatchingCriteria
		{
			// Token: 0x06000F56 RID: 3926 RVA: 0x00051DB0 File Offset: 0x0004FFB0
			public override bool Matches(object customIdentifier)
			{
				if (!(customIdentifier is MyPlatformControllerIdentifier))
				{
					return false;
				}
				MyPlatformControllerIdentifier myPlatformControllerIdentifier = (MyPlatformControllerIdentifier)customIdentifier;
				return (uint)myPlatformControllerIdentifier.productId == this.productId && (uint)myPlatformControllerIdentifier.vendorId == this.vendorId;
			}

			// Token: 0x06000F57 RID: 3927 RVA: 0x00051DEC File Offset: 0x0004FFEC
			protected override object CreateInstance()
			{
				return new MyPlatformHardwareJoystickMapPlatformMap.MatchingCriteria();
			}

			// Token: 0x06000F58 RID: 3928 RVA: 0x00051DF3 File Offset: 0x0004FFF3
			protected override void DeepClone(object destination)
			{
				base.DeepClone(destination);
				MyPlatformHardwareJoystickMapPlatformMap.MatchingCriteria matchingCriteria = (MyPlatformHardwareJoystickMapPlatformMap.MatchingCriteria)destination;
				matchingCriteria.vendorId = this.vendorId;
				matchingCriteria.productId = this.productId;
			}

			// Token: 0x040013FA RID: 5114
			public uint vendorId;

			// Token: 0x040013FB RID: 5115
			public uint productId;
		}
	}
}
