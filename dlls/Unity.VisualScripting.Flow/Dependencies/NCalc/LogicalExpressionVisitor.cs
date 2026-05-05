using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x0200018F RID: 399
	public abstract class LogicalExpressionVisitor
	{
		// Token: 0x06000AD9 RID: 2777
		public abstract void Visit(TernaryExpression ternary);

		// Token: 0x06000ADA RID: 2778
		public abstract void Visit(BinaryExpression binary);

		// Token: 0x06000ADB RID: 2779
		public abstract void Visit(UnaryExpression unary);

		// Token: 0x06000ADC RID: 2780
		public abstract void Visit(ValueExpression value);

		// Token: 0x06000ADD RID: 2781
		public abstract void Visit(FunctionExpression function);

		// Token: 0x06000ADE RID: 2782
		public abstract void Visit(IdentifierExpression identifier);
	}
}
