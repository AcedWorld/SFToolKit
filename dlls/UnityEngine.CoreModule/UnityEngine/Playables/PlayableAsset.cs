using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x0200049B RID: 1179
	[AssetFileNameExtension("playable", new string[]
	{

	})]
	[RequiredByNativeCode]
	[Serializable]
	public abstract class PlayableAsset : ScriptableObject, IPlayableAsset
	{
		// Token: 0x06002874 RID: 10356
		public abstract Playable CreatePlayable(PlayableGraph graph, GameObject owner);

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x06002875 RID: 10357 RVA: 0x000454C4 File Offset: 0x000436C4
		public virtual double duration
		{
			get
			{
				return PlayableBinding.DefaultDuration;
			}
		}

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x06002876 RID: 10358 RVA: 0x000454DC File Offset: 0x000436DC
		public virtual IEnumerable<PlayableBinding> outputs
		{
			get
			{
				return PlayableBinding.None;
			}
		}

		// Token: 0x06002877 RID: 10359 RVA: 0x000454F4 File Offset: 0x000436F4
		[RequiredByNativeCode]
		internal unsafe static void Internal_CreatePlayable(PlayableAsset asset, PlayableGraph graph, GameObject go, IntPtr ptr)
		{
			bool flag = asset == null;
			Playable playable;
			if (flag)
			{
				playable = Playable.Null;
			}
			else
			{
				playable = asset.CreatePlayable(graph, go);
			}
			Playable* ptr2 = (Playable*)ptr.ToPointer();
			*ptr2 = playable;
		}

		// Token: 0x06002878 RID: 10360 RVA: 0x00045530 File Offset: 0x00043730
		[RequiredByNativeCode]
		internal unsafe static void Internal_GetPlayableAssetDuration(PlayableAsset asset, IntPtr ptrToDouble)
		{
			double duration = asset.duration;
			double* ptr = (double*)ptrToDouble.ToPointer();
			*ptr = duration;
		}
	}
}
