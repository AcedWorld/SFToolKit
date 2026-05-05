using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	// Token: 0x02000091 RID: 145
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x00012BF6 File Offset: 0x00010DF6
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00013A8A File Offset: 0x00011C8A
		internal DirectInputControllerExtension(kvqducHUWPYYsnUhPdQAbkdahByH A_1, XrQCRhgeVNkvAgFACVEKOVuolsyXb A_2) : base(new DirectInputControllerExtension.JTjEsFNIpKJTNiHHmrJVDilRQwVs(A_1, A_2))
		{
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00012C0C File Offset: 0x00010E0C
		private DirectInputControllerExtension(DirectInputControllerExtension A_1) : base(A_1)
		{
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0003158C File Offset: 0x0002F78C
		public Guid instanceGuid
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return Guid.Empty;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return Guid.Empty;
				}
				if (this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp == null)
				{
					return Guid.Empty;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.GrRuyCwBfgeHmBsXOdUvfoKYTnYA;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x000315F4 File Offset: 0x0002F7F4
		public Guid productGuid
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return Guid.Empty;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return Guid.Empty;
				}
				if (this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp == null)
				{
					return Guid.Empty;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.mpinInATOSahiTvRyoVzQGzRrZhK;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0003165C File Offset: 0x0002F85C
		public string instanceName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return string.Empty;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.eCVMHuKjPQYZMWBWvJunOxSAFRXf;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x000316B4 File Offset: 0x0002F8B4
		public string productName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return string.Empty;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.RerwfDFBMJnAvgaPpolLVFHnWoJx;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0003170C File Offset: 0x0002F90C
		public Guid forceFeedbackDriverGuid
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return Guid.Empty;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return Guid.Empty;
				}
				if (this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp == null)
				{
					return Guid.Empty;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.JNHTKpUHoqVJrOAJNvUWLXsrstLD;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x00031774 File Offset: 0x0002F974
		public ushort usagePage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				if (this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp == null)
				{
					return 0;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.oyBiqhPDqjctCAUjTDfJfaIoBLcP;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x000317D0 File Offset: 0x0002F9D0
		public ushort usage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				if (this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp == null)
				{
					return 0;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.YZkxvYGxcfzMJxmsOEekeomXLTfc;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x0003182C File Offset: 0x0002FA2C
		public DirectInputDeviceType deviceType
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return DirectInputDeviceType.Device;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return DirectInputDeviceType.Device;
				}
				if (this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp == null)
				{
					return DirectInputDeviceType.Device;
				}
				return (DirectInputDeviceType)this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.SFzavqABstyxKAPPhtfHxqkKcFBhA;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x00031888 File Offset: 0x0002FA88
		public int deviceSubtype
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				if (this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp == null)
				{
					return 0;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.FmgOkcSqQpMhGnthDkBUKiekcsxcA;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x000318E4 File Offset: 0x0002FAE4
		public int rawType
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				if (this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp == null)
				{
					return 0;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.IwErUVjEpAfmkbUNUyOTJAOhSrQt;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x00031940 File Offset: 0x0002FB40
		public bool isHumanInterfaceDevice
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return false;
				}
				return this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd && base.enabled && this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp != null && this.lCoDHnYiviSBIKOFJBsceNHOJcYK.NNwdgTrPsaYrKjyZHnTxOxCpMuiB.XZeKnFBCjDoYyombSakLueSbkodK;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0003199C File Offset: 0x0002FB9C
		public DirectInputDeviceAxisMode axisMode
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return DirectInputDeviceAxisMode.Absolute;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return DirectInputDeviceAxisMode.Absolute;
				}
				return (DirectInputDeviceAxisMode)this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.QZofcHCnpzDkYdneTBSHbUjUBLoBb;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x000319EC File Offset: 0x0002FBEC
		public int bufferSize
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.CzAVOOELGwneGKyjhhgyrfssfcAh;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00031A3C File Offset: 0x0002FC3C
		public Guid classGuid
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return Guid.Empty;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return Guid.Empty;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.glXtxKWFOCbeCsHKblTDdNMRCKnX;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00031A94 File Offset: 0x0002FC94
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00031AE4 File Offset: 0x0002FCE4
		public int forceFeedbackGain
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.stsYcjWowANuNJUNndoayEknIsrX;
			}
			set
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return;
				}
				this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.stsYcjWowANuNJUNndoayEknIsrX = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00031B34 File Offset: 0x0002FD34
		public string interfacePath
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return string.Empty;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.xeNFXbZwkORyeFDHTthLmsyTxNVg;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x00031B8C File Offset: 0x0002FD8C
		public int joystickId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				return this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.kkYLtEsqGUmpxJgyMDbSOtwtwHuN;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00031BDC File Offset: 0x0002FDDC
		public ushort productId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				return (ushort)this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.NtdCqAHaxHLesCTtePYdjHXgTAsYb;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00031C2C File Offset: 0x0002FE2C
		public ushort vendorId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd || !base.enabled)
				{
					return 0;
				}
				return (ushort)this.lCoDHnYiviSBIKOFJBsceNHOJcYK.AxplauPjjqwgrwujotmtbLeworKp.hvPlNSFhsvggEswPiOjjzbrDiKPI.UEoJHVcHZVhwjFSkdZlJtXKTLZN;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00013A99 File Offset: 0x00011C99
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00013AA0 File Offset: 0x00011CA0
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd)
			{
				bool enabled = base.enabled;
			}
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00013AB1 File Offset: 0x00011CB1
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.lCoDHnYiviSBIKOFJBsceNHOJcYK = (source as DirectInputControllerExtension.JTjEsFNIpKJTNiHHmrJVDilRQwVs);
			this.ZEdxofDKMtGkLCMsOZCtnFKBhyFd = (this.lCoDHnYiviSBIKOFJBsceNHOJcYK != null);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00013ACE File Offset: 0x00011CCE
		internal override Controller.Extension Clone()
		{
			return new DirectInputControllerExtension(this);
		}

		// Token: 0x0400060F RID: 1551
		private DirectInputControllerExtension.JTjEsFNIpKJTNiHHmrJVDilRQwVs lCoDHnYiviSBIKOFJBsceNHOJcYK;

		// Token: 0x04000610 RID: 1552
		private bool ZEdxofDKMtGkLCMsOZCtnFKBhyFd;

		// Token: 0x02000092 RID: 146
		private class JTjEsFNIpKJTNiHHmrJVDilRQwVs : IControllerExtensionSource
		{
			// Token: 0x170000FF RID: 255
			// (get) Token: 0x060004DA RID: 1242 RVA: 0x00013AD6 File Offset: 0x00011CD6
			public kvqducHUWPYYsnUhPdQAbkdahByH NNwdgTrPsaYrKjyZHnTxOxCpMuiB
			{
				get
				{
					return this.fcoDzMAmnpOupKKPlDmBlLROJYlQA;
				}
			}

			// Token: 0x17000100 RID: 256
			// (get) Token: 0x060004DB RID: 1243 RVA: 0x00013ADE File Offset: 0x00011CDE
			public XrQCRhgeVNkvAgFACVEKOVuolsyXb AxplauPjjqwgrwujotmtbLeworKp
			{
				get
				{
					return this.MgOeIKIaVPSjwFAntzCmfcQNKBFZA;
				}
			}

			// Token: 0x060004DC RID: 1244 RVA: 0x00013AE6 File Offset: 0x00011CE6
			public JTjEsFNIpKJTNiHHmrJVDilRQwVs(kvqducHUWPYYsnUhPdQAbkdahByH A_1, XrQCRhgeVNkvAgFACVEKOVuolsyXb A_2)
			{
				this.fcoDzMAmnpOupKKPlDmBlLROJYlQA = A_1;
				this.MgOeIKIaVPSjwFAntzCmfcQNKBFZA = A_2;
			}

			// Token: 0x04000611 RID: 1553
			private kvqducHUWPYYsnUhPdQAbkdahByH fcoDzMAmnpOupKKPlDmBlLROJYlQA;

			// Token: 0x04000612 RID: 1554
			private XrQCRhgeVNkvAgFACVEKOVuolsyXb MgOeIKIaVPSjwFAntzCmfcQNKBFZA;
		}
	}
}
