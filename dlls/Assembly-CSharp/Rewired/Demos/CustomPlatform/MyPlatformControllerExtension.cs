using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002D4 RID: 724
	public sealed class MyPlatformControllerExtension : CustomControllerExtension, IControllerVibrator
	{
		// Token: 0x06000F44 RID: 3908 RVA: 0x00051CAF File Offset: 0x0004FEAF
		public MyPlatformControllerExtension(MyPlatformInputSource.Joystick sourceJoystick) : base(new MyPlatformControllerExtension.Source(sourceJoystick))
		{
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x00051CBD File Offset: 0x0004FEBD
		private MyPlatformControllerExtension(MyPlatformControllerExtension other) : base(other)
		{
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x00051CC6 File Offset: 0x0004FEC6
		public override Controller.Extension ShallowCopy()
		{
			return new MyPlatformControllerExtension(this);
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x00051CCE File Offset: 0x0004FECE
		public int vibrationMotorCount
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x00051CD1 File Offset: 0x0004FED1
		public void SetVibration(int motorIndex, float motorLevel)
		{
			((MyPlatformControllerExtension.Source)base.GetSource()).sourceJoystick.SetVibration(motorIndex, motorLevel);
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x00051CEA File Offset: 0x0004FEEA
		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			((MyPlatformControllerExtension.Source)base.GetSource()).sourceJoystick.SetVibration(motorIndex, motorLevel, duration);
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x00051D04 File Offset: 0x0004FF04
		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			((MyPlatformControllerExtension.Source)base.GetSource()).sourceJoystick.SetVibration(motorIndex, motorLevel, stopOtherMotors);
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x00051D1E File Offset: 0x0004FF1E
		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			((MyPlatformControllerExtension.Source)base.GetSource()).sourceJoystick.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x00051D3A File Offset: 0x0004FF3A
		public float GetVibration(int motorIndex)
		{
			return ((MyPlatformControllerExtension.Source)base.GetSource()).sourceJoystick.GetVibration(motorIndex);
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x00051D52 File Offset: 0x0004FF52
		public void StopVibration()
		{
			((MyPlatformControllerExtension.Source)base.GetSource()).sourceJoystick.StopVibration();
		}

		// Token: 0x020002D5 RID: 725
		private class Source : IControllerExtensionSource
		{
			// Token: 0x06000F4E RID: 3918 RVA: 0x00051D69 File Offset: 0x0004FF69
			public Source(MyPlatformInputSource.Joystick sourceJoystick)
			{
				this.sourceJoystick = sourceJoystick;
			}

			// Token: 0x040013F5 RID: 5109
			public readonly MyPlatformInputSource.Joystick sourceJoystick;
		}
	}
}
