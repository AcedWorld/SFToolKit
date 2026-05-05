using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000114 RID: 276
public class Laptop : MonoBehaviour
{
	// Token: 0x06000477 RID: 1143 RVA: 0x0001EAF0 File Offset: 0x0001CCF0
	private void Start()
	{
		this.meshRenderer = base.GetComponent<MeshRenderer>();
		if (this.changeScreen)
		{
			this.ApplyNewScreen();
		}
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x0001EB0C File Offset: 0x0001CD0C
	private void Update()
	{
		this.RGBController();
		if (Input.GetKeyUp(this.keyCode) && this.changeScreen)
		{
			this.ApplyNewScreen();
		}
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x0001EB30 File Offset: 0x0001CD30
	private void ApplyNewScreen()
	{
		if (this.screenTextures.Count > 0)
		{
			int index = Random.Range(0, this.screenTextures.Count);
			Texture value = this.screenTextures[index];
			Material material = this.meshRenderer.materials[1];
			material.SetTexture("_BaseColorMap", value);
			material.SetTexture("_EmissiveColorMap", value);
			material.SetColor("_EmissiveColor", Color.white * this.Emission);
			material.EnableKeyword("_EMISSIVE_COLOR");
		}
	}

	// Token: 0x0600047A RID: 1146 RVA: 0x0001EBB4 File Offset: 0x0001CDB4
	private void RGBController()
	{
		Color a = new Color(Mathf.PingPong(Time.time * 0.5f, 1f), Mathf.PingPong(Time.time * 0.3f, 1f), Mathf.PingPong(Time.time * 0.7f, 1f));
		Material material = this.meshRenderer.materials[0];
		Color value = a * this.Emission;
		material.SetColor("_EmissiveColor", value);
		material.EnableKeyword("_EMISSION");
		material.EnableKeyword("_EMISSIVE_COLOR");
	}

	// Token: 0x040006B6 RID: 1718
	public bool changeScreen;

	// Token: 0x040006B7 RID: 1719
	private MeshRenderer meshRenderer;

	// Token: 0x040006B8 RID: 1720
	public List<Texture> screenTextures;

	// Token: 0x040006B9 RID: 1721
	public float Emission;

	// Token: 0x040006BA RID: 1722
	public KeyCode keyCode;
}
