using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200001C RID: 28
	public sealed class GetMember : MemberUnit
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00003F14 File Offset: 0x00002114
		public GetMember()
		{
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00003F1C File Offset: 0x0000211C
		public GetMember(Member member) : base(member)
		{
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00003F25 File Offset: 0x00002125
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x00003F2D File Offset: 0x0000212D
		[DoNotSerialize]
		[MemberFilter(Fields = true, Properties = true, WriteOnly = false)]
		public Member getter
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

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00003F36 File Offset: 0x00002136
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x00003F3E File Offset: 0x0000213E
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput value { get; private set; }

		// Token: 0x060000F5 RID: 245 RVA: 0x00003F48 File Offset: 0x00002148
		protected override void Definition()
		{
			base.Definition();
			this.value = base.ValueOutput(base.member.type, "value", new Func<Flow, object>(this.Value));
			if (base.member.isPredictable)
			{
				this.value.Predictable();
			}
			if (base.member.requiresTarget)
			{
				base.Requirement(base.target, this.value);
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003FBB File Offset: 0x000021BB
		protected override bool IsMemberValid(Member member)
		{
			return member.isAccessor && member.isGettable;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00003FD0 File Offset: 0x000021D0
		private object Value(Flow flow)
		{
			object target = base.member.requiresTarget ? flow.GetValue(base.target, base.member.targetType) : null;
			return base.member.Get(target);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004014 File Offset: 0x00002214
		public override AnalyticsIdentifier GetAnalyticsIdentifier()
		{
			AnalyticsIdentifier analyticsIdentifier = new AnalyticsIdentifier();
			analyticsIdentifier.Identifier = base.member.targetType.FullName + "." + base.member.name + "(Get)";
			analyticsIdentifier.Namespace = base.member.targetType.Namespace;
			analyticsIdentifier.Hashcode = analyticsIdentifier.Identifier.GetHashCode();
			return analyticsIdentifier;
		}
	}
}
