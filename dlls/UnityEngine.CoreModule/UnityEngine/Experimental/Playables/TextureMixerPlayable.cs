using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Playables;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.Playables
{
	// Token: 0x020004CD RID: 1229
	[RequiredByNativeCode]
	[StaticAccessor("TextureMixerPlayableBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Runtime/Graphics/Director/TextureMixerPlayable.h")]
	[NativeHeader("Runtime/Export/Director/TextureMixerPlayable.bindings.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	public struct TextureMixerPlayable : IPlayable, IEquatable<TextureMixerPlayable>
	{
		// Token: 0x06002B06 RID: 11014 RVA: 0x00048E28 File Offset: 0x00047028
		public static TextureMixerPlayable Create(PlayableGraph graph)
		{
			PlayableHandle handle = TextureMixerPlayable.CreateHandle(graph);
			return new TextureMixerPlayable(handle);
		}

		// Token: 0x06002B07 RID: 11015 RVA: 0x00048E48 File Offset: 0x00047048
		private static PlayableHandle CreateHandle(PlayableGraph graph)
		{
			PlayableHandle @null = PlayableHandle.Null;
			bool flag = !TextureMixerPlayable.CreateTextureMixerPlayableInternal(ref graph, ref @null);
			PlayableHandle result;
			if (flag)
			{
				result = PlayableHandle.Null;
			}
			else
			{
				result = @null;
			}
			return result;
		}

		// Token: 0x06002B08 RID: 11016 RVA: 0x00048E7C File Offset: 0x0004707C
		internal TextureMixerPlayable(PlayableHandle handle)
		{
			bool flag = handle.IsValid();
			if (flag)
			{
				bool flag2 = !handle.IsPlayableOfType<TextureMixerPlayable>();
				if (flag2)
				{
					throw new InvalidCastException("Can't set handle: the playable is not an TextureMixerPlayable.");
				}
			}
			this.m_Handle = handle;
		}

		// Token: 0x06002B09 RID: 11017 RVA: 0x00048EB8 File Offset: 0x000470B8
		public PlayableHandle GetHandle()
		{
			return this.m_Handle;
		}

		// Token: 0x06002B0A RID: 11018 RVA: 0x00048ED0 File Offset: 0x000470D0
		public static implicit operator Playable(TextureMixerPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		// Token: 0x06002B0B RID: 11019 RVA: 0x00048EF0 File Offset: 0x000470F0
		public static explicit operator TextureMixerPlayable(Playable playable)
		{
			return new TextureMixerPlayable(playable.GetHandle());
		}

		// Token: 0x06002B0C RID: 11020 RVA: 0x00048F10 File Offset: 0x00047110
		public bool Equals(TextureMixerPlayable other)
		{
			return this.GetHandle() == other.GetHandle();
		}

		// Token: 0x06002B0D RID: 11021
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateTextureMixerPlayableInternal(ref PlayableGraph graph, ref PlayableHandle handle);

		// Token: 0x04001020 RID: 4128
		private PlayableHandle m_Handle;
	}
}
