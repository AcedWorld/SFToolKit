using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x0200012E RID: 302
	public abstract class ControllerMap
	{
		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x0000B9C4 File Offset: 0x00009BC4
		private static int CzBlKPwjTjacfzPbGLZXigZpxyci
		{
			get
			{
				int jeEGidqFaFyKKvQCqtvCbsZjHJlR = ControllerMap.JeEGidqFaFyKKvQCqtvCbsZjHJlR;
				if (ControllerMap.JeEGidqFaFyKKvQCqtvCbsZjHJlR == 2147483647)
				{
					ControllerMap.JeEGidqFaFyKKvQCqtvCbsZjHJlR = 0;
					return jeEGidqFaFyKKvQCqtvCbsZjHJlR;
				}
				ControllerMap.JeEGidqFaFyKKvQCqtvCbsZjHJlR++;
				return jeEGidqFaFyKKvQCqtvCbsZjHJlR;
			}
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0004AB38 File Offset: 0x00048D38
		public ControllerMap()
		{
			this._id = ControllerMap.CzBlKPwjTjacfzPbGLZXigZpxyci;
			this._sourceMapId = -1;
			this.HWFUNrjTriGKOavtQjbQUrqBHdpB = new AList<ActionElementMap>();
			this.IGoTvMfKlgBPEYhmpbxjOdJhiwXFA = new ReadOnlyCollection<ActionElementMap>(this.HWFUNrjTriGKOavtQjbQUrqBHdpB);
			this.aqaMsJJzfjLlEzvSMKrKSCDkUROh = new AList<ActionElementMap>();
			this.laOEXpGjgemrdAiJhPMPmzQbNvnj = new ReadOnlyCollection<ActionElementMap>(this.aqaMsJJzfjLlEzvSMKrKSCDkUROh);
			this.hWiFVpwQcCdSNWFNLIobQhYAgMvr = ReInput.id;
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0004ABBC File Offset: 0x00048DBC
		public ControllerMap(ControllerMap A_1) : this()
		{
			this._id = ControllerMap.CzBlKPwjTjacfzPbGLZXigZpxyci;
			this._sourceMapId = A_1._sourceMapId;
			this._categoryId = A_1._categoryId;
			this._layoutId = A_1._layoutId;
			this._name = A_1._name;
			this._hardwareGuid = A_1._hardwareGuid;
			this._enabled = A_1._enabled;
			this._playerId = A_1._playerId;
			this._controllerId = A_1._controllerId;
			this._controllerType = A_1._controllerType;
			if (A_1.HWFUNrjTriGKOavtQjbQUrqBHdpB != null)
			{
				int count = A_1.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count;
				for (int i = 0; i < count; i++)
				{
					this.PZZKBEdnqhkcDJTYjgMtpiUZYMfS(new ActionElementMap(A_1.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]));
				}
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x0000B9EA File Offset: 0x00009BEA
		public int id
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return -1;
				}
				return this._id;
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x0000BA0D File Offset: 0x00009C0D
		// (set) Token: 0x06000BC7 RID: 3015 RVA: 0x0000BA30 File Offset: 0x00009C30
		public int sourceMapId
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return -1;
				}
				return this._sourceMapId;
			}
			internal set
			{
				this._sourceMapId = value;
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0000BA39 File Offset: 0x00009C39
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x0000BA5C File Offset: 0x00009C5C
		public int categoryId
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return -1;
				}
				return this._categoryId;
			}
			internal set
			{
				this._categoryId = value;
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x0000BA65 File Offset: 0x00009C65
		// (set) Token: 0x06000BCB RID: 3019 RVA: 0x0000BA88 File Offset: 0x00009C88
		public int layoutId
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return -1;
				}
				return this._layoutId;
			}
			internal set
			{
				this._layoutId = value;
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x0000BA91 File Offset: 0x00009C91
		// (set) Token: 0x06000BCD RID: 3021 RVA: 0x0000BAB8 File Offset: 0x00009CB8
		public string name
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return string.Empty;
				}
				return this._name;
			}
			internal set
			{
				this._name = value;
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x0000BAC1 File Offset: 0x00009CC1
		// (set) Token: 0x06000BCF RID: 3023 RVA: 0x0000BAE8 File Offset: 0x00009CE8
		public Guid hardwareGuid
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return Guid.Empty;
				}
				return this._hardwareGuid;
			}
			internal set
			{
				this._hardwareGuid = value;
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0000BAF1 File Offset: 0x00009CF1
		// (set) Token: 0x06000BD1 RID: 3025 RVA: 0x0000BB14 File Offset: 0x00009D14
		public bool enabled
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return false;
				}
				return this._enabled;
			}
			set
			{
				this._enabled = value;
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x0000BB1D File Offset: 0x00009D1D
		// (set) Token: 0x06000BD3 RID: 3027 RVA: 0x0000BB40 File Offset: 0x00009D40
		public int playerId
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return -1;
				}
				return this._playerId;
			}
			internal set
			{
				this._playerId = value;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x0000BB49 File Offset: 0x00009D49
		// (set) Token: 0x06000BD5 RID: 3029 RVA: 0x0000BB6C File Offset: 0x00009D6C
		public int controllerId
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return -1;
				}
				return this._controllerId;
			}
			internal set
			{
				this._controllerId = value;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x0000BB75 File Offset: 0x00009D75
		public Controller controller
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return null;
				}
				return ReInput.controllers.GetController(this._controllerType, this._controllerId);
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x0000BBA8 File Offset: 0x00009DA8
		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return ControllerType.Keyboard;
				}
				return this._controllerType;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0000BBCB File Offset: 0x00009DCB
		public Player player
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return null;
				}
				return ReInput.players.GetPlayer(this._playerId);
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x0000BBF8 File Offset: 0x00009DF8
		public int elementMapCount
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return 0;
				}
				return this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Count;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0000BC20 File Offset: 0x00009E20
		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return 0;
				}
				return this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x0000BC48 File Offset: 0x00009E48
		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return this.laOEXpGjgemrdAiJhPMPmzQbNvnj;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x0000BC48 File Offset: 0x00009E48
		public IList<ActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return this.laOEXpGjgemrdAiJhPMPmzQbNvnj;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x0000BC6F File Offset: 0x00009E6F
		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
				{
					ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return this.IGoTvMfKlgBPEYhmpbxjOdJhiwXFA;
			}
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x0004AC80 File Offset: 0x00048E80
		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			return inputAction != null && this.ContainsAction(inputAction.id);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0004ACC8 File Offset: 0x00048EC8
		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0004AD20 File Offset: 0x00048F20
		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			AList<ActionElementMap> alist = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh;
			for (int i = 0; i < alist.Count; i++)
			{
				if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x0004AD78 File Offset: 0x00048F78
		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			AList<ActionElementMap> alist = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh;
			for (int i = 0; i < alist.Count; i++)
			{
				if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i].keyCode == keyCode && this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0004ADE4 File Offset: 0x00048FE4
		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> alist = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh;
			for (int i = 0; i < alist.Count; i++)
			{
				if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i].pGMbotKVdjNowDvSSfgThIWDmLSHB == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0004AE48 File Offset: 0x00049048
		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			AList<ActionElementMap> alist = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh;
			for (int i = 0; i < alist.Count; i++)
			{
				if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i].pGMbotKVdjNowDvSSfgThIWDmLSHB == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x0004AEA0 File Offset: 0x000490A0
		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			ActionElementMap actionElementMap;
			return this.ReplaceOrCreateElementMap(elementAssignment, out actionElementMap);
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x0000BC96 File Offset: 0x00009E96
		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			if (this.GetElementMap(elementAssignment.elementMapId) == null)
			{
				return this.CreateElementMap(elementAssignment, out result);
			}
			return this.ReplaceElementMap(elementAssignment, out result);
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x0004AED4 File Offset: 0x000490D4
		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			ActionElementMap actionElementMap;
			return this.CreateElementMap(elementAssignment, out actionElementMap);
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x0004AF08 File Offset: 0x00049108
		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			if (this._controllerType == ControllerType.Keyboard)
			{
				return this.CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (this._controllerType == ControllerType.Joystick || this._controllerType == ControllerType.Mouse || this._controllerType == ControllerType.Custom)
			{
				return this.CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, gRvITEHjKMrWaeGYEmAHofbpCtEU.oMwnKYUpvUGVFiEwmcEFRbkThNxp(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x0004AFB0 File Offset: 0x000491B0
		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap actionElementMap;
			return this.CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out actionElementMap);
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x0004AFD0 File Offset: 0x000491D0
		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.ZIaqgsDccGvTITgnjUFeFXRKbtuj(this, actionElementMap);
			this.PZZKBEdnqhkcDJTYjgMtpiUZYMfS(actionElementMap);
			result = actionElementMap;
			return true;
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x0004B02C File Offset: 0x0004922C
		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap actionElementMap;
			return this.CreateElementMap(actionId, axisContribution, keyCode, modifierKeyFlags, out actionElementMap);
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x0004B048 File Offset: 0x00049248
		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			QOVTkDoOITfuZwGCeDGoFmWBlokg qovtkDoOITfuZwGCeDGoFmWBlokg = QOVTkDoOITfuZwGCeDGoFmWBlokg.VyOkQKoXtMkwBhKlyQuVnnWLDOFU(modifierKeyFlags);
			return this.CreateElementMap(actionId, axisContribution, keyCode, qovtkDoOITfuZwGCeDGoFmWBlokg.VnWsvhRFHEHSdIxIrWgIdjRFuIrM, qovtkDoOITfuZwGCeDGoFmWBlokg.kstazWnyJWSGCyysBrbkrVnXOThf, qovtkDoOITfuZwGCeDGoFmWBlokg.VNapKiuXDsKIQHBroBAQraNbUEMC, out result);
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0004B09C File Offset: 0x0004929C
		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap actionElementMap;
			return this.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out actionElementMap);
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x0004B0BC File Offset: 0x000492BC
		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			this.BakeElementMap(actionElementMap);
			this.PZZKBEdnqhkcDJTYjgMtpiUZYMfS(actionElementMap);
			result = actionElementMap;
			return true;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x0004B118 File Offset: 0x00049318
		public bool ReplaceElementMap(ElementAssignment elementAssignment)
		{
			ActionElementMap actionElementMap;
			return this.ReplaceElementMap(elementAssignment, out actionElementMap);
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0004B130 File Offset: 0x00049330
		public bool ReplaceElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			if (this._controllerType == ControllerType.Keyboard)
			{
				return this.ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (this._controllerType == ControllerType.Joystick || this._controllerType == ControllerType.Mouse || this._controllerType == ControllerType.Custom)
			{
				return this.ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, gRvITEHjKMrWaeGYEmAHofbpCtEU.oMwnKYUpvUGVFiEwmcEFRbkThNxp(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0004B1E4 File Offset: 0x000493E4
		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap actionElementMap;
			return this.ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out actionElementMap);
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0004B204 File Offset: 0x00049404
		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			ActionElementMap elementMap = this.GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (this.GSzbMwbxRiSsXbmiELWPpDeNfAig(elementMapId) < 0)
			{
				this.DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				this.PZZKBEdnqhkcDJTYjgMtpiUZYMfS(elementMap);
			}
			if (this.GSzbMwbxRiSsXbmiELWPpDeNfAig(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.rErenmVlDpOKWgehhlDnVYBzQEz();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.ZIaqgsDccGvTITgnjUFeFXRKbtuj(this, elementMap);
			result = elementMap;
			return true;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0004B2C4 File Offset: 0x000494C4
		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap actionElementMap;
			return this.ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out actionElementMap);
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0004B2E0 File Offset: 0x000494E0
		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			QOVTkDoOITfuZwGCeDGoFmWBlokg qovtkDoOITfuZwGCeDGoFmWBlokg = QOVTkDoOITfuZwGCeDGoFmWBlokg.VyOkQKoXtMkwBhKlyQuVnnWLDOFU(modifierKeyFlags);
			return this.ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, qovtkDoOITfuZwGCeDGoFmWBlokg.VnWsvhRFHEHSdIxIrWgIdjRFuIrM, qovtkDoOITfuZwGCeDGoFmWBlokg.kstazWnyJWSGCyysBrbkrVnXOThf, qovtkDoOITfuZwGCeDGoFmWBlokg.VNapKiuXDsKIQHBroBAQraNbUEMC, out result);
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x0004B314 File Offset: 0x00049514
		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap actionElementMap;
			return this.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out actionElementMap);
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x0004B334 File Offset: 0x00049534
		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				result = null;
				return false;
			}
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap elementMap = this.GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(elementMap._elementType))
			{
				this.DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				this.PZZKBEdnqhkcDJTYjgMtpiUZYMfS(elementMap);
			}
			if (this.GSzbMwbxRiSsXbmiELWPpDeNfAig(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			ControllerMap.LEAbhiCauElIrGssAmMeAWNDgZgEd(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			this.BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0004B3D4 File Offset: 0x000495D4
		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			int num = this.GSzbMwbxRiSsXbmiELWPpDeNfAig(elementMapId);
			if (num < 0)
			{
				return false;
			}
			this.LFtMKQNqDGdYgNZELuTLQVMcGsht(elementMapId, num);
			return true;
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0000BCD5 File Offset: 0x00009ED5
		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return this.DeleteElementMapsWithAction(ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false));
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0000BCE9 File Offset: 0x00009EE9
		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return this.DeleteButtonMapsWithAction(actionId);
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x0004B414 File Offset: 0x00049614
		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].pGMbotKVdjNowDvSSfgThIWDmLSHB == elementMapId)
				{
					return this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				}
			}
			return null;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0000BCF2 File Offset: 0x00009EF2
		public ActionElementMap[] GetElementMaps()
		{
			return this.GetElementMaps(false);
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0004B478 File Offset: 0x00049678
		public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			int elementMapCount = this.elementMapCount;
			if (elementMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			List<ActionElementMap> list = new List<ActionElementMap>(elementMapCount);
			foreach (ActionElementMap actionElementMap in this.AllMaps)
			{
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0000BCFB File Offset: 0x00009EFB
		public int GetElementMaps(List<ActionElementMap> results)
		{
			return this.GetElementMaps(false, results);
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0000BD05 File Offset: 0x00009F05
		public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return this.ajdiJhXMqrwIHOHDQzktaWNSJglO(results, skipDisabledMaps);
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x0004B50C File Offset: 0x0004970C
		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetElementMapsWithAction(actionId);
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x0000BD3E File Offset: 0x00009F3E
		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return this.GetElementMapsWithAction(actionId, false);
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0004B54C File Offset: 0x0004974C
		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x0004B590 File Offset: 0x00049790
		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			if (this.elementMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			foreach (ActionElementMap actionElementMap in this.AllMaps)
			{
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					num++;
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num2 = 0;
			foreach (ActionElementMap actionElementMap2 in this.AllMaps)
			{
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					array[num2] = actionElementMap2;
					num2++;
				}
			}
			return array;
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x0004B694 File Offset: 0x00049894
		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetElementMapsWithAction(actionId, results);
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x0000BD48 File Offset: 0x00009F48
		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return this.GetElementMapsWithAction(actionId, false, results);
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0004B6D4 File Offset: 0x000498D4
		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x0000BD53 File Offset: 0x00009F53
		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return this.SKUXJwoIaunBEdjJKstnsFfqeDRj(actionId, skipDisabledMaps, results, false);
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x0004B714 File Offset: 0x00049914
		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.ElementMapsWithAction(actionId);
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0000BD5F File Offset: 0x00009F5F
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return this.ElementMapsWithAction(actionId, false);
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x0004B754 File Offset: 0x00049954
		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x0000BD69 File Offset: 0x00009F69
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			foreach (ActionElementMap actionElementMap in this.AllMaps)
			{
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					yield return actionElementMap;
				}
			}
			IEnumerator<ActionElementMap> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x0000BD87 File Offset: 0x00009F87
		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return this.GetFirstElementMapWithAction(actionId, false);
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0004B798 File Offset: 0x00049998
		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetFirstElementMapWithAction(actionId);
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x0004B7D4 File Offset: 0x000499D4
		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._actionId == actionId && (!skipDisabledMaps || this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					return this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				}
			}
			return null;
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x0004B850 File Offset: 0x00049A50
		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x0004B890 File Offset: 0x00049A90
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
			IEnumerable<ActionElementMap> result = this.ElementMapsWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, skipDisabledMaps);
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
			return result;
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x0000BD91 File Offset: 0x00009F91
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			using (TempListPool.TList<ActionElementMap> tlist = TempListPool.GetTList<ActionElementMap>())
			{
				List<ActionElementMap> list = tlist.list;
				bool flag;
				this.qZOynvlardfOgSmhUcYADceZXgiK(elementTarget, false, -1, skipDisabledMaps, list, false, out flag);
				foreach (ActionElementMap actionElementMap in list)
				{
					yield return actionElementMap;
				}
				List<ActionElementMap>.Enumerator enumerator = default(List<ActionElementMap>.Enumerator);
			}
			TempListPool.TList<ActionElementMap> tlist = null;
			yield break;
			yield break;
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x0004B8D4 File Offset: 0x00049AD4
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
			IEnumerable<ActionElementMap> result = this.ElementMapsWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, actionId, skipDisabledMaps);
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
			return result;
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x0004B918 File Offset: 0x00049B18
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x0000BDAF File Offset: 0x00009FAF
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			using (TempListPool.TList<ActionElementMap> tlist = TempListPool.GetTList<ActionElementMap>())
			{
				List<ActionElementMap> list = tlist.list;
				bool flag;
				this.qZOynvlardfOgSmhUcYADceZXgiK(elementTarget, true, actionId, skipDisabledMaps, list, false, out flag);
				foreach (ActionElementMap actionElementMap in list)
				{
					yield return actionElementMap;
				}
				List<ActionElementMap>.Enumerator enumerator = default(List<ActionElementMap>.Enumerator);
			}
			TempListPool.TList<ActionElementMap> tlist = null;
			yield break;
			yield break;
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x0004B95C File Offset: 0x00049B5C
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x0004B9A0 File Offset: 0x00049BA0
		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = this.GetFirstElementMapWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, skipDisabledMaps);
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
			return firstElementMapWithElementTarget;
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x0004B9E0 File Offset: 0x00049BE0
		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			bool flag;
			return this.VWwHPcWBNEZnnVHhltRXgvEuUTBR(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x0004BA14 File Offset: 0x00049C14
		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = this.GetFirstElementMapWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, actionId, skipDisabledMaps);
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
			return firstElementMapWithElementTarget;
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x0004BA54 File Offset: 0x00049C54
		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x0004BA94 File Offset: 0x00049C94
		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			bool flag;
			return this.VWwHPcWBNEZnnVHhltRXgvEuUTBR(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x0004BAC8 File Offset: 0x00049CC8
		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x0004BB08 File Offset: 0x00049D08
		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
			int elementMapsWithElementTarget = this.GetElementMapsWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, skipDisabledMaps, results);
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
			return elementMapsWithElementTarget;
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x0004BB48 File Offset: 0x00049D48
		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			bool flag;
			return this.qZOynvlardfOgSmhUcYADceZXgiK(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0004BB80 File Offset: 0x00049D80
		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.awUDFAvrkgZegheEODIWTzvDUnFG(elementTarget);
			int elementMapsWithElementTarget = this.GetElementMapsWithElementTarget(cqmiAtCKCBeBxcvQtMWaEstcdgFPA, actionId, skipDisabledMaps, results);
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA.nCRlKMWMlcpJInXrvtLslXZSGRhP(cqmiAtCKCBeBxcvQtMWaEstcdgFPA);
			return elementMapsWithElementTarget;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0004BBC0 File Offset: 0x00049DC0
		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x0004BC00 File Offset: 0x00049E00
		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			bool flag;
			return this.qZOynvlardfOgSmhUcYADceZXgiK(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x0004BC38 File Offset: 0x00049E38
		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x0000BDD4 File Offset: 0x00009FD4
		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			return this.rDLgZuiPnayTmkrLkGvuWxrcXFAo(predicate, false);
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0000BDF9 File Offset: 0x00009FF9
		internal virtual ActionElementMap rDLgZuiPnayTmkrLkGvuWxrcXFAo(Predicate<ActionElementMap> A_1, bool A_2)
		{
			return this.RixofOlJotgzBiDhFWLJbTRGUAwb(A_1, A_2);
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x0000BE03 File Offset: 0x0000A003
		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.rxumvJUWAAwEeLGFVYlnIfIHxfPS(predicate, false, results, false);
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x0000BE2A File Offset: 0x0000A02A
		internal virtual int rxumvJUWAAwEeLGFVYlnIfIHxfPS(Predicate<ActionElementMap> A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			return this.OVwHeyoENwMCFRQpWcTteYPgupsrA(A_1, A_2, A_3, A_4);
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x0004BC78 File Offset: 0x00049E78
		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return;
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			int count = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachElementMapMatch", exception);
			}
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x0000BE37 File Offset: 0x0000A037
		public virtual void ClearElementMaps()
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return;
			}
			this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Clear();
			this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Clear();
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x0004BD10 File Offset: 0x00049F10
		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			int num = 0;
			int count = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA != state)
				{
					actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = state;
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x0004BD74 File Offset: 0x00049F74
		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null || index < 0 || index >= this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count)
			{
				return null;
			}
			return this.HWFUNrjTriGKOavtQjbQUrqBHdpB[index];
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x0000BE69 File Offset: 0x0000A069
		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray<ActionElementMap>(this.HWFUNrjTriGKOavtQjbQUrqBHdpB);
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0004BDC4 File Offset: 0x00049FC4
		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x0000BE95 File Offset: 0x0000A095
		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.ceUEgirYHmAmkqCBGuLpHWgKorfR(skipDisabledMaps, results, false);
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0004BE34 File Offset: 0x0004A034
		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return this.GetButtonMapsWithAction(inputAction.id);
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0000BEBB File Offset: 0x0000A0BB
		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return this.GetButtonMapsWithAction(actionId, false);
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x0004BE84 File Offset: 0x0004A084
		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return this.GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x0004BED4 File Offset: 0x0004A0D4
		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.array;
			}
			int buttonMapCount = this.buttonMapCount;
			if (buttonMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					num++;
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num2 = 0;
			for (int j = 0; j < buttonMapCount; j++)
			{
				ActionElementMap actionElementMap2 = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					array[num2] = actionElementMap2;
					num2++;
				}
			}
			return array;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0004BF9C File Offset: 0x0004A19C
		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear<ActionElementMap>(results);
				return 0;
			}
			return this.GetButtonMapsWithAction(inputAction.id, results);
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0000BEC5 File Offset: 0x0000A0C5
		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return this.GetButtonMapsWithAction(actionId, false, results);
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x0004BFEC File Offset: 0x0004A1EC
		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			InputAction inputAction = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.JXGGKcxGWRrQIExMBPoPspsDbQUdA(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear<ActionElementMap>(results);
				return 0;
			}
			return this.GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x0000BED0 File Offset: 0x0000A0D0
		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.mlEHJfCzMGYloowqdGhIZFCxCoCi(actionId, skipDisabledMaps, results, false);
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x0000BEF7 File Offset: 0x0000A0F7
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return this.ButtonMapsWithAction(actionId, false);
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x0004C03C File Offset: 0x0004A23C
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.ButtonMapsWithAction(actionId);
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x0000BF01 File Offset: 0x0000A101
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			if (actionId < 0)
			{
				yield break;
			}
			IList<ActionElementMap> buttonMaps = this.ButtonMaps;
			int buttonMapCount = this.buttonMapCount;
			int num;
			for (int i = 0; i < buttonMapCount; i = num + 1)
			{
				ActionElementMap actionElementMap = buttonMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					yield return actionElementMap;
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x0004C07C File Offset: 0x0004A27C
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x0000BF1F File Offset: 0x0000A11F
		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return this.GetFirstButtonMapWithAction(actionId, false);
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x0004C0C0 File Offset: 0x0004A2C0
		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetFirstButtonMapWithAction(actionId);
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x0004C0FC File Offset: 0x0004A2FC
		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> buttonMaps = this.ButtonMaps;
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = buttonMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.enabled))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0004C164 File Offset: 0x0004A364
		public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			int actionId = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false);
			return this.GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x0000BF29 File Offset: 0x0000A129
		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			return this.RixofOlJotgzBiDhFWLJbTRGUAwb(predicate, false);
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x0004C1A4 File Offset: 0x0004A3A4
		internal ActionElementMap RixofOlJotgzBiDhFWLJbTRGUAwb(Predicate<ActionElementMap> A_1, bool A_2)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (A_1 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> buttonMaps = this.ButtonMaps;
			int buttonMapCount = this.buttonMapCount;
			try
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!A_2 || actionElementMap.enabled) && A_1(actionElementMap))
					{
						return actionElementMap;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetFirstButtonMapMatch", exception);
			}
			return null;
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x0000BF4E File Offset: 0x0000A14E
		public int GetButtonMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.OVwHeyoENwMCFRQpWcTteYPgupsrA(predicate, false, results, false);
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x0004C23C File Offset: 0x0004A43C
		internal int OVwHeyoENwMCFRQpWcTteYPgupsrA(Predicate<ActionElementMap> A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (A_3 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!A_4)
			{
				A_3.Clear();
			}
			else
			{
				num = A_3.Count;
			}
			IList<ActionElementMap> buttonMaps = this.ButtonMaps;
			int buttonMapCount = this.buttonMapCount;
			try
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!A_2 || actionElementMap.enabled) && A_1(actionElementMap))
					{
						A_3.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
			return A_3.Count - num;
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x0004C2E8 File Offset: 0x0004A4E8
		public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return;
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			int count = this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x0000BF75 File Offset: 0x0000A175
		public bool DeleteButtonMapsWithAction(string actionName)
		{
			return this.DeleteButtonMapsWithAction(ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(actionName, false));
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x0004C380 File Offset: 0x0004A580
		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int buttonMapCount = this.buttonMapCount;
			if (buttonMapCount == 0)
			{
				return false;
			}
			bool result = false;
			for (int i = buttonMapCount - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					this.LFtMKQNqDGdYgNZELuTLQVMcGsht(actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, i);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x0004C3F4 File Offset: 0x0004A5F4
		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			int num = 0;
			int count = this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA != state)
				{
					actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = state;
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x0000BF89 File Offset: 0x0000A189
		public bool DoesElementAssignmentConflict(ControllerMap controllerMap)
		{
			return this.DoesElementAssignmentConflict(controllerMap, false);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x0000BF93 File Offset: 0x0000A193
		public bool DoesElementAssignmentConflict(ActionElementMap actionElementMap)
		{
			return this.DoesElementAssignmentConflict(actionElementMap, false);
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x0000BF9D File Offset: 0x0000A19D
		public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
		{
			return this.DoesElementAssignmentConflict(conflictCheck, false);
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x0004C458 File Offset: 0x0004A658
		public virtual bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (controllerMap == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!this._enabled || !controllerMap._enabled))
			{
				return false;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return false;
			}
			IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				return false;
			}
			int buttonMapCount = this.buttonMapCount;
			int count = buttonMaps.Count;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap2 = buttonMaps[j];
						if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x0004C520 File Offset: 0x0004A720
		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (actionElementMap == null || this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!this._enabled || !actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				return false;
			}
			for (int i = 0; i < this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count; i++)
			{
				ActionElementMap actionElementMap2 = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x0004C5A8 File Offset: 0x0004A7A8
		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return false;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return false;
			}
			if (skipDisabledMaps && !this._enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if ((!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0000BFA7 File Offset: 0x0000A1A7
		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return this.ElementAssignmentConflicts(controllerMap, false);
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x0000BFB1 File Offset: 0x0000A1B1
		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return this.ElementAssignmentConflicts(actionElementMap, false);
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x0000BFBB File Offset: 0x0000A1BB
		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return this.ElementAssignmentConflicts(conflictCheck, false);
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0000BFC5 File Offset: 0x0000A1C5
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			if (controllerMap == null || this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				yield break;
			}
			if (skipDisabledMaps && (!this._enabled || !controllerMap._enabled))
			{
				yield break;
			}
			IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				yield break;
			}
			int count = buttonMaps.Count;
			int num;
			for (int i = 0; i < this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count; i = num + 1)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count; j = num + 1)
					{
						ActionElementMap actionElementMap2 = buttonMaps[j];
						if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							yield return new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(this._categoryId).userAssignable, -1, this._controllerType, this._controllerId, this._id, actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						}
						num = j;
					}
					actionElementMap = null;
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x0000BFE3 File Offset: 0x0000A1E3
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			if (actionElementMap == null || this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				yield break;
			}
			if (skipDisabledMaps && (!this._enabled || !actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				yield break;
			}
			int num;
			for (int i = 0; i < this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count; i = num + 1)
			{
				ActionElementMap actionElementMap2 = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					yield return new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(this._categoryId).userAssignable, -1, this._controllerType, this._controllerId, this._id, actionElementMap2.pGMbotKVdjNowDvSSfgThIWDmLSHB, actionElementMap2._actionId, actionElementMap2._elementType, actionElementMap2._elementIdentifierId, actionElementMap2.keyCode, actionElementMap2.modifierKeyFlags);
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x0000C001 File Offset: 0x0000A201
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				yield break;
			}
			if (skipDisabledMaps && !this._enabled)
			{
				yield break;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				yield break;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num;
			for (int i = 0; i < this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count; i = num + 1)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if ((!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					yield return new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(this._categoryId).userAssignable, -1, this._controllerType, this._controllerId, this._id, actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x0000C01F File Offset: 0x0000A21F
		public int RemoveElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return this.RemoveElementAssignmentConflicts(controllerMap, false);
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x0000C029 File Offset: 0x0000A229
		public int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return this.RemoveElementAssignmentConflicts(actionElementMap, false);
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x0000C033 File Offset: 0x0000A233
		public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return this.RemoveElementAssignmentConflicts(conflictCheck, false);
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0004C650 File Offset: 0x0004A850
		public virtual int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!this._enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return num;
			}
			IList<ActionElementMap> hwfunrjTriGKOavtQjbQUrqBHdpB = controllerMap.HWFUNrjTriGKOavtQjbQUrqBHdpB;
			if (hwfunrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int buttonMapCount = this.buttonMapCount;
			int count = hwfunrjTriGKOavtQjbQUrqBHdpB.Count;
			for (int i = this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count; j++)
					{
						if ((!skipDisabledMaps || hwfunrjTriGKOavtQjbQUrqBHdpB[j].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.CheckForAssignmentConflict(hwfunrjTriGKOavtQjbQUrqBHdpB[j]))
						{
							this.LFtMKQNqDGdYgNZELuTLQVMcGsht(actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, i);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x0004C758 File Offset: 0x0004A958
		public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!this._enabled || !actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				return 0;
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return num;
			}
			for (int i = this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap2 = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					this.LFtMKQNqDGdYgNZELuTLQVMcGsht(actionElementMap2.pGMbotKVdjNowDvSSfgThIWDmLSHB, i);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x0004C814 File Offset: 0x0004AA14
		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (skipDisabledMaps && !this._enabled)
			{
				return 0;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int i = this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if ((!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					this.LFtMKQNqDGdYgNZELuTLQVMcGsht(actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB, i);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0000C03D File Offset: 0x0000A23D
		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.oYfeUUNDbOWfjygZOQmLKPGJhOMf(controllerMap, false, null, false);
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0000C064 File Offset: 0x0000A264
		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.iYObeNDzWBShOCtJrwtrYgvLbQKU(actionElementMap, false, null, false);
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x0000C08B File Offset: 0x0000A28B
		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.CgqGVjNDzTEOuNcIRWhWJMfOvNov(conflictCheck, false, null, false);
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x0000C0B2 File Offset: 0x0000A2B2
		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.oYfeUUNDbOWfjygZOQmLKPGJhOMf(controllerMap, skipDisabledMaps, null, false);
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x0000C0D9 File Offset: 0x0000A2D9
		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.iYObeNDzWBShOCtJrwtrYgvLbQKU(actionElementMap, skipDisabledMaps, null, false);
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x0000C100 File Offset: 0x0000A300
		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			return this.CgqGVjNDzTEOuNcIRWhWJMfOvNov(conflictCheck, skipDisabledMaps, null, false);
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0004C8F4 File Offset: 0x0004AAF4
		internal virtual int oYfeUUNDbOWfjygZOQmLKPGJhOMf(ControllerMap A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			if (A_3 != null && !A_4)
			{
				A_3.Clear();
			}
			if (A_1 == null)
			{
				return 0;
			}
			if (A_2 && (!this._enabled || !A_1._enabled))
			{
				return 0;
			}
			int num = 0;
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return num;
			}
			IList<ActionElementMap> hwfunrjTriGKOavtQjbQUrqBHdpB = A_1.HWFUNrjTriGKOavtQjbQUrqBHdpB;
			if (hwfunrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int buttonMapCount = this.buttonMapCount;
			int count = hwfunrjTriGKOavtQjbQUrqBHdpB.Count;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap2 = hwfunrjTriGKOavtQjbQUrqBHdpB[j];
						if ((!A_2 || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							actionElementMap.enabled = false;
							if (A_3 != null)
							{
								A_3.Add(actionElementMap);
							}
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x0004C9E4 File Offset: 0x0004ABE4
		internal virtual int iYObeNDzWBShOCtJrwtrYgvLbQKU(ActionElementMap A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			if (A_3 != null && !A_4)
			{
				A_3.Clear();
			}
			if (A_1 == null)
			{
				return 0;
			}
			if (A_2 && (!this._enabled || !A_1.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				return 0;
			}
			int num = 0;
			if (A_1.elementIdentifierId < 0)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA && A_1.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					if (A_3 != null)
					{
						A_3.Add(actionElementMap);
					}
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x0004CA94 File Offset: 0x0004AC94
		internal virtual int CgqGVjNDzTEOuNcIRWhWJMfOvNov(ElementAssignmentConflictCheck A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			if (A_3 != null && !A_4)
			{
				A_3.Clear();
			}
			if (A_2 && !this._enabled)
			{
				return 0;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return 0;
			}
			if (A_1.elementAssignmentType != ElementAssignmentType.Button && A_1.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = A_1.ToElementAssignment();
			int num = 0;
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != A_1.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					if (A_3 != null)
					{
						A_3.Add(actionElementMap);
					}
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x0000C127 File Offset: 0x0000A327
		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform)
		{
			return this.ForEachElementAssignmentConflict(controllerMap, actionToPerform, false);
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x0000C132 File Offset: 0x0000A332
		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform)
		{
			return this.ForEachElementAssignmentConflict(actionElementMap, actionToPerform, false);
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x0000C13D File Offset: 0x0000A33D
		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform)
		{
			return this.ForEachElementAssignmentConflict(conflictCheck, actionToPerform, false);
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x0004CB68 File Offset: 0x0004AD68
		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!this._enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.aqaMsJJzfjLlEzvSMKrKSCDkUROh;
			if (list == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = list.Count;
			for (int i = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i];
				if (!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					for (int j = 0; j < count; j++)
					{
						if ((!skipDisabledMaps || list[j].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.CheckForAssignmentConflict(list[j]))
						{
							try
							{
								actionToPerform(actionElementMap);
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
								return num;
							}
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x0004CC98 File Offset: 0x0004AE98
		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!this._enabled || !actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
			{
				return 0;
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh == null)
			{
				return num;
			}
			for (int i = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap2 = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i];
				if ((!skipDisabledMaps || actionElementMap2.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					try
					{
						actionToPerform(actionElementMap2);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x0004CD84 File Offset: 0x0004AF84
		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (skipDisabledMaps && !this._enabled)
			{
				return 0;
			}
			if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int i = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Count - 1; i >= 0; i--)
			{
				ActionElementMap actionElementMap = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i];
				if ((!skipDisabledMaps || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && actionElementMap.pGMbotKVdjNowDvSSfgThIWDmLSHB != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					try
					{
						actionToPerform(actionElementMap);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0004CE94 File Offset: 0x0004B094
		public string[] GetButtonNames()
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return EmptyObjects<string>.array;
			}
			int buttonMapCount = this.buttonMapCount;
			if (buttonMapCount == 0)
			{
				return new string[0];
			}
			string[] array = new string[buttonMapCount];
			for (int i = 0; i < buttonMapCount; i++)
			{
				array[i] = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].elementIdentifierName;
			}
			return array;
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x0004CEFC File Offset: 0x0004B0FC
		public string ToXmlString()
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return string.Empty;
			}
			string result;
			try
			{
				result = this.nWvwnYPfHMsCzjgCGFWtuVndtMuh().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + base.GetType().Name + " to XML. " + ex.Message);
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0004CF78 File Offset: 0x0004B178
		public string ToJsonString()
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return string.Empty;
			}
			string result;
			try
			{
				result = this.nWvwnYPfHMsCzjgCGFWtuVndtMuh().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + base.GetType().Name + " to JSON. " + ex.Message);
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0004CFF4 File Offset: 0x0004B1F4
		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (this.controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
				return null;
			}
			IControllerTemplate controllerTemplate = this.controller.GetTemplate(templateTypeGuid) ?? (this.controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				COootOIiwXGzUSdmLyqHaOKMeIvB coootOIiwXGzUSdmLyqHaOKMeIvB = ReInput.jXQhCsUPqOUhARLDxEqlegquceWi(templateTypeGuid);
				string str = (coootOIiwXGzUSdmLyqHaOKMeIvB != null) ? coootOIiwXGzUSdmLyqHaOKMeIvB.yRRhNuBLHhhkeeyCuaJSeukbXFcTB : templateTypeGuid.ToString();
				Logger.LogError("The Controller does not implement " + str + ".", true);
				return null;
			}
			return ControllerTemplateMap.yOtzURshwPfXiMNWqELktsJsfyEV(controllerTemplate, this);
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x0000C148 File Offset: 0x0000A348
		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return this.ToControllerTemplateMap(typeof(T));
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x0004D098 File Offset: 0x0004B298
		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (templateInterfaceType == null)
			{
				throw new ArgumentNullException("templateInterfaceType");
			}
			if (this.controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
				return null;
			}
			IControllerTemplate controllerTemplate = this.controller.GetTemplate(templateInterfaceType) ?? (this.controller.GetTemplate(templateInterfaceType) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", true);
				return null;
			}
			return ControllerTemplateMap.yOtzURshwPfXiMNWqELktsJsfyEV(controllerTemplate, this);
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x0000C15A File Offset: 0x0000A35A
		private ControllerTemplateMap BvVbvjogYylWNzfzHNMhTiKgtsF(IControllerTemplate A_1)
		{
			if (ReInput._id != this.hWiFVpwQcCdSNWFNLIobQhYAgMvr)
			{
				ReInput.CheckInitialized(this.hWiFVpwQcCdSNWFNLIobQhYAgMvr);
				return null;
			}
			if (A_1 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.yOtzURshwPfXiMNWqELktsJsfyEV(A_1, this);
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000C6B RID: 3179 RVA: 0x0000C18C File Offset: 0x0000A38C
		internal AList<ActionElementMap> DWkEfFJRIhxezCgjNNPhQPxZoAPO
		{
			get
			{
				return this.HWFUNrjTriGKOavtQjbQUrqBHdpB;
			}
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x0000C194 File Offset: 0x0000A394
		internal virtual bool SNSempsrfLhzSBkFeitYdlebhkwZB(ActionElementMap A_1)
		{
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(A_1._elementType))
			{
				return false;
			}
			this.PZZKBEdnqhkcDJTYjgMtpiUZYMfS(A_1);
			return true;
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x0004D134 File Offset: 0x0004B334
		internal virtual int ajdiJhXMqrwIHOHDQzktaWNSJglO(List<ActionElementMap> A_1, bool A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = A_1.Count;
			int count2 = this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!A_2 || this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					A_1.Add(this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]);
				}
			}
			return A_1.Count - count;
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x0004D1A0 File Offset: 0x0004B3A0
		internal virtual ActionElementMap JSNovEDxowSIZyOYTBaVACuKDKGrA(int A_1, int A_2, ControllerElementType A_3)
		{
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(A_3))
			{
				return null;
			}
			int num = this.tXTvBSOLiOuwLtuHfWPMESYdpEre(A_1, A_2, A_3);
			if (num < 0)
			{
				return null;
			}
			return this.HWFUNrjTriGKOavtQjbQUrqBHdpB[num];
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x0004D1D4 File Offset: 0x0004B3D4
		internal virtual int kJgoMsDubnHnkLcahHbmlVFwtyRu(int A_1, List<ActionElementMap> A_2, bool A_3)
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!A_3)
			{
				A_2.Clear();
			}
			else
			{
				num = A_2.Count;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return 0;
			}
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._elementIdentifierId == A_1)
				{
					A_2.Add(this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]);
				}
			}
			return A_2.Count - num;
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x0004D250 File Offset: 0x0004B450
		internal virtual bool fyvAooZAakpcxpgDeAyPkGufyIJ(int A_1, int A_2, ControllerElementType A_3)
		{
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(A_3))
			{
				return false;
			}
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._elementIdentifierId == A_1 && this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._actionId == A_2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x0004D2A8 File Offset: 0x0004B4A8
		internal virtual int tXTvBSOLiOuwLtuHfWPMESYdpEre(int A_1, int A_2, ControllerElementType A_3)
		{
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(A_3))
			{
				return -1;
			}
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return -1;
			}
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._elementIdentifierId == A_1 && this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._actionId == A_2)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x0004D308 File Offset: 0x0004B508
		internal int GSzbMwbxRiSsXbmiELWPpDeNfAig(int A_1)
		{
			if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB == null)
			{
				return -1;
			}
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].pGMbotKVdjNowDvSSfgThIWDmLSHB == A_1)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x0004D34C File Offset: 0x0004B54C
		internal int ceUEgirYHmAmkqCBGuLpHWgKorfR(bool A_1, List<ActionElementMap> A_2, bool A_3)
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!A_3)
			{
				A_2.Clear();
			}
			int buttonMapCount = this.buttonMapCount;
			int num = 0;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (!A_1 || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA)
				{
					A_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x0004D3AC File Offset: 0x0004B5AC
		internal int mlEHJfCzMGYloowqdGhIZFCxCoCi(int A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			if (A_3 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!A_4)
			{
				A_3.Clear();
			}
			int buttonMapCount = this.buttonMapCount;
			if (buttonMapCount == 0)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (actionElementMap._actionId == A_1 && (!A_2 || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					A_3.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x0004D418 File Offset: 0x0004B618
		internal virtual int SKUXJwoIaunBEdjJKstnsFfqeDRj(int A_1, bool A_2, List<ActionElementMap> A_3, bool A_4)
		{
			if (A_3 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!A_4)
			{
				A_3.Clear();
			}
			if (A_1 < 0)
			{
				return 0;
			}
			int num = 0;
			int buttonMapCount = this.buttonMapCount;
			for (int i = 0; i < buttonMapCount; i++)
			{
				ActionElementMap actionElementMap = this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				if (actionElementMap._actionId == A_1 && (!A_2 || actionElementMap.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA))
				{
					A_3.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0004D488 File Offset: 0x0004B688
		internal virtual ActionElementMap VWwHPcWBNEZnnVHhltRXgvEuUTBR(IControllerElementTarget A_1, bool A_2, int A_3, bool A_4, out bool A_5)
		{
			A_5 = false;
			if (A_2 && A_3 < 0)
			{
				A_5 = true;
				return null;
			}
			if (!this.MqggUIFsbPRyjBNOcMXwctRMNIBSA(A_1))
			{
				A_5 = true;
				return null;
			}
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(A_1.elementType))
			{
				return null;
			}
			int buttonMapCount = this.buttonMapCount;
			int elementIdentifierId = A_1.elementIdentifierId;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if ((!A_2 || this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._actionId == A_3) && (!A_4 || this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].IsTarget(A_1))
				{
					return this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i];
				}
			}
			return null;
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x0004D530 File Offset: 0x0004B730
		internal virtual int qZOynvlardfOgSmhUcYADceZXgiK(IControllerElementTarget A_1, bool A_2, int A_3, bool A_4, List<ActionElementMap> A_5, bool A_6, out bool A_7)
		{
			if (A_5 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!A_6)
			{
				A_5.Clear();
			}
			A_7 = false;
			if (A_2 && A_3 < 0)
			{
				A_7 = true;
				return num;
			}
			if (!this.MqggUIFsbPRyjBNOcMXwctRMNIBSA(A_1))
			{
				A_7 = true;
				return num;
			}
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(A_1.elementType))
			{
				return num;
			}
			int buttonMapCount = this.buttonMapCount;
			int elementIdentifierId = A_1.elementIdentifierId;
			for (int i = 0; i < buttonMapCount; i++)
			{
				if ((!A_2 || this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]._actionId == A_3) && (!A_4 || this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA) && this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].IsTarget(A_1))
				{
					A_5.Add(this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i]);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x0004D600 File Offset: 0x0004B800
		internal void BdzPxgmCxwOVqSMBOsyzttVqyIDK(int A_1, ControllerElementType A_2)
		{
			ActionElementMap elementMap = this.GetElementMap(A_1);
			if (elementMap == null)
			{
				return;
			}
			if (elementMap._elementType == A_2)
			{
				return;
			}
			elementMap._elementType = A_2;
			if (A_2 == ControllerElementType.Button)
			{
				elementMap._axisRange = AxisRange.Full;
				elementMap._invert = false;
			}
			this.DeleteElementMap(A_1);
			this.FOkrqztDUJcOGmSIWcjPCVfiSuzt(elementMap);
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x0000C1AE File Offset: 0x0000A3AE
		internal virtual bool FOkrqztDUJcOGmSIWcjPCVfiSuzt(ActionElementMap A_1)
		{
			if (A_1 == null)
			{
				return false;
			}
			if (!this.OafKnqjnHMXhaDCWhUyhsqNWBnFl(A_1._elementType))
			{
				return false;
			}
			this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Add(A_1);
			this.DgHXiydIOzSDUuugcvoLKbGdIIKbA(A_1);
			return true;
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0004D64C File Offset: 0x0004B84C
		internal bool MqggUIFsbPRyjBNOcMXwctRMNIBSA(IControllerElementTarget A_1)
		{
			if (A_1 == null)
			{
				return false;
			}
			Controller controller = A_1.controller;
			return controller != null && controller.type == this._controllerType && controller.id == this._controllerId;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x0004D688 File Offset: 0x0004B888
		internal bool KvtgDkAlAaYjjVPiONOkrojxitzeb(string A_1)
		{
			bool result;
			try
			{
				this.CJWrYTJPVnzPlgWTnRyPLpdTJbjD(SerializedObject.FromXml(base.GetType(), A_1));
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + base.GetType().Name + "  from XML. " + ex.Message);
				result = false;
			}
			return result;
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x0004D6E8 File Offset: 0x0004B8E8
		internal bool jZwEmtegaFvFtfWXuyTJukYNVxec(string A_1)
		{
			bool result;
			try
			{
				this.CJWrYTJPVnzPlgWTnRyPLpdTJbjD(SerializedObject.FromJson(base.GetType(), A_1));
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + base.GetType().Name + "  from JSON. " + ex.Message);
				result = false;
			}
			return result;
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x0000C1DA File Offset: 0x0000A3DA
		internal void DgHXiydIOzSDUuugcvoLKbGdIIKbA(ActionElementMap A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Add(A_1);
			this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Sort(ControllerMap.GMkBCKugJTAOgCjeSpFlckgUygBv.ONTAIGrDCiVSgnRxujpOyfOwyzkK);
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x0004D748 File Offset: 0x0004B948
		internal void LUFETllQnJZuBIzKSzSieYuqsseE(int A_1)
		{
			int num = this.YaQYLbqxGqdpDMlOdHgBeImhMjQIA(A_1);
			if (num < 0)
			{
				return;
			}
			this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.RemoveAt(num);
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0004D770 File Offset: 0x0004B970
		internal void huRetGmoSIwuSDDmterzMcvLecLR(int A_1, ActionElementMap A_2)
		{
			if (A_2 == null)
			{
				return;
			}
			int num = this.YaQYLbqxGqdpDMlOdHgBeImhMjQIA(A_1);
			if (num < 0)
			{
				return;
			}
			this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[num] = A_2;
			this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Sort(ControllerMap.GMkBCKugJTAOgCjeSpFlckgUygBv.ONTAIGrDCiVSgnRxujpOyfOwyzkK);
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x0000C1FD File Offset: 0x0000A3FD
		internal static void LEAbhiCauElIrGssAmMeAWNDgZgEd(ActionElementMap A_0, int A_1, Pole A_2, int A_3, ControllerElementType A_4, AxisRange A_5, bool A_6)
		{
			A_0.rErenmVlDpOKWgehhlDnVYBzQEz();
			A_0._actionId = A_1;
			A_0._elementType = A_4;
			A_0._elementIdentifierId = A_3;
			A_0._axisContribution = A_2;
			A_0._axisRange = A_5;
			if (A_4 == ControllerElementType.Axis)
			{
				A_0._invert = A_6;
			}
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x0004D7AC File Offset: 0x0004B9AC
		protected void BakeElementMap(ActionElementMap map)
		{
			if (map == null)
			{
				return;
			}
			Controller controller = ReInput.controllers.GetController(this._controllerType, this._controllerId);
			if (controller != null)
			{
				controller.ZIaqgsDccGvTITgnjUFeFXRKbtuj(this, map);
			}
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x0004D7E0 File Offset: 0x0004B9E0
		internal virtual bool CJWrYTJPVnzPlgWTnRyPLpdTJbjD(SerializedObject A_1)
		{
			bool flag = false;
			this._sourceMapId = -1;
			this._categoryId = -1;
			this._layoutId = -1;
			this._name = string.Empty;
			this._hardwareGuid = Guid.Empty;
			this._enabled = true;
			A_1.TryGetDeserializedValueByRef<int>("sourceMapId", ref this._sourceMapId);
			A_1.TryGetDeserializedValueByRef<int>("categoryId", ref this._categoryId);
			A_1.TryGetDeserializedValueByRef<int>("layoutId", ref this._layoutId);
			A_1.TryGetDeserializedValueByRef<string>("name", ref this._name);
			A_1.TryGetDeserializedValueByRef<Guid>("hardwareGuid", ref this._hardwareGuid);
			A_1.TryGetDeserializedValueByRef<bool>("enabled", ref this._enabled);
			if (!flag)
			{
				this.ClearElementMaps();
				flag = true;
			}
			SerializedObject serializedObject = null;
			if (A_1.TryGetDeserializedValueByRef<SerializedObject>("buttonMaps", ref serializedObject) && serializedObject != null)
			{
				for (int i = 0; i < serializedObject.count; i++)
				{
					SerializedObject serializedObject2;
					if (serializedObject.TryGetDeserializedValue<SerializedObject>(i, out serializedObject2) || serializedObject2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.jDXBmuWueOfuvhElQmjIrsZoRVLz(serializedObject2);
						if (ActionElementMap.rsKLuCqJSjqWHzNTrOWmcUvmtQFp(actionElementMap))
						{
							this.PZZKBEdnqhkcDJTYjgMtpiUZYMfS(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0004D8EC File Offset: 0x0004BAEC
		internal virtual void daBkbOQuLTcpvLQDGvFyctuSeSjD(SerializedObject A_1)
		{
			if (A_1.xmlInfo == null)
			{
				A_1.xmlInfo = new SerializedObject.XmlInfo();
			}
			A_1.Add<int>("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			A_1.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				icHQGefQbedChDWtubHCUkbucRzbb = "dataVersion",
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = 2.ToString()
			});
			if (base.GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(this._controllerId);
				Guid guid = (joystick != null) ? joystick.hardwareTypeGuid : Guid.Empty;
				string hQsdIPBPqieQLwIOlxlBAUDVYhDFA = (joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown";
				A_1.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
				{
					icHQGefQbedChDWtubHCUkbucRzbb = "hardwareGuid",
					hQsdIPBPqieQLwIOlxlBAUDVYhDFA = guid.ToString()
				});
				A_1.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
				{
					icHQGefQbedChDWtubHCUkbucRzbb = "hardwareName",
					hQsdIPBPqieQLwIOlxlBAUDVYhDFA = hQsdIPBPqieQLwIOlxlBAUDVYhDFA
				});
			}
			A_1.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				RYjXkEgviKdbPKjefiQAbwFNRXTlA = "xmlns",
				icHQGefQbedChDWtubHCUkbucRzbb = "xsi",
				YulEumEWpPNPEIqyPwfvMWtcRrsFA = null,
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			A_1.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				RYjXkEgviKdbPKjefiQAbwFNRXTlA = "xsi",
				icHQGefQbedChDWtubHCUkbucRzbb = "schemaLocation",
				YulEumEWpPNPEIqyPwfvMWtcRrsFA = null,
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = string.Format("{0} {1}{2}{3}{4}{5}", new object[]
				{
					"http://guavaman.com/rewired",
					"http://guavaman.com/schemas/rewired/",
					"1.1",
					"/",
					base.GetType().Name,
					".xsd"
				})
			});
			A_1.Add<int>("sourceMapId", this._sourceMapId, SerializedObject.FieldOptions.None);
			A_1.Add<int>("categoryId", this._categoryId, SerializedObject.FieldOptions.None);
			A_1.Add<int>("layoutId", this._layoutId, SerializedObject.FieldOptions.None);
			A_1.Add<string>("name", this._name, SerializedObject.FieldOptions.None);
			A_1.Add<Guid>("hardwareGuid", this._hardwareGuid, SerializedObject.FieldOptions.None);
			A_1.Add<bool>("enabled", this._enabled, SerializedObject.FieldOptions.None);
			int buttonMapCount = this.buttonMapCount;
			List<object> list = new List<object>();
			A_1.Add<List<object>>("buttonMaps", list, SerializedObject.FieldOptions.None);
			for (int i = 0; i < buttonMapCount; i++)
			{
				if (this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i] != null)
				{
					list.Add(this.HWFUNrjTriGKOavtQjbQUrqBHdpB[i].rsOAdCguLNDFfxcMNarlfYblvkOrA());
				}
			}
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0000C236 File Offset: 0x0000A436
		private bool OafKnqjnHMXhaDCWhUyhsqNWBnFl(ControllerElementType A_1)
		{
			return A_1 == ControllerElementType.Button;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0000C23F File Offset: 0x0000A43F
		private void LFtMKQNqDGdYgNZELuTLQVMcGsht(int A_1, int A_2)
		{
			this.LUFETllQnJZuBIzKSzSieYuqsseE(A_1);
			if (A_2 < 0 || A_2 >= this.buttonMapCount)
			{
				return;
			}
			this.HWFUNrjTriGKOavtQjbQUrqBHdpB.RemoveAt(A_2);
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0000C262 File Offset: 0x0000A462
		private void PZZKBEdnqhkcDJTYjgMtpiUZYMfS(ActionElementMap A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.HWFUNrjTriGKOavtQjbQUrqBHdpB.Add(A_1);
			this.DgHXiydIOzSDUuugcvoLKbGdIIKbA(A_1);
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x0000C27C File Offset: 0x0000A47C
		private void uoPFLSAfclRRDoZDoBItQJWjvHXaA(ActionElementMap A_1, int A_2)
		{
			if (A_1 == null)
			{
				return;
			}
			if (A_2 < 0 || A_2 >= this.buttonMapCount)
			{
				return;
			}
			this.huRetGmoSIwuSDDmterzMcvLecLR(this.HWFUNrjTriGKOavtQjbQUrqBHdpB[A_2].pGMbotKVdjNowDvSSfgThIWDmLSHB, A_1);
			this.HWFUNrjTriGKOavtQjbQUrqBHdpB[A_2] = A_1;
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x0004DB74 File Offset: 0x0004BD74
		private int YaQYLbqxGqdpDMlOdHgBeImhMjQIA(int A_1)
		{
			if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh == null)
			{
				return -1;
			}
			int count = this.aqaMsJJzfjLlEzvSMKrKSCDkUROh.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.aqaMsJJzfjLlEzvSMKrKSCDkUROh[i].pGMbotKVdjNowDvSSfgThIWDmLSHB == A_1)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x0004DBBC File Offset: 0x0004BDBC
		private SerializedObject nWvwnYPfHMsCzjgCGFWtuVndtMuh()
		{
			SerializedObject serializedObject = new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object);
			this.daBkbOQuLTcpvLQDGvFyctuSeSjD(serializedObject);
			return serializedObject;
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x0000C2B5 File Offset: 0x0000A4B5
		internal static ControllerMap nPcWPeGGLvrSGPqQhGYxyqQuLzOb(ControllerType A_0)
		{
			switch (A_0)
			{
			case ControllerType.Keyboard:
				return new KeyboardMap();
			case ControllerType.Mouse:
				return new MouseMap();
			case ControllerType.Joystick:
				return new JoystickMap();
			default:
				if (A_0 != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				return new CustomControllerMap();
			}
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x0004DBE0 File Offset: 0x0004BDE0
		internal static ControllerMap IeRlDehStzAoxGIHlpokBYqZCmNA(Controller A_0, int A_1, int A_2)
		{
			if (A_0 == null)
			{
				return null;
			}
			ControllerType type = A_0.type;
			switch (type)
			{
			case ControllerType.Keyboard:
				return KeyboardMap.JFaSyrHBRaiVbkesrgmCvmgtAwXT(A_0.hardwareTypeGuid, A_1, A_2);
			case ControllerType.Mouse:
				return MouseMap.RNwLiQPNKIHevYltYooFXsuqwmkl(A_0.hardwareTypeGuid, A_1, A_2);
			case ControllerType.Joystick:
				return JoystickMap.HKXFkYgXWGhCJSjCCpslBeOMKWGxA(A_0.hardwareTypeGuid, A_1, A_2);
			default:
				if (type != ControllerType.Custom)
				{
					throw new NotImplementedException();
				}
				return CustomControllerMap.CktVxwkSxOMnGYFuGSaZIHydTBRF(A_0.hardwareTypeGuid, ((CustomController)A_0).sourceControllerId, A_1, A_2);
			}
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x0004DC5C File Offset: 0x0004BE5C
		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = ControllerMap.nPcWPeGGLvrSGPqQhGYxyqQuLzOb(controllerType);
			ControllerMap result;
			try
			{
				controllerMap.KvtgDkAlAaYjjVPiONOkrojxitzeb(xmlString);
				result = controllerMap;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0004DC9C File Offset: 0x0004BE9C
		public static ControllerMap CreateFromJson(ControllerType controllerType, string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return null;
			}
			ControllerMap controllerMap = ControllerMap.nPcWPeGGLvrSGPqQhGYxyqQuLzOb(controllerType);
			ControllerMap result;
			try
			{
				controllerMap.jZwEmtegaFvFtfWXuyTJukYNVxec(jsonString);
				result = controllerMap;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x040007D8 RID: 2008
		protected int _id;

		// Token: 0x040007D9 RID: 2009
		protected int _sourceMapId;

		// Token: 0x040007DA RID: 2010
		protected int _categoryId;

		// Token: 0x040007DB RID: 2011
		protected int _layoutId;

		// Token: 0x040007DC RID: 2012
		protected string _name = string.Empty;

		// Token: 0x040007DD RID: 2013
		protected Guid _hardwareGuid;

		// Token: 0x040007DE RID: 2014
		protected bool _enabled;

		// Token: 0x040007DF RID: 2015
		internal readonly int hWiFVpwQcCdSNWFNLIobQhYAgMvr;

		// Token: 0x040007E0 RID: 2016
		private readonly AList<ActionElementMap> HWFUNrjTriGKOavtQjbQUrqBHdpB;

		// Token: 0x040007E1 RID: 2017
		private readonly ReadOnlyCollection<ActionElementMap> IGoTvMfKlgBPEYhmpbxjOdJhiwXFA;

		// Token: 0x040007E2 RID: 2018
		private readonly AList<ActionElementMap> aqaMsJJzfjLlEzvSMKrKSCDkUROh;

		// Token: 0x040007E3 RID: 2019
		private readonly ReadOnlyCollection<ActionElementMap> laOEXpGjgemrdAiJhPMPmzQbNvnj;

		// Token: 0x040007E4 RID: 2020
		protected int _playerId = -1;

		// Token: 0x040007E5 RID: 2021
		protected int _controllerId = -1;

		// Token: 0x040007E6 RID: 2022
		protected ControllerType _controllerType;

		// Token: 0x040007E7 RID: 2023
		private static int JeEGidqFaFyKKvQCqtvCbsZjHJlR;

		// Token: 0x0200012F RID: 303
		private class GMkBCKugJTAOgCjeSpFlckgUygBv : IComparer<ActionElementMap>
		{
			// Token: 0x170003AD RID: 941
			// (get) Token: 0x06000C8E RID: 3214 RVA: 0x0000C2ED File Offset: 0x0000A4ED
			public static ControllerMap.GMkBCKugJTAOgCjeSpFlckgUygBv ONTAIGrDCiVSgnRxujpOyfOwyzkK
			{
				get
				{
					ControllerMap.GMkBCKugJTAOgCjeSpFlckgUygBv result;
					if ((result = ControllerMap.GMkBCKugJTAOgCjeSpFlckgUygBv.HamBnqmpEWeJLIboMASXbYwCfxOlb) == null)
					{
						result = (ControllerMap.GMkBCKugJTAOgCjeSpFlckgUygBv.HamBnqmpEWeJLIboMASXbYwCfxOlb = new ControllerMap.GMkBCKugJTAOgCjeSpFlckgUygBv());
					}
					return result;
				}
			}

			// Token: 0x06000C8F RID: 3215 RVA: 0x0004DCDC File Offset: 0x0004BEDC
			public int Compare(ActionElementMap x, ActionElementMap y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x._elementType == y._elementType)
					{
						return x.id.CompareTo(y.id);
					}
					ControllerElementType elementType = x._elementType;
					int num;
					if (elementType != ControllerElementType.Axis)
					{
						if (elementType != ControllerElementType.Button)
						{
							if (elementType != ControllerElementType.CompoundElement)
							{
								throw new NotImplementedException();
							}
							num = 2;
						}
						else
						{
							num = 0;
						}
					}
					else
					{
						num = 1;
					}
					elementType = y._elementType;
					int num2;
					if (elementType != ControllerElementType.Axis)
					{
						if (elementType != ControllerElementType.Button)
						{
							if (elementType != ControllerElementType.CompoundElement)
							{
								throw new NotImplementedException();
							}
							num2 = 2;
						}
						else
						{
							num2 = 0;
						}
					}
					else
					{
						num2 = 1;
					}
					if (num <= num2)
					{
						return -1;
					}
					return 1;
				}
			}

			// Token: 0x040007E8 RID: 2024
			public static ControllerMap.GMkBCKugJTAOgCjeSpFlckgUygBv HamBnqmpEWeJLIboMASXbYwCfxOlb;
		}
	}
}
