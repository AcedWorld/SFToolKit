using System;

namespace UnityEngine.UI
{
	// Token: 0x02000044 RID: 68
	[AddComponentMenu("UI/Effects/Position As UV1", 82)]
	public class PositionAsUV1 : BaseMeshEffect
	{
		// Token: 0x060004B6 RID: 1206 RVA: 0x00016BA5 File Offset: 0x00014DA5
		protected PositionAsUV1()
		{
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00016BB0 File Offset: 0x00014DB0
		public override void ModifyMesh(VertexHelper vh)
		{
			UIVertex uivertex = default(UIVertex);
			for (int i = 0; i < vh.currentVertCount; i++)
			{
				vh.PopulateUIVertex(ref uivertex, i);
				uivertex.uv1 = new Vector2(uivertex.position.x, uivertex.position.y);
				vh.SetUIVertex(uivertex, i);
			}
		}
	}
}
