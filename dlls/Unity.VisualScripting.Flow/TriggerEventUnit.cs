using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200009C RID: 156
	[UnitCategory("Events/Physics")]
	public abstract class TriggerEventUnit : GameObjectEventUnit<Collider>
	{
		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x00009D7C File Offset: 0x00007F7C
		// (set) Token: 0x06000495 RID: 1173 RVA: 0x00009D84 File Offset: 0x00007F84
		[DoNotSerialize]
		public ValueOutput collider { get; private set; }

		// Token: 0x06000496 RID: 1174 RVA: 0x00009D8D File Offset: 0x00007F8D
		protected override void Definition()
		{
			base.Definition();
			this.collider = base.ValueOutput<Collider>("collider");
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00009DA6 File Offset: 0x00007FA6
		protected override void AssignArguments(Flow flow, Collider other)
		{
			flow.SetValue(this.collider, other);
		}
	}
}
