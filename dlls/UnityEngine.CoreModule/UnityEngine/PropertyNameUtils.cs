using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000219 RID: 537
	[NativeHeader("Runtime/Utilities/PropertyName.h")]
	internal class PropertyNameUtils
	{
		// Token: 0x060017B1 RID: 6065 RVA: 0x00027720 File Offset: 0x00025920
		[FreeFunction(IsThreadSafe = true)]
		public static PropertyName PropertyNameFromString([Unmarshalled] string name)
		{
			PropertyName result;
			PropertyNameUtils.PropertyNameFromString_Injected(name, out result);
			return result;
		}

		// Token: 0x060017B3 RID: 6067
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PropertyNameFromString_Injected(string name, out PropertyName ret);
	}
}
