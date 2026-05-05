using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003F8 RID: 1016
	internal static class VisualElementDebugExtensions
	{
		// Token: 0x060020D4 RID: 8404 RVA: 0x0007C1B4 File Offset: 0x0007A3B4
		public static string GetDisplayName(this VisualElement ve, bool withHashCode = true)
		{
			bool flag = ve == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				string text = ve.GetType().Name;
				bool flag2 = !string.IsNullOrEmpty(ve.name);
				if (flag2)
				{
					text = text + "#" + ve.name;
				}
				if (withHashCode)
				{
					text = text + " (" + ve.GetHashCode().ToString("x8") + ")";
				}
				result = text;
			}
			return result;
		}
	}
}
