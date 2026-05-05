using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000044 RID: 68
	public abstract class Controller
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000291 RID: 657 RVA: 0x000042FA File Offset: 0x000024FA
		internal bool DkZfXFCiwMDuRDgLFmVblOlFHFekd
		{
			get
			{
				return this.rKCkYDxXsEaMBNoAFJvXVMYBCmPC == ReInput.previousFrame;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00004309 File Offset: 0x00002509
		// (set) Token: 0x06000293 RID: 659 RVA: 0x0000432C File Offset: 0x0000252C
		public bool enabled
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return false;
				}
				return this.UeFtgBpdctqxEPUWjqUHgBdgMzWQ;
			}
			set
			{
				this.YiinlzRStddWAaeiqMWoRMYdMJYK(value);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00030570 File Offset: 0x0002E770
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00004336 File Offset: 0x00002536
		public string name
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return this._name;
				}
				string result;
				if (this.GLHbZelwhOdwlaXxSwsaxsMXqpGj != null && this.GLHbZelwhOdwlaXxSwsaxsMXqpGj.TryGetLocalizedName(out result))
				{
					return result;
				}
				if (this._type == ControllerType.Joystick && this.legQjhUclFMVpVFTfXDlmJRWuUQj == Consts.joystickGuid_unknownController)
				{
					return this._name;
				}
				if (this.ogPKhCflTWcGLvQucMweZEXjsdQs == null || this.ogPKhCflTWcGLvQucMweZEXjsdQs.parentKeys == null)
				{
					return this._name;
				}
				LocalizationManager.GetAndUpdateLocalizedString(this.mHRJUvJJISHicLjiBAOHXpwmDPfl, (this.ogPKhCflTWcGLvQucMweZEXjsdQs != null) ? this.ogPKhCflTWcGLvQucMweZEXjsdQs.parentKeys : null, pIxAfPCGFQRFBOwQPqPHNpZroQXw.JFMSjqZqDaHCEDpMBlJfyqpAuSbBA(this._type), this._name, out result);
				return result;
			}
			internal set
			{
				this._name = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000296 RID: 662 RVA: 0x0000433F File Offset: 0x0000253F
		// (set) Token: 0x06000297 RID: 663 RVA: 0x00004366 File Offset: 0x00002566
		public string tag
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return string.Empty;
				}
				return this._tag;
			}
			set
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return;
				}
				this._tag = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000298 RID: 664 RVA: 0x00004389 File Offset: 0x00002589
		public string hardwareName
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return string.Empty;
				}
				return this._hardwareName;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000299 RID: 665 RVA: 0x000043B0 File Offset: 0x000025B0
		public ControllerType type
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return ControllerType.Keyboard;
				}
				return this._type;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600029A RID: 666 RVA: 0x000043D3 File Offset: 0x000025D3
		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return Guid.Empty;
				}
				return this.legQjhUclFMVpVFTfXDlmJRWuUQj;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600029B RID: 667
		public abstract Guid deviceInstanceGuid { get; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600029C RID: 668 RVA: 0x000043FA File Offset: 0x000025FA
		public ControllerIdentifier identifier
		{
			get
			{
				return this.cUrAsSHeUGFXDFqaqslWTflpkhUOA;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00004402 File Offset: 0x00002602
		// (set) Token: 0x0600029E RID: 670 RVA: 0x00004425 File Offset: 0x00002625
		public bool isConnected
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return false;
				}
				return this._isConnected;
			}
			internal set
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return;
				}
				if (!value)
				{
					this.Disconnected();
					return;
				}
				this.Connected();
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00004451 File Offset: 0x00002651
		public string hardwareIdentifier
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return string.Empty;
				}
				return this._hardwareIdentifier;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00030638 File Offset: 0x0002E838
		public string mapTypeString
		{
			get
			{
				return this._type.ToString() + "Map";
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x00004478 File Offset: 0x00002678
		public int elementCount
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0;
				}
				return this.eaeCgwOtpabZniAEBKXuUOwFuWtfA.Count;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x000044A0 File Offset: 0x000026A0
		public int buttonCount
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0;
				}
				return this._buttonCount;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x000044C3 File Offset: 0x000026C3
		public IList<Controller.Element> Elements
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<Controller.Element>.EmptyReadOnlyIListT;
				}
				return this.ezeACLPDKGWNxCCIhGEGdxdkefqb;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x000044EA File Offset: 0x000026EA
		public IList<Controller.CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<Controller.CompoundElement>.EmptyReadOnlyIListT;
				}
				return this.fUFfaaGoNfvhLAPIktoQNLHtHYogA;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00004511 File Offset: 0x00002711
		public IList<Controller.Button> Buttons
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<Controller.Button>.EmptyReadOnlyIListT;
				}
				return this.buttons_readOnly;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x00004538 File Offset: 0x00002738
		public Controller.Extension extension
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return null;
				}
				return this.eBSHopCTEUjvWhdBVQVtpDFekbSDA;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0000455B File Offset: 0x0000275B
		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return this.WGnseNgKihPuTwMSEeDkNInQXGEb.elementIdentifiers_readOnly;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00004587 File Offset: 0x00002787
		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return this.WGnseNgKihPuTwMSEeDkNInQXGEb.buttonElementIdentifiers_readOnly;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x000045B3 File Offset: 0x000027B3
		// (set) Token: 0x060002AA RID: 682 RVA: 0x000045BB File Offset: 0x000027BB
		internal ITryGetLocalizedName GLHbZelwhOdwlaXxSwsaxsMXqpGj
		{
			get
			{
				return this.IWPbDjQLwQKrughqtxmyeZzLbUlq;
			}
			set
			{
				this.IWPbDjQLwQKrughqtxmyeZzLbUlq = value;
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060002AB RID: 683 RVA: 0x000045C4 File Offset: 0x000027C4
		// (remove) Token: 0x060002AC RID: 684 RVA: 0x000045DD File Offset: 0x000027DD
		internal event Action<bool> MXqoczOdcBQjivZZflSxxfhRAvjCA
		{
			add
			{
				this.GVhTKdHAKmFjhHuKOMNmDHonlGlmA = (Action<bool>)Delegate.Combine(this.GVhTKdHAKmFjhHuKOMNmDHonlGlmA, value);
			}
			remove
			{
				this.GVhTKdHAKmFjhHuKOMNmDHonlGlmA = (Action<bool>)Delegate.Remove(this.GVhTKdHAKmFjhHuKOMNmDHonlGlmA, value);
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00030664 File Offset: 0x0002E864
		internal Controller(int A_1, InputSource A_2, string A_3, string A_4, string A_5, ControllerType A_6, Guid A_7, int A_8, bool[] A_9, HardwareButtonInfo[] A_10, HardwareControllerMap_Game A_11, Controller.Extension A_12, ControllerDataUpdater A_13)
		{
			this.id = A_1;
			this.inputSource = A_2;
			this._type = A_6;
			this.legQjhUclFMVpVFTfXDlmJRWuUQj = A_7;
			this._buttonCount = A_8;
			this._name = A_3;
			this._hardwareName = A_4;
			this._hardwareIdentifier = A_5;
			this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb = A_13;
			this.WGnseNgKihPuTwMSEeDkNInQXGEb = A_11;
			this.ogPKhCflTWcGLvQucMweZEXjsdQs = A_11.deviceLocalizationInfo;
			this.UeFtgBpdctqxEPUWjqUHgBdgMzWQ = true;
			this.SISUIQtlCHkLdwsmdeqFquyXrGcw = ReInput.id;
			this.mHRJUvJJISHicLjiBAOHXpwmDPfl = new LocalizedString();
			this.MlUwedIqExcYyPpnXeZhaDcJXqlB = new bCHqIsWsJLmmIkpuWMBAcITGmVCV(new Action(this.ZKpLJxTeSBOVpwzXPMmBPPeVFzHDA));
			this.IyhljjWhnREpPEFrzYjBCBrPWmrY(A_12);
			this.eaeCgwOtpabZniAEBKXuUOwFuWtfA = new List<Controller.Element>(A_8);
			this.ezeACLPDKGWNxCCIhGEGdxdkefqb = new ReadOnlyCollection<Controller.Element>(this.eaeCgwOtpabZniAEBKXuUOwFuWtfA);
			this.VBmuldhKXOyEUZaRjXVGZrWVGjny = new List<Controller.CompoundElement>();
			this.fUFfaaGoNfvhLAPIktoQNLHtHYogA = new ReadOnlyCollection<Controller.CompoundElement>(this.VBmuldhKXOyEUZaRjXVGZrWVGjny);
			this.buttons = new Controller.Button[A_8];
			if (A_9 == null || A_9.Length < A_8)
			{
				for (int i = 0; i < A_8; i++)
				{
					this.buttons[i] = new Controller.Button(this, A_11.buttonElementIdentifierIds[i], "Button " + i.ToString(), false, (A_10 != null) ? A_10[i] : new HardwareButtonInfo());
					this.XLjRULaYMvgYNtbsPXBrIvFPOHVy(this.buttons[i]);
				}
			}
			else
			{
				for (int j = 0; j < A_8; j++)
				{
					this.buttons[j] = new Controller.Button(this, A_11.buttonElementIdentifierIds[j], "Button " + j.ToString(), A_9[j], (A_10 != null) ? A_10[j] : new HardwareButtonInfo());
					this.XLjRULaYMvgYNtbsPXBrIvFPOHVy(this.buttons[j]);
				}
			}
			this.buttons_readOnly = new ReadOnlyCollection<Controller.Button>(this.buttons);
			this.PikVMquInDsJMoztBMiHKvwBhjEI = EmptyObjects<IControllerTemplate>.array;
			this.xuAOcBkbHJmDePAYISJvqFAvjEgZ = new ReadOnlyCollection<IControllerTemplate>(this.PikVMquInDsJMoztBMiHKvwBhjEI);
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((qRARPoZhenAEzvKQshZvLFcmqQCG)this.MlUwedIqExcYyPpnXeZhaDcJXqlB).Localize();
			}
			this.Connected();
		}

		// Token: 0x060002AE RID: 686 RVA: 0x000045F6 File Offset: 0x000027F6
		internal virtual void qEnvtUAzINATYqQGwxMxBBiSsAkj()
		{
			this.cUrAsSHeUGFXDFqaqslWTflpkhUOA = new ControllerIdentifier(this);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00030858 File Offset: 0x0002EA58
		public virtual Controller.Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return null;
			}
			if (this.WGnseNgKihPuTwMSEeDkNInQXGEb == null)
			{
				return null;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return this.buttons[buttonIndex];
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x000308A8 File Offset: 0x0002EAA8
		public virtual Controller.CompoundElement GetCompoundElementById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return null;
			}
			int count = this.VBmuldhKXOyEUZaRjXVGZrWVGjny.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.VBmuldhKXOyEUZaRjXVGZrWVGjny[i] != null && this.VBmuldhKXOyEUZaRjXVGZrWVGjny[i].id == elementIdentifierId)
				{
					return this.VBmuldhKXOyEUZaRjXVGZrWVGjny[i];
				}
			}
			return null;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00004604 File Offset: 0x00002804
		[Obsolete("This method is deprecated. Use GetCompoundElementById instead.", false)]
		public virtual Controller.CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			return this.GetCompoundElementById(elementIdentifierId);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000460D File Offset: 0x0000280D
		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return -1;
			}
			return this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00004636 File Offset: 0x00002836
		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return null;
			}
			return this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetElementIdentifierById(elementIdentifierId);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000465F File Offset: 0x0000285F
		public virtual bool GetButton(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return index >= 0 && index < this._buttonCount && this.buttons[index].value;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00004698 File Offset: 0x00002898
		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return index >= 0 && index < this._buttonCount && this.buttons[index].justPressed;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000046D1 File Offset: 0x000028D1
		public virtual bool GetButtonUp(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return index >= 0 && index < this._buttonCount && this.buttons[index].justReleased;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00030918 File Offset: 0x0002EB18
		public virtual bool GetButtonChanged(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return index >= 0 && index < this._buttonCount && this.buttons[index].value != this.buttons[index].valuePrev;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000470A File Offset: 0x0000290A
		public virtual bool GetButtonPrev(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return index >= 0 && index < this._buttonCount && this.buttons[index].valuePrev;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00004743 File Offset: 0x00002943
		public virtual bool GetButtonDoublePressHold(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return this.GetButtonDoublePressHold(index, 0f);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000476C File Offset: 0x0000296C
		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return index >= 0 && index < this._buttonCount && this.buttons[index].DoublePressedAndHeld(speed);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x000047A6 File Offset: 0x000029A6
		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return this.GetButtonDoublePressDown(index, 0f);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000047CF File Offset: 0x000029CF
		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return index >= 0 && index < this._buttonCount && this.buttons[index].JustDoublePressed(speed);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00030970 File Offset: 0x0002EB70
		public virtual double GetButtonTimePressed(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._buttonCount)
			{
				return 0.0;
			}
			return this.buttons[index].timePressed;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000309C4 File Offset: 0x0002EBC4
		public virtual double GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._buttonCount)
			{
				return 0.0;
			}
			return this.buttons[index].timeUnpressed;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00030A18 File Offset: 0x0002EC18
		public virtual double GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._buttonCount)
			{
				return 0.0;
			}
			return this.buttons[index].lastTimePressed;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00030A6C File Offset: 0x0002EC6C
		public virtual double GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._buttonCount)
			{
				return 0.0;
			}
			return this.buttons[index].lastTimeUnpressed;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00030AC0 File Offset: 0x0002ECC0
		public virtual bool GetAnyButton()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			for (int i = 0; i < this._buttonCount; i++)
			{
				if (this.buttons[i].value)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00030B0C File Offset: 0x0002ED0C
		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			for (int i = 0; i < this._buttonCount; i++)
			{
				if (this.buttons[i].justPressed)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00030B58 File Offset: 0x0002ED58
		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			for (int i = 0; i < this._buttonCount; i++)
			{
				if (this.buttons[i].justReleased)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00030BA4 File Offset: 0x0002EDA4
		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			for (int i = 0; i < this._buttonCount; i++)
			{
				if (this.buttons[i].valuePrev)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00030BF0 File Offset: 0x0002EDF0
		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			for (int i = 0; i < this._buttonCount; i++)
			{
				if (this.buttons[i].justChangedState)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00030C3C File Offset: 0x0002EE3C
		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			return buttonIndex >= 0 && buttonIndex < this._buttonCount && this.buttons[buttonIndex].value;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00030C90 File Offset: 0x0002EE90
		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			return buttonIndex >= 0 && buttonIndex < this._buttonCount && this.buttons[buttonIndex].justPressed;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00030CE4 File Offset: 0x0002EEE4
		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			return buttonIndex >= 0 && buttonIndex < this._buttonCount && this.buttons[buttonIndex].justReleased;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00030D38 File Offset: 0x0002EF38
		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			return buttonIndex >= 0 && buttonIndex < this._buttonCount && this.buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00030D8C File Offset: 0x0002EF8C
		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			return buttonIndex >= 0 && buttonIndex < this._buttonCount && this.buttons[buttonIndex].JustDoublePressed(speed);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00030DE0 File Offset: 0x0002EFE0
		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			return this.GetButtonDoublePressHold(buttonIndex, 0f);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00030E24 File Offset: 0x0002F024
		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			return this.GetButtonDoublePressDown(buttonIndex, 0f);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00030E68 File Offset: 0x0002F068
		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			return buttonIndex >= 0 && buttonIndex < this._buttonCount && this.buttons[buttonIndex].valuePrev;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00030EBC File Offset: 0x0002F0BC
		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= this._buttonCount)
			{
				return 0.0;
			}
			return this.buttons[buttonIndex].timePressed;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00030F20 File Offset: 0x0002F120
		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= this._buttonCount)
			{
				return 0.0;
			}
			return this.buttons[buttonIndex].timeUnpressed;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00030F84 File Offset: 0x0002F184
		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= this._buttonCount)
			{
				return 0.0;
			}
			return this.buttons[buttonIndex].lastTimePressed;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00030FE8 File Offset: 0x0002F1E8
		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int buttonIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= this._buttonCount)
			{
				return 0.0;
			}
			return this.buttons[buttonIndex].lastTimeUnpressed;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00004809 File Offset: 0x00002A09
		public virtual ControllerPollingInfo PollForFirstElement()
		{
			return this.PollForFirstButton();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00004811 File Offset: 0x00002A11
		public virtual ControllerPollingInfo PollForFirstElementDown()
		{
			return this.PollForFirstButtonDown();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0003104C File Offset: 0x0002F24C
		public virtual ControllerPollingInfo PollForFirstButton()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
			}
			this.UpdatePollingFrameTracking();
			for (int i = 0; i < this._buttonCount; i++)
			{
				int num;
				if (this.vAuZblHSqPIandyuzORGQDwgXHHv(i, out num))
				{
					return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Button, i, Pole.Positive, this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000310CC File Offset: 0x0002F2CC
		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
			}
			this.UpdatePollingFrameTracking();
			for (int i = 0; i < this._buttonCount; i++)
			{
				int num;
				if (this.FzTNdVJUjdKYwPXMKqWKssOBrPsH(i, out num))
				{
					return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Button, i, Pole.Positive, this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00004819 File Offset: 0x00002A19
		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return this.PollForAllButtons();
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00004821 File Offset: 0x00002A21
		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return this.PollForAllButtonsDown();
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00004829 File Offset: 0x00002A29
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				yield break;
			}
			this.UpdatePollingFrameTracking();
			int num2;
			for (int i = 0; i < this._buttonCount; i = num2 + 1)
			{
				int num;
				if (this.vAuZblHSqPIandyuzORGQDwgXHHv(i, out num))
				{
					yield return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Button, i, Pole.Positive, this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetElementIdentifierName(num), num, KeyCode.None);
				}
				num2 = i;
			}
			yield break;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00004839 File Offset: 0x00002A39
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				yield break;
			}
			this.UpdatePollingFrameTracking();
			int num2;
			for (int i = 0; i < this._buttonCount; i = num2 + 1)
			{
				int num;
				if (this.FzTNdVJUjdKYwPXMKqWKssOBrPsH(i, out num))
				{
					yield return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Button, i, Pole.Positive, this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetElementIdentifierName(num), num, KeyCode.None);
				}
				num2 = i;
			}
			yield break;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0003114C File Offset: 0x0002F34C
		private bool vAuZblHSqPIandyuzORGQDwgXHHv(int A_1, out int A_2)
		{
			A_2 = -1;
			if (!this.buttons[A_1].value || this.buttons[A_1].fuVVJeNPjIGsaeSzACpupNnXrgrL._excludeFromPolling)
			{
				return false;
			}
			A_2 = this.WGnseNgKihPuTwMSEeDkNInQXGEb.buttonElementIdentifierIds[A_1];
			return A_2 >= 0;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x000311A0 File Offset: 0x0002F3A0
		private bool FzTNdVJUjdKYwPXMKqWKssOBrPsH(int A_1, out int A_2)
		{
			A_2 = -1;
			if (!this.buttons[A_1].justPressed || this.buttons[A_1].fuVVJeNPjIGsaeSzACpupNnXrgrL._excludeFromPolling)
			{
				return false;
			}
			A_2 = this.WGnseNgKihPuTwMSEeDkNInQXGEb.buttonElementIdentifierIds[A_1];
			return A_2 >= 0;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x000311F4 File Offset: 0x0002F3F4
		protected void UpdatePollingFrameTracking()
		{
			if (this.TBZzWQxDQFyDyFozuERpFnBJoNkv == ReInput.currentFrame)
			{
				return;
			}
			this.rKCkYDxXsEaMBNoAFJvXVMYBCmPC = this.TBZzWQxDQFyDyFozuERpFnBJoNkv;
			this.TBZzWQxDQFyDyFozuERpFnBJoNkv = ReInput.currentFrame;
			if (!this.DkZfXFCiwMDuRDgLFmVblOlFHFekd)
			{
				if (this.WcWoumfMigeejCwVwqPaGscuaJaJ == 4294967295U)
				{
					this.WcWoumfMigeejCwVwqPaGscuaJaJ = 0U;
					return;
				}
				this.WcWoumfMigeejCwVwqPaGscuaJaJ += 1U;
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00004849 File Offset: 0x00002A49
		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			return this.GetLastTimeActive(false);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00004875 File Offset: 0x00002A75
		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			return this.GetLastTimeAnyButtonPressed();
		}

		// Token: 0x060002DF RID: 735 RVA: 0x000048A0 File Offset: 0x00002AA0
		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			return this.GetLastTimeAnyElementChanged(false);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000048CC File Offset: 0x00002ACC
		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			return this.GetLastTimeAnyButtonChanged();
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00031250 File Offset: 0x0002F450
		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (this.buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < this.buttons.Length; i++)
			{
				double lastTimePressed = this.buttons[i].lastTimePressed;
				if (lastTimePressed > num)
				{
					num = lastTimePressed;
				}
			}
			return num;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000312C4 File Offset: 0x0002F4C4
		public double GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (this.buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < this.buttons.Length; i++)
			{
				double lastTimeStateChanged = this.buttons[i].lastTimeStateChanged;
				if (lastTimeStateChanged > num)
				{
					num = lastTimeStateChanged;
				}
			}
			return num;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00031338 File Offset: 0x0002F538
		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return default(T);
			}
			return this.eBSHopCTEUjvWhdBVQVtpDFekbSDA as T;
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x000048F7 File Offset: 0x00002AF7
		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return this.xuAOcBkbHJmDePAYISJvqFAvjEgZ;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000491E File Offset: 0x00002B1E
		public int templateCount
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0;
				}
				return this.PikVMquInDsJMoztBMiHKvwBhjEI.Length;
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00031378 File Offset: 0x0002F578
		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return null;
			}
			for (int i = 0; i < this.PikVMquInDsJMoztBMiHKvwBhjEI.Length; i++)
			{
				if (this.PikVMquInDsJMoztBMiHKvwBhjEI[i].typeGuid == typeGuid)
				{
					return this.PikVMquInDsJMoztBMiHKvwBhjEI[i];
				}
			}
			return null;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000313D4 File Offset: 0x0002F5D4
		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return null;
			}
			for (int i = 0; i < this.PikVMquInDsJMoztBMiHKvwBhjEI.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(this.PikVMquInDsJMoztBMiHKvwBhjEI[i].GetType(), type))
				{
					return this.PikVMquInDsJMoztBMiHKvwBhjEI[i];
				}
			}
			return null;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00031430 File Offset: 0x0002F630
		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return default(T);
			}
			for (int i = 0; i < this.PikVMquInDsJMoztBMiHKvwBhjEI.Length; i++)
			{
				if (this.PikVMquInDsJMoztBMiHKvwBhjEI[i] is T)
				{
					return this.PikVMquInDsJMoztBMiHKvwBhjEI[i] as T;
				}
			}
			return default(T);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x000314A8 File Offset: 0x0002F6A8
		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			for (int i = 0; i < this.PikVMquInDsJMoztBMiHKvwBhjEI.Length; i++)
			{
				if (this.PikVMquInDsJMoztBMiHKvwBhjEI[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x000314FC File Offset: 0x0002F6FC
		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < this.PikVMquInDsJMoztBMiHKvwBhjEI.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(this.PikVMquInDsJMoztBMiHKvwBhjEI[i].GetType(), type))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00004943 File Offset: 0x00002B43
		public bool ImplementsTemplate<T>() where T : class
		{
			return this.ImplementsTemplate(typeof(T));
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00004955 File Offset: 0x00002B55
		internal void MgYwapbZCQwLiKLveprNZCrDUWPN(IControllerTemplate[] A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.PikVMquInDsJMoztBMiHKvwBhjEI = A_1;
			this.xuAOcBkbHJmDePAYISJvqFAvjEgZ = new ReadOnlyCollection<IControllerTemplate>(this.PikVMquInDsJMoztBMiHKvwBhjEI);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00031564 File Offset: 0x0002F764
		internal virtual void FQTBjLASwKIywYemFGwowQCkCzxHA(UpdateLoopType A_1)
		{
			bool flag = ReInput.IsInputAllowed(this._type);
			int buttonCount = this._buttonCount;
			if (flag)
			{
				for (int i = 0; i < buttonCount; i++)
				{
					if (this.buttons[i].bwvtxgGfdABcgYyNDAvjFRqSNOtN <= 0)
					{
						this.buttons[i].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, i, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
					}
				}
			}
			else
			{
				for (int j = 0; j < buttonCount; j++)
				{
					if (this.buttons[j].bwvtxgGfdABcgYyNDAvjFRqSNOtN <= 0)
					{
						this.buttons[j].KQCkzfztIZInUkmVbUEQZjdhTCLD(A_1);
					}
				}
			}
			if (this.eBSHopCTEUjvWhdBVQVtpDFekbSDA != null)
			{
				this.eBSHopCTEUjvWhdBVQVtpDFekbSDA.UpdateData(A_1);
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00004973 File Offset: 0x00002B73
		internal virtual ButtonStateFlags tdcTLdcmxAGwPEpXWnaBGUvEHgCJb(int A_1)
		{
			if (A_1 < 0 || A_1 >= this._buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return this.buttons[A_1].NaunYgnEofItAYHWzZGhbMVZXfKT;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00004991 File Offset: 0x00002B91
		internal void IyhljjWhnREpPEFrzYjBCBrPWmrY(Controller.Extension A_1)
		{
			if (A_1 == null)
			{
				this.eBSHopCTEUjvWhdBVQVtpDFekbSDA = null;
				return;
			}
			if (this.eBSHopCTEUjvWhdBVQVtpDFekbSDA != null)
			{
				this.CrnanVLriShQUIjluGsNhACGtayK(A_1);
				return;
			}
			A_1.SetController(this);
			this.eBSHopCTEUjvWhdBVQVtpDFekbSDA = A_1.Clone();
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000049C1 File Offset: 0x00002BC1
		internal void CrnanVLriShQUIjluGsNhACGtayK(Controller.Extension A_1)
		{
			if (this.eBSHopCTEUjvWhdBVQVtpDFekbSDA != null)
			{
				this.eBSHopCTEUjvWhdBVQVtpDFekbSDA.SetSource(A_1);
				this.eBSHopCTEUjvWhdBVQVtpDFekbSDA.SetController(this);
				if (A_1 != null)
				{
					A_1.SetController(this);
					return;
				}
			}
			else
			{
				this.IyhljjWhnREpPEFrzYjBCBrPWmrY(A_1);
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x000315F8 File Offset: 0x0002F7F8
		internal virtual void teTpHyJcIRafhlIJVTCUfrhAktlq()
		{
			for (int i = 0; i < this._buttonCount; i++)
			{
				if (this.buttons[i] != null)
				{
					this.buttons[i].Reset();
				}
			}
			if (this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb != null)
			{
				this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.ClearData();
			}
			if (this.eBSHopCTEUjvWhdBVQVtpDFekbSDA != null)
			{
				this.eBSHopCTEUjvWhdBVQVtpDFekbSDA.Clear();
			}
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000049F5 File Offset: 0x00002BF5
		internal virtual bool YiinlzRStddWAaeiqMWoRMYdMJYK(bool A_1)
		{
			if (this.UeFtgBpdctqxEPUWjqUHgBdgMzWQ == A_1)
			{
				return false;
			}
			if (!A_1)
			{
				this.teTpHyJcIRafhlIJVTCUfrhAktlq();
			}
			this.UeFtgBpdctqxEPUWjqUHgBdgMzWQ = A_1;
			if (this.GVhTKdHAKmFjhHuKOMNmDHonlGlmA != null)
			{
				this.GVhTKdHAKmFjhHuKOMNmDHonlGlmA(A_1);
			}
			return true;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00031654 File Offset: 0x0002F854
		internal virtual void VswFFcfRUHqPtFHydytpQrxVsYK(ControllerMap A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			A_1.controllerId = this.id;
			IList<ActionElementMap> buttonMaps = A_1.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				this.ZIaqgsDccGvTITgnjUFeFXRKbtuj(A_1, buttonMaps[i]);
			}
			for (int j = buttonMaps.Count - 1; j >= 0; j--)
			{
				if (buttonMaps[j].elementIndex < 0)
				{
					A_1.DeleteElementMap(buttonMaps[j].pGMbotKVdjNowDvSSfgThIWDmLSHB);
				}
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00004A27 File Offset: 0x00002C27
		internal virtual void ZIaqgsDccGvTITgnjUFeFXRKbtuj(ControllerMap A_1, ActionElementMap A_2)
		{
			if (A_2 == null)
			{
				return;
			}
			if (A_2._elementType != ControllerElementType.Button)
			{
				return;
			}
			A_2.YmjBUAFlEbXvUpfGfovFCfjkhaLrc(A_1);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000316CC File Offset: 0x0002F8CC
		internal bool DQVOuVYkGTobkZcfIdCHMiklaaiH(ActionElementMap A_1, int A_2, out float A_3, out bool A_4)
		{
			A_4 = false;
			A_3 = 0f;
			if (A_2 != A_1._actionId)
			{
				return false;
			}
			int mRCBQDgzARDPVbNsvhiBadcDxEwTB = A_1.mRCBQDgzARDPVbNsvhiBadcDxEwTB;
			if (mRCBQDgzARDPVbNsvhiBadcDxEwTB < 0 || mRCBQDgzARDPVbNsvhiBadcDxEwTB >= this._buttonCount)
			{
				return false;
			}
			A_4 = this.buttons[mRCBQDgzARDPVbNsvhiBadcDxEwTB].evatwZDxHVhPSvLkOiribnozxreiA;
			float num;
			if (A_4)
			{
				num = this.buttons[mRCBQDgzARDPVbNsvhiBadcDxEwTB].pressure;
			}
			else
			{
				num = (this.buttons[mRCBQDgzARDPVbNsvhiBadcDxEwTB].value ? 1f : 0f);
			}
			if (num > 0f)
			{
				if (A_1._elementType == ControllerElementType.Button)
				{
					if (A_1._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (A_1._elementType == ControllerElementType.Axis)
				{
					if (A_1._axisRange == AxisRange.Full)
					{
						if (A_1._invert)
						{
							num *= -1f;
						}
					}
					else if (A_1._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			A_3 = num;
			return true;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x000317A4 File Offset: 0x0002F9A4
		internal bool pApPLZRfIEWcsjbhcblnmbiJrXWT(ActionElementMap A_1, int A_2, bool A_3, out float A_4)
		{
			A_4 = 0f;
			if (A_2 != A_1._actionId)
			{
				return false;
			}
			float num = A_3 ? 1f : 0f;
			if (num > 0f)
			{
				if (A_1._elementType == ControllerElementType.Button)
				{
					if (A_1._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (A_1._elementType == ControllerElementType.Axis)
				{
					if (A_1._axisRange == AxisRange.Full)
					{
						if (A_1._invert)
						{
							num *= -1f;
						}
					}
					else if (A_1._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			A_4 = num;
			return true;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00004A3E File Offset: 0x00002C3E
		internal void XLjRULaYMvgYNtbsPXBrIvFPOHVy(Controller.Element A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			ListTools.AddIfUnique<Controller.Element>(this.eaeCgwOtpabZniAEBKXuUOwFuWtfA, A_1);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00004A51 File Offset: 0x00002C51
		internal void cVOLZuDPMltkbpMYWExnExBwVvDnA(Controller.CompoundElement A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			ListTools.AddIfUnique<Controller.CompoundElement>(this.VBmuldhKXOyEUZaRjXVGZrWVGjny, A_1);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00004A64 File Offset: 0x00002C64
		internal virtual Guid eYEZHCgSUjgEPRTZyQoEIneSFTHr()
		{
			return Guid.Empty;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00004A6B File Offset: 0x00002C6B
		internal virtual void traDKlHspaXCdfNvtkwAFzPfEhYY(bool A_1)
		{
			if (!A_1 && !ReInput.IsInputAllowed(this._type) && this.eBSHopCTEUjvWhdBVQVtpDFekbSDA != null)
			{
				this.eBSHopCTEUjvWhdBVQVtpDFekbSDA.Clear();
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00004A90 File Offset: 0x00002C90
		protected virtual void Connected()
		{
			this._isConnected = true;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00004A99 File Offset: 0x00002C99
		protected virtual void Disconnected()
		{
			this._isConnected = false;
			if (this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb != null)
			{
				this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.ClearData();
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00004AB5 File Offset: 0x00002CB5
		internal static Func<Controller, Guid, bool> ZJwltezfazRoTpkEJonhGGDtHmYEA
		{
			get
			{
				Func<Controller, Guid, bool> result;
				if ((result = Controller.YToizyaEKOffvrBFRdhDIwAddJJKA) == null)
				{
					result = (Controller.YToizyaEKOffvrBFRdhDIwAddJJKA = new Func<Controller, Guid, bool>(Controller.PvbFcvGhKjIftOWUKdvsRDbihcbWA.<>9.WVTmhXKcLuHvUQQowAnxZsJXpIRr));
				}
				return result;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00004AE5 File Offset: 0x00002CE5
		internal static Func<Controller, Type, bool> aecobxgkEHTCBoBDiiBBgDDakTvJA
		{
			get
			{
				Func<Controller, Type, bool> result;
				if ((result = Controller.yGzhyhNPVXDzkPWiGMmwnqhIsqLB) == null)
				{
					result = (Controller.yGzhyhNPVXDzkPWiGMmwnqhIsqLB = new Func<Controller, Type, bool>(Controller.PvbFcvGhKjIftOWUKdvsRDbihcbWA.<>9.npoZPZGuEfwJuCcNLfGYSakEZjhd));
				}
				return result;
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00004B15 File Offset: 0x00002D15
		[CompilerGenerated]
		private void ZKpLJxTeSBOVpwzXPMmBPPeVFzHDA()
		{
			string name = this.name;
		}

		// Token: 0x0400027E RID: 638
		public readonly int id;

		// Token: 0x0400027F RID: 639
		protected string _tag;

		// Token: 0x04000280 RID: 640
		protected string _name;

		// Token: 0x04000281 RID: 641
		private readonly DeviceLocalizationInfo ogPKhCflTWcGLvQucMweZEXjsdQs;

		// Token: 0x04000282 RID: 642
		protected string _hardwareName;

		// Token: 0x04000283 RID: 643
		protected readonly ControllerType _type;

		// Token: 0x04000284 RID: 644
		internal readonly Guid legQjhUclFMVpVFTfXDlmJRWuUQj;

		// Token: 0x04000285 RID: 645
		protected string _hardwareIdentifier;

		// Token: 0x04000286 RID: 646
		protected bool _isConnected;

		// Token: 0x04000287 RID: 647
		private Controller.Extension eBSHopCTEUjvWhdBVQVtpDFekbSDA;

		// Token: 0x04000288 RID: 648
		private bool UeFtgBpdctqxEPUWjqUHgBdgMzWQ;

		// Token: 0x04000289 RID: 649
		private ControllerIdentifier cUrAsSHeUGFXDFqaqslWTflpkhUOA;

		// Token: 0x0400028A RID: 650
		internal int SISUIQtlCHkLdwsmdeqFquyXrGcw;

		// Token: 0x0400028B RID: 651
		protected readonly int _buttonCount;

		// Token: 0x0400028C RID: 652
		protected readonly Controller.Button[] buttons;

		// Token: 0x0400028D RID: 653
		protected readonly ReadOnlyCollection<Controller.Button> buttons_readOnly;

		// Token: 0x0400028E RID: 654
		private readonly IList<Controller.Element> eaeCgwOtpabZniAEBKXuUOwFuWtfA;

		// Token: 0x0400028F RID: 655
		private readonly ReadOnlyCollection<Controller.Element> ezeACLPDKGWNxCCIhGEGdxdkefqb;

		// Token: 0x04000290 RID: 656
		private readonly IList<Controller.CompoundElement> VBmuldhKXOyEUZaRjXVGZrWVGjny;

		// Token: 0x04000291 RID: 657
		private readonly ReadOnlyCollection<Controller.CompoundElement> fUFfaaGoNfvhLAPIktoQNLHtHYogA;

		// Token: 0x04000292 RID: 658
		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		// Token: 0x04000293 RID: 659
		internal readonly ControllerDataUpdater ydAtmTGPnVEBcanqXjmfnQCYnoGgb;

		// Token: 0x04000294 RID: 660
		internal readonly HardwareControllerMap_Game WGnseNgKihPuTwMSEeDkNInQXGEb;

		// Token: 0x04000295 RID: 661
		internal uint WcWoumfMigeejCwVwqPaGscuaJaJ;

		// Token: 0x04000296 RID: 662
		private uint rKCkYDxXsEaMBNoAFJvXVMYBCmPC;

		// Token: 0x04000297 RID: 663
		private uint TBZzWQxDQFyDyFozuERpFnBJoNkv;

		// Token: 0x04000298 RID: 664
		private ITryGetLocalizedName IWPbDjQLwQKrughqtxmyeZzLbUlq;

		// Token: 0x04000299 RID: 665
		private readonly LocalizedString mHRJUvJJISHicLjiBAOHXpwmDPfl;

		// Token: 0x0400029A RID: 666
		private readonly bCHqIsWsJLmmIkpuWMBAcITGmVCV MlUwedIqExcYyPpnXeZhaDcJXqlB;

		// Token: 0x0400029B RID: 667
		private Action<bool> GVhTKdHAKmFjhHuKOMNmDHonlGlmA;

		// Token: 0x0400029C RID: 668
		private IControllerTemplate[] PikVMquInDsJMoztBMiHKvwBhjEI;

		// Token: 0x0400029D RID: 669
		private ReadOnlyCollection<IControllerTemplate> xuAOcBkbHJmDePAYISJvqFAvjEgZ;

		// Token: 0x0400029E RID: 670
		private static Func<Controller, Guid, bool> YToizyaEKOffvrBFRdhDIwAddJJKA;

		// Token: 0x0400029F RID: 671
		private static Func<Controller, Type, bool> yGzhyhNPVXDzkPWiGMmwnqhIsqLB;

		// Token: 0x02000045 RID: 69
		public abstract class Element
		{
			// Token: 0x170000BA RID: 186
			// (get) Token: 0x06000300 RID: 768 RVA: 0x00031830 File Offset: 0x0002FA30
			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = this.LKHdGzaUtOjlAXoGCxNOPVjCeYNe.GetElementIdentifierById(this.id);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			// Token: 0x170000BB RID: 187
			// (get) Token: 0x06000301 RID: 769 RVA: 0x00004B1E File Offset: 0x00002D1E
			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return this.bwvtxgGfdABcgYyNDAvjFRqSNOtN > 0;
				}
			}

			// Token: 0x170000BC RID: 188
			// (get) Token: 0x06000302 RID: 770 RVA: 0x00004B44 File Offset: 0x00002D44
			public Controller.CompoundElement compoundElement
			{
				get
				{
					return this.NicVmABVGMUOhDMBqgfmaClVOaIh;
				}
			}

			// Token: 0x06000303 RID: 771 RVA: 0x00004B4C File Offset: 0x00002D4C
			internal Element(Controller A_1, int A_2, string A_3, ControllerElementType A_4)
			{
				this.LKHdGzaUtOjlAXoGCxNOPVjCeYNe = A_1;
				this.id = A_2;
				this.name = A_3;
				this.type = A_4;
				this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA = ReInput.id;
			}

			// Token: 0x06000304 RID: 772 RVA: 0x00004B7C File Offset: 0x00002D7C
			public void Reset()
			{
				if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
				{
					ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
					return;
				}
				if (this.znbaxGxhRXbWvmLUUUVcTfglolBA != null)
				{
					this.znbaxGxhRXbWvmLUUUVcTfglolBA.UnoYvxOvppjhhjLYeczLfaxIUfTY();
				}
			}

			// Token: 0x06000305 RID: 773 RVA: 0x00004BAB File Offset: 0x00002DAB
			internal void ugZBUZCFxJFpjkVRBWKQDhwkGrcwA(Controller.CompoundElement A_1)
			{
				if (this.bwvtxgGfdABcgYyNDAvjFRqSNOtN > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				this.bwvtxgGfdABcgYyNDAvjFRqSNOtN++;
				if (this.NicVmABVGMUOhDMBqgfmaClVOaIh == null)
				{
					this.NicVmABVGMUOhDMBqgfmaClVOaIh = A_1;
				}
			}

			// Token: 0x06000306 RID: 774 RVA: 0x00004BDD File Offset: 0x00002DDD
			internal void bMoEYnYhsFaOcdcXfFAzDmDkbfvVb(Controller.CompoundElement A_1)
			{
				if (this.bwvtxgGfdABcgYyNDAvjFRqSNOtN == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					this.bwvtxgGfdABcgYyNDAvjFRqSNOtN = 0;
					return;
				}
				this.bwvtxgGfdABcgYyNDAvjFRqSNOtN--;
				if (this.NicVmABVGMUOhDMBqgfmaClVOaIh == A_1)
				{
					this.NicVmABVGMUOhDMBqgfmaClVOaIh = null;
				}
			}

			// Token: 0x040002A0 RID: 672
			public readonly int id;

			// Token: 0x040002A1 RID: 673
			public readonly string name;

			// Token: 0x040002A2 RID: 674
			public readonly ControllerElementType type;

			// Token: 0x040002A3 RID: 675
			internal Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR znbaxGxhRXbWvmLUUUVcTfglolBA;

			// Token: 0x040002A4 RID: 676
			internal int bwvtxgGfdABcgYyNDAvjFRqSNOtN;

			// Token: 0x040002A5 RID: 677
			internal Controller LKHdGzaUtOjlAXoGCxNOPVjCeYNe;

			// Token: 0x040002A6 RID: 678
			internal readonly int sWTAlEgpBQeNSPmSTlNnOVWyIsycA;

			// Token: 0x040002A7 RID: 679
			private Controller.CompoundElement NicVmABVGMUOhDMBqgfmaClVOaIh;

			// Token: 0x02000046 RID: 70
			internal abstract class lXWAMNACmJWEzoPsoONULlKgkOqR
			{
				// Token: 0x170000BD RID: 189
				// (get) Token: 0x06000307 RID: 775 RVA: 0x00004C17 File Offset: 0x00002E17
				public IList<Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt> kcAjzFxnLKbmEMcTyhEZMjkxHALF
				{
					get
					{
						return this.dxwKhmdoOmRSWgzAahJwZdNSbDMdA;
					}
				}

				// Token: 0x170000BE RID: 190
				// (set) Token: 0x06000308 RID: 776 RVA: 0x00031874 File Offset: 0x0002FA74
				public UpdateLoopType njKsyzqMnudoelxKuqYQpSHAiHkq
				{
					set
					{
						if (this.jMdfnQEjXzfudcMFFrwLBeQccwgqe == (int)value)
						{
							return;
						}
						this.jMdfnQEjXzfudcMFFrwLBeQccwgqe = (int)value;
						this.uZbbvTGOIozuQHygqBQEAvfhadYf = this.NfDDJPFlIXgHrkcfDnDvGhTkLnaIA[(int)value];
						this.WcmEmWehoACKlcKoaZVxkHPRBOaQc = this.YGoeedXtqsREinUIYplunGRnaUBD[this.uZbbvTGOIozuQHygqBQEAvfhadYf];
					}
				}

				// Token: 0x06000309 RID: 777 RVA: 0x000318B8 File Offset: 0x0002FAB8
				public lXWAMNACmJWEzoPsoONULlKgkOqR(UpdateLoopSetting A_1)
				{
					this.NfDDJPFlIXgHrkcfDnDvGhTkLnaIA = new int[3];
					this.SOYbhlJWgGhAqQPLAEkmCsNEEwruB = 0;
					using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tlist.list;
						EnumConverter.ToUpdateLoopTypes(A_1, list);
						for (int i = 0; i < list.Count; i++)
						{
							this.NfDDJPFlIXgHrkcfDnDvGhTkLnaIA[(int)list[i]] = this.SOYbhlJWgGhAqQPLAEkmCsNEEwruB;
							this.SOYbhlJWgGhAqQPLAEkmCsNEEwruB++;
						}
					}
					this.YGoeedXtqsREinUIYplunGRnaUBD = new Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt[this.SOYbhlJWgGhAqQPLAEkmCsNEEwruB];
					this.dxwKhmdoOmRSWgzAahJwZdNSbDMdA = new ReadOnlyCollection<Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt>(this.YGoeedXtqsREinUIYplunGRnaUBD);
				}

				// Token: 0x0600030A RID: 778 RVA: 0x0003196C File Offset: 0x0002FB6C
				public void UnoYvxOvppjhhjLYeczLfaxIUfTY()
				{
					for (int i = 0; i < this.SOYbhlJWgGhAqQPLAEkmCsNEEwruB; i++)
					{
						this.YGoeedXtqsREinUIYplunGRnaUBD[i].OzplKoxmDLsktEYwBDdyoJxuXMnj();
					}
				}

				// Token: 0x0600030B RID: 779 RVA: 0x00004C1F File Offset: 0x00002E1F
				public Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt HDcttGUbBzduhpkIHrBDkGENRiPW(UpdateLoopType A_1)
				{
					return this.YGoeedXtqsREinUIYplunGRnaUBD[this.NfDDJPFlIXgHrkcfDnDvGhTkLnaIA[(int)A_1]];
				}

				// Token: 0x040002A8 RID: 680
				protected readonly int SOYbhlJWgGhAqQPLAEkmCsNEEwruB;

				// Token: 0x040002A9 RID: 681
				protected readonly int[] NfDDJPFlIXgHrkcfDnDvGhTkLnaIA;

				// Token: 0x040002AA RID: 682
				protected Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt[] YGoeedXtqsREinUIYplunGRnaUBD;

				// Token: 0x040002AB RID: 683
				public Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt WcmEmWehoACKlcKoaZVxkHPRBOaQc;

				// Token: 0x040002AC RID: 684
				private int uZbbvTGOIozuQHygqBQEAvfhadYf;

				// Token: 0x040002AD RID: 685
				public int jMdfnQEjXzfudcMFFrwLBeQccwgqe = -1;

				// Token: 0x040002AE RID: 686
				protected ReadOnlyCollection<Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt> dxwKhmdoOmRSWgzAahJwZdNSbDMdA;

				// Token: 0x02000047 RID: 71
				public abstract class mHNHLxtZRqaemBQvsxEGhWgSRYlt
				{
					// Token: 0x0600030C RID: 780
					public abstract void OzplKoxmDLsktEYwBDdyoJxuXMnj();
				}
			}
		}

		// Token: 0x02000048 RID: 72
		public sealed class Axis : Controller.Element
		{
			// Token: 0x170000BF RID: 191
			// (get) Token: 0x0600030E RID: 782 RVA: 0x00031998 File Offset: 0x0002FB98
			public float value
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).AWyCKffmZxUlewswFnuqDVxBnQQfc;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).lXkDgXhApzCtOaNElxYGYTBUMVwV;
				}
			}

			// Token: 0x170000C0 RID: 192
			// (get) Token: 0x0600030F RID: 783 RVA: 0x000319F8 File Offset: 0x0002FBF8
			public float valuePrev
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).lbvJLuYnphahtLGMgvXzpHLdbHQM;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).TOQrIhdNQCmqeEbMSGaFSywyeoPu;
				}
			}

			// Token: 0x170000C1 RID: 193
			// (get) Token: 0x06000310 RID: 784 RVA: 0x00004C30 File Offset: 0x00002E30
			// (set) Token: 0x06000311 RID: 785 RVA: 0x00004C66 File Offset: 0x00002E66
			public float valueRaw
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).urlBaaOCKTjTilWbpTNwiMXrbhMM;
				}
				internal set
				{
					((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).wYXFZTFcrOEWqMlDeAlPeOCffbgV(value);
				}
			}

			// Token: 0x170000C2 RID: 194
			// (get) Token: 0x06000312 RID: 786 RVA: 0x00004C7E File Offset: 0x00002E7E
			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).FfRUxDKLAXEhFPDzcswhCwgoumoS;
				}
			}

			// Token: 0x170000C3 RID: 195
			// (get) Token: 0x06000313 RID: 787 RVA: 0x00004CB4 File Offset: 0x00002EB4
			public float valueDelta
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					return this.value - this.valuePrev;
				}
			}

			// Token: 0x170000C4 RID: 196
			// (get) Token: 0x06000314 RID: 788 RVA: 0x00031A58 File Offset: 0x0002FC58
			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).urlBaaOCKTjTilWbpTNwiMXrbhMM - ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).FfRUxDKLAXEhFPDzcswhCwgoumoS;
				}
			}

			// Token: 0x170000C5 RID: 197
			// (get) Token: 0x06000315 RID: 789 RVA: 0x00004CE2 File Offset: 0x00002EE2
			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).XNWuGeScaOIBQSPbDmlopqbaocXG;
				}
			}

			// Token: 0x170000C6 RID: 198
			// (get) Token: 0x06000316 RID: 790 RVA: 0x00004D1C File Offset: 0x00002F1C
			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).bfjamdwapPwwFknirHLqNzhUJKpj;
				}
			}

			// Token: 0x170000C7 RID: 199
			// (get) Token: 0x06000317 RID: 791 RVA: 0x00004D56 File Offset: 0x00002F56
			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).oGNqRcqGlMKOKlCOBZhoeKxsnuNg;
				}
			}

			// Token: 0x170000C8 RID: 200
			// (get) Token: 0x06000318 RID: 792 RVA: 0x00004D90 File Offset: 0x00002F90
			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).YhDaNptGlcAroscKdnpZLWbbaJdL;
				}
			}

			// Token: 0x170000C9 RID: 201
			// (get) Token: 0x06000319 RID: 793 RVA: 0x00004DCA File Offset: 0x00002FCA
			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).QsCRuPKECEhRXdVRXuBXCykARXHi;
				}
			}

			// Token: 0x170000CA RID: 202
			// (get) Token: 0x0600031A RID: 794 RVA: 0x00004E04 File Offset: 0x00003004
			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).doRgBEfeuWmHOFrwCpZqfaXGjrQi;
				}
			}

			// Token: 0x170000CB RID: 203
			// (get) Token: 0x0600031B RID: 795 RVA: 0x00004E3E File Offset: 0x0000303E
			public double timeActive
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IjVkLCHMoWPTTJnrDCWbQyiserXC;
				}
			}

			// Token: 0x170000CC RID: 204
			// (get) Token: 0x0600031C RID: 796 RVA: 0x00004E3E File Offset: 0x0000303E
			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IjVkLCHMoWPTTJnrDCWbQyiserXC;
				}
			}

			// Token: 0x170000CD RID: 205
			// (get) Token: 0x0600031D RID: 797 RVA: 0x00004E78 File Offset: 0x00003078
			public double timeInactive
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).suQlxIkRPIoEbxNZYcwqWGCqNOEC;
				}
			}

			// Token: 0x170000CE RID: 206
			// (get) Token: 0x0600031E RID: 798 RVA: 0x00004EB2 File Offset: 0x000030B2
			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).KGIEcqEVOOYKFCccsfuOCxUPwaSP;
				}
			}

			// Token: 0x170000CF RID: 207
			// (get) Token: 0x0600031F RID: 799 RVA: 0x00004EEC File Offset: 0x000030EC
			// (set) Token: 0x06000320 RID: 800 RVA: 0x00004F26 File Offset: 0x00003126
			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					if (this.fzzkLLIistIuAlLCPzLMFEPVKHOk == null)
					{
						return -1f;
					}
					return this.fzzkLLIistIuAlLCPzLMFEPVKHOk._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (this.fzzkLLIistIuAlLCPzLMFEPVKHOk != null)
					{
						this.fzzkLLIistIuAlLCPzLMFEPVKHOk._pollingDeadZone = value;
					}
				}
			}

			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x06000321 RID: 801 RVA: 0x00004F65 File Offset: 0x00003165
			internal float ZYIzumkBGGVcwncyhoddCBBWIugp
			{
				get
				{
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).lXkDgXhApzCtOaNElxYGYTBUMVwV;
				}
			}

			// Token: 0x170000D1 RID: 209
			// (get) Token: 0x06000322 RID: 802 RVA: 0x00004F7C File Offset: 0x0000317C
			internal float AtQHljjuUfRRvOChxdWqcpbYZEqi
			{
				get
				{
					return ((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).TOQrIhdNQCmqeEbMSGaFSywyeoPu;
				}
			}

			// Token: 0x06000323 RID: 803 RVA: 0x00004F93 File Offset: 0x00003193
			internal void MFaZbePehqPkSTEYlcaoUcwvUKSG(float A_1)
			{
				Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm zfSWCmZdtjjmqpTLTarQcXEodDNm = (Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc;
				zfSWCmZdtjjmqpTLTarQcXEodDNm.lbvJLuYnphahtLGMgvXzpHLdbHQM = zfSWCmZdtjjmqpTLTarQcXEodDNm.AWyCKffmZxUlewswFnuqDVxBnQQfc;
				zfSWCmZdtjjmqpTLTarQcXEodDNm.AWyCKffmZxUlewswFnuqDVxBnQQfc = A_1;
			}

			// Token: 0x170000D2 RID: 210
			// (get) Token: 0x06000324 RID: 804 RVA: 0x00031AB0 File Offset: 0x0002FCB0
			internal float ZQoOPuaFhStRTYOlYriHWUJshfEj
			{
				get
				{
					if (this.fzzkLLIistIuAlLCPzLMFEPVKHOk == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (this.fzzkLLIistIuAlLCPzLMFEPVKHOk._pollingDeadZone >= 0f)
					{
						return this.fzzkLLIistIuAlLCPzLMFEPVKHOk._pollingDeadZone;
					}
					AxisCoordinateMode dataFormat = this.fzzkLLIistIuAlLCPzLMFEPVKHOk._dataFormat;
					if (dataFormat == AxisCoordinateMode.Absolute)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (dataFormat != AxisCoordinateMode.Relative)
					{
						throw new NotImplementedException();
					}
					return ReInput.configuration.defaultRelativeAxisPollingDeadZone;
				}
			}

			// Token: 0x06000325 RID: 805 RVA: 0x00004FB7 File Offset: 0x000031B7
			internal Axis(Controller A_1, int A_2, string A_3, AxisRange A_4, HardwareAxisInfo A_5) : base(A_1, A_2, A_3, ControllerElementType.Axis)
			{
				this.znbaxGxhRXbWvmLUUUVcTfglolBA = new Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU(ReInput.configVars.updateLoop);
				this.eQIIPxGvopaSqUZzYHzkFlxVsYsT = A_4;
				this.fzzkLLIistIuAlLCPzLMFEPVKHOk = A_5;
			}

			// Token: 0x06000326 RID: 806 RVA: 0x00004FE8 File Offset: 0x000031E8
			internal void znxiAoQjQzZirXYdmKafTWVfxAfK(UpdateLoopType A_1)
			{
				if (this.znbaxGxhRXbWvmLUUUVcTfglolBA != null && this.znbaxGxhRXbWvmLUUUVcTfglolBA.jMdfnQEjXzfudcMFFrwLBeQccwgqe != (int)A_1)
				{
					this.znbaxGxhRXbWvmLUUUVcTfglolBA.njKsyzqMnudoelxKuqYQpSHAiHkq = A_1;
				}
			}

			// Token: 0x06000327 RID: 807 RVA: 0x00031B20 File Offset: 0x0002FD20
			internal void FEvBJkPZnMrqaaBDVlPNNBufpbuo(AxisCalibration A_1)
			{
				Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm zfSWCmZdtjjmqpTLTarQcXEodDNm = (Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc;
				zfSWCmZdtjjmqpTLTarQcXEodDNm.TOQrIhdNQCmqeEbMSGaFSywyeoPu = zfSWCmZdtjjmqpTLTarQcXEodDNm.lXkDgXhApzCtOaNElxYGYTBUMVwV;
				float num = A_1.GetCalibratedValue(zfSWCmZdtjjmqpTLTarQcXEodDNm.urlBaaOCKTjTilWbpTNwiMXrbhMM, this.eQIIPxGvopaSqUZzYHzkFlxVsYsT);
				if (A_1.applyRangeCalibration)
				{
					num = MathTools.Clamp(num, -1f, 1f);
				}
				zfSWCmZdtjjmqpTLTarQcXEodDNm.lXkDgXhApzCtOaNElxYGYTBUMVwV = num;
			}

			// Token: 0x06000328 RID: 808 RVA: 0x0000500C File Offset: 0x0000320C
			internal void WaNlEwLGWlEHuFVBsAkSFrvJMQTaA()
			{
				Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm zfSWCmZdtjjmqpTLTarQcXEodDNm = (Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc;
				zfSWCmZdtjjmqpTLTarQcXEodDNm.TOQrIhdNQCmqeEbMSGaFSywyeoPu = zfSWCmZdtjjmqpTLTarQcXEodDNm.lXkDgXhApzCtOaNElxYGYTBUMVwV;
				zfSWCmZdtjjmqpTLTarQcXEodDNm.lXkDgXhApzCtOaNElxYGYTBUMVwV = zfSWCmZdtjjmqpTLTarQcXEodDNm.urlBaaOCKTjTilWbpTNwiMXrbhMM;
			}

			// Token: 0x06000329 RID: 809 RVA: 0x00005035 File Offset: 0x00003235
			internal void WGNjnPthNHRYKMPNuVIrALqFUfyc()
			{
				Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm zfSWCmZdtjjmqpTLTarQcXEodDNm = (Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc;
				zfSWCmZdtjjmqpTLTarQcXEodDNm.TOQrIhdNQCmqeEbMSGaFSywyeoPu = zfSWCmZdtjjmqpTLTarQcXEodDNm.lXkDgXhApzCtOaNElxYGYTBUMVwV;
				zfSWCmZdtjjmqpTLTarQcXEodDNm.lXkDgXhApzCtOaNElxYGYTBUMVwV = 0f;
			}

			// Token: 0x0600032A RID: 810 RVA: 0x0000505D File Offset: 0x0000325D
			internal void vvllVrmPmGSfmAiPKWpLKAaZJcve()
			{
				((Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).ORLuMObXzBOPaLoTAJbqYERPDhG(base.isMemberElement);
			}

			// Token: 0x0600032B RID: 811 RVA: 0x00031B80 File Offset: 0x0002FD80
			internal void WayEqzaAATswjEEXxvVdYphINQyd(float A_1)
			{
				for (int i = 0; i < this.znbaxGxhRXbWvmLUUUVcTfglolBA.kcAjzFxnLKbmEMcTyhEZMjkxHALF.Count; i++)
				{
					Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm zfSWCmZdtjjmqpTLTarQcXEodDNm = this.znbaxGxhRXbWvmLUUUVcTfglolBA.kcAjzFxnLKbmEMcTyhEZMjkxHALF[i] as Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm;
					if (zfSWCmZdtjjmqpTLTarQcXEodDNm != null)
					{
						zfSWCmZdtjjmqpTLTarQcXEodDNm.wYXFZTFcrOEWqMlDeAlPeOCffbgV(A_1);
						zfSWCmZdtjjmqpTLTarQcXEodDNm.TOQrIhdNQCmqeEbMSGaFSywyeoPu = zfSWCmZdtjjmqpTLTarQcXEodDNm.lXkDgXhApzCtOaNElxYGYTBUMVwV;
						zfSWCmZdtjjmqpTLTarQcXEodDNm.lXkDgXhApzCtOaNElxYGYTBUMVwV = 0f;
						zfSWCmZdtjjmqpTLTarQcXEodDNm.ORLuMObXzBOPaLoTAJbqYERPDhG(base.isMemberElement);
					}
				}
			}

			// Token: 0x0600032C RID: 812 RVA: 0x00031BEC File Offset: 0x0002FDEC
			internal float SowOKJRemKGQXusTBFOaIQTdxSdIA(UpdateLoopType A_1, AxisCalibration A_2)
			{
				Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm zfSWCmZdtjjmqpTLTarQcXEodDNm = (Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm)this.znbaxGxhRXbWvmLUUUVcTfglolBA.HDcttGUbBzduhpkIHrBDkGENRiPW(A_1);
				float num = A_2.GetCalibratedValue(zfSWCmZdtjjmqpTLTarQcXEodDNm.urlBaaOCKTjTilWbpTNwiMXrbhMM, this.eQIIPxGvopaSqUZzYHzkFlxVsYsT, A_2.deadZone, false, true);
				if (A_2.applyRangeCalibration)
				{
					num = MathTools.Clamp(num, -1f, 1f);
				}
				return num;
			}

			// Token: 0x040002AF RID: 687
			internal readonly AxisRange eQIIPxGvopaSqUZzYHzkFlxVsYsT;

			// Token: 0x040002B0 RID: 688
			internal readonly HardwareAxisInfo fzzkLLIistIuAlLCPzLMFEPVKHOk;

			// Token: 0x02000049 RID: 73
			internal class cDOBREUIpDCgnyvNYflnIzySguLU : Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR
			{
				// Token: 0x0600032D RID: 813 RVA: 0x00031C40 File Offset: 0x0002FE40
				public cDOBREUIpDCgnyvNYflnIzySguLU(UpdateLoopSetting A_1) : base(A_1)
				{
					for (int i = 0; i < this.SOYbhlJWgGhAqQPLAEkmCsNEEwruB; i++)
					{
						this.YGoeedXtqsREinUIYplunGRnaUBD[i] = new Controller.Axis.cDOBREUIpDCgnyvNYflnIzySguLU.zfSWCmZdtjjmqpTLTarQcXEodDNm();
					}
					this.WcmEmWehoACKlcKoaZVxkHPRBOaQc = this.YGoeedXtqsREinUIYplunGRnaUBD[0];
				}

				// Token: 0x0200004A RID: 74
				public class zfSWCmZdtjjmqpTLTarQcXEodDNm : Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt
				{
					// Token: 0x170000D3 RID: 211
					// (get) Token: 0x0600032E RID: 814 RVA: 0x0000507A File Offset: 0x0000327A
					public double IjVkLCHMoWPTTJnrDCWbQyiserXC
					{
						get
						{
							if ((double)this.lXkDgXhApzCtOaNElxYGYTBUMVwV == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - this.oGNqRcqGlMKOKlCOBZhoeKxsnuNg;
						}
					}

					// Token: 0x170000D4 RID: 212
					// (get) Token: 0x0600032F RID: 815 RVA: 0x000050A4 File Offset: 0x000032A4
					public double ZdPNhkpJVfEtdaRiICUXLbqciaIy
					{
						get
						{
							if ((double)this.urlBaaOCKTjTilWbpTNwiMXrbhMM == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - this.YhDaNptGlcAroscKdnpZLWbbaJdL;
						}
					}

					// Token: 0x170000D5 RID: 213
					// (get) Token: 0x06000330 RID: 816 RVA: 0x000050CE File Offset: 0x000032CE
					public double suQlxIkRPIoEbxNZYcwqWGCqNOEC
					{
						get
						{
							if (this.lXkDgXhApzCtOaNElxYGYTBUMVwV != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - this.XNWuGeScaOIBQSPbDmlopqbaocXG;
						}
					}

					// Token: 0x170000D6 RID: 214
					// (get) Token: 0x06000331 RID: 817 RVA: 0x000050F3 File Offset: 0x000032F3
					public double KGIEcqEVOOYKFCccsfuOCxUPwaSP
					{
						get
						{
							if ((double)this.urlBaaOCKTjTilWbpTNwiMXrbhMM != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - this.bfjamdwapPwwFknirHLqNzhUJKpj;
						}
					}

					// Token: 0x06000332 RID: 818 RVA: 0x00031C80 File Offset: 0x0002FE80
					public void ORLuMObXzBOPaLoTAJbqYERPDhG(bool A_1)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (A_1)
						{
							if (!MathTools.Approximately(this.AWyCKffmZxUlewswFnuqDVxBnQQfc, 0f))
							{
								this.XNWuGeScaOIBQSPbDmlopqbaocXG = unscaledTime;
							}
							else
							{
								this.oGNqRcqGlMKOKlCOBZhoeKxsnuNg = unscaledTime;
							}
							if (!MathTools.IsNear(this.AWyCKffmZxUlewswFnuqDVxBnQQfc, this.lbvJLuYnphahtLGMgvXzpHLdbHQM, 0.001f))
							{
								this.QsCRuPKECEhRXdVRXuBXCykARXHi = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(this.lXkDgXhApzCtOaNElxYGYTBUMVwV, 0f))
							{
								this.XNWuGeScaOIBQSPbDmlopqbaocXG = unscaledTime;
							}
							else
							{
								this.oGNqRcqGlMKOKlCOBZhoeKxsnuNg = unscaledTime;
							}
							if (!MathTools.IsNear(this.lXkDgXhApzCtOaNElxYGYTBUMVwV, this.TOQrIhdNQCmqeEbMSGaFSywyeoPu, 0.001f))
							{
								this.QsCRuPKECEhRXdVRXuBXCykARXHi = unscaledTime;
							}
						}
						if (!MathTools.Approximately(this.urlBaaOCKTjTilWbpTNwiMXrbhMM, 0f))
						{
							this.bfjamdwapPwwFknirHLqNzhUJKpj = unscaledTime;
						}
						else
						{
							this.YhDaNptGlcAroscKdnpZLWbbaJdL = unscaledTime;
						}
						if (!MathTools.IsNear(this.urlBaaOCKTjTilWbpTNwiMXrbhMM, this.FfRUxDKLAXEhFPDzcswhCwgoumoS, 0.001f))
						{
							this.doRgBEfeuWmHOFrwCpZqfaXGjrQi = unscaledTime;
						}
					}

					// Token: 0x06000333 RID: 819 RVA: 0x0000511D File Offset: 0x0000331D
					public void wYXFZTFcrOEWqMlDeAlPeOCffbgV(float A_1)
					{
						if (this.FfRUxDKLAXEhFPDzcswhCwgoumoS != this.urlBaaOCKTjTilWbpTNwiMXrbhMM)
						{
							this.FfRUxDKLAXEhFPDzcswhCwgoumoS = this.urlBaaOCKTjTilWbpTNwiMXrbhMM;
						}
						if (this.urlBaaOCKTjTilWbpTNwiMXrbhMM != A_1)
						{
							this.urlBaaOCKTjTilWbpTNwiMXrbhMM = A_1;
						}
					}

					// Token: 0x06000334 RID: 820 RVA: 0x00031D5C File Offset: 0x0002FF5C
					public virtual void xJVjcCrrfHcAkDqnAYNfbMeKzNugA()
					{
						this.lXkDgXhApzCtOaNElxYGYTBUMVwV = 0f;
						this.TOQrIhdNQCmqeEbMSGaFSywyeoPu = 0f;
						this.urlBaaOCKTjTilWbpTNwiMXrbhMM = 0f;
						this.FfRUxDKLAXEhFPDzcswhCwgoumoS = 0f;
						this.XNWuGeScaOIBQSPbDmlopqbaocXG = 0.0;
						this.bfjamdwapPwwFknirHLqNzhUJKpj = 0.0;
						this.oGNqRcqGlMKOKlCOBZhoeKxsnuNg = 0.0;
						this.YhDaNptGlcAroscKdnpZLWbbaJdL = 0.0;
						this.QsCRuPKECEhRXdVRXuBXCykARXHi = 0.0;
						this.doRgBEfeuWmHOFrwCpZqfaXGjrQi = 0.0;
					}

					// Token: 0x040002B1 RID: 689
					private const float hRPEyWcXusBRDDPrxGfnmlaxoPFjb = 0.001f;

					// Token: 0x040002B2 RID: 690
					public float lXkDgXhApzCtOaNElxYGYTBUMVwV;

					// Token: 0x040002B3 RID: 691
					public float TOQrIhdNQCmqeEbMSGaFSywyeoPu;

					// Token: 0x040002B4 RID: 692
					public float urlBaaOCKTjTilWbpTNwiMXrbhMM;

					// Token: 0x040002B5 RID: 693
					public float FfRUxDKLAXEhFPDzcswhCwgoumoS;

					// Token: 0x040002B6 RID: 694
					public float AWyCKffmZxUlewswFnuqDVxBnQQfc;

					// Token: 0x040002B7 RID: 695
					public float lbvJLuYnphahtLGMgvXzpHLdbHQM;

					// Token: 0x040002B8 RID: 696
					public double XNWuGeScaOIBQSPbDmlopqbaocXG;

					// Token: 0x040002B9 RID: 697
					public double bfjamdwapPwwFknirHLqNzhUJKpj;

					// Token: 0x040002BA RID: 698
					public double oGNqRcqGlMKOKlCOBZhoeKxsnuNg;

					// Token: 0x040002BB RID: 699
					public double YhDaNptGlcAroscKdnpZLWbbaJdL;

					// Token: 0x040002BC RID: 700
					public double QsCRuPKECEhRXdVRXuBXCykARXHi;

					// Token: 0x040002BD RID: 701
					public double doRgBEfeuWmHOFrwCpZqfaXGjrQi;
				}
			}
		}

		// Token: 0x0200004B RID: 75
		public sealed class Button : Controller.Element
		{
			// Token: 0x170000D7 RID: 215
			// (get) Token: 0x06000336 RID: 822 RVA: 0x00005151 File Offset: 0x00003351
			public bool valuePrev
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).dgLCMVEQSYoKoNgOkJYKnqKKRjhb;
				}
			}

			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x06000337 RID: 823 RVA: 0x00005183 File Offset: 0x00003383
			public bool value
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).mUJGVRmxZNeOrKNNMMDKufkqwwjDA;
				}
			}

			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x06000338 RID: 824 RVA: 0x00031DF0 File Offset: 0x0002FFF0
			public float pressure
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					if (this.evatwZDxHVhPSvLkOiribnozxreiA)
					{
						return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.SbipAFRTaRdUjhzNqVKVxUyJIDyh)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).OgjjiOOWooIlzReNgYVOmYwDljHt;
					}
					if (!((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).mUJGVRmxZNeOrKNNMMDKufkqwwjDA)
					{
						return 0f;
					}
					return 1f;
				}
			}

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x06000339 RID: 825 RVA: 0x00031E5C File Offset: 0x0003005C
			public float pressurePrev
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0f;
					}
					if (this.evatwZDxHVhPSvLkOiribnozxreiA)
					{
						return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.SbipAFRTaRdUjhzNqVKVxUyJIDyh)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).ysCNWKIcTbchvNyALyflPfBObVxt;
					}
					if (!((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).dgLCMVEQSYoKoNgOkJYKnqKKRjhb)
					{
						return 0f;
					}
					return 1f;
				}
			}

			// Token: 0x170000DB RID: 219
			// (get) Token: 0x0600033A RID: 826 RVA: 0x000051B5 File Offset: 0x000033B5
			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return this.evatwZDxHVhPSvLkOiribnozxreiA;
				}
			}

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x0600033B RID: 827 RVA: 0x00031EC8 File Offset: 0x000300C8
			public bool justPressed
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return !((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).dgLCMVEQSYoKoNgOkJYKnqKKRjhb && ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).mUJGVRmxZNeOrKNNMMDKufkqwwjDA;
				}
			}

			// Token: 0x170000DD RID: 221
			// (get) Token: 0x0600033C RID: 828 RVA: 0x00031F24 File Offset: 0x00030124
			public bool justReleased
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).dgLCMVEQSYoKoNgOkJYKnqKKRjhb && !((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).mUJGVRmxZNeOrKNNMMDKufkqwwjDA;
				}
			}

			// Token: 0x170000DE RID: 222
			// (get) Token: 0x0600033D RID: 829 RVA: 0x00031F80 File Offset: 0x00030180
			public bool justChangedState
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).dgLCMVEQSYoKoNgOkJYKnqKKRjhb != ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).mUJGVRmxZNeOrKNNMMDKufkqwwjDA;
				}
			}

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x0600033E RID: 830 RVA: 0x000051D8 File Offset: 0x000033D8
			public bool doublePressedAndHeld
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).lqDbwvltkGIbVhGNmZQDCmOqPsRWA.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
				}
			}

			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x0600033F RID: 831 RVA: 0x00031FD8 File Offset: 0x000301D8
			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return false;
					}
					return this.justPressed && ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).lqDbwvltkGIbVhGNmZQDCmOqPsRWA.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
				}
			}

			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x06000340 RID: 832 RVA: 0x0000520F File Offset: 0x0000340F
			public double timePressed
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IOHWYLPfQQlAffRUPhHbhwdDGaWk.iYYBZEdZWjRNEowiokfAQtErJtQX;
				}
			}

			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x06000341 RID: 833 RVA: 0x0000524E File Offset: 0x0000344E
			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IOHWYLPfQQlAffRUPhHbhwdDGaWk.UoGphxgHptsNNoLrRKlCQxHyDDvy;
				}
			}

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x06000342 RID: 834 RVA: 0x0000528D File Offset: 0x0000348D
			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IOHWYLPfQQlAffRUPhHbhwdDGaWk.SZaqWEWxDEjaxLNeDuArknYBuxGc;
				}
			}

			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x06000343 RID: 835 RVA: 0x000052CC File Offset: 0x000034CC
			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IOHWYLPfQQlAffRUPhHbhwdDGaWk.SjfqgewtjZwZHPaYDayNBevdxKykA;
				}
			}

			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x06000344 RID: 836 RVA: 0x0000530B File Offset: 0x0000350B
			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
					{
						ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
						return 0.0;
					}
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IOHWYLPfQQlAffRUPhHbhwdDGaWk.SHqaGETnVgJTYtqLdhZflCFRPBKW;
				}
			}

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x06000345 RID: 837 RVA: 0x00032024 File Offset: 0x00030224
			internal ButtonStateFlags NaunYgnEofItAYHWzZGhbMVZXfKT
			{
				get
				{
					Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA bwpkThTGvdmXmbqqXUTeymYYADZjA = (Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (bwpkThTGvdmXmbqqXUTeymYYADZjA.mUJGVRmxZNeOrKNNMMDKufkqwwjDA)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!bwpkThTGvdmXmbqqXUTeymYYADZjA.dgLCMVEQSYoKoNgOkJYKnqKKRjhb)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (bwpkThTGvdmXmbqqXUTeymYYADZjA.dgLCMVEQSYoKoNgOkJYKnqKKRjhb)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			// Token: 0x06000346 RID: 838 RVA: 0x0000534A File Offset: 0x0000354A
			internal Button(Controller A_1, int A_2, string A_3, HardwareButtonInfo A_4) : base(A_1, A_2, A_3, ControllerElementType.Button)
			{
				this.fuVVJeNPjIGsaeSzACpupNnXrgrL = A_4;
				this.znbaxGxhRXbWvmLUUUVcTfglolBA = new Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA(ReInput.configVars.updateLoop, false);
			}

			// Token: 0x06000347 RID: 839 RVA: 0x00005374 File Offset: 0x00003574
			internal Button(Controller A_1, int A_2, string A_3, bool A_4, HardwareButtonInfo A_5) : base(A_1, A_2, A_3, ControllerElementType.Button)
			{
				this.fuVVJeNPjIGsaeSzACpupNnXrgrL = A_5;
				this.evatwZDxHVhPSvLkOiribnozxreiA = A_4;
				this.znbaxGxhRXbWvmLUUUVcTfglolBA = new Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA(ReInput.configVars.updateLoop, A_4);
			}

			// Token: 0x06000348 RID: 840 RVA: 0x0003206C File Offset: 0x0003026C
			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
				{
					ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
					return false;
				}
				if (speed <= 0f)
				{
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).lqDbwvltkGIbVhGNmZQDCmOqPsRWA.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
				}
				return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IOHWYLPfQQlAffRUPhHbhwdDGaWk.dBSMuoTXNVdemVfLJdZrxvXJHQFH(speed);
			}

			// Token: 0x06000349 RID: 841 RVA: 0x000320D4 File Offset: 0x000302D4
			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA)
				{
					ReInput.CheckInitialized(this.sWTAlEgpBQeNSPmSTlNnOVWyIsycA);
					return false;
				}
				if (!this.justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).lqDbwvltkGIbVhGNmZQDCmOqPsRWA.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
				}
				return ((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).IOHWYLPfQQlAffRUPhHbhwdDGaWk.dBSMuoTXNVdemVfLJdZrxvXJHQFH(speed);
			}

			// Token: 0x0600034A RID: 842 RVA: 0x00032144 File Offset: 0x00030344
			internal void aJKzOJvOZNgUIEuZAqRvLgTmmauS(UpdateLoopType A_1, int A_2, ControllerDataUpdater A_3)
			{
				if (this.znbaxGxhRXbWvmLUUUVcTfglolBA != null && this.znbaxGxhRXbWvmLUUUVcTfglolBA.jMdfnQEjXzfudcMFFrwLBeQccwgqe != (int)A_1)
				{
					this.znbaxGxhRXbWvmLUUUVcTfglolBA.njKsyzqMnudoelxKuqYQpSHAiHkq = A_1;
				}
				if (this.evatwZDxHVhPSvLkOiribnozxreiA)
				{
					((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.SbipAFRTaRdUjhzNqVKVxUyJIDyh)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).UhSpLgTYcuvGAGuSdxxXoNzmvUte(A_3.buttonPressureValues[A_2]);
					return;
				}
				((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).NvuaDaefGYYwLJtTrYEAsfovvVty(A_3.buttonValues[A_2]);
			}

			// Token: 0x0600034B RID: 843 RVA: 0x000321B8 File Offset: 0x000303B8
			internal void KQCkzfztIZInUkmVbUEQZjdhTCLD(UpdateLoopType A_1)
			{
				if (this.znbaxGxhRXbWvmLUUUVcTfglolBA != null && this.znbaxGxhRXbWvmLUUUVcTfglolBA.jMdfnQEjXzfudcMFFrwLBeQccwgqe != (int)A_1)
				{
					this.znbaxGxhRXbWvmLUUUVcTfglolBA.njKsyzqMnudoelxKuqYQpSHAiHkq = A_1;
				}
				if (this.evatwZDxHVhPSvLkOiribnozxreiA)
				{
					((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.SbipAFRTaRdUjhzNqVKVxUyJIDyh)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).UhSpLgTYcuvGAGuSdxxXoNzmvUte(0f);
					return;
				}
				((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.znbaxGxhRXbWvmLUUUVcTfglolBA.WcmEmWehoACKlcKoaZVxkHPRBOaQc).NvuaDaefGYYwLJtTrYEAsfovvVty(false);
			}

			// Token: 0x0600034C RID: 844 RVA: 0x00032220 File Offset: 0x00030420
			internal void QHLjczIVjgRXjLEJwgthpehtVzE()
			{
				for (int i = 0; i < this.znbaxGxhRXbWvmLUUUVcTfglolBA.kcAjzFxnLKbmEMcTyhEZMjkxHALF.Count; i++)
				{
					Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt mHNHLxtZRqaemBQvsxEGhWgSRYlt = this.znbaxGxhRXbWvmLUUUVcTfglolBA.kcAjzFxnLKbmEMcTyhEZMjkxHALF[i];
					if (mHNHLxtZRqaemBQvsxEGhWgSRYlt != null)
					{
						if (this.evatwZDxHVhPSvLkOiribnozxreiA)
						{
							((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.SbipAFRTaRdUjhzNqVKVxUyJIDyh)mHNHLxtZRqaemBQvsxEGhWgSRYlt).UhSpLgTYcuvGAGuSdxxXoNzmvUte(0f);
						}
						else
						{
							((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)mHNHLxtZRqaemBQvsxEGhWgSRYlt).NvuaDaefGYYwLJtTrYEAsfovvVty(false);
						}
					}
				}
			}

			// Token: 0x040002BE RID: 702
			internal readonly bool evatwZDxHVhPSvLkOiribnozxreiA;

			// Token: 0x040002BF RID: 703
			internal readonly HardwareButtonInfo fuVVJeNPjIGsaeSzACpupNnXrgrL;

			// Token: 0x0200004C RID: 76
			internal class lHDwAYugpBAsYJMVeoxHWMlNMGRGA : Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR
			{
				// Token: 0x0600034D RID: 845 RVA: 0x00032284 File Offset: 0x00030484
				public lHDwAYugpBAsYJMVeoxHWMlNMGRGA(UpdateLoopSetting A_1, bool A_2) : base(A_1)
				{
					for (int i = 0; i < this.SOYbhlJWgGhAqQPLAEkmCsNEEwruB; i++)
					{
						if (A_2)
						{
							this.YGoeedXtqsREinUIYplunGRnaUBD[i] = new Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.SbipAFRTaRdUjhzNqVKVxUyJIDyh();
						}
						else
						{
							this.YGoeedXtqsREinUIYplunGRnaUBD[i] = new Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA();
						}
					}
					this.WcmEmWehoACKlcKoaZVxkHPRBOaQc = this.YGoeedXtqsREinUIYplunGRnaUBD[0];
				}

				// Token: 0x0600034E RID: 846 RVA: 0x000322D8 File Offset: 0x000304D8
				public void HhskJHVdrZAMEqJiAwWWJWOuzXde(float A_1)
				{
					for (int i = 0; i < this.YGoeedXtqsREinUIYplunGRnaUBD.Length; i++)
					{
						((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.YGoeedXtqsREinUIYplunGRnaUBD[i]).lqDbwvltkGIbVhGNmZQDCmOqPsRWA.CAXSpubWZqxcTpxRmqTZpPGDLpFk(A_1);
					}
				}

				// Token: 0x0600034F RID: 847 RVA: 0x00032310 File Offset: 0x00030510
				public void cWYtskxTfpoLAZkhGwkAhhHUCVHq()
				{
					for (int i = 0; i < this.YGoeedXtqsREinUIYplunGRnaUBD.Length; i++)
					{
						((Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA)this.YGoeedXtqsREinUIYplunGRnaUBD[i]).lqDbwvltkGIbVhGNmZQDCmOqPsRWA.CAXSpubWZqxcTpxRmqTZpPGDLpFk(0.3f);
					}
				}

				// Token: 0x0200004D RID: 77
				public class BwpkThTGvdmXmbqqXUTeymYYADZjA : Controller.Element.lXWAMNACmJWEzoPsoONULlKgkOqR.mHNHLxtZRqaemBQvsxEGhWgSRYlt
				{
					// Token: 0x06000350 RID: 848 RVA: 0x000053A7 File Offset: 0x000035A7
					public BwpkThTGvdmXmbqqXUTeymYYADZjA()
					{
						this.IOHWYLPfQQlAffRUPhHbhwdDGaWk = new ButtonStateRecorder();
						this.lqDbwvltkGIbVhGNmZQDCmOqPsRWA = new yrvAdJcWjyNKnTjDkNBaBpxKQcjhb(0.3f);
					}

					// Token: 0x06000351 RID: 849 RVA: 0x0003234C File Offset: 0x0003054C
					public void NvuaDaefGYYwLJtTrYEAsfovvVty(bool A_1)
					{
						if (this.dgLCMVEQSYoKoNgOkJYKnqKKRjhb != this.mUJGVRmxZNeOrKNNMMDKufkqwwjDA)
						{
							this.dgLCMVEQSYoKoNgOkJYKnqKKRjhb = this.mUJGVRmxZNeOrKNNMMDKufkqwwjDA;
						}
						if (this.mUJGVRmxZNeOrKNNMMDKufkqwwjDA != A_1)
						{
							this.mUJGVRmxZNeOrKNNMMDKufkqwwjDA = A_1;
						}
						this.IOHWYLPfQQlAffRUPhHbhwdDGaWk.YrWsQqYSgawNqBjZniXtogJhGqhs(A_1 && !this.dgLCMVEQSYoKoNgOkJYKnqKKRjhb, A_1, ReInput.unscaledTime);
						this.lqDbwvltkGIbVhGNmZQDCmOqPsRWA.wslkHESJEInRjPPtzJOTPtKLxADI(0.3f, A_1 && !this.dgLCMVEQSYoKoNgOkJYKnqKKRjhb, A_1);
					}

					// Token: 0x06000352 RID: 850 RVA: 0x000053CA File Offset: 0x000035CA
					public virtual void GVSIHpvpJOadNpJmXAkAfqGxFlsEA()
					{
						this.mUJGVRmxZNeOrKNNMMDKufkqwwjDA = false;
						this.dgLCMVEQSYoKoNgOkJYKnqKKRjhb = false;
						this.IOHWYLPfQQlAffRUPhHbhwdDGaWk.cicvvIwPOZAVQAkdoSThHHSJFNdA();
						this.lqDbwvltkGIbVhGNmZQDCmOqPsRWA.VqzLdvgCGuyZsTDuMsMOtRjAyhlD();
					}

					// Token: 0x040002C0 RID: 704
					public bool mUJGVRmxZNeOrKNNMMDKufkqwwjDA;

					// Token: 0x040002C1 RID: 705
					public bool dgLCMVEQSYoKoNgOkJYKnqKKRjhb;

					// Token: 0x040002C2 RID: 706
					public ButtonStateRecorder IOHWYLPfQQlAffRUPhHbhwdDGaWk;

					// Token: 0x040002C3 RID: 707
					public yrvAdJcWjyNKnTjDkNBaBpxKQcjhb lqDbwvltkGIbVhGNmZQDCmOqPsRWA;
				}

				// Token: 0x0200004E RID: 78
				public class SbipAFRTaRdUjhzNqVKVxUyJIDyh : Controller.Button.lHDwAYugpBAsYJMVeoxHWMlNMGRGA.BwpkThTGvdmXmbqqXUTeymYYADZjA
				{
					// Token: 0x06000354 RID: 852 RVA: 0x000323C4 File Offset: 0x000305C4
					public void UhSpLgTYcuvGAGuSdxxXoNzmvUte(float A_1)
					{
						if (this.ysCNWKIcTbchvNyALyflPfBObVxt != this.OgjjiOOWooIlzReNgYVOmYwDljHt)
						{
							this.ysCNWKIcTbchvNyALyflPfBObVxt = this.OgjjiOOWooIlzReNgYVOmYwDljHt;
						}
						if (this.OgjjiOOWooIlzReNgYVOmYwDljHt != A_1)
						{
							this.OgjjiOOWooIlzReNgYVOmYwDljHt = ((A_1 > 0.001f) ? A_1 : 0f);
						}
						base.NvuaDaefGYYwLJtTrYEAsfovvVty(this.OgjjiOOWooIlzReNgYVOmYwDljHt > 0f);
					}

					// Token: 0x06000355 RID: 853 RVA: 0x000053F8 File Offset: 0x000035F8
					public virtual void KGuxMGNIUbBauxWkrCWAzfKxGXLl()
					{
						base.GVSIHpvpJOadNpJmXAkAfqGxFlsEA();
						this.OgjjiOOWooIlzReNgYVOmYwDljHt = 0f;
						this.ysCNWKIcTbchvNyALyflPfBObVxt = 0f;
					}

					// Token: 0x040002C4 RID: 708
					public float OgjjiOOWooIlzReNgYVOmYwDljHt;

					// Token: 0x040002C5 RID: 709
					public float ysCNWKIcTbchvNyALyflPfBObVxt;
				}
			}
		}

		// Token: 0x0200004F RID: 79
		public abstract class CompoundElement
		{
			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x06000356 RID: 854 RVA: 0x00005416 File Offset: 0x00003616
			public int id
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return -1;
					}
					return this.qnXpLjktzlJXyuQVEKVOmKoHlSZe;
				}
			}

			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x06000357 RID: 855 RVA: 0x00005439 File Offset: 0x00003639
			public string name
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return string.Empty;
					}
					return this.inWTXukeoamPsXEnqGhrcpituaTTA;
				}
			}

			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x06000358 RID: 856 RVA: 0x00005460 File Offset: 0x00003660
			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return CompoundControllerElementType.Axis2D;
					}
					return this.wwlbIJELajLOWngDyQSoPjTnUWkw;
				}
			}

			// Token: 0x170000EA RID: 234
			// (get) Token: 0x06000359 RID: 857 RVA: 0x00005483 File Offset: 0x00003683
			public bool hasElements
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return false;
					}
					return this.dgfBRtnvmMCLOgTfMTcRJOWomNiEb > 0;
				}
			}

			// Token: 0x170000EB RID: 235
			// (get) Token: 0x0600035A RID: 858 RVA: 0x000054A9 File Offset: 0x000036A9
			public int elementCount
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return 0;
					}
					return this.dgfBRtnvmMCLOgTfMTcRJOWomNiEb;
				}
			}

			// Token: 0x170000EC RID: 236
			// (get) Token: 0x0600035B RID: 859
			public abstract int elementCapacity { get; }

			// Token: 0x170000ED RID: 237
			// (get) Token: 0x0600035C RID: 860 RVA: 0x00032424 File Offset: 0x00030624
			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = this.HlLRXnlhPhnDlNGsfSEbhMjggjpN.GetElementIdentifierById(this.qnXpLjktzlJXyuQVEKVOmKoHlSZe);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			// Token: 0x0600035D RID: 861 RVA: 0x00032468 File Offset: 0x00030668
			internal CompoundElement(Controller A_1, int A_2, string A_3, CompoundControllerElementType A_4)
			{
				this.HlLRXnlhPhnDlNGsfSEbhMjggjpN = A_1;
				this.qnXpLjktzlJXyuQVEKVOmKoHlSZe = A_2;
				this.inWTXukeoamPsXEnqGhrcpituaTTA = A_3;
				this.wwlbIJELajLOWngDyQSoPjTnUWkw = A_4;
				this.LmDiLVxGOwjFUgNngDBesfSgOSHlA = new Controller.CompoundElement.eBoZfAtfcmXHVjuoIEhADxiaaXZR[this.elementCapacity];
				this.pANfDQkrlqDzegAZBmPpfPfjhkXtB = ReInput.id;
			}

			// Token: 0x0600035E RID: 862 RVA: 0x000054CC File Offset: 0x000036CC
			internal Controller.Element lkYFWmACQkmVZuvcfDgbRbfnKgEj(int A_1)
			{
				if (A_1 < 0 || A_1 >= this.LmDiLVxGOwjFUgNngDBesfSgOSHlA.Length)
				{
					return null;
				}
				if (this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1] == null)
				{
					return null;
				}
				return this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1].qwLgAEJpDtYuhuQdhauVmefFJpLe;
			}

			// Token: 0x0600035F RID: 863 RVA: 0x000324B4 File Offset: 0x000306B4
			internal \u0001 lkYFWmACQkmVZuvcfDgbRbfnKgEj<\u0001>(int A_1) where \u0001 : Controller.Element
			{
				if (A_1 < 0 || A_1 >= this.LmDiLVxGOwjFUgNngDBesfSgOSHlA.Length)
				{
					return default(\u0001);
				}
				if (this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1] == null)
				{
					return default(\u0001);
				}
				return this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1].qwLgAEJpDtYuhuQdhauVmefFJpLe as \u0001;
			}

			// Token: 0x06000360 RID: 864 RVA: 0x00032508 File Offset: 0x00030708
			internal \u0001 iDxdzWAuYVVvwswdeHOhNUQXbYMtA<\u0001>(int A_1, out int A_2) where \u0001 : Controller.Element
			{
				A_2 = -1;
				if (A_1 < 0 || A_1 >= this.LmDiLVxGOwjFUgNngDBesfSgOSHlA.Length)
				{
					return default(\u0001);
				}
				if (this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1] == null)
				{
					return default(\u0001);
				}
				A_2 = this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1].HZnfbplHzKzBecQdqVmteiGlmHYv;
				return this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1].qwLgAEJpDtYuhuQdhauVmefFJpLe as \u0001;
			}

			// Token: 0x06000361 RID: 865 RVA: 0x0003256C File Offset: 0x0003076C
			internal bool WWUilJVxiirZfJDGzqpkKznvGcUL(Controller.Element A_1, int A_2)
			{
				if (A_1 == null)
				{
					return false;
				}
				if (this.dgfBRtnvmMCLOgTfMTcRJOWomNiEb >= this.elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (A_1.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (this.srqrpFWZRjqjeuEwLcpVPKfYtSXL(A_1) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = this.IeNyzGhJbXKPevZZwcTsDJuCmizo();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return this.vzuPrcTHjZvqcWNfuaQRAvFSRSJbA(A_1, A_2, num);
			}

			// Token: 0x06000362 RID: 866 RVA: 0x000325E4 File Offset: 0x000307E4
			internal bool WufaTbjhSKRZINwdAJOYYrJgaLfE(Controller.Element A_1)
			{
				if (A_1 == null)
				{
					return false;
				}
				if (this.dgfBRtnvmMCLOgTfMTcRJOWomNiEb == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = this.srqrpFWZRjqjeuEwLcpVPKfYtSXL(A_1);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return this.FwmcDOCSDgVsHabXgEETVfmsLjuAb(num);
			}

			// Token: 0x06000363 RID: 867 RVA: 0x0003262C File Offset: 0x0003082C
			internal void pLYqskZblurHFzrkmCufgsUtTbKwA()
			{
				for (int i = 0; i < this.LmDiLVxGOwjFUgNngDBesfSgOSHlA.Length; i++)
				{
					this.FwmcDOCSDgVsHabXgEETVfmsLjuAb(i);
				}
				this.dgfBRtnvmMCLOgTfMTcRJOWomNiEb = 0;
			}

			// Token: 0x06000364 RID: 868 RVA: 0x0003265C File Offset: 0x0003085C
			private int srqrpFWZRjqjeuEwLcpVPKfYtSXL(Controller.Element A_1)
			{
				if (A_1 == null)
				{
					return -1;
				}
				for (int i = 0; i < this.LmDiLVxGOwjFUgNngDBesfSgOSHlA.Length; i++)
				{
					if (this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[i] != null && this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[i].qwLgAEJpDtYuhuQdhauVmefFJpLe == A_1)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06000365 RID: 869 RVA: 0x000326A0 File Offset: 0x000308A0
			private bool vzuPrcTHjZvqcWNfuaQRAvFSRSJbA(Controller.Element A_1, int A_2, int A_3)
			{
				if (A_3 < 0 || A_3 >= this.LmDiLVxGOwjFUgNngDBesfSgOSHlA.Length)
				{
					return false;
				}
				if (this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_3] != null)
				{
					return false;
				}
				this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_3] = new Controller.CompoundElement.eBoZfAtfcmXHVjuoIEhADxiaaXZR(A_1, A_2);
				A_1.ugZBUZCFxJFpjkVRBWKQDhwkGrcwA(this);
				this.dgfBRtnvmMCLOgTfMTcRJOWomNiEb++;
				return true;
			}

			// Token: 0x06000366 RID: 870 RVA: 0x000326F0 File Offset: 0x000308F0
			private bool FwmcDOCSDgVsHabXgEETVfmsLjuAb(int A_1)
			{
				if (A_1 < 0 || A_1 >= this.LmDiLVxGOwjFUgNngDBesfSgOSHlA.Length)
				{
					return false;
				}
				if (this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1] == null)
				{
					return false;
				}
				if (this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1].qwLgAEJpDtYuhuQdhauVmefFJpLe != null)
				{
					this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1].qwLgAEJpDtYuhuQdhauVmefFJpLe.bMoEYnYhsFaOcdcXfFAzDmDkbfvVb(this);
				}
				this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[A_1] = null;
				this.dgfBRtnvmMCLOgTfMTcRJOWomNiEb--;
				return true;
			}

			// Token: 0x06000367 RID: 871 RVA: 0x00032754 File Offset: 0x00030954
			private int IeNyzGhJbXKPevZZwcTsDJuCmizo()
			{
				for (int i = 0; i < this.LmDiLVxGOwjFUgNngDBesfSgOSHlA.Length; i++)
				{
					if (this.LmDiLVxGOwjFUgNngDBesfSgOSHlA[i] == null)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x040002C6 RID: 710
			private int qnXpLjktzlJXyuQVEKVOmKoHlSZe;

			// Token: 0x040002C7 RID: 711
			private string inWTXukeoamPsXEnqGhrcpituaTTA;

			// Token: 0x040002C8 RID: 712
			private CompoundControllerElementType wwlbIJELajLOWngDyQSoPjTnUWkw;

			// Token: 0x040002C9 RID: 713
			private int dgfBRtnvmMCLOgTfMTcRJOWomNiEb;

			// Token: 0x040002CA RID: 714
			private Controller.CompoundElement.eBoZfAtfcmXHVjuoIEhADxiaaXZR[] LmDiLVxGOwjFUgNngDBesfSgOSHlA;

			// Token: 0x040002CB RID: 715
			private Controller HlLRXnlhPhnDlNGsfSEbhMjggjpN;

			// Token: 0x040002CC RID: 716
			internal readonly int pANfDQkrlqDzegAZBmPpfPfjhkXtB;

			// Token: 0x02000050 RID: 80
			private class eBoZfAtfcmXHVjuoIEhADxiaaXZR
			{
				// Token: 0x06000368 RID: 872 RVA: 0x000054F8 File Offset: 0x000036F8
				public eBoZfAtfcmXHVjuoIEhADxiaaXZR(Controller.Element A_1, int A_2)
				{
					this.qwLgAEJpDtYuhuQdhauVmefFJpLe = A_1;
					this.HZnfbplHzKzBecQdqVmteiGlmHYv = A_2;
				}

				// Token: 0x040002CD RID: 717
				public readonly Controller.Element qwLgAEJpDtYuhuQdhauVmefFJpLe;

				// Token: 0x040002CE RID: 718
				public readonly int HZnfbplHzKzBecQdqVmteiGlmHYv;
			}
		}

		// Token: 0x02000051 RID: 81
		public sealed class Axis2D : Controller.CompoundElement
		{
			// Token: 0x170000EE RID: 238
			// (get) Token: 0x06000369 RID: 873 RVA: 0x0000550E File Offset: 0x0000370E
			public override int elementCapacity
			{
				get
				{
					return 2;
				}
			}

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x0600036A RID: 874 RVA: 0x00005511 File Offset: 0x00003711
			public Controller.Axis xAxis
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Axis>(0);
				}
			}

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x0600036B RID: 875 RVA: 0x00005535 File Offset: 0x00003735
			public Controller.Axis yAxis
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Axis>(1);
				}
			}

			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x0600036C RID: 876 RVA: 0x00005559 File Offset: 0x00003759
			public Vector2 value
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return Vector2.zero;
					}
					return this.osCNDJLicACplHYKJibFttDynaHIb();
				}
			}

			// Token: 0x170000F2 RID: 242
			// (get) Token: 0x0600036D RID: 877 RVA: 0x00005580 File Offset: 0x00003780
			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return Vector2.zero;
					}
					return this.DqeomljlkWeWhznXHZpoUbWurvrD();
				}
			}

			// Token: 0x170000F3 RID: 243
			// (get) Token: 0x0600036E RID: 878 RVA: 0x00032784 File Offset: 0x00030984
			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return Vector2.zero;
					}
					return new Vector2((this.xAxis != null) ? this.xAxis.valueRaw : 0f, (this.yAxis != null) ? this.yAxis.valueRaw : 0f);
				}
			}

			// Token: 0x170000F4 RID: 244
			// (get) Token: 0x0600036F RID: 879 RVA: 0x000327EC File Offset: 0x000309EC
			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return Vector2.zero;
					}
					return new Vector2((this.xAxis != null) ? this.xAxis.valueRawPrev : 0f, (this.yAxis != null) ? this.yAxis.valueRawPrev : 0f);
				}
			}

			// Token: 0x06000370 RID: 880 RVA: 0x000055A7 File Offset: 0x000037A7
			internal Axis2D(Controller A_1, int A_2, string A_3, Controller.Axis A_4, Controller.Axis A_5, int A_6, int A_7, CalibrationMap A_8) : base(A_1, A_2, A_3, CompoundControllerElementType.Axis2D)
			{
				base.WWUilJVxiirZfJDGzqpkKznvGcUL(A_4, A_6);
				base.WWUilJVxiirZfJDGzqpkKznvGcUL(A_5, A_7);
				this.uZpAvuZgiIIderReJDWMGQmyTLVA = A_8;
			}

			// Token: 0x06000371 RID: 881 RVA: 0x00032854 File Offset: 0x00030A54
			internal void pwFxdqtVCppluMaoszqiCANFgETr()
			{
				Vector2 value = this.value;
				if (this.xAxis != null)
				{
					this.xAxis.MFaZbePehqPkSTEYlcaoUcwvUKSG(value.x);
				}
				if (this.yAxis != null)
				{
					this.yAxis.MFaZbePehqPkSTEYlcaoUcwvUKSG(value.y);
				}
			}

			// Token: 0x06000372 RID: 882 RVA: 0x0003289C File Offset: 0x00030A9C
			private Vector2 osCNDJLicACplHYKJibFttDynaHIb()
			{
				if (this.uZpAvuZgiIIderReJDWMGQmyTLVA == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Controller.Axis axis = base.iDxdzWAuYVVvwswdeHOhNUQXbYMtA<Controller.Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Controller.Axis axis2 = base.iDxdzWAuYVVvwswdeHOhNUQXbYMtA<Controller.Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = (axis != null) ? axis.valueRaw : 0f;
				float valueRawY = (axis2 != null) ? axis2.valueRaw : 0f;
				return this.uZpAvuZgiIIderReJDWMGQmyTLVA.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			// Token: 0x06000373 RID: 883 RVA: 0x00032924 File Offset: 0x00030B24
			private Vector2 DqeomljlkWeWhznXHZpoUbWurvrD()
			{
				if (this.uZpAvuZgiIIderReJDWMGQmyTLVA == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Controller.Axis axis = base.iDxdzWAuYVVvwswdeHOhNUQXbYMtA<Controller.Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Controller.Axis axis2 = base.iDxdzWAuYVVvwswdeHOhNUQXbYMtA<Controller.Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = (axis != null) ? axis.valueRawPrev : 0f;
				float valueRawY = (axis2 != null) ? axis2.valueRawPrev : 0f;
				return this.uZpAvuZgiIIderReJDWMGQmyTLVA.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			// Token: 0x040002CF RID: 719
			private const int vazBvsPnjjhsDeFVzHtxEYaDAqXb = 2;

			// Token: 0x040002D0 RID: 720
			private CalibrationMap uZpAvuZgiIIderReJDWMGQmyTLVA;
		}

		// Token: 0x02000052 RID: 82
		public sealed class Hat : Controller.CompoundElement
		{
			// Token: 0x170000F5 RID: 245
			// (get) Token: 0x06000374 RID: 884 RVA: 0x000055D1 File Offset: 0x000037D1
			public override int elementCapacity
			{
				get
				{
					return 8;
				}
			}

			// Token: 0x170000F6 RID: 246
			// (get) Token: 0x06000375 RID: 885 RVA: 0x000055D4 File Offset: 0x000037D4
			// (set) Token: 0x06000376 RID: 886 RVA: 0x000055F7 File Offset: 0x000037F7
			public bool force4Way
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return false;
					}
					return this.EBTiGZYTwzYhKdevnrXDDURkoaTq;
				}
				set
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return;
					}
					this.EBTiGZYTwzYhKdevnrXDDURkoaTq = value;
				}
			}

			// Token: 0x170000F7 RID: 247
			// (get) Token: 0x06000377 RID: 887 RVA: 0x0000561A File Offset: 0x0000381A
			public int directionCount
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return 0;
					}
					return this.TQBeLufLArNCkWUHwvDnSpQfOsRZ;
				}
			}

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x06000378 RID: 888 RVA: 0x0000563D File Offset: 0x0000383D
			public IList<Controller.Button> Buttons
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return EmptyObjects<Controller.Button>.EmptyReadOnlyIListT;
					}
					return this.AMWfdRAxRKtrEBBdcwIIjEOdTuLL;
				}
			}

			// Token: 0x170000F9 RID: 249
			// (get) Token: 0x06000379 RID: 889 RVA: 0x00005664 File Offset: 0x00003864
			public Controller.Button buttonUp
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(0);
				}
			}

			// Token: 0x170000FA RID: 250
			// (get) Token: 0x0600037A RID: 890 RVA: 0x00005688 File Offset: 0x00003888
			public Controller.Button buttonRight
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(2);
				}
			}

			// Token: 0x170000FB RID: 251
			// (get) Token: 0x0600037B RID: 891 RVA: 0x000056AC File Offset: 0x000038AC
			public Controller.Button buttonDown
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(4);
				}
			}

			// Token: 0x170000FC RID: 252
			// (get) Token: 0x0600037C RID: 892 RVA: 0x000056D0 File Offset: 0x000038D0
			public Controller.Button buttonLeft
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(6);
				}
			}

			// Token: 0x170000FD RID: 253
			// (get) Token: 0x0600037D RID: 893 RVA: 0x000056F4 File Offset: 0x000038F4
			public Controller.Button buttonUpRight
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(1);
				}
			}

			// Token: 0x170000FE RID: 254
			// (get) Token: 0x0600037E RID: 894 RVA: 0x00005718 File Offset: 0x00003918
			public Controller.Button buttonDownRight
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(3);
				}
			}

			// Token: 0x170000FF RID: 255
			// (get) Token: 0x0600037F RID: 895 RVA: 0x0000573C File Offset: 0x0000393C
			public Controller.Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(5);
				}
			}

			// Token: 0x17000100 RID: 256
			// (get) Token: 0x06000380 RID: 896 RVA: 0x00005760 File Offset: 0x00003960
			public Controller.Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(7);
				}
			}

			// Token: 0x06000381 RID: 897 RVA: 0x000329AC File Offset: 0x00030BAC
			internal Hat(Controller A_1, int A_2, string A_3, Controller.Button[] A_4, int[] A_5) : base(A_1, A_2, A_3, CompoundControllerElementType.Hat)
			{
				int num = (A_4 != null) ? A_4.Length : 0;
				int num2 = (A_5 != null) ? A_5.Length : 0;
				if (num != num2)
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("buttons.Length must be 0, 4, or 8! Length: " + num.ToString());
				}
				for (int i = 0; i < num; i++)
				{
					base.WWUilJVxiirZfJDGzqpkKznvGcUL(A_4[i], A_5[i]);
				}
				this.bttKidFwUHEojyEHURTBZRpyBRrdA = A_4;
				this.OYXvTYOkMycSLiMXJyQBlqfXNihnA = A_5;
				this.TQBeLufLArNCkWUHwvDnSpQfOsRZ = num;
				this.AMWfdRAxRKtrEBBdcwIIjEOdTuLL = new ReadOnlyCollection<Controller.Button>(A_4);
			}

			// Token: 0x06000382 RID: 898 RVA: 0x00032A4C File Offset: 0x00030C4C
			internal void VemTStXfXrIsdaQWUBvMMdXulhEY(UpdateLoopType A_1, ControllerDataUpdater A_2)
			{
				if (this.TQBeLufLArNCkWUHwvDnSpQfOsRZ == 0)
				{
					return;
				}
				if (this.TQBeLufLArNCkWUHwvDnSpQfOsRZ == 8 && (this.EBTiGZYTwzYhKdevnrXDDURkoaTq || ReInput.configVars.force4WayHats))
				{
					this.BLuhWWiEjzswwjJjRbxJmgmbTOgR(this.bttKidFwUHEojyEHURTBZRpyBRrdA[0], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[0], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[7], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[1], A_1, A_2);
					this.BLuhWWiEjzswwjJjRbxJmgmbTOgR(this.bttKidFwUHEojyEHURTBZRpyBRrdA[2], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[2], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[1], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[3], A_1, A_2);
					this.BLuhWWiEjzswwjJjRbxJmgmbTOgR(this.bttKidFwUHEojyEHURTBZRpyBRrdA[4], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[4], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[5], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[3], A_1, A_2);
					this.BLuhWWiEjzswwjJjRbxJmgmbTOgR(this.bttKidFwUHEojyEHURTBZRpyBRrdA[6], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[6], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[5], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[7], A_1, A_2);
					this.kSnGnWjGpVGghPYcZubwJnLrcLNGA(this.bttKidFwUHEojyEHURTBZRpyBRrdA[1], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[1], A_1, A_2);
					this.kSnGnWjGpVGghPYcZubwJnLrcLNGA(this.bttKidFwUHEojyEHURTBZRpyBRrdA[3], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[3], A_1, A_2);
					this.kSnGnWjGpVGghPYcZubwJnLrcLNGA(this.bttKidFwUHEojyEHURTBZRpyBRrdA[5], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[5], A_1, A_2);
					this.kSnGnWjGpVGghPYcZubwJnLrcLNGA(this.bttKidFwUHEojyEHURTBZRpyBRrdA[7], this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[7], A_1, A_2);
					return;
				}
				for (int i = 0; i < this.bttKidFwUHEojyEHURTBZRpyBRrdA.Length; i++)
				{
					if (this.bttKidFwUHEojyEHURTBZRpyBRrdA[i] != null)
					{
						this.bttKidFwUHEojyEHURTBZRpyBRrdA[i].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, this.OYXvTYOkMycSLiMXJyQBlqfXNihnA[i], A_2);
					}
				}
			}

			// Token: 0x06000383 RID: 899 RVA: 0x00032BBC File Offset: 0x00030DBC
			private void BLuhWWiEjzswwjJjRbxJmgmbTOgR(Controller.Button A_1, int A_2, int A_3, int A_4, UpdateLoopType A_5, ControllerDataUpdater A_6)
			{
				if (A_1 == null || A_2 < 0 || A_2 >= A_6.buttonCount)
				{
					return;
				}
				if (!A_1.isPressureSensitive)
				{
					if (A_3 >= 0 && A_3 < A_6.buttonCount)
					{
						A_6.buttonValues[A_2] |= A_6.buttonValues[A_3];
					}
					if (A_4 >= 0 && A_4 < A_6.buttonCount)
					{
						A_6.buttonValues[A_2] |= A_6.buttonValues[A_4];
					}
				}
				else
				{
					A_6.buttonPressureValues[A_2] = MathTools.MaxMagnitude(A_6.buttonPressureValues[A_2], MathTools.MaxMagnitude((A_3 >= 0 && A_3 < A_6.buttonCount) ? A_6.buttonPressureValues[A_3] : 0f, (A_4 >= 0 && A_4 < A_6.buttonCount) ? A_6.buttonPressureValues[A_4] : 0f));
				}
				A_1.aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_5, A_2, A_6);
			}

			// Token: 0x06000384 RID: 900 RVA: 0x00005784 File Offset: 0x00003984
			private void kSnGnWjGpVGghPYcZubwJnLrcLNGA(Controller.Button A_1, int A_2, UpdateLoopType A_3, ControllerDataUpdater A_4)
			{
				if (A_1 == null || A_2 < 0 || A_2 >= A_4.buttonCount)
				{
					return;
				}
				if (!A_1.isPressureSensitive)
				{
					A_4.buttonValues[A_2] = false;
				}
				else
				{
					A_4.buttonPressureValues[A_2] = 0f;
				}
				A_1.aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_3, A_2, A_4);
			}

			// Token: 0x040002D1 RID: 721
			private const int IpgsheGLUwLnJGIQAxUGBQEEeeikA = 8;

			// Token: 0x040002D2 RID: 722
			private const int VqpDODMHwIlmnrBzdjBUmIsKsHLT = 0;

			// Token: 0x040002D3 RID: 723
			private const int wSOcOeGoxXclgWSfWBAvDryCOZEPB = 1;

			// Token: 0x040002D4 RID: 724
			private const int SSswdtFTtgTtDWwdQDIJjAzVGLVA = 2;

			// Token: 0x040002D5 RID: 725
			private const int swEViCroikeQpBtFilWYpJgJIUwH = 3;

			// Token: 0x040002D6 RID: 726
			private const int BOmaNqKpqAHzWGCGhxGzATCQvYDMb = 4;

			// Token: 0x040002D7 RID: 727
			private const int ZQqbSFbgiCPlVkTpaiVGrQiwwUmu = 5;

			// Token: 0x040002D8 RID: 728
			private const int MKHEMNjvUeWCRwFWGHynxspVCJJyA = 6;

			// Token: 0x040002D9 RID: 729
			private const int cJtbZWcWOPgikkNyKkvmljVNRLzaA = 7;

			// Token: 0x040002DA RID: 730
			private readonly int TQBeLufLArNCkWUHwvDnSpQfOsRZ;

			// Token: 0x040002DB RID: 731
			private readonly Controller.Button[] bttKidFwUHEojyEHURTBZRpyBRrdA;

			// Token: 0x040002DC RID: 732
			private readonly ReadOnlyCollection<Controller.Button> AMWfdRAxRKtrEBBdcwIIjEOdTuLL;

			// Token: 0x040002DD RID: 733
			private readonly int[] OYXvTYOkMycSLiMXJyQBlqfXNihnA;

			// Token: 0x040002DE RID: 734
			private bool EBTiGZYTwzYhKdevnrXDDURkoaTq;
		}

		// Token: 0x02000053 RID: 83
		public sealed class DirectionalPad : Controller.CompoundElement
		{
			// Token: 0x17000101 RID: 257
			// (get) Token: 0x06000385 RID: 901 RVA: 0x000057C4 File Offset: 0x000039C4
			public override int elementCapacity
			{
				get
				{
					return 4;
				}
			}

			// Token: 0x17000102 RID: 258
			// (get) Token: 0x06000386 RID: 902 RVA: 0x000057C7 File Offset: 0x000039C7
			public IList<Controller.Button> Buttons
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return EmptyObjects<Controller.Button>.EmptyReadOnlyIListT;
					}
					return this.xnksASLmeDSixnsdrUXqUMNrlMel;
				}
			}

			// Token: 0x17000103 RID: 259
			// (get) Token: 0x06000387 RID: 903 RVA: 0x00005664 File Offset: 0x00003864
			public Controller.Button buttonUp
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(0);
				}
			}

			// Token: 0x17000104 RID: 260
			// (get) Token: 0x06000388 RID: 904 RVA: 0x000056F4 File Offset: 0x000038F4
			public Controller.Button buttonRight
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(1);
				}
			}

			// Token: 0x17000105 RID: 261
			// (get) Token: 0x06000389 RID: 905 RVA: 0x00005688 File Offset: 0x00003888
			public Controller.Button buttonDown
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(2);
				}
			}

			// Token: 0x17000106 RID: 262
			// (get) Token: 0x0600038A RID: 906 RVA: 0x00005718 File Offset: 0x00003918
			public Controller.Button buttonLeft
			{
				get
				{
					if (ReInput._id != this.pANfDQkrlqDzegAZBmPpfPfjhkXtB)
					{
						ReInput.CheckInitialized(this.pANfDQkrlqDzegAZBmPpfPfjhkXtB);
						return null;
					}
					return base.lkYFWmACQkmVZuvcfDgbRbfnKgEj<Controller.Button>(3);
				}
			}

			// Token: 0x0600038B RID: 907 RVA: 0x00032CA4 File Offset: 0x00030EA4
			internal DirectionalPad(Controller A_1, int A_2, string A_3, Controller.Button[] A_4, int[] A_5) : base(A_1, A_2, A_3, CompoundControllerElementType.DPad)
			{
				int num = (A_4 != null) ? A_4.Length : 0;
				int num2 = (A_5 != null) ? A_5.Length : 0;
				if (num != num2)
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4)
				{
					throw new ArgumentException("buttons.Length must be 0 or 4! Length: " + num.ToString());
				}
				for (int i = 0; i < num; i++)
				{
					base.WWUilJVxiirZfJDGzqpkKznvGcUL(A_4[i], A_5[i]);
				}
				this.FcbjJtuaMFgDYLfYpAFqfYIBiEbB = A_4;
				this.MieJiJsZQDcwURsEeFgwZkpOwgDk = A_5;
				this.rBCEbysuWpFwXDoxbuJLnxeRMRgd = num;
				this.xnksASLmeDSixnsdrUXqUMNrlMel = new ReadOnlyCollection<Controller.Button>(A_4);
			}

			// Token: 0x0600038C RID: 908 RVA: 0x00032D40 File Offset: 0x00030F40
			internal void pYOiYUPFcFDuKUemhmfGuZJmGmkO(UpdateLoopType A_1, ControllerDataUpdater A_2)
			{
				if (this.rBCEbysuWpFwXDoxbuJLnxeRMRgd == 0)
				{
					return;
				}
				for (int i = 0; i < this.FcbjJtuaMFgDYLfYpAFqfYIBiEbB.Length; i++)
				{
					if (this.FcbjJtuaMFgDYLfYpAFqfYIBiEbB[i] != null)
					{
						this.FcbjJtuaMFgDYLfYpAFqfYIBiEbB[i].aJKzOJvOZNgUIEuZAqRvLgTmmauS(A_1, this.MieJiJsZQDcwURsEeFgwZkpOwgDk[i], A_2);
					}
				}
			}

			// Token: 0x040002DF RID: 735
			private const int jDTdKRATXhYCMTjVNbDhpDQJgCTbA = 4;

			// Token: 0x040002E0 RID: 736
			private const int RLEVaDymTDOxPLoSPBmuGonQwKTF = 0;

			// Token: 0x040002E1 RID: 737
			private const int INUYrMNYlzEhRUOdnyfCRGOhVsBB = 1;

			// Token: 0x040002E2 RID: 738
			private const int mIgaiAakpKPHeydQCeiPJVISBTjY = 2;

			// Token: 0x040002E3 RID: 739
			private const int RlJgpGgIUbkHpAlTMofeaAKQIrVvA = 3;

			// Token: 0x040002E4 RID: 740
			private readonly int rBCEbysuWpFwXDoxbuJLnxeRMRgd;

			// Token: 0x040002E5 RID: 741
			private readonly Controller.Button[] FcbjJtuaMFgDYLfYpAFqfYIBiEbB;

			// Token: 0x040002E6 RID: 742
			private readonly ReadOnlyCollection<Controller.Button> xnksASLmeDSixnsdrUXqUMNrlMel;

			// Token: 0x040002E7 RID: 743
			private readonly int[] MieJiJsZQDcwURsEeFgwZkpOwgDk;
		}

		// Token: 0x02000054 RID: 84
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			// Token: 0x17000107 RID: 263
			// (get) Token: 0x0600038D RID: 909 RVA: 0x000057EE File Offset: 0x000039EE
			internal bool isJoystickConnected
			{
				get
				{
					return this.iLUmyiKhoRCtiphLFSjJQLiKpgBf != null && this.iLUmyiKhoRCtiphLFSjJQLiKpgBf._isConnected;
				}
			}

			// Token: 0x17000108 RID: 264
			// (get) Token: 0x0600038E RID: 910 RVA: 0x00005805 File Offset: 0x00003A05
			internal bool enabled
			{
				get
				{
					return this.iLUmyiKhoRCtiphLFSjJQLiKpgBf != null && this.iLUmyiKhoRCtiphLFSjJQLiKpgBf.enabled;
				}
			}

			// Token: 0x17000109 RID: 265
			// (get) Token: 0x0600038F RID: 911 RVA: 0x0000581C File Offset: 0x00003A1C
			public Controller controller
			{
				get
				{
					return this.iLUmyiKhoRCtiphLFSjJQLiKpgBf;
				}
			}

			// Token: 0x06000390 RID: 912 RVA: 0x00005824 File Offset: 0x00003A24
			internal Extension(IControllerExtensionSource A_1)
			{
				this._reInputId = ReInput.id;
				this.SrkBFcflHWgxSJTtOpYvElCacybfA(A_1);
			}

			// Token: 0x06000391 RID: 913 RVA: 0x0000583E File Offset: 0x00003A3E
			internal Extension(Controller.Extension A_1) : this(A_1.ulbcUMJfGOIwqQUYgUMFHLIEMJdV)
			{
				this.iLUmyiKhoRCtiphLFSjJQLiKpgBf = A_1.iLUmyiKhoRCtiphLFSjJQLiKpgBf;
			}

			// Token: 0x06000392 RID: 914 RVA: 0x00032D8C File Offset: 0x00030F8C
			internal T GetController<T>() where T : Controller
			{
				if (this.iLUmyiKhoRCtiphLFSjJQLiKpgBf == null)
				{
					return default(T);
				}
				return this.iLUmyiKhoRCtiphLFSjJQLiKpgBf as T;
			}

			// Token: 0x06000393 RID: 915 RVA: 0x00005858 File Offset: 0x00003A58
			internal void SetController(Controller controller)
			{
				this.iLUmyiKhoRCtiphLFSjJQLiKpgBf = controller;
			}

			// Token: 0x06000394 RID: 916 RVA: 0x00005861 File Offset: 0x00003A61
			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return this.ulbcUMJfGOIwqQUYgUMFHLIEMJdV;
			}

			// Token: 0x06000395 RID: 917 RVA: 0x00005869 File Offset: 0x00003A69
			internal void SetSource(Controller.Extension extension)
			{
				if (extension == null)
				{
					this.SrkBFcflHWgxSJTtOpYvElCacybfA(null);
					return;
				}
				this.SrkBFcflHWgxSJTtOpYvElCacybfA(extension.ulbcUMJfGOIwqQUYgUMFHLIEMJdV);
			}

			// Token: 0x06000396 RID: 918 RVA: 0x00005882 File Offset: 0x00003A82
			private void SrkBFcflHWgxSJTtOpYvElCacybfA(IControllerExtensionSource A_1)
			{
				this.ulbcUMJfGOIwqQUYgUMFHLIEMJdV = A_1;
				this.SourceUpdated(this.ulbcUMJfGOIwqQUYgUMFHLIEMJdV);
			}

			// Token: 0x06000397 RID: 919 RVA: 0x00002FF9 File Offset: 0x000011F9
			internal virtual void Clear()
			{
			}

			// Token: 0x06000398 RID: 920
			internal abstract void SourceUpdated(IControllerExtensionSource source);

			// Token: 0x06000399 RID: 921
			internal abstract void UpdateData(UpdateLoopType updateLoop);

			// Token: 0x0600039A RID: 922
			internal abstract Controller.Extension Clone();

			// Token: 0x040002E8 RID: 744
			private Controller iLUmyiKhoRCtiphLFSjJQLiKpgBf;

			// Token: 0x040002E9 RID: 745
			private IControllerExtensionSource ulbcUMJfGOIwqQUYgUMFHLIEMJdV;

			// Token: 0x040002EA RID: 746
			internal readonly int _reInputId;
		}

		// Token: 0x02000055 RID: 85
		[CompilerGenerated]
		[Serializable]
		private sealed class PvbFcvGhKjIftOWUKdvsRDbihcbWA
		{
			// Token: 0x0600039D RID: 925 RVA: 0x000058A3 File Offset: 0x00003AA3
			internal bool WVTmhXKcLuHvUQQowAnxZsJXpIRr(Controller A_1, Guid A_2)
			{
				return A_1.ImplementsTemplate(A_2);
			}

			// Token: 0x0600039E RID: 926 RVA: 0x000058AC File Offset: 0x00003AAC
			internal bool npoZPZGuEfwJuCcNLfGYSakEZjhd(Controller A_1, Type A_2)
			{
				return A_1.ImplementsTemplate(A_2);
			}

			// Token: 0x040002EB RID: 747
			public static readonly Controller.PvbFcvGhKjIftOWUKdvsRDbihcbWA <>9 = new Controller.PvbFcvGhKjIftOWUKdvsRDbihcbWA();

			// Token: 0x040002EC RID: 748
			public static Func<Controller, Guid, bool> <>9__166_0;

			// Token: 0x040002ED RID: 749
			public static Func<Controller, Type, bool> <>9__169_0;
		}
	}
}
