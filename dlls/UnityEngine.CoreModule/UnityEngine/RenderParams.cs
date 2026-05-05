using System;
using UnityEngine.Rendering;

namespace UnityEngine
{
	// Token: 0x02000158 RID: 344
	public struct RenderParams
	{
		// Token: 0x06000AE3 RID: 2787 RVA: 0x000119BC File Offset: 0x0000FBBC
		public RenderParams(Material mat)
		{
			this.layer = 0;
			this.renderingLayerMask = GraphicsSettings.defaultRenderingLayerMask;
			this.rendererPriority = 0;
			this.worldBounds = new Bounds(Vector3.zero, Vector3.zero);
			this.camera = null;
			this.motionVectorMode = MotionVectorGenerationMode.Camera;
			this.reflectionProbeUsage = ReflectionProbeUsage.Off;
			this.material = mat;
			this.matProps = null;
			this.shadowCastingMode = ShadowCastingMode.Off;
			this.receiveShadows = false;
			this.lightProbeUsage = LightProbeUsage.Off;
			this.lightProbeProxyVolume = null;
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x00011A44 File Offset: 0x0000FC44
		// (set) Token: 0x06000AE5 RID: 2789 RVA: 0x00011A4C File Offset: 0x0000FC4C
		public int layer { readonly get; set; }

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x00011A55 File Offset: 0x0000FC55
		// (set) Token: 0x06000AE7 RID: 2791 RVA: 0x00011A5D File Offset: 0x0000FC5D
		public uint renderingLayerMask { readonly get; set; }

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x00011A66 File Offset: 0x0000FC66
		// (set) Token: 0x06000AE9 RID: 2793 RVA: 0x00011A6E File Offset: 0x0000FC6E
		public int rendererPriority { readonly get; set; }

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x00011A77 File Offset: 0x0000FC77
		// (set) Token: 0x06000AEB RID: 2795 RVA: 0x00011A7F File Offset: 0x0000FC7F
		public Bounds worldBounds { readonly get; set; }

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x00011A88 File Offset: 0x0000FC88
		// (set) Token: 0x06000AED RID: 2797 RVA: 0x00011A90 File Offset: 0x0000FC90
		public Camera camera { readonly get; set; }

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x00011A99 File Offset: 0x0000FC99
		// (set) Token: 0x06000AEF RID: 2799 RVA: 0x00011AA1 File Offset: 0x0000FCA1
		public MotionVectorGenerationMode motionVectorMode { readonly get; set; }

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x00011AAA File Offset: 0x0000FCAA
		// (set) Token: 0x06000AF1 RID: 2801 RVA: 0x00011AB2 File Offset: 0x0000FCB2
		public ReflectionProbeUsage reflectionProbeUsage { readonly get; set; }

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x00011ABB File Offset: 0x0000FCBB
		// (set) Token: 0x06000AF3 RID: 2803 RVA: 0x00011AC3 File Offset: 0x0000FCC3
		public Material material { readonly get; set; }

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x00011ACC File Offset: 0x0000FCCC
		// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x00011AD4 File Offset: 0x0000FCD4
		public MaterialPropertyBlock matProps { readonly get; set; }

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x00011ADD File Offset: 0x0000FCDD
		// (set) Token: 0x06000AF7 RID: 2807 RVA: 0x00011AE5 File Offset: 0x0000FCE5
		public ShadowCastingMode shadowCastingMode { readonly get; set; }

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x00011AEE File Offset: 0x0000FCEE
		// (set) Token: 0x06000AF9 RID: 2809 RVA: 0x00011AF6 File Offset: 0x0000FCF6
		public bool receiveShadows { readonly get; set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x00011AFF File Offset: 0x0000FCFF
		// (set) Token: 0x06000AFB RID: 2811 RVA: 0x00011B07 File Offset: 0x0000FD07
		public LightProbeUsage lightProbeUsage { readonly get; set; }

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x00011B10 File Offset: 0x0000FD10
		// (set) Token: 0x06000AFD RID: 2813 RVA: 0x00011B18 File Offset: 0x0000FD18
		public LightProbeProxyVolume lightProbeProxyVolume { readonly get; set; }
	}
}
