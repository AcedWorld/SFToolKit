using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x020001C4 RID: 452
	[NativeHeader("Runtime/Graphics/LOD/LODGroupManager.h")]
	[NativeHeader("Runtime/Graphics/LOD/LODGroup.h")]
	[StaticAccessor("GetLODGroupManager()", StaticAccessorType.Dot)]
	[NativeHeader("Runtime/Graphics/LOD/LODUtility.h")]
	public class LODGroup : Component
	{
		// Token: 0x17000364 RID: 868
		// (get) Token: 0x0600103F RID: 4159 RVA: 0x00015EAC File Offset: 0x000140AC
		// (set) Token: 0x06001040 RID: 4160 RVA: 0x00015EC2 File Offset: 0x000140C2
		public Vector3 localReferencePoint
		{
			get
			{
				Vector3 result;
				this.get_localReferencePoint_Injected(out result);
				return result;
			}
			set
			{
				this.set_localReferencePoint_Injected(ref value);
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06001041 RID: 4161
		// (set) Token: 0x06001042 RID: 4162
		public extern float size { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06001043 RID: 4163
		public extern int lodCount { [NativeMethod("GetLODCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06001044 RID: 4164
		// (set) Token: 0x06001045 RID: 4165
		public extern bool lastLODBillboard { [NativeMethod("GetLastLODIsBillboard")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetLastLODIsBillboard")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06001046 RID: 4166
		// (set) Token: 0x06001047 RID: 4167
		public extern LODFadeMode fadeMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06001048 RID: 4168
		// (set) Token: 0x06001049 RID: 4169
		public extern bool animateCrossFading { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x0600104A RID: 4170
		// (set) Token: 0x0600104B RID: 4171
		public extern bool enabled { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x0600104C RID: 4172
		[FreeFunction("UpdateLODGroupBoundingBox", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void RecalculateBounds();

		// Token: 0x0600104D RID: 4173
		[FreeFunction("GetLODs_Binding", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern LOD[] GetLODs();

		// Token: 0x0600104E RID: 4174 RVA: 0x00015ECC File Offset: 0x000140CC
		[Obsolete("Use SetLODs instead.")]
		public void SetLODS(LOD[] lods)
		{
			this.SetLODs(lods);
		}

		// Token: 0x0600104F RID: 4175
		[FreeFunction("SetLODs_Binding", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetLODs([Unmarshalled] LOD[] lods);

		// Token: 0x06001050 RID: 4176
		[FreeFunction("ForceLODLevel", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void ForceLOD(int index);

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06001051 RID: 4177
		// (set) Token: 0x06001052 RID: 4178
		[StaticAccessor("GetLODGroupManager()")]
		public static extern float crossFadeAnimationDuration { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06001053 RID: 4179 RVA: 0x00015ED8 File Offset: 0x000140D8
		internal Vector3 worldReferencePoint
		{
			get
			{
				Vector3 result;
				this.get_worldReferencePoint_Injected(out result);
				return result;
			}
		}

		// Token: 0x06001055 RID: 4181
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_localReferencePoint_Injected(out Vector3 ret);

		// Token: 0x06001056 RID: 4182
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_localReferencePoint_Injected(ref Vector3 value);

		// Token: 0x06001057 RID: 4183
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_worldReferencePoint_Injected(out Vector3 ret);
	}
}
