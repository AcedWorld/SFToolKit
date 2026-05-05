using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000132 RID: 306
public class ClothingCheatCodeHandler : MonoBehaviour
{
	// Token: 0x060004F0 RID: 1264 RVA: 0x0002223C File Offset: 0x0002043C
	private void Update()
	{
		foreach (char c in Input.inputString)
		{
			if (c == '\n' || c == '\r')
			{
				Debug.Log("Cheat Code Entered: " + this.cheatCode);
				this.ActivateClothing(this.cheatCode);
				this.cheatCode = "";
			}
			else
			{
				this.cheatCode += c.ToString();
			}
		}
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x000222B8 File Offset: 0x000204B8
	public void ActivateClothing(string cheatCode)
	{
		if (string.IsNullOrEmpty(cheatCode))
		{
			Debug.LogWarning("Cheat code is empty.");
			return;
		}
		string text = new string(cheatCode.TrimEnd(new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9'
		}));
		string text2 = cheatCode.Substring(text.Length);
		int num = string.IsNullOrEmpty(text2) ? 0 : (int.Parse(text2) - 1);
		Debug.Log(string.Format("Parsed Prefix: {0}, Color Index: {1}", text, num + 1));
		foreach (ClothingCheatCodeHandler.ClothingCategory clothingCategory in this.categories)
		{
			foreach (ClothingCheatCodeHandler.ClothingItem clothingItem in clothingCategory.items)
			{
				if (clothingItem.cheatCodePrefix == text)
				{
					foreach (ClothingCheatCodeHandler.ClothingItem clothingItem2 in clothingCategory.items)
					{
						if (clothingItem2.gameObject != null)
						{
							clothingItem2.gameObject.SetActive(false);
						}
					}
					if (clothingItem.gameObject != null)
					{
						clothingItem.gameObject.SetActive(true);
						if (num >= 0 && num < clothingItem.materials.Count)
						{
							Renderer component = clothingItem.gameObject.GetComponent<Renderer>();
							if (component != null)
							{
								component.material = clothingItem.materials[num];
								Debug.Log("Material '" + clothingItem.materials[num].name + "' applied to " + clothingItem.gameObject.name);
							}
							else
							{
								Debug.LogWarning("Renderer not found on " + clothingItem.gameObject.name);
							}
						}
						else
						{
							Debug.LogWarning(string.Format("Invalid color index {0} for {1}", num + 1, clothingItem.cheatCodePrefix));
						}
					}
					return;
				}
			}
		}
		Debug.LogWarning("No match for cheat code '" + cheatCode + "'");
	}

	// Token: 0x040007BE RID: 1982
	public List<ClothingCheatCodeHandler.ClothingCategory> categories = new List<ClothingCheatCodeHandler.ClothingCategory>();

	// Token: 0x040007BF RID: 1983
	private string cheatCode = "";

	// Token: 0x02000133 RID: 307
	[Serializable]
	public class ClothingItem
	{
		// Token: 0x040007C0 RID: 1984
		public string cheatCodePrefix;

		// Token: 0x040007C1 RID: 1985
		public GameObject gameObject;

		// Token: 0x040007C2 RID: 1986
		public List<Material> materials;
	}

	// Token: 0x02000134 RID: 308
	[Serializable]
	public class ClothingCategory
	{
		// Token: 0x040007C3 RID: 1987
		public string categoryName;

		// Token: 0x040007C4 RID: 1988
		public List<ClothingCheatCodeHandler.ClothingItem> items;
	}
}
