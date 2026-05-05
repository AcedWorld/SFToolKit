using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000015 RID: 21
	[SerializationVersion("A", new Type[]
	{

	})]
	public sealed class StateGraph : Graph, IGraphEventListener
	{
		// Token: 0x06000076 RID: 118 RVA: 0x00002BB8 File Offset: 0x00000DB8
		public StateGraph()
		{
			this.states = new GraphElementCollection<IState>(this);
			this.transitions = new GraphConnectionCollection<IStateTransition, IState, IState>(this);
			this.groups = new GraphElementCollection<GraphGroup>(this);
			this.sticky = new GraphElementCollection<StickyNote>(this);
			base.elements.Include<IState>(this.states);
			base.elements.Include<IStateTransition>(this.transitions);
			base.elements.Include<GraphGroup>(this.groups);
			base.elements.Include<StickyNote>(this.sticky);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002C3F File Offset: 0x00000E3F
		public override IGraphData CreateData()
		{
			return new StateGraphData(this);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002C48 File Offset: 0x00000E48
		public void StartListening(GraphStack stack)
		{
			stack.GetGraphData<StateGraphData>().isListening = true;
			HashSet<IState> activeStatesNoAlloc = this.GetActiveStatesNoAlloc(stack);
			foreach (IState state in activeStatesNoAlloc)
			{
				IGraphEventListener graphEventListener = state as IGraphEventListener;
				if (graphEventListener != null)
				{
					graphEventListener.StartListening(stack);
				}
			}
			activeStatesNoAlloc.Free<IState>();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002CBC File Offset: 0x00000EBC
		public void StopListening(GraphStack stack)
		{
			HashSet<IState> activeStatesNoAlloc = this.GetActiveStatesNoAlloc(stack);
			foreach (IState state in activeStatesNoAlloc)
			{
				IGraphEventListener graphEventListener = state as IGraphEventListener;
				if (graphEventListener != null)
				{
					graphEventListener.StopListening(stack);
				}
			}
			activeStatesNoAlloc.Free<IState>();
			stack.GetGraphData<StateGraphData>().isListening = false;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002D30 File Offset: 0x00000F30
		public bool IsListening(GraphPointer pointer)
		{
			return pointer.GetGraphData<StateGraphData>().isListening;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002D3D File Offset: 0x00000F3D
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00002D45 File Offset: 0x00000F45
		[DoNotSerialize]
		public GraphElementCollection<IState> states { get; internal set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002D4E File Offset: 0x00000F4E
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00002D56 File Offset: 0x00000F56
		[DoNotSerialize]
		public GraphConnectionCollection<IStateTransition, IState, IState> transitions { get; internal set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002D5F File Offset: 0x00000F5F
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00002D67 File Offset: 0x00000F67
		[DoNotSerialize]
		public GraphElementCollection<GraphGroup> groups { get; internal set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00002D70 File Offset: 0x00000F70
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00002D78 File Offset: 0x00000F78
		[DoNotSerialize]
		public GraphElementCollection<StickyNote> sticky { get; private set; }

		// Token: 0x06000083 RID: 131 RVA: 0x00002D84 File Offset: 0x00000F84
		private HashSet<IState> GetActiveStatesNoAlloc(GraphPointer pointer)
		{
			HashSet<IState> hashSet = HashSetPool<IState>.New();
			foreach (IState state in this.states)
			{
				if (pointer.GetElementData<State.Data>(state).isActive)
				{
					hashSet.Add(state);
				}
			}
			return hashSet;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002DF0 File Offset: 0x00000FF0
		public void Start(Flow flow)
		{
			flow.stack.GetGraphData<StateGraphData>().isListening = true;
			foreach (IState state in from s in this.states
			where s.isStart
			select s)
			{
				try
				{
					state.OnEnter(flow, StateEnterReason.Start);
				}
				catch (Exception ex)
				{
					state.HandleException(flow.stack, ex);
					throw;
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002E94 File Offset: 0x00001094
		public void Stop(Flow flow)
		{
			HashSet<IState> activeStatesNoAlloc = this.GetActiveStatesNoAlloc(flow.stack);
			foreach (IState state in activeStatesNoAlloc)
			{
				try
				{
					state.OnExit(flow, StateExitReason.Stop);
				}
				catch (Exception ex)
				{
					state.HandleException(flow.stack, ex);
					throw;
				}
			}
			activeStatesNoAlloc.Free<IState>();
			flow.stack.GetGraphData<StateGraphData>().isListening = false;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002F28 File Offset: 0x00001128
		public static StateGraph WithStart()
		{
			StateGraph stateGraph = new StateGraph();
			FlowState flowState = FlowState.WithEnterUpdateExit();
			flowState.isStart = true;
			flowState.nest.embed.title = "Start";
			flowState.position = new Vector2(-86f, -15f);
			stateGraph.states.Add(flowState);
			return stateGraph;
		}
	}
}
