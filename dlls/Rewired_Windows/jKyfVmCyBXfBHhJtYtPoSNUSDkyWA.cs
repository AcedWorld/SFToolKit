using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

// Token: 0x02000003 RID: 3
internal class jKyfVmCyBXfBHhJtYtPoSNUSDkyWA : ISteamControllerInternal
{
	// Token: 0x0600000C RID: 12 RVA: 0x00011212 File Offset: 0x0000F412
	public static void IxmolosUQVJvPgZRTwIppMFVYDnL(Dictionary<string, ulong> A_0)
	{
		if (A_0 == null || A_0.Count == 0)
		{
			return;
		}
		jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.iptJgBMovzcNuocjBhXwfkKWalgUA = A_0;
		jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.CdaeYvhHlgvhemepQOqTIeJNimqZ = CollectionTools.CreateInverseDictionary<string, ulong>(A_0);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00011231 File Offset: 0x0000F431
	public static void fydfxuwDmOJlptkBgGJocBYfdzKbA(Dictionary<string, ulong> A_0)
	{
		if (A_0 == null || A_0.Count == 0)
		{
			return;
		}
		jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.RnueHLTNeullxjEEuvPCAloovVni = A_0;
		jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.mnyXmUQAWUPOlKLmDFlvQRaEqRto = CollectionTools.CreateInverseDictionary<string, ulong>(A_0);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00011250 File Offset: 0x0000F450
	public static void QhmKVkXtugIeyFOthrAhzymVgUuQ(Dictionary<string, ulong> A_0)
	{
		if (A_0 == null || A_0.Count == 0)
		{
			return;
		}
		jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.YHzDEoiZJnNZZozcWXYUFMeSXJfY = A_0;
		jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.UGdlDVndXDfSazZuychDXMBhFLUfA = CollectionTools.CreateInverseDictionary<string, ulong>(A_0);
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0001126F File Offset: 0x0000F46F
	public jKyfVmCyBXfBHhJtYtPoSNUSDkyWA(ulong A_1)
	{
		this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb = A_1;
		this.UkOwdlrQuYYnPHHuQddIQOEVxRlC = new bJUVkvzXoNEadjTNezJhuTBmVZtd[8L];
		this.ZxZpBywLDHtRrNOCZRzgmhpADHLA = new List<SteamControllerActionOrigin>(8);
		this.xhMpjPIybkwRcKkKLNOvFIevBBM = new ReadOnlyCollection<SteamControllerActionOrigin>(this.ZxZpBywLDHtRrNOCZRzgmhpADHLA);
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000010 RID: 16 RVA: 0x000112A9 File Offset: 0x0000F4A9
	public int MaxActionSourceCount
	{
		get
		{
			return 8;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000011 RID: 17 RVA: 0x000112AC File Offset: 0x0000F4AC
	public bool IsConnected
	{
		get
		{
			return igMeshIFQwRCOdomrcpnYroKsaVfA.xdMiZSAlmWRtUvBuwVSNcRMQCDnB(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb);
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000112B9 File Offset: 0x0000F4B9
	public string GetActionSetName(ulong handle)
	{
		return this.hxzKHAjfEjIrtzWvWRPrJeRGRxPQ(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.CdaeYvhHlgvhemepQOqTIeJNimqZ, handle);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000112C7 File Offset: 0x0000F4C7
	public string GetDigitalActionName(ulong handle)
	{
		return this.hxzKHAjfEjIrtzWvWRPrJeRGRxPQ(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.UGdlDVndXDfSazZuychDXMBhFLUfA, handle);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000112D5 File Offset: 0x0000F4D5
	public string GetAnalogActionName(ulong handle)
	{
		return this.hxzKHAjfEjIrtzWvWRPrJeRGRxPQ(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.mnyXmUQAWUPOlKLmDFlvQRaEqRto, handle);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x000112E3 File Offset: 0x0000F4E3
	public ulong GetActionSetHandle(ref string actionSetName)
	{
		return this.LbxDvKliyqZRZiATteXyAFVaAqgbb(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.iptJgBMovzcNuocjBhXwfkKWalgUA, ref actionSetName);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000112F1 File Offset: 0x0000F4F1
	public ulong GetDigitalActionHandle(ref string actionName)
	{
		return this.LbxDvKliyqZRZiATteXyAFVaAqgbb(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.YHzDEoiZJnNZZozcWXYUFMeSXJfY, ref actionName);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000112FF File Offset: 0x0000F4FF
	public ulong GetAnalogActionHandle(ref string actionName)
	{
		return this.LbxDvKliyqZRZiATteXyAFVaAqgbb(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.RnueHLTNeullxjEEuvPCAloovVni, ref actionName);
	}

	// Token: 0x06000018 RID: 24 RVA: 0x0001D740 File Offset: 0x0001B940
	public Vector2 GetAnalogActionValue(ulong actionHandle)
	{
		Vector2 vector;
		if (actionHandle == 0UL)
		{
			vector = default(Vector2);
			return vector;
		}
		try
		{
			swQMZLxdbsYOQnnQpAWoDReYNugd swQMZLxdbsYOQnnQpAWoDReYNugd = igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.QxwBdpzJboZUYzJVglbGFDKseBfg(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb, actionHandle);
			if (!swQMZLxdbsYOQnnQpAWoDReYNugd.LGbCcldNpfeEDFgqewOcksDnZrmPb)
			{
				vector = default(Vector2);
				vector = vector;
			}
			else
			{
				vector = new Vector2(swQMZLxdbsYOQnnQpAWoDReYNugd.aLvhBXkFDoMiKtcZIWLPBrigRizt, swQMZLxdbsYOQnnQpAWoDReYNugd.QXXwhzAqVALTxRKcjNPzQynWUOuJ);
			}
		}
		catch
		{
			vector = default(Vector2);
		}
		return vector;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x0001D7B4 File Offset: 0x0001B9B4
	public Vector2 GetAnalogActionValue(ref string actionName)
	{
		ulong analogActionHandle = this.GetAnalogActionHandle(ref actionName);
		return this.GetAnalogActionValue(analogActionHandle);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x0001D7D0 File Offset: 0x0001B9D0
	public bool GetDigitalActionValue(ulong actionHandle)
	{
		if (actionHandle == 0UL)
		{
			return false;
		}
		bool result;
		try
		{
			XovJSEnkbRZCoMFaTjOuGVjoTtvdA xovJSEnkbRZCoMFaTjOuGVjoTtvdA = igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.ApJBKVHgDkhrGZnLQVIyZKGKwMvG(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb, actionHandle);
			Debug.Log(string.Concat(new string[]
			{
				actionHandle.ToString(),
				" state = ",
				xovJSEnkbRZCoMFaTjOuGVjoTtvdA.VyBGstUxYsVkigWABMpAhrKrtDGF.ToString(),
				" active = ",
				xovJSEnkbRZCoMFaTjOuGVjoTtvdA.aJQoUcJQrVZCILwboxBvGerINaFj.ToString()
			}));
			result = (xovJSEnkbRZCoMFaTjOuGVjoTtvdA.aJQoUcJQrVZCILwboxBvGerINaFj && xovJSEnkbRZCoMFaTjOuGVjoTtvdA.VyBGstUxYsVkigWABMpAhrKrtDGF);
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x0001D868 File Offset: 0x0001BA68
	public bool GetDigitalActionValue(ref string actionName)
	{
		ulong digitalActionHandle = this.GetDigitalActionHandle(ref actionName);
		return this.GetDigitalActionValue(digitalActionHandle);
	}

	// Token: 0x0600001C RID: 28 RVA: 0x0001D884 File Offset: 0x0001BA84
	public bool SetActiveActionSet(ulong actionSetHandle)
	{
		if (actionSetHandle == 0UL)
		{
			return false;
		}
		bool result;
		try
		{
			igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.zCzMwFTudiicNwkWEVGpwyqZgMHC(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb, actionSetHandle);
			result = true;
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0001D8C4 File Offset: 0x0001BAC4
	public bool SetActiveActionSet(ref string actionSetName)
	{
		ulong actionSetHandle = this.GetActionSetHandle(ref actionSetName);
		return this.SetActiveActionSet(actionSetHandle);
	}

	// Token: 0x0600001E RID: 30 RVA: 0x0001130D File Offset: 0x0000F50D
	public ulong GetActiveActionSetHandle()
	{
		return igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.BfVWaqVvAFoGiokGkofvOkdYfIPH(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb);
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0001131F File Offset: 0x0000F51F
	public string GetActiveActionSetName()
	{
		return this.hxzKHAjfEjIrtzWvWRPrJeRGRxPQ(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.CdaeYvhHlgvhemepQOqTIeJNimqZ, igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.BfVWaqVvAFoGiokGkofvOkdYfIPH(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb));
	}

	// Token: 0x06000020 RID: 32 RVA: 0x0001133C File Offset: 0x0000F53C
	public void ShowBindingPanel()
	{
		igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.BgeuGuPbAtEatxphNevzSmvBGemv(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb);
	}

	// Token: 0x06000021 RID: 33 RVA: 0x0001134F File Offset: 0x0000F54F
	public void SetHapticPulse(SteamControllerPadType triggerPad, float durationSeconds)
	{
		if (durationSeconds < 0f)
		{
			durationSeconds = 0f;
		}
		igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.dntxxxIVeYTabpVabdguPYpUEeLu(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb, (uint)triggerPad, (ushort)(durationSeconds * 1000000f));
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00011379 File Offset: 0x0000F579
	public void SetHapticPulse(SteamControllerPadType triggerPad, ushort durationMicroSeconds)
	{
		igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.dntxxxIVeYTabpVabdguPYpUEeLu(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb, (uint)triggerPad, durationMicroSeconds);
	}

	// Token: 0x06000023 RID: 35 RVA: 0x0001138D File Offset: 0x0000F58D
	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ref string actionSetName, ref string actionName)
	{
		return this.GetDigitalActionOrigins(this.LbxDvKliyqZRZiATteXyAFVaAqgbb(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.iptJgBMovzcNuocjBhXwfkKWalgUA, ref actionSetName), this.LbxDvKliyqZRZiATteXyAFVaAqgbb(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.YHzDEoiZJnNZZozcWXYUFMeSXJfY, ref actionName));
	}

	// Token: 0x06000024 RID: 36 RVA: 0x0001D8E0 File Offset: 0x0001BAE0
	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		this.ZxZpBywLDHtRrNOCZRzgmhpADHLA.Clear();
		if (actionSetHandle == 0UL || actionHandle == 0UL)
		{
			return this.xhMpjPIybkwRcKkKLNOvFIevBBM;
		}
		int num = igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.ZhfHEllpCapRScXlRFUltdjMyzpL(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb, actionSetHandle, actionHandle, this.UkOwdlrQuYYnPHHuQddIQOEVxRlC);
		for (int i = 0; i < num; i++)
		{
			this.ZxZpBywLDHtRrNOCZRzgmhpADHLA.Add((SteamControllerActionOrigin)this.UkOwdlrQuYYnPHHuQddIQOEVxRlC[i]);
		}
		return this.xhMpjPIybkwRcKkKLNOvFIevBBM;
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000113AD File Offset: 0x0000F5AD
	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ref string actionSetName, ref string actionName)
	{
		return this.GetAnalogActionOrigins(this.LbxDvKliyqZRZiATteXyAFVaAqgbb(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.iptJgBMovzcNuocjBhXwfkKWalgUA, ref actionSetName), this.LbxDvKliyqZRZiATteXyAFVaAqgbb(jKyfVmCyBXfBHhJtYtPoSNUSDkyWA.RnueHLTNeullxjEEuvPCAloovVni, ref actionName));
	}

	// Token: 0x06000026 RID: 38 RVA: 0x0001D944 File Offset: 0x0001BB44
	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		this.ZxZpBywLDHtRrNOCZRzgmhpADHLA.Clear();
		if (actionSetHandle == 0UL || actionHandle == 0UL)
		{
			return this.xhMpjPIybkwRcKkKLNOvFIevBBM;
		}
		int num = igMeshIFQwRCOdomrcpnYroKsaVfA.YyPozqtWNZBhWpBUuVmVDPniiLhV.CdOoBMUKqnCXUzbyAdVfwFItSjmI(this.BUCjNOoHFoEGjKMpshUnwCHxaDyAb, actionSetHandle, actionHandle, this.UkOwdlrQuYYnPHHuQddIQOEVxRlC);
		for (int i = 0; i < num; i++)
		{
			this.ZxZpBywLDHtRrNOCZRzgmhpADHLA.Add((SteamControllerActionOrigin)this.UkOwdlrQuYYnPHHuQddIQOEVxRlC[i]);
		}
		return this.xhMpjPIybkwRcKkKLNOvFIevBBM;
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0001D9A8 File Offset: 0x0001BBA8
	private ulong LbxDvKliyqZRZiATteXyAFVaAqgbb(Dictionary<string, ulong> A_1, ref string A_2)
	{
		if (A_1 == null || string.IsNullOrEmpty(A_2))
		{
			return 0UL;
		}
		ulong result;
		if (!A_1.TryGetValue(A_2, out result))
		{
			return 0UL;
		}
		return result;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x0001D9D4 File Offset: 0x0001BBD4
	private string hxzKHAjfEjIrtzWvWRPrJeRGRxPQ(Dictionary<ulong, string> A_1, ulong A_2)
	{
		if (A_1 == null || A_2 == 0UL)
		{
			return string.Empty;
		}
		string result;
		if (!A_1.TryGetValue(A_2, out result))
		{
			return string.Empty;
		}
		return result;
	}

	// Token: 0x04000005 RID: 5
	private static Dictionary<string, ulong> iptJgBMovzcNuocjBhXwfkKWalgUA;

	// Token: 0x04000006 RID: 6
	private static Dictionary<string, ulong> RnueHLTNeullxjEEuvPCAloovVni;

	// Token: 0x04000007 RID: 7
	private static Dictionary<string, ulong> YHzDEoiZJnNZZozcWXYUFMeSXJfY;

	// Token: 0x04000008 RID: 8
	private static Dictionary<ulong, string> CdaeYvhHlgvhemepQOqTIeJNimqZ;

	// Token: 0x04000009 RID: 9
	private static Dictionary<ulong, string> mnyXmUQAWUPOlKLmDFlvQRaEqRto;

	// Token: 0x0400000A RID: 10
	private static Dictionary<ulong, string> UGdlDVndXDfSazZuychDXMBhFLUfA;

	// Token: 0x0400000B RID: 11
	public readonly ulong BUCjNOoHFoEGjKMpshUnwCHxaDyAb;

	// Token: 0x0400000C RID: 12
	private bJUVkvzXoNEadjTNezJhuTBmVZtd[] UkOwdlrQuYYnPHHuQddIQOEVxRlC;

	// Token: 0x0400000D RID: 13
	private List<SteamControllerActionOrigin> ZxZpBywLDHtRrNOCZRzgmhpADHLA;

	// Token: 0x0400000E RID: 14
	private ReadOnlyCollection<SteamControllerActionOrigin> xhMpjPIybkwRcKkKLNOvFIevBBM;
}
