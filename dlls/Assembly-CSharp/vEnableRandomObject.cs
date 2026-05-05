using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
public class vEnableRandomObject : MonoBehaviour
{
	// Token: 0x06000100 RID: 256 RVA: 0x00009080 File Offset: 0x00007280
	protected void Awake()
	{
		if (this.enableOnStart)
		{
			this.EnableObject();
		}
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00009090 File Offset: 0x00007290
	public virtual void EnableObject()
	{
		int num = Random.Range(0, this.objects.Length * 10) & this.objects.Length - 1;
		for (int i = 0; i < this.objects.Length; i++)
		{
			this.objects[i].SetActive(i == num);
		}
	}

	// Token: 0x04000132 RID: 306
	public GameObject[] objects;

	// Token: 0x04000133 RID: 307
	public bool enableOnStart;
}
