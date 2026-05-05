using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Playables;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.Playables
{
	// Token: 0x020004CC RID: 1228
	[NativeHeader("Runtime/Export/Director/MaterialEffectPlayable.bindings.h")]
	[NativeHeader("Runtime/Shaders/Director/MaterialEffectPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[StaticAccessor("MaterialEffectPlayableBindings", StaticAccessorType.DoubleColon)]
	[RequiredByNativeCode]
	public struct MaterialEffectPlayable : IPlayable, IEquatable<MaterialEffectPlayable>
	{
		// Token: 0x06002AF5 RID: 10997 RVA: 0x00048CB8 File Offset: 0x00046EB8
		public static MaterialEffectPlayable Create(PlayableGraph graph, Material material, int pass = -1)
		{
			PlayableHandle handle = MaterialEffectPlayable.CreateHandle(graph, material, pass);
			return new MaterialEffectPlayable(handle);
		}

		// Token: 0x06002AF6 RID: 10998 RVA: 0x00048CDC File Offset: 0x00046EDC
		private static PlayableHandle CreateHandle(PlayableGraph graph, Material material, int pass)
		{
			PlayableHandle @null = PlayableHandle.Null;
			bool flag = !MaterialEffectPlayable.InternalCreateMaterialEffectPlayable(ref graph, material, pass, ref @null);
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

		// Token: 0x06002AF7 RID: 10999 RVA: 0x00048D10 File Offset: 0x00046F10
		internal MaterialEffectPlayable(PlayableHandle handle)
		{
			bool flag = handle.IsValid();
			if (flag)
			{
				bool flag2 = !handle.IsPlayableOfType<MaterialEffectPlayable>();
				if (flag2)
				{
					throw new InvalidCastException("Can't set handle: the playable is not an MaterialEffectPlayable.");
				}
			}
			this.m_Handle = handle;
		}

		// Token: 0x06002AF8 RID: 11000 RVA: 0x00048D4C File Offset: 0x00046F4C
		public PlayableHandle GetHandle()
		{
			return this.m_Handle;
		}

		// Token: 0x06002AF9 RID: 11001 RVA: 0x00048D64 File Offset: 0x00046F64
		public static implicit operator Playable(MaterialEffectPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		// Token: 0x06002AFA RID: 11002 RVA: 0x00048D84 File Offset: 0x00046F84
		public static explicit operator MaterialEffectPlayable(Playable playable)
		{
			return new MaterialEffectPlayable(playable.GetHandle());
		}

		// Token: 0x06002AFB RID: 11003 RVA: 0x00048DA4 File Offset: 0x00046FA4
		public bool Equals(MaterialEffectPlayable other)
		{
			return this.GetHandle() == other.GetHandle();
		}

		// Token: 0x06002AFC RID: 11004 RVA: 0x00048DC8 File Offset: 0x00046FC8
		public Material GetMaterial()
		{
			return MaterialEffectPlayable.GetMaterialInternal(ref this.m_Handle);
		}

		// Token: 0x06002AFD RID: 11005 RVA: 0x00048DE5 File Offset: 0x00046FE5
		public void SetMaterial(Material value)
		{
			MaterialEffectPlayable.SetMaterialInternal(ref this.m_Handle, value);
		}

		// Token: 0x06002AFE RID: 11006 RVA: 0x00048DF8 File Offset: 0x00046FF8
		public int GetPass()
		{
			return MaterialEffectPlayable.GetPassInternal(ref this.m_Handle);
		}

		// Token: 0x06002AFF RID: 11007 RVA: 0x00048E15 File Offset: 0x00047015
		public void SetPass(int value)
		{
			MaterialEffectPlayable.SetPassInternal(ref this.m_Handle, value);
		}

		// Token: 0x06002B00 RID: 11008
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Material GetMaterialInternal(ref PlayableHandle hdl);

		// Token: 0x06002B01 RID: 11009
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMaterialInternal(ref PlayableHandle hdl, Material material);

		// Token: 0x06002B02 RID: 11010
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetPassInternal(ref PlayableHandle hdl);

		// Token: 0x06002B03 RID: 11011
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPassInternal(ref PlayableHandle hdl, int pass);

		// Token: 0x06002B04 RID: 11012
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool InternalCreateMaterialEffectPlayable(ref PlayableGraph graph, Material material, int pass, ref PlayableHandle handle);

		// Token: 0x06002B05 RID: 11013
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ValidateType(ref PlayableHandle hdl);

		// Token: 0x0400101F RID: 4127
		private PlayableHandle m_Handle;
	}
}
