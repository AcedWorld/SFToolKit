using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000010 RID: 16
	internal class UnityPlayerAccountSettings : ScriptableObject
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002A9D File Offset: 0x00000C9D
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002AA5 File Offset: 0x00000CA5
		public UnityPlayerAccountSettings.SupportedScopesEnum ScopeFlags
		{
			get
			{
				return (UnityPlayerAccountSettings.SupportedScopesEnum)this.scopeMask;
			}
			set
			{
				this.scopeMask = (int)value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002AB0 File Offset: 0x00000CB0
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002ADB File Offset: 0x00000CDB
		public string ClientId
		{
			get
			{
				string text = this.clientId;
				string text2 = (text != null) ? text.Trim() : null;
				if (!string.IsNullOrEmpty(text2))
				{
					return text2;
				}
				return null;
			}
			set
			{
				this.clientId = value.Trim();
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002AEC File Offset: 0x00000CEC
		public string Scope
		{
			get
			{
				string text = "";
				UnityPlayerAccountSettings.SupportedScopesEnum scopeFlags = this.ScopeFlags;
				foreach (KeyValuePair<UnityPlayerAccountSettings.SupportedScopesEnum, string> keyValuePair in UnityPlayerAccountSettings.k_SupportedScopesDictionary)
				{
					if (scopeFlags.HasFlag(keyValuePair.Key))
					{
						text = text + keyValuePair.Value + ";";
					}
				}
				return text.TrimEnd(';');
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002B78 File Offset: 0x00000D78
		public bool UseCustomUri
		{
			get
			{
				return this.useCustomDeepLinkUri;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002B80 File Offset: 0x00000D80
		public string DeepLinkUriScheme
		{
			get
			{
				if (!this.useCustomDeepLinkUri)
				{
					return "unitydl";
				}
				return this.customScheme;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002B96 File Offset: 0x00000D96
		public string DeepLinkUriHostPrefix
		{
			get
			{
				if (!this.useCustomDeepLinkUri)
				{
					return "com.unityplayeraccounts.";
				}
				return this.customHost;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002BAC File Offset: 0x00000DAC
		public static UnityPlayerAccountSettings Load()
		{
			return Resources.Load<UnityPlayerAccountSettings>("UnityPlayerAccountSettings");
		}

		// Token: 0x0400003A RID: 58
		private const string k_DeepLinkUriScheme = "unitydl";

		// Token: 0x0400003B RID: 59
		private const string k_DeepLinkUriHostPrefix = "com.unityplayeraccounts.";

		// Token: 0x0400003C RID: 60
		[SerializeField]
		[HideInInspector]
		[Tooltip("Unity Player Account Client ID.")]
		internal string clientId;

		// Token: 0x0400003D RID: 61
		[HideInInspector]
		[SerializeField]
		internal int scopeMask = (1 << Enum.GetNames(typeof(UnityPlayerAccountSettings.SupportedScopesEnum)).Length) - 1;

		// Token: 0x0400003E RID: 62
		[HideInInspector]
		[SerializeField]
		[Tooltip("Override the default redirect uri")]
		internal bool useCustomDeepLinkUri;

		// Token: 0x0400003F RID: 63
		[HideInInspector]
		[SerializeField]
		[Tooltip("Custom Deep Link URI Scheme")]
		internal string customScheme;

		// Token: 0x04000040 RID: 64
		[HideInInspector]
		[SerializeField]
		[Tooltip("Custom Deep Link URI Host Prefix")]
		internal string customHost;

		// Token: 0x04000041 RID: 65
		private static readonly Dictionary<UnityPlayerAccountSettings.SupportedScopesEnum, string> k_SupportedScopesDictionary = new Dictionary<UnityPlayerAccountSettings.SupportedScopesEnum, string>
		{
			{
				UnityPlayerAccountSettings.SupportedScopesEnum.OpenId,
				"openid"
			},
			{
				UnityPlayerAccountSettings.SupportedScopesEnum.Email,
				"email"
			},
			{
				UnityPlayerAccountSettings.SupportedScopesEnum.OfflineAccess,
				"offline_access"
			}
		};

		// Token: 0x02000029 RID: 41
		[Flags]
		public enum SupportedScopesEnum
		{
			// Token: 0x04000080 RID: 128
			OpenId = 1,
			// Token: 0x04000081 RID: 129
			Email = 2,
			// Token: 0x04000082 RID: 130
			OfflineAccess = 4
		}
	}
}
