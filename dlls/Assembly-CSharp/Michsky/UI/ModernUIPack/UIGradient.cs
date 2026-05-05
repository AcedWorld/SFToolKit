using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000316 RID: 790
	[AddComponentMenu("Modern UI Pack/Effects/UI Gradient")]
	public class UIGradient : BaseMeshEffect
	{
		// Token: 0x17000329 RID: 809
		// (get) Token: 0x0600107A RID: 4218 RVA: 0x00058097 File Offset: 0x00056297
		// (set) Token: 0x0600107B RID: 4219 RVA: 0x0005809F File Offset: 0x0005629F
		public UIGradient.Blend BlendMode
		{
			get
			{
				return this._blendMode;
			}
			set
			{
				this._blendMode = value;
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x0600107C RID: 4220 RVA: 0x000580B3 File Offset: 0x000562B3
		// (set) Token: 0x0600107D RID: 4221 RVA: 0x000580BB File Offset: 0x000562BB
		public Gradient EffectGradient
		{
			get
			{
				return this._effectGradient;
			}
			set
			{
				this._effectGradient = value;
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x0600107E RID: 4222 RVA: 0x000580CF File Offset: 0x000562CF
		// (set) Token: 0x0600107F RID: 4223 RVA: 0x000580D7 File Offset: 0x000562D7
		public UIGradient.Type GradientType
		{
			get
			{
				return this._gradientType;
			}
			set
			{
				this._gradientType = value;
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06001080 RID: 4224 RVA: 0x000580EB File Offset: 0x000562EB
		// (set) Token: 0x06001081 RID: 4225 RVA: 0x000580F3 File Offset: 0x000562F3
		public bool ModifyVertices
		{
			get
			{
				return this._modifyVertices;
			}
			set
			{
				this._modifyVertices = value;
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06001082 RID: 4226 RVA: 0x00058107 File Offset: 0x00056307
		// (set) Token: 0x06001083 RID: 4227 RVA: 0x0005810F File Offset: 0x0005630F
		public float Offset
		{
			get
			{
				return this._offset;
			}
			set
			{
				this._offset = Mathf.Clamp(value, -1f, 1f);
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06001084 RID: 4228 RVA: 0x00058132 File Offset: 0x00056332
		// (set) Token: 0x06001085 RID: 4229 RVA: 0x0005813A File Offset: 0x0005633A
		public float Zoom
		{
			get
			{
				return this._zoom;
			}
			set
			{
				this._zoom = Mathf.Clamp(value, 0.1f, 10f);
				base.graphic.SetVerticesDirty();
			}
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x00058160 File Offset: 0x00056360
		public override void ModifyMesh(VertexHelper helper)
		{
			if (!this.IsActive() || helper.currentVertCount == 0)
			{
				return;
			}
			List<UIVertex> list = new List<UIVertex>();
			helper.GetUIVertexStream(list);
			int count = list.Count;
			UIGradient.Type gradientType = this.GradientType;
			if (gradientType <= UIGradient.Type.Vertical)
			{
				Rect bounds = this.GetBounds(list);
				float num = bounds.xMin;
				float num2 = bounds.width;
				Func<UIVertex, float> func = (UIVertex v) => v.position.x;
				if (this.GradientType == UIGradient.Type.Vertical)
				{
					num = bounds.yMin;
					num2 = bounds.height;
					func = ((UIVertex v) => v.position.y);
				}
				float num3 = (num2 == 0f) ? 0f : (1f / num2 / this.Zoom);
				float num4 = (1f - 1f / this.Zoom) * 0.5f;
				float num5 = this.Offset * (1f - num4) - num4;
				if (this.ModifyVertices)
				{
					this.SplitTrianglesAtGradientStops(list, bounds, num4, helper);
				}
				UIVertex uivertex = default(UIVertex);
				for (int i = 0; i < helper.currentVertCount; i++)
				{
					helper.PopulateUIVertex(ref uivertex, i);
					uivertex.color = this.BlendColor(uivertex.color, this.EffectGradient.Evaluate((func(uivertex) - num) * num3 - num5));
					helper.SetUIVertex(uivertex, i);
				}
				return;
			}
			if (gradientType != UIGradient.Type.Diamond)
			{
				return;
			}
			Rect bounds2 = this.GetBounds(list);
			float num6 = (bounds2.height == 0f) ? 0f : (1f / bounds2.height / this.Zoom);
			float d = bounds2.center.y / 2f;
			Vector3 vector = (Vector3.right + Vector3.up) * d + Vector3.forward * list[0].position.z;
			if (this.ModifyVertices)
			{
				helper.Clear();
				for (int j = 0; j < count; j++)
				{
					helper.AddVert(list[j]);
				}
				helper.AddVert(new UIVertex
				{
					position = vector,
					normal = list[0].normal,
					uv0 = new Vector2(0.5f, 0.5f),
					color = Color.white
				});
				for (int k = 1; k < count; k++)
				{
					helper.AddTriangle(k - 1, k, count);
				}
				helper.AddTriangle(0, count - 1, count);
			}
			UIVertex uivertex2 = default(UIVertex);
			for (int l = 0; l < helper.currentVertCount; l++)
			{
				helper.PopulateUIVertex(ref uivertex2, l);
				uivertex2.color = this.BlendColor(uivertex2.color, this.EffectGradient.Evaluate(Vector3.Distance(uivertex2.position, vector) * num6 - this.Offset));
				helper.SetUIVertex(uivertex2, l);
			}
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x0005848C File Offset: 0x0005668C
		private Rect GetBounds(List<UIVertex> vertices)
		{
			float num = vertices[0].position.x;
			float num2 = num;
			float num3 = vertices[0].position.y;
			float num4 = num3;
			for (int i = vertices.Count - 1; i >= 1; i--)
			{
				float x = vertices[i].position.x;
				float y = vertices[i].position.y;
				if (x > num2)
				{
					num2 = x;
				}
				else if (x < num)
				{
					num = x;
				}
				if (y > num4)
				{
					num4 = y;
				}
				else if (y < num3)
				{
					num3 = y;
				}
			}
			return new Rect(num, num3, num2 - num, num4 - num3);
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x00058534 File Offset: 0x00056734
		private void SplitTrianglesAtGradientStops(List<UIVertex> _vertexList, Rect bounds, float zoomOffset, VertexHelper helper)
		{
			List<float> list = this.FindStops(zoomOffset, bounds);
			if (list.Count > 0)
			{
				helper.Clear();
				int count = _vertexList.Count;
				for (int i = 0; i < count; i += 3)
				{
					float[] positions = this.GetPositions(_vertexList, i);
					List<int> list2 = new List<int>(3);
					List<UIVertex> list3 = new List<UIVertex>(3);
					List<UIVertex> list4 = new List<UIVertex>(2);
					for (int j = 0; j < list.Count; j++)
					{
						int currentVertCount = helper.currentVertCount;
						bool flag = list4.Count > 0;
						bool flag2 = false;
						for (int k = 0; k < 3; k++)
						{
							if (!list2.Contains(k) && positions[k] < list[j])
							{
								int num = (k + 1) % 3;
								UIVertex item = _vertexList[k + i];
								if (positions[num] > list[j])
								{
									list2.Insert(0, k);
									list3.Insert(0, item);
									flag2 = true;
								}
								else
								{
									list2.Add(k);
									list3.Add(item);
								}
							}
						}
						if (list2.Count != 0)
						{
							if (list2.Count == 3)
							{
								break;
							}
							foreach (UIVertex v in list3)
							{
								helper.AddVert(v);
							}
							list4.Clear();
							foreach (int num2 in list2)
							{
								int num3 = (num2 + 1) % 3;
								if (positions[num3] < list[j])
								{
									num3 = (num3 + 1) % 3;
								}
								list4.Add(this.CreateSplitVertex(_vertexList[num2 + i], _vertexList[num3 + i], list[j]));
							}
							if (list4.Count == 1)
							{
								int num4 = (list2[0] + 2) % 3;
								list4.Add(this.CreateSplitVertex(_vertexList[list2[0] + i], _vertexList[num4 + i], list[j]));
							}
							foreach (UIVertex v2 in list4)
							{
								helper.AddVert(v2);
							}
							if (flag)
							{
								helper.AddTriangle(currentVertCount - 2, currentVertCount, currentVertCount + 1);
								helper.AddTriangle(currentVertCount - 2, currentVertCount + 1, currentVertCount - 1);
								if (list3.Count > 0)
								{
									if (flag2)
									{
										helper.AddTriangle(currentVertCount - 2, currentVertCount + 3, currentVertCount);
									}
									else
									{
										helper.AddTriangle(currentVertCount + 1, currentVertCount + 3, currentVertCount - 1);
									}
								}
							}
							else
							{
								int currentVertCount2 = helper.currentVertCount;
								helper.AddTriangle(currentVertCount, currentVertCount2 - 2, currentVertCount2 - 1);
								if (list3.Count > 1)
								{
									helper.AddTriangle(currentVertCount, currentVertCount2 - 1, currentVertCount + 1);
								}
							}
							list3.Clear();
						}
					}
					if (list4.Count > 0)
					{
						if (list3.Count == 0)
						{
							for (int l = 0; l < 3; l++)
							{
								if (!list2.Contains(l) && positions[l] > list[list.Count - 1])
								{
									int num5 = (l + 1) % 3;
									UIVertex item2 = _vertexList[l + i];
									if (positions[num5] > list[list.Count - 1])
									{
										list3.Insert(0, item2);
									}
									else
									{
										list3.Add(item2);
									}
								}
							}
						}
						foreach (UIVertex v3 in list3)
						{
							helper.AddVert(v3);
						}
						int currentVertCount3 = helper.currentVertCount;
						if (list3.Count > 1)
						{
							helper.AddTriangle(currentVertCount3 - 4, currentVertCount3 - 2, currentVertCount3 - 1);
							helper.AddTriangle(currentVertCount3 - 4, currentVertCount3 - 1, currentVertCount3 - 3);
						}
						else if (list3.Count > 0)
						{
							helper.AddTriangle(currentVertCount3 - 3, currentVertCount3 - 1, currentVertCount3 - 2);
						}
					}
					else
					{
						helper.AddVert(_vertexList[i]);
						helper.AddVert(_vertexList[i + 1]);
						helper.AddVert(_vertexList[i + 2]);
						int currentVertCount4 = helper.currentVertCount;
						helper.AddTriangle(currentVertCount4 - 3, currentVertCount4 - 2, currentVertCount4 - 1);
					}
				}
			}
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x000589B4 File Offset: 0x00056BB4
		private float[] GetPositions(List<UIVertex> _vertexList, int index)
		{
			float[] array = new float[3];
			if (this.GradientType == UIGradient.Type.Horizontal)
			{
				array[0] = _vertexList[index].position.x;
				array[1] = _vertexList[index + 1].position.x;
				array[2] = _vertexList[index + 2].position.x;
			}
			else
			{
				array[0] = _vertexList[index].position.y;
				array[1] = _vertexList[index + 1].position.y;
				array[2] = _vertexList[index + 2].position.y;
			}
			return array;
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x00058A54 File Offset: 0x00056C54
		private List<float> FindStops(float zoomOffset, Rect bounds)
		{
			List<float> list = new List<float>();
			float num = this.Offset * (1f - zoomOffset);
			float num2 = zoomOffset - num;
			float num3 = 1f - zoomOffset - num;
			foreach (GradientColorKey gradientColorKey in this.EffectGradient.colorKeys)
			{
				if (gradientColorKey.time >= num3)
				{
					break;
				}
				if (gradientColorKey.time > num2)
				{
					list.Add((gradientColorKey.time - num2) * this.Zoom);
				}
			}
			foreach (GradientAlphaKey gradientAlphaKey in this.EffectGradient.alphaKeys)
			{
				if (gradientAlphaKey.time >= num3)
				{
					break;
				}
				if (gradientAlphaKey.time > num2)
				{
					list.Add((gradientAlphaKey.time - num2) * this.Zoom);
				}
			}
			float num4 = bounds.xMin;
			float num5 = bounds.width;
			if (this.GradientType == UIGradient.Type.Vertical)
			{
				num4 = bounds.yMin;
				num5 = bounds.height;
			}
			list.Sort();
			for (int j = 0; j < list.Count; j++)
			{
				list[j] = list[j] * num5 + num4;
				if (j > 0 && Math.Abs(list[j] - list[j - 1]) < 2f)
				{
					list.RemoveAt(j);
					j--;
				}
			}
			return list;
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x00058BC0 File Offset: 0x00056DC0
		private UIVertex CreateSplitVertex(UIVertex vertex1, UIVertex vertex2, float stop)
		{
			if (this.GradientType == UIGradient.Type.Horizontal)
			{
				float num = vertex1.position.x - stop;
				float num2 = vertex1.position.x - vertex2.position.x;
				float num3 = vertex1.position.y - vertex2.position.y;
				float num4 = vertex1.uv0.x - vertex2.uv0.x;
				float num5 = vertex1.uv0.y - vertex2.uv0.y;
				float num6 = num / num2;
				float y = vertex1.position.y - num3 * num6;
				return new UIVertex
				{
					position = new Vector3(stop, y, vertex1.position.z),
					normal = vertex1.normal,
					uv0 = new Vector2(vertex1.uv0.x - num4 * num6, vertex1.uv0.y - num5 * num6),
					color = Color.white
				};
			}
			float num7 = vertex1.position.y - stop;
			float num8 = vertex1.position.y - vertex2.position.y;
			float num9 = vertex1.position.x - vertex2.position.x;
			float num10 = vertex1.uv0.x - vertex2.uv0.x;
			float num11 = vertex1.uv0.y - vertex2.uv0.y;
			float num12 = num7 / num8;
			float x = vertex1.position.x - num9 * num12;
			return new UIVertex
			{
				position = new Vector3(x, stop, vertex1.position.z),
				normal = vertex1.normal,
				uv0 = new Vector2(vertex1.uv0.x - num10 * num12, vertex1.uv0.y - num11 * num12),
				color = Color.white
			};
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x00058DD0 File Offset: 0x00056FD0
		private Color BlendColor(Color colorA, Color colorB)
		{
			UIGradient.Blend blendMode = this.BlendMode;
			if (blendMode == UIGradient.Blend.Add)
			{
				return colorA + colorB;
			}
			if (blendMode != UIGradient.Blend.Multiply)
			{
				return colorB;
			}
			return colorA * colorB;
		}

		// Token: 0x040015BB RID: 5563
		[SerializeField]
		private UIGradient.Type _gradientType;

		// Token: 0x040015BC RID: 5564
		[SerializeField]
		private UIGradient.Blend _blendMode = UIGradient.Blend.Multiply;

		// Token: 0x040015BD RID: 5565
		[SerializeField]
		private bool _modifyVertices = true;

		// Token: 0x040015BE RID: 5566
		[SerializeField]
		[Range(-1f, 1f)]
		private float _offset;

		// Token: 0x040015BF RID: 5567
		[SerializeField]
		[Range(0.1f, 10f)]
		private float _zoom = 1f;

		// Token: 0x040015C0 RID: 5568
		[SerializeField]
		private Gradient _effectGradient = new Gradient
		{
			colorKeys = new GradientColorKey[]
			{
				new GradientColorKey(Color.black, 0f),
				new GradientColorKey(Color.white, 1f)
			}
		};

		// Token: 0x02000317 RID: 791
		public enum Type
		{
			// Token: 0x040015C2 RID: 5570
			Horizontal,
			// Token: 0x040015C3 RID: 5571
			Vertical,
			// Token: 0x040015C4 RID: 5572
			Diamond
		}

		// Token: 0x02000318 RID: 792
		public enum Blend
		{
			// Token: 0x040015C6 RID: 5574
			Override,
			// Token: 0x040015C7 RID: 5575
			Add,
			// Token: 0x040015C8 RID: 5576
			Multiply
		}
	}
}
