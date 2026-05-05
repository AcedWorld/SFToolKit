using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001E3 RID: 483
	[EventCategory(EventCategory.Pointer)]
	public abstract class MouseEventBase<T> : EventBase<T>, IMouseEvent, IMouseEventInternal where T : MouseEventBase<T>, new()
	{
		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000E7A RID: 3706 RVA: 0x00037395 File Offset: 0x00035595
		// (set) Token: 0x06000E7B RID: 3707 RVA: 0x0003739D File Offset: 0x0003559D
		public EventModifiers modifiers { get; protected set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x000373A6 File Offset: 0x000355A6
		// (set) Token: 0x06000E7D RID: 3709 RVA: 0x000373AE File Offset: 0x000355AE
		public Vector2 mousePosition { get; protected set; }

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x000373B7 File Offset: 0x000355B7
		// (set) Token: 0x06000E7F RID: 3711 RVA: 0x000373BF File Offset: 0x000355BF
		public Vector2 localMousePosition { get; internal set; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x000373C8 File Offset: 0x000355C8
		// (set) Token: 0x06000E81 RID: 3713 RVA: 0x000373D0 File Offset: 0x000355D0
		public Vector2 mouseDelta { get; protected set; }

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x000373D9 File Offset: 0x000355D9
		// (set) Token: 0x06000E83 RID: 3715 RVA: 0x000373E1 File Offset: 0x000355E1
		public int clickCount { get; protected set; }

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000E84 RID: 3716 RVA: 0x000373EA File Offset: 0x000355EA
		// (set) Token: 0x06000E85 RID: 3717 RVA: 0x000373F2 File Offset: 0x000355F2
		public int button { get; protected set; }

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000E86 RID: 3718 RVA: 0x000373FB File Offset: 0x000355FB
		// (set) Token: 0x06000E87 RID: 3719 RVA: 0x00037403 File Offset: 0x00035603
		public int pressedButtons { get; protected set; }

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000E88 RID: 3720 RVA: 0x0003740C File Offset: 0x0003560C
		public bool shiftKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Shift) > EventModifiers.None;
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000E89 RID: 3721 RVA: 0x0003742C File Offset: 0x0003562C
		public bool ctrlKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Control) > EventModifiers.None;
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x0003744C File Offset: 0x0003564C
		public bool commandKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Command) > EventModifiers.None;
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000E8B RID: 3723 RVA: 0x0003746C File Offset: 0x0003566C
		public bool altKey
		{
			get
			{
				return (this.modifiers & EventModifiers.Alt) > EventModifiers.None;
			}
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x0003748C File Offset: 0x0003568C
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

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000E8D RID: 3725 RVA: 0x000374C5 File Offset: 0x000356C5
		// (set) Token: 0x06000E8E RID: 3726 RVA: 0x000374CD File Offset: 0x000356CD
		bool IMouseEventInternal.triggeredByOS { get; set; }

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000E8F RID: 3727 RVA: 0x000374D6 File Offset: 0x000356D6
		// (set) Token: 0x06000E90 RID: 3728 RVA: 0x000374DE File Offset: 0x000356DE
		bool IMouseEventInternal.recomputeTopElementUnderMouse { get; set; }

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000E91 RID: 3729 RVA: 0x000374E7 File Offset: 0x000356E7
		// (set) Token: 0x06000E92 RID: 3730 RVA: 0x000374EF File Offset: 0x000356EF
		IPointerEvent IMouseEventInternal.sourcePointerEvent { get; set; }

		// Token: 0x06000E93 RID: 3731 RVA: 0x000374F8 File Offset: 0x000356F8
		protected override void Init()
		{
			base.Init();
			this.LocalInit();
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x0003750C File Offset: 0x0003570C
		private void LocalInit()
		{
			base.propagation = (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown | EventBase.EventPropagation.Cancellable);
			this.modifiers = EventModifiers.None;
			this.mousePosition = Vector2.zero;
			this.localMousePosition = Vector2.zero;
			this.mouseDelta = Vector2.zero;
			this.clickCount = 0;
			this.button = 0;
			this.pressedButtons = 0;
			((IMouseEventInternal)this).triggeredByOS = false;
			((IMouseEventInternal)this).recomputeTopElementUnderMouse = true;
			((IMouseEventInternal)this).sourcePointerEvent = null;
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x00037580 File Offset: 0x00035780
		// (set) Token: 0x06000E96 RID: 3734 RVA: 0x00037598 File Offset: 0x00035798
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
					this.localMousePosition = visualElement.WorldToLocal(this.mousePosition);
				}
				else
				{
					this.localMousePosition = this.mousePosition;
				}
			}
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x000375E8 File Offset: 0x000357E8
		protected internal override void PreDispatch(IPanel panel)
		{
			base.PreDispatch(panel);
			bool triggeredByOS = ((IMouseEventInternal)this).triggeredByOS;
			if (triggeredByOS)
			{
				PointerDeviceState.SavePointerPosition(PointerId.mousePointerId, this.mousePosition, panel, panel.contextType);
			}
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00037624 File Offset: 0x00035824
		protected internal override void PostDispatch(IPanel panel)
		{
			EventBase eventBase = ((IMouseEventInternal)this).sourcePointerEvent as EventBase;
			bool flag = eventBase != null;
			if (flag)
			{
				Debug.Assert(eventBase.processed);
				BaseVisualElementPanel baseVisualElementPanel = panel as BaseVisualElementPanel;
				if (baseVisualElementPanel != null)
				{
					baseVisualElementPanel.CommitElementUnderPointers();
				}
				bool isPropagationStopped = base.isPropagationStopped;
				if (isPropagationStopped)
				{
					eventBase.StopPropagation();
				}
				bool isImmediatePropagationStopped = base.isImmediatePropagationStopped;
				if (isImmediatePropagationStopped)
				{
					eventBase.StopImmediatePropagation();
				}
				bool isDefaultPrevented = base.isDefaultPrevented;
				if (isDefaultPrevented)
				{
					eventBase.PreventDefault();
				}
				eventBase.processedByFocusController |= base.processedByFocusController;
			}
			base.PostDispatch(panel);
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x000376C0 File Offset: 0x000358C0
		public static T GetPooled(Event systemEvent)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.imguiEvent = systemEvent;
			bool flag = systemEvent != null;
			if (flag)
			{
				pooled.modifiers = systemEvent.modifiers;
				pooled.mousePosition = systemEvent.mousePosition;
				pooled.localMousePosition = systemEvent.mousePosition;
				pooled.mouseDelta = systemEvent.delta;
				pooled.button = systemEvent.button;
				pooled.pressedButtons = PointerDeviceState.GetPressedButtons(PointerId.mousePointerId);
				pooled.clickCount = systemEvent.clickCount;
				pooled.triggeredByOS = true;
				pooled.recomputeTopElementUnderMouse = true;
			}
			return pooled;
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x00037790 File Offset: 0x00035990
		public static T GetPooled(Vector2 position, int button, int clickCount, Vector2 delta, EventModifiers modifiers = EventModifiers.None)
		{
			return MouseEventBase<T>.GetPooled(position, button, clickCount, delta, modifiers, false);
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x000377B0 File Offset: 0x000359B0
		internal static T GetPooled(Vector2 position, int button, int clickCount, Vector2 delta, EventModifiers modifiers, bool fromOS)
		{
			T pooled = EventBase<T>.GetPooled();
			pooled.modifiers = modifiers;
			pooled.mousePosition = position;
			pooled.localMousePosition = position;
			pooled.mouseDelta = delta;
			pooled.button = button;
			pooled.pressedButtons = PointerDeviceState.GetPressedButtons(PointerId.mousePointerId);
			pooled.clickCount = clickCount;
			pooled.triggeredByOS = fromOS;
			pooled.recomputeTopElementUnderMouse = true;
			return pooled;
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x0003784C File Offset: 0x00035A4C
		internal static T GetPooled(IMouseEvent triggerEvent, Vector2 mousePosition, bool recomputeTopElementUnderMouse)
		{
			bool flag = triggerEvent != null;
			T result;
			if (flag)
			{
				result = MouseEventBase<T>.GetPooled(triggerEvent);
			}
			else
			{
				T pooled = EventBase<T>.GetPooled();
				pooled.mousePosition = mousePosition;
				pooled.localMousePosition = mousePosition;
				pooled.recomputeTopElementUnderMouse = recomputeTopElementUnderMouse;
				result = pooled;
			}
			return result;
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x000378A0 File Offset: 0x00035AA0
		public static T GetPooled(IMouseEvent triggerEvent)
		{
			T pooled = EventBase<T>.GetPooled(triggerEvent as EventBase);
			bool flag = triggerEvent != null;
			if (flag)
			{
				pooled.modifiers = triggerEvent.modifiers;
				pooled.mousePosition = triggerEvent.mousePosition;
				pooled.localMousePosition = triggerEvent.mousePosition;
				pooled.mouseDelta = triggerEvent.mouseDelta;
				pooled.button = triggerEvent.button;
				pooled.pressedButtons = triggerEvent.pressedButtons;
				pooled.clickCount = triggerEvent.clickCount;
				IMouseEventInternal mouseEventInternal = triggerEvent as IMouseEventInternal;
				bool flag2 = mouseEventInternal != null;
				if (flag2)
				{
					pooled.triggeredByOS = mouseEventInternal.triggeredByOS;
					pooled.recomputeTopElementUnderMouse = false;
				}
			}
			return pooled;
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x0003797C File Offset: 0x00035B7C
		protected static T GetPooled(IPointerEvent pointerEvent)
		{
			T pooled = EventBase<T>.GetPooled();
			EventBase eventBase = pooled;
			EventBase eventBase2 = pointerEvent as EventBase;
			eventBase.target = ((eventBase2 != null) ? eventBase2.target : null);
			EventBase eventBase3 = pooled;
			EventBase eventBase4 = pointerEvent as EventBase;
			eventBase3.imguiEvent = ((eventBase4 != null) ? eventBase4.imguiEvent : null);
			pooled.modifiers = pointerEvent.modifiers;
			pooled.mousePosition = pointerEvent.position;
			pooled.localMousePosition = pointerEvent.position;
			pooled.mouseDelta = pointerEvent.deltaPosition;
			pooled.button = ((pointerEvent.button == -1) ? 0 : pointerEvent.button);
			pooled.pressedButtons = pointerEvent.pressedButtons;
			pooled.clickCount = pointerEvent.clickCount;
			IPointerEventInternal pointerEventInternal = pointerEvent as IPointerEventInternal;
			bool flag = pointerEventInternal != null;
			if (flag)
			{
				pooled.triggeredByOS = pointerEventInternal.triggeredByOS;
				pooled.recomputeTopElementUnderMouse = true;
				pooled.sourcePointerEvent = pointerEvent;
			}
			return pooled;
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x00037AA7 File Offset: 0x00035CA7
		protected MouseEventBase()
		{
			this.LocalInit();
		}
	}
}
