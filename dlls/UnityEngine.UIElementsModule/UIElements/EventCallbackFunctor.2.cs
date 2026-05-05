using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001AB RID: 427
	internal class EventCallbackFunctor<TEventType, TCallbackArgs> : EventCallbackFunctorBase where TEventType : EventBase<TEventType>, new()
	{
		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x000331E5 File Offset: 0x000313E5
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x000331ED File Offset: 0x000313ED
		internal TCallbackArgs userArgs { get; set; }

		// Token: 0x06000D1A RID: 3354 RVA: 0x000331F6 File Offset: 0x000313F6
		public EventCallbackFunctor(EventCallback<TEventType, TCallbackArgs> callback, TCallbackArgs userArgs, CallbackPhase phase, InvokePolicy invokePolicy) : base(phase, invokePolicy)
		{
			this.userArgs = userArgs;
			this.m_Callback = callback;
			this.m_EventTypeId = EventBase<TEventType>.TypeId();
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x00033220 File Offset: 0x00031420
		public override void Invoke(EventBase evt, PropagationPhase propagationPhase)
		{
			bool flag = evt == null;
			if (flag)
			{
				throw new ArgumentNullException("evt");
			}
			bool flag2 = evt.eventTypeId != this.m_EventTypeId;
			if (!flag2)
			{
				bool flag3 = base.PhaseMatches(propagationPhase);
				if (flag3)
				{
					using (new EventDebuggerLogCall(this.m_Callback, evt))
					{
						this.m_Callback(evt as TEventType, this.userArgs);
					}
				}
			}
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x000332B4 File Offset: 0x000314B4
		public override bool IsEquivalentTo(long eventTypeId, Delegate callback, CallbackPhase phase)
		{
			return this.m_EventTypeId == eventTypeId && this.m_Callback == callback && base.phase == phase;
		}

		// Token: 0x0400062D RID: 1581
		private readonly EventCallback<TEventType, TCallbackArgs> m_Callback;

		// Token: 0x0400062E RID: 1582
		private readonly long m_EventTypeId;
	}
}
