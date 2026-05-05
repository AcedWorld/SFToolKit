using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x020000F2 RID: 242
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		// Token: 0x060007B7 RID: 1975 RVA: 0x0003DA28 File Offset: 0x0003BC28
		static UnityInputHelper()
		{
			for (int i = 0; i < UnityInputHelper.VBbmPHIgxfpljkCaTHmKglTiUlNMA.Length; i++)
			{
				UnityInputHelper.VBbmPHIgxfpljkCaTHmKglTiUlNMA[i] = new UnityInputHelper.HImHZtKuNOvLcHqXyPbvKXGTVFIR(i);
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00008849 File Offset: 0x00006A49
		public static float GetJoystickAxisValueByJoystickId(int joystickId, int axisIndex)
		{
			if (joystickId <= 0 || joystickId > 16)
			{
				return 0f;
			}
			if (axisIndex >= 29)
			{
				return 0f;
			}
			return Input.GetAxis(UnityInputHelper.VBbmPHIgxfpljkCaTHmKglTiUlNMA[joystickId - 1].IYCXcIlkDBslYsSgSvTdTZwdcRfc[axisIndex]);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0000887A File Offset: 0x00006A7A
		public static float GetJoystickAxisRawValueByJoystickId(int joystickId, int axisIndex)
		{
			if (joystickId <= 0 || joystickId > 16)
			{
				return 0f;
			}
			if (axisIndex >= 29)
			{
				return 0f;
			}
			return Input.GetAxisRaw(UnityInputHelper.VBbmPHIgxfpljkCaTHmKglTiUlNMA[joystickId - 1].IYCXcIlkDBslYsSgSvTdTZwdcRfc[axisIndex]);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x000088AB File Offset: 0x00006AAB
		public static float GetJoystickAxisValueByJoystickIndex(int joystickIndex, int axisIndex)
		{
			return UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickIndex + 1, axisIndex);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000088B6 File Offset: 0x00006AB6
		public static float GetJoystickAxisRawValueByJoystickIndex(int joystickIndex, int axisIndex)
		{
			return UnityInputHelper.GetJoystickAxisRawValueByJoystickId(joystickIndex + 1, axisIndex);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0003DA60 File Offset: 0x0003BC60
		public static bool GetJoystickButtonValueByJoystickId(int joystickId, int buttonIndex)
		{
			if (joystickId <= 0 || joystickId > 16)
			{
				return false;
			}
			if (buttonIndex >= 20)
			{
				return false;
			}
			int num = joystickId - 1;
			if (joystickId <= 16)
			{
				return Input.GetKey(KeyCode.Joystick1Button0 + 20 * num + buttonIndex);
			}
			return Input.GetButton(UnityInputHelper.VBbmPHIgxfpljkCaTHmKglTiUlNMA[num].hqUdhyZlsUMuEFxvdOBjpBVGfisKA[buttonIndex]);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x000088C1 File Offset: 0x00006AC1
		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}

		// Token: 0x04000645 RID: 1605
		private static UnityInputHelper.HImHZtKuNOvLcHqXyPbvKXGTVFIR[] VBbmPHIgxfpljkCaTHmKglTiUlNMA = new UnityInputHelper.HImHZtKuNOvLcHqXyPbvKXGTVFIR[16];

		// Token: 0x020000F3 RID: 243
		private class HImHZtKuNOvLcHqXyPbvKXGTVFIR
		{
			// Token: 0x060007BE RID: 1982 RVA: 0x0003DAB0 File Offset: 0x0003BCB0
			public HImHZtKuNOvLcHqXyPbvKXGTVFIR(int A_1)
			{
				this.IYCXcIlkDBslYsSgSvTdTZwdcRfc = new string[29];
				for (int i = 0; i < this.IYCXcIlkDBslYsSgSvTdTZwdcRfc.Length; i++)
				{
					this.IYCXcIlkDBslYsSgSvTdTZwdcRfc[i] = UnityTools.GetUnityInputAxisName(A_1, i);
				}
				if (A_1 + 1 > 16)
				{
					this.hqUdhyZlsUMuEFxvdOBjpBVGfisKA = new string[20];
					for (int j = 0; j < this.hqUdhyZlsUMuEFxvdOBjpBVGfisKA.Length; j++)
					{
						this.hqUdhyZlsUMuEFxvdOBjpBVGfisKA[j] = UnityTools.GetUnityInputButtonName(A_1, j);
					}
				}
			}

			// Token: 0x04000646 RID: 1606
			public string[] IYCXcIlkDBslYsSgSvTdTZwdcRfc;

			// Token: 0x04000647 RID: 1607
			public string[] hqUdhyZlsUMuEFxvdOBjpBVGfisKA;
		}
	}
}
