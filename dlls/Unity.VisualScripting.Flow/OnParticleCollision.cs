using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000098 RID: 152
	[UnitCategory("Events/Physics")]
	public sealed class OnParticleCollision : GameObjectEventUnit<GameObject>
	{
		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x00009C77 File Offset: 0x00007E77
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnParticleCollisionMessageListener);
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00009C83 File Offset: 0x00007E83
		protected override string hookName
		{
			get
			{
				return "OnParticleCollision";
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x00009C8A File Offset: 0x00007E8A
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00009C92 File Offset: 0x00007E92
		[DoNotSerialize]
		public ValueOutput other { get; private set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00009C9B File Offset: 0x00007E9B
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x00009CA3 File Offset: 0x00007EA3
		[DoNotSerialize]
		public ValueOutput collisionEvents { get; private set; }

		// Token: 0x06000488 RID: 1160 RVA: 0x00009CAC File Offset: 0x00007EAC
		protected override void Definition()
		{
			base.Definition();
			this.other = base.ValueOutput<GameObject>("other");
			this.collisionEvents = base.ValueOutput<List<ParticleCollisionEvent>>("collisionEvents");
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00009CD8 File Offset: 0x00007ED8
		protected override void AssignArguments(Flow flow, GameObject other)
		{
			flow.SetValue(this.other, other);
			List<ParticleCollisionEvent> list = new List<ParticleCollisionEvent>();
			flow.stack.GetElementData<GameObjectEventUnit<GameObject>.Data>(this).target.GetComponent<ParticleSystem>().GetCollisionEvents(other, list);
			flow.SetValue(this.collisionEvents, list);
		}
	}
}
