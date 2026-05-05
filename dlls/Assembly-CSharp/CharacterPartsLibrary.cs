using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000094 RID: 148
[CreateAssetMenu(fileName = "Character Parts Library", menuName = "Character/Character Parts Library")]
public class CharacterPartsLibrary : ScriptableObject
{
	// Token: 0x04000316 RID: 790
	public List<TopData> tops = new List<TopData>();

	// Token: 0x04000317 RID: 791
	public List<HatData> hats = new List<HatData>();

	// Token: 0x04000318 RID: 792
	public List<PantsData> pants = new List<PantsData>();

	// Token: 0x04000319 RID: 793
	public List<ShoesData> shoes = new List<ShoesData>();
}
