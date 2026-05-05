using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200012B RID: 299
	public class DebugUIHandlerIndirectToggle : DebugUIHandlerWidget
	{
		// Token: 0x060008F0 RID: 2288 RVA: 0x00029712 File Offset: 0x00027912
		public void Init()
		{
			this.UpdateValueLabel();
			this.valueToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleValueChanged));
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00029736 File Offset: 0x00027936
		private void OnToggleValueChanged(bool value)
		{
			this.setter(this.index, value);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0002974A File Offset: 0x0002794A
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			this.checkmarkImage.color = this.colorSelected;
			return true;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0002976F File Offset: 0x0002796F
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
			this.checkmarkImage.color = this.colorDefault;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00029794 File Offset: 0x00027994
		public override void OnAction()
		{
			bool arg = !this.getter(this.index);
			this.setter(this.index, arg);
			this.UpdateValueLabel();
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x000297CE File Offset: 0x000279CE
		internal void UpdateValueLabel()
		{
			if (this.valueToggle != null)
			{
				this.valueToggle.isOn = this.getter(this.index);
			}
		}

		// Token: 0x0400053E RID: 1342
		public Text nameLabel;

		// Token: 0x0400053F RID: 1343
		public Toggle valueToggle;

		// Token: 0x04000540 RID: 1344
		public Image checkmarkImage;

		// Token: 0x04000541 RID: 1345
		public Func<int, bool> getter;

		// Token: 0x04000542 RID: 1346
		public Action<int, bool> setter;

		// Token: 0x04000543 RID: 1347
		internal int index;
	}
}
