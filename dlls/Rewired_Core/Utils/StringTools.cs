using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x0200049A RID: 1178
	public static class StringTools
	{
		// Token: 0x06002F5C RID: 12124 RVA: 0x000A56D8 File Offset: 0x000A38D8
		public static string ToString(int[] inArray)
		{
			string text = "";
			for (int i = 0; i < inArray.Length; i++)
			{
				text += inArray[i].ToString();
				if (i < inArray.Length - 1)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F5D RID: 12125 RVA: 0x000A5724 File Offset: 0x000A3924
		public static string ToString(float[] inArray)
		{
			string text = "";
			for (int i = 0; i < inArray.Length; i++)
			{
				text += inArray[i].ToString();
				if (i < inArray.Length - 1)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F5E RID: 12126 RVA: 0x000A5770 File Offset: 0x000A3970
		public static string ToString(string[] inArray)
		{
			string text = "";
			for (int i = 0; i < inArray.Length; i++)
			{
				text += inArray[i];
				if (i < inArray.Length - 1)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F5F RID: 12127 RVA: 0x000A57B0 File Offset: 0x000A39B0
		public static string ToString(bool[] inArray)
		{
			string text = "";
			for (int i = 0; i < inArray.Length; i++)
			{
				text += inArray[i].ToString();
				if (i < inArray.Length - 1)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F60 RID: 12128 RVA: 0x000A57FC File Offset: 0x000A39FC
		public static string ToString(byte[] inArray)
		{
			string text = "";
			for (int i = 0; i < inArray.Length; i++)
			{
				text += inArray[i].ToString();
				if (i < inArray.Length - 1)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F61 RID: 12129 RVA: 0x000A5848 File Offset: 0x000A3A48
		public static string ToString(byte[] inArray, string stringOptions, int maxItemsPerLine = 0)
		{
			string text = "";
			for (int i = 0; i < inArray.Length; i++)
			{
				text += inArray[i].ToString(stringOptions);
				if (maxItemsPerLine > 0)
				{
					if ((i + 1) % maxItemsPerLine == 0)
					{
						text += "\n";
					}
					else if (i < inArray.Length - 1)
					{
						text += ", ";
					}
				}
				else if (i < inArray.Length - 1)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F62 RID: 12130 RVA: 0x000A58C4 File Offset: 0x000A3AC4
		public static string ToString(Vector3[] inArray)
		{
			string text = "";
			for (int i = 0; i < inArray.Length; i++)
			{
				string str = text;
				Vector3 vector = inArray[i];
				text = str + vector.ToString();
				if (i < inArray.Length - 1)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F63 RID: 12131 RVA: 0x000A5918 File Offset: 0x000A3B18
		public static string ToString(List<object> list)
		{
			string text = "";
			for (int i = 0; i < list.Count; i++)
			{
				string str = text;
				object obj = list[i];
				text = str + ((obj != null) ? obj.ToString() : null);
				if (i < list.Count - 1)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F64 RID: 12132 RVA: 0x000242C5 File Offset: 0x000224C5
		public static string ToString(Vector2 v)
		{
			return v.x.ToString() + ", " + v.y.ToString();
		}

		// Token: 0x06002F65 RID: 12133 RVA: 0x000A5970 File Offset: 0x000A3B70
		public static string ToString(Vector3 v)
		{
			return string.Concat(new string[]
			{
				v.x.ToString(),
				", ",
				v.y.ToString(),
				", ",
				v.z.ToString()
			});
		}

		// Token: 0x06002F66 RID: 12134 RVA: 0x000A59C8 File Offset: 0x000A3BC8
		public static string ToString<T>(T[] inArray)
		{
			string text = "";
			int num = inArray.Length - 1;
			for (int i = 0; i < inArray.Length; i++)
			{
				text += inArray[i].ToString();
				if (i < num)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F67 RID: 12135 RVA: 0x000A5A1C File Offset: 0x000A3C1C
		public static string ToString<T>(List<T> inList)
		{
			string text = "";
			int num = inList.Count - 1;
			for (int i = 0; i < inList.Count; i++)
			{
				string str = text;
				T t = inList[i];
				text = str + t.ToString();
				if (i < num)
				{
					text += ", ";
				}
			}
			return text;
		}

		// Token: 0x06002F68 RID: 12136 RVA: 0x000A5A78 File Offset: 0x000A3C78
		public static string[] Split(string str, string delimiter)
		{
			if (str == null)
			{
				return null;
			}
			return str.Split(new char[]
			{
				delimiter[0]
			});
		}

		// Token: 0x06002F69 RID: 12137 RVA: 0x000A5AA4 File Offset: 0x000A3CA4
		public static string[] SplitAndTrim(string str, string delimiter)
		{
			if (str == null)
			{
				return null;
			}
			string[] array = StringTools.Split(str, delimiter);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				array[i] = text.Trim();
			}
			return array;
		}

		// Token: 0x06002F6A RID: 12138 RVA: 0x000242E9 File Offset: 0x000224E9
		public static string DecodeNewlines(string s)
		{
			return s.Replace("\\r\\n", "\n");
		}

		// Token: 0x06002F6B RID: 12139 RVA: 0x000242FB File Offset: 0x000224FB
		public static string EncodeNewlines(string s)
		{
			return s.Replace("\n", "\\r\\n");
		}

		// Token: 0x06002F6C RID: 12140 RVA: 0x000A5ADC File Offset: 0x000A3CDC
		public static string ArrayToText(string[] sA)
		{
			string text = "";
			for (int i = 0; i < sA.Length; i++)
			{
				string str = sA[i];
				if (i != 0)
				{
					text += "\n";
				}
				text += str;
			}
			return text;
		}

		// Token: 0x06002F6D RID: 12141 RVA: 0x0002430D File Offset: 0x0002250D
		public static string[] TextToArray(string s)
		{
			return s.Split("\n"[0], StringSplitOptions.None);
		}

		// Token: 0x06002F6E RID: 12142 RVA: 0x00024321 File Offset: 0x00022521
		public static string StringToString(string s)
		{
			if (s == null)
			{
				return "";
			}
			return s;
		}

		// Token: 0x06002F6F RID: 12143 RVA: 0x000A5B1C File Offset: 0x000A3D1C
		public static int StringToInt(string s)
		{
			int result;
			int.TryParse(s, out result);
			return result;
		}

		// Token: 0x06002F70 RID: 12144 RVA: 0x000A5B34 File Offset: 0x000A3D34
		public static float StringToFloat(string s)
		{
			float result;
			float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
			return result;
		}

		// Token: 0x06002F71 RID: 12145 RVA: 0x000A5B58 File Offset: 0x000A3D58
		public static bool StringToBoolean(string s)
		{
			bool result;
			bool.TryParse(s, out result);
			return result;
		}

		// Token: 0x06002F72 RID: 12146 RVA: 0x0002432D File Offset: 0x0002252D
		public static KeyCode StringToKeyCode(string s)
		{
			return (KeyCode)Enum.Parse(typeof(KeyCode), s);
		}

		// Token: 0x06002F73 RID: 12147 RVA: 0x00024344 File Offset: 0x00022544
		public static Enum StringToEnum(string str, Type type)
		{
			return (Enum)Enum.Parse(type, str);
		}

		// Token: 0x06002F74 RID: 12148 RVA: 0x000A5B70 File Offset: 0x000A3D70
		public static string ToStringWithCount(string s)
		{
			if (s == "" || s == null)
			{
				return "0|";
			}
			s = s.Replace("|"[0], ""[0]);
			if (s == "" || s == null)
			{
				return "0|";
			}
			s = s.Length.ToString() + "|" + s;
			return s;
		}

		// Token: 0x06002F75 RID: 12149 RVA: 0x00024352 File Offset: 0x00022552
		public static char[] StringToCharArray(string s)
		{
			if (s == null)
			{
				return null;
			}
			return s.ToCharArray();
		}

		// Token: 0x06002F76 RID: 12150 RVA: 0x0002435F File Offset: 0x0002255F
		public static string CharArrayToString(char[] c)
		{
			if (c == null)
			{
				return null;
			}
			return new string(c);
		}

		// Token: 0x06002F77 RID: 12151 RVA: 0x000A5BE4 File Offset: 0x000A3DE4
		public static string CSVEncode(string s)
		{
			if (s == null || s == "")
			{
				return ",";
			}
			s = s.Replace("\\", "\\\\");
			s = s.Replace(",", "\\,");
			return s + ",";
		}

		// Token: 0x06002F78 RID: 12152 RVA: 0x000A5C38 File Offset: 0x000A3E38
		public static string CSVDecode(string s)
		{
			if (s == null || s == "")
			{
				return "";
			}
			char c = ","[0];
			char c2 = "\\"[0];
			bool flag = false;
			string text = "";
			for (int i = 0; i < s.Length; i++)
			{
				bool flag2 = false;
				if (s[i] == c2)
				{
					if (flag)
					{
						flag2 = true;
					}
					flag = !flag;
				}
				else if (s[i] == c && flag)
				{
					flag2 = true;
					flag = false;
				}
				else
				{
					flag = false;
				}
				if (flag2)
				{
					text = text.Substring(0, text.Length - 1);
				}
				text += s[i].ToString();
			}
			return text;
		}

		// Token: 0x06002F79 RID: 12153 RVA: 0x000A5CF8 File Offset: 0x000A3EF8
		public static string[] CSVToArray(string s)
		{
			if (s == null || s == "")
			{
				return null;
			}
			char c = ","[0];
			char c2 = "\\"[0];
			List<object> list = new List<object>();
			string text = "";
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == c2)
				{
					flag = !flag;
				}
				else
				{
					if (s[i] == c && !flag)
					{
						flag2 = true;
					}
					flag = false;
				}
				if (!flag2)
				{
					text += s[i].ToString();
				}
				else
				{
					text = StringTools.CSVDecode(text);
					list.Add(text);
					text = "";
					flag2 = false;
				}
			}
			string[] array = new string[list.Count];
			for (int j = 0; j < list.Count; j++)
			{
				array[j] = (string)list[j];
			}
			return array;
		}

		// Token: 0x06002F7A RID: 12154 RVA: 0x000A5DEC File Offset: 0x000A3FEC
		public static bool TryParseEnum<TEnum>(string value, out TEnum enumeration)
		{
			enumeration = default(TEnum);
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}
			Type typeFromHandle = typeof(TEnum);
			try
			{
				enumeration = (TEnum)((object)Enum.Parse(typeFromHandle, value, true));
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06002F7B RID: 12155 RVA: 0x0002436C File Offset: 0x0002256C
		public static string TimeToString(int seconds)
		{
			return StringTools.TimeToString((float)seconds);
		}

		// Token: 0x06002F7C RID: 12156 RVA: 0x000A5E44 File Offset: 0x000A4044
		public static string TimeToString(float seconds)
		{
			if (seconds == 0f)
			{
				return seconds.ToString() + " seconds";
			}
			float num = MathTools.Abs(seconds);
			int num2 = MathTools.FloorToInt(num / 3600f);
			float num3 = num - (float)(num2 * 3600);
			int num4 = MathTools.FloorToInt(num3 / 60f);
			float num5 = num3 - (float)(num4 * 60);
			string text = "";
			if (num2 > 0)
			{
				text = text + num2.ToString() + " h";
			}
			if (num4 > 0)
			{
				if (text != "")
				{
					text += ", ";
				}
				text = text + num4.ToString() + " m";
			}
			if (num5 > 0f)
			{
				if (text != "")
				{
					text += ", ";
				}
				text = text + num5.ToString() + " s";
			}
			return text;
		}

		// Token: 0x06002F7E RID: 12158 RVA: 0x000A5F20 File Offset: 0x000A4120
		public static string CleanUpFileName(string name)
		{
			name = name.Trim();
			string pattern = "[ ~`,:;'\\.\\$\\^\\{\\}\\[\\]\\(\\|\\)\\*\\+\\?\\\\" + StringTools.ynahSsPmqgtRrDTtdnAxPZlYWTAD + "]";
			name = Regex.Replace(name, pattern, "_");
			return name;
		}

		// Token: 0x06002F7F RID: 12159 RVA: 0x000A5F5C File Offset: 0x000A415C
		public static string StripTrailingNumbers(string name)
		{
			int num;
			return StringTools.StripTrailingNumbers(name, out num);
		}

		// Token: 0x06002F80 RID: 12160 RVA: 0x000A5F74 File Offset: 0x000A4174
		public static string StripTrailingNumbers(string name, out int number)
		{
			Match match = Regex.Match(name, "[0-9]+$");
			if (!match.Success)
			{
				number = -1;
				return name;
			}
			if (!int.TryParse(match.Value, out number))
			{
				throw new Exception("Could not parse string to Int32! " + match.Value);
			}
			int index = match.Index;
			if (index == 0)
			{
				return "";
			}
			return name.Substring(0, index);
		}

		// Token: 0x06002F81 RID: 12161 RVA: 0x0002438B File Offset: 0x0002258B
		public static string VerifyName(string name, int indexInNameList, string[] names, bool cleanUpIllegalFileChars)
		{
			return StringTools.VerifyName(name, indexInNameList, names, cleanUpIllegalFileChars, false);
		}

		// Token: 0x06002F82 RID: 12162 RVA: 0x000A5FD8 File Offset: 0x000A41D8
		public static string VerifyName(string name, int indexInNameList, string[] names, bool cleanUpIllegalFileChars, bool allowBlank)
		{
			if (cleanUpIllegalFileChars)
			{
				name = StringTools.CleanUpFileName(name);
			}
			else if (name != null)
			{
				name = name.Trim();
			}
			if (!allowBlank && string.IsNullOrEmpty(name))
			{
				name = "0";
			}
			if (allowBlank && string.IsNullOrEmpty(name))
			{
				return name;
			}
			int num = (names != null) ? names.Length : 0;
			if (num == 0)
			{
				return name;
			}
			for (int i = 0; i < num; i++)
			{
				if (i != indexInNameList && names[i] != null && name.Equals(names[i], StringComparison.OrdinalIgnoreCase))
				{
					return StringTools.IterateName(name, indexInNameList, names);
				}
			}
			return name;
		}

		// Token: 0x06002F83 RID: 12163 RVA: 0x000A6058 File Offset: 0x000A4258
		public static string IterateName(string name, int indexInNameList = -1, string[] names = null)
		{
			int num;
			string text = StringTools.StripTrailingNumbers(name, out num);
			if (names != null)
			{
				int num2 = -1;
				int num3 = names.Length;
				for (int i = 0; i < num3; i++)
				{
					if (i != indexInNameList && names[i] != null)
					{
						string text2 = names[i];
						int num4;
						text2 = StringTools.StripTrailingNumbers(text2, out num4);
						if (text.Equals(text2, StringComparison.OrdinalIgnoreCase) && num4 > num2)
						{
							num2 = num4;
						}
					}
				}
				return text + (num2 + 1).ToString();
			}
			return text + (num + 1).ToString();
		}

		// Token: 0x06002F84 RID: 12164 RVA: 0x000A60DC File Offset: 0x000A42DC
		public static string ToString(Rect rect)
		{
			return string.Format("{0}, {1}, {2}, {3}", new object[]
			{
				rect.x,
				rect.y,
				rect.width,
				rect.height
			});
		}

		// Token: 0x06002F85 RID: 12165 RVA: 0x000A6138 File Offset: 0x000A4338
		public static Guid ToGuid(string guid)
		{
			Guid result;
			try
			{
				result = new Guid(guid);
			}
			catch
			{
				result = Guid.Empty;
			}
			return result;
		}

		// Token: 0x06002F86 RID: 12166 RVA: 0x000A6168 File Offset: 0x000A4368
		public static byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length * 2];
			Buffer.BlockCopy(str.ToCharArray(), 0, array, 0, array.Length);
			return array;
		}

		// Token: 0x06002F87 RID: 12167 RVA: 0x000A6198 File Offset: 0x000A4398
		public static string GetString(byte[] bytes)
		{
			char[] array = new char[bytes.Length / 2];
			Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
			return new string(array);
		}

		// Token: 0x06002F88 RID: 12168 RVA: 0x000A61C4 File Offset: 0x000A43C4
		public static string ByteShiftEncode(string source, short shift)
		{
			if (source == null || source == string.Empty)
			{
				return string.Empty;
			}
			int num = Convert.ToInt32(char.MaxValue);
			int num2 = Convert.ToInt32('\0');
			char[] array = source.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				int num3 = Convert.ToInt32(array[i]) + (int)shift;
				if (num3 > num)
				{
					num3 -= num;
				}
				else if (num3 < num2)
				{
					num3 += num;
				}
				array[i] = Convert.ToChar(num3);
			}
			return new string(array);
		}

		// Token: 0x06002F89 RID: 12169 RVA: 0x000A6244 File Offset: 0x000A4444
		public static string GetNullTerminatedUnicodeString(byte[] bytes)
		{
			if (bytes == null || bytes.Length < 3)
			{
				return string.Empty;
			}
			int num = -1;
			for (int i = 0; i < bytes.Length; i += 2)
			{
				if (bytes[i] == 0)
				{
					num = i - 1;
					break;
				}
			}
			if (num < 0)
			{
				return string.Empty;
			}
			int count = num + 1;
			return Encoding.Unicode.GetString(bytes, 0, count);
		}

		// Token: 0x06002F8A RID: 12170 RVA: 0x000A6298 File Offset: 0x000A4498
		public static string SanitizeDeviceString(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			string result;
			try
			{
				result = Regex.Replace(text, "[\\x1A]", "");
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06002F8B RID: 12171 RVA: 0x00024397 File Offset: 0x00022597
		public static string ReplaceChar(string @string, int index, char replacement)
		{
			if (string.IsNullOrEmpty(@string))
			{
				return @string;
			}
			if (index >= @string.Length)
			{
				return @string;
			}
			if (index < 0)
			{
				return @string;
			}
			char[] array = @string.ToCharArray();
			array[index] = replacement;
			return new string(array);
		}

		// Token: 0x06002F8C RID: 12172 RVA: 0x000A62E4 File Offset: 0x000A44E4
		public static string AddSpacesToSentence(string text, bool preserveAcronyms)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length * 2);
			stringBuilder.Append(text[0]);
			for (int i = 1; i < text.Length; i++)
			{
				if (char.IsUpper(text[i]) && ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) || (preserveAcronyms && char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1]))))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(text[i]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06002F8D RID: 12173 RVA: 0x000243C3 File Offset: 0x000225C3
		public static string WriteVar(string name, object value)
		{
			return StringTools.WriteVar(name, value, '=');
		}

		// Token: 0x06002F8E RID: 12174 RVA: 0x000A63A4 File Offset: 0x000A45A4
		public static string WriteVar(string name, object value, char delimiter)
		{
			return string.Concat(new string[]
			{
				name,
				" ",
				delimiter.ToString(),
				" ",
				(value != null) ? value.ToString() : "NULL",
				"\n"
			});
		}

		// Token: 0x06002F8F RID: 12175 RVA: 0x000243CE File Offset: 0x000225CE
		public static void WriteVar(StringBuilder sb, string name, object value)
		{
			StringTools.WriteVar(sb, name, value, '=');
		}

		// Token: 0x06002F90 RID: 12176 RVA: 0x000A63F8 File Offset: 0x000A45F8
		public static void WriteVar(StringBuilder sb, string name, object value, char delimiter)
		{
			sb.Append(name);
			sb.Append(" ");
			sb.Append(delimiter);
			sb.Append(" ");
			sb.Append((value != null) ? value.ToString() : ((value is string) ? string.Empty : "NULL"));
			sb.Append("\n");
		}

		// Token: 0x06002F91 RID: 12177 RVA: 0x000243DA File Offset: 0x000225DA
		public static string Trim(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}
			return str.Trim();
		}

		// Token: 0x06002F92 RID: 12178 RVA: 0x000A6460 File Offset: 0x000A4660
		public static string VariableNameToDisplayName(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return fieldName;
			}
			fieldName = Regex.Replace(fieldName, "[^a-zA-Z0-9_]", "");
			fieldName = Regex.Replace(fieldName, "[_]{2,}", "_");
			if (fieldName.StartsWith("m_") && fieldName.Length > 2)
			{
				fieldName = fieldName.Substring(2);
			}
			fieldName = Regex.Replace(fieldName, "[_]", " ");
			fieldName = fieldName.Trim();
			MatchCollection matchCollection = Regex.Matches(fieldName, "\\b([a-z])");
			char[] array = fieldName.ToCharArray();
			for (int i = 0; i < matchCollection.Count; i++)
			{
				int index = matchCollection[i].Index;
				array[index] = array[index].ToString().ToUpper()[0];
			}
			fieldName = StringTools.AddSpacesToSentence(new string(array), false);
			return Regex.Replace(fieldName, "([a-zA-Z_]+)([0-9]+)", "$1 $2");
		}

		// Token: 0x06002F93 RID: 12179 RVA: 0x000A6540 File Offset: 0x000A4740
		public static int CountChars(string text, char character)
		{
			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == character)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002F94 RID: 12180 RVA: 0x000243EC File Offset: 0x000225EC
		public static string AddSpacesToCamelCase(string text)
		{
			return StringTools.AddSpacesToCamelCase(text, false);
		}

		// Token: 0x06002F95 RID: 12181 RVA: 0x000A657C File Offset: 0x000A477C
		public static string AddSpacesToCamelCase(string text, bool preserveAcronyms)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length * 2);
			stringBuilder.Append(text[0]);
			for (int i = 1; i < text.Length; i++)
			{
				if (char.IsUpper(text[i]))
				{
					if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) || (preserveAcronyms && char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1])))
					{
						stringBuilder.Append(' ');
					}
				}
				else if (char.IsDigit(text[i]) && text[i - 1] != ' ' && !char.IsDigit(text[i - 1]))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(text[i]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06002F96 RID: 12182 RVA: 0x000A6678 File Offset: 0x000A4878
		public static string CamelCaseToSnakeCase(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			if (text.Length < 2)
			{
				return text.ToLowerInvariant();
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(char.ToLowerInvariant(text[0]));
			for (int i = 1; i < text.Length; i++)
			{
				char c = text[i];
				if (char.IsUpper(c))
				{
					stringBuilder.Append('_');
					stringBuilder.Append(char.ToLowerInvariant(c));
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040019C7 RID: 6599
		private static string ynahSsPmqgtRrDTtdnAxPZlYWTAD = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
	}
}
