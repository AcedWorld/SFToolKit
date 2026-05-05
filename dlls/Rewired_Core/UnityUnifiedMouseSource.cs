using System;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	// Token: 0x020000F5 RID: 245
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedMouseSource : IUnifiedMouseSource, IGetSetEnabled, IDisposable
	{
		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x00008993 File Offset: 0x00006B93
		// (set) Token: 0x060007CE RID: 1998 RVA: 0x0000899B File Offset: 0x00006B9B
		public bool enabled
		{
			get
			{
				return this.DhXbXEEFcbnjsiRMSBSayecgYLzy;
			}
			set
			{
				if (this.DhXbXEEFcbnjsiRMSBSayecgYLzy == value)
				{
					return;
				}
				this.DhXbXEEFcbnjsiRMSBSayecgYLzy = value;
				this.Clear();
				ThreadSafeUnityInput.mouse.Monitor(value);
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x000088F8 File Offset: 0x00006AF8
		public InputSource inputSource
		{
			get
			{
				return InputSource.UnityKeyboardAndMouse;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x000089BF File Offset: 0x00006BBF
		public HardwareControllerMap_Game hardwareMap
		{
			get
			{
				if (UnityUnifiedMouseSource.uzGwIzpqSyuEyXrToSLxkOaPMmnk == null)
				{
					UnityUnifiedMouseSource.uzGwIzpqSyuEyXrToSLxkOaPMmnk = UnityUnifiedMouseSource.CreateHardwareMap();
				}
				return UnityUnifiedMouseSource.uzGwIzpqSyuEyXrToSLxkOaPMmnk;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x000089D7 File Offset: 0x00006BD7
		public int buttonCount
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x000057C4 File Offset: 0x000039C4
		public int axisCount
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x0003DC28 File Offset: 0x0003BE28
		public Vector2 mousePosition
		{
			get
			{
				if (!this.DhXbXEEFcbnjsiRMSBSayecgYLzy)
				{
					return default(Vector2);
				}
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x000067FE File Offset: 0x000049FE
		public Controller.Extension controllerExtension
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0003DC58 File Offset: 0x0003BE58
		public UnityUnifiedMouseSource()
		{
			this.UVSRBllujTFMeghFdWLtXAJsJdlg = new UpdateLoopDataSet<UnityUnifiedMouseSource.JnwsyKJHdsMPKJQDqinAXrVvSmiA>(ReInput.configVars.updateLoop, new Func<UnityUnifiedMouseSource.JnwsyKJHdsMPKJQDqinAXrVvSmiA>(UnityUnifiedMouseSource.DOAXSsCUXOxrKirSMVFnmYHrBitf.<>9.JzbabbfijtnenQjngWQVAoxlhwzC));
			this.KExyiaMoMtPmUohMAfAkFWaKssvb = new float[4];
			this.XfeeUKMQDUtimxfDcPlqfDYHRTGV = new bool[7];
			this.enabled = true;
			ReInput.UpdateEndedEvent += this.GsMgMWIIfvmHxilHvkeuclKWFuFZA;
			ReInput.EarlyUpdateEvent += this.rHIpZZqYWEwuOEckjCzYiLOvmlSu;
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x000089DA File Offset: 0x00006BDA
		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			this.UVSRBllujTFMeghFdWLtXAJsJdlg.Get(ReInput.currentUpdateLoop).YOfDEbglnBTsQpPMVcxeONCVXrUg(dataUpdater);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0003DCE0 File Offset: 0x0003BEE0
		public void Clear()
		{
			int count = this.UVSRBllujTFMeghFdWLtXAJsJdlg.Count;
			for (int i = 0; i < count; i++)
			{
				this.UVSRBllujTFMeghFdWLtXAJsJdlg.Get(i).aJKEyxcusUiwFFFKCEKtuhpbSLqjc();
			}
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0003DD18 File Offset: 0x0003BF18
		private void rHIpZZqYWEwuOEckjCzYiLOvmlSu()
		{
			if (!this.DhXbXEEFcbnjsiRMSBSayecgYLzy)
			{
				return;
			}
			ThreadSafeUnityInput.mouse.GetAxisRawValues(this.KExyiaMoMtPmUohMAfAkFWaKssvb);
			ThreadSafeUnityInput.mouse.GetButtonValues(this.XfeeUKMQDUtimxfDcPlqfDYHRTGV);
			int count = this.UVSRBllujTFMeghFdWLtXAJsJdlg.Count;
			for (int i = 0; i < count; i++)
			{
				this.UVSRBllujTFMeghFdWLtXAJsJdlg.Get(i).bEwJTmpvBQgNNpboQosiCzXvsbtk(this.XfeeUKMQDUtimxfDcPlqfDYHRTGV, this.KExyiaMoMtPmUohMAfAkFWaKssvb);
			}
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x000089F2 File Offset: 0x00006BF2
		private void GsMgMWIIfvmHxilHvkeuclKWFuFZA(UpdateLoopType A_1)
		{
			this.UVSRBllujTFMeghFdWLtXAJsJdlg.Get(A_1).HaeBpYbyyXkgzMhhTOzAIZVpRMIl();
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0003DD84 File Offset: 0x0003BF84
		internal static HardwareControllerMap_Game CreateHardwareMap()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.unityUnifiedMouseElementIdentifiers.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new ControllerElementIdentifier(Consts.unityUnifiedMouseElementIdentifiers[i]);
			}
			int[] array2 = new int[7];
			int[] array3 = new int[4];
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j].elementType == ControllerElementType.Axis)
				{
					array3[num2++] = array[j].id;
				}
				else if (array[j].elementType == ControllerElementType.Button)
				{
					array2[num++] = array[j].id;
				}
			}
			AxisCalibrationData[] array4 = new AxisCalibrationData[4];
			AxisRange[] array5 = new AxisRange[4];
			HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
			HardwareButtonInfo[] array7 = new HardwareButtonInfo[7];
			for (int k = 0; k < 4; k++)
			{
				array4[k] = AxisCalibrationData.Raw;
				array5[k] = AxisRange.Full;
				float num3;
				if (k <= 1)
				{
					num3 = 100f;
				}
				else
				{
					num3 = 2f;
				}
				array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
			}
			for (int l = 0; l < 7; l++)
			{
				array7[l] = new HardwareButtonInfo();
			}
			return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00008A05 File Offset: 0x00006C05
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0003DECC File Offset: 0x0003C0CC
		~UnityUnifiedMouseSource()
		{
			this.Dispose(false);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0003DEFC File Offset: 0x0003C0FC
		protected virtual void Dispose(bool disposing)
		{
			if (this.QwZjnoapcGkuIWzrzFGpxJenHKTC)
			{
				return;
			}
			if (disposing)
			{
				if (this.DhXbXEEFcbnjsiRMSBSayecgYLzy)
				{
					ThreadSafeUnityInput.mouse.Monitor(false);
				}
				ReInput.UpdateEndedEvent -= this.GsMgMWIIfvmHxilHvkeuclKWFuFZA;
				ReInput.EarlyUpdateEvent -= this.rHIpZZqYWEwuOEckjCzYiLOvmlSu;
			}
			this.QwZjnoapcGkuIWzrzFGpxJenHKTC = true;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00008A14 File Offset: 0x00006C14
		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (UnityUnifiedMouseSource.uzGwIzpqSyuEyXrToSLxkOaPMmnk == null)
			{
				UnityUnifiedMouseSource.uzGwIzpqSyuEyXrToSLxkOaPMmnk = UnityUnifiedMouseSource.CreateHardwareMap();
			}
			return UnityUnifiedMouseSource.uzGwIzpqSyuEyXrToSLxkOaPMmnk.GetElementType(elementIdentifierId);
		}

		// Token: 0x0400064C RID: 1612
		private static HardwareControllerMap_Game uzGwIzpqSyuEyXrToSLxkOaPMmnk;

		// Token: 0x0400064D RID: 1613
		private UpdateLoopDataSet<UnityUnifiedMouseSource.JnwsyKJHdsMPKJQDqinAXrVvSmiA> UVSRBllujTFMeghFdWLtXAJsJdlg;

		// Token: 0x0400064E RID: 1614
		private float[] KExyiaMoMtPmUohMAfAkFWaKssvb;

		// Token: 0x0400064F RID: 1615
		private bool[] XfeeUKMQDUtimxfDcPlqfDYHRTGV;

		// Token: 0x04000650 RID: 1616
		private bool DhXbXEEFcbnjsiRMSBSayecgYLzy;

		// Token: 0x04000651 RID: 1617
		private bool QwZjnoapcGkuIWzrzFGpxJenHKTC;

		// Token: 0x020000F6 RID: 246
		private class JnwsyKJHdsMPKJQDqinAXrVvSmiA
		{
			// Token: 0x060007DF RID: 2015 RVA: 0x00008A32 File Offset: 0x00006C32
			public JnwsyKJHdsMPKJQDqinAXrVvSmiA(int A_1, int A_2)
			{
				this.QHXmTXnMITFPcVfiPhgPICzLlvxo = new bool[A_1];
				this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL = new float[A_2];
			}

			// Token: 0x060007E0 RID: 2016 RVA: 0x0003DF54 File Offset: 0x0003C154
			public void bEwJTmpvBQgNNpboQosiCzXvsbtk(bool[] A_1, float[] A_2)
			{
				Array.Copy(A_1, this.QHXmTXnMITFPcVfiPhgPICzLlvxo, A_1.Length);
				for (int i = 0; i < this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL.Length; i++)
				{
					this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL[i] += A_2[i];
				}
			}

			// Token: 0x060007E1 RID: 2017 RVA: 0x00008A52 File Offset: 0x00006C52
			public void YOfDEbglnBTsQpPMVcxeONCVXrUg(ControllerDataUpdater A_1)
			{
				Array.Copy(this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL, A_1.axisValues, this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL.Length);
				Array.Copy(this.QHXmTXnMITFPcVfiPhgPICzLlvxo, A_1.buttonValues, this.QHXmTXnMITFPcVfiPhgPICzLlvxo.Length);
			}

			// Token: 0x060007E2 RID: 2018 RVA: 0x00008A86 File Offset: 0x00006C86
			public void aJKEyxcusUiwFFFKCEKtuhpbSLqjc()
			{
				Array.Clear(this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL, 0, this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL.Length);
				Array.Clear(this.QHXmTXnMITFPcVfiPhgPICzLlvxo, 0, this.QHXmTXnMITFPcVfiPhgPICzLlvxo.Length);
			}

			// Token: 0x060007E3 RID: 2019 RVA: 0x00008AB0 File Offset: 0x00006CB0
			public void HaeBpYbyyXkgzMhhTOzAIZVpRMIl()
			{
				Array.Clear(this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL, 0, this.uwqbNiAPsUFTcUhlqbpqKuiAnOuL.Length);
			}

			// Token: 0x04000652 RID: 1618
			private float[] uwqbNiAPsUFTcUhlqbpqKuiAnOuL;

			// Token: 0x04000653 RID: 1619
			private bool[] QHXmTXnMITFPcVfiPhgPICzLlvxo;
		}

		// Token: 0x020000F7 RID: 247
		[CompilerGenerated]
		[Serializable]
		private sealed class DOAXSsCUXOxrKirSMVFnmYHrBitf
		{
			// Token: 0x060007E6 RID: 2022 RVA: 0x00008AD2 File Offset: 0x00006CD2
			internal UnityUnifiedMouseSource.JnwsyKJHdsMPKJQDqinAXrVvSmiA JzbabbfijtnenQjngWQVAoxlhwzC()
			{
				return new UnityUnifiedMouseSource.JnwsyKJHdsMPKJQDqinAXrVvSmiA(7, 4);
			}

			// Token: 0x04000654 RID: 1620
			public static readonly UnityUnifiedMouseSource.DOAXSsCUXOxrKirSMVFnmYHrBitf <>9 = new UnityUnifiedMouseSource.DOAXSsCUXOxrKirSMVFnmYHrBitf();

			// Token: 0x04000655 RID: 1621
			public static Func<UnityUnifiedMouseSource.JnwsyKJHdsMPKJQDqinAXrVvSmiA> <>9__20_0;
		}
	}
}
