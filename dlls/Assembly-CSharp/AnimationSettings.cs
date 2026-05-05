using System;
using UnityEngine;

// Token: 0x02000117 RID: 279
[Serializable]
public class AnimationSettings
{
	// Token: 0x040006C6 RID: 1734
	[Header("Input")]
	public float joystickThreshold = 0.5f;

	// Token: 0x040006C7 RID: 1735
	public float HorizontalInputSmooth;

	// Token: 0x040006C8 RID: 1736
	public float VerticalInputSmooth;

	// Token: 0x040006C9 RID: 1737
	public float GrindDirInputSmooth;

	// Token: 0x040006CA RID: 1738
	[Header("Physics")]
	public float ProceduralXSmooth;

	// Token: 0x040006CB RID: 1739
	public float ProceduralZSmooth;

	// Token: 0x040006CC RID: 1740
	public float HopTiltSmooth;
}
