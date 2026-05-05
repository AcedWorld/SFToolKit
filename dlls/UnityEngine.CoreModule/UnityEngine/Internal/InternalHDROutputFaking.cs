using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Internal
{
	// Token: 0x020003DB RID: 987
	[NativeHeader("Runtime/GfxDevice/HDROutputSettings.h")]
	[ExcludeFromDocs]
	internal static class InternalHDROutputFaking
	{
		// Token: 0x06002147 RID: 8519
		[FreeFunction("HDROutputSettingsBindings::SetFakeHDROutputEnabled")]
		[ExcludeFromDocs]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void SetEnabled(bool enabled);
	}
}
