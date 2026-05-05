using System;
using System.Collections;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000232 RID: 562
	public class ShaderPropAnimator : MonoBehaviour
	{
		// Token: 0x060008C2 RID: 2242 RVA: 0x0003D6AC File Offset: 0x0003B8AC
		private void Awake()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
			this.m_Material = this.m_Renderer.material;
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0003D6CB File Offset: 0x0003B8CB
		private void Start()
		{
			base.StartCoroutine(this.AnimateProperties());
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0003D6DA File Offset: 0x0003B8DA
		private IEnumerator AnimateProperties()
		{
			this.m_frame = Random.Range(0f, 1f);
			for (;;)
			{
				float value = this.GlowCurve.Evaluate(this.m_frame);
				this.m_Material.SetFloat(ShaderUtilities.ID_GlowPower, value);
				this.m_frame += Time.deltaTime * Random.Range(0.2f, 0.3f);
				yield return new WaitForEndOfFrame();
			}
			yield break;
		}

		// Token: 0x04000F21 RID: 3873
		private Renderer m_Renderer;

		// Token: 0x04000F22 RID: 3874
		private Material m_Material;

		// Token: 0x04000F23 RID: 3875
		public AnimationCurve GlowCurve;

		// Token: 0x04000F24 RID: 3876
		public float m_frame;
	}
}
