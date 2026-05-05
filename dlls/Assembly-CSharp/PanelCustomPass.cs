using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

// Token: 0x0200021B RID: 539
internal class PanelCustomPass : CustomPass
{
	// Token: 0x06000882 RID: 2178 RVA: 0x0003B7B8 File Offset: 0x000399B8
	protected override void Execute(CustomPassContext ctx)
	{
		if (this.material == null || this.uiPanel == null)
		{
			return;
		}
		Camera camera = ctx.hdCamera.camera;
		Vector3[] array = new Vector3[4];
		this.uiPanel.GetWorldCorners(array);
		Vector2[] array2 = new Vector2[4];
		for (int i = 0; i < 4; i++)
		{
			array2[i] = RectTransformUtility.WorldToScreenPoint(null, array[i]);
		}
		float num = Mathf.Min(new float[]
		{
			array2[0].x,
			array2[1].x,
			array2[2].x,
			array2[3].x
		});
		float num2 = Mathf.Max(new float[]
		{
			array2[0].x,
			array2[1].x,
			array2[2].x,
			array2[3].x
		});
		float num3 = Mathf.Min(new float[]
		{
			array2[0].y,
			array2[1].y,
			array2[2].y,
			array2[3].y
		});
		float num4 = Mathf.Max(new float[]
		{
			array2[0].y,
			array2[1].y,
			array2[2].y,
			array2[3].y
		});
		float a = num2 - num;
		float a2 = num4 - num3;
		float width = Mathf.Min(a, (float)camera.pixelWidth - num);
		float height = Mathf.Min(a2, (float)camera.pixelHeight - num3);
		float num5 = Mathf.Max(num, 0f);
		float num6 = Mathf.Max(num3, 0f);
		width = Mathf.Min(num2 - num5, (float)camera.pixelWidth - num5);
		height = Mathf.Min(num4 - num6, (float)camera.pixelHeight - num6);
		Rect scissor = new Rect(num5, num6, width, height);
		scissor.x = Mathf.Clamp(scissor.x, 0f, (float)camera.pixelWidth);
		scissor.y = Mathf.Clamp(scissor.y, 0f, (float)camera.pixelHeight);
		scissor.width = Mathf.Clamp(scissor.width, 0f, (float)camera.pixelWidth - scissor.x);
		scissor.height = Mathf.Clamp(scissor.height, 0f, (float)camera.pixelHeight - scissor.y);
		if (scissor.width <= 0f || scissor.height <= 0f)
		{
			return;
		}
		CommandBuffer cmd = ctx.cmd;
		cmd.EnableScissorRect(scissor);
		CoreUtils.DrawFullScreen(cmd, this.material, null, 0);
		cmd.DisableScissorRect();
	}

	// Token: 0x04000EB5 RID: 3765
	public Material material;

	// Token: 0x04000EB6 RID: 3766
	public RectTransform uiPanel;
}
