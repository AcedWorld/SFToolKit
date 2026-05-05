using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003A1 RID: 929
	public class UxmlAttributeOverridesFactory : UxmlFactory<VisualElement, UxmlAttributeOverridesTraits>
	{
		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06001F2B RID: 7979 RVA: 0x00077597 File Offset: 0x00075797
		public override string uxmlName
		{
			get
			{
				return "AttributeOverrides";
			}
		}

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x06001F2C RID: 7980 RVA: 0x0007759E File Offset: 0x0007579E
		public override string uxmlQualifiedName
		{
			get
			{
				return this.uxmlNamespace + "." + this.uxmlName;
			}
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x06001F2D RID: 7981 RVA: 0x000772DA File Offset: 0x000754DA
		public override string substituteForTypeName
		{
			get
			{
				return typeof(VisualElement).Name;
			}
		}

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x06001F2E RID: 7982 RVA: 0x000772EB File Offset: 0x000754EB
		public override string substituteForTypeNamespace
		{
			get
			{
				return typeof(VisualElement).Namespace ?? string.Empty;
			}
		}

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x06001F2F RID: 7983 RVA: 0x00077305 File Offset: 0x00075505
		public override string substituteForTypeQualifiedName
		{
			get
			{
				return typeof(VisualElement).FullName;
			}
		}

		// Token: 0x06001F30 RID: 7984 RVA: 0x000775B8 File Offset: 0x000757B8
		public override VisualElement Create(IUxmlAttributes bag, CreationContext cc)
		{
			return null;
		}

		// Token: 0x04000CE4 RID: 3300
		internal const string k_ElementName = "AttributeOverrides";
	}
}
