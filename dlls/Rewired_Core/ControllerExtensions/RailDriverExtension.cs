using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003C3 RID: 963
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
	{
		// Token: 0x17000916 RID: 2326
		// (get) Token: 0x0600269C RID: 9884 RVA: 0x00014B29 File Offset: 0x00012D29
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x0600269D RID: 9885 RVA: 0x0001C817 File Offset: 0x0001AA17
		internal RailDriverExtension(IDriver_RailDriver A_1) : base(new RailDriverExtension.LUpTmfmBYOHxctDaOEqyglHpGRBz(A_1))
		{
		}

		// Token: 0x0600269E RID: 9886 RVA: 0x0001B76B File Offset: 0x0001996B
		private RailDriverExtension(RailDriverExtension A_1) : base(A_1)
		{
		}

		// Token: 0x17000917 RID: 2327
		// (get) Token: 0x0600269F RID: 9887 RVA: 0x0001C825 File Offset: 0x0001AA25
		// (set) Token: 0x060026A0 RID: 9888 RVA: 0x0001C861 File Offset: 0x0001AA61
		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return false;
				}
				return this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx != null && this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return;
				}
				if (this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx == null)
				{
					return;
				}
				this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.SpeakerEnabled = value;
			}
		}

		// Token: 0x060026A1 RID: 9889 RVA: 0x00094B20 File Offset: 0x00092D20
		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx == null || !base.enabled)
			{
				return;
			}
			this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.SetLEDDisplay(digitIndex, digitBitValues);
		}

		// Token: 0x060026A2 RID: 9890 RVA: 0x00094B70 File Offset: 0x00092D70
		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != this._reInputId)
			{
				ReInput.CheckInitialized(this._reInputId);
				return;
			}
			if (this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx == null || !base.enabled)
			{
				return;
			}
			this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
		}

		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x060026A3 RID: 9891 RVA: 0x0001C89C File Offset: 0x0001AA9C
		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.vendorId;
			}
		}

		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x060026A4 RID: 9892 RVA: 0x0001C8C9 File Offset: 0x0001AAC9
		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.productId;
			}
		}

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x060026A5 RID: 9893 RVA: 0x0001C8F6 File Offset: 0x0001AAF6
		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				return this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.productName;
			}
		}

		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x060026A6 RID: 9894 RVA: 0x0001C927 File Offset: 0x0001AB27
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				return this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.manufacturer;
			}
		}

		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x060026A7 RID: 9895 RVA: 0x0001C958 File Offset: 0x0001AB58
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.usagePage;
			}
		}

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x060026A8 RID: 9896 RVA: 0x0001C985 File Offset: 0x0001AB85
		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				return this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA.ejRtvQTLBenCApmTwpZHNtahtDnx.usage;
			}
		}

		// Token: 0x060026A9 RID: 9897 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		// Token: 0x060026AA RID: 9898 RVA: 0x0001C9B2 File Offset: 0x0001ABB2
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.YBHUcXjDUfEZlGHcIjIDNKDVUeOHA = (source as RailDriverExtension.LUpTmfmBYOHxctDaOEqyglHpGRBz);
		}

		// Token: 0x060026AB RID: 9899 RVA: 0x0001C9C0 File Offset: 0x0001ABC0
		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}

		// Token: 0x040015F0 RID: 5616
		private RailDriverExtension.LUpTmfmBYOHxctDaOEqyglHpGRBz YBHUcXjDUfEZlGHcIjIDNKDVUeOHA;

		// Token: 0x020003C4 RID: 964
		private class LUpTmfmBYOHxctDaOEqyglHpGRBz : IControllerExtensionSource
		{
			// Token: 0x060026AC RID: 9900 RVA: 0x0001C9C8 File Offset: 0x0001ABC8
			public LUpTmfmBYOHxctDaOEqyglHpGRBz(IDriver_RailDriver A_1)
			{
				this.ejRtvQTLBenCApmTwpZHNtahtDnx = A_1;
			}

			// Token: 0x040015F1 RID: 5617
			public readonly IDriver_RailDriver ejRtvQTLBenCApmTwpZHNtahtDnx;
		}
	}
}
