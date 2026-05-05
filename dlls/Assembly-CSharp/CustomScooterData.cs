using System;
using UnityEngine;

// Token: 0x02000106 RID: 262
[Serializable]
public class CustomScooterData
{
	// Token: 0x04000657 RID: 1623
	[Header("Selected Part Names")]
	public string deck;

	// Token: 0x04000658 RID: 1624
	public string bars;

	// Token: 0x04000659 RID: 1625
	public string fork;

	// Token: 0x0400065A RID: 1626
	public string clamp;

	// Token: 0x0400065B RID: 1627
	public string frontWheel;

	// Token: 0x0400065C RID: 1628
	public string rearWheel;

	// Token: 0x0400065D RID: 1629
	public string grips;

	// Token: 0x0400065E RID: 1630
	public string barEnds;

	// Token: 0x0400065F RID: 1631
	public string headset;

	// Token: 0x04000660 RID: 1632
	[Header("Griptape")]
	public string gripTape;

	// Token: 0x04000661 RID: 1633
	public int gripTapeId;

	// Token: 0x04000662 RID: 1634
	[Header("Pegs")]
	public string pegs;

	// Token: 0x04000663 RID: 1635
	public int pegOption;

	// Token: 0x04000664 RID: 1636
	[Header("Deck")]
	public bool hasDeckPegs;
}
