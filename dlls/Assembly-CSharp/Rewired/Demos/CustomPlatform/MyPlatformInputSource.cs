using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002DB RID: 731
	public sealed class MyPlatformInputSource : CustomPlatformInputSource
	{
		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x00051E21 File Offset: 0x00050021
		public override bool isReady
		{
			get
			{
				return this._initialized;
			}
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x00051E29 File Offset: 0x00050029
		public MyPlatformInputSource(CustomPlatformConfigVars configVars) : base(configVars, new CustomPlatformInputSource.InitOptions
		{
			unifiedKeyboardSource = new MyPlatformUnifiedKeyboardSource(),
			unifiedMouseSource = new MyPlatformUnifiedMouseSource()
		})
		{
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x00051E58 File Offset: 0x00050058
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this._initialized = true;
			this.MonitorDeviceChanges();
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x00051E6D File Offset: 0x0005006D
		public override void Update()
		{
			this._joystickInputSource.Update();
			this.MonitorDeviceChanges();
		}

		// Token: 0x06000F5E RID: 3934 RVA: 0x00051E80 File Offset: 0x00050080
		private void MonitorDeviceChanges()
		{
			IList<CustomInputSource.Joystick> joysticks = base.GetJoysticks();
			IList<UnityInputJoystickSource.Joystick> joysticks2 = this._joystickInputSource.GetJoysticks();
			for (int i = joysticks.Count - 1; i >= 0; i--)
			{
				MyPlatformInputSource.Joystick joystick = joysticks[i] as MyPlatformInputSource.Joystick;
				if (!MyPlatformInputSource.ContainsSystemJoystickBySystemId(joysticks2, joystick.sourceJoystick.systemId))
				{
					base.RemoveJoystick(joystick);
				}
			}
			for (int j = 0; j < joysticks2.Count; j++)
			{
				UnityInputJoystickSource.Joystick joystick2 = joysticks2[j];
				if (!MyPlatformInputSource.ContainsJoystickBySystemId(joysticks, joystick2.systemId))
				{
					MyPlatformInputSource.Joystick joystick3 = new MyPlatformInputSource.Joystick(joystick2);
					if (joystick2.vibrationMotorCount > 0)
					{
						joystick3.extension = new MyPlatformControllerExtension(joystick3);
					}
					base.AddJoystick(joystick3);
				}
			}
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x00051F31 File Offset: 0x00050131
		protected override void Dispose(bool disposing)
		{
			if (this._disposed)
			{
				return;
			}
			this._disposed = true;
			base.Dispose(disposing);
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x00051F4C File Offset: 0x0005014C
		private static bool ContainsJoystickBySystemId(IList<CustomInputSource.Joystick> joysticks, long systemId)
		{
			for (int i = 0; i < joysticks.Count; i++)
			{
				long? systemId2 = joysticks[i].systemId;
				if (systemId2.GetValueOrDefault() == systemId & systemId2 != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x00051F90 File Offset: 0x00050190
		private static bool ContainsSystemJoystickBySystemId(IList<UnityInputJoystickSource.Joystick> systemJoysticks, long systemId)
		{
			for (int i = 0; i < systemJoysticks.Count; i++)
			{
				if (systemJoysticks[i].systemId == systemId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040013FC RID: 5116
		private UnityInputJoystickSource _joystickInputSource = new UnityInputJoystickSource();

		// Token: 0x040013FD RID: 5117
		private bool _initialized;

		// Token: 0x040013FE RID: 5118
		private bool _disposed;

		// Token: 0x020002DC RID: 732
		public new sealed class Joystick : CustomPlatformInputSource.Joystick, IControllerVibrator
		{
			// Token: 0x1700030E RID: 782
			// (get) Token: 0x06000F62 RID: 3938 RVA: 0x00051FC0 File Offset: 0x000501C0
			public UnityInputJoystickSource.Joystick sourceJoystick
			{
				get
				{
					return this._sourceJoystick;
				}
			}

			// Token: 0x06000F63 RID: 3939 RVA: 0x00051FC8 File Offset: 0x000501C8
			public Joystick(UnityInputJoystickSource.Joystick sourceJoystick) : base(sourceJoystick.deviceName, sourceJoystick.systemId, sourceJoystick.axisCount, sourceJoystick.buttonCount)
			{
				if (sourceJoystick == null)
				{
					throw new ArgumentNullException("sourceJoystick");
				}
				this._sourceJoystick = sourceJoystick;
				base.customIdentifier = this._sourceJoystick.identifier;
				base.deviceInstanceGuid = sourceJoystick.deviceInstanceGuid;
			}

			// Token: 0x06000F64 RID: 3940 RVA: 0x0005202C File Offset: 0x0005022C
			public override void Update()
			{
				for (int i = 0; i < base.buttonCount; i++)
				{
					this.SetButtonValue(i, this.sourceJoystick.GetButtonValue(i));
				}
				for (int j = 0; j < base.axisCount; j++)
				{
					this.SetAxisValue(j, this.sourceJoystick.GetAxisValue(j));
				}
			}

			// Token: 0x1700030F RID: 783
			// (get) Token: 0x06000F65 RID: 3941 RVA: 0x00052081 File Offset: 0x00050281
			public int vibrationMotorCount
			{
				get
				{
					return this._sourceJoystick.vibrationMotorCount;
				}
			}

			// Token: 0x06000F66 RID: 3942 RVA: 0x0005208E File Offset: 0x0005028E
			public void SetVibration(int motorIndex, float motorLevel)
			{
				this._sourceJoystick.SetVibration(motorIndex, motorLevel);
			}

			// Token: 0x06000F67 RID: 3943 RVA: 0x0005209D File Offset: 0x0005029D
			public void SetVibration(int motorIndex, float motorLevel, float duration)
			{
				this._sourceJoystick.SetVibration(motorIndex, motorLevel, duration);
			}

			// Token: 0x06000F68 RID: 3944 RVA: 0x000520AD File Offset: 0x000502AD
			public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
			{
				this._sourceJoystick.SetVibration(motorIndex, motorLevel, stopOtherMotors);
			}

			// Token: 0x06000F69 RID: 3945 RVA: 0x000520BD File Offset: 0x000502BD
			public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
			{
				this._sourceJoystick.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
			}

			// Token: 0x06000F6A RID: 3946 RVA: 0x000520CF File Offset: 0x000502CF
			public float GetVibration(int motorIndex)
			{
				return this._sourceJoystick.GetVibration(motorIndex);
			}

			// Token: 0x06000F6B RID: 3947 RVA: 0x000520DD File Offset: 0x000502DD
			public void StopVibration()
			{
				this._sourceJoystick.StopVibration();
			}

			// Token: 0x040013FF RID: 5119
			private UnityInputJoystickSource.Joystick _sourceJoystick;
		}
	}
}
