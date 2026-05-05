using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000075 RID: 117
	public static class IBindingExtensions
	{
		// Token: 0x06000548 RID: 1352 RVA: 0x000147B4 File Offset: 0x000129B4
		public static bool IsBound(this IBindable control)
		{
			return ((control != null) ? control.binding : null) != null;
		}
	}
}
