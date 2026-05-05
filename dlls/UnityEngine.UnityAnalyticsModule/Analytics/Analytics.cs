using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Analytics
{
	// Token: 0x0200000D RID: 13
	[NativeHeader("Modules/UnityAnalytics/Public/UnityAnalytics.h")]
	[NativeHeader("Modules/UnityConnect/UnityConnectSettings.h")]
	[NativeHeader("Modules/UnityAnalytics/Public/Events/UserCustomEvent.h")]
	[StructLayout(LayoutKind.Sequential)]
	public static class Analytics
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00003210 File Offset: 0x00001410
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00003238 File Offset: 0x00001438
		public static bool initializeOnStartup
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				return !flag && Analytics.initializeOnStartupInternal;
			}
			set
			{
				bool flag = Analytics.IsInitialized();
				if (flag)
				{
					Analytics.initializeOnStartupInternal = value;
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003258 File Offset: 0x00001458
		public static AnalyticsResult ResumeInitialization()
		{
			bool flag = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.ResumeInitializationInternal();
			}
			return result;
		}

		// Token: 0x0600009E RID: 158
		[NativeMethod("ResumeInitialization")]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult ResumeInitializationInternal();

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600009F RID: 159
		// (set) Token: 0x060000A0 RID: 160
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool initializeOnStartupInternal { [NativeMethod("GetInitializeOnStartup")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetInitializeOnStartup")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x060000A1 RID: 161
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool IsInitialized();

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000A2 RID: 162
		// (set) Token: 0x060000A3 RID: 163
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool enabledInternal { [NativeMethod("GetEnabled")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetEnabled")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000A4 RID: 164
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool playerOptedOutInternal { [NativeMethod("GetPlayerOptedOut")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000A5 RID: 165
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		private static extern string eventUrlInternal { [NativeMethod("GetEventUrl")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000A6 RID: 166
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		private static extern string configUrlInternal { [NativeMethod("GetConfigUrl")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000A7 RID: 167
		[StaticAccessor("GetUnityConnectSettings()", StaticAccessorType.Dot)]
		private static extern string dashboardUrlInternal { [NativeMethod("GetDashboardUrl")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000A8 RID: 168
		// (set) Token: 0x060000A9 RID: 169
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool limitUserTrackingInternal { [NativeMethod("GetLimitUserTracking")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetLimitUserTracking")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000AA RID: 170
		// (set) Token: 0x060000AB RID: 171
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		private static extern bool deviceStatsEnabledInternal { [NativeMethod("GetDeviceStatsEnabled")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetDeviceStatsEnabled")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x060000AC RID: 172
		[NativeMethod("FlushEvents")]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool FlushArchivedEvents();

		// Token: 0x060000AD RID: 173
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult Transaction(string productId, double amount, string currency, string receiptPurchaseData, string signature, bool usingIAPService);

		// Token: 0x060000AE RID: 174
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult SendCustomEventName(string customEventName);

		// Token: 0x060000AF RID: 175
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnalyticsResult SendCustomEvent(CustomEventData eventData);

		// Token: 0x060000B0 RID: 176
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult IsCustomEventWithLimitEnabled(string customEventName);

		// Token: 0x060000B1 RID: 177
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult EnableCustomEventWithLimit(string customEventName, bool enable);

		// Token: 0x060000B2 RID: 178
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult IsEventWithLimitEnabled(string eventName, int ver, string prefix);

		// Token: 0x060000B3 RID: 179
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult EnableEventWithLimit(string eventName, bool enable, int ver, string prefix);

		// Token: 0x060000B4 RID: 180
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult RegisterEventWithLimit(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo, bool notifyServer);

		// Token: 0x060000B5 RID: 181
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult RegisterEventsWithLimit(string[] eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo, bool notifyServer);

		// Token: 0x060000B6 RID: 182
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult SendEventWithLimit(string eventName, object parameters, int ver, string prefix);

		// Token: 0x060000B7 RID: 183
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult SetEventWithLimitEndPoint(string eventName, string endPoint, int ver, string prefix);

		// Token: 0x060000B8 RID: 184
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern AnalyticsResult SetEventWithLimitPriority(string eventName, AnalyticsEventPriority eventPriority, int ver, string prefix);

		// Token: 0x060000B9 RID: 185
		[ThreadSafe]
		[StaticAccessor("GetUnityAnalytics()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool QueueEvent(string eventName, object parameters, int ver, string prefix);

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00003280 File Offset: 0x00001480
		public static bool playerOptedOut
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				return !flag && Analytics.playerOptedOutInternal;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000032A8 File Offset: 0x000014A8
		public static string eventUrl
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				string result;
				if (flag)
				{
					result = string.Empty;
				}
				else
				{
					result = Analytics.eventUrlInternal;
				}
				return result;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000032D4 File Offset: 0x000014D4
		public static string dashboardUrl
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				string result;
				if (flag)
				{
					result = string.Empty;
				}
				else
				{
					result = Analytics.dashboardUrlInternal;
				}
				return result;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00003300 File Offset: 0x00001500
		public static string configUrl
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				string result;
				if (flag)
				{
					result = string.Empty;
				}
				else
				{
					result = Analytics.configUrlInternal;
				}
				return result;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0000332C File Offset: 0x0000152C
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00003354 File Offset: 0x00001554
		public static bool limitUserTracking
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				return !flag && Analytics.limitUserTrackingInternal;
			}
			set
			{
				bool flag = Analytics.IsInitialized();
				if (flag)
				{
					Analytics.limitUserTrackingInternal = value;
				}
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003374 File Offset: 0x00001574
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x0000339C File Offset: 0x0000159C
		public static bool deviceStatsEnabled
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				return !flag && Analytics.deviceStatsEnabledInternal;
			}
			set
			{
				bool flag = Analytics.IsInitialized();
				if (flag)
				{
					Analytics.deviceStatsEnabledInternal = value;
				}
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x000033BC File Offset: 0x000015BC
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x000033E4 File Offset: 0x000015E4
		public static bool enabled
		{
			get
			{
				bool flag = !Analytics.IsInitialized();
				return !flag && Analytics.enabledInternal;
			}
			set
			{
				bool flag = Analytics.IsInitialized();
				if (flag)
				{
					Analytics.enabledInternal = value;
				}
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003404 File Offset: 0x00001604
		public static AnalyticsResult FlushEvents()
		{
			bool flag = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = (Analytics.FlushArchivedEvents() ? AnalyticsResult.Ok : AnalyticsResult.NotInitialized);
			}
			return result;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003434 File Offset: 0x00001634
		[Obsolete("SetUserId is no longer supported", true)]
		public static AnalyticsResult SetUserId(string userId)
		{
			bool flag = string.IsNullOrEmpty(userId);
			if (flag)
			{
				throw new ArgumentException("Cannot set userId to an empty or null string");
			}
			return AnalyticsResult.InvalidData;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000345C File Offset: 0x0000165C
		[Obsolete("SetUserGender is no longer supported", true)]
		public static AnalyticsResult SetUserGender(Gender gender)
		{
			return AnalyticsResult.InvalidData;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003470 File Offset: 0x00001670
		[Obsolete("SetUserBirthYear is no longer supported", true)]
		public static AnalyticsResult SetUserBirthYear(int birthYear)
		{
			return AnalyticsResult.InvalidData;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003484 File Offset: 0x00001684
		[Obsolete("SendUserInfoEvent is no longer supported", true)]
		private static AnalyticsResult SendUserInfoEvent(object param)
		{
			return AnalyticsResult.InvalidData;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003498 File Offset: 0x00001698
		public static AnalyticsResult Transaction(string productId, decimal amount, string currency)
		{
			return Analytics.Transaction(productId, amount, currency, null, null, false);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000034B8 File Offset: 0x000016B8
		public static AnalyticsResult Transaction(string productId, decimal amount, string currency, string receiptPurchaseData, string signature)
		{
			return Analytics.Transaction(productId, amount, currency, receiptPurchaseData, signature, false);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000034D8 File Offset: 0x000016D8
		public static AnalyticsResult Transaction(string productId, decimal amount, string currency, string receiptPurchaseData, string signature, bool usingIAPService)
		{
			bool flag = string.IsNullOrEmpty(productId);
			if (flag)
			{
				throw new ArgumentException("Cannot set productId to an empty or null string");
			}
			bool flag2 = string.IsNullOrEmpty(currency);
			if (flag2)
			{
				throw new ArgumentException("Cannot set currency to an empty or null string");
			}
			bool flag3 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag3)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				bool flag4 = receiptPurchaseData == null;
				if (flag4)
				{
					receiptPurchaseData = string.Empty;
				}
				bool flag5 = signature == null;
				if (flag5)
				{
					signature = string.Empty;
				}
				result = Analytics.Transaction(productId, Convert.ToDouble(amount), currency, receiptPurchaseData, signature, usingIAPService);
			}
			return result;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000355C File Offset: 0x0000175C
		public static AnalyticsResult CustomEvent(string customEventName)
		{
			bool flag = string.IsNullOrEmpty(customEventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set custom event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.SendCustomEventName(customEventName);
			}
			return result;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000359C File Offset: 0x0000179C
		public static AnalyticsResult CustomEvent(string customEventName, Vector3 position)
		{
			bool flag = string.IsNullOrEmpty(customEventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set custom event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				CustomEventData customEventData = new CustomEventData(customEventName);
				customEventData.AddDouble("x", (double)Convert.ToDecimal(position.x));
				customEventData.AddDouble("y", (double)Convert.ToDecimal(position.y));
				customEventData.AddDouble("z", (double)Convert.ToDecimal(position.z));
				AnalyticsResult analyticsResult = Analytics.SendCustomEvent(customEventData);
				customEventData.Dispose();
				result = analyticsResult;
			}
			return result;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003644 File Offset: 0x00001844
		public static AnalyticsResult CustomEvent(string customEventName, IDictionary<string, object> eventData)
		{
			bool flag = string.IsNullOrEmpty(customEventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set custom event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				bool flag3 = eventData == null;
				if (flag3)
				{
					result = Analytics.SendCustomEventName(customEventName);
				}
				else
				{
					CustomEventData customEventData = new CustomEventData(customEventName);
					AnalyticsResult analyticsResult = AnalyticsResult.InvalidData;
					try
					{
						customEventData.AddDictionary(eventData);
						analyticsResult = Analytics.SendCustomEvent(customEventData);
					}
					finally
					{
						customEventData.Dispose();
					}
					result = analyticsResult;
				}
			}
			return result;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000036CC File Offset: 0x000018CC
		public static AnalyticsResult EnableCustomEvent(string customEventName, bool enabled)
		{
			bool flag = string.IsNullOrEmpty(customEventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.EnableCustomEventWithLimit(customEventName, enabled);
			}
			return result;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000370C File Offset: 0x0000190C
		public static AnalyticsResult IsCustomEventEnabled(string customEventName)
		{
			bool flag = string.IsNullOrEmpty(customEventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.IsCustomEventWithLimitEnabled(customEventName);
			}
			return result;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000374C File Offset: 0x0000194C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey = "", string prefix = "")
		{
			string assemblyInfo = string.Empty;
			assemblyInfo = Assembly.GetCallingAssembly().FullName;
			return Analytics.RegisterEvent(eventName, maxEventPerHour, maxItems, vendorKey, 1, prefix, assemblyInfo);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000377C File Offset: 0x0000197C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix = "")
		{
			string assemblyInfo = string.Empty;
			assemblyInfo = Assembly.GetCallingAssembly().FullName;
			return Analytics.RegisterEvent(eventName, maxEventPerHour, maxItems, vendorKey, ver, prefix, assemblyInfo);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000037B0 File Offset: 0x000019B0
		private static AnalyticsResult RegisterEvent(string eventName, int maxEventPerHour, int maxItems, string vendorKey, int ver, string prefix, string assemblyInfo)
		{
			bool flag = string.IsNullOrEmpty(eventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.RegisterEventWithLimit(eventName, maxEventPerHour, maxItems, vendorKey, ver, prefix, assemblyInfo, true);
			}
			return result;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000037F8 File Offset: 0x000019F8
		public static AnalyticsResult SendEvent(string eventName, object parameters, int ver = 1, string prefix = "")
		{
			bool flag = string.IsNullOrEmpty(eventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			bool flag2 = parameters == null;
			if (flag2)
			{
				throw new ArgumentException("Cannot set parameters to null");
			}
			bool flag3 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag3)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.SendEventWithLimit(eventName, parameters, ver, prefix);
			}
			return result;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000384C File Offset: 0x00001A4C
		public static AnalyticsResult SetEventEndPoint(string eventName, string endPoint, int ver = 1, string prefix = "")
		{
			bool flag = string.IsNullOrEmpty(eventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			bool flag2 = endPoint == null;
			if (flag2)
			{
				throw new ArgumentException("Cannot set parameters to null");
			}
			bool flag3 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag3)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.SetEventWithLimitEndPoint(eventName, endPoint, ver, prefix);
			}
			return result;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000038A0 File Offset: 0x00001AA0
		public static AnalyticsResult SetEventPriority(string eventName, AnalyticsEventPriority eventPriority, int ver = 1, string prefix = "")
		{
			bool flag = string.IsNullOrEmpty(eventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.SetEventWithLimitPriority(eventName, eventPriority, ver, prefix);
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000038E0 File Offset: 0x00001AE0
		public static AnalyticsResult EnableEvent(string eventName, bool enabled, int ver = 1, string prefix = "")
		{
			bool flag = string.IsNullOrEmpty(eventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.EnableEventWithLimit(eventName, enabled, ver, prefix);
			}
			return result;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00003920 File Offset: 0x00001B20
		public static AnalyticsResult IsEventEnabled(string eventName, int ver = 1, string prefix = "")
		{
			bool flag = string.IsNullOrEmpty(eventName);
			if (flag)
			{
				throw new ArgumentException("Cannot set event name to an empty or null string");
			}
			bool flag2 = !Analytics.IsInitialized();
			AnalyticsResult result;
			if (flag2)
			{
				result = AnalyticsResult.NotInitialized;
			}
			else
			{
				result = Analytics.IsEventWithLimitEnabled(eventName, ver, prefix);
			}
			return result;
		}
	}
}
