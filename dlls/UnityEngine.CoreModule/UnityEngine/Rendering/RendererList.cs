using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Rendering
{
	// Token: 0x02000461 RID: 1121
	[MovedFrom("UnityEngine.Rendering.RendererUtils")]
	[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/RendererList.h")]
	public struct RendererList
	{
		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x060025A3 RID: 9635 RVA: 0x000403DD File Offset: 0x0003E5DD
		public bool isValid
		{
			get
			{
				return RendererList.get_isValid_Injected(ref this);
			}
		}

		// Token: 0x060025A4 RID: 9636 RVA: 0x000403E5 File Offset: 0x0003E5E5
		internal RendererList(UIntPtr ctx, uint indx)
		{
			this.context = ctx;
			this.index = indx;
			this.frame = 0U;
			this.type = 0U;
		}

		// Token: 0x060025A6 RID: 9638
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isValid_Injected(ref RendererList _unity_self);

		// Token: 0x04000E48 RID: 3656
		internal UIntPtr context;

		// Token: 0x04000E49 RID: 3657
		internal uint index;

		// Token: 0x04000E4A RID: 3658
		internal uint frame;

		// Token: 0x04000E4B RID: 3659
		internal uint type;

		// Token: 0x04000E4C RID: 3660
		public static readonly RendererList nullRendererList = new RendererList(UIntPtr.Zero, uint.MaxValue);
	}
}
