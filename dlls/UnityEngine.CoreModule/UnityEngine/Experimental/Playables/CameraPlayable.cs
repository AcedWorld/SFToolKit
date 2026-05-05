using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Playables;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.Playables
{
	// Token: 0x020004CB RID: 1227
	[NativeHeader("Runtime/Camera//Director/CameraPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[StaticAccessor("CameraPlayableBindings", StaticAccessorType.DoubleColon)]
	[RequiredByNativeCode]
	[NativeHeader("Runtime/Export/Director/CameraPlayable.bindings.h")]
	public struct CameraPlayable : IPlayable, IEquatable<CameraPlayable>
	{
		// Token: 0x06002AE8 RID: 10984 RVA: 0x00048B7C File Offset: 0x00046D7C
		public static CameraPlayable Create(PlayableGraph graph, Camera camera)
		{
			PlayableHandle handle = CameraPlayable.CreateHandle(graph, camera);
			return new CameraPlayable(handle);
		}

		// Token: 0x06002AE9 RID: 10985 RVA: 0x00048B9C File Offset: 0x00046D9C
		private static PlayableHandle CreateHandle(PlayableGraph graph, Camera camera)
		{
			PlayableHandle @null = PlayableHandle.Null;
			bool flag = !CameraPlayable.InternalCreateCameraPlayable(ref graph, camera, ref @null);
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

		// Token: 0x06002AEA RID: 10986 RVA: 0x00048BD0 File Offset: 0x00046DD0
		internal CameraPlayable(PlayableHandle handle)
		{
			bool flag = handle.IsValid();
			if (flag)
			{
				bool flag2 = !handle.IsPlayableOfType<CameraPlayable>();
				if (flag2)
				{
					throw new InvalidCastException("Can't set handle: the playable is not an CameraPlayable.");
				}
			}
			this.m_Handle = handle;
		}

		// Token: 0x06002AEB RID: 10987 RVA: 0x00048C0C File Offset: 0x00046E0C
		public PlayableHandle GetHandle()
		{
			return this.m_Handle;
		}

		// Token: 0x06002AEC RID: 10988 RVA: 0x00048C24 File Offset: 0x00046E24
		public static implicit operator Playable(CameraPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		// Token: 0x06002AED RID: 10989 RVA: 0x00048C44 File Offset: 0x00046E44
		public static explicit operator CameraPlayable(Playable playable)
		{
			return new CameraPlayable(playable.GetHandle());
		}

		// Token: 0x06002AEE RID: 10990 RVA: 0x00048C64 File Offset: 0x00046E64
		public bool Equals(CameraPlayable other)
		{
			return this.GetHandle() == other.GetHandle();
		}

		// Token: 0x06002AEF RID: 10991 RVA: 0x00048C88 File Offset: 0x00046E88
		public Camera GetCamera()
		{
			return CameraPlayable.GetCameraInternal(ref this.m_Handle);
		}

		// Token: 0x06002AF0 RID: 10992 RVA: 0x00048CA5 File Offset: 0x00046EA5
		public void SetCamera(Camera value)
		{
			CameraPlayable.SetCameraInternal(ref this.m_Handle, value);
		}

		// Token: 0x06002AF1 RID: 10993
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Camera GetCameraInternal(ref PlayableHandle hdl);

		// Token: 0x06002AF2 RID: 10994
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCameraInternal(ref PlayableHandle hdl, Camera camera);

		// Token: 0x06002AF3 RID: 10995
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool InternalCreateCameraPlayable(ref PlayableGraph graph, Camera camera, ref PlayableHandle handle);

		// Token: 0x06002AF4 RID: 10996
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ValidateType(ref PlayableHandle hdl);

		// Token: 0x0400101E RID: 4126
		private PlayableHandle m_Handle;
	}
}
