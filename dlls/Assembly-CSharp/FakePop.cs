using System;
using TMPro;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class FakePop : MonoBehaviour
{
	// Token: 0x0600001E RID: 30 RVA: 0x000027D4 File Offset: 0x000009D4
	public void AddDummyLobby()
	{
		if (this.listParent == null || this.lobbyButtonPrefab == null)
		{
			Debug.LogWarning("[FakePop] Assign listParent and lobbyButtonPrefab.");
			return;
		}
		string text = (this.scenePool.Length != 0) ? this.scenePool[Random.Range(0, this.scenePool.Length)] : "Scene";
		string text2 = string.Format("Host_{0}", Random.Range(1000, 9999));
		int num = Random.Range(this.playerRange.x, this.playerRange.y + 1);
		string text3 = (this.regions.Length != 0) ? this.regions[Random.Range(0, this.regions.Length)] : "UNK";
		string location = (this.locations.Length != 0) ? this.locations[Random.Range(0, this.locations.Length)] : "UNK";
		int num2 = Random.Range(this.pingRange.x, this.pingRange.y + 1);
		GameObject gameObject = Object.Instantiate<GameObject>(this.lobbyButtonPrefab, this.listParent);
		MPMapButton component = gameObject.GetComponent<MPMapButton>();
		if (component != null)
		{
			LobbyInfoViewer info = new LobbyInfoViewer
			{
				sceneName = text,
				steamName = text2,
				lobbyId = Guid.NewGuid().ToString(),
				playerCount = string.Format("{0}/8", num),
				region = text3,
				location = location,
				pingMs = num2
			};
			component.Initialize(info);
		}
		else
		{
			TMP_Text componentInChildren = gameObject.GetComponentInChildren<TMP_Text>();
			if (componentInChildren != null)
			{
				componentInChildren.text = string.Format("{0}  •  {1}  •  {2}/8  •  {3}  •  {4}ms", new object[]
				{
					text,
					text2,
					num,
					text3,
					num2
				});
			}
		}
		Debug.Log(string.Format("[FakePop] Added dummy lobby: {0} | {1} | {2}/8 | {3} | {4}ms", new object[]
		{
			text,
			text2,
			num,
			text3,
			num2
		}));
	}

	// Token: 0x0400002C RID: 44
	[Header("Targets")]
	public Transform listParent;

	// Token: 0x0400002D RID: 45
	public GameObject lobbyButtonPrefab;

	// Token: 0x0400002E RID: 46
	[Header("Random Sources")]
	public string[] scenePool = new string[]
	{
		"Miniramp",
		"Street",
		"MegaPark",
		"Vert",
		"Plaza"
	};

	// Token: 0x0400002F RID: 47
	public string[] regions = new string[]
	{
		"OCE",
		"SEA",
		"USW",
		"USE",
		"EU",
		"ASIA"
	};

	// Token: 0x04000030 RID: 48
	public string[] locations = new string[]
	{
		"Auckland",
		"Sydney",
		"Tokyo",
		"Los Angeles",
		"Singapore",
		"Paris"
	};

	// Token: 0x04000031 RID: 49
	[Header("Ping / Players")]
	public Vector2Int pingRange = new Vector2Int(20, 300);

	// Token: 0x04000032 RID: 50
	public Vector2Int playerRange = new Vector2Int(1, 8);
}
