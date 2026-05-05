using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001A1 RID: 417
	public class fsJsonParser
	{
		// Token: 0x06000AE8 RID: 2792 RVA: 0x0002D63C File Offset: 0x0002B83C
		private fsJsonParser(string input)
		{
			this._input = input;
			this._start = 0;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0002D664 File Offset: 0x0002B864
		private fsResult MakeFailure(string message)
		{
			int num = Math.Max(0, this._start - 20);
			int length = Math.Min(50, this._input.Length - num);
			return fsResult.Fail(string.Concat(new string[]
			{
				"Error while parsing: ",
				message,
				"; context = <",
				this._input.Substring(num, length),
				">"
			}));
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0002D6D2 File Offset: 0x0002B8D2
		private bool TryMoveNext()
		{
			if (this._start < this._input.Length)
			{
				this._start++;
				return true;
			}
			return false;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0002D6F8 File Offset: 0x0002B8F8
		private bool HasValue()
		{
			return this.HasValue(0);
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0002D701 File Offset: 0x0002B901
		private bool HasValue(int offset)
		{
			return this._start + offset >= 0 && this._start + offset < this._input.Length;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0002D725 File Offset: 0x0002B925
		private char Character()
		{
			return this.Character(0);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0002D72E File Offset: 0x0002B92E
		private char Character(int offset)
		{
			return this._input[this._start + offset];
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0002D744 File Offset: 0x0002B944
		private void SkipSpace()
		{
			while (this.HasValue())
			{
				if (char.IsWhiteSpace(this.Character()))
				{
					this.TryMoveNext();
				}
				else
				{
					if (!this.HasValue(1) || this.Character(0) != '/')
					{
						break;
					}
					if (this.Character(1) == '/')
					{
						while (this.HasValue())
						{
							if (Environment.NewLine.Contains(this.Character().ToString() ?? ""))
							{
								break;
							}
							this.TryMoveNext();
						}
					}
					else if (this.Character(1) == '*')
					{
						this.TryMoveNext();
						this.TryMoveNext();
						while (this.HasValue(1))
						{
							if (this.Character(0) == '*' && this.Character(1) == '/')
							{
								this.TryMoveNext();
								this.TryMoveNext();
								this.TryMoveNext();
								break;
							}
							this.TryMoveNext();
						}
					}
				}
			}
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0002D830 File Offset: 0x0002BA30
		private fsResult TryParseExact(string content)
		{
			for (int i = 0; i < content.Length; i++)
			{
				if (this.Character() != content[i])
				{
					return this.MakeFailure("Expected " + content[i].ToString());
				}
				if (!this.TryMoveNext())
				{
					return this.MakeFailure("Unexpected end of content when parsing " + content);
				}
			}
			return fsResult.Success;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0002D89C File Offset: 0x0002BA9C
		private fsResult TryParseTrue(out fsData data)
		{
			fsResult result = this.TryParseExact("true");
			if (result.Succeeded)
			{
				data = new fsData(true);
				return fsResult.Success;
			}
			data = null;
			return result;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0002D8D0 File Offset: 0x0002BAD0
		private fsResult TryParseFalse(out fsData data)
		{
			fsResult result = this.TryParseExact("false");
			if (result.Succeeded)
			{
				data = new fsData(false);
				return fsResult.Success;
			}
			data = null;
			return result;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0002D904 File Offset: 0x0002BB04
		private fsResult TryParseNull(out fsData data)
		{
			fsResult result = this.TryParseExact("null");
			if (result.Succeeded)
			{
				data = new fsData();
				return fsResult.Success;
			}
			data = null;
			return result;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0002D937 File Offset: 0x0002BB37
		private bool IsSeparator(char c)
		{
			return char.IsWhiteSpace(c) || c == ',' || c == '}' || c == ']';
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0002D954 File Offset: 0x0002BB54
		private fsResult TryParseNumber(out fsData data)
		{
			int start = this._start;
			while (this.TryMoveNext() && this.HasValue() && !this.IsSeparator(this.Character()))
			{
			}
			string text = this._input.Substring(start, this._start - start);
			if (text.Contains(".") || text.Contains("e") || text.Contains("E") || text == "Infinity" || text == "-Infinity" || text == "NaN")
			{
				double f;
				if (!double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out f))
				{
					data = null;
					return this.MakeFailure("Bad double format with " + text);
				}
				data = new fsData(f);
				return fsResult.Success;
			}
			else
			{
				long i;
				if (!long.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out i))
				{
					data = null;
					return this.MakeFailure("Bad Int64 format with " + text);
				}
				data = new fsData(i);
				return fsResult.Success;
			}
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0002DA58 File Offset: 0x0002BC58
		private fsResult TryParseString(out string str)
		{
			this._cachedStringBuilder.Length = 0;
			if (this.Character() != '"' || !this.TryMoveNext())
			{
				str = string.Empty;
				return this.MakeFailure("Expected initial \" when parsing a string");
			}
			while (this.HasValue() && this.Character() != '"')
			{
				char c = this.Character();
				if (c == '\\')
				{
					char value;
					fsResult result = this.TryUnescapeChar(out value);
					if (result.Failed)
					{
						str = string.Empty;
						return result;
					}
					this._cachedStringBuilder.Append(value);
				}
				else
				{
					this._cachedStringBuilder.Append(c);
					if (!this.TryMoveNext())
					{
						str = string.Empty;
						return this.MakeFailure("Unexpected end of input when reading a string");
					}
				}
			}
			if (!this.HasValue() || this.Character() != '"' || !this.TryMoveNext())
			{
				str = string.Empty;
				return this.MakeFailure("No closing \" when parsing a string");
			}
			str = this._cachedStringBuilder.ToString();
			return fsResult.Success;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0002DB48 File Offset: 0x0002BD48
		private fsResult TryParseArray(out fsData arr)
		{
			if (this.Character() != '[')
			{
				arr = null;
				return this.MakeFailure("Expected initial [ when parsing an array");
			}
			if (!this.TryMoveNext())
			{
				arr = null;
				return this.MakeFailure("Unexpected end of input when parsing an array");
			}
			this.SkipSpace();
			List<fsData> list = new List<fsData>();
			while (this.HasValue() && this.Character() != ']')
			{
				fsData item;
				fsResult result = this.RunParse(out item);
				if (result.Failed)
				{
					arr = null;
					return result;
				}
				list.Add(item);
				this.SkipSpace();
				if (this.HasValue() && this.Character() == ',')
				{
					if (!this.TryMoveNext())
					{
						break;
					}
					this.SkipSpace();
				}
			}
			if (!this.HasValue() || this.Character() != ']' || !this.TryMoveNext())
			{
				arr = null;
				return this.MakeFailure("No closing ] for array");
			}
			arr = new fsData(list);
			return fsResult.Success;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0002DC20 File Offset: 0x0002BE20
		private fsResult TryParseObject(out fsData obj)
		{
			if (this.Character() != '{')
			{
				obj = null;
				return this.MakeFailure("Expected initial { when parsing an object");
			}
			if (!this.TryMoveNext())
			{
				obj = null;
				return this.MakeFailure("Unexpected end of input when parsing an object");
			}
			this.SkipSpace();
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>(fsGlobalConfig.IsCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);
			while (this.HasValue() && this.Character() != '}')
			{
				this.SkipSpace();
				string text;
				fsResult result = this.TryParseString(out text);
				if (result.Failed)
				{
					obj = null;
					return result;
				}
				this.SkipSpace();
				if (!this.HasValue() || this.Character() != ':' || !this.TryMoveNext())
				{
					obj = null;
					return this.MakeFailure("Expected : after key \"" + text + "\"");
				}
				this.SkipSpace();
				fsData value;
				result = this.RunParse(out value);
				if (result.Failed)
				{
					obj = null;
					return result;
				}
				dictionary.Add(text, value);
				this.SkipSpace();
				if (this.HasValue() && this.Character() == ',')
				{
					if (!this.TryMoveNext())
					{
						break;
					}
					this.SkipSpace();
				}
			}
			if (!this.HasValue() || this.Character() != '}' || !this.TryMoveNext())
			{
				obj = null;
				return this.MakeFailure("No closing } for object");
			}
			obj = new fsData(dictionary);
			return fsResult.Success;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0002DD70 File Offset: 0x0002BF70
		private fsResult RunParse(out fsData data)
		{
			this.SkipSpace();
			if (!this.HasValue())
			{
				data = null;
				return this.MakeFailure("Unexpected end of input");
			}
			char c = this.Character();
			if (c <= '[')
			{
				if (c <= 'I')
				{
					switch (c)
					{
					case '"':
					{
						string str;
						fsResult result = this.TryParseString(out str);
						if (result.Failed)
						{
							data = null;
							return result;
						}
						data = new fsData(str);
						return fsResult.Success;
					}
					case '#':
					case '$':
					case '%':
					case '&':
					case '\'':
					case '(':
					case ')':
					case '*':
					case ',':
					case '/':
						goto IL_11F;
					case '+':
					case '-':
					case '.':
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						break;
					default:
						if (c != 'I')
						{
							goto IL_11F;
						}
						break;
					}
				}
				else if (c != 'N')
				{
					if (c != '[')
					{
						goto IL_11F;
					}
					return this.TryParseArray(out data);
				}
				return this.TryParseNumber(out data);
			}
			if (c <= 'n')
			{
				if (c == 'f')
				{
					return this.TryParseFalse(out data);
				}
				if (c == 'n')
				{
					return this.TryParseNull(out data);
				}
			}
			else
			{
				if (c == 't')
				{
					return this.TryParseTrue(out data);
				}
				if (c == '{')
				{
					return this.TryParseObject(out data);
				}
			}
			IL_11F:
			data = null;
			return this.MakeFailure("unable to parse; invalid token \"" + this.Character().ToString() + "\"");
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0002DEC2 File Offset: 0x0002C0C2
		public static fsResult Parse(string input, out fsData data)
		{
			if (string.IsNullOrEmpty(input))
			{
				data = null;
				return fsResult.Fail("No input");
			}
			return new fsJsonParser(input).RunParse(out data);
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0002DEE8 File Offset: 0x0002C0E8
		public static fsData Parse(string input)
		{
			fsData result;
			fsJsonParser.Parse(input, out result).AssertSuccess();
			return result;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0002DF07 File Offset: 0x0002C107
		private bool IsHex(char c)
		{
			return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0002DF30 File Offset: 0x0002C130
		private uint ParseSingleChar(char c1, uint multipliyer)
		{
			uint result = 0U;
			if (c1 >= '0' && c1 <= '9')
			{
				result = (uint)(c1 - '0') * multipliyer;
			}
			else if (c1 >= 'A' && c1 <= 'F')
			{
				result = (uint)(c1 - 'A' + '\n') * multipliyer;
			}
			else if (c1 >= 'a' && c1 <= 'f')
			{
				result = (uint)(c1 - 'a' + '\n') * multipliyer;
			}
			return result;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0002DF80 File Offset: 0x0002C180
		private uint ParseUnicode(char c1, char c2, char c3, char c4)
		{
			uint num = this.ParseSingleChar(c1, 4096U);
			uint num2 = this.ParseSingleChar(c2, 256U);
			uint num3 = this.ParseSingleChar(c3, 16U);
			uint num4 = this.ParseSingleChar(c4, 1U);
			return num + num2 + num3 + num4;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0002DFC0 File Offset: 0x0002C1C0
		private fsResult TryUnescapeChar(out char escaped)
		{
			this.TryMoveNext();
			if (!this.HasValue())
			{
				escaped = ' ';
				return this.MakeFailure("Unexpected end of input after \\");
			}
			char c = this.Character();
			if (c <= '\\')
			{
				if (c <= '/')
				{
					if (c == '"')
					{
						this.TryMoveNext();
						escaped = '"';
						return fsResult.Success;
					}
					if (c == '/')
					{
						this.TryMoveNext();
						escaped = '/';
						return fsResult.Success;
					}
				}
				else
				{
					if (c == '0')
					{
						this.TryMoveNext();
						escaped = '\0';
						return fsResult.Success;
					}
					if (c == '\\')
					{
						this.TryMoveNext();
						escaped = '\\';
						return fsResult.Success;
					}
				}
			}
			else if (c <= 'b')
			{
				if (c == 'a')
				{
					this.TryMoveNext();
					escaped = '\a';
					return fsResult.Success;
				}
				if (c == 'b')
				{
					this.TryMoveNext();
					escaped = '\b';
					return fsResult.Success;
				}
			}
			else
			{
				if (c == 'f')
				{
					this.TryMoveNext();
					escaped = '\f';
					return fsResult.Success;
				}
				if (c == 'n')
				{
					this.TryMoveNext();
					escaped = '\n';
					return fsResult.Success;
				}
				switch (c)
				{
				case 'r':
					this.TryMoveNext();
					escaped = '\r';
					return fsResult.Success;
				case 't':
					this.TryMoveNext();
					escaped = '\t';
					return fsResult.Success;
				case 'u':
					this.TryMoveNext();
					if (this.IsHex(this.Character(0)) && this.IsHex(this.Character(1)) && this.IsHex(this.Character(2)) && this.IsHex(this.Character(3)))
					{
						uint num = this.ParseUnicode(this.Character(0), this.Character(1), this.Character(2), this.Character(3));
						this.TryMoveNext();
						this.TryMoveNext();
						this.TryMoveNext();
						this.TryMoveNext();
						escaped = (char)num;
						return fsResult.Success;
					}
					escaped = '\0';
					return this.MakeFailure(string.Format("invalid escape sequence '\\u{0}{1}{2}{3}'\n", new object[]
					{
						this.Character(0),
						this.Character(1),
						this.Character(2),
						this.Character(3)
					}));
				}
			}
			escaped = '\0';
			return this.MakeFailure(string.Format("Invalid escape sequence \\{0}", this.Character()));
		}

		// Token: 0x04000287 RID: 647
		private readonly StringBuilder _cachedStringBuilder = new StringBuilder(256);

		// Token: 0x04000288 RID: 648
		private int _start;

		// Token: 0x04000289 RID: 649
		private string _input;
	}
}
