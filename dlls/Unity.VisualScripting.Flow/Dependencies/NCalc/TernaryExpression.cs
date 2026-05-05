using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000194 RID: 404
	public class TernaryExpression : LogicalExpression
	{
		// Token: 0x06000B41 RID: 2881 RVA: 0x00019F82 File Offset: 0x00018182
		public TernaryExpression(LogicalExpression leftExpression, LogicalExpression middleExpression, LogicalExpression rightExpression)
		{
			this.LeftExpression = leftExpression;
			this.MiddleExpression = middleExpression;
			this.RightExpression = rightExpression;
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000B42 RID: 2882 RVA: 0x00019F9F File Offset: 0x0001819F
		// (set) Token: 0x06000B43 RID: 2883 RVA: 0x00019FA7 File Offset: 0x000181A7
		public LogicalExpression LeftExpression { get; set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000B44 RID: 2884 RVA: 0x00019FB0 File Offset: 0x000181B0
		// (set) Token: 0x06000B45 RID: 2885 RVA: 0x00019FB8 File Offset: 0x000181B8
		public LogicalExpression MiddleExpression { get; set; }

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000B46 RID: 2886 RVA: 0x00019FC1 File Offset: 0x000181C1
		// (set) Token: 0x06000B47 RID: 2887 RVA: 0x00019FC9 File Offset: 0x000181C9
		public LogicalExpression RightExpression { get; set; }

		// Token: 0x06000B48 RID: 2888 RVA: 0x00019FD2 File Offset: 0x000181D2
		public override void Accept(LogicalExpressionVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
