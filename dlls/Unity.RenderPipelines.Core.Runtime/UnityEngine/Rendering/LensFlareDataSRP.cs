using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000A6 RID: 166
	[Serializable]
	public sealed class LensFlareDataSRP : ScriptableObject
	{
		// Token: 0x0600054C RID: 1356 RVA: 0x0001B7E1 File Offset: 0x000199E1
		public LensFlareDataSRP()
		{
			this.elements = null;
		}

		// Token: 0x040003C7 RID: 967
		public LensFlareDataElementSRP[] elements;
	}
}
