using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	// Token: 0x0200031D RID: 797
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchJoyConLeftDriver : NintendoSwitchJoyConDriver
	{
		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06001756 RID: 5974 RVA: 0x0001D43D File Offset: 0x0001B63D
		protected override int byteIndexStartSticks
		{
			get
			{
				return 6;
			}
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x0001D440 File Offset: 0x0001B640
		public NintendoSwitchJoyConLeftDriver(HIDDeviceDriver.InitArgs A_1) : base(A_1, NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.JoyConLeft)
		{
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x00052AC4 File Offset: 0x00050CC4
		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
			byte[] buttonAxisReadBuffer = base.buttonAxisReadBuffer;
			inputReport.Read(buttonAxisReadBuffer, 2, 4, 0);
			byte b = buttonAxisReadBuffer[1];
			if (base.joyConGripStyle == NintendoSwitchJoyConGripStyle.Horizontal)
			{
				this.buttons[0].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 8) > 0, timestamp);
				this.buttons[1].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 1) > 0, timestamp);
				this.buttons[2].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 2) > 0, timestamp);
				this.buttons[3].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 4) > 0, timestamp);
			}
			else
			{
				this.buttons[0].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 1) > 0, timestamp);
				this.buttons[1].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 4) > 0, timestamp);
				this.buttons[2].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 8) > 0, timestamp);
				this.buttons[3].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 2) > 0, timestamp);
			}
			this.buttons[4].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 32) > 0, timestamp);
			this.buttons[5].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 16) > 0, timestamp);
			this.buttons[6].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 64) > 0, timestamp);
			this.buttons[7].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 128) > 0, timestamp);
			b = buttonAxisReadBuffer[0];
			this.buttons[8].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 1) > 0, timestamp);
			this.buttons[9].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 32) > 0, timestamp);
			this.buttons[10].dcmdjPVjtigsiROYEiHxGPMPgEOn((b & 8) > 0, timestamp);
		}

		// Token: 0x06001759 RID: 5977 RVA: 0x00052C2C File Offset: 0x00050E2C
		protected override void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY)
		{
			if (base.joyConGripStyle == NintendoSwitchJoyConGripStyle.Horizontal)
			{
				ushort num = stickY;
				stickY = stickX;
				stickX = ushort.MaxValue - num;
			}
		}

		// Token: 0x0600175A RID: 5978 RVA: 0x00052C54 File Offset: 0x00050E54
		~NintendoSwitchJoyConLeftDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x0001D44A File Offset: 0x0001B64A
		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600175C RID: 5980 RVA: 0x0001D45E File Offset: 0x0001B65E
		public static bool Matches(int vid, int pid)
		{
			return vid == 1406 && pid == 8198;
		}

		// Token: 0x040032EF RID: 13039
		private const int WsjHbMhULaWTffADOjOkheTbyMmQ = 4;

		// Token: 0x040032F0 RID: 13040
		private const int WPigoOWVgqAOWvRyKRSOHycBDzcA = 6;
	}
}
