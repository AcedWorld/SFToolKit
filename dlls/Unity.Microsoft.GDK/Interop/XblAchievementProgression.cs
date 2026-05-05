using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001E4 RID: 484
	internal struct XblAchievementProgression
	{
		// Token: 0x06000C31 RID: 3121 RVA: 0x0001034F File Offset: 0x0000E54F
		internal T[] GetRequirements<T>(Func<XblAchievementRequirement, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblAchievementRequirement>(this.requirements, this.requirementsCount, ctor);
		}

		// Token: 0x04000656 RID: 1622
		private readonly IntPtr requirements;

		// Token: 0x04000657 RID: 1623
		private readonly SizeT requirementsCount;

		// Token: 0x04000658 RID: 1624
		internal readonly TimeT timeUnlocked;
	}
}
