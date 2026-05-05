using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x0200024A RID: 586
	public class TMP_UiFrameRateCounter : MonoBehaviour
	{
		// Token: 0x06000930 RID: 2352 RVA: 0x000407CC File Offset: 0x0003E9CC
		private void Awake()
		{
			if (!base.enabled)
			{
				return;
			}
			Application.targetFrameRate = 1000;
			GameObject gameObject = new GameObject("Frame Counter");
			this.m_frameCounter_transform = gameObject.AddComponent<RectTransform>();
			this.m_frameCounter_transform.SetParent(base.transform, false);
			this.m_TextMeshPro = gameObject.AddComponent<TextMeshProUGUI>();
			this.m_TextMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
			this.m_TextMeshPro.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Overlay");
			this.m_TextMeshPro.enableWordWrapping = false;
			this.m_TextMeshPro.fontSize = 36f;
			this.m_TextMeshPro.isOverlay = true;
			this.Set_FrameCounter_Position(this.AnchorPosition);
			this.last_AnchorPosition = this.AnchorPosition;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0004088B File Offset: 0x0003EA8B
		private void Start()
		{
			this.m_LastInterval = Time.realtimeSinceStartup;
			this.m_Frames = 0;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x000408A0 File Offset: 0x0003EAA0
		private void Update()
		{
			if (this.AnchorPosition != this.last_AnchorPosition)
			{
				this.Set_FrameCounter_Position(this.AnchorPosition);
			}
			this.last_AnchorPosition = this.AnchorPosition;
			this.m_Frames++;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (realtimeSinceStartup > this.m_LastInterval + this.UpdateInterval)
			{
				float num = (float)this.m_Frames / (realtimeSinceStartup - this.m_LastInterval);
				float arg = 1000f / Mathf.Max(num, 1E-05f);
				if (num < 30f)
				{
					this.htmlColorTag = "<color=yellow>";
				}
				else if (num < 10f)
				{
					this.htmlColorTag = "<color=red>";
				}
				else
				{
					this.htmlColorTag = "<color=green>";
				}
				this.m_TextMeshPro.SetText(this.htmlColorTag + "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS", num, arg);
				this.m_Frames = 0;
				this.m_LastInterval = realtimeSinceStartup;
			}
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00040980 File Offset: 0x0003EB80
		private void Set_FrameCounter_Position(TMP_UiFrameRateCounter.FpsCounterAnchorPositions anchor_position)
		{
			switch (anchor_position)
			{
			case TMP_UiFrameRateCounter.FpsCounterAnchorPositions.TopLeft:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.TopLeft;
				this.m_frameCounter_transform.pivot = new Vector2(0f, 1f);
				this.m_frameCounter_transform.anchorMin = new Vector2(0.01f, 0.99f);
				this.m_frameCounter_transform.anchorMax = new Vector2(0.01f, 0.99f);
				this.m_frameCounter_transform.anchoredPosition = new Vector2(0f, 1f);
				return;
			case TMP_UiFrameRateCounter.FpsCounterAnchorPositions.BottomLeft:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.BottomLeft;
				this.m_frameCounter_transform.pivot = new Vector2(0f, 0f);
				this.m_frameCounter_transform.anchorMin = new Vector2(0.01f, 0.01f);
				this.m_frameCounter_transform.anchorMax = new Vector2(0.01f, 0.01f);
				this.m_frameCounter_transform.anchoredPosition = new Vector2(0f, 0f);
				return;
			case TMP_UiFrameRateCounter.FpsCounterAnchorPositions.TopRight:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.TopRight;
				this.m_frameCounter_transform.pivot = new Vector2(1f, 1f);
				this.m_frameCounter_transform.anchorMin = new Vector2(0.99f, 0.99f);
				this.m_frameCounter_transform.anchorMax = new Vector2(0.99f, 0.99f);
				this.m_frameCounter_transform.anchoredPosition = new Vector2(1f, 1f);
				return;
			case TMP_UiFrameRateCounter.FpsCounterAnchorPositions.BottomRight:
				this.m_TextMeshPro.alignment = TextAlignmentOptions.BottomRight;
				this.m_frameCounter_transform.pivot = new Vector2(1f, 0f);
				this.m_frameCounter_transform.anchorMin = new Vector2(0.99f, 0.01f);
				this.m_frameCounter_transform.anchorMax = new Vector2(0.99f, 0.01f);
				this.m_frameCounter_transform.anchoredPosition = new Vector2(1f, 0f);
				return;
			default:
				return;
			}
		}

		// Token: 0x04000FAA RID: 4010
		public float UpdateInterval = 5f;

		// Token: 0x04000FAB RID: 4011
		private float m_LastInterval;

		// Token: 0x04000FAC RID: 4012
		private int m_Frames;

		// Token: 0x04000FAD RID: 4013
		public TMP_UiFrameRateCounter.FpsCounterAnchorPositions AnchorPosition = TMP_UiFrameRateCounter.FpsCounterAnchorPositions.TopRight;

		// Token: 0x04000FAE RID: 4014
		private string htmlColorTag;

		// Token: 0x04000FAF RID: 4015
		private const string fpsLabel = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS";

		// Token: 0x04000FB0 RID: 4016
		private TextMeshProUGUI m_TextMeshPro;

		// Token: 0x04000FB1 RID: 4017
		private RectTransform m_frameCounter_transform;

		// Token: 0x04000FB2 RID: 4018
		private TMP_UiFrameRateCounter.FpsCounterAnchorPositions last_AnchorPosition;

		// Token: 0x0200024B RID: 587
		public enum FpsCounterAnchorPositions
		{
			// Token: 0x04000FB4 RID: 4020
			TopLeft,
			// Token: 0x04000FB5 RID: 4021
			BottomLeft,
			// Token: 0x04000FB6 RID: 4022
			TopRight,
			// Token: 0x04000FB7 RID: 4023
			BottomRight
		}
	}
}
