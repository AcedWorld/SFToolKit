using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

// Token: 0x0200015B RID: 347
internal static class PElXlTeNHdmaGaVXQsgwGeCoDukhA
{
	// Token: 0x14000022 RID: 34
	// (add) Token: 0x06000B61 RID: 2913 RVA: 0x0003DA2C File Offset: 0x0003BC2C
	// (remove) Token: 0x06000B62 RID: 2914 RVA: 0x0003DA60 File Offset: 0x0003BC60
	public static event EventHandler<ucGBOyjwQWMFcpXHOBVLYsurivbvA> zrpeJnfDwJIMcIrFgaEfgTqkNtBC;

	// Token: 0x14000023 RID: 35
	// (add) Token: 0x06000B63 RID: 2915 RVA: 0x0003DA94 File Offset: 0x0003BC94
	// (remove) Token: 0x06000B64 RID: 2916 RVA: 0x0003DAC8 File Offset: 0x0003BCC8
	public static event EventHandler<ucGBOyjwQWMFcpXHOBVLYsurivbvA> wAhjIdjxYbLYpPTgmFwxdxSxZNUn;

	// Token: 0x06000B65 RID: 2917 RVA: 0x00017F24 File Offset: 0x00016124
	static PElXlTeNHdmaGaVXQsgwGeCoDukhA()
	{
		AppDomain.CurrentDomain.DomainUnload += PElXlTeNHdmaGaVXQsgwGeCoDukhA.NKjfhSJPFIhVrkLeEjsoiSCKSZDA;
		AppDomain.CurrentDomain.ProcessExit += PElXlTeNHdmaGaVXQsgwGeCoDukhA.NKjfhSJPFIhVrkLeEjsoiSCKSZDA;
	}

	// Token: 0x06000B66 RID: 2918 RVA: 0x0003DAFC File Offset: 0x0003BCFC
	private static void NKjfhSJPFIhVrkLeEjsoiSCKSZDA(object A_0, EventArgs A_1)
	{
		if (RqddSrepHsEMwIuLAuLiJJkwDNeN.szEWuIcYNFfbPvkFEkBHjoCbAiBp)
		{
			string value = PElXlTeNHdmaGaVXQsgwGeCoDukhA.XvdEeceDotbisKLZXUeeWNQNBTxU();
			if (!string.IsNullOrEmpty(value))
			{
				Console.WriteLine(value);
			}
		}
	}

	// Token: 0x170001F1 RID: 497
	// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0003DB24 File Offset: 0x0003BD24
	private static Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> aFIDDSoKMDQkXWUBNpaPozTFZjLj
	{
		get
		{
			Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> result;
			if (RqddSrepHsEMwIuLAuLiJJkwDNeN.RsHAPtBsSykNCOLxasflPeJriHFFA)
			{
				if (PElXlTeNHdmaGaVXQsgwGeCoDukhA.tSpaZfCIphTKKFDkfNRTuBvHhVuu == null)
				{
					PElXlTeNHdmaGaVXQsgwGeCoDukhA.tSpaZfCIphTKKFDkfNRTuBvHhVuu = new Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>>(qMVbwuihHnGurDXvaDfqecGAOKEEe.TSxzSLbhUehTfHSNGHyLCRKBeIHHA);
				}
				result = PElXlTeNHdmaGaVXQsgwGeCoDukhA.tSpaZfCIphTKKFDkfNRTuBvHhVuu;
			}
			else
			{
				if (PElXlTeNHdmaGaVXQsgwGeCoDukhA.rXKetUBgyZmSgQxocotBhWnUXraEA == null)
				{
					PElXlTeNHdmaGaVXQsgwGeCoDukhA.rXKetUBgyZmSgQxocotBhWnUXraEA = new Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>>(qMVbwuihHnGurDXvaDfqecGAOKEEe.TSxzSLbhUehTfHSNGHyLCRKBeIHHA);
				}
				result = PElXlTeNHdmaGaVXQsgwGeCoDukhA.rXKetUBgyZmSgQxocotBhWnUXraEA;
			}
			return result;
		}
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x0003DB74 File Offset: 0x0003BD74
	public static void wZbzJmOdawpQuqKmlyElUKkdrWwP(ttVRlsKWObTjefpmeeKUvTYTQZRU A_0)
	{
		if (A_0 == null || A_0.FXEBIagcuThOcOepHwiWojXacofZA == IntPtr.Zero)
		{
			return;
		}
		Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> obj = PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj;
		lock (obj)
		{
			List<IACtPnxQBtPGwZjFdnDWTKLCTFol> list;
			if (!PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj.TryGetValue(A_0.FXEBIagcuThOcOepHwiWojXacofZA, out list))
			{
				list = new List<IACtPnxQBtPGwZjFdnDWTKLCTFol>();
				PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj.Add(A_0.FXEBIagcuThOcOepHwiWojXacofZA, list);
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (StackFrame stackFrame in new StackTrace(3, true).GetFrames())
			{
				if (stackFrame.GetFileLineNumber() != 0)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\t{0}({1},{2}) : {3}", new object[]
					{
						stackFrame.GetFileName(),
						stackFrame.GetFileLineNumber(),
						stackFrame.GetFileColumnNumber(),
						stackFrame.GetMethod()
					}).AppendLine();
				}
			}
			list.Add(new IACtPnxQBtPGwZjFdnDWTKLCTFol(DateTime.Now, A_0, stringBuilder.ToString()));
			PElXlTeNHdmaGaVXQsgwGeCoDukhA.HDvswwjbiqhYkFSxNYFWqGQvFjtVA(A_0);
		}
	}

