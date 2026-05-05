using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001C3 RID: 451
	public abstract class CallbackEventHandler : IEventHandler
	{
		// Token: 0x06000DD1 RID: 3537 RVA: 0x00035AC4 File Offset: 0x00033CC4
		public void RegisterCallback<TEventType>(EventCallback<TEventType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
		{
			bool flag = this.m_CallbackRegistry == null;
			if (flag)
			{
				this.m_CallbackRegistry = new EventCallbackRegistry();
			}
			this.m_CallbackRegistry.RegisterCallback<TEventType>(callback, useTrickleDown, InvokePolicy.Default);
			this.AddEventCategories<TEventType>();
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00035B04 File Offset: 0x00033D04
		private void AddEventCategories<TEventType>() where TEventType : EventBase<TEventType>, new()
		{
			VisualElement visualElement = this as VisualElement;
			bool flag = visualElement != null;
			if (flag)
			{
				visualElement.eventCallbackCategories |= 1 << (int)EventBase<TEventType>.EventCategory;
			}
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x00035B3C File Offset: 0x00033D3C
		public void RegisterCallback<TEventType, TUserArgsType>(EventCallback<TEventType, TUserArgsType> callback, TUserArgsType userArgs, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
		{
			bool flag = this.m_CallbackRegistry == null;
			if (flag)
			{
				this.m_CallbackRegistry = new EventCallbackRegistry();
			}
			this.m_CallbackRegistry.RegisterCallback<TEventType, TUserArgsType>(callback, userArgs, useTrickleDown, InvokePolicy.Default);
			this.AddEventCategories<TEventType>();
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x00035B7C File Offset: 0x00033D7C
		internal void RegisterCallback<TEventType>(EventCallback<TEventType> callback, InvokePolicy invokePolicy, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
		{
			bool flag = this.m_CallbackRegistry == null;
			if (flag)
			{
				this.m_CallbackRegistry = new EventCallbackRegistry();
			}
			this.m_CallbackRegistry.RegisterCallback<TEventType>(callback, useTrickleDown, invokePolicy);
			this.AddEventCategories<TEventType>();
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x00035BBC File Offset: 0x00033DBC
		public void UnregisterCallback<TEventType>(EventCallback<TEventType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
		{
			bool flag = this.m_CallbackRegistry != null;
			if (flag)
			{
				this.m_CallbackRegistry.UnregisterCallback<TEventType>(callback, useTrickleDown);
			}
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x00035BE8 File Offset: 0x00033DE8
		public void UnregisterCallback<TEventType, TUserArgsType>(EventCallback<TEventType, TUserArgsType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
		{
			bool flag = this.m_CallbackRegistry != null;
			if (flag)
			{
				this.m_CallbackRegistry.UnregisterCallback<TEventType, TUserArgsType>(callback, useTrickleDown);
			}
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x00035C14 File Offset: 0x00033E14
		internal bool TryGetUserArgs<TEventType, TCallbackArgs>(EventCallback<TEventType, TCallbackArgs> callback, TrickleDown useTrickleDown, out TCallbackArgs userData) where TEventType : EventBase<TEventType>, new()
		{
			userData = default(TCallbackArgs);
			bool flag = this.m_CallbackRegistry != null;
			return flag && this.m_CallbackRegistry.TryGetUserArgs<TEventType, TCallbackArgs>(callback, useTrickleDown, out userData);
		}

		// Token: 0x06000DD8 RID: 3544
		public abstract void SendEvent(EventBase e);

		// Token: 0x06000DD9 RID: 3545
		internal abstract void SendEvent(EventBase e, DispatchMode dispatchMode);

		// Token: 0x06000DDA RID: 3546 RVA: 0x00035C4D File Offset: 0x00033E4D
		internal void HandleEventAtTargetPhase(EventBase evt)
		{
			evt.currentTarget = evt.target;
			evt.propagationPhase = PropagationPhase.AtTarget;
			this.HandleEventAtCurrentTargetAndPhase(evt);
			evt.propagationPhase = PropagationPhase.DefaultActionAtTarget;
			this.HandleEventAtCurrentTargetAndPhase(evt);
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x00035C7D File Offset: 0x00033E7D
		internal void HandleEventAtTargetAndDefaultPhase(EventBase evt)
		{
			this.HandleEventAtTargetPhase(evt);
			evt.propagationPhase = PropagationPhase.DefaultAction;
			this.HandleEventAtCurrentTargetAndPhase(evt);
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x00035C98 File Offset: 0x00033E98
		internal void HandleEventAtCurrentTargetAndPhase(EventBase evt)
		{
			this.HandleEvent(evt);
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x00035CA3 File Offset: 0x00033EA3
		void IEventHandler.HandleEvent(EventBase evt)
		{
			this.HandleEventAtCurrentTargetAndPhase(evt);
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x00035CB0 File Offset: 0x00033EB0
		[Obsolete("The virtual method CallbackEventHandler.HandleEvent is deprecated and will be removed in a future release. Please override ExecuteDefaultAction instead.")]
		public virtual void HandleEvent(EventBase evt)
		{
			bool flag = evt == null;
			if (!flag)
			{
				switch (evt.propagationPhase)
				{
				case PropagationPhase.TrickleDown:
				case PropagationPhase.BubbleUp:
				{
					bool flag2 = !evt.isPropagationStopped;
					if (flag2)
					{
						EventCallbackRegistry callbackRegistry = this.m_CallbackRegistry;
						if (callbackRegistry != null)
						{
							callbackRegistry.InvokeCallbacks(evt, evt.propagationPhase);
						}
					}
					bool flag3 = this.isIMGUIContainer && !evt.isPropagationStopped;
					if (flag3)
					{
						((IMGUIContainer)this).ProcessEvent(evt);
					}
					break;
				}
				case PropagationPhase.AtTarget:
				{
					bool flag4 = !evt.isPropagationStopped;
					if (flag4)
					{
						EventCallbackRegistry callbackRegistry2 = this.m_CallbackRegistry;
						if (callbackRegistry2 != null)
						{
							callbackRegistry2.InvokeCallbacks(evt, PropagationPhase.TrickleDown);
						}
					}
					bool flag5 = !evt.isPropagationStopped;
					if (flag5)
					{
						EventCallbackRegistry callbackRegistry3 = this.m_CallbackRegistry;
						if (callbackRegistry3 != null)
						{
							callbackRegistry3.InvokeCallbacks(evt, PropagationPhase.BubbleUp);
						}
					}
					bool flag6 = this.isIMGUIContainer && !evt.isPropagationStopped;
					if (flag6)
					{
						((IMGUIContainer)this).ProcessEvent(evt);
					}
					break;
				}
				case PropagationPhase.DefaultAction:
				{
					bool flag7 = !evt.isDefaultPrevented;
					if (flag7)
					{
						using (new EventDebuggerLogExecuteDefaultAction(evt))
						{
							bool flag8;
							if (evt.skipDisabledElements)
							{
								VisualElement visualElement = this as VisualElement;
								if (visualElement != null)
								{
									flag8 = !visualElement.enabledInHierarchy;
									goto IL_1AC;
								}
							}
							flag8 = false;
							IL_1AC:
							bool flag9 = flag8;
							if (flag9)
							{
								this.ExecuteDefaultActionDisabled(evt);
							}
							else
							{
								this.ExecuteDefaultAction(evt);
							}
						}
					}
					break;
				}
				case PropagationPhase.DefaultActionAtTarget:
				{
					bool flag10 = !evt.isDefaultPrevented;
					if (flag10)
					{
						using (new EventDebuggerLogExecuteDefaultAction(evt))
						{
							bool flag11;
							if (evt.skipDisabledElements)
							{
								VisualElement visualElement2 = this as VisualElement;
								if (visualElement2 != null)
								{
									flag11 = !visualElement2.enabledInHierarchy;
									goto IL_144;
								}
							}
							flag11 = false;
							IL_144:
							bool flag12 = flag11;
							if (flag12)
							{
								this.ExecuteDefaultActionDisabledAtTarget(evt);
							}
							else
							{
								this.ExecuteDefaultActionAtTarget(evt);
							}
						}
					}
					break;
				}
				}
			}
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x00035EB4 File Offset: 0x000340B4
		public bool HasTrickleDownHandlers()
		{
			return this.m_CallbackRegistry != null && this.m_CallbackRegistry.HasTrickleDownHandlers();
		}

		// Token: 0x06000DE0 RID: 3552 RVA: 0x00035EDC File Offset: 0x000340DC
		public bool HasBubbleUpHandlers()
		{
			return this.m_CallbackRegistry != null && this.m_CallbackRegistry.HasBubbleHandlers();
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x00003CD2 File Offset: 0x00001ED2
		[EventInterest(EventInterestOptions.Inherit)]
		protected virtual void ExecuteDefaultActionAtTarget(EventBase evt)
		{
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x00003CD2 File Offset: 0x00001ED2
		[EventInterest(EventInterestOptions.Inherit)]
		protected virtual void ExecuteDefaultAction(EventBase evt)
		{
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00003CD2 File Offset: 0x00001ED2
		[EventInterest(EventInterestOptions.Inherit)]
		internal virtual void ExecuteDefaultActionDisabledAtTarget(EventBase evt)
		{
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x00003CD2 File Offset: 0x00001ED2
		[EventInterest(EventInterestOptions.Inherit)]
		internal virtual void ExecuteDefaultActionDisabled(EventBase evt)
		{
		}

		// Token: 0x04000695 RID: 1685
		internal bool isIMGUIContainer = false;

		// Token: 0x04000696 RID: 1686
		private EventCallbackRegistry m_CallbackRegistry;

		// Token: 0x04000697 RID: 1687
		internal const string ExecuteDefaultActionName = "ExecuteDefaultAction";

		// Token: 0x04000698 RID: 1688
		internal const string ExecuteDefaultActionAtTargetName = "ExecuteDefaultActionAtTarget";
	}
}
