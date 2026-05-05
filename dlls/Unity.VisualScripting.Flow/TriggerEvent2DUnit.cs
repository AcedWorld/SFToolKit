using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000A5 RID: 165
	[UnitCategory("Events/Physics 2D")]
	public abstract class TriggerEvent2DUnit : GameObjectEventUnit<Collider2D>
	{
		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x0000A119 File Offset: 0x00008319
		// (set) Token: 0x060004CA RID: 1226 RVA: 0x0000A121 File Offset: 0x00008321
		[DoNotSerialize]
		public ValueOutput collider { get; private set; }

		// Token: 0x060004CB RID: 1227 RVA: 0x0000A12A File Offset: 0x0000832A
		protected override void Definition()
		{
			base.Definition();
			this.collider = base.ValueOutput<Collider2D>("collider");
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0000A143 File Offset: 0x00008343
		protected override void AssignArguments(Flow flow, Collider2D other)
		{
			flow.SetValue(this.collider, other);
		}
	}
}
