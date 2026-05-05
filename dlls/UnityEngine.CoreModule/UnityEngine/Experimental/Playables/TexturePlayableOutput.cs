using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Playables;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.Playables
{
	// Token: 0x020004D0 RID: 1232
	[RequiredByNativeCode]
	[NativeHeader("Runtime/Export/Director/TexturePlayableOutput.bindings.h")]
	[NativeHeader("Runtime/Graphics/Director/TexturePlayableOutput.h")]
	[StaticAccessor("TexturePlayableOutputBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Runtime/Graphics/RenderTexture.h")]
	public struct TexturePlayableOutput : IPlayableOutput
	{
		// Token: 0x06002B11 RID: 11025 RVA: 0x00048F84 File Offset: 0x00047184
		public static TexturePlayableOutput Create(PlayableGraph graph, string name, RenderTexture target)
		{
			PlayableOutputHandle handle;
			bool flag = !TexturePlayableGraphExtensions.InternalCreateTextureOutput(ref graph, name, out handle);
			TexturePlayableOutput result;
			if (flag)
			{
				result = TexturePlayableOutput.Null;
			}
			else
			{
				TexturePlayableOutput texturePlayableOutput = new TexturePlayableOutput(handle);
				texturePlayableOutput.SetTarget(target);
				result = texturePlayableOutput;
			}
			return result;
		}

		// Token: 0x06002B12 RID: 11026 RVA: 0x00048FC4 File Offset: 0x000471C4
		internal TexturePlayableOutput(PlayableOutputHandle handle)
		{
			bool flag = handle.IsValid();
			if (flag)
			{
				bool flag2 = !handle.IsPlayableOutputOfType<TexturePlayableOutput>();
				if (flag2)
				{
					throw new InvalidCastException("Can't set handle: the playable is not an TexturePlayableOutput.");
				}
			}
			this.m_Handle = handle;
		}

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x06002B13 RID: 11027 RVA: 0x00049000 File Offset: 0x00047200
		public static TexturePlayableOutput Null
		{
			get
			{
				return new TexturePlayableOutput(PlayableOutputHandle.Null);
			}
		}

		// Token: 0x06002B14 RID: 11028 RVA: 0x0004901C File Offset: 0x0004721C
		public PlayableOutputHandle GetHandle()
		{
			return this.m_Handle;
		}

		// Token: 0x06002B15 RID: 11029 RVA: 0x00049034 File Offset: 0x00047234
		public static implicit operator PlayableOutput(TexturePlayableOutput output)
		{
			return new PlayableOutput(output.GetHandle());
		}

		// Token: 0x06002B16 RID: 11030 RVA: 0x00049054 File Offset: 0x00047254
		public static explicit operator TexturePlayableOutput(PlayableOutput output)
		{
			return new TexturePlayableOutput(output.GetHandle());
		}

		// Token: 0x06002B17 RID: 11031 RVA: 0x00049074 File Offset: 0x00047274
		public RenderTexture GetTarget()
		{
			return TexturePlayableOutput.InternalGetTarget(ref this.m_Handle);
		}

		// Token: 0x06002B18 RID: 11032 RVA: 0x00049091 File Offset: 0x00047291
		public void SetTarget(RenderTexture value)
		{
			TexturePlayableOutput.InternalSetTarget(ref this.m_Handle, value);
		}

		// Token: 0x06002B19 RID: 11033
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RenderTexture InternalGetTarget(ref PlayableOutputHandle output);

		// Token: 0x06002B1A RID: 11034
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetTarget(ref PlayableOutputHandle output, RenderTexture target);

		// Token: 0x04001021 RID: 4129
		private PlayableOutputHandle m_Handle;
	}
}
