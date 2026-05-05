using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;

// Token: 0x0200010F RID: 271
internal class lNiLuHSggoLjokYLQforkkbXwySd
{
	// Token: 0x0600098F RID: 2447 RVA: 0x00009DC4 File Offset: 0x00007FC4
	public lNiLuHSggoLjokYLQforkkbXwySd(ConfigVars A_1)
	{
		this.NoJZePDALgPWrNIAzCaoDrzTCULy = A_1;
	}

	// Token: 0x170002CB RID: 715
	// (get) Token: 0x06000990 RID: 2448 RVA: 0x00009DD3 File Offset: 0x00007FD3
	public int JZZMSdwQmzZLUZnhPHsPBtaOBmXm
	{
		get
		{
			return this.YigdwiengFaQiHELkjuVSOfzqvWDb;
		}
	}

	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06000991 RID: 2449 RVA: 0x00009DDB File Offset: 0x00007FDB
	public int dqdghehbZcEXgcaPeDgBkdlIrogAd
	{
		get
		{
			return this.QpbkOybHtOJtqrCubyZPOSZJujfo;
		}
	}

	// Token: 0x170002CD RID: 717
	// (get) Token: 0x06000992 RID: 2450 RVA: 0x00009DE3 File Offset: 0x00007FE3
	public Player[] QyodWyQUNwBmszApNAfRKZHwWtCUA
	{
		get
		{
			return this.almzxXuwuHtFoPlUqErrhOUvEYtA;
		}
	}

	// Token: 0x170002CE RID: 718
	// (get) Token: 0x06000993 RID: 2451 RVA: 0x00009DEB File Offset: 0x00007FEB
	public Player[] TORorJrYCuHeKlTGuMSHCpgsllYX
	{
		get
		{
			return this.IMtaSMhYebFuYOireReApzgsJuYH;
		}
	}

