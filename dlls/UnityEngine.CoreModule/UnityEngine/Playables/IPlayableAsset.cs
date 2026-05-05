using System;
using System.Collections.Generic;

namespace UnityEngine.Playables
{
	// Token: 0x0200049A RID: 1178
	public interface IPlayableAsset
	{
		// Token: 0x06002871 RID: 10353
		Playable CreatePlayable(PlayableGraph graph, GameObject owner);

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06002872 RID: 10354
		double duration { get; }

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06002873 RID: 10355
		IEnumerable<PlayableBinding> outputs { get; }
	}
}
