using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200001D RID: 29
	internal static class BC6HExtensions
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00004221 File Offset: 0x00002421
		public static void BC6HEncodeFastCubemap(this CommandBuffer cmb, RenderTargetIdentifier source, int sourceSize, RenderTargetIdentifier target, int fromMip, int toMip, int targetArrayIndex = 0)
		{
			EncodeBC6H.DefaultInstance.EncodeFastCubemap(cmb, source, sourceSize, target, fromMip, toMip, targetArrayIndex);
		}
	}
}
