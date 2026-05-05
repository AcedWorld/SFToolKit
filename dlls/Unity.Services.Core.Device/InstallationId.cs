using System;
using Unity.Services.Core.Device.Internal;
using Unity.Services.Core.Internal;
using UnityEngine;

namespace Unity.Services.Core.Device
{
	// Token: 0x02000003 RID: 3
	internal class InstallationId : IInstallationId, IServiceComponent
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020BE File Offset: 0x000002BE
		public InstallationId()
		{
			this.UnityAdsIdentifierProvider = new UnityAdsIdentifier();
			this.UnityAnalyticsIdentifierProvider = new UnityAnalyticsIdentifier();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020DC File Offset: 0x000002DC
		public string GetOrCreateIdentifier()
		{
			if (string.IsNullOrEmpty(this.Identifier))
			{
				this.CreateIdentifier();
			}
			return this.Identifier;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020F8 File Offset: 0x000002F8
		public void CreateIdentifier()
		{
			this.Identifier = InstallationId.ReadIdentifierFromFile();
			if (!string.IsNullOrEmpty(this.Identifier))
			{
				return;
			}
			string userId = this.UnityAnalyticsIdentifierProvider.UserId;
			string userId2 = this.UnityAdsIdentifierProvider.UserId;
			if (!string.IsNullOrEmpty(userId))
			{
				this.Identifier = userId;
			}
			else if (!string.IsNullOrEmpty(userId2))
			{
				this.Identifier = userId2;
			}
			else
			{
				this.Identifier = InstallationId.GenerateGuid();
			}
			InstallationId.WriteIdentifierToFile(this.Identifier);
			if (string.IsNullOrEmpty(userId))
			{
				this.UnityAnalyticsIdentifierProvider.UserId = this.Identifier;
			}
			if (string.IsNullOrEmpty(userId2))
			{
				this.UnityAdsIdentifierProvider.UserId = this.Identifier;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021A0 File Offset: 0x000003A0
		private static string ReadIdentifierFromFile()
		{
			return PlayerPrefs.GetString("UnityInstallationId");
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021AC File Offset: 0x000003AC
		private static void WriteIdentifierToFile(string identifier)
		{
			PlayerPrefs.SetString("UnityInstallationId", identifier);
			PlayerPrefs.Save();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021C0 File Offset: 0x000003C0
		private static string GenerateGuid()
		{
			return Guid.NewGuid().ToString();
		}

		// Token: 0x04000001 RID: 1
		private const string k_UnityInstallationIdKey = "UnityInstallationId";

		// Token: 0x04000002 RID: 2
		internal string Identifier;

		// Token: 0x04000003 RID: 3
		internal IUserIdentifierProvider UnityAdsIdentifierProvider;

		// Token: 0x04000004 RID: 4
		internal IUserIdentifierProvider UnityAnalyticsIdentifierProvider;
	}
}
