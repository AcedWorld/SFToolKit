using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200012C RID: 300
	public class DebugUIHandlerIntField : DebugUIHandlerWidget
	{
		// Token: 0x060008F7 RID: 2295 RVA: 0x00029802 File Offset: 0x00027A02
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.IntField>();
			this.nameLabel.text = this.m_Field.displayName;
			this.UpdateValueLabel();
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00029833 File Offset: 0x00027A33
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			this.valueLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00029858 File Offset: 0x00027A58
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
			this.valueLabel.color = this.colorDefault;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0002987C File Offset: 0x00027A7C
		public override void OnIncrement(bool fast)
		{
			this.ChangeValue(fast, 1);
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00029886 File Offset: 0x00027A86
		public override void OnDecrement(bool fast)
		{
			this.ChangeValue(fast, -1);
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00029890 File Offset: 0x00027A90
		private void ChangeValue(bool fast, int multiplier)
		{
			int num = this.m_Field.GetValue();
			num += this.m_Field.incStep * (fast ? this.m_Field.intStepMult : 1) * multiplier;
			this.m_Field.SetValue(num);
			this.UpdateValueLabel();
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x000298E0 File Offset: 0x00027AE0
		private void UpdateValueLabel()
		{
			if (this.valueLabel != null)
			{
				this.valueLabel.text = this.m_Field.GetValue().ToString("N0");
			}
		}

		// Token: 0x04000544 RID: 1348
		public Text nameLabel;

		// Token: 0x04000545 RID: 1349
		public Text valueLabel;

		// Token: 0x04000546 RID: 1350
		private DebugUI.IntField m_Field;
	}
}
