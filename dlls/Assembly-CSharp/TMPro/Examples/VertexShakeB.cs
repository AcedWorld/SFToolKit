using System;
using System.Collections;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000253 RID: 595
	public class VertexShakeB : MonoBehaviour
	{
		// Token: 0x06000959 RID: 2393 RVA: 0x00041886 File Offset: 0x0003FA86
		private void Awake()
		{
			this.m_TextComponent = base.GetComponent<TMP_Text>();
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00041894 File Offset: 0x0003FA94
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x000418AC File Offset: 0x0003FAAC
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x000418C4 File Offset: 0x0003FAC4
		private void Start()
		{
			base.StartCoroutine(this.AnimateVertexColors());
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x000418D3 File Offset: 0x0003FAD3
		private void ON_TEXT_CHANGED(Object obj)
		{
			if (this.m_TextComponent)
			{
				this.hasTextChanged = true;
			}
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x000418EC File Offset: 0x0003FAEC
		private IEnumerator AnimateVertexColors()
		{
			this.m_TextComponent.ForceMeshUpdate(false, false);
			TMP_TextInfo textInfo = this.m_TextComponent.textInfo;
			Vector3[][] copyOfVertices = new Vector3[0][];
			this.hasTextChanged = true;
			for (;;)
			{
				if (this.hasTextChanged)
				{
					if (copyOfVertices.Length < textInfo.meshInfo.Length)
					{
						copyOfVertices = new Vector3[textInfo.meshInfo.Length][];
					}
					for (int i = 0; i < textInfo.meshInfo.Length; i++)
					{
						int num = textInfo.meshInfo[i].vertices.Length;
						copyOfVertices[i] = new Vector3[num];
					}
					this.hasTextChanged = false;
				}
				if (textInfo.characterCount == 0)
				{
					yield return new WaitForSeconds(0.25f);
				}
				else
				{
					int lineCount = textInfo.lineCount;
					for (int j = 0; j < lineCount; j++)
					{
						int firstCharacterIndex = textInfo.lineInfo[j].firstCharacterIndex;
						int lastCharacterIndex = textInfo.lineInfo[j].lastCharacterIndex;
						Vector3 b = (textInfo.characterInfo[firstCharacterIndex].bottomLeft + textInfo.characterInfo[lastCharacterIndex].topRight) / 2f;
						Quaternion q = Quaternion.Euler(0f, 0f, Random.Range(-0.25f, 0.25f));
						for (int k = firstCharacterIndex; k <= lastCharacterIndex; k++)
						{
							if (textInfo.characterInfo[k].isVisible)
							{
								int materialReferenceIndex = textInfo.characterInfo[k].materialReferenceIndex;
								int vertexIndex = textInfo.characterInfo[k].vertexIndex;
								Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
								Vector3 b2 = (vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f;
								copyOfVertices[materialReferenceIndex][vertexIndex] = vertices[vertexIndex] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = vertices[vertexIndex + 1] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = vertices[vertexIndex + 2] - b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = vertices[vertexIndex + 3] - b2;
								float d = Random.Range(0.95f, 1.05f);
								Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.one, Quaternion.identity, Vector3.one * d);
								copyOfVertices[materialReferenceIndex][vertexIndex] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 1]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 2]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 3]);
								copyOfVertices[materialReferenceIndex][vertexIndex] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] += b2;
								copyOfVertices[materialReferenceIndex][vertexIndex] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] -= b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] -= b;
								matrix4x = Matrix4x4.TRS(Vector3.one, q, Vector3.one);
								copyOfVertices[materialReferenceIndex][vertexIndex] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 1]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 2]);
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 3]);
								copyOfVertices[materialReferenceIndex][vertexIndex] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 1] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 2] += b;
								copyOfVertices[materialReferenceIndex][vertexIndex + 3] += b;
							}
						}
					}
					for (int l = 0; l < textInfo.meshInfo.Length; l++)
					{
						textInfo.meshInfo[l].mesh.vertices = copyOfVertices[l];
						this.m_TextComponent.UpdateGeometry(textInfo.meshInfo[l].mesh, l);
					}
					yield return new WaitForSeconds(0.1f);
				}
			}
			yield break;
		}

		// Token: 0x04000FD8 RID: 4056
		public float AngleMultiplier = 1f;

		// Token: 0x04000FD9 RID: 4057
		public float SpeedMultiplier = 1f;

		// Token: 0x04000FDA RID: 4058
		public float CurveScale = 1f;

		// Token: 0x04000FDB RID: 4059
		private TMP_Text m_TextComponent;

		// Token: 0x04000FDC RID: 4060
		private bool hasTextChanged;
	}
}
