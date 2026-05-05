using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements.StyleSheets.Syntax
{
	// Token: 0x020004AE RID: 1198
	internal class StyleSyntaxParser
	{
		// Token: 0x06002528 RID: 9512 RVA: 0x0009CC24 File Offset: 0x0009AE24
		public Expression Parse(string syntax)
		{
			bool flag = string.IsNullOrEmpty(syntax);
			Expression result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Expression expression = null;
				bool flag2 = !this.m_ParsedExpressionCache.TryGetValue(syntax, out expression);
				if (flag2)
				{
					StyleSyntaxTokenizer styleSyntaxTokenizer = new StyleSyntaxTokenizer();
					styleSyntaxTokenizer.Tokenize(syntax);
					try
					{
						expression = this.ParseExpression(styleSyntaxTokenizer);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					this.m_ParsedExpressionCache[syntax] = expression;
				}
				result = expression;
			}
			return result;
		}

		// Token: 0x06002529 RID: 9513 RVA: 0x0009CCA8 File Offset: 0x0009AEA8
		private Expression ParseExpression(StyleSyntaxTokenizer tokenizer)
		{
			StyleSyntaxToken current = tokenizer.current;
			while (!StyleSyntaxParser.IsExpressionEnd(current))
			{
				bool flag = current.type == StyleSyntaxTokenType.String || current.type == StyleSyntaxTokenType.LessThan;
				Expression item;
				if (flag)
				{
					item = this.ParseTerm(tokenizer);
				}
				else
				{
					bool flag2 = current.type == StyleSyntaxTokenType.OpenBracket;
					if (!flag2)
					{
						throw new Exception(string.Format("Unexpected token '{0}' in expression", current.type));
					}
					item = this.ParseGroup(tokenizer);
				}
				this.m_ExpressionStack.Push(item);
				ExpressionCombinator expressionCombinator = this.ParseCombinatorType(tokenizer);
				bool flag3 = expressionCombinator > ExpressionCombinator.None;
				if (flag3)
				{
					bool flag4 = this.m_CombinatorStack.Count > 0;
					if (flag4)
					{
						ExpressionCombinator expressionCombinator2 = this.m_CombinatorStack.Peek();
						int num = (int)expressionCombinator2;
						int num2 = (int)expressionCombinator;
						while (num > num2 && expressionCombinator2 != ExpressionCombinator.Group)
						{
							this.ProcessCombinatorStack();
							expressionCombinator2 = ((this.m_CombinatorStack.Count > 0) ? this.m_CombinatorStack.Peek() : ExpressionCombinator.None);
							num = (int)expressionCombinator2;
						}
					}
					this.m_CombinatorStack.Push(expressionCombinator);
				}
				current = tokenizer.current;
			}
			while (this.m_CombinatorStack.Count > 0)
			{
				ExpressionCombinator expressionCombinator3 = this.m_CombinatorStack.Peek();
				bool flag5 = expressionCombinator3 == ExpressionCombinator.Group;
				if (flag5)
				{
					this.m_CombinatorStack.Pop();
					break;
				}
				this.ProcessCombinatorStack();
			}
			return this.m_ExpressionStack.Pop();
		}

		// Token: 0x0600252A RID: 9514 RVA: 0x0009CE34 File Offset: 0x0009B034
		private void ProcessCombinatorStack()
		{
			ExpressionCombinator expressionCombinator = this.m_CombinatorStack.Pop();
			Expression item = this.m_ExpressionStack.Pop();
			Expression item2 = this.m_ExpressionStack.Pop();
			this.m_ProcessExpressionList.Clear();
			this.m_ProcessExpressionList.Add(item2);
			this.m_ProcessExpressionList.Add(item);
			while (this.m_CombinatorStack.Count > 0 && expressionCombinator == this.m_CombinatorStack.Peek())
			{
				Expression item3 = this.m_ExpressionStack.Pop();
				this.m_ProcessExpressionList.Insert(0, item3);
				this.m_CombinatorStack.Pop();
			}
			Expression expression = new Expression(ExpressionType.Combinator);
			expression.combinator = expressionCombinator;
			expression.subExpressions = this.m_ProcessExpressionList.ToArray();
			this.m_ExpressionStack.Push(expression);
		}

		// Token: 0x0600252B RID: 9515 RVA: 0x0009CF0C File Offset: 0x0009B10C
		private Expression ParseTerm(StyleSyntaxTokenizer tokenizer)
		{
			StyleSyntaxToken current = tokenizer.current;
			bool flag = current.type == StyleSyntaxTokenType.LessThan;
			Expression expression;
			if (flag)
			{
				expression = this.ParseDataType(tokenizer);
			}
			else
			{
				bool flag2 = current.type == StyleSyntaxTokenType.String;
				if (!flag2)
				{
					throw new Exception(string.Format("Unexpected token '{0}' in expression. Expected term token", current.type));
				}
				expression = new Expression(ExpressionType.Keyword);
				expression.keyword = current.text.ToLower();
				tokenizer.MoveNext();
			}
			this.ParseMultiplier(tokenizer, ref expression.multiplier);
			return expression;
		}

		// Token: 0x0600252C RID: 9516 RVA: 0x0009CFA0 File Offset: 0x0009B1A0
		private ExpressionCombinator ParseCombinatorType(StyleSyntaxTokenizer tokenizer)
		{
			ExpressionCombinator expressionCombinator = ExpressionCombinator.None;
			StyleSyntaxToken styleSyntaxToken = tokenizer.current;
			while (!StyleSyntaxParser.IsExpressionEnd(styleSyntaxToken) && expressionCombinator == ExpressionCombinator.None)
			{
				StyleSyntaxToken styleSyntaxToken2 = tokenizer.PeekNext();
				switch (styleSyntaxToken.type)
				{
				case StyleSyntaxTokenType.Space:
				{
					bool flag = !StyleSyntaxParser.IsCombinator(styleSyntaxToken2) && styleSyntaxToken2.type != StyleSyntaxTokenType.CloseBracket;
					if (flag)
					{
						expressionCombinator = ExpressionCombinator.Juxtaposition;
					}
					break;
				}
				case StyleSyntaxTokenType.SingleBar:
					expressionCombinator = ExpressionCombinator.Or;
					break;
				case StyleSyntaxTokenType.DoubleBar:
					expressionCombinator = ExpressionCombinator.OrOr;
					break;
				case StyleSyntaxTokenType.DoubleAmpersand:
					expressionCombinator = ExpressionCombinator.AndAnd;
					break;
				default:
					throw new Exception(string.Format("Unexpected token '{0}' in expression. Expected combinator token", styleSyntaxToken.type));
				}
				styleSyntaxToken = tokenizer.MoveNext();
			}
			StyleSyntaxParser.EatSpace(tokenizer);
			return expressionCombinator;
		}

		// Token: 0x0600252D RID: 9517 RVA: 0x0009D064 File Offset: 0x0009B264
		private Expression ParseGroup(StyleSyntaxTokenizer tokenizer)
		{
			StyleSyntaxToken current = tokenizer.current;
			bool flag = current.type != StyleSyntaxTokenType.OpenBracket;
			if (flag)
			{
				throw new Exception(string.Format("Unexpected token '{0}' in group expression. Expected '[' token", current.type));
			}
			this.m_CombinatorStack.Push(ExpressionCombinator.Group);
			tokenizer.MoveNext();
			StyleSyntaxParser.EatSpace(tokenizer);
			Expression expression = this.ParseExpression(tokenizer);
			current = tokenizer.current;
			bool flag2 = current.type != StyleSyntaxTokenType.CloseBracket;
			if (flag2)
			{
				throw new Exception(string.Format("Unexpected token '{0}' in group expression. Expected ']' token", current.type));
			}
			tokenizer.MoveNext();
			Expression expression2 = new Expression(ExpressionType.Combinator);
			expression2.combinator = ExpressionCombinator.Group;
			expression2.subExpressions = new Expression[]
			{
				expression
			};
			this.ParseMultiplier(tokenizer, ref expression2.multiplier);
			return expression2;
		}

		// Token: 0x0600252E RID: 9518 RVA: 0x0009D138 File Offset: 0x0009B338
		private Expression ParseDataType(StyleSyntaxTokenizer tokenizer)
		{
			StyleSyntaxToken styleSyntaxToken = tokenizer.current;
			bool flag = styleSyntaxToken.type != StyleSyntaxTokenType.LessThan;
			if (flag)
			{
				throw new Exception(string.Format("Unexpected token '{0}' in data type expression. Expected '<' token", styleSyntaxToken.type));
			}
			styleSyntaxToken = tokenizer.MoveNext();
			StyleSyntaxTokenType type = styleSyntaxToken.type;
			StyleSyntaxTokenType styleSyntaxTokenType = type;
			Expression expression;
			if (styleSyntaxTokenType != StyleSyntaxTokenType.String)
			{
				if (styleSyntaxTokenType != StyleSyntaxTokenType.SingleQuote)
				{
					throw new Exception(string.Format("Unexpected token '{0}' in data type expression", styleSyntaxToken.type));
				}
				expression = this.ParseProperty(tokenizer);
			}
			else
			{
				string syntax;
				bool flag2 = StylePropertyCache.TryGetNonTerminalValue(styleSyntaxToken.text, out syntax);
				if (flag2)
				{
					expression = this.ParseNonTerminalValue(syntax);
				}
				else
				{
					DataType dataType = DataType.None;
					try
					{
						object obj = Enum.Parse(typeof(DataType), styleSyntaxToken.text.Replace("-", ""), true);
						bool flag3 = obj != null;
						if (flag3)
						{
							dataType = (DataType)obj;
						}
					}
					catch (Exception)
					{
						throw new Exception("Unknown data type '" + styleSyntaxToken.text + "'");
					}
					expression = new Expression(ExpressionType.Data);
					expression.dataType = dataType;
				}
				tokenizer.MoveNext();
			}
			styleSyntaxToken = tokenizer.current;
			bool flag4 = styleSyntaxToken.type != StyleSyntaxTokenType.GreaterThan;
			if (flag4)
			{
				throw new Exception(string.Format("Unexpected token '{0}' in data type expression. Expected '>' token", styleSyntaxToken.type));
			}
			tokenizer.MoveNext();
			return expression;
		}

		// Token: 0x0600252F RID: 9519 RVA: 0x0009D2B4 File Offset: 0x0009B4B4
		private Expression ParseNonTerminalValue(string syntax)
		{
			Expression expression = null;
			bool flag = !this.m_ParsedExpressionCache.TryGetValue(syntax, out expression);
			if (flag)
			{
				this.m_CombinatorStack.Push(ExpressionCombinator.Group);
				expression = this.Parse(syntax);
			}
			return new Expression(ExpressionType.Combinator)
			{
				combinator = ExpressionCombinator.Group,
				subExpressions = new Expression[]
				{
					expression
				}
			};
		}

		// Token: 0x06002530 RID: 9520 RVA: 0x0009D314 File Offset: 0x0009B514
		private Expression ParseProperty(StyleSyntaxTokenizer tokenizer)
		{
			Expression expression = null;
			StyleSyntaxToken styleSyntaxToken = tokenizer.current;
			bool flag = styleSyntaxToken.type != StyleSyntaxTokenType.SingleQuote;
			if (flag)
			{
				throw new Exception(string.Format("Unexpected token '{0}' in property expression. Expected ''' token", styleSyntaxToken.type));
			}
			styleSyntaxToken = tokenizer.MoveNext();
			bool flag2 = styleSyntaxToken.type != StyleSyntaxTokenType.String;
			if (flag2)
			{
				throw new Exception(string.Format("Unexpected token '{0}' in property expression. Expected 'string' token", styleSyntaxToken.type));
			}
			string text = styleSyntaxToken.text;
			string text2;
			bool flag3 = !StylePropertyCache.TryGetSyntax(text, out text2);
			if (flag3)
			{
				throw new Exception("Unknown property '" + text + "' <''> expression.");
			}
			bool flag4 = !this.m_ParsedExpressionCache.TryGetValue(text2, out expression);
			if (flag4)
			{
				this.m_CombinatorStack.Push(ExpressionCombinator.Group);
				expression = this.Parse(text2);
			}
			styleSyntaxToken = tokenizer.MoveNext();
			bool flag5 = styleSyntaxToken.type != StyleSyntaxTokenType.SingleQuote;
			if (flag5)
			{
				throw new Exception(string.Format("Unexpected token '{0}' in property expression. Expected ''' token", styleSyntaxToken.type));
			}
			styleSyntaxToken = tokenizer.MoveNext();
			bool flag6 = styleSyntaxToken.type != StyleSyntaxTokenType.GreaterThan;
			if (flag6)
			{
				throw new Exception(string.Format("Unexpected token '{0}' in property expression. Expected '>' token", styleSyntaxToken.type));
			}
			return new Expression(ExpressionType.Combinator)
			{
				combinator = ExpressionCombinator.Group,
				subExpressions = new Expression[]
				{
					expression
				}
			};
		}

		// Token: 0x06002531 RID: 9521 RVA: 0x0009D47C File Offset: 0x0009B67C
		private void ParseMultiplier(StyleSyntaxTokenizer tokenizer, ref ExpressionMultiplier multiplier)
		{
			StyleSyntaxToken styleSyntaxToken = tokenizer.current;
			bool flag = StyleSyntaxParser.IsMultiplier(styleSyntaxToken);
			if (flag)
			{
				switch (styleSyntaxToken.type)
				{
				case StyleSyntaxTokenType.Asterisk:
					multiplier.type = ExpressionMultiplierType.ZeroOrMore;
					goto IL_A1;
				case StyleSyntaxTokenType.Plus:
					multiplier.type = ExpressionMultiplierType.OneOrMore;
					goto IL_A1;
				case StyleSyntaxTokenType.QuestionMark:
					multiplier.type = ExpressionMultiplierType.ZeroOrOne;
					goto IL_A1;
				case StyleSyntaxTokenType.HashMark:
					multiplier.type = ExpressionMultiplierType.OneOrMoreComma;
					goto IL_A1;
				case StyleSyntaxTokenType.ExclamationPoint:
					multiplier.type = ExpressionMultiplierType.GroupAtLeastOne;
					goto IL_A1;
				case StyleSyntaxTokenType.OpenBrace:
					multiplier.type = ExpressionMultiplierType.Ranges;
					goto IL_A1;
				}
				throw new Exception(string.Format("Unexpected token '{0}' in expression. Expected multiplier token", styleSyntaxToken.type));
				IL_A1:
				styleSyntaxToken = tokenizer.MoveNext();
			}
			bool flag2 = multiplier.type == ExpressionMultiplierType.Ranges;
			if (flag2)
			{
				this.ParseRanges(tokenizer, out multiplier.min, out multiplier.max);
			}
		}

		// Token: 0x06002532 RID: 9522 RVA: 0x0009D558 File Offset: 0x0009B758
		private void ParseRanges(StyleSyntaxTokenizer tokenizer, out int min, out int max)
		{
			min = -1;
			max = -1;
			StyleSyntaxToken styleSyntaxToken = tokenizer.current;
			bool flag = false;
			while (styleSyntaxToken.type != StyleSyntaxTokenType.CloseBrace)
			{
				StyleSyntaxTokenType type = styleSyntaxToken.type;
				StyleSyntaxTokenType styleSyntaxTokenType = type;
				if (styleSyntaxTokenType != StyleSyntaxTokenType.Number)
				{
					if (styleSyntaxTokenType != StyleSyntaxTokenType.Comma)
					{
						throw new Exception(string.Format("Unexpected token '{0}' in expression. Expected ranges token", styleSyntaxToken.type));
					}
					flag = true;
				}
				else
				{
					bool flag2 = !flag;
					if (flag2)
					{
						min = styleSyntaxToken.number;
					}
					else
					{
						max = styleSyntaxToken.number;
					}
				}
				styleSyntaxToken = tokenizer.MoveNext();
			}
			tokenizer.MoveNext();
		}

		// Token: 0x06002533 RID: 9523 RVA: 0x0009D5F0 File Offset: 0x0009B7F0
		private static void EatSpace(StyleSyntaxTokenizer tokenizer)
		{
			StyleSyntaxToken current = tokenizer.current;
			bool flag = current.type == StyleSyntaxTokenType.Space;
			if (flag)
			{
				tokenizer.MoveNext();
			}
		}

		// Token: 0x06002534 RID: 9524 RVA: 0x0009D61C File Offset: 0x0009B81C
		private static bool IsExpressionEnd(StyleSyntaxToken token)
		{
			StyleSyntaxTokenType type = token.type;
			StyleSyntaxTokenType styleSyntaxTokenType = type;
			return styleSyntaxTokenType == StyleSyntaxTokenType.CloseBracket || styleSyntaxTokenType == StyleSyntaxTokenType.End;
		}

		// Token: 0x06002535 RID: 9525 RVA: 0x0009D64C File Offset: 0x0009B84C
		private static bool IsCombinator(StyleSyntaxToken token)
		{
			StyleSyntaxTokenType type = token.type;
			StyleSyntaxTokenType styleSyntaxTokenType = type;
			return styleSyntaxTokenType - StyleSyntaxTokenType.Space <= 3;
		}

		// Token: 0x06002536 RID: 9526 RVA: 0x0009D674 File Offset: 0x0009B874
		private static bool IsMultiplier(StyleSyntaxToken token)
		{
			StyleSyntaxTokenType type = token.type;
			StyleSyntaxTokenType styleSyntaxTokenType = type;
			return styleSyntaxTokenType - StyleSyntaxTokenType.Asterisk <= 4 || styleSyntaxTokenType == StyleSyntaxTokenType.OpenBrace;
		}

		// Token: 0x0400120E RID: 4622
		private List<Expression> m_ProcessExpressionList = new List<Expression>();

		// Token: 0x0400120F RID: 4623
		private Stack<Expression> m_ExpressionStack = new Stack<Expression>();

		// Token: 0x04001210 RID: 4624
		private Stack<ExpressionCombinator> m_CombinatorStack = new Stack<ExpressionCombinator>();

		// Token: 0x04001211 RID: 4625
		private Dictionary<string, Expression> m_ParsedExpressionCache = new Dictionary<string, Expression>();
	}
}
