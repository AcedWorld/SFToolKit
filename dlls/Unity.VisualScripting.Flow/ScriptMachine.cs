using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200017C RID: 380
	[AddComponentMenu("Visual Scripting/Script Machine")]
	[RequireComponent(typeof(Variables))]
	[DisableAnnotation]
	[RenamedFrom("Bolt.FlowMachine")]
	[RenamedFrom("Unity.VisualScripting.FlowMachine")]
	public sealed class ScriptMachine : EventMachine<FlowGraph, ScriptGraphAsset>
	{
		// Token: 0x060009F0 RID: 2544 RVA: 0x00011B4A File Offset: 0x0000FD4A
		public override FlowGraph DefaultGraph()
		{
			return FlowGraph.WithStartUpdate();
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x00011B51 File Offset: 0x0000FD51
		protected override void OnEnable()
		{
			if (base.hasGraph)
			{
				base.graph.StartListening(base.reference);
			}
			base.OnEnable();
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00011B72 File Offset: 0x0000FD72
		protected override void OnInstantiateWhileEnabled()
		{
			if (base.hasGraph)
			{
				base.graph.StartListening(base.reference);
			}
			base.OnInstantiateWhileEnabled();
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00011B93 File Offset: 0x0000FD93
		protected override void OnUninstantiateWhileEnabled()
		{
			base.OnUninstantiateWhileEnabled();
			if (base.hasGraph)
			{
				base.graph.StopListening(base.reference);
			}
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x00011BB4 File Offset: 0x0000FDB4
		protected override void OnDisable()
		{
			base.OnDisable();
			if (base.hasGraph)
			{
				base.graph.StopListening(base.reference);
			}
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00011BD5 File Offset: 0x0000FDD5
		[ContextMenu("Show Data...")]
		protected override void ShowData()
		{
			base.ShowData();
		}
	}
}
