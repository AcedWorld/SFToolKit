using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020001A9 RID: 425
	internal abstract class EventCallbackFunctorBase
	{
		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000D0F RID: 3343 RVA: 0x0003307F File Offset: 0x0003127F
		public CallbackPhase phase { get; }

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000D10 RID: 3344 RVA: 0x00033087 File Offset: 0x00031287
		public InvokePolicy invokePolicy { get; }

		// Token: 0x06000D11 RID: 3345 RVA: 0x0003308F File Offset: 0x0003128F
		protected EventCallbackFunctorBase(CallbackPhase phase, InvokePolicy invokePolicy)
		{
			this.phase = phase;
			this.invokePolicy = invokePolicy;
		}

		// Token: 0x06000D12 RID: 3346
		public abstract void Invoke(EventBase evt, PropagationPhase propagationPhase);

		// Token: 0x06000D13 RID: 3347
		public abstract bool IsEquivalentTo(long eventTypeId, Delegate callback, CallbackPhase phase);

		// Token: 0x06000D14 RID: 3348 RVA: 0x000330A8 File Offset: 0x000312A8
		protected bool PhaseMatches(PropagationPhase propagationPhase)
		{
			CallbackPhase phase = this.phase;
			CallbackPhase callbackPhase = phase;
			if (callbackPhase != CallbackPhase.TargetAndBubbleUp)
			{
				if (callbackPhase == CallbackPhase.TrickleDownAndTarget)
				{
					bool flag = propagationPhase != PropagationPhase.TrickleDown && propagationPhase != PropagationPhase.AtTarget;
					if (flag)
					{
						return false;
					}
				}
			}
			else
			{
				bool flag2 = propagationPhase != PropagationPhase.AtTarget && propagationPhase != PropagationPhase.BubbleUp;
				if (flag2)
				{
					return false;
				}
			}
			return true;
		}
	}
}
