using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200014B RID: 331
	[UnitShortTitle("Is Variable Defined")]
	public abstract class IsVariableDefinedUnit : VariableUnit
	{
		// Token: 0x06000895 RID: 2197 RVA: 0x0000FE75 File Offset: 0x0000E075
		protected IsVariableDefinedUnit()
		{
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0000FE7D File Offset: 0x0000E07D
		protected IsVariableDefinedUnit(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000897 RID: 2199 RVA: 0x0000FE86 File Offset: 0x0000E086
		// (set) Token: 0x06000898 RID: 2200 RVA: 0x0000FE8E File Offset: 0x0000E08E
		[DoNotSerialize]
		[PortLabel("Defined")]
		[PortLabelHidden]
		public new ValueOutput isDefined { get; private set; }

		// Token: 0x06000899 RID: 2201 RVA: 0x0000FE97 File Offset: 0x0000E097
		protected override void Definition()
		{
			base.Definition();
			this.isDefined = base.ValueOutput<bool>("isDefined", new Func<Flow, bool>(this.IsDefined));
			base.Requirement(base.name, this.isDefined);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0000FED0 File Offset: 0x0000E0D0
		protected virtual bool IsDefined(Flow flow)
		{
			string value = flow.GetValue<string>(base.name);
			return this.GetDeclarations(flow).IsDefined(value);
		}
	}
}
