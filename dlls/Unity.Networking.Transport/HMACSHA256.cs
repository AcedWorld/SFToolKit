using System;

namespace Unity.Networking.Transport
{
	// Token: 0x02000015 RID: 21
	internal static class HMACSHA256
	{
		// Token: 0x0600009E RID: 158 RVA: 0x000044F0 File Offset: 0x000026F0
		public unsafe static void ComputeHash(byte* keyValue, int keyArrayLength, byte* messageBytes, int messageLength, byte* result)
		{
			byte* ptr = stackalloc byte[(UIntPtr)32];
			SHA256.SHA256State sha256State = SHA256.SHA256State.Create();
			if (keyArrayLength > 64)
			{
				sha256State.Update(keyValue, keyArrayLength);
				sha256State.Final(ptr);
				keyValue = ptr;
				keyArrayLength = 32;
			}
			byte* ptr2 = stackalloc byte[(UIntPtr)64];
			for (int i = 0; i < keyArrayLength; i++)
			{
				ptr2[i] = (54 ^ keyValue[i]);
			}
			for (int j = keyArrayLength; j < 64; j++)
			{
				ptr2[j] = 54;
			}
			sha256State = SHA256.SHA256State.Create();
			sha256State.Update(ptr2, 64);
			sha256State.Update(messageBytes, messageLength);
			sha256State.Final(result);
			for (int k = 0; k < keyArrayLength; k++)
			{
				ptr2[k] = (92 ^ keyValue[k]);
			}
			for (int l = keyArrayLength; l < 64; l++)
			{
				ptr2[l] = 92;
			}
			sha256State = SHA256.SHA256State.Create();
			sha256State.Update(ptr2, 64);
			sha256State.Update(result, 32);
			sha256State.Final(result);
		}
	}
}
