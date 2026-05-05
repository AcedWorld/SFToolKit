using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000332 RID: 818
	public class vCullingFadeControl : MonoBehaviour
	{
		// Token: 0x17000336 RID: 822
		// (get) Token: 0x060010E5 RID: 4325 RVA: 0x0005B662 File Offset: 0x00059862
		public Transform targetObject
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x060010E6 RID: 4326 RVA: 0x0005B66C File Offset: 0x0005986C
		public Transform cameraTransform
		{
			get
			{
				Transform transform = base.transform;
				if (Camera.main != null)
				{
					transform = Camera.main.transform;
				}
				if (transform == base.transform)
				{
					Debug.LogWarning("Invector : Missing MainCamera");
					base.enabled = false;
				}
				return transform;
			}
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x0005B6B8 File Offset: 0x000598B8
		private void Start()
		{
			this.Init();
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0005B6C0 File Offset: 0x000598C0
		public void Init()
		{
			foreach (FadeMaterials fadeMaterials in this.fadeMeshRenderers)
			{
				fadeMaterials.originalAlpha = new float[fadeMaterials.originalMaterials.Length];
				int i = 0;
				while (i < fadeMaterials.originalMaterials.Length)
				{
					if (fadeMaterials.fadeMaterials[i] == null)
					{
						try
						{
							fadeMaterials.originalAlpha[i] = fadeMaterials.originalMaterials[i].color.a;
							fadeMaterials.fadeMaterials[i] = fadeMaterials.originalMaterials[i];
							goto IL_8F;
						}
						catch
						{
							goto IL_8F;
						}
						goto IL_6F;
					}
					goto IL_6F;
					IL_8F:
					i++;
					continue;
					IL_6F:
					try
					{
						fadeMaterials.originalAlpha[i] = fadeMaterials.fadeMaterials[i].color.a;
					}
					catch
					{
					}
					goto IL_8F;
				}
			}
			foreach (FadeMaterials fadeMaterials2 in this.fadeSkinnedMeshRenderes)
			{
				fadeMaterials2.originalAlpha = new float[fadeMaterials2.originalMaterials.Length];
				int j = 0;
				while (j < fadeMaterials2.originalMaterials.Length)
				{
					if (fadeMaterials2.fadeMaterials[j] == null)
					{
						try
						{
							fadeMaterials2.originalAlpha[j] = fadeMaterials2.originalMaterials[j].color.a;
							fadeMaterials2.fadeMaterials[j] = fadeMaterials2.originalMaterials[j];
							goto IL_151;
						}
						catch
						{
							goto IL_151;
						}
						goto IL_12F;
					}
					goto IL_12F;
					IL_151:
					j++;
					continue;
					IL_12F:
					try
					{
						fadeMaterials2.originalAlpha[j] = fadeMaterials2.fadeMaterials[j].color.a;
					}
					catch
					{
					}
					goto IL_151;
				}
			}
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x0005B898 File Offset: 0x00059A98
		private void LateUpdate()
		{
			this.UpdateEffect();
			if (this.usingTransp)
			{
				this.ChangeAlphaFromDistance();
			}
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0005B8B0 File Offset: 0x00059AB0
		private void UpdateEffect()
		{
			float num = Vector3.Distance(this.cameraTransform.position, this.targetObject.position + this.offset);
			if (num < this.distanceToStartFade && !this.usingTransp)
			{
				this.usingTransp = true;
				this.ChangeMaterialsToFade();
				return;
			}
			if (this.usingTransp && num > this.distanceToStartFade)
			{
				this.usingTransp = false;
				this.ChangeMaterialsToOriginal();
			}
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0005B924 File Offset: 0x00059B24
		private void ChangeMaterialsToOriginal()
		{
			foreach (FadeMaterials fadeMaterials in this.fadeMeshRenderers)
			{
				try
				{
					fadeMaterials.renderer.sharedMaterials = fadeMaterials.originalMaterials;
				}
				catch
				{
				}
			}
			foreach (FadeMaterials fadeMaterials2 in this.fadeSkinnedMeshRenderes)
			{
				try
				{
					fadeMaterials2.renderer.sharedMaterials = fadeMaterials2.originalMaterials;
				}
				catch
				{
				}
			}
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0005B9F0 File Offset: 0x00059BF0
		private void ChangeMaterialsToFade()
		{
			foreach (FadeMaterials fadeMaterials in this.fadeMeshRenderers)
			{
				try
				{
					fadeMaterials.renderer.sharedMaterials = fadeMaterials.fadeMaterials;
				}
				catch
				{
				}
			}
			foreach (FadeMaterials fadeMaterials2 in this.fadeSkinnedMeshRenderes)
			{
				try
				{
					fadeMaterials2.renderer.sharedMaterials = fadeMaterials2.fadeMaterials;
				}
				catch
				{
				}
			}
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0005BABC File Offset: 0x00059CBC
		public void ChangeAlphaFromDistance()
		{
			float num = Vector3.Distance(this.cameraTransform.position, this.targetObject.position + this.offset);
			for (int i = 0; i < this.fadeMeshRenderers.Count; i++)
			{
				for (int j = 0; j < this.fadeMeshRenderers[i].fadeMaterials.Length; j++)
				{
					try
					{
						float num2 = this.fadeMeshRenderers[i].originalAlpha[j] / (this.distanceToStartFade - this.distanceToEndFade);
						Color color = this.fadeMeshRenderers[i].renderer.sharedMaterials[j].color;
						float num3 = this.distanceToStartFade - this.distanceToEndFade - (this.distanceToStartFade - num);
						color.a = num2 * num3;
						color.a = Mathf.Clamp(color.a, 0f, this.fadeMeshRenderers[i].originalAlpha[j]);
						this.fadeMeshRenderers[i].renderer.materials[j].color = color;
					}
					catch
					{
					}
				}
			}
			for (int k = 0; k < this.fadeSkinnedMeshRenderes.Count; k++)
			{
				for (int l = 0; l < this.fadeSkinnedMeshRenderes[k].fadeMaterials.Length; l++)
				{
					try
					{
						float num4 = this.fadeSkinnedMeshRenderes[k].originalAlpha[l] / (this.distanceToStartFade - this.distanceToEndFade);
						Color color2 = this.fadeSkinnedMeshRenderes[k].renderer.sharedMaterials[l].color;
						float num5 = this.distanceToStartFade - this.distanceToEndFade - (this.distanceToStartFade - num);
						color2.a = num4 * num5;
						color2.a = Mathf.Clamp(color2.a, 0f, this.fadeSkinnedMeshRenderes[k].originalAlpha[l]);
						this.fadeSkinnedMeshRenderes[k].renderer.materials[l].color = color2;
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x040016B0 RID: 5808
		public float distanceToStartFade = 0.55f;

		// Token: 0x040016B1 RID: 5809
		public float distanceToEndFade = 0.4f;

		// Token: 0x040016B2 RID: 5810
		public Vector3 offset = new Vector3(0f, 1.3f, 0f);

		// Token: 0x040016B3 RID: 5811
		public List<FadeMaterials> fadeMeshRenderers;

		// Token: 0x040016B4 RID: 5812
		public List<FadeMaterials> fadeSkinnedMeshRenderes;

		// Token: 0x040016B5 RID: 5813
		public bool usingTransp;
	}
}
