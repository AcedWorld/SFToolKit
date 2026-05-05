using System;

namespace UnityEngine.Rendering.HighDefinition.Attributes
{
	// Token: 0x0200023A RID: 570
	internal class MaterialSharedPropertyMappingAttribute : Attribute
	{
		// Token: 0x06001017 RID: 4119 RVA: 0x0007C994 File Offset: 0x0007AB94
		public MaterialSharedPropertyMappingAttribute(MaterialSharedProperty property)
		{
			this.property = property;
		}

		// Token: 0x0400196F RID: 6511
		public readonly MaterialSharedProperty property;
	}
}
