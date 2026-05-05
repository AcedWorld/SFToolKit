using System;
using System.Collections;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000020 RID: 32
	[UnitCategory("Collections")]
	public sealed class CountItems : Unit
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00005089 File Offset: 0x00003289
		// (set) Token: 0x06000137 RID: 311 RVA: 0x00005091 File Offset: 0x00003291
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput collection { get; private set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000138 RID: 312 RVA: 0x0000509A File Offset: 0x0000329A
		// (set) Token: 0x06000139 RID: 313 RVA: 0x000050A2 File Offset: 0x000032A2
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput count { get; private set; }

		// Token: 0x0600013A RID: 314 RVA: 0x000050AC File Offset: 0x000032AC
		protected override void Definition()
		{
			this.collection = base.ValueInput<IEnumerable>("collection");
			this.count = base.ValueOutput<int>("count", new Func<Flow, int>(this.Count));
			base.Requirement(this.collection, this.count);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000050FC File Offset: 0x000032FC
		public int Count(Flow flow)
		{
			IEnumerable value = flow.GetValue<IEnumerable>(this.collection);
			if (value is ICollection)
			{
				return ((ICollection)value).Count;
			}
			return value.Cast<object>().Count<object>();
		}
	}
}
