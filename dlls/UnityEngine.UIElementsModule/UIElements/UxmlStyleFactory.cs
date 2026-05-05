using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200039B RID: 923
	public class UxmlStyleFactory : UxmlFactory<VisualElement, UxmlStyleTraits>
	{
		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06001F09 RID: 7945 RVA: 0x000772BB File Offset: 0x000754BB
		public override string uxmlName
		{
			get
			{
				return "Style";
			}
		}

		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x06001F0A RID: 7946 RVA: 0x000772C2 File Offset: 0x000754C2
		public override string uxmlQualifiedName
		{
			get
			{
				return this.uxmlNamespace + "." + this.uxmlName;
			}
		}

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x06001F0B RID: 7947 RVA: 0x000772DA File Offset: 0x000754DA
		public override string substituteForTypeName
		{
			get
			{
				return typeof(VisualElement).Name;
			}
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x06001F0C RID: 7948 RVA: 0x000772EB File Offset: 0x000754EB
		public override string substituteForTypeNamespace
		{
			get
			{
				return typeof(VisualElement).Namespace ?? string.Empty;
			}
		}

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x06001F0D RID: 7949 RVA: 0x00077305 File Offset: 0x00075505
		public override string substituteForTypeQualifiedName
		{
			get
			{
				return typeof(VisualElement).FullName;
			}
		}

		// Token: 0x06001F0E RID: 7950 RVA: 0x00077318 File Offset: 0x00075518
		public override VisualElement Create(IUxmlAttributes bag, CreationContext cc)
		{
			return null;
		}

		// Token: 0x04000CD4 RID: 3284
		internal const string k_ElementName = "Style";
	}
}
