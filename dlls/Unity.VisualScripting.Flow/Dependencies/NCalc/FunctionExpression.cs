using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x0200018C RID: 396
	public class FunctionExpression : LogicalExpression
	{
		// Token: 0x06000AA7 RID: 2727 RVA: 0x0001459F File Offset: 0x0001279F
		public FunctionExpression(IdentifierExpression identifier, LogicalExpression[] expressions)
		{
			this.Identifier = identifier;
			this.Expressions = expressions;
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x000145B5 File Offset: 0x000127B5
		// (set) Token: 0x06000AA9 RID: 2729 RVA: 0x000145BD File Offset: 0x000127BD
		public IdentifierExpression Identifier { get; set; }

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000AAA RID: 2730 RVA: 0x000145C6 File Offset: 0x000127C6
		// (set) Token: 0x06000AAB RID: 2731 RVA: 0x000145CE File Offset: 0x000127CE
		public LogicalExpression[] Expressions { get; set; }

		// Token: 0x06000AAC RID: 2732 RVA: 0x000145D7 File Offset: 0x000127D7
		public override void Accept(LogicalExpressionVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
