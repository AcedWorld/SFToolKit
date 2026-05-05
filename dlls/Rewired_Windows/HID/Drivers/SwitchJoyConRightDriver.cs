using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	// Token: 0x0200031E RID: 798
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SwitchJoyConRightDriver : NintendoSwitchJoyConDriver
	{
		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x0600175D RID: 5981 RVA: 0x0001D472 File Offset: 0x0001B672
		protected override int byteIndexStartSticks
		{
			get
			{
				return 9;
			}
		}

		// Token: 0x0600175E RID: 5982 RVA: 0x0001D476 File Offset: 0x0001B676
		public SwitchJoyConRightDriver(HIDDeviceDriver.InitArgs A_1) : base(A_1, NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.JoyConRight)
		{
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x00052C84 File Offset: 0x00050E84
		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
			byte[] buttonAxisReadBuffer = base.buttonAxisReadBuffer;
			inputReport.Read(buttonAxisReadBuffer, 2, 3, 0);
			byte b = buttonAxisReadBuffer[0];
			this.buttons[0].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 8) > 0, timestamp);
			this.buttons[1].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 2) > 0, timestamp);
			this.buttons[2].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 4) > 0, timestamp);
			this.buttons[3].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 1) > 0, timestamp);
			this.buttons[4].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 32) > 0, timestamp);
			this.buttons[5].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 16) > 0, timestamp);
			this.buttons[6].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 64) > 0, timestamp);
			this.buttons[7].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 128) > 0, timestamp);
			b = buttonAxisReadBuffer[1];
			this.buttons[8].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 2) > 0, timestamp);
			this.buttons[9].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 16) > 0, timestamp);
			this.buttons[10].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 4) > 0, timestamp);
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x00052D90 File Offset: 0x00050F90
		protected override void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY)
		{
			if (base.joyConGripStyle == NintendoSwitchJoyConGripStyle.Horizontal)
			{
				ushort num = stickY;
				stickY = ushort.MaxValue - stickX;
				stickX = num;
			}
		}

		// Token: 0x06001761 RID: 5985 RVA: 0x00052C54 File Offset: 0x00050E54
		~SwitchJoyConRightDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x06001762 RID: 5986 RVA: 0x0001D44A File Offset: 0x0001B64A
		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x0001D480 File Offset: 0x0001B680
		public static bool Matches(int vid, int pid)
		{
			return vid == 1406 && pid == 8199;
		}

		// Token: 0x040032F1 RID: 13041
		private const int sCBBPpVYHqaApDtEHZwyTZlaxdtK = 3;

		// Token: 0x040032F2 RID: 13042
		private const int apaMNhFSrkjQXVHNVsiDpoWQZkEO = 9;
	}
}
