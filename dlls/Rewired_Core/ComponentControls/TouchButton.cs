using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Rewired.ComponentControls
{
	// Token: 0x020003E5 RID: 997
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Touch Controls/Touch Button")]
	[Serializable]
	public sealed class TouchButton : TouchInteractable
	{
		// Token: 0x1400003D RID: 61
		// (add) Token: 0x060027F4 RID: 10228 RVA: 0x0001DEB2 File Offset: 0x0001C0B2
		// (remove) Token: 0x060027F5 RID: 10229 RVA: 0x0001DEC0 File Offset: 0x0001C0C0
		public event UnityAction<float> AxisValueChangedEvent
		{
			add
			{
				this._onAxisValueChanged.AddListener(value);
			}
			remove
			{
				this._onAxisValueChanged.RemoveListener(value);
			}
		}

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x060027F6 RID: 10230 RVA: 0x0001DECE File Offset: 0x0001C0CE
		// (remove) Token: 0x060027F7 RID: 10231 RVA: 0x0001DEDC File Offset: 0x0001C0DC
		public event UnityAction<bool> ButtonValueChangedEvent
		{
			add
			{
				this._onButtonValueChanged.AddListener(value);
			}
			remove
			{
				this._onButtonValueChanged.RemoveListener(value);
			}
		}

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x060027F8 RID: 10232 RVA: 0x0001DEEA File Offset: 0x0001C0EA
		// (remove) Token: 0x060027F9 RID: 10233 RVA: 0x0001DEF8 File Offset: 0x0001C0F8
		public event UnityAction ButtonDownEvent
		{
			add
			{
				this._onButtonDown.AddListener(value);
			}
			remove
			{
				this._onButtonDown.RemoveListener(value);
			}
		}

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x060027FA RID: 10234 RVA: 0x0001DF06 File Offset: 0x0001C106
		// (remove) Token: 0x060027FB RID: 10235 RVA: 0x0001DF14 File Offset: 0x0001C114
		public event UnityAction ButtonUpEvent
		{
			add
			{
				this._onButtonUp.AddListener(value);
			}
			remove
			{
				this._onButtonUp.RemoveListener(value);
			}
		}

		// Token: 0x17000966 RID: 2406
		// (get) Token: 0x060027FC RID: 10236 RVA: 0x0001DF22 File Offset: 0x0001C122
		public CustomControllerElementTargetSetForFloat targetCustomControllerElement
		{
			get
			{
				return this._targetCustomControllerElement;
			}
		}

		// Token: 0x17000967 RID: 2407
		// (get) Token: 0x060027FD RID: 10237 RVA: 0x0001DF2A File Offset: 0x0001C12A
		// (set) Token: 0x060027FE RID: 10238 RVA: 0x0001DF32 File Offset: 0x0001C132
		public TouchButton.ButtonType buttonType
		{
			get
			{
				return this._buttonType;
			}
			set
			{
				if (this._buttonType == value)
				{
					return;
				}
				this._buttonType = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000968 RID: 2408
		// (get) Token: 0x060027FF RID: 10239 RVA: 0x0001DF4B File Offset: 0x0001C14B
		// (set) Token: 0x06002800 RID: 10240 RVA: 0x0001DF53 File Offset: 0x0001C153
		public bool activateOnSwipeIn
		{
			get
			{
				return this._activateOnSwipeIn;
			}
			set
			{
				if (this._activateOnSwipeIn == value)
				{
					return;
				}
				this._activateOnSwipeIn = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000969 RID: 2409
		// (get) Token: 0x06002801 RID: 10241 RVA: 0x0001DF6C File Offset: 0x0001C16C
		// (set) Token: 0x06002802 RID: 10242 RVA: 0x0001DF7E File Offset: 0x0001C17E
		public bool stayActiveOnSwipeOut
		{
			get
			{
				return this.EeCQaaWHMfTJhKbXSZfIemmUHxyj() || this._stayActiveOnSwipeOut;
			}
			set
			{
				if (this._stayActiveOnSwipeOut == value)
				{
					return;
				}
				this._stayActiveOnSwipeOut = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700096A RID: 2410
		// (get) Token: 0x06002803 RID: 10243 RVA: 0x0001DF97 File Offset: 0x0001C197
		// (set) Token: 0x06002804 RID: 10244 RVA: 0x0001DF9F File Offset: 0x0001C19F
		public bool useDigitalAxisSimulation
		{
			get
			{
				return this._useDigitalAxisSimulation;
			}
			set
			{
				if (this._useDigitalAxisSimulation == value)
				{
					return;
				}
				this._useDigitalAxisSimulation = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700096B RID: 2411
		// (get) Token: 0x06002805 RID: 10245 RVA: 0x0001DFB8 File Offset: 0x0001C1B8
		// (set) Token: 0x06002806 RID: 10246 RVA: 0x0001DFC0 File Offset: 0x0001C1C0
		public float digitalAxisGravity
		{
			get
			{
				return this._digitalAxisGravity;
			}
			set
			{
				if (this._digitalAxisGravity == value)
				{
					return;
				}
				this._digitalAxisGravity = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700096C RID: 2412
		// (get) Token: 0x06002807 RID: 10247 RVA: 0x0001DFD9 File Offset: 0x0001C1D9
		// (set) Token: 0x06002808 RID: 10248 RVA: 0x0001DFE1 File Offset: 0x0001C1E1
		public float digitalAxisSensitivity
		{
			get
			{
				return this._digitalAxisSensitivity;
			}
			set
			{
				if (this._digitalAxisSensitivity == value)
				{
					return;
				}
				this._digitalAxisSensitivity = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700096D RID: 2413
		// (get) Token: 0x06002809 RID: 10249 RVA: 0x0001DFFA File Offset: 0x0001C1FA
		// (set) Token: 0x0600280A RID: 10250 RVA: 0x0001E002 File Offset: 0x0001C202
		public TouchRegion touchRegion
		{
			get
			{
				return this._touchRegion;
			}
			set
			{
				if (this._touchRegion == value)
				{
					return;
				}
				this._touchRegion = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700096E RID: 2414
		// (get) Token: 0x0600280B RID: 10251 RVA: 0x0001E020 File Offset: 0x0001C220
		// (set) Token: 0x0600280C RID: 10252 RVA: 0x0001E028 File Offset: 0x0001C228
		public bool useTouchRegionOnly
		{
			get
			{
				return this._useTouchRegionOnly;
			}
			set
			{
				if (this._useTouchRegionOnly == value)
				{
					return;
				}
				this._useTouchRegionOnly = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x1700096F RID: 2415
		// (get) Token: 0x0600280D RID: 10253 RVA: 0x0001E041 File Offset: 0x0001C241
		// (set) Token: 0x0600280E RID: 10254 RVA: 0x0001E049 File Offset: 0x0001C249
		public bool moveToTouchPosition
		{
			get
			{
				return this._moveToTouchPosition;
			}
			set
			{
				if (this._moveToTouchPosition == value)
				{
					return;
				}
				this._moveToTouchPosition = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000970 RID: 2416
		// (get) Token: 0x0600280F RID: 10255 RVA: 0x0001E062 File Offset: 0x0001C262
		// (set) Token: 0x06002810 RID: 10256 RVA: 0x0001E06A File Offset: 0x0001C26A
		public bool returnOnRelease
		{
			get
			{
				return this._returnOnRelease;
			}
			set
			{
				if (this._returnOnRelease == value)
				{
					return;
				}
				this._returnOnRelease = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000971 RID: 2417
		// (get) Token: 0x06002811 RID: 10257 RVA: 0x0001E083 File Offset: 0x0001C283
		// (set) Token: 0x06002812 RID: 10258 RVA: 0x0001E08B File Offset: 0x0001C28B
		public bool followTouchPosition
		{
			get
			{
				return this._followTouchPosition;
			}
			set
			{
				if (this._followTouchPosition == value)
				{
					return;
				}
				this._followTouchPosition = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000972 RID: 2418
		// (get) Token: 0x06002813 RID: 10259 RVA: 0x0001E0A4 File Offset: 0x0001C2A4
		// (set) Token: 0x06002814 RID: 10260 RVA: 0x0001E0AC File Offset: 0x0001C2AC
		public bool animateOnMoveToTouch
		{
			get
			{
				return this._animateOnMoveToTouch;
			}
			set
			{
				if (this._animateOnMoveToTouch == value)
				{
					return;
				}
				this._animateOnMoveToTouch = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000973 RID: 2419
		// (get) Token: 0x06002815 RID: 10261 RVA: 0x0001E0C5 File Offset: 0x0001C2C5
		// (set) Token: 0x06002816 RID: 10262 RVA: 0x0001E0CD File Offset: 0x0001C2CD
		public float moveToTouchSpeed
		{
			get
			{
				return this._moveToTouchSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 20f);
				if (this._moveToTouchSpeed == value)
				{
					return;
				}
				this._moveToTouchSpeed = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000974 RID: 2420
		// (get) Token: 0x06002817 RID: 10263 RVA: 0x0001E0F8 File Offset: 0x0001C2F8
		// (set) Token: 0x06002818 RID: 10264 RVA: 0x0001E100 File Offset: 0x0001C300
		public bool animateOnReturn
		{
			get
			{
				return this._animateOnReturn;
			}
			set
			{
				if (this._animateOnReturn == value)
				{
					return;
				}
				this._animateOnReturn = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000975 RID: 2421
		// (get) Token: 0x06002819 RID: 10265 RVA: 0x0001E119 File Offset: 0x0001C319
		// (set) Token: 0x0600281A RID: 10266 RVA: 0x0001E121 File Offset: 0x0001C321
		public float returnSpeed
		{
			get
			{
				return this._returnSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 20f);
				if (this._returnSpeed == value)
				{
					return;
				}
				this._returnSpeed = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000976 RID: 2422
		// (get) Token: 0x0600281B RID: 10267 RVA: 0x0001E14C File Offset: 0x0001C34C
		// (set) Token: 0x0600281C RID: 10268 RVA: 0x0001E154 File Offset: 0x0001C354
		public bool manageRaycasting
		{
			get
			{
				return this._manageRaycasting;
			}
			set
			{
				if (this._manageRaycasting == value)
				{
					return;
				}
				this._manageRaycasting = value;
				if (value)
				{
					this.WkjuCNSXaQNmmEmDLoIIpWezmFSE();
				}
				else
				{
					this.cyTformcxtzxQOXALUtsWziQTOSD.GIEiARxYMViVyBKxUpdiLnATYgLQ();
				}
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x17000977 RID: 2423
		// (get) Token: 0x0600281D RID: 10269 RVA: 0x0001E183 File Offset: 0x0001C383
		// (set) Token: 0x0600281E RID: 10270 RVA: 0x0001E18B File Offset: 0x0001C38B
		public int pointerId
		{
			get
			{
				return this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA;
			}
			set
			{
				this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA = value;
			}
		}

		// Token: 0x17000978 RID: 2424
		// (get) Token: 0x0600281F RID: 10271 RVA: 0x0001E194 File Offset: 0x0001C394
		public bool hasPointer
		{
			get
			{
				return this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA != int.MinValue;
			}
		}

		// Token: 0x17000979 RID: 2425
		// (get) Token: 0x06002820 RID: 10272 RVA: 0x0001E1A6 File Offset: 0x0001C3A6
		internal StandaloneAxis axis
		{
			get
			{
				return this._axis;
			}
		}

		// Token: 0x1700097A RID: 2426
		// (get) Token: 0x06002821 RID: 10273 RVA: 0x00096694 File Offset: 0x00094894
		private Action<TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc> moveStartedDelegate
		{
			get
			{
				if (this.XCEbOTXZKWQYZhoxcGAeUlHbVSMT == null)
				{
					return this.XCEbOTXZKWQYZhoxcGAeUlHbVSMT = new Action<TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc>(this.LOfstjqiejcnRjgvwcEYSOXvMbzbA);
				}
				return this.XCEbOTXZKWQYZhoxcGAeUlHbVSMT;
			}
		}

		// Token: 0x1700097B RID: 2427
		// (get) Token: 0x06002822 RID: 10274 RVA: 0x000966C8 File Offset: 0x000948C8
		private Action<TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc> moveEndedDelegate
		{
			get
			{
				if (this.PnlTZBpgdScYhYPGNhiFigZsiLkbA == null)
				{
					return this.PnlTZBpgdScYhYPGNhiFigZsiLkbA = new Action<TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc>(this.FzYehhiiAeBhdTNGmascORIHCONjb);
				}
				return this.PnlTZBpgdScYhYPGNhiFigZsiLkbA;
			}
		}

		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x06002823 RID: 10275 RVA: 0x0001E1AE File Offset: 0x0001C3AE
		private float axisValue
		{
			get
			{
				if (!this._useDigitalAxisSimulation)
				{
					return this._axis.value;
				}
				return this.lnWisbmcPNhKAWLclidLbuQgDRPU;
			}
		}

		// Token: 0x1700097D RID: 2429
		// (get) Token: 0x06002824 RID: 10276 RVA: 0x0001E1CA File Offset: 0x0001C3CA
		private float axisValuePrev
		{
			get
			{
				if (!this._useDigitalAxisSimulation)
				{
					return this._axis.valuePrev;
				}
				return this.yPNDpoKDNYyJzZKgvsstwHlLcbvc;
			}
		}

		// Token: 0x1700097E RID: 2430
		// (get) Token: 0x06002825 RID: 10277 RVA: 0x0001E1E6 File Offset: 0x0001C3E6
		private bool buttonValue
		{
			get
			{
				return this._axis.buttonValue;
			}
		}

		// Token: 0x1700097F RID: 2431
		// (get) Token: 0x06002826 RID: 10278 RVA: 0x0001E1F3 File Offset: 0x0001C3F3
		private bool buttonValuePrev
		{
			get
			{
				return this._axis.buttonValuePrev;
			}
		}

		// Token: 0x17000980 RID: 2432
		// (get) Token: 0x06002827 RID: 10279 RVA: 0x0001E200 File Offset: 0x0001C400
		private int effectivePointerId
		{
			get
			{
				if (this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA == -2147483648)
				{
					return int.MinValue;
				}
				if (this.PnXOUWLZRfcjbBBkcprpraogIZXD != -2147483648)
				{
					return this.PnXOUWLZRfcjbBBkcprpraogIZXD;
				}
				return this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA;
			}
		}

		// Token: 0x06002828 RID: 10280 RVA: 0x000966FC File Offset: 0x000948FC
		[CustomObfuscation(rename = false)]
		private TouchButton()
		{
		}

		// Token: 0x06002829 RID: 10281 RVA: 0x0001E22F File Offset: 0x0001C42F
		public void SetRawValue(float value)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this._axis.SetRawValue(value);
		}

		// Token: 0x0600282A RID: 10282 RVA: 0x0001E246 File Offset: 0x0001C446
		public void SetDefaultPosition()
		{
			this.eMAOwqiESxcXlThqBjQLKTTiowSc(base.ZlJFgENigMndbNzNAXlaJMlysRs.anchoredPosition);
		}

		// Token: 0x0600282B RID: 10283 RVA: 0x0001E259 File Offset: 0x0001C459
		private void eMAOwqiESxcXlThqBjQLKTTiowSc(Vector2 A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.WiZZjedfuoEZcItYfdtMKBLkpWld = A_1;
		}

		// Token: 0x0600282C RID: 10284 RVA: 0x0001E26B File Offset: 0x0001C46B
		public void ReturnToDefaultPosition(bool instant)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.RImNGHSNXYesVuNddHqqFBgJvZIKA(this.WiZZjedfuoEZcItYfdtMKBLkpWld, PositionType.Anchored, !instant && this._animateOnReturn, this._returnSpeed, TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.TowardHome);
		}

		// Token: 0x0600282D RID: 10285 RVA: 0x0001E296 File Offset: 0x0001C496
		public void ReturnToDefaultPosition()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.ReturnToDefaultPosition(false);
		}

		// Token: 0x0600282E RID: 10286 RVA: 0x0001E2A8 File Offset: 0x0001C4A8
		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (!Application.isPlaying)
			{
				return;
			}
			this.WiZZjedfuoEZcItYfdtMKBLkpWld = base.ZlJFgENigMndbNzNAXlaJMlysRs.anchoredPosition;
		}

		// Token: 0x0600282F RID: 10287 RVA: 0x0001E2C9 File Offset: 0x0001C4C9
		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.mRFwFQBBujAVPABNfbmuwrtmmuJFA();
		}

		// Token: 0x06002830 RID: 10288 RVA: 0x0001E2E0 File Offset: 0x0001C4E0
		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.ypZrirDpTPdDSbwgBziSLiFRjrJkA();
		}

		// Token: 0x06002831 RID: 10289 RVA: 0x0001E2F7 File Offset: 0x0001C4F7
		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.mRFwFQBBujAVPABNfbmuwrtmmuJFA();
		}

		// Token: 0x06002832 RID: 10290 RVA: 0x0001E30E File Offset: 0x0001C50E
		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			base.Reset();
			base.transitionType = TouchInteractable.TransitionTypeFlags.ColorTint;
		}

		// Token: 0x06002833 RID: 10291 RVA: 0x0001E31D File Offset: 0x0001C51D
		internal void OnUpdate()
		{
			base.AoHwozRsjiUmhnUZxZinlrstaSL();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.SQxTUyoJtWJMeTQqMXbriaIICULc();
			this.cVWiFgRYfaEInaqvsGQBSayUdmfh();
			this.pLIqejUEhkqzAGfZUWcHejFyDCfA();
			if (this._followTouchPosition)
			{
				this.tvTLSHmRwoKVNHlOLCQPSpOdXOxO(this.effectivePointerId);
			}
		}

		// Token: 0x06002834 RID: 10292 RVA: 0x0001E354 File Offset: 0x0001C554
		internal bool OnInitialize()
		{
			return base.ljoRLbCAHFdMhoOyLpdVnVLwwTMd();
		}

		// Token: 0x06002835 RID: 10293 RVA: 0x0001E361 File Offset: 0x0001C561
		internal void OnCustomControllerUpdate()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			base.WiKtlIjluObCctWuxDsizpItcifHA(this._targetCustomControllerElement, this.axisValue, this._axis.buttonActivationThreshold);
		}

		// Token: 0x06002836 RID: 10294 RVA: 0x000967DC File Offset: 0x000949DC
		internal void OnSubscribeEvents()
		{
			base.SsfxZPZhDDtylHZYnTMQyawFtfbC();
			this._axis.AxisValueChangedEvent += this.sDJgWwHKkPfyJAIGWfJNexgmwgfrA;
			this._axis.ButtonValueChangedEvent += this.qMCmLdlzXTTDukdJCFtZQZupdOoE;
			this._axis.ButtonDownEvent += this.RwTIwBHroVwCtnEOLpmmMJxhWNfQ;
			this._axis.ButtonUpEvent += this.pYUloTECKnLanBANSdkGEakrcgPz;
		}

		// Token: 0x06002837 RID: 10295 RVA: 0x0009684C File Offset: 0x00094A4C
		internal void OnUnsubscribeEvents()
		{
			base.dDJGenyHMNqOIuUSedhLaBWSdtrkA();
			this._axis.AxisValueChangedEvent -= this.sDJgWwHKkPfyJAIGWfJNexgmwgfrA;
			this._axis.ButtonValueChangedEvent -= this.qMCmLdlzXTTDukdJCFtZQZupdOoE;
			this._axis.ButtonDownEvent -= this.RwTIwBHroVwCtnEOLpmmMJxhWNfQ;
			this._axis.ButtonUpEvent -= this.pYUloTECKnLanBANSdkGEakrcgPz;
		}

		// Token: 0x06002838 RID: 10296 RVA: 0x0001E392 File Offset: 0x0001C592
		internal void OnSetProperty()
		{
			base.DIrIjbritRrTvPOfPhRMJhhCMvxGA();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.mRFwFQBBujAVPABNfbmuwrtmmuJFA();
		}

		// Token: 0x06002839 RID: 10297 RVA: 0x000968BC File Offset: 0x00094ABC
		internal void OnClear()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA = int.MinValue;
			this.PnXOUWLZRfcjbBBkcprpraogIZXD = int.MinValue;
			this.BFjnzWzbQOcoGPkkTENnjsLfvvhW = false;
			this.besVMalhWlFgomFdnJSkzUMUdvVS = false;
			if (this._returnOnRelease && this.fsMsSENlcRtHxdORAZQEKCfLIsaN && (this._moveToTouchPosition || this._followTouchPosition))
			{
				this.ReturnToDefaultPosition(true);
			}
			this.fsMsSENlcRtHxdORAZQEKCfLIsaN = false;
			this.BsZgnfbkNwsdWMvaiQUUylsMBExE = false;
			this.rVJlKaHhsfHvbHVffKiygkRddXYJ = TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.None;
			this.dSLUQCKtKnnvCSbXJQgTtIfetDUV();
			this._axis.Clear();
			this.lnWisbmcPNhKAWLclidLbuQgDRPU = 0f;
			this.yPNDpoKDNYyJzZKgvsstwHlLcbvc = 0f;
			this.mRFwFQBBujAVPABNfbmuwrtmmuJFA();
		}

		// Token: 0x0600283A RID: 10298 RVA: 0x0001E3A9 File Offset: 0x0001C5A9
		public override void ClearValue()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this._axis.Clear();
			this.lnWisbmcPNhKAWLclidLbuQgDRPU = 0f;
			if (this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._targetCustomControllerElement);
			}
		}

		// Token: 0x0600283B RID: 10299 RVA: 0x0001E3E3 File Offset: 0x0001C5E3
		internal bool IsPressed()
		{
			return base.veZcaeCyueZWdUyopUIfeodQudJq && base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && (this._axis.buttonValue || this._axis.value != 0f);
		}

		// Token: 0x0600283C RID: 10300 RVA: 0x0001E41D File Offset: 0x0001C61D
		internal bool IsThisOrTouchRegionGameObject(GameObject gameObject)
		{
			return !(gameObject == null) && (base.azuQLFEAbDNvtgPVOdzszMzaxXqC(gameObject) || (this.WQyzNMrPOHNEIvUbddeDKdSTrlTO != null && this.WQyzNMrPOHNEIvUbddeDKdSTrlTO.gameObject == gameObject));
		}

		// Token: 0x0600283D RID: 10301 RVA: 0x0001E456 File Offset: 0x0001C656
		private void pLIqejUEhkqzAGfZUWcHejFyDCfA()
		{
			if (!this._useDigitalAxisSimulation)
			{
				return;
			}
			if (this._axis.buttonValue)
			{
				this.amQoblDkMjcknCspNXnxEspEXtYoA();
				return;
			}
			this.jcZfVlBuIElESvvQahqFxucNDRRjA();
		}

		// Token: 0x0600283E RID: 10302 RVA: 0x00096960 File Offset: 0x00094B60
		private void amQoblDkMjcknCspNXnxEspEXtYoA()
		{
			float num = (this._axis.value >= 0f) ? 1f : -1f;
			float num2 = MathTools.Abs(this._digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += this.lnWisbmcPNhKAWLclidLbuQgDRPU;
			num = MathTools.Clamp(num, -1f, 1f);
			this.KuksGjLoEDRSiXNpKZTzXejPhFzW(num, true);
		}

		// Token: 0x0600283F RID: 10303 RVA: 0x000969C4 File Offset: 0x00094BC4
		private void jcZfVlBuIElESvvQahqFxucNDRRjA()
		{
			float digitalAxisGravity = this._digitalAxisGravity;
			if (digitalAxisGravity == 0f)
			{
				return;
			}
			float num = this.lnWisbmcPNhKAWLclidLbuQgDRPU;
			if (num == 0f)
			{
				return;
			}
			float num2 = digitalAxisGravity * Time.unscaledDeltaTime;
			float num3;
			if (MathTools.Abs(num2) >= MathTools.Abs(num))
			{
				num3 = 0f;
			}
			else
			{
				float num4 = (num > 0f) ? -1f : 1f;
				num3 = num + num4 * num2;
			}
			this.KuksGjLoEDRSiXNpKZTzXejPhFzW(num3, true);
		}

		// Token: 0x06002840 RID: 10304 RVA: 0x0001E47B File Offset: 0x0001C67B
		private void KuksGjLoEDRSiXNpKZTzXejPhFzW(float A_1, bool A_2)
		{
			this.yPNDpoKDNYyJzZKgvsstwHlLcbvc = this.lnWisbmcPNhKAWLclidLbuQgDRPU;
			this.lnWisbmcPNhKAWLclidLbuQgDRPU = A_1;
			if (A_1 != this.yPNDpoKDNYyJzZKgvsstwHlLcbvc)
			{
				base.bQxfVwsHphtKQjTPHonPFeqrEVvE(null);
			}
			if (A_2 && A_1 != this.yPNDpoKDNYyJzZKgvsstwHlLcbvc)
			{
				this._onAxisValueChanged.Invoke(A_1);
			}
		}

		// Token: 0x06002841 RID: 10305 RVA: 0x00096A34 File Offset: 0x00094C34
		private void wKRrQWiKxTFyVrqOpebiXAmIDnzdA()
		{
			if (this._buttonType != TouchButton.ButtonType.ToggleSwitch)
			{
				if (this._buttonType == TouchButton.ButtonType.Standard)
				{
					this._axis.SetRawValue(this._axis.rawMax);
				}
				return;
			}
			if (this.buttonValue)
			{
				this._axis.SetRawValue(this._axis.rawZero);
				return;
			}
			this._axis.SetRawValue(this._axis.rawMax);
		}

		// Token: 0x06002842 RID: 10306 RVA: 0x0001E4B8 File Offset: 0x0001C6B8
		private void CfDlhsLiXJlhDxNRkbWJkUmSlOPl()
		{
			if (this._buttonType == TouchButton.ButtonType.Standard)
			{
				this._axis.SetRawValue(this._axis.rawZero);
			}
		}

		// Token: 0x06002843 RID: 10307 RVA: 0x0001E4D8 File Offset: 0x0001C6D8
		private void mRFwFQBBujAVPABNfbmuwrtmmuJFA()
		{
			this._targetCustomControllerElement.ClearElementCaches();
			this.cVWiFgRYfaEInaqvsGQBSayUdmfh();
			this.WkjuCNSXaQNmmEmDLoIIpWezmFSE();
		}

		// Token: 0x06002844 RID: 10308 RVA: 0x0001E4F1 File Offset: 0x0001C6F1
		private void WkjuCNSXaQNmmEmDLoIIpWezmFSE()
		{
			if (!this._manageRaycasting)
			{
				return;
			}
			this.cyTformcxtzxQOXALUtsWziQTOSD.dHSqDioPfpgmHAtOhAxOuRATBgLSA(base.transform, this.IJYovnoVSVUzohIibeybjRhbpiTB());
		}

		// Token: 0x06002845 RID: 10309 RVA: 0x0001E513 File Offset: 0x0001C713
		private bool IJYovnoVSVUzohIibeybjRhbpiTB()
		{
			return !(this.WQyzNMrPOHNEIvUbddeDKdSTrlTO != null) || !this._useTouchRegionOnly;
		}

		// Token: 0x06002846 RID: 10310 RVA: 0x00096AA0 File Offset: 0x00094CA0
		private void bVZVwoKVpCTLgobIFZYXZOpDlAES(TouchRegion A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.ysqLtvSobaIKxoQnVgNJdxQOaqVQ(A_1);
			A_1.PointerDownEvent += this.IMdQBHurTUggMCngIbMFdDAdejxEb;
			A_1.PointerUpEvent += this.mUCirufydpwCTqJXtnOgsvsqzIcg;
			A_1.PointerEnterEvent += this.DNKWrquuUNECGcCpXvpCmCBZekQg;
			A_1.PointerExitEvent += this.tlIhQmXkGixkigitYVPjttbyOQPw;
		}

		// Token: 0x06002847 RID: 10311 RVA: 0x00096B08 File Offset: 0x00094D08
		private void ysqLtvSobaIKxoQnVgNJdxQOaqVQ(TouchRegion A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			A_1.PointerDownEvent -= this.IMdQBHurTUggMCngIbMFdDAdejxEb;
			A_1.PointerUpEvent -= this.mUCirufydpwCTqJXtnOgsvsqzIcg;
			A_1.PointerEnterEvent -= this.DNKWrquuUNECGcCpXvpCmCBZekQg;
			A_1.PointerExitEvent -= this.tlIhQmXkGixkigitYVPjttbyOQPw;
		}

		// Token: 0x06002848 RID: 10312 RVA: 0x0001E52E File Offset: 0x0001C72E
		private void cVWiFgRYfaEInaqvsGQBSayUdmfh()
		{
			if (this.WQyzNMrPOHNEIvUbddeDKdSTrlTO == this._touchRegion)
			{
				return;
			}
			this.ysqLtvSobaIKxoQnVgNJdxQOaqVQ(this.WQyzNMrPOHNEIvUbddeDKdSTrlTO);
			this.WQyzNMrPOHNEIvUbddeDKdSTrlTO = this._touchRegion;
			this.bVZVwoKVpCTLgobIFZYXZOpDlAES(this.WQyzNMrPOHNEIvUbddeDKdSTrlTO);
		}

		// Token: 0x06002849 RID: 10313 RVA: 0x00096B68 File Offset: 0x00094D68
		private void uQrYpghGUTXfeuTPuCKNtHFcAzqo(Vector2 A_1, bool A_2, float A_3, TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc A_4)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = YPidKbradifyUUSIIphXNVhWkELO.UBhQhaveBoLCAcNGtOVKQpekxHuE(base.hlsJgfPNbiEXjyoptqyskoeItXRG, rectTransform, A_1);
			Vector2 pivot = base.ZlJFgENigMndbNzNAXlaJMlysRs.pivot;
			Vector2 sizeDelta = base.ZlJFgENigMndbNzNAXlaJMlysRs.sizeDelta;
			Vector3 localScale = base.ZlJFgENigMndbNzNAXlaJMlysRs.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			this.RImNGHSNXYesVuNddHqqFBgJvZIKA(vector, PositionType.Local, A_2, A_3, A_4);
		}

		// Token: 0x0600284A RID: 10314 RVA: 0x00096C08 File Offset: 0x00094E08
		private void RImNGHSNXYesVuNddHqqFBgJvZIKA(Vector2 A_1, PositionType A_2, bool A_3, float A_4, TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc A_5)
		{
			if (this.BsZgnfbkNwsdWMvaiQUUylsMBExE && A_3 && this.rVJlKaHhsfHvbHVffKiygkRddXYJ == A_5)
			{
				return;
			}
			if (this.BsZgnfbkNwsdWMvaiQUUylsMBExE && this.QMIgKGzunjBupefYQZvgLWRCwAfB != null)
			{
				this.dSLUQCKtKnnvCSbXJQgTtIfetDUV();
				this.BsZgnfbkNwsdWMvaiQUUylsMBExE = false;
				this.rVJlKaHhsfHvbHVffKiygkRddXYJ = TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.None;
			}
			if (base.hlsJgfPNbiEXjyoptqyskoeItXRG == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				A_3 = false;
			}
			else if (base.hlsJgfPNbiEXjyoptqyskoeItXRG.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				A_3 = false;
			}
			if (A_3)
			{
				Transform transform = base.transform;
				RectTransform rectTransform = base.evSkNeHIwOzqBDBovKqKbEzIdiKl;
				Vector2 one = Vector2.one;
				while ((transform = transform.parent) != rectTransform && !(transform == null))
				{
					one.x *= transform.localScale.x;
					one.y *= transform.localScale.y;
				}
				Vector2 sizeDelta = rectTransform.sizeDelta;
				bool flag = sizeDelta.x < sizeDelta.y;
				float num = MathTools.Max(sizeDelta.x, sizeDelta.y);
				float num2 = flag ? one.y : one.x;
				if (num2 == 0f)
				{
					num2 = 0.0001f;
				}
				A_4 = A_4 / num2 * num;
				this.QMIgKGzunjBupefYQZvgLWRCwAfB = this.curFEYDoLtTlBJOfMKKUAeNanmTW(A_1, A_2, A_4, A_5);
				base.StartCoroutine(this.QMIgKGzunjBupefYQZvgLWRCwAfB);
				this.rVJlKaHhsfHvbHVffKiygkRddXYJ = A_5;
				this.fsMsSENlcRtHxdORAZQEKCfLIsaN = true;
				this.moveStartedDelegate(A_5);
				return;
			}
			this.moveStartedDelegate(A_5);
			this.enXhAFPIFXOucMxEisUpzVjpbuQq(A_5, A_1, A_2);
		}

		// Token: 0x0600284B RID: 10315 RVA: 0x0001E568 File Offset: 0x0001C768
		private IEnumerator curFEYDoLtTlBJOfMKKUAeNanmTW(Vector2 A_1, PositionType A_2, float A_3, TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc A_4)
		{
			if (A_3 > 0f)
			{
				RectTransform rectTransform = base.ZlJFgENigMndbNzNAXlaJMlysRs;
				Vector2 vector = YPidKbradifyUUSIIphXNVhWkELO.FMCCakiREYuspTAFkFHwHJWBXmTdA(rectTransform, A_2);
				float magnitude = (A_1 - vector).magnitude;
				if (magnitude >= 0.01f)
				{
					this.BsZgnfbkNwsdWMvaiQUUylsMBExE = true;
					float num = magnitude / A_3;
					float num2 = 0f;
					while (num2 <= 1f)
					{
						num2 += Time.unscaledDeltaTime / num;
						YPidKbradifyUUSIIphXNVhWkELO.ModUCBJUUjSQBmryOcaxZotSMxyA(rectTransform, Vector2.Lerp(vector, A_1, Mathf.SmoothStep(0f, 1f, num2)), A_2);
						yield return null;
					}
				}
			}
			this.enXhAFPIFXOucMxEisUpzVjpbuQq(A_4, A_1, A_2);
			yield break;
		}

		// Token: 0x0600284C RID: 10316 RVA: 0x00096D90 File Offset: 0x00094F90
		private void enXhAFPIFXOucMxEisUpzVjpbuQq(TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc A_1, Vector2 A_2, PositionType A_3)
		{
			YPidKbradifyUUSIIphXNVhWkELO.ModUCBJUUjSQBmryOcaxZotSMxyA(base.ZlJFgENigMndbNzNAXlaJMlysRs, A_2, A_3);
			this.BsZgnfbkNwsdWMvaiQUUylsMBExE = false;
			this.rVJlKaHhsfHvbHVffKiygkRddXYJ = TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.None;
			if (A_1 == TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.TowardHome)
			{
				this.fsMsSENlcRtHxdORAZQEKCfLIsaN = false;
			}
			else if (A_1 == TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.TowardTouch)
			{
				this.fsMsSENlcRtHxdORAZQEKCfLIsaN = true;
			}
			this.dSLUQCKtKnnvCSbXJQgTtIfetDUV();
			this.moveEndedDelegate(A_1);
		}

		// Token: 0x0600284D RID: 10317 RVA: 0x00096DE8 File Offset: 0x00094FE8
		private void LOfstjqiejcnRjgvwcEYSOXvMbzbA(TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc A_1)
		{
			if (this._manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((this._followTouchPosition && this.stayActiveOnSwipeOut) || (!this._followTouchPosition && this.WQyzNMrPOHNEIvUbddeDKdSTrlTO != null && !this._useTouchRegionOnly && this._moveToTouchPosition)) && this._returnOnRelease && A_1 == TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					this.cyTformcxtzxQOXALUtsWziQTOSD.dHSqDioPfpgmHAtOhAxOuRATBgLSA(base.transform, flag2);
				}
			}
		}

		// Token: 0x0600284E RID: 10318 RVA: 0x00096E5C File Offset: 0x0009505C
		private void FzYehhiiAeBhdTNGmascORIHCONjb(TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc A_1)
		{
			if (this._manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((this._followTouchPosition && this.stayActiveOnSwipeOut) || (!this._followTouchPosition && this.WQyzNMrPOHNEIvUbddeDKdSTrlTO != null && !this._useTouchRegionOnly && this._moveToTouchPosition)) && this._returnOnRelease && A_1 == TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.TowardHome)
				{
					flag = true;
					flag2 = this.IJYovnoVSVUzohIibeybjRhbpiTB();
				}
				if (flag)
				{
					this.cyTformcxtzxQOXALUtsWziQTOSD.dHSqDioPfpgmHAtOhAxOuRATBgLSA(base.transform, flag2);
				}
			}
		}

		// Token: 0x0600284F RID: 10319 RVA: 0x0001E594 File Offset: 0x0001C794
		private void tvTLSHmRwoKVNHlOLCQPSpOdXOxO(int A_1)
		{
			if (!TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(A_1))
			{
				return;
			}
			this.uQrYpghGUTXfeuTPuCKNtHFcAzqo(TouchInteractable.ZUnrIQphLGwhXswkmMnPlWvrfTLc(A_1), false, 0f, TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.TowardTouch);
		}

		// Token: 0x06002850 RID: 10320 RVA: 0x00096ED8 File Offset: 0x000950D8
		private void dSLUQCKtKnnvCSbXJQgTtIfetDUV()
		{
			if (this.QMIgKGzunjBupefYQZvgLWRCwAfB != null)
			{
				try
				{
					base.StopCoroutine(this.QMIgKGzunjBupefYQZvgLWRCwAfB);
				}
				catch
				{
				}
				this.QMIgKGzunjBupefYQZvgLWRCwAfB = null;
			}
		}

		// Token: 0x06002851 RID: 10321 RVA: 0x00096F18 File Offset: 0x00095118
		private void SQxTUyoJtWJMeTQqMXbriaIICULc()
		{
			if (!this.hasPointer)
			{
				return;
			}
			if (!TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(this.effectivePointerId))
			{
				PointerEventData pointerEventData = this.cIrLrHAKcRfQYbeIyLRaLSOHkWHi(this.effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					this.BxjqialratMFjioWLviJutOQJrNB(pointerEventData);
					return;
				}
				this.LytueKJyjJVXEAJQtMMqxIkBgSAj();
			}
		}

		// Token: 0x06002852 RID: 10322 RVA: 0x0001E5B7 File Offset: 0x0001C7B7
		private bool EeCQaaWHMfTJhKbXSZfIemmUHxyj()
		{
			return this._followTouchPosition && (!(this._touchRegion != null) || !this._useTouchRegionOnly);
		}

		// Token: 0x06002853 RID: 10323 RVA: 0x0001E5DC File Offset: 0x0001C7DC
		private void WdwjZSrvvaitLDijOShCAcSlBBsj()
		{
			this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA = int.MinValue;
			this.PnXOUWLZRfcjbBBkcprpraogIZXD = int.MinValue;
		}

		// Token: 0x06002854 RID: 10324 RVA: 0x00096F68 File Offset: 0x00095168
		private bool DHdmycFacFhQEftDlnQNGbDksMug(int A_1)
		{
			return A_1 != int.MinValue && this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA != int.MinValue && (this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA == A_1 || (TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1) && this.PnXOUWLZRfcjbBBkcprpraogIZXD != int.MinValue && A_1 == this.PnXOUWLZRfcjbBBkcprpraogIZXD));
		}

		// Token: 0x06002855 RID: 10325 RVA: 0x00096FBC File Offset: 0x000951BC
		private PointerEventData EGqLWrNVdCSUHletZVzOLZXBrnci(int A_1, GameObject A_2)
		{
			PointerEventData pointerEventData = this.cIrLrHAKcRfQYbeIyLRaLSOHkWHi(A_1);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.ZUnrIQphLGwhXswkmMnPlWvrfTLc(A_1);
			if (TouchInteractable.BPfCcONQMDTOcTiIMuueyAPpzvSi(A_1))
			{
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				if (pointerEventData.pointerEnter != A_2)
				{
					pointerEventData.pointerEnter = A_2;
				}
				float unscaledTime = Time.unscaledTime;
				if (A_2 == pointerEventData.lastPress)
				{
					if (unscaledTime - pointerEventData.clickTime < 0.3f)
					{
						PointerEventData pointerEventData2 = pointerEventData;
						int clickCount = pointerEventData2.clickCount + 1;
						pointerEventData2.clickCount = clickCount;
					}
					else
					{
						pointerEventData.clickCount = 1;
					}
					pointerEventData.clickTime = unscaledTime;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.pointerPress = A_2;
				pointerEventData.rawPointerPress = A_2;
				pointerEventData.clickTime = unscaledTime;
				pointerEventData.pointerDrag = A_2;
			}
			else
			{
				if (!TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1))
				{
					Logger.LogWarning("Unsupported pointerId: " + A_1.ToString());
					return null;
				}
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				float unscaledTime2 = Time.unscaledTime;
				if (A_2 == pointerEventData.lastPress)
				{
					if (unscaledTime2 - pointerEventData.clickTime < 0.3f)
					{
						PointerEventData pointerEventData3 = pointerEventData;
						int clickCount = pointerEventData3.clickCount + 1;
						pointerEventData3.clickCount = clickCount;
					}
					else
					{
						pointerEventData.clickCount = 1;
					}
					pointerEventData.clickTime = unscaledTime2;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.pointerPress = A_2;
				pointerEventData.rawPointerPress = A_2;
				pointerEventData.clickTime = unscaledTime2;
				pointerEventData.pointerDrag = A_2;
			}
			return pointerEventData;
		}

		// Token: 0x06002856 RID: 10326 RVA: 0x00097184 File Offset: 0x00095384
		private PointerEventData DnMbAgzvaUdzsGEtUqKyjMOttPNlA(int A_1)
		{
			PointerEventData pointerEventData = this.cIrLrHAKcRfQYbeIyLRaLSOHkWHi(A_1);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.BPfCcONQMDTOcTiIMuueyAPpzvSi(A_1))
			{
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				pointerEventData.pointerDrag = null;
				pointerEventData.pointerEnter = null;
			}
			else
			{
				if (!TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1))
				{
					Logger.LogWarning("Unsupported pointerId: " + A_1.ToString());
					return null;
				}
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				pointerEventData.pointerDrag = null;
			}
			return pointerEventData;
		}

		// Token: 0x06002857 RID: 10327 RVA: 0x0001E5F4 File Offset: 0x0001C7F4
		private void BxjqialratMFjioWLviJutOQJrNB(PointerEventData A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.OnPointerUp(A_1);
			this.DnMbAgzvaUdzsGEtUqKyjMOttPNlA(this.effectivePointerId);
		}

		// Token: 0x06002858 RID: 10328 RVA: 0x00097218 File Offset: 0x00095418
		private PointerEventData cIrLrHAKcRfQYbeIyLRaLSOHkWHi(int A_1)
		{
			if (A_1 == -2147483648)
			{
				return null;
			}
			if (this.cisiBsBinokKqhuRZtUURRtmFQLn == null)
			{
				this.cisiBsBinokKqhuRZtUURRtmFQLn = new Dictionary<int, PointerEventData>();
			}
			PointerEventData pointerEventData;
			if (!this.cisiBsBinokKqhuRZtUURRtmFQLn.TryGetValue(A_1, out pointerEventData))
			{
				pointerEventData = new PointerEventData(EventSystem.current);
				pointerEventData.pointerId = A_1;
				this.cisiBsBinokKqhuRZtUURRtmFQLn.Add(A_1, pointerEventData);
				if (TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1))
				{
					PointerEventData.InputButton button;
					switch (A_1)
					{
					case -3:
						button = PointerEventData.InputButton.Middle;
						break;
					case -2:
						button = PointerEventData.InputButton.Right;
						break;
					case -1:
						button = PointerEventData.InputButton.Left;
						break;
					default:
						throw new NotImplementedException();
					}
					pointerEventData.button = button;
				}
			}
			return pointerEventData;
		}

		// Token: 0x06002859 RID: 10329 RVA: 0x000972AC File Offset: 0x000954AC
		private void KyARQagbfNInoAuIpSzhgAJtmwoY(PointerEventData A_1, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA A_2)
		{
			if (this.hasPointer && !this.DHdmycFacFhQEftDlnQNGbDksMug(A_1.pointerId))
			{
				return;
			}
			if (base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && base.IsInteractable())
			{
				this.epYDBaGTinHwzzPcrgOXfhinXWiX(A_1.pointerId, A_1.pressPosition, A_2);
			}
			base.OnPointerDown(A_1);
		}

		// Token: 0x0600285A RID: 10330 RVA: 0x0001E60E File Offset: 0x0001C80E
		private void HXwRVMkFsljbPQxeeqXmMfMPEvfI(PointerEventData A_1, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA A_2)
		{
			if (this.hasPointer && !this.DHdmycFacFhQEftDlnQNGbDksMug(A_1.pointerId))
			{
				return;
			}
			if (TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(this.effectivePointerId))
			{
				return;
			}
			this.LytueKJyjJVXEAJQtMMqxIkBgSAj();
			base.OnPointerUp(A_1);
		}

		// Token: 0x0600285B RID: 10331 RVA: 0x000972FC File Offset: 0x000954FC
		private void dbgmXNHfzABBdCbIuIAyARPJeInHb(PointerEventData A_1, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA A_2)
		{
			if (this.hasPointer && !this.DHdmycFacFhQEftDlnQNGbDksMug(A_1.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1.pointerId);
			bool flag2 = false;
			TouchInteractable.MouseButtonFlags allowedMouseButtons;
			if (A_2 != TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.Local)
			{
				if (A_2 != TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.TouchRegion)
				{
					throw new NotImplementedException();
				}
				allowedMouseButtons = this._touchRegion.allowedMouseButtons;
			}
			else
			{
				allowedMouseButtons = base.allowedMouseButtons;
			}
			if (this._activateOnSwipeIn && base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && base.IsInteractable() && (!flag || TouchInteractable.ygyrytQEEfuBWjVlJlbtaHrKeHYjA(allowedMouseButtons)) && !this.BFjnzWzbQOcoGPkkTENnjsLfvvhW)
			{
				if (flag)
				{
					int pnXOUWLZRfcjbBBkcprpraogIZXD;
					if (TouchInteractable.fViPIDXJiFoyaUCiJDHKdMbSRRWeA(allowedMouseButtons, out pnXOUWLZRfcjbBBkcprpraogIZXD))
					{
						this.PnXOUWLZRfcjbBBkcprpraogIZXD = pnXOUWLZRfcjbBBkcprpraogIZXD;
					}
					else
					{
						this.PnXOUWLZRfcjbBBkcprpraogIZXD = A_1.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(A_1);
			if (flag2)
			{
				GameObject gameObject;
				if (A_2 != TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.Local)
				{
					if (A_2 != TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.TouchRegion)
					{
						throw new NotImplementedException();
					}
					gameObject = this.WQyzNMrPOHNEIvUbddeDKdSTrlTO.gameObject;
				}
				else
				{
					gameObject = base.gameObject;
				}
				PointerEventData pointerEventData = this.EGqLWrNVdCSUHletZVzOLZXBrnci((this.PnXOUWLZRfcjbBBkcprpraogIZXD != int.MinValue) ? this.PnXOUWLZRfcjbBBkcprpraogIZXD : A_1.pointerId, gameObject);
				if (pointerEventData != null)
				{
					this.KyARQagbfNInoAuIpSzhgAJtmwoY(pointerEventData, A_2);
				}
			}
			this.besVMalhWlFgomFdnJSkzUMUdvVS = true;
		}

		// Token: 0x0600285C RID: 10332 RVA: 0x00097414 File Offset: 0x00095614
		private void qHbgORJHGtjrPEEehLqUTgjEaTfoB(PointerEventData A_1, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA A_2)
		{
			if (this.hasPointer && !this.DHdmycFacFhQEftDlnQNGbDksMug(A_1.pointerId))
			{
				base.OnPointerExit(A_1);
				return;
			}
			if (!this.stayActiveOnSwipeOut && this.BFjnzWzbQOcoGPkkTENnjsLfvvhW)
			{
				this.LytueKJyjJVXEAJQtMMqxIkBgSAj();
			}
			base.OnPointerExit(A_1);
			this.besVMalhWlFgomFdnJSkzUMUdvVS = false;
		}

		// Token: 0x0600285D RID: 10333 RVA: 0x00097464 File Offset: 0x00095664
		private void epYDBaGTinHwzzPcrgOXfhinXWiX(int A_1, Vector2 A_2, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA A_3)
		{
			this.sUDMoQUHHCwvohkLgFvDhTCMbdAxA = A_1;
			this.BFjnzWzbQOcoGPkkTENnjsLfvvhW = true;
			if (this._followTouchPosition)
			{
				this.tvTLSHmRwoKVNHlOLCQPSpOdXOxO(A_1);
			}
			else if (A_3 == TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.TouchRegion && this._moveToTouchPosition)
			{
				this.uQrYpghGUTXfeuTPuCKNtHFcAzqo(A_2, this._animateOnMoveToTouch, this._moveToTouchSpeed, TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc.TowardTouch);
			}
			this.wKRrQWiKxTFyVrqOpebiXAmIDnzdA();
		}

		// Token: 0x0600285E RID: 10334 RVA: 0x0001E642 File Offset: 0x0001C842
		private void LytueKJyjJVXEAJQtMMqxIkBgSAj()
		{
			this.WdwjZSrvvaitLDijOShCAcSlBBsj();
			this.BFjnzWzbQOcoGPkkTENnjsLfvvhW = false;
			if ((this._followTouchPosition || this._moveToTouchPosition) && this._returnOnRelease && this.fsMsSENlcRtHxdORAZQEKCfLIsaN)
			{
				this.ReturnToDefaultPosition();
			}
			this.CfDlhsLiXJlhDxNRkbWJkUmSlOPl();
		}

		// Token: 0x0600285F RID: 10335 RVA: 0x0001E67D File Offset: 0x0001C87D
		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				return;
			}
			if (this.WQyzNMrPOHNEIvUbddeDKdSTrlTO != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.KyARQagbfNInoAuIpSzhgAJtmwoY(eventData, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.Local);
		}

		// Token: 0x06002860 RID: 10336 RVA: 0x0001E6BC File Offset: 0x0001C8BC
		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			if (this.WQyzNMrPOHNEIvUbddeDKdSTrlTO != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.HXwRVMkFsljbPQxeeqXmMfMPEvfI(eventData, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.Local);
		}

		// Token: 0x06002861 RID: 10337 RVA: 0x0001E6FB File Offset: 0x0001C8FB
		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			if (this.WQyzNMrPOHNEIvUbddeDKdSTrlTO != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.dbgmXNHfzABBdCbIuIAyARPJeInHb(eventData, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.Local);
		}

		// Token: 0x06002862 RID: 10338 RVA: 0x0001E73A File Offset: 0x0001C93A
		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			if (this.WQyzNMrPOHNEIvUbddeDKdSTrlTO != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.qHbgORJHGtjrPEEehLqUTgjEaTfoB(eventData, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.Local);
		}

		// Token: 0x06002863 RID: 10339 RVA: 0x0001E779 File Offset: 0x0001C979
		private void IMdQBHurTUggMCngIbMFdDAdejxEb(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				return;
			}
			this.KyARQagbfNInoAuIpSzhgAJtmwoY(A_1, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.TouchRegion);
		}

		// Token: 0x06002864 RID: 10340 RVA: 0x0001E7A6 File Offset: 0x0001C9A6
		private void mUCirufydpwCTqJXtnOgsvsqzIcg(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			this.HXwRVMkFsljbPQxeeqXmMfMPEvfI(A_1, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.TouchRegion);
		}

		// Token: 0x06002865 RID: 10341 RVA: 0x0001E7D3 File Offset: 0x0001C9D3
		private void DNKWrquuUNECGcCpXvpCmCBZekQg(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			this.dbgmXNHfzABBdCbIuIAyARPJeInHb(A_1, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.TouchRegion);
		}

		// Token: 0x06002866 RID: 10342 RVA: 0x0001E800 File Offset: 0x0001CA00
		private void tlIhQmXkGixkigitYVPjttbyOQPw(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			this.qHbgORJHGtjrPEEehLqUTgjEaTfoB(A_1, TouchButton.kfsCvfTemaaCoephzjyGnHbKCCRXA.TouchRegion);
		}

		// Token: 0x06002867 RID: 10343 RVA: 0x0001E82D File Offset: 0x0001CA2D
		private void sDJgWwHKkPfyJAIGWfJNexgmwgfrA(float A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (this._useDigitalAxisSimulation)
			{
				return;
			}
			base.bQxfVwsHphtKQjTPHonPFeqrEVvE(null);
			this._onAxisValueChanged.Invoke(A_1);
		}

		// Token: 0x06002868 RID: 10344 RVA: 0x0001E854 File Offset: 0x0001CA54
		private void qMCmLdlzXTTDukdJCFtZQZupdOoE(bool A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			base.bQxfVwsHphtKQjTPHonPFeqrEVvE(null);
			this._onButtonValueChanged.Invoke(A_1);
		}

		// Token: 0x06002869 RID: 10345 RVA: 0x0001E872 File Offset: 0x0001CA72
		private void RwTIwBHroVwCtnEOLpmmMJxhWNfQ()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			base.bQxfVwsHphtKQjTPHonPFeqrEVvE(null);
			this._onButtonDown.Invoke();
		}

		// Token: 0x0600286A RID: 10346 RVA: 0x0001E88F File Offset: 0x0001CA8F
		private void pYUloTECKnLanBANSdkGEakrcgPz()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			base.bQxfVwsHphtKQjTPHonPFeqrEVvE(null);
			this._onButtonUp.Invoke();
		}

		// Token: 0x04001724 RID: 5924
		private const float nSJFHrBXfBkqcOybkpivzcBBGfgh = 20f;

		// Token: 0x04001725 RID: 5925
		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		// Token: 0x04001726 RID: 5926
		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchButton.ButtonType _buttonType;

		// Token: 0x04001727 RID: 5927
		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		// Token: 0x04001728 RID: 5928
		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		// Token: 0x04001729 RID: 5929
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useDigitalAxisSimulation;

		// Token: 0x0400172A RID: 5930
		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		// Token: 0x0400172B RID: 5931
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		// Token: 0x0400172C RID: 5932
		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis = new StandaloneAxis();

		// Token: 0x0400172D RID: 5933
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		// Token: 0x0400172E RID: 5934
		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		// Token: 0x0400172F RID: 5935
		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		// Token: 0x04001730 RID: 5936
		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		// Token: 0x04001731 RID: 5937
		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		// Token: 0x04001732 RID: 5938
		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		// Token: 0x04001733 RID: 5939
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		// Token: 0x04001734 RID: 5940
		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		// Token: 0x04001735 RID: 5941
		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		// Token: 0x04001736 RID: 5942
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		// Token: 0x04001737 RID: 5943
		private float lnWisbmcPNhKAWLclidLbuQgDRPU;

		// Token: 0x04001738 RID: 5944
		private float yPNDpoKDNYyJzZKgvsstwHlLcbvc;

		// Token: 0x04001739 RID: 5945
		private TouchRegion WQyzNMrPOHNEIvUbddeDKdSTrlTO;

		// Token: 0x0400173A RID: 5946
		private Vector2 WiZZjedfuoEZcItYfdtMKBLkpWld;

		// Token: 0x0400173B RID: 5947
		private bool BsZgnfbkNwsdWMvaiQUUylsMBExE;

		// Token: 0x0400173C RID: 5948
		private bool fsMsSENlcRtHxdORAZQEKCfLIsaN;

		// Token: 0x0400173D RID: 5949
		private TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc rVJlKaHhsfHvbHVffKiygkRddXYJ;

		// Token: 0x0400173E RID: 5950
		private int sUDMoQUHHCwvohkLgFvDhTCMbdAxA = int.MinValue;

		// Token: 0x0400173F RID: 5951
		private int PnXOUWLZRfcjbBBkcprpraogIZXD = int.MinValue;

		// Token: 0x04001740 RID: 5952
		[NonSerialized]
		private bool BFjnzWzbQOcoGPkkTENnjsLfvvhW;

		// Token: 0x04001741 RID: 5953
		[NonSerialized]
		private bool besVMalhWlFgomFdnJSkzUMUdvVS;

		// Token: 0x04001742 RID: 5954
		private IEnumerator QMIgKGzunjBupefYQZvgLWRCwAfB;

		// Token: 0x04001743 RID: 5955
		private IhGVaSmWhHGFsLRYkATnDFHjoxNf cyTformcxtzxQOXALUtsWziQTOSD = new IhGVaSmWhHGFsLRYkATnDFHjoxNf();

		// Token: 0x04001744 RID: 5956
		private Action<TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc> XCEbOTXZKWQYZhoxcGAeUlHbVSMT;

		// Token: 0x04001745 RID: 5957
		private Action<TouchButton.adciSpKCnjKsqdereBHdGZMgBwPfc> PnlTZBpgdScYhYPGNhiFigZsiLkbA;

		// Token: 0x04001746 RID: 5958
		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchButton.AxisValueChangedEventHandler _onAxisValueChanged = new TouchButton.AxisValueChangedEventHandler();

		// Token: 0x04001747 RID: 5959
		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchButton.ButtonValueChangedEventHandler _onButtonValueChanged = new TouchButton.ButtonValueChangedEventHandler();

		// Token: 0x04001748 RID: 5960
		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchButton.ButtonDownEventHandler _onButtonDown = new TouchButton.ButtonDownEventHandler();

		// Token: 0x04001749 RID: 5961
		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchButton.ButtonUpEventHandler _onButtonUp = new TouchButton.ButtonUpEventHandler();

		// Token: 0x0400174A RID: 5962
		private Dictionary<int, PointerEventData> cisiBsBinokKqhuRZtUURRtmFQLn;

		// Token: 0x020003E6 RID: 998
		public enum ButtonType
		{
			// Token: 0x0400174C RID: 5964
			Standard,
			// Token: 0x0400174D RID: 5965
			ToggleSwitch
		}

		// Token: 0x020003E7 RID: 999
		private enum adciSpKCnjKsqdereBHdGZMgBwPfc
		{
			// Token: 0x0400174F RID: 5967
			None,
			// Token: 0x04001750 RID: 5968
			TowardTouch,
			// Token: 0x04001751 RID: 5969
			TowardHome
		}

		// Token: 0x020003E8 RID: 1000
		private enum kfsCvfTemaaCoephzjyGnHbKCCRXA
		{
			// Token: 0x04001753 RID: 5971
			Local,
			// Token: 0x04001754 RID: 5972
			TouchRegion
		}

		// Token: 0x020003E9 RID: 1001
		[Serializable]
		public class AxisValueChangedEventHandler : UnityEvent<float>
		{
		}

		// Token: 0x020003EA RID: 1002
		[Serializable]
		public class ButtonValueChangedEventHandler : UnityEvent<bool>
		{
		}

		// Token: 0x020003EB RID: 1003
		[Serializable]
		public class ButtonDownEventHandler : UnityEvent
		{
		}

		// Token: 0x020003EC RID: 1004
		[Serializable]
		public class ButtonUpEventHandler : UnityEvent
		{
		}
	}
}
