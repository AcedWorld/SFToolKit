using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200026F RID: 623
	public interface ITransform
	{
		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x060011B3 RID: 4531
		// (set) Token: 0x060011B4 RID: 4532
		Vector3 position { get; set; }

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x060011B5 RID: 4533
		// (set) Token: 0x060011B6 RID: 4534
		Quaternion rotation { get; set; }

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x060011B7 RID: 4535
		// (set) Token: 0x060011B8 RID: 4536
		Vector3 scale { get; set; }

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x060011B9 RID: 4537
		Matrix4x4 matrix { get; }
	}
}
