using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000126 RID: 294
	public class DebugUIHandlerFloatField : DebugUIHandlerWidget
	{
		// Token: 0x060008CF RID: 2255 RVA: 0x0002906B File Offset: 0x0002726B
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.FloatField>();
			this.nameLabel.text = this.m_Field.displayName;
			this.UpdateValueLabel();
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0002909C File Offset: 0x0002729C
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			this.valueLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x000290C1 File Offset: 0x000272C1
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
			this.valueLabel.color = this.colorDefault;
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x000290E5 File Offset: 0x000272E5
		public override void OnIncrement(bool fast)
		{
			this.ChangeValue(fast, 1f);
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x000290F3 File Offset: 0x000272F3
		public override void OnDecrement(bool fast)
		{
			this.ChangeValue(fast, -1f);
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00029104 File Offset: 0x00027304
		private void ChangeValue(bool fast, float multiplier)
		{
			float num = this.m_Field.GetValue();
			num += this.m_Field.incStep * (fast ? this.m_Field.incStepMult : 1f) * multiplier;
			this.m_Field.SetValue(num);
			this.UpdateValueLabel();
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00029158 File Offset: 0x00027358
		private void UpdateValueLabel()
		{
			this.valueLabel.text = this.m_Field.GetValue().ToString("N" + this.m_Field.decimals.ToString());
		}

		// Token: 0x04000529 RID: 1321
		public Text nameLabel;

		// Token: 0x0400052A RID: 1322
		public Text valueLabel;

		// Token: 0x0400052B RID: 1323
		private DebugUI.FloatField m_Field;
	}
}
