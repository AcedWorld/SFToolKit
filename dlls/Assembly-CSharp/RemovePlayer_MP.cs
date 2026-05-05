using System;
using UnityEngine;

// Token: 0x02000090 RID: 144
public class RemovePlayer_MP : MonoBehaviour
{
	// Token: 0x06000264 RID: 612 RVA: 0x00014118 File Offset: 0x00012318
	public void RemoveThePlayer()
	{
		this.menuLogic.onLobbyHosted();
		if (this.player != null)
		{
			Object.Destroy(this.player);
		}
		GameObject gameObject = GameObject.Find("Character");
		if (gameObject != null)
		{
			Object.Destroy(gameObject);
		}
		GameObject gameObject2 = GameObject.Find("DroneParent");
		if (gameObject2 == null)
		{
			gameObject2 = GameObject.Find("DroneParent(Clone)");
		}
		if (gameObject2 != null)
		{
			Object.Destroy(gameObject2);
		}
		if (this.loadingPrefab != null)
		{
			Object.Instantiate<GameObject>(this.loadingPrefab).name = this.loadingPrefab.name;
		}
	}

	// Token: 0x0400030A RID: 778
	public GameObject player;

	// Token: 0x0400030B RID: 779
	public MenuLogic menuLogic;

	// Token: 0x0400030C RID: 780
	public GameObject loadingPrefab;
}
