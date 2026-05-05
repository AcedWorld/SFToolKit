using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001B5 RID: 437
	[MovedFrom("Unity.GameCore")]
	public class XUserHandle : EquatableHandle
	{
		// Token: 0x06000A3E RID: 2622 RVA: 0x0000F65F File Offset: 0x0000D85F
		internal XUserHandle(IntPtr interopHandle) : base(IntPtr.Zero, true, interopHandle)
		{
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x0000F66E File Offset: 0x0000D86E
		internal XUserHandle(IntPtr interopHandle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle, interopHandle)
		{
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x0000F67D File Offset: 0x0000D87D
		internal static int WrapAndReturnHResult(int hresult, IntPtr interopHandle, out XUserHandle handle)
		{
			if (HR.SUCCEEDED(hresult) && interopHandle != IntPtr.Zero)
			{
				handle = new XUserHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x0000F6A2 File Offset: 0x0000D8A2
		protected override bool ReleaseHandle()
		{
			NativeMethods.XUserCloseHandle(this.handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000A42 RID: 2626 RVA: 0x0000F6BB File Offset: 0x0000D8BB
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}
	}
}
