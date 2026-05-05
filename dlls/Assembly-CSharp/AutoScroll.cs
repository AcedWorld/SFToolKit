using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000123 RID: 291
[RequireComponent(typeof(ScrollRect))]
public class AutoScroll : MonoBehaviour
{
	// Token: 0x060004C1 RID: 1217 RVA: 0x000210C2 File Offset: 0x0001F2C2
	private void Awake()
	{
		this.m_ScrollRect = base.GetComponent<ScrollRect>();
		this.m_RectTransform = base.GetComponent<RectTransform>();
		this.m_ContentRectTransform = this.m_ScrollRect.content;
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x000210ED File Offset: 0x0001F2ED
	private void Update()
	{
		this.UpdateScrollToSelected();
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x000210F8 File Offset: 0x0001F2F8
	private void UpdateScrollToSelected()
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject == null)
		{
			return;
		}
		if (currentSelectedGameObject.transform.parent != this.m_ContentRectTransform.transform)
		{
			return;
		}
		this.m_SelectedRectTransform = currentSelectedGameObject.GetComponent<RectTransform>();
		Vector3 vector = this.m_RectTransform.localPosition - this.m_SelectedRectTransform.localPosition;
		float num = this.m_ContentRectTransform.rect.height - this.m_RectTransform.rect.height;
		float num2 = this.m_ContentRectTransform.rect.height - vector.y;
		float num3 = this.m_ScrollRect.normalizedPosition.y * num;
		float num4 = num3 - this.m_SelectedRectTransform.rect.height / 2f + this.m_RectTransform.rect.height;
		float num5 = num3 + this.m_SelectedRectTransform.rect.height / 2f;
		if (num2 > num4)
		{
			float num6 = num2 - num4;
			float y = (num3 + num6) / num;
			this.m_ScrollRect.normalizedPosition = Vector2.Lerp(this.m_ScrollRect.normalizedPosition, new Vector2(0f, y), this.scrollSpeed * Time.unscaledDeltaTime);
			return;
		}
		if (num2 < num5)
		{
			float num7 = num2 - num5;
			float y2 = (num3 + num7) / num;
			this.m_ScrollRect.normalizedPosition = Vector2.Lerp(this.m_ScrollRect.normalizedPosition, new Vector2(0f, y2), this.scrollSpeed * Time.unscaledDeltaTime);
		}
	}

	// Token: 0x04000721 RID: 1825
	public float scrollSpeed = 10f;

	// Token: 0x04000722 RID: 1826
	private ScrollRect m_ScrollRect;

	// Token: 0x04000723 RID: 1827
	private RectTransform m_RectTransform;

	// Token: 0x04000724 RID: 1828
	private RectTransform m_ContentRectTransform;

	// Token: 0x04000725 RID: 1829
	private RectTransform m_SelectedRectTransform;
}
