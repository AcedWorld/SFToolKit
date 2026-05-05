using System;

namespace UnityEngine
{
	// Token: 0x02000212 RID: 530
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060017A5 RID: 6053 RVA: 0x0002752F File Offset: 0x0002572F
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04000870 RID: 2160
		public readonly float min;
	}
}
