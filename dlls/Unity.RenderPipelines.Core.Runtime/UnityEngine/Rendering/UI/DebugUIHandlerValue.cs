using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000138 RID: 312
	public class DebugUIHandlerValue : DebugUIHandlerWidget
	{
		// Token: 0x06000943 RID: 2371 RVA: 0x0002A80A File Offset: 0x00028A0A
		protected override void OnEnable()
		{
			this.m_Timer = 0f;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0002A817 File Offset: 0x00028A17
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.Value>();
			this.nameLabel.text = this.m_Field.displayName;
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0002A842 File Offset: 0x00028A42
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			this.valueLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0002A867 File Offset: 0x00028A67
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
			this.valueLabel.color = this.colorDefault;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0002A88C File Offset: 0x00028A8C
		private void Update()
		{
			if (this.m_Timer >= this.m_Field.refreshRate)
			{
				object value = this.m_Field.GetValue();
				this.valueLabel.text = this.m_Field.FormatString(value);
				if (value is float)
				{
					this.valueLabel.color = (((float)value == 0f) ? DebugUIHandlerValue.k_ZeroColor : this.colorDefault);
				}
				this.m_Timer -= this.m_Field.refreshRate;
			}
			this.m_Timer += Time.deltaTime;
		}

		// Token: 0x0400056D RID: 1389
		public Text nameLabel;

		// Token: 0x0400056E RID: 1390
		public Text valueLabel;

		// Token: 0x0400056F RID: 1391
		private DebugUI.Value m_Field;

		// Token: 0x04000570 RID: 1392
		protected internal float m_Timer;

		// Token: 0x04000571 RID: 1393
		private static readonly Color k_ZeroColor = Color.gray;
	}
}
