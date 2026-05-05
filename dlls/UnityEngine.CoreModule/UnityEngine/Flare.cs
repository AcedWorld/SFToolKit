using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x02000172 RID: 370
	[NativeHeader("Runtime/Camera/Flare.h")]
	public sealed class Flare : Object
	{
		// Token: 0x06000F63 RID: 3939 RVA: 0x00015AFC File Offset: 0x00013CFC
		public Flare()
		{
			Flare.Internal_Create(this);
		}

		// Token: 0x06000F64 RID: 3940
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] Flare self);
	}
}
