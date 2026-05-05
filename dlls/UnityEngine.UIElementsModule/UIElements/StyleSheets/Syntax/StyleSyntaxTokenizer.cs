using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements.StyleSheets.Syntax
{
	// Token: 0x020004B1 RID: 1201
	internal class StyleSyntaxTokenizer
	{
		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x0600253B RID: 9531 RVA: 0x0009D724 File Offset: 0x0009B924
		public StyleSyntaxToken current
		{
			get
			{
				bool flag = this.m_CurrentTokenIndex < 0 || this.m_CurrentTokenIndex >= this.m_Tokens.Count;
				StyleSyntaxToken result;
				if (flag)
				{
					result = new StyleSyntaxToken(StyleSyntaxTokenType.Unknown);
				}
				else
				{
					result = this.m_Tokens[this.m_CurrentTokenIndex];
				}
				return result;
			}
		}

		// Token: 0x0600253C RID: 9532 RVA: 0x0009D778 File Offset: 0x0009B978
		public StyleSyntaxToken MoveNext()
		{
			StyleSyntaxToken current = this.current;
			bool flag = current.type == StyleSyntaxTokenType.Unknown;
			StyleSyntaxToken result;
			if (flag)
			{
				result = current;
			}
			else
			{
				this.m_CurrentTokenIndex++;
				current = this.current;
				bool flag2 = this.m_CurrentTokenIndex == this.m_Tokens.Count;
				if (flag2)
				{
					this.m_CurrentTokenIndex = -1;
				}
				result = current;
			}
			return result;
		}

		// Token: 0x0600253D RID: 9533 RVA: 0x0009D7D8 File Offset: 0x0009B9D8
		public StyleSyntaxToken PeekNext()
		{
			int num = this.m_CurrentTokenIndex + 1;
			bool flag = this.m_CurrentTokenIndex < 0 || num >= this.m_Tokens.Count;
			StyleSyntaxToken result;
			if (flag)
			{
				result = new StyleSyntaxToken(StyleSyntaxTokenType.Unknown);
			}
			else
			{
				result = this.m_Tokens[num];
			}
			return result;
		}

		// Token: 0x0600253E RID: 9534 RVA: 0x0009D82C File Offset: 0x0009BA2C
		public void Tokenize(string syntax)
		{
			this.m_Tokens.Clear();
			this.m_CurrentTokenIndex = 0;
			syntax = syntax.Trim(' ').ToLowerInvariant();
			int i = 0;
			while (i < syntax.Length)
			{
				char c = syntax[i];
				char c2 = c;
				char c3 = c2;
				if (c3 <= '?')
				{
					switch (c3)
					{
					case ' ':
						i = StyleSyntaxTokenizer.GlobCharacter(syntax, i, ' ');
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.Space));
						break;
					case '!':
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.ExclamationPoint));
						break;
					case '"':
					case '$':
					case '%':
					case '(':
					case ')':
						goto IL_2E1;
					case '#':
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.HashMark));
						break;
					case '&':
					{
						bool flag = !StyleSyntaxTokenizer.IsNextCharacter(syntax, i, '&');
						if (flag)
						{
							string text = (i + 1 < syntax.Length) ? syntax[i + 1].ToString() : "EOF";
							Debug.LogAssertionFormat("Expected '&' got '{0}'", new object[]
							{
								text
							});
							this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.Unknown));
						}
						else
						{
							this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.DoubleAmpersand));
							i++;
						}
						break;
					}
					case '\'':
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.SingleQuote));
						break;
					case '*':
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.Asterisk));
						break;
					case '+':
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.Plus));
						break;
					case ',':
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.Comma));
						break;
					default:
						switch (c3)
						{
						case '<':
							this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.LessThan));
							break;
						case '=':
							goto IL_2E1;
						case '>':
							this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.GreaterThan));
							break;
						case '?':
							this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.QuestionMark));
							break;
						default:
							goto IL_2E1;
						}
						break;
					}
				}
				else if (c3 != '[')
				{
					if (c3 != ']')
					{
						switch (c3)
						{
						case '{':
							this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.OpenBrace));
							break;
						case '|':
						{
							bool flag2 = StyleSyntaxTokenizer.IsNextCharacter(syntax, i, '|');
							if (flag2)
							{
								this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.DoubleBar));
								i++;
							}
							else
							{
								this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.SingleBar));
							}
							break;
						}
						case '}':
							this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.CloseBrace));
							break;
						default:
							goto IL_2E1;
						}
					}
					else
					{
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.CloseBracket));
					}
				}
				else
				{
					this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.OpenBracket));
				}
				IL_3BC:
				i++;
				continue;
				IL_2E1:
				bool flag3 = char.IsNumber(c);
				if (flag3)
				{
					int startIndex = i;
					int num = 1;
					while (StyleSyntaxTokenizer.IsNextNumber(syntax, i))
					{
						i++;
						num++;
					}
					string s = syntax.Substring(startIndex, num);
					int number = int.Parse(s);
					this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.Number, number));
				}
				else
				{
					bool flag4 = char.IsLetter(c);
					if (flag4)
					{
						int startIndex2 = i;
						int num2 = 1;
						while (StyleSyntaxTokenizer.IsNextLetterOrDash(syntax, i))
						{
							i++;
							num2++;
						}
						string text2 = syntax.Substring(startIndex2, num2);
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.String, text2));
					}
					else
					{
						Debug.LogAssertionFormat("Expected letter or number got '{0}'", new object[]
						{
							c
						});
						this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.Unknown));
					}
				}
				goto IL_3BC;
			}
			this.m_Tokens.Add(new StyleSyntaxToken(StyleSyntaxTokenType.End));
		}

		// Token: 0x0600253F RID: 9535 RVA: 0x0009DC20 File Offset: 0x0009BE20
		private static bool IsNextCharacter(string s, int index, char c)
		{
			return index + 1 < s.Length && s[index + 1] == c;
		}

		// Token: 0x06002540 RID: 9536 RVA: 0x0009DC4C File Offset: 0x0009BE4C
		private static bool IsNextLetterOrDash(string s, int index)
		{
			return index + 1 < s.Length && (char.IsLetter(s[index + 1]) || s[index + 1] == '-');
		}

		// Token: 0x06002541 RID: 9537 RVA: 0x0009DC8C File Offset: 0x0009BE8C
		private static bool IsNextNumber(string s, int index)
		{
			return index + 1 < s.Length && char.IsNumber(s[index + 1]);
		}

		// Token: 0x06002542 RID: 9538 RVA: 0x0009DCBC File Offset: 0x0009BEBC
		private static int GlobCharacter(string s, int index, char c)
		{
			while (StyleSyntaxTokenizer.IsNextCharacter(s, index, c))
			{
				index++;
			}
			return index;
		}

		// Token: 0x0400122B RID: 4651
		private List<StyleSyntaxToken> m_Tokens = new List<StyleSyntaxToken>();

		// Token: 0x0400122C RID: 4652
		private int m_CurrentTokenIndex = -1;
	}
}
