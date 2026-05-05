using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200022B RID: 555
	internal struct XblSocialManagerEvent
	{
		// Token: 0x06000DE5 RID: 3557 RVA: 0x000112A0 File Offset: 0x0000F4A0
		internal XblSocialManagerUser[] GetUserArray()
		{
			List<XblSocialManagerUser> list = new List<XblSocialManagerUser>();
			foreach (IntPtr intPtr in this.usersAffected)
			{
				if (!(intPtr != IntPtr.Zero))
				{
					break;
				}
				list.Add((XblSocialManagerUser)Marshal.PtrToStructure(intPtr, typeof(XblSocialManagerUser)));
			}
			return list.ToArray();
		}

		// Token: 0x040007B0 RID: 1968
		internal readonly IntPtr user;

		// Token: 0x040007B1 RID: 1969
		internal readonly XblSocialManagerEventType eventType;

		// Token: 0x040007B2 RID: 1970
		internal readonly int hr;

		// Token: 0x040007B3 RID: 1971
		internal readonly XblSocialManagerUserGroupHandle loadedGroup;

		// Token: 0x040007B4 RID: 1972
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		internal readonly IntPtr[] usersAffected;
	}
}
