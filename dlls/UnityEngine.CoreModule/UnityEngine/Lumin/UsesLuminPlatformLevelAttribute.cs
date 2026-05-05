using System;

namespace UnityEngine.Lumin
{
	// Token: 0x020003D9 RID: 985
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	[Obsolete("Lumin is no longer supported in Unity 2022.2")]
	public sealed class UsesLuminPlatformLevelAttribute : Attribute
	{
		// Token: 0x06002143 RID: 8515 RVA: 0x00037553 File Offset: 0x00035753
		public UsesLuminPlatformLevelAttribute(uint platformLevel)
		{
			this.m_PlatformLevel = platformLevel;
		}

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06002144 RID: 8516 RVA: 0x00037564 File Offset: 0x00035764
		public uint platformLevel
		{
			get
			{
				return this.m_PlatformLevel;
			}
		}

		// Token: 0x04000B06 RID: 2822
		private readonly uint m_PlatformLevel;
	}
}
