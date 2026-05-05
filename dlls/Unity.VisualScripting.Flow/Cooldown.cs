using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200012F RID: 303
	[UnitCategory("Time")]
	[TypeIcon(typeof(Timer))]
	[UnitOrder(8)]
	public sealed class Cooldown : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
	{
		// Token: 0x170002BD RID: 701
		// (get) Token: 0x060007DC RID: 2012 RVA: 0x0000E9E8 File Offset: 0x0000CBE8
		// (set) Token: 0x060007DD RID: 2013 RVA: 0x0000E9F0 File Offset: 0x0000CBF0
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x0000E9F9 File Offset: 0x0000CBF9
		// (set) Token: 0x060007DF RID: 2015 RVA: 0x0000EA01 File Offset: 0x0000CC01
		[DoNotSerialize]
		public ControlInput reset { get; private set; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x0000EA0A File Offset: 0x0000CC0A
		// (set) Token: 0x060007E1 RID: 2017 RVA: 0x0000EA12 File Offset: 0x0000CC12
		[DoNotSerialize]
		public ValueInput duration { get; private set; }

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x060007E2 RID: 2018 RVA: 0x0000EA1B File Offset: 0x0000CC1B
		// (set) Token: 0x060007E3 RID: 2019 RVA: 0x0000EA23 File Offset: 0x0000CC23
		[DoNotSerialize]
		[PortLabel("Unscaled")]
		public ValueInput unscaledTime { get; private set; }

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x060007E4 RID: 2020 RVA: 0x0000EA2C File Offset: 0x0000CC2C
		// (set) Token: 0x060007E5 RID: 2021 RVA: 0x0000EA34 File Offset: 0x0000CC34
		[DoNotSerialize]
		[PortLabel("Ready")]
		public ControlOutput exitReady { get; private set; }

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x0000EA3D File Offset: 0x0000CC3D
		// (set) Token: 0x060007E7 RID: 2023 RVA: 0x0000EA45 File Offset: 0x0000CC45
		[DoNotSerialize]
		[PortLabel("Not Ready")]
		public ControlOutput exitNotReady { get; private set; }

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x0000EA4E File Offset: 0x0000CC4E
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x0000EA56 File Offset: 0x0000CC56
		[DoNotSerialize]
		public ControlOutput tick { get; private set; }

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x0000EA5F File Offset: 0x0000CC5F
		// (set) Token: 0x060007EB RID: 2027 RVA: 0x0000EA67 File Offset: 0x0000CC67
		[DoNotSerialize]
		[PortLabel("Completed")]
		public ControlOutput becameReady { get; private set; }

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x0000EA70 File Offset: 0x0000CC70
		// (set) Token: 0x060007ED RID: 2029 RVA: 0x0000EA78 File Offset: 0x0000CC78
		[DoNotSerialize]
		[PortLabel("Remaining")]
		public ValueOutput remainingSeconds { get; private set; }

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x0000EA81 File Offset: 0x0000CC81
		// (set) Token: 0x060007EF RID: 2031 RVA: 0x0000EA89 File Offset: 0x0000CC89
		[DoNotSerialize]
		[PortLabel("Remaining %")]
		public ValueOutput remainingRatio { get; private set; }

		// Token: 0x060007F0 RID: 2032 RVA: 0x0000EA94 File Offset: 0x0000CC94
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.reset = base.ControlInput("reset", new Func<Flow, ControlOutput>(this.Reset));
			this.duration = base.ValueInput<float>("duration", 1f);
			this.unscaledTime = base.ValueInput<bool>("unscaledTime", false);
			this.exitReady = base.ControlOutput("exitReady");
			this.exitNotReady = base.ControlOutput("exitNotReady");
			this.tick = base.ControlOutput("tick");
			this.becameReady = base.ControlOutput("becameReady");
			this.remainingSeconds = base.ValueOutput<float>("remainingSeconds");
			this.remainingRatio = base.ValueOutput<float>("remainingRatio");
			base.Requirement(this.duration, this.enter);
			base.Requirement(this.unscaledTime, this.enter);
			base.Succession(this.enter, this.exitReady);
			base.Succession(this.enter, this.exitNotReady);
			base.Succession(this.enter, this.tick);
			base.Succession(this.enter, this.becameReady);
			base.Assignment(this.enter, this.remainingSeconds);
			base.Assignment(this.enter, this.remainingRatio);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0000EBF9 File Offset: 0x0000CDF9
		public IGraphElementData CreateData()
		{
			return new Cooldown.Data();
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0000EC00 File Offset: 0x0000CE00
		public void StartListening(GraphStack stack)
		{
			Cooldown.Data elementData = stack.GetElementData<Cooldown.Data>(this);
			if (elementData.isListening)
			{
				return;
			}
			GraphReference reference = stack.ToReference();
			EventHook hook = new EventHook("Update", stack.machine, null);
			Action<EmptyEventArgs> action = delegate(EmptyEventArgs args)
			{
				this.TriggerUpdate(reference);
			};
			EventBus.Register<EmptyEventArgs>(hook, action);
			elementData.update = action;
			elementData.isListening = true;
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		public void StopListening(GraphStack stack)
		{
			Cooldown.Data elementData = stack.GetElementData<Cooldown.Data>(this);
			if (!elementData.isListening)
			{
				return;
			}
			EventBus.Unregister(new EventHook("Update", stack.machine, null), elementData.update);
			stack.ClearReference();
			elementData.update = null;
			elementData.isListening = false;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0000ECBA File Offset: 0x0000CEBA
		public bool IsListening(GraphPointer pointer)
		{
			return pointer.GetElementData<Cooldown.Data>(this).isListening;
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0000ECC8 File Offset: 0x0000CEC8
		private void TriggerUpdate(GraphReference reference)
		{
			using (Flow flow = Flow.New(reference))
			{
				this.Update(flow);
			}
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0000ED00 File Offset: 0x0000CF00
		private ControlOutput Enter(Flow flow)
		{
			if (flow.stack.GetElementData<Cooldown.Data>(this).isReady)
			{
				return this.Reset(flow);
			}
			return this.exitNotReady;
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0000ED24 File Offset: 0x0000CF24
		private ControlOutput Reset(Flow flow)
		{
			Cooldown.Data elementData = flow.stack.GetElementData<Cooldown.Data>(this);
			elementData.duration = flow.GetValue<float>(this.duration);
			elementData.remaining = elementData.duration;
			elementData.unscaled = flow.GetValue<bool>(this.unscaledTime);
			return this.exitReady;
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0000ED72 File Offset: 0x0000CF72
		private void AssignMetrics(Flow flow, Cooldown.Data data)
		{
			flow.SetValue(this.remainingSeconds, data.remaining);
			flow.SetValue(this.remainingRatio, Mathf.Clamp01(data.remaining / data.duration));
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0000EDB0 File Offset: 0x0000CFB0
		public void Update(Flow flow)
		{
			Cooldown.Data elementData = flow.stack.GetElementData<Cooldown.Data>(this);
			if (elementData.isReady)
			{
				return;
			}
			elementData.remaining -= (elementData.unscaled ? Time.unscaledDeltaTime : Time.deltaTime);
			elementData.remaining = Mathf.Max(0f, elementData.remaining);
			this.AssignMetrics(flow, elementData);
			GraphStack stack = flow.PreserveStack();
			flow.Invoke(this.tick);
			if (elementData.isReady)
			{
				flow.RestoreStack(stack);
				flow.Invoke(this.becameReady);
			}
			flow.DisposePreservedStack(stack);
		}

		// Token: 0x020001BC RID: 444
		public sealed class Data : IGraphElementData
		{
			// Token: 0x170003CA RID: 970
			// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x0001B475 File Offset: 0x00019675
			public bool isReady
			{
				get
				{
					return this.remaining <= 0f;
				}
			}

			// Token: 0x040003B4 RID: 948
			public float remaining;

			// Token: 0x040003B5 RID: 949
			public float duration;

			// Token: 0x040003B6 RID: 950
			public bool unscaled;

			// Token: 0x040003B7 RID: 951
			public Delegate update;

			// Token: 0x040003B8 RID: 952
			public bool isListening;
		}
	}
}
