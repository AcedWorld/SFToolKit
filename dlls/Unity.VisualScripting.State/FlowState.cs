using System;
using System.ComponentModel;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000004 RID: 4
	[SerializationVersion("A", new Type[]
	{

	})]
	[TypeIcon(typeof(FlowGraph))]
	[DisplayName("Script State")]
	public sealed class FlowState : NesterState<FlowGraph, ScriptGraphAsset>, IGraphEventListener
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002148 File Offset: 0x00000348
		public FlowState()
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002150 File Offset: 0x00000350
		public FlowState(ScriptGraphAsset macro) : base(macro)
		{
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000215C File Offset: 0x0000035C
		protected override void OnEnterImplementation(Flow flow)
		{
			if (flow.stack.TryEnterParentElement(this))
			{
				base.nest.graph.StartListening(flow.stack);
				flow.stack.TriggerEventHandler((EventHook hook) => hook == "OnEnterState", default(EmptyEventArgs), (IGraphParentElement parent) => parent is SubgraphUnit, false);
				flow.stack.ExitParentElement();
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021EC File Offset: 0x000003EC
		protected override void OnExitImplementation(Flow flow)
		{
			if (flow.stack.TryEnterParentElement(this))
			{
				flow.stack.TriggerEventHandler((EventHook hook) => hook == "OnExitState", default(EmptyEventArgs), (IGraphParentElement parent) => parent is SubgraphUnit, false);
				base.nest.graph.StopListening(flow.stack);
				flow.stack.ExitParentElement();
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000227B File Offset: 0x0000047B
		public void StartListening(GraphStack stack)
		{
			if (stack.TryEnterParentElement(this))
			{
				base.nest.graph.StartListening(stack);
				stack.ExitParentElement();
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000229D File Offset: 0x0000049D
		public void StopListening(GraphStack stack)
		{
			if (stack.TryEnterParentElement(this))
			{
				base.nest.graph.StopListening(stack);
				stack.ExitParentElement();
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022BF File Offset: 0x000004BF
		public bool IsListening(GraphPointer pointer)
		{
			return pointer.GetElementData<State.Data>(this).isActive;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000022CD File Offset: 0x000004CD
		public override FlowGraph DefaultGraph()
		{
			return FlowState.GraphWithEnterUpdateExit();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022D4 File Offset: 0x000004D4
		public static FlowState WithEnterUpdateExit()
		{
			return new FlowState
			{
				nest = 
				{
					source = GraphSource.Embed
				},
				nest = 
				{
					embed = FlowState.GraphWithEnterUpdateExit()
				}
			};
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000022F8 File Offset: 0x000004F8
		public static FlowGraph GraphWithEnterUpdateExit()
		{
			return new FlowGraph
			{
				units = 
				{
					new OnEnterState
					{
						position = new Vector2(-205f, -215f)
					},
					new Update
					{
						position = new Vector2(-161f, -38f)
					},
					new OnExitState
					{
						position = new Vector2(-205f, 145f)
					}
				}
			};
		}
	}
}
