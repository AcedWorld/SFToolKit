using System;
using System.Linq;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class Tf01 : MonoBehaviour
{
	// Token: 0x06000082 RID: 130 RVA: 0x00007A98 File Offset: 0x00005C98
	public Transform[] getTF01()
	{
		if (!this.tested)
		{
			this.tf01 = (from g in Object.FindObjectsOfType(typeof(Transform))
			select g as Transform into g
			where g.name.Equals("TF-01")
			select g).ToArray<Transform>();
		}
		this.tested = true;
		return this.tf01;
	}

	// Token: 0x040000C3 RID: 195
	public Transform[] tf01;

	// Token: 0x040000C4 RID: 196
	private bool tested;
}
