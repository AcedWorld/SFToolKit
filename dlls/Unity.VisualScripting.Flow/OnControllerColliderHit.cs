using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000096 RID: 150
	[UnitCategory("Events/Physics")]
	[TypeIcon(typeof(CharacterController))]
	public sealed class OnControllerColliderHit : GameObjectEventUnit<ControllerColliderHit>
	{
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x00009A65 File Offset: 0x00007C65
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnControllerColliderHitMessageListener);
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00009A71 File Offset: 0x00007C71
		protected override string hookName
		{
			get
			{
				return "OnControllerColliderHit";
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x00009A78 File Offset: 0x00007C78
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x00009A80 File Offset: 0x00007C80
		[DoNotSerialize]
		public ValueOutput collider { get; private set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x00009A89 File Offset: 0x00007C89
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x00009A91 File Offset: 0x00007C91
		[DoNotSerialize]
		public ValueOutput controller { get; private set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x00009A9A File Offset: 0x00007C9A
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00009AA2 File Offset: 0x00007CA2
		[DoNotSerialize]
		public ValueOutput moveDirection { get; private set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x00009AAB File Offset: 0x00007CAB
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x00009AB3 File Offset: 0x00007CB3
		[DoNotSerialize]
		public ValueOutput moveLength { get; private set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00009ABC File Offset: 0x00007CBC
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x00009AC4 File Offset: 0x00007CC4
		[DoNotSerialize]
		public ValueOutput normal { get; private set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00009ACD File Offset: 0x00007CCD
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x00009AD5 File Offset: 0x00007CD5
		[DoNotSerialize]
		public ValueOutput point { get; private set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x00009ADE File Offset: 0x00007CDE
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x00009AE6 File Offset: 0x00007CE6
		[DoNotSerialize]
		public ValueOutput data { get; private set; }

		// Token: 0x06000478 RID: 1144 RVA: 0x00009AF0 File Offset: 0x00007CF0
		protected override void Definition()
		{
			base.Definition();
			this.collider = base.ValueOutput<Collider>("collider");
			this.controller = base.ValueOutput<CharacterController>("controller");
			this.moveDirection = base.ValueOutput<Vector3>("moveDirection");
			this.moveLength = base.ValueOutput<float>("moveLength");
			this.normal = base.ValueOutput<Vector3>("normal");
			this.point = base.ValueOutput<Vector3>("point");
			this.data = base.ValueOutput<ControllerColliderHit>("data");
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00009B7C File Offset: 0x00007D7C
		protected override void AssignArguments(Flow flow, ControllerColliderHit hitData)
		{
			flow.SetValue(this.collider, hitData.collider);
			flow.SetValue(this.controller, hitData.controller);
			flow.SetValue(this.moveDirection, hitData.moveDirection);
			flow.SetValue(this.moveLength, hitData.moveLength);
			flow.SetValue(this.normal, hitData.normal);
			flow.SetValue(this.point, hitData.point);
			flow.SetValue(this.data, hitData);
		}
	}
}
