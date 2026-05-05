using System;

namespace Rewired
{
	// Token: 0x0200005C RID: 92
	public abstract class ControllerWithMap : Controller
	{
		// Token: 0x0600040B RID: 1035 RVA: 0x000348F4 File Offset: 0x00032AF4
		internal ControllerWithMap(int A_1, InputSource A_2, string A_3, string A_4, string A_5, ControllerType A_6, Guid A_7, int A_8, bool[] A_9, HardwareControllerMap_Game A_10, Controller.Extension A_11, ControllerDataUpdater A_12) : base(A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8, A_9, A_10.hwButtonInfo, A_10, A_11, A_12)
		{
		}
	}
}
