using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000040 RID: 64
	internal static class HttpUtility
	{
		// Token: 0x06000462 RID: 1122 RVA: 0x00013460 File Offset: 0x00011660
		private static Dictionary<string, char> getEntities()
		{
			object sync = HttpUtility._sync;
			Dictionary<string, char> entities;
			lock (sync)
			{
				if (HttpUtility._entities == null)
				{
					HttpUtility.initEntities();
				}
				entities = HttpUtility._entities;
			}
			return entities;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x000134AC File Offset: 0x000116AC
		private static int getNumber(char c)
		{
			if (c >= '0' && c <= '9')
			{
				return (int)(c - '0');
			}
			if (c >= 'A' && c <= 'F')
			{
				return (int)(c - 'A' + '\n');
			}
			if (c < 'a' || c > 'f')
			{
				return -1;
			}
			return (int)(c - 'a' + '\n');
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x000134E4 File Offset: 0x000116E4
		private static int getNumber(byte[] bytes, int offset, int count)
		{
			int num = 0;
			int num2 = offset + count - 1;
			for (int i = offset; i <= num2; i++)
			{
				int number = HttpUtility.getNumber((char)bytes[i]);
				if (number == -1)
				{
					return -1;
				}
				num = (num << 4) + number;
			}
			return num;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0001351C File Offset: 0x0001171C
		private static int getNumber(string s, int offset, int count)
		{
			int num = 0;
			int num2 = offset + count - 1;
			for (int i = offset; i <= num2; i++)
			{
				int number = HttpUtility.getNumber(s[i]);
				if (number == -1)
				{
					return -1;
				}
				num = (num << 4) + number;
			}
			return num;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00013558 File Offset: 0x00011758
		private static string htmlDecode(string s)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			StringBuilder stringBuilder2 = new StringBuilder();
			int num2 = 0;
			foreach (char c in s)
			{
				if (num == 0)
				{
					if (c == '&')
					{
						stringBuilder2.Append('&');
						num = 1;
					}
					else
					{
						stringBuilder.Append(c);
					}
				}
				else if (c == '&')
				{
					stringBuilder.Append(stringBuilder2.ToString());
					stringBuilder2.Length = 0;
					stringBuilder2.Append('&');
					num = 1;
				}
				else
				{
					stringBuilder2.Append(c);
					if (num == 1)
					{
						if (c == ';')
						{
							stringBuilder.Append(stringBuilder2.ToString());
							stringBuilder2.Length = 0;
							num = 0;
						}
						else
						{
							num2 = 0;
							num = ((c == '#') ? 3 : 2);
						}
					}
					else if (num == 2)
					{
						if (c == ';')
						{
							string text = stringBuilder2.ToString();
							string key = text.Substring(1, text.Length - 2);
							Dictionary<string, char> entities = HttpUtility.getEntities();
							if (entities.ContainsKey(key))
							{
								stringBuilder.Append(entities[key]);
							}
							else
							{
								stringBuilder.Append(text);
							}
							stringBuilder2.Length = 0;
							num = 0;
						}
					}
					else if (num == 3)
					{
						if (c == ';')
						{
							if (stringBuilder2.Length > 3 && num2 < 65536)
							{
								stringBuilder.Append((char)num2);
							}
							else
							{
								stringBuilder.Append(stringBuilder2.ToString());
							}
							stringBuilder2.Length = 0;
							num = 0;
						}
						else if (c == 'x')
						{
							num = ((stringBuilder2.Length == 3) ? 4 : 2);
						}
						else if (!HttpUtility.isNumeric(c))
						{
							num = 2;
						}
						else
						{
							num2 = num2 * 10 + (int)(c - '0');
						}
					}
					else if (num == 4)
					{
						if (c == ';')
						{
							if (stringBuilder2.Length > 4 && num2 < 65536)
							{
								stringBuilder.Append((char)num2);
							}
							else
							{
								stringBuilder.Append(stringBuilder2.ToString());
							}
							stringBuilder2.Length = 0;
							num = 0;
						}
						else
						{
							int number = HttpUtility.getNumber(c);
							if (number == -1)
							{
								num = 2;
							}
							else
							{
								num2 = (num2 << 4) + number;
							}
						}
					}
				}
			}
			if (stringBuilder2.Length > 0)
			{
				stringBuilder.Append(stringBuilder2.ToString());
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00013778 File Offset: 0x00011978
		private static string htmlEncode(string s, bool minimal)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in s)
			{
				stringBuilder.Append((c == '"') ? "&quot;" : ((c == '&') ? "&amp;" : ((c == '<') ? "&lt;" : ((c == '>') ? "&gt;" : ((!minimal && c > '\u009f') ? string.Format("&#{0};", (int)c) : c.ToString())))));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00013808 File Offset: 0x00011A08
		private static void initEntities()
		{
			HttpUtility._entities = new Dictionary<string, char>();
			HttpUtility._entities.Add("nbsp", '\u00a0');
			HttpUtility._entities.Add("iexcl", '¡');
			HttpUtility._entities.Add("cent", '¢');
			HttpUtility._entities.Add("pound", '£');
			HttpUtility._entities.Add("curren", '¤');
			HttpUtility._entities.Add("yen", '¥');
			HttpUtility._entities.Add("brvbar", '¦');
			HttpUtility._entities.Add("sect", '§');
			HttpUtility._entities.Add("uml", '¨');
			HttpUtility._entities.Add("copy", '©');
			HttpUtility._entities.Add("ordf", 'ª');
			HttpUtility._entities.Add("laquo", '«');
			HttpUtility._entities.Add("not", '¬');
			HttpUtility._entities.Add("shy", '­');
			HttpUtility._entities.Add("reg", '®');
			HttpUtility._entities.Add("macr", '¯');
			HttpUtility._entities.Add("deg", '°');
			HttpUtility._entities.Add("plusmn", '±');
			HttpUtility._entities.Add("sup2", '²');
			HttpUtility._entities.Add("sup3", '³');
			HttpUtility._entities.Add("acute", '´');
			HttpUtility._entities.Add("micro", 'µ');
			HttpUtility._entities.Add("para", '¶');
			HttpUtility._entities.Add("middot", '·');
			HttpUtility._entities.Add("cedil", '¸');
			HttpUtility._entities.Add("sup1", '¹');
			HttpUtility._entities.Add("ordm", 'º');
			HttpUtility._entities.Add("raquo", '»');
			HttpUtility._entities.Add("frac14", '¼');
			HttpUtility._entities.Add("frac12", '½');
			HttpUtility._entities.Add("frac34", '¾');
			HttpUtility._entities.Add("iquest", '¿');
			HttpUtility._entities.Add("Agrave", 'À');
			HttpUtility._entities.Add("Aacute", 'Á');
			HttpUtility._entities.Add("Acirc", 'Â');
			HttpUtility._entities.Add("Atilde", 'Ã');
			HttpUtility._entities.Add("Auml", 'Ä');
			HttpUtility._entities.Add("Aring", 'Å');
			HttpUtility._entities.Add("AElig", 'Æ');
			HttpUtility._entities.Add("Ccedil", 'Ç');
			HttpUtility._entities.Add("Egrave", 'È');
			HttpUtility._entities.Add("Eacute", 'É');
			HttpUtility._entities.Add("Ecirc", 'Ê');
			HttpUtility._entities.Add("Euml", 'Ë');
			HttpUtility._entities.Add("Igrave", 'Ì');
			HttpUtility._entities.Add("Iacute", 'Í');
			HttpUtility._entities.Add("Icirc", 'Î');
			HttpUtility._entities.Add("Iuml", 'Ï');
			HttpUtility._entities.Add("ETH", 'Ð');
			HttpUtility._entities.Add("Ntilde", 'Ñ');
			HttpUtility._entities.Add("Ograve", 'Ò');
			HttpUtility._entities.Add("Oacute", 'Ó');
			HttpUtility._entities.Add("Ocirc", 'Ô');
			HttpUtility._entities.Add("Otilde", 'Õ');
			HttpUtility._entities.Add("Ouml", 'Ö');
			HttpUtility._entities.Add("times", '×');
			HttpUtility._entities.Add("Oslash", 'Ø');
			HttpUtility._entities.Add("Ugrave", 'Ù');
			HttpUtility._entities.Add("Uacute", 'Ú');
			HttpUtility._entities.Add("Ucirc", 'Û');
			HttpUtility._entities.Add("Uuml", 'Ü');
			HttpUtility._entities.Add("Yacute", 'Ý');
			HttpUtility._entities.Add("THORN", 'Þ');
			HttpUtility._entities.Add("szlig", 'ß');
			HttpUtility._entities.Add("agrave", 'à');
			HttpUtility._entities.Add("aacute", 'á');
			HttpUtility._entities.Add("acirc", 'â');
			HttpUtility._entities.Add("atilde", 'ã');
			HttpUtility._entities.Add("auml", 'ä');
			HttpUtility._entities.Add("aring", 'å');
			HttpUtility._entities.Add("aelig", 'æ');
			HttpUtility._entities.Add("ccedil", 'ç');
			HttpUtility._entities.Add("egrave", 'è');
			HttpUtility._entities.Add("eacute", 'é');
			HttpUtility._entities.Add("ecirc", 'ê');
			HttpUtility._entities.Add("euml", 'ë');
			HttpUtility._entities.Add("igrave", 'ì');
			HttpUtility._entities.Add("iacute", 'í');
			HttpUtility._entities.Add("icirc", 'î');
			HttpUtility._entities.Add("iuml", 'ï');
			HttpUtility._entities.Add("eth", 'ð');
			HttpUtility._entities.Add("ntilde", 'ñ');
			HttpUtility._entities.Add("ograve", 'ò');
			HttpUtility._entities.Add("oacute", 'ó');
			HttpUtility._entities.Add("ocirc", 'ô');
			HttpUtility._entities.Add("otilde", 'õ');
			HttpUtility._entities.Add("ouml", 'ö');
			HttpUtility._entities.Add("divide", '÷');
			HttpUtility._entities.Add("oslash", 'ø');
			HttpUtility._entities.Add("ugrave", 'ù');
			HttpUtility._entities.Add("uacute", 'ú');
			HttpUtility._entities.Add("ucirc", 'û');
			HttpUtility._entities.Add("uuml", 'ü');
			HttpUtility._entities.Add("yacute", 'ý');
			HttpUtility._entities.Add("thorn", 'þ');
			HttpUtility._entities.Add("yuml", 'ÿ');
			HttpUtility._entities.Add("fnof", 'ƒ');
			HttpUtility._entities.Add("Alpha", 'Α');
			HttpUtility._entities.Add("Beta", 'Β');
			HttpUtility._entities.Add("Gamma", 'Γ');
			HttpUtility._entities.Add("Delta", 'Δ');
			HttpUtility._entities.Add("Epsilon", 'Ε');
			HttpUtility._entities.Add("Zeta", 'Ζ');
			HttpUtility._entities.Add("Eta", 'Η');
			HttpUtility._entities.Add("Theta", 'Θ');
			HttpUtility._entities.Add("Iota", 'Ι');
			HttpUtility._entities.Add("Kappa", 'Κ');
			HttpUtility._entities.Add("Lambda", 'Λ');
			HttpUtility._entities.Add("Mu", 'Μ');
			HttpUtility._entities.Add("Nu", 'Ν');
			HttpUtility._entities.Add("Xi", 'Ξ');
			HttpUtility._entities.Add("Omicron", 'Ο');
			HttpUtility._entities.Add("Pi", 'Π');
			HttpUtility._entities.Add("Rho", 'Ρ');
			HttpUtility._entities.Add("Sigma", 'Σ');
			HttpUtility._entities.Add("Tau", 'Τ');
			HttpUtility._entities.Add("Upsilon", 'Υ');
			HttpUtility._entities.Add("Phi", 'Φ');
			HttpUtility._entities.Add("Chi", 'Χ');
			HttpUtility._entities.Add("Psi", 'Ψ');
			HttpUtility._entities.Add("Omega", 'Ω');
			HttpUtility._entities.Add("alpha", 'α');
			HttpUtility._entities.Add("beta", 'β');
			HttpUtility._entities.Add("gamma", 'γ');
			HttpUtility._entities.Add("delta", 'δ');
			HttpUtility._entities.Add("epsilon", 'ε');
			HttpUtility._entities.Add("zeta", 'ζ');
			HttpUtility._entities.Add("eta", 'η');
			HttpUtility._entities.Add("theta", 'θ');
			HttpUtility._entities.Add("iota", 'ι');
			HttpUtility._entities.Add("kappa", 'κ');
			HttpUtility._entities.Add("lambda", 'λ');
			HttpUtility._entities.Add("mu", 'μ');
			HttpUtility._entities.Add("nu", 'ν');
			HttpUtility._entities.Add("xi", 'ξ');
			HttpUtility._entities.Add("omicron", 'ο');
			HttpUtility._entities.Add("pi", 'π');
			HttpUtility._entities.Add("rho", 'ρ');
			HttpUtility._entities.Add("sigmaf", 'ς');
			HttpUtility._entities.Add("sigma", 'σ');
			HttpUtility._entities.Add("tau", 'τ');
			HttpUtility._entities.Add("upsilon", 'υ');
			HttpUtility._entities.Add("phi", 'φ');
			HttpUtility._entities.Add("chi", 'χ');
			HttpUtility._entities.Add("psi", 'ψ');
			HttpUtility._entities.Add("omega", 'ω');
			HttpUtility._entities.Add("thetasym", 'ϑ');
			HttpUtility._entities.Add("upsih", 'ϒ');
			HttpUtility._entities.Add("piv", 'ϖ');
			HttpUtility._entities.Add("bull", '•');
			HttpUtility._entities.Add("hellip", '…');
			HttpUtility._entities.Add("prime", '′');
			HttpUtility._entities.Add("Prime", '″');
			HttpUtility._entities.Add("oline", '‾');
			HttpUtility._entities.Add("frasl", '⁄');
			HttpUtility._entities.Add("weierp", '℘');
			HttpUtility._entities.Add("image", 'ℑ');
			HttpUtility._entities.Add("real", 'ℜ');
			HttpUtility._entities.Add("trade", '™');
			HttpUtility._entities.Add("alefsym", 'ℵ');
			HttpUtility._entities.Add("larr", '←');
			HttpUtility._entities.Add("uarr", '↑');
			HttpUtility._entities.Add("rarr", '→');
			HttpUtility._entities.Add("darr", '↓');
			HttpUtility._entities.Add("harr", '↔');
			HttpUtility._entities.Add("crarr", '↵');
			HttpUtility._entities.Add("lArr", '⇐');
			HttpUtility._entities.Add("uArr", '⇑');
			HttpUtility._entities.Add("rArr", '⇒');
			HttpUtility._entities.Add("dArr", '⇓');
			HttpUtility._entities.Add("hArr", '⇔');
			HttpUtility._entities.Add("forall", '∀');
			HttpUtility._entities.Add("part", '∂');
			HttpUtility._entities.Add("exist", '∃');
			HttpUtility._entities.Add("empty", '∅');
			HttpUtility._entities.Add("nabla", '∇');
			HttpUtility._entities.Add("isin", '∈');
			HttpUtility._entities.Add("notin", '∉');
			HttpUtility._entities.Add("ni", '∋');
			HttpUtility._entities.Add("prod", '∏');
			HttpUtility._entities.Add("sum", '∑');
			HttpUtility._entities.Add("minus", '−');
			HttpUtility._entities.Add("lowast", '∗');
			HttpUtility._entities.Add("radic", '√');
			HttpUtility._entities.Add("prop", '∝');
			HttpUtility._entities.Add("infin", '∞');
			HttpUtility._entities.Add("ang", '∠');
			HttpUtility._entities.Add("and", '∧');
			HttpUtility._entities.Add("or", '∨');
			HttpUtility._entities.Add("cap", '∩');
			HttpUtility._entities.Add("cup", '∪');
			HttpUtility._entities.Add("int", '∫');
			HttpUtility._entities.Add("there4", '∴');
			HttpUtility._entities.Add("sim", '∼');
			HttpUtility._entities.Add("cong", '≅');
			HttpUtility._entities.Add("asymp", '≈');
			HttpUtility._entities.Add("ne", '≠');
			HttpUtility._entities.Add("equiv", '≡');
			HttpUtility._entities.Add("le", '≤');
			HttpUtility._entities.Add("ge", '≥');
			HttpUtility._entities.Add("sub", '⊂');
			HttpUtility._entities.Add("sup", '⊃');
			HttpUtility._entities.Add("nsub", '⊄');
			HttpUtility._entities.Add("sube", '⊆');
			HttpUtility._entities.Add("supe", '⊇');
			HttpUtility._entities.Add("oplus", '⊕');
			HttpUtility._entities.Add("otimes", '⊗');
			HttpUtility._entities.Add("perp", '⊥');
			HttpUtility._entities.Add("sdot", '⋅');
			HttpUtility._entities.Add("lceil", '⌈');
			HttpUtility._entities.Add("rceil", '⌉');
			HttpUtility._entities.Add("lfloor", '⌊');
			HttpUtility._entities.Add("rfloor", '⌋');
			HttpUtility._entities.Add("lang", '〈');
			HttpUtility._entities.Add("rang", '〉');
			HttpUtility._entities.Add("loz", '◊');
			HttpUtility._entities.Add("spades", '♠');
			HttpUtility._entities.Add("clubs", '♣');
			HttpUtility._entities.Add("hearts", '♥');
			HttpUtility._entities.Add("diams", '♦');
			HttpUtility._entities.Add("quot", '"');
			HttpUtility._entities.Add("amp", '&');
			HttpUtility._entities.Add("lt", '<');
			HttpUtility._entities.Add("gt", '>');
			HttpUtility._entities.Add("OElig", 'Œ');
			HttpUtility._entities.Add("oelig", 'œ');
			HttpUtility._entities.Add("Scaron", 'Š');
			HttpUtility._entities.Add("scaron", 'š');
			HttpUtility._entities.Add("Yuml", 'Ÿ');
			HttpUtility._entities.Add("circ", 'ˆ');
			HttpUtility._entities.Add("tilde", '˜');
			HttpUtility._entities.Add("ensp", '\u2002');
			HttpUtility._entities.Add("emsp", '\u2003');
			HttpUtility._entities.Add("thinsp", '\u2009');
			HttpUtility._entities.Add("zwnj", '‌');
			HttpUtility._entities.Add("zwj", '‍');
			HttpUtility._entities.Add("lrm", '‎');
			HttpUtility._entities.Add("rlm", '‏');
			HttpUtility._entities.Add("ndash", '–');
			HttpUtility._entities.Add("mdash", '—');
			HttpUtility._entities.Add("lsquo", '‘');
			HttpUtility._entities.Add("rsquo", '’');
			HttpUtility._entities.Add("sbquo", '‚');
			HttpUtility._entities.Add("ldquo", '“');
			HttpUtility._entities.Add("rdquo", '”');
			HttpUtility._entities.Add("bdquo", '„');
			HttpUtility._entities.Add("dagger", '†');
			HttpUtility._entities.Add("Dagger", '‡');
			HttpUtility._entities.Add("permil", '‰');
			HttpUtility._entities.Add("lsaquo", '‹');
			HttpUtility._entities.Add("rsaquo", '›');
			HttpUtility._entities.Add("euro", '€');
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00014BC3 File Offset: 0x00012DC3
		private static bool isAlphabet(char c)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00014BE0 File Offset: 0x00012DE0
		private static bool isNumeric(char c)
		{
			return c >= '0' && c <= '9';
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00014BF1 File Offset: 0x00012DF1
		private static bool isUnreserved(char c)
		{
			return c == '*' || c == '-' || c == '.' || c == '_';
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00014C09 File Offset: 0x00012E09
		private static bool isUnreservedInRfc2396(char c)
		{
			return c == '!' || c == '\'' || c == '(' || c == ')' || c == '*' || c == '-' || c == '.' || c == '_' || c == '~';
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00014C3A File Offset: 0x00012E3A
		private static bool isUnreservedInRfc3986(char c)
		{
			return c == '-' || c == '.' || c == '_' || c == '~';
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00014C54 File Offset: 0x00012E54
		private static byte[] urlDecodeToBytes(byte[] bytes, int offset, int count)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int num = offset + count - 1;
				for (int i = offset; i <= num; i++)
				{
					byte b = bytes[i];
					char c = (char)b;
					if (c == '%')
					{
						if (i > num - 2)
						{
							break;
						}
						int number = HttpUtility.getNumber(bytes, i + 1, 2);
						if (number == -1)
						{
							break;
						}
						memoryStream.WriteByte((byte)number);
						i += 2;
					}
					else if (c == '+')
					{
						memoryStream.WriteByte(32);
					}
					else
					{
						memoryStream.WriteByte(b);
					}
				}
				memoryStream.Close();
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00014CF0 File Offset: 0x00012EF0
		private static void urlEncode(byte b, Stream output)
		{
			if (b > 31 && b < 127)
			{
				if (b == 32)
				{
					output.WriteByte(43);
					return;
				}
				if (HttpUtility.isNumeric((char)b))
				{
					output.WriteByte(b);
					return;
				}
				if (HttpUtility.isAlphabet((char)b))
				{
					output.WriteByte(b);
					return;
				}
				if (HttpUtility.isUnreserved((char)b))
				{
					output.WriteByte(b);
					return;
				}
			}
			byte[] buffer = new byte[]
			{
				37,
				(byte)HttpUtility._hexChars[b >> 4],
				(byte)HttpUtility._hexChars[(int)(b & 15)]
			};
			output.Write(buffer, 0, 3);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00014D7C File Offset: 0x00012F7C
		private static byte[] urlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int num = offset + count - 1;
				for (int i = offset; i <= num; i++)
				{
					HttpUtility.urlEncode(bytes[i], memoryStream);
				}
				memoryStream.Close();
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00014DD4 File Offset: 0x00012FD4
		internal static Uri CreateRequestUrl(string requestUri, string host, bool websocketRequest, bool secure)
		{
			if (requestUri == null || requestUri.Length == 0)
			{
				return null;
			}
			if (host == null || host.Length == 0)
			{
				return null;
			}
			string text = null;
			string arg = null;
			if (requestUri.IndexOf('/') == 0)
			{
				arg = requestUri;
			}
			else if (requestUri.MaybeUri())
			{
				Uri uri;
				if (!Uri.TryCreate(requestUri, UriKind.Absolute, out uri))
				{
					return null;
				}
				text = uri.Scheme;
				if (!(websocketRequest ? (text == "ws" || text == "wss") : (text == "http" || text == "https")))
				{
					return null;
				}
				host = uri.Authority;
				arg = uri.PathAndQuery;
			}
			else if (!(requestUri == "*"))
			{
				host = requestUri;
			}
			if (text == null)
			{
				text = (websocketRequest ? (secure ? "wss" : "ws") : (secure ? "https" : "http"));
			}
			if (host.IndexOf(':') == -1)
			{
				host = string.Format("{0}:{1}", host, secure ? 443 : 80);
			}
			Uri result;
			if (!Uri.TryCreate(string.Format("{0}://{1}{2}", text, host, arg), UriKind.Absolute, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00014EF4 File Offset: 0x000130F4
		internal static IPrincipal CreateUser(string response, AuthenticationSchemes scheme, string realm, string method, Func<IIdentity, NetworkCredential> credentialsFinder)
		{
			if (response == null || response.Length == 0)
			{
				return null;
			}
			if (scheme == AuthenticationSchemes.Digest)
			{
				if (realm == null || realm.Length == 0)
				{
					return null;
				}
				if (method == null || method.Length == 0)
				{
					return null;
				}
			}
			else if (scheme != AuthenticationSchemes.Basic)
			{
				return null;
			}
			if (credentialsFinder == null)
			{
				return null;
			}
			StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
			if (response.IndexOf(scheme.ToString(), comparisonType) != 0)
			{
				return null;
			}
			AuthenticationResponse authenticationResponse = AuthenticationResponse.Parse(response);
			if (authenticationResponse == null)
			{
				return null;
			}
			IIdentity identity = authenticationResponse.ToIdentity();
			if (identity == null)
			{
				return null;
			}
			NetworkCredential networkCredential = null;
			try
			{
				networkCredential = credentialsFinder(identity);
			}
			catch
			{
			}
			if (networkCredential == null)
			{
				return null;
			}
			if (scheme == AuthenticationSchemes.Basic)
			{
				if (!(((HttpBasicIdentity)identity).Password == networkCredential.Password))
				{
					return null;
				}
				return new GenericPrincipal(identity, networkCredential.Roles);
			}
			else
			{
				if (!((HttpDigestIdentity)identity).IsValid(networkCredential.Password, realm, method, null))
				{
					return null;
				}
				return new GenericPrincipal(identity, networkCredential.Roles);
			}
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00014FE0 File Offset: 0x000131E0
		internal static Encoding GetEncoding(string contentType)
		{
			string value = "charset=";
			StringComparison comparisonType = StringComparison.OrdinalIgnoreCase;
			foreach (string text in contentType.SplitHeaderValue(new char[]
			{
				';'
			}))
			{
				string text2 = text.Trim();
				if (text2.StartsWith(value, comparisonType))
				{
					string value2 = text2.GetValue('=', true);
					if (value2 == null || value2.Length == 0)
					{
						return null;
					}
					return Encoding.GetEncoding(value2);
				}
			}
			return null;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00015074 File Offset: 0x00013274
		internal static bool TryGetEncoding(string contentType, out Encoding result)
		{
			result = null;
			try
			{
				result = HttpUtility.GetEncoding(contentType);
			}
			catch
			{
				return false;
			}
			return result != null;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x000150AC File Offset: 0x000132AC
		public static string HtmlAttributeEncode(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length <= 0)
			{
				return s;
			}
			return HttpUtility.htmlEncode(s, true);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x000150CE File Offset: 0x000132CE
		public static void HtmlAttributeEncode(string s, TextWriter output)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (s.Length == 0)
			{
				return;
			}
			output.Write(HttpUtility.htmlEncode(s, true));
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00015102 File Offset: 0x00013302
		public static string HtmlDecode(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length <= 0)
			{
				return s;
			}
			return HttpUtility.htmlDecode(s);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00015123 File Offset: 0x00013323
		public static void HtmlDecode(string s, TextWriter output)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (s.Length == 0)
			{
				return;
			}
			output.Write(HttpUtility.htmlDecode(s));
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00015156 File Offset: 0x00013356
		public static string HtmlEncode(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length <= 0)
			{
				return s;
			}
			return HttpUtility.htmlEncode(s, false);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00015178 File Offset: 0x00013378
		public static void HtmlEncode(string s, TextWriter output)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			if (s.Length == 0)
			{
				return;
			}
			output.Write(HttpUtility.htmlEncode(s, false));
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x000151AC File Offset: 0x000133AC
		public static string UrlDecode(string s)
		{
			return HttpUtility.UrlDecode(s, Encoding.UTF8);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x000151BC File Offset: 0x000133BC
		public static string UrlDecode(byte[] bytes, Encoding encoding)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num <= 0)
			{
				return string.Empty;
			}
			return (encoding ?? Encoding.UTF8).GetString(HttpUtility.urlDecodeToBytes(bytes, 0, num));
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x000151FC File Offset: 0x000133FC
		public static string UrlDecode(string s, Encoding encoding)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length == 0)
			{
				return s;
			}
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			return (encoding ?? Encoding.UTF8).GetString(HttpUtility.urlDecodeToBytes(bytes, 0, bytes.Length));
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00015248 File Offset: 0x00013448
		public static string UrlDecode(byte[] bytes, int offset, int count, Encoding encoding)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num == 0)
			{
				if (offset != 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count != 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				return string.Empty;
			}
			else
			{
				if (offset < 0 || offset >= num)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count < 0 || count > num - offset)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				if (count <= 0)
				{
					return string.Empty;
				}
				return (encoding ?? Encoding.UTF8).GetString(HttpUtility.urlDecodeToBytes(bytes, offset, count));
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x000152D8 File Offset: 0x000134D8
		public static byte[] UrlDecodeToBytes(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num <= 0)
			{
				return bytes;
			}
			return HttpUtility.urlDecodeToBytes(bytes, 0, num);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00015308 File Offset: 0x00013508
		public static byte[] UrlDecodeToBytes(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length == 0)
			{
				return new byte[0];
			}
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			return HttpUtility.urlDecodeToBytes(bytes, 0, bytes.Length);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00015348 File Offset: 0x00013548
		public static byte[] UrlDecodeToBytes(byte[] bytes, int offset, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num == 0)
			{
				if (offset != 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count != 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				return bytes;
			}
			else
			{
				if (offset < 0 || offset >= num)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count < 0 || count > num - offset)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				if (count <= 0)
				{
					return new byte[0];
				}
				return HttpUtility.urlDecodeToBytes(bytes, offset, count);
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000153C4 File Offset: 0x000135C4
		public static string UrlEncode(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num <= 0)
			{
				return string.Empty;
			}
			return Encoding.ASCII.GetString(HttpUtility.urlEncodeToBytes(bytes, 0, num));
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x000153FF File Offset: 0x000135FF
		public static string UrlEncode(string s)
		{
			return HttpUtility.UrlEncode(s, Encoding.UTF8);
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0001540C File Offset: 0x0001360C
		public static string UrlEncode(string s, Encoding encoding)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			int length = s.Length;
			if (length == 0)
			{
				return s;
			}
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			byte[] bytes = new byte[encoding.GetMaxByteCount(length)];
			int bytes2 = encoding.GetBytes(s, 0, length, bytes, 0);
			return Encoding.ASCII.GetString(HttpUtility.urlEncodeToBytes(bytes, 0, bytes2));
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00015468 File Offset: 0x00013668
		public static string UrlEncode(byte[] bytes, int offset, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num == 0)
			{
				if (offset != 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count != 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				return string.Empty;
			}
			else
			{
				if (offset < 0 || offset >= num)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count < 0 || count > num - offset)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				if (count <= 0)
				{
					return string.Empty;
				}
				return Encoding.ASCII.GetString(HttpUtility.urlEncodeToBytes(bytes, offset, count));
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x000154F0 File Offset: 0x000136F0
		public static byte[] UrlEncodeToBytes(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num <= 0)
			{
				return bytes;
			}
			return HttpUtility.urlEncodeToBytes(bytes, 0, num);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0001551D File Offset: 0x0001371D
		public static byte[] UrlEncodeToBytes(string s)
		{
			return HttpUtility.UrlEncodeToBytes(s, Encoding.UTF8);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0001552C File Offset: 0x0001372C
		public static byte[] UrlEncodeToBytes(string s, Encoding encoding)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (s.Length == 0)
			{
				return new byte[0];
			}
			byte[] bytes = (encoding ?? Encoding.UTF8).GetBytes(s);
			return HttpUtility.urlEncodeToBytes(bytes, 0, bytes.Length);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00015574 File Offset: 0x00013774
		public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num == 0)
			{
				if (offset != 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count != 0)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				return bytes;
			}
			else
			{
				if (offset < 0 || offset >= num)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (count < 0 || count > num - offset)
				{
					throw new ArgumentOutOfRangeException("count");
				}
				if (count <= 0)
				{
					return new byte[0];
				}
				return HttpUtility.urlEncodeToBytes(bytes, offset, count);
			}
		}

		// Token: 0x04000228 RID: 552
		private static Dictionary<string, char> _entities;

		// Token: 0x04000229 RID: 553
		private static char[] _hexChars = "0123456789ABCDEF".ToCharArray();

		// Token: 0x0400022A RID: 554
		private static object _sync = new object();
	}
}
