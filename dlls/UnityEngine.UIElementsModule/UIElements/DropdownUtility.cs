using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000181 RID: 385
	internal static class DropdownUtility
	{
		// Token: 0x06000C3E RID: 3134 RVA: 0x00030F90 File Offset: 0x0002F190
		internal static IGenericMenu CreateDropdown()
		{
			IGenericMenu result;
			if (DropdownUtility.MakeDropdownFunc == null)
			{
				IGenericMenu genericMenu = new GenericDropdownMenu();
				result = genericMenu;
			}
			else
			{
				result = DropdownUtility.MakeDropdownFunc();
			}
			return result;
		}

		// Token: 0x040005D3 RID: 1491
		internal static Func<IGenericMenu> MakeDropdownFunc;
	}
}
