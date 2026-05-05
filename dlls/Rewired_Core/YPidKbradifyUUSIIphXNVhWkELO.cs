using System;
using Rewired.Utils;
using Rewired.Utils.UI;
using UnityEngine;

// Token: 0x02000524 RID: 1316
internal static class YPidKbradifyUUSIIphXNVhWkELO
{
	// Token: 0x06003621 RID: 13857 RVA: 0x0002A66A File Offset: 0x0002886A
	public static Vector2 VjPWsfkbQHMGiOLqglYttcucudAy(RectTransform A_0, RectTransform A_1, Vector2 A_2)
	{
		return YPidKbradifyUUSIIphXNVhWkELO.KFzUjdTmIgTJmTtRKOgXoHkLUCJc(A_1, UnityTools.TransformPoint(A_0, A_1, A_2));
	}

	// Token: 0x06003622 RID: 13858 RVA: 0x000B65A0 File Offset: 0x000B47A0
	public static Vector2 PshLYKIAkBMcNzrbTbrqtuNigDTc(RectTransform A_0)
	{
		return YPidKbradifyUUSIIphXNVhWkELO.mhOZvBJcfCqKAmIKauBqUEtSGusT(A_0).center;
	}

	// Token: 0x06003623 RID: 13859 RVA: 0x000B65BC File Offset: 0x000B47BC
	public static Rect mhOZvBJcfCqKAmIKauBqUEtSGusT(RectTransform A_0)
	{
		Vector2 vector = Vector2.Scale(A_0.rect.size, A_0.lossyScale);
		Rect result = new Rect(A_0.position.x, (float)Screen.height - A_0.position.y, vector.x, vector.y);
		result.x -= A_0.pivot.x * vector.x;
		result.y -= (1f - A_0.pivot.y) * vector.y;
		return result;
	}

	// Token: 0x06003624 RID: 13860 RVA: 0x0002A67F File Offset: 0x0002887F
	public static Vector2 xRBGQSclFyFEitXSyqUxgVXMkDNz(Canvas A_0, RectTransform A_1, Vector2 A_2)
	{
		return YPidKbradifyUUSIIphXNVhWkELO.KFzUjdTmIgTJmTtRKOgXoHkLUCJc(A_1, YPidKbradifyUUSIIphXNVhWkELO.UBhQhaveBoLCAcNGtOVKQpekxHuE(A_0, A_1, A_2));
	}

	// Token: 0x06003625 RID: 13861 RVA: 0x000B6660 File Offset: 0x000B4860
	public static Vector2 UBhQhaveBoLCAcNGtOVKQpekxHuE(Canvas A_0, RectTransform A_1, Vector2 A_2)
	{
		Camera cam;
		if (A_0 == null || A_0.renderMode == RenderMode.ScreenSpaceOverlay)
		{
			cam = null;
		}
		else
		{
			cam = A_0.worldCamera;
		}
		Vector2 result;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(A_1, A_2, cam, out result);
		return result;
	}

	// Token: 0x06003626 RID: 13862 RVA: 0x0002A694 File Offset: 0x00028894
	public static Vector2 KFzUjdTmIgTJmTtRKOgXoHkLUCJc(RectTransform A_0, Vector3 A_1)
	{
		if (A_0 == null)
		{
			throw new ArgumentNullException("rectTransform");
		}
		return new Vector2(A_1.x, A_1.y) + YPidKbradifyUUSIIphXNVhWkELO.EoRcAsubjJvgXQyXNlLwAWifmhcn(A_0.rect, A_0.pivot);
	}

	// Token: 0x06003627 RID: 13863 RVA: 0x0002A6D1 File Offset: 0x000288D1
	private static Vector2 EoRcAsubjJvgXQyXNlLwAWifmhcn(Rect A_0, Vector2 A_1)
	{
		return new Vector2(A_0.width * A_1.x + A_0.xMin, A_0.height * A_1.y + A_0.yMin);
	}

	// Token: 0x06003628 RID: 13864 RVA: 0x000B6698 File Offset: 0x000B4898
	public static Vector3 FMCCakiREYuspTAFkFHwHJWBXmTdA(Transform A_0, PositionType A_1)
	{
		switch (A_1)
		{
		case PositionType.World:
			return (A_0 as RectTransform).position;
		case PositionType.Local:
			return (A_0 as RectTransform).localPosition;
		case PositionType.Anchored:
			return (A_0 as RectTransform).anchoredPosition;
		default:
			throw new NotImplementedException();
		}
	}

	// Token: 0x06003629 RID: 13865 RVA: 0x000B66E8 File Offset: 0x000B48E8
	public static void ModUCBJUUjSQBmryOcaxZotSMxyA(Transform A_0, Vector3 A_1, PositionType A_2)
	{
		switch (A_2)
		{
		case PositionType.World:
			(A_0 as RectTransform).position = A_1;
			return;
		case PositionType.Local:
			(A_0 as RectTransform).localPosition = A_1;
			return;
		case PositionType.Anchored:
			(A_0 as RectTransform).anchoredPosition = A_1;
			return;
		default:
			throw new NotImplementedException();
		}
	}
}
