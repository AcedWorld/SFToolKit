using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000137 RID: 311
	public class DebugUIHandlerUIntField : DebugUIHandlerWidget
	{
		// Token: 0x0600093B RID: 2363 RVA: 0x0002A6D7 File Offset: 0x000288D7
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.UIntField>();
			this.nameLabel.text = this.m_Field.displayName;
			this.UpdateValueLabel();
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0002A708 File Offset: 0x00028908
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			this.valueLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0002A72D File Offset: 0x0002892D
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
			this.valueLabel.color = this.colorDefault;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0002A751 File Offset: 0x00028951
		public override void OnIncrement(bool fast)
		{
			this.ChangeValue(fast, 1);
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0002A75B File Offset: 0x0002895B
		public override void OnDecrement(bool fast)
		{
			this.ChangeValue(fast, -1);
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0002A768 File Offset: 0x00028968
		private void ChangeValue(bool fast, int multiplier)
		{
			long num = (long)((ulong)this.m_Field.GetValue());
			if (num == 0L && multiplier < 0)
			{
				return;
			}
			num += (long)((ulong)(this.m_Field.incStep * (fast ? this.m_Field.intStepMult : 1U)) * (ulong)((long)multiplier));
			this.m_Field.SetValue((uint)num);
			this.UpdateValueLabel();
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0002A7C4 File Offset: 0x000289C4
		private void UpdateValueLabel()
		{
			if (this.valueLabel != null)
			{
				this.valueLabel.text = this.m_Field.GetValue().ToString("N0");
			}
		}

		// Token: 0x0400056A RID: 1386
		public Text nameLabel;

		// Token: 0x0400056B RID: 1387
		public Text valueLabel;

		// Token: 0x0400056C RID: 1388
		private DebugUI.UIntField m_Field;
	}
}
