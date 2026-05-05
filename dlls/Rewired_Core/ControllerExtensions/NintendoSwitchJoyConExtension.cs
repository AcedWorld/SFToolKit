using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003C1 RID: 961
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		// Token: 0x17000912 RID: 2322
		// (get) Token: 0x06002692 RID: 9874 RVA: 0x0001C702 File Offset: 0x0001A902
		private new NintendoSwitchJoyConExtension.mNCOkpdWthtGZiGAgRvhINukxSfo source
		{
			get
			{
				return base.source as NintendoSwitchJoyConExtension.mNCOkpdWthtGZiGAgRvhINukxSfo;
			}
		}

		// Token: 0x06002693 RID: 9875 RVA: 0x0001C70F File Offset: 0x0001A90F
		internal NintendoSwitchJoyConExtension(IDriver_NintendoSwitchJoyCon A_1) : base(new NintendoSwitchJoyConExtension.mNCOkpdWthtGZiGAgRvhINukxSfo(A_1))
		{
		}

		// Token: 0x06002694 RID: 9876 RVA: 0x0001C71D File Offset: 0x0001A91D
		private NintendoSwitchJoyConExtension(NintendoSwitchJoyConExtension A_1) : base(A_1)
		{
		}

		// Token: 0x17000913 RID: 2323
		// (get) Token: 0x06002695 RID: 9877 RVA: 0x0001C726 File Offset: 0x0001A926
		public NintendoSwitchJoyConType joyConType
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return NintendoSwitchJoyConType.Right;
				}
				if (!base.isValid)
				{
					return NintendoSwitchJoyConType.Left;
				}
				return this.source.QRyfoREGbfzKdfEgfJevvbJULWlmA.joyConType;
			}
		}

		// Token: 0x17000914 RID: 2324
		// (get) Token: 0x06002696 RID: 9878 RVA: 0x0001C75D File Offset: 0x0001A95D
		// (set) Token: 0x06002697 RID: 9879 RVA: 0x0001C794 File Offset: 0x0001A994
		public NintendoSwitchJoyConGripStyle joyConGripStyle
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return NintendoSwitchJoyConGripStyle.Horizontal;
				}
				if (!base.isValid)
				{
					return NintendoSwitchJoyConGripStyle.Horizontal;
				}
				return this.source.QRyfoREGbfzKdfEgfJevvbJULWlmA.joyConGripStyle;
			}
			set
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return;
				}
				if (!base.isValid)
				{
					return;
				}
				this.source.QRyfoREGbfzKdfEgfJevvbJULWlmA.joyConGripStyle = value;
			}
		}

		// Token: 0x06002698 RID: 9880 RVA: 0x0001C7CA File Offset: 0x0001A9CA
		int IAxisCalibrationIndexMap.XFarTmLvEYvrCvrjOOGWFwWDJKGP(int A_1)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return A_1;
			}
			if (!base.isValid)
			{
				return A_1;
			}
			return this.source.QRyfoREGbfzKdfEgfJevvbJULWlmA.GetMappedAxisIndex(A_1);
		}

		// Token: 0x06002699 RID: 9881 RVA: 0x0001C802 File Offset: 0x0001AA02
		internal override Controller.Extension Clone()
		{
			return new NintendoSwitchJoyConExtension(this);
		}

		// Token: 0x020003C2 RID: 962
		private class mNCOkpdWthtGZiGAgRvhINukxSfo : NintendoSwitchGamepadExtension.ExtSource_Base
		{
			// Token: 0x17000915 RID: 2325
			// (get) Token: 0x0600269A RID: 9882 RVA: 0x0001C80A File Offset: 0x0001AA0A
			public IDriver_NintendoSwitchJoyCon QRyfoREGbfzKdfEgfJevvbJULWlmA
			{
				get
				{
					return base.driver as IDriver_NintendoSwitchJoyCon;
				}
			}

			// Token: 0x0600269B RID: 9883 RVA: 0x0001C6F9 File Offset: 0x0001A8F9
			public mNCOkpdWthtGZiGAgRvhINukxSfo(IDriver_NintendoSwitchJoyCon A_1) : base(A_1)
			{
			}
		}
	}
}
