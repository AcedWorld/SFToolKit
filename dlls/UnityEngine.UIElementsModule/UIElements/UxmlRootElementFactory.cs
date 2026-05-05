using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000398 RID: 920
	public class UxmlRootElementFactory : UxmlFactory<VisualElement, UxmlRootElementTraits>
	{
		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x06001EF8 RID: 7928 RVA: 0x0007715E File Offset: 0x0007535E
		public override string uxmlName
		{
			get
			{
				return "UXML";
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x06001EF9 RID: 7929 RVA: 0x00077165 File Offset: 0x00075365
		public override string uxmlQualifiedName
		{
			get
			{
				return this.uxmlNamespace + "." + this.uxmlName;
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x06001EFA RID: 7930 RVA: 0x0007717D File Offset: 0x0007537D
		public override string substituteForTypeName
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x06001EFB RID: 7931 RVA: 0x0007717D File Offset: 0x0007537D
		public override string substituteForTypeNamespace
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06001EFC RID: 7932 RVA: 0x0007717D File Offset: 0x0007537D
		public override string substituteForTypeQualifiedName
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x06001EFD RID: 7933 RVA: 0x00077184 File Offset: 0x00075384
		public override VisualElement Create(IUxmlAttributes bag, CreationContext cc)
		{
			return null;
		}

		// Token: 0x04000CCD RID: 3277
		internal const string k_ElementName = "UXML";
	}
}
