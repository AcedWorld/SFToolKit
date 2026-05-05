using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200007C RID: 124
	public class Box : VisualElement
	{
		// Token: 0x0600055D RID: 1373 RVA: 0x00014F22 File Offset: 0x00013122
		public Box()
		{
			base.AddToClassList(Box.ussClassName);
		}

		// Token: 0x0400021B RID: 539
		public static readonly string ussClassName = "unity-box";

		// Token: 0x0200007D RID: 125
		public new class UxmlFactory : UxmlFactory<Box>
		{
		}
	}
}
