using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000219 RID: 537
	[EventCategory(EventCategory.Pointer)]
	public abstract class PointerEventBase<T> : EventBase<T>, IPointerEvent, IPointerEventInternal where T : PointerEventBase<T>, new()
	{
		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x0003962C File Offset: 0x0003782C
		// (set) Token: 0x06000F92 RID: 3986 RVA: 0x00039634 File Offset: 0x00037834
		public int pointerId { get; protected set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x0003963D File Offset: 0x0003783D
		// (set) Token: 0x06000F94 RID: 3988 RVA: 0x00039645 File Offset: 0x00037845
		public string pointerType { get; protected set; }

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x0003964E File Offset: 0x0003784E
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x00039656 File Offset: 0x00037856
		public bool isPrimary { get; protected set; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000F97 RID: 3991 RVA: 0x0003965F File Offset: 0x0003785F
		// (set) Token: 0x06000F98 RID: 3992 RVA: 0x00039667 File Offset: 0x00037867
		public int button { get; protected set; }

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000F99 RID: 3993 RVA: 0x00039670 File Offset: 0x00037870
		// (set) Token: 0x06000F9A RID: 3994 RVA: 0x00039678 File Offset: 0x00037878
		public int pressedButtons { get; protected set; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000F9B RID: 3995 RVA: 0x00039681 File Offset: 0x00037881
		// (set) Token: 0x06000F9C RID: 3996 RVA: 0x00039689 File Offset: 0x00037889
		public Vector3 position { get; protected set; }

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000F9D RID: 3997 RVA: 0x00039692 File Offset: 0x00037892
		// (set) Token: 0x06000F9E RID: 3998 RVA: 0x0003969A File Offset: 0x0003789A
		public Vector3 localPosition { get; protected set; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000F9F RID: 3999 RVA: 0x000396A3 File Offset: 0x000378A3
		// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x000396AB File Offset: 0x000378AB
		public Vector3 deltaPosition { get; protected set; }

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x000396B4 File Offset: 0x000378B4
		// (set) Token: 0x06000FA2 RID: 4002 RVA: 0x000396BC File Offset: 0x000378BC
		public float deltaTime { get; protected set; }

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x000396C5 File Offset: 0x000378C5
		// (set) Token: 0x06000FA4 RID: 4004 RVA: 0x000396CD File Offset: 0x000378CD
		public int clickCount { get; protected set; }

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000FA5 RID: 4005 RVA: 0x000396D6 File Offset: 0x000378D6
		// (set) Token: 0x06000FA6 RID: 4006 RVA: 0x000396DE File Offset: 0x000378DE
		public float pressure { get; protected set; }

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000FA7 RID: 4007 RVA: 0x000396E7 File Offset: 0x000378E7
		// (set) Token: 0x06000FA8 RID: 4008 RVA: 0x000396EF File Offset: 0x000378EF
		public float tangentialPressure { get; protected set; }

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000FA9 RID: 4009 RVA: 0x000396F8 File Offset: 0x000378F8
		// (set) Token: 0x06000FAA RID: 4010 RVA: 0x00039734 File Offset: 0x00037934
		public float altitudeAngle
		{
			get
			{
				bool altitudeNeedsConversion = this.m_AltitudeNeedsConversion;
				if (altitudeNeedsConversion)
				{
					this.m_AltitudeAngle = PointerEventBase<T>.TiltToAltitude(this.tilt);
					this.m_AltitudeNeedsConversion = false;
				}
				return this.m_AltitudeAngle;
			}
			protected set
			{
				this.m_AltitudeNeedsConversion = true;
				this.m_AltitudeAngle = value;
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000FAB RID: 4011 RVA: 0x00039748 File Offset: 0x00037948
		// (set) Token: 0x06000FAC RID: 4012 RVA: 0x00039784 File Offset: 0x00037984
		public float azimuthAngle
		{
			get
			{
				bool azimuthNeedsConversion = this.m_AzimuthNeedsConversion;
				if (azimuthNeedsConversion)
				{
					this.m_AzimuthAngle = PointerEventBase<T>.TiltToAzimuth(this.tilt);
					this.m_AzimuthNeedsConversion = false;
				}
				return this.m_AzimuthAngle;
			}
			protected set
			{
				this.m_AzimuthNeedsConversion = true;
				this.m_AzimuthAngle = value;
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000FAD RID: 4013 RVA: 0x00039795 File Offset: 0x00037995
		// (set) Token: 0x06000FAE RID: 4014 RVA: 0x0003979D File Offset: 0x0003799D
		public float twist { get; protected set; }

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000FAF RID: 4015 RVA: 0x000397A8 File Offset: 0x000379A8
		// (set) Token: 0x06000FB0 RID: 4016 RVA: 0x0003980F File Offset: 0x00037A0F
		public Vector2 tilt
		{
			get
			{
				bool flag = Application.platform != RuntimePlatform.WindowsEditor && Application.platform != RuntimePlatform.WindowsPlayer && this.pointerType == PointerType.touch && this.m_TiltNeeded;
				if (flag)
				{
					this.m_Tilt = PointerEventBase<T>.AzimuthAndAlitutudeToTilt(this.m_AltitudeAngle, this.m_AzimuthAngle);
					this.m_TiltNeeded = false;
				}
				return this.m_Tilt;
			}
			protected set
			{
				this.m_TiltNeeded = true;
				this.m_Tilt = value;
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000FB1 RID: 4017 RVA: 0x00039820 File Offset: 0x00037A20
		// (set) Token: 0x06000FB2 RID: 4018 RVA: 0x00039828 File Offset: 0x00037A28
		public PenStatus penStatus { get; protected set; }

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x00039831 File Offset: 0x00037A31
		// (set) Token: 0x06000FB4 RID: 4020 RVA: 0x00039839 File Offset: 0x00037A39
		public Vector2 radius { get; protected set; }

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x00039842 File Offset: 0x00037A42
		// (set) Token: 0x06000FB6 RID: 4022 RVA: 0x0003984A File Offset: 0x00037A4A
		public Vector2 radiusVariance { get; protected set; }

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x00039853 File Offset: 0x00037A53
		// (set) Token: 0x06000FB8 RID: 4024 RVA: 0x0003985B File Offset: 0x00037A5B
		public EventModifiers modifiers { get; protected set; }

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000FB9 RID: 4025 RVA: 0x00039864 File Offset: 0x00037A64
		public bool shiftKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Shift) > EventModifiers.None;
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000FBA RID: 4026 RVA: 0x00039884 File Offset: 0x00037A84
		public bool ctrlKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Control) > EventModifiers.None;
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000FBB RID: 4027 RVA: 0x000398A4 File Offset: 0x00037AA4
		public bool commandKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Command) > EventModifiers.None;
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000FBC RID: 4028 RVA: 0x000398C4 File Offset: 0x00037AC4
		public bool altKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Alt) > EventModifiers.None;
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000FBD RID: 4029 RVA: 0x000398E4 File Offset: 0x00037AE4
		public bool actionKey
		{
			get
			{
				bool flag = Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
				bool result;
				if (flag)
				{
					result = this.commandKey;
				}
				else
				{
					result = this.ctrlKey;
				}
				return result;
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000FBE RID: 4030 RVA: 0x0003991D File Offset: 0x00037B1D
		// (set) Token: 0x06000FBF RID: 4031 RVA: 0x00039925 File Offset: 0x00037B25
		bool IPointerEventInternal.triggeredByOS { get; set; }

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000FC0 RID: 4032 RVA: 0x0003992E File Offset: 0x00037B2E
		// (set) Token: 0x06000FC1 RID: 4033 RVA: 0x00039936 File Offset: 0x00037B36
		bool IPointerEventInternal.recomputeTopElementUnderPointer { get; set; }

		// Token: 0x06000FC2 RID: 4034 RVA: 0x0003993F File Offset: 0x00037B3F
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x00039950 File Offset: 0x00037B50
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable);
			base.propagateToIMGUI = false;
			this.pointerId = 0;
			this.pointerType = PointerType.unknown;
			this.isPrimary = false;
			this.button = -1;
			this.pressedButtons = 0;
			this.position = Vector3.zero;
			this.localPosition = Vector3.zero;
			this.deltaPosition = Vector3.zero;
			this.deltaTime = 0f;
			this.clickCount = 0;
			this.pressure = 0f;
			this.tangentialPressure = 0f;
			this.altitudeAngle = 0f;
			this.azimuthAngle = 0f;
			this.tilt = new Vector2(0f, 0f);
			this.twist = 0f;
			this.penStatus = PenStatus.None;
			this.radius = Vector2.zero;
			this.radiusVariance = Vector2.zero;
			this.modifiers = EventModifiers.None;
			((IPointerEventInternal)this).triggeredByOS = false;
			((IPointerEventInternal)this).recomputeTopElementUnderPointer = false;
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x00039A5C File Offset: 0x00037C5C
		// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x00039A74 File Offset: 0x00037C74
		public override IEventHandler currentTarget
		{
			get
			{
				return base.currentTarget;
			}
			internal set
			{
				base.currentTarget = value;
				VisualElement visualElement = this.currentTarget as VisualElement;
				bool flag = visualElement != null;
				if (flag)
				{
					this.localPosition = visualElement.WorldToLocal(this.position);
				}
				else
				{
					this.localPosition = this.position;
				}
			}
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x00039AD0 File Offset: 0x00037CD0
		private static bool IsMouse(Event systemEvent)
		{
			EventType rawType = systemEvent.rawType;
			return rawType == EventType.MouseMove || rawType == EventType.MouseDown || rawType == EventType.MouseUp || rawType == EventType.MouseDrag || rawType == EventType.ContextClick || rawType == EventType.MouseEnterWindow || rawType == EventType.MouseLeaveWindow;
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x00039B0C File Offset: 0x00037D0C
		private static bool IsTouch(Event systemEvent)
		{
			EventType rawType = systemEvent.rawType;
			return rawType == EventType.TouchMove || rawType == EventType.TouchDown || rawType == EventType.TouchUp || rawType == EventType.TouchStationary || rawType == EventType.TouchEnter || rawType == EventType.TouchLeave;
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x00039B48 File Offset: 0x00037D48
		private static float TiltToAzimuth(Vector2 tilt)
		{
			float num = 0f;
			bool flag = tilt.x != 0f;
			if (flag)
			{
				num = 1.5707964f - Mathf.Atan2(-Mathf.Cos(tilt.x) * Mathf.Sin(tilt.y), Mathf.Cos(tilt.y) * Mathf.Sin(tilt.x));
				bool flag2 = num < 0f;
				if (flag2)
				{
					num += 6.2831855f;
				}
				bool flag3 = num >= 1.5707964f;
				if (flag3)
				{
					num -= 1.5707964f;
				}
				else
				{
					num += 4.712389f;
				}
			}
			return num;
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x00039BEC File Offset: 0x00037DEC
		private static Vector2 AzimuthAndAlitutudeToTilt(float altitude, float azimuth)
		{
			return new Vector2(0f, 0f)
			{
				x = Mathf.Atan(Mathf.Cos(azimuth) * Mathf.Cos(altitude) / Mathf.Sin(azimuth)),
				y = Mathf.Atan(Mathf.Cos(azimuth) * Mathf.Sin(altitude) / Mathf.Sin(azimuth))
			};
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x00039C50 File Offset: 0x00037E50
		private static float TiltToAltitude(Vector2 tilt)
		{
			return 1.5707964f - Mathf.Acos(Mathf.Cos(tilt.x) * Mathf.Cos(tilt.y));
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x00039C84 File Offset: 0x00037E84
		public static T GetPooled(Event systemEvent)
		{
			T pooled = EventBase<T>.GetPooled();
			bool flag = !PointerEventBase<T>.IsMouse(systemEvent) && !PointerEventBase<T>.IsTouch(systemEvent) && systemEvent.rawType != EventType.DragUpdated;
			if (flag)
			{
				Debug.Assert(false, string.Concat(new string[]
				{
					"Unexpected event type: ",
					systemEvent.rawType.ToString(),
					" (",
					systemEvent.type.ToString(),
					")"
				}));
			}
			PointerType pointerType = systemEvent.pointerType;
			PointerType pointerType2 = pointerType;
			if (pointerType2 != PointerType.Touch)
			{
				if (pointerType2 != PointerType.Pen)
				{
					pooled.pointerType = PointerType.mouse;
					pooled.pointerId = PointerId.mousePointerId;
				}
				else
				{
					pooled.pointerType = PointerType.pen;
					pooled.pointerId = PointerId.penPointerIdBase;
					bool flag2 = systemEvent.penStatus == PenStatus.Barrel;
					if (flag2)
					{
						PointerDeviceState.PressButton(pooled.pointerId, 1);
					}
					else
					{
						PointerDeviceState.ReleaseButton(pooled.pointerId, 1);
					}
					bool flag3 = systemEvent.penStatus == PenStatus.Eraser;
					if (flag3)
					{
						PointerDeviceState.PressButton(pooled.pointerId, 5);
					}
					else
					{
						PointerDeviceState.ReleaseButton(pooled.pointerId, 5);
					}
				}
			}
			else
			{
				pooled.pointerType = PointerType.touch;
				pooled.pointerId = PointerId.touchPointerIdBase;
			}
			pooled.isPrimary = true;
			pooled.altitudeAngle = 0f;
			pooled.azimuthAngle = 0f;
			pooled.radius = Vector2.zero;
			pooled.radiusVariance = Vector2.zero;
			pooled.imguiEvent = systemEvent;
			bool flag4 = systemEvent.rawType == EventType.MouseDown || systemEvent.rawType == EventType.TouchDown;
			if (flag4)
			{
				PointerDeviceState.PressButton(pooled.pointerId, systemEvent.button);
				pooled.button = systemEvent.button;
			}
			else
			{
				bool flag5 = systemEvent.rawType == EventType.MouseUp || systemEvent.rawType == EventType.TouchUp;
				if (flag5)
				{
					PointerDeviceState.ReleaseButton(pooled.pointerId, systemEvent.button);
					pooled.button = systemEvent.button;
				}
				else
				{
					bool flag6 = systemEvent.rawType == EventType.MouseMove || systemEvent.rawType == EventType.TouchMove;
					if (flag6)
					{
						pooled.button = -1;
					}
				}
			}
			pooled.pressedButtons = PointerDeviceState.GetPressedButtons(pooled.pointerId);
			pooled.position = systemEvent.mousePosition;
			pooled.localPosition = systemEvent.mousePosition;
			pooled.deltaPosition = systemEvent.delta;
			pooled.clickCount = systemEvent.clickCount;
			pooled.modifiers = systemEvent.modifiers;
			pooled.tilt = systemEvent.tilt;
			pooled.penStatus = systemEvent.penStatus;
			pooled.twist = systemEvent.twist;
			PointerType pointerType3 = systemEvent.pointerType;
			PointerType pointerType4 = pointerType3;
			if (pointerType4 != PointerType.Touch)
			{
				if (pointerType4 != PointerType.Pen)
				{
					pooled.pressure = ((pooled.pressedButtons == 0) ? 0f : 0.5f);
				}
				else
				{
					pooled.pressure = systemEvent.pressure;
				}
			}
			else
			{
				pooled.pressure = systemEvent.pressure;
			}
			pooled.tangentialPressure = 0f;
			pooled.triggeredByOS = true;
			return pooled;
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0003A06C File Offset: 0x0003826C
		internal static T GetPooled(EventType eventType, Vector3 mousePosition, Vector2 delta, int button, int clickCount, EventModifiers modifiers)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.pointerId = PointerId.mousePointerId;
			pooled.pointerType = PointerType.mouse;
			pooled.isPrimary = true;
			bool flag = eventType == EventType.MouseDown;
			if (flag)
			{
				PointerDeviceState.PressButton(pooled.pointerId, button);
				pooled.button = button;
			}
			else
			{
				bool flag2 = eventType == EventType.MouseUp;
				if (flag2)
				{
					PointerDeviceState.ReleaseButton(pooled.pointerId, button);
					pooled.button = button;
				}
				else
				{
					pooled.button = -1;
				}
			}
			pooled.pressedButtons = PointerDeviceState.GetPressedButtons(pooled.pointerId);
			pooled.position = mousePosition;
			pooled.localPosition = mousePosition;
			pooled.deltaPosition = delta;
			pooled.clickCount = clickCount;
			pooled.modifiers = modifiers;
			pooled.pressure = ((pooled.pressedButtons == 0) ? 0f : 0.5f);
			pooled.triggeredByOS = true;
			return pooled;
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x0003A1B0 File Offset: 0x000383B0
		public static T GetPooled(Touch touch, EventModifiers modifiers = EventModifiers.None)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.pointerId = touch.fingerId + PointerId.touchPointerIdBase;
			pooled.pointerType = PointerType.touch;
			bool flag = false;
			for (int i = PointerId.touchPointerIdBase; i < PointerId.touchPointerIdBase + PointerId.touchPointerCount; i++)
			{
				bool flag2 = i != pooled.pointerId && PointerDeviceState.GetPressedButtons(i) != 0;
				if (flag2)
				{
					flag = true;
					break;
				}
			}
			pooled.isPrimary = !flag;
			bool flag3 = touch.phase == TouchPhase.Began;
			if (flag3)
			{
				PointerDeviceState.PressButton(pooled.pointerId, 0);
				pooled.button = 0;
			}
			else
			{
				bool flag4 = touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled;
				if (flag4)
				{
					PointerDeviceState.ReleaseButton(pooled.pointerId, 0);
					pooled.button = 0;
				}
				else
				{
					pooled.button = -1;
				}
			}
			pooled.pressedButtons = PointerDeviceState.GetPressedButtons(pooled.pointerId);
			pooled.position = touch.position;
			pooled.localPosition = touch.position;
			pooled.deltaPosition = touch.deltaPosition;
			pooled.deltaTime = touch.deltaTime;
			pooled.clickCount = touch.tapCount;
			pooled.pressure = ((Mathf.Abs(touch.maximumPossiblePressure) > 1E-30f) ? (touch.pressure / touch.maximumPossiblePressure) : 1f);
			pooled.tangentialPressure = 0f;
			pooled.altitudeAngle = touch.altitudeAngle;
			pooled.azimuthAngle = touch.azimuthAngle;
			pooled.twist = 0f;
			pooled.tilt = new Vector2(0f, 0f);
			pooled.penStatus = PenStatus.None;
			pooled.radius = new Vector2(touch.radius, touch.radius);
			pooled.radiusVariance = new Vector2(touch.radiusVariance, touch.radiusVariance);
			pooled.modifiers = modifiers;
			pooled.triggeredByOS = true;
			return pooled;
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x0003A458 File Offset: 0x00038658
		public static T GetPooled(PenData pen, EventModifiers modifiers = EventModifiers.None)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.pointerId = PointerId.penPointerIdBase;
			pooled.pointerType = PointerType.pen;
			pooled.isPrimary = true;
			bool flag = pen.contactType == PenEventType.PenDown;
			if (flag)
			{
				PointerDeviceState.PressButton(pooled.pointerId, 0);
				pooled.button = 0;
			}
			else
			{
				bool flag2 = pen.contactType == PenEventType.PenUp;
				if (flag2)
				{
					PointerDeviceState.ReleaseButton(pooled.pointerId, 0);
					pooled.button = 0;
				}
				else
				{
					pooled.button = -1;
				}
			}
			bool flag3 = pen.penStatus == PenStatus.Barrel;
			if (flag3)
			{
				PointerDeviceState.PressButton(pooled.pointerId, 1);
			}
			else
			{
				PointerDeviceState.ReleaseButton(pooled.pointerId, 1);
			}
			bool flag4 = pen.penStatus == PenStatus.Eraser;
			if (flag4)
			{
				PointerDeviceState.PressButton(pooled.pointerId, 5);
			}
			else
			{
				PointerDeviceState.ReleaseButton(pooled.pointerId, 5);
			}
			pooled.pressedButtons = PointerDeviceState.GetPressedButtons(pooled.pointerId);
			pooled.position = pen.position;
			pooled.localPosition = pen.position;
			pooled.deltaPosition = pen.deltaPos;
			pooled.clickCount = 0;
			pooled.pressure = pen.pressure;
			pooled.tangentialPressure = 0f;
			pooled.twist = pen.twist;
			pooled.tilt = pen.tilt;
			pooled.penStatus = pen.penStatus;
			pooled.radius = Vector2.zero;
			pooled.radiusVariance = Vector2.zero;
			pooled.modifiers = modifiers;
			pooled.triggeredByOS = true;
			return pooled;
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x0003A67C File Offset: 0x0003887C
		internal static T GetPooled(IPointerEvent triggerEvent, Vector2 position, int pointerId)
		{
			bool flag = triggerEvent != null;
			T result;
			if (flag)
			{
				result = PointerEventBase<T>.GetPooled(triggerEvent);
			}
			else
			{
				T pooled = EventBase<T>.GetPooled();
				pooled.position = position;
				pooled.localPosition = position;
				pooled.pointerId = pointerId;
				pooled.pointerType = PointerType.GetPointerType(pointerId);
				result = pooled;
			}
			return result;
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x0003A6EC File Offset: 0x000388EC
		public static T GetPooled(IPointerEvent triggerEvent)
		{
			T pooled = EventBase<T>.GetPooled();
			bool flag = triggerEvent != null;
			if (flag)
			{
				pooled.pointerId = triggerEvent.pointerId;
				pooled.pointerType = triggerEvent.pointerType;
				pooled.isPrimary = triggerEvent.isPrimary;
				pooled.button = triggerEvent.button;
				pooled.pressedButtons = triggerEvent.pressedButtons;
				pooled.position = triggerEvent.position;
				pooled.localPosition = triggerEvent.localPosition;
				pooled.deltaPosition = triggerEvent.deltaPosition;
				pooled.deltaTime = triggerEvent.deltaTime;
				pooled.clickCount = triggerEvent.clickCount;
				pooled.pressure = triggerEvent.pressure;
				pooled.tangentialPressure = triggerEvent.tangentialPressure;
				pooled.altitudeAngle = triggerEvent.altitudeAngle;
				pooled.azimuthAngle = triggerEvent.azimuthAngle;
				pooled.twist = triggerEvent.twist;
				pooled.tilt = triggerEvent.tilt;
				pooled.penStatus = triggerEvent.penStatus;
				pooled.radius = triggerEvent.radius;
				pooled.radiusVariance = triggerEvent.radiusVariance;
				pooled.modifiers = triggerEvent.modifiers;
				IPointerEventInternal pointerEventInternal = triggerEvent as IPointerEventInternal;
				bool flag2 = pointerEventInternal != null;
				if (flag2)
				{
					pooled.triggeredByOS |= pointerEventInternal.triggeredByOS;
				}
			}
			return pooled;
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x0003A8A8 File Offset: 0x00038AA8
		protected internal override void PreDispatch(IPanel panel)
		{
			base.PreDispatch(panel);
			bool triggeredByOS = ((IPointerEventInternal)this).triggeredByOS;
			if (triggeredByOS)
			{
				PointerDeviceState.SavePointerPosition(this.pointerId, this.position, panel, panel.contextType);
			}
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x0003A8E8 File Offset: 0x00038AE8
		protected internal override void PostDispatch(IPanel panel)
		{
			for (int i = 0; i < PointerId.maxPointers; i++)
			{
				panel.ProcessPointerCapture(i);
			}
			bool flag = !panel.ShouldSendCompatibilityMouseEvents(this) && ((IPointerEventInternal)this).triggeredByOS;
			if (flag)
			{
				BaseVisualElementPanel baseVisualElementPanel = panel as BaseVisualElementPanel;
				if (baseVisualElementPanel != null)
				{
					baseVisualElementPanel.CommitElementUnderPointers();
				}
			}
			base.PostDispatch(panel);
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x0003A948 File Offset: 0x00038B48
		protected PointerEventBase()
		{
			this.LocalInit();
		}

		// Token: 0x040006FE RID: 1790
		private const float k_DefaultButtonPressure = 0.5f;

		// Token: 0x040006FF RID: 1791
		private bool m_AltitudeNeedsConversion = true;

		// Token: 0x04000700 RID: 1792
		private bool m_AzimuthNeedsConversion = true;

		// Token: 0x04000701 RID: 1793
		private float m_AltitudeAngle = 0f;

		// Token: 0x04000702 RID: 1794
		private float m_AzimuthAngle = 0f;

		// Token: 0x04000703 RID: 1795
		private bool m_TiltNeeded = true;

		// Token: 0x04000704 RID: 1796
		private Vector2 m_Tilt = new Vector2(0f, 0f);
	}
}
