using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Unity.VisualScripting
{
	// Token: 0x02000166 RID: 358
	public static class StringUtility
	{
		// Token: 0x06000971 RID: 2417 RVA: 0x000287A9 File Offset: 0x000269A9
		public static bool IsNullOrWhiteSpace(string s)
		{
			return s == null || s.Trim() == string.Empty;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x000287C0 File Offset: 0x000269C0
		public static string FallbackEmpty(string s, string fallback)
		{
			if (string.IsNullOrEmpty(s))
			{
				s = fallback;
			}
			return s;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x000287CE File Offset: 0x000269CE
		public static string FallbackWhitespace(string s, string fallback)
		{
			if (StringUtility.IsNullOrWhiteSpace(s))
			{
				s = fallback;
			}
			return s;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x000287DC File Offset: 0x000269DC
		public static void AppendLineFormat(this StringBuilder sb, string format, params object[] args)
		{
			sb.AppendFormat(format, args);
			sb.AppendLine();
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x000287EE File Offset: 0x000269EE
		public static string ToSeparatedString(this IEnumerable enumerable, string separator)
		{
			return string.Join(separator, (from object o in enumerable
			select ((o != null) ? o.ToString() : null) ?? "(null)").ToArray<string>());
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00028825 File Offset: 0x00026A25
		public static string ToCommaSeparatedString(this IEnumerable enumerable)
		{
			return enumerable.ToSeparatedString(", ");
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00028832 File Offset: 0x00026A32
		public static string ToLineSeparatedString(this IEnumerable enumerable)
		{
			return enumerable.ToSeparatedString(Environment.NewLine);
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0002883F File Offset: 0x00026A3F
		public static bool ContainsInsensitive(this string haystack, string needle)
		{
			return haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0002884F File Offset: 0x00026A4F
		public static IEnumerable<int> AllIndexesOf(this string haystack, string needle)
		{
			if (string.IsNullOrEmpty(needle))
			{
				yield break;
			}
			int index = 0;
			for (;;)
			{
				index = haystack.IndexOf(needle, index, StringComparison.OrdinalIgnoreCase);
				if (index == -1)
				{
					break;
				}
				yield return index;
				index += needle.Length;
			}
			yield break;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x00028868 File Offset: 0x00026A68
		public static string Filter(this string s, bool letters = true, bool numbers = true, bool whitespace = true, bool symbols = true, bool punctuation = true)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in s)
			{
				if ((letters || !char.IsLetter(c)) && (numbers || !char.IsNumber(c)) && (whitespace || !char.IsWhiteSpace(c)) && (symbols || !char.IsSymbol(c)) && (punctuation || !char.IsPunctuation(c)))
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x000288E0 File Offset: 0x00026AE0
		public static string FilterReplace(this string s, char replacement, bool merge, bool letters = true, bool numbers = true, bool whitespace = true, bool symbols = true, bool punctuation = true)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in s)
			{
				if ((!letters && char.IsLetter(c)) || (!numbers && char.IsNumber(c)) || (!whitespace && char.IsWhiteSpace(c)) || (!symbols && char.IsSymbol(c)) || (!punctuation && char.IsPunctuation(c)))
				{
					if (!merge || !flag)
					{
						stringBuilder.Append(replacement);
					}
					flag = true;
				}
				else
				{
					stringBuilder.Append(c);
					flag = false;
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x00028974 File Offset: 0x00026B74
		public static string Prettify(this string s)
		{
			return s.FirstCharacterToUpper().SplitWords(' ');
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x00028983 File Offset: 0x00026B83
		public static bool IsWordDelimiter(char c)
		{
			return char.IsWhiteSpace(c) || char.IsSymbol(c) || char.IsPunctuation(c);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x000289A0 File Offset: 0x00026BA0
		public static bool IsWordBeginning(char? previous, char current, char? next)
		{
			bool flag = previous == null;
			bool flag2 = next == null;
			bool flag3 = char.IsLetter(current);
			bool flag4 = previous != null && char.IsLetter(previous.Value);
			bool flag5 = char.IsNumber(current);
			bool flag6 = previous != null && char.IsNumber(previous.Value);
			bool flag7 = char.IsUpper(current);
			bool flag8 = previous != null && char.IsUpper(previous.Value);
			bool flag9 = StringUtility.IsWordDelimiter(current);
			bool flag10 = previous != null && StringUtility.IsWordDelimiter(previous.Value);
			bool flag11 = next != null && char.IsLower(next.Value);
			return (!flag9 && flag) || (!flag9 && flag10) || (flag3 && flag4 && flag7 && !flag8) || (flag3 && flag4 && flag7 && flag8 && !flag2 && flag11) || (flag5 && flag4) || (flag3 && flag6 && flag7 && flag11);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x00028AAC File Offset: 0x00026CAC
		public static bool IsWordBeginning(string s, int index)
		{
			Ensure.That("index").IsGte<int>(index, 0);
			Ensure.That("index").IsLt<int>(index, s.Length);
			char? previous = (index > 0) ? new char?(s[index - 1]) : null;
			char current = s[index];
			char? next = (index < s.Length - 1) ? new char?(s[index + 1]) : null;
			return StringUtility.IsWordBeginning(previous, current, next);
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x00028B34 File Offset: 0x00026D34
		public static string SplitWords(this string s, char separator)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < s.Length; i++)
			{
				char value = s[i];
				if (i > 0 && StringUtility.IsWordBeginning(s, i))
				{
					stringBuilder.Append(separator);
				}
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00028B84 File Offset: 0x00026D84
		public static string RemoveConsecutiveCharacters(this string s, char c)
		{
			StringBuilder stringBuilder = new StringBuilder();
			char c2 = '\0';
			foreach (char c3 in s)
			{
				if (c3 != c || c3 != c2)
				{
					stringBuilder.Append(c3);
					c2 = c3;
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x00028BD4 File Offset: 0x00026DD4
		public static string ReplaceMultiple(this string s, HashSet<char> haystacks, char replacement)
		{
			Ensure.That("haystacks").IsNotNull<HashSet<char>>(haystacks);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in s)
			{
				if (haystacks.Contains(c))
				{
					stringBuilder.Append(replacement);
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00028C33 File Offset: 0x00026E33
		public static string Truncate(this string value, int maxLength, string suffix = "...")
		{
			if (value.Length > maxLength)
			{
				return value.Substring(0, maxLength) + suffix;
			}
			return value;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x00028C4E File Offset: 0x00026E4E
		public static string TrimEnd(this string source, string value)
		{
			if (!source.EndsWith(value))
			{
				return source;
			}
			return source.Remove(source.LastIndexOf(value));
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00028C68 File Offset: 0x00026E68
		public static string TrimStart(this string source, string value)
		{
			if (!source.StartsWith(value))
			{
				return source;
			}
			return source.Substring(value.Length);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00028C84 File Offset: 0x00026E84
		public static string FirstCharacterToLower(this string s)
		{
			if (string.IsNullOrEmpty(s) || char.IsLower(s, 0))
			{
				return s;
			}
			return char.ToLowerInvariant(s[0]).ToString() + s.Substring(1);
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00028CC4 File Offset: 0x00026EC4
		public static string FirstCharacterToUpper(this string s)
		{
			if (string.IsNullOrEmpty(s) || char.IsUpper(s, 0))
			{
				return s;
			}
			return char.ToUpperInvariant(s[0]).ToString() + s.Substring(1);
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00028D04 File Offset: 0x00026F04
		public static string PartBefore(this string s, char c)
		{
			Ensure.That("s").IsNotNull(s);
			int num = s.IndexOf(c);
			if (num > 0)
			{
				return s.Substring(0, num);
			}
			return s;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00028D38 File Offset: 0x00026F38
		public static string PartAfter(this string s, char c)
		{
			Ensure.That("s").IsNotNull(s);
			int num = s.IndexOf(c);
			if (num > 0)
			{
				return s.Substring(num + 1);
			}
			return s;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00028D6C File Offset: 0x00026F6C
		public static void PartsAround(this string s, char c, out string before, out string after)
		{
			Ensure.That("s").IsNotNull(s);
			int num = s.IndexOf(c);
			if (num > 0)
			{
				before = s.Substring(0, num);
				after = s.Substring(num + 1);
				return;
			}
			before = s;
			after = null;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00028DB1 File Offset: 0x00026FB1
		public static bool EndsWith(this string s, char c)
		{
			Ensure.That("s").IsNotNull(s);
			return s[s.Length - 1] == c;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00028DD4 File Offset: 0x00026FD4
		public static bool StartsWith(this string s, char c)
		{
			Ensure.That("s").IsNotNull(s);
			return s[0] == c;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00028DF0 File Offset: 0x00026FF0
		public static bool Contains(this string s, char c)
		{
			Ensure.That("s").IsNotNull(s);
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == c)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00028E2B File Offset: 0x0002702B
		public static string NullIfEmpty(this string s)
		{
			if (s == string.Empty)
			{
				return null;
			}
			return s;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00028E3D File Offset: 0x0002703D
		public static string ToBinaryString(this int value)
		{
			return Convert.ToString(value, 2).PadLeft(8, '0');
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00028E4E File Offset: 0x0002704E
		public static string ToBinaryString(this long value)
		{
			return Convert.ToString(value, 2).PadLeft(16, '0');
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00028E60 File Offset: 0x00027060
		public static string ToBinaryString(this Enum value)
		{
			return Convert.ToString(Convert.ToInt64(value), 2).PadLeft(16, '0');
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00028E78 File Offset: 0x00027078
		public static int CountIndices(this string s, char c)
		{
			int num = 0;
			foreach (char c2 in s)
			{
				if (c == c2)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00028EAB File Offset: 0x000270AB
		public static bool IsGuid(string value)
		{
			return StringUtility.guidRegex.IsMatch(value);
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00028EB8 File Offset: 0x000270B8
		public static string PathEllipsis(string s, int maxLength)
		{
			string text = "...";
			if (s.Length < maxLength)
			{
				return s;
			}
			string fileName = Path.GetFileName(s);
			string directoryName = Path.GetDirectoryName(s);
			int num = maxLength - fileName.Length - text.Length;
			if (num > 0)
			{
				return directoryName.Substring(0, num) + text + Path.DirectorySeparatorChar.ToString() + fileName;
			}
			return text + Path.DirectorySeparatorChar.ToString() + fileName;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x00028F23 File Offset: 0x00027123
		public static string ToHexString(this byte[] bytes)
		{
			return BitConverter.ToString(bytes).Replace("-", "");
		}

		// Token: 0x04000240 RID: 576
		private static readonly Regex guidRegex = new Regex("[a-fA-F0-9]{8}(\\-[a-fA-F0-9]{4}){3}\\-[a-fA-F0-9]{12}");
	}
}
