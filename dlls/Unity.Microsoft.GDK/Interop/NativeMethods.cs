using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001CE RID: 462
	internal class NativeMethods
	{
		// Token: 0x06000AA9 RID: 2729
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XClosedCaptionGetProperties(out XClosedCaptionProperties properties);

		// Token: 0x06000AAA RID: 2730
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XClosedCaptionSetEnabled([MarshalAs(UnmanagedType.I1)] bool enabled);

		// Token: 0x06000AAB RID: 2731
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XHighContrastGetMode(out XHighContrastMode mode);

		// Token: 0x06000AAC RID: 2732
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechToTextSetPositionHint(XSpeechToTextPositionHint position);

		// Token: 0x06000AAD RID: 2733
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechToTextSendString([MarshalAs(UnmanagedType.LPStr)] string speakerName, [MarshalAs(UnmanagedType.LPStr)] string content, XSpeechToTextType type);

		// Token: 0x06000AAE RID: 2734
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechToTextBeginHypothesisString([MarshalAs(UnmanagedType.LPStr)] string speakerName, [MarshalAs(UnmanagedType.LPStr)] string content, XSpeechToTextType type, out uint hypothesisId);

		// Token: 0x06000AAF RID: 2735
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechToTextUpdateHypothesisString(uint hypothesisId, [MarshalAs(UnmanagedType.LPStr)] string content);

		// Token: 0x06000AB0 RID: 2736
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechToTextFinalizeHypothesisString(uint hypothesisId, [MarshalAs(UnmanagedType.LPStr)] string content);

		// Token: 0x06000AB1 RID: 2737
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechToTextCancelHypothesisString(uint hypothesisId);

		// Token: 0x06000AB2 RID: 2738
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppBroadcastGetStatus(IntPtr requestingUser, out XAppBroadcastStatus appBroadcastStatus);

		// Token: 0x06000AB3 RID: 2739
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XAppBroadcastIsAppBroadcasting();

		// Token: 0x06000AB4 RID: 2740
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppBroadcastShowUI(IntPtr requestingUser);

		// Token: 0x06000AB5 RID: 2741
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppBroadcastRegisterIsAppBroadcastingChanged(IntPtr queue, IntPtr context, XAppBroadcastMonitorCallback appBroadcastMonitorCallback, out ulong token);

		// Token: 0x06000AB6 RID: 2742
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureCloseScreenshotStream(IntPtr handle);

		// Token: 0x06000AB7 RID: 2743
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureEnableRecord();

		// Token: 0x06000AB8 RID: 2744
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureDisableRecord();

		// Token: 0x06000AB9 RID: 2745
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XAppBroadcastUnregisterIsAppBroadcastingChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000ABA RID: 2746
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataAddStringEvent([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value, XAppCaptureMetadataPriority priority);

		// Token: 0x06000ABB RID: 2747
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataAddInt32Event([MarshalAs(UnmanagedType.LPStr)] string name, int value, XAppCaptureMetadataPriority priority);

		// Token: 0x06000ABC RID: 2748
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataAddDoubleEvent([MarshalAs(UnmanagedType.LPStr)] string name, double value, XAppCaptureMetadataPriority priority);

		// Token: 0x06000ABD RID: 2749
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataStartStringState([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value, XAppCaptureMetadataPriority priority);

		// Token: 0x06000ABE RID: 2750
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataStartInt32State([MarshalAs(UnmanagedType.LPStr)] string name, int value, XAppCaptureMetadataPriority priority);

		// Token: 0x06000ABF RID: 2751
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataStartDoubleState([MarshalAs(UnmanagedType.LPStr)] string name, double value, XAppCaptureMetadataPriority priority);

		// Token: 0x06000AC0 RID: 2752
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataStopState([MarshalAs(UnmanagedType.LPStr)] string name);

		// Token: 0x06000AC1 RID: 2753
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataStopAllStates();

		// Token: 0x06000AC2 RID: 2754
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureMetadataRemainingStorageBytesAvailable(out ulong value);

		// Token: 0x06000AC3 RID: 2755
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureOpenScreenshotStream([MarshalAs(UnmanagedType.LPStr)] string localId, XAppCaptureScreenshotFormatFlag screenshotFormat, out IntPtr handle, out ulong totalBytes);

		// Token: 0x06000AC4 RID: 2756
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureReadScreenshotStream(IntPtr handle, ulong startPosition, uint bytesToRead, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] [In] [Out] byte[] buffer, out uint bytesWritten);

		// Token: 0x06000AC5 RID: 2757
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureRecordDiagnosticClip(long startTime, uint durationInMs, [MarshalAs(UnmanagedType.LPStr)] string filenamePrefix, out XAppCaptureRecordClipResult result);

		// Token: 0x06000AC6 RID: 2758
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureTakeDiagnosticScreenshot([MarshalAs(UnmanagedType.I1)] bool gamescreenOnly, XAppCaptureScreenshotFormatFlag captureFlags, [MarshalAs(UnmanagedType.LPStr)] string filenamePrefix, out XAppCaptureDiagnosticScreenshotResult result);

		// Token: 0x06000AC7 RID: 2759
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureTakeScreenshot(IntPtr requestingUser, out XAppCaptureTakeScreenshotResult result);

		// Token: 0x06000AC8 RID: 2760
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureRegisterMetadataPurged(IntPtr queue, IntPtr context, XAppCaptureMetadataPurgedCallback callback, out ulong token);

		// Token: 0x06000AC9 RID: 2761
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XAppCaptureUnRegisterMetadataPurged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000ACA RID: 2762
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureReadLocalStream(IntPtr handle, long startPosition, uint bytesToRead, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] [In] [Out] byte[] buffer, out uint bytesWritten);

		// Token: 0x06000ACB RID: 2763
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureCloseLocalStream(IntPtr handle);

		// Token: 0x06000ACC RID: 2764
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureRecordTimespan(IntPtr startTimestamp, ulong durationInMilliseconds, out XAppCaptureLocalResult result);

		// Token: 0x06000ACD RID: 2765
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAppCaptureGetVideoCaptureSettings(out XAppCaptureVideoCaptureSettings userCaptureSettings);

		// Token: 0x06000ACE RID: 2766
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAsyncGetStatus(IntPtr asyncBlock, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000ACF RID: 2767
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAsyncGetResultSize(IntPtr asyncBlock, out ulong bufferSize);

		// Token: 0x06000AD0 RID: 2768
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XAsyncCancel(IntPtr asyncBlock);

		// Token: 0x06000AD1 RID: 2769
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAsyncRun(IntPtr asyncBlock, XAsyncWorkInterop work);

		// Token: 0x06000AD2 RID: 2770
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAsyncBegin(IntPtr asyncInterop, IntPtr context, IntPtr identity, [MarshalAs(UnmanagedType.LPStr)] string identityName, XAsyncProviderInterop provider);

		// Token: 0x06000AD3 RID: 2771
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAsyncSchedule(IntPtr asyncInterop, uint delayInMs);

		// Token: 0x06000AD4 RID: 2772
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XAsyncComplete(IntPtr asyncInterop, uint result, ulong requiredBufferSize);

		// Token: 0x06000AD5 RID: 2773
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XAsyncGetResult(IntPtr asyncInterop, IntPtr identity, ulong bufferSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] [In] [Out] byte[] buffer, out ulong bufferUsed);

		// Token: 0x06000AD6 RID: 2774
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XDisplayHdrModeResult XDisplayTryEnableHdrMode(XDisplayHdrModePreference displayModePreference, out XDisplayHdrModeInfo displayHdrModeInfo);

		// Token: 0x06000AD7 RID: 2775
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XDisplayAcquireTimeoutDeferral(out IntPtr handle);

		// Token: 0x06000AD8 RID: 2776
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XDisplayCloseTimeoutDeferralHandle(IntPtr handle);

		// Token: 0x06000AD9 RID: 2777
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XErrorSetCallback(XErrorCallback callback, IntPtr context);

		// Token: 0x06000ADA RID: 2778
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XErrorSetOptions(XErrorOptions optionsDebuggerPresent, XErrorOptions optionsDebuggerNotPresent);

		// Token: 0x06000ADB RID: 2779
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameEventWrite(IntPtr user, [MarshalAs(UnmanagedType.LPStr)] string serviceConfigId, [MarshalAs(UnmanagedType.LPStr)] string playSessionId, [MarshalAs(UnmanagedType.LPStr)] string eventName, [MarshalAs(UnmanagedType.LPStr)] string dimensionsJson, [MarshalAs(UnmanagedType.LPStr)] string measurementsJson);

		// Token: 0x06000ADC RID: 2780
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameGetXboxTitleId(out uint titleId);

		// Token: 0x06000ADD RID: 2781
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XLaunchNewGame([MarshalAs(UnmanagedType.LPStr)] string exePath, [MarshalAs(UnmanagedType.LPStr)] string args, IntPtr defaultUser);

		// Token: 0x06000ADE RID: 2782
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XLaunchRestartOnCrash([MarshalAs(UnmanagedType.LPStr)] string args, uint reserved);

		// Token: 0x06000ADF RID: 2783
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameInviteRegisterForEvent(IntPtr queue, IntPtr context, XGameInviteEventCallback callback, out ulong token);

		// Token: 0x06000AE0 RID: 2784
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XGameInviteUnregisterForEvent(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000AE1 RID: 2785
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameProtocolRegisterForActivation(IntPtr queue, IntPtr context, XGameProtocolActivationCallback callback, out ulong token);

		// Token: 0x06000AE2 RID: 2786
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XGameProtocolUnregisterForActivation(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000AE3 RID: 2787
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern bool XGameRuntimeIsFeatureAvailable(XGameRuntimeFeature feature);

		// Token: 0x06000AE4 RID: 2788
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameRuntimeInitialize();

		// Token: 0x06000AE5 RID: 2789
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameRuntimeUninitialize();

		// Token: 0x06000AE6 RID: 2790
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveFilesGetFolderWithUiAsync(IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string configurationId, IntPtr async);

		// Token: 0x06000AE7 RID: 2791
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveFilesGetFolderWithUiResult(IntPtr async, ulong folderSize, StringBuilder folderResult);

		// Token: 0x06000AE8 RID: 2792
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveFilesGetRemainingQuota(IntPtr userContext, [MarshalAs(UnmanagedType.LPStr)] string configurationId, out ulong remainingQuota);

		// Token: 0x06000AE9 RID: 2793
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveInitializeProvider(IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string configurationId, [MarshalAs(UnmanagedType.I1)] bool syncOnDemand, out IntPtr provider);

		// Token: 0x06000AEA RID: 2794
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveInitializeProviderAsync(IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string configurationId, [MarshalAs(UnmanagedType.I1)] bool syncOnDemand, IntPtr async);

		// Token: 0x06000AEB RID: 2795
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveInitializeProviderResult(IntPtr async, out IntPtr provider);

		// Token: 0x06000AEC RID: 2796
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameSaveCloseProvider(IntPtr provider);

		// Token: 0x06000AED RID: 2797
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveGetRemainingQuota(IntPtr provider, out long remainingQuota);

		// Token: 0x06000AEE RID: 2798
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveGetRemainingQuotaAsync(IntPtr provider, IntPtr xAsyncBlockInterop);

		// Token: 0x06000AEF RID: 2799
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveGetRemainingQuotaResult(IntPtr async, out long remainingQuota);

		// Token: 0x06000AF0 RID: 2800
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveDeleteContainer(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerName);

		// Token: 0x06000AF1 RID: 2801
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveDeleteContainerAsync(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerName, IntPtr async);

		// Token: 0x06000AF2 RID: 2802
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveDeleteContainerResult(IntPtr async);

		// Token: 0x06000AF3 RID: 2803
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveGetContainerInfo(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerName, IntPtr context, XGameSaveContainerInfoCallback callback);

		// Token: 0x06000AF4 RID: 2804
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveEnumerateContainerInfo(IntPtr provider, IntPtr context, XGameSaveContainerInfoCallback callback);

		// Token: 0x06000AF5 RID: 2805
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveEnumerateContainerInfoByName(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerNamePrefix, IntPtr context, XGameSaveContainerInfoCallback callback);

		// Token: 0x06000AF6 RID: 2806
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveCreateContainer(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerName, out IntPtr containerContext);

		// Token: 0x06000AF7 RID: 2807
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameSaveCloseContainer(IntPtr context);

		// Token: 0x06000AF8 RID: 2808
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveEnumerateBlobInfo(IntPtr container, IntPtr context, XGameSaveBlobInfoCallback callback);

		// Token: 0x06000AF9 RID: 2809
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveEnumerateBlobInfoByName(IntPtr container, [MarshalAs(UnmanagedType.LPStr)] string blobNamePrefix, IntPtr context, XGameSaveBlobInfoCallback callback);

		// Token: 0x06000AFA RID: 2810
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveReadBlobData(IntPtr container, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] blobNames, ref uint countOfBlobs, ulong blobsSize, IntPtr blobData);

		// Token: 0x06000AFB RID: 2811
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveReadBlobDataAsync(IntPtr container, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] blobNames, uint countOfBlobs, IntPtr async);

		// Token: 0x06000AFC RID: 2812
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveReadBlobDataResult(IntPtr async, ulong blobsSize, IntPtr blobData, out uint countOfBlobs);

		// Token: 0x06000AFD RID: 2813
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveCreateUpdate(IntPtr container, [MarshalAs(UnmanagedType.LPStr)] string containerDisplayName, out IntPtr updateContext);

		// Token: 0x06000AFE RID: 2814
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveCloseUpdate(IntPtr context);

		// Token: 0x06000AFF RID: 2815
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveSubmitBlobWrite(IntPtr updateContext, [MarshalAs(UnmanagedType.LPStr)] string blobName, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] [In] [Out] byte[] data, ulong byteCount);

		// Token: 0x06000B00 RID: 2816
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveSubmitBlobDelete(IntPtr updateContext, [MarshalAs(UnmanagedType.LPStr)] string blobName);

		// Token: 0x06000B01 RID: 2817
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveSubmitUpdate(IntPtr updateContext);

		// Token: 0x06000B02 RID: 2818
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveSubmitUpdateAsync(IntPtr updateContext, IntPtr async);

		// Token: 0x06000B03 RID: 2819
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameSaveSubmitUpdateResult(IntPtr async);

		// Token: 0x06000B04 RID: 2820
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingInitialize();

		// Token: 0x06000B05 RID: 2821
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameStreamingUninitialize();

		// Token: 0x06000B06 RID: 2822
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XGameStreamingIsStreaming();

		// Token: 0x06000B07 RID: 2823
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern uint XGameStreamingGetClientCount();

		// Token: 0x06000B08 RID: 2824
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetClients(uint clientCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [In] [Out] XGameStreamingClientId[] clients, out uint clientUsed);

		// Token: 0x06000B09 RID: 2825
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XGameStreamingConnectionState XGameStreamingGetConnectionState(XGameStreamingClientId client);

		// Token: 0x06000B0A RID: 2826
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingRegisterConnectionStateChanged(IntPtr queue, IntPtr context, XGameStreamingConnectionStateChangedCallback callback, out ulong token);

		// Token: 0x06000B0B RID: 2827
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XGameStreamingUnregisterConnectionStateChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000B0C RID: 2828
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameStreamingHideTouchControls();

		// Token: 0x06000B0D RID: 2829
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameStreamingHideTouchControlsOnClient(XGameStreamingClientId client);

		// Token: 0x06000B0E RID: 2830
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameStreamingShowTouchControlLayout([MarshalAs(UnmanagedType.LPStr)] string layout);

		// Token: 0x06000B0F RID: 2831
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameStreamingShowTouchControlLayoutOnClient(XGameStreamingClientId client, [MarshalAs(UnmanagedType.LPStr)] string layout);

		// Token: 0x06000B10 RID: 2832
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingRegisterClientPropertiesChanged(XGameStreamingClientId client, IntPtr queue, IntPtr context, XGameStreamingClientPropertiesChangedCallback callback, out ulong token);

		// Token: 0x06000B11 RID: 2833
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XGameStreamingUnregisterClientPropertiesChanged(XGameStreamingClientId client, ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000B12 RID: 2834
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetStreamPhysicalDimensions(XGameStreamingClientId client, out uint horizontalMm, out uint verticalMm);

		// Token: 0x06000B13 RID: 2835
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetStreamAddedLatency(XGameStreamingClientId client, out uint averageInputLatencyUs, out uint averageOutputLatencyUs, out uint standardDeviationUs);

		// Token: 0x06000B14 RID: 2836
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern ulong XGameStreamingGetServerLocationNameSize();

		// Token: 0x06000B15 RID: 2837
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetServerLocationName(ulong serverLocationNameSize, StringBuilder serverLocationName);

		// Token: 0x06000B16 RID: 2838
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingIsTouchInputEnabled(XGameStreamingClientId client, [MarshalAs(UnmanagedType.I1)] out bool touchInputEnabled);

		// Token: 0x06000B17 RID: 2839
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetLastFrameDisplayed(XGameStreamingClientId client, out ulong framePipelineToken);

		// Token: 0x06000B18 RID: 2840
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetAssociatedFrame(IntPtr gamepadReading, out ulong framePipelineToken);

		// Token: 0x06000B19 RID: 2841
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetGamepadPhysicality(IntPtr gamepadReading, out XGameStreamingGamepadPhysicality gamepadPhysicality);

		// Token: 0x06000B1A RID: 2842
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingUpdateTouchControlsState(ulong operationCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] XGameStreamingTouchControlsStateOperation[] operations);

		// Token: 0x06000B1B RID: 2843
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingUpdateTouchControlsStateOnClient(XGameStreamingClientId client, ulong operationCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XGameStreamingTouchControlsStateOperation[] operations);

		// Token: 0x06000B1C RID: 2844
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingShowTouchControlsWithStateUpdate([MarshalAs(UnmanagedType.LPStr)] string layout, ulong operatoinCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XGameStreamingTouchControlsStateOperation[] operations);

		// Token: 0x06000B1D RID: 2845
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingShowTouchControlsWithStateUpdateOnClient(XGameStreamingClientId client, [MarshalAs(UnmanagedType.LPStr)] string layout, ulong operationCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] XGameStreamingTouchControlsStateOperation[] operations);

		// Token: 0x06000B1E RID: 2846
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern ulong XGameStreamingGetTouchBundleVersionNameSize(XGameStreamingClientId client);

		// Token: 0x06000B1F RID: 2847
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetTouchBundleVersion(XGameStreamingClientId client, out XVersion version, ulong versionNameSize, StringBuilder versionName);

		// Token: 0x06000B20 RID: 2848
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetClientIPAddress(XGameStreamingClientId client, ulong ipAddressSize, StringBuilder ipAddress);

		// Token: 0x06000B21 RID: 2849
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetSessionId(XGameStreamingClientId client, ulong sessionIdSize, StringBuilder sessionId, out ulong sessionIdUsed);

		// Token: 0x06000B22 RID: 2850
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingGetDisplayDetails(XGameStreamingClientId clientId, uint maxSupportedPixels, float widestSupportedAspectRatio, float tallestSupportedAspectRatio, out XGameStreamingDisplayDetails displayDetails);

		// Token: 0x06000B23 RID: 2851
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameStreamingSetResolution(uint width, uint height);

		// Token: 0x06000B24 RID: 2852
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowMessageDialogAsync(IntPtr async, [MarshalAs(UnmanagedType.LPStr)] string titleText, [MarshalAs(UnmanagedType.LPStr)] string contextText, [MarshalAs(UnmanagedType.LPStr)] string firstButtonText, [MarshalAs(UnmanagedType.LPStr)] string secondButtonText, [MarshalAs(UnmanagedType.LPStr)] string thirdButtonText, XGameUiMessageDialogButton defaultButton, XGameUiMessageDialogButton cancelButton);

		// Token: 0x06000B25 RID: 2853
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowMessageDialogResult(IntPtr async, out XGameUiMessageDialogButton resultButton);

		// Token: 0x06000B26 RID: 2854
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowSendGameInviteAsync(IntPtr async, IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string sessionConfigurationId, [MarshalAs(UnmanagedType.LPStr)] string sessionTemplateName, [MarshalAs(UnmanagedType.LPStr)] string sessionId, [MarshalAs(UnmanagedType.LPStr)] string invitationText, [MarshalAs(UnmanagedType.LPStr)] string customActivationContext);

		// Token: 0x06000B27 RID: 2855
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowSendGameInviteResult(IntPtr async);

		// Token: 0x06000B28 RID: 2856
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowMultiplayerActivityGameInviteAsync(IntPtr async, IntPtr requestingUser);

		// Token: 0x06000B29 RID: 2857
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowMultiplayerActivityGameInviteResult(IntPtr async);

		// Token: 0x06000B2A RID: 2858
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowPlayerProfileCardAsync(IntPtr async, IntPtr requestingUser, ulong targetPlayer);

		// Token: 0x06000B2B RID: 2859
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowPlayerProfileCardResult(IntPtr async);

		// Token: 0x06000B2C RID: 2860
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowAchievementsAsync(IntPtr async, IntPtr requestingUser, uint titleId);

		// Token: 0x06000B2D RID: 2861
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowAchievementsResult(IntPtr async);

		// Token: 0x06000B2E RID: 2862
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowPlayerPickerAsync(IntPtr async, IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string promptText, uint selectFromPlayersCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ulong[] selectFromPlayers, uint preSelectedPlayersCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ulong[] preSelectedPlayers, uint minSelectionCount, uint maxSelectionCount);

		// Token: 0x06000B2F RID: 2863
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowPlayerPickerResultCount(IntPtr async, out uint resultPlayersCount);

		// Token: 0x06000B30 RID: 2864
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowPlayerPickerResult(IntPtr async, uint resultPlayersCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ulong[] resultPlayers, out uint resultPlayerUsed);

		// Token: 0x06000B31 RID: 2865
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowErrorDialogAsync(IntPtr async, int errorCode, [MarshalAs(UnmanagedType.LPStr)] string context);

		// Token: 0x06000B32 RID: 2866
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowErrorDialogResult(IntPtr async);

		// Token: 0x06000B33 RID: 2867
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiSetNotificationPositionHint(XGameUiNotificationPositionHint position);

		// Token: 0x06000B34 RID: 2868
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowTextEntryAsync(IntPtr async, [MarshalAs(UnmanagedType.LPStr)] string titleText, [MarshalAs(UnmanagedType.LPStr)] string descriptionText, [MarshalAs(UnmanagedType.LPStr)] string defaultText, XGameUiTextEntryInputScope inputScope, uint maxTextLength);

		// Token: 0x06000B35 RID: 2869
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowTextEntryResultSize(IntPtr async, out uint resultTextBufferSize);

		// Token: 0x06000B36 RID: 2870
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowTextEntryResult(IntPtr async, uint resultTextBufferSize, StringBuilder resultTextBuffer, out uint resultTextBufferUsed);

		// Token: 0x06000B37 RID: 2871
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowWebAuthenticationAsync(IntPtr async, IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string requestUri, [MarshalAs(UnmanagedType.LPStr)] string completionUri);

		// Token: 0x06000B38 RID: 2872
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowWebAuthenticationWithOptionsAsync(IntPtr async, IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string requestUri, [MarshalAs(UnmanagedType.LPStr)] string completionUri, XGameUiWebAuthenticationOptions options);

		// Token: 0x06000B39 RID: 2873
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowWebAuthenticationResult(IntPtr asyncblock, ulong bufferSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] byte[] buffer, out IntPtr ptrToBuffer, out ulong bufferUsed);

		// Token: 0x06000B3A RID: 2874
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiShowWebAuthenticationResultSize(IntPtr async, out ulong bufferSize);

		// Token: 0x06000B3B RID: 2875
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiTextEntryOpen(XGameUiTextEntryOptions options, uint maxLength, [MarshalAs(UnmanagedType.LPStr)] string initialText, uint cursorIndex, out IntPtr handle);

		// Token: 0x06000B3C RID: 2876
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XGameUiTextEntryClose(IntPtr handle);

		// Token: 0x06000B3D RID: 2877
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiTextEntryGetExtents(IntPtr handle, out XGameUiTextEntryExtents extents);

		// Token: 0x06000B3E RID: 2878
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiTextEntryGetState(IntPtr handle, out XGameUiTextEntryChangeTypeFlags changeType, out uint cursorIndex, out uint imeClauseStartIndex, out uint imeClauseEndIndex, uint bufferSize, StringBuilder buffer);

		// Token: 0x06000B3F RID: 2879
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiTextEntryUpdatePositionHint(IntPtr handle, XGameUiTextEntryPositionHint positionHint);

		// Token: 0x06000B40 RID: 2880
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XGameUiTextEntryUpdateVisibility(IntPtr handle, XGameUiTextEntryVisibilityFlags visibilityFlags);

		// Token: 0x06000B41 RID: 2881
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XLaunchUri(IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string uri);

		// Token: 0x06000B42 RID: 2882
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingGetConnectivityHint(out XNetworkingConnectivityHint connectivityHint);

		// Token: 0x06000B43 RID: 2883
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQueryConfigurationSetting(XNetworkingConfigurationSetting configurationSetting, out ulong value);

		// Token: 0x06000B44 RID: 2884
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQueryPreferredLocalUdpMultiplayerPort(out ushort value);

		// Token: 0x06000B45 RID: 2885
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(IntPtr async);

		// Token: 0x06000B46 RID: 2886
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsyncResult(IntPtr async, out ushort preferredLocalUdpMultiplayerPort);

		// Token: 0x06000B47 RID: 2887
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQuerySecurityInformationForUrlAsync([MarshalAs(UnmanagedType.LPStr)] string url, IntPtr async);

		// Token: 0x06000B48 RID: 2888
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQuerySecurityInformationForUrlAsyncResultSize(IntPtr async, out ulong securityInformationBufferByteCount);

		// Token: 0x06000B49 RID: 2889
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQuerySecurityInformationForUrlAsyncResult(IntPtr async, ulong securityInformationBufferByteCount, out ulong securityInformationBufferByteCountUsed, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] byte[] securityInformationBuffer, out IntPtr securityInformation);

		// Token: 0x06000B4A RID: 2890
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQuerySecurityInformationForUrlUtf16Async([MarshalAs(UnmanagedType.LPWStr)] string url, IntPtr async);

		// Token: 0x06000B4B RID: 2891
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQuerySecurityInformationForUrlUtf16AsyncResultSize(IntPtr async, out ulong securityInformationBufferByteCount);

		// Token: 0x06000B4C RID: 2892
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQuerySecurityInformationForUrlUtf16AsyncResult(IntPtr async, ulong securityInformationBufferByteCount, out ulong securityInformationBufferByteCountUsed, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] byte[] securityInformationBuffer, out IntPtr securityInformation);

		// Token: 0x06000B4D RID: 2893
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingQueryStatistics(XNetworkingStatisticsType statisticsType, out XNetworkingStatisticsBuffer statisticsBuffer);

		// Token: 0x06000B4E RID: 2894
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingRegisterConnectivityHintChanged(IntPtr taskQueueHandle, IntPtr context, XNetworkingConnectivityHintChangedCallback callback, out ulong registrationToken);

		// Token: 0x06000B4F RID: 2895
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XNetworkingUnregisterConnectivityHintChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000B50 RID: 2896
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged(IntPtr taskQueueHandle, IntPtr context, XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, out ulong registrationToken);

		// Token: 0x06000B51 RID: 2897
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000B52 RID: 2898
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XNetworkingVerifyServerCertificate(IntPtr requestHandle, IntPtr securityInformation);

		// Token: 0x06000B53 RID: 2899
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageCreateInstallationMonitor([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, uint minimumUpdateIntervalMs, IntPtr queue, out IntPtr installationMonitor);

		// Token: 0x06000B54 RID: 2900
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XPackageCloseInstallationMonitorHandle(IntPtr installationMonitor);

		// Token: 0x06000B55 RID: 2901
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageGetCurrentProcessPackageIdentifier(ulong bufferSize, StringBuilder buffer);

		// Token: 0x06000B56 RID: 2902
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XPackageIsPackagedProcess();

		// Token: 0x06000B57 RID: 2903
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XPackageGetInstallationProgress(IntPtr installationMonitor, out XPackageInstallationProgress progress);

		// Token: 0x06000B58 RID: 2904
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XPackageUpdateInstallationMonitor(IntPtr installationMonitor);

		// Token: 0x06000B59 RID: 2905
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageGetUserLocale(ulong localeSize, StringBuilder locale);

		// Token: 0x06000B5A RID: 2906
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageFindChunkAvailability([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, out XPackageChunkAvailability availability);

		// Token: 0x06000B5B RID: 2907
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageChangeChunkInstallOrder([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors);

		// Token: 0x06000B5C RID: 2908
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageInstallChunks([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, uint minimumUpdateIntervalMs, [MarshalAs(UnmanagedType.I1)] bool suppressUserConfirmation, IntPtr queue, out IntPtr installationMonitor);

		// Token: 0x06000B5D RID: 2909
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageInstallChunksAsync([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, uint minimumUpdateIntervalMs, [MarshalAs(UnmanagedType.I1)] bool suppressUserConfirmation, IntPtr async);

		// Token: 0x06000B5E RID: 2910
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageInstallChunksResult(IntPtr asyncBlock, out IntPtr installationMonitor);

		// Token: 0x06000B5F RID: 2911
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageEstimateDownloadSize([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, out ulong downloadSize, [MarshalAs(UnmanagedType.I1)] out bool shouldPresentUserConfirmation);

		// Token: 0x06000B60 RID: 2912
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageUninstallChunks([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors);

		// Token: 0x06000B61 RID: 2913
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XPackageCloseMountHandle(IntPtr mount);

		// Token: 0x06000B62 RID: 2914
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageEnumerateChunkAvailability([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, XPackageChunkSelectorType type, IntPtr context, XPackageChunkAvailabilityCallback callback);

		// Token: 0x06000B63 RID: 2915
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageEnumerateFeatures([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr context, XPackageFeatureEnumerationCallbackInterop callback);

		// Token: 0x06000B64 RID: 2916
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, IntPtr context, XPackageEnumerationCallback callback);

		// Token: 0x06000B65 RID: 2917
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageGetMountPathSize(IntPtr mount, out ulong pathSize);

		// Token: 0x06000B66 RID: 2918
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageGetMountPath(IntPtr mount, ulong pathSize, StringBuilder path);

		// Token: 0x06000B67 RID: 2919
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageGetWriteStats(out XPackageWriteStats writeStats);

		// Token: 0x06000B68 RID: 2920
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageMountWithUiAsync([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr async);

		// Token: 0x06000B69 RID: 2921
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageMountWithUiResult(IntPtr async, out IntPtr mount);

		// Token: 0x06000B6A RID: 2922
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageRegisterInstallationProgressChanged(IntPtr installationMonitor, IntPtr context, XPackageInstallationProgressCallback callback, out ulong token);

		// Token: 0x06000B6B RID: 2923
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageRegisterPackageInstalled(IntPtr queue, IntPtr context, XPackageInstalledCallback callback, out ulong token);

		// Token: 0x06000B6C RID: 2924
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPackageUninstallUWPInstance([MarshalAs(UnmanagedType.LPStr)] string packageName);

		// Token: 0x06000B6D RID: 2925
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XPackageUninstallPackage([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier);

		// Token: 0x06000B6E RID: 2926
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XPackageUnregisterInstallationProgressChanged(IntPtr installationMonitor, ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000B6F RID: 2927
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XPackageUnregisterPackageInstalled(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000B70 RID: 2928
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPersistentLocalStorageGetPathSize(out ulong pathSize);

		// Token: 0x06000B71 RID: 2929
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPersistentLocalStorageGetPath(ulong pathSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [In] [Out] byte[] path, out ulong pathUsed);

		// Token: 0x06000B72 RID: 2930
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPersistentLocalStorageGetSpaceInfo(out XPersistentLocalStorageSpaceInfo spaceInfo);

		// Token: 0x06000B73 RID: 2931
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPersistentLocalStoragePromptUserForSpaceAsync(ulong requestedBytes, IntPtr asyncBlock);

		// Token: 0x06000B74 RID: 2932
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XPersistentLocalStoragePromptUserForSpaceResult(IntPtr asyncBlock);

		// Token: 0x06000B75 RID: 2933
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerEnumerateInstalledVoices(IntPtr context, XSpeechSynthesizerInstalledVoicesCallback callback);

		// Token: 0x06000B76 RID: 2934
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerCreate(out IntPtr speechSynthesizer);

		// Token: 0x06000B77 RID: 2935
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerCloseHandle(IntPtr speechSynthesizer);

		// Token: 0x06000B78 RID: 2936
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerSetDefaultVoice(IntPtr speechSynthesizer);

		// Token: 0x06000B79 RID: 2937
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerSetCustomVoice(IntPtr speechSynthesizer, [MarshalAs(UnmanagedType.LPStr)] string voiceId);

		// Token: 0x06000B7A RID: 2938
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerCreateStreamFromText(IntPtr speechSynthesizer, [MarshalAs(UnmanagedType.LPStr)] string text, out IntPtr speechSynthesisStream);

		// Token: 0x06000B7B RID: 2939
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerCreateStreamFromSsml(IntPtr speechSynthesizer, [MarshalAs(UnmanagedType.LPStr)] string ssml, out IntPtr speechSynthesisStream);

		// Token: 0x06000B7C RID: 2940
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerCloseStreamHandle(IntPtr speechSynthesisStream);

		// Token: 0x06000B7D RID: 2941
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerGetStreamDataSize(IntPtr speechSynthesisStream, out ulong bufferSize);

		// Token: 0x06000B7E RID: 2942
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSpeechSynthesizerGetStreamData(IntPtr speechSynthesisStream, ulong bufferSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] byte[] buffer, out ulong bufferUsed);

		// Token: 0x06000B7F RID: 2943
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreCreateContext(IntPtr user, out IntPtr storeContextHandle);

		// Token: 0x06000B80 RID: 2944
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XStoreCloseContextHandle(IntPtr storeContextHandle);

		// Token: 0x06000B81 RID: 2945
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XStoreCloseLicenseHandle(IntPtr storeLicenseHandle);

		// Token: 0x06000B82 RID: 2946
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreAcquireLicenseForDurablesAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeId, IntPtr async);

		// Token: 0x06000B83 RID: 2947
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreAcquireLicenseForDurablesResult(IntPtr async, out IntPtr storeLicenseHandle);

		// Token: 0x06000B84 RID: 2948
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreAcquireLicenseForPackageAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr async);

		// Token: 0x06000B85 RID: 2949
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreAcquireLicenseForPackageResult(IntPtr async, out IntPtr storeLicenseHandle);

		// Token: 0x06000B86 RID: 2950
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreCanAcquireLicenseForStoreIdAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeProductId, IntPtr async);

		// Token: 0x06000B87 RID: 2951
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreCanAcquireLicenseForStoreIdResult(IntPtr async, out XStoreCanAcquireLicenseResult storeCanAcquireLicenseResult);

		// Token: 0x06000B88 RID: 2952
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreCanAcquireLicenseForPackageAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr async);

		// Token: 0x06000B89 RID: 2953
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreCanAcquireLicenseForPackageResult(IntPtr async, out XStoreCanAcquireLicenseResult storeCanAcquireLicenseResult);

		// Token: 0x06000B8A RID: 2954
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryProductForCurrentGameAsync(IntPtr storeContextHandle, IntPtr async);

		// Token: 0x06000B8B RID: 2955
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryProductForCurrentGameResult(IntPtr async, out IntPtr productQueryHandle);

		// Token: 0x06000B8C RID: 2956
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreEnumerateProductsQuery(IntPtr productQueryHandle, IntPtr context, XStoreProductQueryCallbackInterop callback);

		// Token: 0x06000B8D RID: 2957
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XStoreCloseProductsQueryHandle(IntPtr productQueryHandle);

		// Token: 0x06000B8E RID: 2958
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreDownloadPackageUpdatesAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] packageIdentifiers, ulong packageIdentifiersCount, IntPtr async);

		// Token: 0x06000B8F RID: 2959
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreDownloadPackageUpdatesResult(IntPtr async);

		// Token: 0x06000B90 RID: 2960
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreDownloadAndInstallPackageUpdatesAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] packageIdentifiers, ulong packageIdentifiersCount, IntPtr async);

		// Token: 0x06000B91 RID: 2961
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreDownloadAndInstallPackageUpdatesResult(IntPtr async);

		// Token: 0x06000B92 RID: 2962
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreDownloadAndInstallPackagesAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] storeIds, ulong storeIdsCount, IntPtr async);

		// Token: 0x06000B93 RID: 2963
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreDownloadAndInstallPackagesResultCount(IntPtr async, out uint count);

		// Token: 0x06000B94 RID: 2964
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreDownloadAndInstallPackagesResult(IntPtr async, uint count, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] XStorePackageIdentifierInterop[] identifiers);

		// Token: 0x06000B95 RID: 2965
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreGetUserCollectionsIdAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string serviceTicket, [MarshalAs(UnmanagedType.LPStr)] string publisherUserId, IntPtr async);

		// Token: 0x06000B96 RID: 2966
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreGetUserCollectionsIdResultSize(IntPtr async, out ulong size);

		// Token: 0x06000B97 RID: 2967
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreGetUserCollectionsIdResult(IntPtr async, ulong size, StringBuilder result);

		// Token: 0x06000B98 RID: 2968
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreGetUserPurchaseIdAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string serviceTicket, [MarshalAs(UnmanagedType.LPStr)] string publisherUserId, IntPtr async);

		// Token: 0x06000B99 RID: 2969
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreGetUserPurchaseIdResultSize(IntPtr async, out ulong size);

		// Token: 0x06000B9A RID: 2970
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreGetUserPurchaseIdResult(IntPtr async, ulong size, StringBuilder result);

		// Token: 0x06000B9B RID: 2971
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XStoreIsAvailabilityPurchasable(XStoreAvailability availability);

		// Token: 0x06000B9C RID: 2972
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XStoreIsLicenseValid(IntPtr storeLicenseHandle);

		// Token: 0x06000B9D RID: 2973
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XStoreProductsQueryHasMorePages(IntPtr productQueryHandle);

		// Token: 0x06000B9E RID: 2974
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreProductsQueryNextPageAsync(IntPtr productQueryHandle, IntPtr async);

		// Token: 0x06000B9F RID: 2975
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreProductsQueryNextPageResult(IntPtr async, out IntPtr productQueryHandle);

		// Token: 0x06000BA0 RID: 2976
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryAddOnLicensesAsync(IntPtr storeContextHandle, IntPtr async);

		// Token: 0x06000BA1 RID: 2977
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryAddOnLicensesResultCount(IntPtr async, out uint count);

		// Token: 0x06000BA2 RID: 2978
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryAddOnLicensesResult(IntPtr async, uint count, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] XStoreAddonLicense[] addOnLicenses);

		// Token: 0x06000BA3 RID: 2979
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryAssociatedProductsAsync(IntPtr storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, IntPtr async);

		// Token: 0x06000BA4 RID: 2980
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryAssociatedProductsResult(IntPtr async, out IntPtr productQueryHandle);

		// Token: 0x06000BA5 RID: 2981
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryConsumableBalanceRemainingAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeProductId, IntPtr async);

		// Token: 0x06000BA6 RID: 2982
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryConsumableBalanceRemainingResult(IntPtr async, out XStoreConsumableResult consumableResult);

		// Token: 0x06000BA7 RID: 2983
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryEntitledProductsAsync(IntPtr storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, IntPtr async);

		// Token: 0x06000BA8 RID: 2984
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryEntitledProductsResult(IntPtr async, out IntPtr productQueryHandle);

		// Token: 0x06000BA9 RID: 2985
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryGameAndDlcPackageUpdatesAsync(IntPtr storeContextHandle, IntPtr async);

		// Token: 0x06000BAA RID: 2986
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryGameAndDlcPackageUpdatesResultCount(IntPtr async, out uint count);

		// Token: 0x06000BAB RID: 2987
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryGameAndDlcPackageUpdatesResult(IntPtr async, uint count, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] XStorePackageUpdate[] packageUpdates);

		// Token: 0x06000BAC RID: 2988
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryGameLicenseAsync(IntPtr storeContextHandle, IntPtr async);

		// Token: 0x06000BAD RID: 2989
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryGameLicenseResult(IntPtr async, out XStoreGameLicense license);

		// Token: 0x06000BAE RID: 2990
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryLicenseTokenAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 1)] string[] productIds, ulong productIdsCount, [MarshalAs(UnmanagedType.LPStr)] string customDeveloperString, IntPtr async);

		// Token: 0x06000BAF RID: 2991
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryLicenseTokenResultSize(IntPtr async, out ulong size);

		// Token: 0x06000BB0 RID: 2992
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryLicenseTokenResult(IntPtr async, ulong size, StringBuilder result);

		// Token: 0x06000BB1 RID: 2993
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryPackageIdentifier([MarshalAs(UnmanagedType.LPStr)] string storeId, ulong size, StringBuilder packageIdentifier);

		// Token: 0x06000BB2 RID: 2994
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryProductForPackageAsync(IntPtr storeContextHandle, XStoreProductKind productKinds, [MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr async);

		// Token: 0x06000BB3 RID: 2995
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryProductForPackageResult(IntPtr async, out IntPtr productQueryHandle);

		// Token: 0x06000BB4 RID: 2996
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryProductsAsync(IntPtr storeContextHandle, XStoreProductKind productKinds, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 3)] string[] storeIds, ulong storeIdsCount, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 5)] string[] actionFilters, ulong actionFiltersCount, IntPtr async);

		// Token: 0x06000BB5 RID: 2997
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreQueryProductsResult(IntPtr async, out IntPtr productQueryHandle);

		// Token: 0x06000BB6 RID: 2998
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreRegisterGameLicenseChanged(IntPtr storeContextHandle, IntPtr queue, IntPtr context, XStoreGameLicenseChangedCallback callback, out ulong token);

		// Token: 0x06000BB7 RID: 2999
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XStoreUnregisterGameLicenseChanged(IntPtr storeContextHandle, ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000BB8 RID: 3000
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreRegisterPackageLicenseLost(IntPtr licenseHandle, IntPtr queue, IntPtr context, XStorePackageLicenseLostCallback callback, out ulong token);

		// Token: 0x06000BB9 RID: 3001
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XStoreUnregisterPackageLicenseLost(IntPtr licenseHandle, ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000BBA RID: 3002
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreReportConsumableFulfillmentAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeProductId, uint quantity, Guid trackingId, IntPtr async);

		// Token: 0x06000BBB RID: 3003
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreReportConsumableFulfillmentResult(IntPtr async, out XStoreConsumableResult consumableResult);

		// Token: 0x06000BBC RID: 3004
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowAssociatedProductsUIAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeId, XStoreProductKind productKinds, IntPtr async);

		// Token: 0x06000BBD RID: 3005
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowAssociatedProductsUIResult(IntPtr async);

		// Token: 0x06000BBE RID: 3006
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowProductPageUIAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeId, IntPtr async);

		// Token: 0x06000BBF RID: 3007
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowProductPageUIResult(IntPtr async);

		// Token: 0x06000BC0 RID: 3008
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowPurchaseUIAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeId, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string extendedJsonData, IntPtr async);

		// Token: 0x06000BC1 RID: 3009
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowPurchaseUIResult(IntPtr async);

		// Token: 0x06000BC2 RID: 3010
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowRateAndReviewUIAsync(IntPtr storeContextHandle, IntPtr async);

		// Token: 0x06000BC3 RID: 3011
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowRateAndReviewUIResult(IntPtr async, out XStoreRateAndReviewResult result);

		// Token: 0x06000BC4 RID: 3012
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowRedeemTokenUIAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string token, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 3)] string[] allowedStoreIds, ulong allowedStoreIdsCount, [MarshalAs(UnmanagedType.I1)] bool disallowCsvRedemption, IntPtr async);

		// Token: 0x06000BC5 RID: 3013
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XStoreShowRedeemTokenUIResult(IntPtr async);

		// Token: 0x06000BC6 RID: 3014
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XSystemGetAnalyticsInfo(out XSystemAnalyticsInfo info);

		// Token: 0x06000BC7 RID: 3015
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSystemGetAppSpecificDeviceId(ulong appSpecificDeviceIdSize, StringBuilder appSpecificDeviceId, out ulong appSpecificDeviceIdUsed);

		// Token: 0x06000BC8 RID: 3016
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSystemGetConsoleId(ulong consoleIdSize, StringBuilder consoleId, out ulong consoleIdUsed);

		// Token: 0x06000BC9 RID: 3017
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XSystemDeviceType XSystemGetDeviceType();

		// Token: 0x06000BCA RID: 3018
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSystemGetXboxLiveSandboxId(ulong sandboxIdSize, StringBuilder sandboxId, out ulong sandboxIdUsed);

		// Token: 0x06000BCB RID: 3019
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern XSystemRuntimeInfo XSystemGetRuntimeInfo();

		// Token: 0x06000BCC RID: 3020
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XSystemIsHandleValid(IntPtr handle);

		// Token: 0x06000BCD RID: 3021
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XSystemHandleTrack(XSystemHandleCallback callback, IntPtr context);

		// Token: 0x06000BCE RID: 3022
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XTaskQueueCloseHandle(IntPtr queue);

		// Token: 0x06000BCF RID: 3023
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueCreate(XTaskQueueDispatchMode workDispatchMode, XTaskQueueDispatchMode completionDispatchMode, out IntPtr queue);

		// Token: 0x06000BD0 RID: 3024
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueCreateComposite(IntPtr workPort, IntPtr completionPort, out IntPtr queue);

		// Token: 0x06000BD1 RID: 3025
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XTaskQueueDispatch(IntPtr queue, XTaskQueuePort port, uint timeoutInMs);

		// Token: 0x06000BD2 RID: 3026
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueDuplicateHandle(IntPtr queueHandle, out IntPtr duplicatedHandle);

		// Token: 0x06000BD3 RID: 3027
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XTaskQueueGetCurrentProcessTaskQueue(out IntPtr queue);

		// Token: 0x06000BD4 RID: 3028
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueGetPort(IntPtr queue, XTaskQueuePort port, out IntPtr portHandle);

		// Token: 0x06000BD5 RID: 3029
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueRegisterMonitor(IntPtr queue, IntPtr callbackContext, XTaskQueueMonitorCallback callback, out ulong token);

		// Token: 0x06000BD6 RID: 3030
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueRegisterWaiter(IntPtr queue, XTaskQueuePort port, SafeWaitHandle waitHandle, IntPtr callbackContext, XTaskQueueCallback callback, out ulong token);

		// Token: 0x06000BD7 RID: 3031
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XTaskQueueSetCurrentProcessTaskQueue(IntPtr queue);

		// Token: 0x06000BD8 RID: 3032
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueSubmitCallback(IntPtr queue, XTaskQueuePort port, IntPtr callbackContext, XTaskQueueCallback callback);

		// Token: 0x06000BD9 RID: 3033
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueSubmitDelayedCallback(IntPtr queue, XTaskQueuePort port, uint delayMs, IntPtr callbackContext, XTaskQueueCallback callback);

		// Token: 0x06000BDA RID: 3034
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueTerminate(IntPtr queue, [MarshalAs(UnmanagedType.I1)] bool wait, IntPtr callbackContext, XTaskQueueTerminatedCallback callback);

		// Token: 0x06000BDB RID: 3035
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueUnregisterMonitor(IntPtr queue, ulong token);

		// Token: 0x06000BDC RID: 3036
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XTaskQueueUnregisterWaiter(IntPtr queue, ulong token);

		// Token: 0x06000BDD RID: 3037
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XThreadAssertNotTimeSensitive();

		// Token: 0x06000BDE RID: 3038
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XThreadIsTimeSensitive();

		// Token: 0x06000BDF RID: 3039
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XThreadSetTimeSensitive([MarshalAs(UnmanagedType.I1)] bool isTimeSensitiveThread);

		// Token: 0x06000BE0 RID: 3040
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserAddAsync(XUserAddOptions options, IntPtr async);

		// Token: 0x06000BE1 RID: 3041
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserAddResult(IntPtr async, out IntPtr newUser);

		// Token: 0x06000BE2 RID: 3042
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserAddByIdWithUiAsync(ulong userId, IntPtr async);

		// Token: 0x06000BE3 RID: 3043
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserAddByIdWithUiResult(IntPtr async, out IntPtr newUser);

		// Token: 0x06000BE4 RID: 3044
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserCheckPrivilege(IntPtr user, XUserPrivilegeOptions options, XUserPrivilege privilege, [MarshalAs(UnmanagedType.I1)] out bool hasPrivilege, out XUserPrivilegeDenyReason reason);

		// Token: 0x06000BE5 RID: 3045
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XUserCloseHandle(IntPtr user);

		// Token: 0x06000BE6 RID: 3046
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern void XUserCloseSignOutDeferralHandle(IntPtr deferral);

		// Token: 0x06000BE7 RID: 3047
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserCompare(IntPtr user1, IntPtr user2);

		// Token: 0x06000BE8 RID: 3048
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserDuplicateHandle(IntPtr handle, out IntPtr duplicatedHandle);

		// Token: 0x06000BE9 RID: 3049
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserFindControllerForUserWithUiAsync(IntPtr user, IntPtr async);

		// Token: 0x06000BEA RID: 3050
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserFindControllerForUserWithUiResult(IntPtr async, out APP_LOCAL_DEVICE_ID deviceId);

		// Token: 0x06000BEB RID: 3051
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserFindForDevice(ref APP_LOCAL_DEVICE_ID deviceId, out IntPtr handle);

		// Token: 0x06000BEC RID: 3052
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserFindUserById(ulong userId, out IntPtr handle);

		// Token: 0x06000BED RID: 3053
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserFindUserByLocalId(XUserLocalId userLocalId, out IntPtr handle);

		// Token: 0x06000BEE RID: 3054
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetAgeGroup(IntPtr user, out XUserAgeGroup ageGroup);

		// Token: 0x06000BEF RID: 3055
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		internal static extern int XUserGetDefaultAudioEndpointUtf16(XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, ulong endpointIdUtf16Count, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] [In] [Out] char[] endpointIdUtf16, out ulong endpointIdUtf16Used);

		// Token: 0x06000BF0 RID: 3056
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetGamerPictureAsync(IntPtr user, XUserGamerPictureSize pictureSize, IntPtr async);

		// Token: 0x06000BF1 RID: 3057
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetGamerPictureResultSize(IntPtr async, out ulong bufferSize);

		// Token: 0x06000BF2 RID: 3058
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetGamerPictureResult(IntPtr async, ulong bufferSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] byte[] buffer, out ulong bufferUsed);

		// Token: 0x06000BF3 RID: 3059
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetGamertag(IntPtr user, XUserGamertagComponent gamertagComponent, ulong gamertagSize, StringBuilder gamertag, out ulong gamertagUsed);

		// Token: 0x06000BF4 RID: 3060
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetId(IntPtr user, out ulong userId);

		// Token: 0x06000BF5 RID: 3061
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetIsGuest(IntPtr user, [MarshalAs(UnmanagedType.I1)] out bool isGuest);

		// Token: 0x06000BF6 RID: 3062
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetLocalId(IntPtr user, out XUserLocalId userLocalId);

		// Token: 0x06000BF7 RID: 3063
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetMaxUsers(out uint maxUsers);

		// Token: 0x06000BF8 RID: 3064
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetSignOutDeferral(out IntPtr deferral);

		// Token: 0x06000BF9 RID: 3065
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetState(IntPtr user, out XUserState state);

		// Token: 0x06000BFA RID: 3066
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetTokenAndSignatureAsync(IntPtr user, XUserGetTokenAndSignatureOptions options, [MarshalAs(UnmanagedType.LPStr)] string method, [MarshalAs(UnmanagedType.LPStr)] string url, ulong headerCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] XUserGetTokenAndSignatureHttpHeader[] headers, ulong bodySize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] bodyBuffer, IntPtr async);

		// Token: 0x06000BFB RID: 3067
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetTokenAndSignatureResultSize(IntPtr async, out ulong bufferSize);

		// Token: 0x06000BFC RID: 3068
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetTokenAndSignatureResult(IntPtr async, ulong bufferSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] byte[] buffer, out IntPtr ptrToBuffer, out ulong bufferUsed);

		// Token: 0x06000BFD RID: 3069
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetTokenAndSignatureUtf16Async(IntPtr user, XUserGetTokenAndSignatureOptions options, [MarshalAs(UnmanagedType.LPWStr)] string method, [MarshalAs(UnmanagedType.LPWStr)] string url, ulong headerCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] XUserGetTokenAndSignatureUtf16HttpHeader[] headers, ulong bodySize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] bodyBuffer, IntPtr async);

		// Token: 0x06000BFE RID: 3070
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetTokenAndSignatureUtf16ResultSize(IntPtr async, out ulong bufferSize);

		// Token: 0x06000BFF RID: 3071
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserGetTokenAndSignatureUtf16Result(IntPtr async, ulong bufferSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [In] [Out] byte[] buffer, out IntPtr ptrToBuffer, out ulong bufferUsed);

		// Token: 0x06000C00 RID: 3072
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XUserIsStoreUser(IntPtr user);

		// Token: 0x06000C01 RID: 3073
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserRegisterForChangeEvent(IntPtr queue, IntPtr context, XUserChangeEventCallback callback, out ulong token);

		// Token: 0x06000C02 RID: 3074
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserRegisterForDefaultAudioEndpointUtf16Changed(IntPtr queue, IntPtr context, XUserDefaultAudioEndpointUtf16ChangedCallback callback, out ulong token);

		// Token: 0x06000C03 RID: 3075
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserRegisterForDeviceAssociationChanged(IntPtr queue, IntPtr context, XUserDeviceAssociationChangedCallback callback, out ulong token);

		// Token: 0x06000C04 RID: 3076
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserResolveIssueWithUiAsync(IntPtr user, [MarshalAs(UnmanagedType.LPStr)] string url, IntPtr async);

		// Token: 0x06000C05 RID: 3077
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserResolveIssueWithUiResult(IntPtr async);

		// Token: 0x06000C06 RID: 3078
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserResolveIssueWithUiUtf16Async(IntPtr user, [MarshalAs(UnmanagedType.LPWStr)] string url, IntPtr async);

		// Token: 0x06000C07 RID: 3079
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserResolveIssueWithUiUtf16Result(IntPtr async);

		// Token: 0x06000C08 RID: 3080
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserResolvePrivilegeWithUiAsync(IntPtr user, XUserPrivilegeOptions options, XUserPrivilege privilege, IntPtr async);

		// Token: 0x06000C09 RID: 3081
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		internal static extern int XUserResolvePrivilegeWithUiResult(IntPtr async);

		// Token: 0x06000C0A RID: 3082
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XUserUnregisterForChangeEvent(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000C0B RID: 3083
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XUserUnregisterForDefaultAudioEndpointUtf16Changed(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x06000C0C RID: 3084
		[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool XUserUnregisterForDeviceAssociationChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

		// Token: 0x04000600 RID: 1536
		internal const int MAX_PATH = 260;

		// Token: 0x04000601 RID: 1537
		internal const int APPCAPTURE_MAX_CAPTURE_FILES = 10;

		// Token: 0x04000602 RID: 1538
		internal const int APPCAPTURE_MAX_LOCALID_LENGTH = 250;
	}
}
