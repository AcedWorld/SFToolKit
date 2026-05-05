using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000222 RID: 546
	internal struct XblPermissionCheckResult
	{
		// Token: 0x06000DDE RID: 3550 RVA: 0x0001122C File Offset: 0x0000F42C
		internal unsafe T[] GetReasons<T>(Func<XblPermissionDenyReasonDetails, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblPermissionDenyReasonDetails>((IntPtr)((void*)this.reasons), this.reasonsCount, ctor);
		}

		// Token: 0x0400078F RID: 1935
		internal readonly NativeBool isAllowed;

		// Token: 0x04000790 RID: 1936
		internal readonly ulong targetXuid;

		// Token: 0x04000791 RID: 1937
		internal readonly XblAnonymousUserType targetUserType;

		// Token: 0x04000792 RID: 1938
		internal readonly XblPermission permissionRequested;

		// Token: 0x04000793 RID: 1939
		private unsafe readonly XblPermissionDenyReasonDetails* reasons;

		// Token: 0x04000794 RID: 1940
		internal readonly SizeT reasonsCount;
	}
}
