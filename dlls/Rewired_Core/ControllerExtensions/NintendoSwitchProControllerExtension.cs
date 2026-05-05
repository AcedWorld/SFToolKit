using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003BF RID: 959
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchProControllerExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension
	{
		// Token: 0x17000910 RID: 2320
		// (get) Token: 0x0600268C RID: 9868 RVA: 0x0001C6B2 File Offset: 0x0001A8B2
		private new NintendoSwitchProControllerExtension.HIVLtOdopYERNANqogwVupLFDrYYA source
		{
			get
			{
				return base.source as NintendoSwitchProControllerExtension.HIVLtOdopYERNANqogwVupLFDrYYA;
			}
		}

		// Token: 0x0600268D RID: 9869 RVA: 0x0001C6BF File Offset: 0x0001A8BF
		internal NintendoSwitchProControllerExtension(IDriver_NintendoSwitchProController A_1) : base(new NintendoSwitchProControllerExtension.HIVLtOdopYERNANqogwVupLFDrYYA(A_1))
		{
		}

		// Token: 0x0600268E RID: 9870 RVA: 0x0001C6D4 File Offset: 0x0001A8D4
		private NintendoSwitchProControllerExtension(NintendoSwitchProControllerExtension A_1) : base(A_1)
		{
		}

		// Token: 0x0600268F RID: 9871 RVA: 0x0001C6E4 File Offset: 0x0001A8E4
		internal override Controller.Extension Clone()
		{
			return new NintendoSwitchProControllerExtension(this);
		}

		// Token: 0x040015EE RID: 5614
		public int motorIndexLeft;

		// Token: 0x040015EF RID: 5615
		public int motorIndexRight = 1;

		// Token: 0x020003C0 RID: 960
		private class HIVLtOdopYERNANqogwVupLFDrYYA : NintendoSwitchGamepadExtension.ExtSource_Base
		{
			// Token: 0x17000911 RID: 2321
			// (get) Token: 0x06002690 RID: 9872 RVA: 0x0001C6EC File Offset: 0x0001A8EC
			public IDriver_NintendoSwitchProController AKfgOezpQOGGaqzMXpHjZmjittAR
			{
				get
				{
					return base.driver as IDriver_NintendoSwitchProController;
				}
			}

			// Token: 0x06002691 RID: 9873 RVA: 0x0001C6F9 File Offset: 0x0001A8F9
			public HIVLtOdopYERNANqogwVupLFDrYYA(IDriver_NintendoSwitchProController A_1) : base(A_1)
			{
			}
		}
	}
}
