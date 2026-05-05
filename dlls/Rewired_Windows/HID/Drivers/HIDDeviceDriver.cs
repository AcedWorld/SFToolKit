using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Utils;

namespace Rewired.HID.Drivers
{
	// Token: 0x02000311 RID: 785
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class HIDDeviceDriver : IControllerDriver, IDisposable
	{
		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x060016F6 RID: 5878 RVA: 0x0001CFE1 File Offset: 0x0001B1E1
		public int AxisCount
		{
			get
			{
				if (this.axes == null)
				{
					return 0;
				}
				return this.axes.Length;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x060016F7 RID: 5879 RVA: 0x0001CFF5 File Offset: 0x0001B1F5
		public int ButtonCount
		{
			get
			{
				if (this.buttons == null)
				{
					return 0;
				}
				return this.buttons.Length;
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x060016F8 RID: 5880 RVA: 0x0001D009 File Offset: 0x0001B209
		public int HatCount
		{
			get
			{
				if (this.hats == null)
				{
					return 0;
				}
				return this.hats.Length;
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x060016F9 RID: 5881 RVA: 0x0001D01D File Offset: 0x0001B21D
		public int AccelerometerCount
		{
			get
			{
				if (this.accelerometers == null)
				{
					return 0;
				}
				return this.accelerometers.Length;
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x060016FA RID: 5882 RVA: 0x0001D031 File Offset: 0x0001B231
		public int GyroscopeCount
		{
			get
			{
				if (this.gyroscopes == null)
				{
					return 0;
				}
				return this.gyroscopes.Length;
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x060016FB RID: 5883 RVA: 0x0001D045 File Offset: 0x0001B245
		public int TouchpadCount
		{
			get
			{
				if (this.touchpads == null)
				{
					return 0;
				}
				return this.touchpads.Length;
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x060016FC RID: 5884 RVA: 0x0001D059 File Offset: 0x0001B259
		public int LightCount
		{
			get
			{
				if (this.lights == null)
				{
					return 0;
				}
				return this.lights.Length;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x060016FD RID: 5885 RVA: 0x0001D06D File Offset: 0x0001B26D
		public int VibrationMotorCount
		{
			get
			{
				if (this.vibrationMotors == null)
				{
					return 0;
				}
				return this.vibrationMotors.Length;
			}
		}

		// Token: 0x060016FE RID: 5886 RVA: 0x000114A8 File Offset: 0x0000F6A8
		public HIDDeviceDriver()
		{
		}

		// Token: 0x060016FF RID: 5887
		public abstract void Update(UpdateLoopType updateLoop);

		// Token: 0x06001700 RID: 5888
		public abstract bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp);

		// Token: 0x06001701 RID: 5889
		public abstract Controller.Extension CreateControllerExtension();

		// Token: 0x06001702 RID: 5890 RVA: 0x000513B0 File Offset: 0x0004F5B0
		public static HIDDeviceDriver GetDriver(HIDDeviceDriver.DriverType driverId, HIDDeviceDriver.InitArgs hidDriverInitArgs)
		{
			if (hidDriverInitArgs == null)
			{
				return null;
			}
			switch (driverId)
			{
			case HIDDeviceDriver.DriverType.DualShock4:
				if (UnityTools.effectivePlatform == Platform.Linux)
				{
					return null;
				}
				return new DualShock4Driver(hidDriverInitArgs);
			case HIDDeviceDriver.DriverType.DualSense:
				return new DualSenseDriver(hidDriverInitArgs);
			case HIDDeviceDriver.DriverType.RailDriver:
				return new RailDriverDriver(hidDriverInitArgs);
			case HIDDeviceDriver.DriverType.SwitchJoyConLeft:
				return new NintendoSwitchJoyConLeftDriver(hidDriverInitArgs);
			case HIDDeviceDriver.DriverType.SwitchJoyConRight:
				return new SwitchJoyConRightDriver(hidDriverInitArgs);
			case HIDDeviceDriver.DriverType.SwitchProController:
				if (hidDriverInitArgs.connectionType != srhddSmbipxLrwlIqjetZPjyhATp.Bluetooth)
				{
					return null;
				}
				return new NintendoSwitchProControllerDriver(hidDriverInitArgs);
			default:
				return null;
			}
		}

		// Token: 0x06001703 RID: 5891 RVA: 0x00051424 File Offset: 0x0004F624
		public static HIDDeviceDriver.DriverType FindDriverId(int vendorId, int productId, IList<EnhancedDeviceSupportDeviceType> exclusions)
		{
			if (DualShock4Driver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.SonyDualShock4))
				{
					return HIDDeviceDriver.DriverType.None;
				}
				return HIDDeviceDriver.DriverType.DualShock4;
			}
			else if (DualSenseDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.SonyDualSense))
				{
					return HIDDeviceDriver.DriverType.None;
				}
				return HIDDeviceDriver.DriverType.DualSense;
			}
			else if (RailDriverDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.PIEngineeringRailDriver))
				{
					return HIDDeviceDriver.DriverType.None;
				}
				return HIDDeviceDriver.DriverType.RailDriver;
			}
			else if (NintendoSwitchJoyConLeftDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchJoyConLeft))
				{
					return HIDDeviceDriver.DriverType.None;
				}
				return HIDDeviceDriver.DriverType.SwitchJoyConLeft;
			}
			else if (SwitchJoyConRightDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchJoyConRight))
				{
					return HIDDeviceDriver.DriverType.None;
				}
				return HIDDeviceDriver.DriverType.SwitchJoyConRight;
			}
			else
			{
				if (!NintendoSwitchProControllerDriver.Matches(vendorId, productId))
				{
					return HIDDeviceDriver.DriverType.None;
				}
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchProController))
				{
					return HIDDeviceDriver.DriverType.None;
				}
				return HIDDeviceDriver.DriverType.SwitchProController;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x0001D081 File Offset: 0x0001B281
		protected bool disposed
		{
			get
			{
				return this.tYrcvFXgggWAFBcHbfKLMluvzDZl;
			}
		}

		// Token: 0x06001705 RID: 5893 RVA: 0x0001D089 File Offset: 0x0001B289
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001706 RID: 5894 RVA: 0x000514D0 File Offset: 0x0004F6D0
		~HIDDeviceDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x06001707 RID: 5895 RVA: 0x0001D098 File Offset: 0x0001B298
		protected virtual void Dispose(bool disposing)
		{
			if (this.tYrcvFXgggWAFBcHbfKLMluvzDZl)
			{
				return;
			}
			this.tYrcvFXgggWAFBcHbfKLMluvzDZl = true;
		}

		// Token: 0x04003258 RID: 12888
		public WlBhllbxXziYUoZmsblPearfaCpbA[] axes;

		// Token: 0x04003259 RID: 12889
		public bsHiSnxdPKGTmlVVXzABmREfuPAX[] buttons;

		// Token: 0x0400325A RID: 12890
		public oPOwiIBMGNECtKWjLBTodfZcpRzbB[] hats;

		// Token: 0x0400325B RID: 12891
		public VowBBGCdjJGeVmPjtscFISvyEvTtA[] accelerometers;

		// Token: 0x0400325C RID: 12892
		public TDbKvyrtcOKmakPyYMqLcuNLqPbe[] gyroscopes;

		// Token: 0x0400325D RID: 12893
		public zwWEPIBfQQjvcFGMdkkFNKDGwfdgA[] touchpads;

		// Token: 0x0400325E RID: 12894
		public UnptiYUxBEDyXRujUEnkdeIKIoPk[] vibrationMotors;

		// Token: 0x0400325F RID: 12895
		public XKforwyiippWnEqzvPiJMMmSIoUfA[] lights;

		// Token: 0x04003260 RID: 12896
		private bool tYrcvFXgggWAFBcHbfKLMluvzDZl;

		// Token: 0x02000312 RID: 786
		[CustomObfuscation(rename = false)]
		public enum DriverType
		{
			// Token: 0x04003262 RID: 12898
			None,
			// Token: 0x04003263 RID: 12899
			DualShock4,
			// Token: 0x04003264 RID: 12900
			DualSense,
			// Token: 0x04003265 RID: 12901
			RailDriver,
			// Token: 0x04003266 RID: 12902
			SwitchJoyConLeft,
			// Token: 0x04003267 RID: 12903
			SwitchJoyConRight,
			// Token: 0x04003268 RID: 12904
			SwitchProController
		}

		// Token: 0x02000313 RID: 787
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal struct HIDProperties
		{
			// Token: 0x06001708 RID: 5896 RVA: 0x00051500 File Offset: 0x0004F700
			public HIDProperties(ushort A_1, ushort A_2, string A_3, string A_4, ushort A_5, ushort A_6, int A_7, int A_8, int A_9)
			{
				this.vendorId = A_1;
				this.productId = A_2;
				this.productName = A_3;
				this.manufacturer = A_4;
				this.usagePage = A_5;
				this.usage = A_6;
				this.maxInputReportLength = A_7;
				this.maxOutputReportLength = A_8;
				this.maxFeatureReportLength = A_9;
			}

			// Token: 0x04003269 RID: 12905
			public ushort vendorId;

			// Token: 0x0400326A RID: 12906
			public ushort productId;

			// Token: 0x0400326B RID: 12907
			public string productName;

			// Token: 0x0400326C RID: 12908
			public string manufacturer;

			// Token: 0x0400326D RID: 12909
			public ushort usagePage;

			// Token: 0x0400326E RID: 12910
			public ushort usage;

			// Token: 0x0400326F RID: 12911
			public int maxInputReportLength;

			// Token: 0x04003270 RID: 12912
			public int maxOutputReportLength;

			// Token: 0x04003271 RID: 12913
			public int maxFeatureReportLength;
		}

		// Token: 0x02000314 RID: 788
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface IHIDDevice
		{
			// Token: 0x170003B9 RID: 953
			// (get) Token: 0x06001709 RID: 5897
			HIDDeviceDriver.HIDProperties properties { get; }

			// Token: 0x0600170A RID: 5898
			bool WriteSync(AWHWYMjOaGiEqJCCtAEpfhRJAtYq outputReport, int timeoutMs);

			// Token: 0x0600170B RID: 5899
			void WriteAsync(AWHWYMjOaGiEqJCCtAEpfhRJAtYq outputReport, int timeoutMs);

			// Token: 0x0600170C RID: 5900
			bool ReadSync(IntPtr buffer, int bytesToRead, int timeoutMs);

			// Token: 0x0600170D RID: 5901
			byte[] GetHidFeatureData(byte reportId, int reportLength, int timeoutMs, int retryCount);
		}

		// Token: 0x02000315 RID: 789
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal class InitArgs
		{
			// Token: 0x0600170E RID: 5902 RVA: 0x0001D0AC File Offset: 0x0001B2AC
			public InitArgs(UpdateLoopSetting A_1, srhddSmbipxLrwlIqjetZPjyhATp A_2, int A_3, int A_4, int A_5, int A_6, HIDDeviceDriver.IHIDDevice A_7)
			{
				this.updateLoopSetting = A_1;
				this.connectionType = A_2;
				this.minAxisValue = A_3;
				this.maxAxisValue = A_4;
				this.hatZeroValue = A_5;
				this.hatSpan = A_6;
				this.hidDevice = A_7;
			}

			// Token: 0x04003272 RID: 12914
			public readonly UpdateLoopSetting updateLoopSetting;

			// Token: 0x04003273 RID: 12915
			public readonly srhddSmbipxLrwlIqjetZPjyhATp connectionType;

			// Token: 0x04003274 RID: 12916
			public readonly int minAxisValue;

			// Token: 0x04003275 RID: 12917
			public readonly int maxAxisValue;

			// Token: 0x04003276 RID: 12918
			public readonly int hatZeroValue;

			// Token: 0x04003277 RID: 12919
			public readonly int hatSpan;

			// Token: 0x04003278 RID: 12920
			public readonly HIDDeviceDriver.IHIDDevice hidDevice;
		}
	}
}
