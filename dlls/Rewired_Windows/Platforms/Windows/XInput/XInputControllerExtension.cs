using System;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.XInput
{
	// Token: 0x0200005A RID: 90
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XInputControllerExtension : Controller.Extension
	{
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00012BF6 File Offset: 0x00010DF6
		private Joystick joystick
		{
			get
			{
				return base.GetController<Joystick>();
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00012BFE File Offset: 0x00010DFE
		internal XInputControllerExtension(hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg A_1) : base(new XInputControllerExtension.fNCHSOYUWqmUyrgKsabDcpVNElaRA(A_1))
		{
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00012C0C File Offset: 0x00010E0C
		private XInputControllerExtension(XInputControllerExtension A_1) : base(A_1)
		{
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0002A198 File Offset: 0x00028398
		public int userIndex
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return 0;
				}
				if (!this.KvSerpfzVyKKCpWGDzlyZNINgMmO || !base.enabled)
				{
					return 0;
				}
				if (this.mVTfSxlFcXXGnkEetgTHNWcfUuCy.SqWqhSCmNhvSBapocFLrxqXCHUoF == null)
				{
					return 0;
				}
				return (int)this.mVTfSxlFcXXGnkEetgTHNWcfUuCy.SqWqhSCmNhvSBapocFLrxqXCHUoF.YxhefCmxGIggoAMJkVFwlzXoLwY.bUmFVuZydMLFywPIoWkXiMHBoRwX;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x0002A1F8 File Offset: 0x000283F8
		public CapabilityFlags capabilityFlags
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return CapabilityFlags.None;
				}
				if (!this.KvSerpfzVyKKCpWGDzlyZNINgMmO || !base.enabled)
				{
					return CapabilityFlags.None;
				}
				if (this.mVTfSxlFcXXGnkEetgTHNWcfUuCy.SqWqhSCmNhvSBapocFLrxqXCHUoF == null)
				{
					return CapabilityFlags.None;
				}
				CELrFAGlKnsjCYGBIIoGyEZcuGQi celrFAGlKnsjCYGBIIoGyEZcuGQi;
				this.mVTfSxlFcXXGnkEetgTHNWcfUuCy.SqWqhSCmNhvSBapocFLrxqXCHUoF.YxhefCmxGIggoAMJkVFwlzXoLwY.xJdeDFgtzTZimOMjzkvPewVzYKtJ(xWqjpLrDBXUZxgRusGkFwZRUWwEG.Any, out celrFAGlKnsjCYGBIIoGyEZcuGQi);
				return (CapabilityFlags)celrFAGlKnsjCYGBIIoGyEZcuGQi.NIqRznhcdiWdhLTtdGNfYYyDyJdK;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0002A260 File Offset: 0x00028460
		public DeviceType deviceType
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return (DeviceType)0;
				}
				if (!this.KvSerpfzVyKKCpWGDzlyZNINgMmO || !base.enabled)
				{
					return (DeviceType)0;
				}
				if (this.mVTfSxlFcXXGnkEetgTHNWcfUuCy.SqWqhSCmNhvSBapocFLrxqXCHUoF == null)
				{
					return (DeviceType)0;
				}
				CELrFAGlKnsjCYGBIIoGyEZcuGQi celrFAGlKnsjCYGBIIoGyEZcuGQi;
				this.mVTfSxlFcXXGnkEetgTHNWcfUuCy.SqWqhSCmNhvSBapocFLrxqXCHUoF.YxhefCmxGIggoAMJkVFwlzXoLwY.xJdeDFgtzTZimOMjzkvPewVzYKtJ(xWqjpLrDBXUZxgRusGkFwZRUWwEG.Any, out celrFAGlKnsjCYGBIIoGyEZcuGQi);
				return (DeviceType)celrFAGlKnsjCYGBIIoGyEZcuGQi.xWAfJVwpvjMYHgMaDoEJksafFIer;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0002A2C8 File Offset: 0x000284C8
		public DeviceSubType deviceSubType
		{
			get
			{
				if (ReInput._id != this._reInputId)
				{
					ReInput.CheckInitialized(this._reInputId);
					return (DeviceSubType)0;
				}
				if (!this.KvSerpfzVyKKCpWGDzlyZNINgMmO || !base.enabled)
				{
					return (DeviceSubType)0;
				}
				if (this.mVTfSxlFcXXGnkEetgTHNWcfUuCy.SqWqhSCmNhvSBapocFLrxqXCHUoF == null)
				{
					return (DeviceSubType)0;
				}
				CELrFAGlKnsjCYGBIIoGyEZcuGQi celrFAGlKnsjCYGBIIoGyEZcuGQi;
				this.mVTfSxlFcXXGnkEetgTHNWcfUuCy.SqWqhSCmNhvSBapocFLrxqXCHUoF.YxhefCmxGIggoAMJkVFwlzXoLwY.xJdeDFgtzTZimOMjzkvPewVzYKtJ(xWqjpLrDBXUZxgRusGkFwZRUWwEG.Any, out celrFAGlKnsjCYGBIIoGyEZcuGQi);
				return (DeviceSubType)celrFAGlKnsjCYGBIIoGyEZcuGQi.ENpAZfUaqGHRZKihIEaRfWaZRSnp;
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00012C15 File Offset: 0x00010E15
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (this.KvSerpfzVyKKCpWGDzlyZNINgMmO)
			{
				bool enabled = base.enabled;
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00012C26 File Offset: 0x00010E26
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.mVTfSxlFcXXGnkEetgTHNWcfUuCy = (source as XInputControllerExtension.fNCHSOYUWqmUyrgKsabDcpVNElaRA);
			this.KvSerpfzVyKKCpWGDzlyZNINgMmO = (this.mVTfSxlFcXXGnkEetgTHNWcfUuCy != null);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00012C43 File Offset: 0x00010E43
		internal override Controller.Extension Clone()
		{
			return new XInputControllerExtension(this);
		}

		// Token: 0x040004C3 RID: 1219
		private XInputControllerExtension.fNCHSOYUWqmUyrgKsabDcpVNElaRA mVTfSxlFcXXGnkEetgTHNWcfUuCy;

		// Token: 0x040004C4 RID: 1220
		private bool KvSerpfzVyKKCpWGDzlyZNINgMmO;

		// Token: 0x0200005B RID: 91
		private class fNCHSOYUWqmUyrgKsabDcpVNElaRA : IControllerExtensionSource
		{
			// Token: 0x17000064 RID: 100
			// (get) Token: 0x060002FA RID: 762 RVA: 0x00012C4B File Offset: 0x00010E4B
			public hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg SqWqhSCmNhvSBapocFLrxqXCHUoF
			{
				get
				{
					return this.ZxhqyseiankxwPXDLvjePbsEmHox;
				}
			}

			// Token: 0x060002FB RID: 763 RVA: 0x00012C53 File Offset: 0x00010E53
			public fNCHSOYUWqmUyrgKsabDcpVNElaRA(hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg A_1)
			{
				this.ZxhqyseiankxwPXDLvjePbsEmHox = A_1;
			}

			// Token: 0x040004C5 RID: 1221
			private hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg ZxhqyseiankxwPXDLvjePbsEmHox;
		}
	}
}
