using System;

namespace UnityEngine
{
	// Token: 0x02000214 RID: 532
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class TextAreaAttribute : PropertyAttribute
	{
		// Token: 0x060017A8 RID: 6056 RVA: 0x00027562 File Offset: 0x00025762
		public TextAreaAttribute()
		{
			this.minLines = 3;
			this.maxLines = 3;
		}

		// Token: 0x060017A9 RID: 6057 RVA: 0x0002757A File Offset: 0x0002577A
		public TextAreaAttribute(int minLines, int maxLines)
		{
			this.minLines = minLines;
			this.maxLines = maxLines;
		}

		// Token: 0x04000872 RID: 2162
		public readonly int minLines;

		// Token: 0x04000873 RID: 2163
		public readonly int maxLines;
	}
}
