using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200012E RID: 302
	public class DebugUIHandlerObject : DebugUIHandlerWidget
	{
		// Token: 0x06000903 RID: 2307 RVA: 0x00029A14 File Offset: 0x00027C14
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			DebugUI.ObjectField objectField = base.CastWidget<DebugUI.ObjectField>();
			this.nameLabel.text = objectField.displayName;
			this.valueLabel.text = objectField.GetValue().name;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00029A56 File Offset: 0x00027C56
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			this.valueLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00029A7B File Offset: 0x00027C7B
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
			this.valueLabel.color = this.colorDefault;
		}

		// Token: 0x0400054D RID: 1357
		public Text nameLabel;

		// Token: 0x0400054E RID: 1358
		public Text valueLabel;
	}
}
