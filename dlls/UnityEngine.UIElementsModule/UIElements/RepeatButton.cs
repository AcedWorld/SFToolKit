using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200011A RID: 282
	public class RepeatButton : TextElement
	{
		// Token: 0x06000970 RID: 2416 RVA: 0x000247EB File Offset: 0x000229EB
		public RepeatButton()
		{
			base.AddToClassList(RepeatButton.ussClassName);
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x00024801 File Offset: 0x00022A01
		public RepeatButton(Action clickEvent, long delay, long interval) : this()
		{
			this.SetAction(clickEvent, delay, interval);
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x00024815 File Offset: 0x00022A15
		public void SetAction(Action clickEvent, long delay, long interval)
		{
			this.RemoveManipulator(this.m_Clickable);
			this.m_Clickable = new Clickable(clickEvent, delay, interval);
			this.AddManipulator(this.m_Clickable);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00024840 File Offset: 0x00022A40
		internal void AddAction(Action clickEvent)
		{
			this.m_Clickable.clicked += clickEvent;
		}

		// Token: 0x04000444 RID: 1092
		private Clickable m_Clickable;

		// Token: 0x04000445 RID: 1093
		public new static readonly string ussClassName = "unity-repeat-button";

		// Token: 0x0200011B RID: 283
		public new class UxmlFactory : UxmlFactory<RepeatButton, RepeatButton.UxmlTraits>
		{
		}

		// Token: 0x0200011C RID: 284
		public new class UxmlTraits : TextElement.UxmlTraits
		{
			// Token: 0x06000976 RID: 2422 RVA: 0x00024868 File Offset: 0x00022A68
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				RepeatButton repeatButton = (RepeatButton)ve;
				repeatButton.SetAction(null, this.m_Delay.GetValueFromBag(bag, cc), this.m_Interval.GetValueFromBag(bag, cc));
			}

			// Token: 0x04000446 RID: 1094
			private UxmlLongAttributeDescription m_Delay = new UxmlLongAttributeDescription
			{
				name = "delay"
			};

			// Token: 0x04000447 RID: 1095
			private UxmlLongAttributeDescription m_Interval = new UxmlLongAttributeDescription
			{
				name = "interval"
			};
		}
	}
}
