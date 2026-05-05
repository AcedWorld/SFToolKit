using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000365 RID: 869
	public class TemplateContainer : BindableElement
	{
		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x06001CDD RID: 7389 RVA: 0x0007009E File Offset: 0x0006E29E
		// (set) Token: 0x06001CDE RID: 7390 RVA: 0x000700A6 File Offset: 0x0006E2A6
		public string templateId { get; private set; }

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06001CDF RID: 7391 RVA: 0x000700AF File Offset: 0x0006E2AF
		// (set) Token: 0x06001CE0 RID: 7392 RVA: 0x000700B7 File Offset: 0x0006E2B7
		public VisualTreeAsset templateSource
		{
			get
			{
				return this.m_TemplateSource;
			}
			internal set
			{
				this.m_TemplateSource = value;
			}
		}

		// Token: 0x06001CE1 RID: 7393 RVA: 0x000700C0 File Offset: 0x0006E2C0
		public TemplateContainer() : this(null)
		{
		}

		// Token: 0x06001CE2 RID: 7394 RVA: 0x000700CB File Offset: 0x0006E2CB
		public TemplateContainer(string templateId)
		{
			this.templateId = templateId;
			this.m_ContentContainer = this;
		}

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06001CE3 RID: 7395 RVA: 0x000700E4 File Offset: 0x0006E2E4
		public override VisualElement contentContainer
		{
			get
			{
				return this.m_ContentContainer;
			}
		}

		// Token: 0x06001CE4 RID: 7396 RVA: 0x000700FC File Offset: 0x0006E2FC
		internal void SetContentContainer(VisualElement content)
		{
			this.m_ContentContainer = content;
		}

		// Token: 0x04000C2A RID: 3114
		private VisualElement m_ContentContainer;

		// Token: 0x04000C2B RID: 3115
		private VisualTreeAsset m_TemplateSource;

		// Token: 0x02000366 RID: 870
		public new class UxmlFactory : UxmlFactory<TemplateContainer, TemplateContainer.UxmlTraits>
		{
			// Token: 0x170006B9 RID: 1721
			// (get) Token: 0x06001CE5 RID: 7397 RVA: 0x00070106 File Offset: 0x0006E306
			public override string uxmlName
			{
				get
				{
					return "Instance";
				}
			}

			// Token: 0x170006BA RID: 1722
			// (get) Token: 0x06001CE6 RID: 7398 RVA: 0x0007010D File Offset: 0x0006E30D
			public override string uxmlQualifiedName
			{
				get
				{
					return this.uxmlNamespace + "." + this.uxmlName;
				}
			}

			// Token: 0x04000C2C RID: 3116
			internal const string k_ElementName = "Instance";
		}

		// Token: 0x02000367 RID: 871
		public new class UxmlTraits : BindableElement.UxmlTraits
		{
			// Token: 0x170006BB RID: 1723
			// (get) Token: 0x06001CE8 RID: 7400 RVA: 0x00070130 File Offset: 0x0006E330
			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get
				{
					yield break;
				}
			}

			// Token: 0x06001CE9 RID: 7401 RVA: 0x00070150 File Offset: 0x0006E350
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				TemplateContainer templateContainer = (TemplateContainer)ve;
				templateContainer.templateId = this.m_Template.GetValueFromBag(bag, cc);
				VisualTreeAsset visualTreeAsset = cc.visualTreeAsset;
				VisualTreeAsset visualTreeAsset2 = (visualTreeAsset != null) ? visualTreeAsset.ResolveTemplate(templateContainer.templateId) : null;
				bool flag = visualTreeAsset2 == null;
				if (flag)
				{
					templateContainer.Add(new Label(string.Format("Unknown Template: '{0}'", templateContainer.templateId)));
				}
				else
				{
					TemplateAsset templateAsset = bag as TemplateAsset;
					List<TemplateAsset.AttributeOverride> list = (templateAsset != null) ? templateAsset.attributeOverrides : null;
					List<TemplateAsset.AttributeOverride> attributeOverrides = cc.attributeOverrides;
					List<TemplateAsset.AttributeOverride> list2 = null;
					bool flag2 = list != null || attributeOverrides != null;
					if (flag2)
					{
						list2 = new List<TemplateAsset.AttributeOverride>();
						bool flag3 = attributeOverrides != null;
						if (flag3)
						{
							list2.AddRange(attributeOverrides);
						}
						bool flag4 = list != null;
						if (flag4)
						{
							list2.AddRange(list);
						}
					}
					visualTreeAsset2.CloneTree(ve, cc.slotInsertionPoints, list2);
				}
				bool flag5 = visualTreeAsset2 == null;
				if (flag5)
				{
					Debug.LogErrorFormat("Could not resolve template with name '{0}'", new object[]
					{
						templateContainer.templateId
					});
				}
			}

			// Token: 0x04000C2D RID: 3117
			internal const string k_TemplateAttributeName = "template";

			// Token: 0x04000C2E RID: 3118
			private UxmlStringAttributeDescription m_Template = new UxmlStringAttributeDescription
			{
				name = "template",
				use = UxmlAttributeDescription.Use.Required
			};
		}
	}
}
