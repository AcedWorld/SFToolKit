using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001E7 RID: 487
	internal static class XblInterop
	{
		// Token: 0x06000C33 RID: 3123
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsResultGetAchievements(IntPtr resultHandle, out IntPtr achievements, out SizeT achievementsCount);

		// Token: 0x06000C34 RID: 3124
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsResultHasNext(IntPtr resultHandle, [MarshalAs(UnmanagedType.U1)] out bool hasNext);

		// Token: 0x06000C35 RID: 3125
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsResultGetNextAsync(IntPtr resultHandle, uint maxItems, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C36 RID: 3126
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsResultGetNextResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle resultHandle);

		// Token: 0x06000C37 RID: 3127
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsGetAchievementsForTitleIdAsync(IntPtr xboxLiveContext, ulong xboxUserId, uint titleId, XblAchievementType type, [MarshalAs(UnmanagedType.U1)] bool unlockedOnly, XblAchievementOrderBy orderBy, uint skipItems, uint maxItems, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C38 RID: 3128
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsGetAchievementsForTitleIdResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle result);

		// Token: 0x06000C39 RID: 3129
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsUpdateAchievementAsync(IntPtr xboxLiveContext, ulong xboxUserId, byte[] achievementId, uint percentComplete, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C3A RID: 3130
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsUpdateAchievementForTitleIdAsync(IntPtr xboxLiveContext, ulong xboxUserId, uint titleId, byte[] serviceConfigurationId, byte[] achievementId, uint percentComplete, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C3B RID: 3131
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsGetAchievementAsync(IntPtr xboxLiveContext, ulong xboxUserId, byte[] serviceConfigurationId, byte[] achievementId, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C3C RID: 3132
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsGetAchievementResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle result);

		// Token: 0x06000C3D RID: 3133
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblFunctionContext XblAchievementsAddAchievementProgressChangeHandler(IntPtr xblContext, XblInterop.XblAchievementsProgressChangeHandler handler, IntPtr handlerContext);

		// Token: 0x06000C3E RID: 3134
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblAchievementsRemoveAchievementProgressChangeHandler(IntPtr xblContextHandle, XblFunctionContext functionContext);

		// Token: 0x06000C3F RID: 3135
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsResultDuplicateHandle(IntPtr handle, out XblAchievementsResultHandle duplicatedHandle);

		// Token: 0x06000C40 RID: 3136
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblAchievementsResultCloseHandle(IntPtr handle);

		// Token: 0x06000C41 RID: 3137
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerResultGetAchievements(IntPtr resultHandle, out IntPtr achievements, out ulong achievementsCount);

		// Token: 0x06000C42 RID: 3138
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerResultDuplicateHandle(IntPtr handle, out XblAchievementsManagerResultHandle duplicatedHandle);

		// Token: 0x06000C43 RID: 3139
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblAchievementsManagerResultCloseHandle(IntPtr handle);

		// Token: 0x06000C44 RID: 3140
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerAddLocalUser(IntPtr user, XTaskQueueHandle queue);

		// Token: 0x06000C45 RID: 3141
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerRemoveLocalUser(IntPtr user);

		// Token: 0x06000C46 RID: 3142
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerIsUserInitialized(ulong xboxUserId);

		// Token: 0x06000C47 RID: 3143
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerDoWork(out IntPtr achievementsEvents, out SizeT achievementsEventsCount);

		// Token: 0x06000C48 RID: 3144
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerGetAchievement(ulong xboxUserId, byte[] achievementId, out XblAchievementsManagerResultHandle achievementResult);

		// Token: 0x06000C49 RID: 3145
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerGetAchievements(ulong xboxUserId, XblAchievementOrderBy sortField, XblAchievementsManagerSortOrder sortOrder, out XblAchievementsManagerResultHandle achievementsResult);

		// Token: 0x06000C4A RID: 3146
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerGetAchievementsByState(ulong xboxUserId, XblAchievementOrderBy sortField, XblAchievementsManagerSortOrder sortOrder, XblAchievementProgressState achievementState, out XblAchievementsManagerResultHandle achievementResult);

		// Token: 0x06000C4B RID: 3147
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblAchievementsManagerUpdateAchievement(ulong xboxUserId, byte[] achievementId, byte currentProgress);

		// Token: 0x06000C4C RID: 3148
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int HCSettingsSetTraceLevel(HCTraceLevel traceLevel);

		// Token: 0x06000C4D RID: 3149
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int HCSettingsGetTraceLevel(out HCTraceLevel traceLevel);

		// Token: 0x06000C4E RID: 3150
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void HCTraceSetClientCallback(HCTraceCallback callback);

		// Token: 0x06000C4F RID: 3151
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void HCTraceSetTraceToDebugger([MarshalAs(UnmanagedType.U1)] bool traceToDebugger);

		// Token: 0x06000C50 RID: 3152
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallRequestSetRequestBodyBytes(IntPtr call, byte[] requestBodyBytes, uint requestBodySize);

		// Token: 0x06000C51 RID: 3153
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetNetworkErrorCode(IntPtr call, out int networkErrorCode, out uint platformNetworkErrorCode);

		// Token: 0x06000C52 RID: 3154
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallRequestSetLongHttpCall(IntPtr call, NativeBool longHttpCall);

		// Token: 0x06000C53 RID: 3155
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallPerformAsync(IntPtr call, XblHttpCallResponseBodyType type, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C54 RID: 3156
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallSetTracing(IntPtr call, NativeBool traceCall);

		// Token: 0x06000C55 RID: 3157
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallCreate(IntPtr xblContext, byte[] method, byte[] url, out XblHttpCallHandle call);

		// Token: 0x06000C56 RID: 3158
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblHttpCallCloseHandle(IntPtr call);

		// Token: 0x06000C57 RID: 3159
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallRequestSetRequestBodyString(IntPtr call, byte[] requestBodyString);

		// Token: 0x06000C58 RID: 3160
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetResponseString(IntPtr call, out UTF8StringPtr responseString);

		// Token: 0x06000C59 RID: 3161
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetHeaderAtIndex(IntPtr call, uint headerIndex, out UTF8StringPtr headerName, out UTF8StringPtr headerValue);

		// Token: 0x06000C5A RID: 3162
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetResponseBodyBytesSize(IntPtr call, out SizeT bufferSize);

		// Token: 0x06000C5B RID: 3163
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetPlatformNetworkErrorMessage(IntPtr call, out UTF8StringPtr platformNetworkErrorMessage);

		// Token: 0x06000C5C RID: 3164
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetResponseBodyBytes(IntPtr call, SizeT bufferSize, [Out] byte[] buffer, out SizeT bufferUsed);

		// Token: 0x06000C5D RID: 3165
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallRequestSetRetryAllowed(IntPtr call, NativeBool retryAllowed);

		// Token: 0x06000C5E RID: 3166
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallRequestSetHeader(IntPtr call, byte[] headerName, byte[] headerValue, NativeBool allowTracing);

		// Token: 0x06000C5F RID: 3167
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallDuplicateHandle(IntPtr call, out XblHttpCallHandle duplicateHandle);

		// Token: 0x06000C60 RID: 3168
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetNumHeaders(IntPtr call, out uint numHeaders);

		// Token: 0x06000C61 RID: 3169
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetStatusCode(IntPtr call, out uint statusCode);

		// Token: 0x06000C62 RID: 3170
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetHeader(IntPtr call, byte[] headerName, out UTF8StringPtr headerValue);

		// Token: 0x06000C63 RID: 3171
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallGetRequestUrl(IntPtr call, out UTF8StringPtr url);

		// Token: 0x06000C64 RID: 3172
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblHttpCallRequestSetRetryCacheId(IntPtr call, uint retryAfterCacheId);

		// Token: 0x06000C65 RID: 3173
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblLeaderboardGetLeaderboardAsync(IntPtr xboxLiveContext, XblLeaderboardQuery leaderboardQuery, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C66 RID: 3174
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblLeaderboardGetLeaderboardResultSize(XAsyncBlockPtr asyncBlockPtr, out SizeT resultSizeInBytes);

		// Token: 0x06000C67 RID: 3175
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblLeaderboardGetLeaderboardResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		// Token: 0x06000C68 RID: 3176
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblLeaderboardResultGetNextAsync(IntPtr xboxLiveContext, [In] ref XblLeaderboardResult leaderboardResult, uint maxItems, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C69 RID: 3177
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblLeaderboardResultGetNextResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		// Token: 0x06000C6A RID: 3178
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblLeaderboardResultGetNextResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		// Token: 0x06000C6B RID: 3179
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingCreateMatchTicketAsync(IntPtr xboxLiveContext, XblMultiplayerSessionReference ticketSessionReference, byte[] matchmakingServiceConfigurationId, byte[] hopperName, ulong ticketTimeout, XblPreserveSessionMode preserveSession, byte[] ticketAttributesJson, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C6C RID: 3180
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingCreateMatchTicketResult(XAsyncBlockPtr async, out XblCreateMatchTicketResponse resultPtr);

		// Token: 0x06000C6D RID: 3181
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingDeleteMatchTicketAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, byte[] hopperName, byte[] ticketId, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C6E RID: 3182
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingGetMatchTicketDetailsAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, byte[] hopperName, byte[] ticketId, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C6F RID: 3183
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingGetMatchTicketDetailsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		// Token: 0x06000C70 RID: 3184
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingGetMatchTicketDetailsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		// Token: 0x06000C71 RID: 3185
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingGetHopperStatisticsAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, byte[] hopperName, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000C72 RID: 3186
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingGetHopperStatisticsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		// Token: 0x06000C73 RID: 3187
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMatchmakingGetHopperStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		// Token: 0x06000C74 RID: 3188
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(ulong xboxUserId, [In] ref XblMultiplayerSessionReference sessionRef, [In] ref XblMultiplayerSessionInitArgs initArgs);

		// Token: 0x06000C75 RID: 3189
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void XblMultiplayerSessionCloseHandle(IntPtr handle);

		// Token: 0x06000C76 RID: 3190
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern TimeT XblMultiplayerSessionTimeOfSession(IntPtr handle);

		// Token: 0x06000C77 RID: 3191
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerSessionInitializationInfo* XblMultiplayerSessionGetInitializationInfo(IntPtr handle);

		// Token: 0x06000C78 RID: 3192
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionSubscribedChangeTypes(IntPtr handle);

		// Token: 0x06000C79 RID: 3193
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionHostCandidates(IntPtr handle, out IntPtr deviceTokens, out SizeT deviceTokensCount);

		// Token: 0x06000C7A RID: 3194
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerSessionReference* XblMultiplayerSessionSessionReference(IntPtr handle);

		// Token: 0x06000C7B RID: 3195
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerSessionSessionConstants(IntPtr handle);

		// Token: 0x06000C7C RID: 3196
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void XblMultiplayerSessionConstantsSetMaxMembersInSession(IntPtr handle, uint maxMembersInSession);

		// Token: 0x06000C7D RID: 3197
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void XblMultiplayerSessionConstantsSetVisibility(IntPtr handle, XblMultiplayerSessionVisibility visibility);

		// Token: 0x06000C7E RID: 3198
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionConstantsSetTimeouts(IntPtr handle, ulong memberReservedTimeout, ulong memberInactiveTimeout, ulong memberReadyTimeout, ulong sessionEmptyTimeout);

		// Token: 0x06000C7F RID: 3199
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionConstantsSetQosConnectivityMetrics(IntPtr handle, NativeBool enableLatencyMetric, NativeBool enableBandwidthDownMetric, NativeBool enableBandwidthUpMetric, NativeBool enableCustomMetric);

		// Token: 0x06000C80 RID: 3200
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionConstantsSetMemberInitialization(IntPtr handle, XblMultiplayerMemberInitialization memberInitialization);

		// Token: 0x06000C81 RID: 3201
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionConstantsSetPeerToPeerRequirements(IntPtr handle, XblMultiplayerPeerToPeerRequirements requirements);

		// Token: 0x06000C82 RID: 3202
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(IntPtr handle, byte[] measurementServerAddressesJson);

		// Token: 0x06000C83 RID: 3203
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSessionConstantsSetCapabilities(IntPtr handle, XblMultiplayerSessionCapabilities capabilities);

		// Token: 0x06000C84 RID: 3204
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerSessionProperties* XblMultiplayerSessionSessionProperties(IntPtr handle);

		// Token: 0x06000C85 RID: 3205
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSessionPropertiesSetKeywords(IntPtr handle, IntPtr keywords, SizeT keywordsCount);

		// Token: 0x06000C86 RID: 3206
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void XblMultiplayerSessionPropertiesSetJoinRestriction(IntPtr handle, XblMultiplayerSessionRestriction joinRestriction);

		// Token: 0x06000C87 RID: 3207
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void XblMultiplayerSessionPropertiesSetReadRestriction(IntPtr handle, XblMultiplayerSessionRestriction readRestriction);

		// Token: 0x06000C88 RID: 3208
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSessionPropertiesSetTurnCollection(IntPtr handle, [In] uint[] turnCollectionMemberIds, SizeT turnCollectionMemberIdsCount);

		// Token: 0x06000C89 RID: 3209
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSessionMembers(IntPtr handle, out IntPtr members, out SizeT membersCount);

		// Token: 0x06000C8A RID: 3210
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerMatchmakingServer* XblMultiplayerSessionMatchmakingServer(IntPtr handle);

		// Token: 0x06000C8B RID: 3211
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerSessionMember* XblMultiplayerSessionCurrentUser(IntPtr handle);

		// Token: 0x06000C8C RID: 3212
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern XblWriteSessionStatus XblMultiplayerSessionWriteStatus(IntPtr handle);

		// Token: 0x06000C8D RID: 3213
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionJoin(IntPtr handle, byte[] memberCustomConstantsJson, [MarshalAs(UnmanagedType.U1)] bool initializeRequested, [MarshalAs(UnmanagedType.U1)] bool joinWithActiveStatus);

		// Token: 0x06000C8E RID: 3214
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void XblMultiplayerSessionSetHostDeviceToken(IntPtr handle, XblDeviceToken hostDeviceToken);

		// Token: 0x06000C8F RID: 3215
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void XblMultiplayerSessionSetClosed(IntPtr handle, [MarshalAs(UnmanagedType.U1)] bool closed);

		// Token: 0x06000C90 RID: 3216
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionSetSessionChangeSubscription(IntPtr handle, XblMultiplayerSessionChangeTypes changeTypes);

		// Token: 0x06000C91 RID: 3217
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionLeave(IntPtr handle);

		// Token: 0x06000C92 RID: 3218
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionCurrentUserSetRoles(IntPtr handle, IntPtr roles, SizeT rolesCount);

		// Token: 0x06000C93 RID: 3219
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionCurrentUserSetEncounters(IntPtr handle, IntPtr encounters, SizeT encountersCount);

		// Token: 0x06000C94 RID: 3220
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionCurrentUserSetMembersInGroup(IntPtr handle, uint[] memberIds, SizeT memberIdsCount);

		// Token: 0x06000C95 RID: 3221
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionCurrentUserSetGroups(IntPtr handle, IntPtr groups, SizeT groupsCount);

		// Token: 0x06000C96 RID: 3222
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionCurrentUserSetCustomPropertyJson(IntPtr handle, byte[] name, byte[] valueJson);

		// Token: 0x06000C97 RID: 3223
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(IntPtr handle, byte[] name);

		// Token: 0x06000C98 RID: 3224
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionCurrentUserSetStatus(IntPtr handle, XblMultiplayerSessionMemberStatus status);

		// Token: 0x06000C99 RID: 3225
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(IntPtr handle, byte[] value);

		// Token: 0x06000C9A RID: 3226
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblFormatSecureDeviceAddress(byte[] deviceId, out XblFormattedSecureDeviceAddress address);

		// Token: 0x06000C9B RID: 3227
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleDuplicateHandle([In] XblMultiplayerSearchHandle handle, out XblMultiplayerSearchHandle duplicatedHandle);

		// Token: 0x06000C9C RID: 3228
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern void XblMultiplayerSearchHandleCloseHandle(IntPtr handle);

		// Token: 0x06000C9D RID: 3229
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetSessionReference([In] IntPtr handle, out XblMultiplayerSessionReference sessionRef);

		// Token: 0x06000C9E RID: 3230
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetId([In] IntPtr handle, out UTF8StringPtr id);

		// Token: 0x06000C9F RID: 3231
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetSessionOwnerXuids([In] IntPtr handle, out IntPtr xuids, out SizeT xuidsCount);

		// Token: 0x06000CA0 RID: 3232
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetTags([In] IntPtr handle, out IntPtr tags, out SizeT tagsCount);

		// Token: 0x06000CA1 RID: 3233
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetStringAttributes([In] IntPtr handle, out IntPtr attributes, out SizeT attributesCount);

		// Token: 0x06000CA2 RID: 3234
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetNumberAttributes([In] IntPtr handle, out IntPtr attributes, out SizeT attributesCount);

		// Token: 0x06000CA3 RID: 3235
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetVisibility([In] IntPtr handle, out XblMultiplayerSessionVisibility visibility);

		// Token: 0x06000CA4 RID: 3236
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetJoinRestriction([In] IntPtr handle, out XblMultiplayerSessionRestriction joinRestriction);

		// Token: 0x06000CA5 RID: 3237
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetSessionClosed([In] IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool closed);

		// Token: 0x06000CA6 RID: 3238
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetMemberCounts([In] IntPtr handle, out SizeT maxMembers, out SizeT currentMembers);

		// Token: 0x06000CA7 RID: 3239
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetCreationTime([In] IntPtr handle, out TimeT creationTime);

		// Token: 0x06000CA8 RID: 3240
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSearchHandleGetCustomSessionPropertiesJson([In] IntPtr handle, out UTF8StringPtr customPropertiesJson);

		// Token: 0x06000CA9 RID: 3241
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerWriteSessionAsync(IntPtr xblContext, IntPtr multiplayerSession, XblMultiplayerSessionWriteMode writeMode, XAsyncBlockPtr async);

		// Token: 0x06000CAA RID: 3242
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerWriteSessionResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

		// Token: 0x06000CAB RID: 3243
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerWriteSessionByHandleAsync(IntPtr xblContext, IntPtr multiplayerSession, XblMultiplayerSessionWriteMode writeMode, byte[] handleId, XAsyncBlockPtr async);

		// Token: 0x06000CAC RID: 3244
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerWriteSessionByHandleResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

		// Token: 0x06000CAD RID: 3245
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerGetSessionAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference sessionRef, XAsyncBlockPtr async);

		// Token: 0x06000CAE RID: 3246
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerGetSessionResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

		// Token: 0x06000CAF RID: 3247
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerGetSessionByHandleAsync(IntPtr xblContext, byte[] handleId, XAsyncBlockPtr async);

		// Token: 0x06000CB0 RID: 3248
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerGetSessionByHandleResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

		// Token: 0x06000CB1 RID: 3249
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerQuerySessionsAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionQuery sessionQuery, XAsyncBlockPtr async);

		// Token: 0x06000CB2 RID: 3250
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerQuerySessionsResultCount(XAsyncBlockPtr async, out SizeT sessionCount);

		// Token: 0x06000CB3 RID: 3251
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerQuerySessionsResult(XAsyncBlockPtr async, SizeT sessionCount, [Out] XblMultiplayerSessionQueryResult[] sessions);

		// Token: 0x06000CB4 RID: 3252
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSetActivityAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference sessionReference, XAsyncBlockPtr async);

		// Token: 0x06000CB5 RID: 3253
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerClearActivityAsync(IntPtr xblContext, byte[] scid, XAsyncBlockPtr async);

		// Token: 0x06000CB6 RID: 3254
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSetTransferHandleAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference targetSessionReference, [In] ref XblMultiplayerSessionReference originSessionReference, XAsyncBlockPtr async);

		// Token: 0x06000CB7 RID: 3255
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSetTransferHandleResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandleId handle);

		// Token: 0x06000CB8 RID: 3256
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerCreateSearchHandleAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference sessionRef, [Optional] XblMultiplayerSessionTag[] tags, SizeT tagsCount, [Optional] XblMultiplayerSessionNumberAttribute[] numberAttributes, SizeT numberAttributesCount, [Optional] XblMultiplayerSessionStringAttribute[] stringAttributes, SizeT stringAttributesCount, XAsyncBlockPtr async);

		// Token: 0x06000CB9 RID: 3257
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerCreateSearchHandleResult(XAsyncBlockPtr async, out XblMultiplayerSearchHandle handle);

		// Token: 0x06000CBA RID: 3258
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerDeleteSearchHandleAsync(IntPtr xblContext, byte[] handleId, XAsyncBlockPtr async);

		// Token: 0x06000CBB RID: 3259
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetSearchHandlesAsync(IntPtr xblContext, byte[] scid, byte[] sessionTemplateName, [Optional] byte[] orderByAttribute, [MarshalAs(UnmanagedType.U1)] bool orderAscending, [Optional] byte[] searchFilter, [Optional] byte[] socialGroup, XAsyncBlockPtr async);

		// Token: 0x06000CBC RID: 3260
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetSearchHandlesResultCount(XAsyncBlockPtr async, out SizeT searchHandleCount);

		// Token: 0x06000CBD RID: 3261
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetSearchHandlesResult(XAsyncBlockPtr async, [Out] XblMultiplayerSearchHandle[] searchHandles, SizeT searchHandleCount);

		// Token: 0x06000CBE RID: 3262
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSendInvitesAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference sessionRef, [In] ulong[] xuids, SizeT xuidsCount, uint titleId, [Optional] byte[] contextStringId, [Optional] byte[] customActivationContext, XAsyncBlockPtr async);

		// Token: 0x06000CBF RID: 3263
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSendInvitesResult(XAsyncBlockPtr async, SizeT handlesCount, [Out] XblMultiplayerInviteHandle[] handles);

		// Token: 0x06000CC0 RID: 3264
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesForSocialGroupAsync(IntPtr xboxLiveContext, byte[] scid, ulong socialGroupOwnerXuid, byte[] socialGroup, XAsyncBlockPtr async);

		// Token: 0x06000CC1 RID: 3265
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(IntPtr xboxLiveContext, byte[] scid, ulong socialGroupOwnerXuid, byte[] socialGroup, XAsyncBlockPtr async);

		// Token: 0x06000CC2 RID: 3266
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesForSocialGroupResultCount(XAsyncBlockPtr async, out SizeT activityCount);

		// Token: 0x06000CC3 RID: 3267
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesForSocialGroupResult(XAsyncBlockPtr async, SizeT activityCount, [Out] XblMultiplayerActivityDetails[] activities);

		// Token: 0x06000CC4 RID: 3268
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		// Token: 0x06000CC5 RID: 3269
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT ptrToBufferCount, out SizeT bufferUsed);

		// Token: 0x06000CC6 RID: 3270
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesForUsersAsync(IntPtr xboxLiveContext, byte[] scid, [In] ulong[] xuids, SizeT xuidsCount, XAsyncBlockPtr async);

		// Token: 0x06000CC7 RID: 3271
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(IntPtr xboxLiveContext, byte[] scid, [In] ulong[] xuids, SizeT xuidsCount, XAsyncBlockPtr async);

		// Token: 0x06000CC8 RID: 3272
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesForUsersResultCount(XAsyncBlockPtr async, out SizeT activityCount);

		// Token: 0x06000CC9 RID: 3273
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesForUsersResult(XAsyncBlockPtr async, SizeT activityCount, [Out] XblMultiplayerActivityDetails[] activities);

		// Token: 0x06000CCA RID: 3274
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		// Token: 0x06000CCB RID: 3275
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT ptrToBufferCount, out SizeT bufferUsed);

		// Token: 0x06000CCC RID: 3276
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblMultiplayerSetSubscriptionsEnabled(IntPtr xblContext, [MarshalAs(UnmanagedType.U1)] bool subscriptionsEnabled);

		// Token: 0x06000CCD RID: 3277
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool XblMultiplayerSubscriptionsEnabled(IntPtr xblHandle);

		// Token: 0x06000CCE RID: 3278
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblFunctionContext XblMultiplayerAddSessionChangedHandler(IntPtr xblContext, XblInterop.XblMultiplayerSessionChangedHandler handler, IntPtr context);

		// Token: 0x06000CCF RID: 3279
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerRemoveSessionChangedHandler(IntPtr xblContext, XblFunctionContext token);

		// Token: 0x06000CD0 RID: 3280
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblFunctionContext XblMultiplayerAddSubscriptionLostHandler(IntPtr xblContext, XblInterop.XblMultiplayerSessionSubscriptionLostHandler handler, IntPtr context);

		// Token: 0x06000CD1 RID: 3281
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerRemoveSubscriptionLostHandler(IntPtr xblContext, XblFunctionContext token);

		// Token: 0x06000CD2 RID: 3282
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSessionSetCustomPropertyJson(IntPtr handle, byte[] name, byte[] valueJson);

		// Token: 0x06000CD3 RID: 3283
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSessionDeleteCustomPropertyJson(IntPtr handle, byte[] name);

		// Token: 0x06000CD4 RID: 3284
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionCompare(IntPtr currentSessionHandle, IntPtr oldSessionHandle);

		// Token: 0x06000CD5 RID: 3285
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblFunctionContext XblMultiplayerAddConnectionIdChangedHandler(IntPtr xblContext, XblInterop.XblMultiplayerConnectionIdChangedHandler handler, IntPtr context);

		// Token: 0x06000CD6 RID: 3286
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerRemoveConnectionIdChangedHandler(IntPtr xblContext, XblFunctionContext token);

		// Token: 0x06000CD7 RID: 3287
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerActivityUpdateRecentPlayers(IntPtr xboxLiveContext, [Optional] XblMultiplayerActivityRecentPlayerUpdate[] updates, SizeT updatesCount);

		// Token: 0x06000CD8 RID: 3288
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerActivityFlushRecentPlayersAsync(IntPtr xboxLiveContext, XAsyncBlockPtr async);

		// Token: 0x06000CD9 RID: 3289
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerActivitySetActivityAsync(IntPtr xboxLiveContext, [In] ref XblMultiplayerActivityInfo activityInfo, [MarshalAs(UnmanagedType.U1)] bool allowCrossPlatformJoin, XAsyncBlockPtr async);

		// Token: 0x06000CDA RID: 3290
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerActivityGetActivityAsync(IntPtr xboxLiveContext, [In] ulong[] xboxUserIdList, SizeT xboxUserIdListCount, XAsyncBlockPtr async);

		// Token: 0x06000CDB RID: 3291
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerActivityGetActivityResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		// Token: 0x06000CDC RID: 3292
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerActivityGetActivityResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBufferResults, out SizeT resultCount, out SizeT bufferUsed);

		// Token: 0x06000CDD RID: 3293
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerActivityDeleteActivityAsync(IntPtr xboxLiveContext, XAsyncBlockPtr async);

		// Token: 0x06000CDE RID: 3294
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerActivitySendInvitesAsync(IntPtr xblContext, [In] ulong[] xboxUserIdList, SizeT xboxUserIdListCount, [MarshalAs(UnmanagedType.U1)] bool allowCrossPlatformJoin, byte[] connectionString, XAsyncBlockPtr async);

		// Token: 0x06000CDF RID: 3295
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionHost(out XblMultiplayerManagerMember hostMember);

		// Token: 0x06000CE0 RID: 3296
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsTournamentRegistrationStateChanged(IntPtr argsHandle, out XblTournamentRegistrationState registrationState, out XblTournamentRegistrationReason registrationReason);

		// Token: 0x06000CE1 RID: 3297
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(byte[] scid, byte[] sessionTemplateName, byte[] sessionName);

		// Token: 0x06000CE2 RID: 3298
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsFindMatchCompleted(IntPtr argsHandle, out XblMultiplayerMatchStatus matchStatus, out XblMultiplayerMeasurementFailure initializationFailureCause);

		// Token: 0x06000CE3 RID: 3299
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionInviteUsers(IntPtr user, [In] ulong[] xuids, SizeT xuidsCount, byte[] contextStringId, byte[] customActivationContext);

		// Token: 0x06000CE4 RID: 3300
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerJoinLobby(byte[] handleId, IntPtr user);

		// Token: 0x06000CE5 RID: 3301
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionInviteFriends(IntPtr requestingUser, byte[] contextStringId, byte[] customActivationContext);

		// Token: 0x06000CE6 RID: 3302
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerSetQosMeasurements(byte[] measurementsJson);

		// Token: 0x06000CE7 RID: 3303
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerSetJoinability(XblMultiplayerJoinability joinability, IntPtr context);

		// Token: 0x06000CE8 RID: 3304
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionAddLocalUser(IntPtr user);

		// Token: 0x06000CE9 RID: 3305
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsMembersCount(IntPtr argsHandle, out SizeT memberCount);

		// Token: 0x06000CEA RID: 3306
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerJoinGameFromLobby(byte[] sessionTemplateName);

		// Token: 0x06000CEB RID: 3307
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern NativeBool XblMultiplayerManagerGameSessionIsHost(ulong xuid);

		// Token: 0x06000CEC RID: 3308
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsPropertiesJson(IntPtr argsHandle, out UTF8StringPtr properties);

		// Token: 0x06000CED RID: 3309
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerGameSessionHost(out XblMultiplayerManagerMember hostMember);

		// Token: 0x06000CEE RID: 3310
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionSessionReference(out XblMultiplayerSessionReference sessionReference);

		// Token: 0x06000CEF RID: 3311
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionSetProperties(byte[] name, byte[] valueJson, IntPtr context);

		// Token: 0x06000CF0 RID: 3312
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(NativeBool autoFillMembers);

		// Token: 0x06000CF1 RID: 3313
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionSetLocalMemberProperties(IntPtr user, byte[] name, byte[] valueJson, IntPtr context);

		// Token: 0x06000CF2 RID: 3314
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionSetSynchronizedProperties(byte[] name, byte[] valueJson, IntPtr context);

		// Token: 0x06000CF3 RID: 3315
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerSessionReference* XblMultiplayerManagerGameSessionSessionReference();

		// Token: 0x06000CF4 RID: 3316
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsXuid(IntPtr argsHandle, out ulong xuid);

		// Token: 0x06000CF5 RID: 3317
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerGameSessionSetProperties(byte[] name, byte[] valueJson, IntPtr context);

		// Token: 0x06000CF6 RID: 3318
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionMembers(SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

		// Token: 0x06000CF7 RID: 3319
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblMultiplayerJoinability XblMultiplayerManagerJoinability();

		// Token: 0x06000CF8 RID: 3320
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern UTF8StringPtr XblMultiplayerManagerLobbySessionPropertiesJson();

		// Token: 0x06000CF9 RID: 3321
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblMultiplayerManagerCancelMatch();

		// Token: 0x06000CFA RID: 3322
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern uint XblMultiplayerManagerEstimatedMatchWaitTime();

		// Token: 0x06000CFB RID: 3323
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerManagerLobbySessionConstants();

		// Token: 0x06000CFC RID: 3324
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsTournamentGameSessionReady(IntPtr argsHandle, out TimeT startTime);

		// Token: 0x06000CFD RID: 3325
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern SizeT XblMultiplayerManagerLobbySessionLocalMembersCount();

		// Token: 0x06000CFE RID: 3326
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern NativeBool XblMultiplayerManagerGameSessionActive();

		// Token: 0x06000CFF RID: 3327
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerInitialize(byte[] lobbySessionTemplateName, XTaskQueueHandle asyncQueue);

		// Token: 0x06000D00 RID: 3328
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionRemoveLocalUser(IntPtr user);

		// Token: 0x06000D01 RID: 3329
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(IntPtr user, byte[] name, IntPtr context);

		// Token: 0x06000D02 RID: 3330
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsMember(IntPtr argsHandle, out XblMultiplayerManagerMember member);

		// Token: 0x06000D03 RID: 3331
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern NativeBool XblMultiplayerManagerMemberAreMembersOnSameDevice([In] ref XblMultiplayerManagerMember first, [In] ref XblMultiplayerManagerMember second);

		// Token: 0x06000D04 RID: 3332
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerGameSessionSetSynchronizedHost(byte[] deviceToken, IntPtr context);

		// Token: 0x06000D05 RID: 3333
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblTournamentTeamResult* XblMultiplayerManagerLobbySessionLastTournamentTeamResult();

		// Token: 0x06000D06 RID: 3334
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSessionReferenceParseFromUriPath(byte[] path, out XblMultiplayerSessionReference sessionReference);

		// Token: 0x06000D07 RID: 3335
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerSessionReferenceToUriPath(XblMultiplayerSessionReference sessionReference, out XblMultiplayerSessionReferenceUri sessionReferenceUri);

		// Token: 0x06000D08 RID: 3336
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLeaveGame();

		// Token: 0x06000D09 RID: 3337
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsMembers(IntPtr argsHandle, SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

		// Token: 0x06000D0A RID: 3338
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern NativeBool XblMultiplayerManagerLobbySessionIsHost(ulong xuid);

		// Token: 0x06000D0B RID: 3339
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerGameSessionSetSynchronizedProperties(byte[] name, byte[] valueJson, IntPtr context);

		// Token: 0x06000D0C RID: 3340
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern UTF8StringPtr XblMultiplayerManagerGameSessionCorrelationId();

		// Token: 0x06000D0D RID: 3341
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerManagerGameSessionConstants();

		// Token: 0x06000D0E RID: 3342
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionLocalMembers(SizeT localMembersCount, [Out] XblMultiplayerManagerMember[] localMembers);

		// Token: 0x06000D0F RID: 3343
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus();

		// Token: 0x06000D10 RID: 3344
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionSetSynchronizedHost(byte[] deviceToken, IntPtr context);

		// Token: 0x06000D11 RID: 3345
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern NativeBool XblMultiplayerManagerAutoFillMembersDuringMatchmaking();

		// Token: 0x06000D12 RID: 3346
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionCorrelationId(out XblGuid correlationId);

		// Token: 0x06000D13 RID: 3347
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern SizeT XblMultiplayerManagerLobbySessionMembersCount();

		// Token: 0x06000D14 RID: 3348
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerFindMatch(byte[] hopperName, byte[] attributesJson, uint timeoutInSeconds);

		// Token: 0x06000D15 RID: 3349
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerDoWork(out IntPtr multiplayerEvents, out SizeT multiplayerEventsCount);

		// Token: 0x06000D16 RID: 3350
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern NativeBool XblMultiplayerSessionReferenceIsValid([In] ref XblMultiplayerSessionReference sessionReference);

		// Token: 0x06000D17 RID: 3351
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerGameSessionMembers(SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

		// Token: 0x06000D18 RID: 3352
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(IntPtr user, byte[] connectionAddress, IntPtr context);

		// Token: 0x06000D19 RID: 3353
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerManagerJoinGame(byte[] sessionName, byte[] sessionTemplateName, [In] ulong[] xuids, SizeT xuidsCount);

		// Token: 0x06000D1A RID: 3354
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern SizeT XblMultiplayerManagerGameSessionMembersCount();

		// Token: 0x06000D1B RID: 3355
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern UTF8StringPtr XblMultiplayerManagerGameSessionPropertiesJson();

		// Token: 0x06000D1C RID: 3356
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblMultiplayerEventArgsPerformQoSMeasurements(IntPtr argsHandle, out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs);

		// Token: 0x06000D1D RID: 3357
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceRecordGetXuid(IntPtr handle, out ulong xuid);

		// Token: 0x06000D1E RID: 3358
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceRecordGetUserState(IntPtr handle, out XblPresenceUserState userState);

		// Token: 0x06000D1F RID: 3359
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceRecordGetDeviceRecords(IntPtr handle, out IntPtr deviceRecords, out SizeT deviceRecordsCount);

		// Token: 0x06000D20 RID: 3360
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceRecordDuplicateHandle(IntPtr handle, out XblPresenceRecordHandle duplicatedHandle);

		// Token: 0x06000D21 RID: 3361
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblPresenceRecordCloseHandle(IntPtr handle);

		// Token: 0x06000D22 RID: 3362
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceSetPresenceAsync(IntPtr xblContextHandle, [MarshalAs(UnmanagedType.U1)] bool isUserActiveInTitle, [Optional] XblPresenceRichPresenceIdsRef richPresenceIds, XAsyncBlockPtr asyncBlockPtr);

		// Token: 0x06000D23 RID: 3363
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceGetPresenceAsync(IntPtr xblContextHandle, ulong xuid, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000D24 RID: 3364
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceGetPresenceResult(XAsyncBlockPtr asyncBlock, out XblPresenceRecordHandle presenceRecordHandle);

		// Token: 0x06000D25 RID: 3365
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceGetPresenceForMultipleUsersAsync(IntPtr xblContextHandle, ulong[] xuids, SizeT xuidsCount, [Optional] XblPresenceQueryFiltersRef filters, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000D26 RID: 3366
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceGetPresenceForMultipleUsersResultCount(XAsyncBlockPtr asyncBlock, out SizeT resultCount);

		// Token: 0x06000D27 RID: 3367
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceGetPresenceForMultipleUsersResult(XAsyncBlockPtr asyncBlock, [Out] XblPresenceRecordHandle[] presenceRecordHandles, SizeT presenceRecordHandlesCount);

		// Token: 0x06000D28 RID: 3368
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceGetPresenceForSocialGroupAsync(IntPtr xblContextHandle, byte[] socialGroupName, [Optional] UInt64Ref socialGroupOwnerXuid, [Optional] XblPresenceQueryFiltersRef filters, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000D29 RID: 3369
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceGetPresenceForSocialGroupResultCount(XAsyncBlockPtr asyncBlock, out SizeT resultCount);

		// Token: 0x06000D2A RID: 3370
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceGetPresenceForSocialGroupResult(XAsyncBlockPtr asyncBlock, [Out] XblPresenceRecordHandle[] presenceRecordHandles, SizeT presenceRecordHandlesCount);

		// Token: 0x06000D2B RID: 3371
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceSubscribeToDevicePresenceChange(XblContextHandle xblContextHandle, ulong xuid, out XblRealTimeActivitySubscriptionHandle subscriptionHandle);

		// Token: 0x06000D2C RID: 3372
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceUnsubscribeFromDevicePresenceChange(XblContextHandle xblContextHandle, XblRealTimeActivitySubscriptionHandle subscriptionHandle);

		// Token: 0x06000D2D RID: 3373
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceSubscribeToTitlePresenceChange(XblContextHandle xblContextHandle, ulong xuid, uint titleId, out XblRealTimeActivitySubscriptionHandle subscriptionHandle);

		// Token: 0x06000D2E RID: 3374
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceUnsubscribeFromTitlePresenceChange(XblContextHandle xblContext, XblRealTimeActivitySubscriptionHandle subscriptionHandle);

		// Token: 0x06000D2F RID: 3375
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblFunctionContext XblPresenceAddDevicePresenceChangedHandler(XblContextHandle xblContextHandle, XblPresenceDevicePresenceChangedHandler handler, IntPtr context);

		// Token: 0x06000D30 RID: 3376
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceRemoveDevicePresenceChangedHandler(XblContextHandle xblContextHandle, XblFunctionContext token);

		// Token: 0x06000D31 RID: 3377
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblFunctionContext XblPresenceAddTitlePresenceChangedHandler(XblContextHandle xblContextHandle, XblPresenceTitlePresenceChangedHandler handler, IntPtr context);

		// Token: 0x06000D32 RID: 3378
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPresenceRemoveTitlePresenceChangedHandler(XblContextHandle xblContextHandle, XblFunctionContext token);

		// Token: 0x06000D33 RID: 3379
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyGetAvoidListAsync(IntPtr xblContextHandle, XAsyncBlockPtr async);

		// Token: 0x06000D34 RID: 3380
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyGetAvoidListResultCount(XAsyncBlockPtr async, out SizeT xuidCount);

		// Token: 0x06000D35 RID: 3381
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyGetAvoidListResult(XAsyncBlockPtr async, SizeT xuidCount, [Out] ulong[] xuids);

		// Token: 0x06000D36 RID: 3382
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyGetMuteListAsync(IntPtr xblContextHandle, XAsyncBlockPtr async);

		// Token: 0x06000D37 RID: 3383
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyGetMuteListResultCount(XAsyncBlockPtr async, out SizeT xuidCount);

		// Token: 0x06000D38 RID: 3384
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyGetMuteListResult(XAsyncBlockPtr async, SizeT xuidCount, [Out] ulong[] xuids);

		// Token: 0x06000D39 RID: 3385
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyCheckPermissionAsync(IntPtr xblContextHandle, XblPermission permissionToCheck, ulong targetXuid, XAsyncBlockPtr async);

		// Token: 0x06000D3A RID: 3386
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyCheckPermissionResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		// Token: 0x06000D3B RID: 3387
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyCheckPermissionResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr result, out SizeT bufferUsed);

		// Token: 0x06000D3C RID: 3388
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyCheckPermissionForAnonymousUserAsync(IntPtr xblContextHandle, XblPermission permissionToCheck, XblAnonymousUserType userType, XAsyncBlockPtr async);

		// Token: 0x06000D3D RID: 3389
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyCheckPermissionForAnonymousUserResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		// Token: 0x06000D3E RID: 3390
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyCheckPermissionForAnonymousUserResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		// Token: 0x06000D3F RID: 3391
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyBatchCheckPermissionAsync(IntPtr xblContextHandle, [In] XblPermission[] permissionsToCheck, SizeT permissionsCount, [In] ulong[] targetXuids, SizeT xuidsCount, [In] XblAnonymousUserType[] targetAnonymousUserTypes, SizeT targetAnonymousUserTypesCount, XAsyncBlockPtr async);

		// Token: 0x06000D40 RID: 3392
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyBatchCheckPermissionResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		// Token: 0x06000D41 RID: 3393
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblPrivacyBatchCheckPermissionResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr results, out SizeT resultsCount, out SizeT bufferUsed);

		// Token: 0x06000D42 RID: 3394
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblProfileGetUserProfileAsync(IntPtr xblContextHandle, ulong xboxUserId, XAsyncBlockPtr async);

		// Token: 0x06000D43 RID: 3395
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblProfileGetUserProfileResult(XAsyncBlockPtr async, out XblUserProfile profile);

		// Token: 0x06000D44 RID: 3396
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblProfileGetUserProfilesAsync(IntPtr xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, XAsyncBlockPtr async);

		// Token: 0x06000D45 RID: 3397
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblProfileGetUserProfilesResultCount(XAsyncBlockPtr async, out SizeT profileCount);

		// Token: 0x06000D46 RID: 3398
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblProfileGetUserProfilesResult(XAsyncBlockPtr async, SizeT profilesCount, [Out] XblUserProfile[] profiles);

		// Token: 0x06000D47 RID: 3399
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblProfileGetUserProfilesForSocialGroupAsync(IntPtr xblContextHandle, byte[] socialGroup, XAsyncBlockPtr async);

		// Token: 0x06000D48 RID: 3400
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblProfileGetUserProfilesForSocialGroupResultCount(XAsyncBlockPtr async, out SizeT profileCount);

		// Token: 0x06000D49 RID: 3401
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblProfileGetUserProfilesForSocialGroupResult(XAsyncBlockPtr async, SizeT profilesCount, [Out] XblUserProfile[] profiles);

		// Token: 0x06000D4A RID: 3402
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialGetSocialRelationshipsAsync(IntPtr xboxLiveContext, ulong xboxUserId, XblSocialRelationshipFilter socialRelationshipFilter, SizeT startIndex, SizeT maxItems, XAsyncBlockPtr async);

		// Token: 0x06000D4B RID: 3403
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialGetSocialRelationshipsResult(XAsyncBlockPtr async, out XblSocialRelationshipResultHandle handle);

		// Token: 0x06000D4C RID: 3404
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialRelationshipResultGetRelationships(XblSocialRelationshipResultHandle resultHandle, out IntPtr relationships, out SizeT relationshipsCount);

		// Token: 0x06000D4D RID: 3405
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialRelationshipResultHasNext(XblSocialRelationshipResultHandle resultHandle, [MarshalAs(UnmanagedType.U1)] out bool hasNext);

		// Token: 0x06000D4E RID: 3406
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialRelationshipResultGetTotalCount(XblSocialRelationshipResultHandle resultHandle, out SizeT totalCount);

		// Token: 0x06000D4F RID: 3407
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialRelationshipResultGetNextAsync(IntPtr xboxLiveContext, XblSocialRelationshipResultHandle resultHandle, SizeT maxItems, XAsyncBlockPtr async);

		// Token: 0x06000D50 RID: 3408
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialRelationshipResultGetNextResult(XAsyncBlockPtr async, out XblSocialRelationshipResultHandle handle);

		// Token: 0x06000D51 RID: 3409
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialRelationshipResultDuplicateHandle(XblSocialRelationshipResultHandle handle, out XblSocialRelationshipResultHandle duplicatedHandle);

		// Token: 0x06000D52 RID: 3410
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblSocialRelationshipResultCloseHandle(XblSocialRelationshipResultHandle handle);

		// Token: 0x06000D53 RID: 3411
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern int XblSocialAddSocialRelationshipChangedHandler(IntPtr xboxLiveContext, XblSocialRelationshipChangedHandler handler, IntPtr handlerContext);

		// Token: 0x06000D54 RID: 3412
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern int XblSocialRemoveSocialRelationshipChangedHandler(IntPtr xboxLiveContext, int handlerFunctionContext);

		// Token: 0x06000D55 RID: 3413
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static extern bool XblSocialManagerPresenceRecordIsUserPlayingTitle([In] ref XblSocialManagerPresenceRecord presenceRecord, uint titleId);

		// Token: 0x06000D56 RID: 3414
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerUserGroupGetUsers(IntPtr group, out IntPtr xboxSocialUsers, out SizeT usersCount);

		// Token: 0x06000D57 RID: 3415
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerUserGroupGetUsersTrackedByGroup(IntPtr group, out IntPtr trackedUsers, out SizeT trackedUsersCount);

		// Token: 0x06000D58 RID: 3416
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerAddLocalUser(IntPtr user, XblSocialManagerExtraDetailLevel extraLevelDetail, XTaskQueueHandle queue);

		// Token: 0x06000D59 RID: 3417
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerRemoveLocalUser(IntPtr user);

		// Token: 0x06000D5A RID: 3418
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerDoWork(out IntPtr socialEvents, out SizeT socialEventsCount);

		// Token: 0x06000D5B RID: 3419
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerCreateSocialUserGroupFromFilters(IntPtr user, XblPresenceFilter presenceDetailLevel, XblRelationshipFilter filter, out XblSocialManagerUserGroupHandle group);

		// Token: 0x06000D5C RID: 3420
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerCreateSocialUserGroupFromList(IntPtr user, ulong[] xboxUserIdList, SizeT xboxUserIdListCount, out XblSocialManagerUserGroupHandle group);

		// Token: 0x06000D5D RID: 3421
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerDestroySocialUserGroup(IntPtr group);

		// Token: 0x06000D5E RID: 3422
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern SizeT XblSocialManagerGetLocalUserCount();

		// Token: 0x06000D5F RID: 3423
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerGetLocalUsers(SizeT usersCount, [Out] IntPtr[] users);

		// Token: 0x06000D60 RID: 3424
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerUpdateSocialUserGroup(IntPtr group, ulong[] users, SizeT usersCount);

		// Token: 0x06000D61 RID: 3425
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerSetRichPresencePollingStatus(IntPtr user, [MarshalAs(UnmanagedType.U1)] bool shouldEnablePolling);

		// Token: 0x06000D62 RID: 3426
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerUserGroupGetType(IntPtr group, out XblSocialUserGroupType type);

		// Token: 0x06000D63 RID: 3427
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerUserGroupGetLocalUser(IntPtr group, out IntPtr localUser);

		// Token: 0x06000D64 RID: 3428
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblSocialManagerUserGroupGetFilters(IntPtr group, out XblPresenceFilter presenceFilter, out XblRelationshipFilter relationshipFilter);

		// Token: 0x06000D65 RID: 3429
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblStringVerifyStringAsync(IntPtr xblContextHandle, byte[] stringToVerify, XAsyncBlockPtr async);

		// Token: 0x06000D66 RID: 3430
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblStringVerifyStringResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		// Token: 0x06000D67 RID: 3431
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblStringVerifyStringResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		// Token: 0x06000D68 RID: 3432
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblStringVerifyStringsAsync(IntPtr xblContextHandle, IntPtr stringsToVerify, ulong stringsCount, XAsyncBlockPtr async);

		// Token: 0x06000D69 RID: 3433
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblStringVerifyStringsResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

		// Token: 0x06000D6A RID: 3434
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblStringVerifyStringsResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBufferStrings, out SizeT stringsCount, out SizeT bufferUsed);

		// Token: 0x06000D6B RID: 3435
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblTitleManagedStatsWriteAsync(IntPtr xblContextHandle, ulong xboxUserId, [In] XblTitleManagedStatistic[] statistics, SizeT statisticsCount, XAsyncBlockPtr async);

		// Token: 0x06000D6C RID: 3436
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblTitleManagedStatsUpdateStatsAsync(IntPtr xblContextHandle, [In] XblTitleManagedStatistic[] statistics, SizeT statisticsCount, XAsyncBlockPtr async);

		// Token: 0x06000D6D RID: 3437
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblTitleManagedStatsDeleteStatsAsync(IntPtr xblContextHandle, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr async);

		// Token: 0x06000D6E RID: 3438
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblTitleStorageBlobMetadataResultGetItems([In] IntPtr resultHandle, out IntPtr items, out SizeT itemsCount);

		// Token: 0x06000D6F RID: 3439
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblTitleStorageBlobMetadataResultHasNext([In] IntPtr resultHandle, [MarshalAs(UnmanagedType.U1)] out bool hasNext);

		// Token: 0x06000D70 RID: 3440
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageBlobMetadataResultGetNextAsync([In] IntPtr resultHandle, uint maxItems, XAsyncBlockPtr async);

		// Token: 0x06000D71 RID: 3441
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageBlobMetadataResultGetNextResult(XAsyncBlockPtr async, out XblTitleStorageBlobMetadataResultHandle result);

		// Token: 0x06000D72 RID: 3442
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageBlobMetadataResultDuplicateHandle([In] IntPtr handle, out XblTitleStorageBlobMetadataResultHandle duplicatedHandle);

		// Token: 0x06000D73 RID: 3443
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageBlobMetadataResultCloseHandle([In] IntPtr handle);

		// Token: 0x06000D74 RID: 3444
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageGetQuotaAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, XblTitleStorageType storageType, XAsyncBlockPtr async);

		// Token: 0x06000D75 RID: 3445
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageGetQuotaResult(XAsyncBlockPtr async, out SizeT usedBytes, out SizeT quotaBytes);

		// Token: 0x06000D76 RID: 3446
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageGetBlobMetadataAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, XblTitleStorageType storageType, byte[] blobPath, ulong xboxUserId, uint skipItems, uint maxItems, XAsyncBlockPtr async);

		// Token: 0x06000D77 RID: 3447
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageGetBlobMetadataResult(XAsyncBlockPtr async, out XblTitleStorageBlobMetadataResultHandle result);

		// Token: 0x06000D78 RID: 3448
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageDeleteBlobAsync(IntPtr xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, [MarshalAs(UnmanagedType.U1)] bool deleteOnlyIfEtagMatches, XAsyncBlockPtr async);

		// Token: 0x06000D79 RID: 3449
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageDownloadBlobAsync(IntPtr xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, IntPtr blobBuffer, SizeT blobBufferCount, XblTitleStorageETagMatchCondition etagMatchCondition, byte[] selectQuery, SizeT preferredDownloadBlockSize, XAsyncBlockPtr async);

		// Token: 0x06000D7A RID: 3450
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageDownloadBlobResult(XAsyncBlockPtr async, out XblTitleStorageBlobMetadata blobMetadata);

		// Token: 0x06000D7B RID: 3451
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageUploadBlobAsync(IntPtr xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, IntPtr blobBuffer, SizeT blobBufferCount, XblTitleStorageETagMatchCondition etagMatchCondition, SizeT preferredUploadBlockSize, XAsyncBlockPtr async);

		// Token: 0x06000D7C RID: 3452
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		public static extern int XblTitleStorageUploadBlobResult(XAsyncBlockPtr async, out XblTitleStorageBlobMetadata blobMetadata);

		// Token: 0x06000D7D RID: 3453
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetSingleUserStatisticAsync(IntPtr xblContextHandle, ulong xboxUserId, byte[] serviceConfigurationId, byte[] statisticName, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000D7E RID: 3454
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetSingleUserStatisticResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		// Token: 0x06000D7F RID: 3455
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetSingleUserStatisticResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		// Token: 0x06000D80 RID: 3456
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetSingleUserStatisticsAsync(IntPtr xblContextHandle, ulong xboxUserId, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000D81 RID: 3457
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetSingleUserStatisticsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		// Token: 0x06000D82 RID: 3458
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetSingleUserStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

		// Token: 0x06000D83 RID: 3459
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsAsync(IntPtr xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000D84 RID: 3460
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		// Token: 0x06000D85 RID: 3461
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT resultsCount, out SizeT bufferUsed);

		// Token: 0x06000D86 RID: 3462
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(IntPtr xblContextHandle, ulong[] xboxUserIds, uint xboxUserIdsCount, IntPtr requestedServiceConfigurationStatisticsCollection, uint requestedServiceConfigurationStatisticsCollectionCount, XAsyncBlockPtr asyncBlock);

		// Token: 0x06000D87 RID: 3463
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

		// Token: 0x06000D88 RID: 3464
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr results, out SizeT resultsCount, out SizeT bufferUsed);

		// Token: 0x06000D89 RID: 3465
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblFunctionContext XblUserStatisticsAddStatisticChangedHandler(IntPtr xblContextHandle, XblInterop.XblStatisticChangedHandler handler, IntPtr handlerContext);

		// Token: 0x06000D8A RID: 3466
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblUserStatisticsRemoveStatisticChangedHandler(IntPtr xblContextHandle, IntPtr context);

		// Token: 0x06000D8B RID: 3467
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsTrackStatistics(XblContextHandle xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount);

		// Token: 0x06000D8C RID: 3468
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblUserStatisticsStopTrackingStatistics(XblContextHandle xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount);

		// Token: 0x06000D8D RID: 3469
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblContextCreateHandle(IntPtr user, out XblContextHandle context);

		// Token: 0x06000D8E RID: 3470
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XblContextCloseHandle(IntPtr xboxLiveContextHandle);

		// Token: 0x06000D8F RID: 3471
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XblErrorCondition XblGetErrorCondition(int hr);

		// Token: 0x06000D90 RID: 3472
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblEventsWriteInGameEvent(IntPtr xboxLiveContext, byte[] eventName, [Optional] byte[] dimensionsJson, [Optional] byte[] measurementsJson);

		// Token: 0x06000D91 RID: 3473
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblWrapper_XblInitialize(byte[] scid, XTaskQueueHandle internalWorkQueue);

		// Token: 0x06000D92 RID: 3474
		[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XblCleanupAsync(XAsyncBlockPtr asyncBlock);

		// Token: 0x04000662 RID: 1634
		public const string XblThunkDllName = "Microsoft.Xbox.Services.GDK.C.Thunks";

		// Token: 0x04000663 RID: 1635
		internal const int XBL_COLOR_CHAR_SIZE = 21;

		// Token: 0x04000664 RID: 1636
		internal const int XBL_DISPLAY_NAME_CHAR_SIZE = 90;

		// Token: 0x04000665 RID: 1637
		internal const int XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE = 675;

		// Token: 0x04000666 RID: 1638
		internal const int XBL_GAMERSCORE_CHAR_SIZE = 48;

		// Token: 0x04000667 RID: 1639
		internal const int XBL_GAMERTAG_CHAR_SIZE = 48;

		// Token: 0x04000668 RID: 1640
		internal const int XBL_MODERN_GAMERTAG_CHAR_SIZE = 97;

		// Token: 0x04000669 RID: 1641
		internal const int XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE = 15;

		// Token: 0x0400066A RID: 1642
		internal const int XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE = 101;

		// Token: 0x0400066B RID: 1643
		internal const int XBL_NUM_PRESENCE_RECORDS = 6;

		// Token: 0x0400066C RID: 1644
		internal const int XBL_REAL_NAME_CHAR_SIZE = 765;

		// Token: 0x0400066D RID: 1645
		internal const int XBL_RICH_PRESENCE_CHAR_SIZE = 300;

		// Token: 0x0400066E RID: 1646
		internal const int XBL_TITLE_NAME_CHAR_SIZE = 300;

		// Token: 0x0400066F RID: 1647
		internal const int XBL_XBOX_USER_ID_CHAR_SIZE = 63;

		// Token: 0x04000670 RID: 1648
		internal const int XBL_GUID_LENGTH = 40;

		// Token: 0x04000671 RID: 1649
		internal const int XBL_SCID_LENGTH = 40;

		// Token: 0x04000672 RID: 1650
		internal const int XBL_SOCIAL_MANAGER_MAX_AFFECTED_USERS_PER_EVENT = 10;

		// Token: 0x04000673 RID: 1651
		internal const int XBL_MULTIPLAYER_SESSION_TEMPLATE_NAME_MAX_LENGTH = 100;

		// Token: 0x04000674 RID: 1652
		internal const int XBL_MULTIPLAYER_SESSION_NAME_MAX_LENGTH = 100;

		// Token: 0x04000675 RID: 1653
		internal const int XBL_MULTIPLAYER_SESSION_REFERENCE_URI_MAX_LENGTH = 284;

		// Token: 0x04000676 RID: 1654
		internal const int XBL_MULTIPLAYER_SEARCH_HANDLE_MAX_FIELD_LENGTH = 100;

		// Token: 0x04000677 RID: 1655
		internal const int XBL_TITLE_STORAGE_MIN_UPLOAD_BLOCK_SIZE = 1024;

		// Token: 0x04000678 RID: 1656
		internal const int XBL_TITLE_STORAGE_MAX_UPLOAD_BLOCK_SIZE = 4194304;

		// Token: 0x04000679 RID: 1657
		internal const int XBL_TITLE_STORAGE_DEFAULT_UPLOAD_BLOCK_SIZE = 262144;

		// Token: 0x0400067A RID: 1658
		internal const int XBL_TITLE_STORAGE_MIN_DOWNLOAD_BLOCK_SIZE = 1024;

		// Token: 0x0400067B RID: 1659
		internal const int XBL_TITLE_STORAGE_DEFAULT_DOWNLOAD_BLOCK_SIZE = 1048576;

		// Token: 0x0400067C RID: 1660
		internal const int XBL_TITLE_STORAGE_BLOB_PATH_MAX_LENGTH = 771;

		// Token: 0x0400067D RID: 1661
		internal const int XBL_TITLE_STORAGE_BLOB_DISPLAY_NAME_MAX_LENGTH = 387;

		// Token: 0x0400067E RID: 1662
		internal const int XBL_TITLE_STORAGE_BLOB_ETAG_MAX_LENGTH = 54;

		// Token: 0x02000328 RID: 808
		// (Invoke) Token: 0x060010DA RID: 4314
		internal delegate void XblAchievementsProgressChangeHandler(XblAchievementProgressChangeEventArgs eventArgs, IntPtr context);

		// Token: 0x02000329 RID: 809
		// (Invoke) Token: 0x060010DE RID: 4318
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate void XblMultiplayerSessionChangedHandler(IntPtr context, XblMultiplayerSessionChangeEventArgs args);

		// Token: 0x0200032A RID: 810
		// (Invoke) Token: 0x060010E2 RID: 4322
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate void XblMultiplayerSessionSubscriptionLostHandler(IntPtr context);

		// Token: 0x0200032B RID: 811
		// (Invoke) Token: 0x060010E6 RID: 4326
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate void XblMultiplayerConnectionIdChangedHandler(IntPtr context);

		// Token: 0x0200032C RID: 812
		// (Invoke) Token: 0x060010EA RID: 4330
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate void XblStatisticChangedHandler(XblStatisticChangeEventArgs statisticChangeEventArgs, IntPtr context);
	}
}