	// Token: 0x06000B69 RID: 2921 RVA: 0x0003DC90 File Offset: 0x0003BE90
	public static List<IACtPnxQBtPGwZjFdnDWTKLCTFol> qvulfzMQNVvCqjPuBmVWFXnISHuy(IntPtr A_0)
	{
		Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> obj = PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj;
		lock (obj)
		{
			List<IACtPnxQBtPGwZjFdnDWTKLCTFol> collection;
			if (PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj.TryGetValue(A_0, out collection))
			{
				return new List<IACtPnxQBtPGwZjFdnDWTKLCTFol>(collection);
			}
		}
		return new List<IACtPnxQBtPGwZjFdnDWTKLCTFol>();
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x0003DCE8 File Offset: 0x0003BEE8
	public static IACtPnxQBtPGwZjFdnDWTKLCTFol QBUQZvWSQinqQIgarFhjKMEYYwcKA(ttVRlsKWObTjefpmeeKUvTYTQZRU A_0)
	{
		Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> obj = PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj;
		lock (obj)
		{
			List<IACtPnxQBtPGwZjFdnDWTKLCTFol> list;
			if (PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj.TryGetValue(A_0.FXEBIagcuThOcOepHwiWojXacofZA, out list))
			{
				foreach (IACtPnxQBtPGwZjFdnDWTKLCTFol iactPnxQBtPGwZjFdnDWTKLCTFol in list)
				{
					if (iactPnxQBtPGwZjFdnDWTKLCTFol.QtRnmVzmpDUoUKwsQMCxGMPokbvw.Target == A_0)
					{
						return iactPnxQBtPGwZjFdnDWTKLCTFol;
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06000B6B RID: 2923 RVA: 0x0003DD88 File Offset: 0x0003BF88
	public static void wABhumzJIsFVMgALtNvtUZYXVPBJA(ttVRlsKWObTjefpmeeKUvTYTQZRU A_0)
	{
		if (A_0 == null || A_0.FXEBIagcuThOcOepHwiWojXacofZA == IntPtr.Zero)
		{
			return;
		}
		Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> obj = PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj;
		lock (obj)
		{
			List<IACtPnxQBtPGwZjFdnDWTKLCTFol> list;
			if (PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj.TryGetValue(A_0.FXEBIagcuThOcOepHwiWojXacofZA, out list))
			{
				for (int i = list.Count - 1; i >= 0; i--)
				{
					IACtPnxQBtPGwZjFdnDWTKLCTFol iactPnxQBtPGwZjFdnDWTKLCTFol = list[i];
					if (iactPnxQBtPGwZjFdnDWTKLCTFol.QtRnmVzmpDUoUKwsQMCxGMPokbvw.Target == A_0)
					{
						list.RemoveAt(i);
					}
					else if (!iactPnxQBtPGwZjFdnDWTKLCTFol.NGnlJoFsplzkuZrGuEoLrWGjZHjB)
					{
						list.RemoveAt(i);
					}
				}
				if (list.Count == 0)
				{
					PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj.Remove(A_0.FXEBIagcuThOcOepHwiWojXacofZA);
				}
				PElXlTeNHdmaGaVXQsgwGeCoDukhA.MziyhefhOmQJqcFicDqKeAXZUdcEA(A_0);
			}
		}
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x0003DE50 File Offset: 0x0003C050
	public static List<IACtPnxQBtPGwZjFdnDWTKLCTFol> NuHfPIEhEDzzxHyqtCBrnehfRbycA()
	{
		List<IACtPnxQBtPGwZjFdnDWTKLCTFol> list = new List<IACtPnxQBtPGwZjFdnDWTKLCTFol>();
		Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> obj = PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj;
		lock (obj)
		{
			foreach (List<IACtPnxQBtPGwZjFdnDWTKLCTFol> list2 in PElXlTeNHdmaGaVXQsgwGeCoDukhA.aFIDDSoKMDQkXWUBNpaPozTFZjLj.Values)
			{
				foreach (IACtPnxQBtPGwZjFdnDWTKLCTFol iactPnxQBtPGwZjFdnDWTKLCTFol in list2)
				{
					if (iactPnxQBtPGwZjFdnDWTKLCTFol.NGnlJoFsplzkuZrGuEoLrWGjZHjB)
					{
						list.Add(iactPnxQBtPGwZjFdnDWTKLCTFol);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x0003DF14 File Offset: 0x0003C114
	public static string XvdEeceDotbisKLZXUeeWNQNBTxU()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (IACtPnxQBtPGwZjFdnDWTKLCTFol iactPnxQBtPGwZjFdnDWTKLCTFol in PElXlTeNHdmaGaVXQsgwGeCoDukhA.NuHfPIEhEDzzxHyqtCBrnehfRbycA())
		{
			string text = iactPnxQBtPGwZjFdnDWTKLCTFol.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.AppendFormat("[{0}]: {1}", num, text);
				object target = iactPnxQBtPGwZjFdnDWTKLCTFol.QtRnmVzmpDUoUKwsQMCxGMPokbvw.Target;
				if (target != null)
				{
					string name = target.GetType().Name;
					int num2;
					if (!dictionary.TryGetValue(name, out num2))
					{
						dictionary[name] = 0;
					}
					dictionary[name] = num2 + 1;
				}
			}
			num++;
		}
		List<string> list = new List<string>(dictionary.Keys);
		list.Sort();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Count per Type:");
		foreach (string text2 in list)
		{
			stringBuilder.AppendFormat("{0} : {1}", text2, dictionary[text2]);
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x0003E05C File Offset: 0x0003C25C
	private static void HDvswwjbiqhYkFSxNYFWqGQvFjtVA(ttVRlsKWObTjefpmeeKUvTYTQZRU A_0)
	{
		EventHandler<ucGBOyjwQWMFcpXHOBVLYsurivbvA> eventHandler = PElXlTeNHdmaGaVXQsgwGeCoDukhA.zrpeJnfDwJIMcIrFgaEfgTqkNtBC;
		if (eventHandler != null)
		{
			eventHandler(null, new ucGBOyjwQWMFcpXHOBVLYsurivbvA(A_0));
		}
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x0003E080 File Offset: 0x0003C280
	private static void MziyhefhOmQJqcFicDqKeAXZUdcEA(ttVRlsKWObTjefpmeeKUvTYTQZRU A_0)
	{
		EventHandler<ucGBOyjwQWMFcpXHOBVLYsurivbvA> eventHandler = PElXlTeNHdmaGaVXQsgwGeCoDukhA.wAhjIdjxYbLYpPTgmFwxdxSxZNUn;
		if (eventHandler != null)
		{
			eventHandler(null, new ucGBOyjwQWMFcpXHOBVLYsurivbvA(A_0));
		}
	}

	// Token: 0x04000A27 RID: 2599
	private static Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> rXKetUBgyZmSgQxocotBhWnUXraEA;

	// Token: 0x04000A28 RID: 2600
	[ThreadStatic]
	private static Dictionary<IntPtr, List<IACtPnxQBtPGwZjFdnDWTKLCTFol>> tSpaZfCIphTKKFDkfNRTuBvHhVuu;
}
