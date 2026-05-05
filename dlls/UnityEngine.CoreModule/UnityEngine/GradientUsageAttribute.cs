using System;

namespace UnityEngine
{
	// Token: 0x02000216 RID: 534
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public sealed class GradientUsageAttribute : PropertyAttribute
	{
		// Token: 0x060017AD RID: 6061 RVA: 0x000276C8 File Offset: 0x000258C8
		public GradientUsageAttribute(bool hdr)
		{
			this.hdr = hdr;
			this.colorSpace = ColorSpace.Gamma;
		}

		// Token: 0x060017AE RID: 6062 RVA: 0x000276EE File Offset: 0x000258EE
		public GradientUsageAttribute(bool hdr, ColorSpace colorSpace)
		{
			this.hdr = hdr;
			this.colorSpace = colorSpace;
		}

		// Token: 0x0400087A RID: 2170
		public readonly bool hdr = false;

		// Token: 0x0400087B RID: 2171
		public readonly ColorSpace colorSpace = ColorSpace.Gamma;
	}
}
