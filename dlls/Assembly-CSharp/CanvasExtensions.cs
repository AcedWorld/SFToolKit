using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
public static class CanvasExtensions
{
	// Token: 0x060000F7 RID: 247 RVA: 0x00008DD4 File Offset: 0x00006FD4
	public static Vector2 WorldToCanvas(this Canvas canvas, Vector3 world_position, Camera camera = null)
	{
		if (camera == null)
		{
			camera = Camera.main;
		}
		Vector3 vector = camera.WorldToViewportPoint(world_position);
		RectTransform component = canvas.GetComponent<RectTransform>();
		return new Vector2(vector.x * component.sizeDelta.x - component.sizeDelta.x * 0.5f, vector.y * component.sizeDelta.y - component.sizeDelta.y * 0.5f);
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00008E50 File Offset: 0x00007050
	public static Vector2 ClampInsideRectagle(this Vector2 pos, RectTransform container, Vector2 margin)
	{
		Vector2 vector = pos;
		vector.x = Mathf.Clamp(vector.x, -container.rect.width / 2f + margin.x, container.rect.width / 2f - margin.x);
		vector.y = Mathf.Clamp(vector.y, -container.rect.height / 2f + margin.y, container.rect.height / 2f - margin.y);
		return vector;
	}
}