	// Token: 0x170002CF RID: 719
	// (get) Token: 0x06000994 RID: 2452 RVA: 0x00009DF3 File Offset: 0x00007FF3
	public IList<Player> CutceaYHAGyESiiqFclOPlqrWKfc
	{
		get
		{
			return this.TuEaWuQmKEGkxGZcBHcBQEXJaCov;
		}
	}

	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06000995 RID: 2453 RVA: 0x00009DFB File Offset: 0x00007FFB
	public IList<Player> rjzgupHwXIugYhKuZNNJGVDiXRWq
	{
		get
		{
			return this.RiXbzlqsCAwEBBuJWcwRrOgRnoVJ;
		}
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x00044CA8 File Offset: 0x00042EA8
	public void nCqQXpERRSjcZexCfinOHERlXKhM()
	{
		if (this.AlXEdacLaEeQdYLxqYfNLfHkpECzA)
		{
			return;
		}
		this.QpbkOybHtOJtqrCubyZPOSZJujfo = ReInput.UserData.playerCount;
		this.YigdwiengFaQiHELkjuVSOfzqvWDb = this.QpbkOybHtOJtqrCubyZPOSZJujfo - 1;
		this.IMtaSMhYebFuYOireReApzgsJuYH = new Player[this.YigdwiengFaQiHELkjuVSOfzqvWDb];
		this.almzxXuwuHtFoPlUqErrhOUvEYtA = new Player[this.QpbkOybHtOJtqrCubyZPOSZJujfo];
		IList<Player_Editor> list = ReInput.UserData.VnvGwsIqlyaVDfkMStriDwUKMMSo;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Player_Editor player_Editor = list[i];
			OdwwNwDVsLLbukoEpkWRZpETNEYi odwwNwDVsLLbukoEpkWRZpETNEYi = player_Editor.eAGuRMxClukjwqFIajUiWCwxmMrr();
			ControllerMapLayoutManager.YuRWKBhEFGtHaIyXShqNamLdASyj yuRWKBhEFGtHaIyXShqNamLdASyj = player_Editor.controllerMapLayoutManagerSettings.MffSkaAdYbkTCWPcYqvQvoYPYQEM();
			ControllerMapEnabler.YqpaJJElEihfpIGutrHkMZgMkOuC yqpaJJElEihfpIGutrHkMZgMkOuC = player_Editor.controllerMapEnablerSettings.UwSBwFEfWdPEWLuRzfwLiSlyNNkXA();
			Player player;
			if (i == 0)
			{
				player = new Player(true, 9999999, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, odwwNwDVsLLbukoEpkWRZpETNEYi, yuRWKBhEFGtHaIyXShqNamLdASyj, yqpaJJElEihfpIGutrHkMZgMkOuC);
				this.FCzBYZnzCagnbxAcTYHtBBnnoGEA = player;
			}
			else
			{
				player = new Player(false, i - 1, player_Editor.name, player_Editor.descriptiveName, player_Editor.key, odwwNwDVsLLbukoEpkWRZpETNEYi, yuRWKBhEFGtHaIyXShqNamLdASyj, yqpaJJElEihfpIGutrHkMZgMkOuC);
				this.IMtaSMhYebFuYOireReApzgsJuYH[i - 1] = player;
			}
			this.almzxXuwuHtFoPlUqErrhOUvEYtA[i] = player;
			player.isPlaying = player_Editor.startPlaying;
			player.controllers.hasMouse = player_Editor.assignMouseOnStart;
			player.controllers.hasKeyboard = player_Editor.assignKeyboardOnStart;
			player.controllers.excludeFromControllerAutoAssignment = player_Editor.excludeFromControllerAutoAssignment;
			player.controllers.maps.OWbhytsFSgGBTJhNRHnpnYugjwSjA(true);
			player.controllers.maps.YyYGTEVcuixmjnDUgDCagYJBERPJ(true);
		}
		this.RiXbzlqsCAwEBBuJWcwRrOgRnoVJ = new ReadOnlyCollection<Player>(this.IMtaSMhYebFuYOireReApzgsJuYH);
		this.TuEaWuQmKEGkxGZcBHcBQEXJaCov = new ReadOnlyCollection<Player>(this.almzxXuwuHtFoPlUqErrhOUvEYtA);
		this.AlXEdacLaEeQdYLxqYfNLfHkpECzA = true;
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x00044E50 File Offset: 0x00043050
	public void qabCvhFfRVAbFBXdoWaKxrEYQhcCb(Joystick A_1)
	{
		if (ReInput.controllerAssigner != null && ReInput.controllerAssigner.CanHandleAssignment(ControllerType.Joystick, A_1))
		{
			ReInput.controllerAssigner.AssignController(ControllerType.Joystick, A_1);
			return;
		}
		if (this.NoJZePDALgPWrNIAzCaoDrzTCULy.reassignJoystickToPreviousOwnerOnReconnect && this.WKCKKireAFphDdicysbQgfYVgFVg(A_1))
		{
			return;
		}
		this.YToUADrRyAowygTSbTqTLdaDNFQM(A_1);
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x00009E03 File Offset: 0x00008003
	public void JWTHzoGqaqFNnEnQRNBarHDNkbPM(Joystick A_1)
	{
		if (this.NoJZePDALgPWrNIAzCaoDrzTCULy.autoAssignJoysticks)
		{
			this.qabCvhFfRVAbFBXdoWaKxrEYQhcCb(A_1);
		}
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x00044EA0 File Offset: 0x000430A0
	public void RrSZCqIrqRKxMlwstGHQNbGSLBhP(ControllerType A_1, int A_2)
	{
		for (int i = 0; i < this.QpbkOybHtOJtqrCubyZPOSZJujfo; i++)
		{
			this.almzxXuwuHtFoPlUqErrhOUvEYtA[i].controllers.RemoveController(A_1, A_2);
		}
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x00044ED4 File Offset: 0x000430D4
	public Player VtObDEzKPQDiJEMzgQRElYBEdxnC(int A_1)
	{
		if (A_1 != 9999999 && (A_1 < 0 || A_1 >= this.YigdwiengFaQiHELkjuVSOfzqvWDb))
		{
			Logger.LogError("Player id " + A_1.ToString() + " does not exist!");
			return null;
		}
		if (A_1 == 9999999)
		{
			return this.FCzBYZnzCagnbxAcTYHtBBnnoGEA;
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			if (this.IMtaSMhYebFuYOireReApzgsJuYH[i].id == A_1)
			{
				return this.IMtaSMhYebFuYOireReApzgsJuYH[A_1];
			}
		}
		return null;
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x00044F50 File Offset: 0x00043150
	public Player lRETGPFimkLNbkfSorwbdoMJsGyy(string A_1)
	{
		if (A_1 != null && !(A_1 == string.Empty))
		{
			if (this.FCzBYZnzCagnbxAcTYHtBBnnoGEA.name.Equals(A_1, StringComparison.OrdinalIgnoreCase))
			{
				return this.FCzBYZnzCagnbxAcTYHtBBnnoGEA;
			}
			for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
			{
				if (this.IMtaSMhYebFuYOireReApzgsJuYH[i].name.Equals(A_1, StringComparison.OrdinalIgnoreCase))
				{
					return this.IMtaSMhYebFuYOireReApzgsJuYH[i];
				}
			}
		}
		Logger.LogError("Player \"" + A_1 + "\" does not exist!");
		return null;
	}

	// Token: 0x0600099C RID: 2460 RVA: 0x00009E19 File Offset: 0x00008019
	public Player CrofyrlIxqANhJbwPluHBcmsknBDA()
	{
		return this.FCzBYZnzCagnbxAcTYHtBBnnoGEA;
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x00044FD0 File Offset: 0x000431D0
	public int KXOOhBhWyaHEcTacjEIxgvFMxWUIA(string A_1)
	{
		if (A_1 == null || A_1 == string.Empty)
		{
			return -1;
		}
		if (this.FCzBYZnzCagnbxAcTYHtBBnnoGEA.name.Equals(A_1, StringComparison.OrdinalIgnoreCase))
		{
			return 9999999;
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			if (this.IMtaSMhYebFuYOireReApzgsJuYH[i].name.Equals(A_1, StringComparison.OrdinalIgnoreCase))
			{
				return this.IMtaSMhYebFuYOireReApzgsJuYH[i].id;
			}
		}
		return -1;
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x00009E21 File Offset: 0x00008021
	public bool RamDiehjEOsqlHkjvlHizdCmdptu(int A_1)
	{
		return A_1 == 9999999 || (A_1 >= 0 && A_1 < this.YigdwiengFaQiHELkjuVSOfzqvWDb);
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x00045040 File Offset: 0x00043240
	public Player[] LPPjwpbwvNCqgRMjhISSKpgiqwuGb(bool A_1)
	{
		int num = this.YigdwiengFaQiHELkjuVSOfzqvWDb;
		if (A_1)
		{
			num++;
		}
		Player[] array = new Player[num];
		int num2 = 0;
		if (A_1)
		{
			array[0] = this.FCzBYZnzCagnbxAcTYHtBBnnoGEA;
			num2 = 1;
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			array[num2 + i] = this.IMtaSMhYebFuYOireReApzgsJuYH[i];
		}
		return array;
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x00045094 File Offset: 0x00043294
	public string[] ULWFuGgyUhfvuPexOLaZJTMXwgDR(bool A_1)
	{
		int num = this.YigdwiengFaQiHELkjuVSOfzqvWDb;
		if (A_1)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (A_1)
		{
			array[0] = this.FCzBYZnzCagnbxAcTYHtBBnnoGEA.name;
			num2 = 1;
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			array[num2 + i] = this.IMtaSMhYebFuYOireReApzgsJuYH[i].name;
		}
		return array;
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x000450F0 File Offset: 0x000432F0
	public string[] hVMWidhRlDUKCvWmiNWFthbpqmRQ(bool A_1)
	{
		int num = this.YigdwiengFaQiHELkjuVSOfzqvWDb;
		if (A_1)
		{
			num++;
		}
		string[] array = new string[num];
		int num2 = 0;
		if (A_1)
		{
			array[0] = this.FCzBYZnzCagnbxAcTYHtBBnnoGEA.descriptiveName;
			num2 = 1;
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			array[num2 + i] = this.IMtaSMhYebFuYOireReApzgsJuYH[i].descriptiveName;
		}
		return array;
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x0004514C File Offset: 0x0004334C
	public int[] DYxdsTjKBypkMwzFTuqBNpYAhDsyA(bool A_1)
	{
		int num = this.YigdwiengFaQiHELkjuVSOfzqvWDb;
		if (A_1)
		{
			num++;
		}
		int[] array = new int[num];
		int num2 = 0;
		if (A_1)
		{
			array[0] = this.FCzBYZnzCagnbxAcTYHtBBnnoGEA.id;
			num2 = 1;
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			array[num2 + i] = this.IMtaSMhYebFuYOireReApzgsJuYH[i].id;
		}
		return array;
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x00009E3B File Offset: 0x0000803B
	public bool aYJyshoOZFtbwWFeZFUfIDZULnHs(Controller A_1)
	{
		return A_1 != null && this.almzxXuwuHtFoPlUqErrhOUvEYtA != null && this.DpFQGzmABmUazBuBIipaVjNmMoth(A_1.type, A_1.id);
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x000451A8 File Offset: 0x000433A8
	public bool DpFQGzmABmUazBuBIipaVjNmMoth(ControllerType A_1, int A_2)
	{
		if (this.almzxXuwuHtFoPlUqErrhOUvEYtA == null)
		{
			return false;
		}
		for (int i = 0; i < this.almzxXuwuHtFoPlUqErrhOUvEYtA.Length; i++)
		{
			if (this.almzxXuwuHtFoPlUqErrhOUvEYtA[i].controllers.ContainsController(A_1, A_2))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x000451EC File Offset: 0x000433EC
	public bool IfifcUKcfcMLWhZCYyHubkLJSindA(ControllerType A_1, int A_2, int A_3)
	{
		Player player = this.VtObDEzKPQDiJEMzgQRElYBEdxnC(A_3);
		return player != null && player.controllers.ContainsController(A_1, A_2);
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x00045214 File Offset: 0x00043414
	public void RsHCABcOGkNIxblqccIENfEGykei(Controller A_1, bool A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_2)
		{
			this.FCzBYZnzCagnbxAcTYHtBBnnoGEA.controllers.RemoveController(A_1);
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			this.IMtaSMhYebFuYOireReApzgsJuYH[i].controllers.RemoveController(A_1);
		}
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x00045260 File Offset: 0x00043460
	public void LeVLiaSHvzNHfQZcaIDuTAZmmAHn(ControllerType A_1, int A_2, bool A_3)
	{
		Controller controller = ReInput.controllers.GetController(A_1, A_2);
		if (controller == null)
		{
			return;
		}
		this.RsHCABcOGkNIxblqccIENfEGykei(controller, A_3);
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x00045288 File Offset: 0x00043488
	public bool yzLgeXRxlRJhmFZBssllRFLyTOVk(Joystick A_1)
	{
		if (A_1 == null || this.almzxXuwuHtFoPlUqErrhOUvEYtA == null)
		{
			return false;
		}
		for (int i = 0; i < this.almzxXuwuHtFoPlUqErrhOUvEYtA.Length; i++)
		{
			if (this.almzxXuwuHtFoPlUqErrhOUvEYtA[i].controllers.ContainsController(A_1))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x000452D0 File Offset: 0x000434D0
	public bool ISPgKPbyYPzszapriHefSnimqxWB(int A_1)
	{
		if (this.almzxXuwuHtFoPlUqErrhOUvEYtA == null)
		{
			return false;
		}
		for (int i = 0; i < this.almzxXuwuHtFoPlUqErrhOUvEYtA.Length; i++)
		{
			if (this.almzxXuwuHtFoPlUqErrhOUvEYtA[i].controllers.ContainsController(ControllerType.Joystick, A_1))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x00045314 File Offset: 0x00043514
	public bool XcfhDOlkHOoqAxJGQxQwkfCaghRD(int A_1, int A_2)
	{
		Player player = this.VtObDEzKPQDiJEMzgQRElYBEdxnC(A_2);
		return player != null && player.controllers.ContainsController(ControllerType.Joystick, A_1);
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x0004533C File Offset: 0x0004353C
	public void QjgbpCWadEQsCfQbSSyOniOuodpO(Joystick A_1, bool A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_2)
		{
			this.FCzBYZnzCagnbxAcTYHtBBnnoGEA.controllers.ARpcVSpEarBEKjFbBWSySbFNiYfM(A_1);
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			this.IMtaSMhYebFuYOireReApzgsJuYH[i].controllers.ARpcVSpEarBEKjFbBWSySbFNiYfM(A_1);
		}
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x00045388 File Offset: 0x00043588
	public void IlzvgtmlLiIVKgCNyYHeocyqmZFdA(int A_1, bool A_2)
	{
		Joystick joystick = ReInput.controllers.GetJoystick(A_1);
		if (joystick == null)
		{
			return;
		}
		this.QjgbpCWadEQsCfQbSSyOniOuodpO(joystick, A_2);
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x00045288 File Offset: 0x00043488
	public bool kAvoSCzfCsNLdTqqEnCDNdkRUODo(CustomController A_1)
	{
		if (A_1 == null || this.almzxXuwuHtFoPlUqErrhOUvEYtA == null)
		{
			return false;
		}
		for (int i = 0; i < this.almzxXuwuHtFoPlUqErrhOUvEYtA.Length; i++)
		{
			if (this.almzxXuwuHtFoPlUqErrhOUvEYtA[i].controllers.ContainsController(A_1))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x000453B0 File Offset: 0x000435B0
	public bool aKgtusqiGreqehokPmuAaMwfuhwyB(int A_1)
	{
		if (this.almzxXuwuHtFoPlUqErrhOUvEYtA == null)
		{
			return false;
		}
		for (int i = 0; i < this.almzxXuwuHtFoPlUqErrhOUvEYtA.Length; i++)
		{
			if (this.almzxXuwuHtFoPlUqErrhOUvEYtA[i].controllers.ContainsController(ControllerType.Custom, A_1))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x000453F4 File Offset: 0x000435F4
	public bool qMfksFffzlWSrLZQwqVBOVUVmMIr(int A_1, int A_2)
	{
		Player player = this.VtObDEzKPQDiJEMzgQRElYBEdxnC(A_2);
		return player != null && player.controllers.ContainsController(ControllerType.Custom, A_1);
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x0004541C File Offset: 0x0004361C
	public void bbgcubmRRibMMbayJOioQEvhIKHUA(CustomController A_1, bool A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_2)
		{
			this.FCzBYZnzCagnbxAcTYHtBBnnoGEA.controllers.mrEeOPDTcljdFyiTyOYQbldchzEJB(A_1);
		}
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			this.IMtaSMhYebFuYOireReApzgsJuYH[i].controllers.mrEeOPDTcljdFyiTyOYQbldchzEJB(A_1);
		}
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x00045468 File Offset: 0x00043668
	public void doizVeJvUuDmRiPKpCrPADfyEFaeb(int A_1, bool A_2)
	{
		CustomController customController = ReInput.controllers.GetCustomController(A_1);
		if (customController == null)
		{
			return;
		}
		this.bbgcubmRRibMMbayJOioQEvhIKHUA(customController, A_2);
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x00045490 File Offset: 0x00043690
	private bool WKCKKireAFphDdicysbQgfYVgFVg(Joystick A_1)
	{
		if (this.NoJZePDALgPWrNIAzCaoDrzTCULy.distributeJoysticksEvenly)
		{
			int num = this.vYXuMvzxIcwzESpVJOFZdgJuYcu();
			if (num < 0)
			{
				return false;
			}
			int num2 = this.IpeJnkndHNXnwgVvApIamEHaDyTDA(A_1.id);
			if (num2 < 0)
			{
				return false;
			}
			Player player = this.IMtaSMhYebFuYOireReApzgsJuYH[num];
			Player player2 = this.IMtaSMhYebFuYOireReApzgsJuYH[num2];
			if (num2 >= 0 && player2.controllers.joystickCount <= player.controllers.joystickCount)
			{
				this.IMtaSMhYebFuYOireReApzgsJuYH[num2].controllers.tDAgZZdWZkhWALHWlMkKACBYvIMxA(A_1, true);
				return true;
			}
			return false;
		}
		else
		{
			int num3 = this.IpeJnkndHNXnwgVvApIamEHaDyTDA(A_1.id);
			if (num3 < 0)
			{
				return false;
			}
			this.IMtaSMhYebFuYOireReApzgsJuYH[num3].controllers.tDAgZZdWZkhWALHWlMkKACBYvIMxA(A_1, true);
			return true;
		}
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x0004553C File Offset: 0x0004373C
	private bool YToUADrRyAowygTSbTqTLdaDNFQM(Joystick A_1)
	{
		if (this.NoJZePDALgPWrNIAzCaoDrzTCULy.distributeJoysticksEvenly)
		{
			int num = this.vYXuMvzxIcwzESpVJOFZdgJuYcu();
			if (num >= 0)
			{
				this.IMtaSMhYebFuYOireReApzgsJuYH[num].controllers.tDAgZZdWZkhWALHWlMkKACBYvIMxA(A_1, true);
				return true;
			}
		}
		else
		{
			for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
			{
				Player player = this.IMtaSMhYebFuYOireReApzgsJuYH[i];
				if (!player.controllers.excludeFromControllerAutoAssignment && (!this.NoJZePDALgPWrNIAzCaoDrzTCULy.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < this.NoJZePDALgPWrNIAzCaoDrzTCULy.maxJoysticksPerPlayer)
				{
					player.controllers.tDAgZZdWZkhWALHWlMkKACBYvIMxA(A_1, true);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x000455DC File Offset: 0x000437DC
	private int vYXuMvzxIcwzESpVJOFZdgJuYcu()
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			Player player = this.IMtaSMhYebFuYOireReApzgsJuYH[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!this.NoJZePDALgPWrNIAzCaoDrzTCULy.assignJoysticksToPlayingPlayersOnly || player.isPlaying))
			{
				int joystickCount = player.controllers.joystickCount;
				if (joystickCount < this.NoJZePDALgPWrNIAzCaoDrzTCULy.maxJoysticksPerPlayer && (num == -1 || joystickCount < num2))
				{
					num = i;
					num2 = joystickCount;
				}
			}
		}
		return num;
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x00045654 File Offset: 0x00043854
	public int IpeJnkndHNXnwgVvApIamEHaDyTDA(int A_1)
	{
		int num = -1;
		double num2 = 0.0;
		for (int i = 0; i < this.YigdwiengFaQiHELkjuVSOfzqvWDb; i++)
		{
			Player player = this.IMtaSMhYebFuYOireReApzgsJuYH[i];
			if (!player.controllers.excludeFromControllerAutoAssignment && (!this.NoJZePDALgPWrNIAzCaoDrzTCULy.assignJoysticksToPlayingPlayersOnly || player.isPlaying) && player.controllers.joystickCount < this.NoJZePDALgPWrNIAzCaoDrzTCULy.maxJoysticksPerPlayer)
			{
				double num3 = player.controllers.qxSrkVvSCvgYILRCONorjaDykjsj(A_1);
				if (num3 >= 0.0 && (num < 0 || num3 > num2))
				{
					num2 = num3;
					num = i;
				}
			}
		}
		return num;
	}

	// Token: 0x0400072F RID: 1839
	private int YigdwiengFaQiHELkjuVSOfzqvWDb;

	// Token: 0x04000730 RID: 1840
	private int QpbkOybHtOJtqrCubyZPOSZJujfo;

	// Token: 0x04000731 RID: 1841
	private Player FCzBYZnzCagnbxAcTYHtBBnnoGEA;

	// Token: 0x04000732 RID: 1842
	private Player[] almzxXuwuHtFoPlUqErrhOUvEYtA;

	// Token: 0x04000733 RID: 1843
	private Player[] IMtaSMhYebFuYOireReApzgsJuYH;

	// Token: 0x04000734 RID: 1844
	private IList<Player> RiXbzlqsCAwEBBuJWcwRrOgRnoVJ;

	// Token: 0x04000735 RID: 1845
	private IList<Player> TuEaWuQmKEGkxGZcBHcBQEXJaCov;

	// Token: 0x04000736 RID: 1846
	private ConfigVars NoJZePDALgPWrNIAzCaoDrzTCULy;

	// Token: 0x04000737 RID: 1847
	private bool AlXEdacLaEeQdYLxqYfNLfHkpECzA;
}
