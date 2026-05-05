using System;
using UnityEngine;

// Token: 0x02000195 RID: 405
[Serializable]
public class GroundInformation
{
	// Token: 0x04000ACC RID: 2764
	public bool debug;

	// Token: 0x04000ACD RID: 2765
	[Header("Information")]
	public float groundAngleX;

	// Token: 0x04000ACE RID: 2766
	public float transformX;

	// Token: 0x04000ACF RID: 2767
	public float transformZ;

	// Token: 0x04000AD0 RID: 2768
	public float AnimationX;

	// Token: 0x04000AD1 RID: 2769
	public float AnimationZ;

	// Token: 0x04000AD2 RID: 2770
	[Header("Settings")]
	public LayerMask layerMask;

	// Token: 0x04000AD3 RID: 2771
	public Vector3 raycastOffset;

	// Token: 0x04000AD4 RID: 2772
	public float xDivider;

	// Token: 0x04000AD5 RID: 2773
	public float zDivider;
}
