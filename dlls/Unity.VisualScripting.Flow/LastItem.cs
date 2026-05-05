using System;
using System.Collections;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x0200002A RID: 42
	[UnitCategory("Collections")]
	public sealed class LastItem : Unit
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00005A3A File Offset: 0x00003C3A
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00005A42 File Offset: 0x00003C42
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput collection { get; private set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00005A4B File Offset: 0x00003C4B
		// (set) Token: 0x06000197 RID: 407 RVA: 0x00005A53 File Offset: 0x00003C53
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput lastItem { get; private set; }

		// Token: 0x06000198 RID: 408 RVA: 0x00005A5C File Offset: 0x00003C5C
		protected override void Definition()
		{
			this.collection = base.ValueInput<IEnumerable>("collection");
			this.lastItem = base.ValueOutput<object>("lastItem", new Func<Flow, object>(this.First));
			base.Requirement(this.collection, this.lastItem);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00005AAC File Offset: 0x00003CAC
		public object First(Flow flow)
		{
			IEnumerable value = flow.GetValue<IEnumerable>(this.collection);
			if (value is IList)
			{
				IList list = (IList)value;
				return list[list.Count - 1];
			}
			return value.Cast<object>().Last<object>();
		}
	}
}
