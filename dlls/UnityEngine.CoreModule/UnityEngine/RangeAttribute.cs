using System;

namespace UnityEngine
{
	// Token: 0x02000211 RID: 529
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class RangeAttribute : PropertyAttribute
	{
		// Token: 0x060017A4 RID: 6052 RVA: 0x00027517 File Offset: 0x00025717
		public RangeAttribute(float min, float max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x0400086E RID: 2158
		public readonly float min;

		// Token: 0x0400086F RID: 2159
		public readonly float max;
	}
}
