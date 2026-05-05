using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000108 RID: 264
[CreateAssetMenu(fileName = "Deck Parts Library", menuName = "ScooterFlow/Deck Parts Library")]
public class ScooterPartsLibrary : ScriptableObject
{
	// Token: 0x04000669 RID: 1641
	public List<DeckData> decks = new List<DeckData>();

	// Token: 0x0400066A RID: 1642
	public List<BarsData> bars = new List<BarsData>();

	// Token: 0x0400066B RID: 1643
	public List<ForksData> forks = new List<ForksData>();

	// Token: 0x0400066C RID: 1644
	public List<ClampData> clamps = new List<ClampData>();

	// Token: 0x0400066D RID: 1645
	public List<FrontWheelData> frontWheels = new List<FrontWheelData>();

	// Token: 0x0400066E RID: 1646
	public List<RearWheelData> rearWheels = new List<RearWheelData>();

	// Token: 0x0400066F RID: 1647
	public List<GripsData> grips = new List<GripsData>();

	// Token: 0x04000670 RID: 1648
	public List<BarEndsData> barEnds = new List<BarEndsData>();

	// Token: 0x04000671 RID: 1649
	public List<HeadsetData> headsets = new List<HeadsetData>();

	// Token: 0x04000672 RID: 1650
	public List<PegsData> pegs = new List<PegsData>();

	// Token: 0x04000673 RID: 1651
	public List<GripTapeData> gripTapes = new List<GripTapeData>();
}
