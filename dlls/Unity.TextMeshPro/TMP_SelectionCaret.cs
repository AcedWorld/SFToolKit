using System;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	// Token: 0x0200004F RID: 79
	[RequireComponent(typeof(CanvasRenderer))]
	public class TMP_SelectionCaret : MaskableGraphic
	{
		// Token: 0x06000363 RID: 867 RVA: 0x00024B6C File Offset: 0x00022D6C
		public override void Cull(Rect clipRect, bool validRect)
		{
			if (validRect)
			{
				base.canvasRenderer.cull = false;
				CanvasUpdateRegistry.RegisterCanvasElementForGraphicRebuild(this);
				return;
			}
			base.Cull(clipRect, validRect);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00024B8C File Offset: 0x00022D8C
		protected override void UpdateGeometry()
		{
		}
	}
}
