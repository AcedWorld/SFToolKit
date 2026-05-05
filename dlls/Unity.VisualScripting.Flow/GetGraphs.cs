using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000AC RID: 172
	[UnitCategory("Graphs/Graph Nodes")]
	public abstract class GetGraphs<TGraph, TGraphAsset, TMachine> : Unit where TGraph : class, IGraph, new() where TGraphAsset : Macro<TGraph> where TMachine : Machine<TGraph, TGraphAsset>
	{
		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x0000AA4B File Offset: 0x00008C4B
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x0000AA53 File Offset: 0x00008C53
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput gameObject { get; protected set; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x0000AA5C File Offset: 0x00008C5C
		// (set) Token: 0x06000507 RID: 1287 RVA: 0x0000AA64 File Offset: 0x00008C64
		[DoNotSerialize]
		[PortLabel("Graphs")]
		[PortLabelHidden]
		public ValueOutput graphList { get; protected set; }

		// Token: 0x06000508 RID: 1288 RVA: 0x0000AA6D File Offset: 0x00008C6D
		protected override void Definition()
		{
			this.gameObject = base.ValueInput<GameObject>("gameObject", null).NullMeansSelf();
			this.graphList = base.ValueOutput<List<TGraphAsset>>("graphList", new Func<Flow, List<TGraphAsset>>(this.Get));
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0000AAA4 File Offset: 0x00008CA4
		private List<TGraphAsset> Get(Flow flow)
		{
			GameObject go = flow.GetValue<GameObject>(this.gameObject);
			return (from machine in go.GetComponents<TMachine>()
			where go.GetComponent<TMachine>().nest.macro != null
			select machine.nest.macro).ToList<TGraphAsset>();
		}
	}
}
