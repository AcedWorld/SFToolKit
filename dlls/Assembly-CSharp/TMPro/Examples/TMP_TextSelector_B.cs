using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples
{
	// Token: 0x02000249 RID: 585
	public class TMP_TextSelector_B : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
	{
		// Token: 0x06000925 RID: 2341 RVA: 0x0003FBDC File Offset: 0x0003DDDC
		private void Awake()
		{
			this.m_TextMeshPro = base.gameObject.GetComponent<TextMeshProUGUI>();
			this.m_Canvas = base.gameObject.GetComponentInParent<Canvas>();
			if (this.m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				this.m_Camera = null;
			}
			else
			{
				this.m_Camera = this.m_Canvas.worldCamera;
			}
			this.m_TextPopup_RectTransform = Object.Instantiate<RectTransform>(this.TextPopup_Prefab_01);
			this.m_TextPopup_RectTransform.SetParent(this.m_Canvas.transform, false);
			this.m_TextPopup_TMPComponent = this.m_TextPopup_RectTransform.GetComponentInChildren<TextMeshProUGUI>();
			this.m_TextPopup_RectTransform.gameObject.SetActive(false);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0003FC7C File Offset: 0x0003DE7C
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0003FC94 File Offset: 0x0003DE94
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0003FCAC File Offset: 0x0003DEAC
		private void ON_TEXT_CHANGED(Object obj)
		{
			if (obj == this.m_TextMeshPro)
			{
				this.m_cachedMeshInfoVertexData = this.m_TextMeshPro.textInfo.CopyMeshInfoVertexData();
			}
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0003FCD4 File Offset: 0x0003DED4
		private void LateUpdate()
		{
			if (this.isHoveringObject)
			{
				int num = TMP_TextUtilities.FindIntersectingCharacter(this.m_TextMeshPro, Input.mousePosition, this.m_Camera, true);
				if (num == -1 || num != this.m_lastIndex)
				{
					this.RestoreCachedVertexAttributes(this.m_lastIndex);
					this.m_lastIndex = -1;
				}
				if (num != -1 && num != this.m_lastIndex && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
				{
					this.m_lastIndex = num;
					int materialReferenceIndex = this.m_TextMeshPro.textInfo.characterInfo[num].materialReferenceIndex;
					int vertexIndex = this.m_TextMeshPro.textInfo.characterInfo[num].vertexIndex;
					Vector3[] vertices = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].vertices;
					Vector3 b = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
					vertices[vertexIndex] -= b;
					vertices[vertexIndex + 1] = vertices[vertexIndex + 1] - b;
					vertices[vertexIndex + 2] = vertices[vertexIndex + 2] - b;
					vertices[vertexIndex + 3] = vertices[vertexIndex + 3] - b;
					float d = 1.5f;
					this.m_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * d);
					vertices[vertexIndex] = this.m_matrix.MultiplyPoint3x4(vertices[vertexIndex]);
					vertices[vertexIndex + 1] = this.m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
					vertices[vertexIndex + 2] = this.m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
					vertices[vertexIndex + 3] = this.m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);
					vertices[vertexIndex] += b;
					vertices[vertexIndex + 1] = vertices[vertexIndex + 1] + b;
					vertices[vertexIndex + 2] = vertices[vertexIndex + 2] + b;
					vertices[vertexIndex + 3] = vertices[vertexIndex + 3] + b;
					Color32 color = new Color32(byte.MaxValue, byte.MaxValue, 192, byte.MaxValue);
					Color32[] colors = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
					colors[vertexIndex] = color;
					colors[vertexIndex + 1] = color;
					colors[vertexIndex + 2] = color;
					colors[vertexIndex + 3] = color;
					TMP_MeshInfo tmp_MeshInfo = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex];
					int dst = vertices.Length - 4;
					tmp_MeshInfo.SwapVertexData(vertexIndex, dst);
					this.m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
				}
				int num2 = TMP_TextUtilities.FindIntersectingWord(this.m_TextMeshPro, Input.mousePosition, this.m_Camera);
				if (this.m_TextPopup_RectTransform != null && this.m_selectedWord != -1 && (num2 == -1 || num2 != this.m_selectedWord))
				{
					TMP_WordInfo tmp_WordInfo = this.m_TextMeshPro.textInfo.wordInfo[this.m_selectedWord];
					for (int i = 0; i < tmp_WordInfo.characterCount; i++)
					{
						int num3 = tmp_WordInfo.firstCharacterIndex + i;
						int materialReferenceIndex2 = this.m_TextMeshPro.textInfo.characterInfo[num3].materialReferenceIndex;
						int vertexIndex2 = this.m_TextMeshPro.textInfo.characterInfo[num3].vertexIndex;
						Color32[] colors2 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex2].colors32;
						Color32 color2 = colors2[vertexIndex2].Tint(1.33333f);
						colors2[vertexIndex2] = color2;
						colors2[vertexIndex2 + 1] = color2;
						colors2[vertexIndex2 + 2] = color2;
						colors2[vertexIndex2 + 3] = color2;
					}
					this.m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
					this.m_selectedWord = -1;
				}
				if (num2 != -1 && num2 != this.m_selectedWord && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
				{
					this.m_selectedWord = num2;
					TMP_WordInfo tmp_WordInfo2 = this.m_TextMeshPro.textInfo.wordInfo[num2];
					for (int j = 0; j < tmp_WordInfo2.characterCount; j++)
					{
						int num4 = tmp_WordInfo2.firstCharacterIndex + j;
						int materialReferenceIndex3 = this.m_TextMeshPro.textInfo.characterInfo[num4].materialReferenceIndex;
						int vertexIndex3 = this.m_TextMeshPro.textInfo.characterInfo[num4].vertexIndex;
						Color32[] colors3 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex3].colors32;
						Color32 color3 = colors3[vertexIndex3].Tint(0.75f);
						colors3[vertexIndex3] = color3;
						colors3[vertexIndex3 + 1] = color3;
						colors3[vertexIndex3 + 2] = color3;
						colors3[vertexIndex3 + 3] = color3;
					}
					this.m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
				}
				int num5 = TMP_TextUtilities.FindIntersectingLink(this.m_TextMeshPro, Input.mousePosition, this.m_Camera);
				if ((num5 == -1 && this.m_selectedLink != -1) || num5 != this.m_selectedLink)
				{
					this.m_TextPopup_RectTransform.gameObject.SetActive(false);
					this.m_selectedLink = -1;
				}
				if (num5 != -1 && num5 != this.m_selectedLink)
				{
					this.m_selectedLink = num5;
					TMP_LinkInfo tmp_LinkInfo = this.m_TextMeshPro.textInfo.linkInfo[num5];
					Vector3 position;
					RectTransformUtility.ScreenPointToWorldPointInRectangle(this.m_TextMeshPro.rectTransform, Input.mousePosition, this.m_Camera, out position);
					string linkID = tmp_LinkInfo.GetLinkID();
					if (linkID == "id_01")
					{
						this.m_TextPopup_RectTransform.position = position;
						this.m_TextPopup_RectTransform.gameObject.SetActive(true);
						this.m_TextPopup_TMPComponent.text = "You have selected link <#ffff00> ID 01";
						return;
					}
					if (!(linkID == "id_02"))
					{
						return;
					}
					this.m_TextPopup_RectTransform.position = position;
					this.m_TextPopup_RectTransform.gameObject.SetActive(true);
					this.m_TextPopup_TMPComponent.text = "You have selected link <#ffff00> ID 02";
					return;
				}
			}
			else if (this.m_lastIndex != -1)
			{
				this.RestoreCachedVertexAttributes(this.m_lastIndex);
				this.m_lastIndex = -1;
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00040398 File Offset: 0x0003E598
		public void OnPointerEnter(PointerEventData eventData)
		{
			this.isHoveringObject = true;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x000403A1 File Offset: 0x0003E5A1
		public void OnPointerExit(PointerEventData eventData)
		{
			this.isHoveringObject = false;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x000020BE File Offset: 0x000002BE
		public void OnPointerClick(PointerEventData eventData)
		{
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x000020BE File Offset: 0x000002BE
		public void OnPointerUp(PointerEventData eventData)
		{
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x000403AC File Offset: 0x0003E5AC
		private void RestoreCachedVertexAttributes(int index)
		{
			if (index == -1 || index > this.m_TextMeshPro.textInfo.characterCount - 1)
			{
				return;
			}
			int materialReferenceIndex = this.m_TextMeshPro.textInfo.characterInfo[index].materialReferenceIndex;
			int vertexIndex = this.m_TextMeshPro.textInfo.characterInfo[index].vertexIndex;
			Vector3[] vertices = this.m_cachedMeshInfoVertexData[materialReferenceIndex].vertices;
			Vector3[] vertices2 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].vertices;
			vertices2[vertexIndex] = vertices[vertexIndex];
			vertices2[vertexIndex + 1] = vertices[vertexIndex + 1];
			vertices2[vertexIndex + 2] = vertices[vertexIndex + 2];
			vertices2[vertexIndex + 3] = vertices[vertexIndex + 3];
			Color32[] colors = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
			Color32[] colors2 = this.m_cachedMeshInfoVertexData[materialReferenceIndex].colors32;
			colors[vertexIndex] = colors2[vertexIndex];
			colors[vertexIndex + 1] = colors2[vertexIndex + 1];
			colors[vertexIndex + 2] = colors2[vertexIndex + 2];
			colors[vertexIndex + 3] = colors2[vertexIndex + 3];
			Vector2[] uvs = this.m_cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
			Vector2[] uvs2 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs0;
			uvs2[vertexIndex] = uvs[vertexIndex];
			uvs2[vertexIndex + 1] = uvs[vertexIndex + 1];
			uvs2[vertexIndex + 2] = uvs[vertexIndex + 2];
			uvs2[vertexIndex + 3] = uvs[vertexIndex + 3];
			Vector2[] uvs3 = this.m_cachedMeshInfoVertexData[materialReferenceIndex].uvs2;
			Vector2[] uvs4 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs2;
			uvs4[vertexIndex] = uvs3[vertexIndex];
			uvs4[vertexIndex + 1] = uvs3[vertexIndex + 1];
			uvs4[vertexIndex + 2] = uvs3[vertexIndex + 2];
			uvs4[vertexIndex + 3] = uvs3[vertexIndex + 3];
			int num = (vertices.Length / 4 - 1) * 4;
			vertices2[num] = vertices[num];
			vertices2[num + 1] = vertices[num + 1];
			vertices2[num + 2] = vertices[num + 2];
			vertices2[num + 3] = vertices[num + 3];
			colors2 = this.m_cachedMeshInfoVertexData[materialReferenceIndex].colors32;
			Color32[] colors3 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
			colors3[num] = colors2[num];
			colors3[num + 1] = colors2[num + 1];
			colors3[num + 2] = colors2[num + 2];
			colors3[num + 3] = colors2[num + 3];
			uvs = this.m_cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
			Vector2[] uvs5 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs0;
			uvs5[num] = uvs[num];
			uvs5[num + 1] = uvs[num + 1];
			uvs5[num + 2] = uvs[num + 2];
			uvs5[num + 3] = uvs[num + 3];
			uvs3 = this.m_cachedMeshInfoVertexData[materialReferenceIndex].uvs2;
			Vector2[] uvs6 = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs2;
			uvs6[num] = uvs3[num];
			uvs6[num + 1] = uvs3[num + 1];
			uvs6[num + 2] = uvs3[num + 2];
			uvs6[num + 3] = uvs3[num + 3];
			this.m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
		}

		// Token: 0x04000F9C RID: 3996
		public RectTransform TextPopup_Prefab_01;

		// Token: 0x04000F9D RID: 3997
		private RectTransform m_TextPopup_RectTransform;

		// Token: 0x04000F9E RID: 3998
		private TextMeshProUGUI m_TextPopup_TMPComponent;

		// Token: 0x04000F9F RID: 3999
		private const string k_LinkText = "You have selected link <#ffff00>";

		// Token: 0x04000FA0 RID: 4000
		private const string k_WordText = "Word Index: <#ffff00>";

		// Token: 0x04000FA1 RID: 4001
		private TextMeshProUGUI m_TextMeshPro;

		// Token: 0x04000FA2 RID: 4002
		private Canvas m_Canvas;

		// Token: 0x04000FA3 RID: 4003
		private Camera m_Camera;

		// Token: 0x04000FA4 RID: 4004
		private bool isHoveringObject;

		// Token: 0x04000FA5 RID: 4005
		private int m_selectedWord = -1;

		// Token: 0x04000FA6 RID: 4006
		private int m_selectedLink = -1;

		// Token: 0x04000FA7 RID: 4007
		private int m_lastIndex = -1;

		// Token: 0x04000FA8 RID: 4008
		private Matrix4x4 m_matrix;

		// Token: 0x04000FA9 RID: 4009
		private TMP_MeshInfo[] m_cachedMeshInfoVertexData;
	}
}
