using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	// Token: 0x020000B1 RID: 177
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x00012BF6 File Offset: 0x00010DF6
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x000144EC File Offset: 0x000126EC
		internal WindowsGamingInputControllerExtension(cWYIDMjUnhAyDysKZVfQnpWFBosr A_1) : base(new WindowsGamingInputControllerExtension.JMCPulNXMgottFPxGCKUCFcsOKjd(A_1))
		{
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00012C0C File Offset: 0x00010E0C
		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension A_1) : base(A_1)
		{
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x000144FA File Offset: 0x000126FA
		public DeviceType deviceType
		{
			get
			{
				return (DeviceType)this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.TSMfrUQJevmaGAlSJIgaOuzacxLE;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000661 RID: 1633 RVA: 0x000351D4 File Offset: 0x000333D4
		public IntPtr nativePointer
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return IntPtr.Zero;
				}
				if (!this.JhLHTAOAMlgxTZPWxWKJglJMLcTh || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb == null)
				{
					return IntPtr.Zero;
				}
				return this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.XVHvXppHcuRGHoTPtHIMCcZTQBvX;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0003523C File Offset: 0x0003343C
		public string nonRoamableId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.JhLHTAOAMlgxTZPWxWKJglJMLcTh || !base.enabled)
				{
					return string.Empty;
				}
				if (this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb == null)
				{
					return string.Empty;
				}
				return this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.YtGeBMQHdLuRTtWLxOQBgwCcsNgn;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x000352A4 File Offset: 0x000334A4
		public bool isWireless
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return false;
				}
				return this.JhLHTAOAMlgxTZPWxWKJglJMLcTh && base.enabled && this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb != null && this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.wasEUKQTUvxVKJCemghPBnlHMpmM;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00035300 File Offset: 0x00033500
		public string productName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.JhLHTAOAMlgxTZPWxWKJglJMLcTh || !base.enabled)
				{
					return string.Empty;
				}
				if (this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb == null)
				{
					return string.Empty;
				}
				return this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.NeigsMKNgqriBxadCuicSosqZZfUA;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x00013A99 File Offset: 0x00011C99
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x00035368 File Offset: 0x00033568
		public ushort vendorId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.JhLHTAOAMlgxTZPWxWKJglJMLcTh || !base.enabled)
				{
					return 0;
				}
				if (this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb == null)
				{
					return 0;
				}
				return this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.xYPClePOxdcHpMsZUAOYEwYaLEYUA.vendorId;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x000353C8 File Offset: 0x000335C8
		public ushort productId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.JhLHTAOAMlgxTZPWxWKJglJMLcTh || !base.enabled)
				{
					return 0;
				}
				if (this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb == null)
				{
					return 0;
				}
				return this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.xYPClePOxdcHpMsZUAOYEwYaLEYUA.productId;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x00035428 File Offset: 0x00033628
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.JhLHTAOAMlgxTZPWxWKJglJMLcTh || !base.enabled)
				{
					return 0;
				}
				if (this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb == null)
				{
					return 0;
				}
				return this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.gHQiCrjzGkFhUXcEQueROCxFvjtv;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x00035484 File Offset: 0x00033684
		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.JhLHTAOAMlgxTZPWxWKJglJMLcTh || !base.enabled)
				{
					return 0;
				}
				if (this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb == null)
				{
					return 0;
				}
				return this.TDOduhaMvdEenmZlsQCCJFTjADKD.LqrENOGOvCPiNpzUyVJsuYFhvGbb.VZZEZMHMYmDmOTlgPaWNDeGieSWBc;
			}
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001450C File Offset: 0x0001270C
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (this.JhLHTAOAMlgxTZPWxWKJglJMLcTh)
			{
				bool enabled = base.enabled;
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0001451D File Offset: 0x0001271D
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.TDOduhaMvdEenmZlsQCCJFTjADKD = (source as WindowsGamingInputControllerExtension.JMCPulNXMgottFPxGCKUCFcsOKjd);
			this.JhLHTAOAMlgxTZPWxWKJglJMLcTh = (this.TDOduhaMvdEenmZlsQCCJFTjADKD != null);
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001453A File Offset: 0x0001273A
		internal override Controller.Extension Clone()
		{
			return new WindowsGamingInputControllerExtension(this);
		}

		// Token: 0x040006AF RID: 1711
		private WindowsGamingInputControllerExtension.JMCPulNXMgottFPxGCKUCFcsOKjd TDOduhaMvdEenmZlsQCCJFTjADKD;

		// Token: 0x040006B0 RID: 1712
		private bool JhLHTAOAMlgxTZPWxWKJglJMLcTh;

		// Token: 0x020000B2 RID: 178
		private class JMCPulNXMgottFPxGCKUCFcsOKjd : IControllerExtensionSource
		{
			// Token: 0x1700014F RID: 335
			// (get) Token: 0x0600066D RID: 1645 RVA: 0x00014542 File Offset: 0x00012742
			public cWYIDMjUnhAyDysKZVfQnpWFBosr LqrENOGOvCPiNpzUyVJsuYFhvGbb
			{
				get
				{
					return this.mhgfmxhiVDFSlmLaBQauVfjAmiVXA;
				}
			}

			// Token: 0x0600066E RID: 1646 RVA: 0x0001454A File Offset: 0x0001274A
			public JMCPulNXMgottFPxGCKUCFcsOKjd(cWYIDMjUnhAyDysKZVfQnpWFBosr A_1)
			{
				this.mhgfmxhiVDFSlmLaBQauVfjAmiVXA = A_1;
			}

			// Token: 0x040006B1 RID: 1713
			private cWYIDMjUnhAyDysKZVfQnpWFBosr mhgfmxhiVDFSlmLaBQauVfjAmiVXA;
		}
	}
}
