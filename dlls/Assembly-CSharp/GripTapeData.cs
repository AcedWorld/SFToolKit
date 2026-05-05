using System;
using UnityEngine;

// Token: 0x02000113 RID: 275
[Serializable]
public class GripTapeData
{
	// Token: 0x040006B2 RID: 1714
	[Header("Basic Info")]
	public string gripTapeName;

	// Token: 0x040006B3 RID: 1715
	public ScooterBrands brand;

	// Token: 0x040006B4 RID: 1716
	public int gripTapeIdentificationNumber;

	// Token: 0x040006B5 RID: 1717
	[Header("Grip Tape Components")]
	public Texture gripTapeTexture;
}
