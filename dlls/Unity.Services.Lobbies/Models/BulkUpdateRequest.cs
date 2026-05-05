using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Unity.Services.Lobbies.Http;
using UnityEngine.Scripting;

namespace Unity.Services.Lobbies.Models
{
	// Token: 0x02000031 RID: 49
	[Preserve]
	[DataContract(Name = "BulkUpdateRequest")]
	internal class BulkUpdateRequest
	{
		// Token: 0x0600015A RID: 346 RVA: 0x00006459 File Offset: 0x00004659
		[Preserve]
		public BulkUpdateRequest(UpdateRequest lobbyUpdate = null, Dictionary<string, PlayerUpdateRequest> playerUpdates = null, List<Player> playersToAdd = null, List<string> playersToRemove = null, bool? ignoreIneffectualUpdates = false)
		{
			this.LobbyUpdate = lobbyUpdate;
			this.PlayerUpdates = playerUpdates;
			this.PlayersToAdd = playersToAdd;
			this.PlayersToRemove = playersToRemove;
			this.IgnoreIneffectualUpdates = ignoreIneffectualUpdates;
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00006486 File Offset: 0x00004686
		[Preserve]
		[JsonConverter(typeof(JsonObjectConverter))]
		[DataMember(Name = "lobbyUpdate", EmitDefaultValue = false)]
		public UpdateRequest LobbyUpdate { get; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600015C RID: 348 RVA: 0x0000648E File Offset: 0x0000468E
		[Preserve]
		[JsonConverter(typeof(JsonObjectCollectionConverter))]
		[DataMember(Name = "playerUpdates", EmitDefaultValue = false)]
		public Dictionary<string, PlayerUpdateRequest> PlayerUpdates { get; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00006496 File Offset: 0x00004696
		[Preserve]
		[DataMember(Name = "playersToAdd", EmitDefaultValue = false)]
		public List<Player> PlayersToAdd { get; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000649E File Offset: 0x0000469E
		[Preserve]
		[DataMember(Name = "playersToRemove", EmitDefaultValue = false)]
		public List<string> PlayersToRemove { get; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600015F RID: 351 RVA: 0x000064A6 File Offset: 0x000046A6
		[Preserve]
		[DataMember(Name = "ignoreIneffectualUpdates", EmitDefaultValue = true)]
		public bool? IgnoreIneffectualUpdates { get; }

		// Token: 0x06000160 RID: 352 RVA: 0x000064B0 File Offset: 0x000046B0
		internal string SerializeAsPathParam()
		{
			string text = "";
			if (this.LobbyUpdate != null)
			{
				text = text + "lobbyUpdate," + this.LobbyUpdate.ToString() + ",";
			}
			if (this.PlayerUpdates != null)
			{
				text = text + "playerUpdates," + this.PlayerUpdates.ToString() + ",";
			}
			if (this.PlayersToAdd != null)
			{
				text = text + "playersToAdd," + this.PlayersToAdd.ToString() + ",";
			}
			if (this.PlayersToRemove != null)
			{
				text = text + "playersToRemove," + this.PlayersToRemove.ToString() + ",";
			}
			if (this.IgnoreIneffectualUpdates != null)
			{
				text = text + "ignoreIneffectualUpdates," + this.IgnoreIneffectualUpdates.ToString();
			}
			return text;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00006584 File Offset: 0x00004784
		internal Dictionary<string, string> GetAsQueryParam()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.PlayersToRemove != null)
			{
				string value = this.PlayersToRemove.ToString();
				dictionary.Add("playersToRemove", value);
			}
			if (this.IgnoreIneffectualUpdates != null)
			{
				string value2 = this.IgnoreIneffectualUpdates.ToString();
				dictionary.Add("ignoreIneffectualUpdates", value2);
			}
			return dictionary;
		}
	}
}
