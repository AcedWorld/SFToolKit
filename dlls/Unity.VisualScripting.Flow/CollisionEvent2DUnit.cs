using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200009D RID: 157
	[UnitCategory("Events/Physics 2D")]
	public abstract class CollisionEvent2DUnit : GameObjectEventUnit<Collision2D>
	{
		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x00009DBD File Offset: 0x00007FBD
		// (set) Token: 0x0600049A RID: 1178 RVA: 0x00009DC5 File Offset: 0x00007FC5
		[DoNotSerialize]
		public ValueOutput collider { get; private set; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x00009DCE File Offset: 0x00007FCE
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x00009DD6 File Offset: 0x00007FD6
		[DoNotSerialize]
		public ValueOutput contacts { get; private set; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x00009DDF File Offset: 0x00007FDF
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x00009DE7 File Offset: 0x00007FE7
		[DoNotSerialize]
		public ValueOutput relativeVelocity { get; private set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x00009DF0 File Offset: 0x00007FF0
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x00009DF8 File Offset: 0x00007FF8
		[DoNotSerialize]
		public ValueOutput enabled { get; private set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x00009E01 File Offset: 0x00008001
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x00009E09 File Offset: 0x00008009
		[DoNotSerialize]
		public ValueOutput data { get; private set; }

		// Token: 0x060004A3 RID: 1187 RVA: 0x00009E14 File Offset: 0x00008014
		protected override void Definition()
		{
			base.Definition();
			this.collider = base.ValueOutput<Collider2D>("collider");
			this.contacts = base.ValueOutput<ContactPoint2D[]>("contacts");
			this.relativeVelocity = base.ValueOutput<Vector2>("relativeVelocity");
			this.enabled = base.ValueOutput<bool>("enabled");
			this.data = base.ValueOutput<Collision2D>("data");
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00009E7C File Offset: 0x0000807C
		protected override void AssignArguments(Flow flow, Collision2D collisionData)
		{
			flow.SetValue(this.collider, collisionData.collider);
			flow.SetValue(this.contacts, collisionData.contacts);
			flow.SetValue(this.relativeVelocity, collisionData.relativeVelocity);
			flow.SetValue(this.enabled, collisionData.enabled);
			flow.SetValue(this.data, collisionData);
		}
	}
}
