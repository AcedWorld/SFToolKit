using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
	// Token: 0x020003F9 RID: 1017
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Touch Joystick")]
	[Serializable]
	public sealed class TouchJoystick : TouchInteractable
	{
		// Token: 0x1700099C RID: 2460
		// (get) Token: 0x060028F9 RID: 10489 RVA: 0x0001F142 File Offset: 0x0001D342
		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement
		{
			get
			{
				return this._horizontalAxisCustomControllerElement;
			}
		}

		// Token: 0x1700099D RID: 2461
		// (get) Token: 0x060028FA RID: 10490 RVA: 0x0001F14A File Offset: 0x0001D34A
		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement
		{
			get
			{
				return this._verticalAxisCustomControllerElement;
			}
		}

		// Token: 0x1700099E RID: 2462
		// (get) Token: 0x060028FB RID: 10491 RVA: 0x0001F152 File Offset: 0x0001D352
		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement
		{
			get
			{
				return this._tapCustomControllerElement;
			}
		}

		// Token: 0x1700099F RID: 2463
		// (get) Token: 0x060028FC RID: 10492 RVA: 0x0001F15A File Offset: 0x0001D35A
		// (set) Token: 0x060028FD RID: 10493 RVA: 0x0001F162 File Offset: 0x0001D362
		public RectTransform stickTransform
		{
			get
			{
				return this._stickTransform;
			}
			set
			{
				if (this._stickTransform == value)
				{
					return;
				}
				this._stickTransform = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A0 RID: 2464
		// (get) Token: 0x060028FE RID: 10494 RVA: 0x0001F180 File Offset: 0x0001D380
		// (set) Token: 0x060028FF RID: 10495 RVA: 0x0001F188 File Offset: 0x0001D388
		public TouchJoystick.JoystickMode joystickMode
		{
			get
			{
				return this._joystickMode;
			}
			set
			{
				if (this._joystickMode == value)
				{
					return;
				}
				this._joystickMode = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x06002900 RID: 10496 RVA: 0x0001F1A1 File Offset: 0x0001D3A1
		// (set) Token: 0x06002901 RID: 10497 RVA: 0x0001F1A9 File Offset: 0x0001D3A9
		public float digitalModeDeadZone
		{
			get
			{
				return this._digitalModeDeadZone;
			}
			set
			{
				value = MathTools.Clamp01(value);
				if (this._digitalModeDeadZone == value)
				{
					return;
				}
				this._digitalModeDeadZone = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x06002902 RID: 10498 RVA: 0x0001F1CA File Offset: 0x0001D3CA
		// (set) Token: 0x06002903 RID: 10499 RVA: 0x0001F1D2 File Offset: 0x0001D3D2
		public float stickRange
		{
			get
			{
				return this._stickRange;
			}
			set
			{
				value = MathTools.Clamp(value, 1f, 1000f);
				if (this._stickRange == value)
				{
					return;
				}
				this._stickRange = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A3 RID: 2467
		// (get) Token: 0x06002904 RID: 10500 RVA: 0x0001F1FD File Offset: 0x0001D3FD
		// (set) Token: 0x06002905 RID: 10501 RVA: 0x0001F205 File Offset: 0x0001D405
		public bool scaleStickRange
		{
			get
			{
				return this._scaleStickRange;
			}
			set
			{
				if (this._scaleStickRange == value)
				{
					return;
				}
				this._scaleStickRange = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x06002906 RID: 10502 RVA: 0x0001F21E File Offset: 0x0001D41E
		// (set) Token: 0x06002907 RID: 10503 RVA: 0x0001F226 File Offset: 0x0001D426
		private TouchJoystick.StickBounds aRAiibDdlAjMhDuOmFrVgnXFvSUMB
		{
			get
			{
				return this._stickBounds;
			}
			set
			{
				if (this._stickBounds == value)
				{
					return;
				}
				this._stickBounds = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x06002908 RID: 10504 RVA: 0x0001F23F File Offset: 0x0001D43F
		// (set) Token: 0x06002909 RID: 10505 RVA: 0x0001F247 File Offset: 0x0001D447
		public TouchJoystick.AxisDirection axesToUse
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
				this.hJvsUWhvoVCHUEDgmUBwEoZIHnHI(value);
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x0600290A RID: 10506 RVA: 0x0001F260 File Offset: 0x0001D460
		// (set) Token: 0x0600290B RID: 10507 RVA: 0x0001F268 File Offset: 0x0001D468
		public TouchJoystick.SnapDirections snapDirections
		{
			get
			{
				return this._snapDirections;
			}
			set
			{
				if (this._snapDirections == value)
				{
					return;
				}
				this._snapDirections = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x0600290C RID: 10508 RVA: 0x0001F281 File Offset: 0x0001D481
		// (set) Token: 0x0600290D RID: 10509 RVA: 0x0001F289 File Offset: 0x0001D489
		public bool snapStickToTouch
		{
			get
			{
				return this._snapStickToTouch;
			}
			set
			{
				if (this._snapStickToTouch == value)
				{
					return;
				}
				this._snapStickToTouch = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A8 RID: 2472
		// (get) Token: 0x0600290E RID: 10510 RVA: 0x0001F2A2 File Offset: 0x0001D4A2
		// (set) Token: 0x0600290F RID: 10511 RVA: 0x0001F2AA File Offset: 0x0001D4AA
		public bool centerStickOnRelease
		{
			get
			{
				return this._centerStickOnRelease;
			}
			set
			{
				if (this._centerStickOnRelease == value)
				{
					return;
				}
				this._centerStickOnRelease = value;
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009A9 RID: 2473
		// (get) Token: 0x06002910 RID: 10512 RVA: 0x0001F2C3 File Offset: 0x0001D4C3
		// (set) Token: 0x06002911 RID: 10513 RVA: 0x0001F2CB File Offset: 0x0001D4CB
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

		// Token: 0x170009AA RID: 2474
		// (get) Token: 0x06002912 RID: 10514 RVA: 0x0001F2E4 File Offset: 0x0001D4E4
		// (set) Token: 0x06002913 RID: 10515 RVA: 0x0001F2F6 File Offset: 0x0001D4F6
		public bool stayActiveOnSwipeOut
		{
			get
			{
				return this.KgXPKbQwatRYDrLvkkgumTpDDmmU() || this._stayActiveOnSwipeOut;
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

		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x06002914 RID: 10516 RVA: 0x0001F30F File Offset: 0x0001D50F
		// (set) Token: 0x06002915 RID: 10517 RVA: 0x0001F317 File Offset: 0x0001D517
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

		// Token: 0x170009AC RID: 2476
		// (get) Token: 0x06002916 RID: 10518 RVA: 0x0001F330 File Offset: 0x0001D530
		// (set) Token: 0x06002917 RID: 10519 RVA: 0x0001F338 File Offset: 0x0001D538
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

		// Token: 0x170009AD RID: 2477
		// (get) Token: 0x06002918 RID: 10520 RVA: 0x0001F35E File Offset: 0x0001D55E
		// (set) Token: 0x06002919 RID: 10521 RVA: 0x0001F366 File Offset: 0x0001D566
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

		// Token: 0x170009AE RID: 2478
		// (get) Token: 0x0600291A RID: 10522 RVA: 0x0001F388 File Offset: 0x0001D588
		// (set) Token: 0x0600291B RID: 10523 RVA: 0x0001F390 File Offset: 0x0001D590
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

		// Token: 0x170009AF RID: 2479
		// (get) Token: 0x0600291C RID: 10524 RVA: 0x0001F3AE File Offset: 0x0001D5AE
		// (set) Token: 0x0600291D RID: 10525 RVA: 0x0001F3B6 File Offset: 0x0001D5B6
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

		// Token: 0x170009B0 RID: 2480
		// (get) Token: 0x0600291E RID: 10526 RVA: 0x0001F3CF File Offset: 0x0001D5CF
		// (set) Token: 0x0600291F RID: 10527 RVA: 0x0001F3D7 File Offset: 0x0001D5D7
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

		// Token: 0x170009B1 RID: 2481
		// (get) Token: 0x06002920 RID: 10528 RVA: 0x0001F3F0 File Offset: 0x0001D5F0
		// (set) Token: 0x06002921 RID: 10529 RVA: 0x0001F3F8 File Offset: 0x0001D5F8
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

		// Token: 0x170009B2 RID: 2482
		// (get) Token: 0x06002922 RID: 10530 RVA: 0x0001F411 File Offset: 0x0001D611
		// (set) Token: 0x06002923 RID: 10531 RVA: 0x0001F419 File Offset: 0x0001D619
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

		// Token: 0x170009B3 RID: 2483
		// (get) Token: 0x06002924 RID: 10532 RVA: 0x0001F432 File Offset: 0x0001D632
		// (set) Token: 0x06002925 RID: 10533 RVA: 0x0001F43A File Offset: 0x0001D63A
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

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06002926 RID: 10534 RVA: 0x0001F453 File Offset: 0x0001D653
		// (set) Token: 0x06002927 RID: 10535 RVA: 0x0001F45B File Offset: 0x0001D65B
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

		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06002928 RID: 10536 RVA: 0x0001F486 File Offset: 0x0001D686
		// (set) Token: 0x06002929 RID: 10537 RVA: 0x0001F48E File Offset: 0x0001D68E
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

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x0600292A RID: 10538 RVA: 0x0001F4A7 File Offset: 0x0001D6A7
		// (set) Token: 0x0600292B RID: 10539 RVA: 0x0001F4AF File Offset: 0x0001D6AF
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

		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x0600292C RID: 10540 RVA: 0x0001F4DA File Offset: 0x0001D6DA
		// (set) Token: 0x0600292D RID: 10541 RVA: 0x0001F4E2 File Offset: 0x0001D6E2
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
					this.dOBIEFUTIykrubTpRBFCGsUvsaUV();
				}
				else
				{
					this._imageRaycastHelper.GIEiARxYMViVyBKxUpdiLnATYgLQ();
				}
				this.FfCSAENAWeppOruWNCWYRiwVBqGj();
			}
		}

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x0600292E RID: 10542 RVA: 0x0001F511 File Offset: 0x0001D711
		public AxisCalibration horizontalAxisCalibration
		{
			get
			{
				return this._axis2D.xAxis.calibration;
			}
		}

		// Token: 0x170009B9 RID: 2489
		// (get) Token: 0x0600292F RID: 10543 RVA: 0x0001F523 File Offset: 0x0001D723
		public AxisCalibration verticalAxisCalibration
		{
			get
			{
				return this._axis2D.yAxis.calibration;
			}
		}

		// Token: 0x170009BA RID: 2490
		// (get) Token: 0x06002930 RID: 10544 RVA: 0x0001F535 File Offset: 0x0001D735
		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType
		{
			get
			{
				return this._axis2D.calibration;
			}
		}

		// Token: 0x170009BB RID: 2491
		// (get) Token: 0x06002931 RID: 10545 RVA: 0x0001F535 File Offset: 0x0001D735
		public Axis2DCalibration axis2DCalibration
		{
			get
			{
				return this._axis2D.calibration;
			}
		}

		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06002932 RID: 10546 RVA: 0x0001F542 File Offset: 0x0001D742
		// (set) Token: 0x06002933 RID: 10547 RVA: 0x0001F54A File Offset: 0x0001D74A
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

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x06002934 RID: 10548 RVA: 0x0001F553 File Offset: 0x0001D753
		public bool hasPointer
		{
			get
			{
				return this._pointerId != int.MinValue;
			}
		}

		// Token: 0x170009BE RID: 2494
		// (get) Token: 0x06002935 RID: 10549 RVA: 0x0001F565 File Offset: 0x0001D765
		private bool vdmfjQKVdvfpXcYnqlbcVQJbgxVfb
		{
			get
			{
				return this._lastTapFrame == Time.frameCount;
			}
		}

		// Token: 0x170009BF RID: 2495
		// (get) Token: 0x06002936 RID: 10550 RVA: 0x0001F574 File Offset: 0x0001D774
		internal StandaloneAxis2D YbbtFsyAauXQZBJXHgvagULLPuPFA
		{
			get
			{
				return this._axis2D;
			}
		}

		// Token: 0x170009C0 RID: 2496
		// (get) Token: 0x06002937 RID: 10551 RVA: 0x00097F98 File Offset: 0x00096198
		private Action<TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA> yGzuopIUyzXGPgPExCpeeYqcyydg
		{
			get
			{
				if (this.__moveStartedDelegate == null)
				{
					return this.__moveStartedDelegate = new Action<TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA>(this.wmwvRqwqvEjPSLlLISPceToFtuEh);
				}
				return this.__moveStartedDelegate;
			}
		}

		// Token: 0x170009C1 RID: 2497
		// (get) Token: 0x06002938 RID: 10552 RVA: 0x00097FCC File Offset: 0x000961CC
		private Action<TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA> bzAVQiXvDLGXLorChicYFBnTxthG
		{
			get
			{
				if (this.__moveEndedDelegate == null)
				{
					return this.__moveEndedDelegate = new Action<TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA>(this.eYynfGixqGUfyOCaZJHrasTHeNNf);
				}
				return this.__moveEndedDelegate;
			}
		}

		// Token: 0x170009C2 RID: 2498
		// (get) Token: 0x06002939 RID: 10553 RVA: 0x0001F57C File Offset: 0x0001D77C
		private int pAuCrXUfDqZRmSwHZDpSIbHjwtfk
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

		// Token: 0x170009C3 RID: 2499
		// (get) Token: 0x0600293A RID: 10554 RVA: 0x0001F5AB File Offset: 0x0001D7AB
		private RectTransform umzJBwygwTGRcOQjrIrwQMBpcsCBA
		{
			get
			{
				if (this._lastClaimSource != TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion)
				{
					return base.transform as RectTransform;
				}
				return base.transform.parent as RectTransform;
			}
		}

		// Token: 0x170009C4 RID: 2500
		// (get) Token: 0x0600293B RID: 10555 RVA: 0x00098000 File Offset: 0x00096200
		private float MgcSlSYSeSnEUrjqwLONMGXGLfHf
		{
			get
			{
				if (Time.frameCount == this._calculatedStickRange_lastUpdatedFrame)
				{
					return this.__calculatedStickRange_cachedValue;
				}
				RectTransform rectTransform = base.evSkNeHIwOzqBDBovKqKbEzIdiKl;
				RectTransform rectTransform2 = this.umzJBwygwTGRcOQjrIrwQMBpcsCBA;
				Vector3 position = new Vector3(0f, this._stickRange, 0f);
				Vector3 a = rectTransform.TransformPoint(position) - rectTransform.position;
				Vector3 a2 = rectTransform2.InverseTransformPoint(a + rectTransform2.position);
				float magnitude;
				if (this._scaleStickRange)
				{
					Vector3 lossyScale = rectTransform.lossyScale;
					Vector3 lossyScale2 = rectTransform2.lossyScale;
					if (lossyScale.x != 0f)
					{
						lossyScale2.x /= lossyScale.x;
					}
					if (lossyScale.y != 0f)
					{
						lossyScale2.y /= lossyScale.y;
					}
					if (lossyScale.z != 0f)
					{
						lossyScale2.z /= lossyScale.z;
					}
					if (this._lastClaimSource == TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion)
					{
						lossyScale2.Scale(base.transform.localScale);
					}
					magnitude = Vector3.Scale(a2, lossyScale2).magnitude;
				}
				else
				{
					magnitude = a2.magnitude;
				}
				this.__calculatedStickRange_cachedValue = magnitude;
				this._calculatedStickRange_lastUpdatedFrame = Time.frameCount;
				return magnitude;
			}
		}

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x0600293C RID: 10556 RVA: 0x0001F5D2 File Offset: 0x0001D7D2
		// (remove) Token: 0x0600293D RID: 10557 RVA: 0x0001F5E0 File Offset: 0x0001D7E0
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

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x0600293E RID: 10558 RVA: 0x0001F5EE File Offset: 0x0001D7EE
		// (remove) Token: 0x0600293F RID: 10559 RVA: 0x0001F5FC File Offset: 0x0001D7FC
		public event UnityAction<Vector2> StickPositionChangedEvent
		{
			add
			{
				this._onStickPositionChanged.AddListener(value);
			}
			remove
			{
				this._onStickPositionChanged.RemoveListener(value);
			}
		}

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x06002940 RID: 10560 RVA: 0x0001F60A File Offset: 0x0001D80A
		// (remove) Token: 0x06002941 RID: 10561 RVA: 0x0001F618 File Offset: 0x0001D818
		public event UnityAction TouchDownEvent
		{
			add
			{
				this._onTouchStarted.AddListener(value);
			}
			remove
			{
				this._onTouchStarted.RemoveListener(value);
			}
		}

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06002942 RID: 10562 RVA: 0x0001F626 File Offset: 0x0001D826
		// (remove) Token: 0x06002943 RID: 10563 RVA: 0x0001F634 File Offset: 0x0001D834
		public event UnityAction TouchUpEvent
		{
			add
			{
				this._onTouchEnded.AddListener(value);
			}
			remove
			{
				this._onTouchEnded.RemoveListener(value);
			}
		}

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06002944 RID: 10564 RVA: 0x0001F642 File Offset: 0x0001D842
		// (remove) Token: 0x06002945 RID: 10565 RVA: 0x0001F650 File Offset: 0x0001D850
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

		// Token: 0x06002946 RID: 10566 RVA: 0x00098138 File Offset: 0x00096338
		[CustomObfuscation(rename = false)]
		private TouchJoystick()
		{
		}

		// Token: 0x06002947 RID: 10567 RVA: 0x0001F65E File Offset: 0x0001D85E
		public Vector2 GetValue()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return this._axis2D.rawZero;
			}
			return this._axis2D.value;
		}

		// Token: 0x06002948 RID: 10568 RVA: 0x0001F67F File Offset: 0x0001D87F
		public Vector2 GetRawValue()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return this._axis2D.rawZero;
			}
			return this._axis2D.rawValue;
		}

		// Token: 0x06002949 RID: 10569 RVA: 0x00098254 File Offset: 0x00096454
		public void SetRawValue(Vector2 value)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (this._joystickMode == TouchJoystick.JoystickMode.Digital)
			{
				if (value.sqrMagnitude <= this._digitalModeDeadZone * this._digitalModeDeadZone)
				{
					value.x = 0f;
					value.y = 0f;
				}
				else
				{
					value.Normalize();
				}
			}
			if (this._snapDirections != TouchJoystick.SnapDirections.None)
			{
				value = MathTools.SnapVectorToNearestAngle(value, 360f / (float)this._snapDirections);
				if (value.x != 0f)
				{
					if (MathTools.IsNearZero(value.x, 0.0001f))
					{
						value.x = 0f;
					}
					else if (MathTools.IsNear(value.x, 1f, 0.0001f))
					{
						value.x = 1f;
					}
					else if (MathTools.IsNear(value.x, -1f, 0.0001f))
					{
						value.x = -1f;
					}
				}
				if (value.y != 0f)
				{
					if (MathTools.IsNearZero(value.y, 0.0001f))
					{
						value.y = 0f;
					}
					else if (MathTools.IsNear(value.y, 1f, 0.0001f))
					{
						value.y = 1f;
					}
					else if (MathTools.IsNear(value.y, -1f, 0.0001f))
					{
						value.y = -1f;
					}
				}
			}
			if (this._useXAxis || this._useYAxis)
			{
				this._axis2D.SetRawValue(this._useXAxis ? value.x : 0f, this._useYAxis ? value.y : 0f);
			}
		}

		// Token: 0x0600294A RID: 10570 RVA: 0x0001F6A0 File Offset: 0x0001D8A0
		public void SetDefaultPosition()
		{
			this.MnbBkVCmYKKWVNUMDsttRfQMjdwiA(base.ZlJFgENigMndbNzNAXlaJMlysRs.anchoredPosition);
		}

		// Token: 0x0600294B RID: 10571 RVA: 0x0001F6B3 File Offset: 0x0001D8B3
		private void MnbBkVCmYKKWVNUMDsttRfQMjdwiA(Vector2 A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this._origAnchoredPosition = A_1;
		}

		// Token: 0x0600294C RID: 10572 RVA: 0x0001F6C5 File Offset: 0x0001D8C5
		public void ReturnToDefaultPosition(bool instant)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.WpvBpWgMNeFJLXkXEvSeLzXglEELA(this._origAnchoredPosition, PositionType.Anchored, !instant && this._animateOnReturn, this._returnSpeed, TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.TowardHome);
		}

		// Token: 0x0600294D RID: 10573 RVA: 0x0001F6F0 File Offset: 0x0001D8F0
		public void ReturnToDefaultPosition()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.ReturnToDefaultPosition(false);
		}

		// Token: 0x0600294E RID: 10574 RVA: 0x000983FC File Offset: 0x000965FC
		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (!Application.isPlaying)
			{
				return;
			}
			this._origAnchoredPosition = base.ZlJFgENigMndbNzNAXlaJMlysRs.anchoredPosition;
			if (this._stickTransform != null)
			{
				this._origStickAnchoredPosition = this._stickTransform.anchoredPosition;
			}
			this.SetRawValue(this.YbbtFsyAauXQZBJXHgvagULLPuPFA.rawZero);
		}

		// Token: 0x0600294F RID: 10575 RVA: 0x0001F702 File Offset: 0x0001D902
		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.HJwHBkSxKnubQjgPRiGSuMxZTLoB();
		}

		// Token: 0x06002950 RID: 10576 RVA: 0x0001F719 File Offset: 0x0001D919
		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this._axis2D.Deinitialize();
			this.ypZrirDpTPdDSbwgBziSLiFRjrJkA();
		}

		// Token: 0x06002951 RID: 10577 RVA: 0x0001F73B File Offset: 0x0001D93B
		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.VsqgfEONWmbnuOXStggPuebYZjIo();
			this.HJwHBkSxKnubQjgPRiGSuMxZTLoB();
		}

		// Token: 0x06002952 RID: 10578 RVA: 0x0001F758 File Offset: 0x0001D958
		internal void HUSlrqHpHOAasdUuyeGbdDhFzYdbB()
		{
			base.AoHwozRsjiUmhnUZxZinlrstaSL();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.SriOBqLGRuWlskvZdHZMMFbGHDTd();
			this.DwtdANJMcqjdreYaYsIMWtWUPpsq();
			this.oqUGnMRglfbtChWicNWCUlukBjrVA();
		}

		// Token: 0x06002953 RID: 10579 RVA: 0x0001F77B File Offset: 0x0001D97B
		internal bool QOEVLTMIabNHbaAnWNKkncvdrgFl()
		{
			if (!base.ljoRLbCAHFdMhoOyLpdVnVLwwTMd())
			{
				return false;
			}
			this.VsqgfEONWmbnuOXStggPuebYZjIo();
			this._axis2D.Initialize();
			return true;
		}

		// Token: 0x06002954 RID: 10580 RVA: 0x00098458 File Offset: 0x00096658
		internal void wSnddJFqUsrQMlWFCuUyQwfHHWmUA()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			Vector2 value = this._axis2D.value;
			if (this._useXAxis)
			{
				base.WiKtlIjluObCctWuxDsizpItcifHA(this._horizontalAxisCustomControllerElement, value.x, this._axis2D.xAxis.buttonActivationThreshold);
			}
			if (this._useYAxis)
			{
				base.WiKtlIjluObCctWuxDsizpItcifHA(this._verticalAxisCustomControllerElement, value.y, this._axis2D.yAxis.buttonActivationThreshold);
			}
			if (this._allowTap)
			{
				base.wxsDJwhBGhAlFpbeoLzNoYvIriVe(this._tapCustomControllerElement, this.vdmfjQKVdvfpXcYnqlbcVQJbgxVfb);
			}
		}

		// Token: 0x06002955 RID: 10581 RVA: 0x0001F799 File Offset: 0x0001D999
		internal void ifdcfIJbjcCnnPGLCtXMBpSNqauDb()
		{
			base.SsfxZPZhDDtylHZYnTMQyawFtfbC();
			this._axis2D.ValueChangedEvent += this.yOzxllYTIwiJPCEmyPVcmXQpiNLA;
		}

		// Token: 0x06002956 RID: 10582 RVA: 0x0001F7B8 File Offset: 0x0001D9B8
		internal void eYpEYvDbEEKphbsQerwqMctMJdYOc()
		{
			base.dDJGenyHMNqOIuUSedhLaBWSdtrkA();
			this._axis2D.ValueChangedEvent -= this.yOzxllYTIwiJPCEmyPVcmXQpiNLA;
		}

		// Token: 0x06002957 RID: 10583 RVA: 0x0001F7D7 File Offset: 0x0001D9D7
		internal void SIEaCFpyfChCoazOCNYJysqsroTt()
		{
			base.DIrIjbritRrTvPOfPhRMJhhCMvxGA();
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this.VsqgfEONWmbnuOXStggPuebYZjIo();
			this.HJwHBkSxKnubQjgPRiGSuMxZTLoB();
		}

		// Token: 0x06002958 RID: 10584 RVA: 0x000984F4 File Offset: 0x000966F4
		internal void KayeurchGCRCpegHCervAYGWNUqK()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this._pointerId = int.MinValue;
			this._realMousePointerId = int.MinValue;
			this.BQClJJeHAyUDDZqUBwHgVeToADnIA = false;
			this.dwkrAWEnfPkLNLXmUCbcGHfpvKld = false;
			this._pointerDownIsFake = false;
			this._lastPressAnchoredPosition = Vector2.zero;
			this._lastPressStartingValue = Vector2.zero;
			this._calculatedStickRange_lastUpdatedFrame = -1;
			this._lastTapFrame = -1;
			this._isEligibleForTap = false;
			if (this._returnOnRelease && this._isMovedFromDefaultPosition && (this._moveToTouchPosition || this._followTouchPosition))
			{
				this.ReturnToDefaultPosition(true);
			}
			this._isMovedFromDefaultPosition = false;
			this._isMoving = false;
			this._moveDirection = TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.None;
			this.iRafZgahKneIeTKlCbeOiXHcpqNDc();
			this._axis2D.Clear();
			this.HJwHBkSxKnubQjgPRiGSuMxZTLoB();
		}

		// Token: 0x06002959 RID: 10585 RVA: 0x000985B4 File Offset: 0x000967B4
		internal void wlzEZrgmrftfuWvvfitEwlXcNwyQA()
		{
			base.MUlawrgchCgLWJWMYFjmPACJhbWPA();
			if (this._hierarchyValueChangedHandlers == null)
			{
				this._hierarchyValueChangedHandlers = new XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<TouchJoystick.IValueChangedHandler, Vector2>(TouchJoystick.lIrviqyAGtkJCiEQjohiXeGtTjPi);
			}
			this._hierarchyValueChangedHandlers.GetHandlers(base.transform);
			if (this._hierarchyStickPositionChangedHandlers == null)
			{
				this._hierarchyStickPositionChangedHandlers = new XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<TouchJoystick.IStickPositionChangedHandler, Vector2>(TouchJoystick.qfKrSsHFnxspXdfLjTLdAckWkBop);
			}
			this._hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
		}

		// Token: 0x0600295A RID: 10586 RVA: 0x0009861C File Offset: 0x0009681C
		public override void ClearValue()
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			this._axis2D.Clear();
			this._lastTapFrame = -1;
			if (this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._horizontalAxisCustomControllerElement);
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._verticalAxisCustomControllerElement);
				base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._tapCustomControllerElement);
			}
		}

		// Token: 0x0600295B RID: 10587 RVA: 0x0001F7F4 File Offset: 0x0001D9F4
		internal bool vmBpKqkiECwXzxZoJGCPCEsjpGBk()
		{
			return base.veZcaeCyueZWdUyopUIfeodQudJq && base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && this.BQClJJeHAyUDDZqUBwHgVeToADnIA;
		}

		// Token: 0x0600295C RID: 10588 RVA: 0x0001F810 File Offset: 0x0001DA10
		internal bool WQpreBPQJOwuGTvOQHdWzlhIqXeQ(GameObject A_1)
		{
			return !(A_1 == null) && (base.azuQLFEAbDNvtgPVOdzszMzaxXqC(A_1) || (this._workingTouchRegion != null && this._workingTouchRegion.gameObject == A_1));
		}

		// Token: 0x0600295D RID: 10589 RVA: 0x0001F849 File Offset: 0x0001DA49
		private void HJwHBkSxKnubQjgPRiGSuMxZTLoB()
		{
			this._horizontalAxisCustomControllerElement.ClearElementCaches();
			this._verticalAxisCustomControllerElement.ClearElementCaches();
			this._tapCustomControllerElement.ClearElementCaches();
			this.oqUGnMRglfbtChWicNWCUlukBjrVA();
			this.dOBIEFUTIykrubTpRBFCGsUvsaUV();
		}

		// Token: 0x0600295E RID: 10590 RVA: 0x0001F878 File Offset: 0x0001DA78
		private void dOBIEFUTIykrubTpRBFCGsUvsaUV()
		{
			if (!this._manageRaycasting)
			{
				return;
			}
			this._imageRaycastHelper.dHSqDioPfpgmHAtOhAxOuRATBgLSA(base.transform, this.PngXqlzirBlOmfzldLDjbqYDHKqn());
		}

		// Token: 0x0600295F RID: 10591 RVA: 0x0001F89A File Offset: 0x0001DA9A
		private bool PngXqlzirBlOmfzldLDjbqYDHKqn()
		{
			return !(this._workingTouchRegion != null) || !this._useTouchRegionOnly;
		}

		// Token: 0x06002960 RID: 10592 RVA: 0x00098680 File Offset: 0x00096880
		private void rerXbplRcsBQOsSqMTVavsTTXsMg(TouchRegion A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.UjzXdrTwEgaVUmjueRrVxxwSgLvu(A_1);
			A_1.PointerDownEvent += this.raMLucqUIFHpurgZKWLViYbHmKyi;
			A_1.PointerUpEvent += this.TAgezgeoIAqXzQkXCULulMGuqcKl;
			A_1.PointerEnterEvent += this.LlZbnbRnuYNEmelquPpOqUoEWrTh;
			A_1.PointerExitEvent += this.AxsczwBNAHUTyoGcGdgPUOUDifbvA;
			A_1.BeginDragEvent += this.XjnUBIDMBvThJhboMwNJHfVQPGXT;
			A_1.DragEvent += this.MnpLHNdRuDosmUHsvYdGjPIXyHnh;
			A_1.EndDragEvent += this.OKTtJsmTMKMrPCXfRqVfeFntemKq;
		}

		// Token: 0x06002961 RID: 10593 RVA: 0x0009871C File Offset: 0x0009691C
		private void UjzXdrTwEgaVUmjueRrVxxwSgLvu(TouchRegion A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			A_1.PointerDownEvent -= this.raMLucqUIFHpurgZKWLViYbHmKyi;
			A_1.PointerUpEvent -= this.TAgezgeoIAqXzQkXCULulMGuqcKl;
			A_1.PointerEnterEvent -= this.LlZbnbRnuYNEmelquPpOqUoEWrTh;
			A_1.PointerExitEvent -= this.AxsczwBNAHUTyoGcGdgPUOUDifbvA;
			A_1.BeginDragEvent -= this.XjnUBIDMBvThJhboMwNJHfVQPGXT;
			A_1.DragEvent -= this.MnpLHNdRuDosmUHsvYdGjPIXyHnh;
			A_1.EndDragEvent -= this.OKTtJsmTMKMrPCXfRqVfeFntemKq;
		}

		// Token: 0x06002962 RID: 10594 RVA: 0x0001F8B5 File Offset: 0x0001DAB5
		private void oqUGnMRglfbtChWicNWCUlukBjrVA()
		{
			if (this._workingTouchRegion == this._touchRegion)
			{
				return;
			}
			this.UjzXdrTwEgaVUmjueRrVxxwSgLvu(this._workingTouchRegion);
			this._workingTouchRegion = this._touchRegion;
			this.rerXbplRcsBQOsSqMTVavsTTXsMg(this._workingTouchRegion);
		}

		// Token: 0x06002963 RID: 10595 RVA: 0x000987B4 File Offset: 0x000969B4
		private void xhkyFOGINKlesFEfVQYCbZwzpUXq(Vector2 A_1, bool A_2, float A_3, TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA A_4)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = YPidKbradifyUUSIIphXNVhWkELO.UBhQhaveBoLCAcNGtOVKQpekxHuE(base.hlsJgfPNbiEXjyoptqyskoeItXRG, rectTransform, A_1);
			Vector2 pivot = base.ZlJFgENigMndbNzNAXlaJMlysRs.pivot;
			Vector2 sizeDelta = base.ZlJFgENigMndbNzNAXlaJMlysRs.sizeDelta;
			Vector3 localScale = base.ZlJFgENigMndbNzNAXlaJMlysRs.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			this.WpvBpWgMNeFJLXkXEvSeLzXglEELA(vector, PositionType.Local, A_2, A_3, A_4);
		}

		// Token: 0x06002964 RID: 10596 RVA: 0x00098854 File Offset: 0x00096A54
		private void WpvBpWgMNeFJLXkXEvSeLzXglEELA(Vector2 A_1, PositionType A_2, bool A_3, float A_4, TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA A_5)
		{
			if (this._isMoving && A_3 && this._moveDirection == A_5)
			{
				return;
			}
			if (this._isMoving && this._coroutineMove != null)
			{
				this.iRafZgahKneIeTKlCbeOiXHcpqNDc();
				this._isMoving = false;
				this._moveDirection = TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.None;
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
				this._coroutineMove = this.UNDaCIxBvahKpIaxwUbPptPWJGjMA(A_1, A_2, A_4, A_5);
				base.StartCoroutine(this._coroutineMove);
				this._moveDirection = A_5;
				this._isMovedFromDefaultPosition = true;
				this.yGzuopIUyzXGPgPExCpeeYqcyydg(A_5);
				return;
			}
			this.yGzuopIUyzXGPgPExCpeeYqcyydg(A_5);
			this.ETAzplrylunNafVDgBTCivPtWfuD(A_5, A_1, A_2);
		}

		// Token: 0x06002965 RID: 10597 RVA: 0x0001F8EF File Offset: 0x0001DAEF
		private IEnumerator UNDaCIxBvahKpIaxwUbPptPWJGjMA(Vector2 A_1, PositionType A_2, float A_3, TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA A_4)
		{
			if (A_3 > 0f)
			{
				RectTransform rectTransform = base.ZlJFgENigMndbNzNAXlaJMlysRs;
				Vector2 vector = YPidKbradifyUUSIIphXNVhWkELO.FMCCakiREYuspTAFkFHwHJWBXmTdA(rectTransform, A_2);
				float magnitude = (A_1 - vector).magnitude;
				if (magnitude >= 0.01f)
				{
					this._isMoving = true;
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
			this.ETAzplrylunNafVDgBTCivPtWfuD(A_4, A_1, A_2);
			yield break;
		}

		// Token: 0x06002966 RID: 10598 RVA: 0x000989DC File Offset: 0x00096BDC
		private void ETAzplrylunNafVDgBTCivPtWfuD(TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA A_1, Vector2 A_2, PositionType A_3)
		{
			YPidKbradifyUUSIIphXNVhWkELO.ModUCBJUUjSQBmryOcaxZotSMxyA(base.ZlJFgENigMndbNzNAXlaJMlysRs, A_2, A_3);
			this._isMoving = false;
			this._moveDirection = TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.None;
			if (A_1 == TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.TowardHome)
			{
				this._isMovedFromDefaultPosition = false;
			}
			else if (A_1 == TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.TowardTouch)
			{
				this._isMovedFromDefaultPosition = true;
			}
			this.iRafZgahKneIeTKlCbeOiXHcpqNDc();
			this.bzAVQiXvDLGXLorChicYFBnTxthG(A_1);
		}

		// Token: 0x06002967 RID: 10599 RVA: 0x00098A34 File Offset: 0x00096C34
		private void wmwvRqwqvEjPSLlLISPceToFtuEh(TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA A_1)
		{
			if (this._manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((this._followTouchPosition && this.stayActiveOnSwipeOut) || (!this._followTouchPosition && this._workingTouchRegion != null && !this._useTouchRegionOnly && this._moveToTouchPosition)) && this._returnOnRelease && A_1 == TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					this._imageRaycastHelper.dHSqDioPfpgmHAtOhAxOuRATBgLSA(base.transform, flag2);
				}
			}
		}

		// Token: 0x06002968 RID: 10600 RVA: 0x00098AA8 File Offset: 0x00096CA8
		private void eYynfGixqGUfyOCaZJHrasTHeNNf(TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA A_1)
		{
			if (this._manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((this._followTouchPosition && this.stayActiveOnSwipeOut) || (!this._followTouchPosition && this._workingTouchRegion != null && !this._useTouchRegionOnly && this._moveToTouchPosition)) && this._returnOnRelease && A_1 == TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.TowardHome)
				{
					flag = true;
					flag2 = this.PngXqlzirBlOmfzldLDjbqYDHKqn();
				}
				if (flag)
				{
					this._imageRaycastHelper.dHSqDioPfpgmHAtOhAxOuRATBgLSA(base.transform, flag2);
				}
			}
		}

		// Token: 0x06002969 RID: 10601 RVA: 0x00098B24 File Offset: 0x00096D24
		private void iRafZgahKneIeTKlCbeOiXHcpqNDc()
		{
			if (this._coroutineMove != null)
			{
				try
				{
					base.StopCoroutine(this._coroutineMove);
				}
				catch
				{
				}
				this._coroutineMove = null;
			}
		}

		// Token: 0x0600296A RID: 10602 RVA: 0x00098B64 File Offset: 0x00096D64
		private void sowijTZyWmlfVxuhktZfmBoqcAVR(int A_1, Vector2 A_2, PositionType A_3)
		{
			if (!TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(A_1))
			{
				return;
			}
			this.WpvBpWgMNeFJLXkXEvSeLzXglEELA(YPidKbradifyUUSIIphXNVhWkELO.FMCCakiREYuspTAFkFHwHJWBXmTdA(base.ZlJFgENigMndbNzNAXlaJMlysRs, A_3) + A_2, A_3, false, 0f, TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.TowardTouch);
			if (this._lastClaimSource == TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion)
			{
				this._lastPressAnchoredPosition += A_2;
			}
		}

		// Token: 0x0600296B RID: 10603 RVA: 0x00098BBC File Offset: 0x00096DBC
		private void DwtdANJMcqjdreYaYsIMWtWUPpsq()
		{
			if (!this.hasPointer)
			{
				return;
			}
			if (TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk))
			{
				if (this._pointerDownIsFake)
				{
					PointerEventData pointerEventData = this.ImWubEkDlaxqdUFIbVRXKAwDyEZg(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk, (this._workingTouchRegion != null && this._useTouchRegionOnly) ? this._workingTouchRegion.gameObject : ((this._stickTransform != null) ? this._stickTransform.gameObject : base.gameObject));
					if (pointerEventData != null)
					{
						this.jsKPgSLTnrOnTUFxqyPjvyRTgLKX(pointerEventData, this._lastClaimSource);
					}
				}
				return;
			}
			PointerEventData pointerEventData2 = this.JCNEpzPKFuHhHfbbUHXPPgIRlKOKA(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk);
			if (pointerEventData2 != null && pointerEventData2.pointerPress != null)
			{
				this.nhKkSHitcKOxiGccuFCSTzwaPNEt(pointerEventData2);
				return;
			}
			this.icFsdkqHGzASpObgaGdgChRkUfzr();
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x00098C78 File Offset: 0x00096E78
		private void SriOBqLGRuWlskvZdHZMMFbGHDTd()
		{
			if (!this.hasPointer)
			{
				return;
			}
			Vector2 vector = TouchInteractable.ZUnrIQphLGwhXswkmMnPlWvrfTLc(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk);
			this.yDDOmbTSIHnNVkJZhZoraEQlqUsh(ref vector);
		}

		// Token: 0x0600296D RID: 10605 RVA: 0x00098CA8 File Offset: 0x00096EA8
		private void yDDOmbTSIHnNVkJZhZoraEQlqUsh(ref Vector2 A_1)
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

		// Token: 0x0600296E RID: 10606 RVA: 0x0001F91B File Offset: 0x0001DB1B
		private bool KgXPKbQwatRYDrLvkkgumTpDDmmU()
		{
			return this._followTouchPosition && (!(this._touchRegion != null) || !this._useTouchRegionOnly);
		}

		// Token: 0x0600296F RID: 10607 RVA: 0x0001F940 File Offset: 0x0001DB40
		private void yEfDrYApJxXRHvtOfojShuaSESCl()
		{
			this._pointerId = int.MinValue;
			this._realMousePointerId = int.MinValue;
			this._lastClaimSource = TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local;
		}

		// Token: 0x06002970 RID: 10608 RVA: 0x00098D14 File Offset: 0x00096F14
		private bool noQgFIdwYtjypyjjMxWfwwSTzXR(int A_1)
		{
			return A_1 != int.MinValue && this._pointerId != int.MinValue && (this._pointerId == A_1 || (TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1) && this._realMousePointerId != int.MinValue && A_1 == this._realMousePointerId));
		}

		// Token: 0x06002971 RID: 10609 RVA: 0x00098D68 File Offset: 0x00096F68
		private PointerEventData ZmrlMpGrSzctdCFcdkItDQdrvMGH(int A_1, GameObject A_2)
		{
			PointerEventData pointerEventData = this.JCNEpzPKFuHhHfbbUHXPPgIRlKOKA(A_1);
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

		// Token: 0x06002972 RID: 10610 RVA: 0x00098F30 File Offset: 0x00097130
		private PointerEventData ImWubEkDlaxqdUFIbVRXKAwDyEZg(int A_1, GameObject A_2)
		{
			PointerEventData pointerEventData = this.JCNEpzPKFuHhHfbbUHXPPgIRlKOKA(A_1);
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

		// Token: 0x06002973 RID: 10611 RVA: 0x00098F98 File Offset: 0x00097198
		private PointerEventData PjmDQBNafWfTHfEFjVHbpXiTeNJmA(int A_1)
		{
			PointerEventData pointerEventData = this.JCNEpzPKFuHhHfbbUHXPPgIRlKOKA(A_1);
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

		// Token: 0x06002974 RID: 10612 RVA: 0x0001F95F File Offset: 0x0001DB5F
		private void nhKkSHitcKOxiGccuFCSTzwaPNEt(PointerEventData A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.OnPointerUp(A_1);
			this.PjmDQBNafWfTHfEFjVHbpXiTeNJmA(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk);
		}

		// Token: 0x06002975 RID: 10613 RVA: 0x0001F979 File Offset: 0x0001DB79
		private void jsKPgSLTnrOnTUFxqyPjvyRTgLKX(PointerEventData A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_2)
		{
			if (A_1 == null)
			{
				return;
			}
			if (A_2 == TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local)
			{
				this.OnDrag(A_1);
			}
			else
			{
				if (A_2 != TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion)
				{
					throw new NotImplementedException();
				}
				this.MnpLHNdRuDosmUHsvYdGjPIXyHnh(A_1);
			}
			this.PjmDQBNafWfTHfEFjVHbpXiTeNJmA(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk);
		}

		// Token: 0x06002976 RID: 10614 RVA: 0x0009902C File Offset: 0x0009722C
		private PointerEventData JCNEpzPKFuHhHfbbUHXPPgIRlKOKA(int A_1)
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

		// Token: 0x06002977 RID: 10615 RVA: 0x000990C0 File Offset: 0x000972C0
		private void VsqgfEONWmbnuOXStggPuebYZjIo()
		{
			this.hJvsUWhvoVCHUEDgmUBwEoZIHnHI(this._axesToUse);
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
		}

		// Token: 0x06002978 RID: 10616 RVA: 0x00099140 File Offset: 0x00097340
		private void hJvsUWhvoVCHUEDgmUBwEoZIHnHI(TouchJoystick.AxisDirection A_1)
		{
			bool flag = A_1 == TouchJoystick.AxisDirection.Both || A_1 == TouchJoystick.AxisDirection.Horizontal;
			if (this._useXAxis != flag)
			{
				this._useXAxis = flag;
				if (!flag && this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
				{
					int targetCount = this._horizontalAxisCustomControllerElement.targetCount;
					for (int i = 0; i < targetCount; i++)
					{
						base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._horizontalAxisCustomControllerElement[i]);
					}
				}
			}
			bool flag2 = A_1 == TouchJoystick.AxisDirection.Both || A_1 == TouchJoystick.AxisDirection.Vertical;
			if (this._useYAxis != flag2)
			{
				this._useYAxis = flag2;
				if (!flag2 && this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
				{
					int targetCount2 = this._verticalAxisCustomControllerElement.targetCount;
					for (int j = 0; j < targetCount2; j++)
					{
						base.WoSgDjfaOkuapKqTxSyHHZPJULte.ClearElementValue(this._verticalAxisCustomControllerElement[j]);
					}
				}
			}
			this._axesToUse = A_1;
		}

		// Token: 0x06002979 RID: 10617 RVA: 0x00099208 File Offset: 0x00097408
		private void eNtxkDHOSHPSKAgOsxLqQcRPYEzm(PointerEventData A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_2)
		{
			if (this.hasPointer && !this.noQgFIdwYtjypyjjMxWfwwSTzXR(A_1.pointerId))
			{
				return;
			}
			if (base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && base.IsInteractable())
			{
				this.QgBSSkudBhVFXkmdAHLcClRKZWwi(A_1.pointerId, A_1.pressPosition, A_2);
			}
			base.OnPointerDown(A_1);
		}

		// Token: 0x0600297A RID: 10618 RVA: 0x0001F9AB File Offset: 0x0001DBAB
		private void BGMDHqeVBtzyMShzxbLcqQjnOJYJ(PointerEventData A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_2)
		{
			if (this.hasPointer && !this.noQgFIdwYtjypyjjMxWfwwSTzXR(A_1.pointerId))
			{
				return;
			}
			if (TouchInteractable.OgkzCYVKiHNqmJCTuwqSbQmVtDFx(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk))
			{
				return;
			}
			this.icFsdkqHGzASpObgaGdgChRkUfzr();
			base.OnPointerUp(A_1);
		}

		// Token: 0x0600297B RID: 10619 RVA: 0x00099258 File Offset: 0x00097458
		private void cxDFDliKLFOqEZRWoPiywkKldftGb(PointerEventData A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_2)
		{
			if (this.hasPointer && !this.noQgFIdwYtjypyjjMxWfwwSTzXR(A_1.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.aaIbPrCaBllOFcEdgmfZmYUuTIqob(A_1.pointerId);
			bool flag2 = false;
			TouchInteractable.MouseButtonFlags allowedMouseButtons;
			if (A_2 != TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local)
			{
				if (A_2 != TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion)
				{
					throw new NotImplementedException();
				}
				allowedMouseButtons = this._touchRegion.allowedMouseButtons;
			}
			else
			{
				allowedMouseButtons = base.allowedMouseButtons;
			}
			if (this._activateOnSwipeIn && base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA() && base.IsInteractable() && (!flag || TouchInteractable.ygyrytQEEfuBWjVlJlbtaHrKeHYjA(allowedMouseButtons)) && !this.BQClJJeHAyUDDZqUBwHgVeToADnIA)
			{
				if (flag)
				{
					int realMousePointerId;
					if (TouchInteractable.fViPIDXJiFoyaUCiJDHKdMbSRRWeA(allowedMouseButtons, out realMousePointerId))
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
				GameObject gameObject;
				if (A_2 != TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local)
				{
					if (A_2 != TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion)
					{
						throw new NotImplementedException();
					}
					gameObject = this._workingTouchRegion.gameObject;
				}
				else
				{
					gameObject = base.gameObject;
				}
				PointerEventData pointerEventData = this.ZmrlMpGrSzctdCFcdkItDQdrvMGH((this._realMousePointerId != int.MinValue) ? this._realMousePointerId : A_1.pointerId, gameObject);
				if (pointerEventData != null)
				{
					this.eNtxkDHOSHPSKAgOsxLqQcRPYEzm(pointerEventData, A_2);
					if (this.BQClJJeHAyUDDZqUBwHgVeToADnIA)
					{
						this._pointerDownIsFake = true;
					}
				}
			}
			this.dwkrAWEnfPkLNLXmUCbcGHfpvKld = true;
		}

		// Token: 0x0600297C RID: 10620 RVA: 0x0009937C File Offset: 0x0009757C
		private void BrOeyXjLtEOoWIQTMCxzGAbBykQS(PointerEventData A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_2)
		{
			if (this.hasPointer && !this.noQgFIdwYtjypyjjMxWfwwSTzXR(A_1.pointerId))
			{
				base.OnPointerExit(A_1);
				return;
			}
			if (!this.stayActiveOnSwipeOut && this.BQClJJeHAyUDDZqUBwHgVeToADnIA)
			{
				this.icFsdkqHGzASpObgaGdgChRkUfzr();
			}
			base.OnPointerExit(A_1);
			this.dwkrAWEnfPkLNLXmUCbcGHfpvKld = false;
		}

		// Token: 0x0600297D RID: 10621 RVA: 0x0001F9DF File Offset: 0x0001DBDF
		private void UGeXjDGOMXsVmGEXgSXrWIbEioJQ(PointerEventData A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_2)
		{
			if (!this.hasPointer)
			{
				return;
			}
			if (!this.noQgFIdwYtjypyjjMxWfwwSTzXR(A_1.pointerId))
			{
				return;
			}
			base.OnBeginDrag(A_1);
		}

		// Token: 0x0600297E RID: 10622 RVA: 0x000993CC File Offset: 0x000975CC
		private void mAlTcdJQAbwbKsuICEGTCAfJbmhy(PointerEventData A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_2)
		{
			if (!this.hasPointer)
			{
				return;
			}
			if (!this.noQgFIdwYtjypyjjMxWfwwSTzXR(A_1.pointerId))
			{
				return;
			}
			RectTransform rectTransform = this.umzJBwygwTGRcOQjrIrwQMBpcsCBA;
			Vector2 vector;
			if (this._snapStickToTouch)
			{
				vector = YPidKbradifyUUSIIphXNVhWkELO.VjPWsfkbQHMGiOLqglYttcucudAy(base.ZlJFgENigMndbNzNAXlaJMlysRs, rectTransform, base.ZlJFgENigMndbNzNAXlaJMlysRs.rect.center);
			}
			else
			{
				vector = this._lastPressAnchoredPosition;
			}
			if (!this._centerStickOnRelease && !this._snapStickToTouch)
			{
				vector -= this._lastPressStartingValue * this.MgcSlSYSeSnEUrjqwLONMGXGLfHf;
			}
			Vector2 vector2 = YPidKbradifyUUSIIphXNVhWkELO.xRBGQSclFyFEitXSyqUxgVXMkDNz(base.hlsJgfPNbiEXjyoptqyskoeItXRG, rectTransform, A_1.position);
			Vector2 vector3 = new Vector2(this._useXAxis ? (vector2.x - vector.x) : 0f, this._useYAxis ? (vector2.y - vector.y) : 0f);
			Vector2 vector4;
			if (this._stickBounds == TouchJoystick.StickBounds.Circle)
			{
				vector4 = Vector2.ClampMagnitude(vector3, this.MgcSlSYSeSnEUrjqwLONMGXGLfHf);
			}
			else
			{
				if (this._stickBounds != TouchJoystick.StickBounds.Square)
				{
					throw new NotImplementedException();
				}
				vector4 = MathTools.Clamp(vector3, -this.MgcSlSYSeSnEUrjqwLONMGXGLfHf, this.MgcSlSYSeSnEUrjqwLONMGXGLfHf);
			}
			Vector2 rawValue = vector4 / this.MgcSlSYSeSnEUrjqwLONMGXGLfHf;
			this.SetRawValue(rawValue);
			if (this._followTouchPosition)
			{
				if (this._stickBounds == TouchJoystick.StickBounds.Circle)
				{
					if (vector3.sqrMagnitude > this.MgcSlSYSeSnEUrjqwLONMGXGLfHf)
					{
						Vector2 vector5 = new Vector2(this._useXAxis ? (vector3.x - vector4.x) : 0f, this._useXAxis ? (vector3.y - vector4.y) : 0f);
						this.sowijTZyWmlfVxuhktZfmBoqcAVR(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk, vector5, PositionType.Anchored);
					}
				}
				else
				{
					if (this._stickBounds != TouchJoystick.StickBounds.Square)
					{
						throw new NotImplementedException();
					}
					bool flag = Mathf.Abs(vector3.x) > this.MgcSlSYSeSnEUrjqwLONMGXGLfHf;
					bool flag2 = Mathf.Abs(vector3.y) > this.MgcSlSYSeSnEUrjqwLONMGXGLfHf;
					if (flag || flag2)
					{
						Vector2 vector6 = new Vector2((this._useXAxis && flag) ? (vector3.x - vector4.x) : 0f, (this._useXAxis && flag2) ? (vector3.y - vector4.y) : 0f);
						this.sowijTZyWmlfVxuhktZfmBoqcAVR(this.pAuCrXUfDqZRmSwHZDpSIbHjwtfk, vector6, PositionType.Anchored);
					}
				}
			}
			base.OnDrag(A_1);
		}

		// Token: 0x0600297F RID: 10623 RVA: 0x0001FA00 File Offset: 0x0001DC00
		private void yZZAMiiFQQYqTuLNEHKBjTeApUTrb(PointerEventData A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_2)
		{
			if (!this.hasPointer)
			{
				return;
			}
			if (!this.noQgFIdwYtjypyjjMxWfwwSTzXR(A_1.pointerId))
			{
				return;
			}
			base.OnEndDrag(A_1);
		}

		// Token: 0x06002980 RID: 10624 RVA: 0x00099618 File Offset: 0x00097818
		private void QgBSSkudBhVFXkmdAHLcClRKZWwi(int A_1, Vector2 A_2, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi A_3)
		{
			this._pointerId = A_1;
			this._lastClaimSource = A_3;
			this._isEligibleForTap = true;
			this._lastPressAnchoredPosition = YPidKbradifyUUSIIphXNVhWkELO.xRBGQSclFyFEitXSyqUxgVXMkDNz(base.hlsJgfPNbiEXjyoptqyskoeItXRG, this.umzJBwygwTGRcOQjrIrwQMBpcsCBA, A_2);
			this.BQClJJeHAyUDDZqUBwHgVeToADnIA = true;
			this._lastPressStartingValue.x = MathTools.Clamp(this._axis2D.value.x, -1f, 1f);
			this._lastPressStartingValue.y = MathTools.Clamp(this._axis2D.value.y, -1f, 1f);
			this._touchStartTime = Time.realtimeSinceStartup;
			this._touchStartPosition = A_2;
			if (A_3 == TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion && (this._moveToTouchPosition || this._followTouchPosition))
			{
				if (this._followTouchPosition)
				{
					this.xhkyFOGINKlesFEfVQYCbZwzpUXq(A_2, false, 0f, TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.TowardTouch);
				}
				else
				{
					this.xhkyFOGINKlesFEfVQYCbZwzpUXq(A_2, this._animateOnMoveToTouch, this._moveToTouchSpeed, TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA.TowardTouch);
				}
			}
			if (this._onTouchStarted != null)
			{
				this._onTouchStarted.Invoke();
			}
			PointerEventData pointerEventData = this.ImWubEkDlaxqdUFIbVRXKAwDyEZg(this._pointerId, (A_3 == TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion) ? this._workingTouchRegion.gameObject : ((this._stickTransform != null) ? this._stickTransform.gameObject : base.gameObject));
			if (pointerEventData != null)
			{
				this.jsKPgSLTnrOnTUFxqyPjvyRTgLKX(pointerEventData, A_3);
			}
		}

		// Token: 0x06002981 RID: 10625 RVA: 0x0009975C File Offset: 0x0009795C
		private void icFsdkqHGzASpObgaGdgChRkUfzr()
		{
			this.yEfDrYApJxXRHvtOfojShuaSESCl();
			bool flag = this._allowTap && this._isEligibleForTap;
			this.BQClJJeHAyUDDZqUBwHgVeToADnIA = false;
			this._pointerDownIsFake = false;
			this._lastPressAnchoredPosition = Vector2.zero;
			this._lastPressStartingValue = Vector2.zero;
			if ((this._followTouchPosition || this._moveToTouchPosition) && this._returnOnRelease && this._isMovedFromDefaultPosition)
			{
				this.ReturnToDefaultPosition();
			}
			if (this._centerStickOnRelease)
			{
				this.SetRawValue(this._axis2D.rawZero);
			}
			if (this._onTouchEnded != null)
			{
				this._onTouchEnded.Invoke();
			}
			this._isEligibleForTap = false;
			if (flag)
			{
				this._lastTapFrame = Time.frameCount + 1;
				this._onTap.Invoke();
			}
		}

		// Token: 0x06002982 RID: 10626 RVA: 0x0001FA21 File Offset: 0x0001DC21
		internal void jMtUtnWNqCeZCNwpwkiSDxyJKVCi(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			if (this._workingTouchRegion != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.BGMDHqeVBtzyMShzxbLcqQjnOJYJ(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local);
		}

		// Token: 0x06002983 RID: 10627 RVA: 0x0001FA60 File Offset: 0x0001DC60
		internal void GRJYcGweLVduhFHkBEzsGfhcILmZ(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				return;
			}
			if (this._workingTouchRegion != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.eNtxkDHOSHPSKAgOsxLqQcRPYEzm(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local);
		}

		// Token: 0x06002984 RID: 10628 RVA: 0x0001FA9F File Offset: 0x0001DC9F
		internal void gEhxtSXpPHzmDvmpYFcskkyoYdTNA(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			if (this._workingTouchRegion != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.cxDFDliKLFOqEZRWoPiywkKldftGb(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local);
		}

		// Token: 0x06002985 RID: 10629 RVA: 0x0001FADE File Offset: 0x0001DCDE
		internal void UWPNuutXDCQsSJiJcaKmnOsGPIun(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			if (this._workingTouchRegion != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.BrOeyXjLtEOoWIQTMCxzGAbBykQS(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local);
		}

		// Token: 0x06002986 RID: 10630 RVA: 0x0001FB1D File Offset: 0x0001DD1D
		internal void WpMaCxdZSkfrggBwKrskAiKUOezfA(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				return;
			}
			if (this._workingTouchRegion != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.UGeXjDGOMXsVmGEXgSXrWIbEioJQ(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local);
		}

		// Token: 0x06002987 RID: 10631 RVA: 0x0001FB5D File Offset: 0x0001DD5D
		internal void ELUxwaMPaiFbfQCKvzuOnhRUEhQi(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.Drag))
			{
				return;
			}
			if (this._workingTouchRegion != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.mAlTcdJQAbwbKsuICEGTCAfJbmhy(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local);
		}

		// Token: 0x06002988 RID: 10632 RVA: 0x0001FB9C File Offset: 0x0001DD9C
		internal void CGAQYmoLcQyWJleNwVxBtYBvtQZj(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				return;
			}
			if (this._workingTouchRegion != null && this._useTouchRegionOnly)
			{
				return;
			}
			this.yZZAMiiFQQYqTuLNEHKBjTeApUTrb(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.Local);
		}

		// Token: 0x06002989 RID: 10633 RVA: 0x0001FBDC File Offset: 0x0001DDDC
		private void raMLucqUIFHpurgZKWLViYbHmKyi(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				return;
			}
			this.eNtxkDHOSHPSKAgOsxLqQcRPYEzm(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion);
		}

		// Token: 0x0600298A RID: 10634 RVA: 0x0001FC09 File Offset: 0x0001DE09
		private void TAgezgeoIAqXzQkXCULulMGuqcKl(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			this.BGMDHqeVBtzyMShzxbLcqQjnOJYJ(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion);
		}

		// Token: 0x0600298B RID: 10635 RVA: 0x0001FC36 File Offset: 0x0001DE36
		private void LlZbnbRnuYNEmelquPpOqUoEWrTh(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			this.cxDFDliKLFOqEZRWoPiywkKldftGb(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion);
		}

		// Token: 0x0600298C RID: 10636 RVA: 0x0001FC63 File Offset: 0x0001DE63
		private void AxsczwBNAHUTyoGcGdgPUOUDifbvA(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			this.BrOeyXjLtEOoWIQTMCxzGAbBykQS(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion);
		}

		// Token: 0x0600298D RID: 10637 RVA: 0x0001FC90 File Offset: 0x0001DE90
		private void XjnUBIDMBvThJhboMwNJHfVQPGXT(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				return;
			}
			this.UGeXjDGOMXsVmGEXgSXrWIbEioJQ(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion);
		}

		// Token: 0x0600298E RID: 10638 RVA: 0x0001FCBE File Offset: 0x0001DEBE
		private void MnpLHNdRuDosmUHsvYdGjPIXyHnh(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				return;
			}
			this.mAlTcdJQAbwbKsuICEGTCAfJbmhy(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion);
		}

		// Token: 0x0600298F RID: 10639 RVA: 0x0001FCEB File Offset: 0x0001DEEB
		private void OKTtJsmTMKMrPCXfRqVfeFntemKq(PointerEventData A_1)
		{
			if (!base.veZcaeCyueZWdUyopUIfeodQudJq)
			{
				return;
			}
			if (!TouchInteractable.GaWflnNdJmrlCTtfjBFaofbzwzaK(A_1.pointerId, this._touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				return;
			}
			this.yZZAMiiFQQYqTuLNEHKBjTeApUTrb(A_1, TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi.TouchRegion);
		}

		// Token: 0x06002990 RID: 10640 RVA: 0x00099818 File Offset: 0x00097A18
		private void yOzxllYTIwiJPCEmyPVcmXQpiNLA(Vector2 A_1)
		{
			base.bQxfVwsHphtKQjTPHonPFeqrEVvE(null);
			Vector2 vector = A_1;
			if (this._axis2D.xAxis.calibration.invert)
			{
				vector.x *= -1f;
			}
			if (this._axis2D.yAxis.calibration.invert)
			{
				vector.y *= -1f;
			}
			vector = MathTools.Clamp(vector, -1f, 1f);
			if (this._stickTransform != null)
			{
				RectTransform rectTransform = this.umzJBwygwTGRcOQjrIrwQMBpcsCBA;
				Vector3 vector2 = vector * this.MgcSlSYSeSnEUrjqwLONMGXGLfHf;
				vector2 += rectTransform.InverseTransformPoint(base.transform.position);
				Vector3 position = rectTransform.TransformPoint(vector2);
				Vector3 vector3 = this._stickTransform.parent.InverseTransformPoint(position);
				Vector2 vector4 = YPidKbradifyUUSIIphXNVhWkELO.KFzUjdTmIgTJmTtRKOgXoHkLUCJc(this._stickTransform.parent as RectTransform, vector3);
				vector4 += this._origStickAnchoredPosition;
				this._stickTransform.anchoredPosition = vector4;
			}
			this._hierarchyValueChangedHandlers.ExecuteOnAll(A_1);
			this._hierarchyStickPositionChangedHandlers.ExecuteOnAll(vector);
			this._onValueChanged.Invoke(A_1);
			this._onStickPositionChanged.Invoke(vector);
		}

		// Token: 0x170009C5 RID: 2501
		// (get) Token: 0x06002991 RID: 10641 RVA: 0x0001FD19 File Offset: 0x0001DF19
		internal static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchJoystick.IValueChangedHandler, Vector2> lIrviqyAGtkJCiEQjohiXeGtTjPi
		{
			get
			{
				if (TouchJoystick.__valueChangedHandlerDelegate == null)
				{
					TouchJoystick.__valueChangedHandlerDelegate = new XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchJoystick.IValueChangedHandler, Vector2>(TouchJoystick.VNdqIicbjVROeLQZbpLCRmjuvtMX.<>9.TzKDOxilQDFqwIpbXtdyiFjFdpgQA);
				}
				return TouchJoystick.__valueChangedHandlerDelegate;
			}
		}

		// Token: 0x170009C6 RID: 2502
		// (get) Token: 0x06002992 RID: 10642 RVA: 0x0001FD4B File Offset: 0x0001DF4B
		internal static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchJoystick.IStickPositionChangedHandler, Vector2> qfKrSsHFnxspXdfLjTLdAckWkBop
		{
			get
			{
				if (TouchJoystick.__stickPositionChangedHandlerDelegate == null)
				{
					TouchJoystick.__stickPositionChangedHandlerDelegate = new XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchJoystick.IStickPositionChangedHandler, Vector2>(TouchJoystick.VNdqIicbjVROeLQZbpLCRmjuvtMX.<>9.jPJFOqFlbZYoksgsyasAQNgsgdEB);
				}
				return TouchJoystick.__stickPositionChangedHandlerDelegate;
			}
		}

		// Token: 0x0400179A RID: 6042
		private const float MAX_MOVE_SPEED = 20f;

		// Token: 0x0400179B RID: 6043
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		// Token: 0x0400179C RID: 6044
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		// Token: 0x0400179D RID: 6045
		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		// Token: 0x0400179E RID: 6046
		[Tooltip("The Rect Transform of the stick disc. This is moved around by the user when manipulating the joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private RectTransform _stickTransform;

		// Token: 0x0400179F RID: 6047
		[Tooltip("The joystick's mode of operation. Set this to Digital to simulate a D-Pad which has only On/Off states. If you want mimic a real D-Pad, you should also set Snap Directions to 8.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.JoystickMode _joystickMode;

		// Token: 0x040017A0 RID: 6048
		[Tooltip("A dead zone which is applied when Stick Mode is set to Digital. This is used to filter out tiny stick movements near 0, 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		private float _digitalModeDeadZone = 0.3f;

		// Token: 0x040017A1 RID: 6049
		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0.01f, 1000f)]
		private float _stickRange = 60f;

		// Token: 0x040017A2 RID: 6050
		[Tooltip("If enabled, the stick range will scale with parent controls. Otherwise, the stick range will remain constant.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _scaleStickRange = true;

		// Token: 0x040017A3 RID: 6051
		[Tooltip("The shape of the range of movement of the joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.StickBounds _stickBounds;

		// Token: 0x040017A4 RID: 6052
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.AxisDirection _axesToUse;

		// Token: 0x040017A5 RID: 6053
		[Tooltip("Snaps joystick movement to a fixed number of directions. This can be used to create a D-Pad, for example, setting it to 4 or 8 directions. If you want a true D-Pad, Stick Mode should be set to digital.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.SnapDirections _snapDirections;

		// Token: 0x040017A6 RID: 6054
		[Tooltip("If true, the stick disc will snap immediately to the touch position when initially touched. This results in the stick disc being centered to the touch position. This will cause the stick to generate input immediately when touched if not touched perfectly centered.If false, the stick disc will remain in its current position on touch, and when dragged will retain the same offset. The stick's center point will be set to the position of the touch. The initial touch will not cause the stick to pop in any direction.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _snapStickToTouch;

		// Token: 0x040017A7 RID: 6055
		[Tooltip("If true, the stick will return to the center after it is released. Otherwise, the stick will remain in the last position and continue to return input.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _centerStickOnRelease = true;

		// Token: 0x040017A8 RID: 6056
		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		// Token: 0x040017A9 RID: 6057
		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		// Token: 0x040017AA RID: 6058
		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		// Token: 0x040017AB RID: 6059
		[Tooltip("Should taps on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		// Token: 0x040017AC RID: 6060
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, 3.4028235E+38f)]
		private float _tapTimeout = 0.25f;

		// Token: 0x040017AD RID: 6061
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, 2147483647)]
		private int _tapDistanceLimit = 10;

		// Token: 0x040017AE RID: 6062
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the joystick's RectTransform. This can be useful if you want a larger area of the screen to act as a joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		// Token: 0x040017AF RID: 6063
		[Tooltip("If True, hovers/clicks/touches on the local joystick will be ignored and only Touch Region touches will be used. Otherwise, both touches on the joystick and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		// Token: 0x040017B0 RID: 6064
		[Tooltip("If True, the joystick will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a joystick and have the joystick graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		// Token: 0x040017B1 RID: 6065
		[Tooltip("If Move To Touch Position is enabled, this will make the joystick return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		// Token: 0x040017B2 RID: 6066
		[Tooltip("If True, the joystick will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		// Token: 0x040017B3 RID: 6067
		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		// Token: 0x040017B4 RID: 6068
		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		// Token: 0x040017B5 RID: 6069
		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		// Token: 0x040017B6 RID: 6070
		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		// Token: 0x040017B7 RID: 6071
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		// Token: 0x040017B8 RID: 6072
		private bool _useXAxis;

		// Token: 0x040017B9 RID: 6073
		private bool _useYAxis;

		// Token: 0x040017BA RID: 6074
		private XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<TouchJoystick.IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		// Token: 0x040017BB RID: 6075
		private XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<TouchJoystick.IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		// Token: 0x040017BC RID: 6076
		private TouchRegion _workingTouchRegion;

		// Token: 0x040017BD RID: 6077
		private Vector2 _origAnchoredPosition;

		// Token: 0x040017BE RID: 6078
		private Vector2 _origStickAnchoredPosition;

		// Token: 0x040017BF RID: 6079
		private Vector2 _lastPressAnchoredPosition;

		// Token: 0x040017C0 RID: 6080
		private bool _isMoving;

		// Token: 0x040017C1 RID: 6081
		private bool _isMovedFromDefaultPosition;

		// Token: 0x040017C2 RID: 6082
		private TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA _moveDirection;

		// Token: 0x040017C3 RID: 6083
		private int _pointerId = int.MinValue;

		// Token: 0x040017C4 RID: 6084
		private int _realMousePointerId = int.MinValue;

		// Token: 0x040017C5 RID: 6085
		[NonSerialized]
		private bool BQClJJeHAyUDDZqUBwHgVeToADnIA;

		// Token: 0x040017C6 RID: 6086
		[NonSerialized]
		private bool dwkrAWEnfPkLNLXmUCbcGHfpvKld;

		// Token: 0x040017C7 RID: 6087
		private bool _pointerDownIsFake;

		// Token: 0x040017C8 RID: 6088
		private Vector2 _lastPressStartingValue;

		// Token: 0x040017C9 RID: 6089
		private TouchJoystick.qfYZVUHgThVWdOsZzkmEPJEpngbi _lastClaimSource;

		// Token: 0x040017CA RID: 6090
		private float _touchStartTime;

		// Token: 0x040017CB RID: 6091
		private Vector2 _touchStartPosition;

		// Token: 0x040017CC RID: 6092
		private IEnumerator _coroutineMove;

		// Token: 0x040017CD RID: 6093
		private IhGVaSmWhHGFsLRYkATnDFHjoxNf _imageRaycastHelper = new IhGVaSmWhHGFsLRYkATnDFHjoxNf();

		// Token: 0x040017CE RID: 6094
		private int _calculatedStickRange_lastUpdatedFrame = -1;

		// Token: 0x040017CF RID: 6095
		private int _lastTapFrame = -1;

		// Token: 0x040017D0 RID: 6096
		private bool _isEligibleForTap;

		// Token: 0x040017D1 RID: 6097
		private float __calculatedStickRange_cachedValue;

		// Token: 0x040017D2 RID: 6098
		private Action<TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA> __moveStartedDelegate;

		// Token: 0x040017D3 RID: 6099
		private Action<TouchJoystick.vScXzBLRALavIkteSRtyVhQHbhQFA> __moveEndedDelegate;

		// Token: 0x040017D4 RID: 6100
		[Tooltip("Event sent when the joystick value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.ValueChangedEventHandler _onValueChanged = new TouchJoystick.ValueChangedEventHandler();

		// Token: 0x040017D5 RID: 6101
		[Tooltip("Event sent when the joystick's stick position changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.ValueChangedEventHandler _onStickPositionChanged = new TouchJoystick.ValueChangedEventHandler();

		// Token: 0x040017D6 RID: 6102
		[Tooltip("Event sent when the joystick is touched.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.TouchStartedEventHandler _onTouchStarted = new TouchJoystick.TouchStartedEventHandler();

		// Token: 0x040017D7 RID: 6103
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.TouchEndedEventHandler _onTouchEnded = new TouchJoystick.TouchEndedEventHandler();

		// Token: 0x040017D8 RID: 6104
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchJoystick.TapEventHandler _onTap = new TouchJoystick.TapEventHandler();

		// Token: 0x040017D9 RID: 6105
		private Dictionary<int, PointerEventData> __fakePointerEventData;

		// Token: 0x040017DA RID: 6106
		private static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchJoystick.IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		// Token: 0x040017DB RID: 6107
		private static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchJoystick.IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

		// Token: 0x020003FA RID: 1018
		public enum AxisDirection
		{
			// Token: 0x040017DD RID: 6109
			Both,
			// Token: 0x040017DE RID: 6110
			Horizontal,
			// Token: 0x040017DF RID: 6111
			Vertical
		}

		// Token: 0x020003FB RID: 1019
		public enum JoystickMode
		{
			// Token: 0x040017E1 RID: 6113
			Analog,
			// Token: 0x040017E2 RID: 6114
			Digital
		}

		// Token: 0x020003FC RID: 1020
		public enum SnapDirections
		{
			// Token: 0x040017E4 RID: 6116
			None,
			// Token: 0x040017E5 RID: 6117
			Four = 4,
			// Token: 0x040017E6 RID: 6118
			Eight = 8,
			// Token: 0x040017E7 RID: 6119
			Sixteen = 16,
			// Token: 0x040017E8 RID: 6120
			ThirtyTwo = 32,
			// Token: 0x040017E9 RID: 6121
			SixtyFour = 64
		}

		// Token: 0x020003FD RID: 1021
		private enum vScXzBLRALavIkteSRtyVhQHbhQFA
		{
			// Token: 0x040017EB RID: 6123
			None,
			// Token: 0x040017EC RID: 6124
			TowardTouch,
			// Token: 0x040017ED RID: 6125
			TowardHome
		}

		// Token: 0x020003FE RID: 1022
		private enum qfYZVUHgThVWdOsZzkmEPJEpngbi
		{
			// Token: 0x040017EF RID: 6127
			Local,
			// Token: 0x040017F0 RID: 6128
			TouchRegion
		}

		// Token: 0x020003FF RID: 1023
		public enum StickBounds
		{
			// Token: 0x040017F2 RID: 6130
			Circle,
			// Token: 0x040017F3 RID: 6131
			Square
		}

		// Token: 0x02000400 RID: 1024
		[Serializable]
		public class ValueChangedEventHandler : UnityEvent<Vector2>
		{
		}

		// Token: 0x02000401 RID: 1025
		[Serializable]
		public class StickPositionChangedEventHandler : UnityEvent<Vector2>
		{
		}

		// Token: 0x02000402 RID: 1026
		[Serializable]
		public class TapEventHandler : UnityEvent
		{
		}

		// Token: 0x02000403 RID: 1027
		[Serializable]
		public class TouchStartedEventHandler : UnityEvent
		{
		}

		// Token: 0x02000404 RID: 1028
		[Serializable]
		public class TouchEndedEventHandler : UnityEvent
		{
		}

		// Token: 0x02000405 RID: 1029
		public interface IValueChangedHandler
		{
			// Token: 0x06002998 RID: 10648
			void OnValueChanged(Vector2 value);
		}

		// Token: 0x02000406 RID: 1030
		public interface IStickPositionChangedHandler
		{
			// Token: 0x06002999 RID: 10649
			void OnStickPositionChanged(Vector2 value);
		}

		// Token: 0x02000407 RID: 1031
		[CompilerGenerated]
		[Serializable]
		private sealed class VNdqIicbjVROeLQZbpLCRmjuvtMX
		{
			// Token: 0x0600299C RID: 10652 RVA: 0x0001FD89 File Offset: 0x0001DF89
			internal void TzKDOxilQDFqwIpbXtdyiFjFdpgQA(TouchJoystick.IValueChangedHandler A_1, Vector2 A_2)
			{
				A_1.OnValueChanged(A_2);
			}

			// Token: 0x0600299D RID: 10653 RVA: 0x0001FD92 File Offset: 0x0001DF92
			internal void jPJFOqFlbZYoksgsyasAQNgsgdEB(TouchJoystick.IStickPositionChangedHandler A_1, Vector2 A_2)
			{
				A_1.OnStickPositionChanged(A_2);
			}

			// Token: 0x040017F4 RID: 6132
			public static readonly TouchJoystick.VNdqIicbjVROeLQZbpLCRmjuvtMX <>9 = new TouchJoystick.VNdqIicbjVROeLQZbpLCRmjuvtMX();

			// Token: 0x040017F5 RID: 6133
			public static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchJoystick.IValueChangedHandler, Vector2> <>9__277_0;

			// Token: 0x040017F6 RID: 6134
			public static XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<TouchJoystick.IStickPositionChangedHandler, Vector2> <>9__280_0;
		}
	}
}
