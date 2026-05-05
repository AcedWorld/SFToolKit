using System;

namespace Rewired
{
	// Token: 0x020000E3 RID: 227
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ControllerDataUpdater
	{
		// Token: 0x06000755 RID: 1877 RVA: 0x0003C704 File Offset: 0x0003A904
		public ControllerDataUpdater(InputSource A_1, int A_2, int A_3, UnknownControllerHat[] A_4)
		{
			if (A_2 < 0 || A_3 < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.source = A_1;
			this.axisCount = A_2;
			this.buttonCount = A_3;
			this.IeHGSTNKIcOAcbsEXHxsQlGBidmu = A_4;
			this.axisValues = new float[A_2];
			this.buttonValues = new bool[A_3];
			this.buttonPressureValues = new float[A_3];
			this.axisHasBeenPressedOSXLinux = new bool[A_2];
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0003C774 File Offset: 0x0003A974
		public bool IsUnknownHatCardinal(int buttonIndex)
		{
			if (this.IeHGSTNKIcOAcbsEXHxsQlGBidmu == null)
			{
				return false;
			}
			for (int i = 0; i < this.IeHGSTNKIcOAcbsEXHxsQlGBidmu.Length; i++)
			{
				if (this.IeHGSTNKIcOAcbsEXHxsQlGBidmu[i].IsButtonIndexCardinal(buttonIndex))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0003C7B4 File Offset: 0x0003A9B4
		public UnknownControllerHat.HatButtons GetUnknownHatButtons(int buttonIndex)
		{
			if (this.IeHGSTNKIcOAcbsEXHxsQlGBidmu == null)
			{
				return null;
			}
			for (int i = 0; i < this.IeHGSTNKIcOAcbsEXHxsQlGBidmu.Length; i++)
			{
				if (this.IeHGSTNKIcOAcbsEXHxsQlGBidmu[i].ContainsButtonIndex(buttonIndex))
				{
					return this.IeHGSTNKIcOAcbsEXHxsQlGBidmu[i].GetButtons();
				}
			}
			return null;
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0003C800 File Offset: 0x0003AA00
		public void ClearData()
		{
			Array.Clear(this.axisValues, 0, this.axisValues.Length);
			Array.Clear(this.buttonValues, 0, this.buttonValues.Length);
			Array.Clear(this.buttonPressureValues, 0, this.buttonPressureValues.Length);
			Array.Clear(this.axisHasBeenPressedOSXLinux, 0, this.axisHasBeenPressedOSXLinux.Length);
			this.hasReceivedInput = false;
		}

		// Token: 0x0400060E RID: 1550
		public readonly InputSource source;

		// Token: 0x0400060F RID: 1551
		public readonly int axisCount;

		// Token: 0x04000610 RID: 1552
		public readonly int buttonCount;

		// Token: 0x04000611 RID: 1553
		public readonly float[] axisValues;

		// Token: 0x04000612 RID: 1554
		public readonly bool[] buttonValues;

		// Token: 0x04000613 RID: 1555
		public readonly float[] buttonPressureValues;

		// Token: 0x04000614 RID: 1556
		public readonly bool[] axisHasBeenPressedOSXLinux;

		// Token: 0x04000615 RID: 1557
		private readonly UnknownControllerHat[] IeHGSTNKIcOAcbsEXHxsQlGBidmu;

		// Token: 0x04000616 RID: 1558
		public bool hasReceivedInput;
	}
}
