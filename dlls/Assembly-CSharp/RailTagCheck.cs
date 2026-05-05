using System;
using UnityEngine;

// Token: 0x020001A8 RID: 424
public class RailTagCheck : MonoBehaviour
{
	// Token: 0x060006A6 RID: 1702 RVA: 0x00032376 File Offset: 0x00030576
	private void Start()
	{
		this.Rails = GameObject.FindGameObjectsWithTag("Rail");
		this.Coping = GameObject.FindGameObjectsWithTag("Coping");
		this.ChangeObjectLayer();
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x000323A0 File Offset: 0x000305A0
	private void ChangeObjectLayer()
	{
		GameObject[] array = this.Rails;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].layer = base.gameObject.layer;
		}
		foreach (GameObject gameObject in this.Coping)
		{
		}
	}

	// Token: 0x04000B9C RID: 2972
	public GameObject[] Rails;

	// Token: 0x04000B9D RID: 2973
	public GameObject[] Coping;
}
