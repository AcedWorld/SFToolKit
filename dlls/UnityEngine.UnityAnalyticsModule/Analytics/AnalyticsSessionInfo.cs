using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics
{
	// Token: 0x02000009 RID: 9
	[RequiredByNativeCode]
	[NativeHeader("UnityAnalyticsScriptingClasses.h")]
	[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
	public static class AnalyticsSessionInfo
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600006E RID: 110 RVA: 0x00002C7C File Offset: 0x00000E7C
		// (remove) Token: 0x0600006F RID: 111 RVA: 0x00002CB0 File Offset: 0x00000EB0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event AnalyticsSessionInfo.SessionStateChanged sessionStateChanged;

		// Token: 0x06000070 RID: 112 RVA: 0x00002CE4 File Offset: 0x00000EE4
		[RequiredByNativeCode]
		internal static void CallSessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged)
		{
			AnalyticsSessionInfo.SessionStateChanged sessionStateChanged = AnalyticsSessionInfo.sessionStateChanged;
			bool flag = sessionStateChanged != null;
			if (flag)
			{
				sessionStateChanged(sessionState, sessionId, sessionElapsedTime, sessionChanged);
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000071 RID: 113
		public static extern AnalyticsSessionState sessionState { [NativeMethod("GetPlayerSessionState")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000072 RID: 114
		public static extern long sessionId { [NativeMethod("GetPlayerSessionId")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000073 RID: 115
		public static extern long sessionCount { [NativeMethod("GetPlayerSessionCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000074 RID: 116
		public static extern long sessionElapsedTime { [NativeMethod("GetPlayerSessionElapsedTime")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000075 RID: 117
		public static extern bool sessionFirstRun { [NativeMethod("GetPlayerSessionFirstRun", false, true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000076 RID: 118
		public static extern string userId { [NativeMethod("GetUserId")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002D0C File Offset: 0x00000F0C
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002D34 File Offset: 0x00000F34
		public static string customUserId
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				string result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = AnalyticsSessionInfo.customUserIdInternal;
				}
				return result;
			}
			set
			{
				bool flag = Analytics.IsInitialized();
				if (flag)
				{
					AnalyticsSessionInfo.customUserIdInternal = value;
				}
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002D54 File Offset: 0x00000F54
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00002D7C File Offset: 0x00000F7C
		public static string customDeviceId
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				string result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = AnalyticsSessionInfo.customDeviceIdInternal;
				}
				return result;
			}
			set
			{
				bool flag = Analytics.IsInitialized();
				if (flag)
				{
					AnalyticsSessionInfo.customDeviceIdInternal = value;
				}
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600007B RID: 123 RVA: 0x00002D9C File Offset: 0x00000F9C
		// (remove) Token: 0x0600007C RID: 124 RVA: 0x00002DD0 File Offset: 0x00000FD0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event AnalyticsSessionInfo.IdentityTokenChanged identityTokenChanged;

		// Token: 0x0600007D RID: 125 RVA: 0x00002E04 File Offset: 0x00001004
		[RequiredByNativeCode]
		internal static void CallIdentityTokenChanged(string token)
		{
			AnalyticsSessionInfo.IdentityTokenChanged identityTokenChanged = AnalyticsSessionInfo.identityTokenChanged;
			bool flag = identityTokenChanged != null;
			if (flag)
			{
				identityTokenChanged(token);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00002E28 File Offset: 0x00001028
		public static string identityToken
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				string result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = AnalyticsSessionInfo.identityTokenInternal;
				}
				return result;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600007F RID: 127
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern string identityTokenInternal { [NativeMethod("GetIdentityToken")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000080 RID: 128
		// (set) Token: 0x06000081 RID: 129
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern string customUserIdInternal { [NativeMethod("GetCustomUserId")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetCustomUserId")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000082 RID: 130
		// (set) Token: 0x06000083 RID: 131
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern string customDeviceIdInternal { [NativeMethod("GetCustomDeviceId")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetCustomDeviceId")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x0200000A RID: 10
		// (Invoke) Token: 0x06000085 RID: 133
		public delegate void SessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged);

		// Token: 0x0200000B RID: 11
		// (Invoke) Token: 0x06000089 RID: 137
		public delegate void IdentityTokenChanged(string token);
	}
}
