using System;
using System.Text.RegularExpressions;
using Unity.Services.Core;

namespace Unity.Services.Authentication
{
	// Token: 0x02000007 RID: 7
	public static class AuthenticationExtensions
	{
		// Token: 0x0600008E RID: 142 RVA: 0x00003DC6 File Offset: 0x00001FC6
		public static InitializationOptions SetProfile(this InitializationOptions options, string profile)
		{
			if (string.IsNullOrEmpty(profile) || !Regex.Match(profile, "^[a-zA-Z0-9_-]{1,30}$").Success)
			{
				throw AuthenticationException.Create(AuthenticationErrorCodes.ClientInvalidProfile, "Invalid profile name. The profile may only contain alphanumeric values, '-', '_', and must be no longer than 30 characters.", null);
			}
			return options.SetOption("com.unity.services.authentication.profile", profile);
		}

		// Token: 0x0400002A RID: 42
		internal const string ProfileKey = "com.unity.services.authentication.profile";

		// Token: 0x0400002B RID: 43
		private const string k_ProfileRegex = "^[a-zA-Z0-9_-]{1,30}$";
	}
}
