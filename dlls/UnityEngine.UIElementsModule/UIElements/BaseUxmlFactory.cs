using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003D0 RID: 976
	public abstract class BaseUxmlFactory<TCreatedType, TTraits> where TCreatedType : new() where TTraits : BaseUxmlTraits, new()
	{
		// Token: 0x0600200A RID: 8202 RVA: 0x000792A8 File Offset: 0x000774A8
		protected BaseUxmlFactory()
		{
			this.m_Traits = Activator.CreateInstance<TTraits>();
		}

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x0600200B RID: 8203 RVA: 0x000792C0 File Offset: 0x000774C0
		public virtual string uxmlName
		{
			get
			{
				return typeof(TCreatedType).Name;
			}
		}

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x0600200C RID: 8204 RVA: 0x000792E4 File Offset: 0x000774E4
		public virtual string uxmlNamespace
		{
			get
			{
				return typeof(TCreatedType).Namespace ?? string.Empty;
			}
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x0600200D RID: 8205 RVA: 0x00079310 File Offset: 0x00077510
		public virtual string uxmlQualifiedName
		{
			get
			{
				return typeof(TCreatedType).FullName;
			}
		}

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x0600200E RID: 8206 RVA: 0x00079331 File Offset: 0x00077531
		public virtual Type uxmlType
		{
			get
			{
				return typeof(TCreatedType);
			}
		}

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x0600200F RID: 8207 RVA: 0x00079340 File Offset: 0x00077540
		public bool canHaveAnyAttribute
		{
			get
			{
				return this.m_Traits.canHaveAnyAttribute;
			}
		}

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06002010 RID: 8208 RVA: 0x00079364 File Offset: 0x00077564
		public virtual IEnumerable<UxmlAttributeDescription> uxmlAttributesDescription
		{
			get
			{
				return this.m_Traits.uxmlAttributesDescription;
			}
		}

		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x06002011 RID: 8209 RVA: 0x00079388 File Offset: 0x00077588
		public virtual IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
		{
			get
			{
				return this.m_Traits.uxmlChildElementsDescription;
			}
		}

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x06002012 RID: 8210 RVA: 0x000793AC File Offset: 0x000775AC
		public virtual string substituteForTypeName
		{
			get
			{
				bool flag = typeof(TCreatedType) == typeof(VisualElement);
				string result;
				if (flag)
				{
					result = string.Empty;
				}
				else
				{
					result = typeof(VisualElement).Name;
				}
				return result;
			}
		}

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x06002013 RID: 8211 RVA: 0x000793F4 File Offset: 0x000775F4
		public virtual string substituteForTypeNamespace
		{
			get
			{
				bool flag = typeof(TCreatedType) == typeof(VisualElement);
				string result;
				if (flag)
				{
					result = string.Empty;
				}
				else
				{
					result = (typeof(VisualElement).Namespace ?? string.Empty);
				}
				return result;
			}
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06002014 RID: 8212 RVA: 0x00079444 File Offset: 0x00077644
		public virtual string substituteForTypeQualifiedName
		{
			get
			{
				bool flag = typeof(TCreatedType) == typeof(VisualElement);
				string result;
				if (flag)
				{
					result = string.Empty;
				}
				else
				{
					result = typeof(VisualElement).FullName;
				}
				return result;
			}
		}

		// Token: 0x06002015 RID: 8213 RVA: 0x0007948C File Offset: 0x0007768C
		public virtual bool AcceptsAttributeBag(IUxmlAttributes bag, CreationContext cc)
		{
			return true;
		}

		// Token: 0x04000D3C RID: 3388
		internal TTraits m_Traits;
	}
}
