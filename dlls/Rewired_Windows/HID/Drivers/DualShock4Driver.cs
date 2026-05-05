using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	// Token: 0x0200030C RID: 780
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		// Token: 0x17000398 RID: 920
		// (get) Token: 0x0600169C RID: 5788 RVA: 0x0004D698 File Offset: 0x0004B898
		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.VibrationMotorCount; i++)
				{
					if (this.vibrationMotors[i].jytYrChQDenkTUaEnqBMeGDoorVS > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x0600169D RID: 5789 RVA: 0x0001CE38 File Offset: 0x0001B038
		public float BatteryLevel
		{
			get
			{
				return (float)this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x0600169E RID: 5790 RVA: 0x0001CE41 File Offset: 0x0001B041
		public bool BatteryCharging
		{
			get
			{
				return this.lAPogrRHsVgbxiAQUvwPDjjskmSgb == DualShock4Driver.hxXaJMCeImyVOgpiHOxLyEIdFmvLA.Charging;
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x0600169F RID: 5791 RVA: 0x0001C809 File Offset: 0x0001AA09
		// (set) Token: 0x060016A0 RID: 5792 RVA: 0x0001C818 File Offset: 0x0001AA18
		public float LeftMotor
		{
			get
			{
				return this.vibrationMotors[0].kEsBudgJSBjLmBXIUoFwHyyKoNffb;
			}
			set
			{
				this.vibrationMotors[0].kEsBudgJSBjLmBXIUoFwHyyKoNffb = value;
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x060016A1 RID: 5793 RVA: 0x0001C828 File Offset: 0x0001AA28
		// (set) Token: 0x060016A2 RID: 5794 RVA: 0x0001C837 File Offset: 0x0001AA37
		public float RightMotor
		{
			get
			{
				return this.vibrationMotors[1].kEsBudgJSBjLmBXIUoFwHyyKoNffb;
			}
			set
			{
				this.vibrationMotors[1].kEsBudgJSBjLmBXIUoFwHyyKoNffb = value;
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x060016A3 RID: 5795 RVA: 0x0001C847 File Offset: 0x0001AA47
		// (set) Token: 0x060016A4 RID: 5796 RVA: 0x0001C856 File Offset: 0x0001AA56
		public float LightColorR
		{
			get
			{
				return this.lights[0].WXlrSLzaZpCuguvLdwWCHbFyyuCA;
			}
			set
			{
				this.lights[0].WXlrSLzaZpCuguvLdwWCHbFyyuCA = value;
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x060016A5 RID: 5797 RVA: 0x0001C866 File Offset: 0x0001AA66
		// (set) Token: 0x060016A6 RID: 5798 RVA: 0x0001C875 File Offset: 0x0001AA75
		public float LightColorG
		{
			get
			{
				return this.lights[0].NlktmPymgpqEHqHjTFqAeIkdedTib;
			}
			set
			{
				this.lights[0].NlktmPymgpqEHqHjTFqAeIkdedTib = value;
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x060016A7 RID: 5799 RVA: 0x0001C885 File Offset: 0x0001AA85
		// (set) Token: 0x060016A8 RID: 5800 RVA: 0x0001C894 File Offset: 0x0001AA94
		public float LightColorB
		{
			get
			{
				return this.lights[0].xoiGHZgpntivkVPnRSGBiemETlwn;
			}
			set
			{
				this.lights[0].xoiGHZgpntivkVPnRSGBiemETlwn = value;
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x060016A9 RID: 5801 RVA: 0x0001CE4C File Offset: 0x0001B04C
		// (set) Token: 0x060016AA RID: 5802 RVA: 0x0004FF18 File Offset: 0x0004E118
		public float LightFlashOnDuration
		{
			get
			{
				return (float)this.SfRAeVzugzILGbOCSSwryoGerodwA;
			}
			set
			{
				this.SfRAeVzugzILGbOCSSwryoGerodwA = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				this.DYhWbMjfLDaNzHwRWwDfAasNLFxYA();
				if (this.SfRAeVzugzILGbOCSSwryoGerodwA == 0 && this.kerQgGFWlGmhEiPxDehEgbgCTIBT == 0)
				{
					this.yQCmSaTdflMzXQrUqeWxOpoRxhfK = true;
				}
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x060016AB RID: 5803 RVA: 0x0001CE55 File Offset: 0x0001B055
		// (set) Token: 0x060016AC RID: 5804 RVA: 0x0004FF70 File Offset: 0x0004E170
		public float LightFlashOffDuration
		{
			get
			{
				return (float)this.kerQgGFWlGmhEiPxDehEgbgCTIBT;
			}
			set
			{
				this.kerQgGFWlGmhEiPxDehEgbgCTIBT = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				this.DYhWbMjfLDaNzHwRWwDfAasNLFxYA();
				if (this.SfRAeVzugzILGbOCSSwryoGerodwA == 0 && this.kerQgGFWlGmhEiPxDehEgbgCTIBT == 0)
				{
					this.yQCmSaTdflMzXQrUqeWxOpoRxhfK = true;
				}
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x060016AD RID: 5805 RVA: 0x0001CE5E File Offset: 0x0001B05E
		public Vector3 AccelerometerValue
		{
			get
			{
				return this.ilmBjbrBieIFBiZstRJYwfyJshgiA(this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD);
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x0001C92F File Offset: 0x0001AB2F
		public Vector3 AccelerometerValueRaw
		{
			get
			{
				return new Vector3(this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[0], this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[1], this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[2]);
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x060016AF RID: 5807 RVA: 0x0001CE73 File Offset: 0x0001B073
		public Vector3 GyroscopeValue
		{
			get
			{
				return this.gXArnmUiwPVLOAbfBwuCmsLzwCcu(this.gyroscopes[0].CxhCZOFOLzfwwTtqOruQEcpotRwP);
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x0001C978 File Offset: 0x0001AB78
		public Vector3 GyroscopeValueRaw
		{
			get
			{
				return new Vector3(this.gyroscopes[0].oxrAVCGYVAsFpNwvvghIcKXCXRPLA[0], this.gyroscopes[0].oxrAVCGYVAsFpNwvvghIcKXCXRPLA[1], this.gyroscopes[0].oxrAVCGYVAsFpNwvvghIcKXCXRPLA[2]);
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x060016B1 RID: 5809 RVA: 0x0004FFC8 File Offset: 0x0004E1C8
		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[0], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[1], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[2]);
				return this.BVItPzaNAyNQjADNrktCzWxwUOdK(vector, this.VRLnVyBiHYyzNvvDmUXQTvdhoBKE);
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x060016B2 RID: 5810 RVA: 0x0001C9AC File Offset: 0x0001ABAC
		public Vector3 LastGyroscopeValueRaw
		{
			get
			{
				return new Vector3(this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[0], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[1], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[2]);
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x060016B3 RID: 5811 RVA: 0x0001CE88 File Offset: 0x0001B088
		public Quaternion Orientation
		{
			get
			{
				return this.lXpcFamxsQDcUXiSZAIBlQkqusPg;
			}
		}

		// Token: 0x060016B4 RID: 5812 RVA: 0x0001CE90 File Offset: 0x0001B090
		public void ResetOrientation()
		{
			this.lXpcFamxsQDcUXiSZAIBlQkqusPg = Quaternion.identity;
			this.tVFvtcNWNgpqczHZpImVxHJEhXDZ = false;
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x060016B5 RID: 5813 RVA: 0x00012219 File Offset: 0x00010419
		public int MaxTouches
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x060016B6 RID: 5814 RVA: 0x0004D7CC File Offset: 0x0004B9CC
		public int GetTouchCount()
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL[i].isTouching)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x0001C9FC File Offset: 0x0001ABFC
		public bool IsTouchingAtIndex(int index)
		{
			return index >= 0 && index < 2 && this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL[index].isTouching;
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x0001CA20 File Offset: 0x0001AC20
		public bool IsTouchingAtTouchId(int touchId)
		{
			return this.touchpads[0].tgKrcXnHuYRQqdFCcKwYoFPjhrei(touchId);
		}

		// Token: 0x060016B9 RID: 5817 RVA: 0x0001CA30 File Offset: 0x0001AC30
		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL[index].touchId;
		}

		// Token: 0x060016BA RID: 5818 RVA: 0x0004D808 File Offset: 0x0004BA08
		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			if (index < 0 || index >= 2)
			{
				return false;
			}
			zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] mbGotkNspciCdWUfwbxMijjJnXsL = this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL;
			if (!mbGotkNspciCdWUfwbxMijjJnXsL[index].isTouching)
			{
				return false;
			}
			position.x = mbGotkNspciCdWUfwbxMijjJnXsL[index].positionX;
			position.y = mbGotkNspciCdWUfwbxMijjJnXsL[index].positionY;
			return true;
		}

		// Token: 0x060016BB RID: 5819 RVA: 0x0004D86C File Offset: 0x0004BA6C
		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!this.touchpads[0].tgKrcXnHuYRQqdFCcKwYoFPjhrei(touchId))
			{
				return false;
			}
			zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] mbGotkNspciCdWUfwbxMijjJnXsL = this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL;
			for (int i = 0; i < mbGotkNspciCdWUfwbxMijjJnXsL.Length; i++)
			{
				if (mbGotkNspciCdWUfwbxMijjJnXsL[i].isTouching)
				{
					position.x = mbGotkNspciCdWUfwbxMijjJnXsL[i].positionX;
					position.y = mbGotkNspciCdWUfwbxMijjJnXsL[i].positionY;
				}
			}
			return true;
		}

		// Token: 0x060016BC RID: 5820 RVA: 0x0004D8E4 File Offset: 0x0004BAE4
		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (index < 0 || index >= 2)
			{
				return false;
			}
			zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] mbGotkNspciCdWUfwbxMijjJnXsL = this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL;
			if (!mbGotkNspciCdWUfwbxMijjJnXsL[index].isTouching)
			{
				return false;
			}
			positionX = mbGotkNspciCdWUfwbxMijjJnXsL[index].positionAbsX;
			positionY = mbGotkNspciCdWUfwbxMijjJnXsL[index].positionAbsY;
			return true;
		}

		// Token: 0x060016BD RID: 5821 RVA: 0x0004D93C File Offset: 0x0004BB3C
		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!this.touchpads[0].tgKrcXnHuYRQqdFCcKwYoFPjhrei(touchId))
			{
				return false;
			}
			zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] mbGotkNspciCdWUfwbxMijjJnXsL = this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL;
			for (int i = 0; i < mbGotkNspciCdWUfwbxMijjJnXsL.Length; i++)
			{
				if (mbGotkNspciCdWUfwbxMijjJnXsL[i].isTouching)
				{
					positionX = mbGotkNspciCdWUfwbxMijjJnXsL[i].positionAbsX;
					positionY = mbGotkNspciCdWUfwbxMijjJnXsL[i].positionAbsY;
				}
			}
			return true;
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x0001CEA4 File Offset: 0x0001B0A4
		public void StopLightFlash()
		{
			this.SfRAeVzugzILGbOCSSwryoGerodwA = 0;
			this.kerQgGFWlGmhEiPxDehEgbgCTIBT = 0;
			this.gCnQQHqHpSclFaaTMOMpkOHErIOi = true;
			this.yQCmSaTdflMzXQrUqeWxOpoRxhfK = true;
			this.BjUdifCHajkCysHjEpiiAZnmasxM = true;
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x0004D9A8 File Offset: 0x0004BBA8
		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			for (int i = 0; i < vibrationMotorCount; i++)
			{
				this.vibrationMotors[i].jytYrChQDenkTUaEnqBMeGDoorVS = 0;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x060016C0 RID: 5824 RVA: 0x0001CEC9 File Offset: 0x0001B0C9
		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				return this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.vendorId;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x060016C1 RID: 5825 RVA: 0x0001CED6 File Offset: 0x0001B0D6
		ushort IHIDControllerExtension.productId
		{
			get
			{
				return this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.productId;
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x060016C2 RID: 5826 RVA: 0x0001CEE3 File Offset: 0x0001B0E3
		string IHIDControllerExtension.productName
		{
			get
			{
				return this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.productName;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x060016C3 RID: 5827 RVA: 0x0001CEF0 File Offset: 0x0001B0F0
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				return this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.manufacturer;
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x060016C4 RID: 5828 RVA: 0x0001CEFD File Offset: 0x0001B0FD
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				return this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.usagePage;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x060016C5 RID: 5829 RVA: 0x0001CF0A File Offset: 0x0001B10A
		ushort IHIDControllerExtension.usage
		{
			get
			{
				return this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.usage;
			}
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x00050018 File Offset: 0x0004E218
		public DualShock4Driver(HIDDeviceDriver.InitArgs A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			this.MPqBVRXerrPAsUWttcBpiZiwuJeh = A_1.hidDevice;
			this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd = this.MPqBVRXerrPAsUWttcBpiZiwuJeh.properties;
			this.KRBwQTiHzeQbWvMgaySNvbkXRzWg = A_1.hatZeroValue;
			this.hCEVGQvbyxrGFtIkpvinmfiICiGiA = A_1.hatSpan;
			this.pIrCMfasGXMrNUmMhDMogqnCsPwJb = A_1.connectionType;
			this.BXYEClcspwHrgusOwWQcYfEWkDYy = (this.pIrCMfasGXMrNUmMhDMogqnCsPwJb == srhddSmbipxLrwlIqjetZPjyhATp.Bluetooth);
			if (this.BXYEClcspwHrgusOwWQcYfEWkDYy)
			{
				this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.maxOutputReportLength = 78;
			}
			if (this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.maxOutputReportLength < 23)
			{
				this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.maxOutputReportLength = 23;
			}
			this.ZoIqpaEhbldximcXPXAseJCwwNaj = new NativeBuffer(64);
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf = new NativeBuffer(this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.maxOutputReportLength);
			this.zbGkoPaYAhvqTpKORPKzEEbmDPaG = new AWHWYMjOaGiEqJCCtAEpfhRJAtYq(this.tfvTgBPTbSCyUcYxvOctQcXXRNsf.Pointer, this.tfvTgBPTbSCyUcYxvOctQcXXRNsf.Length, this.qYzbsbnIIlcDxlhWAfyQAhkdAvGd.maxOutputReportLength);
			this.lights = new XKforwyiippWnEqzvPiJMMmSIoUfA[]
			{
				new XKforwyiippWnEqzvPiJMMmSIoUfA(11, 24, 28)
			};
			this.lights[0].yJbfInhGiJsJTYGNoUbQXlGorbpp += this.BOHAJpArWFfpkqpcAWpdvajMQkyL;
			this.TAqJHfanUmJXnzuOsJloSsxGfUOR = true;
			this.vibrationMotors = new UnptiYUxBEDyXRujUEnkdeIKIoPk[]
			{
				new UnptiYUxBEDyXRujUEnkdeIKIoPk(0, 255),
				new UnptiYUxBEDyXRujUEnkdeIKIoPk(0, 255)
			};
			this.vibrationMotors[0].ztNbeMSTMsaUVsclhemevRUkIIOp += this.IyWkvULgZscKDdhwqFablshbgbkW;
			this.vibrationMotors[1].ztNbeMSTMsaUVsclhemevRUkIIOp += this.IyWkvULgZscKDdhwqFablshbgbkW;
			if (this.MPqBVRXerrPAsUWttcBpiZiwuJeh.GetHidFeatureData(2, 37, 1000, 3) == null)
			{
				throw new Exception();
			}
			this.YuiCMUTIPqvvqCOLLwtliBTeeoBIA = true;
			if (this.BXYEClcspwHrgusOwWQcYfEWkDYy)
			{
				this.sLfLDhcfHICrpPzpcmUIySLAZsdc = true;
				this.zbGkoPaYAhvqTpKORPKzEEbmDPaG.VFcPLOdKGWJLUQiPVizWfUYDMaON = (this.zbGkoPaYAhvqTpKORPKzEEbmDPaG.VFcPLOdKGWJLUQiPVizWfUYDMaON | UJcTHgtazRRmIgoeHeVUoZaJEtEL.WriteDirect);
				this.sLfLDhcfHICrpPzpcmUIySLAZsdc = this.eYeDospHHRIIFEyXxEIaOwDfMGKTA(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
				if (!this.sLfLDhcfHICrpPzpcmUIySLAZsdc)
				{
					this.zbGkoPaYAhvqTpKORPKzEEbmDPaG.VFcPLOdKGWJLUQiPVizWfUYDMaON = (this.zbGkoPaYAhvqTpKORPKzEEbmDPaG.VFcPLOdKGWJLUQiPVizWfUYDMaON & ~UJcTHgtazRRmIgoeHeVUoZaJEtEL.WriteDirect);
				}
			}
			else
			{
				this.sLfLDhcfHICrpPzpcmUIySLAZsdc = this.eYeDospHHRIIFEyXxEIaOwDfMGKTA(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
			}
			if (!this.sLfLDhcfHICrpPzpcmUIySLAZsdc)
			{
				throw new Exception();
			}
			this.YnzQwiGsLpltXkuwJUbJywWoebJv = 1;
			this.OasYpuEKjyAqXHenJFlIyJMRxbLHA = 0;
			if (this.BXYEClcspwHrgusOwWQcYfEWkDYy && this.sLfLDhcfHICrpPzpcmUIySLAZsdc)
			{
				this.YnzQwiGsLpltXkuwJUbJywWoebJv = 17;
				this.OasYpuEKjyAqXHenJFlIyJMRxbLHA = 2;
			}
			this.EzmljccEngEHuMgWPRstbQGlQlyl = 5 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA;
			this.WPwDrKyEFMXAvnhgCrjuaAeByzgh = 6 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA;
			this.WhoJbdxSIdmLTAGfAXdVlKSqdPvh = 7 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA;
			this.buttons = new bsHiSnxdPKGTmlVVXzABmREfuPAX[14];
			for (int i = 0; i < 14; i++)
			{
				this.buttons[i] = new bsHiSnxdPKGTmlVVXzABmREfuPAX(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			this.axes = new WlBhllbxXziYUoZmsblPearfaCpbA[]
			{
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0U,
					unitsExp = 0U
				}, false, 0),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0U,
					unitsExp = 0U
				}, false, 0)
			};
			this.hats = new oPOwiIBMGNECtKWjLBTodfZcpRzbB[]
			{
				new oPOwiIBMGNECtKWjLBTodfZcpRzbB(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20U,
					unitsExp = 0U
				}, new Func<int, int>(this.xOSVvVBdcufThUKSrlZviwghmvji))
			};
			this.accelerometers = new VowBBGCdjJGeVmPjtscFISvyEvTtA[]
			{
				new VowBBGCdjJGeVmPjtscFISvyEvTtA(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 48
				}, 3, new Action<byte[], float[]>(this.wrcFdJIfRuyfkrbrwimnzLvIeHYx))
			};
			this.gyroscopes = new TDbKvyrtcOKmakPyYMqLcuNLqPbe[]
			{
				new TDbKvyrtcOKmakPyYMqLcuNLqPbe(A_1.updateLoopSetting, this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 48
				}, 3, 60, new Action<byte[], float[]>(this.dJMrJpGePYeZngXsuEaaeBOONZSdb), new Func<float>(this.WwFkvUaACLXySGuxwTugsscwuxGd))
			};
			this.touchpads = new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA[]
			{
				new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA(this.YnzQwiGsLpltXkuwJUbJywWoebJv, new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA,
					bitSize = 48
				}, 60, new Action<NativeBuffer, zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[]>(this.eecEhDvBSKttVEcDRQxiRQCkhtDE))
			};
			this.OryNRCVgPtiEtAhvqIkJZRhYVJeAA = ReInput.realTime;
		}

		// Token: 0x060016C7 RID: 5831 RVA: 0x0001CF17 File Offset: 0x0001B117
		public override void Update(UpdateLoopType updateLoop)
		{
			this.FKOFrwDBHUHQOfnDOTQvTMQDRezC();
			this.nPMShtwJilAmnyMqmkDyIubUOTqj(xvcebytMmHXPBmUQiJYMACsdJpLo.Asynchronous);
		}

		// Token: 0x060016C8 RID: 5832 RVA: 0x00050724 File Offset: 0x0004E924
		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < this.ZoIqpaEhbldximcXPXAseJCwwNaj.Length)
			{
				return false;
			}
			this.PDoJrhnmlgEVByVJbthTPUMdpLUm = (float)(timestamp - this.OryNRCVgPtiEtAhvqIkJZRhYVJeAA);
			this.OryNRCVgPtiEtAhvqIkJZRhYVJeAA = timestamp;
			this.ZoIqpaEhbldximcXPXAseJCwwNaj.Write(inputReportPtr, inputReportLength, this.ZoIqpaEhbldximcXPXAseJCwwNaj.Length, 0, 0);
			this.aSMDiRmwLodIeUddFSSFhjDEaTjJA(this.ZoIqpaEhbldximcXPXAseJCwwNaj);
			this.gTwoYzTypJpneZEdTgJdmxDyjQhh(this.ZoIqpaEhbldximcXPXAseJCwwNaj, timestamp);
			zHTBvVyhFGDLpEJMFINchPNfqnfnb[] array = this.axes;
			this.YEAghqUVBFkaqpgsAfZhjjfzCqXcA(array, this.ZoIqpaEhbldximcXPXAseJCwwNaj, timestamp);
			array = this.hats;
			this.YEAghqUVBFkaqpgsAfZhjjfzCqXcA(array, this.ZoIqpaEhbldximcXPXAseJCwwNaj, timestamp);
			array = this.accelerometers;
			this.YEAghqUVBFkaqpgsAfZhjjfzCqXcA(array, this.ZoIqpaEhbldximcXPXAseJCwwNaj, timestamp);
			array = this.gyroscopes;
			this.YEAghqUVBFkaqpgsAfZhjjfzCqXcA(array, this.ZoIqpaEhbldximcXPXAseJCwwNaj, timestamp);
			array = this.touchpads;
			this.YEAghqUVBFkaqpgsAfZhjjfzCqXcA(array, this.ZoIqpaEhbldximcXPXAseJCwwNaj, timestamp);
			byte b = this.ZoIqpaEhbldximcXPXAseJCwwNaj[30 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA];
			byte b2 = b & 15;
			if ((b & 16) != 0)
			{
				if (b2 <= 10)
				{
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = MathTools.Clamp((int)(b2 * 10 + 5), 0, 100);
					this.lAPogrRHsVgbxiAQUvwPDjjskmSgb = DualShock4Driver.hxXaJMCeImyVOgpiHOxLyEIdFmvLA.Charging;
				}
				else
				{
					switch (b2)
					{
					case 11:
						this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 100;
						this.lAPogrRHsVgbxiAQUvwPDjjskmSgb = DualShock4Driver.hxXaJMCeImyVOgpiHOxLyEIdFmvLA.Full;
						goto IL_201;
					case 14:
						this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 0;
						this.lAPogrRHsVgbxiAQUvwPDjjskmSgb = DualShock4Driver.hxXaJMCeImyVOgpiHOxLyEIdFmvLA.Charging;
						goto IL_201;
					}
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 0;
					this.lAPogrRHsVgbxiAQUvwPDjjskmSgb = DualShock4Driver.hxXaJMCeImyVOgpiHOxLyEIdFmvLA.Unknown;
				}
			}
			else
			{
				switch (MathTools.Clamp((int)b2, 0, 8))
				{
				case 0:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 5;
					break;
				case 1:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 20;
					break;
				case 2:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 30;
					break;
				case 3:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 45;
					break;
				case 4:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 55;
					break;
				case 5:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 70;
					break;
				case 6:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 80;
					break;
				case 7:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 95;
					break;
				case 8:
					this.ZBiiQhFzxHVmsIPLnAfbNGisMJJAb = 100;
					break;
				}
				this.lAPogrRHsVgbxiAQUvwPDjjskmSgb = DualShock4Driver.hxXaJMCeImyVOgpiHOxLyEIdFmvLA.Discharging;
			}
			IL_201:
			this.IZPjXlbQePpAJfETndsKDfIKlSQU();
			return true;
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x0001CF26 File Offset: 0x0001B126
		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		// Token: 0x060016CA RID: 5834 RVA: 0x0001CF2E File Offset: 0x0001B12E
		private void nPMShtwJilAmnyMqmkDyIubUOTqj(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			if (!this.gCnQQHqHpSclFaaTMOMpkOHErIOi)
			{
				return;
			}
			this.eYeDospHHRIIFEyXxEIaOwDfMGKTA(A_1);
			this.gCnQQHqHpSclFaaTMOMpkOHErIOi = false;
		}

		// Token: 0x060016CB RID: 5835 RVA: 0x0005093C File Offset: 0x0004EB3C
		private bool eYeDospHHRIIFEyXxEIaOwDfMGKTA(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			this.XgtCHIuWaPlMjlMYfhaUaYNEiagw();
			bool result = this.aRrEpuitVnvFxjQiOVjeiQXYAIrCb(A_1);
			if (this.yQCmSaTdflMzXQrUqeWxOpoRxhfK)
			{
				result = this.aRrEpuitVnvFxjQiOVjeiQXYAIrCb(A_1);
				this.yQCmSaTdflMzXQrUqeWxOpoRxhfK = false;
			}
			return result;
		}

		// Token: 0x060016CC RID: 5836 RVA: 0x00050970 File Offset: 0x0004EB70
		private unsafe void XgtCHIuWaPlMjlMYfhaUaYNEiagw()
		{
			byte b = 0;
			b |= 1;
			this.gDHafEhtgsvfUMVrETdSZISKydLy = false;
			b |= 2;
			this.TAqJHfanUmJXnzuOsJloSsxGfUOR = false;
			b |= 4;
			this.BjUdifCHajkCysHjEpiiAZnmasxM = false;
			byte b2 = 128;
			if (this.BXYEClcspwHrgusOwWQcYfEWkDYy)
			{
				b2 |= 64;
			}
			if (this.YuiCMUTIPqvvqCOLLwtliBTeeoBIA)
			{
				b2 |= 4;
				this.YuiCMUTIPqvvqCOLLwtliBTeeoBIA = false;
			}
			if (this.BXYEClcspwHrgusOwWQcYfEWkDYy && this.sLfLDhcfHICrpPzpcmUIySLAZsdc)
			{
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[0] = 17;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[1] = b2;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[2] = 0;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[3] = b;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[4] = 0;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[5] = 0;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[6] = (byte)this.vibrationMotors[1].jytYrChQDenkTUaEnqBMeGDoorVS;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[7] = (byte)this.vibrationMotors[0].jytYrChQDenkTUaEnqBMeGDoorVS;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[8] = this.lights[0].TlvlHFiErUcjYOwvLtmUwbOdHcBfA;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[9] = this.lights[0].PWTUXhdobKCWkDPPBdKjnUKMnFly;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[10] = this.lights[0].vyzFPPOkFkdeNAGombLrQBWeWzFsA;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[11] = this.SfRAeVzugzILGbOCSSwryoGerodwA;
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[12] = this.kerQgGFWlGmhEiPxDehEgbgCTIBT;
				int wecDRwdtVamuAIClsAVTsQSmECoTA = this.zbGkoPaYAhvqTpKORPKzEEbmDPaG.wecDRwdtVamuAIClsAVTsQSmECoTA;
				uint bytes = DualShock4Driver.RLmmLsymrbjkMaPKYccvemUbVhnU.DJtFhMBUMEwegTeoykJVAYIsmfGFb((byte*)((void*)this.tfvTgBPTbSCyUcYxvOctQcXXRNsf.Pointer), wecDRwdtVamuAIClsAVTsQSmECoTA - 4, 162U);
				this.tfvTgBPTbSCyUcYxvOctQcXXRNsf.Write(bytes, wecDRwdtVamuAIClsAVTsQSmECoTA - 4);
				return;
			}
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[0] = 5;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[1] = b;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[2] = 0;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[4] = (byte)this.vibrationMotors[1].jytYrChQDenkTUaEnqBMeGDoorVS;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[5] = (byte)this.vibrationMotors[0].jytYrChQDenkTUaEnqBMeGDoorVS;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[6] = this.lights[0].TlvlHFiErUcjYOwvLtmUwbOdHcBfA;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[7] = this.lights[0].PWTUXhdobKCWkDPPBdKjnUKMnFly;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[8] = this.lights[0].vyzFPPOkFkdeNAGombLrQBWeWzFsA;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[9] = this.SfRAeVzugzILGbOCSSwryoGerodwA;
			this.tfvTgBPTbSCyUcYxvOctQcXXRNsf[10] = this.kerQgGFWlGmhEiPxDehEgbgCTIBT;
		}

		// Token: 0x060016CD RID: 5837 RVA: 0x00050BE0 File Offset: 0x0004EDE0
		private bool aRrEpuitVnvFxjQiOVjeiQXYAIrCb(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			this.WsXmOeraeAcgJCvmvlGBJGKdpVDBb = ReInput.realTime + 4.0;
			if (A_1 == xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous)
			{
				return this.MPqBVRXerrPAsUWttcBpiZiwuJeh.WriteSync(this.zbGkoPaYAhvqTpKORPKzEEbmDPaG, 0);
			}
			if (A_1 == xvcebytMmHXPBmUQiJYMACsdJpLo.Asynchronous)
			{
				this.MPqBVRXerrPAsUWttcBpiZiwuJeh.WriteAsync(this.zbGkoPaYAhvqTpKORPKzEEbmDPaG, 1000);
				return true;
			}
			throw new NotImplementedException();
		}

		// Token: 0x060016CE RID: 5838 RVA: 0x00050C3C File Offset: 0x0004EE3C
		private void gTwoYzTypJpneZEdTgJdmxDyjQhh(NativeBuffer A_1, double A_2)
		{
			byte b = A_1[this.EzmljccEngEHuMgWPRstbQGlQlyl];
			this.buttons[0].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 16) > 0, A_2);
			this.buttons[1].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 32) > 0, A_2);
			this.buttons[2].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 64) > 0, A_2);
			this.buttons[3].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 128) > 0, A_2);
			b = A_1[this.WPwDrKyEFMXAvnhgCrjuaAeByzgh];
			this.buttons[4].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 1) > 0, A_2);
			this.buttons[5].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 2) > 0, A_2);
			this.buttons[6].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 4) > 0, A_2);
			this.buttons[7].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 8) > 0, A_2);
			this.buttons[8].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 16) > 0, A_2);
			this.buttons[9].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 32) > 0, A_2);
			this.buttons[10].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 64) > 0, A_2);
			this.buttons[11].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 128) > 0, A_2);
			b = A_1[this.WhoJbdxSIdmLTAGfAXdVlKSqdPvh];
			this.buttons[12].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 1) > 0, A_2);
			this.buttons[13].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 2) > 0, A_2);
		}

		// Token: 0x060016CF RID: 5839 RVA: 0x0004E9C4 File Offset: 0x0004CBC4
		private void YEAghqUVBFkaqpgsAfZhjjfzCqXcA(zHTBvVyhFGDLpEJMFINchPNfqnfnb[] A_1, NativeBuffer A_2, double A_3)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				A_1[i].WMAwtKiWRygWRqyRkTqlMnhmDEdgA(A_2, A_3);
			}
		}

		// Token: 0x060016D0 RID: 5840 RVA: 0x0001CF48 File Offset: 0x0001B148
		private void FKOFrwDBHUHQOfnDOTQvTMQDRezC()
		{
			if (this.isVibrating && ReInput.realTime >= this.WsXmOeraeAcgJCvmvlGBJGKdpVDBb)
			{
				this.gCnQQHqHpSclFaaTMOMpkOHErIOi = true;
				this.gDHafEhtgsvfUMVrETdSZISKydLy = true;
			}
		}

		// Token: 0x060016D1 RID: 5841 RVA: 0x00050D9C File Offset: 0x0004EF9C
		private void aSMDiRmwLodIeUddFSSFhjDEaTjJA(NativeBuffer A_1)
		{
			if (!this.sLfLDhcfHICrpPzpcmUIySLAZsdc)
			{
				return;
			}
			ushort num = this.ZoIqpaEhbldximcXPXAseJCwwNaj.ReadUShort(10 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA);
			float vrlnVyBiHYyzNvvDmUXQTvdhoBKE;
			if (num != this.WKdgXNaRyIRudedsoilvTrrHOEZw)
			{
				int num2;
				if (num < this.WKdgXNaRyIRudedsoilvTrrHOEZw)
				{
					num2 = (int)(num + ushort.MaxValue - this.WKdgXNaRyIRudedsoilvTrrHOEZw);
				}
				else
				{
					num2 = (int)(num - this.WKdgXNaRyIRudedsoilvTrrHOEZw);
				}
				vrlnVyBiHYyzNvvDmUXQTvdhoBKE = (float)num2 / 187500f;
			}
			else
			{
				vrlnVyBiHYyzNvvDmUXQTvdhoBKE = 0f;
			}
			this.WKdgXNaRyIRudedsoilvTrrHOEZw = num;
			this.VRLnVyBiHYyzNvvDmUXQTvdhoBKE = vrlnVyBiHYyzNvvDmUXQTvdhoBKE;
		}

		// Token: 0x060016D2 RID: 5842 RVA: 0x00050E14 File Offset: 0x0004F014
		private void IZPjXlbQePpAJfETndsKDfIKlSQU()
		{
			if (!this.sLfLDhcfHICrpPzpcmUIySLAZsdc)
			{
				return;
			}
			float vrlnVyBiHYyzNvvDmUXQTvdhoBKE = this.VRLnVyBiHYyzNvvDmUXQTvdhoBKE;
			Vector3 vector = this.BVItPzaNAyNQjADNrktCzWxwUOdK(new Vector3(this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[0], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[1], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[2]), this.VRLnVyBiHYyzNvvDmUXQTvdhoBKE);
			DualShock4Driver.LPqsurSJNedsuUKHgXAQpokeeNNE(ref vector);
			Vector3 vector2 = new Vector3(this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[0] * -1f, this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[1] * -1f, this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[2] * -1f);
			this.XZSKMJvbsHkFPtUxGMFqFLzuAgeB(vector2, vector);
		}

		// Token: 0x060016D3 RID: 5843 RVA: 0x0001CB57 File Offset: 0x0001AD57
		private static bool LPqsurSJNedsuUKHgXAQpokeeNNE(ref Vector3 A_0)
		{
			if (A_0.magnitude < 0.004f)
			{
				A_0.x = 0f;
				A_0.y = 0f;
				A_0.z = 0f;
				return false;
			}
			return true;
		}

		// Token: 0x060016D4 RID: 5844 RVA: 0x00050ECC File Offset: 0x0004F0CC
		private void XZSKMJvbsHkFPtUxGMFqFLzuAgeB(Vector3 A_1, Vector3 A_2)
		{
			Quaternion rhs = Quaternion.Euler(A_2);
			float sqrMagnitude = A_1.sqrMagnitude;
			DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV lnmnzvxfbhgXbYVhgDOdUGxQnHsV;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && this.ojKWgMLTEbqGrotluISpKVaBnSDB(A_1, out lnmnzvxfbhgXbYVhgDOdUGxQnHsV))
			{
				Quaternion a = this.lXpcFamxsQDcUXiSZAIBlQkqusPg * rhs;
				if (!this.tVFvtcNWNgpqczHZpImVxHJEhXDZ)
				{
					this.tVFvtcNWNgpqczHZpImVxHJEhXDZ = true;
					this.MPuZkstKqbhVTrcHVEgrOtojAlLu = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					this.SokGXMyiyqrgPQyGcXeuBVxcIiKd = this.lXpcFamxsQDcUXiSZAIBlQkqusPg;
				}
				this.MPuZkstKqbhVTrcHVEgrOtojAlLu *= rhs;
				this.SokGXMyiyqrgPQyGcXeuBVxcIiKd *= rhs;
				Quaternion quaternion;
				if ((lnmnzvxfbhgXbYVhgDOdUGxQnHsV & DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV.XZ) != DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV.None)
				{
					quaternion = this.GpdMPRtQjWKbOrongjvYUXyjMOsj(A_1, a.eulerAngles.y);
				}
				else if ((lnmnzvxfbhgXbYVhgDOdUGxQnHsV & DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV.Y) != DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV.None)
				{
					quaternion = this.SpntEcrTSZRvNauFxNgzzjEYynxs(A_1, 0f);
					Vector3 vector = this.SokGXMyiyqrgPQyGcXeuBVxcIiKd * Vector3.right;
					float y = -MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					quaternion = Quaternion.Euler(0f, y, 0f) * quaternion;
				}
				else
				{
					quaternion = Quaternion.identity;
				}
				this.lXpcFamxsQDcUXiSZAIBlQkqusPg = Quaternion.Lerp(a, quaternion, 0.01999998f);
				return;
			}
			this.lXpcFamxsQDcUXiSZAIBlQkqusPg *= rhs;
			if (this.tVFvtcNWNgpqczHZpImVxHJEhXDZ)
			{
				this.tVFvtcNWNgpqczHZpImVxHJEhXDZ = false;
			}
		}

		// Token: 0x060016D5 RID: 5845 RVA: 0x00051044 File Offset: 0x0004F244
		private static Quaternion HABLsFIlqhEikgfHMVARboquvhyT(Quaternion A_0, Vector3 A_1)
		{
			Vector3 vector = DualShock4Driver.ySEGpmNXSTEplCEYbBDUxZOOHmrwA(new Vector3(A_0.x, A_0.y, A_0.z), A_1);
			return new Quaternion(vector.x, vector.y, vector.z, A_0.w);
		}

		// Token: 0x060016D6 RID: 5846 RVA: 0x0004ECE4 File Offset: 0x0004CEE4
		private static Vector3 ySEGpmNXSTEplCEYbBDUxZOOHmrwA(Vector3 A_0, Vector3 A_1)
		{
			float num = Vector3.Dot(A_1, A_1);
			if (num < 1E-45f)
			{
				return Vector3.zero;
			}
			return A_1 * Vector3.Dot(A_0, A_1) / num;
		}

		// Token: 0x060016D7 RID: 5847 RVA: 0x0004ED1C File Offset: 0x0004CF1C
		private Quaternion jagZKHhNlUBXyAfttsNYRyUfhxoV(Quaternion A_1, DualShock4Driver.ZgjtIhlEdwHmyyRjWkNZDgOsQvrq A_2)
		{
			Vector4 vector = default(Vector4);
			if (MathTools.Approximately(A_1.w, 0f) && MathTools.Approximately(A_1[(int)A_2], 0f))
			{
				A_1 = Quaternion.identity;
			}
			else
			{
				float num = A_1[(int)A_2];
				float num2 = MathTools.Sqrt(A_1.w * A_1.w + num * num);
				vector[3] = A_1.w / num2;
				vector[(int)A_2] = num / num2;
				A_1 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
			}
			return A_1;
		}

		// Token: 0x060016D8 RID: 5848 RVA: 0x0004EDC8 File Offset: 0x0004CFC8
		public static Quaternion Inverse(Quaternion quaternion)
		{
			float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
			float num2 = 1f / num;
			Quaternion result;
			result.x = -quaternion.x * num2;
			result.y = -quaternion.y * num2;
			result.z = -quaternion.z * num2;
			result.w = quaternion.w * num2;
			return result;
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0004EE58 File Offset: 0x0004D058
		private float OaUxCRfyQhrQXrsUJEvygeQhaYCY(float A_1, float A_2)
		{
			A_1 = MathTools.ClampAngle360(A_1);
			A_2 = MathTools.ClampAngle360(A_2);
			if (A_1 == A_2)
			{
				return 0f;
			}
			if (A_1 >= 180f)
			{
				A_1 -= 360f;
			}
			if (A_2 >= 180f)
			{
				A_2 -= 360f;
			}
			return A_1 - A_2;
		}

		// Token: 0x060016DA RID: 5850 RVA: 0x0004EEA4 File Offset: 0x0004D0A4
		private Vector3 oGelUXTrzYPdeLgiQzqziVsYnQFm(Vector3 A_1, float A_2 = 0f)
		{
			float num = MathTools.Atan2(A_1.z, A_1.y);
			float x = MathTools.Sqrt(MathTools.Pow(A_1.y, 2f) + MathTools.Pow(A_1.z, 2f));
			float num2 = MathTools.Atan2(A_1.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = -num2 * 57.29578f;
			return new Vector3(x2, A_2, z);
		}

		// Token: 0x060016DB RID: 5851 RVA: 0x0004EF14 File Offset: 0x0004D114
		private Quaternion GpdMPRtQjWKbOrongjvYUXyjMOsj(Vector3 A_1, float A_2 = 0f)
		{
			float num = MathTools.Atan2(A_1.z, A_1.y);
			float x = MathTools.Sqrt(MathTools.Pow(A_1.y, 2f) + MathTools.Pow(A_1.z, 2f));
			float num2 = MathTools.Atan2(A_1.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = -num2 * 57.29578f;
			return Quaternion.Euler(x2, A_2, z);
		}

		// Token: 0x060016DC RID: 5852 RVA: 0x0004EF84 File Offset: 0x0004D184
		private Quaternion SpntEcrTSZRvNauFxNgzzjEYynxs(Vector3 A_1, float A_2 = 0f)
		{
			float num = MathTools.Atan2(A_1.z, A_1.y);
			float x = MathTools.Sqrt(MathTools.Pow(A_1.y, 2f) + MathTools.Pow(A_1.z, 2f));
			float num2 = MathTools.Atan2(A_1.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = -num2 * 57.29578f;
			Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x2, 0f, 0f);
			if (A_2 != 0f)
			{
				return quaternion * Quaternion.Euler(0f, A_2, 0f);
			}
			return quaternion;
		}

		// Token: 0x060016DD RID: 5853 RVA: 0x0001CB8A File Offset: 0x0001AD8A
		private float vKlFZmJUajSMrOfFmIQMHfwOphdK(Vector3 A_1)
		{
			return MathTools.Atan2(A_1.x, A_1.z) * 57.29578f;
		}

		// Token: 0x060016DE RID: 5854 RVA: 0x0001CBA3 File Offset: 0x0001ADA3
		private bool lYZXWyDfjEgkUTyMRJnIFZDlABGq(float A_1)
		{
			return A_1 >= 45f && A_1 <= 70f;
		}

		// Token: 0x060016DF RID: 5855 RVA: 0x0005108C File Offset: 0x0004F28C
		private bool ojKWgMLTEbqGrotluISpKVaBnSDB(Vector3 A_1, out DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV A_2)
		{
			A_1.Normalize();
			A_2 = DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV.None;
			bool result = false;
			if (this.pVWiGtrMmtZoWiBQvmYNUTylETET(A_1))
			{
				result = true;
				A_2 |= DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV.XZ;
			}
			if (this.ktrlFqzKayaVEIKIsqSuUkvvNgLG(A_1))
			{
				result = true;
				A_2 |= DualShock4Driver.LNMNZVXFBhgXbYVhgDOdUGxQnHsV.Y;
			}
			return result;
		}

		// Token: 0x060016E0 RID: 5856 RVA: 0x0001CBBA File Offset: 0x0001ADBA
		private bool pVWiGtrMmtZoWiBQvmYNUTylETET(Vector3 A_1)
		{
			return A_1.y <= 0f && Vector3.Angle(Vector3.down, A_1) <= 45f;
		}

		// Token: 0x060016E1 RID: 5857 RVA: 0x0001CBE0 File Offset: 0x0001ADE0
		private bool ktrlFqzKayaVEIKIsqSuUkvvNgLG(Vector3 A_1)
		{
			return A_1.z >= 0f && Vector3.Angle(new Vector3(0f, 0f, 1f), A_1) <= 20f;
		}

		// Token: 0x060016E2 RID: 5858 RVA: 0x0001CC15 File Offset: 0x0001AE15
		private Vector3 ilmBjbrBieIFBiZstRJYwfyJshgiA(float[] A_1)
		{
			return new Vector3(A_1[0] * 0.00012207031f * -1f, A_1[1] * 0.00012207031f * -1f, A_1[2] * 0.00012207031f);
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x000510C8 File Offset: 0x0004F2C8
		private Vector3 gXArnmUiwPVLOAbfBwuCmsLzwCcu(RingBuffer<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA> A_1)
		{
			Vector3 vector = default(Vector3);
			int count = A_1.Count;
			for (int i = 0; i < count; i++)
			{
				TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA tfparbbNAvPzQuJwQCaWGkjzhFcEA = A_1[i];
				vector += this.BVItPzaNAyNQjADNrktCzWxwUOdK(tfparbbNAvPzQuJwQCaWGkjzhFcEA.pvLAGAwFJrHGOyvACtaBXkmQbXxf, tfparbbNAvPzQuJwQCaWGkjzhFcEA.LXxeqTTliOIfyvHMKPvmZGvcuGex);
			}
			return vector;
		}

		// Token: 0x060016E4 RID: 5860 RVA: 0x0001CC43 File Offset: 0x0001AE43
		private Vector3 BVItPzaNAyNQjADNrktCzWxwUOdK(Vector3 A_1, float A_2)
		{
			A_1.x *= -1f;
			A_1.y *= -1f;
			return A_1 * 0.06103702f * A_2;
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x0001CC76 File Offset: 0x0001AE76
		private int xOSVvVBdcufThUKSrlZviwghmvji(int A_1)
		{
			A_1 &= 15;
			return A_1;
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x0001CC7F File Offset: 0x0001AE7F
		private void wrcFdJIfRuyfkrbrwimnzLvIeHYx(byte[] A_1, float[] A_2)
		{
			A_2[0] = (float)BitConverter.ToInt16(A_1, 0);
			A_2[1] = (float)BitConverter.ToInt16(A_1, 2);
			A_2[2] = (float)BitConverter.ToInt16(A_1, 4);
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x0001CC7F File Offset: 0x0001AE7F
		private void dJMrJpGePYeZngXsuEaaeBOONZSdb(byte[] A_1, float[] A_2)
		{
			A_2[0] = (float)BitConverter.ToInt16(A_1, 0);
			A_2[1] = (float)BitConverter.ToInt16(A_1, 2);
			A_2[2] = (float)BitConverter.ToInt16(A_1, 4);
		}

		// Token: 0x060016E8 RID: 5864 RVA: 0x0001CF6D File Offset: 0x0001B16D
		private float WwFkvUaACLXySGuxwTugsscwuxGd()
		{
			return this.VRLnVyBiHYyzNvvDmUXQTvdhoBKE;
		}

		// Token: 0x060016E9 RID: 5865 RVA: 0x00051114 File Offset: 0x0004F314
		private void eecEhDvBSKttVEcDRQxiRQCkhtDE(NativeBuffer A_1, zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] A_2)
		{
			int num = 35 + this.OasYpuEKjyAqXHenJFlIyJMRxbLHA;
			int positionRawX = (int)(A_1[1 + num] + (A_1[2 + num] & 15) * byte.MaxValue);
			int positionRawY = ((A_1[2 + num] & 240) >> 4) + (int)(A_1[3 + num] * 16);
			int positionRawX2 = (int)(A_1[5 + num] + (A_1[6 + num] & 15) * byte.MaxValue);
			int positionRawY2 = ((A_1[6 + num] & 240) >> 4) + (int)(A_1[7 + num] * 16);
			byte b = A_1[num];
			bool flag = b < 128;
			byte b2 = A_1[num + 4];
			bool flag2 = b2 < 128;
			int num2 = (int)(b & 127);
			int num3 = (int)(b2 & 127);
			A_2[0].isTouching = flag;
			A_2[0].touchId = this.jKStgfzIVntRWqxSvRUAPTOaAjwb(0, flag, num2);
			A_2[0].positionRawX = positionRawX;
			A_2[0].positionRawY = positionRawY;
			A_2[1].isTouching = flag2;
			A_2[1].touchId = this.jKStgfzIVntRWqxSvRUAPTOaAjwb(1, flag2, num3);
			A_2[1].positionRawX = positionRawX2;
			A_2[1].positionRawY = positionRawY2;
		}

		// Token: 0x060016EA RID: 5866 RVA: 0x00051258 File Offset: 0x0004F458
		private int jKStgfzIVntRWqxSvRUAPTOaAjwb(int A_1, bool A_2, int A_3)
		{
			if (!A_2)
			{
				this.maLGtqBfTyMjpKHAsyYNAJsLdKNQ[A_1] = -1;
				this.ndrMhQYnLPaASCrlWSvUkgHCuXYb[A_1] = A_3;
				return -1;
			}
			if (A_3 != this.ndrMhQYnLPaASCrlWSvUkgHCuXYb[A_1])
			{
				int hmaPanMWDJAxOUamibchKBXVegqy = this.HmaPanMWDJAxOUamibchKBXVegqy;
				if (this.HmaPanMWDJAxOUamibchKBXVegqy == 2147483647)
				{
					this.HmaPanMWDJAxOUamibchKBXVegqy = 0;
				}
				else
				{
					this.HmaPanMWDJAxOUamibchKBXVegqy++;
				}
				this.ndrMhQYnLPaASCrlWSvUkgHCuXYb[A_1] = A_3;
				this.maLGtqBfTyMjpKHAsyYNAJsLdKNQ[A_1] = hmaPanMWDJAxOUamibchKBXVegqy;
				return hmaPanMWDJAxOUamibchKBXVegqy;
			}
			return this.maLGtqBfTyMjpKHAsyYNAJsLdKNQ[A_1];
		}

		// Token: 0x060016EB RID: 5867 RVA: 0x0001CF75 File Offset: 0x0001B175
		private void BOHAJpArWFfpkqpcAWpdvajMQkyL()
		{
			this.TAqJHfanUmJXnzuOsJloSsxGfUOR = true;
			this.yOuaqHwuQJZXabYqZdbqudjvtWsG();
		}

		// Token: 0x060016EC RID: 5868 RVA: 0x0001CF84 File Offset: 0x0001B184
		private void DYhWbMjfLDaNzHwRWwDfAasNLFxYA()
		{
			this.BjUdifCHajkCysHjEpiiAZnmasxM = true;
			this.yOuaqHwuQJZXabYqZdbqudjvtWsG();
		}

		// Token: 0x060016ED RID: 5869 RVA: 0x0001CF93 File Offset: 0x0001B193
		private void IyWkvULgZscKDdhwqFablshbgbkW()
		{
			this.gDHafEhtgsvfUMVrETdSZISKydLy = true;
			this.yOuaqHwuQJZXabYqZdbqudjvtWsG();
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x0001CFA2 File Offset: 0x0001B1A2
		private void yOuaqHwuQJZXabYqZdbqudjvtWsG()
		{
			this.gCnQQHqHpSclFaaTMOMpkOHErIOi = true;
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x0004F27C File Offset: 0x0004D47C
		~DualShock4Driver()
		{
			this.Dispose(false);
		}

		// Token: 0x060016F0 RID: 5872 RVA: 0x000512D0 File Offset: 0x0004F4D0
		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			base.Dispose(disposing);
			if (disposing)
			{
				this.StopVibration();
				this.nPMShtwJilAmnyMqmkDyIubUOTqj(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
				if (this.ZoIqpaEhbldximcXPXAseJCwwNaj != null)
				{
					this.ZoIqpaEhbldximcXPXAseJCwwNaj.Dispose();
				}
				if (this.tfvTgBPTbSCyUcYxvOctQcXXRNsf != null)
				{
					this.tfvTgBPTbSCyUcYxvOctQcXXRNsf.Dispose();
				}
			}
		}

		// Token: 0x060016F1 RID: 5873 RVA: 0x00051324 File Offset: 0x0004F524
		public static bool Matches(int vid, int pid)
		{
			for (int i = 0; i < Consts.pidVids_sony_dualShock4.Count; i++)
			{
				if ((int)Consts.pidVids_sony_dualShock4[i].vendorId == vid && (int)Consts.pidVids_sony_dualShock4[i].productId == pid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060016F2 RID: 5874 RVA: 0x0001CFAB File Offset: 0x0001B1AB
		[Conditional("DEBUG_THIS")]
		private static void IGoVcEqwctNozKBJWCiTcTAEmOfbA(object A_0)
		{
			Logger.Log(A_0, true);
		}

		// Token: 0x040031D9 RID: 12761
		private const float RrwKZAMioQoAFPAARGsGXhowAjKU = 4f;

		// Token: 0x040031DA RID: 12762
		private const int JCRvFKoaMEjqOmVSqtxWreoTrzDG = 14;

		// Token: 0x040031DB RID: 12763
		private const int GBdPjvDFRlzniICYQJQhOYYqoAtH = 2;

		// Token: 0x040031DC RID: 12764
		private const int ltbmoSairVKjHqCUDTizoqnvieZV = 0;

		// Token: 0x040031DD RID: 12765
		private const int ukIaOaUwKKuNbUvSuHKDrtEmbxiF = 1912;

		// Token: 0x040031DE RID: 12766
		private const int HlyWFyZoaBbVtMByHLGcXEQRBCOBA = 0;

		// Token: 0x040031DF RID: 12767
		private const int YpMUjSAcUIDORxPzibrHqBSkzhnd = 941;

		// Token: 0x040031E0 RID: 12768
		private const bool xTbGlVPnZIcwBboyydWYFwXpxLuIb = false;

		// Token: 0x040031E1 RID: 12769
		private const bool TgVUrQWivfCXOTAojmRFDbgenGbk = true;

		// Token: 0x040031E2 RID: 12770
		private const float nHxDvkTverHBogcMZFxLlryNuefKA = 2.5f;

		// Token: 0x040031E3 RID: 12771
		private const int UbPTmXczSWJqISjQwEycCNguifP = 0;

		// Token: 0x040031E4 RID: 12772
		private const int BZGRJlxTZZqAuccURlWHJgbEAcIs = 0;

		// Token: 0x040031E5 RID: 12773
		private const int nJRHkVPRQALKfKokRRXmGtmrqXPI = 1;

		// Token: 0x040031E6 RID: 12774
		private const int JKOsrYJZnkLQyKhAnhCaKcWCrwue = 0;

		// Token: 0x040031E7 RID: 12775
		private const int hNLdChhTsvbNvhdrEcROnwcUIsqXB = 0;

		// Token: 0x040031E8 RID: 12776
		private const int ghmZqVAChTBICRCMwVFBLMKOfDnx = 0;

		// Token: 0x040031E9 RID: 12777
		private const int crdqxVUeMeRQYEWZnqNWnJRSISbo = 1;

		// Token: 0x040031EA RID: 12778
		private const int jSkshcoshwEBCcUakOPiimjHPuufc = 17;

		// Token: 0x040031EB RID: 12779
		private const int zrhMxszAvSKAibkoMAtrKGmlXabVA = 0;

		// Token: 0x040031EC RID: 12780
		private const int EwpOuxMCyQVtcmiwyPbriGTcLuYq = 2;

		// Token: 0x040031ED RID: 12781
		private const int lwmQYIagZdFNNJNIwmigEwZmmHke = 64;

		// Token: 0x040031EE RID: 12782
		private const int QAjiEwQesqtmcnqVxZNTSySbDgAu = 78;

		// Token: 0x040031EF RID: 12783
		private const byte wDeRqzfmGZUecxdkyEvzoUuPvJbY = 17;

		// Token: 0x040031F0 RID: 12784
		private const byte KvwxljbdaWYklmbNstfJgxTYiuXx = 5;

		// Token: 0x040031F1 RID: 12785
		private const byte weQbXiGOpywmCJEqzxaNEiBQUFMF = 2;

		// Token: 0x040031F2 RID: 12786
		private const byte bkmycaaDGPGbiumjxVAAHGCBEDUI = 37;

		// Token: 0x040031F3 RID: 12787
		private const byte DAIvCWcFewYARbByEGYtGEYfnZxdA = 5;

		// Token: 0x040031F4 RID: 12788
		private const byte OepocnQLggDroiciKUzbCbVvAPud = 41;

		// Token: 0x040031F5 RID: 12789
		private const byte mnaVNrxbUBpvXpVbmGQkItHcNwnE = 163;

		// Token: 0x040031F6 RID: 12790
		private const byte bQWfLtgNHUOrqGlvtnNtYJPPGhnjb = 49;

		// Token: 0x040031F7 RID: 12791
		private const byte EwaKtgfsNUAcNLiEKEhqXHXJMKpM = 18;

		// Token: 0x040031F8 RID: 12792
		private const byte lLBSxrtgpmJWuDzcEhAQxeSSaEeDA = 16;

		// Token: 0x040031F9 RID: 12793
		private const byte GbEFIpZDVrxlYnDknjDHtHWTjDPc = 161;

		// Token: 0x040031FA RID: 12794
		private const byte kXNJOhxHUZALhVJGKMekRFRnAyUbA = 162;

		// Token: 0x040031FB RID: 12795
		private const byte RxEhTTRWEeHefsIAPRSdmbQIXYZH = 163;

		// Token: 0x040031FC RID: 12796
		private const int IqRHnVgNkMCXbeHxUhOfNBnWyfEM = 1;

		// Token: 0x040031FD RID: 12797
		private const int PPIPWLAGrQMbiZdKDVoruLtIyazD = 2;

		// Token: 0x040031FE RID: 12798
		private const int UjnGFXQwlHZWIDaRNlVbglpaLTYV = 3;

		// Token: 0x040031FF RID: 12799
		private const int tJFzFqevpqnimZSuLDqEvjBuGcri = 4;

		// Token: 0x04003200 RID: 12800
		private const int BVScAEHdrREwUeYBGgmEnTQqlbwub = 8;

		// Token: 0x04003201 RID: 12801
		private const int rhvcQtEwViwOFOpbSResfmUfbfdM = 9;

		// Token: 0x04003202 RID: 12802
		private const int vMKxpFfHWqmWHWQbaqozZfpuuXtn = 5;

		// Token: 0x04003203 RID: 12803
		private const int booEYvGERkfAGjIiNWctBMueEWfgA = 19;

		// Token: 0x04003204 RID: 12804
		private const int MoSFlecmOTpyhTUDWnIgPdJRsBWh = 13;

		// Token: 0x04003205 RID: 12805
		private const int GHxDLXKvjdjifQjdmTwyJFvednPO = 35;

		// Token: 0x04003206 RID: 12806
		private const int rgihdMlGPHsaqdeKIDHlNFHPCqIf = 5;

		// Token: 0x04003207 RID: 12807
		private const int JKcvGJqAbxkZboWsBmewasbqbTpc = 6;

		// Token: 0x04003208 RID: 12808
		private const int CuVZPCfAuYeOfEtyBrtZGcoDOJTjb = 7;

		// Token: 0x04003209 RID: 12809
		private const int APuNODYXhfnCBqfYMcOjajCxeUrLA = 10;

		// Token: 0x0400320A RID: 12810
		private const int EIDbboAyOgayRWONHiCeCFzlrijaA = 30;

		// Token: 0x0400320B RID: 12811
		private const int JUoeMsecGaAkCiPjspFUKGvsbBEb = 27;

		// Token: 0x0400320C RID: 12812
		private const byte RsJmAbFsrbKDVvSTZWNEsDhHjgUy = 200;

		// Token: 0x0400320D RID: 12813
		private const byte EFUvkUihpxHmEJNqINLeybddvgWn = 53;

		// Token: 0x0400320E RID: 12814
		private const byte ZUidUrRMrAwnnRMpQIMOIwJRgLYOA = 255;

		// Token: 0x0400320F RID: 12815
		private const byte NoBXqUhQGVgPAxXxVTydkNYdjUds = 0;

		// Token: 0x04003210 RID: 12816
		private const bool BeyFEncjiBSMApkhFkYxADhiUwaCA = true;

		// Token: 0x04003211 RID: 12817
		private const int JhUeaeIlBZhISUfXvMgUIboqkEKHA = 60;

		// Token: 0x04003212 RID: 12818
		private const int DQVPedXEMdwLicaYEQZlGcJKSZwg = 60;

		// Token: 0x04003213 RID: 12819
		private const int hmdSbXeXBUpTsBBtpfuOvCJGHjwJA = 187500;

		// Token: 0x04003214 RID: 12820
		private const float wTzfTpuGjcOGRaGljZOZUhUNiqmm = 8192f;

		// Token: 0x04003215 RID: 12821
		private const float VdUdSNEvXiUDdsVTlGUejeYrNNap = 0.0010652969f;

		// Token: 0x04003216 RID: 12822
		private const float usFVwkUGrRVtirafNDvYKJDvTxZd = 0.06103702f;

		// Token: 0x04003217 RID: 12823
		private const bool uexfgSjQDeKVzaaSDUmhmneAHfEvb = true;

		// Token: 0x04003218 RID: 12824
		private const bool qZSMLEfkYFyCkVLNGDtEveUZCMFAA = true;

		// Token: 0x04003219 RID: 12825
		private const bool BBePJtrHxayRJCOzKOwheXcLVbuo = true;

		// Token: 0x0400321A RID: 12826
		private const bool nfcIDdcCGKBBgWCMmuPjivYKKTuFb = true;

		// Token: 0x0400321B RID: 12827
		private const float FJAyCMHVIdbJHDfstwhEykiGYaoP = 4096f;

		// Token: 0x0400321C RID: 12828
		private const float soZfkjRHQoevbgfZIFpDbsffTllfB = 16384f;

		// Token: 0x0400321D RID: 12829
		private const float PQjsWniIZlPDjuyenQwFAiEGrJWE = 16777216f;

		// Token: 0x0400321E RID: 12830
		private const float RagantMMGsllyvdSuDPlWCsqAGEEA = 268435460f;

		// Token: 0x0400321F RID: 12831
		private const float uAOjRWsVGauAXBcEsWPpujzuVbnJ = 0.01999998f;

		// Token: 0x04003220 RID: 12832
		private const float KInmSOmPBUeEFLQCSAemyamZGWZC = 8192f;

		// Token: 0x04003221 RID: 12833
		private const float sPAJbvbufSnGNcNmnkgJzMzdCBXBA = 0.98f;

		// Token: 0x04003222 RID: 12834
		private const float wQRyVDeXjxMbwcnJnmYtjLvAisKH = 45f;

		// Token: 0x04003223 RID: 12835
		private const float zMSkCgDBGELhmBwisOyUgfghrCae = 20f;

		// Token: 0x04003224 RID: 12836
		private readonly HIDDeviceDriver.IHIDDevice MPqBVRXerrPAsUWttcBpiZiwuJeh;

		// Token: 0x04003225 RID: 12837
		private readonly HIDDeviceDriver.HIDProperties qYzbsbnIIlcDxlhWAfyQAhkdAvGd;

		// Token: 0x04003226 RID: 12838
		private readonly bool BXYEClcspwHrgusOwWQcYfEWkDYy;

		// Token: 0x04003227 RID: 12839
		private readonly srhddSmbipxLrwlIqjetZPjyhATp pIrCMfasGXMrNUmMhDMogqnCsPwJb;

		// Token: 0x04003228 RID: 12840
		private readonly int KRBwQTiHzeQbWvMgaySNvbkXRzWg;

		// Token: 0x04003229 RID: 12841
		private readonly int hCEVGQvbyxrGFtIkpvinmfiICiGiA;

		// Token: 0x0400322A RID: 12842
		private readonly bool sLfLDhcfHICrpPzpcmUIySLAZsdc;

		// Token: 0x0400322B RID: 12843
		private readonly byte YnzQwiGsLpltXkuwJUbJywWoebJv;

		// Token: 0x0400322C RID: 12844
		private readonly int OasYpuEKjyAqXHenJFlIyJMRxbLHA;

		// Token: 0x0400322D RID: 12845
		private readonly int EzmljccEngEHuMgWPRstbQGlQlyl;

		// Token: 0x0400322E RID: 12846
		private readonly int WPwDrKyEFMXAvnhgCrjuaAeByzgh;

		// Token: 0x0400322F RID: 12847
		private readonly int WhoJbdxSIdmLTAGfAXdVlKSqdPvh;

		// Token: 0x04003230 RID: 12848
		private readonly NativeBuffer ZoIqpaEhbldximcXPXAseJCwwNaj;

		// Token: 0x04003231 RID: 12849
		private readonly NativeBuffer tfvTgBPTbSCyUcYxvOctQcXXRNsf;

		// Token: 0x04003232 RID: 12850
		private readonly AWHWYMjOaGiEqJCCtAEpfhRJAtYq zbGkoPaYAhvqTpKORPKzEEbmDPaG;

		// Token: 0x04003233 RID: 12851
		private readonly byte[] MMNAfadbcTXBSLRIuctMGPNFNBMT = new byte[]
		{
			162
		};

		// Token: 0x04003234 RID: 12852
		private bool gCnQQHqHpSclFaaTMOMpkOHErIOi;

		// Token: 0x04003235 RID: 12853
		private bool yQCmSaTdflMzXQrUqeWxOpoRxhfK;

		// Token: 0x04003236 RID: 12854
		private double WsXmOeraeAcgJCvmvlGBJGKdpVDBb;

		// Token: 0x04003237 RID: 12855
		private int ZBiiQhFzxHVmsIPLnAfbNGisMJJAb;

		// Token: 0x04003238 RID: 12856
		private DualShock4Driver.hxXaJMCeImyVOgpiHOxLyEIdFmvLA lAPogrRHsVgbxiAQUvwPDjjskmSgb = DualShock4Driver.hxXaJMCeImyVOgpiHOxLyEIdFmvLA.Unknown;

		// Token: 0x04003239 RID: 12857
		private Quaternion lXpcFamxsQDcUXiSZAIBlQkqusPg = Quaternion.identity;

		// Token: 0x0400323A RID: 12858
		private ushort WKdgXNaRyIRudedsoilvTrrHOEZw;

		// Token: 0x0400323B RID: 12859
		private float VRLnVyBiHYyzNvvDmUXQTvdhoBKE;

		// Token: 0x0400323C RID: 12860
		private double OryNRCVgPtiEtAhvqIkJZRhYVJeAA;

		// Token: 0x0400323D RID: 12861
		private float PDoJrhnmlgEVByVJbthTPUMdpLUm;

		// Token: 0x0400323E RID: 12862
		private bool gDHafEhtgsvfUMVrETdSZISKydLy;

		// Token: 0x0400323F RID: 12863
		private bool TAqJHfanUmJXnzuOsJloSsxGfUOR;

		// Token: 0x04003240 RID: 12864
		private bool BjUdifCHajkCysHjEpiiAZnmasxM;

		// Token: 0x04003241 RID: 12865
		private bool YuiCMUTIPqvvqCOLLwtliBTeeoBIA;

		// Token: 0x04003242 RID: 12866
		private byte SfRAeVzugzILGbOCSSwryoGerodwA;

		// Token: 0x04003243 RID: 12867
		private byte kerQgGFWlGmhEiPxDehEgbgCTIBT;

		// Token: 0x04003244 RID: 12868
		private Quaternion MPuZkstKqbhVTrcHVEgrOtojAlLu = Quaternion.identity;

		// Token: 0x04003245 RID: 12869
		private Quaternion SokGXMyiyqrgPQyGcXeuBVxcIiKd = Quaternion.identity;

		// Token: 0x04003246 RID: 12870
		private bool tVFvtcNWNgpqczHZpImVxHJEhXDZ;

		// Token: 0x04003247 RID: 12871
		private int HmaPanMWDJAxOUamibchKBXVegqy;

		// Token: 0x04003248 RID: 12872
		private int[] maLGtqBfTyMjpKHAsyYNAJsLdKNQ = new int[2];

		// Token: 0x04003249 RID: 12873
		private int[] ndrMhQYnLPaASCrlWSvUkgHCuXYb = new int[2];

		// Token: 0x0200030D RID: 781
		private enum ZgjtIhlEdwHmyyRjWkNZDgOsQvrq
		{
			// Token: 0x0400324B RID: 12875
			X,
			// Token: 0x0400324C RID: 12876
			Y,
			// Token: 0x0400324D RID: 12877
			Z
		}

		// Token: 0x0200030E RID: 782
		private enum LNMNZVXFBhgXbYVhgDOdUGxQnHsV
		{
			// Token: 0x0400324F RID: 12879
			None,
			// Token: 0x04003250 RID: 12880
			XZ,
			// Token: 0x04003251 RID: 12881
			Y
		}

		// Token: 0x0200030F RID: 783
		private static class RLmmLsymrbjkMaPKYccvemUbVhnU
		{
			// Token: 0x060016F3 RID: 5875 RVA: 0x0001CFB4 File Offset: 0x0001B1B4
			public unsafe static uint DJtFhMBUMEwegTeoykJVAYIsmfGFb(byte* A_0, int A_1, uint A_2)
			{
				return ~DualShock4Driver.RLmmLsymrbjkMaPKYccvemUbVhnU.nsNzxDWwpBqtRlFANFCPgKHveXCfb(DualShock4Driver.RLmmLsymrbjkMaPKYccvemUbVhnU.nsNzxDWwpBqtRlFANFCPgKHveXCfb(uint.MaxValue, (byte*)(&A_2), 1, 3988292384U), A_0, A_1, 3988292384U);
			}

			// Token: 0x060016F4 RID: 5876 RVA: 0x0001CFD2 File Offset: 0x0001B1D2
			public unsafe static uint DHDjrIwipaLsBIQlcXEhgEIcnnfW(uint A_0, byte* A_1, int A_2)
			{
				return DualShock4Driver.RLmmLsymrbjkMaPKYccvemUbVhnU.nsNzxDWwpBqtRlFANFCPgKHveXCfb(A_0, A_1, A_2, 3988292384U);
			}

			// Token: 0x060016F5 RID: 5877 RVA: 0x00051370 File Offset: 0x0004F570
			private unsafe static uint nsNzxDWwpBqtRlFANFCPgKHveXCfb(uint A_0, byte* A_1, int A_2, uint A_3)
			{
				for (int i = 0; i < A_2; i++)
				{
					A_0 ^= (uint)A_1[i];
					for (int j = 0; j < 8; j++)
					{
						A_0 = (A_0 >> 1 ^ (((A_0 & 1U) != 0U) ? A_3 : 0U));
					}
				}
				return A_0;
			}

			// Token: 0x04003252 RID: 12882
			private const uint NcaKAKgeiwDwbxQFCazEquenEzQk = 3988292384U;
		}

		// Token: 0x02000310 RID: 784
		private enum hxXaJMCeImyVOgpiHOxLyEIdFmvLA
		{
			// Token: 0x04003254 RID: 12884
			Discharging,
			// Token: 0x04003255 RID: 12885
			Charging,
			// Token: 0x04003256 RID: 12886
			Full,
			// Token: 0x04003257 RID: 12887
			Unknown
		}
	}
}
