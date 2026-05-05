using System;
using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
	// Token: 0x0200006F RID: 111
	public static class RaycasterManager
	{
		// Token: 0x0600066B RID: 1643 RVA: 0x0001B548 File Offset: 0x00019748
		internal static void AddRaycaster(BaseRaycaster baseRaycaster)
		{
			if (RaycasterManager.s_Raycasters.Contains(baseRaycaster))
			{
				return;
			}
			RaycasterManager.s_Raycasters.Add(baseRaycaster);
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001B563 File Offset: 0x00019763
		public static List<BaseRaycaster> GetRaycasters()
		{
			return RaycasterManager.s_Raycasters;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0001B56A File Offset: 0x0001976A
		internal static void RemoveRaycasters(BaseRaycaster baseRaycaster)
		{
			if (!RaycasterManager.s_Raycasters.Contains(baseRaycaster))
			{
				return;
			}
			RaycasterManager.s_Raycasters.Remove(baseRaycaster);
		}

		// Token: 0x0400022F RID: 559
		private static readonly List<BaseRaycaster> s_Raycasters = new List<BaseRaycaster>();
	}
}
