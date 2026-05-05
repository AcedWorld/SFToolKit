using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	// Token: 0x0200031C RID: 796
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchJoyConDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchJoyCon, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x0600174A RID: 5962 RVA: 0x0001D3D0 File Offset: 0x0001B5D0
		protected byte[] buttonAxisReadBuffer
		{
			get
			{
				return this.zOfMbpipluWpeFhTgIdwQFhfeRYd;
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x0600174B RID: 5963
		protected abstract int byteIndexStartSticks { get; }

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x0600174C RID: 5964 RVA: 0x0001D3D8 File Offset: 0x0001B5D8
		public NintendoSwitchJoyConType joyConType
		{
			get
			{
				return this.WWOvIbZLRdOhIeqsushFLyxFinNe;
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x0600174D RID: 5965 RVA: 0x0001D3E0 File Offset: 0x0001B5E0
		// (set) Token: 0x0600174E RID: 5966 RVA: 0x0001D3E8 File Offset: 0x0001B5E8
		public NintendoSwitchJoyConGripStyle joyConGripStyle
		{
			get
			{
				return this.JrDCnYDXDoXLfWxvpERKVkrMrFqEA;
			}
			set
			{
				this.JrDCnYDXDoXLfWxvpERKVkrMrFqEA = value;
			}
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x0001D3F1 File Offset: 0x0001B5F1
		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
		{
			if (elementIndex < 0 || elementIndex > 1)
			{
				return elementIndex;
			}
			if (this.JrDCnYDXDoXLfWxvpERKVkrMrFqEA != NintendoSwitchJoyConGripStyle.Vertical)
			{
				return elementIndex;
			}
			if (elementIndex == 0)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x000528B4 File Offset: 0x00050AB4
		protected NintendoSwitchJoyConDriver(HIDDeviceDriver.InitArgs A_1, NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA A_2) : base(A_1, A_2, 11, 2, 1)
		{
			if (A_2 != NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.JoyConLeft && A_2 != NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.JoyConRight)
			{
				throw new ArgumentException("controllerType");
			}
			this.WWOvIbZLRdOhIeqsushFLyxFinNe = ((A_2 == NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.JoyConLeft) ? NintendoSwitchJoyConType.Left : NintendoSwitchJoyConType.Right);
			this.JrDCnYDXDoXLfWxvpERKVkrMrFqEA = NintendoSwitchJoyConGripStyle.Horizontal;
			this.vQIFLFxBJAXtLrNpNAvBbdJMFqAdA = new NativeBuffer(5);
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
				}, false, 32767)
			};
			base.Initialize();
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0001D40D File Offset: 0x0001B60D
		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchJoyConExtension(this);
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x000529E4 File Offset: 0x00050BE4
		protected override void UpdateElements(zHTBvVyhFGDLpEJMFINchPNfqnfnb[] elements, NativeBuffer inputReport, double timestamp)
		{
			byte[] array = this.zOfMbpipluWpeFhTgIdwQFhfeRYd;
			inputReport.Read(array, 3, this.byteIndexStartSticks, 0);
			ushort valueX = (ushort)((int)array[0] | (int)(array[1] & 15) << 8);
			ushort valueY = (ushort)(array[1] >> 4 | (int)array[2] << 4);
			ushort bytes;
			ushort bytes2;
			base.GetCalibratedStickValue(valueX, valueY, base.GetAxisCalibration(0), base.GetAxisCalibration(1), out bytes, out bytes2);
			this.HandleGripStyleStickAxisSwap(ref bytes, ref bytes2);
			this.vQIFLFxBJAXtLrNpNAvBbdJMFqAdA.Write(33, 0);
			this.vQIFLFxBJAXtLrNpNAvBbdJMFqAdA.Write(bytes, 1);
			this.vQIFLFxBJAXtLrNpNAvBbdJMFqAdA.Write(bytes2, 3);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].WMAwtKiWRygWRqyRkTqlMnhmDEdgA(this.vQIFLFxBJAXtLrNpNAvBbdJMFqAdA, timestamp);
			}
		}

		// Token: 0x06001753 RID: 5971
		protected abstract void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY);

		// Token: 0x06001754 RID: 5972 RVA: 0x00052A94 File Offset: 0x00050C94
		~NintendoSwitchJoyConDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x0001D415 File Offset: 0x0001B615
		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			if (disposing && this.vQIFLFxBJAXtLrNpNAvBbdJMFqAdA != null)
			{
				this.vQIFLFxBJAXtLrNpNAvBbdJMFqAdA.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x040032E6 RID: 13030
		private const int gkasslKgBiZxoiyCtQLjzewaVpEb = 11;

		// Token: 0x040032E7 RID: 13031
		private const int wAlEtUkdvBtIASyvwGbFsGgjhTIiA = 2;

		// Token: 0x040032E8 RID: 13032
		private const int PjqtKbRMcngIYSVivKEOhAcXoyle = 1;

		// Token: 0x040032E9 RID: 13033
		private const int gUylPxCiuFMisAAGJrMgmLmBcoQdA = 1;

		// Token: 0x040032EA RID: 13034
		private const int qPPCCWdocIJNuyEPIDELGsSNCWjf = 3;

		// Token: 0x040032EB RID: 13035
		private readonly NativeBuffer vQIFLFxBJAXtLrNpNAvBbdJMFqAdA;

		// Token: 0x040032EC RID: 13036
		private readonly NintendoSwitchJoyConType WWOvIbZLRdOhIeqsushFLyxFinNe;

		// Token: 0x040032ED RID: 13037
		private NintendoSwitchJoyConGripStyle JrDCnYDXDoXLfWxvpERKVkrMrFqEA;

		// Token: 0x040032EE RID: 13038
		private readonly byte[] zOfMbpipluWpeFhTgIdwQFhfeRYd = new byte[3];
	}
}
