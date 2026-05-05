using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x0200023F RID: 575
	public class TextMeshSpawner : MonoBehaviour
	{
		// Token: 0x06000909 RID: 2313 RVA: 0x000020BE File Offset: 0x000002BE
		private void Awake()
		{
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0003ECFC File Offset: 0x0003CEFC
		private void Start()
		{
			for (int i = 0; i < this.NumberOfNPC; i++)
			{
				if (this.SpawnType == 0)
				{
					GameObject gameObject = new GameObject();
					gameObject.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));
					TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
					textMeshPro.fontSize = 96f;
					textMeshPro.text = "!";
					textMeshPro.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
					this.floatingText_Script = gameObject.AddComponent<TextMeshProFloatingText>();
					this.floatingText_Script.SpawnType = 0;
				}
				else
				{
					GameObject gameObject2 = new GameObject();
					gameObject2.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));
					TextMesh textMesh = gameObject2.AddComponent<TextMesh>();
					textMesh.GetComponent<Renderer>().sharedMaterial = this.TheFont.material;
					textMesh.font = this.TheFont;
					textMesh.anchor = TextAnchor.LowerCenter;
					textMesh.fontSize = 96;
					textMesh.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
					textMesh.text = "!";
					this.floatingText_Script = gameObject2.AddComponent<TextMeshProFloatingText>();
					this.floatingText_Script.SpawnType = 1;
				}
			}
		}

		// Token: 0x04000F6E RID: 3950
		public int SpawnType;

		// Token: 0x04000F6F RID: 3951
		public int NumberOfNPC = 12;

		// Token: 0x04000F70 RID: 3952
		public Font TheFont;

		// Token: 0x04000F71 RID: 3953
		private TextMeshProFloatingText floatingText_Script;
	}
}
