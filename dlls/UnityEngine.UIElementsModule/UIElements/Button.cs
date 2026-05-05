using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200007E RID: 126
	public class Button : TextElement
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x00014F50 File Offset: 0x00013150
		// (set) Token: 0x06000561 RID: 1377 RVA: 0x00014F68 File Offset: 0x00013168
		public Clickable clickable
		{
			get
			{
				return this.m_Clickable;
			}
			set
			{
				bool flag = this.m_Clickable != null && this.m_Clickable.target == this;
				if (flag)
				{
					this.RemoveManipulator(this.m_Clickable);
				}
				this.m_Clickable = value;
				bool flag2 = this.m_Clickable != null;
				if (flag2)
				{
					this.AddManipulator(this.m_Clickable);
				}
			}
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000562 RID: 1378 RVA: 0x00014FC5 File Offset: 0x000131C5
		// (remove) Token: 0x06000563 RID: 1379 RVA: 0x00014FD0 File Offset: 0x000131D0
		[Obsolete("onClick is obsolete. Use clicked instead (UnityUpgradable) -> clicked", true)]
		public event Action onClick
		{
			add
			{
				this.clicked += value;
			}
			remove
			{
				this.clicked -= value;
			}
		}

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000564 RID: 1380 RVA: 0x00014FDC File Offset: 0x000131DC
		// (remove) Token: 0x06000565 RID: 1381 RVA: 0x00015018 File Offset: 0x00013218
		public event Action clicked
		{
			add
			{
				bool flag = this.m_Clickable == null;
				if (flag)
				{
					this.clickable = new Clickable(value);
				}
				else
				{
					this.m_Clickable.clicked += value;
				}
			}
			remove
			{
				bool flag = this.m_Clickable != null;
				if (flag)
				{
					this.m_Clickable.clicked -= value;
				}
			}
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00015042 File Offset: 0x00013242
		public Button() : this(null)
		{
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00015050 File Offset: 0x00013250
		public Button(Action clickEvent)
		{
			base.AddToClassList(Button.ussClassName);
			this.clickable = new Clickable(clickEvent);
			base.focusable = true;
			base.tabIndex = 0;
			base.RegisterCallback<NavigationSubmitEvent>(new EventCallback<NavigationSubmitEvent>(this.OnNavigationSubmit), TrickleDown.NoTrickleDown);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x000150A2 File Offset: 0x000132A2
		private void OnNavigationSubmit(NavigationSubmitEvent evt)
		{
			Clickable clickable = this.clickable;
			if (clickable != null)
			{
				clickable.SimulateSingleClick(evt, 100);
			}
			evt.StopPropagation();
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x000150C4 File Offset: 0x000132C4
		protected internal override Vector2 DoMeasure(float desiredWidth, VisualElement.MeasureMode widthMode, float desiredHeight, VisualElement.MeasureMode heightMode)
		{
			string text = this.text;
			bool flag = string.IsNullOrEmpty(text);
			if (flag)
			{
				text = Button.NonEmptyString;
			}
			return base.MeasureTextSize(text, desiredWidth, widthMode, desiredHeight, heightMode);
		}

		// Token: 0x0400021C RID: 540
		public new static readonly string ussClassName = "unity-button";

		// Token: 0x0400021D RID: 541
		private Clickable m_Clickable;

		// Token: 0x0400021E RID: 542
		private static readonly string NonEmptyString = " ";

		// Token: 0x0200007F RID: 127
		public new class UxmlFactory : UxmlFactory<Button, Button.UxmlTraits>
		{
		}

		// Token: 0x02000080 RID: 128
		public new class UxmlTraits : TextElement.UxmlTraits
		{
			// Token: 0x0600056C RID: 1388 RVA: 0x0001511A File Offset: 0x0001331A
			public UxmlTraits()
			{
				base.focusable.defaultValue = true;
			}
		}
	}
}
