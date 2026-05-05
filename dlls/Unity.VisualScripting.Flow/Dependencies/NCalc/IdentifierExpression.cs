using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x0200018D RID: 397
	public class IdentifierExpression : LogicalExpression
	{
		// Token: 0x06000AAD RID: 2733 RVA: 0x000145E0 File Offset: 0x000127E0
		public IdentifierExpression(string name)
		{
			this.Name = name;
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000AAE RID: 2734 RVA: 0x000145EF File Offset: 0x000127EF
		// (set) Token: 0x06000AAF RID: 2735 RVA: 0x000145F7 File Offset: 0x000127F7
		public string Name { get; set; }

		// Token: 0x06000AB0 RID: 2736 RVA: 0x00014600 File Offset: 0x00012800
		public override void Accept(LogicalExpressionVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
