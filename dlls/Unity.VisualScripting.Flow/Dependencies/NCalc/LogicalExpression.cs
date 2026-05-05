using System;
using System.Text;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x0200018E RID: 398
	public abstract class LogicalExpression
	{
		// Token: 0x06000AB1 RID: 2737 RVA: 0x00014609 File Offset: 0x00012809
		public BinaryExpression And(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.And, this, operand);
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x00014613 File Offset: 0x00012813
		public BinaryExpression And(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.And, this, new ValueExpression(operand));
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00014622 File Offset: 0x00012822
		public BinaryExpression DividedBy(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Div, this, operand);
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0001462D File Offset: 0x0001282D
		public BinaryExpression DividedBy(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Div, this, new ValueExpression(operand));
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0001463D File Offset: 0x0001283D
		public BinaryExpression EqualsTo(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Equal, this, operand);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x00014647 File Offset: 0x00012847
		public BinaryExpression EqualsTo(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Equal, this, new ValueExpression(operand));
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x00014656 File Offset: 0x00012856
		public BinaryExpression GreaterThan(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Greater, this, operand);
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00014660 File Offset: 0x00012860
		public BinaryExpression GreaterThan(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Greater, this, new ValueExpression(operand));
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0001466F File Offset: 0x0001286F
		public BinaryExpression GreaterOrEqualThan(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.GreaterOrEqual, this, operand);
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00014679 File Offset: 0x00012879
		public BinaryExpression GreaterOrEqualThan(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.GreaterOrEqual, this, new ValueExpression(operand));
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00014688 File Offset: 0x00012888
		public BinaryExpression LesserThan(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Lesser, this, operand);
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00014692 File Offset: 0x00012892
		public BinaryExpression LesserThan(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Lesser, this, new ValueExpression(operand));
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x000146A1 File Offset: 0x000128A1
		public BinaryExpression LesserOrEqualThan(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.LesserOrEqual, this, operand);
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x000146AB File Offset: 0x000128AB
		public BinaryExpression LesserOrEqualThan(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.LesserOrEqual, this, new ValueExpression(operand));
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x000146BA File Offset: 0x000128BA
		public BinaryExpression Minus(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Minus, this, operand);
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x000146C4 File Offset: 0x000128C4
		public BinaryExpression Minus(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Minus, this, new ValueExpression(operand));
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x000146D3 File Offset: 0x000128D3
		public BinaryExpression Modulo(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Modulo, this, operand);
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x000146DE File Offset: 0x000128DE
		public BinaryExpression Modulo(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Modulo, this, new ValueExpression(operand));
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x000146EE File Offset: 0x000128EE
		public BinaryExpression NotEqual(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.NotEqual, this, operand);
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x000146F8 File Offset: 0x000128F8
		public BinaryExpression NotEqual(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.NotEqual, this, new ValueExpression(operand));
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00014707 File Offset: 0x00012907
		public BinaryExpression Or(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Or, this, operand);
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00014711 File Offset: 0x00012911
		public BinaryExpression Or(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Or, this, new ValueExpression(operand));
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x00014720 File Offset: 0x00012920
		public BinaryExpression Plus(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Plus, this, operand);
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0001472B File Offset: 0x0001292B
		public BinaryExpression Plus(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Plus, this, new ValueExpression(operand));
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0001473B File Offset: 0x0001293B
		public BinaryExpression Mult(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.Times, this, operand);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00014746 File Offset: 0x00012946
		public BinaryExpression Mult(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.Times, this, new ValueExpression(operand));
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00014756 File Offset: 0x00012956
		public BinaryExpression BitwiseOr(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.BitwiseOr, this, operand);
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00014761 File Offset: 0x00012961
		public BinaryExpression BitwiseOr(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.BitwiseOr, this, new ValueExpression(operand));
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00014771 File Offset: 0x00012971
		public BinaryExpression BitwiseAnd(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.BitwiseAnd, this, operand);
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x0001477C File Offset: 0x0001297C
		public BinaryExpression BitwiseAnd(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.BitwiseAnd, this, new ValueExpression(operand));
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x0001478C File Offset: 0x0001298C
		public BinaryExpression BitwiseXOr(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.BitwiseXOr, this, operand);
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00014797 File Offset: 0x00012997
		public BinaryExpression BitwiseXOr(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.BitwiseXOr, this, new ValueExpression(operand));
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x000147A7 File Offset: 0x000129A7
		public BinaryExpression LeftShift(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.LeftShift, this, operand);
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x000147B2 File Offset: 0x000129B2
		public BinaryExpression LeftShift(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.LeftShift, this, new ValueExpression(operand));
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x000147C2 File Offset: 0x000129C2
		public BinaryExpression RightShift(LogicalExpression operand)
		{
			return new BinaryExpression(BinaryExpressionType.RightShift, this, operand);
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x000147CD File Offset: 0x000129CD
		public BinaryExpression RightShift(object operand)
		{
			return new BinaryExpression(BinaryExpressionType.RightShift, this, new ValueExpression(operand));
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x000147E0 File Offset: 0x000129E0
		public override string ToString()
		{
			SerializationVisitor serializationVisitor = new SerializationVisitor();
			this.Accept(serializationVisitor);
			return serializationVisitor.Result.ToString().TrimEnd(' ');
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0001480C File Offset: 0x00012A0C
		public virtual void Accept(LogicalExpressionVisitor visitor)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x00014814 File Offset: 0x00012A14
		private static string ExtractString(string text)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			int startIndex = 1;
			int num;
			while ((num = stringBuilder.ToString().IndexOf('\\', startIndex)) != -1)
			{
				char c = stringBuilder[num + 1];
				if (c <= '\\')
				{
					if (c != '\'')
					{
						if (c != '\\')
						{
							goto IL_13E;
						}
						stringBuilder.Remove(num, 2).Insert(num, '\\');
					}
					else
					{
						stringBuilder.Remove(num, 2).Insert(num, '\'');
					}
				}
				else if (c != 'n')
				{
					switch (c)
					{
					case 'r':
						stringBuilder.Remove(num, 2).Insert(num, '\r');
						break;
					case 's':
						goto IL_13E;
					case 't':
						stringBuilder.Remove(num, 2).Insert(num, '\t');
						break;
					case 'u':
					{
						string value = stringBuilder[num + 4] + stringBuilder[num + 5];
						string value2 = stringBuilder[num + 2] + stringBuilder[num + 3];
						char value3 = Encoding.Unicode.GetChars(new byte[]
						{
							Convert.ToByte(value, 16),
							Convert.ToByte(value2, 16)
						})[0];
						stringBuilder.Remove(num, 6).Insert(num, value3);
						break;
					}
					default:
						goto IL_13E;
					}
				}
				else
				{
					stringBuilder.Remove(num, 2).Insert(num, '\n');
				}
				startIndex = num + 1;
				continue;
				IL_13E:
				throw new ApplicationException("Unvalid escape sequence: \\" + c.ToString());
			}
			stringBuilder.Remove(0, 1);
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			return stringBuilder.ToString();
		}

		// Token: 0x0400025C RID: 604
		private const char BS = '\\';
	}
}
