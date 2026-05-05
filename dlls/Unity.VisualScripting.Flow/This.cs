using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200012E RID: 302
	[SpecialUnit]
	[RenamedFrom("Bolt.Self")]
	[RenamedFrom("Unity.VisualScripting.Self")]
	public sealed class This : Unit
	{
		// Token: 0x170002BC RID: 700
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x0000E97F File Offset: 0x0000CB7F
		// (set) Token: 0x060007D7 RID: 2007 RVA: 0x0000E987 File Offset: 0x0000CB87
		[DoNotSerialize]
		[PortLabelHidden]
		[PortLabel("This")]
		public ValueOutput self { get; private set; }

		// Token: 0x060007D8 RID: 2008 RVA: 0x0000E990 File Offset: 0x0000CB90
		protected override void Definition()
		{
			this.self = base.ValueOutput<GameObject>("self", new Func<Flow, GameObject>(this.Result)).PredictableIf(new Func<Flow, bool>(this.IsPredictable));
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0000E9C0 File Offset: 0x0000CBC0
		private GameObject Result(Flow flow)
		{
			return flow.stack.self;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0000E9CD File Offset: 0x0000CBCD
		private bool IsPredictable(Flow flow)
		{
			return flow.stack.self != null;
		}
	}
}
