using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200001D RID: 29
	internal class LobbyPatcherChanges : ILobbyChanges
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x000049F5 File Offset: 0x00002BF5
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x000049FD File Offset: 0x00002BFD
		public bool LobbyDeleted { get; private set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00004A06 File Offset: 0x00002C06
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00004A0E File Offset: 0x00002C0E
		public ChangedLobbyValue<string> Name { get; private set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00004A17 File Offset: 0x00002C17
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00004A1F File Offset: 0x00002C1F
		public ChangedLobbyValue<bool> IsPrivate { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00004A28 File Offset: 0x00002C28
		// (set) Token: 0x060000AA RID: 170 RVA: 0x00004A30 File Offset: 0x00002C30
		public ChangedLobbyValue<bool> IsLocked { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00004A39 File Offset: 0x00002C39
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00004A41 File Offset: 0x00002C41
		public ChangedLobbyValue<bool> HasPassword { get; private set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00004A4A File Offset: 0x00002C4A
		// (set) Token: 0x060000AE RID: 174 RVA: 0x00004A52 File Offset: 0x00002C52
		public ChangedLobbyValue<int> AvailableSlots { get; private set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00004A5B File Offset: 0x00002C5B
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00004A63 File Offset: 0x00002C63
		public ChangedLobbyValue<int> MaxPlayers { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00004A6C File Offset: 0x00002C6C
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00004A74 File Offset: 0x00002C74
		public ChangedOrRemovedLobbyValue<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> Data { get; private set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00004A7D File Offset: 0x00002C7D
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00004A85 File Offset: 0x00002C85
		public ChangedLobbyValue<List<int>> PlayerLeft { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00004A8E File Offset: 0x00002C8E
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00004A96 File Offset: 0x00002C96
		public ChangedLobbyValue<List<LobbyPlayerJoined>> PlayerJoined { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00004A9F File Offset: 0x00002C9F
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00004AA7 File Offset: 0x00002CA7
		public ChangedLobbyValue<Dictionary<int, LobbyPlayerChanges>> PlayerData { get; private set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00004AB0 File Offset: 0x00002CB0
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00004AB8 File Offset: 0x00002CB8
		public ChangedLobbyValue<string> HostId { get; private set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00004AC1 File Offset: 0x00002CC1
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00004AC9 File Offset: 0x00002CC9
		public ChangedLobbyValue<int> Version { get; private set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00004AD2 File Offset: 0x00002CD2
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00004ADA File Offset: 0x00002CDA
		public ChangedLobbyValue<DateTime> LastUpdated { get; private set; }

		// Token: 0x060000BF RID: 191 RVA: 0x00004AE3 File Offset: 0x00002CE3
		public LobbyPatcherChanges(int version)
		{
			this.Version = LobbyValue.Changed<int>(version);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004AF7 File Offset: 0x00002CF7
		public void LobbyDeletedChange()
		{
			this.LobbyDeleted = true;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004B00 File Offset: 0x00002D00
		public void NameChange(string name)
		{
			this.Name = LobbyValue.Changed<string>(name);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004B0E File Offset: 0x00002D0E
		public void IsPrivateChange(bool isPrivate)
		{
			this.IsPrivate = LobbyValue.Changed<bool>(isPrivate);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004B1C File Offset: 0x00002D1C
		public void IsLockedChange(bool isLocked)
		{
			this.IsLocked = LobbyValue.Changed<bool>(isLocked);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004B2A File Offset: 0x00002D2A
		public void HasPasswordChange(bool hasPassword)
		{
			this.HasPassword = LobbyValue.Changed<bool>(hasPassword);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004B38 File Offset: 0x00002D38
		public void AvailableSlotsChange(int availableSlots)
		{
			this.AvailableSlots = LobbyValue.Changed<int>(availableSlots);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004B46 File Offset: 0x00002D46
		public void MaxPlayersChange(int maxPlayers)
		{
			this.MaxPlayers = LobbyValue.Changed<int>(maxPlayers);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004B54 File Offset: 0x00002D54
		public void DataChange(string key, DataObject dataObject)
		{
			if (!this.Data.Changed)
			{
				this.Data = LobbyValue.ChangedNotRemoved<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>>(new Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>());
			}
			this.Data.Value[key] = LobbyValue.ChangedNotRemoved<DataObject>(dataObject);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004B9C File Offset: 0x00002D9C
		public void DataAdded(string key, DataObject dataObject)
		{
			if (!this.Data.Added)
			{
				this.Data = LobbyValue.ChangeAdded<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>>(new Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>());
			}
			this.Data.Value[key] = LobbyValue.ChangeAdded<DataObject>(dataObject);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004BE3 File Offset: 0x00002DE3
		public void DataRemoveChange()
		{
			this.Data = LobbyValue.Removed<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>>();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004BF0 File Offset: 0x00002DF0
		public void DataRemoveChange(string key)
		{
			if (!this.Data.Changed)
			{
				this.Data = LobbyValue.ChangedNotRemoved<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>>(new Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>());
			}
			this.Data.Value[key] = LobbyValue.Removed<DataObject>();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004C36 File Offset: 0x00002E36
		public void HostChange(string newHostId)
		{
			this.HostId = LobbyValue.Changed<string>(newHostId);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004C44 File Offset: 0x00002E44
		public void LastUpdatedChange(DateTime lastUpdated)
		{
			this.LastUpdated = LobbyValue.Changed<DateTime>(lastUpdated);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004C54 File Offset: 0x00002E54
		public void PlayerLeftChange(int index)
		{
			if (!this.PlayerLeft.Changed)
			{
				this.PlayerLeft = LobbyValue.Changed<List<int>>(new List<int>());
			}
			this.PlayerLeft.Value.Add(index);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004C98 File Offset: 0x00002E98
		public void PlayerJoinedChange(int index, Player player)
		{
			if (!this.PlayerJoined.Changed)
			{
				this.PlayerJoined = LobbyValue.Added<List<LobbyPlayerJoined>>(new List<LobbyPlayerJoined>());
			}
			this.PlayerJoined.Value.Add(new LobbyPlayerJoined(index, player));
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004CE0 File Offset: 0x00002EE0
		public void PlayerDataChange(int index, string key, PlayerDataObject playerDataObject)
		{
			LobbyPlayerChanges lobbyPlayerChanges = this.PreparePlayerDataChange(index);
			if (!lobbyPlayerChanges.ChangedData.Changed)
			{
				lobbyPlayerChanges.ChangedData = LobbyValue.ChangedNotRemoved<Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>(new Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>());
			}
			lobbyPlayerChanges.ChangedData.Value[key] = LobbyValue.ChangedNotRemoved<PlayerDataObject>(playerDataObject);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004D30 File Offset: 0x00002F30
		public void PlayerDataAdded(int index, string key, PlayerDataObject playerDataObject)
		{
			LobbyPlayerChanges lobbyPlayerChanges = this.PreparePlayerDataAddition(index);
			if (!lobbyPlayerChanges.ChangedData.Added)
			{
				lobbyPlayerChanges.ChangedData = LobbyValue.ChangeAdded<Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>(new Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>());
			}
			lobbyPlayerChanges.ChangedData.Value[key] = LobbyValue.ChangeAdded<PlayerDataObject>(playerDataObject);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004D80 File Offset: 0x00002F80
		public void PlayerDataRemoveChange(int index)
		{
			LobbyPlayerChanges lobbyPlayerChanges = this.PreparePlayerDataChange(index);
			if (!lobbyPlayerChanges.ChangedData.Changed)
			{
				lobbyPlayerChanges.ChangedData = LobbyValue.Removed<Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>();
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004DB0 File Offset: 0x00002FB0
		public void PlayerDataRemoveChange(int index, string key)
		{
			LobbyPlayerChanges lobbyPlayerChanges = this.PreparePlayerDataChange(index);
			if (!lobbyPlayerChanges.ChangedData.Changed)
			{
				lobbyPlayerChanges.ChangedData = LobbyValue.ChangedNotRemoved<Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>(new Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>());
			}
			lobbyPlayerChanges.ChangedData.Value[key] = LobbyValue.Removed<PlayerDataObject>();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004DFE File Offset: 0x00002FFE
		public void PlayerConnectionInfoChange(int index, string connectionInfo)
		{
			this.PreparePlayerDataChange(index).ConnectionInfoChanged = LobbyValue.Changed<string>(connectionInfo);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004E12 File Offset: 0x00003012
		public void PlayerLastUpdatedChange(int index, DateTime lastUpdated)
		{
			this.PreparePlayerDataChange(index).LastUpdatedChanged = LobbyValue.Changed<DateTime>(lastUpdated);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004E26 File Offset: 0x00003026
		public void ApplyToLobby(Lobby lobby)
		{
			LobbyPatcher.ApplyPatchesToLobby(this, lobby);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004E30 File Offset: 0x00003030
		private LobbyPlayerChanges PreparePlayerDataChange(int index)
		{
			if (!this.PlayerData.Changed)
			{
				this.PlayerData = LobbyValue.Changed<Dictionary<int, LobbyPlayerChanges>>(new Dictionary<int, LobbyPlayerChanges>());
			}
			LobbyPlayerChanges lobbyPlayerChanges;
			if (!this.PlayerData.Value.TryGetValue(index, out lobbyPlayerChanges))
			{
				lobbyPlayerChanges = new LobbyPlayerChanges(index);
				this.PlayerData.Value[index] = lobbyPlayerChanges;
			}
			return lobbyPlayerChanges;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004E94 File Offset: 0x00003094
		private LobbyPlayerChanges PreparePlayerDataAddition(int index)
		{
			if (!this.PlayerData.Changed)
			{
				this.PlayerData = LobbyValue.Added<Dictionary<int, LobbyPlayerChanges>>(new Dictionary<int, LobbyPlayerChanges>());
			}
			LobbyPlayerChanges lobbyPlayerChanges;
			if (!this.PlayerData.Value.TryGetValue(index, out lobbyPlayerChanges))
			{
				lobbyPlayerChanges = new LobbyPlayerChanges(index);
				this.PlayerData.Value[index] = lobbyPlayerChanges;
			}
			return lobbyPlayerChanges;
		}
	}
}
