using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003E8 RID: 1000
	public struct CreationContext : IEquatable<CreationContext>
	{
		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x060020A8 RID: 8360 RVA: 0x0007BC77 File Offset: 0x00079E77
		// (set) Token: 0x060020A9 RID: 8361 RVA: 0x0007BC7F File Offset: 0x00079E7F
		public VisualElement target { readonly get; private set; }

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x060020AA RID: 8362 RVA: 0x0007BC88 File Offset: 0x00079E88
		// (set) Token: 0x060020AB RID: 8363 RVA: 0x0007BC90 File Offset: 0x00079E90
		public VisualTreeAsset visualTreeAsset { readonly get; private set; }

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x060020AC RID: 8364 RVA: 0x0007BC99 File Offset: 0x00079E99
		// (set) Token: 0x060020AD RID: 8365 RVA: 0x0007BCA1 File Offset: 0x00079EA1
		public Dictionary<string, VisualElement> slotInsertionPoints { readonly get; private set; }

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x060020AE RID: 8366 RVA: 0x0007BCAA File Offset: 0x00079EAA
		// (set) Token: 0x060020AF RID: 8367 RVA: 0x0007BCB2 File Offset: 0x00079EB2
		internal List<TemplateAsset.AttributeOverride> attributeOverrides { readonly get; private set; }

		// Token: 0x060020B0 RID: 8368 RVA: 0x0007BCBB File Offset: 0x00079EBB
		internal CreationContext(Dictionary<string, VisualElement> slotInsertionPoints, VisualTreeAsset vta, VisualElement target)
		{
			this = new CreationContext(slotInsertionPoints, null, vta, target);
		}

		// Token: 0x060020B1 RID: 8369 RVA: 0x0007BCC9 File Offset: 0x00079EC9
		internal CreationContext(Dictionary<string, VisualElement> slotInsertionPoints, List<TemplateAsset.AttributeOverride> attributeOverrides, VisualTreeAsset vta, VisualElement target)
		{
			this.target = target;
			this.slotInsertionPoints = slotInsertionPoints;
			this.attributeOverrides = attributeOverrides;
			this.visualTreeAsset = vta;
		}

		// Token: 0x060020B2 RID: 8370 RVA: 0x0007BCF0 File Offset: 0x00079EF0
		public override bool Equals(object obj)
		{
			return obj is CreationContext && this.Equals((CreationContext)obj);
		}

		// Token: 0x060020B3 RID: 8371 RVA: 0x0007BD1C File Offset: 0x00079F1C
		public bool Equals(CreationContext other)
		{
			return EqualityComparer<VisualElement>.Default.Equals(this.target, other.target) && EqualityComparer<VisualTreeAsset>.Default.Equals(this.visualTreeAsset, other.visualTreeAsset) && EqualityComparer<Dictionary<string, VisualElement>>.Default.Equals(this.slotInsertionPoints, other.slotInsertionPoints);
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x0007BD7C File Offset: 0x00079F7C
		public override int GetHashCode()
		{
			int num = -2123482148;
			num = num * -1521134295 + EqualityComparer<VisualElement>.Default.GetHashCode(this.target);
			num = num * -1521134295 + EqualityComparer<VisualTreeAsset>.Default.GetHashCode(this.visualTreeAsset);
			return num * -1521134295 + EqualityComparer<Dictionary<string, VisualElement>>.Default.GetHashCode(this.slotInsertionPoints);
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x0007BDE0 File Offset: 0x00079FE0
		public static bool operator ==(CreationContext context1, CreationContext context2)
		{
			return context1.Equals(context2);
		}

		// Token: 0x060020B6 RID: 8374 RVA: 0x0007BDFC File Offset: 0x00079FFC
		public static bool operator !=(CreationContext context1, CreationContext context2)
		{
			return !(context1 == context2);
		}

		// Token: 0x04000D85 RID: 3461
		public static readonly CreationContext Default = default(CreationContext);
	}
}
