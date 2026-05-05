using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x020000EF RID: 239
	[UnitOrder(303)]
	[TypeIcon(typeof(Add<>))]
	public abstract class Sum<T> : MultiInputUnit<T>
	{
		// Token: 0x17000288 RID: 648
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x0000D6E9 File Offset: 0x0000B8E9
		// (set) Token: 0x060006FF RID: 1791 RVA: 0x0000D6F1 File Offset: 0x0000B8F1
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput sum { get; private set; }

		// Token: 0x06000700 RID: 1792 RVA: 0x0000D6FC File Offset: 0x0000B8FC
		protected override void Definition()
		{
			IDefaultValue<T> defaultValue = this as IDefaultValue<T>;
			if (defaultValue != null)
			{
				List<ValueInput> list = new List<ValueInput>();
				base.multiInputs = list.AsReadOnly();
				for (int i = 0; i < this.inputCount; i++)
				{
					if (i == 0)
					{
						list.Add(base.ValueInput<T>(i.ToString()));
					}
					else
					{
						list.Add(base.ValueInput<T>(i.ToString(), defaultValue.defaultValue));
					}
				}
			}
			else
			{
				base.Definition();
			}
			this.sum = base.ValueOutput<T>("sum", new Func<Flow, T>(this.Operation)).Predictable();
			foreach (ValueInput source in base.multiInputs)
			{
				base.Requirement(source, this.sum);
			}
		}

		// Token: 0x06000701 RID: 1793
		public abstract T Operation(T a, T b);

		// Token: 0x06000702 RID: 1794
		public abstract T Operation(IEnumerable<T> values);

		// Token: 0x06000703 RID: 1795 RVA: 0x0000D7DC File Offset: 0x0000B9DC
		public T Operation(Flow flow)
		{
			if (this.inputCount == 2)
			{
				return this.Operation(flow.GetValue<T>(base.multiInputs[0]), flow.GetValue<T>(base.multiInputs[1]));
			}
			return this.Operation(base.multiInputs.Select(new Func<ValueInput, T>(flow.GetValue<T>)));
		}
	}
}
