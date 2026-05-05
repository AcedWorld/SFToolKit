using System;

namespace UnityEngine
{
	// Token: 0x0200020F RID: 527
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class SpaceAttribute : PropertyAttribute
	{
		// Token: 0x060017A1 RID: 6049 RVA: 0x000274E0 File Offset: 0x000256E0
		public SpaceAttribute()
		{
			this.height = 8f;
		}

		// Token: 0x060017A2 RID: 6050 RVA: 0x000274F5 File Offset: 0x000256F5
		public SpaceAttribute(float height)
		{
			this.height = height;
		}

		// Token: 0x0400086C RID: 2156
		public readonly float height;
	}
}
