using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000D9 RID: 217
	[UnitOrder(401)]
	public abstract class Normalize<T> : Unit
	{
		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x0000CF8B File Offset: 0x0000B18B
		// (set) Token: 0x0600068A RID: 1674 RVA: 0x0000CF93 File Offset: 0x0000B193
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x0000CF9C File Offset: 0x0000B19C
		// (set) Token: 0x0600068C RID: 1676 RVA: 0x0000CFA4 File Offset: 0x0000B1A4
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x0600068D RID: 1677 RVA: 0x0000CFB0 File Offset: 0x0000B1B0
		protected override void Definition()
		{
			this.input = base.ValueInput<T>("input");
			this.output = base.ValueOutput<T>("output", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.input, this.output);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0000D002 File Offset: 0x0000B202
		private T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.input));
		}

		// Token: 0x0600068F RID: 1679
		public abstract T Operation(T input);
	}
}
