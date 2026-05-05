using System;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x02000495 RID: 1173
	public interface IPlayableBehaviour
	{
		// Token: 0x0600285E RID: 10334
		[RequiredByNativeCode]
		void OnGraphStart(Playable playable);

		// Token: 0x0600285F RID: 10335
		[RequiredByNativeCode]
		void OnGraphStop(Playable playable);

		// Token: 0x06002860 RID: 10336
		[RequiredByNativeCode]
		void OnPlayableCreate(Playable playable);

		// Token: 0x06002861 RID: 10337
		[RequiredByNativeCode]
		void OnPlayableDestroy(Playable playable);

		// Token: 0x06002862 RID: 10338
		[RequiredByNativeCode]
		void OnBehaviourPlay(Playable playable, FrameData info);

		// Token: 0x06002863 RID: 10339
		[RequiredByNativeCode]
		void OnBehaviourPause(Playable playable, FrameData info);

		// Token: 0x06002864 RID: 10340
		[RequiredByNativeCode]
		void PrepareFrame(Playable playable, FrameData info);

		// Token: 0x06002865 RID: 10341
		[RequiredByNativeCode]
		void ProcessFrame(Playable playable, FrameData info, object playerData);
	}
}
