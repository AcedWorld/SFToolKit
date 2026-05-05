using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000018 RID: 24
	internal class JwtDecoder : IJwtDecoder
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00002FCD File Offset: 0x000011CD
		internal JwtDecoder(IDateTimeWrapper dateTime)
		{
			this.m_DateTime = dateTime;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002FE8 File Offset: 0x000011E8
		public T Decode<T>(string token) where T : BaseJwt
		{
			string[] array = token.Split(JwtDecoder.k_JwtSeparator);
			if (array.Length != 3)
			{
				Debug.LogError(string.Format("That is not a valid token (expected 3 parts but has {0}).", array.Length));
				return default(T);
			}
			string input = array[0];
			string input2 = array[1];
			JwtDecoder.Base64UrlDecode(array[2]);
			string @string = Encoding.UTF8.GetString(JwtDecoder.Base64UrlDecode(input));
			string string2 = Encoding.UTF8.GetString(JwtDecoder.Base64UrlDecode(input2));
			JsonConvert.DeserializeObject<Dictionary<string, string>>(@string, this.m_JsonSerializerSettings);
			T t = JsonConvert.DeserializeObject<T>(string2, this.m_JsonSerializerSettings);
			if (this.m_DateTime.SecondsSinceUnixEpoch() >= (double)t.ExpirationTimeUnix)
			{
				Debug.LogError("Token has expired.");
				return default(T);
			}
			return t;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000030A8 File Offset: 0x000012A8
		private static byte[] Base64UrlDecode(string input)
		{
			string text = input.Replace('-', '+');
			text = text.Replace('_', '/');
			int num = input.Length % 4;
			if (num > 0)
			{
				text += new string('=', 4 - num);
			}
			return Convert.FromBase64String(text);
		}

		// Token: 0x04000049 RID: 73
		private static readonly DateTime k_UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		// Token: 0x0400004A RID: 74
		private static readonly char[] k_JwtSeparator = new char[]
		{
			'.'
		};

		// Token: 0x0400004B RID: 75
		private readonly JsonSerializerSettings m_JsonSerializerSettings = new JsonSerializerSettings();

		// Token: 0x0400004C RID: 76
		private readonly IDateTimeWrapper m_DateTime;
	}
}
