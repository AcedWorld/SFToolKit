using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000135 RID: 309
	public class DebugUIHandlerToggle : DebugUIHandlerWidget
	{
		// Token: 0x06000930 RID: 2352 RVA: 0x0002A410 File Offset: 0x00028610
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.BoolField>();
			this.nameLabel.text = this.m_Field.displayName;
			this.UpdateValueLabel();
			this.valueToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleValueChanged));
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0002A468 File Offset: 0x00028668
		private void OnToggleValueChanged(bool value)
		{
			this.m_Field.SetValue(value);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0002A476 File Offset: 0x00028676
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			this.checkmarkImage.color = this.colorSelected;
			return true;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0002A49B File Offset: 0x0002869B
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
			this.checkmarkImage.color = this.colorDefault;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0002A4C0 File Offset: 0x000286C0
		public override void OnAction()
		{
			bool value = !this.m_Field.GetValue();
			this.m_Field.SetValue(value);
			this.UpdateValueLabel();
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0002A4EE File Offset: 0x000286EE
		protected internal virtual void UpdateValueLabel()
		{
			if (this.valueToggle != null)
			{
				this.valueToggle.isOn = this.m_Field.GetValue();
			}
		}

		// Token: 0x04000564 RID: 1380
		public Text nameLabel;

		// Token: 0x04000565 RID: 1381
		public Toggle valueToggle;

		// Token: 0x04000566 RID: 1382
		public Image checkmarkImage;

		// Token: 0x04000567 RID: 1383
		protected internal DebugUI.BoolField m_Field;
	}
}
