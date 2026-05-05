using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000A1 RID: 161
	[UnitCategory("Events/Physics 2D")]
	public sealed class OnJointBreak2D : GameObjectEventUnit<Joint2D>
	{
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x00009F41 File Offset: 0x00008141
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnJointBreak2DMessageListener);
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x00009F4D File Offset: 0x0000814D
		protected override string hookName
		{
			get
			{
				return "OnJointBreak2D";
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x00009F54 File Offset: 0x00008154
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x00009F5C File Offset: 0x0000815C
		[DoNotSerialize]
		public ValueOutput breakForce { get; private set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x00009F65 File Offset: 0x00008165
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x00009F6D File Offset: 0x0000816D
		[DoNotSerialize]
		public ValueOutput breakTorque { get; private set; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060004B5 RID: 1205 RVA: 0x00009F76 File Offset: 0x00008176
		// (set) Token: 0x060004B6 RID: 1206 RVA: 0x00009F7E File Offset: 0x0000817E
		[DoNotSerialize]
		public ValueOutput connectedBody { get; private set; }

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00009F87 File Offset: 0x00008187
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x00009F8F File Offset: 0x0000818F
		[DoNotSerialize]
		public ValueOutput reactionForce { get; private set; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00009F98 File Offset: 0x00008198
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x00009FA0 File Offset: 0x000081A0
		[DoNotSerialize]
		public ValueOutput reactionTorque { get; private set; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x00009FA9 File Offset: 0x000081A9
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x00009FB1 File Offset: 0x000081B1
		[DoNotSerialize]
		public ValueOutput joint { get; private set; }

		// Token: 0x060004BD RID: 1213 RVA: 0x00009FBC File Offset: 0x000081BC
		protected override void Definition()
		{
			base.Definition();
			this.breakForce = base.ValueOutput<float>("breakForce");
			this.breakTorque = base.ValueOutput<float>("breakTorque");
			this.connectedBody = base.ValueOutput<Rigidbody2D>("connectedBody");
			this.reactionForce = base.ValueOutput<Vector2>("reactionForce");
			this.reactionTorque = base.ValueOutput<float>("reactionTorque");
			this.joint = base.ValueOutput<Joint2D>("joint");
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000A038 File Offset: 0x00008238
		protected override void AssignArguments(Flow flow, Joint2D joint)
		{
			flow.SetValue(this.breakForce, joint.breakForce);
			flow.SetValue(this.breakTorque, joint.breakTorque);
			flow.SetValue(this.connectedBody, joint.connectedBody);
			flow.SetValue(this.reactionForce, joint.reactionForce);
			flow.SetValue(this.reactionTorque, joint.reactionTorque);
			flow.SetValue(this.joint, joint);
		}
	}
}
