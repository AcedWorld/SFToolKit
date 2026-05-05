using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003A6 RID: 934
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DualSenseExtension : Controller.Extension, IControllerVibrator, IDualShock4Extension, IDualSenseExtension, IHIDControllerExtension
	{
		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x06002591 RID: 9617 RVA: 0x00014B29 File Offset: 0x00012D29
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x06002592 RID: 9618 RVA: 0x00092A30 File Offset: 0x00090C30
		internal DualSenseExtension(IDriver_DualSense A_1) : base(new DualSenseExtension.NUNLyiWkNtEaghvxXCbtDGRAPubS(A_1, A_1.VibrationMotorCount > 0, A_1.VibrationMotorCount))
		{
			this.OwGeSuPUUqnglGqjLePhcWEqUXzRA = new TimerAbs[A_1.VibrationMotorCount];
			ArrayTools.Populate<TimerAbs>(this.OwGeSuPUUqnglGqjLePhcWEqUXzRA, 0, this.OwGeSuPUUqnglGqjLePhcWEqUXzRA.Length);
		}

		// Token: 0x06002593 RID: 9619 RVA: 0x00092A80 File Offset: 0x00090C80
		private DualSenseExtension(DualSenseExtension A_1) : base(A_1)
		{
			try
			{
				this.OwGeSuPUUqnglGqjLePhcWEqUXzRA = new TimerAbs[A_1.vibrationMotorCount];
			}
			catch
			{
				this.OwGeSuPUUqnglGqjLePhcWEqUXzRA = new TimerAbs[0];
			}
			ArrayTools.Populate<TimerAbs>(this.OwGeSuPUUqnglGqjLePhcWEqUXzRA, 0, this.OwGeSuPUUqnglGqjLePhcWEqUXzRA.Length);
		}

		// Token: 0x170008C4 RID: 2244
		// (get) Token: 0x06002594 RID: 9620 RVA: 0x0001B7B1 File Offset: 0x000199B1
		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
				{
					return 0;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.UizpGcazxEsStSctxwPFNKiGCGtT;
			}
		}

		// Token: 0x06002595 RID: 9621 RVA: 0x0001B7E3 File Offset: 0x000199E3
		public void SetVibration(int motorIndex, float motorLevel)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, false);
		}

		// Token: 0x06002596 RID: 9622 RVA: 0x0001B7F3 File Offset: 0x000199F3
		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			this.SetVibration(motorIndex, motorLevel, duration, false);
		}

		// Token: 0x06002597 RID: 9623 RVA: 0x0001B7FF File Offset: 0x000199FF
		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		// Token: 0x06002598 RID: 9624 RVA: 0x00092ADC File Offset: 0x00090CDC
		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return;
			}
			if (motorIndex < 0 || motorIndex >= this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.UizpGcazxEsStSctxwPFNKiGCGtT)
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

		// Token: 0x06002599 RID: 9625 RVA: 0x00092B4C File Offset: 0x00090D4C
		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0f;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return 0f;
			}
			if (!this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.AGUGEEyhpXjOKIrXtfnqfdRJmZaTA)
			{
				return 0f;
			}
			if (motorIndex == 0)
			{
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LeftMotor;
			}
			if (motorIndex != 1)
			{
				return 0f;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.RightMotor;
		}

		// Token: 0x0600259A RID: 9626 RVA: 0x00092BD4 File Offset: 0x00090DD4
		public void StopVibration()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return;
			}
			if (!this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.AGUGEEyhpXjOKIrXtfnqfdRJmZaTA)
			{
				return;
			}
			for (int i = 0; i < this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.UizpGcazxEsStSctxwPFNKiGCGtT; i++)
			{
				this.OwGeSuPUUqnglGqjLePhcWEqUXzRA[i].Clear();
			}
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.StopVibration();
		}

		// Token: 0x0600259B RID: 9627 RVA: 0x0001B80F File Offset: 0x00019A0F
		public DualSenseVibrationMode GetVibrationMode()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return DualSenseVibrationMode.Compatible2;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.vibrationMode;
		}

		// Token: 0x0600259C RID: 9628 RVA: 0x0001B83C File Offset: 0x00019A3C
		public void SetVibrationMode(DualSenseVibrationMode mode)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.vibrationMode = mode;
		}

		// Token: 0x0600259D RID: 9629 RVA: 0x00092C50 File Offset: 0x00090E50
		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return 0f;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return 0f;
			}
			if (!this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.AGUGEEyhpXjOKIrXtfnqfdRJmZaTA)
			{
				return 0f;
			}
			if (motor == DualShock4MotorType.LeftMotor)
			{
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LeftMotor;
			}
			if (motor != DualShock4MotorType.RightMotor)
			{
				throw new NotImplementedException();
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.RightMotor;
		}

		// Token: 0x0600259E RID: 9630 RVA: 0x0001B869 File Offset: 0x00019A69
		public void SetVibration(DualShock4MotorType motor, float motorLevel)
		{
			this.SetVibration(motor, motorLevel, 0f, false);
		}

		// Token: 0x0600259F RID: 9631 RVA: 0x0001B879 File Offset: 0x00019A79
		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration)
		{
			this.SetVibration(motor, motorLevel, duration, false);
		}

		// Token: 0x060025A0 RID: 9632 RVA: 0x0001B885 File Offset: 0x00019A85
		public void SetVibration(DualShock4MotorType motor, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		// Token: 0x060025A1 RID: 9633 RVA: 0x00092CD8 File Offset: 0x00090ED8
		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return;
			}
			if (!this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.AGUGEEyhpXjOKIrXtfnqfdRJmZaTA)
			{
				return;
			}
			if (stopOtherMotors)
			{
				for (int i = 0; i < this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.UizpGcazxEsStSctxwPFNKiGCGtT; i++)
				{
					this.OwGeSuPUUqnglGqjLePhcWEqUXzRA[i].Clear();
				}
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.StopVibration();
			}
			motorLevel = MathTools.Clamp01(motorLevel);
			if (motor != DualShock4MotorType.LeftMotor)
			{
				if (motor != DualShock4MotorType.RightMotor)
				{
					throw new NotImplementedException();
				}
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.RightMotor = motorLevel;
			}
			else
			{
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LeftMotor = motorLevel;
			}
			this.pXFAWPbkwiWqFbrgDmHVrluCZGLqA(motor, motorLevel, duration);
		}

		// Token: 0x060025A2 RID: 9634 RVA: 0x0001B895 File Offset: 0x00019A95
		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			this.SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		// Token: 0x060025A3 RID: 9635 RVA: 0x00092DA0 File Offset: 0x00090FA0
		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return;
			}
			if (!this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.AGUGEEyhpXjOKIrXtfnqfdRJmZaTA)
			{
				return;
			}
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LeftMotor = MathTools.Clamp01(leftMotorLevel);
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.RightMotor = MathTools.Clamp01(rightMotorLevel);
			this.pXFAWPbkwiWqFbrgDmHVrluCZGLqA(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
			this.pXFAWPbkwiWqFbrgDmHVrluCZGLqA(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
		}

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x060025A4 RID: 9636 RVA: 0x00092E28 File Offset: 0x00091028
		// (set) Token: 0x060025A5 RID: 9637 RVA: 0x0001B8A9 File Offset: 0x00019AA9
		public float lightColorRed
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0f;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return 0f;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorR;
			}
			set
			{
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
				{
					return;
				}
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorR = value;
			}
		}

		// Token: 0x170008C6 RID: 2246
		// (get) Token: 0x060025A6 RID: 9638 RVA: 0x00092E7C File Offset: 0x0009107C
		// (set) Token: 0x060025A7 RID: 9639 RVA: 0x0001B8C5 File Offset: 0x00019AC5
		public float lightColorGreen
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0f;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return 0f;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorG;
			}
			set
			{
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
				{
					return;
				}
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorG = value;
			}
		}

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x060025A8 RID: 9640 RVA: 0x00092ED0 File Offset: 0x000910D0
		// (set) Token: 0x060025A9 RID: 9641 RVA: 0x0001B8E1 File Offset: 0x00019AE1
		public float lightColorBlue
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0f;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return 0f;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorB;
			}
			set
			{
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
				{
					return;
				}
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorB = value;
			}
		}

		// Token: 0x060025AA RID: 9642 RVA: 0x00092F24 File Offset: 0x00091124
		public Color GetLightColor()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return default(Color);
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
			{
				return default(Color);
			}
			return new Color(this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorR, this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorG, this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorB, 1f);
		}

		// Token: 0x060025AB RID: 9643 RVA: 0x00092FA0 File Offset: 0x000911A0
		public void SetLightColor(Color color)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return;
			}
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorR = color.r * color.a;
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorG = color.g * color.a;
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorB = color.b * color.a;
		}

		// Token: 0x060025AC RID: 9644 RVA: 0x0001B8FD File Offset: 0x00019AFD
		public void SetLightColor(float red, float green, float blue)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			this.SetLightColor(red, green, blue, 1f);
		}

		// Token: 0x060025AD RID: 9645 RVA: 0x00093030 File Offset: 0x00091230
		public void SetLightColor(float red, float green, float blue, float intensity)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return;
			}
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorR = red * intensity;
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorG = green * intensity;
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LightColorB = blue * intensity;
		}

		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x060025AE RID: 9646 RVA: 0x0001B927 File Offset: 0x00019B27
		// (set) Token: 0x060025AF RID: 9647 RVA: 0x0001B966 File Offset: 0x00019B66
		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return DualSenseMicrophoneLightMode.Off;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return;
				}
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.microphoneLightMode = value;
			}
		}

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x060025B0 RID: 9648 RVA: 0x0001B9A4 File Offset: 0x00019BA4
		// (set) Token: 0x060025B1 RID: 9649 RVA: 0x0001B9E3 File Offset: 0x00019BE3
		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return DualSenseOtherLightBrightness.High;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return;
				}
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.otherLightBrightness = value;
			}
		}

		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x060025B2 RID: 9650 RVA: 0x0001BA21 File Offset: 0x00019C21
		// (set) Token: 0x060025B3 RID: 9651 RVA: 0x0001BA60 File Offset: 0x00019C60
		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return DualSensePlayerLightFlags.None;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.playerLights;
			}
			set
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
				{
					return;
				}
				this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.playerLights = value;
			}
		}

		// Token: 0x060025B4 RID: 9652 RVA: 0x000930A4 File Offset: 0x000912A4
		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.AccelerometerValueRaw;
		}

		// Token: 0x060025B5 RID: 9653 RVA: 0x00093100 File Offset: 0x00091300
		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.AccelerometerValue;
		}

		// Token: 0x060025B6 RID: 9654 RVA: 0x0009315C File Offset: 0x0009135C
		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LastGyroscopeValueRaw;
		}

		// Token: 0x060025B7 RID: 9655 RVA: 0x000931B8 File Offset: 0x000913B8
		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.LastGyroscopeValue;
		}

		// Token: 0x060025B8 RID: 9656 RVA: 0x00093214 File Offset: 0x00091414
		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GyroscopeValueRaw;
		}

		// Token: 0x060025B9 RID: 9657 RVA: 0x00093270 File Offset: 0x00091470
		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Vector3.zero;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GyroscopeValue;
		}

		// Token: 0x060025BA RID: 9658 RVA: 0x000932CC File Offset: 0x000914CC
		public Quaternion GetOrientation()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return Quaternion.identity;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.Orientation;
		}

		// Token: 0x060025BB RID: 9659 RVA: 0x0001BA9E File Offset: 0x00019C9E
		public void ResetOrientation()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
			{
				return;
			}
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.ResetOrientation();
		}

		// Token: 0x170008CB RID: 2251
		// (get) Token: 0x060025BC RID: 9660 RVA: 0x0001BAD3 File Offset: 0x00019CD3
		public int maxTouches
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
				{
					return 0;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.MaxTouches;
			}
		}

		// Token: 0x170008CC RID: 2252
		// (get) Token: 0x060025BD RID: 9661 RVA: 0x0001BB0A File Offset: 0x00019D0A
		public int touchCount
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GetTouchCount();
			}
		}

		// Token: 0x060025BE RID: 9662 RVA: 0x0009332C File Offset: 0x0009152C
		public int GetTouchId(int index)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return -1;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GetTouchIdAtIndex(index);
		}

		// Token: 0x060025BF RID: 9663 RVA: 0x00093380 File Offset: 0x00091580
		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GetTouchPositionByIndex(index, out position);
		}

		// Token: 0x060025C0 RID: 9664 RVA: 0x000933EC File Offset: 0x000915EC
		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GetTouchPositionByTouchId(touchId, out position);
		}

		// Token: 0x060025C1 RID: 9665 RVA: 0x00093458 File Offset: 0x00091658
		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int num;
			int num2;
			bool touchPositionAbsoluteByIndex = this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GetTouchPositionAbsoluteByIndex(index, out num, out num2);
			position = new Vector2((float)num, (float)num2);
			return touchPositionAbsoluteByIndex;
		}

		// Token: 0x060025C2 RID: 9666 RVA: 0x000934D4 File Offset: 0x000916D4
		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int num;
			int num2;
			bool touchPositionAbsoluteByTouchId = this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GetTouchPositionAbsoluteByTouchId(touchId, out num, out num2);
			position = new Vector2((float)num, (float)num2);
			return touchPositionAbsoluteByTouchId;
		}

		// Token: 0x060025C3 RID: 9667 RVA: 0x00093550 File Offset: 0x00091750
		public bool IsTouching(int index)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb && base.enabled && ReInput.IsInputAllowed(ControllerType.Joystick) && this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.IsTouchingAtIndex(index);
		}

		// Token: 0x060025C4 RID: 9668 RVA: 0x000935A4 File Offset: 0x000917A4
		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb && base.enabled && ReInput.IsInputAllowed(ControllerType.Joystick) && this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.IsTouchingAtTouchId(touchId);
		}

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x060025C5 RID: 9669 RVA: 0x0001BB37 File Offset: 0x00019D37
		public float batteryLevel
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0f;
				}
				if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
				{
					return 0f;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.BatteryLevel;
			}
		}

		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x060025C6 RID: 9670 RVA: 0x0001BB76 File Offset: 0x00019D76
		public bool batteryCharging
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return false;
				}
				return this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb && this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.BatteryCharging;
			}
		}

		// Token: 0x060025C7 RID: 9671 RVA: 0x0001BBAD File Offset: 0x00019DAD
		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return false;
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.SetTriggerEffect(trigger, effect);
		}

		// Token: 0x060025C8 RID: 9672 RVA: 0x000935F8 File Offset: 0x000917F8
		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return default(DualSenseTriggerEffectStates);
			}
			return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.GetTriggerEffectStates();
		}

		// Token: 0x060025C9 RID: 9673 RVA: 0x0001BBDC File Offset: 0x00019DDC
		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			return this.GetGyroscopeValue();
		}

		// Token: 0x060025CA RID: 9674 RVA: 0x0001BBE4 File Offset: 0x00019DE4
		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			return this.GetGyroscopeValueRaw();
		}

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x060025CB RID: 9675 RVA: 0x0001BBEC File Offset: 0x00019DEC
		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.vendorId;
			}
		}

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x060025CC RID: 9676 RVA: 0x0001BC19 File Offset: 0x00019E19
		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.productId;
			}
		}

		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x060025CD RID: 9677 RVA: 0x0001BC46 File Offset: 0x00019E46
		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.productName;
			}
		}

		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x060025CE RID: 9678 RVA: 0x0001BC77 File Offset: 0x00019E77
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.manufacturer;
			}
		}

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x060025CF RID: 9679 RVA: 0x0001BCA8 File Offset: 0x00019EA8
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.usagePage;
			}
		}

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x060025D0 RID: 9680 RVA: 0x0001BCD5 File Offset: 0x00019ED5
		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu.usage;
			}
		}

		// Token: 0x060025D1 RID: 9681 RVA: 0x0001BD02 File Offset: 0x00019F02
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb || !base.enabled)
			{
				return;
			}
			this.gHydMVFsvBLogcnggGkmFUhsMjSVB();
		}

		// Token: 0x060025D2 RID: 9682 RVA: 0x0001BD1B File Offset: 0x00019F1B
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.BVlkVuXKPwfczAidWBiXgGbEjwmDA = (source as DualSenseExtension.NUNLyiWkNtEaghvxXCbtDGRAPubS);
			this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb = (this.BVlkVuXKPwfczAidWBiXgGbEjwmDA != null && this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.rYxZFEvmOdVZTuxVBpRMzalxypbu != null);
		}

		// Token: 0x060025D3 RID: 9683 RVA: 0x0001BD48 File Offset: 0x00019F48
		internal override Controller.Extension Clone()
		{
			return new DualSenseExtension(this);
		}

		// Token: 0x060025D4 RID: 9684 RVA: 0x00093638 File Offset: 0x00091838
		private void gHydMVFsvBLogcnggGkmFUhsMjSVB()
		{
			if (!this.HpdNJbwhTUMbKQcVxnWIcYWdjZUb)
			{
				return;
			}
			if (!this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.AGUGEEyhpXjOKIrXtfnqfdRJmZaTA)
			{
				return;
			}
			for (int i = 0; i < this.BVlkVuXKPwfczAidWBiXgGbEjwmDA.UizpGcazxEsStSctxwPFNKiGCGtT; i++)
			{
				if (this.OwGeSuPUUqnglGqjLePhcWEqUXzRA[i].Update())
				{
					this.SetVibration(i, 0f, false);
				}
			}
		}

		// Token: 0x060025D5 RID: 9685 RVA: 0x00093690 File Offset: 0x00091890
		private void pXFAWPbkwiWqFbrgDmHVrluCZGLqA(DualShock4MotorType A_1, float A_2, float A_3)
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
				this.OwGeSuPUUqnglGqjLePhcWEqUXzRA[num].Clear();
				return;
			}
			this.OwGeSuPUUqnglGqjLePhcWEqUXzRA[num].Start((double)A_3);
		}

		// Token: 0x04001593 RID: 5523
		private DualSenseExtension.NUNLyiWkNtEaghvxXCbtDGRAPubS BVlkVuXKPwfczAidWBiXgGbEjwmDA;

		// Token: 0x04001594 RID: 5524
		private bool HpdNJbwhTUMbKQcVxnWIcYWdjZUb;

		// Token: 0x04001595 RID: 5525
		private TimerAbs[] OwGeSuPUUqnglGqjLePhcWEqUXzRA;

		// Token: 0x020003A7 RID: 935
		private class NUNLyiWkNtEaghvxXCbtDGRAPubS : IControllerExtensionSource
		{
			// Token: 0x060025D6 RID: 9686 RVA: 0x0001BD50 File Offset: 0x00019F50
			public NUNLyiWkNtEaghvxXCbtDGRAPubS(IDriver_DualSense A_1, bool A_2, int A_3)
			{
				this.rYxZFEvmOdVZTuxVBpRMzalxypbu = A_1;
				this.AGUGEEyhpXjOKIrXtfnqfdRJmZaTA = A_2;
				this.UizpGcazxEsStSctxwPFNKiGCGtT = A_3;
			}

			// Token: 0x04001596 RID: 5526
			public readonly IDriver_DualSense rYxZFEvmOdVZTuxVBpRMzalxypbu;

			// Token: 0x04001597 RID: 5527
			public readonly bool AGUGEEyhpXjOKIrXtfnqfdRJmZaTA;

			// Token: 0x04001598 RID: 5528
			public readonly int UizpGcazxEsStSctxwPFNKiGCGtT;
		}
	}
}
