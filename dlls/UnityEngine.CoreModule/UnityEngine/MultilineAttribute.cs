using System;

namespace UnityEngine
{
	// Token: 0x02000213 RID: 531
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class MultilineAttribute : PropertyAttribute
	{
		// Token: 0x060017A6 RID: 6054 RVA: 0x00027540 File Offset: 0x00025740
		public MultilineAttribute()
		{
			this.lines = 3;
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x00027551 File Offset: 0x00025751
		public MultilineAttribute(int lines)
		{
			this.lines = lines;
		}

		// Token: 0x04000871 RID: 2161
		public readonly int lines;
	}
}
