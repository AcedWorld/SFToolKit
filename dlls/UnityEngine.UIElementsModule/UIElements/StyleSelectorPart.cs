using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000353 RID: 851
	[Serializable]
	internal struct StyleSelectorPart
	{
		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x06001C81 RID: 7297 RVA: 0x0006EA70 File Offset: 0x0006CC70
		// (set) Token: 0x06001C82 RID: 7298 RVA: 0x0006EA88 File Offset: 0x0006CC88
		public string value
		{
			get
			{
				return this.m_Value;
			}
			internal set
			{
				this.m_Value = value;
			}
		}

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x06001C83 RID: 7299 RVA: 0x0006EA94 File Offset: 0x0006CC94
		// (set) Token: 0x06001C84 RID: 7300 RVA: 0x0006EAAC File Offset: 0x0006CCAC
		public StyleSelectorType type
		{
			get
			{
				return this.m_Type;
			}
			internal set
			{
				this.m_Type = value;
			}
		}

		// Token: 0x06001C85 RID: 7301 RVA: 0x0006EAB8 File Offset: 0x0006CCB8
		public override string ToString()
		{
			return UnityString.Format("[StyleSelectorPart: value={0}, type={1}]", new object[]
			{
				this.value,
				this.type
			});
		}

		// Token: 0x06001C86 RID: 7302 RVA: 0x0006EAF4 File Offset: 0x0006CCF4
		public static StyleSelectorPart CreateClass(string className)
		{
			return new StyleSelectorPart
			{
				m_Type = StyleSelectorType.Class,
				m_Value = className
			};
		}

		// Token: 0x06001C87 RID: 7303 RVA: 0x0006EB20 File Offset: 0x0006CD20
		public static StyleSelectorPart CreatePseudoClass(string className)
		{
			return new StyleSelectorPart
			{
				m_Type = StyleSelectorType.PseudoClass,
				m_Value = className
			};
		}

		// Token: 0x06001C88 RID: 7304 RVA: 0x0006EB4C File Offset: 0x0006CD4C
		public static StyleSelectorPart CreateId(string Id)
		{
			return new StyleSelectorPart
			{
				m_Type = StyleSelectorType.ID,
				m_Value = Id
			};
		}

		// Token: 0x06001C89 RID: 7305 RVA: 0x0006EB78 File Offset: 0x0006CD78
		public static StyleSelectorPart CreateType(Type t)
		{
			return new StyleSelectorPart
			{
				m_Type = StyleSelectorType.Type,
				m_Value = t.Name
			};
		}

		// Token: 0x06001C8A RID: 7306 RVA: 0x0006EBA8 File Offset: 0x0006CDA8
		public static StyleSelectorPart CreateType(string typeName)
		{
			return new StyleSelectorPart
			{
				m_Type = StyleSelectorType.Type,
				m_Value = typeName
			};
		}

		// Token: 0x06001C8B RID: 7307 RVA: 0x0006EBD4 File Offset: 0x0006CDD4
		public static StyleSelectorPart CreatePredicate(object predicate)
		{
			return new StyleSelectorPart
			{
				m_Type = StyleSelectorType.Predicate,
				tempData = predicate
			};
		}

		// Token: 0x06001C8C RID: 7308 RVA: 0x0006EC00 File Offset: 0x0006CE00
		public static StyleSelectorPart CreateWildCard()
		{
			return new StyleSelectorPart
			{
				m_Type = StyleSelectorType.Wildcard
			};
		}

		// Token: 0x04000BCC RID: 3020
		[SerializeField]
		private string m_Value;

		// Token: 0x04000BCD RID: 3021
		[SerializeField]
		private StyleSelectorType m_Type;

		// Token: 0x04000BCE RID: 3022
		internal object tempData;
	}
}
