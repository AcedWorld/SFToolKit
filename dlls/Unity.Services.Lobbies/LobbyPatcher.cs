using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine.Scripting;

// Token: 0x02000004 RID: 4
internal static class LobbyPatcher
{
	// Token: 0x06000004 RID: 4 RVA: 0x00002080 File Offset: 0x00000280
	internal static void ApplyPatchesToLobby(ILobbyChanges changes, Lobby lobbyToChange)
	{
		if (changes.Version.Value <= lobbyToChange.Version)
		{
			return;
		}
		if (changes.LobbyDeleted)
		{
			Logger.LogWarning("Attempting to apply changes to lobby, but the lobby has been deleted. Check if a lobby has been deleted by checking .LobbyDeleted");
			return;
		}
		if (changes.Name.Changed)
		{
			lobbyToChange.Name = changes.Name.Value;
		}
		if (changes.IsPrivate.Changed)
		{
			lobbyToChange.IsPrivate = changes.IsPrivate.Value;
		}
		if (changes.IsLocked.Changed)
		{
			lobbyToChange.IsLocked = changes.IsLocked.Value;
		}
		if (changes.HasPassword.Changed)
		{
			lobbyToChange.HasPassword = changes.HasPassword.Value;
		}
		if (changes.AvailableSlots.Changed)
		{
			lobbyToChange.AvailableSlots = changes.AvailableSlots.Value;
		}
		if (changes.MaxPlayers.Changed)
		{
			lobbyToChange.MaxPlayers = changes.MaxPlayers.Value;
		}
		if (changes.Data.Removed)
		{
			if (lobbyToChange.Data != null)
			{
				lobbyToChange.Data.Clear();
			}
		}
		else if (changes.Data.Changed)
		{
			if (lobbyToChange.Data == null)
			{
				lobbyToChange.Data = new Dictionary<string, DataObject>();
			}
			foreach (KeyValuePair<string, ChangedOrRemovedLobbyValue<DataObject>> keyValuePair in changes.Data.Value)
			{
				if (keyValuePair.Value.Removed)
				{
					lobbyToChange.Data.Remove(keyValuePair.Key);
				}
				else
				{
					lobbyToChange.Data[keyValuePair.Key] = keyValuePair.Value.Value;
				}
			}
		}
		if (changes.PlayerLeft.Changed)
		{
			List<int> value = changes.PlayerLeft.Value;
			value.Sort((int first, int second) => second.CompareTo(first));
			foreach (int index in value)
			{
				lobbyToChange.Players.RemoveAt(index);
			}
		}
		if (changes.PlayerJoined.Changed)
		{
			if (lobbyToChange.Players == null)
			{
				lobbyToChange.Players = new List<Player>(changes.PlayerJoined.Value.Count);
			}
			foreach (LobbyPlayerJoined lobbyPlayerJoined in changes.PlayerJoined.Value)
			{
				lobbyToChange.Players.Insert(lobbyPlayerJoined.PlayerIndex, lobbyPlayerJoined.Player);
			}
		}
		if (changes.PlayerData.Changed)
		{
			foreach (KeyValuePair<int, LobbyPlayerChanges> keyValuePair2 in changes.PlayerData.Value)
			{
				LobbyPlayerChanges value2 = keyValuePair2.Value;
				int playerIndex = keyValuePair2.Value.PlayerIndex;
				Player player = lobbyToChange.Players[playerIndex];
				if (value2.ConnectionInfoChanged.Changed)
				{
					player.ConnectionInfo = keyValuePair2.Value.ConnectionInfoChanged.Value;
				}
				if (value2.LastUpdatedChanged.Changed)
				{
					player.LastUpdated = value2.LastUpdatedChanged.Value;
				}
				if (value2.ChangedData.Removed)
				{
					if (player.Data != null)
					{
						player.Data.Clear();
					}
				}
				else if (value2.ChangedData.Changed)
				{
					if (player.Data == null)
					{
						player.Data = new Dictionary<string, PlayerDataObject>();
					}
					foreach (KeyValuePair<string, ChangedOrRemovedLobbyValue<PlayerDataObject>> keyValuePair3 in value2.ChangedData.Value)
					{
						if (keyValuePair3.Value.Removed)
						{
							player.Data.Remove(keyValuePair3.Key);
						}
						else
						{
							player.Data[keyValuePair3.Key] = keyValuePair3.Value.Value;
						}
					}
				}
			}
		}
		if (changes.Version.Changed)
		{
			lobbyToChange.Version = changes.Version.Value;
		}
		if (changes.HostId.Changed)
		{
			lobbyToChange.HostId = changes.HostId.Value;
		}
		if (changes.LastUpdated.Changed)
		{
			lobbyToChange.LastUpdated = changes.LastUpdated.Value;
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002604 File Offset: 0x00000804
	internal static LobbyPatcherChanges GetLobbyDiff(Lobby lobby1, Lobby lobby2)
	{
		LobbyPatcherChanges lobbyPatcherChanges = new LobbyPatcherChanges(lobby1.Version);
		if (lobby2 == null)
		{
			lobbyPatcherChanges.LobbyDeletedChange();
			return lobbyPatcherChanges;
		}
		if (lobby1.Version == lobby2.Version)
		{
			return lobbyPatcherChanges;
		}
		Lobby lobby3 = (lobby1.Version < lobby2.Version) ? lobby1 : lobby2;
		Lobby lobby4 = (lobby1.Version > lobby2.Version) ? lobby1 : lobby2;
		lobbyPatcherChanges = new LobbyPatcherChanges(lobby4.Version);
		if (lobby3.Name != null && !lobby3.Name.Equals(lobby4.Name))
		{
			lobbyPatcherChanges.NameChange(lobby4.Name);
		}
		if (lobby3.IsPrivate != lobby4.IsPrivate)
		{
			lobbyPatcherChanges.IsPrivateChange(lobby4.IsPrivate);
		}
		if (lobby3.IsLocked != lobby4.IsLocked)
		{
			lobbyPatcherChanges.IsLockedChange(lobby4.IsLocked);
		}
		if (lobby3.AvailableSlots != lobby4.AvailableSlots)
		{
			lobbyPatcherChanges.AvailableSlotsChange(lobby4.AvailableSlots);
		}
		if (lobby3.MaxPlayers != lobby4.MaxPlayers)
		{
			lobbyPatcherChanges.MaxPlayersChange(lobby4.MaxPlayers);
		}
		if (lobby3.HostId != null && !lobby3.HostId.Equals(lobby4.HostId))
		{
			lobbyPatcherChanges.HostChange(lobby4.HostId);
		}
		if (!lobby3.LastUpdated.Equals(lobby4.LastUpdated))
		{
			lobbyPatcherChanges.LastUpdatedChange(lobby4.LastUpdated);
		}
		if (lobby4.Data == null)
		{
			lobbyPatcherChanges.DataRemoveChange();
		}
		else
		{
			foreach (string key in lobby4.Data.Keys)
			{
				if (lobby3.Data == null || !lobby3.Data.ContainsKey(key) || lobby3.Data[key] == null)
				{
					lobbyPatcherChanges.DataAdded(key, lobby4.Data[key]);
				}
			}
			if (lobby3.Data != null)
			{
				foreach (string key2 in lobby3.Data.Keys)
				{
					if (!lobby4.Data.ContainsKey(key2) || lobby4.Data[key2] == null)
					{
						lobbyPatcherChanges.DataRemoveChange(key2);
					}
					else if (lobby3.Data[key2] == null)
					{
						lobbyPatcherChanges.DataAdded(key2, lobby4.Data[key2]);
					}
					else if (!LobbyPatcher.IsLobbyDataEqual(lobby3.Data[key2], lobby4.Data[key2]))
					{
						lobbyPatcherChanges.DataChange(key2, lobby4.Data[key2]);
					}
				}
			}
		}
		if (lobby4.Players == null || lobby4.Players.Count == 0)
		{
			if (lobby3.Players != null)
			{
				for (int i = lobby3.Players.Count - 1; i >= 0; i--)
				{
					lobbyPatcherChanges.PlayerLeftChange(i);
				}
			}
			return lobbyPatcherChanges;
		}
		List<Player> list = null;
		if (lobby3.Players != null)
		{
			list = new List<Player>(lobby3.Players);
			Dictionary<string, int> dictionary = new Dictionary<string, int>(lobby3.Players.Count);
			for (int j = 0; j < lobby3.Players.Count; j++)
			{
				dictionary.Add(lobby3.Players[j].Id, j);
			}
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>(lobby4.Players.Count);
			for (int k = 0; k < lobby4.Players.Count; k++)
			{
				dictionary2.Add(lobby4.Players[k].Id, k);
			}
			for (int l = lobby3.Players.Count - 1; l >= 0; l--)
			{
				Player player = lobby3.Players[l];
				if (!dictionary2.ContainsKey(player.Id))
				{
					lobbyPatcherChanges.PlayerLeftChange(l);
					list.RemoveAt(l);
				}
				else
				{
					int index = dictionary2[player.Id];
					Player player2 = lobby4.Players[index];
					DateTime lastUpdated = player.LastUpdated;
					if (!player.LastUpdated.Equals(player2.LastUpdated))
					{
						lobbyPatcherChanges.PlayerLastUpdatedChange(index, player2.LastUpdated);
					}
					if (player.ConnectionInfo == null || !player.ConnectionInfo.Equals(player2.ConnectionInfo))
					{
						lobbyPatcherChanges.PlayerConnectionInfoChange(index, player2.ConnectionInfo);
					}
					if (player.Data != null && player2.Data == null)
					{
						lobbyPatcherChanges.PlayerDataRemoveChange(index);
					}
					else
					{
						if (player.Data == null && player2.Data != null)
						{
							using (Dictionary<string, PlayerDataObject>.KeyCollection.Enumerator enumerator2 = player2.Data.Keys.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									string key3 = enumerator2.Current;
									lobbyPatcherChanges.PlayerDataAdded(index, key3, player2.Data[key3]);
								}
								goto IL_628;
							}
						}
						if (player.Data != null && player2.Data != null)
						{
							foreach (string key4 in player2.Data.Keys)
							{
								if (!player.Data.ContainsKey(key4) || player.Data[key4] == null)
								{
									lobbyPatcherChanges.PlayerDataAdded(index, key4, player2.Data[key4]);
								}
							}
							using (player.Data.Keys.GetEnumerator())
							{
								foreach (string key5 in player.Data.Keys)
								{
									if (!player2.Data.ContainsKey(key5) || player2.Data[key5] == null)
									{
										lobbyPatcherChanges.PlayerDataRemoveChange(index, key5);
									}
									else if (player.Data[key5] == null)
									{
										lobbyPatcherChanges.PlayerDataAdded(index, key5, player2.Data[key5]);
									}
									else if (!LobbyPatcher.IsPlayerDataEqual(player.Data[key5], player2.Data[key5]))
									{
										lobbyPatcherChanges.PlayerDataChange(index, key5, player2.Data[key5]);
									}
								}
							}
						}
					}
				}
				IL_628:;
			}
		}
		if (lobby4.Players != null)
		{
			for (int m = 0; m < lobby4.Players.Count; m++)
			{
				if (list == null)
				{
					lobbyPatcherChanges.PlayerJoinedChange(m, lobby4.Players[m]);
				}
				else if (list.Count <= m || !list[m].Id.Equals(lobby4.Players[m].Id))
				{
					lobbyPatcherChanges.PlayerJoinedChange(m, lobby4.Players[m]);
				}
			}
		}
		return lobbyPatcherChanges;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002D18 File Offset: 0x00000F18
	private static bool IsLobbyDataEqual(DataObject d1, DataObject d2)
	{
		return d1.Value == d2.Value && d1.Index == d2.Index && d1.Visibility == d2.Visibility;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002D4B File Offset: 0x00000F4B
	private static bool IsPlayerDataEqual(PlayerDataObject d1, PlayerDataObject d2)
	{
		return d1.Value == d2.Value && d1.Visibility == d2.Visibility;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002D70 File Offset: 0x00000F70
	internal static LobbyPatcherChanges GetLobbyChanges(string json)
	{
		if (string.IsNullOrWhiteSpace(json))
		{
			Logger.LogError("Unable to apply patches to lobby as the provided JSON was null!");
		}
		LobbyPatcher.LobbyPatches lobbyPatches = JsonConvert.DeserializeObject<LobbyPatcher.LobbyPatches>(json);
		if (lobbyPatches == null)
		{
			Logger.LogError("Unable to deserialize JSON to LobbyPatches!");
		}
		return LobbyPatcher.GetLobbyPatches(lobbyPatches);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002D9C File Offset: 0x00000F9C
	internal static LobbyPatcherChanges GetLobbyPatches(LobbyPatcher.LobbyPatches lobbyPatches)
	{
		if (lobbyPatches.Patches == null || lobbyPatches.Patches.Count < 1)
		{
			Logger.LogWarning("Attempting to apply patches to lobby, but there were no patches to apply.");
			return new LobbyPatcherChanges(lobbyPatches.Version);
		}
		LobbyPatcherChanges lobbyPatcherChanges = new LobbyPatcherChanges(lobbyPatches.Version);
		foreach (LobbyPatcher.LobbyPatch patch in lobbyPatches.Patches)
		{
			LobbyPatcher.ParseLobbyPatch(patch, lobbyPatcherChanges);
		}
		return lobbyPatcherChanges;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002E28 File Offset: 0x00001028
	private static void ParseLobbyPatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		string op = patch.op;
		if (op == "add")
		{
			LobbyPatcher.ParseAddPatch(patch, changes);
			return;
		}
		if (op == "replace")
		{
			LobbyPatcher.ParseReplacePatch(patch, changes);
			return;
		}
		if (!(op == "remove"))
		{
			Logger.LogError("patch.op(" + patch.op + ") is not implemented by the LobbyPatcher");
			return;
		}
		LobbyPatcher.ParseRemovePatch(patch, changes);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002E98 File Offset: 0x00001098
	private static void ParseAddPatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		if (patch.path.StartsWith("/data/"))
		{
			LobbyPatcher.ParseLobbyDataAddOrReplacePatch(patch, changes);
			return;
		}
		if (patch.path.StartsWith("/players/"))
		{
			LobbyPatcher.ParsePlayerAddPatch(patch, changes);
			return;
		}
		string path = patch.path;
		uint num = <PrivateImplementationDetails>.ComputeStringHash(path);
		if (num <= 2078458813U)
		{
			if (num <= 1139407317U)
			{
				if (num != 1098918819U)
				{
					if (num == 1139407317U)
					{
						if (path == "/hostId")
						{
							changes.HostChange((string)patch.value);
							return;
						}
					}
				}
				else if (path == "/hasPassword")
				{
					changes.HasPasswordChange((bool)patch.value);
					return;
				}
			}
			else if (num != 1240880126U)
			{
				if (num == 2078458813U)
				{
					if (path == "/name")
					{
						changes.NameChange((string)patch.value);
						return;
					}
				}
			}
			else if (path == "/data")
			{
				LobbyPatcher.ParseAddLobbyData((JObject)patch.value, changes);
				return;
			}
		}
		else if (num <= 2541990806U)
		{
			if (num != 2514840529U)
			{
				if (num == 2541990806U)
				{
					if (path == "/availableSlots")
					{
						changes.AvailableSlotsChange((int)((long)patch.value));
						return;
					}
				}
			}
			else if (path == "/isPrivate")
			{
				changes.IsPrivateChange((bool)patch.value);
				return;
			}
		}
		else if (num != 3353346180U)
		{
			if (num != 3580185597U)
			{
				if (num == 4186195922U)
				{
					if (path == "/maxPlayers")
					{
						changes.MaxPlayersChange((int)((long)patch.value));
						return;
					}
				}
			}
			else if (path == "/lastUpdated")
			{
				changes.LastUpdatedChange((DateTime)patch.value);
				return;
			}
		}
		else if (path == "/isLocked")
		{
			changes.IsLockedChange((bool)patch.value);
			return;
		}
		Logger.LogError("Not implemented add patch with path[" + patch.path + "]");
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000030E4 File Offset: 0x000012E4
	private static void ParseReplacePatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		if (patch.path.StartsWith("/data/"))
		{
			LobbyPatcher.ParseLobbyDataAddOrReplacePatch(patch, changes);
			return;
		}
		if (patch.path.StartsWith("/players/"))
		{
			LobbyPatcher.ParsePlayerReplacePatch(patch, changes);
			return;
		}
		string path = patch.path;
		uint num = <PrivateImplementationDetails>.ComputeStringHash(path);
		if (num <= 2514840529U)
		{
			if (num <= 1139407317U)
			{
				if (num != 1098918819U)
				{
					if (num == 1139407317U)
					{
						if (path == "/hostId")
						{
							changes.HostChange((string)patch.value);
							return;
						}
					}
				}
				else if (path == "/hasPassword")
				{
					changes.HasPasswordChange((bool)patch.value);
					return;
				}
			}
			else if (num != 2078458813U)
			{
				if (num == 2514840529U)
				{
					if (path == "/isPrivate")
					{
						changes.IsPrivateChange((bool)patch.value);
						return;
					}
				}
			}
			else if (path == "/name")
			{
				changes.NameChange((string)patch.value);
				return;
			}
		}
		else if (num <= 3353346180U)
		{
			if (num != 2541990806U)
			{
				if (num == 3353346180U)
				{
					if (path == "/isLocked")
					{
						changes.IsLockedChange((bool)patch.value);
						return;
					}
				}
			}
			else if (path == "/availableSlots")
			{
				changes.AvailableSlotsChange((int)((long)patch.value));
				return;
			}
		}
		else if (num != 3580185597U)
		{
			if (num == 4186195922U)
			{
				if (path == "/maxPlayers")
				{
					changes.MaxPlayersChange((int)((long)patch.value));
					return;
				}
			}
		}
		else if (path == "/lastUpdated")
		{
			changes.LastUpdatedChange((DateTime)patch.value);
			return;
		}
		Logger.LogError("Not implemented replace patch with path[" + patch.path + "]");
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000032FC File Offset: 0x000014FC
	private static void ParseRemovePatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		if (patch.path.StartsWith("/data/"))
		{
			LobbyPatcher.ParseLobbyDataRemovePatch(patch, changes);
			return;
		}
		if (patch.path.StartsWith("/players/"))
		{
			LobbyPatcher.ParsePlayerRemovePatch(patch, changes);
			return;
		}
		string path = patch.path;
		uint num = <PrivateImplementationDetails>.ComputeStringHash(path);
		if (num <= 1240880126U)
		{
			if (num <= 1098918819U)
			{
				if (num != 705468254U)
				{
					if (num == 1098918819U)
					{
						if (path == "/hasPassword")
						{
							changes.HasPasswordChange(false);
							return;
						}
					}
				}
				else if (path == "/")
				{
					changes.LobbyDeletedChange();
					return;
				}
			}
			else if (num != 1139407317U)
			{
				if (num == 1240880126U)
				{
					if (path == "/data")
					{
						LobbyPatcher.ParseLobbyDataRemovePatch(patch, changes);
						return;
					}
				}
			}
			else if (path == "/hostId")
			{
				changes.HostChange(null);
				return;
			}
		}
		else if (num <= 2514840529U)
		{
			if (num != 2078458813U)
			{
				if (num == 2514840529U)
				{
					if (path == "/isPrivate")
					{
						changes.IsPrivateChange(false);
						return;
					}
				}
			}
			else if (path == "/name")
			{
				changes.NameChange(null);
				return;
			}
		}
		else if (num != 2541990806U)
		{
			if (num != 3353346180U)
			{
				if (num == 4186195922U)
				{
					if (path == "/maxPlayers")
					{
						changes.MaxPlayersChange(150);
						return;
					}
				}
			}
			else if (path == "/isLocked")
			{
				changes.IsLockedChange(false);
				return;
			}
		}
		else if (path == "/availableSlots")
		{
			changes.AvailableSlotsChange(0);
			return;
		}
		Logger.LogError("Not implemented remove patch with path[" + patch.path + "]");
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000034CC File Offset: 0x000016CC
	private static void ParseAddLobbyData(JObject data, LobbyPatcherChanges changes)
	{
		foreach (KeyValuePair<string, JToken> keyValuePair in data)
		{
			changes.DataAdded(keyValuePair.Key, keyValuePair.Value.ToObject<DataObject>());
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00003528 File Offset: 0x00001728
	private static void ParseLobbyDataAddOrReplacePatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		int length = "/data/".Length;
		int num = patch.path.IndexOf('/', length);
		string key = (num < 0) ? patch.path.Substring(length) : patch.path.Substring(num);
		JObject jobject = (JObject)patch.value;
		changes.DataChange(key, jobject.ToObject<DataObject>());
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00003588 File Offset: 0x00001788
	private static void ParseLobbyDataRemovePatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		if (patch.path == "/data")
		{
			changes.DataRemoveChange();
			return;
		}
		string key = patch.path.Substring("/data/".Length);
		changes.DataRemoveChange(key);
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000035CC File Offset: 0x000017CC
	private static string GetPlayerPathAndIndex(LobbyPatcher.LobbyPatch patch, out int playerIndex)
	{
		string[] array = patch.path.Split('/', StringSplitOptions.None);
		if (!int.TryParse(array[2], out playerIndex))
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string str in array)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append("\"" + str + "\"");
			}
			throw new InvalidOperationException(string.Format("Unable to parse section[{0}] from sections[{1}]", array[2], stringBuilder));
		}
		if (array.Length <= 3)
		{
			return "/" + array[1];
		}
		return patch.path.Substring(array[1].Length + array[2].Length + 2);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00003684 File Offset: 0x00001884
	private static void ParsePlayerAddPatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		int index;
		string playerPathAndIndex = LobbyPatcher.GetPlayerPathAndIndex(patch, out index);
		if (playerPathAndIndex.StartsWith("/data"))
		{
			LobbyPatcher.ParseAddOrReplacePlayerData(index, patch, playerPathAndIndex, changes, true);
			return;
		}
		if (playerPathAndIndex == "/players")
		{
			LobbyPatcher.ParseAddPlayer(patch, index, changes);
			return;
		}
		if (!(playerPathAndIndex == "/connectionInfo"))
		{
			Logger.LogError(string.Concat(new string[]
			{
				"Not implemented add player patch with path[",
				playerPathAndIndex,
				"] from player patch[",
				patch.path,
				"]"
			}));
			return;
		}
		changes.PlayerConnectionInfoChange(index, (string)patch.value);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00003720 File Offset: 0x00001920
	private static void ParsePlayerReplacePatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		int index;
		string playerPathAndIndex = LobbyPatcher.GetPlayerPathAndIndex(patch, out index);
		if (playerPathAndIndex.StartsWith("/data"))
		{
			LobbyPatcher.ParseAddOrReplacePlayerData(index, patch, playerPathAndIndex, changes, false);
			return;
		}
		if (playerPathAndIndex == "/connectionInfo")
		{
			changes.PlayerConnectionInfoChange(index, (string)patch.value);
			return;
		}
		if (!(playerPathAndIndex == "/lastUpdated"))
		{
			Logger.LogError("Not implemented replace player patch with path[" + playerPathAndIndex + "]");
			return;
		}
		changes.PlayerLastUpdatedChange(index, (DateTime)patch.value);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000037A8 File Offset: 0x000019A8
	private static void ParsePlayerRemovePatch(LobbyPatcher.LobbyPatch patch, LobbyPatcherChanges changes)
	{
		int index;
		string playerPathAndIndex = LobbyPatcher.GetPlayerPathAndIndex(patch, out index);
		if (playerPathAndIndex.StartsWith("/data"))
		{
			LobbyPatcher.ParseRemovePlayerData(index, patch, playerPathAndIndex, changes);
			return;
		}
		if (playerPathAndIndex == "/players")
		{
			changes.PlayerLeftChange(index);
			return;
		}
		if (!(playerPathAndIndex == "/connectionInfo"))
		{
			Logger.LogError("Not implemented remove player patch with path[" + playerPathAndIndex + "]");
			return;
		}
		changes.PlayerConnectionInfoChange(index, null);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00003818 File Offset: 0x00001A18
	private static void ParseAddPlayer(LobbyPatcher.LobbyPatch patch, int index, LobbyPatcherChanges changes)
	{
		Player player = ((JObject)patch.value).ToObject<Player>();
		changes.PlayerJoinedChange(index, player);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00003840 File Offset: 0x00001A40
	private static void ParseAddOrReplacePlayerData(int index, LobbyPatcher.LobbyPatch patch, string path, LobbyPatcherChanges changes, bool isAdding = false)
	{
		if (path == "/data")
		{
			using (IEnumerator<KeyValuePair<string, JToken>> enumerator = ((JObject)patch.value).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, JToken> keyValuePair = enumerator.Current;
					if (isAdding)
					{
						changes.PlayerDataAdded(index, keyValuePair.Key, keyValuePair.Value.ToObject<PlayerDataObject>());
					}
					else
					{
						changes.PlayerDataChange(index, keyValuePair.Key, keyValuePair.Value.ToObject<PlayerDataObject>());
					}
				}
				return;
			}
		}
		string key = patch.path.Split('/', StringSplitOptions.None)[4];
		JObject jobject = (JObject)patch.value;
		if (isAdding)
		{
			changes.PlayerDataAdded(index, key, jobject.ToObject<PlayerDataObject>());
			return;
		}
		changes.PlayerDataChange(index, key, jobject.ToObject<PlayerDataObject>());
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00003910 File Offset: 0x00001B10
	private static void ParseRemovePlayerData(int index, LobbyPatcher.LobbyPatch patch, string path, LobbyPatcherChanges changes)
	{
		if (path == "/data")
		{
			changes.PlayerDataRemoveChange(index);
			return;
		}
		string key = path.Substring("/data/".Length);
		changes.PlayerDataRemoveChange(index, key);
	}

	// Token: 0x04000002 RID: 2
	private const int MaxPlayerCount = 150;

	// Token: 0x0200007C RID: 124
	internal class LobbyPatch
	{
		// Token: 0x06000361 RID: 865 RVA: 0x0000C458 File Offset: 0x0000A658
		[Preserve]
		public LobbyPatch()
		{
		}

		// Token: 0x04000197 RID: 407
		public string op;

		// Token: 0x04000198 RID: 408
		public string path;

		// Token: 0x04000199 RID: 409
		public object value;
	}

	// Token: 0x0200007D RID: 125
	internal class LobbyPatches
	{
		// Token: 0x06000362 RID: 866 RVA: 0x0000C460 File Offset: 0x0000A660
		[Preserve]
		public LobbyPatches()
		{
		}

		// Token: 0x0400019A RID: 410
		public int Version;

		// Token: 0x0400019B RID: 411
		public List<LobbyPatcher.LobbyPatch> Patches;
	}
}
