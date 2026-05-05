using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000F9 RID: 249
public class LocateSpawnPoint : MonoBehaviour
{
	// Token: 0x06000412 RID: 1042 RVA: 0x0001D6E4 File Offset: 0x0001B8E4
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		this.modmapBrain = GameObject.Find("ModMap_Brain");
		this.modmapbrainScript = this.modmapBrain.GetComponent<ModmapBrain>();
		this.modmapName = this.modmapbrainScript.modMapSelected;
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x0001D724 File Offset: 0x0001B924
	private void Update()
	{
		if (this.searchingForSpawnpoint && GameObject.Find("ModMap_Spawnpoint") != null)
		{
			Debug.Log("SpawnPoint");
			this.spawnPoint = GameObject.Find("ModMap_Spawnpoint");
			this.StartLevel();
			this.searchingForSpawnpoint = false;
			this.myLoadedAssetBundle = this.modmapbrainScript.myLoadedAssetBundle;
		}
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0001D784 File Offset: 0x0001B984
	public void StartLevel()
	{
		if (this.player == null)
		{
			Object.Instantiate<GameObject>(this.playerComponents, this.spawnPoint.transform.position, this.spawnPoint.transform.rotation);
			this.player = this.playerComponents;
			this.drone = GameObject.Find("ModMapFreeCam");
			this.modMapFreeCam = this.drone.GetComponent<ModMapFreeCam>();
			this.modMapFreeCam.modMapLoaded = true;
			base.StartCoroutine(this.delay());
		}
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0001D811 File Offset: 0x0001BA11
	private IEnumerator delay()
	{
		yield return new WaitForSecondsRealtime(1f);
		this.unloadAssetBundle();
		yield return new WaitForSecondsRealtime(1f);
		this.DeleteThis();
		yield break;
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0001D820 File Offset: 0x0001BA20
	public void unloadAssetBundle()
	{
		Debug.Log("Assetbundle Unloaded");
		this.myLoadedAssetBundle.Unload(false);
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0001D838 File Offset: 0x0001BA38
	public void DeleteThis()
	{
		Debug.Log("Spawner Removed");
		Object.Destroy(base.gameObject);
	}

	// Token: 0x04000609 RID: 1545
	public GameObject spawnPoint;

	// Token: 0x0400060A RID: 1546
	public GameObject playerComponents;

	// Token: 0x0400060B RID: 1547
	public bool searchingForSpawnpoint;

	// Token: 0x0400060C RID: 1548
	private GameObject modmapBrain;

	// Token: 0x0400060D RID: 1549
	private ModmapBrain modmapbrainScript;

	// Token: 0x0400060E RID: 1550
	public AssetBundle myLoadedAssetBundle;

	// Token: 0x0400060F RID: 1551
	public string modmapName;

	// Token: 0x04000610 RID: 1552
	private GameObject player;

	// Token: 0x04000611 RID: 1553
	private GameObject drone;

	// Token: 0x04000612 RID: 1554
	private ModMapFreeCam modMapFreeCam;
}
