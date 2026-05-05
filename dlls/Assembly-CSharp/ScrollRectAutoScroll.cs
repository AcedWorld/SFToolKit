using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001C0 RID: 448
[RequireComponent(typeof(ScrollRect))]
public class ScrollRectAutoScroll : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	// Token: 0x060006F5 RID: 1781 RVA: 0x00033E6C File Offset: 0x0003206C
	private void OnEnable()
	{
		if (this.m_ScrollRect)
		{
			this.m_ScrollRect.content.GetComponentsInChildren<Selectable>(this.m_Selectables);
		}
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x00033E91 File Offset: 0x00032091
	private void Awake()
	{
		this.m_ScrollRect = base.GetComponent<ScrollRect>();
		this.rePlayer = ReInput.players.GetPlayer(this.RewiredPlayerID);
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x00033EB5 File Offset: 0x000320B5
	private void Start()
	{
		if (this.m_ScrollRect)
		{
			this.m_ScrollRect.content.GetComponentsInChildren<Selectable>(this.m_Selectables);
		}
		this.ScrollToSelected(true);
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x00033EE4 File Offset: 0x000320E4
	private void Update()
	{
		this.InputScroll();
		if (!this.mouseOver)
		{
			this.m_ScrollRect.normalizedPosition = Vector2.Lerp(this.m_ScrollRect.normalizedPosition, this.m_NextScrollPosition, this.scrollSpeed * Time.unscaledDeltaTime);
			return;
		}
		this.m_NextScrollPosition = this.m_ScrollRect.normalizedPosition;
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x00033F40 File Offset: 0x00032140
	private void InputScroll()
	{
		if (!this.vertical && this.m_Selectables.Count > 0 && this.rePlayer.GetAxis("UIHorizontal") != 0f)
		{
			this.ScrollToSelected(false);
		}
		if (this.vertical && this.m_Selectables.Count > 0 && this.rePlayer.GetAxis("UIVertical") != 0f)
		{
			this.ScrollToSelected(false);
		}
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x00033FB8 File Offset: 0x000321B8
	private void ScrollToSelected(bool quickScroll)
	{
		int num = -1;
		Selectable selectable = EventSystem.current.currentSelectedGameObject ? EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>() : null;
		if (selectable)
		{
			num = this.m_Selectables.IndexOf(selectable);
		}
		if (num > -1)
		{
			if (quickScroll)
			{
				this.m_ScrollRect.normalizedPosition = new Vector2(0f, 1f - (float)num / ((float)this.m_Selectables.Count - 1f));
				this.m_NextScrollPosition = this.m_ScrollRect.normalizedPosition;
				return;
			}
			this.m_NextScrollPosition = new Vector2(0f, 1f - (float)num / ((float)this.m_Selectables.Count - 1f));
		}
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x00034074 File Offset: 0x00032274
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.mouseOver = true;
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x0003407D File Offset: 0x0003227D
	public void OnPointerExit(PointerEventData eventData)
	{
		this.mouseOver = false;
		this.ScrollToSelected(false);
	}

	// Token: 0x04000C57 RID: 3159
	public bool vertical;

	// Token: 0x04000C58 RID: 3160
	public float scrollSpeed = 10f;

	// Token: 0x04000C59 RID: 3161
	private bool mouseOver;

	// Token: 0x04000C5A RID: 3162
	private List<Selectable> m_Selectables = new List<Selectable>();

	// Token: 0x04000C5B RID: 3163
	private ScrollRect m_ScrollRect;

	// Token: 0x04000C5C RID: 3164
	private Vector2 m_NextScrollPosition = Vector2.up;

	// Token: 0x04000C5D RID: 3165
	public int RewiredPlayerID;

	// Token: 0x04000C5E RID: 3166
	private Player rePlayer;
}
