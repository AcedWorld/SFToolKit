using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000171 RID: 369
	[NativeHeader("Runtime/Camera/OcclusionArea.h")]
	public sealed class OcclusionArea : Component
	{
		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x00015ABC File Offset: 0x00013CBC
		// (set) Token: 0x06000F5B RID: 3931 RVA: 0x00015AD2 File Offset: 0x00013CD2
		public Vector3 center
		{
			get
			{
				Vector3 result;
				this.get_center_Injected(out result);
				return result;
			}
			set
			{
				this.set_center_Injected(ref value);
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000F5C RID: 3932 RVA: 0x00015ADC File Offset: 0x00013CDC
		// (set) Token: 0x06000F5D RID: 3933 RVA: 0x00015AF2 File Offset: 0x00013CF2
		public Vector3 size
		{
			get
			{
				Vector3 result;
				this.get_size_Injected(out result);
				return result;
			}
			set
			{
				this.set_size_Injected(ref value);
			}
		}

		// Token: 0x06000F5F RID: 3935
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_center_Injected(out Vector3 ret);

		// Token: 0x06000F60 RID: 3936
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_center_Injected(ref Vector3 value);

		// Token: 0x06000F61 RID: 3937
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_size_Injected(out Vector3 ret);

		// Token: 0x06000F62 RID: 3938
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_size_Injected(ref Vector3 value);
	}
}
