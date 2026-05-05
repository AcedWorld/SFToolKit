using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004D1 RID: 1233
	[NativeHeader("Runtime/Camera/ReflectionProbes.h")]
	internal class BuiltinRuntimeReflectionSystem : IScriptableRuntimeReflectionSystem, IDisposable
	{
		// Token: 0x06002B1B RID: 11035 RVA: 0x000490A4 File Offset: 0x000472A4
		public bool TickRealtimeProbes()
		{
			return BuiltinRuntimeReflectionSystem.BuiltinUpdate();
		}

		// Token: 0x06002B1C RID: 11036 RVA: 0x000490BB File Offset: 0x000472BB
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06002B1D RID: 11037 RVA: 0x00002669 File Offset: 0x00000869
		private void Dispose(bool disposing)
		{
		}

		// Token: 0x06002B1E RID: 11038
		[StaticAccessor("GetReflectionProbes()", Type = StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool BuiltinUpdate();

		// Token: 0x06002B1F RID: 11039 RVA: 0x000490C8 File Offset: 0x000472C8
		[RequiredByNativeCode]
		private static BuiltinRuntimeReflectionSystem Internal_BuiltinRuntimeReflectionSystem_New()
		{
			return new BuiltinRuntimeReflectionSystem();
		}
	}
}
