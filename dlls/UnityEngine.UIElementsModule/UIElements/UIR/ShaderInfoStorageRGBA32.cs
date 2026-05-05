using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000461 RID: 1121
	internal class ShaderInfoStorageRGBA32 : ShaderInfoStorage<Color32>
	{
		// Token: 0x06002303 RID: 8963 RVA: 0x00087CBB File Offset: 0x00085EBB
		public ShaderInfoStorageRGBA32(int initialSize = 64, int maxSize = 4096) : base(TextureFormat.RGBA32, ShaderInfoStorageRGBA32.s_Convert, initialSize, maxSize)
		{
		}

		// Token: 0x04001024 RID: 4132
		private static readonly Func<Color, Color32> s_Convert = (Color c) => c;
	}
}
