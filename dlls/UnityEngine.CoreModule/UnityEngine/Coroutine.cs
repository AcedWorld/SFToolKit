using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200023D RID: 573
	[RequiredByNativeCode]
	[NativeHeader("Runtime/Mono/Coroutine.h")]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class Coroutine : YieldInstruction
	{
		// Token: 0x060018A3 RID: 6307 RVA: 0x00028EA4 File Offset: 0x000270A4
		private Coroutine()
		{
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x00028EB0 File Offset: 0x000270B0
		~Coroutine()
		{
			Coroutine.ReleaseCoroutine(this.m_Ptr);
		}

		// Token: 0x060018A5 RID: 6309
		[FreeFunction("Coroutine::CleanupCoroutineGC", true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReleaseCoroutine(IntPtr ptr);

		// Token: 0x040008A6 RID: 2214
		internal IntPtr m_Ptr;
	}
}
