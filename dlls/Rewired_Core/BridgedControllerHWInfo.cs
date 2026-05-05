using System;
using Rewired.Platforms;

namespace Rewired
{
	// Token: 0x020000E0 RID: 224
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class BridgedControllerHWInfo
	{
		// Token: 0x0600074F RID: 1871 RVA: 0x000033F4 File Offset: 0x000015F4
		public BridgedControllerHWInfo()
		{
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0000834D File Offset: 0x0000654D
		public BridgedControllerHWInfo(BridgedControllerHWInfo A_1)
		{
			A_1.JeOBBccbTxGIPiYsxjzTVwGiTetPA(this);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0003C5A4 File Offset: 0x0003A7A4
		private void JeOBBccbTxGIPiYsxjzTVwGiTetPA(BridgedControllerHWInfo A_1)
		{
			A_1.isMock = this.isMock;
			A_1.inputManagerSource = this.inputManagerSource;
			A_1.inputSource = this.inputSource;
			A_1.deviceType = this.deviceType;
			A_1.hardwareIdentifier = this.hardwareIdentifier;
			A_1.hardwareAxisCount = this.hardwareAxisCount;
			A_1.hardwareButtonCount = this.hardwareButtonCount;
			A_1.hardwareHatCount = this.hardwareHatCount;
			A_1.hw_productName = this.hw_productName;
			A_1.hw_pidVid = this.hw_pidVid;
			A_1.hw_deviceGuid = this.hw_deviceGuid;
			A_1.hw_productId = this.hw_productId;
			A_1.hw_bluetoothDeviceName = this.hw_bluetoothDeviceName;
			A_1.hw_isBluetoothDevice = this.hw_isBluetoothDevice;
			A_1.hw_supportsVoice = this.hw_supportsVoice;
			A_1.hw_supportsVibration = this.hw_supportsVibration;
			A_1.hw_xInputSubType = this.hw_xInputSubType;
			A_1.hw_manufacturer = this.hw_manufacturer;
			A_1.hw_serialNumber = this.hw_serialNumber;
			A_1.hw_vendorId = this.hw_vendorId;
			A_1.hw_version = this.hw_version;
			A_1.hw_isSDL2Gamepad = this.hw_isSDL2Gamepad;
			A_1.webGL_webBrowserType = this.webGL_webBrowserType;
			A_1.webGL_osType = this.webGL_osType;
			A_1.webGL_mappingType = this.webGL_mappingType;
			A_1.hw_localVibrationMotorCount = this.hw_localVibrationMotorCount;
			A_1.definitionMatchTag = this.definitionMatchTag;
			A_1.userCustomIdentifier = this.userCustomIdentifier;
		}

		// Token: 0x040005D9 RID: 1497
		public bool isMock;

		// Token: 0x040005DA RID: 1498
		public InputSource inputManagerSource;

		// Token: 0x040005DB RID: 1499
		public InputSource inputSource;

		// Token: 0x040005DC RID: 1500
		public ControlDeviceType deviceType;

		// Token: 0x040005DD RID: 1501
		public string hardwareIdentifier;

		// Token: 0x040005DE RID: 1502
		public int hardwareAxisCount;

		// Token: 0x040005DF RID: 1503
		public int hardwareButtonCount;

		// Token: 0x040005E0 RID: 1504
		public int hardwareHatCount;

		// Token: 0x040005E1 RID: 1505
		public string hw_productName;

		// Token: 0x040005E2 RID: 1506
		public PidVid hw_pidVid;

		// Token: 0x040005E3 RID: 1507
		public Guid hw_deviceGuid;

		// Token: 0x040005E4 RID: 1508
		public int hw_productId;

		// Token: 0x040005E5 RID: 1509
		public string hw_bluetoothDeviceName;

		// Token: 0x040005E6 RID: 1510
		public bool hw_isBluetoothDevice;

		// Token: 0x040005E7 RID: 1511
		public bool hw_supportsVoice;

		// Token: 0x040005E8 RID: 1512
		public bool hw_supportsVibration;

		// Token: 0x040005E9 RID: 1513
		public XInputDeviceSubType hw_xInputSubType;

		// Token: 0x040005EA RID: 1514
		public string hw_manufacturer;

		// Token: 0x040005EB RID: 1515
		public string hw_serialNumber;

		// Token: 0x040005EC RID: 1516
		public int hw_vendorId;

		// Token: 0x040005ED RID: 1517
		public int hw_version;

		// Token: 0x040005EE RID: 1518
		public string hw_systemDeviceName;

		// Token: 0x040005EF RID: 1519
		public bool hw_isSDL2Gamepad;

		// Token: 0x040005F0 RID: 1520
		public WebGLWebBrowserType webGL_webBrowserType;

		// Token: 0x040005F1 RID: 1521
		public WebGLOSType webGL_osType;

		// Token: 0x040005F2 RID: 1522
		public WebGLGamepadMappingType webGL_mappingType;

		// Token: 0x040005F3 RID: 1523
		public string[] webGL_webBrowserVersionSplit;

		// Token: 0x040005F4 RID: 1524
		public string[] webGL_osVersionSplit;

		// Token: 0x040005F5 RID: 1525
		public int hw_localVibrationMotorCount;

		// Token: 0x040005F6 RID: 1526
		public string definitionMatchTag;

		// Token: 0x040005F7 RID: 1527
		public object userCustomIdentifier;
	}
}
