using System;
using System.Text;

namespace Unity.Services.Authentication
{
	// Token: 0x02000056 RID: 86
	internal class JwtDecoder : IJwtDecoder
	{
		// Token: 0x06000240 RID: 576 RVA: 0x00006904 File Offset: 0x00004B04
		public T Decode<T>(string token) where T : BaseJwt
		{
			string[] array = token.Split(JwtDecoder.k_JwtSeparator);
			if (array.Length == 3)
			{
				string input = array[1];
				return IsolatedJsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(this.Base64UrlDecode(input)), SerializerSettings.DefaultSerializerSettings);
			}
			Logger.LogError(string.Format("That is not a valid token (expected 3 parts but has {0}).", array.Length));
			return default(T);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00006964 File Offset: 0x00004B64
		private byte[] Base64UrlDecode(string input)
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

		// Token: 0x0400011F RID: 287
		private static readonly char[] k_JwtSeparator = new char[]
		{
			'.'
		};
	}
}
