using System;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Networking
{
	// Token: 0x0200000D RID: 13
	[NativeHeader("UnityWebRequestScriptingClasses.h")]
	[UsedByNativeCode]
	[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequestAsyncOperation.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class UnityWebRequestAsyncOperation : AsyncOperation
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00003BD4 File Offset: 0x00001DD4
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00003BDC File Offset: 0x00001DDC
		public UnityWebRequest webRequest { get; internal set; }
	}
}
