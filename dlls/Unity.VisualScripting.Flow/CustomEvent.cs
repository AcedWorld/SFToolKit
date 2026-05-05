using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000058 RID: 88
	[UnitCategory("Events")]
	[UnitOrder(0)]
	public sealed class CustomEvent : GameObjectEventUnit<CustomEventArgs>
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000895D File Offset: 0x00006B5D
		public override Type MessageListenerType
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000354 RID: 852 RVA: 0x00008960 File Offset: 0x00006B60
		protected override string hookName
		{
			get
			{
				return "Custom";
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00008967 File Offset: 0x00006B67
		// (set) Token: 0x06000356 RID: 854 RVA: 0x0000896F File Offset: 0x00006B6F
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

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00008980 File Offset: 0x00006B80
		// (set) Token: 0x06000358 RID: 856 RVA: 0x00008988 File Offset: 0x00006B88
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput name { get; private set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00008991 File Offset: 0x00006B91
		[DoNotSerialize]
		public List<ValueOutput> argumentPorts { get; } = new List<ValueOutput>();

		// Token: 0x0600035A RID: 858 RVA: 0x0000899C File Offset: 0x00006B9C
		protected override void Definition()
		{
			base.Definition();
			this.name = base.ValueInput<string>("name", string.Empty);
			this.argumentPorts.Clear();
			for (int i = 0; i < this.argumentCount; i++)
			{
				this.argumentPorts.Add(base.ValueOutput<object>("argument_" + i.ToString()));
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00008A03 File Offset: 0x00006C03
		protected override bool ShouldTrigger(Flow flow, CustomEventArgs args)
		{
			return EventUnit<CustomEventArgs>.CompareNames(flow, this.name, args.name);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00008A18 File Offset: 0x00006C18
		protected override void AssignArguments(Flow flow, CustomEventArgs args)
		{
			for (int i = 0; i < this.argumentCount; i++)
			{
				flow.SetValue(this.argumentPorts[i], args.arguments[i]);
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00008A50 File Offset: 0x00006C50
		public static void Trigger(GameObject target, string name, params object[] args)
		{
			EventBus.Trigger<CustomEventArgs>("Custom", target, new CustomEventArgs(name, args));
		}

		// Token: 0x040000FB RID: 251
		[SerializeAs("argumentCount")]
		private int _argumentCount;
	}
}
