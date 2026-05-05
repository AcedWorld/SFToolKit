using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003CC RID: 972
	public interface IBaseUxmlFactory
	{
		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x06001FFD RID: 8189
		string uxmlName { get; }

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x06001FFE RID: 8190
		string uxmlNamespace { get; }

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x06001FFF RID: 8191
		string uxmlQualifiedName { get; }

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x06002000 RID: 8192
		Type uxmlType { get; }

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x06002001 RID: 8193
		bool canHaveAnyAttribute { get; }

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x06002002 RID: 8194
		IEnumerable<UxmlAttributeDescription> uxmlAttributesDescription { get; }

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x06002003 RID: 8195
		IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription { get; }

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x06002004 RID: 8196
		string substituteForTypeName { get; }

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x06002005 RID: 8197
		string substituteForTypeNamespace { get; }

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x06002006 RID: 8198
		string substituteForTypeQualifiedName { get; }

		// Token: 0x06002007 RID: 8199
		bool AcceptsAttributeBag(IUxmlAttributes bag, CreationContext cc);
	}
}
