using System;
using System.Collections;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000029 RID: 41
	[UnitCategory("Collections")]
	public sealed class FirstItem : Unit
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00005984 File Offset: 0x00003B84
		// (set) Token: 0x0600018E RID: 398 RVA: 0x0000598C File Offset: 0x00003B8C
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput collection { get; private set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00005995 File Offset: 0x00003B95
		// (set) Token: 0x06000190 RID: 400 RVA: 0x0000599D File Offset: 0x00003B9D
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput firstItem { get; private set; }

		// Token: 0x06000191 RID: 401 RVA: 0x000059A8 File Offset: 0x00003BA8
		protected override void Definition()
		{
			this.collection = base.ValueInput<IEnumerable>("collection");
			this.firstItem = base.ValueOutput<object>("firstItem", new Func<Flow, object>(this.First));
			base.Requirement(this.collection, this.firstItem);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000059F8 File Offset: 0x00003BF8
		public object First(Flow flow)
		{
			IEnumerable value = flow.GetValue<IEnumerable>(this.collection);
			if (value is IList)
			{
				return ((IList)value)[0];
			}
			return value.Cast<object>().First<object>();
		}
	}
}
