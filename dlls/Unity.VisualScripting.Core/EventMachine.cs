using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000056 RID: 86
	public abstract class EventMachine<TGraph, TMacro> : Machine<TGraph, TMacro>, IEventMachine, IMachine, IGraphRoot, IGraphParent, IGraphNester, IAotStubbable where TGraph : class, IGraph, new() where TMacro : Macro<TGraph>, new()
	{
		// Token: 0x06000271 RID: 625 RVA: 0x000062AC File Offset: 0x000044AC
		protected void TriggerEvent(string name)
		{
			if (base.hasGraph)
			{
				this.TriggerRegisteredEvent<EmptyEventArgs>(new EventHook(name, this, null), default(EmptyEventArgs));
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000062D8 File Offset: 0x000044D8
		protected void TriggerEvent<TArgs>(string name, TArgs args)
		{
			if (base.hasGraph)
			{
				this.TriggerRegisteredEvent<TArgs>(new EventHook(name, this, null), args);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x000062F4 File Offset: 0x000044F4
		protected void TriggerUnregisteredEvent(string name)
		{
			if (base.hasGraph)
			{
				this.TriggerUnregisteredEvent<EmptyEventArgs>(name, default(EmptyEventArgs));
			}
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000631E File Offset: 0x0000451E
		protected virtual void TriggerRegisteredEvent<TArgs>(EventHook hook, TArgs args)
		{
			EventBus.Trigger<TArgs>(hook, args);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00006328 File Offset: 0x00004528
		protected virtual void TriggerUnregisteredEvent<TArgs>(EventHook hook, TArgs args)
		{
			using (GraphStack graphStack = base.reference.ToStackPooled())
			{
				graphStack.TriggerEventHandler((EventHook _hook) => _hook == hook, args, (IGraphParentElement parent) => true, true);
				graphStack.ClearReference();
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000063A4 File Offset: 0x000045A4
		protected override void Awake()
		{
			base.Awake();
			GlobalMessageListener.Require();
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000063B1 File Offset: 0x000045B1
		protected override void OnEnable()
		{
			base.OnEnable();
			this.TriggerEvent("OnEnable");
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000063C4 File Offset: 0x000045C4
		protected virtual void Start()
		{
			this.TriggerEvent("Start");
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000063D1 File Offset: 0x000045D1
		protected override void OnInstantiateWhileEnabled()
		{
			base.OnInstantiateWhileEnabled();
			this.TriggerEvent("OnEnable");
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000063E4 File Offset: 0x000045E4
		protected virtual void Update()
		{
			this.TriggerEvent("Update");
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000063F1 File Offset: 0x000045F1
		protected virtual void FixedUpdate()
		{
			this.TriggerEvent("FixedUpdate");
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000063FE File Offset: 0x000045FE
		protected virtual void LateUpdate()
		{
			this.TriggerEvent("LateUpdate");
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000640B File Offset: 0x0000460B
		protected override void OnUninstantiateWhileEnabled()
		{
			this.TriggerEvent("OnDisable");
			base.OnUninstantiateWhileEnabled();
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000641E File Offset: 0x0000461E
		protected override void OnDisable()
		{
			this.TriggerEvent("OnDisable");
			base.OnDisable();
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00006434 File Offset: 0x00004634
		protected override void OnDestroy()
		{
			try
			{
				this.TriggerEvent("OnDestroy");
			}
			finally
			{
				base.OnDestroy();
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00006468 File Offset: 0x00004668
		public override void TriggerAnimationEvent(AnimationEvent animationEvent)
		{
			this.TriggerEvent<AnimationEvent>("AnimationEvent", animationEvent);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00006476 File Offset: 0x00004676
		public override void TriggerUnityEvent(string name)
		{
			this.TriggerEvent<string>("UnityEvent", name);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00006484 File Offset: 0x00004684
		protected virtual void OnDrawGizmos()
		{
			this.TriggerUnregisteredEvent("OnDrawGizmos");
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00006491 File Offset: 0x00004691
		protected virtual void OnDrawGizmosSelected()
		{
			this.TriggerUnregisteredEvent("OnDrawGizmosSelected");
		}
	}
}
