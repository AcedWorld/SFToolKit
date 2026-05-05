using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x020004A6 RID: 1190
	[RequiredByNativeCode]
	public struct PlayableOutput : IPlayableOutput, IEquatable<PlayableOutput>
	{
		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x06002972 RID: 10610 RVA: 0x000464E0 File Offset: 0x000446E0
		public static PlayableOutput Null
		{
			get
			{
				return PlayableOutput.m_NullPlayableOutput;
			}
		}

		// Token: 0x06002973 RID: 10611 RVA: 0x000464F7 File Offset: 0x000446F7
		[VisibleToOtherModules]
		internal PlayableOutput(PlayableOutputHandle handle)
		{
			this.m_Handle = handle;
		}

		// Token: 0x06002974 RID: 10612 RVA: 0x00046504 File Offset: 0x00044704
		public PlayableOutputHandle GetHandle()
		{
			return this.m_Handle;
		}

		// Token: 0x06002975 RID: 10613 RVA: 0x0004651C File Offset: 0x0004471C
		public bool IsPlayableOutputOfType<T>() where T : struct, IPlayableOutput
		{
			return this.GetHandle().IsPlayableOutputOfType<T>();
		}

		// Token: 0x06002976 RID: 10614 RVA: 0x0004653C File Offset: 0x0004473C
		public Type GetPlayableOutputType()
		{
			return this.GetHandle().GetPlayableOutputType();
		}

		// Token: 0x06002977 RID: 10615 RVA: 0x0004655C File Offset: 0x0004475C
		public bool Equals(PlayableOutput other)
		{
			return this.GetHandle() == other.GetHandle();
		}

		// Token: 0x04000F7D RID: 3965
		private PlayableOutputHandle m_Handle;

		// Token: 0x04000F7E RID: 3966
		private static readonly PlayableOutput m_NullPlayableOutput = new PlayableOutput(PlayableOutputHandle.Null);
	}
}
