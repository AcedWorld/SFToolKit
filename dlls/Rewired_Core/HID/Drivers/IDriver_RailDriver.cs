using System;
using Rewired.ControllerExtensions;

namespace Rewired.HID.Drivers
{
	// Token: 0x020001DE RID: 478
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IDriver_RailDriver : IControllerDriver, IHIDControllerExtension
	{
		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x0600189C RID: 6300
		// (set) Token: 0x0600189D RID: 6301
		bool SpeakerEnabled { get; set; }

		// Token: 0x0600189E RID: 6302
		void SetLEDDisplay(int digitIndex, byte digitBitValues);

		// Token: 0x0600189F RID: 6303
		void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues);
	}
}
