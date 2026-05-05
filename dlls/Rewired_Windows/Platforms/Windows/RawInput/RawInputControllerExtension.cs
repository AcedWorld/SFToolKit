using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	// Token: 0x02000075 RID: 117
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00012BF6 File Offset: 0x00010DF6
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000132A0 File Offset: 0x000114A0
		internal RawInputControllerExtension(wiIzvHRiukqjxVPnFrbFTKiAAbar A_1) : base(new RawInputControllerExtension.yTGtpZkOcavLpOoijlMLHMmDnIfP(A_1))
		{
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00012C0C File Offset: 0x00010E0C
		private RawInputControllerExtension(RawInputControllerExtension A_1) : base(A_1)
		{
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060003BD RID: 957 RVA: 0x0002C57C File Offset: 0x0002A77C
		public IntPtr hidDeviceHandle
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return IntPtr.Zero;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return IntPtr.Zero;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.nNEOnkDsaULOlpElKebSYChufHTd;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060003BE RID: 958 RVA: 0x0002C5E8 File Offset: 0x0002A7E8
		public IntPtr rawInputDeviceHandle
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return IntPtr.Zero;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return IntPtr.Zero;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.aCbCjPbrDsLQiAeZMzgPciiOyrLMA;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060003BF RID: 959 RVA: 0x0002C650 File Offset: 0x0002A850
		public string devicePath
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return string.Empty;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return string.Empty;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.nyEfTKiBlpGrjhSHAOmjrGriiJiR;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0002C6BC File Offset: 0x0002A8BC
		public string productName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return string.Empty;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return string.Empty;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.aNWLXhLWGmlNwNjarBtbGFEZsCcjb;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0002C724 File Offset: 0x0002A924
		public string manufacturer
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return string.Empty;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return string.Empty;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.xhmRNvxxHxnkLAMkmjAikcgBUsLY;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x0002C78C File Offset: 0x0002A98C
		public ushort vendorId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return 0;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return 0;
				}
				return (ushort)this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.iYEmfoJliEcUkzCqcvRxHanukpuq;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0002C7E8 File Offset: 0x0002A9E8
		public ushort productId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return 0;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return 0;
				}
				return (ushort)this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.gQKqCyxHcQWSYcLHtQkBxKYVGOOeA;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0002C844 File Offset: 0x0002AA44
		public Guid productGuid
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return Guid.Empty;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return Guid.Empty;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return Guid.Empty;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.GWbIxeTfbRipYnHifgKzkkVPynigA;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0002C8AC File Offset: 0x0002AAAC
		public bool isBluetoothDevice
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return false;
				}
				return this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA && base.enabled && this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn != null && this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.sSEwpwqkxLufRnCodfVriXMzECJm;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0002C908 File Offset: 0x0002AB08
		public string bluetoothDeviceName
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return string.Empty;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return string.Empty;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return string.Empty;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.xgLtCGMbIZFiPgINPDaFQATjyGnb;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x0002C970 File Offset: 0x0002AB70
		public int hubId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return -1;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return -1;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return -1;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.zltcjHyzaLhueBNdTSYmVmEgcXhg;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0002C9CC File Offset: 0x0002ABCC
		public int portId
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return -1;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return -1;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return -1;
				}
				return this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.wfvcPenIcZkEdVUgkhglirdeOJfQ;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x0002CA28 File Offset: 0x0002AC28
		public ushort usagePage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return 0;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return 0;
				}
				return (ushort)this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.uStAgDxEcOAbbgfjBKKeIdWrklZcb.cokBHYDpGjMULdyNCfUoWDZvhZIpA;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0002CA8C File Offset: 0x0002AC8C
		public ushort usage
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA || !base.enabled)
				{
					return 0;
				}
				if (this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn == null)
				{
					return 0;
				}
				return (ushort)this.TFXwGlBitMFzVhBsIOfteErhWTuH.yJZfJHkdJEwNZOoBqpPKmVZxLzJn.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.uStAgDxEcOAbbgfjBKKeIdWrklZcb.tmpUyTjLkuZKfbsSAFjDQZhZBIfE;
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x000132AE File Offset: 0x000114AE
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA)
			{
				bool enabled = base.enabled;
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000132BF File Offset: 0x000114BF
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.TFXwGlBitMFzVhBsIOfteErhWTuH = (source as RawInputControllerExtension.yTGtpZkOcavLpOoijlMLHMmDnIfP);
			this.ydOFeHnSQyRbjCqijRmNhAeUbXNiA = (this.TFXwGlBitMFzVhBsIOfteErhWTuH != null);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x000132DC File Offset: 0x000114DC
		internal override Controller.Extension Clone()
		{
			return new RawInputControllerExtension(this);
		}

		// Token: 0x04000553 RID: 1363
		private RawInputControllerExtension.yTGtpZkOcavLpOoijlMLHMmDnIfP TFXwGlBitMFzVhBsIOfteErhWTuH;

		// Token: 0x04000554 RID: 1364
		private bool ydOFeHnSQyRbjCqijRmNhAeUbXNiA;

		// Token: 0x02000076 RID: 118
		private class yTGtpZkOcavLpOoijlMLHMmDnIfP : IControllerExtensionSource
		{
			// Token: 0x170000C2 RID: 194
			// (get) Token: 0x060003CE RID: 974 RVA: 0x000132E4 File Offset: 0x000114E4
			public wiIzvHRiukqjxVPnFrbFTKiAAbar yJZfJHkdJEwNZOoBqpPKmVZxLzJn
			{
				get
				{
					return this.VBnGCxEChBcwtiNwaGGSngFujxKTA;
				}
			}

			// Token: 0x060003CF RID: 975 RVA: 0x000132EC File Offset: 0x000114EC
			public yTGtpZkOcavLpOoijlMLHMmDnIfP(wiIzvHRiukqjxVPnFrbFTKiAAbar A_1)
			{
				this.VBnGCxEChBcwtiNwaGGSngFujxKTA = A_1;
			}

			// Token: 0x04000555 RID: 1365
			private wiIzvHRiukqjxVPnFrbFTKiAAbar VBnGCxEChBcwtiNwaGGSngFujxKTA;
		}
	}
}
