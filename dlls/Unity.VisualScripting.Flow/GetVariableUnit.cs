using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000140 RID: 320
	[UnitShortTitle("Get Variable")]
	public abstract class GetVariableUnit : VariableUnit
	{
		// Token: 0x06000877 RID: 2167 RVA: 0x0000FC81 File Offset: 0x0000DE81
		protected GetVariableUnit()
		{
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x0000FC89 File Offset: 0x0000DE89
		protected GetVariableUnit(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x0000FC92 File Offset: 0x0000DE92
		// (set) Token: 0x0600087A RID: 2170 RVA: 0x0000FC9A File Offset: 0x0000DE9A
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x0600087B RID: 2171 RVA: 0x0000FCA4 File Offset: 0x0000DEA4
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput<object>("value", new Func<Flow, object>(this.Get)).PredictableIf(new Func<Flow, bool>(this.IsDefined));
			base.Requirement(base.name, this.value);
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x0000FCFC File Offset: 0x0000DEFC
		protected virtual bool IsDefined(Flow flow)
		{
			string value = flow.GetValue<string>(base.name);
			VariableDeclarations declarations = this.GetDeclarations(flow);
			return declarations != null && declarations.IsDefined(value);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0000FD2C File Offset: 0x0000DF2C
		protected virtual object Get(Flow flow)
		{
			string value = flow.GetValue<string>(base.name);
			return this.GetDeclarations(flow).Get(value);
		}
	}
}
