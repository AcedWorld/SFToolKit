using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000125 RID: 293
	public abstract class DebugUIHandlerField<T> : DebugUIHandlerWidget where T : DebugUI.Widget
	{
		// Token: 0x060008C8 RID: 2248 RVA: 0x00028F18 File Offset: 0x00027118
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<T>();
			this.nameLabel.text = this.m_Field.displayName;
			this.UpdateValueLabel();
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x00028F50 File Offset: 0x00027150
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			if (this.nextButtonText != null)
			{
				this.nextButtonText.color = this.colorSelected;
			}
			if (this.previousButtonText != null)
			{
				this.previousButtonText.color = this.colorSelected;
			}
			this.nameLabel.color = this.colorSelected;
			this.valueLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00028FC0 File Offset: 0x000271C0
		public override void OnDeselection()
		{
			if (this.nextButtonText != null)
			{
				this.nextButtonText.color = this.colorDefault;
			}
			if (this.previousButtonText != null)
			{
				this.previousButtonText.color = this.colorDefault;
			}
			this.nameLabel.color = this.colorDefault;
			this.valueLabel.color = this.colorDefault;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0002902D File Offset: 0x0002722D
		public override void OnAction()
		{
			this.OnIncrement(false);
		}

		// Token: 0x060008CC RID: 2252
		public abstract void UpdateValueLabel();

		// Token: 0x060008CD RID: 2253 RVA: 0x00029036 File Offset: 0x00027236
		protected void SetLabelText(string text)
		{
			if (text.Length > 26)
			{
				text = text.Substring(0, 23) + "...";
			}
			this.valueLabel.text = text;
		}

		// Token: 0x04000524 RID: 1316
		public Text nextButtonText;

		// Token: 0x04000525 RID: 1317
		public Text previousButtonText;

		// Token: 0x04000526 RID: 1318
		public Text nameLabel;

		// Token: 0x04000527 RID: 1319
		public Text valueLabel;

		// Token: 0x04000528 RID: 1320
		protected internal T m_Field;
	}
}
