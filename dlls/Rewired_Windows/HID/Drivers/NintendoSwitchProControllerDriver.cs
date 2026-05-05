using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	// Token: 0x0200031F RID: 799
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		// Token: 0x06001764 RID: 5988 RVA: 0x00052DB8 File Offset: 0x00050FB8
		public NintendoSwitchProControllerDriver(HIDDeviceDriver.InitArgs A_1) : base(A_1, NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.ProController, 18, 4, 2)
		{
			this.hwMwKmySfPrlLndRmTHPyGJBVHAH = new NativeBuffer(9);
			this.axes = new WlBhllbxXziYUoZmsblPearfaCpbA[]
			{
				new WlBhllbxXziYUoZmsblPearfaCpbA(33, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 32767),
				new WlBhllbxXziYUoZmsblPearfaCpbA(33, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 3,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 32767),
				new WlBhllbxXziYUoZmsblPearfaCpbA(33, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 5,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 32767),
				new WlBhllbxXziYUoZmsblPearfaCpbA(33, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 7,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 32767)
			};
			base.Initialize();
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x0001D494 File Offset: 0x0001B694
		public override void Update(UpdateLoopType updateLoop)
		{
			base.Update(updateLoop);
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x0001D49D File Offset: 0x0001B69D
		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchProControllerExtension(this);
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x00052F80 File Offset: 0x00051180
		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB, 3, 3, 0);
			this.buttons[0].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[0] & 4) > 0, timestamp);
			this.buttons[1].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[0] & 8) > 0, timestamp);
			this.buttons[2].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[0] & 1) > 0, timestamp);
			this.buttons[3].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[0] & 2) > 0, timestamp);
			this.buttons[4].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[2] & 64) > 0, timestamp);
			this.buttons[5].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[0] & 64) > 0, timestamp);
			this.buttons[6].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[2] & 128) > 0, timestamp);
			this.buttons[7].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[0] & 128) > 0, timestamp);
			this.buttons[8].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[1] & 1) > 0, timestamp);
			this.buttons[9].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[1] & 2) > 0, timestamp);
			this.buttons[10].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[1] & 32) > 0, timestamp);
			this.buttons[11].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[1] & 16) > 0, timestamp);
			this.buttons[12].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[1] & 8) > 0, timestamp);
			this.buttons[13].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[1] & 4) > 0, timestamp);
			this.buttons[14].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[2] & 2) > 0, timestamp);
			this.buttons[15].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[2] & 4) > 0, timestamp);
			this.buttons[16].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[2] & 1) > 0, timestamp);
			this.buttons[17].dcmdjPVjtigsiROYEiHxGPMPgEOn((this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB[2] & 8) > 0, timestamp);
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x00053198 File Offset: 0x00051398
		protected override void UpdateElements(zHTBvVyhFGDLpEJMFINchPNfqnfnb[] elements, NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB, 6, 6, 0);
			byte[] array = this.rSVvCdosUaGrvFJxbgMcDtlDmuBWB;
			int num = 0;
			ushort valueX = (ushort)((int)array[num] | (int)(array[1 + num] & 15) << 8);
			ushort valueY = (ushort)(array[1 + num] >> 4 | (int)array[2 + num] << 4);
			num = 3;
			ushort valueX2 = (ushort)((int)array[num] | (int)(array[1 + num] & 15) << 8);
			ushort valueY2 = (ushort)(array[1 + num] >> 4 | (int)array[2 + num] << 4);
			ushort bytes;
			ushort bytes2;
			base.GetCalibratedStickValue(valueX, valueY, base.GetAxisCalibration(0), base.GetAxisCalibration(1), out bytes, out bytes2);
			ushort bytes3;
			ushort bytes4;
			base.GetCalibratedStickValue(valueX2, valueY2, base.GetAxisCalibration(2), base.GetAxisCalibration(3), out bytes3, out bytes4);
			this.hwMwKmySfPrlLndRmTHPyGJBVHAH.Write(33, 0);
			this.hwMwKmySfPrlLndRmTHPyGJBVHAH.Write(bytes, 1);
			this.hwMwKmySfPrlLndRmTHPyGJBVHAH.Write(bytes2, 3);
			this.hwMwKmySfPrlLndRmTHPyGJBVHAH.Write(bytes3, 5);
			this.hwMwKmySfPrlLndRmTHPyGJBVHAH.Write(bytes4, 7);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].WMAwtKiWRygWRqyRkTqlMnhmDEdgA(this.hwMwKmySfPrlLndRmTHPyGJBVHAH, timestamp);
			}
		}

		// Token: 0x06001769 RID: 5993 RVA: 0x00052A94 File Offset: 0x00050C94
		~NintendoSwitchProControllerDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x0600176A RID: 5994 RVA: 0x0001D4A5 File Offset: 0x0001B6A5
		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			if (disposing && this.hwMwKmySfPrlLndRmTHPyGJBVHAH != null)
			{
				this.hwMwKmySfPrlLndRmTHPyGJBVHAH.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600176B RID: 5995 RVA: 0x0001D4CD File Offset: 0x0001B6CD
		public static bool Matches(int vid, int pid)
		{
			return vid == 1406 && pid == 8201;
		}

		// Token: 0x040032F3 RID: 13043
		private const int HUrnZULDcDcblSewzhqJGnqIYmRQ = 18;

		// Token: 0x040032F4 RID: 13044
		private const int MpIePcAiFkhRkBUVglKJkdFOpGAhb = 4;

		// Token: 0x040032F5 RID: 13045
		private const int QXloTaJgmkJVgfeWyWvAwjDkjnaz = 2;

		// Token: 0x040032F6 RID: 13046
		private const int dHliZldOCBfxmxrMdQJiAHDJFNci = 3;

		// Token: 0x040032F7 RID: 13047
		private const int LjWvyuHhqeBkWhiAAYUFcjniIQkC = 6;

		// Token: 0x040032F8 RID: 13048
		private const int PNIvKGDGIRGHSwTVmfsrJEUiWutT = 1;

		// Token: 0x040032F9 RID: 13049
		private const int MIUbPNFNMIseMaBpoteObNKDtDQU = 3;

		// Token: 0x040032FA RID: 13050
		private const int eIsfXdmvgrvPufxpOdrBuCEmvVuO = 5;

		// Token: 0x040032FB RID: 13051
		private const int UbaiBgOonAEPAWEKSDcdPjgREJSCA = 7;

		// Token: 0x040032FC RID: 13052
		private readonly byte[] rSVvCdosUaGrvFJxbgMcDtlDmuBWB = new byte[6];

		// Token: 0x040032FD RID: 13053
		private readonly NativeBuffer hwMwKmySfPrlLndRmTHPyGJBVHAH;
	}
}
