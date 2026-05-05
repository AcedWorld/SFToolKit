using System;
using System.Globalization;
using System.Text;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000193 RID: 403
	public class SerializationVisitor : LogicalExpressionVisitor
	{
		// Token: 0x06000B37 RID: 2871 RVA: 0x00019A14 File Offset: 0x00017C14
		public SerializationVisitor()
		{
			this.Result = new StringBuilder();
			this._numberFormatInfo = new NumberFormatInfo
			{
				NumberDecimalSeparator = "."
			};
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000B38 RID: 2872 RVA: 0x00019A3D File Offset: 0x00017C3D
		// (set) Token: 0x06000B39 RID: 2873 RVA: 0x00019A45 File Offset: 0x00017C45
		public StringBuilder Result { get; protected set; }

		// Token: 0x06000B3A RID: 2874 RVA: 0x00019A50 File Offset: 0x00017C50
		public override void Visit(TernaryExpression ternary)
		{
			this.EncapsulateNoValue(ternary.LeftExpression);
			this.Result.Append("? ");
			this.EncapsulateNoValue(ternary.MiddleExpression);
			this.Result.Append(": ");
			this.EncapsulateNoValue(ternary.RightExpression);
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00019AA4 File Offset: 0x00017CA4
		public override void Visit(BinaryExpression binary)
		{
			this.EncapsulateNoValue(binary.LeftExpression);
			switch (binary.Type)
			{
			case BinaryExpressionType.And:
				this.Result.Append("and ");
				break;
			case BinaryExpressionType.Or:
				this.Result.Append("or ");
				break;
			case BinaryExpressionType.NotEqual:
				this.Result.Append("!= ");
				break;
			case BinaryExpressionType.LesserOrEqual:
				this.Result.Append("<= ");
				break;
			case BinaryExpressionType.GreaterOrEqual:
				this.Result.Append(">= ");
				break;
			case BinaryExpressionType.Lesser:
				this.Result.Append("< ");
				break;
			case BinaryExpressionType.Greater:
				this.Result.Append("> ");
				break;
			case BinaryExpressionType.Equal:
				this.Result.Append("= ");
				break;
			case BinaryExpressionType.Minus:
				this.Result.Append("- ");
				break;
			case BinaryExpressionType.Plus:
				this.Result.Append("+ ");
				break;
			case BinaryExpressionType.Modulo:
				this.Result.Append("% ");
				break;
			case BinaryExpressionType.Div:
				this.Result.Append("/ ");
				break;
			case BinaryExpressionType.Times:
				this.Result.Append("* ");
				break;
			case BinaryExpressionType.BitwiseOr:
				this.Result.Append("| ");
				break;
			case BinaryExpressionType.BitwiseAnd:
				this.Result.Append("& ");
				break;
			case BinaryExpressionType.BitwiseXOr:
				this.Result.Append("~ ");
				break;
			case BinaryExpressionType.LeftShift:
				this.Result.Append("<< ");
				break;
			case BinaryExpressionType.RightShift:
				this.Result.Append(">> ");
				break;
			}
			this.EncapsulateNoValue(binary.RightExpression);
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x00019C98 File Offset: 0x00017E98
		public override void Visit(UnaryExpression unary)
		{
			switch (unary.Type)
			{
			case UnaryExpressionType.Not:
				this.Result.Append("!");
				break;
			case UnaryExpressionType.Negate:
				this.Result.Append("-");
				break;
			case UnaryExpressionType.BitwiseNot:
				this.Result.Append("~");
				break;
			}
			this.EncapsulateNoValue(unary.Expression);
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00019D04 File Offset: 0x00017F04
		public override void Visit(ValueExpression value)
		{
			switch (value.Type)
			{
			case ValueType.Integer:
				this.Result.Append(value.Value).Append(" ");
				return;
			case ValueType.String:
				this.Result.Append("'").Append(value.Value).Append("'").Append(" ");
				return;
			case ValueType.DateTime:
				this.Result.Append("#").Append(value.Value).Append("#").Append(" ");
				return;
			case ValueType.Float:
				this.Result.Append(decimal.Parse(value.Value.ToString()).ToString(this._numberFormatInfo)).Append(" ");
				return;
			case ValueType.Boolean:
				this.Result.Append(value.Value).Append(" ");
				return;
			default:
				return;
			}
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x00019E04 File Offset: 0x00018004
		public override void Visit(FunctionExpression function)
		{
			this.Result.Append(function.Identifier.Name);
			this.Result.Append("(");
			for (int i = 0; i < function.Expressions.Length; i++)
			{
				function.Expressions[i].Accept(this);
				if (i < function.Expressions.Length - 1)
				{
					this.Result.Remove(this.Result.Length - 1, 1);
					this.Result.Append(", ");
				}
			}
			while (this.Result[this.Result.Length - 1] == ' ')
			{
				this.Result.Remove(this.Result.Length - 1, 1);
			}
			this.Result.Append(") ");
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x00019EDB File Offset: 0x000180DB
		public override void Visit(IdentifierExpression identifier)
		{
			this.Result.Append("[").Append(identifier.Name).Append("] ");
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x00019F04 File Offset: 0x00018104
		protected void EncapsulateNoValue(LogicalExpression expression)
		{
			if (expression is ValueExpression)
			{
				expression.Accept(this);
				return;
			}
			this.Result.Append("(");
			expression.Accept(this);
			while (this.Result[this.Result.Length - 1] == ' ')
			{
				this.Result.Remove(this.Result.Length - 1, 1);
			}
			this.Result.Append(") ");
		}

		// Token: 0x04000326 RID: 806
		private readonly NumberFormatInfo _numberFormatInfo;
	}
}
