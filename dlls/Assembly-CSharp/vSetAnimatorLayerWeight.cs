using System;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class vSetAnimatorLayerWeight : MonoBehaviour
{
	// Token: 0x06000103 RID: 259 RVA: 0x000090DE File Offset: 0x000072DE
	private void Start()
	{
		base.GetComponent<Animator>().SetLayerWeight(this.animatorLayerIndex, this.value);
	}

	// Token: 0x04000134 RID: 308
	[Range(0f, 1f)]
	public float value;

	// Token: 0x04000135 RID: 309
	public int animatorLayerIndex;
}
