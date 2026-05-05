using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000195 RID: 405
	public class UnaryExpression : LogicalExpression
	{
		// Token: 0x06000B49 RID: 2889 RVA: 0x00019FDB File Offset: 0x000181DB
		public UnaryExpression(UnaryExpressionType type, LogicalExpression expression)
		{
			this.Type = type;
			this.Expression = expression;
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x00019FF1 File Offset: 0x000181F1
		// (set) Token: 0x06000B4B RID: 2891 RVA: 0x00019FF9 File Offset: 0x000181F9
		public LogicalExpression Expression { get; set; }

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0001A002 File Offset: 0x00018202
		// (set) Token: 0x06000B4D RID: 2893 RVA: 0x0001A00A File Offset: 0x0001820A
		public UnaryExpressionType Type { get; set; }

		// Token: 0x06000B4E RID: 2894 RVA: 0x0001A013 File Offset: 0x00018213
		public override void Accept(LogicalExpressionVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
