using System;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000463 RID: 1123
	internal class ShaderInfoStorageRGBAFloat : ShaderInfoStorage<Color>
	{
		// Token: 0x06002308 RID: 8968 RVA: 0x00087CF8 File Offset: 0x00085EF8
		public ShaderInfoStorageRGBAFloat(int initialSize = 64, int maxSize = 4096) : base(TextureFormat.RGBAFloat, ShaderInfoStorageRGBAFloat.s_Convert, initialSize, maxSize)
		{
		}

		// Token: 0x04001026 RID: 4134
		private static readonly Func<Color, Color> s_Convert = (Color c) => c;
	}
}
