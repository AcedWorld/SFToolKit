using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000AB RID: 171
	[UnitCategory("Graphs/Graph Nodes")]
	public abstract class GetGraph<TGraph, TGraphAsset, TMachine> : Unit where TGraph : class, IGraph, new() where TGraphAsset : Macro<TGraph> where TMachine : Machine<TGraph, TGraphAsset>
	{
		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0000A9C9 File Offset: 0x00008BC9
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x0000A9D1 File Offset: 0x00008BD1
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput gameObject { get; protected set; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x0000A9DA File Offset: 0x00008BDA
		// (set) Token: 0x06000500 RID: 1280 RVA: 0x0000A9E2 File Offset: 0x00008BE2
		[DoNotSerialize]
		[PortLabel("Graph")]
		[PortLabelHidden]
		public ValueOutput graphOutput { get; protected set; }

		// Token: 0x06000501 RID: 1281 RVA: 0x0000A9EB File Offset: 0x00008BEB
		protected override void Definition()
		{
			this.gameObject = base.ValueInput<GameObject>("gameObject", null).NullMeansSelf();
			this.graphOutput = base.ValueOutput<TGraphAsset>("graphOutput", new Func<Flow, TGraphAsset>(this.Get));
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0000AA21 File Offset: 0x00008C21
		private TGraphAsset Get(Flow flow)
		{
			return flow.GetValue<GameObject>(this.gameObject).GetComponent<TMachine>().nest.macro;
		}
	}
}
