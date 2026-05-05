using System;
using UnityEngine.TextCore.Text;

namespace UnityEngine.UIElements
{
	// Token: 0x02000326 RID: 806
	internal interface IStylePainter
	{
		// Token: 0x06001B3D RID: 6973
		MeshWriteData DrawMesh(int vertexCount, int indexCount, Texture texture, Material material, MeshGenerationContext.MeshFlags flags);

		// Token: 0x06001B3E RID: 6974
		void DrawText(TextElement te);

		// Token: 0x06001B3F RID: 6975
		void DrawText(string text, Vector2 pos, float fontSize, Color color, FontAsset font);

		// Token: 0x06001B40 RID: 6976
		void DrawRectangle(MeshGenerationContextUtils.RectangleParams rectParams);

		// Token: 0x06001B41 RID: 6977
		void DrawBorder(MeshGenerationContextUtils.BorderParams borderParams);

		// Token: 0x06001B42 RID: 6978
		void DrawImmediate(Action callback, bool cullingEnabled);

		// Token: 0x06001B43 RID: 6979
		void DrawVectorImage(VectorImage vectorImage, Vector2 pos, Angle rotationAngle, Vector2 scale);

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x06001B44 RID: 6980
		VisualElement visualElement { get; }
	}
}
