using System;
using System.Collections.Generic;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;

// Token: 0x02000005 RID: 5
public class LobbyEventCallbacks
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x06000018 RID: 24 RVA: 0x0000394C File Offset: 0x00001B4C
	// (remove) Token: 0x06000019 RID: 25 RVA: 0x00003984 File Offset: 0x00001B84
	public event Action<ILobbyChanges> LobbyChanged;

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x0600001A RID: 26 RVA: 0x000039BC File Offset: 0x00001BBC
	// (remove) Token: 0x0600001B RID: 27 RVA: 0x000039F4 File Offset: 0x00001BF4
	public event Action<List<LobbyPlayerJoined>> PlayerJoined;

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x0600001C RID: 28 RVA: 0x00003A2C File Offset: 0x00001C2C
	// (remove) Token: 0x0600001D RID: 29 RVA: 0x00003A64 File Offset: 0x00001C64
	public event Action<List<int>> PlayerLeft;

	// Token: 0x14000004 RID: 4
	// (add) Token: 0x0600001E RID: 30 RVA: 0x00003A9C File Offset: 0x00001C9C
	// (remove) Token: 0x0600001F RID: 31 RVA: 0x00003AD4 File Offset: 0x00001CD4
	public event Action<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> DataChanged;

	// Token: 0x14000005 RID: 5
	// (add) Token: 0x06000020 RID: 32 RVA: 0x00003B0C File Offset: 0x00001D0C
	// (remove) Token: 0x06000021 RID: 33 RVA: 0x00003B44 File Offset: 0x00001D44
	public event Action<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> DataRemoved;

	// Token: 0x14000006 RID: 6
	// (add) Token: 0x06000022 RID: 34 RVA: 0x00003B7C File Offset: 0x00001D7C
	// (remove) Token: 0x06000023 RID: 35 RVA: 0x00003BB4 File Offset: 0x00001DB4
	public event Action<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> DataAdded;

	// Token: 0x14000007 RID: 7
	// (add) Token: 0x06000024 RID: 36 RVA: 0x00003BEC File Offset: 0x00001DEC
	// (remove) Token: 0x06000025 RID: 37 RVA: 0x00003C24 File Offset: 0x00001E24
	public event Action<Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>> PlayerDataChanged;

	// Token: 0x14000008 RID: 8
	// (add) Token: 0x06000026 RID: 38 RVA: 0x00003C5C File Offset: 0x00001E5C
	// (remove) Token: 0x06000027 RID: 39 RVA: 0x00003C94 File Offset: 0x00001E94
	public event Action<Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>> PlayerDataRemoved;

	// Token: 0x14000009 RID: 9
	// (add) Token: 0x06000028 RID: 40 RVA: 0x00003CCC File Offset: 0x00001ECC
	// (remove) Token: 0x06000029 RID: 41 RVA: 0x00003D04 File Offset: 0x00001F04
	public event Action<Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>> PlayerDataAdded;

	// Token: 0x1400000A RID: 10
	// (add) Token: 0x0600002A RID: 42 RVA: 0x00003D3C File Offset: 0x00001F3C
	// (remove) Token: 0x0600002B RID: 43 RVA: 0x00003D74 File Offset: 0x00001F74
	public event Action LobbyDeleted;

	// Token: 0x1400000B RID: 11
	// (add) Token: 0x0600002C RID: 44 RVA: 0x00003DAC File Offset: 0x00001FAC
	// (remove) Token: 0x0600002D RID: 45 RVA: 0x00003DE4 File Offset: 0x00001FE4
	public event Action KickedFromLobby;

	// Token: 0x1400000C RID: 12
	// (add) Token: 0x0600002E RID: 46 RVA: 0x00003E1C File Offset: 0x0000201C
	// (remove) Token: 0x0600002F RID: 47 RVA: 0x00003E54 File Offset: 0x00002054
	public event Action<LobbyEventConnectionState> LobbyEventConnectionStateChanged;

	// Token: 0x06000030 RID: 48 RVA: 0x00003E8C File Offset: 0x0000208C
	internal void InvokeLobbyChanged(ILobbyChanges changes)
	{
		Action<ILobbyChanges> lobbyChanged = this.LobbyChanged;
		if (lobbyChanged != null)
		{
			lobbyChanged(changes);
		}
		if (changes.LobbyDeleted)
		{
			Action lobbyDeleted = this.LobbyDeleted;
			if (lobbyDeleted != null)
			{
				lobbyDeleted();
			}
		}
		if (changes.PlayerJoined.Changed || changes.PlayerJoined.Added)
		{
			Action<List<LobbyPlayerJoined>> playerJoined = this.PlayerJoined;
			if (playerJoined != null)
			{
				playerJoined(changes.PlayerJoined.Value);
			}
		}
		if (changes.PlayerLeft.Changed || changes.PlayerLeft.Added)
		{
			Action<List<int>> playerLeft = this.PlayerLeft;
			if (playerLeft != null)
			{
				playerLeft(changes.PlayerLeft.Value);
			}
		}
		if (changes.Data.Added || changes.Data.Changed || changes.Data.Removed)
		{
			Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>> dictionary = new Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>();
			Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>> dictionary2 = new Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>();
			Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>> dictionary3 = new Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>();
			if (changes.Data.Value == null)
			{
				Action<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> dataRemoved = this.DataRemoved;
				if (dataRemoved == null)
				{
					return;
				}
				dataRemoved(null);
				return;
			}
			else
			{
				foreach (string key in changes.Data.Value.Keys)
				{
					if (changes.Data.Added || changes.Data.Value[key].Added)
					{
						dictionary3.Add(key, changes.Data.Value[key]);
					}
					else if (changes.Data.Removed || changes.Data.Value[key].Removed)
					{
						dictionary2.Add(key, changes.Data.Value[key]);
					}
					else if (changes.Data.Changed && changes.Data.Value[key].Changed)
					{
						dictionary.Add(key, changes.Data.Value[key]);
					}
				}
				if (dictionary.Count > 0)
				{
					Action<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> dataChanged = this.DataChanged;
					if (dataChanged != null)
					{
						dataChanged(dictionary);
					}
				}
				if (dictionary2.Count > 0)
				{
					Action<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> dataRemoved2 = this.DataRemoved;
					if (dataRemoved2 != null)
					{
						dataRemoved2(dictionary2);
					}
				}
				if (dictionary3.Count > 0)
				{
					Action<Dictionary<string, ChangedOrRemovedLobbyValue<DataObject>>> dataAdded = this.DataAdded;
					if (dataAdded != null)
					{
						dataAdded(dictionary3);
					}
				}
			}
		}
		if (changes.PlayerData.Added || changes.PlayerData.Changed)
		{
			Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>> dictionary4 = new Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>();
			Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>> dictionary5 = new Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>();
			Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>> dictionary6 = new Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>();
			foreach (KeyValuePair<int, LobbyPlayerChanges> keyValuePair in changes.PlayerData.Value)
			{
				if (keyValuePair.Value == null || keyValuePair.Value.ChangedData.Value == null)
				{
					dictionary5.Add(keyValuePair.Key, null);
				}
				else
				{
					foreach (KeyValuePair<string, ChangedOrRemovedLobbyValue<PlayerDataObject>> keyValuePair2 in keyValuePair.Value.ChangedData.Value)
					{
						if (keyValuePair2.Value.Added)
						{
							if (!dictionary6.ContainsKey(keyValuePair.Key))
							{
								dictionary6.Add(keyValuePair.Key, new Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>());
							}
							dictionary6[keyValuePair.Key].Add(keyValuePair2.Key, keyValuePair2.Value);
						}
						else if (keyValuePair2.Value.Removed)
						{
							if (!dictionary5.ContainsKey(keyValuePair.Key))
							{
								dictionary5.Add(keyValuePair.Key, new Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>());
							}
							dictionary5[keyValuePair.Key].Add(keyValuePair2.Key, keyValuePair2.Value);
						}
						else if (keyValuePair2.Value.Changed)
						{
							if (!dictionary4.ContainsKey(keyValuePair.Key))
							{
								dictionary4.Add(keyValuePair.Key, new Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>());
							}
							dictionary4[keyValuePair.Key].Add(keyValuePair2.Key, keyValuePair2.Value);
						}
					}
				}
			}
			if (dictionary4.Count > 0)
			{
				Action<Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>> playerDataChanged = this.PlayerDataChanged;
				if (playerDataChanged != null)
				{
					playerDataChanged(dictionary4);
				}
			}
			if (dictionary5.Count > 0)
			{
				Action<Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>> playerDataRemoved = this.PlayerDataRemoved;
				if (playerDataRemoved != null)
				{
					playerDataRemoved(dictionary5);
				}
			}
			if (dictionary6.Count > 0)
			{
				Action<Dictionary<int, Dictionary<string, ChangedOrRemovedLobbyValue<PlayerDataObject>>>> playerDataAdded = this.PlayerDataAdded;
				if (playerDataAdded == null)
				{
					return;
				}
				playerDataAdded(dictionary6);
			}
		}
	}

	// Token: 0x06000031 RID: 49 RVA: 0x000043D4 File Offset: 0x000025D4
	internal void InvokeKickedFromLobby()
	{
		Action kickedFromLobby = this.KickedFromLobby;
		if (kickedFromLobby == null)
		{
			return;
		}
		kickedFromLobby();
	}

	// Token: 0x06000032 RID: 50 RVA: 0x000043E6 File Offset: 0x000025E6
	internal void InvokeLobbyEventConnectionStateChanged(LobbyEventConnectionState state)
	{
		Action<LobbyEventConnectionState> lobbyEventConnectionStateChanged = this.LobbyEventConnectionStateChanged;
		if (lobbyEventConnectionStateChanged == null)
		{
			return;
		}
		lobbyEventConnectionStateChanged(state);
	}
}
