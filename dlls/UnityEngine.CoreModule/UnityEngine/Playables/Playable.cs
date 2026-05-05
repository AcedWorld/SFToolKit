using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Playables
{
	// Token: 0x02000499 RID: 1177
	[RequiredByNativeCode]
	public struct Playable : IPlayable, IEquatable<Playable>
	{
		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06002869 RID: 10345 RVA: 0x000453E8 File Offset: 0x000435E8
		public static Playable Null
		{
			get
			{
				return Playable.m_NullPlayable;
			}
		}

		// Token: 0x0600286A RID: 10346 RVA: 0x00045400 File Offset: 0x00043600
		public static Playable Create(PlayableGraph graph, int inputCount = 0)
		{
			Playable playable = new Playable(graph.CreatePlayableHandle());
			playable.SetInputCount(inputCount);
			return playable;
		}

		// Token: 0x0600286B RID: 10347 RVA: 0x00045429 File Offset: 0x00043629
		[VisibleToOtherModules]
		internal Playable(PlayableHandle handle)
		{
			this.m_Handle = handle;
		}

		// Token: 0x0600286C RID: 10348 RVA: 0x00045434 File Offset: 0x00043634
		public PlayableHandle GetHandle()
		{
			return this.m_Handle;
		}

		// Token: 0x0600286D RID: 10349 RVA: 0x0004544C File Offset: 0x0004364C
		public bool IsPlayableOfType<T>() where T : struct, IPlayable
		{
			return this.GetHandle().IsPlayableOfType<T>();
		}

		// Token: 0x0600286E RID: 10350 RVA: 0x0004546C File Offset: 0x0004366C
		public Type GetPlayableType()
		{
			return this.GetHandle().GetPlayableType();
		}

		// Token: 0x0600286F RID: 10351 RVA: 0x0004548C File Offset: 0x0004368C
		public bool Equals(Playable other)
		{
			return this.GetHandle() == other.GetHandle();
		}

		// Token: 0x04000F5F RID: 3935
		private PlayableHandle m_Handle;

		// Token: 0x04000F60 RID: 3936
		private static readonly Playable m_NullPlayable = new Playable(PlayableHandle.Null);
	}
}
