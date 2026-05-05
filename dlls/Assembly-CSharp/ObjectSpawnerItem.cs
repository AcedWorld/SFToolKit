using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class ObjectSpawnerItem : MonoBehaviour
{
	// Token: 0x060002CD RID: 717 RVA: 0x00016605 File Offset: 0x00014805
	private void Start()
	{
		this.object_Spawner = GameObject.Find("Object_Spawner");
		this.objectSpawner = this.object_Spawner.GetComponent<ObjectSpawner>();
	}

	// Token: 0x060002CE RID: 718 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}

	// Token: 0x060002CF RID: 719 RVA: 0x00016628 File Offset: 0x00014828
	private void OnTriggerEnter(Collider other)
	{
		foreach (MeshRenderer meshRenderer in this.meshRenderers)
		{
			meshRenderer.material = this.nonPlacable;
		}
		this.objectSpawner.clearToSpawn = false;
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x0001668C File Offset: 0x0001488C
	private void OnTriggerExit(Collider other)
	{
		foreach (MeshRenderer meshRenderer in this.meshRenderers)
		{
			meshRenderer.material = this.placable;
		}
		this.objectSpawner.clearToSpawn = true;
	}

	// Token: 0x0400038A RID: 906
	public GameObject object_Spawner;

	// Token: 0x0400038B RID: 907
	public ObjectSpawner objectSpawner;

	// Token: 0x0400038C RID: 908
	public Material placable;

	// Token: 0x0400038D RID: 909
	public Material nonPlacable;

	// Token: 0x0400038E RID: 910
	public List<MeshRenderer> meshRenderers;
}
