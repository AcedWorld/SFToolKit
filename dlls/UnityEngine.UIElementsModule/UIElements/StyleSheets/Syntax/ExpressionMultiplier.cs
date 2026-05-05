using System;

namespace UnityEngine.UIElements.StyleSheets.Syntax
{
	// Token: 0x020004AD RID: 1197
	internal struct ExpressionMultiplier
	{
		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x06002524 RID: 9508 RVA: 0x0009CB50 File Offset: 0x0009AD50
		// (set) Token: 0x06002525 RID: 9509 RVA: 0x0009CB68 File Offset: 0x0009AD68
		public ExpressionMultiplierType type
		{
			get
			{
				return this.m_Type;
			}
			set
			{
				this.SetType(value);
			}
		}

		// Token: 0x06002526 RID: 9510 RVA: 0x0009CB74 File Offset: 0x0009AD74
		public ExpressionMultiplier(ExpressionMultiplierType type = ExpressionMultiplierType.None)
		{
			this.m_Type = type;
			this.min = (this.max = 1);
			this.SetType(type);
		}

		// Token: 0x06002527 RID: 9511 RVA: 0x0009CBA4 File Offset: 0x0009ADA4
		private void SetType(ExpressionMultiplierType value)
		{
			this.m_Type = value;
			switch (value)
			{
			case ExpressionMultiplierType.ZeroOrMore:
				this.min = 0;
				this.max = 100;
				return;
			case ExpressionMultiplierType.OneOrMore:
			case ExpressionMultiplierType.OneOrMoreComma:
			case ExpressionMultiplierType.GroupAtLeastOne:
				this.min = 1;
				this.max = 100;
				return;
			case ExpressionMultiplierType.ZeroOrOne:
				this.min = 0;
				this.max = 1;
				return;
			}
			this.min = (this.max = 1);
		}

		// Token: 0x0400120A RID: 4618
		public const int Infinity = 100;

		// Token: 0x0400120B RID: 4619
		private ExpressionMultiplierType m_Type;

		// Token: 0x0400120C RID: 4620
		public int min;

		// Token: 0x0400120D RID: 4621
		public int max;
	}
}
