using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020001BD RID: 445
	[Serializable]
	internal class EventDebuggerEventRecord
	{
		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000D85 RID: 3461 RVA: 0x000354FD File Offset: 0x000336FD
		// (set) Token: 0x06000D86 RID: 3462 RVA: 0x00035505 File Offset: 0x00033705
		public string eventBaseName { get; private set; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000D87 RID: 3463 RVA: 0x0003550E File Offset: 0x0003370E
		// (set) Token: 0x06000D88 RID: 3464 RVA: 0x00035516 File Offset: 0x00033716
		public long eventTypeId { get; private set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000D89 RID: 3465 RVA: 0x0003551F File Offset: 0x0003371F
		// (set) Token: 0x06000D8A RID: 3466 RVA: 0x00035527 File Offset: 0x00033727
		public ulong eventId { get; private set; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000D8B RID: 3467 RVA: 0x00035530 File Offset: 0x00033730
		// (set) Token: 0x06000D8C RID: 3468 RVA: 0x00035538 File Offset: 0x00033738
		private ulong triggerEventId { get; set; }

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000D8D RID: 3469 RVA: 0x00035541 File Offset: 0x00033741
		// (set) Token: 0x06000D8E RID: 3470 RVA: 0x00035549 File Offset: 0x00033749
		internal long timestamp { get; private set; }

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000D8F RID: 3471 RVA: 0x00035552 File Offset: 0x00033752
		// (set) Token: 0x06000D90 RID: 3472 RVA: 0x0003555A File Offset: 0x0003375A
		public IEventHandler target { get; set; }

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000D91 RID: 3473 RVA: 0x00035563 File Offset: 0x00033763
		// (set) Token: 0x06000D92 RID: 3474 RVA: 0x0003556B File Offset: 0x0003376B
		private List<IEventHandler> skipElements { get; set; }

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000D93 RID: 3475 RVA: 0x00035574 File Offset: 0x00033774
		// (set) Token: 0x06000D94 RID: 3476 RVA: 0x0003557C File Offset: 0x0003377C
		public bool hasUnderlyingPhysicalEvent { get; private set; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x00035585 File Offset: 0x00033785
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x0003558D File Offset: 0x0003378D
		private bool isPropagationStopped { get; set; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x00035596 File Offset: 0x00033796
		// (set) Token: 0x06000D98 RID: 3480 RVA: 0x0003559E File Offset: 0x0003379E
		private bool isImmediatePropagationStopped { get; set; }

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x000355A7 File Offset: 0x000337A7
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x000355AF File Offset: 0x000337AF
		private bool isDefaultPrevented { get; set; }

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x000355B8 File Offset: 0x000337B8
		// (set) Token: 0x06000D9C RID: 3484 RVA: 0x000355C0 File Offset: 0x000337C0
		public PropagationPhase propagationPhase { get; private set; }

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000D9D RID: 3485 RVA: 0x000355C9 File Offset: 0x000337C9
		// (set) Token: 0x06000D9E RID: 3486 RVA: 0x000355D1 File Offset: 0x000337D1
		private IEventHandler currentTarget { get; set; }

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x000355DA File Offset: 0x000337DA
		// (set) Token: 0x06000DA0 RID: 3488 RVA: 0x000355E2 File Offset: 0x000337E2
		private bool dispatch { get; set; }

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x000355EB File Offset: 0x000337EB
		// (set) Token: 0x06000DA2 RID: 3490 RVA: 0x000355F3 File Offset: 0x000337F3
		private Vector2 originalMousePosition { get; set; }

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x000355FC File Offset: 0x000337FC
		// (set) Token: 0x06000DA4 RID: 3492 RVA: 0x00035604 File Offset: 0x00033804
		public EventModifiers modifiers { get; private set; }

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x0003560D File Offset: 0x0003380D
		// (set) Token: 0x06000DA6 RID: 3494 RVA: 0x00035615 File Offset: 0x00033815
		public Vector2 mousePosition { get; private set; }

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x0003561E File Offset: 0x0003381E
		// (set) Token: 0x06000DA8 RID: 3496 RVA: 0x00035626 File Offset: 0x00033826
		public int clickCount { get; private set; }

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x0003562F File Offset: 0x0003382F
		// (set) Token: 0x06000DAA RID: 3498 RVA: 0x00035637 File Offset: 0x00033837
		public int button { get; private set; }

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000DAB RID: 3499 RVA: 0x00035640 File Offset: 0x00033840
		// (set) Token: 0x06000DAC RID: 3500 RVA: 0x00035648 File Offset: 0x00033848
		public int pressedButtons { get; private set; }

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000DAD RID: 3501 RVA: 0x00035651 File Offset: 0x00033851
		// (set) Token: 0x06000DAE RID: 3502 RVA: 0x00035659 File Offset: 0x00033859
		public Vector3 delta { get; private set; }

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x00035662 File Offset: 0x00033862
		// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x0003566A File Offset: 0x0003386A
		public char character { get; private set; }

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x00035673 File Offset: 0x00033873
		// (set) Token: 0x06000DB2 RID: 3506 RVA: 0x0003567B File Offset: 0x0003387B
		public KeyCode keyCode { get; private set; }

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000DB3 RID: 3507 RVA: 0x00035684 File Offset: 0x00033884
		// (set) Token: 0x06000DB4 RID: 3508 RVA: 0x0003568C File Offset: 0x0003388C
		public string commandName { get; private set; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x00035695 File Offset: 0x00033895
		// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x0003569D File Offset: 0x0003389D
		public NavigationDeviceType deviceType { get; private set; }

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x000356A6 File Offset: 0x000338A6
		// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x000356AE File Offset: 0x000338AE
		public NavigationMoveEvent.Direction navigationDirection { get; private set; }

		// Token: 0x06000DB9 RID: 3513 RVA: 0x000356B8 File Offset: 0x000338B8
		private void Init(EventBase evt)
		{
			Type type = evt.GetType();
			this.eventBaseName = EventDebugger.GetTypeDisplayName(type);
			this.eventTypeId = evt.eventTypeId;
			this.eventId = evt.eventId;
			this.triggerEventId = evt.triggerEventId;
			this.timestamp = evt.timestamp;
			this.target = evt.target;
			this.skipElements = evt.skipElements;
			this.isPropagationStopped = evt.isPropagationStopped;
			this.isImmediatePropagationStopped = evt.isImmediatePropagationStopped;
			this.isDefaultPrevented = evt.isDefaultPrevented;
			IMouseEvent mouseEvent = evt as IMouseEvent;
			IMouseEventInternal mouseEventInternal = evt as IMouseEventInternal;
			this.hasUnderlyingPhysicalEvent = (mouseEvent != null && mouseEventInternal != null && mouseEventInternal.triggeredByOS);
			this.propagationPhase = evt.propagationPhase;
			this.originalMousePosition = evt.originalMousePosition;
			this.currentTarget = evt.currentTarget;
			this.dispatch = evt.dispatch;
			bool flag = mouseEvent != null;
			if (flag)
			{
				this.modifiers = mouseEvent.modifiers;
				this.mousePosition = mouseEvent.mousePosition;
				this.button = mouseEvent.button;
				this.pressedButtons = mouseEvent.pressedButtons;
				this.clickCount = mouseEvent.clickCount;
				WheelEvent wheelEvent = mouseEvent as WheelEvent;
				bool flag2 = wheelEvent != null;
				if (flag2)
				{
					this.delta = wheelEvent.delta;
				}
			}
			IPointerEvent pointerEvent = evt as IPointerEvent;
			bool flag3 = pointerEvent != null;
			if (flag3)
			{
				IPointerEventInternal pointerEventInternal = evt as IPointerEventInternal;
				this.hasUnderlyingPhysicalEvent = (pointerEvent != null && pointerEventInternal != null && pointerEventInternal.triggeredByOS);
				this.modifiers = pointerEvent.modifiers;
				this.mousePosition = pointerEvent.position;
				this.button = pointerEvent.button;
				this.pressedButtons = pointerEvent.pressedButtons;
				this.clickCount = pointerEvent.clickCount;
			}
			IKeyboardEvent keyboardEvent = evt as IKeyboardEvent;
			bool flag4 = keyboardEvent != null;
			if (flag4)
			{
				this.modifiers = keyboardEvent.modifiers;
				this.character = keyboardEvent.character;
				this.keyCode = keyboardEvent.keyCode;
			}
			ICommandEvent commandEvent = evt as ICommandEvent;
			bool flag5 = commandEvent != null;
			if (flag5)
			{
				this.commandName = commandEvent.commandName;
			}
			INavigationEvent navigationEvent = evt as INavigationEvent;
			bool flag6 = navigationEvent != null;
			if (flag6)
			{
				this.deviceType = navigationEvent.deviceType;
				NavigationMoveEvent navigationMoveEvent = evt as NavigationMoveEvent;
				bool flag7 = navigationMoveEvent != null;
				if (flag7)
				{
					this.navigationDirection = navigationMoveEvent.direction;
				}
			}
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00035938 File Offset: 0x00033B38
		public EventDebuggerEventRecord(EventBase evt)
		{
			this.Init(evt);
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x0003594C File Offset: 0x00033B4C
		public string TimestampString()
		{
			long ticks = (long)((float)this.timestamp / 1000f * 10000000f);
			return new DateTime(ticks).ToString("HH:mm:ss.ffffff");
		}
	}
}
