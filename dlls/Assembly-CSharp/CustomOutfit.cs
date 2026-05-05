using System;
using UnityEngine;

// Token: 0x0200009A RID: 154
[CreateAssetMenu(fileName = "New Custom Outfit", menuName = "Character/Custom Outfit")]
public class CustomOutfit : ScriptableObject
{
	// Token: 0x0400032D RID: 813
	[Header("Outfit Selection")]
	public CustomOutfitData outfit = new CustomOutfitData();
}
