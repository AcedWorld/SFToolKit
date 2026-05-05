using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001B1 RID: 433
	internal class EventCallbackRegistry
	{
		// Token: 0x06000D2F RID: 3375 RVA: 0x00033674 File Offset: 0x00031874
		private static EventCallbackList GetCallbackList(EventCallbackList initializer = null)
		{
			return EventCallbackRegistry.s_ListPool.Get(initializer);
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x00033691 File Offset: 0x00031891
		private static void ReleaseCallbackList(EventCallbackList toRelease)
		{
			EventCallbackRegistry.s_ListPool.Release(toRelease);
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x000336A0 File Offset: 0x000318A0
		public EventCallbackRegistry()
		{
			this.m_IsInvoking = 0;
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x000336B4 File Offset: 0x000318B4
		private EventCallbackList GetCallbackListForWriting()
		{
			bool flag = this.m_IsInvoking > 0;
			EventCallbackList result;
			if (flag)
			{
				bool flag2 = this.m_TemporaryCallbacks == null;
				if (flag2)
				{
					bool flag3 = this.m_Callbacks != null;
					if (flag3)
					{
						this.m_TemporaryCallbacks = EventCallbackRegistry.GetCallbackList(this.m_Callbacks);
					}
					else
					{
						this.m_TemporaryCallbacks = EventCallbackRegistry.GetCallbackList(null);
					}
				}
				result = this.m_TemporaryCallbacks;
			}
			else
			{
				bool flag4 = this.m_Callbacks == null;
				if (flag4)
				{
					this.m_Callbacks = EventCallbackRegistry.GetCallbackList(null);
				}
				result = this.m_Callbacks;
			}
			return result;
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00033740 File Offset: 0x00031940
		private EventCallbackList GetCallbackListForReading()
		{
			bool flag = this.m_TemporaryCallbacks != null;
			EventCallbackList result;
			if (flag)
			{
				result = this.m_TemporaryCallbacks;
			}
			else
			{
				result = this.m_Callbacks;
			}
			return result;
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x00033770 File Offset: 0x00031970
		private bool ShouldRegisterCallback(long eventTypeId, Delegate callback, CallbackPhase phase)
		{
			bool flag = callback == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EventCallbackList callbackListForReading = this.GetCallbackListForReading();
				bool flag2 = callbackListForReading != null;
				result = (!flag2 || !callbackListForReading.Contains(eventTypeId, callback, phase));
			}
			return result;
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x000337B0 File Offset: 0x000319B0
		private bool UnregisterCallback(long eventTypeId, Delegate callback, TrickleDown useTrickleDown)
		{
			bool flag = callback == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EventCallbackList callbackListForWriting = this.GetCallbackListForWriting();
				CallbackPhase phase = (useTrickleDown == TrickleDown.TrickleDown) ? CallbackPhase.TrickleDownAndTarget : CallbackPhase.TargetAndBubbleUp;
				result = callbackListForWriting.Remove(eventTypeId, callback, phase);
			}
			return result;
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x000337E8 File Offset: 0x000319E8
		public void RegisterCallback<TEventType>(EventCallback<TEventType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown, InvokePolicy invokePolicy = InvokePolicy.Default) where TEventType : EventBase<TEventType>, new()
		{
			bool flag = callback == null;
			if (flag)
			{
				throw new ArgumentException("callback parameter is null");
			}
			long eventTypeId = EventBase<TEventType>.TypeId();
			CallbackPhase phase = (useTrickleDown == TrickleDown.TrickleDown) ? CallbackPhase.TrickleDownAndTarget : CallbackPhase.TargetAndBubbleUp;
			EventCallbackList eventCallbackList = this.GetCallbackListForReading();
			bool flag2 = eventCallbackList == null || !eventCallbackList.Contains(eventTypeId, callback, phase);
			if (flag2)
			{
				eventCallbackList = this.GetCallbackListForWriting();
				eventCallbackList.Add(new EventCallbackFunctor<TEventType>(callback, phase, invokePolicy));
			}
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x00033850 File Offset: 0x00031A50
		public void RegisterCallback<TEventType, TCallbackArgs>(EventCallback<TEventType, TCallbackArgs> callback, TCallbackArgs userArgs, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown, InvokePolicy invokePolicy = InvokePolicy.Default) where TEventType : EventBase<TEventType>, new()
		{
			bool flag = callback == null;
			if (flag)
			{
				throw new ArgumentException("callback parameter is null");
			}
			long eventTypeId = EventBase<TEventType>.TypeId();
			CallbackPhase phase = (useTrickleDown == TrickleDown.TrickleDown) ? CallbackPhase.TrickleDownAndTarget : CallbackPhase.TargetAndBubbleUp;
			EventCallbackList eventCallbackList = this.GetCallbackListForReading();
			bool flag2 = eventCallbackList != null;
			if (flag2)
			{
				EventCallbackFunctor<TEventType, TCallbackArgs> eventCallbackFunctor = eventCallbackList.Find(eventTypeId, callback, phase) as EventCallbackFunctor<TEventType, TCallbackArgs>;
				bool flag3 = eventCallbackFunctor != null;
				if (flag3)
				{
					eventCallbackFunctor.userArgs = userArgs;
					return;
				}
			}
			eventCallbackList = this.GetCallbackListForWriting();
			eventCallbackList.Add(new EventCallbackFunctor<TEventType, TCallbackArgs>(callback, userArgs, phase, invokePolicy));
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x000338D4 File Offset: 0x00031AD4
		public bool UnregisterCallback<TEventType>(EventCallback<TEventType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
		{
			long eventTypeId = EventBase<TEventType>.TypeId();
			return this.UnregisterCallback(eventTypeId, callback, useTrickleDown);
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x000338F8 File Offset: 0x00031AF8
		public bool UnregisterCallback<TEventType, TCallbackArgs>(EventCallback<TEventType, TCallbackArgs> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown) where TEventType : EventBase<TEventType>, new()
		{
			long eventTypeId = EventBase<TEventType>.TypeId();
			return this.UnregisterCallback(eventTypeId, callback, useTrickleDown);
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x0003391C File Offset: 0x00031B1C
		internal bool TryGetUserArgs<TEventType, TCallbackArgs>(EventCallback<TEventType, TCallbackArgs> callback, TrickleDown useTrickleDown, out TCallbackArgs userArgs) where TEventType : EventBase<TEventType>, new()
		{
			userArgs = default(TCallbackArgs);
			bool flag = callback == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EventCallbackList callbackListForReading = this.GetCallbackListForReading();
				long eventTypeId = EventBase<TEventType>.TypeId();
				CallbackPhase phase = (useTrickleDown == TrickleDown.TrickleDown) ? CallbackPhase.TrickleDownAndTarget : CallbackPhase.TargetAndBubbleUp;
				EventCallbackFunctor<TEventType, TCallbackArgs> eventCallbackFunctor = callbackListForReading.Find(eventTypeId, callback, phase) as EventCallbackFunctor<TEventType, TCallbackArgs>;
				bool flag2 = eventCallbackFunctor == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					userArgs = eventCallbackFunctor.userArgs;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x00033988 File Offset: 0x00031B88
		public void InvokeCallbacks(EventBase evt, PropagationPhase propagationPhase)
		{
			bool flag = this.m_Callbacks == null;
			if (!flag)
			{
				this.m_IsInvoking++;
				bool flag2;
				if (evt.skipDisabledElements)
				{
					VisualElement visualElement = evt.currentTarget as VisualElement;
					if (visualElement != null)
					{
						flag2 = !visualElement.enabledInHierarchy;
						goto IL_45;
					}
				}
				flag2 = false;
				IL_45:
				bool flag3 = flag2;
				for (int i = 0; i < this.m_Callbacks.Count; i++)
				{
					bool isImmediatePropagationStopped = evt.isImmediatePropagationStopped;
					if (isImmediatePropagationStopped)
					{
						break;
					}
					bool flag4 = flag3 && this.m_Callbacks[i].invokePolicy != InvokePolicy.IncludeDisabled;
					if (!flag4)
					{
						this.m_Callbacks[i].Invoke(evt, propagationPhase);
					}
				}
				this.m_IsInvoking--;
				bool flag5 = this.m_IsInvoking == 0;
				if (flag5)
				{
					bool flag6 = this.m_TemporaryCallbacks != null;
					if (flag6)
					{
						EventCallbackRegistry.ReleaseCallbackList(this.m_Callbacks);
						this.m_Callbacks = EventCallbackRegistry.GetCallbackList(this.m_TemporaryCallbacks);
						EventCallbackRegistry.ReleaseCallbackList(this.m_TemporaryCallbacks);
						this.m_TemporaryCallbacks = null;
					}
				}
			}
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x00033AA4 File Offset: 0x00031CA4
		public bool HasTrickleDownHandlers()
		{
			return this.m_Callbacks != null && this.m_Callbacks.trickleDownCallbackCount > 0;
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x00033AD0 File Offset: 0x00031CD0
		public bool HasBubbleHandlers()
		{
			return this.m_Callbacks != null && this.m_Callbacks.bubbleUpCallbackCount > 0;
		}

		// Token: 0x0400063D RID: 1597
		private static readonly EventCallbackListPool s_ListPool = new EventCallbackListPool();

		// Token: 0x0400063E RID: 1598
		private EventCallbackList m_Callbacks;

		// Token: 0x0400063F RID: 1599
		private EventCallbackList m_TemporaryCallbacks;

		// Token: 0x04000640 RID: 1600
		private int m_IsInvoking;
	}
}
