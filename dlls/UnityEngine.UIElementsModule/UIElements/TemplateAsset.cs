using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace UnityEngine.UIElements
{
	// Token: 0x020003A4 RID: 932
	[Serializable]
	internal class TemplateAsset : VisualElementAsset
	{
		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06001F3C RID: 7996 RVA: 0x000776B4 File Offset: 0x000758B4
		// (set) Token: 0x06001F3D RID: 7997 RVA: 0x000776CC File Offset: 0x000758CC
		public string templateAlias
		{
			get
			{
				return this.m_TemplateAlias;
			}
			set
			{
				this.m_TemplateAlias = value;
			}
		}

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06001F3E RID: 7998 RVA: 0x000776D8 File Offset: 0x000758D8
		// (set) Token: 0x06001F3F RID: 7999 RVA: 0x00077708 File Offset: 0x00075908
		public List<TemplateAsset.AttributeOverride> attributeOverrides
		{
			get
			{
				return (this.m_AttributeOverrides == null) ? (this.m_AttributeOverrides = new List<TemplateAsset.AttributeOverride>()) : this.m_AttributeOverrides;
			}
			set
			{
				this.m_AttributeOverrides = value;
			}
		}

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06001F40 RID: 8000 RVA: 0x00077714 File Offset: 0x00075914
		// (set) Token: 0x06001F41 RID: 8001 RVA: 0x0007772C File Offset: 0x0007592C
		internal List<VisualTreeAsset.SlotUsageEntry> slotUsages
		{
			get
			{
				return this.m_SlotUsages;
			}
			set
			{
				this.m_SlotUsages = value;
			}
		}

		// Token: 0x06001F42 RID: 8002 RVA: 0x00077736 File Offset: 0x00075936
		public TemplateAsset(string templateAlias, string fullTypeName) : base(fullTypeName)
		{
			Assert.IsFalse(string.IsNullOrEmpty(templateAlias), "Template alias must not be null or empty");
			this.m_TemplateAlias = templateAlias;
		}

		// Token: 0x06001F43 RID: 8003 RVA: 0x0007775C File Offset: 0x0007595C
		public void AddSlotUsage(string slotName, int resId)
		{
			bool flag = this.m_SlotUsages == null;
			if (flag)
			{
				this.m_SlotUsages = new List<VisualTreeAsset.SlotUsageEntry>();
			}
			this.m_SlotUsages.Add(new VisualTreeAsset.SlotUsageEntry(slotName, resId));
		}

		// Token: 0x04000CEB RID: 3307
		[SerializeField]
		private string m_TemplateAlias;

		// Token: 0x04000CEC RID: 3308
		[SerializeField]
		private List<TemplateAsset.AttributeOverride> m_AttributeOverrides;

		// Token: 0x04000CED RID: 3309
		[SerializeField]
		private List<VisualTreeAsset.SlotUsageEntry> m_SlotUsages;

		// Token: 0x020003A5 RID: 933
		[Serializable]
		public struct AttributeOverride
		{
			// Token: 0x04000CEE RID: 3310
			public string m_ElementName;

			// Token: 0x04000CEF RID: 3311
			public string m_AttributeName;

			// Token: 0x04000CF0 RID: 3312
			public string m_Value;
		}
	}
}
