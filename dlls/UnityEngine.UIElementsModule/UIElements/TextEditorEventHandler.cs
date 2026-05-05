using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020000D1 RID: 209
	internal class TextEditorEventHandler
	{
		// Token: 0x06000702 RID: 1794 RVA: 0x0001B027 File Offset: 0x00019227
		protected TextEditorEventHandler(TextElement textElement, TextEditingUtilities editingUtilities)
		{
			this.textElement = textElement;
			this.editingUtilities = editingUtilities;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public virtual void ExecuteDefaultActionAtTarget(EventBase evt)
		{
		}

		// Token: 0x04000319 RID: 793
		protected TextElement textElement;

		// Token: 0x0400031A RID: 794
		protected TextEditingUtilities editingUtilities;
	}
}
