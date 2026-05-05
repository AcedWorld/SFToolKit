using System;
using Unity.Profiling;
using UnityEngine.TextCore.Text;

namespace UnityEngine.UIElements
{
	// Token: 0x020002B0 RID: 688
	public class MeshGenerationContext
	{
		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x060013C2 RID: 5058 RVA: 0x0004625C File Offset: 0x0004445C
		public VisualElement visualElement
		{
			get
			{
				return this.painter.visualElement;
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x060013C3 RID: 5059 RVA: 0x0004627C File Offset: 0x0004447C
		public Painter2D painter2D
		{
			get
			{
				bool flag = this.m_Painter2D == null;
				if (flag)
				{
					this.m_Painter2D = new Painter2D(this);
				}
				return this.m_Painter2D;
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x060013C4 RID: 5060 RVA: 0x000462AD File Offset: 0x000444AD
		internal bool hasPainter2D
		{
			get
			{
				return this.m_Painter2D != null;
			}
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x000462B8 File Offset: 0x000444B8
		internal MeshGenerationContext(IStylePainter painter)
		{
			this.painter = painter;
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x000462CC File Offset: 0x000444CC
		public MeshWriteData Allocate(int vertexCount, int indexCount, Texture texture = null)
		{
			MeshWriteData result;
			using (MeshGenerationContext.s_AllocateMarker.Auto())
			{
				result = this.painter.DrawMesh(vertexCount, indexCount, texture, null, MeshGenerationContext.MeshFlags.None);
			}
			return result;
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x0004631C File Offset: 0x0004451C
		internal MeshWriteData Allocate(int vertexCount, int indexCount, Texture texture, Material material, MeshGenerationContext.MeshFlags flags)
		{
			MeshWriteData result;
			using (MeshGenerationContext.s_AllocateMarker.Auto())
			{
				result = this.painter.DrawMesh(vertexCount, indexCount, texture, material, flags);
			}
			return result;
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x00046370 File Offset: 0x00044570
		public void DrawVectorImage(VectorImage vectorImage, Vector2 offset, Angle rotationAngle, Vector2 scale)
		{
			using (MeshGenerationContext.s_DrawVectorImageMarker.Auto())
			{
				this.painter.DrawVectorImage(vectorImage, offset, rotationAngle, scale);
			}
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x000463C0 File Offset: 0x000445C0
		public void DrawText(string text, Vector2 pos, float fontSize, Color color, FontAsset font = null)
		{
			bool flag = font == null;
			if (flag)
			{
				font = TextUtilities.GetFontAsset(this.visualElement);
			}
			this.painter.DrawText(text, pos, fontSize, color, font);
		}

		// Token: 0x04000937 RID: 2359
		private Painter2D m_Painter2D;

		// Token: 0x04000938 RID: 2360
		private static readonly ProfilerMarker s_AllocateMarker = new ProfilerMarker("UIR.MeshGenerationContext.Allocate");

		// Token: 0x04000939 RID: 2361
		private static readonly ProfilerMarker s_DrawVectorImageMarker = new ProfilerMarker("UIR.MeshGenerationContext.DrawVectorImage");

		// Token: 0x0400093A RID: 2362
		internal IStylePainter painter;

		// Token: 0x020002B1 RID: 689
		[Flags]
		internal enum MeshFlags
		{
			// Token: 0x0400093C RID: 2364
			None = 0,
			// Token: 0x0400093D RID: 2365
			UVisDisplacement = 1,
			// Token: 0x0400093E RID: 2366
			SkipDynamicAtlas = 2
		}
	}
}
