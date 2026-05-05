using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Android
{
	// Token: 0x02000010 RID: 16
	[NativeConditional("PLATFORM_ANDROID")]
	[StaticAccessor("AndroidApp", StaticAccessorType.DoubleColon)]
	[NativeHeader("Modules/AndroidJNI/Public/AndroidApp.bindings.h")]
	internal static class AndroidApp
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000214 RID: 532 RVA: 0x0000940C File Offset: 0x0000760C
		public static AndroidJavaObject Context
		{
			get
			{
				AndroidApp.AcquireContextAndActivity();
				return AndroidApp.m_Context;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000215 RID: 533 RVA: 0x0000942C File Offset: 0x0000762C
		public static AndroidJavaObject Activity
		{
			get
			{
				AndroidApp.AcquireContextAndActivity();
				return AndroidApp.m_Activity;
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000944C File Offset: 0x0000764C
		private static void AcquireContextAndActivity()
		{
			bool flag = AndroidApp.m_Context != null;
			if (!flag)
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					AndroidApp.m_Context = androidJavaClass.GetStatic<AndroidJavaObject>("currentContext");
					AndroidApp.m_Activity = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
				}
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000217 RID: 535
		public static extern IntPtr UnityPlayerRaw { [ThreadSafe] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000218 RID: 536 RVA: 0x000094B4 File Offset: 0x000076B4
		public static AndroidJavaObject UnityPlayer
		{
			get
			{
				bool flag = AndroidApp.m_UnityPlayer != null;
				AndroidJavaObject unityPlayer;
				if (flag)
				{
					unityPlayer = AndroidApp.m_UnityPlayer;
				}
				else
				{
					AndroidApp.m_UnityPlayer = new AndroidJavaObject(AndroidApp.UnityPlayerRaw);
					unityPlayer = AndroidApp.m_UnityPlayer;
				}
				return unityPlayer;
			}
		}

		// Token: 0x04000021 RID: 33
		private static AndroidJavaObject m_Context;

		// Token: 0x04000022 RID: 34
		private static AndroidJavaObject m_Activity;

		// Token: 0x04000023 RID: 35
		private static AndroidJavaObject m_UnityPlayer;
	}
}
