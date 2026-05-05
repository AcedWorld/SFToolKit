using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class WaterSample : MonoBehaviour
{
	// Token: 0x06000078 RID: 120 RVA: 0x00007470 File Offset: 0x00005670
	private void Start()
	{
		this.r = base.GetComponent<Renderer>();
		if (this.r)
		{
			this.mat = this.r.sharedMaterial;
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x0000749C File Offset: 0x0000569C
	private void Update()
	{
		if (!this.r)
		{
			return;
		}
		if (!this.mat)
		{
			return;
		}
		Vector4 vector = this.mat.GetVector("WaveSpeed");
		float @float = this.mat.GetFloat("_WaveScale");
		float num = Time.time / 20f;
		Vector4 vector2 = vector * (num * @float);
		Vector4 value = new Vector4(Mathf.Repeat(vector2.x, 1f), Mathf.Repeat(vector2.y, 1f), Mathf.Repeat(vector2.z, 1f), Mathf.Repeat(vector2.w, 1f));
		this.mat.SetVector("_WaveOffset", value);
	}

	// Token: 0x040000BB RID: 187
	private Renderer r;

	// Token: 0x040000BC RID: 188
	private Material mat;
}
