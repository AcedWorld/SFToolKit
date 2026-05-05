using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000183 RID: 387
	public class BinaryExpression : LogicalExpression
	{
		// Token: 0x06000A60 RID: 2656 RVA: 0x00012E09 File Offset: 0x00011009
		public BinaryExpression(BinaryExpressionType type, LogicalExpression leftExpression, LogicalExpression rightExpression)
		{
			this.Type = type;
			this.LeftExpression = leftExpression;
			this.RightExpression = rightExpression;
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000A61 RID: 2657 RVA: 0x00012E26 File Offset: 0x00011026
		// (set) Token: 0x06000A62 RID: 2658 RVA: 0x00012E2E File Offset: 0x0001102E
		public LogicalExpression LeftExpression { get; set; }

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x00012E37 File Offset: 0x00011037
		// (set) Token: 0x06000A64 RID: 2660 RVA: 0x00012E3F File Offset: 0x0001103F
		public LogicalExpression RightExpression { get; set; }

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x00012E48 File Offset: 0x00011048
		// (set) Token: 0x06000A66 RID: 2662 RVA: 0x00012E50 File Offset: 0x00011050
		public BinaryExpressionType Type { get; set; }

		// Token: 0x06000A67 RID: 2663 RVA: 0x00012E59 File Offset: 0x00011059
		public override void Accept(LogicalExpressionVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
