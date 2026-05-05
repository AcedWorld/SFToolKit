using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000130 RID: 304
	[UnitCategory("Time")]
	[UnitOrder(7)]
	public sealed class Timer : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
	{
		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x0000EE4F File Offset: 0x0000D04F
		// (set) Token: 0x060007FC RID: 2044 RVA: 0x0000EE57 File Offset: 0x0000D057
		[DoNotSerialize]
		public ControlInput start { get; private set; }

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x0000EE60 File Offset: 0x0000D060
		// (set) Token: 0x060007FE RID: 2046 RVA: 0x0000EE68 File Offset: 0x0000D068
		[DoNotSerialize]
		public ControlInput pause { get; private set; }

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x0000EE71 File Offset: 0x0000D071
		// (set) Token: 0x06000800 RID: 2048 RVA: 0x0000EE79 File Offset: 0x0000D079
		[DoNotSerialize]
		public ControlInput resume { get; private set; }

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x0000EE82 File Offset: 0x0000D082
		// (set) Token: 0x06000802 RID: 2050 RVA: 0x0000EE8A File Offset: 0x0000D08A
		[DoNotSerialize]
		public ControlInput toggle { get; private set; }

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0000EE93 File Offset: 0x0000D093
		// (set) Token: 0x06000804 RID: 2052 RVA: 0x0000EE9B File Offset: 0x0000D09B
		[DoNotSerialize]
		public ValueInput duration { get; private set; }

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x0000EEA4 File Offset: 0x0000D0A4
		// (set) Token: 0x06000806 RID: 2054 RVA: 0x0000EEAC File Offset: 0x0000D0AC
		[DoNotSerialize]
		[PortLabel("Unscaled")]
		public ValueInput unscaledTime { get; private set; }

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x0000EEB5 File Offset: 0x0000D0B5
		// (set) Token: 0x06000808 RID: 2056 RVA: 0x0000EEBD File Offset: 0x0000D0BD
		[DoNotSerialize]
		public ControlOutput started { get; private set; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x0000EEC6 File Offset: 0x0000D0C6
		// (set) Token: 0x0600080A RID: 2058 RVA: 0x0000EECE File Offset: 0x0000D0CE
		[DoNotSerialize]
		public ControlOutput tick { get; private set; }

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x0000EED7 File Offset: 0x0000D0D7
		// (set) Token: 0x0600080C RID: 2060 RVA: 0x0000EEDF File Offset: 0x0000D0DF
		[DoNotSerialize]
		public ControlOutput completed { get; private set; }

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x0000EEE8 File Offset: 0x0000D0E8
		// (set) Token: 0x0600080E RID: 2062 RVA: 0x0000EEF0 File Offset: 0x0000D0F0
		[DoNotSerialize]
		[PortLabel("Elapsed")]
		public ValueOutput elapsedSeconds { get; private set; }

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x0000EEF9 File Offset: 0x0000D0F9
		// (set) Token: 0x06000810 RID: 2064 RVA: 0x0000EF01 File Offset: 0x0000D101
		[DoNotSerialize]
		[PortLabel("Elapsed %")]
		public ValueOutput elapsedRatio { get; private set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x0000EF0A File Offset: 0x0000D10A
		// (set) Token: 0x06000812 RID: 2066 RVA: 0x0000EF12 File Offset: 0x0000D112
		[DoNotSerialize]
		[PortLabel("Remaining")]
		public ValueOutput remainingSeconds { get; private set; }

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0000EF1B File Offset: 0x0000D11B
		// (set) Token: 0x06000814 RID: 2068 RVA: 0x0000EF23 File Offset: 0x0000D123
		[DoNotSerialize]
		[PortLabel("Remaining %")]
		public ValueOutput remainingRatio { get; private set; }

		// Token: 0x06000815 RID: 2069 RVA: 0x0000EF2C File Offset: 0x0000D12C
		protected override void Definition()
		{
			this.isControlRoot = true;
			this.start = base.ControlInput("start", new Func<Flow, ControlOutput>(this.Start));
			this.pause = base.ControlInput("pause", new Func<Flow, ControlOutput>(this.Pause));
			this.resume = base.ControlInput("resume", new Func<Flow, ControlOutput>(this.Resume));
			this.toggle = base.ControlInput("toggle", new Func<Flow, ControlOutput>(this.Toggle));
			this.duration = base.ValueInput<float>("duration", 1f);
			this.unscaledTime = base.ValueInput<bool>("unscaledTime", false);
			this.started = base.ControlOutput("started");
			this.tick = base.ControlOutput("tick");
			this.completed = base.ControlOutput("completed");
			this.elapsedSeconds = base.ValueOutput<float>("elapsedSeconds");
			this.elapsedRatio = base.ValueOutput<float>("elapsedRatio");
			this.remainingSeconds = base.ValueOutput<float>("remainingSeconds");
			this.remainingRatio = base.ValueOutput<float>("remainingRatio");
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0000F053 File Offset: 0x0000D253
		public IGraphElementData CreateData()
		{
			return new Timer.Data();
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0000F05C File Offset: 0x0000D25C
		public void StartListening(GraphStack stack)
		{
			Timer.Data elementData = stack.GetElementData<Timer.Data>(this);
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

		// Token: 0x06000818 RID: 2072 RVA: 0x0000F0C8 File Offset: 0x0000D2C8
		public void StopListening(GraphStack stack)
		{
			Timer.Data elementData = stack.GetElementData<Timer.Data>(this);
			if (!elementData.isListening)
			{
				return;
			}
			EventBus.Unregister(new EventHook("Update", stack.machine, null), elementData.update);
			stack.ClearReference();
			elementData.update = null;
			elementData.isListening = false;
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0000F116 File Offset: 0x0000D316
		public bool IsListening(GraphPointer pointer)
		{
			return pointer.GetElementData<Timer.Data>(this).isListening;
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0000F124 File Offset: 0x0000D324
		private void TriggerUpdate(GraphReference reference)
		{
			using (Flow flow = Flow.New(reference))
			{
				this.Update(flow);
			}
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0000F15C File Offset: 0x0000D35C
		private ControlOutput Start(Flow flow)
		{
			Timer.Data elementData = flow.stack.GetElementData<Timer.Data>(this);
			elementData.elapsed = 0f;
			elementData.duration = flow.GetValue<float>(this.duration);
			elementData.active = true;
			elementData.paused = false;
			elementData.unscaled = flow.GetValue<bool>(this.unscaledTime);
			this.AssignMetrics(flow, elementData);
			return this.started;
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0000F1C1 File Offset: 0x0000D3C1
		private ControlOutput Pause(Flow flow)
		{
			flow.stack.GetElementData<Timer.Data>(this).paused = true;
			return null;
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0000F1D6 File Offset: 0x0000D3D6
		private ControlOutput Resume(Flow flow)
		{
			flow.stack.GetElementData<Timer.Data>(this).paused = false;
			return null;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0000F1EC File Offset: 0x0000D3EC
		private ControlOutput Toggle(Flow flow)
		{
			Timer.Data elementData = flow.stack.GetElementData<Timer.Data>(this);
			if (!elementData.active)
			{
				return this.Start(flow);
			}
			elementData.paused = !elementData.paused;
			return null;
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0000F228 File Offset: 0x0000D428
		private void AssignMetrics(Flow flow, Timer.Data data)
		{
			flow.SetValue(this.elapsedSeconds, data.elapsed);
			flow.SetValue(this.elapsedRatio, Mathf.Clamp01(data.elapsed / data.duration));
			flow.SetValue(this.remainingSeconds, Mathf.Max(0f, data.duration - data.elapsed));
			flow.SetValue(this.remainingRatio, Mathf.Clamp01((data.duration - data.elapsed) / data.duration));
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0000F2C4 File Offset: 0x0000D4C4
		public void Update(Flow flow)
		{
			Timer.Data elementData = flow.stack.GetElementData<Timer.Data>(this);
			if (!elementData.active || elementData.paused)
			{
				return;
			}
			elementData.elapsed += (elementData.unscaled ? Time.unscaledDeltaTime : Time.deltaTime);
			elementData.elapsed = Mathf.Min(elementData.elapsed, elementData.duration);
			this.AssignMetrics(flow, elementData);
			GraphStack stack = flow.PreserveStack();
			flow.Invoke(this.tick);
			if (elementData.elapsed >= elementData.duration)
			{
				elementData.active = false;
				flow.RestoreStack(stack);
				flow.Invoke(this.completed);
			}
			flow.DisposePreservedStack(stack);
		}

		// Token: 0x020001BE RID: 446
		public sealed class Data : IGraphElementData
		{
			// Token: 0x040003BB RID: 955
			public float elapsed;

			// Token: 0x040003BC RID: 956
			public float duration;

			// Token: 0x040003BD RID: 957
			public bool active;

			// Token: 0x040003BE RID: 958
			public bool paused;

			// Token: 0x040003BF RID: 959
			public bool unscaled;

			// Token: 0x040003C0 RID: 960
			public Delegate update;

			// Token: 0x040003C1 RID: 961
			public bool isListening;
		}
	}
}
