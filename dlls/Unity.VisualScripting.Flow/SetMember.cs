using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200001F RID: 31
	public sealed class SetMember : MemberUnit
	{
		// Token: 0x06000120 RID: 288 RVA: 0x00004D9D File Offset: 0x00002F9D
		public SetMember()
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004DA5 File Offset: 0x00002FA5
		public SetMember(Member member) : base(member)
		{
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00004DAE File Offset: 0x00002FAE
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00004DB6 File Offset: 0x00002FB6
		[Serialize]
		[InspectableIf("supportsChaining")]
		public bool chainable { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004DBF File Offset: 0x00002FBF
		[DoNotSerialize]
		public bool supportsChaining
		{
			get
			{
				return base.member.requiresTarget;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00004DCC File Offset: 0x00002FCC
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00004DD4 File Offset: 0x00002FD4
		[DoNotSerialize]
		[MemberFilter(Fields = true, Properties = true, ReadOnly = false)]
		public Member setter
		{
			get
			{
				return base.member;
			}
			set
			{
				base.member = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00004DDD File Offset: 0x00002FDD
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00004DE5 File Offset: 0x00002FE5
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput assign { get; private set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00004DEE File Offset: 0x00002FEE
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00004DF6 File Offset: 0x00002FF6
		[DoNotSerialize]
		[PortLabel("Value")]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00004DFF File Offset: 0x00002FFF
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00004E07 File Offset: 0x00003007
		[DoNotSerialize]
		[PortLabel("Value")]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00004E10 File Offset: 0x00003010
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00004E18 File Offset: 0x00003018
		[DoNotSerialize]
		[PortLabel("Target")]
		[PortLabelHidden]
		public ValueOutput targetOutput { get; private set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00004E21 File Offset: 0x00003021
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00004E29 File Offset: 0x00003029
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput assigned { get; private set; }

		// Token: 0x06000131 RID: 305 RVA: 0x00004E34 File Offset: 0x00003034
		protected override void Definition()
		{
			base.Definition();
			this.assign = base.ControlInput("assign", new Func<Flow, ControlOutput>(this.Assign));
			this.assigned = base.ControlOutput("assigned");
			base.Succession(this.assign, this.assigned);
			if (this.supportsChaining && this.chainable)
			{
				this.targetOutput = base.ValueOutput(base.member.targetType, "targetOutput");
				base.Assignment(this.assign, this.targetOutput);
			}
			this.output = base.ValueOutput(base.member.type, "output");
			base.Assignment(this.assign, this.output);
			if (base.member.requiresTarget)
			{
				base.Requirement(base.target, this.assign);
			}
			this.input = base.ValueInput(base.member.type, "input");
			base.Requirement(this.input, this.assign);
			if (base.member.allowsNull)
			{
				this.input.AllowsNull();
			}
			this.input.SetDefaultValue(base.member.type.PseudoDefault());
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004F74 File Offset: 0x00003174
		protected override bool IsMemberValid(Member member)
		{
			return member.isAccessor && member.isSettable;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00004F88 File Offset: 0x00003188
		private object GetAndChainTarget(Flow flow)
		{
			if (base.member.requiresTarget)
			{
				object value = flow.GetValue(base.target, base.member.targetType);
				if (this.supportsChaining && this.chainable)
				{
					flow.SetValue(this.targetOutput, value);
				}
				return value;
			}
			return null;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00004FDC File Offset: 0x000031DC
		private ControlOutput Assign(Flow flow)
		{
			object andChainTarget = this.GetAndChainTarget(flow);
			object convertedValue = flow.GetConvertedValue(this.input);
			flow.SetValue(this.output, base.member.Set(andChainTarget, convertedValue));
			return this.assigned;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00005020 File Offset: 0x00003220
		public override AnalyticsIdentifier GetAnalyticsIdentifier()
		{
			AnalyticsIdentifier analyticsIdentifier = new AnalyticsIdentifier();
			analyticsIdentifier.Identifier = base.member.targetType.FullName + "." + base.member.name + "(Set)";
			analyticsIdentifier.Namespace = base.member.targetType.Namespace;
			analyticsIdentifier.Hashcode = analyticsIdentifier.Identifier.GetHashCode();
			return analyticsIdentifier;
		}
	}
}
