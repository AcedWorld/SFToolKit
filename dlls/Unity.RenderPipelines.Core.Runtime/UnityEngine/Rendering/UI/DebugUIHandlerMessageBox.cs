using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200012D RID: 301
	public class DebugUIHandlerMessageBox : DebugUIHandlerWidget
	{
		// Token: 0x060008FF RID: 2303 RVA: 0x00029928 File Offset: 0x00027B28
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.MessageBox>();
			this.nameLabel.text = this.m_Field.displayName;
			Image component = base.GetComponent<Image>();
			DebugUI.MessageBox.Style style = this.m_Field.style;
			if (style == DebugUI.MessageBox.Style.Warning)
			{
				component.color = DebugUIHandlerMessageBox.k_WarningBackgroundColor;
				return;
			}
			if (style != DebugUI.MessageBox.Style.Error)
			{
				return;
			}
			component.color = DebugUIHandlerMessageBox.k_ErrorBackgroundColor;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0002999B File Offset: 0x00027B9B
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			return false;
		}

		// Token: 0x04000547 RID: 1351
		public Text nameLabel;

		// Token: 0x04000548 RID: 1352
		private DebugUI.MessageBox m_Field;

		// Token: 0x04000549 RID: 1353
		private static Color32 k_WarningBackgroundColor = new Color32(231, 180, 3, 30);

		// Token: 0x0400054A RID: 1354
		private static Color32 k_WarningTextColor = new Color32(231, 180, 3, byte.MaxValue);

		// Token: 0x0400054B RID: 1355
		private static Color32 k_ErrorBackgroundColor = new Color32(231, 75, 3, 30);

		// Token: 0x0400054C RID: 1356
		private static Color32 k_ErrorTextColor = new Color32(231, 75, 3, byte.MaxValue);
	}
}
