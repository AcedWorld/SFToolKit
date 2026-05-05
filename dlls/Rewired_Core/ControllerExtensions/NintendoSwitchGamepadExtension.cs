using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003BD RID: 957
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class NintendoSwitchGamepadExtension : Controller.Extension, IControllerVibrator, IHIDControllerExtension
	{
		// Token: 0x17000905 RID: 2309
		// (get) Token: 0x0600266C RID: 9836 RVA: 0x0001C476 File Offset: 0x0001A676
		protected bool isValid
		{
			get
			{
				return this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA;
			}
		}

		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x0600266D RID: 9837 RVA: 0x00014B29 File Offset: 0x00012D29
		protected Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x0600266E RID: 9838 RVA: 0x0001C47E File Offset: 0x0001A67E
		protected object source
		{
			get
			{
				return this.VfguiVDMffddVahurRluGVWQTlTx;
			}
		}

		// Token: 0x0600266F RID: 9839 RVA: 0x0001B762 File Offset: 0x00019962
		internal NintendoSwitchGamepadExtension(NintendoSwitchGamepadExtension.ExtSource_Base A_1) : base(A_1)
		{
		}

		// Token: 0x06002670 RID: 9840 RVA: 0x0001B76B File Offset: 0x0001996B
		protected NintendoSwitchGamepadExtension(NintendoSwitchGamepadExtension A_1) : base(A_1)
		{
		}

		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x06002671 RID: 9841 RVA: 0x0001C486 File Offset: 0x0001A686
		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA)
				{
					return 0;
				}
				return this.VfguiVDMffddVahurRluGVWQTlTx.driver.vibrationMotorCount;
			}
		}

		// Token: 0x06002672 RID: 9842 RVA: 0x000947B8 File Offset: 0x000929B8
		public NintendoSwitchGamepadVibration GetVibration(int motorIndex)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return NintendoSwitchGamepadVibration.KxaOiDOpcHZejzePlLdBIqvsCYsO;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return NintendoSwitchGamepadVibration.KxaOiDOpcHZejzePlLdBIqvsCYsO;
			}
			float num;
			float num2;
			float num3;
			float num4;
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.GetVibration(motorIndex, out num, out num2, out num3, out num4);
			return new NintendoSwitchGamepadVibration(num, num2, num3, num4);
		}

		// Token: 0x06002673 RID: 9843 RVA: 0x0009481C File Offset: 0x00092A1C
		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
		}

		// Token: 0x06002674 RID: 9844 RVA: 0x0009486C File Offset: 0x00092A6C
		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, stopOtherMotors);
		}

		// Token: 0x06002675 RID: 9845 RVA: 0x000948C0 File Offset: 0x00092AC0
		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
		}

		// Token: 0x06002676 RID: 9846 RVA: 0x00094914 File Offset: 0x00092B14
		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors);
		}

		// Token: 0x06002677 RID: 9847 RVA: 0x00094968 File Offset: 0x00092B68
		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh);
		}

		// Token: 0x06002678 RID: 9848 RVA: 0x000949CC File Offset: 0x00092BCC
		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, float duration)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, duration);
		}

		// Token: 0x06002679 RID: 9849 RVA: 0x00094A30 File Offset: 0x00092C30
		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, duration, stopOtherMotors);
		}

		// Token: 0x0600267A RID: 9850 RVA: 0x00094A94 File Offset: 0x00092C94
		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, bool stopOtherMotors)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA || !base.enabled)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, stopOtherMotors);
		}

		// Token: 0x0600267B RID: 9851 RVA: 0x0001C4BD File Offset: 0x0001A6BD
		public void StopVibration(int motorIndex)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.StopVibration(motorIndex);
		}

		// Token: 0x0600267C RID: 9852 RVA: 0x0001C4F3 File Offset: 0x0001A6F3
		public void StopVibration()
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (!this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA)
			{
				return;
			}
			this.VfguiVDMffddVahurRluGVWQTlTx.driver.StopVibration();
		}

		// Token: 0x0600267D RID: 9853 RVA: 0x0001C528 File Offset: 0x0001A728
		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel)
		{
			this.SetVibration(motorIndex, motorLevel, 160f, motorLevel, 320f, 0f);
		}

		// Token: 0x0600267E RID: 9854 RVA: 0x0001C542 File Offset: 0x0001A742
		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration)
		{
			this.SetVibration(motorIndex, motorLevel, 160f, motorLevel, 320f, duration);
		}

		// Token: 0x0600267F RID: 9855 RVA: 0x0001C528 File Offset: 0x0001A728
		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motorIndex, motorLevel, 160f, motorLevel, 320f, 0f);
		}

		// Token: 0x06002680 RID: 9856 RVA: 0x0001C542 File Offset: 0x0001A742
		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			this.SetVibration(motorIndex, motorLevel, 160f, motorLevel, 320f, duration);
		}

		// Token: 0x06002681 RID: 9857 RVA: 0x00094AF8 File Offset: 0x00092CF8
		float IControllerVibrator.GetVibration(int motorIndex)
		{
			NintendoSwitchGamepadVibration vibration = this.GetVibration(motorIndex);
			return MathTools.Max(vibration.amplitudeLow, vibration.amplitudeHigh);
		}

		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x06002682 RID: 9858 RVA: 0x0001C558 File Offset: 0x0001A758
		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.VfguiVDMffddVahurRluGVWQTlTx.driver.vendorId;
			}
		}

		// Token: 0x1700090A RID: 2314
		// (get) Token: 0x06002683 RID: 9859 RVA: 0x0001C585 File Offset: 0x0001A785
		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.VfguiVDMffddVahurRluGVWQTlTx.driver.productId;
			}
		}

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x06002684 RID: 9860 RVA: 0x0001C5B2 File Offset: 0x0001A7B2
		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				return this.VfguiVDMffddVahurRluGVWQTlTx.driver.productName;
			}
		}

		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x06002685 RID: 9861 RVA: 0x0001C5E3 File Offset: 0x0001A7E3
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				return this.VfguiVDMffddVahurRluGVWQTlTx.driver.manufacturer;
			}
		}

		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x06002686 RID: 9862 RVA: 0x0001C614 File Offset: 0x0001A814
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.VfguiVDMffddVahurRluGVWQTlTx.driver.usagePage;
			}
		}

		// Token: 0x1700090E RID: 2318
		// (get) Token: 0x06002687 RID: 9863 RVA: 0x0001C641 File Offset: 0x0001A841
		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.VfguiVDMffddVahurRluGVWQTlTx.driver.usage;
			}
		}

		// Token: 0x06002688 RID: 9864 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		// Token: 0x06002689 RID: 9865 RVA: 0x0001C66E File Offset: 0x0001A86E
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.VfguiVDMffddVahurRluGVWQTlTx = (source as NintendoSwitchGamepadExtension.ExtSource_Base);
			this.sUSYJzXkxAEhDSgLvaMBgJBLQvcCA = (this.VfguiVDMffddVahurRluGVWQTlTx != null && this.VfguiVDMffddVahurRluGVWQTlTx.driver != null);
		}

		// Token: 0x040015EB RID: 5611
		private NintendoSwitchGamepadExtension.ExtSource_Base VfguiVDMffddVahurRluGVWQTlTx;

		// Token: 0x040015EC RID: 5612
		private bool sUSYJzXkxAEhDSgLvaMBgJBLQvcCA;

		// Token: 0x020003BE RID: 958
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		internal class ExtSource_Base : IControllerExtensionSource
		{
			// Token: 0x1700090F RID: 2319
			// (get) Token: 0x0600268A RID: 9866 RVA: 0x0001C69B File Offset: 0x0001A89B
			public IDriver_NintendoSwitchController driver
			{
				get
				{
					return this._driver;
				}
			}

			// Token: 0x0600268B RID: 9867 RVA: 0x0001C6A3 File Offset: 0x0001A8A3
			public ExtSource_Base(IDriver_NintendoSwitchController A_1)
			{
				this._driver = A_1;
			}

			// Token: 0x040015ED RID: 5613
			private readonly IDriver_NintendoSwitchController _driver;
		}
	}
}
