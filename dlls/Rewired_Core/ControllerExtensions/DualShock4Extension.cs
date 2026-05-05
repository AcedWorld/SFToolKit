using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003B6 RID: 950
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DualShock4Extension : Controller.Extension, IControllerVibrator, IDualShock4Extension, IHIDControllerExtension
	{
		// Token: 0x170008EF RID: 2287
		// (get) Token: 0x0600261D RID: 9757 RVA: 0x00014B29 File Offset: 0x00012D29
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x0600261E RID: 9758 RVA: 0x000939DC File Offset: 0x00091BDC
		internal DualShock4Extension(IDriver_DualShock4 A_1) : base(new DualShock4Extension.TOpgIFeaOaElKJPdseQRJfIJosQYA(A_1, A_1.VibrationMotorCount > 0, A_1.VibrationMotorCount))
		{
			this.PHpLEfUQxYNYpxIxQRUkukswGHSs = new TimerAbs[A_1.VibrationMotorCount];
			ArrayTools.Populate<TimerAbs>(this.PHpLEfUQxYNYpxIxQRUkukswGHSs, 0, this.PHpLEfUQxYNYpxIxQRUkukswGHSs.Length);
		}

		// Token: 0x0600261F RID: 9759 RVA: 0x00093A2C File Offset: 0x00091C2C
		private DualShock4Extension(DualShock4Extension A_1) : base(A_1)
		{
			try
			{
				this.PHpLEfUQxYNYpxIxQRUkukswGHSs = new TimerAbs[A_1.vibrationMotorCount];
			}
			catch
			{
				this.PHpLEfUQxYNYpxIxQRUkukswGHSs = new TimerAbs[0];
			}
			ArrayTools.Populate<TimerAbs>(this.PHpLEfUQxYNYpxIxQRUkukswGHSs, 0, this.PHpLEfUQxYNYpxIxQRUkukswGHSs.Length);
		}

		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x06002620 RID: 9760 RVA: 0x0001BFA1 File Offset: 0x0001A1A1
		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
				{
					return 0;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.wsLXqPGUEJhFpCxTWGFODOAcbGhM;
			}
		}

		// Token: 0x06002621 RID: 9761 RVA: 0x0001BFD3 File Offset: 0x0001A1D3
		public void SetVibration(int motorIndex, float motorLevel)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, false);
		}

		// Token: 0x06002622 RID: 9762 RVA: 0x0001BFE3 File Offset: 0x0001A1E3
		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			this.SetVibration(motorIndex, motorLevel, duration, false);
		}

		// Token: 0x06002623 RID: 9763 RVA: 0x0001BFEF File Offset: 0x0001A1EF
		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		// Token: 0x06002624 RID: 9764 RVA: 0x00093A88 File Offset: 0x00091C88
		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			if (motorIndex < 0 || motorIndex >= this.rNCDklHJigBYldrmDbqdaSVdHFJgE.wsLXqPGUEJhFpCxTWGFODOAcbGhM)
			{
				return;
			}
			DualShock4MotorType motor;
			if (motorIndex != 0)
			{
				if (motorIndex != 1)
				{
					throw new NotImplementedException();
				}
				motor = DualShock4MotorType.RightMotor;
			}
			else
			{
				motor = DualShock4MotorType.LeftMotor;
			}
			this.SetVibration(motor, motorLevel, duration, stopOtherMotors);
		}

		// Token: 0x06002625 RID: 9765 RVA: 0x00093AF8 File Offset: 0x00091CF8
		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0f;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return 0f;
			}
			if (!this.rNCDklHJigBYldrmDbqdaSVdHFJgE.GOGORasIdNEXAiBeYLALYzvTSxYs)
			{
				return 0f;
			}
			if (motorIndex == 0)
			{
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LeftMotor;
			}
			if (motorIndex != 1)
			{
				return 0f;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.RightMotor;
		}

		// Token: 0x06002626 RID: 9766 RVA: 0x00093B80 File Offset: 0x00091D80
		public void StopVibration()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			if (!this.rNCDklHJigBYldrmDbqdaSVdHFJgE.GOGORasIdNEXAiBeYLALYzvTSxYs)
			{
				return;
			}
			for (int i = 0; i < this.rNCDklHJigBYldrmDbqdaSVdHFJgE.wsLXqPGUEJhFpCxTWGFODOAcbGhM; i++)
			{
				this.PHpLEfUQxYNYpxIxQRUkukswGHSs[i].Clear();
			}
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.StopVibration();
		}

		// Token: 0x06002627 RID: 9767 RVA: 0x00093BFC File Offset: 0x00091DFC
		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0f;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return 0f;
			}
			if (!this.rNCDklHJigBYldrmDbqdaSVdHFJgE.GOGORasIdNEXAiBeYLALYzvTSxYs)
			{
				return 0f;
			}
			if (motor == DualShock4MotorType.LeftMotor)
			{
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LeftMotor;
			}
			if (motor != DualShock4MotorType.RightMotor)
			{
				throw new NotImplementedException();
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.RightMotor;
		}

		// Token: 0x06002628 RID: 9768 RVA: 0x0001BFFF File Offset: 0x0001A1FF
		public void SetVibration(DualShock4MotorType motor, float motorLevel)
		{
			this.SetVibration(motor, motorLevel, 0f, false);
		}

		// Token: 0x06002629 RID: 9769 RVA: 0x0001C00F File Offset: 0x0001A20F
		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration)
		{
			this.SetVibration(motor, motorLevel, duration, false);
		}

		// Token: 0x0600262A RID: 9770 RVA: 0x0001C01B File Offset: 0x0001A21B
		public void SetVibration(DualShock4MotorType motor, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		// Token: 0x0600262B RID: 9771 RVA: 0x00093C84 File Offset: 0x00091E84
		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			if (!this.rNCDklHJigBYldrmDbqdaSVdHFJgE.GOGORasIdNEXAiBeYLALYzvTSxYs)
			{
				return;
			}
			if (stopOtherMotors)
			{
				for (int i = 0; i < this.rNCDklHJigBYldrmDbqdaSVdHFJgE.wsLXqPGUEJhFpCxTWGFODOAcbGhM; i++)
				{
					this.PHpLEfUQxYNYpxIxQRUkukswGHSs[i].Clear();
				}
				this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.StopVibration();
			}
			motorLevel = MathTools.Clamp01(motorLevel);
			if (motor != DualShock4MotorType.LeftMotor)
			{
				if (motor != DualShock4MotorType.RightMotor)
				{
					throw new NotImplementedException();
				}
				this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.RightMotor = motorLevel;
			}
			else
			{
				this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LeftMotor = motorLevel;
			}
			this.rRyHkjRGsXwGENnBvnccdRrTajpB(motor, motorLevel, duration);
		}

		// Token: 0x0600262C RID: 9772 RVA: 0x0001C02B File Offset: 0x0001A22B
		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			this.SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		// Token: 0x0600262D RID: 9773 RVA: 0x00093D4C File Offset: 0x00091F4C
		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			if (!this.rNCDklHJigBYldrmDbqdaSVdHFJgE.GOGORasIdNEXAiBeYLALYzvTSxYs)
			{
				return;
			}
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LeftMotor = MathTools.Clamp01(leftMotorLevel);
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.RightMotor = MathTools.Clamp01(rightMotorLevel);
			this.rRyHkjRGsXwGENnBvnccdRrTajpB(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
			this.rRyHkjRGsXwGENnBvnccdRrTajpB(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
		}

		// Token: 0x170008F1 RID: 2289
		// (get) Token: 0x0600262E RID: 9774 RVA: 0x00093DD4 File Offset: 0x00091FD4
		// (set) Token: 0x0600262F RID: 9775 RVA: 0x0001C03F File Offset: 0x0001A23F
		public float lightColorRed
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0f;
				}
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
				{
					return 0f;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorR;
			}
			set
			{
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
				{
					return;
				}
				this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorR = value;
			}
		}

		// Token: 0x170008F2 RID: 2290
		// (get) Token: 0x06002630 RID: 9776 RVA: 0x00093E28 File Offset: 0x00092028
		// (set) Token: 0x06002631 RID: 9777 RVA: 0x0001C05B File Offset: 0x0001A25B
		public float lightColorGreen
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0f;
				}
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
				{
					return 0f;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorG;
			}
			set
			{
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
				{
					return;
				}
				this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorG = value;
			}
		}

		// Token: 0x170008F3 RID: 2291
		// (get) Token: 0x06002632 RID: 9778 RVA: 0x00093E7C File Offset: 0x0009207C
		// (set) Token: 0x06002633 RID: 9779 RVA: 0x0001C077 File Offset: 0x0001A277
		public float lightColorBlue
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0f;
				}
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
				{
					return 0f;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorB;
			}
			set
			{
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
				{
					return;
				}
				this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorB = value;
			}
		}

		// Token: 0x06002634 RID: 9780 RVA: 0x00093ED0 File Offset: 0x000920D0
		public Color GetLightColor()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return default(Color);
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
			{
				return default(Color);
			}
			return new Color(this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorR, this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorG, this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorB, 1f);
		}

		// Token: 0x06002635 RID: 9781 RVA: 0x00093F4C File Offset: 0x0009214C
		public void SetLightColor(Color color)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorR = color.r * color.a;
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorG = color.g * color.a;
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorB = color.b * color.a;
		}

		// Token: 0x06002636 RID: 9782 RVA: 0x0001C093 File Offset: 0x0001A293
		public void SetLightColor(float red, float green, float blue)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			this.SetLightColor(red, green, blue, 1f);
		}

		// Token: 0x06002637 RID: 9783 RVA: 0x00093FDC File Offset: 0x000921DC
		public void SetLightColor(float red, float green, float blue, float intensity)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorR = red * intensity;
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorG = green * intensity;
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightColorB = blue * intensity;
		}

		// Token: 0x06002638 RID: 9784 RVA: 0x00094050 File Offset: 0x00092250
		public void SetLightFlash(float onDuration, float offDuration)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightFlashOnDuration = onDuration;
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LightFlashOffDuration = offDuration;
		}

		// Token: 0x06002639 RID: 9785 RVA: 0x0001C0BD File Offset: 0x0001A2BD
		public void StopLightFlash()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.StopLightFlash();
		}

		// Token: 0x0600263A RID: 9786 RVA: 0x000940AC File Offset: 0x000922AC
		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.AccelerometerValueRaw;
		}

		// Token: 0x0600263B RID: 9787 RVA: 0x00094108 File Offset: 0x00092308
		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.AccelerometerValue;
		}

		// Token: 0x0600263C RID: 9788 RVA: 0x00094164 File Offset: 0x00092364
		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LastGyroscopeValueRaw;
		}

		// Token: 0x0600263D RID: 9789 RVA: 0x000941C0 File Offset: 0x000923C0
		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.LastGyroscopeValue;
		}

		// Token: 0x0600263E RID: 9790 RVA: 0x0009421C File Offset: 0x0009241C
		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.GyroscopeValueRaw;
		}

		// Token: 0x0600263F RID: 9791 RVA: 0x00094278 File Offset: 0x00092478
		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.GyroscopeValue;
		}

		// Token: 0x06002640 RID: 9792 RVA: 0x000942D4 File Offset: 0x000924D4
		public Quaternion GetOrientation()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Quaternion.identity;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.Orientation;
		}

		// Token: 0x06002641 RID: 9793 RVA: 0x0001C0FA File Offset: 0x0001A2FA
		public void ResetOrientation()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
			{
				return;
			}
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.ResetOrientation();
		}

		// Token: 0x170008F4 RID: 2292
		// (get) Token: 0x06002642 RID: 9794 RVA: 0x0001C12F File Offset: 0x0001A32F
		public int maxTouches
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
				{
					return 0;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.MaxTouches;
			}
		}

		// Token: 0x170008F5 RID: 2293
		// (get) Token: 0x06002643 RID: 9795 RVA: 0x0001C166 File Offset: 0x0001A366
		public int touchCount
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.GetTouchCount();
			}
		}

		// Token: 0x06002644 RID: 9796 RVA: 0x00094334 File Offset: 0x00092534
		public int GetTouchId(int index)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return -1;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.GetTouchIdAtIndex(index);
		}

		// Token: 0x06002645 RID: 9797 RVA: 0x00094388 File Offset: 0x00092588
		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.GetTouchPositionByIndex(index, out position);
		}

		// Token: 0x06002646 RID: 9798 RVA: 0x000943F4 File Offset: 0x000925F4
		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.GetTouchPositionByTouchId(touchId, out position);
		}

		// Token: 0x06002647 RID: 9799 RVA: 0x00094460 File Offset: 0x00092660
		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int num;
			int num2;
			bool touchPositionAbsoluteByIndex = this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.GetTouchPositionAbsoluteByIndex(index, out num, out num2);
			position = new Vector2((float)num, (float)num2);
			return touchPositionAbsoluteByIndex;
		}

		// Token: 0x06002648 RID: 9800 RVA: 0x000944DC File Offset: 0x000926DC
		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int num;
			int num2;
			bool touchPositionAbsoluteByTouchId = this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.GetTouchPositionAbsoluteByTouchId(touchId, out num, out num2);
			position = new Vector2((float)num, (float)num2);
			return touchPositionAbsoluteByTouchId;
		}

		// Token: 0x06002649 RID: 9801 RVA: 0x00094558 File Offset: 0x00092758
		public bool IsTouching(int index)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb && base.enabled && ReInput.IsInputAllowed(ControllerType.Joystick) && this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.IsTouchingAtIndex(index);
		}

		// Token: 0x0600264A RID: 9802 RVA: 0x000945AC File Offset: 0x000927AC
		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb && base.enabled && ReInput.IsInputAllowed(ControllerType.Joystick) && this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.IsTouchingAtTouchId(touchId);
		}

		// Token: 0x170008F6 RID: 2294
		// (get) Token: 0x0600264B RID: 9803 RVA: 0x0001C193 File Offset: 0x0001A393
		public float batteryLevel
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0f;
				}
				if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
				{
					return 0f;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.BatteryLevel;
			}
		}

		// Token: 0x170008F7 RID: 2295
		// (get) Token: 0x0600264C RID: 9804 RVA: 0x0001C1D2 File Offset: 0x0001A3D2
		public bool batteryCharging
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return false;
				}
				return this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb && this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.BatteryCharging;
			}
		}

		// Token: 0x0600264D RID: 9805 RVA: 0x0001C209 File Offset: 0x0001A409
		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			return this.GetGyroscopeValue();
		}

		// Token: 0x0600264E RID: 9806 RVA: 0x0001C211 File Offset: 0x0001A411
		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			return this.GetGyroscopeValueRaw();
		}

		// Token: 0x170008F8 RID: 2296
		// (get) Token: 0x0600264F RID: 9807 RVA: 0x0001C219 File Offset: 0x0001A419
		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.vendorId;
			}
		}

		// Token: 0x170008F9 RID: 2297
		// (get) Token: 0x06002650 RID: 9808 RVA: 0x0001C246 File Offset: 0x0001A446
		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.productId;
			}
		}

		// Token: 0x170008FA RID: 2298
		// (get) Token: 0x06002651 RID: 9809 RVA: 0x0001C273 File Offset: 0x0001A473
		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.productName;
			}
		}

		// Token: 0x170008FB RID: 2299
		// (get) Token: 0x06002652 RID: 9810 RVA: 0x0001C2A4 File Offset: 0x0001A4A4
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.manufacturer;
			}
		}

		// Token: 0x170008FC RID: 2300
		// (get) Token: 0x06002653 RID: 9811 RVA: 0x0001C2D5 File Offset: 0x0001A4D5
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.usagePage;
			}
		}

		// Token: 0x170008FD RID: 2301
		// (get) Token: 0x06002654 RID: 9812 RVA: 0x0001C302 File Offset: 0x0001A502
		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo.usage;
			}
		}

		// Token: 0x06002655 RID: 9813 RVA: 0x0001C32F File Offset: 0x0001A52F
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb || !base.enabled)
			{
				return;
			}
			this.jshcnpASoZElZfEahQjiqSKlMpLyA();
		}

		// Token: 0x06002656 RID: 9814 RVA: 0x0001C348 File Offset: 0x0001A548
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.rNCDklHJigBYldrmDbqdaSVdHFJgE = (source as DualShock4Extension.TOpgIFeaOaElKJPdseQRJfIJosQYA);
			this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb = (this.rNCDklHJigBYldrmDbqdaSVdHFJgE != null && this.rNCDklHJigBYldrmDbqdaSVdHFJgE.FbEIHsUOjzHFeLONfaPgCcysorQo != null);
		}

		// Token: 0x06002657 RID: 9815 RVA: 0x0001C375 File Offset: 0x0001A575
		internal override Controller.Extension Clone()
		{
			return new DualShock4Extension(this);
		}

		// Token: 0x06002658 RID: 9816 RVA: 0x00094600 File Offset: 0x00092800
		private void jshcnpASoZElZfEahQjiqSKlMpLyA()
		{
			if (!this.PxdgWWzLeUmwJhuOLlWhdgsxsuUb)
			{
				return;
			}
			if (!this.rNCDklHJigBYldrmDbqdaSVdHFJgE.GOGORasIdNEXAiBeYLALYzvTSxYs)
			{
				return;
			}
			for (int i = 0; i < this.rNCDklHJigBYldrmDbqdaSVdHFJgE.wsLXqPGUEJhFpCxTWGFODOAcbGhM; i++)
			{
				if (this.PHpLEfUQxYNYpxIxQRUkukswGHSs[i].Update())
				{
					this.SetVibration(i, 0f, false);
				}
			}
		}

		// Token: 0x06002659 RID: 9817 RVA: 0x00094658 File Offset: 0x00092858
		private void rRyHkjRGsXwGENnBvnccdRrTajpB(DualShock4MotorType A_1, float A_2, float A_3)
		{
			int num;
			if (A_1 != DualShock4MotorType.LeftMotor)
			{
				if (A_1 != DualShock4MotorType.RightMotor)
				{
					throw new NotImplementedException();
				}
				num = 1;
			}
			else
			{
				num = 0;
			}
			if (A_2 <= 0f || A_3 <= 0f)
			{
				this.PHpLEfUQxYNYpxIxQRUkukswGHSs[num].Clear();
				return;
			}
			this.PHpLEfUQxYNYpxIxQRUkukswGHSs[num].Start((double)A_3);
		}

		// Token: 0x040015D0 RID: 5584
		private DualShock4Extension.TOpgIFeaOaElKJPdseQRJfIJosQYA rNCDklHJigBYldrmDbqdaSVdHFJgE;

		// Token: 0x040015D1 RID: 5585
		private bool PxdgWWzLeUmwJhuOLlWhdgsxsuUb;

		// Token: 0x040015D2 RID: 5586
		private TimerAbs[] PHpLEfUQxYNYpxIxQRUkukswGHSs;

		// Token: 0x020003B7 RID: 951
		private class TOpgIFeaOaElKJPdseQRJfIJosQYA : IControllerExtensionSource
		{
			// Token: 0x0600265A RID: 9818 RVA: 0x0001C37D File Offset: 0x0001A57D
			public TOpgIFeaOaElKJPdseQRJfIJosQYA(IDriver_DualShock4 A_1, bool A_2, int A_3)
			{
				this.FbEIHsUOjzHFeLONfaPgCcysorQo = A_1;
				this.GOGORasIdNEXAiBeYLALYzvTSxYs = A_2;
				this.wsLXqPGUEJhFpCxTWGFODOAcbGhM = A_3;
			}

			// Token: 0x040015D3 RID: 5587
			public readonly IDriver_DualShock4 FbEIHsUOjzHFeLONfaPgCcysorQo;

			// Token: 0x040015D4 RID: 5588
			public readonly bool GOGORasIdNEXAiBeYLALYzvTSxYs;

			// Token: 0x040015D5 RID: 5589
			public readonly int wsLXqPGUEJhFpCxTWGFODOAcbGhM;
		}
	}
}
