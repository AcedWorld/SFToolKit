using System;

namespace UnityEngine.Android
{
	// Token: 0x0200001F RID: 31
	public struct Permission
	{
		// Token: 0x0600025A RID: 602 RVA: 0x00009F24 File Offset: 0x00008124
		private static AndroidJavaObject GetUnityPermissions()
		{
			bool flag = Permission.m_UnityPermissions != null;
			AndroidJavaObject unityPermissions;
			if (flag)
			{
				unityPermissions = Permission.m_UnityPermissions;
			}
			else
			{
				Permission.m_UnityPermissions = new AndroidJavaClass("com.unity3d.player.UnityPermissions");
				unityPermissions = Permission.m_UnityPermissions;
			}
			return unityPermissions;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00009F60 File Offset: 0x00008160
		public static bool HasUserAuthorizedPermission(string permission)
		{
			bool flag = permission == null;
			return !flag;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00009F80 File Offset: 0x00008180
		public static void RequestUserPermission(string permission)
		{
			bool flag = permission == null;
			if (!flag)
			{
				Permission.RequestUserPermissions(new string[]
				{
					permission
				}, null);
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00009FAC File Offset: 0x000081AC
		public static void RequestUserPermissions(string[] permissions)
		{
			bool flag = permissions == null || permissions.Length == 0;
			if (!flag)
			{
				Permission.RequestUserPermissions(permissions, null);
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00009FD4 File Offset: 0x000081D4
		public static void RequestUserPermission(string permission, PermissionCallbacks callbacks)
		{
			bool flag = permission == null;
			if (!flag)
			{
				Permission.RequestUserPermissions(new string[]
				{
					permission
				}, callbacks);
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000A000 File Offset: 0x00008200
		public static void RequestUserPermissions(string[] permissions, PermissionCallbacks callbacks)
		{
			bool flag = permissions == null || permissions.Length == 0;
			if (flag)
			{
			}
		}

		// Token: 0x04000055 RID: 85
		public const string Camera = "android.permission.CAMERA";

		// Token: 0x04000056 RID: 86
		public const string Microphone = "android.permission.RECORD_AUDIO";

		// Token: 0x04000057 RID: 87
		public const string FineLocation = "android.permission.ACCESS_FINE_LOCATION";

		// Token: 0x04000058 RID: 88
		public const string CoarseLocation = "android.permission.ACCESS_COARSE_LOCATION";

		// Token: 0x04000059 RID: 89
		public const string ExternalStorageRead = "android.permission.READ_EXTERNAL_STORAGE";

		// Token: 0x0400005A RID: 90
		public const string ExternalStorageWrite = "android.permission.WRITE_EXTERNAL_STORAGE";

		// Token: 0x0400005B RID: 91
		private static AndroidJavaObject m_UnityPermissions;
	}
}
