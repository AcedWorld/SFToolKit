using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	// Token: 0x020002FC RID: 764
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06001613 RID: 5651 RVA: 0x0004D698 File Offset: 0x0004B898
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

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06001614 RID: 5652 RVA: 0x0001C7DE File Offset: 0x0001A9DE
		public float BatteryLevel
		{
			get
			{
				return (float)this.HenoeakTkuuOECUUSRHTxjGxxJtk;
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06001615 RID: 5653 RVA: 0x0001C7E7 File Offset: 0x0001A9E7
		public bool BatteryCharging
		{
			get
			{
				return this.NdlMqgpTLtBGGXWbWkAnxjEbPfVj == DualSenseDriver.xgALdxMpRZqdEupLJqzwNllssyDm.Charging;
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06001616 RID: 5654 RVA: 0x0001C7F2 File Offset: 0x0001A9F2
		// (set) Token: 0x06001617 RID: 5655 RVA: 0x0001C7FA File Offset: 0x0001A9FA
		public DualSenseVibrationMode vibrationMode
		{
			get
			{
				return this.vIKjFKSLbwuBSScPCCTIVRIojGeEA;
			}
			set
			{
				this.vIKjFKSLbwuBSScPCCTIVRIojGeEA = value;
				this.qWSEyyyhENTESWboTeJdJwsffljGA();
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06001618 RID: 5656 RVA: 0x0001C809 File Offset: 0x0001AA09
		// (set) Token: 0x06001619 RID: 5657 RVA: 0x0001C818 File Offset: 0x0001AA18
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

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x0600161A RID: 5658 RVA: 0x0001C828 File Offset: 0x0001AA28
		// (set) Token: 0x0600161B RID: 5659 RVA: 0x0001C837 File Offset: 0x0001AA37
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

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x0600161C RID: 5660 RVA: 0x0001C847 File Offset: 0x0001AA47
		// (set) Token: 0x0600161D RID: 5661 RVA: 0x0001C856 File Offset: 0x0001AA56
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

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x0600161E RID: 5662 RVA: 0x0001C866 File Offset: 0x0001AA66
		// (set) Token: 0x0600161F RID: 5663 RVA: 0x0001C875 File Offset: 0x0001AA75
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

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06001620 RID: 5664 RVA: 0x0001C885 File Offset: 0x0001AA85
		// (set) Token: 0x06001621 RID: 5665 RVA: 0x0001C894 File Offset: 0x0001AA94
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

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06001622 RID: 5666 RVA: 0x0001C8A4 File Offset: 0x0001AAA4
		// (set) Token: 0x06001623 RID: 5667 RVA: 0x0004D6CC File Offset: 0x0004B8CC
		public float LightFlashOnDuration
		{
			get
			{
				return (float)this.niqqIsssRafDQwDezigYlQtGcGUcA;
			}
			set
			{
				this.niqqIsssRafDQwDezigYlQtGcGUcA = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				this.rwjeomgYCtlsjgQzDUawPNmSmwFzA();
				if (this.niqqIsssRafDQwDezigYlQtGcGUcA == 0 && this.TzrojzHzfOtClyqLOqeTwxfMDbii == 0)
				{
					this.ACIUqfAulQkhDzoUKRfxsGdQHtpc = true;
				}
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06001624 RID: 5668 RVA: 0x0001C8AD File Offset: 0x0001AAAD
		// (set) Token: 0x06001625 RID: 5669 RVA: 0x0004D724 File Offset: 0x0004B924
		public float LightFlashOffDuration
		{
			get
			{
				return (float)this.TzrojzHzfOtClyqLOqeTwxfMDbii;
			}
			set
			{
				this.TzrojzHzfOtClyqLOqeTwxfMDbii = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				this.rwjeomgYCtlsjgQzDUawPNmSmwFzA();
				if (this.niqqIsssRafDQwDezigYlQtGcGUcA == 0 && this.TzrojzHzfOtClyqLOqeTwxfMDbii == 0)
				{
					this.ACIUqfAulQkhDzoUKRfxsGdQHtpc = true;
				}
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06001626 RID: 5670 RVA: 0x0001C8B6 File Offset: 0x0001AAB6
		// (set) Token: 0x06001627 RID: 5671 RVA: 0x0001C8BE File Offset: 0x0001AABE
		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				return this.BqVkTHNpOpBMRCwfmjRThhRvnOAR;
			}
			set
			{
				this.BqVkTHNpOpBMRCwfmjRThhRvnOAR = value;
				this.qWSEyyyhENTESWboTeJdJwsffljGA();
				this.cMzLhDMnRMTPcUbhHvgmDketcBFGA = true;
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06001628 RID: 5672 RVA: 0x0001C8D4 File Offset: 0x0001AAD4
		// (set) Token: 0x06001629 RID: 5673 RVA: 0x0001C8E1 File Offset: 0x0001AAE1
		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				return DualSenseDriver.heoaEUEBCEYNZzOXOTTaacZgLkju(this.bKRBPwbOlxiiUYnSaTcRqXBUBHTd);
			}
			set
			{
				this.bKRBPwbOlxiiUYnSaTcRqXBUBHTd = DualSenseDriver.ABGEYjKawyNqwKPseawCydOsWhIk(value);
				this.qWSEyyyhENTESWboTeJdJwsffljGA();
				this.HrsbfIizTFjfiUQRDJwRcMmDKPTNA = true;
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x0600162A RID: 5674 RVA: 0x0001C8FC File Offset: 0x0001AAFC
		// (set) Token: 0x0600162B RID: 5675 RVA: 0x0001C904 File Offset: 0x0001AB04
		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				return this.qGqGTuTEcJdIIREVSJoRDrOZHcwm;
			}
			set
			{
				this.qGqGTuTEcJdIIREVSJoRDrOZHcwm = value;
				this.qWSEyyyhENTESWboTeJdJwsffljGA();
				this.efOWjQrVptmFXycDFUCjTnkKDNbq = true;
			}
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x0001C91A File Offset: 0x0001AB1A
		public Vector3 AccelerometerValue
		{
			get
			{
				return this.AUHIzRDdQlokwCmcRFEhtcSaHLkw(this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD);
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x0600162D RID: 5677 RVA: 0x0001C92F File Offset: 0x0001AB2F
		public Vector3 AccelerometerValueRaw
		{
			get
			{
				return new Vector3(this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[0], this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[1], this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[2]);
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x0600162E RID: 5678 RVA: 0x0001C963 File Offset: 0x0001AB63
		public Vector3 GyroscopeValue
		{
			get
			{
				return this.lvqwMXedNxgkCgTnLYtgoDqrNEbLA(this.gyroscopes[0].CxhCZOFOLzfwwTtqOruQEcpotRwP);
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x0600162F RID: 5679 RVA: 0x0001C978 File Offset: 0x0001AB78
		public Vector3 GyroscopeValueRaw
		{
			get
			{
				return new Vector3(this.gyroscopes[0].oxrAVCGYVAsFpNwvvghIcKXCXRPLA[0], this.gyroscopes[0].oxrAVCGYVAsFpNwvvghIcKXCXRPLA[1], this.gyroscopes[0].oxrAVCGYVAsFpNwvvghIcKXCXRPLA[2]);
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06001630 RID: 5680 RVA: 0x0004D77C File Offset: 0x0004B97C
		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[0], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[1], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[2]);
				return this.GQzzTJOwcYVEWDOhRbVsdhXhgpJd(vector, this.SpkApLOyVjkvlycvIcvDjCMuAwraA);
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06001631 RID: 5681 RVA: 0x0001C9AC File Offset: 0x0001ABAC
		public Vector3 LastGyroscopeValueRaw
		{
			get
			{
				return new Vector3(this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[0], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[1], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[2]);
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06001632 RID: 5682 RVA: 0x0001C9E0 File Offset: 0x0001ABE0
		public Quaternion Orientation
		{
			get
			{
				return this.XFeikQhdjUOPaDjKNYRnplQNHMfFb;
			}
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x0001C9E8 File Offset: 0x0001ABE8
		public void ResetOrientation()
		{
			this.XFeikQhdjUOPaDjKNYRnplQNHMfFb = Quaternion.identity;
			this.RBDBhSHnXWSAnWYYWXhIodKvSXHm = false;
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x00012219 File Offset: 0x00010419
		public int MaxTouches
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x0004D7CC File Offset: 0x0004B9CC
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

		// Token: 0x06001636 RID: 5686 RVA: 0x0001C9FC File Offset: 0x0001ABFC
		public bool IsTouchingAtIndex(int index)
		{
			return index >= 0 && index < 2 && this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL[index].isTouching;
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x0001CA20 File Offset: 0x0001AC20
		public bool IsTouchingAtTouchId(int touchId)
		{
			return this.touchpads[0].tgKrcXnHuYRQqdFCcKwYoFPjhrei(touchId);
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x0001CA30 File Offset: 0x0001AC30
		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return this.touchpads[0].mbGotkNspciCdWUfwbxMijjJnXsL[index].touchId;
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x0004D808 File Offset: 0x0004BA08
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

		// Token: 0x0600163A RID: 5690 RVA: 0x0004D86C File Offset: 0x0004BA6C
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

		// Token: 0x0600163B RID: 5691 RVA: 0x0004D8E4 File Offset: 0x0004BAE4
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

		// Token: 0x0600163C RID: 5692 RVA: 0x0004D93C File Offset: 0x0004BB3C
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

		// Token: 0x0600163D RID: 5693 RVA: 0x0001CA54 File Offset: 0x0001AC54
		public void StopLightFlash()
		{
			this.niqqIsssRafDQwDezigYlQtGcGUcA = 0;
			this.TzrojzHzfOtClyqLOqeTwxfMDbii = 0;
			this.qWSEyyyhENTESWboTeJdJwsffljGA();
			this.ACIUqfAulQkhDzoUKRfxsGdQHtpc = true;
			this.VxUtaGOXjOqRDGbodAujhxsyeSvk = true;
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x0004D9A8 File Offset: 0x0004BBA8
		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			for (int i = 0; i < vibrationMotorCount; i++)
			{
				this.vibrationMotors[i].jytYrChQDenkTUaEnqBMeGDoorVS = 0;
			}
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x0001CA78 File Offset: 0x0001AC78
		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			if (trigger == DualSenseTriggerType.Left)
			{
				this.wFeMfrbsWpCDJbhliEzLeGxwOSEP[0] = effect;
				this.qWSEyyyhENTESWboTeJdJwsffljGA();
				this.fFZBQnrjCCgnMPMAZXHrkvokUiye = true;
				return true;
			}
			if (trigger != DualSenseTriggerType.Right)
			{
				return false;
			}
			this.wFeMfrbsWpCDJbhliEzLeGxwOSEP[1] = effect;
			this.qWSEyyyhENTESWboTeJdJwsffljGA();
			this.pTzMlECtCDHmvknUlfEmaPhINuGib = true;
			return true;
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x0004D9D8 File Offset: 0x0004BBD8
		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			return new DualSenseTriggerEffectStates
			{
				leftTrigger = this.vuzbqmcfxMFmSdIilLZaXxPGjfaf[0],
				rightTrigger = this.vuzbqmcfxMFmSdIilLZaXxPGjfaf[1]
			};
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06001641 RID: 5697 RVA: 0x0001CAB4 File Offset: 0x0001ACB4
		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				return this.THAEgAGzxCBAPxcMTVaZOmEyakyv.vendorId;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06001642 RID: 5698 RVA: 0x0001CAC1 File Offset: 0x0001ACC1
		ushort IHIDControllerExtension.productId
		{
			get
			{
				return this.THAEgAGzxCBAPxcMTVaZOmEyakyv.productId;
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06001643 RID: 5699 RVA: 0x0001CACE File Offset: 0x0001ACCE
		string IHIDControllerExtension.productName
		{
			get
			{
				return this.THAEgAGzxCBAPxcMTVaZOmEyakyv.productName;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06001644 RID: 5700 RVA: 0x0001CADB File Offset: 0x0001ACDB
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				return this.THAEgAGzxCBAPxcMTVaZOmEyakyv.manufacturer;
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06001645 RID: 5701 RVA: 0x0001CAE8 File Offset: 0x0001ACE8
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				return this.THAEgAGzxCBAPxcMTVaZOmEyakyv.usagePage;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06001646 RID: 5702 RVA: 0x0001CAF5 File Offset: 0x0001ACF5
		ushort IHIDControllerExtension.usage
		{
			get
			{
				return this.THAEgAGzxCBAPxcMTVaZOmEyakyv.usage;
			}
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x0004DA0C File Offset: 0x0004BC0C
		public DualSenseDriver(HIDDeviceDriver.InitArgs A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			this.vopaOdvZXmmvkDiibFtNaurhFYPJA = A_1.hidDevice;
			this.THAEgAGzxCBAPxcMTVaZOmEyakyv = this.vopaOdvZXmmvkDiibFtNaurhFYPJA.properties;
			this.CuqXScJiVmEBZTIEnskYOaYqhkFu = A_1.hatZeroValue;
			this.EvQDPYhgMkFyMVgJdJKpKGTWPwBRA = A_1.hatSpan;
			this.vtFZlLBbtohFVCltIGDNvqojcghKA = (A_1.connectionType == srhddSmbipxLrwlIqjetZPjyhATp.Bluetooth);
			if (this.vtFZlLBbtohFVCltIGDNvqojcghKA)
			{
				this.MonAxeBhmQOjwtuyrMwHEBxThtRAb = 78;
			}
			else
			{
				this.MonAxeBhmQOjwtuyrMwHEBxThtRAb = 48;
			}
			this.OPDBmlQmdVpALplchXSETGiLhzlh = new NativeBuffer(64);
			this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA = new NativeBuffer(this.MonAxeBhmQOjwtuyrMwHEBxThtRAb);
			this.BBtPFjnSBTpngXHkKDhJKqTEzsTy = new AWHWYMjOaGiEqJCCtAEpfhRJAtYq(this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA.Pointer, this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA.Length, this.MonAxeBhmQOjwtuyrMwHEBxThtRAb);
			this.lights = new XKforwyiippWnEqzvPiJMMmSIoUfA[]
			{
				new XKforwyiippWnEqzvPiJMMmSIoUfA(11, 24, 28)
			};
			this.lights[0].yJbfInhGiJsJTYGNoUbQXlGorbpp += this.FljLtdLymqPAFubUGigKzfnthHmQ;
			this.vibrationMotors = new UnptiYUxBEDyXRujUEnkdeIKIoPk[]
			{
				new UnptiYUxBEDyXRujUEnkdeIKIoPk(0, 255),
				new UnptiYUxBEDyXRujUEnkdeIKIoPk(0, 255)
			};
			this.vibrationMotors[0].ztNbeMSTMsaUVsclhemevRUkIIOp += this.SmFxbbxCSzcpRHAWyXWauzPnOvSTA;
			this.vibrationMotors[1].ztNbeMSTMsaUVsclhemevRUkIIOp += this.SmFxbbxCSzcpRHAWyXWauzPnOvSTA;
			this.vIKjFKSLbwuBSScPCCTIVRIojGeEA = DualSenseVibrationMode.Compatible2;
			this.wVJDccOKbLwbTAkeyBwOhhBQfjMI = true;
			this.fFZBQnrjCCgnMPMAZXHrkvokUiye = true;
			this.pTzMlECtCDHmvknUlfEmaPhINuGib = true;
			this.cMzLhDMnRMTPcUbhHvgmDketcBFGA = true;
			this.efOWjQrVptmFXycDFUCjTnkKDNbq = true;
			this.HrsbfIizTFjfiUQRDJwRcMmDKPTNA = true;
			this.VxUtaGOXjOqRDGbodAujhxsyeSvk = true;
			this.jmBsJUbcWsmRrylqtURIAzteatfT = true;
			this.ucsrNLFFzQZxXEKfirkRWcXaLKFg = true;
			this.ACcmWhSikaHNCGlPXTUGqfWmquOU = 2;
			if (this.vtFZlLBbtohFVCltIGDNvqojcghKA)
			{
				byte[] hidFeatureData = this.vopaOdvZXmmvkDiibFtNaurhFYPJA.GetHidFeatureData(5, 41, 1000, 3);
				this.FKIphGjuKJhiiTnDUecqFBtmlEiL = (hidFeatureData != null && hidFeatureData.Length != 0);
				if (this.FKIphGjuKJhiiTnDUecqFBtmlEiL)
				{
					this.CbKLYosANlCegVYbVWsDESTUdAQv(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
				}
			}
			else
			{
				this.FKIphGjuKJhiiTnDUecqFBtmlEiL = true;
				this.FKIphGjuKJhiiTnDUecqFBtmlEiL = this.CbKLYosANlCegVYbVWsDESTUdAQv(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
			}
			if (!this.FKIphGjuKJhiiTnDUecqFBtmlEiL)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			this.AzDkSpEmXOsqritrOzXfXneZuUhi = 1;
			this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA = 0;
			if (this.vtFZlLBbtohFVCltIGDNvqojcghKA && this.FKIphGjuKJhiiTnDUecqFBtmlEiL)
			{
				this.AzDkSpEmXOsqritrOzXfXneZuUhi = 49;
				this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA = 1;
			}
			this.yDshYmiDYDnhtdPDHlKFNzMwysaQA = 8 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA;
			this.JeGBVcfcEGuzTkqANdMTDaGisypz = 9 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA;
			this.mjDbQLLyLaPRWwtbPxnlBOcAPIBJ = 10 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA;
			this.buttons = new bsHiSnxdPKGTmlVVXzABmREfuPAX[15];
			for (int i = 0; i < 15; i++)
			{
				this.buttons[i] = new bsHiSnxdPKGTmlVVXzABmREfuPAX(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			this.axes = new WlBhllbxXziYUoZmsblPearfaCpbA[]
			{
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0U,
					unitsExp = 0U
				}, false, 0),
				new WlBhllbxXziYUoZmsblPearfaCpbA(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
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
				new oPOwiIBMGNECtKWjLBTodfZcpRzbB(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20U,
					unitsExp = 0U
				}, new Func<int, int>(this.kyofkDYRaQQwvVdPINTcLyoKBuJD))
			};
			this.accelerometers = new VowBBGCdjJGeVmPjtscFISvyEvTtA[]
			{
				new VowBBGCdjJGeVmPjtscFISvyEvTtA(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 48
				}, 3, new Action<byte[], float[]>(this.PZwNuBAQyviozkURxwNBZyypSOTF))
			};
			this.gyroscopes = new TDbKvyrtcOKmakPyYMqLcuNLqPbe[]
			{
				new TDbKvyrtcOKmakPyYMqLcuNLqPbe(A_1.updateLoopSetting, this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 48
				}, 3, 60, new Action<byte[], float[]>(this.FgbYDAPNBnSvLZXTeIliKNPlFpBJA), new Func<float>(this.XfPqHllRYMrlQFJcJlHTDWCNsPZM))
			};
			this.touchpads = new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA[]
			{
				new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA(this.AzDkSpEmXOsqritrOzXfXneZuUhi, new zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA,
					bitSize = 48
				}, 60, new Action<NativeBuffer, zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[]>(this.BwSHVMcdDjCevnShdmyiidgJERtCA))
			};
			this.AeQfseKCYUQBZMhTynYzzxtymloNA = ReInput.realTime;
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x0001CB02 File Offset: 0x0001AD02
		public override void Update(UpdateLoopType updateLoop)
		{
			this.UZPBPcdTwmgkhrBGTHOAeLMJiUnRA();
			this.oWvuWWtEZFFApYUXEdOezWeqatzM(xvcebytMmHXPBmUQiJYMACsdJpLo.Asynchronous);
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x0004E12C File Offset: 0x0004C32C
		public unsafe override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < this.OPDBmlQmdVpALplchXSETGiLhzlh.Length)
			{
				return false;
			}
			if (this.vtFZlLBbtohFVCltIGDNvqojcghKA && this.FKIphGjuKJhiiTnDUecqFBtmlEiL && *(byte*)((void*)inputReportPtr) == 1)
			{
				return false;
			}
			this.tsISduhmrovoypWaHlwLCwXlSVBJ = (float)(timestamp - this.AeQfseKCYUQBZMhTynYzzxtymloNA);
			this.AeQfseKCYUQBZMhTynYzzxtymloNA = timestamp;
			this.OPDBmlQmdVpALplchXSETGiLhzlh.Write(inputReportPtr, inputReportLength, this.OPDBmlQmdVpALplchXSETGiLhzlh.Length, 0, 0);
			this.wzwzfRWLmWoaKzMHtJkLhteUfrNj(this.OPDBmlQmdVpALplchXSETGiLhzlh);
			this.EJYmCKgYwURJAvHRwwKmmZRFNUSX(this.OPDBmlQmdVpALplchXSETGiLhzlh, timestamp);
			zHTBvVyhFGDLpEJMFINchPNfqnfnb[] array = this.axes;
			this.lvAUrPLzzdAubzzkDWRyVekvvbjr(array, this.OPDBmlQmdVpALplchXSETGiLhzlh, timestamp);
			array = this.hats;
			this.lvAUrPLzzdAubzzkDWRyVekvvbjr(array, this.OPDBmlQmdVpALplchXSETGiLhzlh, timestamp);
			array = this.accelerometers;
			this.lvAUrPLzzdAubzzkDWRyVekvvbjr(array, this.OPDBmlQmdVpALplchXSETGiLhzlh, timestamp);
			array = this.gyroscopes;
			this.lvAUrPLzzdAubzzkDWRyVekvvbjr(array, this.OPDBmlQmdVpALplchXSETGiLhzlh, timestamp);
			array = this.touchpads;
			this.lvAUrPLzzdAubzzkDWRyVekvvbjr(array, this.OPDBmlQmdVpALplchXSETGiLhzlh, timestamp);
			byte b = this.OPDBmlQmdVpALplchXSETGiLhzlh[53 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA];
			DualSenseDriver.TcXhaMHRvzhzAeUVdSEXdNpdYIaRA tcXhaMHRvzhzAeUVdSEXdNpdYIaRA = (DualSenseDriver.TcXhaMHRvzhzAeUVdSEXdNpdYIaRA)((b & 240) >> 4);
			if (tcXhaMHRvzhzAeUVdSEXdNpdYIaRA <= DualSenseDriver.TcXhaMHRvzhzAeUVdSEXdNpdYIaRA.Full)
			{
				if (tcXhaMHRvzhzAeUVdSEXdNpdYIaRA <= DualSenseDriver.TcXhaMHRvzhzAeUVdSEXdNpdYIaRA.Charging)
				{
					this.HenoeakTkuuOECUUSRHTxjGxxJtk = MathTools.Clamp((int)((b & 15) * 10 + 5), 0, 100);
					this.NdlMqgpTLtBGGXWbWkAnxjEbPfVj = ((tcXhaMHRvzhzAeUVdSEXdNpdYIaRA == DualSenseDriver.TcXhaMHRvzhzAeUVdSEXdNpdYIaRA.Charging) ? DualSenseDriver.xgALdxMpRZqdEupLJqzwNllssyDm.Charging : DualSenseDriver.xgALdxMpRZqdEupLJqzwNllssyDm.Discharging);
					goto IL_17F;
				}
				if (tcXhaMHRvzhzAeUVdSEXdNpdYIaRA == DualSenseDriver.TcXhaMHRvzhzAeUVdSEXdNpdYIaRA.Full)
				{
					this.HenoeakTkuuOECUUSRHTxjGxxJtk = 100;
					this.NdlMqgpTLtBGGXWbWkAnxjEbPfVj = DualSenseDriver.xgALdxMpRZqdEupLJqzwNllssyDm.Full;
					goto IL_17F;
				}
			}
			else
			{
				if (tcXhaMHRvzhzAeUVdSEXdNpdYIaRA - DualSenseDriver.TcXhaMHRvzhzAeUVdSEXdNpdYIaRA.TemperatureOutOfRange <= 1)
				{
					this.HenoeakTkuuOECUUSRHTxjGxxJtk = 0;
					this.NdlMqgpTLtBGGXWbWkAnxjEbPfVj = DualSenseDriver.xgALdxMpRZqdEupLJqzwNllssyDm.Charging;
					goto IL_17F;
				}
				if (tcXhaMHRvzhzAeUVdSEXdNpdYIaRA != DualSenseDriver.TcXhaMHRvzhzAeUVdSEXdNpdYIaRA.ChargingError)
				{
				}
			}
			this.HenoeakTkuuOECUUSRHTxjGxxJtk = 0;
			this.NdlMqgpTLtBGGXWbWkAnxjEbPfVj = DualSenseDriver.xgALdxMpRZqdEupLJqzwNllssyDm.Unknown;
			IL_17F:
			this.kiHZrXsaLSWcMDpIZPjtfrMllPbY = ((this.OPDBmlQmdVpALplchXSETGiLhzlh[54 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA] & 1) > 0);
			this.vuzbqmcfxMFmSdIilLZaXxPGjfaf[0] = DualSenseDriver.RsqzXAWrjXSfoKEnDGBBeMgWCLRoA(DualSenseTriggerType.Left, this.OPDBmlQmdVpALplchXSETGiLhzlh[43 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA], this.OPDBmlQmdVpALplchXSETGiLhzlh[48 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA]);
			this.vuzbqmcfxMFmSdIilLZaXxPGjfaf[1] = DualSenseDriver.RsqzXAWrjXSfoKEnDGBBeMgWCLRoA(DualSenseTriggerType.Right, this.OPDBmlQmdVpALplchXSETGiLhzlh[42 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA], this.OPDBmlQmdVpALplchXSETGiLhzlh[48 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA]);
			this.rZjrdeBATtnjGQKQgGlJIZNhIWhd();
			return true;
		}

		// Token: 0x0600164A RID: 5706 RVA: 0x0001CB11 File Offset: 0x0001AD11
		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x0001CB19 File Offset: 0x0001AD19
		private void oWvuWWtEZFFApYUXEdOezWeqatzM(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			if (!this.MmuCodCdGMDbaGxzdqbNHsZvtqahb)
			{
				return;
			}
			this.CbKLYosANlCegVYbVWsDESTUdAQv(A_1);
			this.MmuCodCdGMDbaGxzdqbNHsZvtqahb = false;
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x0004E34C File Offset: 0x0004C54C
		private bool CbKLYosANlCegVYbVWsDESTUdAQv(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			this.nrBSmyNyjojsRLBnkBHnWtTkcVUn();
			bool result = this.phWJUbVqkaHpCiKdZtNxKKBhkudM(A_1);
			if (this.ACIUqfAulQkhDzoUKRfxsGdQHtpc)
			{
				result = this.phWJUbVqkaHpCiKdZtNxKKBhkudM(A_1);
				this.ACIUqfAulQkhDzoUKRfxsGdQHtpc = false;
			}
			return result;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x0004E380 File Offset: 0x0004C580
		private void nrBSmyNyjojsRLBnkBHnWtTkcVUn()
		{
			if (this.vtFZlLBbtohFVCltIGDNvqojcghKA && this.FKIphGjuKJhiiTnDUecqFBtmlEiL)
			{
				this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA[0] = 49;
				this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA[1] = 2;
				this.EiUdkmyLygahUOfdUgcSHZSfLFnU(this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA, 2);
				uint num = DualSenseDriver.oceCSqwBTJdZDLlvGflGEaqVuJNE(this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA, 74);
				this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA[74] = (byte)(num & 255U);
				this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA[75] = (byte)((num & 65280U) >> 8);
				this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA[76] = (byte)((num & 16711680U) >> 16);
				this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA[77] = (byte)((num & 4278190080U) >> 24);
				return;
			}
			this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA[0] = 2;
			this.EiUdkmyLygahUOfdUgcSHZSfLFnU(this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA, 1);
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x0004E450 File Offset: 0x0004C650
		private void EiUdkmyLygahUOfdUgcSHZSfLFnU(NativeBuffer A_1, int A_2)
		{
			DualSenseDriver.ufbPHdhYzXnlyMLxozdOYepXctaG ufbPHdhYzXnlyMLxozdOYepXctaG = DualSenseDriver.ufbPHdhYzXnlyMLxozdOYepXctaG.None;
			DualSenseDriver.JlBCZZeVYblOqMkBiODOkFQhEatdb jlBCZZeVYblOqMkBiODOkFQhEatdb = DualSenseDriver.JlBCZZeVYblOqMkBiODOkFQhEatdb.None;
			ufbPHdhYzXnlyMLxozdOYepXctaG |= DualSenseDriver.ufbPHdhYzXnlyMLxozdOYepXctaG.HapticsSelect;
			if (this.vIKjFKSLbwuBSScPCCTIVRIojGeEA == DualSenseVibrationMode.Compatible)
			{
				ufbPHdhYzXnlyMLxozdOYepXctaG |= DualSenseDriver.ufbPHdhYzXnlyMLxozdOYepXctaG.CompatibleVibrationMode1;
			}
			this.wVJDccOKbLwbTAkeyBwOhhBQfjMI = false;
			ufbPHdhYzXnlyMLxozdOYepXctaG |= DualSenseDriver.ufbPHdhYzXnlyMLxozdOYepXctaG.LeftTriggerEffect;
			this.fFZBQnrjCCgnMPMAZXHrkvokUiye = false;
			ufbPHdhYzXnlyMLxozdOYepXctaG |= DualSenseDriver.ufbPHdhYzXnlyMLxozdOYepXctaG.RightTriggerEffect;
			this.pTzMlECtCDHmvknUlfEmaPhINuGib = false;
			jlBCZZeVYblOqMkBiODOkFQhEatdb |= DualSenseDriver.JlBCZZeVYblOqMkBiODOkFQhEatdb.MicrophoneLEDControl;
			this.cMzLhDMnRMTPcUbhHvgmDketcBFGA = false;
			jlBCZZeVYblOqMkBiODOkFQhEatdb |= DualSenseDriver.JlBCZZeVYblOqMkBiODOkFQhEatdb.PlayerIndicatorLEDControl;
			this.efOWjQrVptmFXycDFUCjTnkKDNbq = false;
			jlBCZZeVYblOqMkBiODOkFQhEatdb |= DualSenseDriver.JlBCZZeVYblOqMkBiODOkFQhEatdb.LightbarControl;
			this.VxUtaGOXjOqRDGbodAujhxsyeSvk = false;
			jlBCZZeVYblOqMkBiODOkFQhEatdb |= DualSenseDriver.JlBCZZeVYblOqMkBiODOkFQhEatdb.ChangeOverallMotorEffectPower;
			this.ucsrNLFFzQZxXEKfirkRWcXaLKFg = false;
			A_1[A_2] = (byte)ufbPHdhYzXnlyMLxozdOYepXctaG;
			A_1[1 + A_2] = (byte)jlBCZZeVYblOqMkBiODOkFQhEatdb;
			A_1[2 + A_2] = (byte)this.vibrationMotors[1].jytYrChQDenkTUaEnqBMeGDoorVS;
			A_1[3 + A_2] = (byte)this.vibrationMotors[0].jytYrChQDenkTUaEnqBMeGDoorVS;
			A_1[8 + A_2] = (byte)this.BqVkTHNpOpBMRCwfmjRThhRvnOAR;
			DualSenseDriver.eJZWqzSUzdnKnVCXsmZonKbMqCXK eJZWqzSUzdnKnVCXsmZonKbMqCXK = DualSenseDriver.eJZWqzSUzdnKnVCXsmZonKbMqCXK.None;
			eJZWqzSUzdnKnVCXsmZonKbMqCXK |= DualSenseDriver.eJZWqzSUzdnKnVCXsmZonKbMqCXK.OtherLightBrightnessControl;
			this.HrsbfIizTFjfiUQRDJwRcMmDKPTNA = false;
			if (this.vIKjFKSLbwuBSScPCCTIVRIojGeEA == DualSenseVibrationMode.Compatible2)
			{
				eJZWqzSUzdnKnVCXsmZonKbMqCXK |= DualSenseDriver.eJZWqzSUzdnKnVCXsmZonKbMqCXK.CompatibleVibrationMode2;
			}
			eJZWqzSUzdnKnVCXsmZonKbMqCXK |= DualSenseDriver.eJZWqzSUzdnKnVCXsmZonKbMqCXK.LightbarSetupControl;
			this.jmBsJUbcWsmRrylqtURIAzteatfT = false;
			A_1[38 + A_2] = (byte)eJZWqzSUzdnKnVCXsmZonKbMqCXK;
			A_1[41 + A_2] = this.ACcmWhSikaHNCGlPXTUGqfWmquOU;
			A_1[42 + A_2] = (byte)this.bKRBPwbOlxiiUYnSaTcRqXBUBHTd;
			A_1[43 + A_2] = (byte)this.qGqGTuTEcJdIIREVSJoRDrOZHcwm;
			if (this.eFddSZgSoVhABDOrziRrCiJUSfTCA)
			{
				A_1[43 + A_2] = (byte)((int)A_1[43 + A_2] & -33);
			}
			else
			{
				int index = 43 + A_2;
				A_1[index] |= 32;
			}
			A_1[44 + A_2] = this.lights[0].TlvlHFiErUcjYOwvLtmUwbOdHcBfA;
			A_1[45 + A_2] = this.lights[0].PWTUXhdobKCWkDPPBdKjnUKMnFly;
			A_1[46 + A_2] = this.lights[0].vyzFPPOkFkdeNAGombLrQBWeWzFsA;
			this.uiLCDasenvCllmkDnHAYvjUqPrrM(ref this.wFeMfrbsWpCDJbhliEzLeGxwOSEP[1], A_1, 10 + A_2);
			this.uiLCDasenvCllmkDnHAYvjUqPrrM(ref this.wFeMfrbsWpCDJbhliEzLeGxwOSEP[0], A_1, 21 + A_2);
			A_1[36 + A_2] = 0;
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x0004E628 File Offset: 0x0004C828
		private void uiLCDasenvCllmkDnHAYvjUqPrrM(ref IDualSenseTriggerEffect A_1, NativeBuffer A_2, int A_3)
		{
			if (A_1 == null)
			{
				A_2[A_3] = 0;
				return;
			}
			switch (A_1.triggerEffectType)
			{
			case DualSenseTriggerEffectType.Off:
				DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(this.JVmsOIlzqiJsrTZvQIEroqmOwMOp, 0);
				break;
			case DualSenseTriggerEffectType.Feedback:
			{
				DualSenseTriggerEffectFeedback dualSenseTriggerEffectFeedback = (DualSenseTriggerEffectFeedback)A_1;
				DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.GoczaKltbOwJckpRAaXvRoeOtLlf(this.JVmsOIlzqiJsrTZvQIEroqmOwMOp, 0, dualSenseTriggerEffectFeedback.position, dualSenseTriggerEffectFeedback.strength);
				break;
			}
			case DualSenseTriggerEffectType.Weapon:
			{
				DualSenseTriggerEffectWeapon dualSenseTriggerEffectWeapon = (DualSenseTriggerEffectWeapon)A_1;
				DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.OCNqhvVrcgdULvBRgULVnYpivuPg(this.JVmsOIlzqiJsrTZvQIEroqmOwMOp, 0, dualSenseTriggerEffectWeapon.startPosition, dualSenseTriggerEffectWeapon.endPosition, dualSenseTriggerEffectWeapon.strength);
				break;
			}
			case DualSenseTriggerEffectType.Vibration:
			{
				DualSenseTriggerEffectVibration dualSenseTriggerEffectVibration = (DualSenseTriggerEffectVibration)A_1;
				DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.cIcTnQVSBlSbYAGFmIoRtCbJJAdW(this.JVmsOIlzqiJsrTZvQIEroqmOwMOp, 0, dualSenseTriggerEffectVibration.position, dualSenseTriggerEffectVibration.amplitude, dualSenseTriggerEffectVibration.frequency);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionFeedback:
				((DualSenseTriggerEffectMultiplePositionFeedback)A_1).strength.CopyTo(this.JHfcameSWbragWWScGjeksAvgTYeA);
				DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.YRJEyNBWJMCCstXQjuCXItBAQQWgA(this.JVmsOIlzqiJsrTZvQIEroqmOwMOp, 0, this.JHfcameSWbragWWScGjeksAvgTYeA);
				break;
			case DualSenseTriggerEffectType.SlopeFeedback:
			{
				DualSenseTriggerEffectSlopeFeedback dualSenseTriggerEffectSlopeFeedback = (DualSenseTriggerEffectSlopeFeedback)A_1;
				DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.EuzHGDGpdryDDJhWNfgZmVBBeHlaA(this.JVmsOIlzqiJsrTZvQIEroqmOwMOp, 0, dualSenseTriggerEffectSlopeFeedback.startPosition, dualSenseTriggerEffectSlopeFeedback.endPosition, dualSenseTriggerEffectSlopeFeedback.startStrength, dualSenseTriggerEffectSlopeFeedback.endStrength);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionVibration:
			{
				DualSenseTriggerEffectMultiplePositionVibration dualSenseTriggerEffectMultiplePositionVibration = (DualSenseTriggerEffectMultiplePositionVibration)A_1;
				dualSenseTriggerEffectMultiplePositionVibration.amplitude.CopyTo(this.JHfcameSWbragWWScGjeksAvgTYeA);
				DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.cHcwwXippnCgIodOhdsjBLXjIrNp(this.JVmsOIlzqiJsrTZvQIEroqmOwMOp, 0, dualSenseTriggerEffectMultiplePositionVibration.frequency, this.JHfcameSWbragWWScGjeksAvgTYeA);
				break;
			}
			default:
				Logger.LogWarning("Unknown trigger effect type: 0x" + ((byte)A_1.triggerEffectType).ToString("x2"));
				return;
			}
			A_2.Write(this.JVmsOIlzqiJsrTZvQIEroqmOwMOp, this.JVmsOIlzqiJsrTZvQIEroqmOwMOp.Length, A_3, 0);
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x0004E7EC File Offset: 0x0004C9EC
		private bool phWJUbVqkaHpCiKdZtNxKKBhkudM(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			this.VohmrkeAdkFUoTNBpgqrCqbJOjphb = ReInput.realTime + 4.0;
			if (A_1 == xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous)
			{
				return this.vopaOdvZXmmvkDiibFtNaurhFYPJA.WriteSync(this.BBtPFjnSBTpngXHkKDhJKqTEzsTy, 0);
			}
			if (A_1 == xvcebytMmHXPBmUQiJYMACsdJpLo.Asynchronous)
			{
				this.vopaOdvZXmmvkDiibFtNaurhFYPJA.WriteAsync(this.BBtPFjnSBTpngXHkKDhJKqTEzsTy, 1000);
				return true;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x0004E848 File Offset: 0x0004CA48
		private void EJYmCKgYwURJAvHRwwKmmZRFNUSX(NativeBuffer A_1, double A_2)
		{
			byte b = A_1[this.yDshYmiDYDnhtdPDHlKFNzMwysaQA];
			this.buttons[0].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 16) > 0, A_2);
			this.buttons[1].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 32) > 0, A_2);
			this.buttons[2].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 64) > 0, A_2);
			this.buttons[3].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 128) > 0, A_2);
			b = A_1[this.JeGBVcfcEGuzTkqANdMTDaGisypz];
			this.buttons[4].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 1) > 0, A_2);
			this.buttons[5].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 2) > 0, A_2);
			this.buttons[6].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 4) > 0, A_2);
			this.buttons[7].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 8) > 0, A_2);
			this.buttons[8].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 16) > 0, A_2);
			this.buttons[9].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 32) > 0, A_2);
			this.buttons[10].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 64) > 0, A_2);
			this.buttons[11].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 128) > 0, A_2);
			b = A_1[this.mjDbQLLyLaPRWwtbPxnlBOcAPIBJ];
			this.buttons[12].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 1) > 0, A_2);
			this.buttons[13].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 2) > 0, A_2);
			if (this.FKIphGjuKJhiiTnDUecqFBtmlEiL)
			{
				this.buttons[14].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 4) > 0, A_2);
			}
		}

		// Token: 0x06001652 RID: 5714 RVA: 0x0004E9C4 File Offset: 0x0004CBC4
		private void lvAUrPLzzdAubzzkDWRyVekvvbjr(zHTBvVyhFGDLpEJMFINchPNfqnfnb[] A_1, NativeBuffer A_2, double A_3)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				A_1[i].WMAwtKiWRygWRqyRkTqlMnhmDEdgA(A_2, A_3);
			}
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x0001CB33 File Offset: 0x0001AD33
		private void UZPBPcdTwmgkhrBGTHOAeLMJiUnRA()
		{
			if (this.isVibrating && ReInput.realTime >= this.VohmrkeAdkFUoTNBpgqrCqbJOjphb)
			{
				this.qWSEyyyhENTESWboTeJdJwsffljGA();
				this.wVJDccOKbLwbTAkeyBwOhhBQfjMI = true;
			}
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x0004E9EC File Offset: 0x0004CBEC
		private void wzwzfRWLmWoaKzMHtJkLhteUfrNj(NativeBuffer A_1)
		{
			if (!this.FKIphGjuKJhiiTnDUecqFBtmlEiL)
			{
				return;
			}
			uint num = this.OPDBmlQmdVpALplchXSETGiLhzlh.ReadUInt(28 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA);
			float spkApLOyVjkvlycvIcvDjCMuAwraA;
			if (num != this.qgyNlIUpsYiOLrWErFRvvNMElZTS)
			{
				uint num2;
				if (num < this.qgyNlIUpsYiOLrWErFRvvNMElZTS)
				{
					num2 = (uint)((ulong)num + (ulong)-1 - (ulong)this.qgyNlIUpsYiOLrWErFRvvNMElZTS);
				}
				else
				{
					num2 = num - this.qgyNlIUpsYiOLrWErFRvvNMElZTS;
				}
				spkApLOyVjkvlycvIcvDjCMuAwraA = num2 / 3000000f;
			}
			else
			{
				spkApLOyVjkvlycvIcvDjCMuAwraA = 0f;
			}
			this.qgyNlIUpsYiOLrWErFRvvNMElZTS = num;
			this.SpkApLOyVjkvlycvIcvDjCMuAwraA = spkApLOyVjkvlycvIcvDjCMuAwraA;
		}

		// Token: 0x06001655 RID: 5717 RVA: 0x0004EA68 File Offset: 0x0004CC68
		private void rZjrdeBATtnjGQKQgGlJIZNhIWhd()
		{
			if (!this.FKIphGjuKJhiiTnDUecqFBtmlEiL)
			{
				return;
			}
			if (this.SpkApLOyVjkvlycvIcvDjCMuAwraA <= 0f)
			{
				return;
			}
			Vector3 vector = this.GQzzTJOwcYVEWDOhRbVsdhXhgpJd(new Vector3(this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[0], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[1], this.gyroscopes[0].dcPcKZhVzOuuuyblktasXCrYPsIq[2]), this.SpkApLOyVjkvlycvIcvDjCMuAwraA);
			DualSenseDriver.eHXoniFQIbgZtutCUHZkYQtAmrLJ(ref vector);
			Vector3 vector2 = new Vector3(this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[0] * -1f, this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[1] * -1f, this.accelerometers[0].wxlPSRPpXOGcnsgwYrXChZnlGJzD[2] * -1f);
			this.QOgfKEUWmgqRFhuQTiGcVVCOZRgb(vector2, vector);
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x0001CB57 File Offset: 0x0001AD57
		private static bool eHXoniFQIbgZtutCUHZkYQtAmrLJ(ref Vector3 A_0)
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

		// Token: 0x06001657 RID: 5719 RVA: 0x0004EB24 File Offset: 0x0004CD24
		private void QOgfKEUWmgqRFhuQTiGcVVCOZRgb(Vector3 A_1, Vector3 A_2)
		{
			Quaternion rhs = Quaternion.Euler(A_2);
			float sqrMagnitude = A_1.sqrMagnitude;
			DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE fzvaeaGPnJYhsQXnexOZdTgFRNEE;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && this.ImYYingPEreELCpgtdGKJQSJHRVc(A_1, out fzvaeaGPnJYhsQXnexOZdTgFRNEE))
			{
				Quaternion a = this.XFeikQhdjUOPaDjKNYRnplQNHMfFb * rhs;
				if (!this.RBDBhSHnXWSAnWYYWXhIodKvSXHm)
				{
					this.RBDBhSHnXWSAnWYYWXhIodKvSXHm = true;
					this.zwLayRExrWMSdfSlMuvqtZJLOamF = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					this.VdkMiNITPXMsWDJEohICWqdKJYiJ = this.XFeikQhdjUOPaDjKNYRnplQNHMfFb;
				}
				this.zwLayRExrWMSdfSlMuvqtZJLOamF *= rhs;
				this.VdkMiNITPXMsWDJEohICWqdKJYiJ *= rhs;
				Quaternion quaternion;
				if ((fzvaeaGPnJYhsQXnexOZdTgFRNEE & DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE.XZ) != DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE.None)
				{
					quaternion = this.MmwikNNtkvaIktJqUmzAKetmnfRU(A_1, a.eulerAngles.y);
				}
				else if ((fzvaeaGPnJYhsQXnexOZdTgFRNEE & DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE.Y) != DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE.None)
				{
					quaternion = this.DIrRdFjwZbAXcTvwZrNCGqlUDDNQ(A_1, 0f);
					Vector3 vector = this.VdkMiNITPXMsWDJEohICWqdKJYiJ * Vector3.right;
					float y = -MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					quaternion = Quaternion.Euler(0f, y, 0f) * quaternion;
				}
				else
				{
					quaternion = Quaternion.identity;
				}
				this.XFeikQhdjUOPaDjKNYRnplQNHMfFb = Quaternion.Lerp(a, quaternion, 0.01999998f);
				return;
			}
			this.XFeikQhdjUOPaDjKNYRnplQNHMfFb *= rhs;
			if (this.RBDBhSHnXWSAnWYYWXhIodKvSXHm)
			{
				this.RBDBhSHnXWSAnWYYWXhIodKvSXHm = false;
			}
		}

		// Token: 0x06001658 RID: 5720 RVA: 0x0004EC9C File Offset: 0x0004CE9C
		private static Quaternion jvZCTCCCyQADchxoCXOTchGMlchB(Quaternion A_0, Vector3 A_1)
		{
			Vector3 vector = DualSenseDriver.GvibffbUEJUeCBuVQeWlyhpFWkZSA(new Vector3(A_0.x, A_0.y, A_0.z), A_1);
			return new Quaternion(vector.x, vector.y, vector.z, A_0.w);
		}

		// Token: 0x06001659 RID: 5721 RVA: 0x0004ECE4 File Offset: 0x0004CEE4
		private static Vector3 GvibffbUEJUeCBuVQeWlyhpFWkZSA(Vector3 A_0, Vector3 A_1)
		{
			float num = Vector3.Dot(A_1, A_1);
			if (num < 1E-45f)
			{
				return Vector3.zero;
			}
			return A_1 * Vector3.Dot(A_0, A_1) / num;
		}

		// Token: 0x0600165A RID: 5722 RVA: 0x0004ED1C File Offset: 0x0004CF1C
		private Quaternion rHUUHzUKENPrqTAbSxrneDrgbxzM(Quaternion A_1, DualSenseDriver.PCEuntbMBYUDNIBQAvwBrBKqgPhaA A_2)
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

		// Token: 0x0600165B RID: 5723 RVA: 0x0004EDC8 File Offset: 0x0004CFC8
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

		// Token: 0x0600165C RID: 5724 RVA: 0x0004EE58 File Offset: 0x0004D058
		private float mhkAuHDRUuxQXKprykygBSSeMzkEc(float A_1, float A_2)
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

		// Token: 0x0600165D RID: 5725 RVA: 0x0004EEA4 File Offset: 0x0004D0A4
		private Vector3 nKNxHLPBrqGWQoSlkELOyGqyvhjg(Vector3 A_1, float A_2 = 0f)
		{
			float num = MathTools.Atan2(A_1.z, A_1.y);
			float x = MathTools.Sqrt(MathTools.Pow(A_1.y, 2f) + MathTools.Pow(A_1.z, 2f));
			float num2 = MathTools.Atan2(A_1.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = -num2 * 57.29578f;
			return new Vector3(x2, A_2, z);
		}

		// Token: 0x0600165E RID: 5726 RVA: 0x0004EF14 File Offset: 0x0004D114
		private Quaternion MmwikNNtkvaIktJqUmzAKetmnfRU(Vector3 A_1, float A_2 = 0f)
		{
			float num = MathTools.Atan2(A_1.z, A_1.y);
			float x = MathTools.Sqrt(MathTools.Pow(A_1.y, 2f) + MathTools.Pow(A_1.z, 2f));
			float num2 = MathTools.Atan2(A_1.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = -num2 * 57.29578f;
			return Quaternion.Euler(x2, A_2, z);
		}

		// Token: 0x0600165F RID: 5727 RVA: 0x0004EF84 File Offset: 0x0004D184
		private Quaternion DIrRdFjwZbAXcTvwZrNCGqlUDDNQ(Vector3 A_1, float A_2 = 0f)
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

		// Token: 0x06001660 RID: 5728 RVA: 0x0001CB8A File Offset: 0x0001AD8A
		private float hJmuDZtseNmgbPneIjhWICrKBBUs(Vector3 A_1)
		{
			return MathTools.Atan2(A_1.x, A_1.z) * 57.29578f;
		}

		// Token: 0x06001661 RID: 5729 RVA: 0x0001CBA3 File Offset: 0x0001ADA3
		private bool itkZVCbjUAECecEZiCWNbxxNTzjGA(float A_1)
		{
			return A_1 >= 45f && A_1 <= 70f;
		}

		// Token: 0x06001662 RID: 5730 RVA: 0x0004F038 File Offset: 0x0004D238
		private bool ImYYingPEreELCpgtdGKJQSJHRVc(Vector3 A_1, out DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE A_2)
		{
			A_1.Normalize();
			A_2 = DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE.None;
			bool result = false;
			if (this.QGcfPcOBMuSGcXMIbacefBvJBYFW(A_1))
			{
				result = true;
				A_2 |= DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE.XZ;
			}
			if (this.KDBkFkRpSBlLrygyLtBadNADpOuT(A_1))
			{
				result = true;
				A_2 |= DualSenseDriver.FZvaeaGPnJYhsQXnexOZdTgFRNEE.Y;
			}
			return result;
		}

		// Token: 0x06001663 RID: 5731 RVA: 0x0001CBBA File Offset: 0x0001ADBA
		private bool QGcfPcOBMuSGcXMIbacefBvJBYFW(Vector3 A_1)
		{
			return A_1.y <= 0f && Vector3.Angle(Vector3.down, A_1) <= 45f;
		}

		// Token: 0x06001664 RID: 5732 RVA: 0x0001CBE0 File Offset: 0x0001ADE0
		private bool KDBkFkRpSBlLrygyLtBadNADpOuT(Vector3 A_1)
		{
			return A_1.z >= 0f && Vector3.Angle(new Vector3(0f, 0f, 1f), A_1) <= 20f;
		}

		// Token: 0x06001665 RID: 5733 RVA: 0x0001CC15 File Offset: 0x0001AE15
		private Vector3 AUHIzRDdQlokwCmcRFEhtcSaHLkw(float[] A_1)
		{
			return new Vector3(A_1[0] * 0.00012207031f * -1f, A_1[1] * 0.00012207031f * -1f, A_1[2] * 0.00012207031f);
		}

		// Token: 0x06001666 RID: 5734 RVA: 0x0004F074 File Offset: 0x0004D274
		private Vector3 lvqwMXedNxgkCgTnLYtgoDqrNEbLA(RingBuffer<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA> A_1)
		{
			Vector3 vector = default(Vector3);
			int count = A_1.Count;
			for (int i = 0; i < count; i++)
			{
				TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA tfparbbNAvPzQuJwQCaWGkjzhFcEA = A_1[i];
				vector += this.GQzzTJOwcYVEWDOhRbVsdhXhgpJd(tfparbbNAvPzQuJwQCaWGkjzhFcEA.pvLAGAwFJrHGOyvACtaBXkmQbXxf, tfparbbNAvPzQuJwQCaWGkjzhFcEA.LXxeqTTliOIfyvHMKPvmZGvcuGex);
			}
			return vector;
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x0001CC43 File Offset: 0x0001AE43
		private Vector3 GQzzTJOwcYVEWDOhRbVsdhXhgpJd(Vector3 A_1, float A_2)
		{
			A_1.x *= -1f;
			A_1.y *= -1f;
			return A_1 * 0.06103702f * A_2;
		}

		// Token: 0x06001668 RID: 5736 RVA: 0x0001CC76 File Offset: 0x0001AE76
		private int kyofkDYRaQQwvVdPINTcLyoKBuJD(int A_1)
		{
			A_1 &= 15;
			return A_1;
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x0001CC7F File Offset: 0x0001AE7F
		private void PZwNuBAQyviozkURxwNBZyypSOTF(byte[] A_1, float[] A_2)
		{
			A_2[0] = (float)BitConverter.ToInt16(A_1, 0);
			A_2[1] = (float)BitConverter.ToInt16(A_1, 2);
			A_2[2] = (float)BitConverter.ToInt16(A_1, 4);
		}

		// Token: 0x0600166A RID: 5738 RVA: 0x0001CC7F File Offset: 0x0001AE7F
		private void FgbYDAPNBnSvLZXTeIliKNPlFpBJA(byte[] A_1, float[] A_2)
		{
			A_2[0] = (float)BitConverter.ToInt16(A_1, 0);
			A_2[1] = (float)BitConverter.ToInt16(A_1, 2);
			A_2[2] = (float)BitConverter.ToInt16(A_1, 4);
		}

		// Token: 0x0600166B RID: 5739 RVA: 0x0001CCA2 File Offset: 0x0001AEA2
		private float XfPqHllRYMrlQFJcJlHTDWCNsPZM()
		{
			return this.SpkApLOyVjkvlycvIcvDjCMuAwraA;
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x0004F0C0 File Offset: 0x0004D2C0
		private void BwSHVMcdDjCevnShdmyiidgJERtCA(NativeBuffer A_1, zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData[] A_2)
		{
			int num = 33 + this.bKVFFmKQdrAdAXmJXLCsxOvQiAwA;
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
			A_2[0].touchId = this.fsEXmUDVgBLLIQWLdTHISVZQrsSp(0, flag, num2);
			A_2[0].positionRawX = positionRawX;
			A_2[0].positionRawY = positionRawY;
			A_2[1].isTouching = flag2;
			A_2[1].touchId = this.fsEXmUDVgBLLIQWLdTHISVZQrsSp(1, flag2, num3);
			A_2[1].positionRawX = positionRawX2;
			A_2[1].positionRawY = positionRawY2;
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x0004F204 File Offset: 0x0004D404
		private int fsEXmUDVgBLLIQWLdTHISVZQrsSp(int A_1, bool A_2, int A_3)
		{
			if (!A_2)
			{
				this.iKAKWCeTWoIeyuHmHxUuKRfacVtW[A_1] = -1;
				this.VqhFDIFeISTdrgSYnARLbArNkMnP[A_1] = A_3;
				return -1;
			}
			if (A_3 != this.VqhFDIFeISTdrgSYnARLbArNkMnP[A_1])
			{
				int ipaBCrhgtYinEZlpekTAECljLYdA = this.IPaBCrhgtYinEZlpekTAECljLYdA;
				if (this.IPaBCrhgtYinEZlpekTAECljLYdA == 2147483647)
				{
					this.IPaBCrhgtYinEZlpekTAECljLYdA = 0;
				}
				else
				{
					this.IPaBCrhgtYinEZlpekTAECljLYdA++;
				}
				this.VqhFDIFeISTdrgSYnARLbArNkMnP[A_1] = A_3;
				this.iKAKWCeTWoIeyuHmHxUuKRfacVtW[A_1] = ipaBCrhgtYinEZlpekTAECljLYdA;
				return ipaBCrhgtYinEZlpekTAECljLYdA;
			}
			return this.iKAKWCeTWoIeyuHmHxUuKRfacVtW[A_1];
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x0001CCAA File Offset: 0x0001AEAA
		private void FljLtdLymqPAFubUGigKzfnthHmQ()
		{
			this.VxUtaGOXjOqRDGbodAujhxsyeSvk = true;
			this.qWSEyyyhENTESWboTeJdJwsffljGA();
		}

		// Token: 0x0600166F RID: 5743 RVA: 0x0001CCAA File Offset: 0x0001AEAA
		private void rwjeomgYCtlsjgQzDUawPNmSmwFzA()
		{
			this.VxUtaGOXjOqRDGbodAujhxsyeSvk = true;
			this.qWSEyyyhENTESWboTeJdJwsffljGA();
		}

		// Token: 0x06001670 RID: 5744 RVA: 0x0001CCB9 File Offset: 0x0001AEB9
		private void SmFxbbxCSzcpRHAWyXWauzPnOvSTA()
		{
			this.wVJDccOKbLwbTAkeyBwOhhBQfjMI = true;
			this.qWSEyyyhENTESWboTeJdJwsffljGA();
		}

		// Token: 0x06001671 RID: 5745 RVA: 0x0001CCC8 File Offset: 0x0001AEC8
		private void qWSEyyyhENTESWboTeJdJwsffljGA()
		{
			this.MmuCodCdGMDbaGxzdqbNHsZvtqahb = true;
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x0004F27C File Offset: 0x0004D47C
		~DualSenseDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x06001673 RID: 5747 RVA: 0x0004F2AC File Offset: 0x0004D4AC
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
				this.oWvuWWtEZFFApYUXEdOezWeqatzM(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
				if (this.OPDBmlQmdVpALplchXSETGiLhzlh != null)
				{
					this.OPDBmlQmdVpALplchXSETGiLhzlh.Dispose();
				}
				if (this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA != null)
				{
					this.gADMYNxoxxmjAiNDzAwIwAKWGFbeA.Dispose();
				}
			}
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x0001CCD1 File Offset: 0x0001AED1
		public static bool Matches(int vid, int pid)
		{
			return pid == 3302 && vid == 1356;
		}

		// Token: 0x06001675 RID: 5749 RVA: 0x0004F300 File Offset: 0x0004D500
		private static uint oceCSqwBTJdZDLlvGflGEaqVuJNE(NativeBuffer A_0, int A_1)
		{
			uint num = 3940166985U;
			for (int i = 0; i < A_1; i++)
			{
				num = (DualSenseDriver.NeFyakBjHeeBnxdxmbwGlzKgWbkk[(int)((byte)num ^ A_0[i])] ^ num >> 8);
			}
			return num;
		}

		// Token: 0x06001676 RID: 5750 RVA: 0x0001CCE5 File Offset: 0x0001AEE5
		private static DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm ABGEYjKawyNqwKPseawCydOsWhIk(DualSenseOtherLightBrightness A_0)
		{
			switch (A_0)
			{
			case DualSenseOtherLightBrightness.Low:
				return DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm.Low;
			case DualSenseOtherLightBrightness.Medium:
				return DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm.Medium;
			case DualSenseOtherLightBrightness.High:
				return DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm.High;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06001677 RID: 5751 RVA: 0x0001CD06 File Offset: 0x0001AF06
		private static DualSenseOtherLightBrightness heoaEUEBCEYNZzOXOTTaacZgLkju(DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm A_0)
		{
			switch (A_0)
			{
			case DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm.High:
				return DualSenseOtherLightBrightness.High;
			case DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm.Medium:
				return DualSenseOtherLightBrightness.Medium;
			case DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm.Low:
				return DualSenseOtherLightBrightness.Low;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x0004F338 File Offset: 0x0004D538
		private static DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA sYmDOeDpHRYdyasZBfQNrxuPcNZsA(DualSenseTriggerType A_0, byte A_1)
		{
			byte b;
			if (A_0 != DualSenseTriggerType.Left)
			{
				if (A_0 != DualSenseTriggerType.Right)
				{
					return DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Off;
				}
				b = new DualSenseDriver.FRJklUpLETAfgAIfIlZuMsQxmuwV(A_1).PbFcXGgtGFFwPIfMiGDhZXBoerzBA;
			}
			else
			{
				b = new DualSenseDriver.FRJklUpLETAfgAIfIlZuMsQxmuwV(A_1).zckbzEHJuFcJPESbDwgGTuafUVFIB;
			}
			switch (b)
			{
			case 0:
				return DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Off;
			case 1:
				return DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Feedback;
			case 2:
				return DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Weapon;
			case 3:
				return DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Vibration;
			case 4:
				return DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.SlopeFeedback;
			default:
				return DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Off;
			}
		}

		// Token: 0x06001679 RID: 5753 RVA: 0x0004F39C File Offset: 0x0004D59C
		private static DualSenseTriggerEffectState RsqzXAWrjXSfoKEnDGBBeMgWCLRoA(DualSenseTriggerType A_0, byte A_1, byte A_2)
		{
			byte b = new DualSenseDriver.FRJklUpLETAfgAIfIlZuMsQxmuwV(A_1).zckbzEHJuFcJPESbDwgGTuafUVFIB;
			switch (DualSenseDriver.sYmDOeDpHRYdyasZBfQNrxuPcNZsA(A_0, A_2))
			{
			case DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Off:
				return DualSenseTriggerEffectState.Off;
			case DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Feedback:
				if (b == 0)
				{
					return DualSenseTriggerEffectState.FeedbackIdle;
				}
				if (b != 1)
				{
					return DualSenseTriggerEffectState.FeedbackIdle;
				}
				return DualSenseTriggerEffectState.FeedbackApplyingForce;
			case DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Weapon:
				switch (b)
				{
				case 0:
					return DualSenseTriggerEffectState.WeaponIdle;
				case 1:
					return DualSenseTriggerEffectState.WeaponFiring;
				case 2:
					return DualSenseTriggerEffectState.WeaponFired;
				default:
					return DualSenseTriggerEffectState.WeaponIdle;
				}
				break;
			case DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.Vibration:
				if (b == 0)
				{
					return DualSenseTriggerEffectState.VibrationIdle;
				}
				if (b != 1)
				{
					return DualSenseTriggerEffectState.VibrationIdle;
				}
				return DualSenseTriggerEffectState.VibrationVibrating;
			case DualSenseDriver.vAWLsUYlbmIWpwiOKEXwPlPvHpdFA.SlopeFeedback:
				switch (b)
				{
				case 0:
					return (DualSenseTriggerEffectState)8;
				case 1:
					return (DualSenseTriggerEffectState)9;
				case 2:
					return (DualSenseTriggerEffectState)10;
				default:
					return (DualSenseTriggerEffectState)8;
				}
				break;
			default:
				return DualSenseTriggerEffectState.Off;
			}
		}

		// Token: 0x0600167A RID: 5754 RVA: 0x0001CD27 File Offset: 0x0001AF27
		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
			if (msg == null)
			{
				return;
			}
			Logger.Log("DualSenseDriver: " + ((msg != null) ? msg.ToString() : null));
		}

		// Token: 0x04003112 RID: 12562
		private const float ABLednoizqyfCFTkGdMtSPsRCNAp = 4f;

		// Token: 0x04003113 RID: 12563
		private const int KFNDnWtwwWmGSlwspFqbpaEctYPN = 15;

		// Token: 0x04003114 RID: 12564
		private const int gVFuIEBijpBXYGMMHeuyxhLQCaFIb = 2;

		// Token: 0x04003115 RID: 12565
		private const int JCTxvRhrzfnGYNMGlHTFakAEXXeNA = 0;

		// Token: 0x04003116 RID: 12566
		private const int YluOsWjVyVpRWUacXMEFooHMNdJm = 1912;

		// Token: 0x04003117 RID: 12567
		private const int MrBwBoHjADPEBNLXNgLGsPhkOmMl = 0;

		// Token: 0x04003118 RID: 12568
		private const int fxKyXSaKJJEgvjlQqsYkhVxbNGGp = 941;

		// Token: 0x04003119 RID: 12569
		private const bool jzqpvFrQcZDnPzhdmyxYKScfNXYG = false;

		// Token: 0x0400311A RID: 12570
		private const bool yHLHekLmACRocJqNACqDBDvYzctUA = true;

		// Token: 0x0400311B RID: 12571
		private const float NcZLTxeDoStpTTrYRObJfeYNzlso = 2.5f;

		// Token: 0x0400311C RID: 12572
		private const int XuqGdIlujxeudOIoefmnfoYZiYeIA = 0;

		// Token: 0x0400311D RID: 12573
		private const int WhdhxEdWPcQSfaJrzkAatBnpZVSQ = 0;

		// Token: 0x0400311E RID: 12574
		private const int VTokjhMAPJCKpSxoQaIkCVbhPwbF = 1;

		// Token: 0x0400311F RID: 12575
		private const int eJgLNzoatOuZztbTWzyeRLRPhXhH = 0;

		// Token: 0x04003120 RID: 12576
		private const int yyfBJZEKuACkGuceHBNhAUOnBZiC = 0;

		// Token: 0x04003121 RID: 12577
		private const int jTgWrvJbQCogYUBTeilazEMXHeYG = 0;

		// Token: 0x04003122 RID: 12578
		private const int UfnUfomPOkRnqxbPBUOavxxigodc = 1;

		// Token: 0x04003123 RID: 12579
		private const int lwzMnkjNhqeUSfTYhTkCFqdQAFhuA = 49;

		// Token: 0x04003124 RID: 12580
		private const int JrOlXBvrFAVyuvZAsNuiyTiJJHDj = 0;

		// Token: 0x04003125 RID: 12581
		private const int yMtkVzZjCNIpZFBSjheDbgyStdJIA = 1;

		// Token: 0x04003126 RID: 12582
		private const int JLxovYhiVxXZDCxIxhZNIPdtlVqD = 64;

		// Token: 0x04003127 RID: 12583
		private const int VIEPglCGhwLvHUBbUABIhYHzaECqA = 48;

		// Token: 0x04003128 RID: 12584
		private const int brHdEnIHQRbhRhXrZsiiFkfJWkjDA = 78;

		// Token: 0x04003129 RID: 12585
		private const int TOywTUgNuWuzWdDAuzMsJKIydndY = 5;

		// Token: 0x0400312A RID: 12586
		private const int xluBNqPyhXWEGsPqUayUbwtRuYElA = 41;

		// Token: 0x0400312B RID: 12587
		private const byte kLLAKXvmYweUbAVvDByYquASOoJf = 1;

		// Token: 0x0400312C RID: 12588
		private const byte UnyESggmaYqnDylxMIGkmGfFcYaBA = 2;

		// Token: 0x0400312D RID: 12589
		private const int KISjlXBwjXTElxSrdhFwmVCUcHr = 1;

		// Token: 0x0400312E RID: 12590
		private const int zdjdUCdpiZrUGrIdoLQjVXLmtMAi = 2;

		// Token: 0x0400312F RID: 12591
		private const int GXovdexbYCFWzPmghOklIdSbzgMD = 3;

		// Token: 0x04003130 RID: 12592
		private const int qlmbhccySjKZWKTAQFLNvhwQozxZ = 4;

		// Token: 0x04003131 RID: 12593
		private const int xJdeNjDRjamqaffHMdpAUJRKJxxF = 5;

		// Token: 0x04003132 RID: 12594
		private const int yKQVCSwTyyHWuHGSlaMAzpcPOSlo = 6;

		// Token: 0x04003133 RID: 12595
		private const int RafdAwbSwzSbswuwIIfAVtCirdXDA = 8;

		// Token: 0x04003134 RID: 12596
		private const int hSoApckRgkvQMaNFOeyhuCRZiyKY = 22;

		// Token: 0x04003135 RID: 12597
		private const int JyKgcQYdxaMuZFNAYGXZGYZspaFG = 16;

		// Token: 0x04003136 RID: 12598
		private const int QTHInkuTAExpYrSjmbLNjJPbAPVu = 33;

		// Token: 0x04003137 RID: 12599
		private const int tdEgTqikNJoiiZbolYvhQdfzlfQKA = 8;

		// Token: 0x04003138 RID: 12600
		private const int NflGnEVbmKHTDDjFyPUlICzBQSOCA = 9;

		// Token: 0x04003139 RID: 12601
		private const int lihgbrHsOYMSeiNQkvonoswAICftA = 10;

		// Token: 0x0400313A RID: 12602
		private const int GxPdhVcrrtnNgBOZbftJjQBnsUfYB = 28;

		// Token: 0x0400313B RID: 12603
		private const int VQhcYUZXMUwGSPLxapjyAnKYcPGt = 53;

		// Token: 0x0400313C RID: 12604
		private const int YhrCohBswPhrGgUMYrZsbeuxwuoE = 54;

		// Token: 0x0400313D RID: 12605
		private const int BQDEsgxaYLEsOBMrJIcSlEjGnXYgb = 43;

		// Token: 0x0400313E RID: 12606
		private const int MtIFJLNnKLjtNmWYNgtyDnhJBscR = 42;

		// Token: 0x0400313F RID: 12607
		private const int idmBuKBeDjtIjiVbOIhSwxJpdwvB = 48;

		// Token: 0x04003140 RID: 12608
		private const bool jDLnmwDacBHfLdpnGHQtsunPiQZaA = true;

		// Token: 0x04003141 RID: 12609
		private const int crYuZySQoejOchfRVOxIzhbedcAY = 60;

		// Token: 0x04003142 RID: 12610
		private const int EpjcTEDChEkQxuONdbJjsIVtxovX = 60;

		// Token: 0x04003143 RID: 12611
		private const int GIfFlPgrknxXMBaucGHIwaxmJKAab = 3000000;

		// Token: 0x04003144 RID: 12612
		private const float vcWwlIXwgOCkMOJYKsLEBpIFipmFA = 8192f;

		// Token: 0x04003145 RID: 12613
		private const float VgfsWISxSdFIUzrohPbAAiAqnyWc = 0.0010652969f;

		// Token: 0x04003146 RID: 12614
		private const float EXybqKNqddNvtnQSdktnHMALuQRh = 0.06103702f;

		// Token: 0x04003147 RID: 12615
		private const bool FpEDfEdgIDmCbwwPndlHRTUvdpYbA = true;

		// Token: 0x04003148 RID: 12616
		private const bool oraabpCqrZpsTsFQoesMEfSQyijW = true;

		// Token: 0x04003149 RID: 12617
		private const bool jaFYKWlxPWGbyOIpGocbyMnBMFgU = true;

		// Token: 0x0400314A RID: 12618
		private const bool HzNIeQVyVRIUyVdRDnpYxWQNAqxr = true;

		// Token: 0x0400314B RID: 12619
		private const float uRZRMXDyMZIWKcdvVFofTPhYwPFh = 4096f;

		// Token: 0x0400314C RID: 12620
		private const float mCZdPEhtndbOeRIHhZWKMoDbxuwG = 16384f;

		// Token: 0x0400314D RID: 12621
		private const float fpKhdgLdveAqmHyYuHDcKOTLYDCf = 16777216f;

		// Token: 0x0400314E RID: 12622
		private const float spmngediVvOzNKppHtqWfgcRQYCN = 268435460f;

		// Token: 0x0400314F RID: 12623
		private const float NibTYlbFybTnWWIgbvzxVsQFLEVH = 0.01999998f;

		// Token: 0x04003150 RID: 12624
		private const float TFnQqQnvjBwngXwMRlSgQhrJfxgdA = 8192f;

		// Token: 0x04003151 RID: 12625
		private const float WhIDDZoZGxfnITTfQtuPTlJmtPIA = 0.98f;

		// Token: 0x04003152 RID: 12626
		private const float jPBscXqoNualNMyRtfdsPerAvKZw = 45f;

		// Token: 0x04003153 RID: 12627
		private const float xTQClAJPdkgSOHgtxNvQeSniaifjb = 20f;

		// Token: 0x04003154 RID: 12628
		private const DualSenseVibrationMode giSjrXZbKDGGyGBEmIaSPsBHNmIoA = DualSenseVibrationMode.Compatible2;

		// Token: 0x04003155 RID: 12629
		private readonly HIDDeviceDriver.IHIDDevice vopaOdvZXmmvkDiibFtNaurhFYPJA;

		// Token: 0x04003156 RID: 12630
		private readonly HIDDeviceDriver.HIDProperties THAEgAGzxCBAPxcMTVaZOmEyakyv;

		// Token: 0x04003157 RID: 12631
		private readonly bool vtFZlLBbtohFVCltIGDNvqojcghKA;

		// Token: 0x04003158 RID: 12632
		private readonly int CuqXScJiVmEBZTIEnskYOaYqhkFu;

		// Token: 0x04003159 RID: 12633
		private readonly int EvQDPYhgMkFyMVgJdJKpKGTWPwBRA;

		// Token: 0x0400315A RID: 12634
		private readonly bool FKIphGjuKJhiiTnDUecqFBtmlEiL;

		// Token: 0x0400315B RID: 12635
		private readonly byte AzDkSpEmXOsqritrOzXfXneZuUhi;

		// Token: 0x0400315C RID: 12636
		private readonly int bKVFFmKQdrAdAXmJXLCsxOvQiAwA;

		// Token: 0x0400315D RID: 12637
		private readonly int yDshYmiDYDnhtdPDHlKFNzMwysaQA;

		// Token: 0x0400315E RID: 12638
		private readonly int JeGBVcfcEGuzTkqANdMTDaGisypz;

		// Token: 0x0400315F RID: 12639
		private readonly int mjDbQLLyLaPRWwtbPxnlBOcAPIBJ;

		// Token: 0x04003160 RID: 12640
		private readonly NativeBuffer OPDBmlQmdVpALplchXSETGiLhzlh;

		// Token: 0x04003161 RID: 12641
		private readonly NativeBuffer gADMYNxoxxmjAiNDzAwIwAKWGFbeA;

		// Token: 0x04003162 RID: 12642
		private AWHWYMjOaGiEqJCCtAEpfhRJAtYq BBtPFjnSBTpngXHkKDhJKqTEzsTy;

		// Token: 0x04003163 RID: 12643
		private int MonAxeBhmQOjwtuyrMwHEBxThtRAb;

		// Token: 0x04003164 RID: 12644
		private bool MmuCodCdGMDbaGxzdqbNHsZvtqahb;

		// Token: 0x04003165 RID: 12645
		private bool ACIUqfAulQkhDzoUKRfxsGdQHtpc;

		// Token: 0x04003166 RID: 12646
		private double VohmrkeAdkFUoTNBpgqrCqbJOjphb;

		// Token: 0x04003167 RID: 12647
		private int HenoeakTkuuOECUUSRHTxjGxxJtk;

		// Token: 0x04003168 RID: 12648
		private DualSenseDriver.xgALdxMpRZqdEupLJqzwNllssyDm NdlMqgpTLtBGGXWbWkAnxjEbPfVj;

		// Token: 0x04003169 RID: 12649
		private bool kiHZrXsaLSWcMDpIZPjtfrMllPbY;

		// Token: 0x0400316A RID: 12650
		private Quaternion XFeikQhdjUOPaDjKNYRnplQNHMfFb = Quaternion.identity;

		// Token: 0x0400316B RID: 12651
		private DualSenseMicrophoneLightMode BqVkTHNpOpBMRCwfmjRThhRvnOAR;

		// Token: 0x0400316C RID: 12652
		private DualSenseDriver.IGkeSHgtDubstPlTGJHTtQcNWbwm bKRBPwbOlxiiUYnSaTcRqXBUBHTd;

		// Token: 0x0400316D RID: 12653
		private DualSensePlayerLightFlags qGqGTuTEcJdIIREVSJoRDrOZHcwm;

		// Token: 0x0400316E RID: 12654
		private bool eFddSZgSoVhABDOrziRrCiJUSfTCA;

		// Token: 0x0400316F RID: 12655
		private uint qgyNlIUpsYiOLrWErFRvvNMElZTS;

		// Token: 0x04003170 RID: 12656
		private float SpkApLOyVjkvlycvIcvDjCMuAwraA;

		// Token: 0x04003171 RID: 12657
		private double AeQfseKCYUQBZMhTynYzzxtymloNA;

		// Token: 0x04003172 RID: 12658
		private float tsISduhmrovoypWaHlwLCwXlSVBJ;

		// Token: 0x04003173 RID: 12659
		private readonly IDualSenseTriggerEffect[] wFeMfrbsWpCDJbhliEzLeGxwOSEP = new IDualSenseTriggerEffect[2];

		// Token: 0x04003174 RID: 12660
		private readonly byte[] JHfcameSWbragWWScGjeksAvgTYeA = new byte[10];

		// Token: 0x04003175 RID: 12661
		private readonly byte[] JVmsOIlzqiJsrTZvQIEroqmOwMOp = new byte[11];

		// Token: 0x04003176 RID: 12662
		private DualSenseTriggerEffectState[] vuzbqmcfxMFmSdIilLZaXxPGjfaf = new DualSenseTriggerEffectState[2];

		// Token: 0x04003177 RID: 12663
		private DualSenseVibrationMode vIKjFKSLbwuBSScPCCTIVRIojGeEA;

		// Token: 0x04003178 RID: 12664
		private byte ACcmWhSikaHNCGlPXTUGqfWmquOU;

		// Token: 0x04003179 RID: 12665
		private bool wVJDccOKbLwbTAkeyBwOhhBQfjMI;

		// Token: 0x0400317A RID: 12666
		private bool fFZBQnrjCCgnMPMAZXHrkvokUiye;

		// Token: 0x0400317B RID: 12667
		private bool pTzMlECtCDHmvknUlfEmaPhINuGib;

		// Token: 0x0400317C RID: 12668
		private bool cMzLhDMnRMTPcUbhHvgmDketcBFGA;

		// Token: 0x0400317D RID: 12669
		private bool efOWjQrVptmFXycDFUCjTnkKDNbq;

		// Token: 0x0400317E RID: 12670
		private bool HrsbfIizTFjfiUQRDJwRcMmDKPTNA;

		// Token: 0x0400317F RID: 12671
		private bool VxUtaGOXjOqRDGbodAujhxsyeSvk;

		// Token: 0x04003180 RID: 12672
		private bool jmBsJUbcWsmRrylqtURIAzteatfT;

		// Token: 0x04003181 RID: 12673
		private bool ucsrNLFFzQZxXEKfirkRWcXaLKFg;

		// Token: 0x04003182 RID: 12674
		private byte niqqIsssRafDQwDezigYlQtGcGUcA;

		// Token: 0x04003183 RID: 12675
		private byte TzrojzHzfOtClyqLOqeTwxfMDbii;

		// Token: 0x04003184 RID: 12676
		private Quaternion zwLayRExrWMSdfSlMuvqtZJLOamF = Quaternion.identity;

		// Token: 0x04003185 RID: 12677
		private Quaternion VdkMiNITPXMsWDJEohICWqdKJYiJ = Quaternion.identity;

		// Token: 0x04003186 RID: 12678
		private bool RBDBhSHnXWSAnWYYWXhIodKvSXHm;

		// Token: 0x04003187 RID: 12679
		private int IPaBCrhgtYinEZlpekTAECljLYdA;

		// Token: 0x04003188 RID: 12680
		private int[] iKAKWCeTWoIeyuHmHxUuKRfacVtW = new int[2];

		// Token: 0x04003189 RID: 12681
		private int[] VqhFDIFeISTdrgSYnARLbArNkMnP = new int[2];

		// Token: 0x0400318A RID: 12682
		private static uint[] NeFyakBjHeeBnxdxmbwGlzKgWbkk = new uint[]
		{
			3523407757U,
			2768625435U,
			1007455905U,
			1259060791U,
			3580832660U,
			2724731650U,
			996231864U,
			1281784366U,
			3705235391U,
			2883475241U,
			852952723U,
			1171273221U,
			3686048678U,
			2897449776U,
			901431946U,
			1119744540U,
			3484811241U,
			3098726271U,
			565944005U,
			1455205971U,
			3369614320U,
			3219065702U,
			651582172U,
			1372678730U,
			3245242331U,
			3060352845U,
			794826487U,
			1483155041U,
			3322131394U,
			2969862996U,
			671994606U,
			1594548856U,
			3916222277U,
			2657877971U,
			123907689U,
			1885708031U,
			3993045852U,
			2567322570U,
			1010288U,
			1997036262U,
			3887548279U,
			2427484129U,
			163128923U,
			2126386893U,
			3772416878U,
			2547889144U,
			248832578U,
			2043925204U,
			4108050209U,
			2212294583U,
			450215437U,
			1842515611U,
			4088798008U,
			2226203566U,
			498629140U,
			1790921346U,
			4194326291U,
			2366072709U,
			336475711U,
			1661535913U,
			4251816714U,
			2322244508U,
			325317158U,
			1684325040U,
			2766056989U,
			3554254475U,
			1255198513U,
			1037565863U,
			2746444292U,
			3568589458U,
			1304234792U,
			985283518U,
			2852464175U,
			3707901625U,
			1141589763U,
			856455061U,
			2909332022U,
			3664761504U,
			1130791706U,
			878818188U,
			3110715001U,
			3463352047U,
			1466425173U,
			543223747U,
			3187964512U,
			3372436214U,
			1342839628U,
			655174618U,
			3081909835U,
			3233089245U,
			1505515367U,
			784033777U,
			2967466578U,
			3352871620U,
			1590793086U,
			701932520U,
			2679148245U,
			3904355907U,
			1908338681U,
			112844655U,
			2564639436U,
			4024072794U,
			1993550816U,
			30677878U,
			2439710439U,
			3865851505U,
			2137352139U,
			140662621U,
			2517025534U,
			3775001192U,
			2013832146U,
			252678980U,
			2181537457U,
			4110462503U,
			1812594589U,
			453955339U,
			2238339752U,
			4067256894U,
			1801730948U,
			476252946U,
			2363233923U,
			4225443349U,
			1657960367U,
			366298937U,
			2343686810U,
			4239843852U,
			1707062198U,
			314082080U,
			1069182125U,
			1220369467U,
			3518238081U,
			2796764439U,
			953657524U,
			1339070498U,
			3604597144U,
			2715744526U,
			828499103U,
			1181144073U,
			3748627891U,
			2825434405U,
			906764422U,
			1091244048U,
			3624026538U,
			2936369468U,
			571309257U,
			1426738271U,
			3422756325U,
			3137613171U,
			627095760U,
			1382516806U,
			3413039612U,
			3161057642U,
			752284923U,
			1540473965U,
			3268974039U,
			3051332929U,
			733688034U,
			1555824756U,
			3316994510U,
			2998034776U,
			81022053U,
			1943239923U,
			3940166985U,
			2648514015U,
			62490748U,
			1958656234U,
			3988253008U,
			2595281350U,
			168805463U,
			2097738945U,
			3825313147U,
			2466682349U,
			224526414U,
			2053451992U,
			3815530850U,
			2490061300U,
			425942017U,
			1852075159U,
			4151131437U,
			2154433979U,
			504272920U,
			1762240654U,
			4026595636U,
			2265434530U,
			397988915U,
			1623188645U,
			4189500703U,
			2393998729U,
			282398762U,
			1741824188U,
			4275794182U,
			2312913296U,
			1231433021U,
			1046551979U,
			2808630289U,
			3496967303U,
			1309403428U,
			957143474U,
			2684717064U,
			3607279774U,
			1203610895U,
			817534361U,
			2847130659U,
			3736401077U,
			1087398166U,
			936857984U,
			2933784634U,
			3654889644U,
			1422998873U,
			601230799U,
			3135200373U,
			3453512931U,
			1404893504U,
			616286678U,
			3182598252U,
			3400902906U,
			1510651243U,
			755860989U,
			3020215367U,
			3271812305U,
			1567060338U,
			710951396U,
			3010007134U,
			3295551688U,
			1913130485U,
			84884835U,
			2617666777U,
			3942734927U,
			1969605100U,
			40040826U,
			2607524032U,
			3966539862U,
			2094237127U,
			198489425U,
			2464015595U,
			3856323709U,
			2076066270U,
			213479752U,
			2511347954U,
			3803648100U,
			1874795921U,
			414723335U,
			2175892669U,
			4139142187U,
			1758648712U,
			534112542U,
			2262612132U,
			4057696306U,
			1633981859U,
			375629109U,
			2406151311U,
			4167943193U,
			1711886778U,
			286155052U,
			2282172566U,
			4278190080U
		};

		// Token: 0x0400318B RID: 12683
		private const uint nLCjLTYozLbSKjOHEfwQJHpKrme = 3940166985U;

		// Token: 0x020002FD RID: 765
		private enum PCEuntbMBYUDNIBQAvwBrBKqgPhaA
		{
			// Token: 0x0400318D RID: 12685
			X,
			// Token: 0x0400318E RID: 12686
			Y,
			// Token: 0x0400318F RID: 12687
			Z
		}

		// Token: 0x020002FE RID: 766
		private enum FZvaeaGPnJYhsQXnexOZdTgFRNEE
		{
			// Token: 0x04003191 RID: 12689
			None,
			// Token: 0x04003192 RID: 12690
			XZ,
			// Token: 0x04003193 RID: 12691
			Y
		}

		// Token: 0x020002FF RID: 767
		private enum vAWLsUYlbmIWpwiOKEXwPlPvHpdFA : byte
		{
			// Token: 0x04003195 RID: 12693
			Off,
			// Token: 0x04003196 RID: 12694
			Feedback,
			// Token: 0x04003197 RID: 12695
			Weapon,
			// Token: 0x04003198 RID: 12696
			Vibration,
			// Token: 0x04003199 RID: 12697
			SlopeFeedback
		}

		// Token: 0x02000300 RID: 768
		private enum IGkeSHgtDubstPlTGJHTtQcNWbwm : byte
		{
			// Token: 0x0400319B RID: 12699
			High,
			// Token: 0x0400319C RID: 12700
			Medium,
			// Token: 0x0400319D RID: 12701
			Low
		}

		// Token: 0x02000301 RID: 769
		private enum TcXhaMHRvzhzAeUVdSEXdNpdYIaRA : byte
		{
			// Token: 0x0400319F RID: 12703
			Discharging,
			// Token: 0x040031A0 RID: 12704
			Charging,
			// Token: 0x040031A1 RID: 12705
			Full,
			// Token: 0x040031A2 RID: 12706
			TemperatureOutOfRange = 10,
			// Token: 0x040031A3 RID: 12707
			TemperatureError,
			// Token: 0x040031A4 RID: 12708
			ChargingError = 15
		}

		// Token: 0x02000302 RID: 770
		private enum xgALdxMpRZqdEupLJqzwNllssyDm
		{
			// Token: 0x040031A6 RID: 12710
			NotCharging,
			// Token: 0x040031A7 RID: 12711
			Discharging,
			// Token: 0x040031A8 RID: 12712
			Charging,
			// Token: 0x040031A9 RID: 12713
			Full,
			// Token: 0x040031AA RID: 12714
			Unknown
		}

		// Token: 0x02000303 RID: 771
		private enum ufbPHdhYzXnlyMLxozdOYepXctaG : byte
		{
			// Token: 0x040031AC RID: 12716
			None,
			// Token: 0x040031AD RID: 12717
			CompatibleVibrationMode1,
			// Token: 0x040031AE RID: 12718
			HapticsSelect,
			// Token: 0x040031AF RID: 12719
			RightTriggerEffect = 4,
			// Token: 0x040031B0 RID: 12720
			LeftTriggerEffect = 8,
			// Token: 0x040031B1 RID: 12721
			AudioVolume = 16,
			// Token: 0x040031B2 RID: 12722
			ToggleInternalSpeaker = 32,
			// Token: 0x040031B3 RID: 12723
			MicrophoneVolume = 64,
			// Token: 0x040031B4 RID: 12724
			ToggleInternalMicOrExternalSpeaker = 128
		}

		// Token: 0x02000304 RID: 772
		private enum JlBCZZeVYblOqMkBiODOkFQhEatdb : byte
		{
			// Token: 0x040031B6 RID: 12726
			None,
			// Token: 0x040031B7 RID: 12727
			MicrophoneLEDControl,
			// Token: 0x040031B8 RID: 12728
			PowerSaveControl,
			// Token: 0x040031B9 RID: 12729
			LightbarControl = 4,
			// Token: 0x040031BA RID: 12730
			TurnOffLEDs = 8,
			// Token: 0x040031BB RID: 12731
			PlayerIndicatorLEDControl = 16,
			// Token: 0x040031BC RID: 12732
			Unknown1 = 32,
			// Token: 0x040031BD RID: 12733
			ChangeOverallMotorEffectPower = 64,
			// Token: 0x040031BE RID: 12734
			Unknown2 = 128
		}

		// Token: 0x02000305 RID: 773
		private enum eJZWqzSUzdnKnVCXsmZonKbMqCXK : byte
		{
			// Token: 0x040031C0 RID: 12736
			None,
			// Token: 0x040031C1 RID: 12737
			OtherLightBrightnessControl,
			// Token: 0x040031C2 RID: 12738
			LightbarSetupControl,
			// Token: 0x040031C3 RID: 12739
			CompatibleVibrationMode2 = 4
		}

		// Token: 0x02000306 RID: 774
		private struct FRJklUpLETAfgAIfIlZuMsQxmuwV
		{
			// Token: 0x17000396 RID: 918
			// (get) Token: 0x0600167C RID: 5756 RVA: 0x0001CD64 File Offset: 0x0001AF64
			// (set) Token: 0x0600167D RID: 5757 RVA: 0x0001CD70 File Offset: 0x0001AF70
			public byte PbFcXGgtGFFwPIfMiGDhZXBoerzBA
			{
				get
				{
					return this.BdoVQZcQTZabYggDroRnuZQXHnxaA & 15;
				}
				set
				{
					if (value >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					this.BdoVQZcQTZabYggDroRnuZQXHnxaA = (byte)((int)this.zckbzEHJuFcJPESbDwgGTuafUVFIB << 4 | (int)(value & 15));
				}
			}

			// Token: 0x17000397 RID: 919
			// (get) Token: 0x0600167E RID: 5758 RVA: 0x0001CD96 File Offset: 0x0001AF96
			// (set) Token: 0x0600167F RID: 5759 RVA: 0x0001CDA1 File Offset: 0x0001AFA1
			public byte zckbzEHJuFcJPESbDwgGTuafUVFIB
			{
				get
				{
					return (byte)(this.BdoVQZcQTZabYggDroRnuZQXHnxaA >> 4);
				}
				set
				{
					if (value >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					this.BdoVQZcQTZabYggDroRnuZQXHnxaA = (byte)((int)value << 4 | (int)this.PbFcXGgtGFFwPIfMiGDhZXBoerzBA);
				}
			}

			// Token: 0x06001680 RID: 5760 RVA: 0x0001CDC4 File Offset: 0x0001AFC4
			public FRJklUpLETAfgAIfIlZuMsQxmuwV(byte A_1)
			{
				this.BdoVQZcQTZabYggDroRnuZQXHnxaA = A_1;
			}

			// Token: 0x06001681 RID: 5761 RVA: 0x0001CDCD File Offset: 0x0001AFCD
			public FRJklUpLETAfgAIfIlZuMsQxmuwV(byte A_1, byte A_2)
			{
				if (A_1 >= 16 || A_2 >= 16)
				{
					throw new ArithmeticException("Value must be between 0 and 16.");
				}
				this.BdoVQZcQTZabYggDroRnuZQXHnxaA = (byte)((int)A_2 << 4 | (int)A_1);
			}

			// Token: 0x040031C4 RID: 12740
			private const string abuyyFdCyGwLYxzYOzZPsIiKMgtb = "Value must be between 0 and 16.";

			// Token: 0x040031C5 RID: 12741
			public byte BdoVQZcQTZabYggDroRnuZQXHnxaA;
		}

		// Token: 0x02000307 RID: 775
		private static class qGjEqHFoNqZgBUKxhvJpfYDzPysgA
		{
			// Token: 0x02000308 RID: 776
			public enum anKogYwHIaNizosBZiUEmrpFZvyP : byte
			{
				// Token: 0x040031C7 RID: 12743
				Off = 5,
				// Token: 0x040031C8 RID: 12744
				Feedback = 33,
				// Token: 0x040031C9 RID: 12745
				Weapon = 37,
				// Token: 0x040031CA RID: 12746
				Vibration,
				// Token: 0x040031CB RID: 12747
				Bow = 34,
				// Token: 0x040031CC RID: 12748
				Galloping,
				// Token: 0x040031CD RID: 12749
				Machine = 39,
				// Token: 0x040031CE RID: 12750
				Simple_Feedback = 1,
				// Token: 0x040031CF RID: 12751
				Simple_Weapon,
				// Token: 0x040031D0 RID: 12752
				Simple_Vibration = 6,
				// Token: 0x040031D1 RID: 12753
				Limited_Feedback = 17,
				// Token: 0x040031D2 RID: 12754
				Limited_Weapon,
				// Token: 0x040031D3 RID: 12755
				DebugFC = 252,
				// Token: 0x040031D4 RID: 12756
				DebugFD,
				// Token: 0x040031D5 RID: 12757
				DebugFE
			}

			// Token: 0x02000309 RID: 777
			public static class ooLfNLvKdnqymjgxzymORMQOICqI
			{
				// Token: 0x06001682 RID: 5762 RVA: 0x0004F438 File Offset: 0x0004D638
				public static bool axePwaxXADDnteaRIbBMeqxjgPAGb(byte[] A_0, int A_1)
				{
					A_0[A_1] = 5;
					A_0[A_1 + 1] = 0;
					A_0[A_1 + 2] = 0;
					A_0[A_1 + 3] = 0;
					A_0[A_1 + 4] = 0;
					A_0[A_1 + 5] = 0;
					A_0[A_1 + 6] = 0;
					A_0[A_1 + 7] = 0;
					A_0[A_1 + 8] = 0;
					A_0[A_1 + 9] = 0;
					A_0[A_1 + 10] = 0;
					return true;
				}

				// Token: 0x06001683 RID: 5763 RVA: 0x0004F488 File Offset: 0x0004D688
				public static bool GoczaKltbOwJckpRAaXvRoeOtLlf(byte[] A_0, int A_1, byte A_2, byte A_3)
				{
					if (A_2 > 9)
					{
						return false;
					}
					if (A_3 > 8)
					{
						return false;
					}
					if (A_3 > 0)
					{
						byte b = A_3 - 1 & 7;
						uint num = 0U;
						ushort num2 = 0;
						for (int i = (int)A_2; i < 10; i++)
						{
							num |= (uint)((uint)b << 3 * i);
							num2 |= (ushort)(1 << i);
						}
						A_0[A_1] = 33;
						A_0[A_1 + 1] = (byte)(num2 & 255);
						A_0[A_1 + 2] = (byte)(num2 >> 8 & 255);
						A_0[A_1 + 3] = (byte)(num & 255U);
						A_0[A_1 + 4] = (byte)(num >> 8 & 255U);
						A_0[A_1 + 5] = (byte)(num >> 16 & 255U);
						A_0[A_1 + 6] = (byte)(num >> 24 & 255U);
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x06001684 RID: 5764 RVA: 0x0004F558 File Offset: 0x0004D758
				public static bool OCNqhvVrcgdULvBRgULVnYpivuPg(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4)
				{
					if (A_2 > 7 || A_2 < 2)
					{
						return false;
					}
					if (A_3 > 8)
					{
						return false;
					}
					if (A_3 <= A_2)
					{
						return false;
					}
					if (A_4 > 8)
					{
						return false;
					}
					if (A_4 > 0)
					{
						ushort num = (ushort)(1 << (int)A_2 | 1 << (int)A_3);
						A_0[A_1] = 37;
						A_0[A_1 + 1] = (byte)(num & 255);
						A_0[A_1 + 2] = (byte)(num >> 8 & 255);
						A_0[A_1 + 3] = A_4 - 1;
						A_0[A_1 + 4] = 0;
						A_0[A_1 + 5] = 0;
						A_0[A_1 + 6] = 0;
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x06001685 RID: 5765 RVA: 0x0004F5F8 File Offset: 0x0004D7F8
				public static bool cIcTnQVSBlSbYAGFmIoRtCbJJAdW(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4)
				{
					if (A_2 > 9)
					{
						return false;
					}
					if (A_3 > 8)
					{
						return false;
					}
					if (A_3 > 0 && A_4 > 0)
					{
						byte b = A_3 - 1 & 7;
						uint num = 0U;
						ushort num2 = 0;
						for (int i = (int)A_2; i < 10; i++)
						{
							num |= (uint)((uint)b << 3 * i);
							num2 |= (ushort)(1 << i);
						}
						A_0[A_1] = 38;
						A_0[A_1 + 1] = (byte)(num2 & 255);
						A_0[A_1 + 2] = (byte)(num2 >> 8 & 255);
						A_0[A_1 + 3] = (byte)(num & 255U);
						A_0[A_1 + 4] = (byte)(num >> 8 & 255U);
						A_0[A_1 + 5] = (byte)(num >> 16 & 255U);
						A_0[A_1 + 6] = (byte)(num >> 24 & 255U);
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = A_4;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x06001686 RID: 5766 RVA: 0x0004F6D0 File Offset: 0x0004D8D0
				public static bool YRJEyNBWJMCCstXQjuCXItBAQQWgA(byte[] A_0, int A_1, byte[] A_2)
				{
					if (A_2.Length != 10)
					{
						return false;
					}
					if (A_2.Any(new Func<byte, bool>(DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.cZafvedMTiseFwIBcpNVUkrbqXKB.<>9.pAJgXeUmLGamqzCYCaZgBTWVbaKgb)))
					{
						uint num = 0U;
						ushort num2 = 0;
						for (int i = 0; i < 10; i++)
						{
							if (A_2[i] > 0)
							{
								byte b = A_2[i] - 1 & 7;
								num |= (uint)((uint)b << 3 * i);
								num2 |= (ushort)(1 << i);
							}
						}
						A_0[A_1] = 33;
						A_0[A_1 + 1] = (byte)(num2 & 255);
						A_0[A_1 + 2] = (byte)(num2 >> 8 & 255);
						A_0[A_1 + 3] = (byte)(num & 255U);
						A_0[A_1 + 4] = (byte)(num >> 8 & 255U);
						A_0[A_1 + 5] = (byte)(num >> 16 & 255U);
						A_0[A_1 + 6] = (byte)(num >> 24 & 255U);
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x06001687 RID: 5767 RVA: 0x0004F7C8 File Offset: 0x0004D9C8
				public static bool EuzHGDGpdryDDJhWNfgZmVBBeHlaA(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4, byte A_5)
				{
					if (A_2 > 8 || A_2 < 0)
					{
						return false;
					}
					if (A_3 > 9)
					{
						return false;
					}
					if (A_3 <= A_2)
					{
						return false;
					}
					if (A_4 > 8)
					{
						return false;
					}
					if (A_4 < 1)
					{
						return false;
					}
					if (A_5 > 8)
					{
						return false;
					}
					if (A_5 < 1)
					{
						return false;
					}
					byte[] array = new byte[10];
					float num = 1f * (float)(A_5 - A_4) / (float)(A_3 - A_2);
					for (int i = (int)A_2; i < 10; i++)
					{
						if (i <= (int)A_3)
						{
							array[i] = (byte)Math.Round((double)((float)A_4 + num * (float)(i - (int)A_2)));
						}
						else
						{
							array[i] = A_5;
						}
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.YRJEyNBWJMCCstXQjuCXItBAQQWgA(A_0, A_1, array);
				}

				// Token: 0x06001688 RID: 5768 RVA: 0x0004F858 File Offset: 0x0004DA58
				public static bool cHcwwXippnCgIodOhdsjBLXjIrNp(byte[] A_0, int A_1, byte A_2, byte[] A_3)
				{
					if (A_3.Length != 10)
					{
						return false;
					}
					if (A_2 > 0)
					{
						if (A_3.Any(new Func<byte, bool>(DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.cZafvedMTiseFwIBcpNVUkrbqXKB.<>9.clnJhPIGNlFIatvULbIyybIRkWkc)))
						{
							uint num = 0U;
							ushort num2 = 0;
							for (int i = 0; i < 10; i++)
							{
								if (A_3[i] > 0)
								{
									byte b = A_3[i] - 1 & 7;
									num |= (uint)((uint)b << 3 * i);
									num2 |= (ushort)(1 << i);
								}
							}
							A_0[A_1] = 38;
							A_0[A_1 + 1] = (byte)(num2 & 255);
							A_0[A_1 + 2] = (byte)(num2 >> 8 & 255);
							A_0[A_1 + 3] = (byte)(num & 255U);
							A_0[A_1 + 4] = (byte)(num >> 8 & 255U);
							A_0[A_1 + 5] = (byte)(num >> 16 & 255U);
							A_0[A_1 + 6] = (byte)(num >> 24 & 255U);
							A_0[A_1 + 7] = 0;
							A_0[A_1 + 8] = 0;
							A_0[A_1 + 9] = A_2;
							A_0[A_1 + 10] = 0;
							return true;
						}
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x06001689 RID: 5769 RVA: 0x0004F958 File Offset: 0x0004DB58
				public static bool UMaAzYgdbTaaXdLtHfnSOVByugkOc(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4, byte A_5)
				{
					if (A_2 > 8)
					{
						return false;
					}
					if (A_3 > 8)
					{
						return false;
					}
					if (A_2 >= A_3)
					{
						return false;
					}
					if (A_4 > 8)
					{
						return false;
					}
					if (A_5 > 8)
					{
						return false;
					}
					if (A_3 > 0 && A_4 > 0 && A_5 > 0)
					{
						ushort num = (ushort)(1 << (int)A_2 | 1 << (int)A_3);
						uint num2 = (uint)((int)(A_4 - 1 & 7) | (int)(A_5 - 1 & 7) << 3);
						A_0[A_1] = 34;
						A_0[A_1 + 1] = (byte)(num & 255);
						A_0[A_1 + 2] = (byte)(num >> 8 & 255);
						A_0[A_1 + 3] = (byte)(num2 & 255U);
						A_0[A_1 + 4] = (byte)(num2 >> 8 & 255U);
						A_0[A_1 + 5] = 0;
						A_0[A_1 + 6] = 0;
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x0600168A RID: 5770 RVA: 0x0004FA28 File Offset: 0x0004DC28
				public static bool szRoYvOJyMQIZMLKXDlFiIOczbfLA(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4, byte A_5, byte A_6)
				{
					if (A_2 > 8)
					{
						return false;
					}
					if (A_3 > 9)
					{
						return false;
					}
					if (A_2 >= A_3)
					{
						return false;
					}
					if (A_5 > 7)
					{
						return false;
					}
					if (A_4 > 6)
					{
						return false;
					}
					if (A_4 >= A_5)
					{
						return false;
					}
					if (A_6 > 0)
					{
						ushort num = (ushort)(1 << (int)A_2 | 1 << (int)A_3);
						uint num2 = (uint)((int)(A_5 & 7) | (int)(A_4 & 7) << 3);
						A_0[A_1] = 35;
						A_0[A_1 + 1] = (byte)(num & 255);
						A_0[A_1 + 2] = (byte)(num >> 8 & 255);
						A_0[A_1 + 3] = (byte)(num2 & 255U);
						A_0[A_1 + 4] = A_6;
						A_0[A_1 + 5] = 0;
						A_0[A_1 + 6] = 0;
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x0600168B RID: 5771 RVA: 0x0004FAE4 File Offset: 0x0004DCE4
				public static bool iJiqSanKuQQsfjMOydkPrNvHPVVe(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4, byte A_5, byte A_6, byte A_7)
				{
					if (A_2 > 8)
					{
						return false;
					}
					if (A_3 > 9)
					{
						return false;
					}
					if (A_3 <= A_2)
					{
						return false;
					}
					if (A_4 > 7)
					{
						return false;
					}
					if (A_5 > 7)
					{
						return false;
					}
					if (A_6 > 0)
					{
						ushort num = (ushort)(1 << (int)A_2 | 1 << (int)A_3);
						uint num2 = (uint)((int)(A_4 & 7) | (int)(A_5 & 7) << 3);
						A_0[A_1] = 39;
						A_0[A_1 + 1] = (byte)(num & 255);
						A_0[A_1 + 2] = (byte)(num >> 8 & 255);
						A_0[A_1 + 3] = (byte)(num2 & 255U);
						A_0[A_1 + 4] = A_6;
						A_0[A_1 + 5] = A_7;
						A_0[A_1 + 6] = 0;
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x0600168C RID: 5772 RVA: 0x0004FB98 File Offset: 0x0004DD98
				public static bool hQkzJyHTrVMPGxZFHHjyJmxjEjQdA(byte[] A_0, int A_1, byte A_2, byte A_3)
				{
					A_0[A_1] = 1;
					A_0[A_1 + 1] = A_2;
					A_0[A_1 + 2] = A_3;
					A_0[A_1 + 3] = 0;
					A_0[A_1 + 4] = 0;
					A_0[A_1 + 5] = 0;
					A_0[A_1 + 6] = 0;
					A_0[A_1 + 7] = 0;
					A_0[A_1 + 8] = 0;
					A_0[A_1 + 9] = 0;
					A_0[A_1 + 10] = 0;
					return true;
				}

				// Token: 0x0600168D RID: 5773 RVA: 0x0004FBE8 File Offset: 0x0004DDE8
				public static bool dsCaAKbWaapYCGahctyyUcNuRIUs(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4)
				{
					A_0[A_1] = 2;
					A_0[A_1 + 1] = A_2;
					A_0[A_1 + 2] = A_3;
					A_0[A_1 + 3] = A_4;
					A_0[A_1 + 4] = 0;
					A_0[A_1 + 5] = 0;
					A_0[A_1 + 6] = 0;
					A_0[A_1 + 7] = 0;
					A_0[A_1 + 8] = 0;
					A_0[A_1 + 9] = 0;
					A_0[A_1 + 10] = 0;
					return true;
				}

				// Token: 0x0600168E RID: 5774 RVA: 0x0004FC3C File Offset: 0x0004DE3C
				public static bool dxwXXGvFkLPxdYihYmtlRGggcJrM(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4)
				{
					if (A_4 > 0 && A_3 > 0)
					{
						A_0[A_1] = 6;
						A_0[A_1 + 1] = A_4;
						A_0[A_1 + 2] = A_3;
						A_0[A_1 + 3] = A_2;
						A_0[A_1 + 4] = 0;
						A_0[A_1 + 5] = 0;
						A_0[A_1 + 6] = 0;
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x0600168F RID: 5775 RVA: 0x0004FCA0 File Offset: 0x0004DEA0
				public static bool tMskaOtVVmlqSXoYymiisBHDUmQl(byte[] A_0, int A_1, byte A_2, byte A_3)
				{
					if (A_3 > 10)
					{
						return false;
					}
					if (A_3 > 0)
					{
						A_0[A_1] = 17;
						A_0[A_1 + 1] = A_2;
						A_0[A_1 + 2] = A_3;
						A_0[A_1 + 3] = 0;
						A_0[A_1 + 4] = 0;
						A_0[A_1 + 5] = 0;
						A_0[A_1 + 6] = 0;
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x06001690 RID: 5776 RVA: 0x0004FD04 File Offset: 0x0004DF04
				public static bool rxScTzwqfgGnllkwvGkEJESVSdbvA(byte[] A_0, int A_1, byte A_2, byte A_3, byte A_4)
				{
					if (A_2 < 16)
					{
						return false;
					}
					if (A_3 < A_2 || A_2 + 100 < A_3)
					{
						return false;
					}
					if (A_4 > 10)
					{
						return false;
					}
					if (A_4 > 0)
					{
						A_0[A_1] = 18;
						A_0[A_1 + 1] = A_2;
						A_0[A_1 + 2] = A_3;
						A_0[A_1 + 3] = A_4;
						A_0[A_1 + 4] = 0;
						A_0[A_1 + 5] = 0;
						A_0[A_1 + 6] = 0;
						A_0[A_1 + 7] = 0;
						A_0[A_1 + 8] = 0;
						A_0[A_1 + 9] = 0;
						A_0[A_1 + 10] = 0;
						return true;
					}
					return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
				}

				// Token: 0x0200030A RID: 778
				public static class MQGJGllggRvPuLkzrHZQizikrllI
				{
					// Token: 0x06001691 RID: 5777 RVA: 0x0001CDF0 File Offset: 0x0001AFF0
					public static bool GVwRXzCesXUvDacdNAMFLjQvFpAK(byte[] A_0, int A_1)
					{
						return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.axePwaxXADDnteaRIbBMeqxjgPAGb(A_0, A_1);
					}

					// Token: 0x06001692 RID: 5778 RVA: 0x0001CDF9 File Offset: 0x0001AFF9
					public static bool GbKakjkBshuEEnoIRqplQJZbncjxA(byte[] A_0, int A_1, float A_2, float A_3)
					{
						A_2 = (float)Math.Round((double)(A_2 * 9f));
						A_3 = (float)Math.Round((double)(A_3 * 8f));
						return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.GoczaKltbOwJckpRAaXvRoeOtLlf(A_0, A_1, (byte)A_2, (byte)A_3);
					}

					// Token: 0x06001693 RID: 5779 RVA: 0x0004FD80 File Offset: 0x0004DF80
					public static bool FXXVGQOuylRpxFqlNppVbbrfaVlgA(byte[] A_0, int A_1, float A_2, float A_3, float A_4)
					{
						A_2 = (float)Math.Round((double)(A_2 * 9f));
						A_3 = (float)Math.Round((double)(A_3 * 9f));
						A_4 = (float)Math.Round((double)(A_4 * 8f));
						return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.OCNqhvVrcgdULvBRgULVnYpivuPg(A_0, A_1, (byte)A_2, (byte)A_3, (byte)A_4);
					}

					// Token: 0x06001694 RID: 5780 RVA: 0x0004FDCC File Offset: 0x0004DFCC
					public static bool FcbiVRXkVjAGcozbULWYEqzFAcnp(byte[] A_0, int A_1, float A_2, float A_3, float A_4)
					{
						A_2 = (float)Math.Round((double)(A_2 * 9f));
						A_3 = (float)Math.Round((double)(A_3 * 8f));
						A_4 = (float)Math.Round((double)(A_4 * 255f));
						return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.cIcTnQVSBlSbYAGFmIoRtCbJJAdW(A_0, A_1, (byte)A_2, (byte)A_3, (byte)A_4);
					}

					// Token: 0x06001695 RID: 5781 RVA: 0x0004FE18 File Offset: 0x0004E018
					public static bool VWHhYawoeZLHmmLLnaqzrjgOQlFK(byte[] A_0, int A_1, float[] A_2)
					{
						if (A_2.Length != 10)
						{
							return false;
						}
						byte[] array = new byte[10];
						for (int i = 0; i < 10; i++)
						{
							array[i] = (byte)Math.Round((double)(A_2[i] * 8f));
						}
						return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.YRJEyNBWJMCCstXQjuCXItBAQQWgA(A_0, A_1, array);
					}

					// Token: 0x06001696 RID: 5782 RVA: 0x0004FE60 File Offset: 0x0004E060
					public static bool LLIrbnOuXIINiAnNSqqStZGOGdex(byte[] A_0, int A_1, float A_2, float A_3, float A_4, float A_5)
					{
						A_2 = (float)Math.Round((double)(A_2 * 9f));
						A_3 = (float)Math.Round((double)(A_3 * 9f));
						A_4 = (float)Math.Round((double)(A_4 * 8f));
						A_5 = (float)Math.Round((double)(A_5 * 8f));
						return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.EuzHGDGpdryDDJhWNfgZmVBBeHlaA(A_0, A_1, (byte)A_2, (byte)A_3, (byte)A_4, (byte)A_5);
					}

					// Token: 0x06001697 RID: 5783 RVA: 0x0004FEC0 File Offset: 0x0004E0C0
					public static bool BxlEKRIHgBsArJtSiKpgtevTvFDR(byte[] A_0, int A_1, float[] A_2, float A_3)
					{
						if (A_2.Length != 10)
						{
							return false;
						}
						A_3 = (float)Math.Round((double)(A_3 * 255f));
						byte[] array = new byte[10];
						for (int i = 0; i < 10; i++)
						{
							array[i] = (byte)Math.Round((double)(A_2[i] * 8f));
						}
						return DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.cHcwwXippnCgIodOhdsjBLXjIrNp(A_0, A_1, (byte)A_3, array);
					}
				}

				// Token: 0x0200030B RID: 779
				[CompilerGenerated]
				[Serializable]
				private sealed class cZafvedMTiseFwIBcpNVUkrbqXKB
				{
					// Token: 0x0600169A RID: 5786 RVA: 0x0001CE32 File Offset: 0x0001B032
					internal bool pAJgXeUmLGamqzCYCaZgBTWVbaKgb(byte A_1)
					{
						return A_1 > 0;
					}

					// Token: 0x0600169B RID: 5787 RVA: 0x0001CE32 File Offset: 0x0001B032
					internal bool clnJhPIGNlFIatvULbIyybIRkWkc(byte A_1)
					{
						return A_1 > 0;
					}

					// Token: 0x040031D6 RID: 12758
					public static readonly DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.cZafvedMTiseFwIBcpNVUkrbqXKB <>9 = new DualSenseDriver.qGjEqHFoNqZgBUKxhvJpfYDzPysgA.ooLfNLvKdnqymjgxzymORMQOICqI.cZafvedMTiseFwIBcpNVUkrbqXKB();

					// Token: 0x040031D7 RID: 12759
					public static Func<byte, bool> <>9__4_0;

					// Token: 0x040031D8 RID: 12760
					public static Func<byte, bool> <>9__6_0;
				}
			}
		}
	}
}
