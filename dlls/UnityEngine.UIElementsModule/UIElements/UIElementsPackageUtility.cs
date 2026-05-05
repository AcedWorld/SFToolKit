using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000379 RID: 889
	internal static class UIElementsPackageUtility
	{
		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x06001DF9 RID: 7673 RVA: 0x00073FDB File Offset: 0x000721DB
		// (set) Token: 0x06001DFA RID: 7674 RVA: 0x00073FE2 File Offset: 0x000721E2
		internal static bool IsUIEPackageLoaded { get; private set; }

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x06001DFB RID: 7675 RVA: 0x00073FEA File Offset: 0x000721EA
		// (set) Token: 0x06001DFC RID: 7676 RVA: 0x00073FF1 File Offset: 0x000721F1
		internal static string EditorResourcesBasePath { get; private set; }

		// Token: 0x06001DFD RID: 7677 RVA: 0x00073FF9 File Offset: 0x000721F9
		static UIElementsPackageUtility()
		{
			UIElementsPackageUtility.Refresh();
		}

		// Token: 0x06001DFE RID: 7678 RVA: 0x00074002 File Offset: 0x00072202
		internal static void Refresh()
		{
			UIElementsPackageUtility.EditorResourcesBasePath = "";
			UIElementsPackageUtility.IsUIEPackageLoaded = false;
		}
	}
}
