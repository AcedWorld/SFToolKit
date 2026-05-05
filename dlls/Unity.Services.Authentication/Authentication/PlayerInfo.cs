using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Unity.Services.Authentication
{
	// Token: 0x0200001B RID: 27
	public sealed class PlayerInfo
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00004CF8 File Offset: 0x00002EF8
		public string Id { get; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000144 RID: 324 RVA: 0x00004D00 File Offset: 0x00002F00
		public DateTime? CreatedAt { get; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00004D08 File Offset: 0x00002F08
		public List<Identity> Identities { get; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00004D10 File Offset: 0x00002F10
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00004D18 File Offset: 0x00002F18
		[CanBeNull]
		public string Username { get; internal set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00004D21 File Offset: 0x00002F21
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00004D29 File Offset: 0x00002F29
		[CanBeNull]
		public DateTime? LastPasswordUpdate { get; internal set; }

		// Token: 0x0600014A RID: 330 RVA: 0x00004D32 File Offset: 0x00002F32
		internal PlayerInfo(string playerId)
		{
			this.Id = playerId;
			this.Identities = new List<Identity>();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00004D4C File Offset: 0x00002F4C
		internal PlayerInfo(PlayerInfoResponse response)
		{
			string id = response.Id;
			string createdAt = response.CreatedAt;
			List<ExternalIdentity> externalIds = response.ExternalIds;
			UsernameInfo usernamePassword = response.UsernamePassword;
			string username = (usernamePassword != null) ? usernamePassword.Username : null;
			UsernameInfo usernamePassword2 = response.UsernamePassword;
			this..ctor(id, createdAt, externalIds, username, (usernamePassword2 != null) ? usernamePassword2.PasswordUpdatedAt : null);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00004D8C File Offset: 0x00002F8C
		internal PlayerInfo(User user)
		{
			string id = user.Id;
			string createdAt = user.CreatedAt;
			List<ExternalIdentity> externalIds = user.ExternalIds;
			UsernameInfo usernameInfo = user.UsernameInfo;
			string username = ((usernameInfo != null) ? usernameInfo.Username : null) ?? user.Username;
			UsernameInfo usernameInfo2 = user.UsernameInfo;
			this..ctor(id, createdAt, externalIds, username, (usernameInfo2 != null) ? usernameInfo2.PasswordUpdatedAt : null);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00004DE0 File Offset: 0x00002FE0
		internal PlayerInfo(string playerId, string createdAt, List<ExternalIdentity> externalIdentities, string username, string lastPasswordUpdate)
		{
			this.Id = playerId;
			this.Identities = new List<Identity>();
			double value;
			if (double.TryParse(createdAt, out value))
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				this.CreatedAt = new DateTime?(dateTime.AddSeconds(value));
			}
			if (externalIdentities != null)
			{
				foreach (ExternalIdentity externalIdentity in externalIdentities)
				{
					this.Identities.Add(new Identity(externalIdentity));
				}
			}
			this.Username = username;
			double value2;
			if (double.TryParse(lastPasswordUpdate, out value2))
			{
				DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				this.LastPasswordUpdate = new DateTime?(dateTime2.AddSeconds(value2));
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00004EBC File Offset: 0x000030BC
		public string GetFacebookId()
		{
			return this.GetIdentityId("facebook.com");
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00004EC9 File Offset: 0x000030C9
		public string GetSteamId()
		{
			return this.GetIdentityId("steampowered.com");
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00004ED6 File Offset: 0x000030D6
		public string GetGoogleId()
		{
			return this.GetIdentityId("google.com");
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004EE3 File Offset: 0x000030E3
		public string GetGooglePlayGamesId()
		{
			return this.GetIdentityId("google-play-games");
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004EF0 File Offset: 0x000030F0
		public string GetAppleId()
		{
			return this.GetIdentityId("apple.com");
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00004EFD File Offset: 0x000030FD
		public string GetAppleGameCenterId()
		{
			return this.GetIdentityId("apple-game-center");
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00004F0A File Offset: 0x0000310A
		public string GetOculusId()
		{
			return this.GetIdentityId("oculus");
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00004F17 File Offset: 0x00003117
		public string GetOpenIdConnectId(string idProviderName)
		{
			if (!this.ValidateOpenIdConnectIdProviderName(idProviderName))
			{
				return null;
			}
			return this.GetIdentityId(idProviderName);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00004F2B File Offset: 0x0000312B
		public string GetUnityId()
		{
			return this.GetIdentityId("unity");
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00004F38 File Offset: 0x00003138
		public string GetCustomId()
		{
			return this.GetIdentityId("custom");
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00004F45 File Offset: 0x00003145
		public List<Identity> GetOpenIdConnectIdProviders()
		{
			List<Identity> identities = this.Identities;
			if (identities == null)
			{
				return null;
			}
			return identities.FindAll((Identity id) => id.TypeId.StartsWith("oidc-"));
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00004F78 File Offset: 0x00003178
		internal string GetIdentityId(string typeId)
		{
			List<Identity> identities = this.Identities;
			if (identities == null)
			{
				return null;
			}
			Identity identity = identities.FirstOrDefault((Identity x) => x.TypeId == typeId);
			if (identity == null)
			{
				return null;
			}
			return identity.UserId;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00004FBA File Offset: 0x000031BA
		internal void AddExternalIdentity(ExternalIdentity externalId)
		{
			if (externalId != null)
			{
				this.Identities.Add(new Identity(externalId));
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004FD0 File Offset: 0x000031D0
		internal void RemoveIdentity(string typeId)
		{
			List<Identity> identities = this.Identities;
			if (identities == null)
			{
				return;
			}
			identities.RemoveAll((Identity x) => x.TypeId == typeId);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005007 File Offset: 0x00003207
		private bool ValidateOpenIdConnectIdProviderName(string idProviderName)
		{
			return !string.IsNullOrEmpty(idProviderName) && Regex.Match(idProviderName, "^oidc-[a-z0-9-_\\.]{1,15}$").Success;
		}

		// Token: 0x04000063 RID: 99
		private const string k_OpenIdConnectPrefix = "oidc-";

		// Token: 0x04000064 RID: 100
		private const string k_IdProviderNameRegex = "^oidc-[a-z0-9-_\\.]{1,15}$";
	}
}
