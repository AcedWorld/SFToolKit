using System;
using UnityEngine;

// Token: 0x0200011C RID: 284
[Serializable]
public class MyScooterParts
{
	// Token: 0x040006F5 RID: 1781
	public GameObject deck;

	// Token: 0x040006F6 RID: 1782
	public GameObject brake;

	// Token: 0x040006F7 RID: 1783
	public GameObject bars;

	// Token: 0x040006F8 RID: 1784
	public GameObject forks;

	// Token: 0x040006F9 RID: 1785
	public GameObject clamp;

	// Token: 0x040006FA RID: 1786
	public GameObject frontWheel;

	// Token: 0x040006FB RID: 1787
	public GameObject frontTyre;

	// Token: 0x040006FC RID: 1788
	public GameObject rearWheel;

	// Token: 0x040006FD RID: 1789
	public GameObject rearTyre;

	// Token: 0x040006FE RID: 1790
	public GameObject leftGrip;

	// Token: 0x040006FF RID: 1791
	public GameObject rightGrip;

	// Token: 0x04000700 RID: 1792
	public GameObject leftBarEnd;

	// Token: 0x04000701 RID: 1793
	public GameObject rightBarEnd;

	// Token: 0x04000702 RID: 1794
	public GameObject headset;

	// Token: 0x04000703 RID: 1795
	public GameObject gripTape;

	// Token: 0x04000704 RID: 1796
	[Header("Peg Meshes")]
	public GameObject frontLeftPeg;

	// Token: 0x04000705 RID: 1797
	public GameObject frontRightPeg;

	// Token: 0x04000706 RID: 1798
	public GameObject rearLeftPeg;

	// Token: 0x04000707 RID: 1799
	public GameObject rearRightPeg;

	// Token: 0x04000708 RID: 1800
	[Header("Parents")]
	public Transform deckAddonParent;

	// Token: 0x04000709 RID: 1801
	public Transform frontPegsParent;

	// Token: 0x0400070A RID: 1802
	public Transform rearPegsParent;
}
