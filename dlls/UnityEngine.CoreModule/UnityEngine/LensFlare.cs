using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000173 RID: 371
	[NativeHeader("Runtime/Camera/Flare.h")]
	public sealed class LensFlare : Behaviour
	{
		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000F65 RID: 3941
		// (set) Token: 0x06000F66 RID: 3942
		public extern float brightness { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000F67 RID: 3943
		// (set) Token: 0x06000F68 RID: 3944
		public extern float fadeSpeed { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000F69 RID: 3945 RVA: 0x00015B10 File Offset: 0x00013D10
		// (set) Token: 0x06000F6A RID: 3946 RVA: 0x00015B26 File Offset: 0x00013D26
		public Color color
		{
			get
			{
				Color result;
				this.get_color_Injected(out result);
				return result;
			}
			set
			{
				this.set_color_Injected(ref value);
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000F6B RID: 3947
		// (set) Token: 0x06000F6C RID: 3948
		public extern Flare flare { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000F6E RID: 3950
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_color_Injected(out Color ret);

		// Token: 0x06000F6F RID: 3951
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_color_Injected(ref Color value);
	}
}
