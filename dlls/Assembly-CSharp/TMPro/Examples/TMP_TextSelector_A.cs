using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples
{
	// Token: 0x02000248 RID: 584
	public class TMP_TextSelector_A : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x06000920 RID: 2336 RVA: 0x0003F808 File Offset: 0x0003DA08
		private void Awake()
		{
			this.m_TextMeshPro = base.gameObject.GetComponent<TextMeshPro>();
			this.m_Camera = Camera.main;
			this.m_TextMeshPro.ForceMeshUpdate(false, false);
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0003F834 File Offset: 0x0003DA34
		private void LateUpdate()
		{
			this.m_isHoveringObject = false;
			if (TMP_TextUtilities.IsIntersectingRectTransform(this.m_TextMeshPro.rectTransform, Input.mousePosition, Camera.main))
			{
				this.m_isHoveringObject = true;
			}
			if (this.m_isHoveringObject)
			{
				int num = TMP_TextUtilities.FindIntersectingCharacter(this.m_TextMeshPro, Input.mousePosition, Camera.main, true);
				if (num != -1 && num != this.m_lastCharIndex && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
				{
					this.m_lastCharIndex = num;
					int materialReferenceIndex = this.m_TextMeshPro.textInfo.characterInfo[num].materialReferenceIndex;
					int vertexIndex = this.m_TextMeshPro.textInfo.characterInfo[num].vertexIndex;
					Color32 color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
					Color32[] colors = this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
					colors[vertexIndex] = color;
					colors[vertexIndex + 1] = color;
					colors[vertexIndex + 2] = color;
					colors[vertexIndex + 3] = color;
					this.m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].mesh.colors32 = colors;
				}
				int num2 = TMP_TextUtilities.FindIntersectingLink(this.m_TextMeshPro, Input.mousePosition, this.m_Camera);
				if ((num2 == -1 && this.m_selectedLink != -1) || num2 != this.m_selectedLink)
				{
					this.m_selectedLink = -1;
				}
				if (num2 != -1 && num2 != this.m_selectedLink)
				{
					this.m_selectedLink = num2;
					TMP_LinkInfo tmp_LinkInfo = this.m_TextMeshPro.textInfo.linkInfo[num2];
					Vector3 vector;
					RectTransformUtility.ScreenPointToWorldPointInRectangle(this.m_TextMeshPro.rectTransform, Input.mousePosition, this.m_Camera, out vector);
					string linkID = tmp_LinkInfo.GetLinkID();
					if (!(linkID == "id_01"))
					{
						linkID == "id_02";
					}
				}
				int num3 = TMP_TextUtilities.FindIntersectingWord(this.m_TextMeshPro, Input.mousePosition, Camera.main);
				if (num3 != -1 && num3 != this.m_lastWordIndex)
				{
					this.m_lastWordIndex = num3;
					TMP_WordInfo tmp_WordInfo = this.m_TextMeshPro.textInfo.wordInfo[num3];
					Vector3 position = this.m_TextMeshPro.transform.TransformPoint(this.m_TextMeshPro.textInfo.characterInfo[tmp_WordInfo.firstCharacterIndex].bottomLeft);
					position = Camera.main.WorldToScreenPoint(position);
					Color32[] colors2 = this.m_TextMeshPro.textInfo.meshInfo[0].colors32;
					Color32 color2 = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
					for (int i = 0; i < tmp_WordInfo.characterCount; i++)
					{
						int vertexIndex2 = this.m_TextMeshPro.textInfo.characterInfo[tmp_WordInfo.firstCharacterIndex + i].vertexIndex;
						colors2[vertexIndex2] = color2;
						colors2[vertexIndex2 + 1] = color2;
						colors2[vertexIndex2 + 2] = color2;
						colors2[vertexIndex2 + 3] = color2;
					}
					this.m_TextMeshPro.mesh.colors32 = colors2;
				}
			}
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0003FB99 File Offset: 0x0003DD99
		public void OnPointerEnter(PointerEventData eventData)
		{
			Debug.Log("OnPointerEnter()");
			this.m_isHoveringObject = true;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0003FBAC File Offset: 0x0003DDAC
		public void OnPointerExit(PointerEventData eventData)
		{
			Debug.Log("OnPointerExit()");
			this.m_isHoveringObject = false;
		}

		// Token: 0x04000F96 RID: 3990
		private TextMeshPro m_TextMeshPro;

		// Token: 0x04000F97 RID: 3991
		private Camera m_Camera;

		// Token: 0x04000F98 RID: 3992
		private bool m_isHoveringObject;

		// Token: 0x04000F99 RID: 3993
		private int m_selectedLink = -1;

		// Token: 0x04000F9A RID: 3994
		private int m_lastCharIndex = -1;

		// Token: 0x04000F9B RID: 3995
		private int m_lastWordIndex = -1;
	}
}
