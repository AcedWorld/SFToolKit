using System;
using System.Security.Cryptography;
using System.Text;

namespace Unity.Services.Authentication
{
	// Token: 0x02000052 RID: 82
	internal class CodeChallengeGenerator
	{
		// Token: 0x06000226 RID: 550 RVA: 0x00006581 File Offset: 0x00004781
		internal CodeChallengeGenerator()
		{
			this.m_CodeBuilder = new StringBuilder(125);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00006598 File Offset: 0x00004798
		public string GenerateCode()
		{
			byte[] array = new byte[125];
			using (RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider())
			{
				rngcryptoServiceProvider.GetBytes(array);
			}
			this.m_CodeBuilder.Clear();
			for (int i = 0; i < 125; i++)
			{
				this.m_CodeBuilder.Append("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[(int)array[i] % "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Length]);
			}
			return this.m_CodeBuilder.ToString();
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00006620 File Offset: 0x00004820
		public string GenerateStateString()
		{
			return Guid.NewGuid().ToString();
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00006640 File Offset: 0x00004840
		public static string S256EncodeChallenge(string code)
		{
			HashAlgorithm hashAlgorithm = SHA256.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(code);
			return BitConverter.ToString(hashAlgorithm.ComputeHash(bytes)).Replace("-", "").ToLower();
		}

		// Token: 0x04000110 RID: 272
		private const int k_CodeLength = 125;

		// Token: 0x04000111 RID: 273
		private const string k_CodeChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

		// Token: 0x04000112 RID: 274
		private readonly StringBuilder m_CodeBuilder;
	}
}
