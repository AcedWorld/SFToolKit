using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Connect
{
	// Token: 0x02000002 RID: 2
	[NativeHeader("Modules/UnityConnect/UnityConnectSettings.h")]
	internal class UnityConnectSettings : Object
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1
		// (set) Token: 0x06000002 RID: 2
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		public static extern bool enabled { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3
		// (set) Token: 0x06000004 RID: 4
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		public static extern bool testMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5
		// (set) Token: 0x06000006 RID: 6
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		public static extern string eventUrl { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7
		// (set) Token: 0x06000008 RID: 8
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		public static extern string eventOldUrl { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9
		// (set) Token: 0x0600000A RID: 10
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		public static extern string configUrl { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11
		// (set) Token: 0x0600000C RID: 12
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		public static extern int testInitMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }
	}
}
