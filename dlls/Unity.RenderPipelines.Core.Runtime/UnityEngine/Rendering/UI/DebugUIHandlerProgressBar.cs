using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000133 RID: 307
	public class DebugUIHandlerProgressBar : DebugUIHandlerWidget
	{
		// Token: 0x06000923 RID: 2339 RVA: 0x0002A092 File Offset: 0x00028292
		protected override void OnEnable()
		{
			this.m_Timer = 0f;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0002A09F File Offset: 0x0002829F
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Value = base.CastWidget<DebugUI.ProgressBarValue>();
			this.nameLabel.text = this.m_Value.displayName;
			this.UpdateValue();
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0002A0D0 File Offset: 0x000282D0
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0002A0E4 File Offset: 0x000282E4
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0002A0F8 File Offset: 0x000282F8
		private void Update()
		{
			if (this.m_Timer >= this.m_Value.refreshRate)
			{
				this.UpdateValue();
				this.m_Timer -= this.m_Value.refreshRate;
			}
			this.m_Timer += Time.deltaTime;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0002A148 File Offset: 0x00028348
		private void UpdateValue()
		{
			float num = (float)this.m_Value.GetValue();
			this.valueLabel.text = this.m_Value.FormatString(num);
			Vector3 localScale = this.progressBarRect.localScale;
			localScale.x = num;
			this.progressBarRect.localScale = localScale;
		}

		// Token: 0x0400055E RID: 1374
		public Text nameLabel;

		// Token: 0x0400055F RID: 1375
		public Text valueLabel;

		// Token: 0x04000560 RID: 1376
		public RectTransform progressBarRect;

		// Token: 0x04000561 RID: 1377
		private DebugUI.ProgressBarValue m_Value;

		// Token: 0x04000562 RID: 1378
		private float m_Timer;
	}
}
