using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020001A2 RID: 418
	public abstract class EventBase : IDisposable
	{
		// Token: 0x06000CAE RID: 3246 RVA: 0x00032544 File Offset: 0x00030744
		protected static long RegisterEventType()
		{
			return EventBase.s_LastTypeId += 1L;
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00032564 File Offset: 0x00030764
		public virtual long eventTypeId
		{
			get
			{
				return -1L;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x00032568 File Offset: 0x00030768
		internal EventCategory eventCategory { get; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x00032570 File Offset: 0x00030770
		// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x00032578 File Offset: 0x00030778
		public long timestamp { get; private set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x00032581 File Offset: 0x00030781
		// (set) Token: 0x06000CB4 RID: 3252 RVA: 0x00032589 File Offset: 0x00030789
		internal ulong eventId { get; private set; }

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x00032592 File Offset: 0x00030792
		// (set) Token: 0x06000CB6 RID: 3254 RVA: 0x0003259A File Offset: 0x0003079A
		internal ulong triggerEventId { get; private set; }

		// Token: 0x06000CB7 RID: 3255 RVA: 0x000325A3 File Offset: 0x000307A3
		internal void SetTriggerEventId(ulong id)
		{
			this.triggerEventId = id;
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000CB8 RID: 3256 RVA: 0x000325AE File Offset: 0x000307AE
		// (set) Token: 0x06000CB9 RID: 3257 RVA: 0x000325B6 File Offset: 0x000307B6
		internal EventBase.EventPropagation propagation { get; set; }

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000CBA RID: 3258 RVA: 0x000325BF File Offset: 0x000307BF
		// (set) Token: 0x06000CBB RID: 3259 RVA: 0x000325C7 File Offset: 0x000307C7
		internal PropagationPaths path { get; set; }

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000CBC RID: 3260 RVA: 0x000325D0 File Offset: 0x000307D0
		// (set) Token: 0x06000CBD RID: 3261 RVA: 0x000325D8 File Offset: 0x000307D8
		private EventBase.LifeCycleStatus lifeCycleStatus { get; set; }

		// Token: 0x06000CBE RID: 3262 RVA: 0x00003CD2 File Offset: 0x00001ED2
		[Obsolete("Override PreDispatch(IPanel panel) instead.")]
		protected virtual void PreDispatch()
		{
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x000325E1 File Offset: 0x000307E1
		protected internal virtual void PreDispatch(IPanel panel)
		{
			this.PreDispatch();
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x00003CD2 File Offset: 0x00001ED2
		[Obsolete("Override PostDispatch(IPanel panel) instead.")]
		protected virtual void PostDispatch()
		{
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x000325EB File Offset: 0x000307EB
		protected internal virtual void PostDispatch(IPanel panel)
		{
			this.PostDispatch();
			this.processed = true;
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x00032600 File Offset: 0x00030800
		// (set) Token: 0x06000CC3 RID: 3267 RVA: 0x00032620 File Offset: 0x00030820
		public bool bubbles
		{
			get
			{
				return (this.propagation & EventBase.EventPropagation.Bubbles) > EventBase.EventPropagation.None;
			}
			protected set
			{
				if (value)
				{
					this.propagation |= EventBase.EventPropagation.Bubbles;
				}
				else
				{
					this.propagation &= ~EventBase.EventPropagation.Bubbles;
				}
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000CC4 RID: 3268 RVA: 0x00032658 File Offset: 0x00030858
		// (set) Token: 0x06000CC5 RID: 3269 RVA: 0x00032678 File Offset: 0x00030878
		public bool tricklesDown
		{
			get
			{
				return (this.propagation & EventBase.EventPropagation.TricklesDown) > EventBase.EventPropagation.None;
			}
			protected set
			{
				if (value)
				{
					this.propagation |= EventBase.EventPropagation.TricklesDown;
				}
				else
				{
					this.propagation &= ~EventBase.EventPropagation.TricklesDown;
				}
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000CC6 RID: 3270 RVA: 0x000326B0 File Offset: 0x000308B0
		internal bool bubblesOrTricklesDown
		{
			get
			{
				return (this.propagation & (EventBase.EventPropagation.Bubbles | EventBase.EventPropagation.TricklesDown)) > EventBase.EventPropagation.None;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x000326C0 File Offset: 0x000308C0
		// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x000326E0 File Offset: 0x000308E0
		internal bool skipDisabledElements
		{
			get
			{
				return (this.propagation & EventBase.EventPropagation.SkipDisabledElements) > EventBase.EventPropagation.None;
			}
			set
			{
				if (value)
				{
					this.propagation |= EventBase.EventPropagation.SkipDisabledElements;
				}
				else
				{
					this.propagation &= ~EventBase.EventPropagation.SkipDisabledElements;
				}
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x00032718 File Offset: 0x00030918
		// (set) Token: 0x06000CCA RID: 3274 RVA: 0x00032738 File Offset: 0x00030938
		internal bool ignoreCompositeRoots
		{
			get
			{
				return (this.propagation & EventBase.EventPropagation.IgnoreCompositeRoots) > EventBase.EventPropagation.None;
			}
			set
			{
				if (value)
				{
					this.propagation |= EventBase.EventPropagation.IgnoreCompositeRoots;
				}
				else
				{
					this.propagation &= ~EventBase.EventPropagation.IgnoreCompositeRoots;
				}
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000CCB RID: 3275 RVA: 0x00032771 File Offset: 0x00030971
		// (set) Token: 0x06000CCC RID: 3276 RVA: 0x00032779 File Offset: 0x00030979
		internal IEventHandler leafTarget { get; private set; }

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x00032784 File Offset: 0x00030984
		// (set) Token: 0x06000CCE RID: 3278 RVA: 0x0003279C File Offset: 0x0003099C
		public IEventHandler target
		{
			get
			{
				return this.m_Target;
			}
			set
			{
				this.m_Target = value;
				bool flag = this.leafTarget == null;
				if (flag)
				{
					this.leafTarget = value;
				}
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x000327C8 File Offset: 0x000309C8
		internal List<IEventHandler> skipElements { get; } = new List<IEventHandler>();

		// Token: 0x06000CD0 RID: 3280 RVA: 0x000327D0 File Offset: 0x000309D0
		internal bool Skip(IEventHandler h)
		{
			return this.skipElements.Contains(h);
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x000327F0 File Offset: 0x000309F0
		// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x00032810 File Offset: 0x00030A10
		public bool isPropagationStopped
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.PropagationStopped) > EventBase.LifeCycleStatus.None;
			}
			private set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.PropagationStopped;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.PropagationStopped;
				}
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x00032848 File Offset: 0x00030A48
		public void StopPropagation()
		{
			this.isPropagationStopped = true;
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000CD4 RID: 3284 RVA: 0x00032854 File Offset: 0x00030A54
		// (set) Token: 0x06000CD5 RID: 3285 RVA: 0x00032874 File Offset: 0x00030A74
		public bool isImmediatePropagationStopped
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.ImmediatePropagationStopped) > EventBase.LifeCycleStatus.None;
			}
			private set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.ImmediatePropagationStopped;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.ImmediatePropagationStopped;
				}
			}
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x000328AC File Offset: 0x00030AAC
		public void StopImmediatePropagation()
		{
			this.isPropagationStopped = true;
			this.isImmediatePropagationStopped = true;
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x000328C0 File Offset: 0x00030AC0
		// (set) Token: 0x06000CD8 RID: 3288 RVA: 0x000328E0 File Offset: 0x00030AE0
		public bool isDefaultPrevented
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.DefaultPrevented) > EventBase.LifeCycleStatus.None;
			}
			private set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.DefaultPrevented;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.DefaultPrevented;
				}
			}
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x00032918 File Offset: 0x00030B18
		public void PreventDefault()
		{
			bool flag = (this.propagation & EventBase.EventPropagation.Cancellable) == EventBase.EventPropagation.Cancellable;
			if (flag)
			{
				this.isDefaultPrevented = true;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000CDA RID: 3290 RVA: 0x0003293F File Offset: 0x00030B3F
		// (set) Token: 0x06000CDB RID: 3291 RVA: 0x00032947 File Offset: 0x00030B47
		public PropagationPhase propagationPhase { get; internal set; }

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000CDC RID: 3292 RVA: 0x00032950 File Offset: 0x00030B50
		// (set) Token: 0x06000CDD RID: 3293 RVA: 0x00032968 File Offset: 0x00030B68
		public virtual IEventHandler currentTarget
		{
			get
			{
				return this.m_CurrentTarget;
			}
			internal set
			{
				this.m_CurrentTarget = value;
				bool flag = this.imguiEvent != null;
				if (flag)
				{
					VisualElement visualElement = this.currentTarget as VisualElement;
					bool flag2 = visualElement != null;
					if (flag2)
					{
						this.imguiEvent.mousePosition = visualElement.WorldToLocal(this.originalMousePosition);
					}
					else
					{
						this.imguiEvent.mousePosition = this.originalMousePosition;
					}
				}
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000CDE RID: 3294 RVA: 0x000329D0 File Offset: 0x00030BD0
		// (set) Token: 0x06000CDF RID: 3295 RVA: 0x000329F0 File Offset: 0x00030BF0
		public bool dispatch
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.Dispatching) > EventBase.LifeCycleStatus.None;
			}
			internal set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.Dispatching;
					this.dispatched = true;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.Dispatching;
				}
			}
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x00032A30 File Offset: 0x00030C30
		internal void MarkReceivedByDispatcher()
		{
			Debug.Assert(!this.dispatched, "Events cannot be dispatched more than once.");
			this.dispatched = true;
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x00032A50 File Offset: 0x00030C50
		// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x00032A74 File Offset: 0x00030C74
		private bool dispatched
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.Dispatched) > EventBase.LifeCycleStatus.None;
			}
			set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.Dispatched;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.Dispatched;
				}
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x00032AB4 File Offset: 0x00030CB4
		// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x00032AD8 File Offset: 0x00030CD8
		internal bool processed
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.Processed) > EventBase.LifeCycleStatus.None;
			}
			private set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.Processed;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.Processed;
				}
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00032B18 File Offset: 0x00030D18
		// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x00032B3C File Offset: 0x00030D3C
		internal bool processedByFocusController
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.ProcessedByFocusController) > EventBase.LifeCycleStatus.None;
			}
			set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.ProcessedByFocusController;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.ProcessedByFocusController;
				}
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x00032B7C File Offset: 0x00030D7C
		// (set) Token: 0x06000CE8 RID: 3304 RVA: 0x00032B9C File Offset: 0x00030D9C
		internal bool stopDispatch
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.StopDispatch) > EventBase.LifeCycleStatus.None;
			}
			set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.StopDispatch;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.StopDispatch;
				}
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x00032BD8 File Offset: 0x00030DD8
		// (set) Token: 0x06000CEA RID: 3306 RVA: 0x00032BFC File Offset: 0x00030DFC
		internal bool propagateToIMGUI
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.PropagateToIMGUI) > EventBase.LifeCycleStatus.None;
			}
			set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.PropagateToIMGUI;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.PropagateToIMGUI;
				}
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000CEB RID: 3307 RVA: 0x00032C3C File Offset: 0x00030E3C
		// (set) Token: 0x06000CEC RID: 3308 RVA: 0x00032C5C File Offset: 0x00030E5C
		private bool imguiEventIsValid
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.IMGUIEventIsValid) > EventBase.LifeCycleStatus.None;
			}
			set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.IMGUIEventIsValid;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.IMGUIEventIsValid;
				}
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000CED RID: 3309 RVA: 0x00032C98 File Offset: 0x00030E98
		// (set) Token: 0x06000CEE RID: 3310 RVA: 0x00032CBC File Offset: 0x00030EBC
		public Event imguiEvent
		{
			get
			{
				return this.imguiEventIsValid ? this.m_ImguiEvent : null;
			}
			protected set
			{
				bool flag = this.m_ImguiEvent == null;
				if (flag)
				{
					this.m_ImguiEvent = new Event();
				}
				bool flag2 = value != null;
				if (flag2)
				{
					this.m_ImguiEvent.CopyFrom(value);
					this.imguiEventIsValid = true;
					this.originalMousePosition = value.mousePosition;
				}
				else
				{
					this.imguiEventIsValid = false;
				}
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000CEF RID: 3311 RVA: 0x00032D1C File Offset: 0x00030F1C
		// (set) Token: 0x06000CF0 RID: 3312 RVA: 0x00032D24 File Offset: 0x00030F24
		public Vector2 originalMousePosition { get; private set; }

		// Token: 0x06000CF1 RID: 3313 RVA: 0x00032D2D File Offset: 0x00030F2D
		protected virtual void Init()
		{
			this.LocalInit();
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00032D38 File Offset: 0x00030F38
		private void LocalInit()
		{
			this.timestamp = Panel.TimeSinceStartupMs();
			this.triggerEventId = 0UL;
			ulong num = EventBase.s_NextEventId;
			EventBase.s_NextEventId = num + 1UL;
			this.eventId = num;
			this.propagation = EventBase.EventPropagation.None;
			PropagationPaths path = this.path;
			if (path != null)
			{
				path.Release();
			}
			this.path = null;
			this.leafTarget = null;
			this.target = null;
			this.skipElements.Clear();
			this.isPropagationStopped = false;
			this.isImmediatePropagationStopped = false;
			this.isDefaultPrevented = false;
			this.propagationPhase = PropagationPhase.None;
			this.originalMousePosition = Vector2.zero;
			this.m_CurrentTarget = null;
			this.dispatch = false;
			this.stopDispatch = false;
			this.propagateToIMGUI = true;
			this.dispatched = false;
			this.processed = false;
			this.processedByFocusController = false;
			this.imguiEventIsValid = false;
			this.pooled = false;
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x00032E21 File Offset: 0x00031021
		protected EventBase() : this(EventCategory.Default)
		{
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00032E2C File Offset: 0x0003102C
		internal EventBase(EventCategory category)
		{
			this.eventCategory = category;
			this.m_ImguiEvent = null;
			this.LocalInit();
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x00032E58 File Offset: 0x00031058
		// (set) Token: 0x06000CF6 RID: 3318 RVA: 0x00032E78 File Offset: 0x00031078
		protected bool pooled
		{
			get
			{
				return (this.lifeCycleStatus & EventBase.LifeCycleStatus.Pooled) > EventBase.LifeCycleStatus.None;
			}
			set
			{
				if (value)
				{
					this.lifeCycleStatus |= EventBase.LifeCycleStatus.Pooled;
				}
				else
				{
					this.lifeCycleStatus &= ~EventBase.LifeCycleStatus.Pooled;
				}
			}
		}

		// Token: 0x06000CF7 RID: 3319
		internal abstract void Acquire();

		// Token: 0x06000CF8 RID: 3320
		public abstract void Dispose();

		// Token: 0x04000600 RID: 1536
		private static long s_LastTypeId;

		// Token: 0x04000602 RID: 1538
		private static ulong s_NextEventId;

		// Token: 0x0400060A RID: 1546
		private IEventHandler m_Target;

		// Token: 0x0400060D RID: 1549
		private IEventHandler m_CurrentTarget;

		// Token: 0x0400060E RID: 1550
		private Event m_ImguiEvent;

		// Token: 0x020001A3 RID: 419
		[Flags]
		internal enum EventPropagation
		{
			// Token: 0x04000611 RID: 1553
			None = 0,
			// Token: 0x04000612 RID: 1554
			Bubbles = 1,
			// Token: 0x04000613 RID: 1555
			TricklesDown = 2,
			// Token: 0x04000614 RID: 1556
			Cancellable = 4,
			// Token: 0x04000615 RID: 1557
			SkipDisabledElements = 8,
			// Token: 0x04000616 RID: 1558
			IgnoreCompositeRoots = 16
		}

		// Token: 0x020001A4 RID: 420
		[Flags]
		private enum LifeCycleStatus
		{
			// Token: 0x04000618 RID: 1560
			None = 0,
			// Token: 0x04000619 RID: 1561
			PropagationStopped = 1,
			// Token: 0x0400061A RID: 1562
			ImmediatePropagationStopped = 2,
			// Token: 0x0400061B RID: 1563
			DefaultPrevented = 4,
			// Token: 0x0400061C RID: 1564
			Dispatching = 8,
			// Token: 0x0400061D RID: 1565
			Pooled = 16,
			// Token: 0x0400061E RID: 1566
			IMGUIEventIsValid = 32,
			// Token: 0x0400061F RID: 1567
			StopDispatch = 64,
			// Token: 0x04000620 RID: 1568
			PropagateToIMGUI = 128,
			// Token: 0x04000621 RID: 1569
			Dispatched = 512,
			// Token: 0x04000622 RID: 1570
			Processed = 1024,
			// Token: 0x04000623 RID: 1571
			ProcessedByFocusController = 2048
		}
	}
}
