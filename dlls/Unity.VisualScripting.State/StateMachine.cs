using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000018 RID: 24
	[AddComponentMenu("Visual Scripting/State Machine")]
	[RequireComponent(typeof(Variables))]
	[DisableAnnotation]
	public sealed class StateMachine : EventMachine<StateGraph, StateGraphAsset>
	{
		// Token: 0x0600008D RID: 141 RVA: 0x00002FB0 File Offset: 0x000011B0
		protected override void OnEnable()
		{
			if (base.hasGraph)
			{
				using (Flow flow = Flow.New(base.reference))
				{
					base.graph.Start(flow);
				}
			}
			base.OnEnable();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003000 File Offset: 0x00001200
		protected override void OnInstantiateWhileEnabled()
		{
			if (base.hasGraph)
			{
				using (Flow flow = Flow.New(base.reference))
				{
					base.graph.Start(flow);
				}
			}
			base.OnInstantiateWhileEnabled();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003050 File Offset: 0x00001250
		protected override void OnUninstantiateWhileEnabled()
		{
			base.OnUninstantiateWhileEnabled();
			if (base.hasGraph)
			{
				using (Flow flow = Flow.New(base.reference))
				{
					base.graph.Stop(flow);
				}
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000030A0 File Offset: 0x000012A0
		protected override void OnDisable()
		{
			base.OnDisable();
			if (base.hasGraph)
			{
				using (Flow flow = Flow.New(base.reference))
				{
					base.graph.Stop(flow);
				}
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000030F0 File Offset: 0x000012F0
		[ContextMenu("Show Data...")]
		protected override void ShowData()
		{
			base.ShowData();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000030F8 File Offset: 0x000012F8
		public override StateGraph DefaultGraph()
		{
			return StateGraph.WithStart();
		}
	}
}
