using System;
using JetBrains.Annotations;
using Unity.Services.Core.Configuration.Internal;
using UnityEngine;

namespace Unity.Services.Authentication
{
	// Token: 0x0200004F RID: 79
	internal class AuthenticationCache : IAuthenticationCache, ICache
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00006492 File Offset: 0x00004692
		public string CloudProjectId
		{
			get
			{
				return this.m_CloudProjectId.GetCloudProjectId();
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000214 RID: 532 RVA: 0x0000649F File Offset: 0x0000469F
		public string Profile
		{
			get
			{
				return this.m_Profile.Current;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000215 RID: 533 RVA: 0x000064AC File Offset: 0x000046AC
		private string Prefix
		{
			get
			{
				return this.CloudProjectId + "." + this.Profile + ".unity.services.authentication.";
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000216 RID: 534 RVA: 0x000064C9 File Offset: 0x000046C9
		private string OldPrefix
		{
			get
			{
				return "unity.services.authentication.";
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000064D0 File Offset: 0x000046D0
		public AuthenticationCache(ICloudProjectId cloudProjectId, IProfile profile)
		{
			this.m_CloudProjectId = cloudProjectId;
			this.m_Profile = profile;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000064E6 File Offset: 0x000046E6
		public bool HasKey(string key)
		{
			return PlayerPrefs.HasKey(this.GetKey(key));
		}

		// Token: 0x06000219 RID: 537 RVA: 0x000064F4 File Offset: 0x000046F4
		public void DeleteKey(string key)
		{
			PlayerPrefs.DeleteKey(this.GetKey(key));
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00006502 File Offset: 0x00004702
		[CanBeNull]
		public string GetString(string key)
		{
			if (!this.HasKey(key))
			{
				return null;
			}
			return PlayerPrefs.GetString(this.GetKey(key));
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000651B File Offset: 0x0000471B
		public void SetString(string key, string value)
		{
			PlayerPrefs.SetString(this.GetKey(key), value);
			PlayerPrefs.Save();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00006530 File Offset: 0x00004730
		public void Migrate(string key)
		{
			string oldKey = this.GetOldKey(key);
			if (PlayerPrefs.HasKey(oldKey))
			{
				PlayerPrefs.SetString(this.GetKey(key), PlayerPrefs.GetString(oldKey));
				PlayerPrefs.DeleteKey(oldKey);
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00006565 File Offset: 0x00004765
		internal string GetKey(string key)
		{
			return this.Prefix + key;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00006573 File Offset: 0x00004773
		internal string GetOldKey(string key)
		{
			return this.OldPrefix + key;
		}

		// Token: 0x0400010E RID: 270
		private ICloudProjectId m_CloudProjectId;

		// Token: 0x0400010F RID: 271
		private IProfile m_Profile;
	}
}
