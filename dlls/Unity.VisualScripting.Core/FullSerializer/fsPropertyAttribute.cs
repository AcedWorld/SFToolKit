using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001A6 RID: 422
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class fsPropertyAttribute : Attribute
	{
		// Token: 0x06000B12 RID: 2834 RVA: 0x0002E8D0 File Offset: 0x0002CAD0
		public fsPropertyAttribute() : this(string.Empty)
		{
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0002E8DD File Offset: 0x0002CADD
		public fsPropertyAttribute(string name)
		{
			this.Name = name;
		}

		// Token: 0x04000293 RID: 659
		public string Name;

		// Token: 0x04000294 RID: 660
		public Type Converter;
	}
}
