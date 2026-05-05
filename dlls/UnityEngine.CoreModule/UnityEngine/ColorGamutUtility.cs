using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000155 RID: 341
	public class ColorGamutUtility
	{
		// Token: 0x06000ACC RID: 2764
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern ColorPrimaries GetColorPrimaries(ColorGamut gamut);

		// Token: 0x06000ACD RID: 2765
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern WhitePoint GetWhitePoint(ColorGamut gamut);

		// Token: 0x06000ACE RID: 2766
		[FreeFunction(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern TransferFunction GetTransferFunction(ColorGamut gamut);
	}
}
