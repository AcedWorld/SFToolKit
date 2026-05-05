using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200005C RID: 92
	[SerializationVersion("A", new Type[]
	{

	})]
	[SpecialUnit]
	public abstract class EventUnit<TArgs> : Unit, IEventUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener, IGraphElementWithData, IGraphEventHandler<TArgs>
	{
		// Token: 0x06000364 RID: 868 RVA: 0x00008AA5 File Offset: 0x00006CA5
		public virtual IGraphElementData CreateData()
		{
			return new EventUnit<TArgs>.Data();
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000365 RID: 869 RVA: 0x00008AAC File Offset: 0x00006CAC
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00008AB4 File Offset: 0x00006CB4
		[Serialize]
		[Inspectable]
		[InspectorExpandTooltip]
		public bool coroutine { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00008ABD File Offset: 0x00006CBD
		// (set) Token: 0x06000368 RID: 872 RVA: 0x00008AC5 File Offset: 0x00006CC5
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput trigger { get; private set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000369 RID: 873
		[DoNotSerialize]
		protected abstract bool register { get; }

		// Token: 0x0600036A RID: 874 RVA: 0x00008ACE File Offset: 0x00006CCE
		protected override void Definition()
		{
			this.isControlRoot = true;
			this.trigger = base.ControlOutput("trigger");
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00008AE8 File Offset: 0x00006CE8
		public virtual EventHook GetHook(GraphReference reference)
		{
			throw new InvalidImplementationException(string.Format("Missing event hook for '{0}'.", this));
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00008AFC File Offset: 0x00006CFC
		public virtual void StartListening(GraphStack stack)
		{
			EventUnit<TArgs>.Data elementData = stack.GetElementData<EventUnit<TArgs>.Data>(this);
			if (elementData.isListening)
			{
				return;
			}
			if (this.register)
			{
				GraphReference reference = stack.ToReference();
				EventHook hook = this.GetHook(reference);
				Action<TArgs> handler = delegate(TArgs args)
				{
					this.Trigger(reference, args);
				};
				EventBus.Register<TArgs>(hook, handler);
				elementData.hook = hook;
				elementData.handler = handler;
			}
			elementData.isListening = true;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00008B74 File Offset: 0x00006D74
		public virtual void StopListening(GraphStack stack)
		{
			EventUnit<TArgs>.Data elementData = stack.GetElementData<EventUnit<TArgs>.Data>(this);
			if (!elementData.isListening)
			{
				return;
			}
			foreach (Flow flow in elementData.activeCoroutines)
			{
				flow.StopCoroutine(false);
			}
			if (this.register)
			{
				EventBus.Unregister(elementData.hook, elementData.handler);
				stack.ClearReference();
				elementData.handler = null;
			}
			elementData.isListening = false;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00008C04 File Offset: 0x00006E04
		public override void Uninstantiate(GraphReference instance)
		{
			EventUnit<TArgs>.StopAllCoroutines(instance.GetElementData<EventUnit<TArgs>.Data>(this).activeCoroutines.ToHashSetPooled<Flow>());
			base.Uninstantiate(instance);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00008C24 File Offset: 0x00006E24
		private static void StopAllCoroutines(HashSet<Flow> activeCoroutines)
		{
			foreach (Flow flow in activeCoroutines)
			{
				flow.StopCoroutineImmediate();
			}
			activeCoroutines.Free<Flow>();
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00008C78 File Offset: 0x00006E78
		public bool IsListening(GraphPointer pointer)
		{
			return pointer.hasData && pointer.GetElementData<EventUnit<TArgs>.Data>(this).isListening;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00008C90 File Offset: 0x00006E90
		public void Trigger(GraphReference reference, TArgs args)
		{
			this.InternalTrigger(reference, args);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00008C9C File Offset: 0x00006E9C
		private protected virtual void InternalTrigger(GraphReference reference, TArgs args)
		{
			Flow flow = Flow.New(reference);
			if (!this.ShouldTrigger(flow, args))
			{
				flow.Dispose();
				return;
			}
			this.AssignArguments(flow, args);
			this.Run(flow);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00008CD0 File Offset: 0x00006ED0
		protected virtual bool ShouldTrigger(Flow flow, TArgs args)
		{
			return true;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00008CD3 File Offset: 0x00006ED3
		protected virtual void AssignArguments(Flow flow, TArgs args)
		{
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00008CD8 File Offset: 0x00006ED8
		private void Run(Flow flow)
		{
			if (flow.enableDebug)
			{
				IUnitDebugData elementDebugData = flow.stack.GetElementDebugData<IUnitDebugData>(this);
				elementDebugData.lastInvokeFrame = EditorTimeBinding.frame;
				elementDebugData.lastInvokeTime = EditorTimeBinding.time;
			}
			if (this.coroutine)
			{
				flow.StartCoroutine(this.trigger, flow.stack.GetElementData<EventUnit<TArgs>.Data>(this).activeCoroutines);
				return;
			}
			flow.Run(this.trigger);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00008D40 File Offset: 0x00006F40
		protected static bool CompareNames(Flow flow, ValueInput namePort, string calledName)
		{
			Ensure.That("calledName").IsNotNull(calledName);
			string text = calledName.Trim();
			string value = flow.GetValue<string>(namePort);
			return text.Equals((value != null) ? value.Trim() : null, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00008D79 File Offset: 0x00006F79
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}

		// Token: 0x020001B0 RID: 432
		public class Data : IGraphElementData
		{
			// Token: 0x0400039C RID: 924
			public EventHook hook;

			// Token: 0x0400039D RID: 925
			public Delegate handler;

			// Token: 0x0400039E RID: 926
			public bool isListening;

			// Token: 0x0400039F RID: 927
			public HashSet<Flow> activeCoroutines = new HashSet<Flow>();
		}
	}
}
