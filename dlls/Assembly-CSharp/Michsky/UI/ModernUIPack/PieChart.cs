using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x020002F3 RID: 755
	public class PieChart : MaskableGraphic
	{
		// Token: 0x06000FEF RID: 4079 RVA: 0x00054619 File Offset: 0x00052819
		protected override void Awake()
		{
			base.Awake();
			this.UpdateIndicators();
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x00054628 File Offset: 0x00052828
		private void Update()
		{
			this.borderThickness = Mathf.Clamp(this.borderThickness, -75f, base.rectTransform.rect.width / 3.333f);
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x00054668 File Offset: 0x00052868
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			if (this.chartData.Count == 0)
			{
				return;
			}
			float num = -base.rectTransform.pivot.x * base.rectTransform.rect.width;
			float num2 = -base.rectTransform.pivot.x * base.rectTransform.rect.width + this.borderThickness;
			float d = -base.rectTransform.pivot.x * base.rectTransform.rect.width * 0.6f;
			float d2 = -base.rectTransform.pivot.x * base.rectTransform.rect.width * 0.6f + this.borderThickness;
			vh.Clear();
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			Vector2 vector3 = new Vector2(0f, 0f);
			Vector2 vector4 = new Vector2(0f, 1f);
			Vector2 vector5 = new Vector2(1f, 1f);
			Vector2 vector6 = new Vector2(1f, 0f);
			float num3 = this.fillAmount;
			float num4 = 360f / (float)this.segments;
			int num5 = (int)((float)(this.segments + 1) * num3);
			int num6 = 0;
			float total = 0f;
			float num7 = this.chartData[0].value;
			this.chartData.ForEach(delegate(PieChart.PieChartDataNode s)
			{
				total += s.value;
			});
			Color32 color = this.chartData[0].color;
			for (int i = 0; i < num5; i++)
			{
				float f = 0.017453292f * ((float)i * num4);
				float num8 = Mathf.Cos(f);
				float num9 = Mathf.Sin(f);
				vector3 = new Vector2(0f, 1f);
				vector4 = new Vector2(1f, 1f);
				vector5 = new Vector2(1f, 0f);
				vector6 = new Vector2(0f, 0f);
				Vector2 vector7 = vector;
				Vector2 vector8 = new Vector2(num * num8, num * num9);
				Vector2 vector9 = new Vector2(num2 * num8, num2 * num9);
				Vector2 vector10 = vector2;
				if ((float)i > num7 / total * (float)this.segments && num6 < this.chartData.Count - 1)
				{
					num6++;
					num7 += this.chartData[num6].value;
					color = this.chartData[num6].color;
				}
				vh.AddUIVertexQuad(this.SetVbo(new Vector2[]
				{
					vector7,
					vector8,
					vector9 * d2 / num2,
					vector10 * d2 / num2
				}, new Vector2[]
				{
					vector3,
					vector4,
					vector5,
					vector6
				}, color));
				if (this.enableBorderColor)
				{
					vh.AddUIVertexQuad(this.SetVbo(new Vector2[]
					{
						vector7,
						vector8,
						vector9,
						vector10
					}, new Vector2[]
					{
						vector3,
						vector4,
						vector5,
						vector6
					}, this.borderColor));
					vh.AddUIVertexQuad(this.SetVbo(new Vector2[]
					{
						vector7 * d / num,
						vector8 * d / num,
						vector9 * d2 / num2,
						vector10 * d2 / num2
					}, new Vector2[]
					{
						vector3,
						vector4,
						vector5,
						vector6
					}, this.borderColor));
				}
				vector = vector8;
				vector2 = vector9;
			}
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x00054A94 File Offset: 0x00052C94
		public void SetData(List<PieChart.PieChartDataNode> data)
		{
			this.chartData = data;
			this.SetVerticesDirty();
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x00054AA4 File Offset: 0x00052CA4
		protected UIVertex[] SetVbo(Vector2[] vertices, Vector2[] uvs, Color32 color)
		{
			UIVertex[] array = new UIVertex[4];
			for (int i = 0; i < vertices.Length; i++)
			{
				UIVertex simpleVert = UIVertex.simpleVert;
				simpleVert.color = color;
				simpleVert.position = vertices[i];
				simpleVert.uv0 = uvs[i];
				array[i] = simpleVert;
			}
			return array;
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x00054B04 File Offset: 0x00052D04
		public void UpdateIndicators()
		{
			for (int i = 0; i < this.chartData.Count; i++)
			{
				if (this.chartData[i].indicatorImage != null)
				{
					this.chartData[i].indicatorImage.color = this.chartData[i].color;
				}
				if (this.chartData[i].indicatorText != null && this.addValueToIndicator)
				{
					this.chartData[i].indicatorText.text = this.chartData[i].name + this.valuePrefix + this.chartData[i].value.ToString() + this.valueSuffix;
				}
				else if (this.chartData[i].indicatorText != null && !this.addValueToIndicator)
				{
					this.chartData[i].indicatorText.text = this.chartData[i].name;
				}
			}
			if (this.indicatorParent != null)
			{
				base.StartCoroutine("UpdateIndicatorLayout");
			}
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x00054C45 File Offset: 0x00052E45
		public void ChangeValue(int itemIndex, float itemValue)
		{
			this.chartData[itemIndex].value = itemValue;
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x00054C5C File Offset: 0x00052E5C
		public void AddNewItem()
		{
			PieChart.PieChartDataNode item = new PieChart.PieChartDataNode();
			this.chartData.Add(item);
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x00054C7B File Offset: 0x00052E7B
		private IEnumerator UpdateIndicatorLayout()
		{
			yield return new WaitForSeconds(0.1f);
			LayoutRebuilder.ForceRebuildLayoutImmediate(this.indicatorParent.GetComponentInParent<RectTransform>());
			yield break;
		}

		// Token: 0x040014D9 RID: 5337
		[SerializeField]
		public List<PieChart.PieChartDataNode> chartData = new List<PieChart.PieChartDataNode>();

		// Token: 0x040014DA RID: 5338
		[Range(-75f, 150f)]
		public float borderThickness = 5f;

		// Token: 0x040014DB RID: 5339
		[SerializeField]
		private Color borderColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		// Token: 0x040014DC RID: 5340
		public Transform indicatorParent;

		// Token: 0x040014DD RID: 5341
		public string valuePrefix = "(";

		// Token: 0x040014DE RID: 5342
		public string valueSuffix = ")";

		// Token: 0x040014DF RID: 5343
		public bool addValueToIndicator = true;

		// Token: 0x040014E0 RID: 5344
		public bool enableBorderColor;

		// Token: 0x040014E1 RID: 5345
		private float fillAmount = 1f;

		// Token: 0x040014E2 RID: 5346
		private int segments = 720;

		// Token: 0x020002F4 RID: 756
		[Serializable]
		public class PieChartDataNode
		{
			// Token: 0x040014E3 RID: 5347
			public string name = "Chart Item";

			// Token: 0x040014E4 RID: 5348
			public float value = 10f;

			// Token: 0x040014E5 RID: 5349
			public Color32 color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

			// Token: 0x040014E6 RID: 5350
			public Image indicatorImage;

			// Token: 0x040014E7 RID: 5351
			public TextMeshProUGUI indicatorText;
		}
	}
}
