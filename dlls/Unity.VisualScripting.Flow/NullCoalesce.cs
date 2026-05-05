using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200012D RID: 301
	[UnitCategory("Nulls")]
	[TypeIcon(typeof(Null))]
	public sealed class NullCoalesce : Unit
	{
		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0000E87E File Offset: 0x0000CA7E
		// (set) Token: 0x060007CE RID: 1998 RVA: 0x0000E886 File Offset: 0x0000CA86
		[DoNotSerialize]
		public ValueInput input { get; private set; }

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0000E88F File Offset: 0x0000CA8F
		// (set) Token: 0x060007D0 RID: 2000 RVA: 0x0000E897 File Offset: 0x0000CA97
		[DoNotSerialize]
		public ValueInput fallback { get; private set; }

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x060007D1 RID: 2001 RVA: 0x0000E8A0 File Offset: 0x0000CAA0
		// (set) Token: 0x060007D2 RID: 2002 RVA: 0x0000E8A8 File Offset: 0x0000CAA8
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput result { get; private set; }

		// Token: 0x060007D3 RID: 2003 RVA: 0x0000E8B4 File Offset: 0x0000CAB4
		protected override void Definition()
		{
			this.input = base.ValueInput<object>("input").AllowsNull();
			this.fallback = base.ValueInput<object>("fallback");
			this.result = base.ValueOutput<object>("result", new Func<Flow, object>(this.Coalesce)).Predictable();
			base.Requirement(this.input, this.result);
			base.Requirement(this.fallback, this.result);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0000E930 File Offset: 0x0000CB30
		public object Coalesce(Flow flow)
		{
			object value = flow.GetValue(this.input);
			bool flag;
			if (value is Object)
			{
				flag = ((Object)value == null);
			}
			else
			{
				flag = (value == null);
			}
			if (!flag)
			{
				return value;
			}
			return flow.GetValue(this.fallback);
		}
	}
}
