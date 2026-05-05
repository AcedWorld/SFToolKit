using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000A9 RID: 169
	[UnitSurtitle("Custom Event")]
	[UnitShortTitle("Trigger")]
	[TypeIcon(typeof(CustomEvent))]
	[UnitCategory("Events")]
	[UnitOrder(1)]
	public sealed class TriggerCustomEvent : Unit
	{
		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x0000A289 File Offset: 0x00008489
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x0000A291 File Offset: 0x00008491
		[DoNotSerialize]
		public List<ValueInput> arguments { get; private set; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0000A29A File Offset: 0x0000849A
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x0000A2A2 File Offset: 0x000084A2
		[DoNotSerialize]
		[Inspectable]
		[UnitHeaderInspectable("Arguments")]
		public int argumentCount
		{
			get
			{
				return this._argumentCount;
			}
			set
			{
				this._argumentCount = Mathf.Clamp(value, 0, 10);
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0000A2B3 File Offset: 0x000084B3
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x0000A2BB File Offset: 0x000084BB
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0000A2C4 File Offset: 0x000084C4
		// (set) Token: 0x060004E5 RID: 1253 RVA: 0x0000A2CC File Offset: 0x000084CC
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput name { get; private set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0000A2D5 File Offset: 0x000084D5
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x0000A2DD File Offset: 0x000084DD
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput target { get; private set; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x0000A2E6 File Offset: 0x000084E6
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x0000A2EE File Offset: 0x000084EE
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x060004EA RID: 1258 RVA: 0x0000A2F8 File Offset: 0x000084F8
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Trigger));
			this.exit = base.ControlOutput("exit");
			this.name = base.ValueInput<string>("name", string.Empty);
			this.target = base.ValueInput<GameObject>("target", null).NullMeansSelf();
			this.arguments = new List<ValueInput>();
			for (int i = 0; i < this.argumentCount; i++)
			{
				ValueInput valueInput = base.ValueInput<object>("argument_" + i.ToString());
				this.arguments.Add(valueInput);
				base.Requirement(valueInput, this.enter);
			}
			base.Requirement(this.name, this.enter);
			base.Requirement(this.target, this.enter);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0000A3E4 File Offset: 0x000085E4
		private ControlOutput Trigger(Flow flow)
		{
			GameObject value = flow.GetValue<GameObject>(this.target);
			string value2 = flow.GetValue<string>(this.name);
			object[] args = this.arguments.Select(new Func<ValueInput, object>(flow.GetConvertedValue)).ToArray<object>();
			CustomEvent.Trigger(value, value2, args);
			return this.exit;
		}

		// Token: 0x04000134 RID: 308
		[SerializeAs("argumentCount")]
		private int _argumentCount;
	}
}
