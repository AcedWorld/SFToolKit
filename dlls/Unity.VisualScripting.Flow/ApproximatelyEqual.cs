using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000B6 RID: 182
	[UnitCategory("Logic")]
	[UnitShortTitle("Equal")]
	[UnitSubtitle("(Approximately)")]
	[UnitOrder(7)]
	[Obsolete("Use the Equal node with Numeric enabled instead.")]
	public sealed class ApproximatelyEqual : Unit
	{
		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x0000B19F File Offset: 0x0000939F
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x0000B1A7 File Offset: 0x000093A7
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x0000B1B0 File Offset: 0x000093B0
		// (set) Token: 0x0600054D RID: 1357 RVA: 0x0000B1B8 File Offset: 0x000093B8
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x0000B1C1 File Offset: 0x000093C1
		// (set) Token: 0x0600054F RID: 1359 RVA: 0x0000B1C9 File Offset: 0x000093C9
		[DoNotSerialize]
		[PortLabel("A ≈ B")]
		public ValueOutput equal { get; private set; }

		// Token: 0x06000550 RID: 1360 RVA: 0x0000B1D4 File Offset: 0x000093D4
		protected override void Definition()
		{
			this.a = base.ValueInput<float>("a");
			this.b = base.ValueInput<float>("b", 0f);
			this.equal = base.ValueOutput<bool>("equal", new Func<Flow, bool>(this.Comparison)).Predictable();
			base.Requirement(this.a, this.equal);
			base.Requirement(this.b, this.equal);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0000B24E File Offset: 0x0000944E
		public bool Comparison(Flow flow)
		{
			return Mathf.Approximately(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b));
		}
	}
}
