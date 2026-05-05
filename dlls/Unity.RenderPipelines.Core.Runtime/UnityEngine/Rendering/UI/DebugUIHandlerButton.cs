using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200011E RID: 286
	public class DebugUIHandlerButton : DebugUIHandlerWidget
	{
		// Token: 0x0600088D RID: 2189 RVA: 0x00027D08 File Offset: 0x00025F08
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.Button>();
			this.nameLabel.text = this.m_Field.displayName;
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00027D33 File Offset: 0x00025F33
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00027D47 File Offset: 0x00025F47
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00027D5A File Offset: 0x00025F5A
		public override void OnAction()
		{
			if (this.m_Field.action != null)
			{
				this.m_Field.action();
			}
		}

		// Token: 0x0400050C RID: 1292
		public Text nameLabel;

		// Token: 0x0400050D RID: 1293
		private DebugUI.Button m_Field;
	}
}
