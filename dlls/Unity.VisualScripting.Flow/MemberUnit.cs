using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200001E RID: 30
	[SpecialUnit]
	public abstract class MemberUnit : Unit, IAotStubbable
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00004C7E File Offset: 0x00002E7E
		protected MemberUnit()
		{
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00004C86 File Offset: 0x00002E86
		protected MemberUnit(Member member) : this()
		{
			this.member = member;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00004C95 File Offset: 0x00002E95
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00004C9D File Offset: 0x00002E9D
		[Serialize]
		[MemberFilter(Fields = true, Properties = true, Methods = true, Constructors = true)]
		public Member member { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00004CA6 File Offset: 0x00002EA6
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00004CAE File Offset: 0x00002EAE
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput target { get; private set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00004CB7 File Offset: 0x00002EB7
		public override bool canDefine
		{
			get
			{
				return this.member != null;
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00004CC8 File Offset: 0x00002EC8
		protected override void Definition()
		{
			this.member.EnsureReflected();
			if (!this.IsMemberValid(this.member))
			{
				throw new NotSupportedException("The member type is not valid for this unit.");
			}
			if (this.member.requiresTarget)
			{
				this.target = base.ValueInput(this.member.targetType, "target");
				this.target.SetDefaultValue(this.member.targetType.PseudoDefault());
				if (typeof(Object).IsAssignableFrom(this.member.targetType))
				{
					this.target.NullMeansSelf();
				}
			}
		}

		// Token: 0x0600011D RID: 285
		protected abstract bool IsMemberValid(Member member);

		// Token: 0x0600011E RID: 286 RVA: 0x00004D65 File Offset: 0x00002F65
		public override void Prewarm()
		{
			if (this.member != null && this.member.isReflected)
			{
				this.member.Prewarm();
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004D8D File Offset: 0x00002F8D
		public override IEnumerable<object> GetAotStubs(HashSet<object> visited)
		{
			if (this.member != null && this.member.isReflected)
			{
				yield return this.member.info;
			}
			yield break;
		}
	}
}
