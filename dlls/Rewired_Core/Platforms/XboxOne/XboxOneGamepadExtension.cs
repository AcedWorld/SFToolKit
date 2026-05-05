using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	// Token: 0x02000215 RID: 533
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x0600192B RID: 6443 RVA: 0x00014B29 File Offset: 0x00012D29
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x0600192C RID: 6444 RVA: 0x00070794 File Offset: 0x0006E994
		public int xboxOneUserId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return -1;
				}
				if (this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.vBMcKgXTrVyCwmeRnUrBXQMqhZqi == null || this.joystick == null)
				{
					return -1;
				}
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.vBMcKgXTrVyCwmeRnUrBXQMqhZqi.GetXboxOneUserIdFromUnityJoystick(this.joystick.unityId);
			}
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x0600192D RID: 6445 RVA: 0x000707F0 File Offset: 0x0006E9F0
		public ulong xboxOneJoystickId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0UL;
				}
				if (this.joystick == null)
				{
					return 0UL;
				}
				long? systemId = this.joystick.systemId;
				if (systemId == null)
				{
					return 0UL;
				}
				return (ulong)systemId.Value;
			}
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x00070844 File Offset: 0x0006EA44
		internal XboxOneGamepadExtension(bool A_1, IXboxOneInputSource A_2) : base(new XboxOneGamepadExtension.FgGUEVbLTLjmqoPwnkzWQUWahmsl(A_1, A_2, default(eSdkeiNbMcydmNPVeUBLWdxGyQBY)))
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			this.JlmAqIbfoTshSTdtraeTbZiHFdrHb = new TimerAbs[4];
			ArrayTools.Populate<TimerAbs>(this.JlmAqIbfoTshSTdtraeTbZiHFdrHb, 0, this.JlmAqIbfoTshSTdtraeTbZiHFdrHb.Length);
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x00014B31 File Offset: 0x00012D31
		private XboxOneGamepadExtension(XboxOneGamepadExtension A_1) : base(A_1)
		{
			this.JlmAqIbfoTshSTdtraeTbZiHFdrHb = new TimerAbs[4];
			ArrayTools.Populate<TimerAbs>(this.JlmAqIbfoTshSTdtraeTbZiHFdrHb, 0, this.JlmAqIbfoTshSTdtraeTbZiHFdrHb.Length);
		}

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x06001930 RID: 6448 RVA: 0x00014B5A File Offset: 0x00012D5A
		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return 4;
			}
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x00014B78 File Offset: 0x00012D78
		public void SetVibration(int motorIndex, float motorLevel)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, false);
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x00014B88 File Offset: 0x00012D88
		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			this.SetVibration(motorIndex, motorLevel, duration, false);
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x00014B94 File Offset: 0x00012D94
		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x00070898 File Offset: 0x0006EA98
		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (motorIndex < 0 || motorIndex >= 4)
			{
				return;
			}
			XboxOneGamepadMotorType motor;
			switch (motorIndex)
			{
			case 0:
				motor = XboxOneGamepadMotorType.LeftMotor;
				break;
			case 1:
				motor = XboxOneGamepadMotorType.RightMotor;
				break;
			case 2:
				motor = XboxOneGamepadMotorType.LeftTriggerMotor;
				break;
			case 3:
				motor = XboxOneGamepadMotorType.RightTriggerMotor;
				break;
			default:
				throw new NotImplementedException();
			}
			this.SetVibration(motor, motorLevel, duration, stopOtherMotors);
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x00070904 File Offset: 0x0006EB04
		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0f;
			}
			if (!this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.aNZEZdVhpBcWZrUNWXcRuwGjrFGv)
			{
				return 0f;
			}
			switch (motorIndex)
			{
			case 0:
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.gdBPKlEdhBDpGEcYiIRVAgICEphbB;
			case 1:
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.rsRYIFctnTdEVaccRwfIxKCqKsnaA;
			case 2:
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.hRlKGOKRGYLWBqITgkPCbICHbOgkA;
			case 3:
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.VTcIEopRaueHhlLCffWgHzzBscenA;
			default:
				return 0f;
			}
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x000709A4 File Offset: 0x0006EBA4
		public float GetVibration(XboxOneGamepadMotorType motor)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0f;
			}
			if (!this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.aNZEZdVhpBcWZrUNWXcRuwGjrFGv)
			{
				return 0f;
			}
			switch (motor)
			{
			case XboxOneGamepadMotorType.LeftMotor:
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.gdBPKlEdhBDpGEcYiIRVAgICEphbB;
			case XboxOneGamepadMotorType.RightMotor:
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.rsRYIFctnTdEVaccRwfIxKCqKsnaA;
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.hRlKGOKRGYLWBqITgkPCbICHbOgkA;
			case XboxOneGamepadMotorType.RightTriggerMotor:
				return this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.VTcIEopRaueHhlLCffWgHzzBscenA;
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x00070A44 File Offset: 0x0006EC44
		public void StopVibration()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.aNZEZdVhpBcWZrUNWXcRuwGjrFGv)
			{
				return;
			}
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.PcWrfDkLwlrRMmoSPuhUUCgsCsst();
			for (int i = 0; i < 4; i++)
			{
				this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[i].Clear();
			}
			this.MDCHwMZsZaAnfcEADpxdJXqZtWzq();
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x00014BA4 File Offset: 0x00012DA4
		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel)
		{
			this.SetVibration(motor, motorLevel, 0f, false);
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x00014BB4 File Offset: 0x00012DB4
		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration)
		{
			this.SetVibration(motor, motorLevel, duration, false);
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x00014BC0 File Offset: 0x00012DC0
		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x00070AA8 File Offset: 0x0006ECA8
		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.aNZEZdVhpBcWZrUNWXcRuwGjrFGv)
			{
				return;
			}
			if (stopOtherMotors)
			{
				this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.PcWrfDkLwlrRMmoSPuhUUCgsCsst();
				for (int i = 0; i < 4; i++)
				{
					this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[i].Clear();
				}
			}
			motorLevel = MathTools.Clamp01(motorLevel);
			switch (motor)
			{
			case XboxOneGamepadMotorType.LeftMotor:
				this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.gdBPKlEdhBDpGEcYiIRVAgICEphbB = motorLevel;
				break;
			case XboxOneGamepadMotorType.RightMotor:
				this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.rsRYIFctnTdEVaccRwfIxKCqKsnaA = motorLevel;
				break;
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.hRlKGOKRGYLWBqITgkPCbICHbOgkA = motorLevel;
				break;
			case XboxOneGamepadMotorType.RightTriggerMotor:
				this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.VTcIEopRaueHhlLCffWgHzzBscenA = motorLevel;
				break;
			default:
				throw new NotImplementedException();
			}
			this.dWJePVoiaLzrGrCBaJKCzjMsWEgW(motor, motorLevel, duration);
			this.MDCHwMZsZaAnfcEADpxdJXqZtWzq();
		}

		// Token: 0x0600193C RID: 6460 RVA: 0x00014BD0 File Offset: 0x00012DD0
		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			this.SetVibration(leftMotorLevel, rightMotorLevel, false);
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x00070B8C File Offset: 0x0006ED8C
		public void SetVibration(float leftMotorLevel, float rightMotorLevel, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.aNZEZdVhpBcWZrUNWXcRuwGjrFGv)
			{
				return;
			}
			if (stopOtherMotors)
			{
				this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.PcWrfDkLwlrRMmoSPuhUUCgsCsst();
				for (int i = 0; i < 4; i++)
				{
					this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[i].Clear();
				}
			}
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.ZcyaRTYWeBIzaxumVJuTfiDpvGfw = this.xboxOneJoystickId;
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.gdBPKlEdhBDpGEcYiIRVAgICEphbB = MathTools.Clamp01(leftMotorLevel);
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.rsRYIFctnTdEVaccRwfIxKCqKsnaA = MathTools.Clamp01(rightMotorLevel);
			this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[0].Clear();
			this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[1].Clear();
			this.MDCHwMZsZaAnfcEADpxdJXqZtWzq();
		}

		// Token: 0x0600193E RID: 6462 RVA: 0x00070C50 File Offset: 0x0006EE50
		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.aNZEZdVhpBcWZrUNWXcRuwGjrFGv)
			{
				return;
			}
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.ZcyaRTYWeBIzaxumVJuTfiDpvGfw = this.xboxOneJoystickId;
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.gdBPKlEdhBDpGEcYiIRVAgICEphbB = MathTools.Clamp01(leftMotorLevel);
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.rsRYIFctnTdEVaccRwfIxKCqKsnaA = MathTools.Clamp01(rightMotorLevel);
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.hRlKGOKRGYLWBqITgkPCbICHbOgkA = MathTools.Clamp01(leftTriggerLevel);
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx.VTcIEopRaueHhlLCffWgHzzBscenA = MathTools.Clamp01(rightTriggerLevel);
			for (int i = 0; i < 4; i++)
			{
				this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[i].Clear();
			}
			this.MDCHwMZsZaAnfcEADpxdJXqZtWzq();
		}

		// Token: 0x0600193F RID: 6463 RVA: 0x00070D14 File Offset: 0x0006EF14
		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!base.isJoystickConnected || !this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.aNZEZdVhpBcWZrUNWXcRuwGjrFGv)
			{
				return;
			}
			this.dWJePVoiaLzrGrCBaJKCzjMsWEgW(motor, 0f, 0f);
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.vBMcKgXTrVyCwmeRnUrBXQMqhZqi.PulseVibrateMotor(this.xboxOneJoystickId, motor, startLevel, endLevel, duration);
		}

		// Token: 0x06001940 RID: 6464 RVA: 0x00014BDB File Offset: 0x00012DDB
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			this.KArTDCAIMbBXJPYCnAbptKWumBRJ();
		}

		// Token: 0x06001941 RID: 6465 RVA: 0x00014BE3 File Offset: 0x00012DE3
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu = (source as XboxOneGamepadExtension.FgGUEVbLTLjmqoPwnkzWQUWahmsl);
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x00014BF1 File Offset: 0x00012DF1
		internal override Controller.Extension Clone()
		{
			return new XboxOneGamepadExtension(this);
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x00070D80 File Offset: 0x0006EF80
		private void KArTDCAIMbBXJPYCnAbptKWumBRJ()
		{
			if (!this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.aNZEZdVhpBcWZrUNWXcRuwGjrFGv)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[i].Update())
				{
					this.SetVibration(i, 0f, false);
				}
			}
		}

		// Token: 0x06001944 RID: 6468 RVA: 0x00070DC4 File Offset: 0x0006EFC4
		private void dWJePVoiaLzrGrCBaJKCzjMsWEgW(XboxOneGamepadMotorType A_1, float A_2, float A_3)
		{
			int num;
			switch (A_1)
			{
			case XboxOneGamepadMotorType.LeftMotor:
				num = 0;
				break;
			case XboxOneGamepadMotorType.RightMotor:
				num = 1;
				break;
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				num = 2;
				break;
			case XboxOneGamepadMotorType.RightTriggerMotor:
				num = 3;
				break;
			default:
				throw new NotImplementedException();
			}
			if (A_2 <= 0f || A_3 <= 0f)
			{
				this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[num].Clear();
				return;
			}
			this.JlmAqIbfoTshSTdtraeTbZiHFdrHb[num].Start((double)A_3);
		}

		// Token: 0x06001945 RID: 6469 RVA: 0x00014BF9 File Offset: 0x00012DF9
		private void MDCHwMZsZaAnfcEADpxdJXqZtWzq()
		{
			if (!base.isJoystickConnected)
			{
				return;
			}
			this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.vBMcKgXTrVyCwmeRnUrBXQMqhZqi.SetXboxOneVibration(this.xboxOneJoystickId, this.gGRDYIKQNrDEKOmzAqTvCPfwoWHu.PImKhNsmrcrXPGgEbJXNaVEjcAGx);
		}

		// Token: 0x04000E52 RID: 3666
		private XboxOneGamepadExtension.FgGUEVbLTLjmqoPwnkzWQUWahmsl gGRDYIKQNrDEKOmzAqTvCPfwoWHu;

		// Token: 0x04000E53 RID: 3667
		private TimerAbs[] JlmAqIbfoTshSTdtraeTbZiHFdrHb;

		// Token: 0x02000216 RID: 534
		private class FgGUEVbLTLjmqoPwnkzWQUWahmsl : IControllerExtensionSource
		{
			// Token: 0x06001946 RID: 6470 RVA: 0x00014C26 File Offset: 0x00012E26
			public FgGUEVbLTLjmqoPwnkzWQUWahmsl(bool A_1, IXboxOneInputSource A_2, eSdkeiNbMcydmNPVeUBLWdxGyQBY A_3)
			{
				this.PImKhNsmrcrXPGgEbJXNaVEjcAGx = A_3;
				this.vBMcKgXTrVyCwmeRnUrBXQMqhZqi = A_2;
				this.aNZEZdVhpBcWZrUNWXcRuwGjrFGv = A_1;
			}

			// Token: 0x04000E54 RID: 3668
			public const int zRqvAQRAnptzObgcMHaHSpdlpxqm = 4;

			// Token: 0x04000E55 RID: 3669
			public eSdkeiNbMcydmNPVeUBLWdxGyQBY PImKhNsmrcrXPGgEbJXNaVEjcAGx;

			// Token: 0x04000E56 RID: 3670
			public readonly IXboxOneInputSource vBMcKgXTrVyCwmeRnUrBXQMqhZqi;

			// Token: 0x04000E57 RID: 3671
			public readonly bool aNZEZdVhpBcWZrUNWXcRuwGjrFGv;
		}
	}
}
