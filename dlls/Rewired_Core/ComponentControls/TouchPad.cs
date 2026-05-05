using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.ComponentControls
{
	// Token: 0x02000409 RID: 1033
	[RequireComponent(typeof(Image))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Touch Pad")]
	[Serializable]
	public sealed class TouchPad : TouchInteractable, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		// Token: 0x1400004C RID: 76
		// (add) Token: 0x060029A4 RID: 10660 RVA: 0x0001FDB2 File Offset: 0x0001DFB2
		// (remove) Token: 0x060029A5 RID: 10661 RVA: 0x0001FDC0 File Offset: 0x0001DFC0
		public event UnityAction<Vector2> ValueChangedEvent
		{
			add
			{
				this._onValueChanged.AddListener(value);
			}
			remove
			{
				this._onValueChanged.RemoveListener(value);
			}
		}

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x060029A6 RID: 10662 RVA: 0x0001FDCE File Offset: 0x0001DFCE
		// (remove) Token: 0x060029A7 RID: 10663 RVA: 0x0001FDDC File Offset: 0x0001DFDC
		public event UnityAction TapEvent
		{
			add
			{
				this._onTap.AddListener(value);
			}
			remove
			{
				this._onTap.RemoveListener(value);
			}
		}

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x060029A8 RID: 10664 RVA: 0x0001FDEA File Offset: 0x0001DFEA
		// (remove) Token: 0x060029A9 RID: 10665 RVA: 0x0001FDF8 File Offset: 0x0001DFF8
		public event UnityAction PressDownEvent
		{
			add
			{
				this._onPressDown.AddListener(value);
			}
			remove
			{
				this._onPressDown.RemoveListener(value);
			}
		}

		// Token: 0x1400004F RID: 79
		// (add) Token: 0x060029AA RID: 10666 RVA: 0x0001FE06 File Offset: 0x0001E006
		// (remove) Token: 0x060029AB RID: 10667 RVA: 0x0001FE14 File Offset: 0x0001E014
		public event UnityAction PressUpEvent
		{
			add
			{
				this._onPressUp.AddListener(value);
			}
			remove
			{
				this._onPressUp.RemoveListener(value);
			}
		}

		// Token: 0x170009C9 RID: 2505
		// (get) Token: 0x060029AC RID: 10668 RVA: 0x0001FE22 File Offset: 0x0001E022
		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement
		{
			get
			{
				return this._horizontalAxisCustomControllerElement;
			}
		}

		// Token: 0x170009CA RID: 2506
		// (get) Token: 0x060029AD RID: 10669 RVA: 0x0001FE2A File Offset: 0x0001E02A
		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement
		{
			get
			{
				return this._verticalAxisCustomControllerElement;
			}
		}

		// Token: 0x170009CB RID: 2507
		// (get) Token: 0x060029AE RID: 10670 RVA: 0x0001FE32 File Offset: 0x0001E032
		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement
		{
			get
			{
				return this._tapCustomControllerElement;
			}
		}

		// Token: 0x170009CC RID: 2508
		// (get) Token: 0x060029AF RID: 10671 RVA: 0x0001FE3A File Offset: 0x0001E03A
		public CustomControllerElementTargetSetForBoolean pressCustomControllerElement
		{
			get
			{
				return this._pressCustomControllerElement;
			}
		}

		// Token: 0x170009CD RID: 2509
		// (get) Token: 0x060029B0 RID: 10672 RVA: 0x0001FE42 File Offset: 0x0001E042
		// (set) Token: 0x060029B1 RID: 10673 RVA: 0x0001FE4A File Offset: 0x0001E04A
		public TouchPad.AxisDirection axesToUse
		{
			get
			{
				return this._axesToUse;
			}
			set
			{
				if (this._axesToUse == value)
				{
					return;
				}
				this.iFFrDYlNqnDnXMsRICXInQtkBmpHA(value);
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009CE RID: 2510
		// (get) Token: 0x060029B2 RID: 10674 RVA: 0x0001FE63 File Offset: 0x0001E063
		// (set) Token: 0x060029B3 RID: 10675 RVA: 0x0001FE6B File Offset: 0x0001E06B
		public TouchPad.TouchPadMode touchPadMode
		{
			get
			{
				return this._touchPadMode;
			}
			set
			{
				if (this._touchPadMode == value)
				{
					return;
				}
				this._touchPadMode = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009CF RID: 2511
		// (get) Token: 0x060029B4 RID: 10676 RVA: 0x0001FE84 File Offset: 0x0001E084
		// (set) Token: 0x060029B5 RID: 10677 RVA: 0x0001FE8C File Offset: 0x0001E08C
		public TouchPad.ValueFormat valueFormat
		{
			get
			{
				return this._valueFormat;
			}
			set
			{
				if (this._valueFormat == value)
				{
					return;
				}
				this._valueFormat = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009D0 RID: 2512
		// (get) Token: 0x060029B6 RID: 10678 RVA: 0x0001FEA5 File Offset: 0x0001E0A5
		// (set) Token: 0x060029B7 RID: 10679 RVA: 0x0001FEAD File Offset: 0x0001E0AD
		public bool useInertia
		{
			get
			{
				return this._useInertia;
			}
			set
			{
				if (this._useInertia == value)
				{
					return;
				}
				this._useInertia = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009D1 RID: 2513
		// (get) Token: 0x060029B8 RID: 10680 RVA: 0x0001FEC6 File Offset: 0x0001E0C6
		// (set) Token: 0x060029B9 RID: 10681 RVA: 0x0001FECE File Offset: 0x0001E0CE
		public float inertiaFriction
		{
			get
			{
				return this._inertiaFriction;
			}
			set
			{
				value = MathTools.Max(0f, value);
				if (this._inertiaFriction == value)
				{
					return;
				}
				this._inertiaFriction = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x060029BA RID: 10682 RVA: 0x0001FEF4 File Offset: 0x0001E0F4
		// (set) Token: 0x060029BB RID: 10683 RVA: 0x0001FEFC File Offset: 0x0001E0FC
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

		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x060029BC RID: 10684 RVA: 0x0001FF15 File Offset: 0x0001E115
		// (set) Token: 0x060029BD RID: 10685 RVA: 0x0001FF1D File Offset: 0x0001E11D
		public bool stayActiveOnSwipeOut
		{
			get
			{
				return this._stayActiveOnSwipeOut;
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

		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x060029BE RID: 10686 RVA: 0x0001FF36 File Offset: 0x0001E136
		// (set) Token: 0x060029BF RID: 10687 RVA: 0x0001FF3E File Offset: 0x0001E13E
		public bool allowTap
		{
			get
			{
				return this._allowTap;
			}
			set
			{
				if (this._allowTap == value)
				{
					return;
				}
				this._allowTap = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x060029C0 RID: 10688 RVA: 0x0001FF57 File Offset: 0x0001E157
		// (set) Token: 0x060029C1 RID: 10689 RVA: 0x0001FF5F File Offset: 0x0001E15F
		public float tapTimeout
		{
			get
			{
				return this._tapTimeout;
			}
			set
			{
				value = MathTools.Max(0f, value);
				if (this._tapTimeout == value)
				{
					return;
				}
				this._tapTimeout = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x060029C2 RID: 10690 RVA: 0x0001FF85 File Offset: 0x0001E185
		// (set) Token: 0x060029C3 RID: 10691 RVA: 0x0001FF8D File Offset: 0x0001E18D
		public int tapDistanceLimit
		{
			get
			{
				return this._tapDistanceLimit;
			}
			set
			{
				value = MathTools.Max(-1, value);
				if (this._tapDistanceLimit == value)
				{
					return;
				}
				this._tapDistanceLimit = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x060029C4 RID: 10692 RVA: 0x0001FFAF File Offset: 0x0001E1AF
		// (set) Token: 0x060029C5 RID: 10693 RVA: 0x0001FFB7 File Offset: 0x0001E1B7
		public bool allowPress
		{
			get
			{
				return this._allowPress;
			}
			set
			{
				if (this._allowPress == value)
				{
					return;
				}
				this._allowPress = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x060029C6 RID: 10694 RVA: 0x0001FFD0 File Offset: 0x0001E1D0
		// (set) Token: 0x060029C7 RID: 10695 RVA: 0x0001FFD8 File Offset: 0x0001E1D8
		public float pressStartDelay
		{
			get
			{
				return this._pressStartDelay;
			}
			set
			{
				value = Mathf.Max(0f, value);
				if (this._pressStartDelay == value)
				{
					return;
				}
				this._pressStartDelay = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x060029C8 RID: 10696 RVA: 0x0001FFFE File Offset: 0x0001E1FE
		// (set) Token: 0x060029C9 RID: 10697 RVA: 0x00020006 File Offset: 0x0001E206
		public int pressDistanceLimit
		{
			get
			{
				return this._pressDistanceLimit;
			}
			set
			{
				value = MathTools.Max(-1, value);
				if (this._pressDistanceLimit == value)
				{
					return;
				}
				this._pressDistanceLimit = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x060029CA RID: 10698 RVA: 0x00020028 File Offset: 0x0001E228
		// (set) Token: 0x060029CB RID: 10699 RVA: 0x00099A90 File Offset: 0x00097C90
		public bool hideAtRuntime
		{
			get
			{
				return this._hideAtRuntime;
			}
			set
			{
				this._hideAtRuntime = value;
				if (value)
				{
					return;
				}
				this._hideAtRuntime = true;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x060029CC RID: 10700 RVA: 0x00020030 File Offset: 0x0001E230
		// (set) Token: 0x060029CD RID: 10701 RVA: 0x00020038 File Offset: 0x0001E238
		public int pointerId
		{
			get
			{
				return this._pointerId;
			}
			set
			{
				this._pointerId = value;
			}
		}

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x060029CE RID: 10702 RVA: 0x00020041 File Offset: 0x0001E241
		public bool hasPointer
		{
			get
			{
				return this._pointerId != int.MinValue;
			}
		}

		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x060029CF RID: 10703 RVA: 0x00020053 File Offset: 0x0001E253
		public Vector2 touchStartPosition
		{
			get
			{
				if (!this.hasPointer)
				{
					return Vector2.zero;
				}
				return this._touchStartPosition;
			}
		}

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x060029D0 RID: 10704 RVA: 0x00020069 File Offset: 0x0001E269
		public Vector2 touchPosition
		{
			get
			{
				if (!TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq))
				{
					return Vector2.zero;
				}
				return TouchInteractable.ZUnrIQphLGwhXswkmMnPlWvrfTLc(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq);
			}
		}

		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x060029D1 RID: 10705 RVA: 0x0002008E File Offset: 0x0001E28E
		public AxisCalibration horizontalAxisCalibration
		{
			get
			{
				return this._axis2D.xAxis.calibration;
			}
		}

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x060029D2 RID: 10706 RVA: 0x000200A0 File Offset: 0x0001E2A0
		public AxisCalibration verticalAxisCalibration
		{
			get
			{
				return this._axis2D.yAxis.calibration;
			}
		}

		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x060029D3 RID: 10707 RVA: 0x000200B2 File Offset: 0x0001E2B2
		public Axis2DCalibration axis2DCalibration
		{
			get
			{
				return this._axis2D.calibration;
			}
		}

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x060029D4 RID: 10708 RVA: 0x000200BF File Offset: 0x0001E2BF
		internal StandaloneAxis2D UlZUNflJdgHESLYdWfNUJbOStoHg
		{
			get
			{
				return this._axis2D;
			}
		}

		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x060029D5 RID: 10709 RVA: 0x000200C7 File Offset: 0x0001E2C7
		private int irhRZvOoFfQUfIZNFwqKsVXMbsDq
		{
			get
			{
				if (this._pointerId == -2147483648)
				{
					return int.MinValue;
				}
				if (this._realMousePointerId != -2147483648)
				{
					return this._realMousePointerId;
				}
				return this._pointerId;
			}
		}

		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x060029D6 RID: 10710 RVA: 0x000200F6 File Offset: 0x0001E2F6
		private bool fXmjSXoKIiaqJjIlxwPOlBxihCyBA
		{
			get
			{
				return this._lastTapFrame == Time.frameCount;
			}
		}

		// Token: 0x060029D7 RID: 10711 RVA: 0x00099AB8 File Offset: 0x00097CB8
		[CustomObfuscation(rename = false)]
		private TouchPad()
		{
		}

		// Token: 0x060029D8 RID: 10712 RVA: 0x00020105 File Offset: 0x0001E305
		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (!Application.isPlaying)
			{
				return;
			}
			if (this._hideAtRuntime)
			{
				base.visible = false;
			}
		}

		// Token: 0x060029D9 RID: 10713 RVA: 0x00020124 File Offset: 0x0001E324
		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.wLmUQACxccgjgpHHepogeyVWebMh();
			this.ipPXceibCBYQjyJEtenneGSbBgec();
		}

		// Token: 0x060029DA RID: 10714 RVA: 0x00020141 File Offset: 0x0001E341
		internal bool qENzjHqsBKFeihJnbaoLYbJSaJSC()
		{
			if (!base.ljoRLbCAHFdMhoOyLpdVnVLwwTMd())
			{
				return false;
			}
			this.wLmUQACxccgjgpHHepogeyVWebMh();
			return true;
		}

		// Token: 0x060029DB RID: 10715 RVA: 0x00020154 File Offset: 0x0001E354
		internal void pXzCBGClVVUGkuLjQUfiFArRjCAp()
		{
			base.AoHwozRsjiUmhnUZxZinlrstaSL();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.OnmzWserPNqVjUObakICZqUFereu();
			this.HiAQChbxaNBxIDEPxXkVzJOXfdgF();
			this.yjOcaWVPyxCODxIPrxqCVdFgBVsl();
			this.rMVGbOeWhYFRNjgAmsrcGXfFkxYn();
			this.CPJjKigeiNDyLrfYYsbJmYSNEHFq();
		}

		// Token: 0x060029DC RID: 10716 RVA: 0x00099B90 File Offset: 0x00097D90
		internal void cSENdeqyIFMCUEAKNTWxwJYRgbLs()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			Vector2 vector = (this._touchPadMode == TouchPad.TouchPadMode.ScreenPosition) ? this._axis2D.rawValue : this._axis2D.value;
			if (this._useXAxis)
			{
				base.WiKtlIjluObCctWuxDsizpItcifHA(this._horizontalAxisCustomControllerElement, vector.x, this._axis2D.xAxis.buttonActivationThreshold);
			}
			if (this._useYAxis)
			{
				base.WiKtlIjluObCctWuxDsizpItcifHA(this._verticalAxisCustomControllerElement, vector.y, this._axis2D.xAxis.buttonActivationThreshold);
			}
			if (this._allowTap)
			{
				base.wxsDJwhBGhAlFpbeoLzNoYvIriVe(this._tapCustomControllerElement, this.fXmjSXoKIiaqJjIlxwPOlBxihCyBA);
			}
			if (this._allowPress)
			{
				base.wxsDJwhBGhAlFpbeoLzNoYvIriVe(this._pressCustomControllerElement, this._pressValue);
			}
		}

		// Token: 0x060029DD RID: 10717 RVA: 0x00020183 File Offset: 0x0001E383
		internal void cwcwUsAdTFdbgSHjEcGUczGHAcrd()
		{
			base.DIrIjbritRrTvPOfPhRMJhhCMvxGA();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.wLmUQACxccgjgpHHepogeyVWebMh();
			this.ipPXceibCBYQjyJEtenneGSbBgec();
		}

		// Token: 0x060029DE RID: 10718 RVA: 0x00099C5C File Offset: 0x00097E5C
		internal void sYqabaVnbEXiFNlQEBkogkJmzobhA()
		{
			base.ypZrirDpTPdDSbwgBziSLiFRjrJkA();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this._pointerId = int.MinValue;
			this._realMousePointerId = int.MinValue;
			this.bNkmGtrSyHVkUxSFqQVYqlrdxTOA = false;
			this.NMgPdgSLNKjVBrRjdgKlKtQActXT = false;
			this._pointerDownIsFake = false;
			this._currentCenter = Vector2.zero;
			this._previousTouchPosition = Vector2.zero;
			this._axis2D.Clear();
			this._lastTapFrame = -1;
			this._pressValue = false;
			this._isEligibleForTap = false;
			this._isEligibleForPress = false;
		}

		// Token: 0x060029DF RID: 10719 RVA: 0x00099CE8 File Offset: 0x00097EE8
		public override void ClearValue()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this._axis2D.Clear();
			this._lastTapFrame = -1;
			this._pressValue = false;
			if (this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._horizontalAxisCustomControllerElement);
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._verticalAxisCustomControllerElement);
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._tapCustomControllerElement);
			}
		}

		// Token: 0x060029E0 RID: 10720 RVA: 0x000201A0 File Offset: 0x0001E3A0
		private void ipPXceibCBYQjyJEtenneGSbBgec()
		{
			this._horizontalAxisCustomControllerElement.ClearElementCaches();
			this._verticalAxisCustomControllerElement.ClearElementCaches();
			this._tapCustomControllerElement.ClearElementCaches();
			this._pressCustomControllerElement.ClearElementCaches();
		}

		// Token: 0x060029E1 RID: 10721 RVA: 0x00099D54 File Offset: 0x00097F54
		private void wLmUQACxccgjgpHHepogeyVWebMh()
		{
			this.iFFrDYlNqnDnXMsRICXInQtkBmpHA(this._axesToUse);
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			if (!base.hkMTiCBrvqenueclmmzSAhNXvEwA.useCustomController)
			{
				return;
			}
			if (this._useXAxis)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ValidateElements(this._horizontalAxisCustomControllerElement);
			}
			if (this._useYAxis)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ValidateElements(this._verticalAxisCustomControllerElement);
			}
			if (this._allowTap)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ValidateElements(this._tapCustomControllerElement);
			}
			if (this._allowPress)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ValidateElements(this._pressCustomControllerElement);
			}
		}

		// Token: 0x060029E2 RID: 10722 RVA: 0x00099DEC File Offset: 0x00097FEC
		private void iFFrDYlNqnDnXMsRICXInQtkBmpHA(TouchPad.AxisDirection A_1)
		{
			bool flag = A_1 == TouchPad.AxisDirection.Both || A_1 == TouchPad.AxisDirection.Horizontal;
			if (this._useXAxis != flag)
			{
				this._useXAxis = flag;
				if (!flag && this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
				{
					base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._horizontalAxisCustomControllerElement);
				}
			}
			bool flag2 = A_1 == TouchPad.AxisDirection.Both || A_1 == TouchPad.AxisDirection.Vertical;
			if (this._useYAxis != flag2)
			{
				this._useYAxis = flag2;
				if (!flag2 && this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
				{
					base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._verticalAxisCustomControllerElement);
				}
			}
			this._axesToUse = A_1;
		}

		// Token: 0x060029E3 RID: 10723 RVA: 0x00099E70 File Offset: 0x00098070
		private void HiAQChbxaNBxIDEPxXkVzJOXfdgF()
		{
			if (!this.hasPointer)
			{
				return;
			}
			if (!TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq))
			{
				PointerEventData pointerEventData = this.nEzEbKwKsVWJWDgpIPpEEUJCpVos(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					this.YUUxJnPZJmCITQiGDGwhPYVCtJRd(pointerEventData);
					return;
				}
				this.xNqkhGdbnLHbPCUyFWljVviIHVmu();
			}
		}

		// Token: 0x060029E4 RID: 10724 RVA: 0x00099EC0 File Offset: 0x000980C0
		private void yjOcaWVPyxCODxIPrxqCVdFgBVsl()
		{
			if (this._touchPadMode == TouchPad.TouchPadMode.VectorFromCenter)
			{
				Graphic targetGraphic = base.targetGraphic;
				RectTransform rectTransform = (targetGraphic != null) ? (targetGraphic.transform as RectTransform) : base.ZlJFgENigMndbNzNAXlaJMlysRs;
				this._currentCenter = rectTransform.TransformPoint(rectTransform.rect.center);
				this._currentCenter = RectTransformUtility.WorldToScreenPoint(base.hlsJgfPNbiEXjyoptqyskoeItXRG.worldCamera, this._currentCenter);
			}
			if (!this.hasPointer || !TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq))
			{
				return;
			}
			Vector3 vector = TouchInteractable.ZUnrIQphLGwhXswkmMnPlWvrfTLc(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq);
			Vector2 vector2;
			if (this._touchPadMode == TouchPad.TouchPadMode.ScreenPosition)
			{
				vector2 = vector;
			}
			else
			{
				if (this._touchPadMode == TouchPad.TouchPadMode.Delta)
				{
					this._currentCenter = this._previousTouchPosition;
				}
				vector2 = new Vector2(vector.x - this._currentCenter.x, vector.y - this._currentCenter.y);
			}
			vector2 = this.EXXHYdyNfYWKizBfJSAtwzmLbJkw(vector2);
			this._axis2D.SetRawValue(vector2.x, vector2.y);
			if (this._touchPadMode == TouchPad.TouchPadMode.Delta)
			{
				this._smoothDelta.PmunlQIOXrizYmRzaHafCobjXKaw(vector2.x, vector2.y);
			}
			this._previousTouchPosition = vector;
		}

		// Token: 0x060029E5 RID: 10725 RVA: 0x0009A000 File Offset: 0x00098200
		private void rMVGbOeWhYFRNjgAmsrcGXfFkxYn()
		{
			if (this._touchPadMode != TouchPad.TouchPadMode.Delta || !this._useInertia)
			{
				return;
			}
			if (this.hasPointer)
			{
				return;
			}
			Vector2 rawValue = this._axis2D.rawValue;
			float smoothDeltaTime = Time.smoothDeltaTime;
			float num = Mathf.Lerp(rawValue.x, 0f, this._inertiaFriction * smoothDeltaTime);
			float num2 = Mathf.Lerp(rawValue.y, 0f, this._inertiaFriction * smoothDeltaTime);
			if (MathTools.IsNearZero(num, 0.0001f))
			{
				num = 0f;
			}
			if (MathTools.IsNearZero(num2, 0.0001f))
			{
				num2 = 0f;
			}
			this._axis2D.SetRawValue(num, num2);
		}

		// Token: 0x060029E6 RID: 10726 RVA: 0x0009A09C File Offset: 0x0009829C
		private void OnmzWserPNqVjUObakICZqUFereu()
		{
			if (!this.hasPointer)
			{
				return;
			}
			Vector2 vector = TouchInteractable.ZUnrIQphLGwhXswkmMnPlWvrfTLc(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq);
			this.joDYuIkcJrstBsPTEjQlkrKEShiI(ref vector);
			this.QOuooPJJykKELYXEtQoqPrLNXvAK(ref vector);
		}

		// Token: 0x060029E7 RID: 10727 RVA: 0x0009A0D4 File Offset: 0x000982D4
		private void joDYuIkcJrstBsPTEjQlkrKEShiI(ref Vector2 A_1)
		{
			if (!this._allowTap || !this._isEligibleForTap)
			{
				return;
			}
			if ((this._tapTimeout > 0f && Time.realtimeSinceStartup - this._touchStartTime > this._tapTimeout) || (this._tapDistanceLimit >= 0 && Vector2.Distance(this._touchStartPosition, A_1) > (float)this._tapDistanceLimit))
			{
				this._isEligibleForTap = false;
			}
		}

		// Token: 0x060029E8 RID: 10728 RVA: 0x0009A140 File Offset: 0x00098340
		private void QOuooPJJykKELYXEtQoqPrLNXvAK(ref Vector2 A_1)
		{
			if (!this._allowPress || !this._isEligibleForPress)
			{
				return;
			}
			if (this._pressDistanceLimit >= 0 && Vector2.Distance(this._touchStartPosition, A_1) > (float)this._pressDistanceLimit)
			{
				this._isEligibleForPress = false;
				this.hfxOmMMNqSKuwfcxdVVadXUqBvmH(false);
				return;
			}
			if (this._pressStartDelay > 0f && Time.realtimeSinceStartup - this._touchStartTime < this._pressStartDelay)
			{
				return;
			}
			this.hfxOmMMNqSKuwfcxdVVadXUqBvmH(true);
		}

		// Token: 0x060029E9 RID: 10729 RVA: 0x0009A1BC File Offset: 0x000983BC
		private void CPJjKigeiNDyLrfYYsbJmYSNEHFq()
		{
			if (this._touchPadMode == TouchPad.TouchPadMode.Delta)
			{
				Vector2 value = this._axis2D.value;
				Vector2 valuePrev = this._axis2D.valuePrev;
				if (value.x != 0f || value.y != 0f || valuePrev.x != 0f || valuePrev.y != 0f)
				{
					this._onValueChanged.Invoke(this._axis2D.value);
					return;
				}
			}
			else
			{
				Vector2 valueDelta = this._axis2D.valueDelta;
				if (valueDelta.x != 0f || valueDelta.y != 0f)
				{
					this._onValueChanged.Invoke(this._axis2D.value);
				}
			}
		}

		// Token: 0x060029EA RID: 10730 RVA: 0x0009A270 File Offset: 0x00098470
		private Vector2 EXXHYdyNfYWKizBfJSAtwzmLbJkw(Vector2 A_1)
		{
			switch (this._valueFormat)
			{
			case TouchPad.ValueFormat.Pixels:
				break;
			case TouchPad.ValueFormat.Screen:
				A_1.x /= (float)Screen.width;
				A_1.y /= (float)Screen.height;
				break;
			case TouchPad.ValueFormat.Physical:
			{
				float num = Screen.dpi;
				if (num < 10f)
				{
					num = 96f;
				}
				A_1 = A_1 / num * 100f;
				break;
			}
			case TouchPad.ValueFormat.Direction:
				A_1.Normalize();
				break;
			default:
				throw new NotImplementedException();
			}
			return A_1;
		}

		// Token: 0x060029EB RID: 10731 RVA: 0x000201CE File Offset: 0x0001E3CE
		private void hfxOmMMNqSKuwfcxdVVadXUqBvmH(bool A_1)
		{
			if (A_1 == this._pressValue)
			{
				return;
			}
			this._pressValue = A_1;
			if (A_1)
			{
				this._onPressDown.Invoke();
				return;
			}
			this._onPressUp.Invoke();
		}

		// Token: 0x060029EC RID: 10732 RVA: 0x0009A2FC File Offset: 0x000984FC
		private void vCmOJUPlISGSHWLErZlTXxeuYiNe(PointerEventData A_1)
		{
			if (this.hasPointer && !this.oKUHlRDiyTbSYWiIzaDrXiRsqZPl(A_1.pointerId))
			{
				return;
			}
			if (base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && base.IsInteractable())
			{
				this.RdgacmxqGBjFtpZlKkNdfgjApTS(A_1.pointerId, A_1.pressPosition);
			}
			base.OnPointerDown(A_1);
		}

		// Token: 0x060029ED RID: 10733 RVA: 0x000201FB File Offset: 0x0001E3FB
		private void OZzoDjomSaFtVkibTKDQGGafCYijA(PointerEventData A_1)
		{
			if (this.hasPointer && !this.oKUHlRDiyTbSYWiIzaDrXiRsqZPl(A_1.pointerId))
			{
				return;
			}
			if (TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq))
			{
				return;
			}
			this.xNqkhGdbnLHbPCUyFWljVviIHVmu();
			base.OnPointerUp(A_1);
		}

		// Token: 0x060029EE RID: 10734 RVA: 0x0009A34C File Offset: 0x0009854C
		private void sKdVSWqZtsWibguFInazpOmvYihb(PointerEventData A_1)
		{
			if (this.hasPointer && !this.oKUHlRDiyTbSYWiIzaDrXiRsqZPl(A_1.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1.pointerId);
			bool flag2 = false;
			if (this._activateOnSwipeIn && base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && base.IsInteractable() && (!flag || TouchInteractable.ygyrytQEEfuBWjVlJlbtaHrKeHYjA(base.allowedMouseButtons)) && !this.bNkmGtrSyHVkUxSFqQVYqlrdxTOA)
			{
				if (flag)
				{
					int realMousePointerId;
					if (TouchInteractable.fViPIDXJiFoyaUCiJDHKdMbSRRWeA(base.allowedMouseButtons, out realMousePointerId))
					{
						this._realMousePointerId = realMousePointerId;
					}
					else
					{
						this._realMousePointerId = A_1.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(A_1);
			if (flag2)
			{
				GameObject gameObject = base.gameObject;
				PointerEventData pointerEventData = this.hxhrjfVnYfwHgxYOjYPbtUcgpzKc((this._realMousePointerId != int.MinValue) ? this._realMousePointerId : A_1.pointerId, gameObject);
				if (pointerEventData != null)
				{
					this.vCmOJUPlISGSHWLErZlTXxeuYiNe(pointerEventData);
					if (this.bNkmGtrSyHVkUxSFqQVYqlrdxTOA)
					{
						this._pointerDownIsFake = true;
					}
				}
			}
			this.NMgPdgSLNKjVBrRjdgKlKtQActXT = true;
		}

		// Token: 0x060029EF RID: 10735 RVA: 0x0009A434 File Offset: 0x00098634
		private void ZUeXtNXTlJJFIMXSELrydOkqvBRE(PointerEventData A_1)
		{
			if (this.hasPointer && !this.oKUHlRDiyTbSYWiIzaDrXiRsqZPl(A_1.pointerId))
			{
				base.OnPointerExit(A_1);
				return;
			}
			if (!this.stayActiveOnSwipeOut && this.bNkmGtrSyHVkUxSFqQVYqlrdxTOA)
			{
				this.xNqkhGdbnLHbPCUyFWljVviIHVmu();
			}
			base.OnPointerExit(A_1);
			this.NMgPdgSLNKjVBrRjdgKlKtQActXT = false;
		}

		// Token: 0x060029F0 RID: 10736 RVA: 0x0009A484 File Offset: 0x00098684
		private void RdgacmxqGBjFtpZlKkNdfgjApTS(int A_1, Vector2 A_2)
		{
			this._pointerId = A_1;
			this.bNkmGtrSyHVkUxSFqQVYqlrdxTOA = true;
			this._isEligibleForTap = true;
			this._isEligibleForPress = true;
			if (this._touchPadMode != TouchPad.TouchPadMode.VectorFromCenter)
			{
				this._currentCenter = A_2;
			}
			if (this._touchPadMode == TouchPad.TouchPadMode.Delta)
			{
				this._previousTouchPosition = A_2;
			}
			this._touchStartTime = Time.realtimeSinceStartup;
			this._touchStartPosition = A_2;
		}

		// Token: 0x060029F1 RID: 10737 RVA: 0x0009A4E4 File Offset: 0x000986E4
		private void xNqkhGdbnLHbPCUyFWljVviIHVmu()
		{
			bool flag = this._allowTap && this._isEligibleForTap;
			this.IlmyxrMbxLLonMoybNEfRcOCLBNJ();
			this.bNkmGtrSyHVkUxSFqQVYqlrdxTOA = false;
			if (this._useInertia && this._touchPadMode == TouchPad.TouchPadMode.Delta)
			{
				this._axis2D.SetRawValue(this._smoothDelta.SKwCdfjtgPqfGDGDUhBFRtVfFKMl());
			}
			else
			{
				this._axis2D.SetRawValue(0f, 0f);
			}
			this.hfxOmMMNqSKuwfcxdVVadXUqBvmH(false);
			this._isEligibleForTap = false;
			this._isEligibleForPress = false;
			if (flag)
			{
				this._lastTapFrame = Time.frameCount + 1;
				this._onTap.Invoke();
			}
		}

		// Token: 0x060029F2 RID: 10738 RVA: 0x0002022F File Offset: 0x0001E42F
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
			this.OZzoDjomSaFtVkibTKDQGGafCYijA(eventData);
		}

		// Token: 0x060029F3 RID: 10739 RVA: 0x00020256 File Offset: 0x0001E456
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
			this.vCmOJUPlISGSHWLErZlTXxeuYiNe(eventData);
		}

		// Token: 0x060029F4 RID: 10740 RVA: 0x0002027D File Offset: 0x0001E47D
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
			this.sKdVSWqZtsWibguFInazpOmvYihb(eventData);
		}

		// Token: 0x060029F5 RID: 10741 RVA: 0x000202A4 File Offset: 0x0001E4A4
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
			this.ZUeXtNXTlJJFIMXSELrydOkqvBRE(eventData);
		}

		// Token: 0x060029F6 RID: 10742 RVA: 0x000202CB File Offset: 0x0001E4CB
		private void IlmyxrMbxLLonMoybNEfRcOCLBNJ()
		{
			this._pointerId = int.MinValue;
			this._realMousePointerId = int.MinValue;
		}

		// Token: 0x060029F7 RID: 10743 RVA: 0x0009A57C File Offset: 0x0009877C
		private bool oKUHlRDiyTbSYWiIzaDrXiRsqZPl(int A_1)
		{
			return A_1 != int.MinValue && this._pointerId != int.MinValue && (this._pointerId == A_1 || (TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1) && this._realMousePointerId != int.MinValue && A_1 == this._realMousePointerId));
		}

		// Token: 0x060029F8 RID: 10744 RVA: 0x0009A5D0 File Offset: 0x000987D0
		private PointerEventData hxhrjfVnYfwHgxYOjYPbtUcgpzKc(int A_1, GameObject A_2)
		{
			PointerEventData pointerEventData = this.nEzEbKwKsVWJWDgpIPpEEUJCpVos(A_1);
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

		// Token: 0x060029F9 RID: 10745 RVA: 0x0009A798 File Offset: 0x00098998
		private PointerEventData rltQCeZZSVfZHHEHmDOjSTNOvxoP(int A_1, GameObject A_2)
		{
			PointerEventData pointerEventData = this.nEzEbKwKsVWJWDgpIPpEEUJCpVos(A_1);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.ZUnrIQphLGwhXswkmMnPlWvrfTLc(A_1);
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.dragging = true;
			pointerEventData.pointerDrag = A_2;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			return pointerEventData;
		}

		// Token: 0x060029FA RID: 10746 RVA: 0x0009A800 File Offset: 0x00098A00
		private PointerEventData rdUGRAerPMZZpqsQjNOvzzXastUE(int A_1)
		{
			PointerEventData pointerEventData = this.nEzEbKwKsVWJWDgpIPpEEUJCpVos(A_1);
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

		// Token: 0x060029FB RID: 10747 RVA: 0x000202E3 File Offset: 0x0001E4E3
		private void YUUxJnPZJmCITQiGDGwhPYVCtJRd(PointerEventData A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.OnPointerUp(A_1);
			this.rdUGRAerPMZZpqsQjNOvzzXastUE(this.irhRZvOoFfQUfIZNFwqKsVXMbsDq);
		}

		// Token: 0x060029FC RID: 10748 RVA: 0x0009A894 File Offset: 0x00098A94
		private PointerEventData nEzEbKwKsVWJWDgpIPpEEUJCpVos(int A_1)
		{
			if (A_1 == -2147483648)
			{
				return null;
			}
			if (this.__fakePointerEventData == null)
			{
				this.__fakePointerEventData = new Dictionary<int, PointerEventData>();
			}
			PointerEventData pointerEventData;
			if (!this.__fakePointerEventData.TryGetValue(A_1, out pointerEventData))
			{
				pointerEventData = new PointerEventData(EventSystem.current);
				pointerEventData.pointerId = A_1;
				this.__fakePointerEventData.Add(A_1, pointerEventData);
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

		// Token: 0x04001802 RID: 6146
		private const int SMOOTH_DELTA_FRAME_COUNT = 3;

		// Token: 0x04001803 RID: 6147
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		// Token: 0x04001804 RID: 6148
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		// Token: 0x04001805 RID: 6149
		[Tooltip("The Custom Controller element that will receive input values from touch pad taps.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		// Token: 0x04001806 RID: 6150
		[Tooltip("The Custom Controller element that will receive input values from touch pad presses.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _pressCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		// Token: 0x04001807 RID: 6151
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPad.AxisDirection _axesToUse;

		// Token: 0x04001808 RID: 6152
		[Tooltip("The mode of the touch pad.\n\nDelta - Returns the change in position of the touch from the previous to the current frame.\n\nScreen Position - Returns the absolute position of the touch  on the screen.\n\nVector From Center - Returns a vector from the center of the Touch Pad to the current touch position.\n\nVector From Initial Touch - Returns a vector from the intial touch position to the current touch position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPad.TouchPadMode _touchPadMode;

		// Token: 0x04001809 RID: 6153
		[Tooltip("The format of the resulting data generated by the touch pad.\n\nPixels - Screen pixels.\n\nScreen - The proportion of the value to screen size in the corresponding dimension. 1 unit = 1 screen length (width for X, height for Y).\n\nPhysical - 1 unit = 1/100th of an inch. The resulting value will be consistent across different screen resolutions and sizes. IMPORTANT: This relies on the value returned by UnityEngine.Screen.dpi. If the device does not return a value, a reference resolution of 96 dpi will be used.\n\nDirection - A normalized direction vector.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPad.ValueFormat _valueFormat;

		// Token: 0x0400180A RID: 6154
		[Tooltip("If enabled, when swiped and released, the value will slowly fall toward zero based on the Friction value. This only has an effect if Touch Pad Mode is set to Position Delta.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useInertia;

		// Token: 0x0400180B RID: 6155
		[Tooltip("Determines how quickly a swipe value will fall toward zero when Use Inertia is enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, 3.4028235E+38f)]
		private float _inertiaFriction = 3f;

		// Token: 0x0400180C RID: 6156
		[Tooltip("If true, the touch pad can be activated by a touch swipe that began in an area outside the touch pad region. If false, the touch pad can only be activated by a direct touch.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		// Token: 0x0400180D RID: 6157
		[Tooltip("If true, the touch pad will stay engaged even if the touch that activated it moves outside the touch pad region. If false, the touch pad will be released once the touch that activated it moves outside the touch pad region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		// Token: 0x0400180E RID: 6158
		[Tooltip("Should taps on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		// Token: 0x0400180F RID: 6159
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, 3.4028235E+38f)]
		private float _tapTimeout = 0.25f;

		// Token: 0x04001810 RID: 6160
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, 2147483647)]
		private int _tapDistanceLimit = 10;

		// Token: 0x04001811 RID: 6161
		[Tooltip("Should presses (continual press like a button) on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowPress;

		// Token: 0x04001812 RID: 6162
		[Tooltip("Time the touch pad must be touched before it will be considered a press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _pressStartDelay = 0.1f;

		// Token: 0x04001813 RID: 6163
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a press. Any movement beyond this value will cancel the press. [-1 = no limit]")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, 2147483647)]
		private int _pressDistanceLimit = 10;

		// Token: 0x04001814 RID: 6164
		[Tooltip("If enabled, the control will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime;

		// Token: 0x04001815 RID: 6165
		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis2D _axis2D = StandaloneAxis2D.CreateRelative();

		// Token: 0x04001816 RID: 6166
		[Tooltip("Event sent when the value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPad.ValueChangedEventHandler _onValueChanged = new TouchPad.ValueChangedEventHandler();

		// Token: 0x04001817 RID: 6167
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPad.TapEventHandler _onTap = new TouchPad.TapEventHandler();

		// Token: 0x04001818 RID: 6168
		[Tooltip("Event sent when the touch pad is initally pressed. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPad.PressDownEventHandler _onPressDown = new TouchPad.PressDownEventHandler();

		// Token: 0x04001819 RID: 6169
		[Tooltip("Event sent when the touch pad is released after a press. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPad.PressUpEventHandler _onPressUp = new TouchPad.PressUpEventHandler();

		// Token: 0x0400181A RID: 6170
		private bool _useXAxis;

		// Token: 0x0400181B RID: 6171
		private bool _useYAxis;

		// Token: 0x0400181C RID: 6172
		private int _pointerId = int.MinValue;

		// Token: 0x0400181D RID: 6173
		private int _realMousePointerId = int.MinValue;

		// Token: 0x0400181E RID: 6174
		[NonSerialized]
		private bool bNkmGtrSyHVkUxSFqQVYqlrdxTOA;

		// Token: 0x0400181F RID: 6175
		[NonSerialized]
		private bool NMgPdgSLNKjVBrRjdgKlKtQActXT;

		// Token: 0x04001820 RID: 6176
		private bool _pointerDownIsFake;

		// Token: 0x04001821 RID: 6177
		private Vector2 _touchStartPosition;

		// Token: 0x04001822 RID: 6178
		private float _touchStartTime;

		// Token: 0x04001823 RID: 6179
		private Vector3 _currentCenter;

		// Token: 0x04001824 RID: 6180
		private Vector2 _previousTouchPosition;

		// Token: 0x04001825 RID: 6181
		private int _lastTapFrame = -1;

		// Token: 0x04001826 RID: 6182
		private bool _isEligibleForTap;

		// Token: 0x04001827 RID: 6183
		private bool _isEligibleForPress;

		// Token: 0x04001828 RID: 6184
		private bool _pressValue;

		// Token: 0x04001829 RID: 6185
		private TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG _smoothDelta = new TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG(3);

		// Token: 0x0400182A RID: 6186
		private Dictionary<int, PointerEventData> __fakePointerEventData;

		// Token: 0x0200040A RID: 1034
		public enum AxisDirection
		{
			// Token: 0x0400182C RID: 6188
			Both,
			// Token: 0x0400182D RID: 6189
			Horizontal,
			// Token: 0x0400182E RID: 6190
			Vertical
		}

		// Token: 0x0200040B RID: 1035
		public enum TouchPadMode
		{
			// Token: 0x04001830 RID: 6192
			Delta,
			// Token: 0x04001831 RID: 6193
			ScreenPosition,
			// Token: 0x04001832 RID: 6194
			VectorFromCenter,
			// Token: 0x04001833 RID: 6195
			VectorFromInitialTouch
		}

		// Token: 0x0200040C RID: 1036
		public enum ValueFormat
		{
			// Token: 0x04001835 RID: 6197
			Pixels,
			// Token: 0x04001836 RID: 6198
			Screen,
			// Token: 0x04001837 RID: 6199
			Physical,
			// Token: 0x04001838 RID: 6200
			Direction
		}

		// Token: 0x0200040D RID: 1037
		private class quhtbzHrsKPEZIreILLYgsMPMXEG
		{
			// Token: 0x060029FD RID: 10749 RVA: 0x000202FD File Offset: 0x0001E4FD
			public quhtbzHrsKPEZIreILLYgsMPMXEG(int A_1)
			{
				if (A_1 < 2)
				{
					throw new ArgumentOutOfRangeException("maxSmoothFrames must be >= 2");
				}
				this.ORIAhlDkFvxseERJJmSLmomsqbmxA = A_1;
				this.xALuBobrVBDrgkgRSaRLdbqclskk = new TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG.LLwdJQIXFILsUtrmtaipKNVNTcQz[A_1];
				ArrayTools.Populate<TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG.LLwdJQIXFILsUtrmtaipKNVNTcQz>(this.xALuBobrVBDrgkgRSaRLdbqclskk);
			}

			// Token: 0x060029FE RID: 10750 RVA: 0x0009A928 File Offset: 0x00098B28
			public void PmunlQIOXrizYmRzaHafCobjXKaw(float A_1, float A_2)
			{
				uint currentFrame = ReInput.currentFrame;
				if (this.jTzAJsGRbBatocbdoQoeanBeSZOZb >= 0 && this.xALuBobrVBDrgkgRSaRLdbqclskk[this.jTzAJsGRbBatocbdoQoeanBeSZOZb].sgOoPkQaUYUYPALkABhlsWFmQgQV == currentFrame)
				{
					return;
				}
				this.wzYSgozXcDcPjCRhXBkKQzDRxKHK();
				TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG.LLwdJQIXFILsUtrmtaipKNVNTcQz llwdJQIXFILsUtrmtaipKNVNTcQz = this.xALuBobrVBDrgkgRSaRLdbqclskk[this.jTzAJsGRbBatocbdoQoeanBeSZOZb];
				llwdJQIXFILsUtrmtaipKNVNTcQz.xjvAIcSSNlGApEDNOulkEUsjuntHA = A_1;
				llwdJQIXFILsUtrmtaipKNVNTcQz.hBSSVbyNHXDziFVqDbpnxjJleGqEA = A_2;
				llwdJQIXFILsUtrmtaipKNVNTcQz.sgOoPkQaUYUYPALkABhlsWFmQgQV = currentFrame;
			}

			// Token: 0x060029FF RID: 10751 RVA: 0x0009A984 File Offset: 0x00098B84
			public Vector2 SKwCdfjtgPqfGDGDUhBFRtVfFKMl()
			{
				if (this.jTzAJsGRbBatocbdoQoeanBeSZOZb < 0)
				{
					return default(Vector2);
				}
				int num = this.jTzAJsGRbBatocbdoQoeanBeSZOZb;
				TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG.LLwdJQIXFILsUtrmtaipKNVNTcQz llwdJQIXFILsUtrmtaipKNVNTcQz = this.xALuBobrVBDrgkgRSaRLdbqclskk[num];
				Vector2 result = new Vector2(llwdJQIXFILsUtrmtaipKNVNTcQz.xjvAIcSSNlGApEDNOulkEUsjuntHA, llwdJQIXFILsUtrmtaipKNVNTcQz.hBSSVbyNHXDziFVqDbpnxjJleGqEA);
				uint sgOoPkQaUYUYPALkABhlsWFmQgQV = llwdJQIXFILsUtrmtaipKNVNTcQz.sgOoPkQaUYUYPALkABhlsWFmQgQV;
				int num2 = num;
				int num3 = 1;
				while ((num2 = this.BLRnqwmCtsRaGIteIjlJpVheOyxU(num2, this.ORIAhlDkFvxseERJJmSLmomsqbmxA)) != num)
				{
					TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG.LLwdJQIXFILsUtrmtaipKNVNTcQz llwdJQIXFILsUtrmtaipKNVNTcQz2 = this.xALuBobrVBDrgkgRSaRLdbqclskk[num2];
					if (!TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG.kmDqeXNWHUnLUIjohWARsjCzbRZT(llwdJQIXFILsUtrmtaipKNVNTcQz2.sgOoPkQaUYUYPALkABhlsWFmQgQV, sgOoPkQaUYUYPALkABhlsWFmQgQV))
					{
						break;
					}
					result.x += llwdJQIXFILsUtrmtaipKNVNTcQz2.xjvAIcSSNlGApEDNOulkEUsjuntHA;
					result.y += llwdJQIXFILsUtrmtaipKNVNTcQz2.hBSSVbyNHXDziFVqDbpnxjJleGqEA;
					sgOoPkQaUYUYPALkABhlsWFmQgQV = llwdJQIXFILsUtrmtaipKNVNTcQz2.sgOoPkQaUYUYPALkABhlsWFmQgQV;
					num3++;
				}
				if (num3 > 0)
				{
					result.x /= (float)num3;
					result.y /= (float)num3;
				}
				return result;
			}

			// Token: 0x06002A00 RID: 10752 RVA: 0x00020339 File Offset: 0x0001E539
			private void wzYSgozXcDcPjCRhXBkKQzDRxKHK()
			{
				this.jTzAJsGRbBatocbdoQoeanBeSZOZb = TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG.OmvCUGAYudnfALryOZBxykTHSsaV(this.jTzAJsGRbBatocbdoQoeanBeSZOZb, this.ORIAhlDkFvxseERJJmSLmomsqbmxA);
			}

			// Token: 0x06002A01 RID: 10753 RVA: 0x00020352 File Offset: 0x0001E552
			private static int OmvCUGAYudnfALryOZBxykTHSsaV(int A_0, int A_1)
			{
				if (A_0 >= A_1 - 1)
				{
					return 0;
				}
				return ++A_0;
			}

			// Token: 0x06002A02 RID: 10754 RVA: 0x00020362 File Offset: 0x0001E562
			private int BLRnqwmCtsRaGIteIjlJpVheOyxU(int A_1, int A_2)
			{
				if (A_1 > 0)
				{
					return --A_1;
				}
				return A_2 - 1;
			}

			// Token: 0x06002A03 RID: 10755 RVA: 0x00020372 File Offset: 0x0001E572
			private static bool kmDqeXNWHUnLUIjohWARsjCzbRZT(uint A_0, uint A_1)
			{
				if (A_1 == 0U)
				{
					return A_0 == uint.MaxValue;
				}
				return A_0 == A_1 - 1U;
			}

			// Token: 0x04001839 RID: 6201
			private int ORIAhlDkFvxseERJJmSLmomsqbmxA;

			// Token: 0x0400183A RID: 6202
			private TouchPad.quhtbzHrsKPEZIreILLYgsMPMXEG.LLwdJQIXFILsUtrmtaipKNVNTcQz[] xALuBobrVBDrgkgRSaRLdbqclskk;

			// Token: 0x0400183B RID: 6203
			private int jTzAJsGRbBatocbdoQoeanBeSZOZb = -1;

			// Token: 0x0200040E RID: 1038
			private class LLwdJQIXFILsUtrmtaipKNVNTcQz
			{
				// Token: 0x0400183C RID: 6204
				public float xjvAIcSSNlGApEDNOulkEUsjuntHA;

				// Token: 0x0400183D RID: 6205
				public float hBSSVbyNHXDziFVqDbpnxjJleGqEA;

				// Token: 0x0400183E RID: 6206
				public uint sgOoPkQaUYUYPALkABhlsWFmQgQV;
			}
		}

		// Token: 0x0200040F RID: 1039
		[Serializable]
		public class ValueChangedEventHandler : UnityEvent<Vector2>
		{
		}

		// Token: 0x02000410 RID: 1040
		[Serializable]
		public class TapEventHandler : UnityEvent
		{
		}

		// Token: 0x02000411 RID: 1041
		[Serializable]
		public class PressDownEventHandler : UnityEvent
		{
		}

		// Token: 0x02000412 RID: 1042
		[Serializable]
		public class PressUpEventHandler : UnityEvent
		{
		}
	}
}
