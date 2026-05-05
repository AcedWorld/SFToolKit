using System;
using System.Security.Cryptography;
using System.Text;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000014 RID: 20
	internal class CodeChallengeGenerator
	{
		// Token: 0x06000068 RID: 104 RVA: 0x00002E62 File Offset: 0x00001062
		internal CodeChallengeGenerator()
		{
			this.m_CodeBuilder = new StringBuilder(128);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002E7C File Offset: 0x0000107C
		public string GenerateCode()
		{
			byte[] array = new byte[128];
			using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
			{
				rngcryptoServiceProvider.GetBytes(array);
			}
			this.m_CodeBuilder.Clear();
			for (int i = 0; i < 128; i++)
			{
				this.m_CodeBuilder.Append("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[(int)array[i] % "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Length]);
			}
			return this.m_CodeBuilder.ToString();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002F08 File Offset: 0x00001108
		public string GenerateStateString()
		{
			return Guid.NewGuid().ToString();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002F28 File Offset: 0x00001128
		public static string S256EncodeChallenge(string code)
		{
			HashAlgorithm hashAlgorithm = SHA256.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(code);
			return CodeChallengeGenerator.UrlSafeBase64Encode(hashAlgorithm.ComputeHash(bytes));
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002F51 File Offset: 0x00001151
		private static string UrlSafeBase64Encode(byte[] input)
		{
			return Convert.ToBase64String(input).Replace('+', '-').Replace('/', '_').Replace("=", "");
		}

		// Token: 0x04000045 RID: 69
		private const int k_CodeLength = 128;

		// Token: 0x04000046 RID: 70
		private const string k_CodeChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

		// Token: 0x04000047 RID: 71
		private readonly StringBuilder m_CodeBuilder;
	}
}
