using System;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace TMPro.Examples
{
	// Token: 0x0200022B RID: 555
	public class Benchmark03 : MonoBehaviour
	{
		// Token: 0x060008B5 RID: 2229 RVA: 0x000020BE File Offset: 0x000002BE
		private void Awake()
		{
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x0003C9B4 File Offset: 0x0003ABB4
		private void Start()
		{
			TMP_FontAsset tmp_FontAsset = null;
			switch (this.Benchmark)
			{
			case Benchmark03.BenchmarkType.TMP_SDF_MOBILE:
				tmp_FontAsset = TMP_FontAsset.CreateFontAsset(this.SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic, true);
				break;
			case Benchmark03.BenchmarkType.TMP_SDF__MOBILE_SSD:
				tmp_FontAsset = TMP_FontAsset.CreateFontAsset(this.SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic, true);
				tmp_FontAsset.material.shader = Shader.Find("TextMeshPro/Mobile/Distance Field SSD");
				break;
			case Benchmark03.BenchmarkType.TMP_SDF:
				tmp_FontAsset = TMP_FontAsset.CreateFontAsset(this.SourceFont, 90, 9, GlyphRenderMode.SDFAA, 256, 256, AtlasPopulationMode.Dynamic, true);
				tmp_FontAsset.material.shader = Shader.Find("TextMeshPro/Distance Field");
				break;
			case Benchmark03.BenchmarkType.TMP_BITMAP_MOBILE:
				tmp_FontAsset = TMP_FontAsset.CreateFontAsset(this.SourceFont, 90, 9, GlyphRenderMode.SMOOTH, 256, 256, AtlasPopulationMode.Dynamic, true);
				break;
			}
			for (int i = 0; i < this.NumberOfSamples; i++)
			{
				Benchmark03.BenchmarkType benchmark = this.Benchmark;
				if (benchmark > Benchmark03.BenchmarkType.TMP_BITMAP_MOBILE)
				{
					if (benchmark == Benchmark03.BenchmarkType.TEXTMESH_BITMAP)
					{
						TextMesh textMesh = new GameObject
						{
							transform = 
							{
								position = new Vector3(0f, 1.2f, 0f)
							}
						}.AddComponent<TextMesh>();
						textMesh.GetComponent<Renderer>().sharedMaterial = this.SourceFont.material;
						textMesh.font = this.SourceFont;
						textMesh.anchor = TextAnchor.MiddleCenter;
						textMesh.fontSize = 130;
						textMesh.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
						textMesh.text = "@";
					}
				}
				else
				{
					TextMeshPro textMeshPro = new GameObject
					{
						transform = 
						{
							position = new Vector3(0f, 1.2f, 0f)
						}
					}.AddComponent<TextMeshPro>();
					textMeshPro.font = tmp_FontAsset;
					textMeshPro.fontSize = 128f;
					textMeshPro.text = "@";
					textMeshPro.alignment = TextAlignmentOptions.Center;
					textMeshPro.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
					if (this.Benchmark == Benchmark03.BenchmarkType.TMP_BITMAP_MOBILE)
					{
						textMeshPro.fontSize = 132f;
					}
				}
			}
		}

		// Token: 0x04000EE8 RID: 3816
		public int NumberOfSamples = 100;

		// Token: 0x04000EE9 RID: 3817
		public Benchmark03.BenchmarkType Benchmark;

		// Token: 0x04000EEA RID: 3818
		public Font SourceFont;

		// Token: 0x0200022C RID: 556
		public enum BenchmarkType
		{
			// Token: 0x04000EEC RID: 3820
			TMP_SDF_MOBILE,
			// Token: 0x04000EED RID: 3821
			TMP_SDF__MOBILE_SSD,
			// Token: 0x04000EEE RID: 3822
			TMP_SDF,
			// Token: 0x04000EEF RID: 3823
			TMP_BITMAP_MOBILE,
			// Token: 0x04000EF0 RID: 3824
			TEXTMESH_BITMAP
		}
	}
}
