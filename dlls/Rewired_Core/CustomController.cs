using System;
using Rewired.Utils;

namespace Rewired
{
	// Token: 0x0200005D RID: 93
	public sealed class CustomController : ControllerWithAxes
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x00005C4E File Offset: 0x00003E4E
		public int sourceControllerId
		{
			get
			{
				return this.eHCHRUvhmdnByqSUDjIWcodcFYYY;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x00005C56 File Offset: 0x00003E56
		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return Guid.Empty;
				}
				return this.eppnOVPBmKJLtxpUOaCSCtLWGnLfb;
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00034924 File Offset: 0x00032B24
		internal CustomController(huKiUXRfzpflYKKFNfZwEZCsaovIA A_1) : this(A_1.hLdPkfJRBFIEOylPSwjSHXgpJjZK, A_1.hXCjOcePxRDXAsQsmHmdSBGfeEeM, A_1.GdeEcpYTyFmSyouxkAegmkkymLxv, A_1.eOjfuHGRNiEwMvKMPnUoKrWRvQpY, A_1.LrwDvShgEYSPEQswkNIZNFclDllr, A_1.tHjBcYVSIYHuOUCvErhaIVHtCHNu, A_1.zQkfhPnLEnhuTMVsjblBIgueOrUd, A_1.pViHeOXfMSLVoXztWupQWkZsWoUJ, A_1.WLxxhKczmNfUGgARybzRCRnnRTuy, A_1.QbdCPGYevrtvtZZczPLgqboMFqPi, null, new ControllerDataUpdater(A_1.eOjfuHGRNiEwMvKMPnUoKrWRvQpY, A_1.pViHeOXfMSLVoXztWupQWkZsWoUJ, A_1.WLxxhKczmNfUGgARybzRCRnnRTuy, null))
		{
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0003498C File Offset: 0x00032B8C
		private CustomController(int A_1, int A_2, Guid A_3, InputSource A_4, string A_5, string A_6, string A_7, int A_8, int A_9, HardwareControllerMap_Game A_10, Controller.Extension A_11, ControllerDataUpdater A_12) : base(A_1, A_4, A_5, A_6, A_7, ControllerType.Custom, A_3, A_8, A_9, null, A_10, A_11, A_12)
		{
			this.eHCHRUvhmdnByqSUDjIWcodcFYYY = A_2;
			this.eppnOVPBmKJLtxpUOaCSCtLWGnLfb = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + this.eHCHRUvhmdnByqSUDjIWcodcFYYY.ToString() + ", controllerId = " + A_1.ToString());
			this.qEnvtUAzINATYqQGwxMxBBiSsAkj();
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x000349F0 File Offset: 0x00032BF0
		internal void imQEMIFlJSzXxTzPdPBsQDHzJfsnA()
		{
			if (!this.rsNEAPpFrdXdKvkXXJrUQarZlBTp)
			{
				return;
			}
			if (this.lagAjqNdCEUCFhwEXNALpmPHMPjy != null)
			{
				for (int i = 0; i < this._axisCount; i++)
				{
					this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.axisValues[i] = this.lagAjqNdCEUCFhwEXNALpmPHMPjy(i);
				}
			}
			if (this.kolfIcqaYcNVUijuPYCXZIfcQeov != null)
			{
				for (int j = 0; j < this._buttonCount; j++)
				{
					this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.buttonValues[j] = this.kolfIcqaYcNVUijuPYCXZIfcQeov(j);
				}
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00034A6C File Offset: 0x00032C6C
		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (index < 0 || index >= this._axisCount)
			{
				Logger.LogWarning(index.ToString() + " is not a valid Axis index.");
				return;
			}
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.axisValues[index] = value;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00034AD0 File Offset: 0x00032CD0
		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementName);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				Logger.LogWarning("\"" + axisIndex.ToString() + "\" is not a valid Axis name.");
				return;
			}
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.axisValues[axisIndex] = value;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00034B44 File Offset: 0x00032D44
		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				Logger.LogWarning(elementId.ToString() + " is not a valid Axis id.");
				return;
			}
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.axisValues[axisIndex] = value;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00034BB4 File Offset: 0x00032DB4
		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (index < 0 || index >= this._buttonCount)
			{
				Logger.LogWarning(index.ToString() + " is not a valid Button index.");
				return;
			}
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.buttonValues[index] = value;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00034C18 File Offset: 0x00032E18
		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementName);
			if (buttonIndex < 0 || buttonIndex >= this._buttonCount)
			{
				Logger.LogWarning("\"" + buttonIndex.ToString() + "\" is not a valid Button name.");
				return;
			}
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.buttonValues[buttonIndex] = value;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00034C8C File Offset: 0x00032E8C
		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementId);
			if (buttonIndex < 0 || buttonIndex >= this._buttonCount)
			{
				Logger.LogWarning(elementId.ToString() + " is not a valid Button id.");
				return;
			}
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.buttonValues[buttonIndex] = value;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00005C7D File Offset: 0x00003E7D
		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			this.lagAjqNdCEUCFhwEXNALpmPHMPjy = callback;
			if (!this.rsNEAPpFrdXdKvkXXJrUQarZlBTp)
			{
				this.rsNEAPpFrdXdKvkXXJrUQarZlBTp = true;
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00005CAF File Offset: 0x00003EAF
		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			this.kolfIcqaYcNVUijuPYCXZIfcQeov = callback;
			if (!this.rsNEAPpFrdXdKvkXXJrUQarZlBTp)
			{
				this.rsNEAPpFrdXdKvkXXJrUQarZlBTp = true;
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00034CFC File Offset: 0x00032EFC
		public void ClearAxisValue(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (index < 0 || index >= this._axisCount)
			{
				Logger.LogWarning(index.ToString() + " is not a valid Axis index.");
				return;
			}
			float num = (this._calibrationMap != null) ? this._calibrationMap.GetAxis(index).calibratedZero : 0f;
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.axisValues[index] = num;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00034D80 File Offset: 0x00032F80
		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementName);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				Logger.LogWarning("\"" + axisIndex.ToString() + "\" is not a valid Axis name.");
				return;
			}
			this.ClearAxisValue(axisIndex);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00034DF0 File Offset: 0x00032FF0
		public void ClearAxisValueById(int elementId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				Logger.LogWarning(elementId.ToString() + " is not a valid Axis id.");
				return;
			}
			this.ClearAxisValue(axisIndex);
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00034E58 File Offset: 0x00033058
		public void ClearButtonValue(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			if (index < 0 || index >= this._buttonCount)
			{
				Logger.LogWarning(index.ToString() + " is not a valid Button index.");
				return;
			}
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.buttonValues[index] = false;
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.buttonPressureValues[index] = 0f;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00034ECC File Offset: 0x000330CC
		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementName);
			if (buttonIndex < 0 || buttonIndex >= this._buttonCount)
			{
				Logger.LogWarning("\"" + buttonIndex.ToString() + "\" is not a valid Button name.");
				return;
			}
			this.ClearButtonValue(buttonIndex);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00034F3C File Offset: 0x0003313C
		public void ClearButtonValueById(int elementId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!base.enabled)
			{
				return;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementId);
			if (buttonIndex < 0 || buttonIndex >= this._buttonCount)
			{
				Logger.LogWarning(elementId.ToString() + " is not a valid Button id.");
				return;
			}
			this.ClearButtonValue(buttonIndex);
		}

		// Token: 0x04000311 RID: 785
		private int eHCHRUvhmdnByqSUDjIWcodcFYYY;

		// Token: 0x04000312 RID: 786
		private Func<int, float> lagAjqNdCEUCFhwEXNALpmPHMPjy;

		// Token: 0x04000313 RID: 787
		private Func<int, bool> kolfIcqaYcNVUijuPYCXZIfcQeov;

		// Token: 0x04000314 RID: 788
		private bool rsNEAPpFrdXdKvkXXJrUQarZlBTp;

		// Token: 0x04000315 RID: 789
		private Guid eppnOVPBmKJLtxpUOaCSCtLWGnLfb;
	}
}
