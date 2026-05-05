using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200001B RID: 27
	[TypeIcon(typeof(StateGraph))]
	public sealed class SuperState : NesterState<StateGraph, StateGraphAsset>, IGraphEventListener
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x00003418 File Offset: 0x00001618
		public SuperState()
		{
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003420 File Offset: 0x00001620
		public SuperState(StateGraphAsset macro) : base(macro)
		{
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003429 File Offset: 0x00001629
		public static SuperState WithStart()
		{
			return new SuperState
			{
				nest = 
				{
					source = GraphSource.Embed
				},
				nest = 
				{
					embed = StateGraph.WithStart()
				}
			};
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000344C File Offset: 0x0000164C
		protected override void OnEnterImplementation(Flow flow)
		{
			if (flow.stack.TryEnterParentElement(this))
			{
				base.nest.graph.Start(flow);
				flow.stack.ExitParentElement();
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003478 File Offset: 0x00001678
		protected override void OnExitImplementation(Flow flow)
		{
			if (flow.stack.TryEnterParentElement(this))
			{
				base.nest.graph.Stop(flow);
				flow.stack.ExitParentElement();
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000034A4 File Offset: 0x000016A4
		public void StartListening(GraphStack stack)
		{
			if (stack.TryEnterParentElement(this))
			{
				base.nest.graph.StartListening(stack);
				stack.ExitParentElement();
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000034C6 File Offset: 0x000016C6
		public void StopListening(GraphStack stack)
		{
			if (stack.TryEnterParentElement(this))
			{
				base.nest.graph.StopListening(stack);
				stack.ExitParentElement();
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000034E8 File Offset: 0x000016E8
		public bool IsListening(GraphPointer pointer)
		{
			return pointer.GetElementData<State.Data>(this).isActive;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000034F6 File Offset: 0x000016F6
		public override StateGraph DefaultGraph()
		{
			return StateGraph.WithStart();
		}
	}
}
