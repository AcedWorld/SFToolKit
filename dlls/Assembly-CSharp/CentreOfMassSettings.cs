using System;
using UnityEngine;

// Token: 0x02000193 RID: 403
[Serializable]
public class CentreOfMassSettings
{
	// Token: 0x04000AC4 RID: 2756
	public bool debug;

	// Token: 0x04000AC5 RID: 2757
	[Header("Current Centre Of Mass")]
	public Vector3 CentreOfMass;

	// Token: 0x04000AC6 RID: 2758
	[Header("State Locations")]
	public Vector3 Normal;

	// Token: 0x04000AC7 RID: 2759
	public Vector3 InAir;
}
