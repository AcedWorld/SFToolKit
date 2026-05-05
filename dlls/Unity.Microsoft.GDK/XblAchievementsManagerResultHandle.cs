using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000073 RID: 115
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementsManagerResultHandle : EquatableHandle
	{
		// Token: 0x06000453 RID: 1107 RVA: 0x00009C66 File Offset: 0x00007E66
		internal XblAchievementsManagerResultHandle(XblAchievementsManagerResultHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.Ptr)
		{
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00009C7A File Offset: 0x00007E7A
		internal static int WrapAndReturnHResult(int hresult, XblAchievementsManagerResultHandle interopHandle, out XblAchievementsManagerResultHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XblAchievementsManagerResultHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00009C94 File Offset: 0x00007E94
		public override bool Equals(object obj)
		{
			XblAchievementsManagerResultHandle xblAchievementsManagerResultHandle = obj as XblAchievementsManagerResultHandle;
			return xblAchievementsManagerResultHandle != null && base.Handle == xblAchievementsManagerResultHandle.Handle;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00009CC0 File Offset: 0x00007EC0
		public override int GetHashCode()
		{
			return base.Handle.GetHashCode();
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00009CDB File Offset: 0x00007EDB
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00009CED File Offset: 0x00007EED
		protected override bool ReleaseHandle()
		{
			XblInterop.XblAchievementsManagerResultCloseHandle(base.Handle);
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00009D06 File Offset: 0x00007F06
		public static bool operator ==(XblAchievementsManagerResultHandle handle1, XblAchievementsManagerResultHandle handle2)
		{
			if (handle1 != null)
			{
				return handle1.Equals(handle2);
			}
			return handle2 == null;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00009D17 File Offset: 0x00007F17
		public static bool operator !=(XblAchievementsManagerResultHandle handle1, XblAchievementsManagerResultHandle handle2)
		{
			return !(handle1 == handle2);
		}
	}
}
