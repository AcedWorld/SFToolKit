using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000131 RID: 305
	public class DebugUIHandlerPanel : MonoBehaviour
	{
		// Token: 0x06000912 RID: 2322 RVA: 0x00029C2F File Offset: 0x00027E2F
		private void OnEnable()
		{
			this.m_ScrollTransform = this.scrollRect.GetComponent<RectTransform>();
			this.m_ContentTransform = base.GetComponent<DebugUIHandlerContainer>().contentHolder;
			this.m_MaskTransform = base.GetComponentInChildren<Mask>(true).rectTransform;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00029C65 File Offset: 0x00027E65
		internal void SetPanel(DebugUI.Panel panel)
		{
			this.m_Panel = panel;
			this.nameLabel.text = panel.displayName;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00029C7F File Offset: 0x00027E7F
		internal DebugUI.Panel GetPanel()
		{
			return this.m_Panel;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00029C87 File Offset: 0x00027E87
		public void SelectNextItem()
		{
			this.Canvas.SelectNextPanel();
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00029C94 File Offset: 0x00027E94
		public void SelectPreviousItem()
		{
			this.Canvas.SelectPreviousPanel();
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00029CA1 File Offset: 0x00027EA1
		public void OnScrollbarClicked()
		{
			DebugManager.instance.SetScrollTarget(null);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00029CAE File Offset: 0x00027EAE
		internal void SetScrollTarget(DebugUIHandlerWidget target)
		{
			this.m_ScrollTarget = target;
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00029CB8 File Offset: 0x00027EB8
		internal void UpdateScroll()
		{
			if (this.m_ScrollTarget == null)
			{
				return;
			}
			RectTransform component = this.m_ScrollTarget.GetComponent<RectTransform>();
			float yposInScroll = this.GetYPosInScroll(component);
			float num = (this.GetYPosInScroll(this.m_MaskTransform) - yposInScroll) / (this.m_ContentTransform.rect.size.y - this.m_ScrollTransform.rect.size.y);
			float num2 = this.scrollRect.verticalNormalizedPosition - num;
			num2 = Mathf.Clamp01(num2);
			this.scrollRect.verticalNormalizedPosition = Mathf.Lerp(this.scrollRect.verticalNormalizedPosition, num2, Time.deltaTime * 10f);
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00029D68 File Offset: 0x00027F68
		private float GetYPosInScroll(RectTransform target)
		{
			Vector3 b = new Vector3((0.5f - target.pivot.x) * target.rect.size.x, (0.5f - target.pivot.y) * target.rect.size.y, 0f);
			Vector3 position = target.localPosition + b;
			Vector3 position2 = target.parent.TransformPoint(position);
			return this.m_ScrollTransform.TransformPoint(position2).y;
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00029DF6 File Offset: 0x00027FF6
		internal DebugUIHandlerWidget GetFirstItem()
		{
			return base.GetComponent<DebugUIHandlerContainer>().GetFirstItem();
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00029E03 File Offset: 0x00028003
		public void ResetDebugManager()
		{
			DebugManager.instance.Reset();
		}

		// Token: 0x04000551 RID: 1361
		public Text nameLabel;

		// Token: 0x04000552 RID: 1362
		public ScrollRect scrollRect;

		// Token: 0x04000553 RID: 1363
		public RectTransform viewport;

		// Token: 0x04000554 RID: 1364
		public DebugUIHandlerCanvas Canvas;

		// Token: 0x04000555 RID: 1365
		private RectTransform m_ScrollTransform;

		// Token: 0x04000556 RID: 1366
		private RectTransform m_ContentTransform;

		// Token: 0x04000557 RID: 1367
		private RectTransform m_MaskTransform;

		// Token: 0x04000558 RID: 1368
		private DebugUIHandlerWidget m_ScrollTarget;

		// Token: 0x04000559 RID: 1369
		protected internal DebugUI.Panel m_Panel;
	}
}
