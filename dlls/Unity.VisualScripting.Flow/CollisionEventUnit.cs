using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000092 RID: 146
	[UnitCategory("Events/Physics")]
	public abstract class CollisionEventUnit : GameObjectEventUnit<Collision>
	{
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x000098E2 File Offset: 0x00007AE2
		// (set) Token: 0x06000453 RID: 1107 RVA: 0x000098EA File Offset: 0x00007AEA
		[DoNotSerialize]
		public ValueOutput collider { get; private set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x000098F3 File Offset: 0x00007AF3
		// (set) Token: 0x06000455 RID: 1109 RVA: 0x000098FB File Offset: 0x00007AFB
		[DoNotSerialize]
		public ValueOutput contacts { get; private set; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x00009904 File Offset: 0x00007B04
		// (set) Token: 0x06000457 RID: 1111 RVA: 0x0000990C File Offset: 0x00007B0C
		[DoNotSerialize]
		public ValueOutput impulse { get; private set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x00009915 File Offset: 0x00007B15
		// (set) Token: 0x06000459 RID: 1113 RVA: 0x0000991D File Offset: 0x00007B1D
		[DoNotSerialize]
		public ValueOutput relativeVelocity { get; private set; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x00009926 File Offset: 0x00007B26
		// (set) Token: 0x0600045B RID: 1115 RVA: 0x0000992E File Offset: 0x00007B2E
		[DoNotSerialize]
		public ValueOutput data { get; private set; }

		// Token: 0x0600045C RID: 1116 RVA: 0x00009938 File Offset: 0x00007B38
		protected override void Definition()
		{
			base.Definition();
			this.collider = base.ValueOutput<Collider>("collider");
			this.contacts = base.ValueOutput<ContactPoint[]>("contacts");
			this.impulse = base.ValueOutput<Vector3>("impulse");
			this.relativeVelocity = base.ValueOutput<Vector3>("relativeVelocity");
			this.data = base.ValueOutput<Collision>("data");
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x000099A0 File Offset: 0x00007BA0
		protected override void AssignArguments(Flow flow, Collision collision)
		{
			flow.SetValue(this.collider, collision.collider);
			flow.SetValue(this.contacts, collision.contacts);
			flow.SetValue(this.impulse, collision.impulse);
			flow.SetValue(this.relativeVelocity, collision.relativeVelocity);
			flow.SetValue(this.data, collision);
		}
	}
}
