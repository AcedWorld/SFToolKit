using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200039E RID: 926
	public class UxmlTemplateFactory : UxmlFactory<VisualElement, UxmlTemplateTraits>
	{
		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06001F1A RID: 7962 RVA: 0x00077443 File Offset: 0x00075643
		public override string uxmlName
		{
			get
			{
				return "Template";
			}
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06001F1B RID: 7963 RVA: 0x0007744A File Offset: 0x0007564A
		public override string uxmlQualifiedName
		{
			get
			{
				return this.uxmlNamespace + "." + this.uxmlName;
			}
		}

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06001F1C RID: 7964 RVA: 0x000772DA File Offset: 0x000754DA
		public override string substituteForTypeName
		{
			get
			{
				return typeof(VisualElement).Name;
			}
		}

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x06001F1D RID: 7965 RVA: 0x000772EB File Offset: 0x000754EB
		public override string substituteForTypeNamespace
		{
			get
			{
				return typeof(VisualElement).Namespace ?? string.Empty;
			}
		}

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x06001F1E RID: 7966 RVA: 0x00077305 File Offset: 0x00075505
		public override string substituteForTypeQualifiedName
		{
			get
			{
				return typeof(VisualElement).FullName;
			}
		}

		// Token: 0x06001F1F RID: 7967 RVA: 0x00077464 File Offset: 0x00075664
		public override VisualElement Create(IUxmlAttributes bag, CreationContext cc)
		{
			return null;
		}

		// Token: 0x04000CDC RID: 3292
		internal const string k_ElementName = "Template";
	}
}
