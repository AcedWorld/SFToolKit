using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;

namespace Rewired
{
	// Token: 0x020000F4 RID: 244
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedKeyboardSource : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
	{
		// Token: 0x1700028B RID: 651
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x000088CC File Offset: 0x00006ACC
		// (set) Token: 0x060007C0 RID: 1984 RVA: 0x000088D4 File Offset: 0x00006AD4
		public bool enabled
		{
			get
			{
				return this.uUTamTchkJCPpCYTQXXXDroIDwvBc;
			}
			set
			{
				if (this.uUTamTchkJCPpCYTQXXXDroIDwvBc == value)
				{
					return;
				}
				this.uUTamTchkJCPpCYTQXXXDroIDwvBc = value;
				this.Clear();
				ThreadSafeUnityInput.keyboard.Monitor(value);
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x000088F8 File Offset: 0x00006AF8
		public InputSource inputSource
		{
			get
			{
				return InputSource.UnityKeyboardAndMouse;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x000088FC File Offset: 0x00006AFC
		public HardwareControllerMap_Game hardwareMap
		{
			get
			{
				if (UnityUnifiedKeyboardSource.XovcqIdXpFqmZqeHPckHwsMYdDvhA == null)
				{
					UnityUnifiedKeyboardSource.XovcqIdXpFqmZqeHPckHwsMYdDvhA = UnityUnifiedKeyboardSource.CreateHardwareMap();
				}
				return UnityUnifiedKeyboardSource.XovcqIdXpFqmZqeHPckHwsMYdDvhA;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x00003F1F File Offset: 0x0000211F
		public int buttonCount
		{
			get
			{
				return 132;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x000067FE File Offset: 0x000049FE
		public Controller.Extension controllerExtension
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00008914 File Offset: 0x00006B14
		public UnityUnifiedKeyboardSource()
		{
			this.enabled = true;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00008923 File Offset: 0x00006B23
		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			if (!this.uUTamTchkJCPpCYTQXXXDroIDwvBc)
			{
				return;
			}
			ThreadSafeUnityInput.keyboard.GetKeyValues(dataUpdater.buttonValues);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00002FF9 File Offset: 0x000011F9
		public void Clear()
		{
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0003DB28 File Offset: 0x0003BD28
		internal static HardwareControllerMap_Game CreateHardwareMap()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, true);
			}
			int[] array2 = new int[132];
			for (int j = 0; j < 132; j++)
			{
				array2[j] = array[j].id;
			}
			HardwareButtonInfo[] array3 = new HardwareButtonInfo[132];
			for (int k = 0; k < 132; k++)
			{
				array3[k] = new HardwareButtonInfo();
			}
			return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0000893E File Offset: 0x00006B3E
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0003DBF8 File Offset: 0x0003BDF8
		~UnityUnifiedKeyboardSource()
		{
			this.Dispose(false);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0000894D File Offset: 0x00006B4D
		protected virtual void Dispose(bool disposing)
		{
			if (this.uTpzxssvYXlSvSJTNpduSixBWLTR)
			{
				return;
			}
			if (disposing && this.uUTamTchkJCPpCYTQXXXDroIDwvBc)
			{
				ThreadSafeUnityInput.keyboard.Monitor(false);
			}
			this.uTpzxssvYXlSvSJTNpduSixBWLTR = true;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00008975 File Offset: 0x00006B75
		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (UnityUnifiedKeyboardSource.XovcqIdXpFqmZqeHPckHwsMYdDvhA == null)
			{
				UnityUnifiedKeyboardSource.XovcqIdXpFqmZqeHPckHwsMYdDvhA = UnityUnifiedKeyboardSource.CreateHardwareMap();
			}
			return UnityUnifiedKeyboardSource.XovcqIdXpFqmZqeHPckHwsMYdDvhA.GetElementType(elementIdentifierId);
		}

		// Token: 0x04000648 RID: 1608
		private const int UIXKnTUQlSGjheuwpqEYCSmFNPVV = 132;

		// Token: 0x04000649 RID: 1609
		private static HardwareControllerMap_Game XovcqIdXpFqmZqeHPckHwsMYdDvhA;

		// Token: 0x0400064A RID: 1610
		private bool uUTamTchkJCPpCYTQXXXDroIDwvBc;

		// Token: 0x0400064B RID: 1611
		private bool uTpzxssvYXlSvSJTNpduSixBWLTR;
	}
}
