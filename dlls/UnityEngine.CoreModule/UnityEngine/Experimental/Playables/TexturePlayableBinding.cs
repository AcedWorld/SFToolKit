using System;
using UnityEngine.Playables;

namespace UnityEngine.Experimental.Playables
{
	// Token: 0x020004CE RID: 1230
	public static class TexturePlayableBinding
	{
		// Token: 0x06002B0E RID: 11022 RVA: 0x00048F34 File Offset: 0x00047134
		public static PlayableBinding Create(string name, Object key)
		{
			return PlayableBinding.CreateInternal(name, key, typeof(RenderTexture), new PlayableBinding.CreateOutputMethod(TexturePlayableBinding.CreateTextureOutput));
		}

		// Token: 0x06002B0F RID: 11023 RVA: 0x00048F64 File Offset: 0x00047164
		private static PlayableOutput CreateTextureOutput(PlayableGraph graph, string name)
		{
			return TexturePlayableOutput.Create(graph, name, null);
		}
	}
}
