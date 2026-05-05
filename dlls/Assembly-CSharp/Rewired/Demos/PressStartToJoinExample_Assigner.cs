using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Demos
{
	// Token: 0x020002BD RID: 701
	[AddComponentMenu("")]
	public class PressStartToJoinExample_Assigner : MonoBehaviour
	{
		// Token: 0x06000EDB RID: 3803 RVA: 0x0004FC00 File Offset: 0x0004DE00
		public static Player GetRewiredPlayer(int gamePlayerId)
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			if (PressStartToJoinExample_Assigner.instance == null)
			{
				Debug.LogError("Not initialized. Do you have a PressStartToJoinPlayerSelector in your scehe?");
				return null;
			}
			for (int i = 0; i < PressStartToJoinExample_Assigner.instance.playerMap.Count; i++)
			{
				if (PressStartToJoinExample_Assigner.instance.playerMap[i].gamePlayerId == gamePlayerId)
				{
					return ReInput.players.GetPlayer(PressStartToJoinExample_Assigner.instance.playerMap[i].rewiredPlayerId);
				}
			}
			return null;
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x0004FC82 File Offset: 0x0004DE82
		private void Awake()
		{
			this.playerMap = new List<PressStartToJoinExample_Assigner.PlayerMap>();
			PressStartToJoinExample_Assigner.instance = this;
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x0004FC98 File Offset: 0x0004DE98
		private void Update()
		{
			for (int i = 0; i < ReInput.players.playerCount; i++)
			{
				if (ReInput.players.GetPlayer(i).GetButtonDown("JoinGame"))
				{
					this.AssignNextPlayer(i);
				}
			}
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x0004FCD8 File Offset: 0x0004DED8
		private void AssignNextPlayer(int rewiredPlayerId)
		{
			if (this.playerMap.Count >= this.maxPlayers)
			{
				Debug.LogError("Max player limit already reached!");
				return;
			}
			int nextGamePlayerId = this.GetNextGamePlayerId();
			this.playerMap.Add(new PressStartToJoinExample_Assigner.PlayerMap(rewiredPlayerId, nextGamePlayerId));
			Player player = ReInput.players.GetPlayer(rewiredPlayerId);
			player.controllers.maps.SetMapsEnabled(false, "Assignment");
			player.controllers.maps.SetMapsEnabled(true, "Default");
			Debug.Log("Added Rewired Player id " + rewiredPlayerId.ToString() + " to game player " + nextGamePlayerId.ToString());
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x0004FD78 File Offset: 0x0004DF78
		private int GetNextGamePlayerId()
		{
			int num = this.gamePlayerIdCounter;
			this.gamePlayerIdCounter = num + 1;
			return num;
		}

		// Token: 0x04001371 RID: 4977
		private static PressStartToJoinExample_Assigner instance;

		// Token: 0x04001372 RID: 4978
		public int maxPlayers = 4;

		// Token: 0x04001373 RID: 4979
		private List<PressStartToJoinExample_Assigner.PlayerMap> playerMap;

		// Token: 0x04001374 RID: 4980
		private int gamePlayerIdCounter;

		// Token: 0x020002BE RID: 702
		private class PlayerMap
		{
			// Token: 0x06000EE1 RID: 3809 RVA: 0x0004FDA5 File Offset: 0x0004DFA5
			public PlayerMap(int rewiredPlayerId, int gamePlayerId)
			{
				this.rewiredPlayerId = rewiredPlayerId;
				this.gamePlayerId = gamePlayerId;
			}

			// Token: 0x04001375 RID: 4981
			public int rewiredPlayerId;

			// Token: 0x04001376 RID: 4982
			public int gamePlayerId;
		}
	}
}
