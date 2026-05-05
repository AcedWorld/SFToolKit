using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020000DE RID: 222
	public class Label : TextElement
	{
		// Token: 0x060007A8 RID: 1960 RVA: 0x0001D5EE File Offset: 0x0001B7EE
		public Label() : this(string.Empty)
		{
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0001D5FD File Offset: 0x0001B7FD
		public Label(string text)
		{
			base.AddToClassList(Label.ussClassName);
			this.text = text;
		}

		// Token: 0x0400034E RID: 846
		public new static readonly string ussClassName = "unity-label";

		// Token: 0x020000DF RID: 223
		public new class UxmlFactory : UxmlFactory<Label, Label.UxmlTraits>
		{
		}

		// Token: 0x020000E0 RID: 224
		public new class UxmlTraits : TextElement.UxmlTraits
		{
		}
	}
}
