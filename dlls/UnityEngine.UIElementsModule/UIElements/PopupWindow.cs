using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200010B RID: 267
	public class PopupWindow : TextElement
	{
		// Token: 0x06000928 RID: 2344 RVA: 0x000237FC File Offset: 0x000219FC
		public PopupWindow()
		{
			base.AddToClassList(PopupWindow.ussClassName);
			this.m_ContentContainer = new VisualElement
			{
				name = "unity-content-container"
			};
			this.m_ContentContainer.AddToClassList(PopupWindow.contentUssClassName);
			base.hierarchy.Add(this.m_ContentContainer);
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x0002385C File Offset: 0x00021A5C
		public override VisualElement contentContainer
		{
			get
			{
				return this.m_ContentContainer;
			}
		}

		// Token: 0x04000418 RID: 1048
		private VisualElement m_ContentContainer;

		// Token: 0x04000419 RID: 1049
		public new static readonly string ussClassName = "unity-popup-window";

		// Token: 0x0400041A RID: 1050
		public static readonly string contentUssClassName = PopupWindow.ussClassName + "__content-container";

		// Token: 0x0200010C RID: 268
		public new class UxmlFactory : UxmlFactory<PopupWindow, PopupWindow.UxmlTraits>
		{
		}

		// Token: 0x0200010D RID: 269
		public new class UxmlTraits : TextElement.UxmlTraits
		{
			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x0600092C RID: 2348 RVA: 0x000238A0 File Offset: 0x00021AA0
			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get
				{
					yield return new UxmlChildElementDescription(typeof(VisualElement));
					yield break;
				}
			}
		}
	}
}
