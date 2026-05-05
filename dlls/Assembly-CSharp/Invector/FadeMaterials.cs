using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000333 RID: 819
	[Serializable]
	public class FadeMaterials
	{
		// Token: 0x040016B6 RID: 5814
		public Renderer renderer;

		// Token: 0x040016B7 RID: 5815
		public Material[] originalMaterials;

		// Token: 0x040016B8 RID: 5816
		public Material[] fadeMaterials;

		// Token: 0x040016B9 RID: 5817
		public float[] originalAlpha;
	}
}
