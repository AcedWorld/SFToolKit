using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using AOT;
using Unity.XGamingRuntime.Interop;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200000D RID: 13
	[MovedFrom("Unity.GameCore")]
	public class SDK
	{
		// Token: 0x06000038 RID: 56 RVA: 0x0000230C File Offset: 0x0000050C
		[MonoPInvokeCallback]
		private unsafe static void HCWebSocketMessageCallback(HCWebsocketHandle websocket, IntPtr incomingBodyString, IntPtr functionContext)
		{
			HCWebsocketHandle hcwebsocketHandle = GCHandle.FromIntPtr(functionContext).Target as HCWebsocketHandle;
			if (websocket.Ptr != hcwebsocketHandle.InteropHandle.Ptr)
			{
				hcwebsocketHandle.InteropHandle = websocket;
			}
			string incomingBodyString2 = null;
			if (incomingBodyString != IntPtr.Zero)
			{
				int num = 0;
				while (Marshal.ReadByte(incomingBodyString, num) != 0)
				{
					num++;
				}
				incomingBodyString2 = Encoding.UTF8.GetString((byte*)((void*)incomingBodyString), num);
			}
			HCWebSocketMessageFunction messageCallback = hcwebsocketHandle.messageCallback;
			if (messageCallback == null)
			{
				return;
			}
			messageCallback(hcwebsocketHandle, incomingBodyString2);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002390 File Offset: 0x00000590
		[MonoPInvokeCallback]
		private static void HCWebSocketBinaryMessageCallback(HCWebsocketHandle websocket, IntPtr payloadBytes, uint countOfBlobs, IntPtr functionContext)
		{
			HCWebsocketHandle hcwebsocketHandle = GCHandle.FromIntPtr(functionContext).Target as HCWebsocketHandle;
			if (websocket.Ptr != hcwebsocketHandle.InteropHandle.Ptr)
			{
				hcwebsocketHandle.InteropHandle = websocket;
			}
			byte[] array = null;
			if (payloadBytes != IntPtr.Zero && countOfBlobs != 0U)
			{
				array = new byte[countOfBlobs];
				Marshal.Copy(payloadBytes, array, 0, array.Length);
			}
			HCWebSocketBinaryMessageFunction binaryMessageCallback = hcwebsocketHandle.binaryMessageCallback;
			if (binaryMessageCallback == null)
			{
				return;
			}
			binaryMessageCallback(hcwebsocketHandle, array);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002408 File Offset: 0x00000608
		[MonoPInvokeCallback]
		private static void HCWebSocketCloseCallback(HCWebsocketHandle websocket, HCWebSocketCloseStatus closeStatus, IntPtr functionContext)
		{
			HCWebsocketHandle hcwebsocketHandle = GCHandle.FromIntPtr(functionContext).Target as HCWebsocketHandle;
			if (websocket.Ptr != hcwebsocketHandle.InteropHandle.Ptr)
			{
				hcwebsocketHandle.InteropHandle = websocket;
			}
			HCWebSocketCloseEventFunction closeCallback = hcwebsocketHandle.closeCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback(hcwebsocketHandle, closeStatus);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000245C File Offset: 0x0000065C
		[MonoPInvokeCallback]
		private unsafe static void HCWebSocketRoutedCallback(HCWebsocketHandle websocket, NativeBool receiving, IntPtr message, IntPtr payloadBytes, SizeT payloadSize, IntPtr conext)
		{
			HCWebSocketMessageFunction hcwebSocketMessageFunction;
			HCWebSocketBinaryMessageFunction hcwebSocketBinaryMessageFunction;
			HCWebSocketCloseEventFunction hcwebSocketCloseEventFunction;
			IntPtr value;
			XGRInterop.HCWebSocketGetEventFunctions(websocket, out hcwebSocketMessageFunction, out hcwebSocketBinaryMessageFunction, out hcwebSocketCloseEventFunction, out value);
			HCWebsocketHandle hcwebsocketHandle = GCHandle.FromIntPtr(value).Target as HCWebsocketHandle;
			if (websocket.Ptr != hcwebsocketHandle.InteropHandle.Ptr)
			{
				hcwebsocketHandle.InteropHandle = websocket;
			}
			string message2 = null;
			if (message != IntPtr.Zero)
			{
				int num = 0;
				while (Marshal.ReadByte(message, num) != 0)
				{
					num++;
				}
				message2 = Encoding.UTF8.GetString((byte*)((void*)message), num);
			}
			byte[] array = null;
			if (payloadBytes != IntPtr.Zero && !payloadSize.IsZero)
			{
				array = new byte[payloadSize.ToInt32()];
				Marshal.Copy(payloadBytes, array, 0, array.Length);
			}
			HCWebSocketRoutedHandler hcwebSocketRoutedHandler = SDK.routedCallback;
			if (hcwebSocketRoutedHandler == null)
			{
				return;
			}
			hcwebSocketRoutedHandler(hcwebsocketHandle, receiving.Value, message2, array);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002538 File Offset: 0x00000738
		public static int HCInitialize()
		{
			return XGRInterop.HCInitialize(IntPtr.Zero);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002544 File Offset: 0x00000744
		public static int HCCleanupAsync(HCCleanupHandler completionRoutine)
		{
			return XGRInterop.HCCleanupAsync(AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
			{
				HCCleanupHandler completionRoutine2 = completionRoutine;
				if (completionRoutine2 == null)
				{
					return;
				}
				completionRoutine2();
			}));
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002580 File Offset: 0x00000780
		public static int HCWebSocketCreate(out HCWebsocketHandle websocket, HCWebSocketMessageFunction messageFunc, HCWebSocketBinaryMessageFunction binaryMessageFunc, HCWebSocketCloseEventFunction closeFunc)
		{
			HCWebsocketHandle hcwebsocketHandle = new HCWebsocketHandle(default(HCWebsocketHandle))
			{
				messageFunc = new HCWebSocketMessageFunction(SDK.HCWebSocketMessageCallback),
				binaryMessageFunc = new HCWebSocketBinaryMessageFunction(SDK.HCWebSocketBinaryMessageCallback),
				closeFunc = new HCWebSocketCloseEventFunction(SDK.HCWebSocketCloseCallback),
				messageCallback = messageFunc,
				binaryMessageCallback = binaryMessageFunc,
				closeCallback = closeFunc
			};
			GCHandle gchandle = GCHandle.Alloc(hcwebsocketHandle);
			hcwebsocketHandle.cbHandle = gchandle;
			HCWebsocketHandle hcwebsocketHandle2;
			int num = XGRInterop.HCWebSocketCreate(out hcwebsocketHandle2, hcwebsocketHandle.messageFunc, hcwebsocketHandle.binaryMessageFunc, hcwebsocketHandle.closeFunc, GCHandle.ToIntPtr(gchandle));
			if (num == 0 && hcwebsocketHandle2.Ptr == IntPtr.Zero)
			{
				gchandle.Free();
				websocket = null;
				return num;
			}
			return HCWebsocketHandle.WrapAndReturnHResult(num, hcwebsocketHandle2, out websocket, gchandle);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002640 File Offset: 0x00000840
		public static int HCWebSocketSetProxyUri(HCWebsocketHandle websocket, byte[] proxyUri)
		{
			return XGRInterop.HCWebSocketSetProxyUri(websocket.InteropHandle, proxyUri);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002650 File Offset: 0x00000850
		public static int HCWebSocketSetHeader(HCWebsocketHandle websocket, string headerName, string headerValue)
		{
			byte[] headerName2 = Converters.StringToNullTerminatedUTF8ByteArray(headerName);
			byte[] headerValue2 = Converters.StringToNullTerminatedUTF8ByteArray(headerValue);
			return XGRInterop.HCWebSocketSetHeader(websocket.InteropHandle, headerName2, headerValue2);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002678 File Offset: 0x00000878
		public static int HCWebSocketConnectAsync(string uri, string subProtocol, HCWebsocketHandle websocket, HCSocketCompletionResultFunction completionRoutine)
		{
			XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
			{
				WebSocketCompletionResult webSocketCompletionResult = default(WebSocketCompletionResult);
				int num = XGRInterop.HCGetWebSocketConnectResult(block, ref webSocketCompletionResult);
				if (num == 0)
				{
					completionRoutine(websocket, webSocketCompletionResult.errorCode, webSocketCompletionResult.platformErrorCode);
					return;
				}
				completionRoutine(null, num, 0U);
			});
			byte[] uri2 = Converters.StringToNullTerminatedUTF8ByteArray(uri);
			byte[] subProtocol2 = Converters.StringToNullTerminatedUTF8ByteArray(subProtocol);
			return XGRInterop.HCWebSocketConnectAsync(uri2, subProtocol2, websocket.InteropHandle, block2);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000026D4 File Offset: 0x000008D4
		public static int HCWebSocketSendMessageAsync(HCWebsocketHandle websocket, string message, HCSocketCompletionResultFunction completionRoutine)
		{
			XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
			{
				WebSocketCompletionResult webSocketCompletionResult = default(WebSocketCompletionResult);
				int num = XGRInterop.HCGetWebSocketSendMessageResult(block, ref webSocketCompletionResult);
				if (num == 0)
				{
					completionRoutine(websocket, webSocketCompletionResult.errorCode, webSocketCompletionResult.platformErrorCode);
					return;
				}
				completionRoutine(null, num, 0U);
			});
			byte[] message2 = Converters.StringToNullTerminatedUTF8ByteArray(message);
			return XGRInterop.HCWebSocketSendMessageAsync(websocket.InteropHandle, message2, block2);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000272C File Offset: 0x0000092C
		public static int HCWebSocketSendBinaryMessageAsync(HCWebsocketHandle websocket, byte[] data, uint payloadSize, HCSocketCompletionResultFunction completionRoutine)
		{
			XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
			{
				WebSocketCompletionResult webSocketCompletionResult = default(WebSocketCompletionResult);
				int num = XGRInterop.HCGetWebSocketSendMessageResult(block, ref webSocketCompletionResult);
				if (num == 0)
				{
					completionRoutine(websocket, webSocketCompletionResult.errorCode, webSocketCompletionResult.platformErrorCode);
					return;
				}
				completionRoutine(null, num, 0U);
			});
			return XGRInterop.HCWebSocketSendBinaryMessageAsync(websocket.InteropHandle, data, payloadSize, block2);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000277C File Offset: 0x0000097C
		public static int HCWebSocketDisconnect(HCWebsocketHandle websocket)
		{
			return XGRInterop.HCWebSocketDisconnect(websocket.InteropHandle);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002789 File Offset: 0x00000989
		public static int HCWebSocketCloseHandle(HCWebsocketHandle websocket)
		{
			int num = XGRInterop.HCWebSocketCloseHandle(websocket.InteropHandle);
			if (num == 0)
			{
				websocket.cbHandle.Free();
				websocket.ClearInteropHandle();
			}
			return num;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000027AA File Offset: 0x000009AA
		[Obsolete("This method is deprecated and will be removed. Use the HCWebSocketRouted event instead.", false)]
		public static int HCAddWebSocketRoutedHandler(HCWebSocketRoutedHandler handler)
		{
			if (SDK.routedCallback == null)
			{
				SDK.hcRoutedHandlerId = XGRInterop.HCAddWebSocketRoutedHandler(new HCWebSocketRoutedHandler(SDK.HCWebSocketRoutedCallback), IntPtr.Zero);
			}
			SDK.routedCallback = (HCWebSocketRoutedHandler)Delegate.Combine(SDK.routedCallback, handler);
			return SDK.hcRoutedHandlerId;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000027E8 File Offset: 0x000009E8
		[Obsolete("This method is deprecated and will be removed. Use the HCWebSocketRouted event instead.", false)]
		public static void HCRemoveWebSocketRoutedHandler(int handlerId)
		{
			XGRInterop.HCRemoveWebSocketRoutedHandler(handlerId);
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000048 RID: 72 RVA: 0x000027F0 File Offset: 0x000009F0
		// (remove) Token: 0x06000049 RID: 73 RVA: 0x00002829 File Offset: 0x00000A29
		public static event HCWebSocketRoutedHandler HCWebSocketRouted
		{
			add
			{
				if (SDK.routedCallback == null)
				{
					SDK.hcRoutedHandlerId = XGRInterop.HCAddWebSocketRoutedHandler(new HCWebSocketRoutedHandler(SDK.HCWebSocketRoutedCallback), IntPtr.Zero);
				}
				SDK.routedCallback = (HCWebSocketRoutedHandler)Delegate.Combine(SDK.routedCallback, value);
			}
			remove
			{
				SDK.routedCallback = (HCWebSocketRoutedHandler)Delegate.Remove(SDK.routedCallback, value);
				if (SDK.routedCallback == null)
				{
					XGRInterop.HCRemoveWebSocketRoutedHandler(SDK.hcRoutedHandlerId);
					SDK.hcRoutedHandlerId = 0;
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002858 File Offset: 0x00000A58
		public static int XClosedCaptionGetProperties(out XClosedCaptionProperties properties)
		{
			properties = null;
			XClosedCaptionProperties interop = default(XClosedCaptionProperties);
			int num = NativeMethods.XClosedCaptionGetProperties(out interop);
			if (HR.SUCCEEDED(num))
			{
				properties = new XClosedCaptionProperties(interop);
			}
			return num;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002887 File Offset: 0x00000A87
		public static int XClosedCaptionSetEnabled(bool enabled)
		{
			return NativeMethods.XClosedCaptionSetEnabled(enabled);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000288F File Offset: 0x00000A8F
		public static int XHighContrastGetMode(out XHighContrastMode mode)
		{
			return NativeMethods.XHighContrastGetMode(out mode);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002897 File Offset: 0x00000A97
		public static int XSpeechToTextSetPositionHint(XSpeechToTextPositionHint position)
		{
			return NativeMethods.XSpeechToTextSetPositionHint(position);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000289F File Offset: 0x00000A9F
		public static int XSpeechToTextSendString(string speakerName, string content, XSpeechToTextType type)
		{
			return NativeMethods.XSpeechToTextSendString(speakerName, content, type);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000028A9 File Offset: 0x00000AA9
		public static int XSpeechToTextBeginHypothesisString(string speakerName, string content, XSpeechToTextType type, out uint hypothesisId)
		{
			return NativeMethods.XSpeechToTextBeginHypothesisString(speakerName, content, type, out hypothesisId);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000028B4 File Offset: 0x00000AB4
		public static int XSpeechToTextUpdateHypothesisString(uint hypothesisId, string content)
		{
			return NativeMethods.XSpeechToTextUpdateHypothesisString(hypothesisId, content);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000028BD File Offset: 0x00000ABD
		public static int XSpeechToTextFinalizeHypothesisString(uint hypothesisId, string content)
		{
			return NativeMethods.XSpeechToTextFinalizeHypothesisString(hypothesisId, content);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000028C6 File Offset: 0x00000AC6
		public static int XSpeechToTextCancelHypothesisString(uint hypothesisId)
		{
			return NativeMethods.XSpeechToTextCancelHypothesisString(hypothesisId);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000028D0 File Offset: 0x00000AD0
		public static int XAppBroadcastGetStatus(XUserHandle requestingUser, out XAppBroadcastStatus appBroadcastStatus)
		{
			appBroadcastStatus = null;
			IntPtr requestingUser2 = (requestingUser != null) ? requestingUser.Handle : IntPtr.Zero;
			XAppBroadcastStatus interop = default(XAppBroadcastStatus);
			int result = NativeMethods.XAppBroadcastGetStatus(requestingUser2, out interop);
			appBroadcastStatus = new XAppBroadcastStatus(interop);
			return result;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000290D File Offset: 0x00000B0D
		public static bool XAppBroadcastIsAppBroadcasting()
		{
			return NativeMethods.XAppBroadcastIsAppBroadcasting();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002914 File Offset: 0x00000B14
		public static int XAppBroadcastShowUI(XUserHandle requestingUser)
		{
			return NativeMethods.XAppBroadcastShowUI((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002934 File Offset: 0x00000B34
		public static int XAppBroadcastRegisterIsAppBroadcastingChanged(XTaskQueueHandle queue, IntPtr context, XAppBroadcastMonitorCallback appBroadcastMonitorCallback, out XIsAppBroadcastingChangedRegistrationToken token)
		{
			XAppBroadcastMonitorCallback callback = delegate(IntPtr context)
			{
				appBroadcastMonitorCallback(context);
			};
			token = new XIsAppBroadcastingChangedRegistrationToken(callback, context2);
			ulong token2;
			int num = NativeMethods.XAppBroadcastRegisterIsAppBroadcastingChanged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.interop.Token = token2;
				return num;
			}
			token.interop.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000029BC File Offset: 0x00000BBC
		public static int XAppBroadcastRegisterIsAppBroadcastingChanged(XTaskQueueHandle queue, XAppBroadcastMonitorCallback appBroadcastMonitorCallback, out XIsAppBroadcastingChangedRegistrationToken token)
		{
			return SDK.XAppBroadcastRegisterIsAppBroadcastingChanged(queue, IntPtr.Zero, appBroadcastMonitorCallback, out token);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000029CB File Offset: 0x00000BCB
		public static int XAppCaptureCloseLocalStream(XAppCaptureLocalStreamHandle handle)
		{
			handle.Close();
			return handle.CloseResult;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000029D9 File Offset: 0x00000BD9
		[Obsolete("Please use XAppCaptureCloseScreenshotStream(XAppCaptureScreenshotStreamHandle) instead.", false)]
		public static int XAppCaptureCloseScreenshotStream(IntPtr handle)
		{
			return NativeMethods.XAppCaptureCloseScreenshotStream(handle);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000029E1 File Offset: 0x00000BE1
		public static int XAppCaptureCloseScreenshotStream(XAppCaptureScreenshotStreamHandle handle)
		{
			handle.Close();
			return handle.CloseResult;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000029EF File Offset: 0x00000BEF
		public static int XAppCaptureEnableRecord()
		{
			return NativeMethods.XAppCaptureEnableRecord();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000029F6 File Offset: 0x00000BF6
		public static int XAppCaptureDisableRecord()
		{
			return NativeMethods.XAppCaptureDisableRecord();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000029FD File Offset: 0x00000BFD
		public static bool XAppBroadcastUnregisterIsAppBroadcastingChanged(XIsAppBroadcastingChangedRegistrationToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002A06 File Offset: 0x00000C06
		public static int XAppCaptureMetadataAddStringEvent(string name, string value, XAppCaptureMetadataPriority priority)
		{
			return NativeMethods.XAppCaptureMetadataAddStringEvent(name, value, priority);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002A10 File Offset: 0x00000C10
		public static int XAppCaptureMetadataAddInt32Event(string name, int value, XAppCaptureMetadataPriority priority)
		{
			return NativeMethods.XAppCaptureMetadataAddInt32Event(name, value, priority);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002A1A File Offset: 0x00000C1A
		public static int XAppCaptureMetadataAddDoubleEvent(string name, double value, XAppCaptureMetadataPriority priority)
		{
			return NativeMethods.XAppCaptureMetadataAddDoubleEvent(name, value, priority);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002A24 File Offset: 0x00000C24
		public static int XAppCaptureMetadataStartStringState(string name, string value, XAppCaptureMetadataPriority priority)
		{
			return NativeMethods.XAppCaptureMetadataStartStringState(name, value, priority);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002A2E File Offset: 0x00000C2E
		public static int XAppCaptureMetadataStartInt32State(string name, int value, XAppCaptureMetadataPriority priority)
		{
			return NativeMethods.XAppCaptureMetadataStartInt32State(name, value, priority);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002A38 File Offset: 0x00000C38
		public static int XAppCaptureMetadataStartDoubleState(string name, double value, XAppCaptureMetadataPriority priority)
		{
			return NativeMethods.XAppCaptureMetadataStartDoubleState(name, value, priority);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002A42 File Offset: 0x00000C42
		public static int XAppCaptureMetadataStopState(string name)
		{
			return NativeMethods.XAppCaptureMetadataStopState(name);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002A4A File Offset: 0x00000C4A
		public static int XAppCaptureMetadataStopAllStates()
		{
			return NativeMethods.XAppCaptureMetadataStopAllStates();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002A51 File Offset: 0x00000C51
		public static int XAppCaptureMetadataRemainingStorageBytesAvailable(out ulong value)
		{
			return NativeMethods.XAppCaptureMetadataRemainingStorageBytesAvailable(out value);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002A59 File Offset: 0x00000C59
		[Obsolete("Use XAppCaptureOpenScreenshotStream(string localId, XAppCaptureScreenshotFormatFlag, out XAppCaptureScreenshotStreamHandle, out UInt64)", false)]
		public static int XAppCaptureOpenScreenshotStream(XAppScreenshotLocalId id, XAppCaptureScreenshotFormatFlag screenshotFormat, out IntPtr handle, out ulong totalBytes)
		{
			return NativeMethods.XAppCaptureOpenScreenshotStream(Encoding.UTF8.GetString(id.Value), screenshotFormat, out handle, out totalBytes);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002A74 File Offset: 0x00000C74
		public static int XAppCaptureOpenScreenshotStream(string localId, XAppCaptureScreenshotFormatFlag screenshotFormat, out XAppCaptureScreenshotStreamHandle handle, out ulong totalBytes)
		{
			IntPtr intPtr;
			int num = NativeMethods.XAppCaptureOpenScreenshotStream(localId, screenshotFormat, out intPtr, out totalBytes);
			if (HR.SUCCEEDED(num) && intPtr == IntPtr.Zero)
			{
				handle = null;
				return num;
			}
			return XAppCaptureScreenshotStreamHandle.WrapAndReturnHResult(num, intPtr, out handle);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002AB0 File Offset: 0x00000CB0
		[Obsolete("Use XAppCaptureReadScreenshotStream(XAppCaptureScreenshotStreamHandle, UInt64, UInt32, byte[], out UInt32)", false)]
		public static int XAppCaptureReadScreenshotStream(IntPtr handle, ulong startPosition, uint totalBytes, byte[] data, out int bytesWritten)
		{
			uint num;
			int result = NativeMethods.XAppCaptureReadScreenshotStream(handle, startPosition, totalBytes, data, out num);
			bytesWritten = (int)num;
			return result;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002ACC File Offset: 0x00000CCC
		public static int XAppCaptureReadScreenshotStream(XAppCaptureScreenshotStreamHandle handle, ulong startPosition, uint bytesToRead, byte[] buffer, out uint bytesWritten)
		{
			return NativeMethods.XAppCaptureReadScreenshotStream(handle.Handle, startPosition, bytesToRead, buffer, out bytesWritten);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002AE0 File Offset: 0x00000CE0
		public static int XAppCaptureRecordDiagnosticClip(long startTime, uint durationInMs, string filenamePrefix, out XAppCaptureRecordClipResult result)
		{
			result = null;
			XAppCaptureRecordClipResult interop = default(XAppCaptureRecordClipResult);
			int num = NativeMethods.XAppCaptureRecordDiagnosticClip(startTime, durationInMs, filenamePrefix, out interop);
			if (HR.SUCCEEDED(num))
			{
				result = new XAppCaptureRecordClipResult(interop);
			}
			return num;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002B14 File Offset: 0x00000D14
		public static int XAppCaptureTakeDiagnosticScreenshot(bool gamescreenOnly, XAppCaptureScreenshotFormatFlag captureFlags, string filenamePrefix, out XAppCaptureDiagnosticScreenshotResult result)
		{
			result = null;
			XAppCaptureDiagnosticScreenshotResult interop = default(XAppCaptureDiagnosticScreenshotResult);
			int num = NativeMethods.XAppCaptureTakeDiagnosticScreenshot(gamescreenOnly, captureFlags, filenamePrefix, out interop);
			if (HR.SUCCEEDED(num))
			{
				result = new XAppCaptureDiagnosticScreenshotResult(interop);
			}
			return num;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002B48 File Offset: 0x00000D48
		public static int XAppCaptureTakeScreenshot(XUserHandle requestingUser, out XAppCaptureTakeScreenshotResult result)
		{
			result = null;
			XAppCaptureTakeScreenshotResult interop = default(XAppCaptureTakeScreenshotResult);
			int num = NativeMethods.XAppCaptureTakeScreenshot((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, out interop);
			if (HR.SUCCEEDED(num))
			{
				result = new XAppCaptureTakeScreenshotResult(interop);
			}
			return num;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002B90 File Offset: 0x00000D90
		public static int XAppCaptureRegisterMetadataPurged(XTaskQueueHandle queue, IntPtr context, XAppCaptureMetadataPurgedCallback callback, out XMetadataPurgedToken token)
		{
			XAppCaptureMetadataPurgedCallback callback2 = delegate(IntPtr context)
			{
				callback(context);
			};
			token = new XMetadataPurgedToken(callback2, context2);
			ulong token2;
			int num = NativeMethods.XAppCaptureRegisterMetadataPurged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.interop.Dispose();
			token = null;
			return num;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002C13 File Offset: 0x00000E13
		public static int XAppCaptureRegisterMetadataPurged(XTaskQueueHandle queue, XAppCaptureMetadataPurgedCallback callback, out XMetadataPurgedToken token)
		{
			return SDK.XAppCaptureRegisterMetadataPurged(queue, IntPtr.Zero, callback, out token);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002C22 File Offset: 0x00000E22
		public static bool XAppCaptureUnRegisterMetadataPurged(XMetadataPurgedToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002C2B File Offset: 0x00000E2B
		public static int XAppCaptureReadLocalStream(XAppCaptureLocalStreamHandle handle, long startPosition, uint bytesToRead, ref byte[] buffer, out uint bytesWritten)
		{
			return NativeMethods.XAppCaptureReadLocalStream(handle.Handle, startPosition, bytesToRead, buffer, out bytesWritten);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002C40 File Offset: 0x00000E40
		public static int XAppCaptureRecordTimespan(SYSTEMTIME startTimestamp, ulong durationInMilliseconds, out XAppCaptureLocalResult result)
		{
			result = null;
			int num = 0;
			GCHandle gchandle = GCHandle.Alloc(startTimestamp.interop, GCHandleType.Pinned);
			try
			{
				XAppCaptureLocalResult interop;
				num = NativeMethods.XAppCaptureRecordTimespan(gchandle.AddrOfPinnedObject(), durationInMilliseconds, out interop);
				if (HR.SUCCEEDED(num))
				{
					result = new XAppCaptureLocalResult(interop);
				}
			}
			catch (Exception ex)
			{
				num = ex.HResult;
			}
			finally
			{
				gchandle.Free();
			}
			return num;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002CB4 File Offset: 0x00000EB4
		public static int XAppCaptureRecordTimespan(ulong durationInMilliseconds, out XAppCaptureLocalResult result)
		{
			result = null;
			XAppCaptureLocalResult interop;
			int num = NativeMethods.XAppCaptureRecordTimespan(IntPtr.Zero, durationInMilliseconds, out interop);
			if (HR.SUCCEEDED(num))
			{
				result = new XAppCaptureLocalResult(interop);
			}
			return num;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002CE4 File Offset: 0x00000EE4
		public static int XAppCaptureGetVideoCaptureSettings(out XAppCaptureVideoCaptureSettings userCaptureSettings)
		{
			XAppCaptureVideoCaptureSettings interop = default(XAppCaptureVideoCaptureSettings);
			userCaptureSettings = null;
			int num = NativeMethods.XAppCaptureGetVideoCaptureSettings(out interop);
			if (HR.SUCCEEDED(num))
			{
				userCaptureSettings = new XAppCaptureVideoCaptureSettings(interop);
			}
			return num;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002D14 File Offset: 0x00000F14
		[MonoPInvokeCallback(typeof(XAsyncWorkInterop))]
		private static int OnAsyncWorkCallback(IntPtr asyncBlock)
		{
			CallbackWrapper<XAsyncWorkInterop> callbackWrapper;
			if (!SDK.asyncWorkCallbackDictionary.TryGetValue(asyncBlock, out callbackWrapper))
			{
				return -2147024809;
			}
			return (GCHandle.FromIntPtr(callbackWrapper.CallbackContext).Target as CallbackWrapper<XAsyncWorkInterop>).Callback(asyncBlock);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002D59 File Offset: 0x00000F59
		public static int XAsyncGetStatus(XAsyncBlock asyncBlock, bool wait)
		{
			return NativeMethods.XAsyncGetStatus(asyncBlock.InteropPtr, wait);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002D67 File Offset: 0x00000F67
		public static int XAsyncGetResultSize(XAsyncBlock asyncBlock, out ulong bufferSize)
		{
			return NativeMethods.XAsyncGetResultSize(asyncBlock.InteropPtr, out bufferSize);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002D78 File Offset: 0x00000F78
		public static void XAsyncCancel(XAsyncBlock asyncBlock)
		{
			if (asyncBlock.IsCompleted)
			{
				return;
			}
			CallbackWrapper<XAsyncWorkInterop> callbackWrapper;
			if (SDK.asyncWorkCallbackDictionary.TryGetValue(asyncBlock.InteropPtr, out callbackWrapper))
			{
				callbackWrapper.Dispose();
				callbackWrapper = null;
				SDK.asyncWorkCallbackDictionary.Remove(asyncBlock.InteropPtr);
			}
			NativeMethods.XAsyncCancel(asyncBlock.InteropPtr);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002DC8 File Offset: 0x00000FC8
		public static int XAsyncRun(XAsyncBlock asyncBlock, XAsyncWork work)
		{
			CallbackWrapper<XAsyncWorkInterop> callbackWrapper;
			if (SDK.asyncWorkCallbackDictionary.TryGetValue(asyncBlock.InteropPtr, out callbackWrapper))
			{
				callbackWrapper.Dispose();
				callbackWrapper = null;
				SDK.asyncWorkCallbackDictionary.Remove(asyncBlock.InteropPtr);
			}
			CallbackWrapper<XAsyncWorkInterop> callbackWrapper2 = new CallbackWrapper<XAsyncWorkInterop>((IntPtr _asyncBlockInterop) => work(asyncBlock), asyncBlock.Context, new XAsyncWorkInterop(SDK.OnAsyncWorkCallback));
			SDK.asyncWorkCallbackDictionary.Add(asyncBlock.InteropPtr, callbackWrapper2);
			return NativeMethods.XAsyncRun(asyncBlock.InteropPtr, callbackWrapper2.StaticCallback);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002E75 File Offset: 0x00001075
		private static void DispatchGXDKTaskQueue()
		{
			while (!SDK.m_StopExecution)
			{
				SDK.XTaskQueueDispatch(SDK.defaultQueue, XTaskQueuePort.Work, 32U);
			}
			SDK.DispatchGXDKTaskDone();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002E95 File Offset: 0x00001095
		private static void DispatchGXDKTaskDone()
		{
			SDK.isInitialized = false;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002EA0 File Offset: 0x000010A0
		public static int CreateDefaultTaskQueue()
		{
			if (SDK.isInitialized)
			{
				return 0;
			}
			int num = SDK.XTaskQueueCreate(XTaskQueueDispatchMode.Manual, XTaskQueueDispatchMode.Manual, out SDK.defaultQueue);
			if (HR.SUCCEEDED(num))
			{
				SDK.m_StopExecution = false;
				SDK.m_DispatchJob = new Thread(new ThreadStart(SDK.DispatchGXDKTaskQueue))
				{
					Name = "GXDK Task Queue Dispatch"
				};
				SDK.m_DispatchJob.Start();
				SDK.isInitialized = true;
			}
			return num;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002F07 File Offset: 0x00001107
		public static void CloseDefaultXTaskQueue()
		{
			if (SDK.isInitialized)
			{
				if (!SDK.m_StopExecution)
				{
					SDK.m_StopExecution = true;
				}
				SDK.m_DispatchJob.Join();
				SDK.defaultQueue.Close();
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002F37 File Offset: 0x00001137
		public static bool XTaskQueueDispatch(uint timeoutInMs)
		{
			return SDK.XTaskQueueDispatch(SDK.defaultQueue, XTaskQueuePort.Completion, timeoutInMs);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002F45 File Offset: 0x00001145
		public static int XUserRegisterForChangeEvent(XUserChangeEventCallback callback, out XUserChangeRegistrationToken token)
		{
			return SDK.XUserRegisterForChangeEvent(SDK.defaultQueue, IntPtr.Zero, callback, out token);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002F58 File Offset: 0x00001158
		[Obsolete("Please use XGameSaveCloseUpdate(XGameSaveUpdateHandle context) instead. (UnityUpgradable) -> XGameSaveCloseUpdate(*)", true)]
		public static void XGameSaveCloseUpdateHandle(XGameSaveUpdateHandle updateHandle)
		{
			SDK.XGameSaveCloseUpdate(updateHandle);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002F60 File Offset: 0x00001160
		public static int XGameSaveDeleteContainerAsync(XGameSaveProviderHandle gameSaveProviderHandle, string containerName, XGameSaveDeleteContainerCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hr = SDK.XGameSaveDeleteContainerResult(_async);
				onCompleted(hr);
			}, IntPtr.Zero);
			int num = SDK.XGameSaveDeleteContainerAsync(gameSaveProviderHandle, containerName, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002FBC File Offset: 0x000011BC
		public static int XGameSaveGetRemainingQuotaAsync(XGameSaveProviderHandle provider, XGameSaveGetRemainingQuotaCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				long remainingQuota;
				int hr = SDK.XGameSaveGetRemainingQuotaResult(_async, out remainingQuota);
				onCompleted(hr, remainingQuota);
			}, IntPtr.Zero);
			int num = SDK.XGameSaveGetRemainingQuotaAsync(provider, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, 0L);
			}
			return num;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003018 File Offset: 0x00001218
		public static int XGameSaveInitializeProviderAsync(XUserHandle requestingUser, string configurationId, bool syncOnDemand, XGameSaveInitializeProviderCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XGameSaveProviderHandle gameSaveProviderHandle;
				int hresult = SDK.XGameSaveInitializeProviderResult(_async, out gameSaveProviderHandle);
				onCompleted(hresult, gameSaveProviderHandle);
			}, IntPtr.Zero);
			int num = SDK.XGameSaveInitializeProviderAsync(requestingUser, configurationId, syncOnDemand, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003074 File Offset: 0x00001274
		public static int XGameSaveReadBlobDataAsync(XGameSaveContainerHandle container, string[] blobNames, XGameSaveReadBlobDataCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong blobsSize;
				int num2 = SDK.XAsyncGetResultSize(_async, out blobsSize);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				XGameSaveBlob[] blobs;
				num2 = SDK.XGameSaveReadBlobDataResult(_async, blobsSize, out blobs);
				onCompleted(num2, blobs);
			}, IntPtr.Zero);
			int num = SDK.XGameSaveReadBlobDataAsync(container, blobNames, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000030D0 File Offset: 0x000012D0
		public static int XGameSaveSubmitUpdateAsync(XGameSaveUpdateHandle updateContext, XGameSaveSubmitUpdateCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XGameSaveSubmitUpdateResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XGameSaveSubmitUpdateAsync(updateContext, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000312C File Offset: 0x0000132C
		public static int XGameSaveFilesGetFolderWithUiAsync(XUserHandle requestingUser, string configurationId, XGameSaveFilesGetFolderWithUiCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong folderSize = 261UL;
				string folderResult;
				int hresult = SDK.XGameSaveFilesGetFolderWithUiResult(_async, folderSize, out folderResult);
				onCompleted(hresult, folderResult);
			}, IntPtr.Zero);
			int num = SDK.XGameSaveFilesGetFolderWithUiAsync(requestingUser, configurationId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003188 File Offset: 0x00001388
		public static int XGameUiShowAchievementsAsync(XUserHandle requestingUser, uint titleId, XGameUiShowAchievementsCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XGameUiShowAchievementsResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowAchievementsAsync(xasyncBlock, requestingUser, titleId);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000031E4 File Offset: 0x000013E4
		public static int XGameUiShowErrorDialogAsync(int errorCode, string context, XGameUiShowErrorDialogCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XGameUiShowErrorDialogResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowErrorDialogAsync(xasyncBlock, errorCode, context);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003240 File Offset: 0x00001440
		public static int XGameUiShowMessageDialogAsync(string titleText, string contextText, string firstButtonText, string secondButtonText, string thirdButtonText, XGameUiMessageDialogButton defaultButton, XGameUiMessageDialogButton cancelButton, XGameUiShowMessageDialogCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XGameUiMessageDialogButton resultButton;
				int hresult = SDK.XGameUiShowMessageDialogResult(_async, out resultButton);
				onCompleted(hresult, resultButton);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowMessageDialogAsync(xasyncBlock, titleText, contextText, firstButtonText, secondButtonText, thirdButtonText, defaultButton, cancelButton);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, XGameUiMessageDialogButton.First);
			}
			return num;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000032A4 File Offset: 0x000014A4
		public static int XGameUiShowMultiplayerActivityGameInviteAsync(XUserHandle requestingUser, XGameUiShowMultiplayerActivityGameInviteCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XGameUiShowMultiplayerActivityGameInviteResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowMultiplayerActivityGameInviteAsync(xasyncBlock, requestingUser);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003300 File Offset: 0x00001500
		public static int XGameUiShowPlayerPickerAsync(XUserHandle requestingUser, string promptText, ulong[] selectFromPlayers, ulong[] preSelectedPlayers, uint minSelectionCount, uint maxSelectionCount, XGameUiShowPlayerPickerCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				uint num3;
				int num2 = SDK.XGameUiShowPlayerPickerResultCount(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				ulong[] resultPlayers = new ulong[num3];
				uint num4;
				num2 = SDK.XGameUiShowPlayerPickerResult(_async, resultPlayers, out num4);
				onCompleted(num2, resultPlayers);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowPlayerPickerAsync(xasyncBlock, requestingUser, promptText, selectFromPlayers, preSelectedPlayers, minSelectionCount, maxSelectionCount);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003364 File Offset: 0x00001564
		public static int XGameUiShowPlayerProfileCardAsync(XUserHandle requestingUser, ulong targetPlayer, XGameUiShowPlayerProfileCardCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XGameUiShowPlayerProfileCardResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowPlayerProfileCardAsync(xasyncBlock, requestingUser, targetPlayer);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000033C0 File Offset: 0x000015C0
		public static int XGameUiShowSendGameInviteAsync(XUserHandle requestingUser, string sessionConfigurationId, string sessionTemplateName, string sessionId, string invitationText, string customActivationContext, XGameUiShowSendGameInviteCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XGameUiShowSendGameInviteResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowSendGameInviteAsync(xasyncBlock, requestingUser, sessionConfigurationId, sessionTemplateName, sessionId, invitationText, customActivationContext);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003424 File Offset: 0x00001624
		public static int XGameUiShowTextEntryAsync(string titleText, string descriptionText, string defaultText, XGameUiTextEntryInputScope inputScope, uint maxTextLength, XGameUiShowTextEntryCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				uint resultTextBufferSize;
				int num2 = SDK.XGameUiShowTextEntryResultSize(_async, out resultTextBufferSize);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				string resultText;
				num2 = SDK.XGameUiShowTextEntryResult(_async, resultTextBufferSize, out resultText);
				onCompleted(num2, resultText);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowTextEntryAsync(xasyncBlock, titleText, descriptionText, defaultText, inputScope, maxTextLength);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003484 File Offset: 0x00001684
		public static int XGameUiShowWebAuthenticationAsync(XUserHandle requestingUser, string requestUri, string completeUri, XGameUiShowWebAuthenticationAsyncCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong num3;
				int num2 = SDK.XGameUiShowWebAuthenticationResultSize(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				byte[] buffer = new byte[num3];
				XGameUiWebAuthenticationResultData result;
				num2 = SDK.XGameUiShowWebAuthenticationResult(_async, buffer, out result);
				onCompleted(num2, result);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowWebAuthenticationAsync(xasyncBlock, requestingUser, requestUri, completeUri);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000034E0 File Offset: 0x000016E0
		public static int XGameUiShowWebAuthenticationWithOptionsAsync(XUserHandle requestingUser, string requestUri, string completeUri, XGameUiWebAuthenticationOptions options, Action<int, XGameUiWebAuthenticationResultData> onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong num3;
				int num2 = SDK.XGameUiShowWebAuthenticationResultSize(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				byte[] buffer = new byte[num3];
				XGameUiWebAuthenticationResultData arg;
				num2 = SDK.XGameUiShowWebAuthenticationResult(_async, buffer, out arg);
				onCompleted(num2, arg);
			}, IntPtr.Zero);
			int num = SDK.XGameUiShowWebAuthenticationWithOptionsAsync(xasyncBlock, requestingUser, requestUri, completeUri, options);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003540 File Offset: 0x00001740
		public static int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(XNetworkingQueryPreferredLocalUdpMultiplayerPortResultFunction onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ushort preferredLocalUdpMultiplayerPort;
				int errorCode = SDK.XNetworkingQueryPreferredLocalUdpMultiplayerPortAsyncResult(_async, out preferredLocalUdpMultiplayerPort);
				onCompleted(errorCode, preferredLocalUdpMultiplayerPort);
			}, IntPtr.Zero);
			int num = SDK.XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, 0);
			}
			return num;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000359C File Offset: 0x0000179C
		public static int XNetworkingQuerySecurityInformationForUrlAsync(string url, XNetworkingQuerySecurityInformationForUrlResultCallback onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong num3;
				int num2 = SDK.XNetworkingQuerySecurityInformationForUrlAsyncResultSize(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				byte[] securityInformationBuffer = new byte[num3];
				ulong num4;
				XNetworkingSecurityInformation result;
				num2 = SDK.XNetworkingQuerySecurityInformationForUrlAsyncResult(_async, securityInformationBuffer, out num4, out result);
				onCompleted(num2, result);
			}, IntPtr.Zero);
			int num = SDK.XNetworkingQuerySecurityInformationForUrlAsync(url, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000035F8 File Offset: 0x000017F8
		public static int XNetworkingQuerySecurityInformationForUrlUtf16Async(string url, XNetworkingQuerySecurityInformationForUrlResultCallback onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong num3;
				int num2 = SDK.XNetworkingQuerySecurityInformationForUrlUtf16AsyncResultSize(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				byte[] securityInformationBuffer = new byte[num3];
				ulong num4;
				XNetworkingSecurityInformation result;
				num2 = SDK.XNetworkingQuerySecurityInformationForUrlUtf16AsyncResult(_async, securityInformationBuffer, out num4, out result);
				onCompleted(num2, result);
			}, IntPtr.Zero);
			int num = SDK.XNetworkingQuerySecurityInformationForUrlUtf16Async(url, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003652 File Offset: 0x00001852
		public static int XNetworkingRegisterConnectivityHintChanged(XNetworkingConnectivityHintChangedCallback callback, out XNetworkingRegisterConnectivityHintChangedCallbackToken token)
		{
			return SDK.XNetworkingRegisterConnectivityHintChanged(SDK.defaultQueue, IntPtr.Zero, callback, out token);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003665 File Offset: 0x00001865
		public static int XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, out XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken token)
		{
			return SDK.XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged(SDK.defaultQueue, IntPtr.Zero, callback, out token);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003678 File Offset: 0x00001878
		public static bool XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken token)
		{
			return SDK.XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(token, true);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003681 File Offset: 0x00001881
		public static int XPackageCreateInstallationMonitor(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, out XPackageInstallationMonitorHandle installationMonitor)
		{
			return SDK.XPackageCreateInstallationMonitor(packageIdentifier, selectors, minimumUpdateIntervalMs, SDK.defaultQueue, out installationMonitor);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003691 File Offset: 0x00001891
		public static int XPackageCreateInstallationMonitor(string packageIdentifier, uint minimumUpdateIntervalMs, out XPackageInstallationMonitorHandle installationMonitor)
		{
			return SDK.XPackageCreateInstallationMonitor(packageIdentifier, new XPackageChunkSelector[0], minimumUpdateIntervalMs, out installationMonitor);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000036A4 File Offset: 0x000018A4
		public static int XPackageInstallChunksAsync(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, bool suppressUserConfirmation, XPackageInstallChunksCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XPackageInstallationMonitorHandle installationMonitor;
				int hresult = SDK.XPackageInstallChunksResult(_async, out installationMonitor);
				onCompleted(hresult, installationMonitor);
			}, IntPtr.Zero);
			int num = SDK.XPackageInstallChunksAsync(packageIdentifier, selectors, minimumUpdateIntervalMs, suppressUserConfirmation, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003702 File Offset: 0x00001902
		[Obsolete("XPackageMount(string, out XPackageMountHandle) has been removed. Please use XPackageMountWithUiAsync(string packageIdentifier, XPackageMountWithUiAsyncCompleted) instead.", true)]
		public static int XPackageMount(string packageIdentifier, out XPackageMountHandle mountHandle)
		{
			throw new NotSupportedException("XPackageMount(string, out XPackageMountHandle) has been removed. Please use XPackageMountWithUiAsync(string packageIdentifier, XPackageMountWithUiAsyncCompleted) instead.");
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003710 File Offset: 0x00001910
		public static int XPackageMountWithUiAsync(string packageIdentifier, XPackageMountWithUiAsyncCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XPackageMountHandle mountHandle;
				int hresult = SDK.XPackageMountWithUiResult(_async, out mountHandle);
				onCompleted(hresult, mountHandle);
			}, IntPtr.Zero);
			int num = SDK.XPackageMountWithUiAsync(packageIdentifier, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000376A File Offset: 0x0000196A
		public static int XPackageRegisterPackageInstalled(XPackageInstalledCallback callback, out XPackageRegisterPackageInstalledToken token)
		{
			return SDK.XPackageRegisterPackageInstalled(SDK.defaultQueue, IntPtr.Zero, callback, out token);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000377D File Offset: 0x0000197D
		public static int XPackageRegisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XPackageInstallationProgressCallback callback, out XPackageRegisterInstallationProgressChangedToken token)
		{
			return SDK.XPackageRegisterInstallationProgressChanged(installationMonitor, IntPtr.Zero, callback, out token);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000378C File Offset: 0x0000198C
		public static int XPersistentLocalStoragePromptUserForSpaceAsync(ulong requestedBytes, XPersistentLocalStoragePromptUserForSpaceAsyncCallback onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XPersistentLocalStoragePromptUserForSpaceResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XPersistentLocalStoragePromptUserForSpaceAsync(requestedBytes, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000037E8 File Offset: 0x000019E8
		public static int XStoreAcquireLicenseForDurablesAsync(XStoreContext context, string storeId, XStoreAcquireLicenseForDurablesCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreLicense license;
				int hresult = SDK.XStoreAcquireLicenseForDurablesResult(_async, out license);
				onCompleted(hresult, license);
			}, IntPtr.Zero);
			int num = SDK.XStoreAcquireLicenseForDurablesAsync(context, storeId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003844 File Offset: 0x00001A44
		public static int XStoreAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XStoreAcquireLicenseForPackageCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreLicense license;
				int hresult = SDK.XStoreAcquireLicenseForPackageResult(_async, out license);
				onCompleted(hresult, license);
			}, IntPtr.Zero);
			int num = SDK.XStoreAcquireLicenseForPackageAsync(context, packageIdentifier, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000038A0 File Offset: 0x00001AA0
		public static int XStoreCanAcquireLicenseForPackageAsync(XStoreContext storeContextHandle, string packageIdentifier, XStoreCanAcquireLicenseForPackageCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreCanAcquireLicenseResult result;
				int hresult = SDK.XStoreCanAcquireLicenseForPackageResult(_async, out result);
				onCompleted(hresult, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreCanAcquireLicenseForPackageAsync(storeContextHandle, packageIdentifier, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000038FC File Offset: 0x00001AFC
		public static int XStoreCanAcquireLicenseForStoreIdAsync(XStoreContext storeContextHandle, string storeProductId, XStoreCanAcquireLicenseForStoreIdCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreCanAcquireLicenseResult result;
				int hresult = SDK.XStoreCanAcquireLicenseForStoreIdResult(_async, out result);
				onCompleted(hresult, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreCanAcquireLicenseForStoreIdAsync(storeContextHandle, storeProductId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003958 File Offset: 0x00001B58
		public static int XStoreDownloadAndInstallPackagesAsync(XStoreContext storeContextHandle, string[] storeIds, XStoreDownloadAndInstallPackagesCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				uint count;
				int num2 = SDK.XStoreDownloadAndInstallPackagesResultCount(_async, out count);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				string[] packageIdentifiers;
				num2 = SDK.XStoreDownloadAndInstallPackagesResult(_async, count, out packageIdentifiers);
				onCompleted(num2, packageIdentifiers);
			}, IntPtr.Zero);
			int num = SDK.XStoreDownloadAndInstallPackagesAsync(storeContextHandle, storeIds, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000039B4 File Offset: 0x00001BB4
		public static int XStoreDownloadAndInstallPackageUpdatesAsync(XStoreContext storeContextHandle, string[] packageIdentifiers, XStoreDownloadAndInstallPackageUpdatesCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XStoreDownloadAndInstallPackageUpdatesResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XStoreDownloadAndInstallPackageUpdatesAsync(storeContextHandle, packageIdentifiers, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003A10 File Offset: 0x00001C10
		public static int XStoreDownloadPackageUpdatesAsync(XStoreContext storeContextHandle, string[] packageIdentifiers, XStoreDownloadPackageUpdatesCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XStoreDownloadPackageUpdatesResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XStoreDownloadPackageUpdatesAsync(storeContextHandle, packageIdentifiers, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003A6C File Offset: 0x00001C6C
		public static int XStoreGetUserCollectionsIdAsync(XStoreContext storeContextHandle, string serviceTicket, string publisherUserId, XStoreGetUserCollectionsIdCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong size;
				int num2 = SDK.XStoreGetUserCollectionsIdResultSize(_async, out size);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				string token;
				num2 = SDK.XStoreGetUserCollectionsIdResult(_async, size, out token);
				onCompleted(num2, token);
			}, IntPtr.Zero);
			int num = SDK.XStoreGetUserCollectionsIdAsync(storeContextHandle, serviceTicket, publisherUserId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003AC8 File Offset: 0x00001CC8
		public static int XStoreGetUserPurchaseIdAsync(XStoreContext storeContextHandle, string serviceTicket, string publisherUserId, XStoreGetUserPurchaseIdCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong size;
				int num2 = SDK.XStoreGetUserPurchaseIdResultSize(_async, out size);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				string token;
				num2 = SDK.XStoreGetUserPurchaseIdResult(_async, size, out token);
				onCompleted(num2, token);
			}, IntPtr.Zero);
			int num = SDK.XStoreGetUserPurchaseIdAsync(storeContextHandle, serviceTicket, publisherUserId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003B24 File Offset: 0x00001D24
		public static int XStoreProductsQueryNextPageAsync(XStoreProductQuery productQueryHandle, XStoreQueryComplete onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreProductQuery xstoreProductQuery;
				int num2 = SDK.XStoreProductsQueryNextPageResult(_async, out xstoreProductQuery);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				XStoreProduct[] pageItems;
				num2 = SDK.XStoreEnumerateProductsQuery(xstoreProductQuery, out pageItems);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				bool hasMorePages = SDK.XStoreProductsQueryHasMorePages(xstoreProductQuery);
				XStoreQueryResult result = new XStoreQueryResult(xstoreProductQuery, pageItems, hasMorePages);
				onCompleted(num2, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreProductsQueryNextPageAsync(productQueryHandle, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003B7E File Offset: 0x00001D7E
		public static int XStoreProductsQueryNextPageAsync(XStoreQueryResult currentPage, XStoreQueryComplete completionRoutine)
		{
			return SDK.XStoreProductsQueryNextPageAsync(currentPage.QueryHandle, completionRoutine);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003B8C File Offset: 0x00001D8C
		public static int XStoreQueryAssociatedProductsAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, Action<int, XStoreProductQuery> onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreProductQuery arg2;
				int arg = SDK.XStoreQueryAssociatedProductsResult(_async, out arg2);
				onCompleted(arg, arg2);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryAssociatedProductsAsync(storeContextHandle, productKinds, maxItemsToRetrievePerPage, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003BE8 File Offset: 0x00001DE8
		public static int XStoreQueryAssociatedProductsAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XStoreQueryComplete onCompleted)
		{
			return SDK.XStoreQueryAssociatedProductsAsync(storeContextHandle, productKinds, maxItemsToRetrievePerPage, delegate(int hr, XStoreProductQuery queryResult)
			{
				if (HR.FAILED(hr))
				{
					onCompleted(hr, null);
					return;
				}
				XStoreProduct[] pageItems;
				hr = SDK.XStoreEnumerateProductsQuery(queryResult, out pageItems);
				if (HR.FAILED(hr))
				{
					onCompleted(hr, null);
					return;
				}
				bool hasMorePages = SDK.XStoreProductsQueryHasMorePages(queryResult);
				XStoreQueryResult result = new XStoreQueryResult(queryResult, pageItems, hasMorePages);
				onCompleted(hr, result);
			});
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003C16 File Offset: 0x00001E16
		public static void XStoreCloseProductsQueryHandle(XStoreQueryResult result)
		{
			SDK.XStoreCloseProductsQueryHandle(result.QueryHandle);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003C24 File Offset: 0x00001E24
		public static int XStoreQueryAddOnLicensesAsync(XStoreContext storeContextHandle, XStoreQueryAddOnLicensesCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				uint num3;
				int num2 = SDK.XStoreQueryAddOnLicensesResultCount(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				XStoreAddonLicense[] array = new XStoreAddonLicense[num3];
				num2 = SDK.XStoreQueryAddOnLicensesResult(_async, array);
				onCompleted(num2, array);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryAddOnLicensesAsync(storeContextHandle, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003C80 File Offset: 0x00001E80
		public static int XStoreQueryConsumableBalanceRemainingAsync(XStoreContext storeContextHandle, string storeProductId, XStoreQueryConsumableBalanceRemainingCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreConsumableResult result;
				int hresult = SDK.XStoreQueryConsumableBalanceRemainingResult(_async, out result);
				onCompleted(hresult, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryConsumableBalanceRemainingAsync(storeContextHandle, storeProductId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003CDC File Offset: 0x00001EDC
		public static int XStoreQueryEntitledProductsAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XStoreQueryComplete onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreProductQuery xstoreProductQuery;
				int num2 = SDK.XStoreQueryEntitledProductsResult(_async, out xstoreProductQuery);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				XStoreProduct[] pageItems;
				num2 = SDK.XStoreEnumerateProductsQuery(xstoreProductQuery, out pageItems);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				bool hasMorePages = SDK.XStoreProductsQueryHasMorePages(xstoreProductQuery);
				XStoreQueryResult result = new XStoreQueryResult(xstoreProductQuery, pageItems, hasMorePages);
				onCompleted(num2, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryEntitledProductsAsync(storeContextHandle, productKinds, maxItemsToRetrievePerPage, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003D38 File Offset: 0x00001F38
		public static int XStoreQueryGameAndDlcPackageUpdatesAsync(XStoreContext storeContextHandle, XStoreQueryGameAndDlcPackageUpdatesCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				uint num3;
				int num2 = SDK.XStoreQueryGameAndDlcPackageUpdatesResultCount(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				XStorePackageUpdate[] packageUpdates = new XStorePackageUpdate[num3];
				num2 = SDK.XStoreQueryGameAndDlcPackageUpdatesResult(_async, packageUpdates);
				onCompleted(num2, packageUpdates);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryGameAndDlcPackageUpdatesAsync(storeContextHandle, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003D94 File Offset: 0x00001F94
		public static int XStoreQueryGameLicenseAsync(XStoreContext storeContextHandle, XStoreQueryGameLicenseCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreGameLicense license;
				int hresult = SDK.XStoreQueryGameLicenseResult(_async, out license);
				onCompleted(hresult, license);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryGameLicenseAsync(storeContextHandle, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003DF0 File Offset: 0x00001FF0
		public static int XStoreQueryLicenseTokenAsync(XStoreContext storeContextHandle, string[] productIds, string customDeveloperString, XStoreQueryLicenseTokenCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong size;
				int num2 = SDK.XStoreQueryLicenseTokenResultSize(_async, out size);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				string token;
				num2 = SDK.XStoreQueryLicenseTokenResult(_async, size, out token);
				onCompleted(num2, token);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryLicenseTokenAsync(storeContextHandle, productIds, customDeveloperString, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003E4C File Offset: 0x0000204C
		[Obsolete("Please use XStoreQueryLicenseTokenAsync(XStoreContext, string[], string, XStoreQueryLicenseTokenCompleted) instead.", false)]
		public static void XStoreQueryLicenseTokenAsync(XStoreContext context, string[] productIds, uint productIdsCount, string customDeveloperString, XStoreQueryLicenseTokenCompleted completionRoutine)
		{
			SDK.XStoreQueryLicenseTokenAsync(context, productIds, customDeveloperString, completionRoutine);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003E5C File Offset: 0x0000205C
		public static int XStoreQueryProductForCurrentGameAsync(XStoreContext storeContextHandle, XStoreQueryComplete onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreProductQuery xstoreProductQuery;
				int num2 = SDK.XStoreQueryProductForCurrentGameResult(_async, out xstoreProductQuery);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				XStoreProduct[] pageItems;
				num2 = SDK.XStoreEnumerateProductsQuery(xstoreProductQuery, out pageItems);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				bool hasMorePages = SDK.XStoreProductsQueryHasMorePages(xstoreProductQuery);
				XStoreQueryResult result = new XStoreQueryResult(xstoreProductQuery, pageItems, hasMorePages);
				onCompleted(num2, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryProductForCurrentGameAsync(storeContextHandle, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003EB8 File Offset: 0x000020B8
		public static int XStoreQueryProductForPackageAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, string packageIdentifier, XStoreQueryComplete onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreProductQuery xstoreProductQuery;
				int num2 = SDK.XStoreQueryProductForPackageResult(_async, out xstoreProductQuery);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				XStoreProduct[] pageItems;
				num2 = SDK.XStoreEnumerateProductsQuery(xstoreProductQuery, out pageItems);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				bool hasMorePages = SDK.XStoreProductsQueryHasMorePages(xstoreProductQuery);
				XStoreQueryResult result = new XStoreQueryResult(xstoreProductQuery, pageItems, hasMorePages);
				onCompleted(num2, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryProductForPackageAsync(storeContextHandle, productKinds, packageIdentifier, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003F14 File Offset: 0x00002114
		public static int XStoreQueryProductsAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, string[] storeIds, string[] actionFilters, XStoreQueryComplete onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreProductQuery xstoreProductQuery;
				int num2 = SDK.XStoreQueryProductsResult(_async, out xstoreProductQuery);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				XStoreProduct[] pageItems;
				num2 = SDK.XStoreEnumerateProductsQuery(xstoreProductQuery, out pageItems);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				bool hasMorePages = SDK.XStoreProductsQueryHasMorePages(xstoreProductQuery);
				XStoreQueryResult result = new XStoreQueryResult(xstoreProductQuery, pageItems, hasMorePages);
				onCompleted(num2, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreQueryProductsAsync(storeContextHandle, productKinds, storeIds, actionFilters, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003F72 File Offset: 0x00002172
		public static int XStoreRegisterGameLicenseChanged(XStoreContext context, XStoreGameLicenseChangedCallback callback, out GameLicenseChangedCallbackToken token)
		{
			return SDK.XStoreRegisterGameLicenseChanged(context, SDK.defaultQueue, IntPtr.Zero, callback, out token);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003F86 File Offset: 0x00002186
		public static void XStoreUnregisterGameLicenseChanged(XStoreContext context, GameLicenseChangedCallbackToken token)
		{
			token.Unregister(true);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003F90 File Offset: 0x00002190
		public static int XStoreRegisterPackageLicenseLost(XStoreLicense license, XStorePackageLicenseLostCallback callback, out PackageLicenseLostCallbackToken token)
		{
			return SDK.XStoreRegisterPackageLicenseLost(license, SDK.defaultQueue, IntPtr.Zero, callback, out token);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003FA4 File Offset: 0x000021A4
		public static void XStoreUnregisterPackageLicenseLost(XStoreLicense license, PackageLicenseLostCallbackToken token)
		{
			token.Unregister(true);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003FB0 File Offset: 0x000021B0
		public static int XStoreReportConsumableFulfillmentAsync(XStoreContext storeContextHandle, string storeProductId, uint quantity, Guid trackingId, XStoreReportConsumableFulfillmentCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreConsumableResult result;
				int hresult = SDK.XStoreReportConsumableFulfillmentResult(_async, out result);
				onCompleted(hresult, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreReportConsumableFulfillmentAsync(storeContextHandle, storeProductId, quantity, trackingId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004010 File Offset: 0x00002210
		public static int XStoreShowAssociatedProductsUIAsync(XStoreContext storeContextHandle, string storeId, XStoreProductKind productKinds, XStoreShowAssociatedProductsUICompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XStoreShowAssociatedProductsUIResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XStoreShowAssociatedProductsUIAsync(storeContextHandle, storeId, productKinds, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000406C File Offset: 0x0000226C
		public static int XStoreShowProductPageUIAsync(XStoreContext storeContextHandle, string storeId, XStoreShowProductPageUICompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XStoreShowProductPageUIResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XStoreShowProductPageUIAsync(storeContextHandle, storeId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000040C8 File Offset: 0x000022C8
		public static int XStoreShowPurchaseUIAsync(XStoreContext storeContextHandle, string storeId, string name, string extendedJsonData, XStoreShowPurchaseUICompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XStoreShowPurchaseUIResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XStoreShowPurchaseUIAsync(storeContextHandle, storeId, name, extendedJsonData, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004128 File Offset: 0x00002328
		public static int XStoreShowRateAndReviewUIAsync(XStoreContext storeContextHandle, XStoreShowRateAndReviewUICompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XStoreRateAndReviewResult result;
				int hresult = SDK.XStoreShowRateAndReviewUIResult(_async, out result);
				onCompleted(hresult, result);
			}, IntPtr.Zero);
			int num = SDK.XStoreShowRateAndReviewUIAsync(storeContextHandle, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004184 File Offset: 0x00002384
		public static int XStoreShowRedeemTokenUIAsync(XStoreContext storeContextHandle, string token, string[] allowedStoreIds, bool disallowCsvRedemption, XStoreShowRedeemTokenUICompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XStoreShowRedeemTokenUIResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XStoreShowRedeemTokenUIAsync(storeContextHandle, token, allowedStoreIds, disallowCsvRedemption, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000041E4 File Offset: 0x000023E4
		public static int XUserAddByIdWithUiAsync(ulong userId, XUserAddCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XUserHandle userHandle;
				int hresult = SDK.XUserAddByIdWithUiResult(_async, out userHandle);
				onCompleted(hresult, userHandle);
			}, IntPtr.Zero);
			int num = SDK.XUserAddByIdWithUiAsync(userId, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004240 File Offset: 0x00002440
		public static int XUserFindControllerForUserWithUiAsync(XUserHandle user, XUserFindControllerForUserWithUiResult onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				APP_LOCAL_DEVICE_ID deviceId;
				int hresult = SDK.XUserFindControllerForUserWithUiResult(_async, out deviceId);
				onCompleted(hresult, deviceId);
			}, IntPtr.Zero);
			int num = SDK.XUserFindControllerForUserWithUiAsync(user, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000429C File Offset: 0x0000249C
		public static int XUserGetTokenAndSignatureUtf16Async(XUserHandle user, XUserGetTokenAndSignatureOptions options, string method, string url, XUserGetTokenAndSignatureUtf16HttpHeader[] headers, byte[] bodyBuffer, XUserGetTokenAndSignatureUtf16Result onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong num3;
				int num2 = SDK.XUserGetTokenAndSignatureUtf16ResultSize(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				byte[] buffer = new byte[num3];
				XUserGetTokenAndSignatureUtf16Data tokenAndSignature;
				num2 = SDK.XUserGetTokenAndSignatureUtf16Result(_async, buffer, out tokenAndSignature);
				onCompleted(num2, tokenAndSignature);
			}, IntPtr.Zero);
			int num = SDK.XUserGetTokenAndSignatureUtf16Async(user, options, method, url, headers, bodyBuffer, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004300 File Offset: 0x00002500
		public static int XUserResolveIssueWithUiUtf16Async(XUserHandle user, string url, XUserResolveIssueWithUiUtf16Result onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XUserResolveIssueWithUiUtf16Result(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XUserResolveIssueWithUiUtf16Async(user, url, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000435C File Offset: 0x0000255C
		public static int XUserResolvePrivilegeWithUiAsync(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, XUserResolvePrivilegeWithUiCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				int hresult = SDK.XUserResolvePrivilegeWithUiResult(_async);
				onCompleted(hresult);
			}, IntPtr.Zero);
			int num = SDK.XUserResolvePrivilegeWithUiAsync(user, options, privilege, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num);
			}
			return num;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000043B8 File Offset: 0x000025B8
		public static int XUserGetGamerPictureAsync(XUserHandle user, XUserGamerPictureSize pictureSize, XUserGetGamerPictureCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				ulong num3;
				int num2 = SDK.XUserGetGamerPictureResultSize(_async, out num3);
				if (HR.FAILED(num2))
				{
					onCompleted(num2, null);
					return;
				}
				byte[] buffer = new byte[num3];
				ulong num4;
				num2 = SDK.XUserGetGamerPictureResult(_async, buffer, out num4);
				onCompleted(num2, buffer);
			}, IntPtr.Zero);
			int num = SDK.XUserGetGamerPictureAsync(user, pictureSize, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004414 File Offset: 0x00002614
		public static int XUserAddAsync(XUserAddOptions options, XUserAddCompleted onCompleted)
		{
			XAsyncBlock xasyncBlock = new XAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock _async)
			{
				XUserHandle userHandle;
				int hresult = SDK.XUserAddResult(_async, out userHandle);
				onCompleted(hresult, userHandle);
			}, IntPtr.Zero);
			int num = SDK.XUserAddAsync(options, xasyncBlock);
			if (HR.FAILED(num))
			{
				xasyncBlock.Dispose();
				onCompleted(num, null);
			}
			return num;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000446E File Offset: 0x0000266E
		public static int XAppBroadcastRegisterIsAppBroadcastingChanged(XAppBroadcastMonitorCallback callback, out XIsAppBroadcastingChangedRegistrationToken token)
		{
			return SDK.XAppBroadcastRegisterIsAppBroadcastingChanged(SDK.defaultQueue, callback, out token);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000447C File Offset: 0x0000267C
		public static bool XAppBroadcastUnregisterIsAppBroadcastingChanged(XIsAppBroadcastingChangedRegistrationToken token)
		{
			return SDK.XAppBroadcastUnregisterIsAppBroadcastingChanged(token, true);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004485 File Offset: 0x00002685
		public static int XAppCaptureRegisterMetadataPurged(XAppCaptureMetadataPurgedCallback callback, out XMetadataPurgedToken token)
		{
			return SDK.XAppCaptureRegisterMetadataPurged(SDK.defaultQueue, callback, out token);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004493 File Offset: 0x00002693
		public static bool XAppCaptureUnRegisterMetadataPurged(XMetadataPurgedToken token)
		{
			return SDK.XAppCaptureUnRegisterMetadataPurged(token, true);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000449C File Offset: 0x0000269C
		public static int XGameInviteRegisterForEvent(XGameInviteEventCallback callback, out XGameInviteRegistrationToken token)
		{
			return SDK.XGameInviteRegisterForEvent(SDK.defaultQueue, callback, out token);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000044AC File Offset: 0x000026AC
		[MonoPInvokeCallback(typeof(XAsyncProviderInterop))]
		private static int OnAsyncProvider(XAsyncOp op, XAsyncProviderData data)
		{
			return (GCHandle.FromIntPtr(data.context).Target as CallbackWrapper<XAsyncProviderInterop>).Callback(op, data);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000044E0 File Offset: 0x000026E0
		public static int XAsyncBegin(XAsyncBlock asyncBlock, IntPtr context, IntPtr identity, string identityName, XAsyncProvider provider)
		{
			int result;
			using (CallbackWrapper<XAsyncProviderInterop> callbackWrapper = new CallbackWrapper<XAsyncProviderInterop>(delegate(XAsyncOp _op, XAsyncProviderData _dataInterop)
			{
				XAsyncProviderData data = new XAsyncProviderData(_dataInterop, asyncBlock);
				return provider(_op, data);
			}, context, new XAsyncProviderInterop(SDK.OnAsyncProvider)))
			{
				result = NativeMethods.XAsyncBegin(asyncBlock.InteropPtr, callbackWrapper.CallbackContext, identity, identityName, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004560 File Offset: 0x00002760
		public static int XAsyncSchedule(XAsyncBlock asyncBlock, uint delayInMs)
		{
			return NativeMethods.XAsyncSchedule(asyncBlock.InteropPtr, delayInMs);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000456E File Offset: 0x0000276E
		public static void XAsyncComplete(XAsyncBlock asyncBlock, uint result, ulong requiredBufferSize)
		{
			NativeMethods.XAsyncComplete(asyncBlock.InteropPtr, result, requiredBufferSize);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000457D File Offset: 0x0000277D
		public static int XAsyncGetResult(XAsyncBlock asyncBlock, IntPtr identity, byte[] buffer, out ulong bufferUsed)
		{
			return NativeMethods.XAsyncGetResult(asyncBlock.InteropPtr, identity, (ulong)buffer.Length, buffer, out bufferUsed);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004594 File Offset: 0x00002794
		public static XDisplayHdrModeResult XDisplayTryEnableHdrMode(XDisplayHdrModePreference displayModePreference, out XDisplayHdrModeInfo displayHdrModeInfo)
		{
			XDisplayHdrModeInfo interop = default(XDisplayHdrModeInfo);
			XDisplayHdrModeResult result = NativeMethods.XDisplayTryEnableHdrMode(displayModePreference, out interop);
			displayHdrModeInfo = new XDisplayHdrModeInfo(interop);
			return result;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000045BC File Offset: 0x000027BC
		public static int XDisplayAcquireTimeoutDeferral(out XDisplayTimeoutDeferralHandle handle)
		{
			handle = null;
			IntPtr handle2;
			int num = NativeMethods.XDisplayAcquireTimeoutDeferral(out handle2);
			if (HR.SUCCEEDED(num))
			{
				handle = new XDisplayTimeoutDeferralHandle(handle2);
			}
			return num;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000045E3 File Offset: 0x000027E3
		public static void XDisplayCloseTimeoutDeferralHandle(XDisplayTimeoutDeferralHandle handle)
		{
			handle.Close();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000045EC File Offset: 0x000027EC
		[MonoPInvokeCallback(typeof(XErrorCallback))]
		private static bool OnErrorCallback(int hr, string msg, IntPtr context)
		{
			CallbackWrapper<XErrorCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XErrorCallback>;
			return callbackWrapper.Callback(hr, msg, callbackWrapper.Context);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004620 File Offset: 0x00002820
		public static void XErrorSetCallback(XErrorCallback callback, IntPtr context)
		{
			XErrorCallback callback2 = (int hr, string msg, IntPtr context) => callback(hr, msg, context);
			if (SDK.errorCallbackWrapper != null)
			{
				SDK.errorCallbackWrapper.Dispose();
				SDK.errorCallbackWrapper = null;
			}
			if (callback != null)
			{
				SDK.errorCallbackWrapper = new CallbackWrapper<XErrorCallback>(callback2, context2, new XErrorCallback(SDK.OnErrorCallback));
			}
			NativeMethods.XErrorSetCallback((SDK.errorCallbackWrapper != null) ? SDK.errorCallbackWrapper.StaticCallback : null, (SDK.errorCallbackWrapper != null) ? SDK.errorCallbackWrapper.CallbackContext : IntPtr.Zero);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000046AD File Offset: 0x000028AD
		public static void XErrorSetOptions(XErrorOptions optionsDebuggerPresent, XErrorOptions optionsDebuggerNotPresent)
		{
			NativeMethods.XErrorSetOptions(optionsDebuggerPresent, optionsDebuggerNotPresent);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000046B8 File Offset: 0x000028B8
		public static int XGameSaveEnumerateBlobInfo(XGameSaveContainerHandle container, out XGameSaveBlobInfo[] blobInfos)
		{
			blobInfos = null;
			List<XGameSaveBlobInfo> results = new List<XGameSaveBlobInfo>();
			int num = SDK.XGameSaveEnumerateBlobInfo(container, IntPtr.Zero, delegate(XGameSaveBlobInfo _blobInfo, IntPtr _context)
			{
				results.Add(_blobInfo);
				return true;
			});
			if (HR.SUCCEEDED(num))
			{
				blobInfos = results.ToArray();
			}
			return num;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004708 File Offset: 0x00002908
		public static int XGameSaveGetContainerInfo(XGameSaveProviderHandle provider, string containerName, out XGameSaveContainerInfo containerInfo)
		{
			containerInfo = null;
			XGameSaveContainerInfo info = null;
			int num = SDK.XGameSaveGetContainerInfo(provider, containerName, IntPtr.Zero, delegate(XGameSaveContainerInfo _info, IntPtr _context)
			{
				info = _info;
				return true;
			});
			if (HR.SUCCEEDED(num))
			{
				containerInfo = info;
			}
			return num;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004750 File Offset: 0x00002950
		public static int XGameSaveEnumerateContainerInfo(XGameSaveProviderHandle provider, out XGameSaveContainerInfo[] localInfos)
		{
			localInfos = null;
			List<XGameSaveContainerInfo> results = new List<XGameSaveContainerInfo>();
			int num = SDK.XGameSaveEnumerateContainerInfo(provider, IntPtr.Zero, delegate(XGameSaveContainerInfo _info, IntPtr _context)
			{
				results.Add(_info);
				return true;
			});
			if (HR.SUCCEEDED(num))
			{
				localInfos = results.ToArray();
			}
			return num;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000047A0 File Offset: 0x000029A0
		public static int XGameSaveEnumerateContainerInfoByName(XGameSaveProviderHandle provider, string containerNamePrefix, out XGameSaveContainerInfo[] localInfos)
		{
			localInfos = null;
			List<XGameSaveContainerInfo> results = new List<XGameSaveContainerInfo>();
			int num = SDK.XGameSaveEnumerateContainerInfoByName(provider, containerNamePrefix, IntPtr.Zero, delegate(XGameSaveContainerInfo _info, IntPtr _context)
			{
				results.Add(_info);
				return true;
			});
			if (HR.SUCCEEDED(num))
			{
				localInfos = results.ToArray();
			}
			return num;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000047F0 File Offset: 0x000029F0
		public static int XGameSaveEnumerateBlobInfoByName(XGameSaveContainerHandle provider, string blobNamePrefix, out XGameSaveBlobInfo[] blobInfos)
		{
			blobInfos = null;
			List<XGameSaveBlobInfo> results = new List<XGameSaveBlobInfo>();
			int num = SDK.XGameSaveEnumerateBlobInfoByName(provider, blobNamePrefix, IntPtr.Zero, delegate(XGameSaveBlobInfo _info, IntPtr _context)
			{
				results.Add(_info);
				return true;
			});
			if (HR.SUCCEEDED(num))
			{
				blobInfos = results.ToArray();
			}
			return num;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00004840 File Offset: 0x00002A40
		public static int XGameSaveReadBlobData(XGameSaveContainerHandle container, List<XGameSaveBlobInfo> blobInfos, out List<XGameSaveBlob> blobs)
		{
			blobs = null;
			XGameSaveBlob[] collection;
			int num = SDK.XGameSaveReadBlobData(container, blobInfos.ToArray(), out collection);
			if (HR.SUCCEEDED(num))
			{
				blobs = new List<XGameSaveBlob>(collection);
			}
			return num;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004870 File Offset: 0x00002A70
		public static int XSpeechSynthesizerEnumerateInstalledVoices(out XSpeechSynthesizerVoiceInformation[] voiceInformation)
		{
			SDK.<>c__DisplayClass181_0 CS$<>8__locals1 = new SDK.<>c__DisplayClass181_0();
			voiceInformation = null;
			CS$<>8__locals1.voices = new List<XSpeechSynthesizerVoiceInformation>();
			int num = SDK.XSpeechSynthesizerEnumerateInstalledVoices(IntPtr.Zero, new XSpeechSynthesizerInstalledVoicesCallback(CS$<>8__locals1.<XSpeechSynthesizerEnumerateInstalledVoices>g__VoiceCallback|0));
			if (HR.SUCCEEDED(num))
			{
				voiceInformation = CS$<>8__locals1.voices.ToArray();
			}
			return num;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000048BC File Offset: 0x00002ABC
		public static int XSpeechSynthesizerGetStreamData(XSpeechSynthesizerStreamHandle speechSynthesisStream, out byte[] buffer)
		{
			buffer = null;
			ulong num2;
			int num = SDK.XSpeechSynthesizerGetStreamDataSize(speechSynthesisStream, out num2);
			if (HR.FAILED(num))
			{
				return num;
			}
			buffer = new byte[num2];
			ulong num3;
			return SDK.XSpeechSynthesizerGetStreamData(speechSynthesisStream, buffer, out num3);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000048F4 File Offset: 0x00002AF4
		public static int XStoreEnumerateProductsQuery(XStoreProductQuery productQueryHandle, out XStoreProduct[] products)
		{
			SDK.<>c__DisplayClass183_0 CS$<>8__locals1 = new SDK.<>c__DisplayClass183_0();
			products = null;
			CS$<>8__locals1.tmpProducts = new List<XStoreProduct>();
			int num = SDK.XStoreEnumerateProductsQuery(productQueryHandle, IntPtr.Zero, new XStoreProductQueryCallback(CS$<>8__locals1.<XStoreEnumerateProductsQuery>g__OnProduct|0));
			if (HR.SUCCEEDED(num))
			{
				products = CS$<>8__locals1.tmpProducts.ToArray();
			}
			return num;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00004944 File Offset: 0x00002B44
		public static int XUserGetGamertag(XUserHandle user, XUserGamertagComponent gamertagComponent, out string gamertag)
		{
			gamertag = null;
			int capacity;
			switch (gamertagComponent)
			{
			case XUserGamertagComponent.Classic:
				capacity = 16;
				break;
			case XUserGamertagComponent.Modern:
				capacity = 97;
				break;
			case XUserGamertagComponent.ModernSuffix:
				capacity = 15;
				break;
			case XUserGamertagComponent.UniqueModern:
				capacity = 101;
				break;
			default:
				return -2147024809;
			}
			StringBuilder stringBuilder = new StringBuilder(capacity);
			ulong num2;
			int num = SDK.XUserGetGamertag(user, gamertagComponent, stringBuilder, out num2);
			if (HR.SUCCEEDED(num))
			{
				gamertag = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000049A9 File Offset: 0x00002BA9
		public static int XAppCaptureRecordDiagnosticClip(DateTime startTime, uint durationInMS, string fileNamePrefix, out XAppCaptureRecordClipResult result)
		{
			if (startTime.Kind != DateTimeKind.Utc)
			{
				startTime = startTime.ToUniversalTime();
			}
			return SDK.XAppCaptureRecordDiagnosticClip(new TimeT(startTime).SecondsSinceUnixEpoch, durationInMS, fileNamePrefix, out result);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000049D4 File Offset: 0x00002BD4
		public static int XPackageGetMountPath(XPackageMountHandle mountHandle, out string path)
		{
			path = string.Empty;
			ulong pathSize;
			int num = SDK.XPackageGetMountPathSize(mountHandle, out pathSize);
			if (HR.FAILED(num))
			{
				return num;
			}
			return SDK.XPackageGetMountPath(mountHandle, pathSize, out path);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004A03 File Offset: 0x00002C03
		public static int XPackageEstimateDownloadSize(string packageIdentifier, out ulong downloadSize, out bool shouldPresentUserConfirmation)
		{
			return SDK.XPackageEstimateDownloadSize(packageIdentifier, new XPackageChunkSelector[0], out downloadSize, out shouldPresentUserConfirmation);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00004A13 File Offset: 0x00002C13
		public static int XPackageEnumerateChunkAvailability(string packageIdentifier, XPackageChunkSelectorType type, XPackageChunkAvailabilityCallback callback)
		{
			return SDK.XPackageEnumerateChunkAvailability(packageIdentifier, type, IntPtr.Zero, callback);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004A24 File Offset: 0x00002C24
		public static int XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, out XPackageDetails[] details)
		{
			details2 = null;
			List<XPackageDetails> results = new List<XPackageDetails>();
			int num = SDK.XPackageEnumeratePackages(kind, scope, IntPtr.Zero, delegate(IntPtr context, XPackageDetails details)
			{
				results.Add(details);
				return true;
			});
			if (HR.SUCCEEDED(num))
			{
				details2 = results.ToArray();
			}
			return num;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004A74 File Offset: 0x00002C74
		public static int XPackageEnumerateFeatures(string packageIdentifier, out XPackageFeature[] features)
		{
			features = null;
			List<XPackageFeature> results = new List<XPackageFeature>();
			int num = SDK.XPackageEnumerateFeatures(packageIdentifier, IntPtr.Zero, delegate(IntPtr context, XPackageFeature feature)
			{
				results.Add(feature);
				return true;
			});
			if (HR.SUCCEEDED(num))
			{
				features = results.ToArray();
			}
			return num;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004AC1 File Offset: 0x00002CC1
		public static int XSpeechSynthesizerSetCustomVoice(XSpeechSynthesizerHandle speechSynthesizer, XSpeechSynthesizerVoiceInformation voiceInformation)
		{
			return SDK.XSpeechSynthesizerSetCustomVoice(speechSynthesizer, voiceInformation.VoiceId);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004ACF File Offset: 0x00002CCF
		public static int XGameGetXboxTitleId(out uint titleId)
		{
			return NativeMethods.XGameGetXboxTitleId(out titleId);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004AD8 File Offset: 0x00002CD8
		public static void XLaunchNewGame(string exePath, string args, XUserHandle defaultUser)
		{
			IntPtr defaultUser2 = (defaultUser != null) ? defaultUser.Handle : IntPtr.Zero;
			NativeMethods.XLaunchNewGame(exePath, args, defaultUser2);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004B04 File Offset: 0x00002D04
		public static int XLaunchRestartOnCrash(string args, uint reserved)
		{
			return NativeMethods.XLaunchRestartOnCrash(args, reserved);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00004B0D File Offset: 0x00002D0D
		public static int XGameEventWrite(XUserHandle user, string serviceConfigId, string playSessionId, string eventName, string dimensionsJson, string measurementsJson)
		{
			return NativeMethods.XGameEventWrite((user != null) ? user.Handle : IntPtr.Zero, serviceConfigId, playSessionId, eventName, dimensionsJson, measurementsJson);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004B34 File Offset: 0x00002D34
		public static int XGameInviteRegisterForEvent(XTaskQueueHandle handle, XGameInviteEventCallback callback, IntPtr context, out XGameInviteRegistrationToken token)
		{
			XGameInviteEventCallback callback2 = delegate(IntPtr context, string inviteUri)
			{
				callback(context, inviteUri);
			};
			token = new XGameInviteRegistrationToken(callback2, context2);
			ulong num2;
			int num = NativeMethods.XGameInviteRegisterForEvent((handle != null) ? handle.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out num2);
			if (HR.SUCCEEDED(num) && num2 != 0UL)
			{
				token.Token = num2;
				return num;
			}
			token.interop.Dispose();
			token = null;
			return num;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004BBA File Offset: 0x00002DBA
		public static int XGameInviteRegisterForEvent(XTaskQueueHandle handle, XGameInviteEventCallback callback, out XGameInviteRegistrationToken token)
		{
			return SDK.XGameInviteRegisterForEvent(handle, callback, IntPtr.Zero, out token);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00004BC9 File Offset: 0x00002DC9
		public static bool XGameInviteUnregisterForEvent(XGameInviteRegistrationToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004BD2 File Offset: 0x00002DD2
		public static bool XGameInviteUnregisterForEvent(XGameInviteRegistrationToken token)
		{
			return SDK.XGameInviteUnregisterForEvent(token, true);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00004BDC File Offset: 0x00002DDC
		public static int XGameProtocolRegisterForActivation(XTaskQueueHandle queue, IntPtr context, XGameProtocolActivationCallback callback, out XGameProtocolActivationToken token)
		{
			XGameProtocolActivationCallback callback2 = delegate(IntPtr context, string protocolUri)
			{
				callback(context, protocolUri);
			};
			token = new XGameProtocolActivationToken(callback2, context2);
			ulong token2;
			int num = NativeMethods.XGameProtocolRegisterForActivation((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.interop.Dispose();
			token = null;
			return num;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004C5F File Offset: 0x00002E5F
		public static bool XGameProtocolUnregisterForActivation(XGameProtocolActivationToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004C68 File Offset: 0x00002E68
		public static bool XGameRuntimeIsFeatureAvailable(XGameRuntimeFeature feature)
		{
			return NativeMethods.XGameRuntimeIsFeatureAvailable(feature);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00004C70 File Offset: 0x00002E70
		public static int XGameRuntimeInitialize()
		{
			return NativeMethods.XGameRuntimeInitialize();
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004C77 File Offset: 0x00002E77
		public static void XGameRuntimeUninitialize()
		{
			NativeMethods.XGameRuntimeUninitialize();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004C7E File Offset: 0x00002E7E
		public static void XGameSaveCloseContainer(XGameSaveContainerHandle context)
		{
			context.Close();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004C86 File Offset: 0x00002E86
		public static void XGameSaveCloseProvider(XGameSaveProviderHandle provider)
		{
			provider.Close();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004C8E File Offset: 0x00002E8E
		public static void XGameSaveCloseUpdate(XGameSaveUpdateHandle context)
		{
			context.Close();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004C98 File Offset: 0x00002E98
		public static int XGameSaveInitializeProvider(XUserHandle requestingUser, string configurationId, bool syncOnDemand, out XGameSaveProviderHandle provider)
		{
			IntPtr intPtr = 0;
			provider = null;
			int num = NativeMethods.XGameSaveInitializeProvider((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, configurationId, syncOnDemand, out intPtr);
			if (HR.SUCCEEDED(num) || (num == -2138898428 && intPtr != (IntPtr)0))
			{
				provider = new XGameSaveProviderHandle(intPtr);
			}
			return num;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004CF3 File Offset: 0x00002EF3
		public static int XGameSaveInitializeProviderAsync(XUserHandle requestingUser, string configurationId, bool syncOnDemand, XAsyncBlock asyncBlock)
		{
			return NativeMethods.XGameSaveInitializeProviderAsync((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, configurationId, syncOnDemand, asyncBlock.InteropPtr);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004D18 File Offset: 0x00002F18
		public static int XGameSaveInitializeProviderResult(XAsyncBlock asyncBlock, out XGameSaveProviderHandle provider)
		{
			IntPtr intPtr = 0;
			provider = null;
			int num = NativeMethods.XGameSaveInitializeProviderResult(asyncBlock.InteropPtr, out intPtr);
			if (HR.SUCCEEDED(num) || (num == -2138898428 && intPtr != (IntPtr)0))
			{
				provider = new XGameSaveProviderHandle(intPtr);
			}
			return num;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004D61 File Offset: 0x00002F61
		public static int XGameSaveGetRemainingQuota(XGameSaveProviderHandle provider, out long remainingQuota)
		{
			return NativeMethods.XGameSaveGetRemainingQuota(provider.Handle, out remainingQuota);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00004D6F File Offset: 0x00002F6F
		public static int XGameSaveGetRemainingQuotaAsync(XGameSaveProviderHandle provider, XAsyncBlock asyncBlock)
		{
			return NativeMethods.XGameSaveGetRemainingQuotaAsync(provider.Handle, asyncBlock.InteropPtr);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00004D82 File Offset: 0x00002F82
		public static int XGameSaveGetRemainingQuotaResult(XAsyncBlock async, out long remainingQuota)
		{
			return NativeMethods.XGameSaveGetRemainingQuotaResult(async.InteropPtr, out remainingQuota);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004D90 File Offset: 0x00002F90
		public static int XGameSaveDeleteContainer(XGameSaveProviderHandle provider, string containerName)
		{
			return NativeMethods.XGameSaveDeleteContainer(provider.Handle, containerName);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00004D9E File Offset: 0x00002F9E
		public static int XGameSaveDeleteContainerAsync(XGameSaveProviderHandle provider, string containerName, XAsyncBlock async)
		{
			return NativeMethods.XGameSaveDeleteContainerAsync(provider.Handle, containerName, async.InteropPtr);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00004DB2 File Offset: 0x00002FB2
		public static int XGameSaveDeleteContainerResult(XAsyncBlock async)
		{
			return NativeMethods.XGameSaveDeleteContainerResult(async.InteropPtr);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00004DC0 File Offset: 0x00002FC0
		[MonoPInvokeCallback(typeof(XGameSaveContainerInfoCallback))]
		private static bool OnContainerInfo(XGameSaveContainerInfo info, IntPtr context)
		{
			CallbackWrapper<XGameSaveContainerInfoCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameSaveContainerInfoCallback>;
			return callbackWrapper.Callback(info, callbackWrapper.Context);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00004DF4 File Offset: 0x00002FF4
		public static int XGameSaveGetContainerInfo(XGameSaveProviderHandle provider, string containerName, IntPtr context, XGameSaveContainerInfoCallback callback)
		{
			int result;
			using (CallbackWrapper<XGameSaveContainerInfoCallback> callbackWrapper = new CallbackWrapper<XGameSaveContainerInfoCallback>((XGameSaveContainerInfo info, IntPtr callbackContext) => callback(new XGameSaveContainerInfo(info), callbackContext), context, new XGameSaveContainerInfoCallback(SDK.OnContainerInfo)))
			{
				result = NativeMethods.XGameSaveGetContainerInfo(provider.Handle, containerName, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00004E64 File Offset: 0x00003064
		public static int XGameSaveEnumerateContainerInfo(XGameSaveProviderHandle provider, IntPtr context, XGameSaveContainerInfoCallback callback)
		{
			int result;
			using (CallbackWrapper<XGameSaveContainerInfoCallback> callbackWrapper = new CallbackWrapper<XGameSaveContainerInfoCallback>((XGameSaveContainerInfo info, IntPtr callbackContext) => callback(new XGameSaveContainerInfo(info), callbackContext), context, new XGameSaveContainerInfoCallback(SDK.OnContainerInfo)))
			{
				result = NativeMethods.XGameSaveEnumerateContainerInfo(provider.Handle, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00004ED0 File Offset: 0x000030D0
		public static int XGameSaveEnumerateContainerInfoByName(XGameSaveProviderHandle provider, string containerNamePrefix, IntPtr context, XGameSaveContainerInfoCallback callback)
		{
			int result;
			using (CallbackWrapper<XGameSaveContainerInfoCallback> callbackWrapper = new CallbackWrapper<XGameSaveContainerInfoCallback>((XGameSaveContainerInfo info, IntPtr callbackContext) => callback(new XGameSaveContainerInfo(info), callbackContext), context, new XGameSaveContainerInfoCallback(SDK.OnContainerInfo)))
			{
				result = NativeMethods.XGameSaveEnumerateContainerInfoByName(provider.Handle, containerNamePrefix, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004F40 File Offset: 0x00003140
		public static int XGameSaveReadBlobData(XGameSaveContainerHandle container, XGameSaveBlobInfo[] blobInfos, out XGameSaveBlob[] blobData)
		{
			blobData = null;
			int num = 0;
			string[] array = (from x in blobInfos
			select x.Name).ToArray<string>();
			uint count = (uint)array.Length;
			ulong num2 = (ulong)((long)blobInfos.Sum((XGameSaveBlobInfo x) => Marshal.SizeOf(typeof(XGameSaveBlobInterop)) + x.Name.Length + 1 + Convert.ToInt32(x.Size)));
			IntPtr intPtr = Marshal.AllocHGlobal(Convert.ToInt32(num2));
			try
			{
				num = NativeMethods.XGameSaveReadBlobData(container.Handle, array, ref count, num2, intPtr);
				if (HR.SUCCEEDED(num))
				{
					blobData = InteropHelpers.MarshalArray<XGameSaveBlobInterop, XGameSaveBlob>(intPtr, count, (XGameSaveBlobInterop blobDataInterop) => new XGameSaveBlob(blobDataInterop));
				}
			}
			catch (Exception ex)
			{
				num = ex.HResult;
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
			return num;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005028 File Offset: 0x00003228
		public static int XGameSaveCreateContainer(XGameSaveProviderHandle provider, string containerName, out XGameSaveContainerHandle containerContext)
		{
			containerContext = null;
			IntPtr handle;
			int num = NativeMethods.XGameSaveCreateContainer(provider.Handle, containerName, out handle);
			if (HR.SUCCEEDED(num))
			{
				containerContext = new XGameSaveContainerHandle(handle);
			}
			return num;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005058 File Offset: 0x00003258
		public static int XGameSaveReadBlobDataResult(XAsyncBlock async, ulong blobsSize, out XGameSaveBlob[] blobData)
		{
			blobData = null;
			int num = 0;
			IntPtr intPtr = Marshal.AllocHGlobal(Convert.ToInt32(blobsSize));
			try
			{
				uint count;
				num = NativeMethods.XGameSaveReadBlobDataResult(async.InteropPtr, blobsSize, intPtr, out count);
				if (HR.SUCCEEDED(num))
				{
					blobData = InteropHelpers.MarshalArray<XGameSaveBlobInterop, XGameSaveBlob>(intPtr, count, (XGameSaveBlobInterop blobDataInterop) => new XGameSaveBlob(blobDataInterop));
				}
			}
			catch (Exception ex)
			{
				num = ex.HResult;
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
			return num;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000050E4 File Offset: 0x000032E4
		[MonoPInvokeCallback(typeof(XGameSaveBlobInfoCallback))]
		private static bool OnBlobInfo(XGameSaveBlobInfo info, IntPtr context)
		{
			CallbackWrapper<XGameSaveBlobInfoCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameSaveBlobInfoCallback>;
			return callbackWrapper.Callback(info, callbackWrapper.Context);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005118 File Offset: 0x00003318
		public static int XGameSaveEnumerateBlobInfo(XGameSaveContainerHandle container, IntPtr context, XGameSaveBlobInfoCallback callback)
		{
			int result;
			using (CallbackWrapper<XGameSaveBlobInfoCallback> callbackWrapper = new CallbackWrapper<XGameSaveBlobInfoCallback>((XGameSaveBlobInfo info, IntPtr callbackContext) => callback(new XGameSaveBlobInfo(info), callbackContext), context, new XGameSaveBlobInfoCallback(SDK.OnBlobInfo)))
			{
				result = NativeMethods.XGameSaveEnumerateBlobInfo(container.Handle, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005184 File Offset: 0x00003384
		public static int XGameSaveEnumerateBlobInfoByName(XGameSaveContainerHandle container, string blobNamePrefix, IntPtr context, XGameSaveBlobInfoCallback callback)
		{
			int result;
			using (CallbackWrapper<XGameSaveBlobInfoCallback> callbackWrapper = new CallbackWrapper<XGameSaveBlobInfoCallback>((XGameSaveBlobInfo info, IntPtr callbackContext) => callback(new XGameSaveBlobInfo(info), callbackContext), context, new XGameSaveBlobInfoCallback(SDK.OnBlobInfo)))
			{
				result = NativeMethods.XGameSaveEnumerateBlobInfoByName(container.Handle, blobNamePrefix, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000051F4 File Offset: 0x000033F4
		public static int XGameSaveReadBlobDataAsync(XGameSaveContainerHandle container, string[] blobNames, XAsyncBlock async)
		{
			return NativeMethods.XGameSaveReadBlobDataAsync(container.Handle, blobNames, (uint)blobNames.Length, async.InteropPtr);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000520C File Offset: 0x0000340C
		public static int XGameSaveCreateUpdate(XGameSaveContainerHandle container, string containerDisplayName, out XGameSaveUpdateHandle updateContext)
		{
			updateContext = null;
			IntPtr handle;
			int num = NativeMethods.XGameSaveCreateUpdate(container.Handle, containerDisplayName, out handle);
			if (HR.SUCCEEDED(num))
			{
				updateContext = new XGameSaveUpdateHandle(handle);
			}
			return num;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000523A File Offset: 0x0000343A
		public static int XGameSaveSubmitBlobWrite(XGameSaveUpdateHandle updateContext, string blobName, byte[] data)
		{
			return NativeMethods.XGameSaveSubmitBlobWrite(updateContext.Handle, blobName, data, (ulong)data.Length);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000524D File Offset: 0x0000344D
		public static int XGameSaveSubmitBlobWrite(XGameSaveUpdateHandle updateContext, string blobName, byte[] data, uint length)
		{
			return NativeMethods.XGameSaveSubmitBlobWrite(updateContext.Handle, blobName, data, (ulong)length);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000525E File Offset: 0x0000345E
		public static int XGameSaveSubmitBlobDelete(XGameSaveUpdateHandle updateContext, string blobName)
		{
			return NativeMethods.XGameSaveSubmitBlobDelete(updateContext.Handle, blobName);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000526C File Offset: 0x0000346C
		public static int XGameSaveSubmitUpdate(XGameSaveUpdateHandle updateContext)
		{
			return NativeMethods.XGameSaveSubmitUpdate(updateContext.Handle);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005279 File Offset: 0x00003479
		public static int XGameSaveSubmitUpdateAsync(XGameSaveUpdateHandle updateContext, XAsyncBlock async)
		{
			return NativeMethods.XGameSaveSubmitUpdateAsync(updateContext.Handle, async.InteropPtr);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000528C File Offset: 0x0000348C
		public static int XGameSaveSubmitUpdateResult(XAsyncBlock async)
		{
			return NativeMethods.XGameSaveSubmitUpdateResult(async.InteropPtr);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005299 File Offset: 0x00003499
		public static int XGameSaveFilesGetFolderWithUiAsync(XUserHandle requestingUser, string configurationId, XAsyncBlock async)
		{
			return NativeMethods.XGameSaveFilesGetFolderWithUiAsync((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, configurationId, async.InteropPtr);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000052C0 File Offset: 0x000034C0
		public static int XGameSaveFilesGetFolderWithUiResult(XAsyncBlock async, ulong folderSize, out string folderResult)
		{
			folderResult = null;
			StringBuilder stringBuilder = new StringBuilder((int)folderSize);
			int num = NativeMethods.XGameSaveFilesGetFolderWithUiResult(async.InteropPtr, folderSize, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				folderResult = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000052F8 File Offset: 0x000034F8
		[Obsolete("Please use XGameSaveFilesGetRemainingQuota(XUserHandle, string, out UInt64) instead", false)]
		public static int XGameSaveFilesGetRemainingQuota(XUserHandle userContext, string configurationId, out long remainingQuota)
		{
			ulong num;
			int result = NativeMethods.XGameSaveFilesGetRemainingQuota(userContext.Handle, configurationId, out num);
			remainingQuota = (long)num;
			return result;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00005316 File Offset: 0x00003516
		public static int XGameSaveFilesGetRemainingQuota(XUserHandle userContext, string configurationId, out ulong remainingQuota)
		{
			return NativeMethods.XGameSaveFilesGetRemainingQuota((userContext != null) ? userContext.Handle : IntPtr.Zero, configurationId, out remainingQuota);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00005338 File Offset: 0x00003538
		private static int ProcessTouchControlOperation(ref XGameStreamingTouchControlsStateOperation[] operations, out XGameStreamingTouchControlsStateOperation[] nativeOperations, out List<IntPtr> stringsToFree)
		{
			nativeOperations = new XGameStreamingTouchControlsStateOperation[operations.Length];
			stringsToFree = new List<IntPtr>();
			for (int i = 0; i < operations.Length; i++)
			{
				XGameStreamingTouchControlsStateOperation xgameStreamingTouchControlsStateOperation = operations[i];
				nativeOperations[i].path = xgameStreamingTouchControlsStateOperation.Path;
				nativeOperations[i].value.valueKind = xgameStreamingTouchControlsStateOperation.Value.ValueKind;
				switch (xgameStreamingTouchControlsStateOperation.Value.ValueKind)
				{
				case XGameStreamingTouchControlsStateValueKind.Boolean:
					nativeOperations[i].value.boolValue = xgameStreamingTouchControlsStateOperation.Value.BoolValue;
					break;
				case XGameStreamingTouchControlsStateValueKind.Integer:
					nativeOperations[i].value.integerValue = xgameStreamingTouchControlsStateOperation.Value.IntegerValue;
					break;
				case XGameStreamingTouchControlsStateValueKind.Double:
					nativeOperations[i].value.doubleValue = xgameStreamingTouchControlsStateOperation.Value.DoubleValue;
					break;
				case XGameStreamingTouchControlsStateValueKind.String:
					nativeOperations[i].value.stringValue = InteropHelpers.MarshalStringUtf8(xgameStreamingTouchControlsStateOperation.Value.StringValue);
					stringsToFree.Add(nativeOperations[i].value.stringValue);
					break;
				default:
					return -2147024809;
				}
			}
			return 0;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000546C File Offset: 0x0000366C
		public static int XGameStreamingInitialize()
		{
			return NativeMethods.XGameStreamingInitialize();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00005473 File Offset: 0x00003673
		public static void XGameStreamingUninitialize()
		{
			NativeMethods.XGameStreamingUninitialize();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000547A File Offset: 0x0000367A
		public static bool XGameStreamingIsStreaming()
		{
			return NativeMethods.XGameStreamingIsStreaming();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005481 File Offset: 0x00003681
		public static uint XGameStreamingGetClientCount()
		{
			return NativeMethods.XGameStreamingGetClientCount();
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00005488 File Offset: 0x00003688
		public static int XGameStreamingGetClients(ref XGameStreamingClientId[] clients, out uint clientUsed)
		{
			XGameStreamingClientId[] array = new XGameStreamingClientId[clients.Length];
			int num = NativeMethods.XGameStreamingGetClients((uint)clients.Length, array, out clientUsed);
			if (HR.SUCCEEDED(num))
			{
				clients = new XGameStreamingClientId[clientUsed];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)clientUsed))
				{
					clients[num2] = new XGameStreamingClientId(array[num2]);
					num2++;
				}
			}
			return num;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000054DC File Offset: 0x000036DC
		public static XGameStreamingConnectionState XGameStreamingGetConnectionState(XGameStreamingClientId client)
		{
			return NativeMethods.XGameStreamingGetConnectionState(client.data);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000054EC File Offset: 0x000036EC
		public static int XGameStreamingRegisterConnectionStateChanged(XTaskQueueHandle queue, IntPtr context, XGameStreamingConnectionStateChangedCallback callback, out XGameStreamingConnectionStateChangedToken token)
		{
			XGameStreamingConnectionStateChangedCallback callback2 = delegate(IntPtr _context, XGameStreamingClientId _client, XGameStreamingConnectionState _state)
			{
				callback(_context, new XGameStreamingClientId(_client), _state);
			};
			token = new XGameStreamingConnectionStateChangedToken(callback2, context);
			ulong num = 0UL;
			int num2 = NativeMethods.XGameStreamingRegisterConnectionStateChanged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out num);
			if (HR.SUCCEEDED(num2) && num != 0UL)
			{
				token.Token = num;
				return num2;
			}
			token.interop.Dispose();
			token = null;
			return num2;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00005575 File Offset: 0x00003775
		public static bool XGameStreamingUnregisterConnectionStateChanged(XGameStreamingConnectionStateChangedToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000557E File Offset: 0x0000377E
		public static void XGameStreamingHideTouchControls()
		{
			NativeMethods.XGameStreamingHideTouchControls();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005585 File Offset: 0x00003785
		public static void XGameStreamingHideTouchControlsOnClient(XGameStreamingClientId client)
		{
			NativeMethods.XGameStreamingHideTouchControlsOnClient(client.data);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00005592 File Offset: 0x00003792
		public static void XGameStreamingShowTouchControlLayout(string layout)
		{
			NativeMethods.XGameStreamingShowTouchControlLayout(layout);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000559A File Offset: 0x0000379A
		public static void XGameStreamingShowTouchControlLayoutOnClient(XGameStreamingClientId client, string layout)
		{
			NativeMethods.XGameStreamingShowTouchControlLayoutOnClient(client.data, layout);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000055A8 File Offset: 0x000037A8
		public static int XGameStreamingRegisterClientPropertiesChanged(XGameStreamingClientId client, XTaskQueueHandle queue, IntPtr context, XGameStreamingClientPropertiesChangedCallback callback, out XGameStreamingRegisterClientPropertiesChangedToken token)
		{
			XGameStreamingClientPropertiesChangedCallback callback2 = delegate(IntPtr _context, XGameStreamingClientId _clientId, uint _updatedPropertiesCount, XGameStreamingClientProperty[] _updatedProperties)
			{
				callback(_context, new XGameStreamingClientId(_clientId), _updatedProperties);
			};
			token = new XGameStreamingRegisterClientPropertiesChangedToken(client, callback2, context);
			ulong token2 = 0UL;
			int num = NativeMethods.XGameStreamingRegisterClientPropertiesChanged(client.data, queue.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.interop.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000562B File Offset: 0x0000382B
		public static bool XGameStreamingUnregisterClientPropertiesChanged(XGameStreamingClientId client, XGameStreamingRegisterClientPropertiesChangedToken token, bool wait)
		{
			return token.Unregister(client, wait);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00005635 File Offset: 0x00003835
		public static int XGameStreamingGetStreamPhysicalDimensions(XGameStreamingClientId client, out uint horizontalMm, out uint verticalMm)
		{
			return NativeMethods.XGameStreamingGetStreamPhysicalDimensions(client.data, out horizontalMm, out verticalMm);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00005644 File Offset: 0x00003844
		public static int XGameStreamingGetStreamAddedLatency(XGameStreamingClientId client, out uint averageInputLatencyUs, out uint averageOutputLatencyUs, out uint standardDeviationUs)
		{
			return NativeMethods.XGameStreamingGetStreamAddedLatency(client.data, out averageInputLatencyUs, out averageOutputLatencyUs, out standardDeviationUs);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00005654 File Offset: 0x00003854
		public static ulong XGameStreamingGetServerLocationNameSize()
		{
			return NativeMethods.XGameStreamingGetServerLocationNameSize();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000565C File Offset: 0x0000385C
		public static int XGameStreamingGetServerLocationName(ulong serverLocalNameSize, out string serverLocationName)
		{
			serverLocationName = null;
			StringBuilder stringBuilder = new StringBuilder((int)serverLocalNameSize);
			int num = NativeMethods.XGameStreamingGetServerLocationName(serverLocalNameSize, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				serverLocationName = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000568B File Offset: 0x0000388B
		public static int XGameStreamingIsTouchInputEnabled(XGameStreamingClientId client, out bool touchInputEnabled)
		{
			return NativeMethods.XGameStreamingIsTouchInputEnabled(client.data, out touchInputEnabled);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000569C File Offset: 0x0000389C
		public static int XGameStreamingGetLastFrameDisplayed(XGameStreamingClientId client, out D3D12XBOX_FRAME_PIPELINE_TOKEN framePipelineToken)
		{
			framePipelineToken = null;
			ulong value = 0UL;
			int num = NativeMethods.XGameStreamingGetLastFrameDisplayed(client.data, out value);
			if (HR.SUCCEEDED(num))
			{
				framePipelineToken = new D3D12XBOX_FRAME_PIPELINE_TOKEN(value);
			}
			return num;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000056CC File Offset: 0x000038CC
		public static int XGameStreamingUpdateTouchControlsState(XGameStreamingTouchControlsStateOperation[] operations)
		{
			int num = 0;
			if (operations != null)
			{
				List<IntPtr> list = new List<IntPtr>();
				try
				{
					XGameStreamingTouchControlsStateOperation[] operations2;
					num = SDK.ProcessTouchControlOperation(ref operations, out operations2, out list);
					if (HR.SUCCEEDED(num))
					{
						num = NativeMethods.XGameStreamingUpdateTouchControlsState((ulong)((long)operations.Length), operations2);
					}
					return num;
				}
				finally
				{
					foreach (IntPtr ptr in list)
					{
						Marshal.FreeCoTaskMem(ptr);
					}
				}
			}
			num = NativeMethods.XGameStreamingUpdateTouchControlsState(0UL, null);
			return num;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000575C File Offset: 0x0000395C
		public static int XGameStreamingUpdateTouchControlsStateOnClient(XGameStreamingClientId client, XGameStreamingTouchControlsStateOperation[] operations)
		{
			int num = 0;
			if (operations != null)
			{
				List<IntPtr> list = new List<IntPtr>();
				try
				{
					XGameStreamingTouchControlsStateOperation[] operations2 = null;
					num = SDK.ProcessTouchControlOperation(ref operations, out operations2, out list);
					if (HR.SUCCEEDED(num))
					{
						num = NativeMethods.XGameStreamingUpdateTouchControlsStateOnClient(client.data, (ulong)((long)operations.Length), operations2);
					}
					return num;
				}
				finally
				{
					foreach (IntPtr ptr in list)
					{
						Marshal.FreeCoTaskMem(ptr);
					}
				}
			}
			num = NativeMethods.XGameStreamingUpdateTouchControlsStateOnClient(client.data, 0UL, null);
			return num;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000057F8 File Offset: 0x000039F8
		public static int XGameStreamingShowTouchControlsWithStateUpdate(string layout, XGameStreamingTouchControlsStateOperation[] operations)
		{
			int num = 0;
			if (operations != null)
			{
				List<IntPtr> list = new List<IntPtr>();
				try
				{
					XGameStreamingTouchControlsStateOperation[] operations2;
					num = SDK.ProcessTouchControlOperation(ref operations, out operations2, out list);
					if (HR.SUCCEEDED(num))
					{
						num = NativeMethods.XGameStreamingShowTouchControlsWithStateUpdate(layout, (ulong)((long)operations.Length), operations2);
					}
					return num;
				}
				finally
				{
					foreach (IntPtr ptr in list)
					{
						Marshal.FreeCoTaskMem(ptr);
					}
				}
			}
			num = NativeMethods.XGameStreamingShowTouchControlsWithStateUpdate(layout, 0UL, null);
			return num;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00005888 File Offset: 0x00003A88
		public static int XGameStreamingShowTouchControlsWithStateUpdateOnClient(XGameStreamingClientId client, string layout, XGameStreamingTouchControlsStateOperation[] operations)
		{
			int num = 0;
			List<IntPtr> list = new List<IntPtr>();
			if (operations != null)
			{
				try
				{
					XGameStreamingTouchControlsStateOperation[] operations2;
					num = SDK.ProcessTouchControlOperation(ref operations, out operations2, out list);
					if (HR.SUCCEEDED(num))
					{
						num = NativeMethods.XGameStreamingShowTouchControlsWithStateUpdateOnClient(client.data, layout, (ulong)((long)operations.Length), operations2);
					}
					return num;
				}
				finally
				{
					foreach (IntPtr ptr in list)
					{
						Marshal.FreeCoTaskMem(ptr);
					}
				}
			}
			num = NativeMethods.XGameStreamingShowTouchControlsWithStateUpdateOnClient(client.data, layout, 0UL, null);
			return num;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00005924 File Offset: 0x00003B24
		public static ulong XGameStreamingGetTouchBundleVersionNameSize(XGameStreamingClientId client)
		{
			return NativeMethods.XGameStreamingGetTouchBundleVersionNameSize(client.data);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00005934 File Offset: 0x00003B34
		public static int XGameStreamingGetTouchBundleVersion(XGameStreamingClientId client, out XVersion version, ulong versionNameSize, out string versionName)
		{
			versionName = null;
			StringBuilder stringBuilder = new StringBuilder((int)versionNameSize);
			version = null;
			XVersion interop = default(XVersion);
			int num = NativeMethods.XGameStreamingGetTouchBundleVersion(client.data, out interop, versionNameSize, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				versionName = stringBuilder.ToString();
				version = new XVersion(interop);
			}
			return num;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005980 File Offset: 0x00003B80
		public static int XGameStreamingGetClientIPAddress(XGameStreamingClientId client, out string ipAddress)
		{
			ipAddress = null;
			StringBuilder stringBuilder = new StringBuilder(65);
			int num = NativeMethods.XGameStreamingGetClientIPAddress(client.data, 65UL, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				ipAddress = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000059B8 File Offset: 0x00003BB8
		public static int XGameStreamingGetSessionId(XGameStreamingClientId client, out string sessionId)
		{
			sessionId = null;
			StringBuilder stringBuilder = new StringBuilder(256);
			ulong num = 0UL;
			int num2 = NativeMethods.XGameStreamingGetSessionId(client.data, 256UL, stringBuilder, out num);
			if (HR.SUCCEEDED(num2))
			{
				sessionId = stringBuilder.ToString();
			}
			return num2;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000059FC File Offset: 0x00003BFC
		public static int XGameStreamingGetDisplayDetails(XGameStreamingClientId clientId, uint maxSupportedPixels, float widestSupportedAspectRatio, float tallestSupportedAspectRatio, out XGameStreamingDisplayDetails displayDetails)
		{
			displayDetails = null;
			XGameStreamingDisplayDetails interop = default(XGameStreamingDisplayDetails);
			int num = NativeMethods.XGameStreamingGetDisplayDetails(clientId.data, maxSupportedPixels, widestSupportedAspectRatio, tallestSupportedAspectRatio, out interop);
			if (HR.SUCCEEDED(num))
			{
				displayDetails = new XGameStreamingDisplayDetails(interop);
			}
			return num;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00005A36 File Offset: 0x00003C36
		public static int XGameStreamingSetResolution(uint width, uint height)
		{
			return NativeMethods.XGameStreamingSetResolution(width, height);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00005A3F File Offset: 0x00003C3F
		public static int XGameUiShowMessageDialogAsync(XAsyncBlock async, string titleText, string contextText, string firstButtonText, string secondButtonText, string thirdButtonText, XGameUiMessageDialogButton defaultButton, XGameUiMessageDialogButton cancelButton)
		{
			return NativeMethods.XGameUiShowMessageDialogAsync(async.InteropPtr, titleText, contextText, firstButtonText, secondButtonText, thirdButtonText, defaultButton, cancelButton);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00005A57 File Offset: 0x00003C57
		public static int XGameUiShowMessageDialogResult(XAsyncBlock async, out XGameUiMessageDialogButton resultButton)
		{
			return NativeMethods.XGameUiShowMessageDialogResult(async.InteropPtr, out resultButton);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00005A68 File Offset: 0x00003C68
		public static int XGameUiShowSendGameInviteAsync(XAsyncBlock async, XUserHandle requestingUser, string sessionConfigurationId, string sessionTemplateName, string sessionId, string invitationText, string customActivationContext)
		{
			IntPtr requestingUser2 = (requestingUser != null) ? requestingUser.Handle : IntPtr.Zero;
			return NativeMethods.XGameUiShowSendGameInviteAsync(async.InteropPtr, requestingUser2, sessionConfigurationId, sessionTemplateName, sessionId, invitationText, customActivationContext);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00005AA0 File Offset: 0x00003CA0
		public static int XGameUiShowSendGameInviteResult(XAsyncBlock async)
		{
			return NativeMethods.XGameUiShowSendGameInviteResult(async.InteropPtr);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00005AB0 File Offset: 0x00003CB0
		public static int XGameUiShowMultiplayerActivityGameInviteAsync(XAsyncBlock async, XUserHandle requestingUser)
		{
			IntPtr requestingUser2 = (requestingUser != null) ? requestingUser.Handle : IntPtr.Zero;
			return NativeMethods.XGameUiShowMultiplayerActivityGameInviteAsync(async.InteropPtr, requestingUser2);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00005AE0 File Offset: 0x00003CE0
		public static int XGameUiShowMultiplayerActivityGameInviteResult(XAsyncBlock async)
		{
			return NativeMethods.XGameUiShowMultiplayerActivityGameInviteResult(async.InteropPtr);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00005AF0 File Offset: 0x00003CF0
		public static int XGameUiShowPlayerProfileCardAsync(XAsyncBlock async, XUserHandle requestingUser, ulong targetPlayer)
		{
			IntPtr requestingUser2 = (requestingUser != null) ? requestingUser.Handle : IntPtr.Zero;
			return NativeMethods.XGameUiShowPlayerProfileCardAsync(async.InteropPtr, requestingUser2, targetPlayer);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00005B21 File Offset: 0x00003D21
		public static int XGameUiShowPlayerProfileCardResult(XAsyncBlock async)
		{
			return NativeMethods.XGameUiShowPlayerProfileCardResult(async.InteropPtr);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00005B30 File Offset: 0x00003D30
		public static int XGameUiShowAchievementsAsync(XAsyncBlock async, XUserHandle requestingUser, uint titleId)
		{
			IntPtr requestingUser2 = (requestingUser != null) ? requestingUser.Handle : IntPtr.Zero;
			return NativeMethods.XGameUiShowAchievementsAsync(async.InteropPtr, requestingUser2, titleId);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00005B61 File Offset: 0x00003D61
		public static int XGameUiShowAchievementsResult(XAsyncBlock async)
		{
			return NativeMethods.XGameUiShowAchievementsResult(async.InteropPtr);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00005B70 File Offset: 0x00003D70
		public static int XGameUiShowPlayerPickerAsync(XAsyncBlock async, XUserHandle requestingUser, string promptText, ulong[] selectFromPlayers, ulong[] preSelectedPlayers, uint minSelectionCount, uint maxSelectionCount)
		{
			IntPtr requestingUser2 = (requestingUser != null) ? requestingUser.Handle : IntPtr.Zero;
			uint preSelectedPlayersCount = (uint)((preSelectedPlayers != null) ? preSelectedPlayers.Length : 0);
			return NativeMethods.XGameUiShowPlayerPickerAsync(async.InteropPtr, requestingUser2, promptText, (uint)selectFromPlayers.Length, selectFromPlayers, preSelectedPlayersCount, preSelectedPlayers, minSelectionCount, maxSelectionCount);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00005BB8 File Offset: 0x00003DB8
		public static int XGameUiShowWebAuthenticationResult(XAsyncBlock async, byte[] buffer, out XGameUiWebAuthenticationResultData result)
		{
			result = null;
			IntPtr ptr;
			ulong num2;
			int num = NativeMethods.XGameUiShowWebAuthenticationResult(async.InteropPtr, (ulong)((long)buffer.Length), buffer, out ptr, out num2);
			if (HR.SUCCEEDED(num))
			{
				result = new XGameUiWebAuthenticationResultData((XGameUiWebAuthenticationResultData)Marshal.PtrToStructure(ptr, typeof(XGameUiWebAuthenticationResultData)));
			}
			return num;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00005C00 File Offset: 0x00003E00
		public static int XGameUiShowPlayerPickerResultCount(XAsyncBlock async, out uint resultPlayersCount)
		{
			return NativeMethods.XGameUiShowPlayerPickerResultCount(async.InteropPtr, out resultPlayersCount);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005C0E File Offset: 0x00003E0E
		public static int XGameUiShowPlayerPickerResult(XAsyncBlock async, ulong[] resultPlayers, out uint resultPlayerUsed)
		{
			return NativeMethods.XGameUiShowPlayerPickerResult(async.InteropPtr, (uint)resultPlayers.Length, resultPlayers, out resultPlayerUsed);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00005C20 File Offset: 0x00003E20
		public static int XGameUiShowErrorDialogAsync(XAsyncBlock async, int errorCode, string context)
		{
			return NativeMethods.XGameUiShowErrorDialogAsync(async.InteropPtr, errorCode, context);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00005C2F File Offset: 0x00003E2F
		public static int XGameUiShowErrorDialogResult(XAsyncBlock async)
		{
			return NativeMethods.XGameUiShowErrorDialogResult(async.InteropPtr);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00005C3C File Offset: 0x00003E3C
		public static int XGameUiSetNotificationPositionHint(XGameUiNotificationPositionHint position)
		{
			return NativeMethods.XGameUiSetNotificationPositionHint(position);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005C44 File Offset: 0x00003E44
		public static int XGameUiShowTextEntryAsync(XAsyncBlock async, string titleText, string descriptionText, string defaultText, XGameUiTextEntryInputScope inputScope, uint maxTextLength)
		{
			return NativeMethods.XGameUiShowTextEntryAsync(async.InteropPtr, titleText, descriptionText, defaultText, inputScope, maxTextLength);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005C58 File Offset: 0x00003E58
		public static int XGameUiShowTextEntryResultSize(XAsyncBlock async, out uint resultTextBufferSize)
		{
			return NativeMethods.XGameUiShowTextEntryResultSize(async.InteropPtr, out resultTextBufferSize);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005C68 File Offset: 0x00003E68
		public static int XGameUiShowTextEntryResult(XAsyncBlock async, uint resultTextBufferSize, out string resultTextBuffer)
		{
			resultTextBuffer = null;
			StringBuilder stringBuilder = new StringBuilder((int)resultTextBufferSize);
			uint num2;
			int num = NativeMethods.XGameUiShowTextEntryResult(async.InteropPtr, resultTextBufferSize, stringBuilder, out num2);
			if (HR.SUCCEEDED(num))
			{
				resultTextBuffer = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00005CA0 File Offset: 0x00003EA0
		public static int XGameUiShowWebAuthenticationAsync(XAsyncBlock async, XUserHandle requestingUser, string requestUri, string completeUri)
		{
			IntPtr requestingUser2 = (requestingUser != null) ? requestingUser.Handle : IntPtr.Zero;
			return NativeMethods.XGameUiShowWebAuthenticationAsync(async.InteropPtr, requestingUser2, requestUri, completeUri);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00005CD4 File Offset: 0x00003ED4
		public static int XGameUiShowWebAuthenticationWithOptionsAsync(XAsyncBlock async, XUserHandle requestingUser, string requestUri, string completionUri, XGameUiWebAuthenticationOptions options)
		{
			IntPtr requestingUser2 = (requestingUser != null) ? requestingUser.Handle : IntPtr.Zero;
			return NativeMethods.XGameUiShowWebAuthenticationWithOptionsAsync(async.InteropPtr, requestingUser2, requestUri, completionUri, options);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00005D08 File Offset: 0x00003F08
		public static int XGameUiShowWebAuthenticationResultSize(XAsyncBlock async, out ulong bufferSize)
		{
			return NativeMethods.XGameUiShowWebAuthenticationResultSize(async.InteropPtr, out bufferSize);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00005D16 File Offset: 0x00003F16
		public static void XGameUiTextEntryClose(XGameUiTextEntryHandle handle)
		{
			handle.Close();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00005D20 File Offset: 0x00003F20
		public static int XGameUiTextEntryGetExtents(XGameUiTextEntryHandle handle, out XGameUiTextEntryExtents extents)
		{
			extents = null;
			XGameUiTextEntryExtents interop = default(XGameUiTextEntryExtents);
			int num = NativeMethods.XGameUiTextEntryGetExtents(handle.Handle, out interop);
			if (HR.SUCCEEDED(num))
			{
				extents = new XGameUiTextEntryExtents(interop);
			}
			return num;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00005D58 File Offset: 0x00003F58
		public static int XGameUiTextEntryOpen(XGameUiTextEntryOptions options, uint maxLength, string initialText, uint cursorIndex, out XGameUiTextEntryHandle handle)
		{
			handle = null;
			IntPtr handle2;
			int num = NativeMethods.XGameUiTextEntryOpen(options.data, maxLength, initialText, cursorIndex, out handle2);
			if (HR.SUCCEEDED(num))
			{
				handle = new XGameUiTextEntryHandle(handle2);
			}
			return num;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00005D8C File Offset: 0x00003F8C
		public static int XGameUiTextEntryGetState(XGameUiTextEntryHandle handle, out XGameUiTextEntryChangeTypeFlags changeType, out uint cursorIndex, out uint imeClauseStartIndex, out uint imeClauseEndIndex, uint bufferSize, out string buffer)
		{
			buffer = null;
			StringBuilder stringBuilder = new StringBuilder((int)bufferSize);
			int num = NativeMethods.XGameUiTextEntryGetState(handle.Handle, out changeType, out cursorIndex, out imeClauseStartIndex, out imeClauseEndIndex, bufferSize, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				buffer = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00005DC9 File Offset: 0x00003FC9
		public static int XGameUiTextEntryUpdatePositionHint(XGameUiTextEntryHandle handle, XGameUiTextEntryPositionHint positionHint)
		{
			return NativeMethods.XGameUiTextEntryUpdatePositionHint(handle.Handle, positionHint);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00005DD7 File Offset: 0x00003FD7
		public static int XGameUiTextEntryUpdateVisibility(XGameUiTextEntryHandle handle, XGameUiTextEntryVisibilityFlags visibilityFlags)
		{
			return NativeMethods.XGameUiTextEntryUpdateVisibility(handle.Handle, visibilityFlags);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005DE5 File Offset: 0x00003FE5
		public static int XLaunchUri(XUserHandle requestingUser, string uri)
		{
			return NativeMethods.XLaunchUri((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, uri);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00005E04 File Offset: 0x00004004
		public static int XNetworkingGetConnectivityHint(out XNetworkingConnectivityHint getConnectivityHint)
		{
			getConnectivityHint = null;
			XNetworkingConnectivityHint interop;
			int num = NativeMethods.XNetworkingGetConnectivityHint(out interop);
			if (HR.SUCCEEDED(num))
			{
				getConnectivityHint = new XNetworkingConnectivityHint(interop);
			}
			return num;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00005E2B File Offset: 0x0000402B
		public static int XNetworkingQueryConfigurationSetting(XNetworkingConfigurationSetting getConfigurationSetting, out ulong value)
		{
			return NativeMethods.XNetworkingQueryConfigurationSetting(getConfigurationSetting, out value);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00005E34 File Offset: 0x00004034
		public static int XNetworkingQueryPreferredLocalUdpMultiplayerPort(out ushort value)
		{
			return NativeMethods.XNetworkingQueryPreferredLocalUdpMultiplayerPort(out value);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00005E3C File Offset: 0x0000403C
		public static int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(XAsyncBlock async)
		{
			return NativeMethods.XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(async.InteropPtr);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00005E49 File Offset: 0x00004049
		public static int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsyncResult(XAsyncBlock async, out ushort preferredLocalUdpMultiplayerPort)
		{
			return NativeMethods.XNetworkingQueryPreferredLocalUdpMultiplayerPortAsyncResult(async.InteropPtr, out preferredLocalUdpMultiplayerPort);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00005E57 File Offset: 0x00004057
		public static int XNetworkingQuerySecurityInformationForUrlAsync(string url, XAsyncBlock async)
		{
			return NativeMethods.XNetworkingQuerySecurityInformationForUrlAsync(url, async.InteropPtr);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005E65 File Offset: 0x00004065
		public static int XNetworkingQuerySecurityInformationForUrlAsyncResultSize(XAsyncBlock async, out ulong securityInformationBufferByteCount)
		{
			return NativeMethods.XNetworkingQuerySecurityInformationForUrlAsyncResultSize(async.InteropPtr, out securityInformationBufferByteCount);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005E74 File Offset: 0x00004074
		public static int XNetworkingQuerySecurityInformationForUrlAsyncResult(XAsyncBlock async, byte[] securityInformationBuffer, out ulong securityInformationBufferByteCountUsed, out XNetworkingSecurityInformation securityInformation)
		{
			securityInformation = new XNetworkingSecurityInformation();
			IntPtr securityInformationInteropPtr;
			int num = NativeMethods.XNetworkingQuerySecurityInformationForUrlAsyncResult(async.InteropPtr, (ulong)((long)securityInformationBuffer.Length), out securityInformationBufferByteCountUsed, securityInformationBuffer, out securityInformationInteropPtr);
			if (HR.SUCCEEDED(num))
			{
				SDK.MarshalXNetworkingSecurityInformationInteropToManaged(securityInformationInteropPtr, ref securityInformation);
			}
			return num;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00005EAA File Offset: 0x000040AA
		public static int XNetworkingQuerySecurityInformationForUrlUtf16Async(string url, XAsyncBlock async)
		{
			return NativeMethods.XNetworkingQuerySecurityInformationForUrlUtf16Async(url, async.InteropPtr);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00005EB8 File Offset: 0x000040B8
		public static int XNetworkingQuerySecurityInformationForUrlUtf16AsyncResultSize(XAsyncBlock async, out ulong securityInformationBufferByteCount)
		{
			return NativeMethods.XNetworkingQuerySecurityInformationForUrlUtf16AsyncResultSize(async.InteropPtr, out securityInformationBufferByteCount);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00005EC8 File Offset: 0x000040C8
		public static int XNetworkingQuerySecurityInformationForUrlUtf16AsyncResult(XAsyncBlock async, byte[] securityInformationBuffer, out ulong securityInformationBufferByteCountUsed, out XNetworkingSecurityInformation securityInformation)
		{
			securityInformation = new XNetworkingSecurityInformation();
			IntPtr securityInformationInteropPtr;
			int num = NativeMethods.XNetworkingQuerySecurityInformationForUrlUtf16AsyncResult(async.InteropPtr, (ulong)((long)securityInformationBuffer.Length), out securityInformationBufferByteCountUsed, securityInformationBuffer, out securityInformationInteropPtr);
			if (HR.SUCCEEDED(num))
			{
				SDK.MarshalXNetworkingSecurityInformationInteropToManaged(securityInformationInteropPtr, ref securityInformation);
			}
			return num;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005F00 File Offset: 0x00004100
		public static int XNetworkingQueryStatistics(XNetworkingStatisticsType statisticsType, out XNetworkingStatisticsBuffer statisticsBuffer)
		{
			XNetworkingStatisticsBuffer interop = default(XNetworkingStatisticsBuffer);
			statisticsBuffer = null;
			int num = NativeMethods.XNetworkingQueryStatistics(statisticsType, out interop);
			if (HR.SUCCEEDED(num))
			{
				statisticsBuffer = new XNetworkingStatisticsBuffer(interop);
			}
			return num;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005F30 File Offset: 0x00004130
		public static int XNetworkingRegisterConnectivityHintChanged(XTaskQueueHandle queue, IntPtr context, XNetworkingConnectivityHintChangedCallback callback, out XNetworkingRegisterConnectivityHintChangedCallbackToken token)
		{
			XNetworkingConnectivityHintChangedCallback callback2 = delegate(IntPtr context, XNetworkingConnectivityHint connectivityHint)
			{
				callback(context, new XNetworkingConnectivityHint(connectivityHint));
			};
			ulong token2 = 0UL;
			IntPtr taskQueueHandle = (queue != null) ? queue.Handle : IntPtr.Zero;
			token = new XNetworkingRegisterConnectivityHintChangedCallbackToken(callback2, context2);
			int num = NativeMethods.XNetworkingRegisterConnectivityHintChanged(taskQueueHandle, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.interop.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005FB6 File Offset: 0x000041B6
		public static bool XNetworkingUnregisterConnectivityHintChanged(XNetworkingRegisterConnectivityHintChangedCallbackToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00005FC0 File Offset: 0x000041C0
		public static int XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged(XTaskQueueHandle queue, IntPtr context, XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, out XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken token)
		{
			XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback2 = delegate(IntPtr context, ushort preferredLocalUdpMultiplayerPort)
			{
				callback(context, preferredLocalUdpMultiplayerPort);
			};
			ulong token2 = 0UL;
			token = new XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken(callback2, context2);
			int num = NativeMethods.XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.interop.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00006046 File Offset: 0x00004246
		public static bool XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00006050 File Offset: 0x00004250
		public static int XNetworkingVerifyServerCertificate(IntPtr requestHandle, XNetworkingSecurityInformation securityInformation)
		{
			IntPtr zero;
			SDK.MarshalXNetworkingSecurityInformationManagedToInterop(securityInformation, out zero);
			int result = NativeMethods.XNetworkingVerifyServerCertificate(requestHandle, zero);
			if (zero != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(zero);
				zero = IntPtr.Zero;
			}
			return result;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00006088 File Offset: 0x00004288
		public static void MarshalXNetworkingSecurityInformationInteropToManaged(IntPtr securityInformationInteropPtr, ref XNetworkingSecurityInformation securityInformation)
		{
			XNetworkingSecurityInformation xnetworkingSecurityInformation = (XNetworkingSecurityInformation)Marshal.PtrToStructure(securityInformationInteropPtr, typeof(XNetworkingSecurityInformation));
			int num = Convert.ToInt32(xnetworkingSecurityInformation.thumbprintCount);
			securityInformation.EnabledHttpSecurityProtocolFlags = xnetworkingSecurityInformation.enabledHttpSecurityProtocolFlags;
			securityInformation.Thumbprints = new XNetworkingThumbprint[num];
			long num2 = xnetworkingSecurityInformation.thumbprints.ToInt64();
			int num3 = Marshal.SizeOf(typeof(XNetworkingThumbprint));
			for (int i = 0; i < num; i++)
			{
				XNetworkingThumbprint xnetworkingThumbprint = (XNetworkingThumbprint)Marshal.PtrToStructure(new IntPtr(num2 + (long)(i * num3)), typeof(XNetworkingThumbprint));
				securityInformation.Thumbprints[i] = new XNetworkingThumbprint();
				securityInformation.Thumbprints[i].ThumbprintType = xnetworkingThumbprint.thumbprintType;
				securityInformation.Thumbprints[i].ThumbprintBuffer = new byte[xnetworkingThumbprint.thumbprintBufferByteCount];
				Marshal.Copy(xnetworkingThumbprint.thumbprintBuffer, securityInformation.Thumbprints[i].ThumbprintBuffer, 0, securityInformation.Thumbprints[i].ThumbprintBuffer.Length);
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00006194 File Offset: 0x00004394
		public static void MarshalXNetworkingSecurityInformationManagedToInterop(XNetworkingSecurityInformation securityInformation, out IntPtr securityInformationInteropPtr)
		{
			int num = Marshal.SizeOf(typeof(XNetworkingSecurityInformation));
			IntPtr intPtr = new IntPtr(num);
			num += Marshal.SizeOf(typeof(XNetworkingThumbprint)) * Convert.ToInt32(securityInformation.Thumbprints.Length);
			IntPtr pointer = new IntPtr(num);
			foreach (XNetworkingThumbprint xnetworkingThumbprint in securityInformation.Thumbprints)
			{
				num += Convert.ToInt32(xnetworkingThumbprint.ThumbprintBuffer.Length);
			}
			securityInformationInteropPtr = Marshal.AllocHGlobal(Convert.ToInt32(num));
			IntPtr intPtr2 = securityInformationInteropPtr + intPtr.ToInt32();
			intPtr = securityInformationInteropPtr + intPtr.ToInt32();
			pointer = securityInformationInteropPtr + pointer.ToInt32();
			XNetworkingThumbprint xnetworkingThumbprint2 = default(XNetworkingThumbprint);
			for (int j = 0; j < securityInformation.Thumbprints.Length; j++)
			{
				xnetworkingThumbprint2.thumbprintType = securityInformation.Thumbprints[j].ThumbprintType;
				xnetworkingThumbprint2.thumbprintBufferByteCount = Convert.ToUInt64(securityInformation.Thumbprints[j].ThumbprintBuffer.Length);
				xnetworkingThumbprint2.thumbprintBuffer = new IntPtr(pointer.ToInt64());
				Marshal.Copy(securityInformation.Thumbprints[j].ThumbprintBuffer, 0, xnetworkingThumbprint2.thumbprintBuffer, securityInformation.Thumbprints[j].ThumbprintBuffer.Length);
				Marshal.StructureToPtr<XNetworkingThumbprint>(xnetworkingThumbprint2, intPtr2, false);
				intPtr2 += Marshal.SizeOf(typeof(XNetworkingThumbprint));
				pointer += securityInformation.Thumbprints[j].ThumbprintBuffer.Length;
			}
			Marshal.StructureToPtr<XNetworkingSecurityInformation>(new XNetworkingSecurityInformation
			{
				enabledHttpSecurityProtocolFlags = securityInformation.EnabledHttpSecurityProtocolFlags,
				thumbprintCount = Convert.ToUInt64(securityInformation.Thumbprints.Length),
				thumbprints = new IntPtr(intPtr.ToInt64())
			}, securityInformationInteropPtr, false);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00006360 File Offset: 0x00004560
		private static int ProcessChunkSelector(XPackageChunkSelector[] selectors, ref XPackageChunkSelectorInterop[] nativeSelectors, out List<IntPtr> stringsToFree)
		{
			stringsToFree = new List<IntPtr>();
			for (int i = 0; i < selectors.Length; i++)
			{
				XPackageChunkSelector xpackageChunkSelector = selectors[i];
				nativeSelectors[i].type = xpackageChunkSelector.Type;
				switch (xpackageChunkSelector.Type)
				{
				case XPackageChunkSelectorType.Language:
				case XPackageChunkSelectorType.Tag:
				case XPackageChunkSelectorType.Feature:
					nativeSelectors[i].languageOrTagOrFeature = InteropHelpers.MarshalStringUtf8(xpackageChunkSelector.LanguageTagOrFeature);
					stringsToFree.Add(nativeSelectors[i].languageOrTagOrFeature);
					break;
				case XPackageChunkSelectorType.Chunk:
					nativeSelectors[i].chunkId = xpackageChunkSelector.ChunkId;
					break;
				default:
					return -2147024809;
				}
			}
			return 0;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00006408 File Offset: 0x00004608
		public static int XPackageCreateInstallationMonitor(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, XTaskQueueHandle queue, out XPackageInstallationMonitorHandle installationMonitor)
		{
			int num = 0;
			installationMonitor = null;
			IntPtr queue2 = (queue != null) ? queue.Handle : IntPtr.Zero;
			if (selectors != null)
			{
				XPackageChunkSelectorInterop[] array = new XPackageChunkSelectorInterop[selectors.Length];
				List<IntPtr> list = new List<IntPtr>();
				try
				{
					num = SDK.ProcessChunkSelector(selectors, ref array, out list);
					if (HR.SUCCEEDED(num))
					{
						IntPtr handle;
						num = NativeMethods.XPackageCreateInstallationMonitor(packageIdentifier, (uint)array.Length, array, minimumUpdateIntervalMs, queue2, out handle);
						if (HR.SUCCEEDED(num))
						{
							installationMonitor = new XPackageInstallationMonitorHandle(handle);
						}
					}
					return num;
				}
				finally
				{
					foreach (IntPtr ptr in list)
					{
						Marshal.FreeCoTaskMem(ptr);
					}
				}
			}
			IntPtr handle2;
			num = NativeMethods.XPackageCreateInstallationMonitor(packageIdentifier, 0U, null, minimumUpdateIntervalMs, queue2, out handle2);
			if (HR.SUCCEEDED(num))
			{
				installationMonitor = new XPackageInstallationMonitorHandle(handle2);
			}
			return num;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000064E8 File Offset: 0x000046E8
		public static void XPackageCloseInstallationMonitorHandle(XPackageInstallationMonitorHandle installationMonitor)
		{
			installationMonitor.Close();
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000064F0 File Offset: 0x000046F0
		public static int XPackageGetCurrentProcessPackageIdentifier(out string buffer)
		{
			buffer = null;
			StringBuilder stringBuilder = new StringBuilder(SDK.XPACKAGE_IDENTIFIER_MAX_LENGTH);
			int num = NativeMethods.XPackageGetCurrentProcessPackageIdentifier((ulong)((long)SDK.XPACKAGE_IDENTIFIER_MAX_LENGTH), stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				buffer = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006527 File Offset: 0x00004727
		public static bool XPackageIsPackagedProcess()
		{
			return NativeMethods.XPackageIsPackagedProcess();
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00006530 File Offset: 0x00004730
		public static void XPackageGetInstallationProgress(XPackageInstallationMonitorHandle installationMonitor, out XPackageInstallationProgress progress)
		{
			XPackageInstallationProgress interop;
			NativeMethods.XPackageGetInstallationProgress(installationMonitor.Handle, out interop);
			progress = new XPackageInstallationProgress(interop);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00006552 File Offset: 0x00004752
		public static void XPackageUpdateInstallationMonitor(XPackageInstallationMonitorHandle installationMonitor)
		{
			NativeMethods.XPackageUpdateInstallationMonitor(installationMonitor.Handle);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00006560 File Offset: 0x00004760
		public static int XPackageGetUserLocale(out string locale)
		{
			locale = null;
			StringBuilder stringBuilder = new StringBuilder(SDK.LOCALE_NAME_MAX_LENGTH);
			int num = NativeMethods.XPackageGetUserLocale((ulong)((long)SDK.LOCALE_NAME_MAX_LENGTH), stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				locale = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00006598 File Offset: 0x00004798
		public static int XPackageFindChunkAvailability(string packageIdentifier, XPackageChunkSelector[] selectors, out XPackageChunkAvailability availability)
		{
			availability = XPackageChunkAvailability.Ready;
			int num = 0;
			if (selectors != null)
			{
				List<IntPtr> list = new List<IntPtr>();
				try
				{
					XPackageChunkSelectorInterop[] array = new XPackageChunkSelectorInterop[selectors.Length];
					num = SDK.ProcessChunkSelector(selectors, ref array, out list);
					if (HR.SUCCEEDED(num))
					{
						num = NativeMethods.XPackageFindChunkAvailability(packageIdentifier, (uint)array.Length, array, out availability);
					}
					return num;
				}
				finally
				{
					foreach (IntPtr ptr in list)
					{
						Marshal.FreeCoTaskMem(ptr);
					}
				}
			}
			num = NativeMethods.XPackageFindChunkAvailability(packageIdentifier, 0U, null, out availability);
			return num;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00006634 File Offset: 0x00004834
		public static int XPackageChangeChunkInstallOrder(string packageIdentifier, XPackageChunkSelector[] selectors)
		{
			int num = 0;
			List<IntPtr> list = new List<IntPtr>();
			try
			{
				XPackageChunkSelectorInterop[] array = new XPackageChunkSelectorInterop[selectors.Length];
				num = SDK.ProcessChunkSelector(selectors, ref array, out list);
				if (HR.SUCCEEDED(num))
				{
					num = NativeMethods.XPackageChangeChunkInstallOrder(packageIdentifier, (uint)array.Length, array);
				}
			}
			finally
			{
				foreach (IntPtr ptr in list)
				{
					Marshal.FreeCoTaskMem(ptr);
				}
			}
			return num;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000066C0 File Offset: 0x000048C0
		public static int XPackageInstallChunks(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, bool suppressUserConfirmation, XTaskQueueHandle queue, out XPackageInstallationMonitorHandle installationMonitor)
		{
			List<IntPtr> list = new List<IntPtr>();
			int num = 0;
			try
			{
				installationMonitor = null;
				XPackageChunkSelectorInterop[] array = new XPackageChunkSelectorInterop[selectors.Length];
				num = SDK.ProcessChunkSelector(selectors, ref array, out list);
				if (HR.SUCCEEDED(num))
				{
					IntPtr queue2 = (queue != null) ? queue.Handle : IntPtr.Zero;
					IntPtr handle;
					num = NativeMethods.XPackageInstallChunks(packageIdentifier, (uint)array.Length, array, minimumUpdateIntervalMs, suppressUserConfirmation, queue2, out handle);
					if (HR.SUCCEEDED(num))
					{
						installationMonitor = new XPackageInstallationMonitorHandle(handle);
					}
				}
			}
			finally
			{
				foreach (IntPtr ptr in list)
				{
					Marshal.FreeCoTaskMem(ptr);
				}
			}
			return num;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00006780 File Offset: 0x00004980
		public static int XPackageInstallChunksAsync(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, bool suppressUserConfirmation, XAsyncBlock async)
		{
			XPackageChunkSelectorInterop[] array = new XPackageChunkSelectorInterop[selectors.Length];
			int num = 0;
			List<IntPtr> list = new List<IntPtr>();
			try
			{
				num = SDK.ProcessChunkSelector(selectors, ref array, out list);
				if (HR.SUCCEEDED(num))
				{
					num = NativeMethods.XPackageInstallChunksAsync(packageIdentifier, (uint)array.Length, array, minimumUpdateIntervalMs, suppressUserConfirmation, async.InteropPtr);
				}
			}
			finally
			{
				foreach (IntPtr ptr in list)
				{
					Marshal.FreeCoTaskMem(ptr);
				}
			}
			return num;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006814 File Offset: 0x00004A14
		public static int XPackageInstallChunksResult(XAsyncBlock asyncBlock, out XPackageInstallationMonitorHandle installationMonitor)
		{
			installationMonitor = null;
			IntPtr handle;
			int num = NativeMethods.XPackageInstallChunksResult(asyncBlock.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				installationMonitor = new XPackageInstallationMonitorHandle(handle);
			}
			return num;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006844 File Offset: 0x00004A44
		public static int XPackageEstimateDownloadSize(string packageIdentifier, XPackageChunkSelector[] selectors, out ulong downloadSize, out bool shouldPresentUserConfirmation)
		{
			downloadSize = 0UL;
			shouldPresentUserConfirmation = false;
			int num = 0;
			List<IntPtr> list = new List<IntPtr>();
			try
			{
				XPackageChunkSelectorInterop[] array = new XPackageChunkSelectorInterop[selectors.Length];
				num = SDK.ProcessChunkSelector(selectors, ref array, out list);
				if (HR.SUCCEEDED(num))
				{
					num = NativeMethods.XPackageEstimateDownloadSize(packageIdentifier, (uint)array.Length, array, out downloadSize, out shouldPresentUserConfirmation);
				}
			}
			finally
			{
				foreach (IntPtr ptr in list)
				{
					Marshal.FreeCoTaskMem(ptr);
				}
			}
			return num;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000068D8 File Offset: 0x00004AD8
		public static int XPackageUninstallChunks(string packageIdentifier, XPackageChunkSelector[] selectors)
		{
			XPackageChunkSelectorInterop[] array = new XPackageChunkSelectorInterop[selectors.Length];
			int num = 0;
			List<IntPtr> list = new List<IntPtr>();
			try
			{
				num = SDK.ProcessChunkSelector(selectors, ref array, out list);
				if (HR.SUCCEEDED(num))
				{
					num = NativeMethods.XPackageUninstallChunks(packageIdentifier, (uint)array.Length, array);
				}
			}
			finally
			{
				foreach (IntPtr ptr in list)
				{
					Marshal.FreeCoTaskMem(ptr);
				}
			}
			return num;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00006964 File Offset: 0x00004B64
		public static void XPackageCloseMountHandle(XPackageMountHandle mount)
		{
			mount.Close();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000696C File Offset: 0x00004B6C
		[MonoPInvokeCallback(typeof(XPackageChunkAvailabilityCallback))]
		private static bool OnPackageChunkAvailability(IntPtr context, XPackageChunkSelectorInterop selector, XPackageChunkAvailability availability)
		{
			CallbackWrapper<XPackageChunkAvailabilityCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XPackageChunkAvailabilityCallback>;
			return callbackWrapper.Callback(callbackWrapper.Context, selector, availability);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000069A0 File Offset: 0x00004BA0
		public static int XPackageEnumerateChunkAvailability(string packageIdentifier, XPackageChunkSelectorType type, IntPtr context, XPackageChunkAvailabilityCallback callback)
		{
			int result;
			using (CallbackWrapper<XPackageChunkAvailabilityCallback> callbackWrapper = new CallbackWrapper<XPackageChunkAvailabilityCallback>((IntPtr _context, XPackageChunkSelectorInterop _selector, XPackageChunkAvailability _availability) => callback(_context, new XPackageChunkSelector(_selector), _availability), context, new XPackageChunkAvailabilityCallback(SDK.OnPackageChunkAvailability)))
			{
				result = NativeMethods.XPackageEnumerateChunkAvailability(packageIdentifier, type, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00006A08 File Offset: 0x00004C08
		[MonoPInvokeCallback(typeof(XPackageFeatureEnumerationCallbackInterop))]
		private static bool OnXPackageFeature(IntPtr context, XPackageFeature feature)
		{
			CallbackWrapper<XPackageFeatureEnumerationCallbackInterop> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XPackageFeatureEnumerationCallbackInterop>;
			return callbackWrapper.Callback(callbackWrapper.Context, feature);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00006A3C File Offset: 0x00004C3C
		public static int XPackageEnumerateFeatures(string packageIdentifier, IntPtr context, XPackageFeatureEnumerationCallback callback)
		{
			int result;
			using (CallbackWrapper<XPackageFeatureEnumerationCallbackInterop> callbackWrapper = new CallbackWrapper<XPackageFeatureEnumerationCallbackInterop>(delegate(IntPtr _context, XPackageFeature _featureInterop)
			{
				XPackageFeature feature = new XPackageFeature(_featureInterop);
				return callback(_context, feature);
			}, context, new XPackageFeatureEnumerationCallbackInterop(SDK.OnXPackageFeature)))
			{
				result = NativeMethods.XPackageEnumerateFeatures(packageIdentifier, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00006AA4 File Offset: 0x00004CA4
		[MonoPInvokeCallback(typeof(XPackageEnumerationCallback))]
		private static bool OnPackageEnumeration(IntPtr context, XPackageDetails details)
		{
			CallbackWrapper<XPackageEnumerationCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XPackageEnumerationCallback>;
			return callbackWrapper.Callback(callbackWrapper.Context, details);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00006AD8 File Offset: 0x00004CD8
		public static int XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, IntPtr context, XPackageEnumerationCallback callback)
		{
			int result;
			using (CallbackWrapper<XPackageEnumerationCallback> callbackWrapper = new CallbackWrapper<XPackageEnumerationCallback>(delegate(IntPtr _context, XPackageDetails _details)
			{
				XPackageDetails details = new XPackageDetails(_details);
				return callback(_context, details);
			}, context, new XPackageEnumerationCallback(SDK.OnPackageEnumeration)))
			{
				result = NativeMethods.XPackageEnumeratePackages(kind, scope, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00006B40 File Offset: 0x00004D40
		public static int XPackageGetMountPathSize(XPackageMountHandle mount, out ulong pathSize)
		{
			return NativeMethods.XPackageGetMountPathSize(mount.Handle, out pathSize);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00006B50 File Offset: 0x00004D50
		public static int XPackageGetMountPath(XPackageMountHandle mount, ulong pathSize, out string path)
		{
			path = null;
			StringBuilder stringBuilder = new StringBuilder((int)pathSize);
			int num = NativeMethods.XPackageGetMountPath(mount.Handle, pathSize, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				path = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00006B88 File Offset: 0x00004D88
		public static int XPackageGetWriteStats(out XPackageWriteStats writeStats)
		{
			writeStats = null;
			XPackageWriteStats interop = default(XPackageWriteStats);
			int num = NativeMethods.XPackageGetWriteStats(out interop);
			if (HR.SUCCEEDED(num))
			{
				writeStats = new XPackageWriteStats(interop);
			}
			return num;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00006BB7 File Offset: 0x00004DB7
		public static int XPackageMountWithUiAsync(string packageIdentifier, XAsyncBlock asyncBlock)
		{
			return NativeMethods.XPackageMountWithUiAsync(packageIdentifier, asyncBlock.InteropPtr);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00006BC8 File Offset: 0x00004DC8
		public static int XPackageMountWithUiResult(XAsyncBlock async, out XPackageMountHandle mount)
		{
			mount = null;
			IntPtr handle;
			int num = NativeMethods.XPackageMountWithUiResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				mount = new XPackageMountHandle(handle);
			}
			return num;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00006BF8 File Offset: 0x00004DF8
		public static int XPackageRegisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitorHandle, IntPtr context, XPackageInstallationProgressCallback callback, out XPackageRegisterInstallationProgressChangedToken token)
		{
			XPackageInstallationProgressCallback callback2 = delegate(IntPtr _context, IntPtr _monitor)
			{
				callback(_context, installationMonitorHandle);
			};
			token = new XPackageRegisterInstallationProgressChangedToken(installationMonitorHandle, callback2, context);
			ulong token2;
			int num = NativeMethods.XPackageRegisterInstallationProgressChanged(installationMonitorHandle.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00006C7C File Offset: 0x00004E7C
		public static int XPackageRegisterPackageInstalled(XTaskQueueHandle queue, IntPtr context, XPackageInstalledCallback callback, out XPackageRegisterPackageInstalledToken token)
		{
			XPackageInstalledCallback callback2 = delegate(IntPtr _context, XPackageDetails _details)
			{
				callback(_context, new XPackageDetails(_details));
			};
			token = new XPackageRegisterPackageInstalledToken(callback2, context);
			ulong token2;
			int num = NativeMethods.XPackageRegisterPackageInstalled(queue.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00006CEA File Offset: 0x00004EEA
		public static int XPackageUninstallUWPInstance(string packageName)
		{
			return NativeMethods.XPackageUninstallUWPInstance(packageName);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00006CF2 File Offset: 0x00004EF2
		public static bool XPackageUninstallPackage(string packageIdentifier)
		{
			return NativeMethods.XPackageUninstallPackage(packageIdentifier);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00006CFA File Offset: 0x00004EFA
		public static bool XPackageUnregisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XPackageRegisterInstallationProgressChangedToken token, bool wait)
		{
			return token.Unregister(installationMonitor, wait);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00006D04 File Offset: 0x00004F04
		public static bool XPackageUnregisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XPackageRegisterInstallationProgressChangedToken token)
		{
			return SDK.XPackageUnregisterInstallationProgressChanged(installationMonitor, token, true);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00006D0E File Offset: 0x00004F0E
		public static bool XPackageUnregisterPackageInstalled(XPackageRegisterPackageInstalledToken token)
		{
			return SDK.XPackageUnregisterPackageInstalled(token, true);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00006D17 File Offset: 0x00004F17
		public static bool XPackageUnregisterPackageInstalled(XPackageRegisterPackageInstalledToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00006D20 File Offset: 0x00004F20
		public static int XPersistentLocalStorageGetPathSize(out ulong pathSize)
		{
			return NativeMethods.XPersistentLocalStorageGetPathSize(out pathSize);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00006D28 File Offset: 0x00004F28
		public static int XPersistentLocalStorageGetPath(ulong pathSize, out string path)
		{
			path = null;
			ulong num = 0UL;
			byte[] array = new byte[pathSize];
			int num2 = NativeMethods.XPersistentLocalStorageGetPath(pathSize, array, out num);
			if (HR.SUCCEEDED(num2))
			{
				path = Encoding.UTF8.GetString(array, 0, (int)num).TrimEnd('\0');
			}
			return num2;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00006D6C File Offset: 0x00004F6C
		public static int XPersistentLocalStorageGetSpaceInfo(out XPersistentLocalStorageSpaceInfo spaceInfo)
		{
			spaceInfo = null;
			XPersistentLocalStorageSpaceInfo interop = default(XPersistentLocalStorageSpaceInfo);
			int num = NativeMethods.XPersistentLocalStorageGetSpaceInfo(out interop);
			if (HR.SUCCEEDED(num))
			{
				spaceInfo = new XPersistentLocalStorageSpaceInfo(interop);
			}
			return num;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00006D9B File Offset: 0x00004F9B
		public static int XPersistentLocalStoragePromptUserForSpaceAsync(ulong requestedBytes, XAsyncBlock asyncBlock)
		{
			return NativeMethods.XPersistentLocalStoragePromptUserForSpaceAsync(requestedBytes, asyncBlock.InteropPtr);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00006DA9 File Offset: 0x00004FA9
		public static int XPersistentLocalStoragePromptUserForSpaceResult(XAsyncBlock asyncBlock)
		{
			return NativeMethods.XPersistentLocalStoragePromptUserForSpaceResult(asyncBlock.InteropPtr);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00006DB8 File Offset: 0x00004FB8
		[MonoPInvokeCallback(typeof(XSpeechSynthesizerInstalledVoicesCallback))]
		private static bool OnSpeechSynthesizerInstalledVoicesCallback(ref XSpeechSynthesizerVoiceInformation information, IntPtr context)
		{
			return (GCHandle.FromIntPtr(context).Target as CallbackWrapper<XSpeechSynthesizerInstalledVoicesCallback>).Callback(ref information, context);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00006DE4 File Offset: 0x00004FE4
		public static int XSpeechSynthesizerEnumerateInstalledVoices(IntPtr context, XSpeechSynthesizerInstalledVoicesCallback callback)
		{
			int result;
			using (CallbackWrapper<XSpeechSynthesizerInstalledVoicesCallback> callbackWrapper = new CallbackWrapper<XSpeechSynthesizerInstalledVoicesCallback>(delegate(ref XSpeechSynthesizerVoiceInformation _information, IntPtr _context)
			{
				XSpeechSynthesizerVoiceInformation xspeechSynthesizerVoiceInformation = new XSpeechSynthesizerVoiceInformation(_information);
				return callback(ref xspeechSynthesizerVoiceInformation, _context);
			}, context, new XSpeechSynthesizerInstalledVoicesCallback(SDK.OnSpeechSynthesizerInstalledVoicesCallback)))
			{
				result = NativeMethods.XSpeechSynthesizerEnumerateInstalledVoices(callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00006E4C File Offset: 0x0000504C
		public static int XSpeechSynthesizerCreate(out XSpeechSynthesizerHandle speechSynthesizer)
		{
			speechSynthesizer = null;
			IntPtr handle;
			int num = NativeMethods.XSpeechSynthesizerCreate(out handle);
			if (HR.SUCCEEDED(num))
			{
				speechSynthesizer = new XSpeechSynthesizerHandle(handle);
			}
			return num;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00006E73 File Offset: 0x00005073
		public static int XSpeechSynthesizerCloseHandle(XSpeechSynthesizerHandle speechSynthesizer)
		{
			speechSynthesizer.Close();
			return speechSynthesizer.CloseResult;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00006E81 File Offset: 0x00005081
		public static int XSpeechSynthesizerSetDefaultVoice(XSpeechSynthesizerHandle speechSynthesizer)
		{
			return NativeMethods.XSpeechSynthesizerSetDefaultVoice(speechSynthesizer.Handle);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00006E8E File Offset: 0x0000508E
		public static int XSpeechSynthesizerSetCustomVoice(XSpeechSynthesizerHandle speechSynthesizer, string voiceId)
		{
			return NativeMethods.XSpeechSynthesizerSetCustomVoice(speechSynthesizer.Handle, voiceId);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00006E9C File Offset: 0x0000509C
		public static int XSpeechSynthesizerCreateStreamFromText(XSpeechSynthesizerHandle speechSynthesizer, string text, out XSpeechSynthesizerStreamHandle speechSynthesisStream)
		{
			speechSynthesisStream = null;
			IntPtr handle;
			int num = NativeMethods.XSpeechSynthesizerCreateStreamFromText(speechSynthesizer.Handle, text, out handle);
			if (HR.SUCCEEDED(num))
			{
				speechSynthesisStream = new XSpeechSynthesizerStreamHandle(handle);
			}
			return num;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00006ECC File Offset: 0x000050CC
		public static int XSpeechSynthesizerCreateStreamFromSsml(XSpeechSynthesizerHandle speechSynthesizer, string ssml, out XSpeechSynthesizerStreamHandle speechSynthesisStream)
		{
			speechSynthesisStream = null;
			IntPtr handle;
			int num = NativeMethods.XSpeechSynthesizerCreateStreamFromSsml(speechSynthesizer.Handle, ssml, out handle);
			if (HR.SUCCEEDED(num))
			{
				speechSynthesisStream = new XSpeechSynthesizerStreamHandle(handle);
			}
			return num;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00006EFA File Offset: 0x000050FA
		public static int XSpeechSynthesizerCloseStreamHandle(XSpeechSynthesizerStreamHandle speechSynthesisStream)
		{
			speechSynthesisStream.Close();
			return speechSynthesisStream.CloseResult;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00006F08 File Offset: 0x00005108
		public static int XSpeechSynthesizerGetStreamDataSize(XSpeechSynthesizerStreamHandle speechSynthesisStream, out ulong bufferSize)
		{
			return NativeMethods.XSpeechSynthesizerGetStreamDataSize(speechSynthesisStream.Handle, out bufferSize);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00006F16 File Offset: 0x00005116
		public static int XSpeechSynthesizerGetStreamData(XSpeechSynthesizerStreamHandle speechSynthesisStream, byte[] buffer, out ulong bufferUsed)
		{
			return NativeMethods.XSpeechSynthesizerGetStreamData(speechSynthesisStream.Handle, (ulong)((long)buffer.Length), buffer, out bufferUsed);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00006F2C File Offset: 0x0000512C
		public static int XStoreCreateContext(XUserHandle user, out XStoreContext storeContext)
		{
			storeContext = null;
			IntPtr user2 = (user != null) ? user.Handle : IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			int num = NativeMethods.XStoreCreateContext(user2, out zero);
			if (HR.SUCCEEDED(num))
			{
				storeContext = new XStoreContext(zero);
			}
			return num;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00006F6F File Offset: 0x0000516F
		public static int XStoreCreateContext(out XStoreContext storeContext)
		{
			return SDK.XStoreCreateContext(null, out storeContext);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00006F78 File Offset: 0x00005178
		public static void XStoreCloseContextHandle(XStoreContext storeContext)
		{
			storeContext.Close();
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00006F80 File Offset: 0x00005180
		public static void XStoreCloseLicenseHandle(XStoreLicense storeLicense)
		{
			storeLicense.Close();
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00006F88 File Offset: 0x00005188
		public static int XStoreAcquireLicenseForDurablesAsync(XStoreContext context, string storeId, XAsyncBlock async)
		{
			return NativeMethods.XStoreAcquireLicenseForDurablesAsync(context.Handle, storeId, async.InteropPtr);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00006F9C File Offset: 0x0000519C
		public static int XStoreAcquireLicenseForDurablesResult(XAsyncBlock async, out XStoreLicense storeLicense)
		{
			storeLicense = null;
			IntPtr handle;
			int num = NativeMethods.XStoreAcquireLicenseForDurablesResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				storeLicense = new XStoreLicense(handle);
			}
			return num;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00006FC9 File Offset: 0x000051C9
		public static int XStoreAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XAsyncBlock async)
		{
			return NativeMethods.XStoreAcquireLicenseForPackageAsync(context.Handle, packageIdentifier, async.InteropPtr);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00006FE0 File Offset: 0x000051E0
		public static int XStoreAcquireLicenseForPackageResult(XAsyncBlock async, out XStoreLicense storeLicenseHandle)
		{
			storeLicenseHandle = null;
			IntPtr handle;
			int num = NativeMethods.XStoreAcquireLicenseForPackageResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				storeLicenseHandle = new XStoreLicense(handle);
			}
			return num;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000700D File Offset: 0x0000520D
		public static int XStoreCanAcquireLicenseForStoreIdAsync(XStoreContext storeContext, string storeProductId, XAsyncBlock async)
		{
			return NativeMethods.XStoreCanAcquireLicenseForStoreIdAsync(storeContext.Handle, storeProductId, async.InteropPtr);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00007024 File Offset: 0x00005224
		public static int XStoreCanAcquireLicenseForStoreIdResult(XAsyncBlock async, out XStoreCanAcquireLicenseResult storeCanAcquireLicenseResult)
		{
			storeCanAcquireLicenseResult = null;
			XStoreCanAcquireLicenseResult interop;
			int num = NativeMethods.XStoreCanAcquireLicenseForStoreIdResult(async.InteropPtr, out interop);
			if (HR.SUCCEEDED(num))
			{
				storeCanAcquireLicenseResult = new XStoreCanAcquireLicenseResult(interop);
			}
			return num;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00007051 File Offset: 0x00005251
		public static int XStoreCanAcquireLicenseForPackageAsync(XStoreContext storeContext, string packageIdentifier, XAsyncBlock async)
		{
			return NativeMethods.XStoreCanAcquireLicenseForPackageAsync(storeContext.Handle, packageIdentifier, async.InteropPtr);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00007068 File Offset: 0x00005268
		public static int XStoreCanAcquireLicenseForPackageResult(XAsyncBlock async, out XStoreCanAcquireLicenseResult storeCanAcquireLicenseResult)
		{
			storeCanAcquireLicenseResult = null;
			XStoreCanAcquireLicenseResult interop;
			int num = NativeMethods.XStoreCanAcquireLicenseForPackageResult(async.InteropPtr, out interop);
			if (HR.SUCCEEDED(num))
			{
				storeCanAcquireLicenseResult = new XStoreCanAcquireLicenseResult(interop);
			}
			return num;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00007095 File Offset: 0x00005295
		public static int XStoreQueryProductForCurrentGameAsync(XStoreContext storeContext, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryProductForCurrentGameAsync(storeContext.Handle, async.InteropPtr);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000070A8 File Offset: 0x000052A8
		public static int XStoreQueryProductForCurrentGameResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
		{
			productQueryHandle = null;
			IntPtr handle;
			int num = NativeMethods.XStoreQueryProductForCurrentGameResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				productQueryHandle = new XStoreProductQuery(handle);
			}
			return num;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000070D8 File Offset: 0x000052D8
		[MonoPInvokeCallback(typeof(XStoreProductQueryCallbackInterop))]
		private static bool OnProductQueryCallback([In] ref XStoreProductInterop product, IntPtr context)
		{
			CallbackWrapper<XStoreProductQueryCallbackInterop> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XStoreProductQueryCallbackInterop>;
			return callbackWrapper.Callback(ref product, callbackWrapper.Context);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000710C File Offset: 0x0000530C
		public static int XStoreEnumerateProductsQuery(XStoreProductQuery productQueryHandle, IntPtr context, XStoreProductQueryCallback callback)
		{
			int result;
			using (CallbackWrapper<XStoreProductQueryCallbackInterop> callbackWrapper = new CallbackWrapper<XStoreProductQueryCallbackInterop>(delegate(ref XStoreProductInterop product, IntPtr context)
			{
				return callback(new XStoreProduct(ref product), context);
			}, context2, new XStoreProductQueryCallbackInterop(SDK.OnProductQueryCallback)))
			{
				result = NativeMethods.XStoreEnumerateProductsQuery(productQueryHandle.Handle, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
			}
			return result;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00007178 File Offset: 0x00005378
		public static void XStoreCloseProductsQueryHandle(XStoreProductQuery productQueryHandle)
		{
			productQueryHandle.Close();
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00007180 File Offset: 0x00005380
		public static int XStoreDownloadPackageUpdatesAsync(XStoreContext storeContext, string[] packageIdentifiers, XAsyncBlock async)
		{
			return NativeMethods.XStoreDownloadPackageUpdatesAsync(storeContext.Handle, packageIdentifiers, (ulong)((long)packageIdentifiers.Length), async.InteropPtr);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00007198 File Offset: 0x00005398
		public static int XStoreDownloadPackageUpdatesResult(XAsyncBlock async)
		{
			return NativeMethods.XStoreDownloadPackageUpdatesResult(async.InteropPtr);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000071A5 File Offset: 0x000053A5
		public static int XStoreDownloadAndInstallPackageUpdatesAsync(XStoreContext storeContext, string[] packageIdentifiers, XAsyncBlock async)
		{
			return NativeMethods.XStoreDownloadAndInstallPackageUpdatesAsync(storeContext.Handle, packageIdentifiers, (ulong)((long)packageIdentifiers.Length), async.InteropPtr);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000071BD File Offset: 0x000053BD
		public static int XStoreDownloadAndInstallPackageUpdatesResult(XAsyncBlock async)
		{
			return NativeMethods.XStoreDownloadAndInstallPackageUpdatesResult(async.InteropPtr);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000071CA File Offset: 0x000053CA
		public static int XStoreDownloadAndInstallPackagesAsync(XStoreContext storeContext, string[] storeIds, XAsyncBlock async)
		{
			return NativeMethods.XStoreDownloadAndInstallPackagesAsync(storeContext.Handle, storeIds, (ulong)((long)storeIds.Length), async.InteropPtr);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000071E2 File Offset: 0x000053E2
		public static int XStoreDownloadAndInstallPackagesResultCount(XAsyncBlock async, out uint count)
		{
			return NativeMethods.XStoreDownloadAndInstallPackagesResultCount(async.InteropPtr, out count);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000071F0 File Offset: 0x000053F0
		public static int XStoreDownloadAndInstallPackagesResult(XAsyncBlock async, uint count, out string[] packageIdentifiers)
		{
			packageIdentifiers = null;
			XStorePackageIdentifierInterop[] array = new XStorePackageIdentifierInterop[count];
			int num = NativeMethods.XStoreDownloadAndInstallPackagesResult(async.InteropPtr, count, array);
			if (HR.SUCCEEDED(num))
			{
				packageIdentifiers = new string[count];
				for (uint num2 = 0U; num2 < count; num2 += 1U)
				{
					packageIdentifiers[(int)num2] = array[(int)num2].Data;
				}
			}
			return num;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00007242 File Offset: 0x00005442
		public static int XStoreGetUserCollectionsIdAsync(XStoreContext storeContext, string serviceTicket, string publisherUserId, XAsyncBlock async)
		{
			return NativeMethods.XStoreGetUserCollectionsIdAsync(storeContext.Handle, serviceTicket, publisherUserId, async.InteropPtr);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00007257 File Offset: 0x00005457
		public static int XStoreGetUserCollectionsIdResultSize(XAsyncBlock async, out ulong size)
		{
			return NativeMethods.XStoreGetUserCollectionsIdResultSize(async.InteropPtr, out size);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00007268 File Offset: 0x00005468
		public static int XStoreGetUserCollectionsIdResult(XAsyncBlock async, ulong size, out string result)
		{
			result = null;
			StringBuilder stringBuilder = new StringBuilder((int)size);
			int num = NativeMethods.XStoreGetUserCollectionsIdResult(async.InteropPtr, size, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				result = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000729D File Offset: 0x0000549D
		public static int XStoreGetUserPurchaseIdAsync(XStoreContext storeContext, string serviceTicket, string publisherUserId, XAsyncBlock async)
		{
			return NativeMethods.XStoreGetUserPurchaseIdAsync(storeContext.Handle, serviceTicket, publisherUserId, async.InteropPtr);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000072B2 File Offset: 0x000054B2
		public static int XStoreGetUserPurchaseIdResultSize(XAsyncBlock async, out ulong size)
		{
			return NativeMethods.XStoreGetUserPurchaseIdResultSize(async.InteropPtr, out size);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000072C0 File Offset: 0x000054C0
		public static int XStoreGetUserPurchaseIdResult(XAsyncBlock async, ulong size, out string result)
		{
			result = null;
			StringBuilder stringBuilder = new StringBuilder((int)size);
			int num = NativeMethods.XStoreGetUserPurchaseIdResult(async.InteropPtr, size, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				result = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000072F5 File Offset: 0x000054F5
		public static bool XStoreIsAvailabilityPurchasable(XStoreAvailability availability)
		{
			return NativeMethods.XStoreIsAvailabilityPurchasable(availability.interop);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00007302 File Offset: 0x00005502
		public static bool XStoreIsLicenseValid(XStoreLicense license)
		{
			return NativeMethods.XStoreIsLicenseValid(license.Handle);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000730F File Offset: 0x0000550F
		public static bool XStoreProductsQueryHasMorePages(XStoreProductQuery productQueryHandle)
		{
			return NativeMethods.XStoreProductsQueryHasMorePages(productQueryHandle.Handle);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000731C File Offset: 0x0000551C
		public static int XStoreProductsQueryNextPageAsync(XStoreProductQuery productQueryHandle, XAsyncBlock async)
		{
			return NativeMethods.XStoreProductsQueryNextPageAsync(productQueryHandle.Handle, async.InteropPtr);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00007330 File Offset: 0x00005530
		public static int XStoreProductsQueryNextPageResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
		{
			productQueryHandle = null;
			IntPtr handle;
			int num = NativeMethods.XStoreProductsQueryNextPageResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				productQueryHandle = new XStoreProductQuery(handle);
			}
			return num;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000735D File Offset: 0x0000555D
		public static int XStoreQueryAddOnLicensesAsync(XStoreContext storeContext, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryAddOnLicensesAsync(storeContext.Handle, async.InteropPtr);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00007370 File Offset: 0x00005570
		public static int XStoreQueryAddOnLicensesResultCount(XAsyncBlock async, out uint count)
		{
			return NativeMethods.XStoreQueryAddOnLicensesResultCount(async.InteropPtr, out count);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00007380 File Offset: 0x00005580
		public static int XStoreQueryAddOnLicensesResult(XAsyncBlock async, XStoreAddonLicense[] addOnLicenses)
		{
			XStoreAddonLicense[] array = new XStoreAddonLicense[addOnLicenses.Length];
			int num = NativeMethods.XStoreQueryAddOnLicensesResult(async.InteropPtr, (uint)array.Length, array);
			if (HR.SUCCEEDED(num))
			{
				for (int i = 0; i < addOnLicenses.Length; i++)
				{
					addOnLicenses[i] = new XStoreAddonLicense(array[i]);
				}
			}
			return num;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000073CC File Offset: 0x000055CC
		public static int XStoreQueryAssociatedProductsAsync(XStoreContext storeContext, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryAssociatedProductsAsync(storeContext.Handle, productKinds, maxItemsToRetrievePerPage, async.InteropPtr);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000073E4 File Offset: 0x000055E4
		public static int XStoreQueryAssociatedProductsResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
		{
			productQueryHandle = null;
			IntPtr handle;
			int num = NativeMethods.XStoreQueryAssociatedProductsResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				productQueryHandle = new XStoreProductQuery(handle);
			}
			return num;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00007411 File Offset: 0x00005611
		public static int XStoreQueryConsumableBalanceRemainingAsync(XStoreContext storeContext, string storeProductId, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryConsumableBalanceRemainingAsync(storeContext.Handle, storeProductId, async.InteropPtr);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00007428 File Offset: 0x00005628
		public static int XStoreQueryConsumableBalanceRemainingResult(XAsyncBlock async, out XStoreConsumableResult consumableResult)
		{
			consumableResult = null;
			XStoreConsumableResult interop = default(XStoreConsumableResult);
			int num = NativeMethods.XStoreQueryConsumableBalanceRemainingResult(async.InteropPtr, out interop);
			if (HR.SUCCEEDED(num))
			{
				consumableResult = new XStoreConsumableResult(interop);
			}
			return num;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000745D File Offset: 0x0000565D
		public static int XStoreQueryEntitledProductsAsync(XStoreContext storeContext, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryEntitledProductsAsync(storeContext.Handle, productKinds, maxItemsToRetrievePerPage, async.InteropPtr);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00007474 File Offset: 0x00005674
		public static int XStoreQueryEntitledProductsResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
		{
			productQueryHandle = null;
			IntPtr handle;
			int num = NativeMethods.XStoreQueryEntitledProductsResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				productQueryHandle = new XStoreProductQuery(handle);
			}
			return num;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000074A1 File Offset: 0x000056A1
		public static int XStoreQueryGameAndDlcPackageUpdatesAsync(XStoreContext storeContext, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryGameAndDlcPackageUpdatesAsync(storeContext.Handle, async.InteropPtr);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000074B4 File Offset: 0x000056B4
		public static int XStoreQueryGameAndDlcPackageUpdatesResultCount(XAsyncBlock async, out uint count)
		{
			return NativeMethods.XStoreQueryGameAndDlcPackageUpdatesResultCount(async.InteropPtr, out count);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000074C4 File Offset: 0x000056C4
		public static int XStoreQueryGameAndDlcPackageUpdatesResult(XAsyncBlock async, XStorePackageUpdate[] packageUpdates)
		{
			XStorePackageUpdate[] array = new XStorePackageUpdate[packageUpdates.Length];
			int num = NativeMethods.XStoreQueryGameAndDlcPackageUpdatesResult(async.InteropPtr, (uint)array.Length, array);
			if (HR.SUCCEEDED(num))
			{
				for (int i = 0; i < packageUpdates.Length; i++)
				{
					packageUpdates[i] = new XStorePackageUpdate(array[i]);
				}
			}
			return num;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00007510 File Offset: 0x00005710
		public static int XStoreQueryGameLicenseAsync(XStoreContext storeContext, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryGameLicenseAsync(storeContext.Handle, async.InteropPtr);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00007524 File Offset: 0x00005724
		public static int XStoreQueryGameLicenseResult(XAsyncBlock async, out XStoreGameLicense license)
		{
			license = null;
			XStoreGameLicense interop = default(XStoreGameLicense);
			int num = NativeMethods.XStoreQueryGameLicenseResult(async.InteropPtr, out interop);
			if (HR.SUCCEEDED(num))
			{
				license = new XStoreGameLicense(interop);
			}
			return num;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00007559 File Offset: 0x00005759
		public static int XStoreQueryLicenseTokenAsync(XStoreContext storeContext, string[] productIds, string customDeveloperString, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryLicenseTokenAsync(storeContext.Handle, productIds, (ulong)((long)productIds.Length), customDeveloperString, async.InteropPtr);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00007572 File Offset: 0x00005772
		public static int XStoreQueryLicenseTokenResultSize(XAsyncBlock async, out ulong size)
		{
			return NativeMethods.XStoreQueryLicenseTokenResultSize(async.InteropPtr, out size);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00007580 File Offset: 0x00005780
		public static int XStoreQueryLicenseTokenResult(XAsyncBlock async, ulong size, out string result)
		{
			result = null;
			StringBuilder stringBuilder = new StringBuilder((int)size);
			int num = NativeMethods.XStoreQueryLicenseTokenResult(async.InteropPtr, size, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				result = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x000075B8 File Offset: 0x000057B8
		public static int XStoreQueryPackageIdentifier(string storeId, ulong size, out string packageIdentifier)
		{
			packageIdentifier = null;
			StringBuilder stringBuilder = new StringBuilder((int)size);
			int num = NativeMethods.XStoreQueryPackageIdentifier(storeId, size, stringBuilder);
			if (HR.SUCCEEDED(num))
			{
				packageIdentifier = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x000075E8 File Offset: 0x000057E8
		public static int XStoreQueryPackageIdentifier(string storeId, out string packageIdentifier)
		{
			return SDK.XStoreQueryPackageIdentifier(storeId, (ulong)((long)SDK.XPACKAGE_IDENTIFIER_MAX_LENGTH), out packageIdentifier);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000075F7 File Offset: 0x000057F7
		public static int XStoreQueryProductForPackageAsync(XStoreContext storeContext, XStoreProductKind productKinds, string packageIdentifier, XAsyncBlock async)
		{
			return NativeMethods.XStoreQueryProductForPackageAsync(storeContext.Handle, productKinds, packageIdentifier, async.InteropPtr);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000760C File Offset: 0x0000580C
		public static int XStoreQueryProductForPackageResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
		{
			productQueryHandle = null;
			IntPtr handle;
			int num = NativeMethods.XStoreQueryProductForPackageResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				productQueryHandle = new XStoreProductQuery(handle);
			}
			return num;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000763C File Offset: 0x0000583C
		public static int XStoreQueryProductsAsync(XStoreContext storeContext, XStoreProductKind productKinds, string[] storeIds, string[] actionFilters, XAsyncBlock async)
		{
			ulong actionFiltersCount = (ulong)((actionFilters != null) ? ((long)actionFilters.Length) : 0L);
			return NativeMethods.XStoreQueryProductsAsync(storeContext.Handle, productKinds, storeIds, (ulong)((long)storeIds.Length), actionFilters, actionFiltersCount, async.InteropPtr);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00007670 File Offset: 0x00005870
		public static int XStoreQueryProductsResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
		{
			productQueryHandle = null;
			IntPtr handle;
			int num = NativeMethods.XStoreQueryProductsResult(async.InteropPtr, out handle);
			if (HR.SUCCEEDED(num))
			{
				productQueryHandle = new XStoreProductQuery(handle);
			}
			return num;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000076A0 File Offset: 0x000058A0
		public static int XStoreRegisterGameLicenseChanged(XStoreContext storeContext, XTaskQueueHandle queue, IntPtr context, XStoreGameLicenseChangedCallback callback, out GameLicenseChangedCallbackToken token)
		{
			XStoreGameLicenseChangedCallback callback2 = delegate(IntPtr context)
			{
				callback(context);
			};
			token = new GameLicenseChangedCallbackToken(storeContext, callback2, context2);
			ulong token2;
			int num = NativeMethods.XStoreRegisterGameLicenseChanged(storeContext.Handle, queue.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.Dispose();
			token = null;
			return num;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000771B File Offset: 0x0000591B
		public static bool XStoreUnregisterGameLicenseChanged(GameLicenseChangedCallbackToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00007724 File Offset: 0x00005924
		public static int XStoreRegisterPackageLicenseLost(XStoreLicense licenseHandle, XTaskQueueHandle queue, IntPtr context, XStorePackageLicenseLostCallback callback, out PackageLicenseLostCallbackToken token)
		{
			XStorePackageLicenseLostCallback callback2 = delegate(IntPtr context)
			{
				callback(context);
			};
			token = new PackageLicenseLostCallbackToken(licenseHandle, callback2, context2);
			ulong token2;
			int num = NativeMethods.XStoreRegisterPackageLicenseLost(licenseHandle.Handle, queue.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.Dispose();
			token = null;
			return num;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000779F File Offset: 0x0000599F
		public static bool XStoreUnregisterPackageLicenseLost(PackageLicenseLostCallbackToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000077A8 File Offset: 0x000059A8
		public static bool XStoreUnregisterPackageLicenseLost(PackageLicenseLostCallbackToken token)
		{
			return SDK.XStoreUnregisterPackageLicenseLost(token, true);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000077B1 File Offset: 0x000059B1
		public static int XStoreReportConsumableFulfillmentAsync(XStoreContext storeContext, string storeProductId, uint quantity, Guid trackingId, XAsyncBlock async)
		{
			return NativeMethods.XStoreReportConsumableFulfillmentAsync(storeContext.Handle, storeProductId, quantity, trackingId, async.InteropPtr);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000077C8 File Offset: 0x000059C8
		public static int XStoreReportConsumableFulfillmentResult(XAsyncBlock async, out XStoreConsumableResult consumableResult)
		{
			consumableResult = null;
			XStoreConsumableResult interop = default(XStoreConsumableResult);
			int num = NativeMethods.XStoreReportConsumableFulfillmentResult(async.InteropPtr, out interop);
			if (HR.SUCCEEDED(num))
			{
				consumableResult = new XStoreConsumableResult(interop);
			}
			return num;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000077FD File Offset: 0x000059FD
		public static int XStoreShowAssociatedProductsUIAsync(XStoreContext storeContext, string storeId, XStoreProductKind productKinds, XAsyncBlock async)
		{
			return NativeMethods.XStoreShowAssociatedProductsUIAsync(storeContext.Handle, storeId, productKinds, async.InteropPtr);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00007812 File Offset: 0x00005A12
		public static int XStoreShowAssociatedProductsUIResult(XAsyncBlock async)
		{
			return NativeMethods.XStoreShowAssociatedProductsUIResult(async.InteropPtr);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000781F File Offset: 0x00005A1F
		public static int XStoreShowProductPageUIAsync(XStoreContext storeContext, string storeId, XAsyncBlock async)
		{
			return NativeMethods.XStoreShowProductPageUIAsync(storeContext.Handle, storeId, async.InteropPtr);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00007833 File Offset: 0x00005A33
		public static int XStoreShowProductPageUIResult(XAsyncBlock async)
		{
			return NativeMethods.XStoreShowProductPageUIResult(async.InteropPtr);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00007840 File Offset: 0x00005A40
		public static int XStoreShowPurchaseUIAsync(XStoreContext storeContext, string storeId, string name, string extendedJsonData, XAsyncBlock async)
		{
			return NativeMethods.XStoreShowPurchaseUIAsync(storeContext.Handle, storeId, name, extendedJsonData, async.InteropPtr);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00007857 File Offset: 0x00005A57
		public static int XStoreShowPurchaseUIResult(XAsyncBlock async)
		{
			return NativeMethods.XStoreShowPurchaseUIResult(async.InteropPtr);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00007864 File Offset: 0x00005A64
		public static int XStoreShowRateAndReviewUIAsync(XStoreContext storeContext, XAsyncBlock async)
		{
			return NativeMethods.XStoreShowRateAndReviewUIAsync(storeContext.Handle, async.InteropPtr);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00007878 File Offset: 0x00005A78
		public static int XStoreShowRateAndReviewUIResult(XAsyncBlock async, out XStoreRateAndReviewResult result)
		{
			result = null;
			XStoreRateAndReviewResult interop = default(XStoreRateAndReviewResult);
			int num = NativeMethods.XStoreShowRateAndReviewUIResult(async.InteropPtr, out interop);
			if (HR.SUCCEEDED(num))
			{
				result = new XStoreRateAndReviewResult(interop);
			}
			return num;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x000078AD File Offset: 0x00005AAD
		public static int XStoreShowRedeemTokenUIAsync(XStoreContext storeContext, string token, string[] allowedStoreIds, bool disallowCsvRedemption, XAsyncBlock async)
		{
			return NativeMethods.XStoreShowRedeemTokenUIAsync(storeContext.Handle, token, allowedStoreIds, (ulong)((long)allowedStoreIds.Length), disallowCsvRedemption, async.InteropPtr);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x000078C8 File Offset: 0x00005AC8
		public static int XStoreShowRedeemTokenUIResult(XAsyncBlock async)
		{
			return NativeMethods.XStoreShowRedeemTokenUIResult(async.InteropPtr);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000078D8 File Offset: 0x00005AD8
		public static XSystemAnalyticsInfo XSystemGetAnalyticsInfo()
		{
			XSystemAnalyticsInfo interop = default(XSystemAnalyticsInfo);
			NativeMethods.XSystemGetAnalyticsInfo(out interop);
			return new XSystemAnalyticsInfo(interop);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000078FC File Offset: 0x00005AFC
		public static int XSystemGetAppSpecificDeviceId(out string appSpecificDeviceId)
		{
			appSpecificDeviceId = null;
			StringBuilder stringBuilder = new StringBuilder((int)SDK.XSystemAppSpecificDeviceIdBytes);
			ulong num2;
			int num = NativeMethods.XSystemGetAppSpecificDeviceId((ulong)((long)stringBuilder.Capacity), stringBuilder, out num2);
			if (HR.SUCCEEDED(num))
			{
				appSpecificDeviceId = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00007938 File Offset: 0x00005B38
		public static int XSystemGetConsoleId(out string consoleId)
		{
			consoleId = null;
			StringBuilder stringBuilder = new StringBuilder((int)SDK.XSystemConsoleIdBytes);
			ulong num2;
			int num = NativeMethods.XSystemGetConsoleId((ulong)((long)stringBuilder.Capacity), stringBuilder, out num2);
			if (HR.SUCCEEDED(num))
			{
				consoleId = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00007973 File Offset: 0x00005B73
		public static XSystemDeviceType XSystemGetDeviceType()
		{
			return NativeMethods.XSystemGetDeviceType();
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000797C File Offset: 0x00005B7C
		public static int XSystemGetXboxLiveSandboxId(out string sandboxId)
		{
			sandboxId = null;
			StringBuilder stringBuilder = new StringBuilder((int)SDK.XSystemXboxLiveSandboxIdMaxBytes);
			ulong num2;
			int num = NativeMethods.XSystemGetXboxLiveSandboxId((ulong)((long)stringBuilder.Capacity), stringBuilder, out num2);
			if (HR.SUCCEEDED(num))
			{
				sandboxId = stringBuilder.ToString();
			}
			return num;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000079B7 File Offset: 0x00005BB7
		public static XSystemRuntimeInfo XSystemGetRuntimeInfo()
		{
			return new XSystemRuntimeInfo(NativeMethods.XSystemGetRuntimeInfo());
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000079C3 File Offset: 0x00005BC3
		public static bool XSystemIsHandleValid(IntPtr handle)
		{
			return NativeMethods.XSystemIsHandleValid(handle);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000079CC File Offset: 0x00005BCC
		public static int XSystemHandleTrack(XSystemHandleCallback callback, IntPtr context, out XSystemHandleCallbackHandle handle)
		{
			XSystemHandleCallback callback2 = delegate(IntPtr handlePtr, XSystemHandleType type, XSystemHandleCallbackReason reason, IntPtr callbackContext)
			{
				callback(handlePtr, type, reason, callbackContext);
			};
			handle = new XSystemHandleCallbackHandle(callback2, context);
			int num = NativeMethods.XSystemHandleTrack(handle.interop.StaticCallback, handle.interop.CallbackContext);
			if (HR.FAILED(num))
			{
				handle.Dispose();
				handle = null;
			}
			return num;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00007A29 File Offset: 0x00005C29
		public static void XTaskQueueCloseHandle(XTaskQueueHandle queue)
		{
			queue.Close();
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00007A34 File Offset: 0x00005C34
		public static int XTaskQueueCreate(XTaskQueueDispatchMode workDispatchMode, XTaskQueueDispatchMode completionDispatchMode, out XTaskQueueHandle handle)
		{
			handle = null;
			IntPtr handle2;
			int num = NativeMethods.XTaskQueueCreate(workDispatchMode, completionDispatchMode, out handle2);
			if (HR.SUCCEEDED(num))
			{
				handle = new XTaskQueueHandle(handle2);
			}
			return num;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00007A60 File Offset: 0x00005C60
		public static int XTaskQueueCreateComposite(XTaskQueuePortHandle workPort, XTaskQueuePortHandle completionPort, out XTaskQueueHandle queue)
		{
			queue = null;
			IntPtr handle;
			int num = NativeMethods.XTaskQueueCreateComposite(workPort.Handle, completionPort.Handle, out handle);
			if (HR.SUCCEEDED(num))
			{
				queue = new XTaskQueueHandle(handle);
			}
			return num;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00007A93 File Offset: 0x00005C93
		public static bool XTaskQueueDispatch(XTaskQueueHandle queue, XTaskQueuePort port, uint timeoutInMs)
		{
			return NativeMethods.XTaskQueueDispatch(queue.Handle, port, timeoutInMs);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00007AA4 File Offset: 0x00005CA4
		public static int XTaskQueueDuplicateHandle(XTaskQueueHandle queue, out XTaskQueueHandle duplicatedHandle)
		{
			duplicatedHandle = null;
			IntPtr handle;
			int num = NativeMethods.XTaskQueueDuplicateHandle(queue.Handle, out handle);
			if (HR.SUCCEEDED(num))
			{
				duplicatedHandle = new XTaskQueueHandle(handle);
			}
			return num;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00007AD4 File Offset: 0x00005CD4
		public static bool XTaskQueueGetCurrentProcessTaskQueue(out XTaskQueueHandle queue)
		{
			IntPtr handle;
			bool flag = NativeMethods.XTaskQueueGetCurrentProcessTaskQueue(out handle);
			queue = (flag ? new XTaskQueueHandle(handle) : null);
			return flag;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00007AF8 File Offset: 0x00005CF8
		public static int XTaskQueueGetPort(XTaskQueueHandle queue, XTaskQueuePort port, out XTaskQueuePortHandle portHandle)
		{
			portHandle = null;
			IntPtr handle;
			int num = NativeMethods.XTaskQueueGetPort(queue.Handle, port, out handle);
			if (HR.SUCCEEDED(num))
			{
				portHandle = new XTaskQueuePortHandle(handle);
			}
			return num;
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00007B28 File Offset: 0x00005D28
		public static int XTaskQueueRegisterMonitor(XTaskQueueHandle queue, IntPtr callbackContext, XTaskQueueMonitorCallback callback, out XTaskQueueMonitorCallbackHandle tokenHandle)
		{
			XTaskQueueMonitorCallback callback2 = delegate(IntPtr context, IntPtr queuePtr, XTaskQueuePort port)
			{
				callback(context, queuePtr, port);
			};
			tokenHandle = new XTaskQueueMonitorCallbackHandle(queue, callback2, callbackContext);
			ulong token;
			int num = NativeMethods.XTaskQueueRegisterMonitor(queue.Handle, tokenHandle.interop.CallbackContext, tokenHandle.interop.StaticCallback, out token);
			if (HR.SUCCEEDED(num))
			{
				tokenHandle.Token = token;
				return num;
			}
			tokenHandle.Dispose();
			tokenHandle = null;
			return num;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00007B98 File Offset: 0x00005D98
		public static int XTaskQueueRegisterWaiter(XTaskQueueHandle queue, XTaskQueuePort port, WaitHandle waitHandle, IntPtr callbackContext, XTaskQueueCallback callback, out XTaskQueueWaiterCallbackHandle tokenHandle)
		{
			XTaskQueueCallback callback2 = delegate(IntPtr context, bool canceled)
			{
				callback(context, canceled);
			};
			tokenHandle = new XTaskQueueWaiterCallbackHandle(queue, callback2, callbackContext);
			ulong token;
			int num = NativeMethods.XTaskQueueRegisterWaiter(queue.Handle, port, waitHandle.SafeWaitHandle, tokenHandle.interop.CallbackContext, tokenHandle.interop.StaticCallback, out token);
			if (HR.SUCCEEDED(num))
			{
				tokenHandle.Token = token;
				return num;
			}
			tokenHandle.Dispose();
			tokenHandle = null;
			return num;
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00007C15 File Offset: 0x00005E15
		public static void XTaskQueueSetCurrentProcessTaskQueue(XTaskQueueHandle queue)
		{
			NativeMethods.XTaskQueueSetCurrentProcessTaskQueue(queue.Handle);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00007C24 File Offset: 0x00005E24
		public static int XTaskQueueSubmitCallback(XTaskQueueHandle queue, XTaskQueuePort port, IntPtr callbackContext, XTaskQueueCallback callback, out XTaskQueueCallbackHandle callbackHandle)
		{
			XTaskQueueCallback callback2 = delegate(IntPtr context, bool canceled)
			{
				callback(context, canceled);
			};
			callbackHandle = new XTaskQueueCallbackHandle(callback2, callbackContext);
			int num = NativeMethods.XTaskQueueSubmitCallback(queue.Handle, port, callbackHandle.interop.CallbackContext, callbackHandle.interop.StaticCallback);
			if (HR.FAILED(num))
			{
				callbackHandle.Dispose();
				callbackHandle = null;
			}
			return num;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00007C90 File Offset: 0x00005E90
		public static int XTaskQueueSubmitDelayedCallback(XTaskQueueHandle queue, XTaskQueuePort port, uint delayMs, IntPtr callbackContext, XTaskQueueCallback callback, out XTaskQueueCallbackHandle callbackHandle)
		{
			XTaskQueueCallback callback2 = delegate(IntPtr context, bool canceled)
			{
				callback(context, canceled);
			};
			callbackHandle = new XTaskQueueCallbackHandle(callback2, callbackContext);
			int num = NativeMethods.XTaskQueueSubmitDelayedCallback(queue.Handle, port, delayMs, callbackHandle.interop.CallbackContext, callbackHandle.interop.StaticCallback);
			if (HR.FAILED(num))
			{
				callbackHandle.Dispose();
				callbackHandle = null;
			}
			return num;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00007CFC File Offset: 0x00005EFC
		public static int XTaskQueueTerminate(XTaskQueueHandle queue, bool wait, IntPtr callbackContext, XTaskQueueTerminatedCallback callback, out XTaskQueueTerminateCallbackHandle callbackHandle)
		{
			XTaskQueueTerminatedCallback callback2 = delegate(IntPtr context)
			{
				callback(context);
			};
			callbackHandle = new XTaskQueueTerminateCallbackHandle(callback2, callbackContext);
			int num = NativeMethods.XTaskQueueTerminate(queue.Handle, wait, callbackHandle.interop.CallbackContext, callbackHandle.interop.StaticCallback);
			if (HR.FAILED(num))
			{
				callbackHandle.Dispose();
				callbackHandle = null;
			}
			return num;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00007D65 File Offset: 0x00005F65
		public static int XTaskQueueTerminate(XTaskQueueHandle queue, bool wait, IntPtr callbackContext)
		{
			return NativeMethods.XTaskQueueTerminate(queue.Handle, wait, callbackContext, null);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00007D75 File Offset: 0x00005F75
		public static void XTaskQueueUnregisterMonitor(XTaskQueueHandle queue, XTaskQueueMonitorCallbackHandle token)
		{
			token.Unregister(queue);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00007D7E File Offset: 0x00005F7E
		public static void XTaskQueueUnregisterWaiter(XTaskQueueHandle queue, XTaskQueueWaiterCallbackHandle token)
		{
			token.Unregister(queue);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00007D87 File Offset: 0x00005F87
		public static void XThreadAssertNotTimeSensitive()
		{
			NativeMethods.XThreadAssertNotTimeSensitive();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00007D8E File Offset: 0x00005F8E
		public static bool XThreadIsTimeSensitive()
		{
			return NativeMethods.XThreadIsTimeSensitive();
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00007D95 File Offset: 0x00005F95
		public static int XThreadSetTimeSensitive(bool isTimeSensitiveThread)
		{
			return NativeMethods.XThreadSetTimeSensitive(isTimeSensitiveThread);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00007D9D File Offset: 0x00005F9D
		public static int XUserAddAsync(XUserAddOptions options, XAsyncBlock async)
		{
			return NativeMethods.XUserAddAsync(options, async.InteropPtr);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00007DAC File Offset: 0x00005FAC
		public static int XUserAddResult(XAsyncBlock async, out XUserHandle newUser)
		{
			IntPtr interopHandle;
			return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserAddResult(async.InteropPtr, out interopHandle), interopHandle, out newUser);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00007DCD File Offset: 0x00005FCD
		public static int XUserAddByIdWithUiAsync(ulong userId, XAsyncBlock async)
		{
			return NativeMethods.XUserAddByIdWithUiAsync(userId, async.InteropPtr);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00007DDC File Offset: 0x00005FDC
		public static int XUserAddByIdWithUiResult(XAsyncBlock async, out XUserHandle newUser)
		{
			IntPtr interopHandle;
			return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserAddByIdWithUiResult(async.InteropPtr, out interopHandle), interopHandle, out newUser);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00007DFD File Offset: 0x00005FFD
		public static int XUserCheckPrivilege(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, out bool hasPrivilege, out XUserPrivilegeDenyReason reason)
		{
			return NativeMethods.XUserCheckPrivilege((user != null) ? user.Handle : IntPtr.Zero, options, privilege, out hasPrivilege, out reason);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00007E1F File Offset: 0x0000601F
		public static void XUserCloseHandle(XUserHandle user)
		{
			if (user == null)
			{
				return;
			}
			user.Close();
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00007E31 File Offset: 0x00006031
		public static int XUserCloseSignOutDeferralHandle(XUserSignOutDeferralHandle deferral)
		{
			deferral.Close();
			return 0;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00007E3C File Offset: 0x0000603C
		public static int XUserCompare(XUserHandle user1, XUserHandle user2)
		{
			IntPtr user3 = (user1 != null) ? user1.Handle : IntPtr.Zero;
			IntPtr user4 = (user2 != null) ? user2.Handle : IntPtr.Zero;
			return NativeMethods.XUserCompare(user3, user4);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00007E7C File Offset: 0x0000607C
		public static int XUserCompare(XUserHandle user1, XUserHandle user2, out int comparisonResult)
		{
			comparisonResult = SDK.XUserCompare(user1, user2);
			return 0;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00007E88 File Offset: 0x00006088
		public static int XUserDuplicateHandle(XUserHandle handle, out XUserHandle duplicatedHandle)
		{
			IntPtr interopHandle;
			return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserDuplicateHandle((handle != null) ? handle.Handle : IntPtr.Zero, out interopHandle), interopHandle, out duplicatedHandle);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00007EB9 File Offset: 0x000060B9
		public static int XUserFindControllerForUserWithUiAsync(XUserHandle user, XAsyncBlock async)
		{
			return NativeMethods.XUserFindControllerForUserWithUiAsync((user != null) ? user.Handle : IntPtr.Zero, async.InteropPtr);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00007EDC File Offset: 0x000060DC
		public static int XUserFindControllerForUserWithUiResult(XAsyncBlock async, out APP_LOCAL_DEVICE_ID deviceId)
		{
			deviceId = null;
			APP_LOCAL_DEVICE_ID interop = default(APP_LOCAL_DEVICE_ID);
			int num = NativeMethods.XUserFindControllerForUserWithUiResult(async.InteropPtr, out interop);
			if (HR.SUCCEEDED(num))
			{
				deviceId = new APP_LOCAL_DEVICE_ID(interop);
			}
			return num;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00007F14 File Offset: 0x00006114
		public static int XUserFindForDevice(APP_LOCAL_DEVICE_ID deviceId, out XUserHandle handle)
		{
			IntPtr interopHandle;
			return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserFindForDevice(ref deviceId.interop, out interopHandle), interopHandle, out handle);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00007F38 File Offset: 0x00006138
		public static int XUserFindUserById(ulong userId, out XUserHandle handle)
		{
			IntPtr interopHandle;
			return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserFindUserById(userId, out interopHandle), interopHandle, out handle);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00007F54 File Offset: 0x00006154
		public static int XUserFindUserByLocalId(XUserLocalId userLocalId, out XUserHandle handle)
		{
			IntPtr interopHandle;
			return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserFindUserByLocalId(userLocalId.interop, out interopHandle), interopHandle, out handle);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00007F75 File Offset: 0x00006175
		public static int XUserGetAgeGroup(XUserHandle user, out XUserAgeGroup ageGroup)
		{
			return NativeMethods.XUserGetAgeGroup((user != null) ? user.Handle : IntPtr.Zero, out ageGroup);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00007F93 File Offset: 0x00006193
		public static int XUserGetDefaultAudioEndpointUtf16(XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, ulong endpointIdUtf16Count, char[] endpointIdUtf16, out ulong endpointIdUtf16Used)
		{
			return NativeMethods.XUserGetDefaultAudioEndpointUtf16(user.interop, defaultAudioEndpointKind, endpointIdUtf16Count, endpointIdUtf16, out endpointIdUtf16Used);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00007FA5 File Offset: 0x000061A5
		public static int XUserGetGamerPictureAsync(XUserHandle user, XUserGamerPictureSize pictureSize, XAsyncBlock async)
		{
			return NativeMethods.XUserGetGamerPictureAsync((user != null) ? user.Handle : IntPtr.Zero, pictureSize, async.InteropPtr);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00007FC9 File Offset: 0x000061C9
		public static int XUserGetGamerPictureResultSize(XAsyncBlock async, out ulong bufferSize)
		{
			return NativeMethods.XUserGetGamerPictureResultSize(async.InteropPtr, out bufferSize);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00007FD7 File Offset: 0x000061D7
		public static int XUserGetGamerPictureResult(XAsyncBlock async, byte[] buffer, out ulong bufferUsed)
		{
			return NativeMethods.XUserGetGamerPictureResult(async.InteropPtr, (ulong)((long)buffer.Length), buffer, out bufferUsed);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00007FEA File Offset: 0x000061EA
		public static int XUserGetGamertag(XUserHandle user, XUserGamertagComponent gamertagComponent, StringBuilder gamertag, out ulong gamertagUsed)
		{
			return NativeMethods.XUserGetGamertag((user != null) ? user.Handle : IntPtr.Zero, gamertagComponent, (ulong)((long)gamertag.Capacity), gamertag, out gamertagUsed);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00008011 File Offset: 0x00006211
		public static int XUserGetId(XUserHandle user, out ulong userId)
		{
			return NativeMethods.XUserGetId((user != null) ? user.Handle : IntPtr.Zero, out userId);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000802F File Offset: 0x0000622F
		public static int XUserGetIsGuest(XUserHandle user, out bool isGuest)
		{
			return NativeMethods.XUserGetIsGuest((user != null) ? user.Handle : IntPtr.Zero, out isGuest);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00008050 File Offset: 0x00006250
		public static int XUserGetLocalId(XUserHandle user, out XUserLocalId userLocalId)
		{
			userLocalId = null;
			XUserLocalId interop = default(XUserLocalId);
			int num = NativeMethods.XUserGetLocalId((user != null) ? user.Handle : IntPtr.Zero, out interop);
			if (HR.SUCCEEDED(num))
			{
				userLocalId = new XUserLocalId(interop);
			}
			return num;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00008095 File Offset: 0x00006295
		public static int XUserGetMaxUsers(out uint maxUsers)
		{
			return NativeMethods.XUserGetMaxUsers(out maxUsers);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000080A0 File Offset: 0x000062A0
		public static int XUserGetSignOutDeferral(out XUserSignOutDeferralHandle deferral)
		{
			deferral = null;
			IntPtr interopHandle;
			int num = NativeMethods.XUserGetSignOutDeferral(out interopHandle);
			if (HR.SUCCEEDED(num))
			{
				deferral = new XUserSignOutDeferralHandle(interopHandle);
			}
			return num;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000080C7 File Offset: 0x000062C7
		public static int XUserGetState(XUserHandle user, out XUserState state)
		{
			return NativeMethods.XUserGetState((user != null) ? user.Handle : IntPtr.Zero, out state);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000080E8 File Offset: 0x000062E8
		public static int XUserGetTokenAndSignatureAsync(XUserHandle user, XUserGetTokenAndSignatureOptions options, string method, string url, XUserGetTokenAndSignatureHttpHeader[] headers, byte[] bodyBuffer, XAsyncBlock async)
		{
			XUserGetTokenAndSignatureHttpHeader[] array = null;
			if (headers != null)
			{
				array = new XUserGetTokenAndSignatureHttpHeader[headers.Length];
				for (int i = 0; i < headers.Length; i++)
				{
					array[i] = headers[i].interop;
				}
			}
			IntPtr user2 = (user != null) ? user.Handle : IntPtr.Zero;
			ulong headerCount = (ulong)((array != null) ? ((long)array.Length) : 0L);
			ulong bodySize = (ulong)((bodyBuffer != null) ? ((long)bodyBuffer.Length) : 0L);
			return NativeMethods.XUserGetTokenAndSignatureAsync(user2, options, method, url, headerCount, array, bodySize, bodyBuffer, async.InteropPtr);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00008168 File Offset: 0x00006368
		public static int XUserGetTokenAndSignatureResultSize(XAsyncBlock async, out ulong bufferSize)
		{
			return NativeMethods.XUserGetTokenAndSignatureResultSize(async.InteropPtr, out bufferSize);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00008178 File Offset: 0x00006378
		public static int XUserGetTokenAndSignatureResult(XAsyncBlock async, byte[] buffer, out XUserGetTokenAndSignatureData result)
		{
			result = null;
			XUserGetTokenAndSignatureData interop = default(XUserGetTokenAndSignatureData);
			IntPtr ptr;
			ulong num2;
			int num = NativeMethods.XUserGetTokenAndSignatureResult(async.InteropPtr, (ulong)((long)buffer.Length), buffer, out ptr, out num2);
			if (HR.SUCCEEDED(num))
			{
				interop = (XUserGetTokenAndSignatureData)Marshal.PtrToStructure(ptr, typeof(XUserGetTokenAndSignatureData));
				result = new XUserGetTokenAndSignatureData(interop);
			}
			return num;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000081CC File Offset: 0x000063CC
		public static int XUserGetTokenAndSignatureUtf16Async(XUserHandle user, XUserGetTokenAndSignatureOptions options, string method, string url, XUserGetTokenAndSignatureUtf16HttpHeader[] headers, byte[] bodyBuffer, XAsyncBlock async)
		{
			XUserGetTokenAndSignatureUtf16HttpHeader[] array = null;
			if (headers != null)
			{
				array = new XUserGetTokenAndSignatureUtf16HttpHeader[headers.Length];
				for (int i = 0; i < headers.Length; i++)
				{
					array[i] = headers[i].interop;
				}
			}
			IntPtr user2 = (user != null) ? user.Handle : IntPtr.Zero;
			ulong headerCount = (ulong)((array != null) ? ((long)array.Length) : 0L);
			ulong bodySize = (ulong)((bodyBuffer != null) ? ((long)bodyBuffer.Length) : 0L);
			return NativeMethods.XUserGetTokenAndSignatureUtf16Async(user2, options, method, url, headerCount, array, bodySize, bodyBuffer, async.InteropPtr);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000824C File Offset: 0x0000644C
		public static int XUserGetTokenAndSignatureUtf16ResultSize(XAsyncBlock async, out ulong bufferSize)
		{
			return NativeMethods.XUserGetTokenAndSignatureUtf16ResultSize(async.InteropPtr, out bufferSize);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000825C File Offset: 0x0000645C
		public static int XUserGetTokenAndSignatureUtf16Result(XAsyncBlock async, byte[] buffer, out XUserGetTokenAndSignatureUtf16Data result)
		{
			result = null;
			XUserGetTokenAndSignatureUtf16Data interop = default(XUserGetTokenAndSignatureUtf16Data);
			IntPtr ptr;
			ulong num2;
			int num = NativeMethods.XUserGetTokenAndSignatureUtf16Result(async.InteropPtr, (ulong)((long)buffer.Length), buffer, out ptr, out num2);
			if (HR.SUCCEEDED(num))
			{
				interop = (XUserGetTokenAndSignatureUtf16Data)Marshal.PtrToStructure(ptr, typeof(XUserGetTokenAndSignatureUtf16Data));
				result = new XUserGetTokenAndSignatureUtf16Data(interop);
			}
			return num;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000082AE File Offset: 0x000064AE
		public static bool XUserIsStoreUser(XUserHandle user)
		{
			return NativeMethods.XUserIsStoreUser((user != null) ? user.Handle : IntPtr.Zero);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000082CC File Offset: 0x000064CC
		public static int XUserRegisterForChangeEvent(XTaskQueueHandle queue, IntPtr context, XUserChangeEventCallback callback, out XUserChangeRegistrationToken token)
		{
			XUserChangeEventCallback callback2 = delegate(IntPtr callbackContext, XUserLocalId userLocalId, XUserChangeEvent changeEvent)
			{
				callback(callbackContext, new XUserLocalId(userLocalId), changeEvent);
			};
			token = new XUserChangeRegistrationToken(callback2, context);
			ulong token2;
			int num = NativeMethods.XUserRegisterForChangeEvent((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000834C File Offset: 0x0000654C
		public static int XUserRegisterForDefaultAudioEndpointUtf16Changed(XTaskQueueHandle queue, IntPtr context, XUserDefaultAudioEndpointUtf16ChangedCallback callback, out XUserDefaultAudioEndpointUtf16RegistrationToken token)
		{
			XUserDefaultAudioEndpointUtf16ChangedCallback callback2 = delegate(IntPtr callbackContext, XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, string endpointIdUtf16)
			{
				callback(callbackContext, new XUserLocalId(user), defaultAudioEndpointKind, endpointIdUtf16);
			};
			token = new XUserDefaultAudioEndpointUtf16RegistrationToken(callback2, context);
			ulong token2;
			int num = NativeMethods.XUserRegisterForDefaultAudioEndpointUtf16Changed((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000083CC File Offset: 0x000065CC
		public static int XUserRegisterForDeviceAssociationChanged(XTaskQueueHandle queue, IntPtr context, XUserDeviceAssociationChangedCallback callback, out XUserDeviceAssociationChangedRegistrationToken token)
		{
			XUserDeviceAssociationChangedCallback callback2 = delegate(IntPtr context, ref XUserDeviceAssociationChange change)
			{
				XUserDeviceAssociationChange xuserDeviceAssociationChange = new XUserDeviceAssociationChange(change);
				callback(context, ref xuserDeviceAssociationChange);
			};
			token = new XUserDeviceAssociationChangedRegistrationToken(callback2, context2);
			ulong token2;
			int num = NativeMethods.XUserRegisterForDeviceAssociationChanged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
			if (HR.SUCCEEDED(num))
			{
				token.Token = token2;
				return num;
			}
			token.Dispose();
			token = null;
			return num;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000844A File Offset: 0x0000664A
		public static int XUserResolveIssueWithUiAsync(XUserHandle user, string url, XAsyncBlock async)
		{
			return NativeMethods.XUserResolveIssueWithUiAsync((user != null) ? user.Handle : IntPtr.Zero, url, async.InteropPtr);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000846E File Offset: 0x0000666E
		public static int XUserResolveIssueWithUiResult(XAsyncBlock async)
		{
			return NativeMethods.XUserResolveIssueWithUiResult(async.InteropPtr);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000847B File Offset: 0x0000667B
		public static int XUserResolveIssueWithUiUtf16Async(XUserHandle user, string url, XAsyncBlock async)
		{
			return NativeMethods.XUserResolveIssueWithUiUtf16Async((user != null) ? user.Handle : IntPtr.Zero, url, async.InteropPtr);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000849F File Offset: 0x0000669F
		public static int XUserResolveIssueWithUiUtf16Result(XAsyncBlock async)
		{
			return NativeMethods.XUserResolveIssueWithUiUtf16Result(async.InteropPtr);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000084AC File Offset: 0x000066AC
		public static int XUserResolvePrivilegeWithUiAsync(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, XAsyncBlock async)
		{
			return NativeMethods.XUserResolvePrivilegeWithUiAsync((user != null) ? user.Handle : IntPtr.Zero, options, privilege, async.InteropPtr);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000084D1 File Offset: 0x000066D1
		public static int XUserResolvePrivilegeWithUiResult(XAsyncBlock async)
		{
			return NativeMethods.XUserResolvePrivilegeWithUiResult(async.InteropPtr);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000084DE File Offset: 0x000066DE
		public static bool XUserUnregisterForChangeEvent(XUserChangeRegistrationToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000084E7 File Offset: 0x000066E7
		public static bool XUserUnregisterForChangeEvent(XUserChangeRegistrationToken token)
		{
			return SDK.XUserUnregisterForChangeEvent(token, true);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x000084F0 File Offset: 0x000066F0
		public static bool XUserUnregisterForDefaultAudioEndpointUtf16Changed(XUserDefaultAudioEndpointUtf16RegistrationToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x000084F9 File Offset: 0x000066F9
		public static bool XUserUnregisterForDeviceAssociationChanged(XUserDeviceAssociationChangedRegistrationToken token, bool wait)
		{
			return token.Unregister(wait);
		}

		// Token: 0x0400001C RID: 28
		private static HCWebSocketRoutedHandler routedCallback;

		// Token: 0x0400001D RID: 29
		private static int hcRoutedHandlerId;

		// Token: 0x0400001E RID: 30
		private static Dictionary<IntPtr, CallbackWrapper<XAsyncWorkInterop>> asyncWorkCallbackDictionary = new Dictionary<IntPtr, CallbackWrapper<XAsyncWorkInterop>>();

		// Token: 0x0400001F RID: 31
		private static XTaskQueueHandle defaultQueue;

		// Token: 0x04000020 RID: 32
		private static Thread m_DispatchJob;

		// Token: 0x04000021 RID: 33
		private static volatile bool isInitialized = false;

		// Token: 0x04000022 RID: 34
		private static volatile bool m_StopExecution;

		// Token: 0x04000023 RID: 35
		private const string obsoleteXPackageMountMsg = "XPackageMount(string, out XPackageMountHandle) has been removed. Please use XPackageMountWithUiAsync(string packageIdentifier, XPackageMountWithUiAsyncCompleted) instead.";

		// Token: 0x04000024 RID: 36
		private static CallbackWrapper<XErrorCallback> errorCallbackWrapper;

		// Token: 0x04000025 RID: 37
		private const int XUserGamertagComponentClassicMaxBytes = 16;

		// Token: 0x04000026 RID: 38
		private const int XUserGamertagComponentModernMaxBytes = 97;

		// Token: 0x04000027 RID: 39
		private const int XUserGamertagComponentModernSuffixMaxBytes = 15;

		// Token: 0x04000028 RID: 40
		private const int XUserGamertagComponentUniqueModernMaxBytes = 101;

		// Token: 0x04000029 RID: 41
		private XGameStreamingClientId XGameStreamingNullClientId = new XGameStreamingClientId(0UL);

		// Token: 0x0400002A RID: 42
		private XGameStreamingClientId XGameStreamingAllClients = new XGameStreamingClientId(ulong.MaxValue);

		// Token: 0x0400002B RID: 43
		private const ulong ClientIPAddressMaxBytes = 65UL;

		// Token: 0x0400002C RID: 44
		private const ulong SessionIdMaxBytes = 256UL;

		// Token: 0x0400002D RID: 45
		public static readonly int XPACKAGE_IDENTIFIER_MAX_LENGTH = 33;

		// Token: 0x0400002E RID: 46
		public static readonly int LOCALE_NAME_MAX_LENGTH = 85;

		// Token: 0x0400002F RID: 47
		public static readonly ulong XSystemAppSpecificDeviceIdBytes = 45UL;

		// Token: 0x04000030 RID: 48
		public static readonly ulong XSystemConsoleIdBytes = 39UL;

		// Token: 0x04000031 RID: 49
		public static readonly ulong XSystemXboxLiveSandboxIdMaxBytes = 16UL;

		// Token: 0x04000032 RID: 50
		public static readonly ulong XUserAudioEndpointMaxUtf16Count = 56UL;

		// Token: 0x020002A9 RID: 681
		public class XBL
		{
			// Token: 0x06000EAF RID: 3759 RVA: 0x00011DC0 File Offset: 0x0000FFC0
			public static int XblAchievementsResultGetAchievements(XblAchievementsResultHandle resultHandle, out XblAchievement[] achievements)
			{
				if (resultHandle == null)
				{
					achievements = null;
					return -2147024809;
				}
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblAchievementsResultGetAchievements(resultHandle.Handle, out rawPtr, out count);
				if (HR.FAILED(num))
				{
					achievements = null;
					return num;
				}
				achievements = Converters.PtrToClassArray<XblAchievement, XblAchievement>(rawPtr, count, (XblAchievement a) => new XblAchievement(a));
				return num;
			}

			// Token: 0x06000EB0 RID: 3760 RVA: 0x00011E25 File Offset: 0x00010025
			public static int XblAchievementsResultHasNext(XblAchievementsResultHandle resultHandle, out bool hasNext)
			{
				if (resultHandle == null)
				{
					hasNext = false;
					return -2147024809;
				}
				return XblInterop.XblAchievementsResultHasNext(resultHandle.Handle, out hasNext);
			}

			// Token: 0x06000EB1 RID: 3761 RVA: 0x00011E48 File Offset: 0x00010048
			public static void XblAchievementsResultGetNextAsync(XblAchievementsResultHandle resultHandle, uint maxItems, SDK.XBL.XblAchievementsResultGetNextResult completionRoutine)
			{
				if (resultHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblAchievementsResultHandle interopHandle;
					int num2 = XblInterop.XblAchievementsResultGetNextResult(block, out interopHandle);
					if (HR.SUCCEEDED(num2))
					{
						completionRoutine(num2, new XblAchievementsResultHandle(interopHandle));
						return;
					}
					completionRoutine(num2, null);
				});
				int num = XblInterop.XblAchievementsResultGetNextAsync(resultHandle.Handle, maxItems, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000EB2 RID: 3762 RVA: 0x00011EC4 File Offset: 0x000100C4
			public static void XblAchievementsGetAchievementsForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, XblAchievementType type, bool unlockedOnly, XblAchievementOrderBy orderBy, uint skipItems, uint maxItems, SDK.XBL.XblAchievementsGetAchievementsForTitleIdResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblAchievementsResultHandle interopHandle;
					int num2 = XblInterop.XblAchievementsGetAchievementsForTitleIdResult(block, out interopHandle);
					if (HR.SUCCEEDED(num2))
					{
						completionRoutine(num2, new XblAchievementsResultHandle(interopHandle));
						return;
					}
					completionRoutine(num2, null);
				});
				int num = XblInterop.XblAchievementsGetAchievementsForTitleIdAsync(xboxLiveContext.Handle, xboxUserId, titleId, type, unlockedOnly, orderBy, skipItems, maxItems, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000EB3 RID: 3763 RVA: 0x00011F4C File Offset: 0x0001014C
			public static void XblAchievementsUpdateAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, string achievementId, uint percentComplete, SDK.XBL.XblAchievementsUpdateAchievementResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, false);
					completionRoutine(hresult);
				});
				int num = XblInterop.XblAchievementsUpdateAchievementAsync(xboxLiveContext.Handle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(achievementId), percentComplete, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000EB4 RID: 3764 RVA: 0x00011FCC File Offset: 0x000101CC
			public static void XblAchievementsUpdateAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, string serviceConfigurationId, string achievementId, uint percentComplete, SDK.XBL.XblAchievementsUpdateAchievementForTitleIdResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, false);
					completionRoutine(hresult);
				});
				int num = XblInterop.XblAchievementsUpdateAchievementForTitleIdAsync(xboxLiveContext.Handle, xboxUserId, titleId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(achievementId), percentComplete, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000EB5 RID: 3765 RVA: 0x00012058 File Offset: 0x00010258
			public static void XblAchievementsUpdateAchievementForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, string serviceConfigurationId, string achievementId, uint percentComplete, SDK.XBL.XblAchievementsUpdateAchievementForTitleIdResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, false);
					completionRoutine(hresult);
				});
				int num = XblInterop.XblAchievementsUpdateAchievementForTitleIdAsync(xboxLiveContext.Handle, xboxUserId, titleId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(achievementId), percentComplete, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000EB6 RID: 3766 RVA: 0x000120E4 File Offset: 0x000102E4
			public static void XblAchievementsGetAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, string serviceConfigurationId, string achievementId, SDK.XBL.XblAchievementsGetAchievementResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblAchievementsResultHandle interopHandle;
					int num2 = XblInterop.XblAchievementsGetAchievementResult(block, out interopHandle);
					if (HR.SUCCEEDED(num2))
					{
						completionRoutine(num2, new XblAchievementsResultHandle(interopHandle));
						return;
					}
					completionRoutine(num2, null);
				});
				int num = XblInterop.XblAchievementsGetAchievementAsync(xboxLiveContext.Handle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(achievementId), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000EB7 RID: 3767 RVA: 0x0001216C File Offset: 0x0001036C
			public static XblFunctionContext XblAchievementsAddAchievementProgressChangeHandler(XblContextHandle xboxLiveContext, SDK.XBL.XblAchievementsProgressChangeHandlerResult handler, IntPtr handlerContext)
			{
				if (xboxLiveContext == null)
				{
					handler(-2147024809, null, IntPtr.Zero);
					return default(XblFunctionContext);
				}
				XblInterop.XblAchievementsProgressChangeHandler handler2 = delegate(XblAchievementProgressChangeEventArgs eventArgsInterop, IntPtr context)
				{
					XblAchievementProgressChangeEventArgs eventArgs = new XblAchievementProgressChangeEventArgs(eventArgsInterop);
					handler(0, eventArgs, context);
				};
				return XblInterop.XblAchievementsAddAchievementProgressChangeHandler(xboxLiveContext.Handle, handler2, handlerContext);
			}

			// Token: 0x06000EB8 RID: 3768 RVA: 0x000121C9 File Offset: 0x000103C9
			public static XblFunctionContext XblAchievementsAddAchievementProgressChangeHandler(XblContextHandle xboxLiveContext, SDK.XBL.XblAchievementsProgressChangeHandlerResult handler)
			{
				return SDK.XBL.XblAchievementsAddAchievementProgressChangeHandler(xboxLiveContext, handler, IntPtr.Zero);
			}

			// Token: 0x06000EB9 RID: 3769 RVA: 0x000121D7 File Offset: 0x000103D7
			public static void XblAchievementsRemoveAchievementProgressChangeHandler(XblContextHandle xblContextHandle, XblFunctionContext functionContext)
			{
				XblInterop.XblAchievementsRemoveAchievementProgressChangeHandler(xblContextHandle.Handle, functionContext);
			}

			// Token: 0x06000EBA RID: 3770 RVA: 0x000121E8 File Offset: 0x000103E8
			public static int XblAchievementsResultDuplicateHandle(XblAchievementsResultHandle handle, out XblAchievementsResultHandle duplicatedHandle)
			{
				if (handle == null)
				{
					duplicatedHandle = null;
					return -2147024809;
				}
				XblAchievementsResultHandle interopHandle;
				int num = XblInterop.XblAchievementsResultDuplicateHandle(handle.Handle, out interopHandle);
				if (HR.SUCCEEDED(num))
				{
					duplicatedHandle = new XblAchievementsResultHandle(interopHandle);
					return num;
				}
				duplicatedHandle = null;
				return num;
			}

			// Token: 0x06000EBB RID: 3771 RVA: 0x00012228 File Offset: 0x00010428
			public static void XblAchievementsResultCloseHandle(XblAchievementsResultHandle handle)
			{
				if (handle == null)
				{
					return;
				}
				handle.Close();
			}

			// Token: 0x06000EBC RID: 3772 RVA: 0x0001223C File Offset: 0x0001043C
			public static int XblAchievementsManagerResultGetAchievements(XblAchievementsManagerResultHandle handle, out XblAchievement[] achievements)
			{
				if (handle == null)
				{
					achievements = null;
					return -2147024809;
				}
				IntPtr rawPtr;
				ulong num2;
				int num = XblInterop.XblAchievementsManagerResultGetAchievements(handle.Handle, out rawPtr, out num2);
				if (HR.FAILED(num) || num2 == 0UL)
				{
					achievements = null;
					return num;
				}
				achievements = Converters.PtrToClassArray<XblAchievement, XblAchievement>(rawPtr, new SizeT(num2), (XblAchievement x) => new XblAchievement(x));
				return num;
			}

			// Token: 0x06000EBD RID: 3773 RVA: 0x000122AC File Offset: 0x000104AC
			public static int XblAchievementsManagerResultDuplicateHandle(XblAchievementsManagerResultHandle handle, out XblAchievementsManagerResultHandle duplicatedHandle)
			{
				if (handle == null)
				{
					duplicatedHandle = null;
					return -2147024809;
				}
				XblAchievementsManagerResultHandle interopHandle;
				return XblAchievementsManagerResultHandle.WrapAndReturnHResult(XblInterop.XblAchievementsManagerResultDuplicateHandle(handle.Handle, out interopHandle), interopHandle, out duplicatedHandle);
			}

			// Token: 0x06000EBE RID: 3774 RVA: 0x000122DF File Offset: 0x000104DF
			public static void XblAchievementsManagerResultCloseHandle(XblAchievementsManagerResultHandle handle)
			{
				if (handle == null)
				{
					return;
				}
				handle.Close();
			}

			// Token: 0x06000EBF RID: 3775 RVA: 0x000122F1 File Offset: 0x000104F1
			public static int XblAchievementsManagerAddLocalUser(XUserHandle user)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblAchievementsManagerAddLocalUser(user.Handle, SDK.defaultQueue);
			}

			// Token: 0x06000EC0 RID: 3776 RVA: 0x00012312 File Offset: 0x00010512
			public static int XblAchievementsManagerRemoveLocalUser(XUserHandle user)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblAchievementsManagerRemoveLocalUser(user.Handle);
			}

			// Token: 0x06000EC1 RID: 3777 RVA: 0x0001232E File Offset: 0x0001052E
			public static int XblAchievementsManagerIsUserInitialized(ulong xboxUserId)
			{
				return XblInterop.XblAchievementsManagerIsUserInitialized(xboxUserId);
			}

			// Token: 0x06000EC2 RID: 3778 RVA: 0x00012338 File Offset: 0x00010538
			public static int XblAchievementsManagerDoWork(out XblAchievementsManagerEvent[] events)
			{
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblAchievementsManagerDoWork(out rawPtr, out count);
				if (HR.FAILED(num) || count.IsZero)
				{
					events = null;
					return num;
				}
				events = Converters.PtrToClassArray<XblAchievementsManagerEvent, XblAchievementsManagerEvent>(rawPtr, count, (XblAchievementsManagerEvent x) => new XblAchievementsManagerEvent(x));
				return num;
			}

			// Token: 0x06000EC3 RID: 3779 RVA: 0x00012390 File Offset: 0x00010590
			public static int XblAchievementsManagerGetAchievement(ulong xboxUserId, string achievementId, out XblAchievementsManagerResultHandle handle)
			{
				byte[] achievementId2 = Converters.StringToNullTerminatedUTF8ByteArray(achievementId);
				XblAchievementsManagerResultHandle interopHandle;
				return XblAchievementsManagerResultHandle.WrapAndReturnHResult(XblInterop.XblAchievementsManagerGetAchievement(xboxUserId, achievementId2, out interopHandle), interopHandle, out handle);
			}

			// Token: 0x06000EC4 RID: 3780 RVA: 0x000123B4 File Offset: 0x000105B4
			public static int XblAchievementsManagerGetAchievements(ulong xboxUserId, XblAchievementOrderBy sortField, XblAchievementsManagerSortOrder sortOrder, out XblAchievementsManagerResultHandle handle)
			{
				XblAchievementsManagerResultHandle interopHandle;
				return XblAchievementsManagerResultHandle.WrapAndReturnHResult(XblInterop.XblAchievementsManagerGetAchievements(xboxUserId, sortField, sortOrder, out interopHandle), interopHandle, out handle);
			}

			// Token: 0x06000EC5 RID: 3781 RVA: 0x000123D4 File Offset: 0x000105D4
			public static int XblAchievementsManagerGetAchievementsByState(ulong xboxUserId, XblAchievementOrderBy sortField, XblAchievementsManagerSortOrder sortOrder, XblAchievementProgressState achievementState, out XblAchievementsManagerResultHandle handle)
			{
				XblAchievementsManagerResultHandle interopHandle;
				return XblAchievementsManagerResultHandle.WrapAndReturnHResult(XblInterop.XblAchievementsManagerGetAchievementsByState(xboxUserId, sortField, sortOrder, achievementState, out interopHandle), interopHandle, out handle);
			}

			// Token: 0x06000EC6 RID: 3782 RVA: 0x000123F4 File Offset: 0x000105F4
			public static int XblAchievementsManagerUpdateAchievement(ulong xboxUserId, string achievementId, byte currentProgress)
			{
				byte[] achievementId2 = Converters.StringToNullTerminatedUTF8ByteArray(achievementId);
				return XblInterop.XblAchievementsManagerUpdateAchievement(xboxUserId, achievementId2, currentProgress);
			}

			// Token: 0x06000EC7 RID: 3783 RVA: 0x00012410 File Offset: 0x00010610
			public static XblErrorCondition XblGetErrorCondition(int hr)
			{
				return XblInterop.XblGetErrorCondition(hr);
			}

			// Token: 0x06000EC8 RID: 3784 RVA: 0x00012418 File Offset: 0x00010618
			public static XblHresult XblGetHRESULT(int hr)
			{
				XblHresult result = XblHresult.HRESULT_NOT_RECOGNIZED;
				try
				{
					result = (XblHresult)Enum.GetValues(typeof(XblHresult)).GetValue(hr);
				}
				catch (IndexOutOfRangeException)
				{
					result = XblHresult.HRESULT_NOT_RECOGNIZED;
				}
				return result;
			}

			// Token: 0x06000EC9 RID: 3785 RVA: 0x0001245C File Offset: 0x0001065C
			public static int XblEventsWriteInGameEvent(XblContextHandle xboxLiveContext, string eventName, string dimensionsJson, string measurementsJson)
			{
				if (xboxLiveContext == null)
				{
					return -2147024809;
				}
				return XblInterop.XblEventsWriteInGameEvent(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(eventName), Converters.StringToNullTerminatedUTF8ByteArray(dimensionsJson), Converters.StringToNullTerminatedUTF8ByteArray(measurementsJson));
			}

			// Token: 0x06000ECA RID: 3786 RVA: 0x0001248A File Offset: 0x0001068A
			public static int HCSettingsSetTraceLevel(HCTraceLevel traceLevel)
			{
				return XblInterop.HCSettingsSetTraceLevel(traceLevel);
			}

			// Token: 0x06000ECB RID: 3787 RVA: 0x00012492 File Offset: 0x00010692
			public static int HCSettingsGetTraceLevel(out HCTraceLevel traceLevel)
			{
				return XblInterop.HCSettingsGetTraceLevel(out traceLevel);
			}

			// Token: 0x06000ECC RID: 3788 RVA: 0x0001249A File Offset: 0x0001069A
			public static void HCTraceSetTraceToDebugger(bool traceToDebugger)
			{
				XblInterop.HCTraceSetTraceToDebugger(traceToDebugger);
			}

			// Token: 0x06000ECD RID: 3789 RVA: 0x000124A2 File Offset: 0x000106A2
			public static int XblHttpCallRequestSetRequestBodyBytes(XblHttpCallHandle call, byte[] requestBodyBytes)
			{
				if (call == null || requestBodyBytes == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetRequestBodyBytes(call.Handle, requestBodyBytes, (uint)requestBodyBytes.Length);
			}

			// Token: 0x06000ECE RID: 3790 RVA: 0x000124C5 File Offset: 0x000106C5
			public static int XblHttpCallGetNetworkErrorCode(XblHttpCallHandle call, out int networkErrorCode, out uint platformNetworkErrorCode)
			{
				if (call == null)
				{
					networkErrorCode = 0;
					platformNetworkErrorCode = 0U;
					return -2147024809;
				}
				return XblInterop.XblHttpCallGetNetworkErrorCode(call.Handle, out networkErrorCode, out platformNetworkErrorCode);
			}

			// Token: 0x06000ECF RID: 3791 RVA: 0x000124E9 File Offset: 0x000106E9
			public static int XblHttpCallRequestSetLongHttpCall(XblHttpCallHandle call, bool longHttpCall)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetLongHttpCall(call.Handle, new NativeBool(longHttpCall));
			}

			// Token: 0x06000ED0 RID: 3792 RVA: 0x0001250C File Offset: 0x0001070C
			public static void XblHttpCallPerformAsync(XblHttpCallHandle call, XblHttpCallResponseBodyType type, XblHttpCallPerformCompleted completionRoutine)
			{
				if (call == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				int num = XblInterop.XblHttpCallPerformAsync(call.Handle, type, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000ED1 RID: 3793 RVA: 0x00012584 File Offset: 0x00010784
			public static int XblHttpCallSetTracing(XblHttpCallHandle call, bool traceCall)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallSetTracing(call.Handle, new NativeBool(traceCall));
			}

			// Token: 0x06000ED2 RID: 3794 RVA: 0x000125A8 File Offset: 0x000107A8
			public static int XblHttpCallCreate(XblContextHandle xblContext, string method, string url, out XblHttpCallHandle call)
			{
				if (xblContext == null)
				{
					call = null;
					return -2147024809;
				}
				XblHttpCallHandle interopHandle;
				return XblHttpCallHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblHttpCallCreate(xblContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(method), Converters.StringToNullTerminatedUTF8ByteArray(url), out interopHandle), interopHandle, out call);
			}

			// Token: 0x06000ED3 RID: 3795 RVA: 0x000125E7 File Offset: 0x000107E7
			public static void XblHttpCallCloseHandle(XblHttpCallHandle call)
			{
				if (call == null)
				{
					return;
				}
				XblInterop.XblHttpCallCloseHandle(call.Handle);
			}

			// Token: 0x06000ED4 RID: 3796 RVA: 0x000125FE File Offset: 0x000107FE
			public static int XblHttpCallRequestSetRequestBodyString(XblHttpCallHandle call, string requestBodyString)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetRequestBodyString(call.Handle, Converters.StringToNullTerminatedUTF8ByteArray(requestBodyString));
			}

			// Token: 0x06000ED5 RID: 3797 RVA: 0x00012620 File Offset: 0x00010820
			public static int XblHttpCallGetResponseString(XblHttpCallHandle call, out string responseString)
			{
				responseString = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr utf8StringPtr;
				int num = XblInterop.XblHttpCallGetResponseString(call.Handle, out utf8StringPtr);
				if (HR.SUCCEEDED(num))
				{
					responseString = utf8StringPtr.GetString();
				}
				return num;
			}

			// Token: 0x06000ED6 RID: 3798 RVA: 0x00012660 File Offset: 0x00010860
			public static int XblHttpCallGetHeaderAtIndex(XblHttpCallHandle call, uint headerIndex, out string headerName, out string headerValue)
			{
				headerName = null;
				headerValue = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr utf8StringPtr;
				UTF8StringPtr utf8StringPtr2;
				int num = XblInterop.XblHttpCallGetHeaderAtIndex(call.Handle, headerIndex, out utf8StringPtr, out utf8StringPtr2);
				if (HR.SUCCEEDED(num))
				{
					headerName = utf8StringPtr.GetString();
					headerValue = utf8StringPtr2.GetString();
				}
				return num;
			}

			// Token: 0x06000ED7 RID: 3799 RVA: 0x000126AC File Offset: 0x000108AC
			public static int XblHttpCallGetPlatformNetworkErrorMessage(XblHttpCallHandle call, out string platformNetworkErrorMessage)
			{
				platformNetworkErrorMessage = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr utf8StringPtr;
				int num = XblInterop.XblHttpCallGetPlatformNetworkErrorMessage(call.Handle, out utf8StringPtr);
				if (HR.SUCCEEDED(num))
				{
					platformNetworkErrorMessage = utf8StringPtr.GetString();
				}
				return num;
			}

			// Token: 0x06000ED8 RID: 3800 RVA: 0x000126EC File Offset: 0x000108EC
			public static int XblHttpCallGetResponseBodyBytes(XblHttpCallHandle call, out byte[] buffer)
			{
				buffer = null;
				if (call == null)
				{
					return -2147024809;
				}
				SizeT bufferSize;
				int num = XblInterop.XblHttpCallGetResponseBodyBytesSize(call.Handle, out bufferSize);
				if (HR.SUCCEEDED(num))
				{
					buffer = new byte[bufferSize.ToInt32()];
					SizeT sizeT;
					return XblInterop.XblHttpCallGetResponseBodyBytes(call.Handle, bufferSize, buffer, out sizeT);
				}
				return num;
			}

			// Token: 0x06000ED9 RID: 3801 RVA: 0x00012741 File Offset: 0x00010941
			public static int XblHttpCallRequestSetRetryAllowed(XblHttpCallHandle call, bool retryAllowed)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetRetryAllowed(call.Handle, new NativeBool(retryAllowed));
			}

			// Token: 0x06000EDA RID: 3802 RVA: 0x00012763 File Offset: 0x00010963
			public static int XblHttpCallRequestSetHeader(XblHttpCallHandle call, string headerName, string headerValue, bool allowTracing)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetHeader(call.Handle, Converters.StringToNullTerminatedUTF8ByteArray(headerName), Converters.StringToNullTerminatedUTF8ByteArray(headerValue), new NativeBool(allowTracing));
			}

			// Token: 0x06000EDB RID: 3803 RVA: 0x00012794 File Offset: 0x00010994
			public static int XblHttpCallDuplicateHandle(XblHttpCallHandle call, out XblHttpCallHandle duplicateHandle)
			{
				if (call == null)
				{
					duplicateHandle = null;
					return -2147024809;
				}
				XblHttpCallHandle interopHandle;
				return XblHttpCallHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblHttpCallDuplicateHandle(call.Handle, out interopHandle), interopHandle, out duplicateHandle);
			}

			// Token: 0x06000EDC RID: 3804 RVA: 0x000127C7 File Offset: 0x000109C7
			public static int XblHttpCallGetNumHeaders(XblHttpCallHandle call, out uint numHeaders)
			{
				if (call == null)
				{
					numHeaders = 0U;
					return -2147024809;
				}
				return XblInterop.XblHttpCallGetNumHeaders(call.Handle, out numHeaders);
			}

			// Token: 0x06000EDD RID: 3805 RVA: 0x000127E7 File Offset: 0x000109E7
			public static int XblHttpCallGetStatusCode(XblHttpCallHandle call, out uint statusCode)
			{
				if (call == null)
				{
					statusCode = 0U;
					return -2147024809;
				}
				return XblInterop.XblHttpCallGetStatusCode(call.Handle, out statusCode);
			}

			// Token: 0x06000EDE RID: 3806 RVA: 0x00012808 File Offset: 0x00010A08
			public static int XblHttpCallGetHeader(XblHttpCallHandle call, string headerName, out string headerValue)
			{
				headerValue = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr utf8StringPtr;
				int num = XblInterop.XblHttpCallGetHeader(call.Handle, Converters.StringToNullTerminatedUTF8ByteArray(headerName), out utf8StringPtr);
				if (HR.SUCCEEDED(num))
				{
					headerValue = utf8StringPtr.GetString();
				}
				return num;
			}

			// Token: 0x06000EDF RID: 3807 RVA: 0x0001284C File Offset: 0x00010A4C
			public static int XblHttpCallGetRequestUrl(XblHttpCallHandle call, out string url)
			{
				url = null;
				if (call == null)
				{
					return -2147024809;
				}
				UTF8StringPtr utf8StringPtr;
				int num = XblInterop.XblHttpCallGetRequestUrl(call.Handle, out utf8StringPtr);
				if (HR.SUCCEEDED(num))
				{
					url = utf8StringPtr.GetString();
				}
				return num;
			}

			// Token: 0x06000EE0 RID: 3808 RVA: 0x00012889 File Offset: 0x00010A89
			public static int XblHttpCallRequestSetRetryCacheId(XblHttpCallHandle call, uint retryAfterCacheId)
			{
				if (call == null)
				{
					return -2147024809;
				}
				return XblInterop.XblHttpCallRequestSetRetryCacheId(call.Handle, retryAfterCacheId);
			}

			// Token: 0x06000EE1 RID: 3809 RVA: 0x000128A8 File Offset: 0x00010AA8
			public static void XblLeaderboardGetLeaderboardAsync(XblContextHandle xboxLiveContext, XblLeaderboardQuery leaderboardQuery, XblLeaderboardGetLeaderboardCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblLeaderboardGetLeaderboardResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						Debug.Log(string.Format("XblLeaderboardGetLeaderboardResultSize() Failed with: 0x{0:X8}", num2));
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblLeaderboardGetLeaderboardResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							Debug.Log(string.Format("XblLeaderboardGetLeaderboardResult() Failed with: 0x{0:X8}", num2));
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass<XblLeaderboardResult, XblLeaderboardResult>(rawPtr, (XblLeaderboardResult r) => new XblLeaderboardResult(r)));
						}
					}
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					int num = XblInterop.XblLeaderboardGetLeaderboardAsync(xboxLiveContext.Handle, new XblLeaderboardQuery(leaderboardQuery, disposableCollection), block2);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			// Token: 0x06000EE2 RID: 3810 RVA: 0x00012944 File Offset: 0x00010B44
			public static void XblLeaderboardResultGetNextAsync(XblContextHandle xboxLiveContext, XblLeaderboardResult leaderboardResult, uint maxItems, XblLeaderboardGetNextCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblLeaderboardResultGetNextResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblLeaderboardResultGetNextResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass<XblLeaderboardResult, XblLeaderboardResult>(rawPtr, (XblLeaderboardResult r) => new XblLeaderboardResult(r)));
						}
					}
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XblLeaderboardResult xblLeaderboardResult = new XblLeaderboardResult(leaderboardResult, disposableCollection);
					int num = XblInterop.XblLeaderboardResultGetNextAsync(xboxLiveContext.Handle, ref xblLeaderboardResult, maxItems, block2);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			// Token: 0x06000EE3 RID: 3811 RVA: 0x000129E8 File Offset: 0x00010BE8
			public static void XblMatchmakingCreateMatchTicketAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionReference ticketSessionReference, string matchmakingServiceConfigurationId, string hopperName, ulong ticketTimeout, XblPreserveSessionMode preserveSession, string ticketAttributesJson, SDK.XBL.XblMatchmakingCreateMatchTicketHandleResult completionRoutine)
			{
				if (xboxLiveContext == null || ticketSessionReference == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblCreateMatchTicketResponse interopHandle;
					int num2 = XblInterop.XblMatchmakingCreateMatchTicketResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblCreateMatchTicketResponse(interopHandle));
				});
				int num = XblInterop.XblMatchmakingCreateMatchTicketAsync(xboxLiveContext.Handle, new XblMultiplayerSessionReference(ticketSessionReference), Converters.StringToNullTerminatedUTF8ByteArray(matchmakingServiceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(hopperName), ticketTimeout, preserveSession, Converters.StringToNullTerminatedUTF8ByteArray(ticketAttributesJson), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000EE4 RID: 3812 RVA: 0x00012A84 File Offset: 0x00010C84
			public static void XblMatchmakingDeleteMatchTicketAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, string ticketId, SDK.XBL.XblMatchmakingDeleteMatchTicketHandleResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				int num = XblInterop.XblMatchmakingDeleteMatchTicketAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(hopperName), Converters.StringToNullTerminatedUTF8ByteArray(ticketId), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000EE5 RID: 3813 RVA: 0x00012B10 File Offset: 0x00010D10
			public static void XblMatchmakingGetMatchTicketDetailsAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, string ticketId, SDK.XBL.XblMatchmakingGetMatchTicketDetailsHandleResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblMatchmakingGetMatchTicketDetailsResultSize(block, out bufferSize);
					if (HR.FAILED(num2) || bufferSize.IsZero)
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblMatchmakingGetMatchTicketDetailsResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblMatchTicketDetailsResponse[] array = Converters.PtrToClassArray<XblMatchTicketDetailsResponse, XblMatchTicketDetailsResponse>(rawPtr, 1U, (XblMatchTicketDetailsResponse r) => new XblMatchTicketDetailsResponse(r));
							completionRoutine(num2, array[0]);
						}
					}
				});
				int num = XblInterop.XblMatchmakingGetMatchTicketDetailsAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(hopperName), Converters.StringToNullTerminatedUTF8ByteArray(ticketId), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000EE6 RID: 3814 RVA: 0x00012B9C File Offset: 0x00010D9C
			public static void XblMatchmakingGetHopperStatisticsAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, SDK.XBL.XblMatchmakingGetHopperStatisticsHandleResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblMatchmakingGetMatchTicketDetailsResultSize(block, out bufferSize);
					if (HR.FAILED(num2) || bufferSize.IsZero)
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblMatchmakingGetMatchTicketDetailsResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblHopperStatisticsResponse[] array = Converters.PtrToClassArray<XblHopperStatisticsResponse, XblHopperStatisticsResponse>(rawPtr, 1U, (XblHopperStatisticsResponse r) => new XblHopperStatisticsResponse(r));
							completionRoutine(num2, array[0]);
						}
					}
				});
				int num = XblInterop.XblMatchmakingGetHopperStatisticsAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(hopperName), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000EE7 RID: 3815 RVA: 0x00012C24 File Offset: 0x00010E24
			public static XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(ulong xboxUserId, XblMultiplayerSessionReference sessionRef, XblMultiplayerSessionInitArgs initArgs)
			{
				XblMultiplayerSessionHandle result;
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XblMultiplayerSessionReference xblMultiplayerSessionReference = new XblMultiplayerSessionReference(sessionRef);
					XblMultiplayerSessionInitArgs xblMultiplayerSessionInitArgs = new XblMultiplayerSessionInitArgs(initArgs, disposableCollection);
					result = new XblMultiplayerSessionHandle(XblInterop.XblMultiplayerSessionCreateHandle(xboxUserId, ref xblMultiplayerSessionReference, ref xblMultiplayerSessionInitArgs));
				}
				return result;
			}

			// Token: 0x06000EE8 RID: 3816 RVA: 0x00012C78 File Offset: 0x00010E78
			public static void XblMultiplayerSessionCloseHandle(XblMultiplayerSessionHandle handle)
			{
				if (handle != null)
				{
					handle.Close();
				}
			}

			// Token: 0x06000EE9 RID: 3817 RVA: 0x00012C8C File Offset: 0x00010E8C
			public static DateTime XblMultiplayerSessionTimeOfSession(XblMultiplayerSessionHandle handle)
			{
				if (handle == null)
				{
					return default(DateTime);
				}
				return XblInterop.XblMultiplayerSessionTimeOfSession(handle.Handle).DateTime;
			}

			// Token: 0x06000EEA RID: 3818 RVA: 0x00012CC0 File Offset: 0x00010EC0
			public unsafe static XblMultiplayerSessionInitializationInfo XblMultiplayerSessionGetInitializationInfo(XblMultiplayerSessionHandle handle)
			{
				XblMultiplayerSessionInitializationInfo* ptr = null;
				if (handle != null)
				{
					ptr = XblInterop.XblMultiplayerSessionGetInitializationInfo(handle.Handle);
				}
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionInitializationInfo(*ptr);
			}

			// Token: 0x06000EEB RID: 3819 RVA: 0x00012CF7 File Offset: 0x00010EF7
			public static XblMultiplayerSessionChangeTypes XblMultiplayerSessionSubscribedChangeTypes(XblMultiplayerSessionHandle handle)
			{
				if (handle == null)
				{
					return XblMultiplayerSessionChangeTypes.None;
				}
				return XblInterop.XblMultiplayerSessionSubscribedChangeTypes(handle.Handle);
			}

			// Token: 0x06000EEC RID: 3820 RVA: 0x00012D10 File Offset: 0x00010F10
			public static int XblMultiplayerSessionHostCandidates(XblMultiplayerSessionHandle handle, out XblDeviceToken[] deviceTokens)
			{
				deviceTokens = null;
				if (handle == null)
				{
					return -2147024809;
				}
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblMultiplayerSessionHostCandidates(handle.Handle, out rawPtr, out count);
				if (HR.SUCCEEDED(num))
				{
					deviceTokens = Converters.PtrToClassArray<XblDeviceToken, XblDeviceToken>(rawPtr, count, (XblDeviceToken x) => new XblDeviceToken(x));
				}
				return num;
			}

			// Token: 0x06000EED RID: 3821 RVA: 0x00012D70 File Offset: 0x00010F70
			public unsafe static XblMultiplayerSessionReference XblMultiplayerSessionSessionReference(XblMultiplayerSessionHandle handle)
			{
				XblMultiplayerSessionReference* ptr = null;
				if (handle != null)
				{
					ptr = XblInterop.XblMultiplayerSessionSessionReference(handle.Handle);
				}
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionReference(*ptr);
			}

			// Token: 0x06000EEE RID: 3822 RVA: 0x00012DA8 File Offset: 0x00010FA8
			public unsafe static XblMultiplayerSessionConstants XblMultiplayerSessionSessionConstants(XblMultiplayerSessionHandle handle)
			{
				if (handle == null)
				{
					return null;
				}
				XblMultiplayerSessionConstants* ptr = XblInterop.XblMultiplayerSessionSessionConstants(handle.Handle);
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionConstants(*ptr);
			}

			// Token: 0x06000EEF RID: 3823 RVA: 0x00012DDE File Offset: 0x00010FDE
			public static void XblMultiplayerSessionConstantsSetMaxMembersInSession(XblMultiplayerSessionHandle handle, uint maxMembersInSession)
			{
				if (handle != null)
				{
					XblInterop.XblMultiplayerSessionConstantsSetMaxMembersInSession(handle.Handle, maxMembersInSession);
				}
			}

			// Token: 0x06000EF0 RID: 3824 RVA: 0x00012DF5 File Offset: 0x00010FF5
			public static void XblMultiplayerSessionConstantsSetVisibility(XblMultiplayerSessionHandle handle, XblMultiplayerSessionVisibility visibility)
			{
				if (handle != null)
				{
					XblInterop.XblMultiplayerSessionConstantsSetVisibility(handle.Handle, visibility);
				}
			}

			// Token: 0x06000EF1 RID: 3825 RVA: 0x00012E0C File Offset: 0x0001100C
			public static int XblMultiplayerSessionConstantsSetTimeouts(XblMultiplayerSessionHandle handle, ulong memberReservedTimeout, ulong memberInactiveTimeout, ulong memberReadyTimeout, ulong sessionEmptyTimeout)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionConstantsSetTimeouts(handle.Handle, memberReservedTimeout, memberInactiveTimeout, memberReadyTimeout, sessionEmptyTimeout);
			}

			// Token: 0x06000EF2 RID: 3826 RVA: 0x00012E2D File Offset: 0x0001102D
			public static int XblMultiplayerSessionConstantsSetQosConnectivityMetrics(XblMultiplayerSessionHandle handle, bool enableLatencyMetric, bool enableBandwidthDownMetric, bool enableBandwidthUpMetric, bool enableCustomMetric)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionConstantsSetQosConnectivityMetrics(handle.Handle, new NativeBool(enableLatencyMetric), new NativeBool(enableBandwidthDownMetric), new NativeBool(enableBandwidthUpMetric), new NativeBool(enableCustomMetric));
			}

			// Token: 0x06000EF3 RID: 3827 RVA: 0x00012E62 File Offset: 0x00011062
			public static int XblMultiplayerSessionConstantsSetMemberInitialization(XblMultiplayerSessionHandle handle, XblMultiplayerMemberInitialization memberInitialization)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionConstantsSetMemberInitialization(handle.Handle, new XblMultiplayerMemberInitialization(memberInitialization));
			}

			// Token: 0x06000EF4 RID: 3828 RVA: 0x00012E84 File Offset: 0x00011084
			public static int XblMultiplayerSessionConstantsSetPeerToPeerRequirements(XblMultiplayerSessionHandle handle, XblMultiplayerPeerToPeerRequirements requirements)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionConstantsSetPeerToPeerRequirements(handle.Handle, new XblMultiplayerPeerToPeerRequirements(requirements));
			}

			// Token: 0x06000EF5 RID: 3829 RVA: 0x00012EA6 File Offset: 0x000110A6
			public static int XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(XblMultiplayerSessionHandle handle, string measurementServerAddressesJson)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(measurementServerAddressesJson));
			}

			// Token: 0x06000EF6 RID: 3830 RVA: 0x00012EC8 File Offset: 0x000110C8
			public static int XblMultiplayerSessionConstantsSetCapabilities(XblMultiplayerSessionHandle handle, XblMultiplayerSessionCapabilities capabilities)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionConstantsSetCapabilities(handle.Handle, (capabilities == null) ? default(XblMultiplayerSessionCapabilities) : new XblMultiplayerSessionCapabilities(capabilities));
			}

			// Token: 0x06000EF7 RID: 3831 RVA: 0x00012F04 File Offset: 0x00011104
			public unsafe static XblMultiplayerSessionProperties XblMultiplayerSessionSessionProperties(XblMultiplayerSessionHandle handle)
			{
				if (handle == null)
				{
					return null;
				}
				XblMultiplayerSessionProperties* ptr = XblInterop.XblMultiplayerSessionSessionProperties(handle.Handle);
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionProperties(*ptr);
			}

			// Token: 0x06000EF8 RID: 3832 RVA: 0x00012F3C File Offset: 0x0001113C
			public static int XblMultiplayerSessionPropertiesSetKeywords(XblMultiplayerSessionHandle handle, string[] keywords)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				int result;
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(keywords))
				{
					result = XblInterop.XblMultiplayerSessionPropertiesSetKeywords(handle.Handle, disposableBuffer.IntPtr, new SizeT(keywords.Length));
				}
				return result;
			}

			// Token: 0x06000EF9 RID: 3833 RVA: 0x00012F98 File Offset: 0x00011198
			public static void XblMultiplayerSessionPropertiesSetJoinRestriction(XblMultiplayerSessionHandle handle, XblMultiplayerSessionRestriction joinRestriction)
			{
				if (handle == null)
				{
					return;
				}
				XblInterop.XblMultiplayerSessionPropertiesSetJoinRestriction(handle.Handle, joinRestriction);
			}

			// Token: 0x06000EFA RID: 3834 RVA: 0x00012FB0 File Offset: 0x000111B0
			public static void XblMultiplayerSessionPropertiesSetReadRestriction(XblMultiplayerSessionHandle handle, XblMultiplayerSessionRestriction readRestriction)
			{
				if (handle == null)
				{
					return;
				}
				XblInterop.XblMultiplayerSessionPropertiesSetReadRestriction(handle.Handle, readRestriction);
			}

			// Token: 0x06000EFB RID: 3835 RVA: 0x00012FC8 File Offset: 0x000111C8
			public static int XblMultiplayerSessionPropertiesSetTurnCollection(XblMultiplayerSessionHandle handle, uint[] turnCollectionMemberIds)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionPropertiesSetTurnCollection(handle.Handle, turnCollectionMemberIds, new SizeT(turnCollectionMemberIds.Length));
				}
				return -2147024809;
			}

			// Token: 0x06000EFC RID: 3836 RVA: 0x00012FF0 File Offset: 0x000111F0
			public static int XblMultiplayerSessionMembers(XblMultiplayerSessionHandle handle, out XblMultiplayerSessionMember[] members)
			{
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblMultiplayerSessionMembers(handle.Handle, out rawPtr, out count);
				if (HR.FAILED(num) || count.IsZero)
				{
					members = null;
					return num;
				}
				members = Converters.PtrToClassArray<XblMultiplayerSessionMember, XblMultiplayerSessionMember>(rawPtr, count, (XblMultiplayerSessionMember x) => new XblMultiplayerSessionMember(x));
				return num;
			}

			// Token: 0x06000EFD RID: 3837 RVA: 0x0001304C File Offset: 0x0001124C
			public unsafe static XblMultiplayerMatchmakingServer XblMultiplayerSessionMatchmakingServer(XblMultiplayerSessionHandle handle)
			{
				if (handle == null)
				{
					return null;
				}
				XblMultiplayerMatchmakingServer* ptr = XblInterop.XblMultiplayerSessionMatchmakingServer(handle.Handle);
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerMatchmakingServer(*ptr);
			}

			// Token: 0x06000EFE RID: 3838 RVA: 0x00013084 File Offset: 0x00011284
			public unsafe static XblMultiplayerSessionMember XblMultiplayerSessionCurrentUser(XblMultiplayerSessionHandle handle)
			{
				if (handle == null)
				{
					return null;
				}
				XblMultiplayerSessionMember* ptr = XblInterop.XblMultiplayerSessionCurrentUser(handle.Handle);
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionMember(*ptr);
			}

			// Token: 0x06000EFF RID: 3839 RVA: 0x000130BC File Offset: 0x000112BC
			public static int XblMultiplayerSessionCurrentUserSetRoles(XblMultiplayerSessionHandle handle, XblMultiplayerSessionMemberRole[] roles)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				int result;
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					SizeT rolesCount;
					IntPtr roles2 = Converters.ClassArrayToPtr<XblMultiplayerSessionMemberRole, XblMultiplayerSessionMemberRole>(roles, (XblMultiplayerSessionMemberRole role, DisposableCollection collection) => new XblMultiplayerSessionMemberRole(role, disposableCollection), disposableCollection, out rolesCount);
					result = XblInterop.XblMultiplayerSessionCurrentUserSetRoles(handle.Handle, roles2, rolesCount);
				}
				return result;
			}

			// Token: 0x06000F00 RID: 3840 RVA: 0x0001313C File Offset: 0x0001133C
			public static int XblMultiplayerSessionCurrentUserSetEncounters(XblMultiplayerSessionHandle handle, string[] encounters)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				int result;
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(encounters))
				{
					result = XblInterop.XblMultiplayerSessionCurrentUserSetEncounters(handle.Handle, disposableBuffer.IntPtr, new SizeT(encounters.Length));
				}
				return result;
			}

			// Token: 0x06000F01 RID: 3841 RVA: 0x00013198 File Offset: 0x00011398
			public static int XblMultiplayerSessionCurrentUserSetMembersInGroup(XblMultiplayerSessionHandle handle, uint[] memberIds)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionCurrentUserSetMembersInGroup(handle.Handle, memberIds, new SizeT(memberIds.Length));
			}

			// Token: 0x06000F02 RID: 3842 RVA: 0x000131C0 File Offset: 0x000113C0
			public static int XblMultiplayerSessionCurrentUserSetGroups(XblMultiplayerSessionHandle handle, string[] groups)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				int result;
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(groups))
				{
					result = XblInterop.XblMultiplayerSessionCurrentUserSetGroups(handle.Handle, disposableBuffer.IntPtr, new SizeT(groups.Length));
				}
				return result;
			}

			// Token: 0x06000F03 RID: 3843 RVA: 0x0001321C File Offset: 0x0001141C
			public static int XblMultiplayerSessionCurrentUserSetCustomPropertyJson(XblMultiplayerSessionHandle handle, string name, string valueJson)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionCurrentUserSetCustomPropertyJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson));
			}

			// Token: 0x06000F04 RID: 3844 RVA: 0x00013244 File Offset: 0x00011444
			public static int XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(XblMultiplayerSessionHandle handle, string name)
			{
				if (handle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name));
			}

			// Token: 0x06000F05 RID: 3845 RVA: 0x00013266 File Offset: 0x00011466
			public static XblWriteSessionStatus XblMultiplayerSessionWriteStatus(XblMultiplayerSessionHandle handle)
			{
				return XblInterop.XblMultiplayerSessionWriteStatus(handle.Handle);
			}

			// Token: 0x06000F06 RID: 3846 RVA: 0x00013273 File Offset: 0x00011473
			public static int XblMultiplayerSessionJoin(XblMultiplayerSessionHandle handle, string memberCustomConstantsJson, bool initializeRequested, bool joinWithActiveStatus)
			{
				return XblInterop.XblMultiplayerSessionJoin(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(memberCustomConstantsJson), initializeRequested, joinWithActiveStatus);
			}

			// Token: 0x06000F07 RID: 3847 RVA: 0x00013288 File Offset: 0x00011488
			public static void XblMultiplayerSessionSetHostDeviceToken(XblMultiplayerSessionHandle handle, XblDeviceToken hostDeviceToken)
			{
				if (handle == null)
				{
					return;
				}
				XblInterop.XblMultiplayerSessionSetHostDeviceToken(handle.Handle, new XblDeviceToken(hostDeviceToken));
			}

			// Token: 0x06000F08 RID: 3848 RVA: 0x000132A5 File Offset: 0x000114A5
			public static void XblMultiplayerSessionSetClosed(XblMultiplayerSessionHandle handle, bool closed)
			{
				if (handle != null)
				{
					XblInterop.XblMultiplayerSessionSetClosed(handle.Handle, closed);
				}
			}

			// Token: 0x06000F09 RID: 3849 RVA: 0x000132BC File Offset: 0x000114BC
			public static int XblMultiplayerSessionSetSessionChangeSubscription(XblMultiplayerSessionHandle handle, XblMultiplayerSessionChangeTypes changeTypes)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionSetSessionChangeSubscription(handle.Handle, changeTypes);
				}
				return -2147024809;
			}

			// Token: 0x06000F0A RID: 3850 RVA: 0x000132D9 File Offset: 0x000114D9
			public static int XblMultiplayerSessionLeave(XblMultiplayerSessionHandle handle)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionLeave(handle.Handle);
				}
				return -2147024809;
			}

			// Token: 0x06000F0B RID: 3851 RVA: 0x000132F5 File Offset: 0x000114F5
			public static int XblMultiplayerSessionCurrentUserSetStatus(XblMultiplayerSessionHandle handle, XblMultiplayerSessionMemberStatus status)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionCurrentUserSetStatus(handle.Handle, status);
				}
				return -2147024809;
			}

			// Token: 0x06000F0C RID: 3852 RVA: 0x00013312 File Offset: 0x00011512
			public static int XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(XblMultiplayerSessionHandle handle, string value)
			{
				if (handle != null)
				{
					return XblInterop.XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(value));
				}
				return -2147024809;
			}

			// Token: 0x06000F0D RID: 3853 RVA: 0x00013334 File Offset: 0x00011534
			public static int XblFormatSecureDeviceAddress(string deviceId, out string address)
			{
				if (deviceId != null)
				{
					XblFormattedSecureDeviceAddress xblFormattedSecureDeviceAddress;
					int result = XblInterop.XblFormatSecureDeviceAddress(Converters.StringToNullTerminatedUTF8ByteArray(deviceId), out xblFormattedSecureDeviceAddress);
					address = xblFormattedSecureDeviceAddress.GetValue();
					return result;
				}
				address = null;
				return -2147024809;
			}

			// Token: 0x06000F0E RID: 3854 RVA: 0x00013363 File Offset: 0x00011563
			public static void XblMultiplayerSearchHandleCloseHandle(XblMultiplayerSearchHandle handle)
			{
				if (handle != null)
				{
					handle.Close();
				}
			}

			// Token: 0x06000F0F RID: 3855 RVA: 0x00013374 File Offset: 0x00011574
			public static int XblMultiplayerSearchHandleGetSessionReference(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionReference sessionRef)
			{
				XblMultiplayerSessionReference interopStruct;
				int num = XblInterop.XblMultiplayerSearchHandleGetSessionReference(handle.Handle, out interopStruct);
				if (HR.FAILED(num))
				{
					sessionRef = null;
					return num;
				}
				sessionRef = new XblMultiplayerSessionReference(interopStruct);
				return num;
			}

			// Token: 0x06000F10 RID: 3856 RVA: 0x000133A4 File Offset: 0x000115A4
			public static int XblMultiplayerSearchHandleGetId(XblMultiplayerSearchHandle handle, out string id)
			{
				UTF8StringPtr utf8StringPtr;
				int num = XblInterop.XblMultiplayerSearchHandleGetId(handle.Handle, out utf8StringPtr);
				if (HR.FAILED(num))
				{
					id = null;
					return num;
				}
				id = utf8StringPtr.GetString();
				return num;
			}

			// Token: 0x06000F11 RID: 3857 RVA: 0x000133D4 File Offset: 0x000115D4
			public static int XblMultiplayerSearchHandleGetSessionOwnerXuids(XblMultiplayerSearchHandle handle, out ulong[] xuids)
			{
				IntPtr rawPtr;
				SizeT sizeT;
				int num = XblInterop.XblMultiplayerSearchHandleGetSessionOwnerXuids(handle.Handle, out rawPtr, out sizeT);
				if (HR.FAILED(num) || sizeT.IsZero)
				{
					xuids = null;
					return num;
				}
				xuids = Converters.PtrToClassArray<ulong, ulong>(rawPtr, sizeT.ToUInt32(), (ulong x) => x);
				return num;
			}

			// Token: 0x06000F12 RID: 3858 RVA: 0x00013438 File Offset: 0x00011638
			public static int XblMultiplayerSearchHandleGetTags(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionTag[] tags)
			{
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblMultiplayerSearchHandleGetTags(handle.Handle, out rawPtr, out count);
				if (HR.FAILED(num) || count.IsZero)
				{
					tags = null;
					return num;
				}
				tags = Converters.PtrToClassArray<XblMultiplayerSessionTag, XblMultiplayerSessionTag>(rawPtr, count, (XblMultiplayerSessionTag x) => new XblMultiplayerSessionTag(x));
				return num;
			}

			// Token: 0x06000F13 RID: 3859 RVA: 0x00013494 File Offset: 0x00011694
			public static int XblMultiplayerSearchHandleGetStringAttributes(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionStringAttribute[] attributes)
			{
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblMultiplayerSearchHandleGetStringAttributes(handle.Handle, out rawPtr, out count);
				if (HR.FAILED(num) || count.IsZero)
				{
					attributes = null;
					return num;
				}
				attributes = Converters.PtrToClassArray<XblMultiplayerSessionStringAttribute, XblMultiplayerSessionStringAttribute>(rawPtr, count, (XblMultiplayerSessionStringAttribute x) => new XblMultiplayerSessionStringAttribute(x));
				return num;
			}

			// Token: 0x06000F14 RID: 3860 RVA: 0x000134F0 File Offset: 0x000116F0
			public static int XblMultiplayerSearchHandleGetNumberAttributes(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionNumberAttribute[] attributes)
			{
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblMultiplayerSearchHandleGetNumberAttributes(handle.Handle, out rawPtr, out count);
				if (HR.FAILED(num) || count.IsZero)
				{
					attributes = null;
					return num;
				}
				attributes = Converters.PtrToClassArray<XblMultiplayerSessionNumberAttribute, XblMultiplayerSessionNumberAttribute>(rawPtr, count, (XblMultiplayerSessionNumberAttribute x) => new XblMultiplayerSessionNumberAttribute(x));
				return num;
			}

			// Token: 0x06000F15 RID: 3861 RVA: 0x0001354C File Offset: 0x0001174C
			public static int XblMultiplayerSearchHandleGetVisibility(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionVisibility visibility)
			{
				return XblInterop.XblMultiplayerSearchHandleGetVisibility(handle.Handle, out visibility);
			}

			// Token: 0x06000F16 RID: 3862 RVA: 0x0001355A File Offset: 0x0001175A
			public static int XblMultiplayerSearchHandleGetJoinRestriction(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionRestriction joinRestriction)
			{
				return XblInterop.XblMultiplayerSearchHandleGetJoinRestriction(handle.Handle, out joinRestriction);
			}

			// Token: 0x06000F17 RID: 3863 RVA: 0x00013568 File Offset: 0x00011768
			public static int XblMultiplayerSearchHandleGetSessionClosed(XblMultiplayerSearchHandle handle, out bool closed)
			{
				return XblInterop.XblMultiplayerSearchHandleGetSessionClosed(handle.Handle, out closed);
			}

			// Token: 0x06000F18 RID: 3864 RVA: 0x00013578 File Offset: 0x00011778
			public static int XblMultiplayerSearchHandleGetMemberCounts(XblMultiplayerSearchHandle handle, out uint maxMembers, out uint currentMembers)
			{
				maxMembers = 0U;
				currentMembers = 0U;
				if (handle == null)
				{
					return -2147024809;
				}
				SizeT sizeT;
				SizeT sizeT2;
				int num = XblInterop.XblMultiplayerSearchHandleGetMemberCounts(handle.Handle, out sizeT, out sizeT2);
				if (HR.SUCCEEDED(num))
				{
					maxMembers = sizeT.ToUInt32();
					currentMembers = sizeT2.ToUInt32();
				}
				return num;
			}

			// Token: 0x06000F19 RID: 3865 RVA: 0x000135C4 File Offset: 0x000117C4
			public static int XblMultiplayerSearchHandleGetCreationTime(XblMultiplayerSearchHandle handle, out DateTime creationTime)
			{
				creationTime = default(DateTime);
				if (handle == null)
				{
					return -2147024809;
				}
				TimeT timeT;
				int num = XblInterop.XblMultiplayerSearchHandleGetCreationTime(handle.Handle, out timeT);
				if (HR.SUCCEEDED(num))
				{
					creationTime = timeT.DateTime;
				}
				return num;
			}

			// Token: 0x06000F1A RID: 3866 RVA: 0x0001360C File Offset: 0x0001180C
			public static int XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(XblMultiplayerSearchHandle handle, out string customPropertiesJson)
			{
				customPropertiesJson = null;
				if (handle == null)
				{
					return -2147024809;
				}
				UTF8StringPtr utf8StringPtr;
				int num = XblInterop.XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(handle.Handle, out utf8StringPtr);
				if (HR.SUCCEEDED(num))
				{
					customPropertiesJson = utf8StringPtr.GetString();
				}
				return num;
			}

			// Token: 0x06000F1B RID: 3867 RVA: 0x0001364C File Offset: 0x0001184C
			public static void XblMultiplayerWriteSessionAsync(XblContextHandle xblContext, XblMultiplayerSessionHandle handle, XblMultiplayerSessionWriteMode writeMode, SDK.XBL.XblMultiplayerWriteSessionHandleResult completionRoutine)
			{
				if (xblContext == null || handle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblMultiplayerSessionHandle interopHandle;
					int num2 = XblInterop.XblMultiplayerWriteSessionResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblMultiplayerSessionHandle(interopHandle));
				});
				int num = XblInterop.XblMultiplayerWriteSessionAsync(xblContext.Handle, handle.Handle, writeMode, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F1C RID: 3868 RVA: 0x000136D8 File Offset: 0x000118D8
			public static void XblMultiplayerWriteSessionByHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionHandle handle, XblMultiplayerSessionWriteMode writeMode, string handleId, SDK.XBL.XblMultiplayerWriteSessionHandleResult completionRoutine)
			{
				if (xblContext == null || handle == null || handleId == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblMultiplayerSessionHandle interopHandle;
					int num2 = XblInterop.XblMultiplayerWriteSessionByHandleResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblMultiplayerSessionHandle(interopHandle));
				});
				int num = XblInterop.XblMultiplayerWriteSessionByHandleAsync(xblContext.Handle, handle.Handle, writeMode, Converters.StringToNullTerminatedUTF8ByteArray(handleId), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F1D RID: 3869 RVA: 0x0001376C File Offset: 0x0001196C
			public static void XblMultiplayerGetSessionAsync(XblContextHandle xblContext, XblMultiplayerSessionReference sessionRef, SDK.XBL.XblMultiplayerGetSessionHandleResult completionRoutine)
			{
				if (xblContext == null || sessionRef == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblMultiplayerSessionHandle interopHandle;
					int num2 = XblInterop.XblMultiplayerGetSessionResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblMultiplayerSessionHandle(interopHandle));
				});
				XblMultiplayerSessionReference xblMultiplayerSessionReference = new XblMultiplayerSessionReference(sessionRef);
				int num = XblInterop.XblMultiplayerGetSessionAsync(xblContext.Handle, ref xblMultiplayerSessionReference, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F1E RID: 3870 RVA: 0x000137F4 File Offset: 0x000119F4
			public static void XblMultiplayerGetSessionByHandleAsync(XblContextHandle xblContext, string handleId, SDK.XBL.XblMultiplayerGetSessionHandleResult completionRoutine)
			{
				if (xblContext == null || handleId == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblMultiplayerSessionHandle interopHandle;
					int num2 = XblInterop.XblMultiplayerGetSessionByHandleResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblMultiplayerSessionHandle(interopHandle));
				});
				int num = XblInterop.XblMultiplayerGetSessionByHandleAsync(xblContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(handleId), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F1F RID: 3871 RVA: 0x00013878 File Offset: 0x00011A78
			public static void XblMultiplayerQuerySessionsAsync(XblContextHandle xblContext, XblMultiplayerSessionQuery sessionQuery, SDK.XBL.XblMultiplayerSessionQueryHandleResult completionRoutine)
			{
				if (xblContext == null || sessionQuery == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT sessionCount;
					int num = XblInterop.XblMultiplayerQuerySessionsResultCount(block, out sessionCount);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
						return;
					}
					XblMultiplayerSessionQueryResult[] array = new XblMultiplayerSessionQueryResult[sessionCount.ToInt32()];
					num = XblInterop.XblMultiplayerQuerySessionsResult(block, sessionCount, array);
					if (HR.FAILED(num))
					{
						completionRoutine(-2147024809, null);
						return;
					}
					completionRoutine(num, Array.ConvertAll<XblMultiplayerSessionQueryResult, XblMultiplayerSessionQueryResult>(array, (XblMultiplayerSessionQueryResult h) => new XblMultiplayerSessionQueryResult(h)));
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XblMultiplayerSessionQuery xblMultiplayerSessionQuery = new XblMultiplayerSessionQuery(sessionQuery, disposableCollection);
					if (HR.FAILED(XblInterop.XblMultiplayerQuerySessionsAsync(xblContext.Handle, ref xblMultiplayerSessionQuery, block2)))
					{
						AsyncHelpers.CleanupAsyncBlock(block2);
						completionRoutine(-2147024809, null);
					}
				}
			}

			// Token: 0x06000F20 RID: 3872 RVA: 0x00013924 File Offset: 0x00011B24
			public static void XblMultiplayerSetActivityAsync(XblContextHandle xblContext, XblMultiplayerSessionReference sessionReference, SDK.XBL.XblMultiplayerSetActivityHandleResult completionRoutine)
			{
				if (xblContext == null || sessionReference == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				XblMultiplayerSessionReference xblMultiplayerSessionReference = new XblMultiplayerSessionReference(sessionReference);
				int num = XblInterop.XblMultiplayerSetActivityAsync(xblContext.Handle, ref xblMultiplayerSessionReference, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000F21 RID: 3873 RVA: 0x000139A8 File Offset: 0x00011BA8
			public static void XblMultiplayerClearActivityAsync(XblContextHandle xblContext, string scid, SDK.XBL.XblMultiplayerClearActivityHandleResult completionRoutine)
			{
				if (xblContext == null || scid == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				int num = XblInterop.XblMultiplayerClearActivityAsync(xblContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000F22 RID: 3874 RVA: 0x00013A28 File Offset: 0x00011C28
			public static void XblMultiplayerSetTransferHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionReference targetSessionReference, XblMultiplayerSessionReference originSessionReference, SDK.XBL.XblMultiplayerSetTransferHandleResult completionRoutine)
			{
				if (xblContext == null || originSessionReference == null || targetSessionReference == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblMultiplayerSessionHandleId interopHandle;
					int num2 = XblInterop.XblMultiplayerSetTransferHandleResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblMultiplayerSessionHandleId(interopHandle));
				});
				XblMultiplayerSessionReference xblMultiplayerSessionReference = new XblMultiplayerSessionReference(originSessionReference);
				XblMultiplayerSessionReference xblMultiplayerSessionReference2 = new XblMultiplayerSessionReference(targetSessionReference);
				int num = XblInterop.XblMultiplayerSetTransferHandleAsync(xblContext.Handle, ref xblMultiplayerSessionReference2, ref xblMultiplayerSessionReference, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F23 RID: 3875 RVA: 0x00013AC0 File Offset: 0x00011CC0
			public static void XblMultiplayerCreateSearchHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionReference sessionRef, XblMultiplayerSessionTag[] tags, XblMultiplayerSessionNumberAttribute[] numberAttributes, XblMultiplayerSessionStringAttribute[] stringAttributes, SDK.XBL.XblMultiplayerCreateSearchHandleResult completionRoutine)
			{
				if (xblContext == null || sessionRef == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblMultiplayerSearchHandle interopHandle;
					int num2 = XblInterop.XblMultiplayerCreateSearchHandleResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblMultiplayerSearchHandle(interopHandle));
				});
				XblMultiplayerSessionReference xblMultiplayerSessionReference = new XblMultiplayerSessionReference(sessionRef);
				XblMultiplayerSessionTag[] array = Converters.ConvertArrayToFixedLength<XblMultiplayerSessionTag, XblMultiplayerSessionTag>(tags, tags.Length, (XblMultiplayerSessionTag r) => new XblMultiplayerSessionTag(r));
				XblMultiplayerSessionNumberAttribute[] array2 = Converters.ConvertArrayToFixedLength<XblMultiplayerSessionNumberAttribute, XblMultiplayerSessionNumberAttribute>(numberAttributes, numberAttributes.Length, (XblMultiplayerSessionNumberAttribute r) => new XblMultiplayerSessionNumberAttribute(r));
				XblMultiplayerSessionStringAttribute[] array3 = Converters.ConvertArrayToFixedLength<XblMultiplayerSessionStringAttribute, XblMultiplayerSessionStringAttribute>(stringAttributes, stringAttributes.Length, (XblMultiplayerSessionStringAttribute r) => new XblMultiplayerSessionStringAttribute(r));
				int num = XblInterop.XblMultiplayerCreateSearchHandleAsync(xblContext.Handle, ref xblMultiplayerSessionReference, array, new SizeT(array.Length), array2, new SizeT(array2.Length), array3, new SizeT(array3.Length), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F24 RID: 3876 RVA: 0x00013BE8 File Offset: 0x00011DE8
			public static void XblMultiplayerDeleteSearchHandleAsync(XblContextHandle xblContext, string handleId, SDK.XBL.XblMultiplayerDeleteSearchHandleResult completionRoutine)
			{
				if (xblContext == null || handleId == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				int num = XblInterop.XblMultiplayerDeleteSearchHandleAsync(xblContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(handleId), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000F25 RID: 3877 RVA: 0x00013C68 File Offset: 0x00011E68
			public static void XblMultiplayerGetSearchHandlesAsync(XblContextHandle xboxLiveContext, string scid, string sessionTemplateName, string orderByAttribute, bool orderAscending, string searchFilter, string socialGroup, SDK.XBL.XblMultiplayerGetSearchHandlesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, new XblMultiplayerSearchHandle[0]);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT searchHandleCount;
					int num2 = XblInterop.XblMultiplayerGetSearchHandlesResultCount(block, out searchHandleCount);
					if (HR.FAILED(num2) || searchHandleCount.IsZero)
					{
						completionRoutine(num2, new XblMultiplayerSearchHandle[0]);
						return;
					}
					XblMultiplayerSearchHandle[] array = new XblMultiplayerSearchHandle[searchHandleCount.ToInt32()];
					int num3 = XblInterop.XblMultiplayerGetSearchHandlesResult(block, array, searchHandleCount);
					if (!HR.FAILED(num3))
					{
						completionRoutine(num3, Array.ConvertAll<XblMultiplayerSearchHandle, XblMultiplayerSearchHandle>(array, (XblMultiplayerSearchHandle h) => new XblMultiplayerSearchHandle(h)));
						return;
					}
					completionRoutine(num3, new XblMultiplayerSearchHandle[0]);
				});
				int num = XblInterop.XblMultiplayerGetSearchHandlesAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), Converters.StringToNullTerminatedUTF8ByteArray(orderByAttribute), orderAscending, Converters.StringToNullTerminatedUTF8ByteArray(searchFilter), Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, new XblMultiplayerSearchHandle[0]);
				}
			}

			// Token: 0x06000F26 RID: 3878 RVA: 0x00013D10 File Offset: 0x00011F10
			public static void XblMultiplayerSendInvitesAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionReference sessionRef, ulong[] xboxUserIdList, uint titleId, string contextStringId, string customActivationContext, SDK.XBL.XblMultiplayerSendInvitesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, new XblMultiplayerInviteHandle[0]);
					return;
				}
				SizeT xuidsCount = new SizeT((xboxUserIdList != null) ? xboxUserIdList.Length : 0);
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblMultiplayerInviteHandle[] array = new XblMultiplayerInviteHandle[xuidsCount.ToInt32()];
					int num2 = XblInterop.XblMultiplayerSendInvitesResult(block, xuidsCount, array);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, new XblMultiplayerInviteHandle[0]);
						return;
					}
					completionRoutine(num2, Array.ConvertAll<XblMultiplayerInviteHandle, XblMultiplayerInviteHandle>(array, (XblMultiplayerInviteHandle h) => new XblMultiplayerInviteHandle(h)));
				});
				XblMultiplayerSessionReference xblMultiplayerSessionReference = new XblMultiplayerSessionReference(sessionRef);
				int num = XblInterop.XblMultiplayerSendInvitesAsync(xboxLiveContext.Handle, ref xblMultiplayerSessionReference, xboxUserIdList, xuidsCount, titleId, Converters.StringToNullTerminatedUTF8ByteArray(contextStringId), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, new XblMultiplayerInviteHandle[0]);
				}
			}

			// Token: 0x06000F27 RID: 3879 RVA: 0x00013DC8 File Offset: 0x00011FC8
			public static void XblMultiplayerGetActivitiesForSocialGroupAsync(XblContextHandle xboxLiveContext, string scid, ulong socialGroupOwnerXuid, string socialGroup, SDK.XBL.XblMultiplayerGetActivitiesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, new XblMultiplayerActivityDetails[0]);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT activityCount;
					int num2 = XblInterop.XblMultiplayerGetActivitiesForSocialGroupResultCount(block, out activityCount);
					if (HR.FAILED(num2) || activityCount.IsZero)
					{
						completionRoutine(num2, new XblMultiplayerActivityDetails[0]);
						return;
					}
					XblMultiplayerActivityDetails[] array = new XblMultiplayerActivityDetails[activityCount.ToInt32()];
					int num3 = XblInterop.XblMultiplayerGetActivitiesForSocialGroupResult(block, activityCount, array);
					if (!HR.FAILED(num3))
					{
						completionRoutine(num3, Array.ConvertAll<XblMultiplayerActivityDetails, XblMultiplayerActivityDetails>(array, (XblMultiplayerActivityDetails h) => new XblMultiplayerActivityDetails(h)));
						return;
					}
					completionRoutine(num3, new XblMultiplayerActivityDetails[0]);
				});
				int num = XblInterop.XblMultiplayerGetActivitiesForSocialGroupAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), socialGroupOwnerXuid, Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, new XblMultiplayerActivityDetails[0]);
				}
			}

			// Token: 0x06000F28 RID: 3880 RVA: 0x00013E5C File Offset: 0x0001205C
			public static void XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(XblContextHandle xboxLiveContext, string scid, ulong socialGroupOwnerXuid, string socialGroup, SDK.XBL.XblMultiplayerGetActivitiesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, new XblMultiplayerActivityDetails[0]);
					return;
				}
				int hr;
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(block, out bufferSize);
					if (HR.FAILED(hr) || bufferSize.IsZero)
					{
						completionRoutine(hr, new XblMultiplayerActivityDetails[0]);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT count;
						SizeT sizeT;
						hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out count, out sizeT);
						if (HR.FAILED(hr))
						{
							completionRoutine(hr, null);
						}
						else
						{
							completionRoutine(hr, Converters.PtrToClassArray<XblMultiplayerActivityDetails, XblMultiplayerActivityDetails>(rawPtr, count, (XblMultiplayerActivityDetails r) => new XblMultiplayerActivityDetails(r)));
						}
					}
				});
				hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), socialGroupOwnerXuid, Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), block2);
				if (HR.FAILED(hr))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(hr, new XblMultiplayerActivityDetails[0]);
				}
			}

			// Token: 0x06000F29 RID: 3881 RVA: 0x00013EFC File Offset: 0x000120FC
			public static void XblMultiplayerGetActivitiesForUsersAsync(XblContextHandle xboxLiveContext, string scid, ulong[] xuids, SDK.XBL.XblMultiplayerGetActivitiesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, new XblMultiplayerActivityDetails[0]);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT activityCount;
					int num2 = XblInterop.XblMultiplayerGetActivitiesForUsersResultCount(block, out activityCount);
					if (HR.FAILED(num2) || activityCount.IsZero)
					{
						completionRoutine(num2, new XblMultiplayerActivityDetails[0]);
						return;
					}
					XblMultiplayerActivityDetails[] array = new XblMultiplayerActivityDetails[activityCount.ToInt32()];
					int num3 = XblInterop.XblMultiplayerGetActivitiesForUsersResult(block, activityCount, array);
					if (!HR.FAILED(num3))
					{
						completionRoutine(num3, Array.ConvertAll<XblMultiplayerActivityDetails, XblMultiplayerActivityDetails>(array, (XblMultiplayerActivityDetails h) => new XblMultiplayerActivityDetails(h)));
						return;
					}
					completionRoutine(num3, new XblMultiplayerActivityDetails[0]);
				});
				int num = XblInterop.XblMultiplayerGetActivitiesForUsersAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), xuids, new SizeT((xuids != null) ? xuids.Length : 0), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, new XblMultiplayerActivityDetails[0]);
				}
			}

			// Token: 0x06000F2A RID: 3882 RVA: 0x00013F94 File Offset: 0x00012194
			public static void XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(XblContextHandle xboxLiveContext, string scid, ulong[] xuids, SDK.XBL.XblMultiplayerGetActivitiesResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, new XblMultiplayerActivityDetails[0]);
					return;
				}
				int hr;
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(block, out bufferSize);
					if (HR.FAILED(hr))
					{
						completionRoutine(hr, new XblMultiplayerActivityDetails[0]);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT count;
						SizeT sizeT;
						hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out count, out sizeT);
						if (HR.FAILED(hr))
						{
							completionRoutine(hr, null);
						}
						else
						{
							completionRoutine(hr, Converters.PtrToClassArray<XblMultiplayerActivityDetails, XblMultiplayerActivityDetails>(rawPtr, count, (XblMultiplayerActivityDetails r) => new XblMultiplayerActivityDetails(r)));
						}
					}
				});
				hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), xuids, new SizeT((xuids != null) ? xuids.Length : 0), block2);
				if (HR.FAILED(hr))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(hr, new XblMultiplayerActivityDetails[0]);
				}
			}

			// Token: 0x06000F2B RID: 3883 RVA: 0x0001403B File Offset: 0x0001223B
			public static int XblMultiplayerSetSubscriptionsEnabled(XblContextHandle xblContext, bool subscriptionsEnabled)
			{
				return XblInterop.XblMultiplayerSetSubscriptionsEnabled(xblContext.Handle, subscriptionsEnabled);
			}

			// Token: 0x06000F2C RID: 3884 RVA: 0x00014049 File Offset: 0x00012249
			public static bool XblMultiplayerSubscriptionsEnabled(XblContextHandle xblHandle)
			{
				return XblInterop.XblMultiplayerSubscriptionsEnabled(xblHandle.Handle);
			}

			// Token: 0x06000F2D RID: 3885 RVA: 0x00014056 File Offset: 0x00012256
			public static int XblMultiplayerSessionSetCustomPropertyJson(XblMultiplayerSessionHandle handle, string name, string valueJson)
			{
				return XblInterop.XblMultiplayerSessionSetCustomPropertyJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson));
			}

			// Token: 0x06000F2E RID: 3886 RVA: 0x0001406F File Offset: 0x0001226F
			public static int XblMultiplayerSessionDeleteCustomPropertyJson(XblMultiplayerSessionHandle handle, string name)
			{
				return XblInterop.XblMultiplayerSessionDeleteCustomPropertyJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name));
			}

			// Token: 0x06000F2F RID: 3887 RVA: 0x00014082 File Offset: 0x00012282
			public static XblMultiplayerSessionChangeTypes XblMultiplayerSessionCompare(XblMultiplayerSessionHandle currentSessionHandle, XblMultiplayerSessionHandle oldSessionHandle)
			{
				if (currentSessionHandle == null || oldSessionHandle == null)
				{
					return XblMultiplayerSessionChangeTypes.Everything;
				}
				return XblInterop.XblMultiplayerSessionCompare(currentSessionHandle.Handle, oldSessionHandle.Handle);
			}

			// Token: 0x06000F30 RID: 3888 RVA: 0x000140AC File Offset: 0x000122AC
			public static int XblMultiplayerActivityUpdateRecentPlayers(XblContextHandle xboxLiveContext, XblMultiplayerActivityRecentPlayerUpdate[] updates)
			{
				if (xboxLiveContext == null)
				{
					return -2147024809;
				}
				XblMultiplayerActivityRecentPlayerUpdate[] updates2 = Converters.ConvertArrayToFixedLength<XblMultiplayerActivityRecentPlayerUpdate, XblMultiplayerActivityRecentPlayerUpdate>(updates, updates.Length, (XblMultiplayerActivityRecentPlayerUpdate r) => new XblMultiplayerActivityRecentPlayerUpdate(r));
				return XblInterop.XblMultiplayerActivityUpdateRecentPlayers(xboxLiveContext.Handle, updates2, new SizeT((updates == null) ? 0 : updates.Length));
			}

			// Token: 0x06000F31 RID: 3889 RVA: 0x0001410C File Offset: 0x0001230C
			public static void XblMultiplayerActivityFlushRecentPlayersAsync(XblContextHandle xboxLiveContext, SDK.XBL.XblMultiplayerActivityAsyncOperationCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				int num = XblInterop.XblMultiplayerActivityFlushRecentPlayersAsync(xboxLiveContext.Handle, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000F32 RID: 3890 RVA: 0x00014184 File Offset: 0x00012384
			public static void XblMultiplayerActivitySetActivityAsync(XblContextHandle xboxLiveContext, XblMultiplayerActivityInfo activityInfo, bool allowCrossPlatformJoin, SDK.XBL.XblMultiplayerActivityAsyncOperationCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XblMultiplayerActivityInfo xblMultiplayerActivityInfo = new XblMultiplayerActivityInfo(activityInfo, disposableCollection);
					int num = XblInterop.XblMultiplayerActivitySetActivityAsync(xboxLiveContext.Handle, ref xblMultiplayerActivityInfo, allowCrossPlatformJoin, block2);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(block2);
						completionRoutine(num);
					}
				}
			}

			// Token: 0x06000F33 RID: 3891 RVA: 0x0001422C File Offset: 0x0001242C
			public static void XblMultiplayerActivityGetActivityAsync(XblContextHandle xboxLiveContext, ulong[] xboxUserIdList, SDK.XBL.XblMultiplayerGetActivityAsyncOperationCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				int hr;
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					hr = XblInterop.XblMultiplayerActivityGetActivityResultSize(block, out bufferSize);
					if (HR.FAILED(hr))
					{
						completionRoutine(hr, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT count;
						SizeT sizeT;
						hr = XblInterop.XblMultiplayerActivityGetActivityResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out count, out sizeT);
						if (HR.FAILED(hr))
						{
							completionRoutine(hr, null);
						}
						else
						{
							completionRoutine(hr, Converters.PtrToClassArray<XblMultiplayerActivityInfo, XblMultiplayerActivityInfo>(rawPtr, count, (XblMultiplayerActivityInfo r) => new XblMultiplayerActivityInfo(r)));
						}
					}
				});
				hr = XblInterop.XblMultiplayerActivityGetActivityAsync(xboxLiveContext.Handle, xboxUserIdList, new SizeT((xboxUserIdList != null) ? xboxUserIdList.Length : 0), block2);
				if (HR.FAILED(hr))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(hr, null);
				}
			}

			// Token: 0x06000F34 RID: 3892 RVA: 0x000142C4 File Offset: 0x000124C4
			public static void XblMultiplayerActivityDeleteActivityAsync(XblContextHandle xboxLiveContext, SDK.XBL.XblMultiplayerActivityAsyncOperationCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				int num = XblInterop.XblMultiplayerActivityDeleteActivityAsync(xboxLiveContext.Handle, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000F35 RID: 3893 RVA: 0x0001433C File Offset: 0x0001253C
			public static void XblMultiplayerActivitySendInvitesAsync(XblContextHandle xboxLiveContext, ulong[] xboxUserIdList, bool allowCrossPlatformJoin, string connectionString, SDK.XBL.XblMultiplayerActivityAsyncOperationCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				int num = XblInterop.XblMultiplayerActivitySendInvitesAsync(xboxLiveContext.Handle, xboxUserIdList, new SizeT((xboxUserIdList != null) ? xboxUserIdList.Length : 0), allowCrossPlatformJoin, Converters.StringToNullTerminatedUTF8ByteArray(connectionString), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000F36 RID: 3894 RVA: 0x000143CA File Offset: 0x000125CA
			public static int XblMultiplayerManagerInitialize(string lobbySessionTemplateName)
			{
				return XblInterop.XblMultiplayerManagerInitialize(Converters.StringToNullTerminatedUTF8ByteArray(lobbySessionTemplateName), SDK.defaultQueue);
			}

			// Token: 0x06000F37 RID: 3895 RVA: 0x000143DC File Offset: 0x000125DC
			public static int XblMultiplayerManagerDoWork(out XblMultiplayerEvent[] events)
			{
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblMultiplayerManagerDoWork(out rawPtr, out count);
				if (HR.FAILED(num))
				{
					events = null;
					return num;
				}
				events = Converters.PtrToClassArray<XblMultiplayerEvent, XblMultiplayerEvent>(rawPtr, count, (XblMultiplayerEvent x) => new XblMultiplayerEvent(x));
				return num;
			}

			// Token: 0x06000F38 RID: 3896 RVA: 0x00014429 File Offset: 0x00012629
			public static XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(string scid, string sessionTemplateName, string sessionName)
			{
				return new XblMultiplayerSessionReference(XblInterop.XblMultiplayerSessionReferenceCreate(Converters.StringToNullTerminatedUTF8ByteArray(scid), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), Converters.StringToNullTerminatedUTF8ByteArray(sessionName)));
			}

			// Token: 0x06000F39 RID: 3897 RVA: 0x00014447 File Offset: 0x00012647
			public static int XblMultiplayerManagerJoinLobby(string handleId, XUserHandle user)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerJoinLobby(Converters.StringToNullTerminatedUTF8ByteArray(handleId), user.Handle);
			}

			// Token: 0x06000F3A RID: 3898 RVA: 0x00014469 File Offset: 0x00012669
			public static int XblMultiplayerManagerSetQosMeasurements(string measurementsJson)
			{
				return XblInterop.XblMultiplayerManagerSetQosMeasurements(Converters.StringToNullTerminatedUTF8ByteArray(measurementsJson));
			}

			// Token: 0x06000F3B RID: 3899 RVA: 0x00014476 File Offset: 0x00012676
			public static int XblMultiplayerManagerSetJoinability(XblMultiplayerJoinability joinability, object context)
			{
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerSetJoinability(joinability, ctx), context);
			}

			// Token: 0x06000F3C RID: 3900 RVA: 0x00014495 File Offset: 0x00012695
			public static int XblMultiplayerManagerJoinGameFromLobby(string sessionTemplateName)
			{
				return XblInterop.XblMultiplayerManagerJoinGameFromLobby(Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName));
			}

			// Token: 0x06000F3D RID: 3901 RVA: 0x000144A2 File Offset: 0x000126A2
			public static void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(bool autoFillMembers)
			{
				XblInterop.XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(new NativeBool(autoFillMembers));
			}

			// Token: 0x06000F3E RID: 3902 RVA: 0x000144AF File Offset: 0x000126AF
			public static XblMultiplayerJoinability XblMultiplayerManagerJoinability()
			{
				return XblInterop.XblMultiplayerManagerJoinability();
			}

			// Token: 0x06000F3F RID: 3903 RVA: 0x000144B6 File Offset: 0x000126B6
			public static void XblMultiplayerManagerCancelMatch()
			{
				XblInterop.XblMultiplayerManagerCancelMatch();
			}

			// Token: 0x06000F40 RID: 3904 RVA: 0x000144BD File Offset: 0x000126BD
			public static uint XblMultiplayerManagerEstimatedMatchWaitTime()
			{
				return XblInterop.XblMultiplayerManagerEstimatedMatchWaitTime();
			}

			// Token: 0x06000F41 RID: 3905 RVA: 0x000144C4 File Offset: 0x000126C4
			public static bool XblMultiplayerManagerMemberAreMembersOnSameDevice(XblMultiplayerManagerMember first, XblMultiplayerManagerMember second)
			{
				bool value;
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XblMultiplayerManagerMember xblMultiplayerManagerMember = new XblMultiplayerManagerMember(first, disposableCollection);
					XblMultiplayerManagerMember xblMultiplayerManagerMember2 = new XblMultiplayerManagerMember(second, disposableCollection);
					value = XblInterop.XblMultiplayerManagerMemberAreMembersOnSameDevice(ref xblMultiplayerManagerMember, ref xblMultiplayerManagerMember2).Value;
				}
				return value;
			}

			// Token: 0x06000F42 RID: 3906 RVA: 0x0001451C File Offset: 0x0001271C
			public static int XblMultiplayerSessionReferenceParseFromUriPath(string path, out XblMultiplayerSessionReference sessionReference)
			{
				XblMultiplayerSessionReference interopStruct;
				int num = XblInterop.XblMultiplayerSessionReferenceParseFromUriPath(Converters.StringToNullTerminatedUTF8ByteArray(path), out interopStruct);
				if (HR.FAILED(num))
				{
					sessionReference = null;
					return num;
				}
				sessionReference = new XblMultiplayerSessionReference(interopStruct);
				return num;
			}

			// Token: 0x06000F43 RID: 3907 RVA: 0x00014550 File Offset: 0x00012750
			public static int XblMultiplayerSessionReferenceToUriPath(XblMultiplayerSessionReference sessionReference, out XblMultiplayerSessionReferenceUri sessionReferenceUri)
			{
				XblMultiplayerSessionReferenceUri interopStruct;
				int num = XblInterop.XblMultiplayerSessionReferenceToUriPath(new XblMultiplayerSessionReference(sessionReference), out interopStruct);
				if (HR.FAILED(num))
				{
					sessionReferenceUri = null;
					return num;
				}
				sessionReferenceUri = new XblMultiplayerSessionReferenceUri(interopStruct);
				return num;
			}

			// Token: 0x06000F44 RID: 3908 RVA: 0x00014581 File Offset: 0x00012781
			public static int XblMultiplayerManagerLeaveGame()
			{
				return XblInterop.XblMultiplayerManagerLeaveGame();
			}

			// Token: 0x06000F45 RID: 3909 RVA: 0x00014588 File Offset: 0x00012788
			public static XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus()
			{
				return XblInterop.XblMultiplayerManagerMatchStatus();
			}

			// Token: 0x06000F46 RID: 3910 RVA: 0x00014590 File Offset: 0x00012790
			public static bool XblMultiplayerManagerAutoFillMembersDuringMatchmaking()
			{
				return XblInterop.XblMultiplayerManagerAutoFillMembersDuringMatchmaking().Value;
			}

			// Token: 0x06000F47 RID: 3911 RVA: 0x000145AA File Offset: 0x000127AA
			public static int XblMultiplayerManagerFindMatch(string hopperName, string attributesJson, uint timeoutInSeconds)
			{
				return XblInterop.XblMultiplayerManagerFindMatch(Converters.StringToNullTerminatedUTF8ByteArray(hopperName), Converters.StringToNullTerminatedUTF8ByteArray(attributesJson), timeoutInSeconds);
			}

			// Token: 0x06000F48 RID: 3912 RVA: 0x000145C0 File Offset: 0x000127C0
			public static bool XblMultiplayerSessionReferenceIsValid(XblMultiplayerSessionReference sessionReference)
			{
				XblMultiplayerSessionReference xblMultiplayerSessionReference = new XblMultiplayerSessionReference(sessionReference);
				return XblInterop.XblMultiplayerSessionReferenceIsValid(ref xblMultiplayerSessionReference).Value;
			}

			// Token: 0x06000F49 RID: 3913 RVA: 0x000145E4 File Offset: 0x000127E4
			public static int XblMultiplayerManagerJoinGame(string sessionName, string sessionTemplateName, ulong[] xuids)
			{
				return XblInterop.XblMultiplayerManagerJoinGame(Converters.StringToNullTerminatedUTF8ByteArray(sessionName), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), xuids, new SizeT(xuids.Length));
			}

			// Token: 0x06000F4A RID: 3914 RVA: 0x00014600 File Offset: 0x00012800
			public static int XblMultiplayerEventArgsTournamentRegistrationStateChanged(XblMultiplayerEventArgsHandle argsHandle, out XblTournamentRegistrationState registrationState, out XblTournamentRegistrationReason registrationReason)
			{
				if (argsHandle == null)
				{
					registrationState = XblTournamentRegistrationState.Unknown;
					registrationReason = XblTournamentRegistrationReason.Unknown;
					return -2147024809;
				}
				return XblInterop.XblMultiplayerEventArgsTournamentRegistrationStateChanged(argsHandle.Handle, out registrationState, out registrationReason);
			}

			// Token: 0x06000F4B RID: 3915 RVA: 0x00014624 File Offset: 0x00012824
			public static int XblMultiplayerEventArgsFindMatchCompleted(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerMatchStatus matchStatus, out XblMultiplayerMeasurementFailure initializationFailureCause)
			{
				if (argsHandle == null)
				{
					matchStatus = XblMultiplayerMatchStatus.None;
					initializationFailureCause = XblMultiplayerMeasurementFailure.Unknown;
					return -2147024809;
				}
				return XblInterop.XblMultiplayerEventArgsFindMatchCompleted(argsHandle.Handle, out matchStatus, out initializationFailureCause);
			}

			// Token: 0x06000F4C RID: 3916 RVA: 0x00014648 File Offset: 0x00012848
			public static int XblMultiplayerEventArgsPropertiesJson(XblMultiplayerEventArgsHandle argsHandle, out string properties)
			{
				properties = null;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				UTF8StringPtr utf8StringPtr;
				int num = XblInterop.XblMultiplayerEventArgsPropertiesJson(argsHandle.Handle, out utf8StringPtr);
				if (HR.SUCCEEDED(num))
				{
					properties = utf8StringPtr.GetString();
				}
				return num;
			}

			// Token: 0x06000F4D RID: 3917 RVA: 0x00014685 File Offset: 0x00012885
			public static int XblMultiplayerEventArgsXuid(XblMultiplayerEventArgsHandle argsHandle, out ulong xuid)
			{
				xuid = 0UL;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerEventArgsXuid(argsHandle.Handle, out xuid);
			}

			// Token: 0x06000F4E RID: 3918 RVA: 0x000146A8 File Offset: 0x000128A8
			public static int XblMultiplayerEventArgsTournamentGameSessionReady(XblMultiplayerEventArgsHandle argsHandle, out DateTime startTime)
			{
				startTime = default(DateTime);
				if (argsHandle == null)
				{
					return -2147024809;
				}
				TimeT timeT;
				int num = XblInterop.XblMultiplayerEventArgsTournamentGameSessionReady(argsHandle.Handle, out timeT);
				if (HR.SUCCEEDED(num))
				{
					startTime = timeT.DateTime;
				}
				return num;
			}

			// Token: 0x06000F4F RID: 3919 RVA: 0x000146F0 File Offset: 0x000128F0
			public static int XblMultiplayerEventArgsMember(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember member)
			{
				member = null;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				XblMultiplayerManagerMember interopStruct;
				int num = XblInterop.XblMultiplayerEventArgsMember(argsHandle.Handle, out interopStruct);
				if (HR.SUCCEEDED(num))
				{
					member = new XblMultiplayerManagerMember(interopStruct);
				}
				return num;
			}

			// Token: 0x06000F50 RID: 3920 RVA: 0x0001472C File Offset: 0x0001292C
			public static int XblMultiplayerEventArgsMembers(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember[] members)
			{
				members = null;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				SizeT membersCount;
				int num = XblInterop.XblMultiplayerEventArgsMembersCount(argsHandle.Handle, out membersCount);
				if (HR.FAILED(num))
				{
					return num;
				}
				XblMultiplayerManagerMember[] array = new XblMultiplayerManagerMember[membersCount.ToInt32()];
				num = XblInterop.XblMultiplayerEventArgsMembers(argsHandle.Handle, membersCount, array);
				if (HR.SUCCEEDED(num))
				{
					members = Array.ConvertAll<XblMultiplayerManagerMember, XblMultiplayerManagerMember>(array, (XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
				}
				return num;
			}

			// Token: 0x06000F51 RID: 3921 RVA: 0x000147B0 File Offset: 0x000129B0
			public static int XblMultiplayerEventArgsPerformQoSMeasurements(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs)
			{
				performQoSMeasurementsArgs = null;
				if (argsHandle == null)
				{
					return -2147024809;
				}
				XblMultiplayerPerformQoSMeasurementsArgs interopStruct;
				int num = XblInterop.XblMultiplayerEventArgsPerformQoSMeasurements(argsHandle.Handle, out interopStruct);
				if (HR.SUCCEEDED(num))
				{
					performQoSMeasurementsArgs = new XblMultiplayerPerformQoSMeasurementsArgs(interopStruct);
				}
				return num;
			}

			// Token: 0x06000F52 RID: 3922 RVA: 0x000147EC File Offset: 0x000129EC
			private static int SessionSetInternalWithMarshalledContext(Func<IntPtr, int> setterFunction, object context)
			{
				IntPtr intPtr = IntPtr.Zero;
				if (context != null)
				{
					intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(context));
				}
				int num = setterFunction(intPtr);
				if (HR.FAILED(num) && intPtr != IntPtr.Zero)
				{
					GCHandle.FromIntPtr(intPtr).Free();
				}
				return num;
			}

			// Token: 0x06000F53 RID: 3923 RVA: 0x00014838 File Offset: 0x00012A38
			public static bool XblMultiplayerManagerGameSessionIsHost(ulong xuid)
			{
				return XblInterop.XblMultiplayerManagerGameSessionIsHost(xuid).Value;
			}

			// Token: 0x06000F54 RID: 3924 RVA: 0x00014854 File Offset: 0x00012A54
			public static int XblMultiplayerManagerGameSessionHost(out XblMultiplayerManagerMember hostMember)
			{
				hostMember = null;
				XblMultiplayerManagerMember interopStruct;
				int num = XblInterop.XblMultiplayerManagerGameSessionHost(out interopStruct);
				if (HR.SUCCEEDED(num))
				{
					hostMember = new XblMultiplayerManagerMember(interopStruct);
				}
				return num;
			}

			// Token: 0x06000F55 RID: 3925 RVA: 0x0001487C File Offset: 0x00012A7C
			public static int XblMultiplayerManagerLobbySessionSessionReference(out XblMultiplayerSessionReference sessionReference)
			{
				sessionReference = null;
				XblMultiplayerSessionReference interopStruct;
				int num = XblInterop.XblMultiplayerManagerLobbySessionSessionReference(out interopStruct);
				if (HR.SUCCEEDED(num))
				{
					sessionReference = new XblMultiplayerSessionReference(interopStruct);
				}
				return num;
			}

			// Token: 0x06000F56 RID: 3926 RVA: 0x000148A4 File Offset: 0x00012AA4
			public unsafe static XblMultiplayerSessionReference XblMultiplayerManagerGameSessionSessionReference()
			{
				XblMultiplayerSessionReference* ptr = XblInterop.XblMultiplayerManagerGameSessionSessionReference();
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionReference(*ptr);
			}

			// Token: 0x06000F57 RID: 3927 RVA: 0x000148CC File Offset: 0x00012ACC
			public static bool XblMultiplayerManagerGameSessionActive()
			{
				return XblInterop.XblMultiplayerManagerGameSessionActive().Value;
			}

			// Token: 0x06000F58 RID: 3928 RVA: 0x000148E6 File Offset: 0x00012AE6
			public static int XblMultiplayerManagerGameSessionSetProperties(string name, string valueJson, object context)
			{
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			// Token: 0x06000F59 RID: 3929 RVA: 0x0001490C File Offset: 0x00012B0C
			public static int XblMultiplayerManagerGameSessionSetSynchronizedHost(string deviceToken, object context)
			{
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetSynchronizedHost(Converters.StringToNullTerminatedUTF8ByteArray(deviceToken), ctx), context);
			}

			// Token: 0x06000F5A RID: 3930 RVA: 0x0001492B File Offset: 0x00012B2B
			public static int XblMultiplayerManagerGameSessionSetSynchronizedProperties(string name, string valueJson, object context)
			{
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetSynchronizedProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			// Token: 0x06000F5B RID: 3931 RVA: 0x00014954 File Offset: 0x00012B54
			public static string XblMultiplayerManagerGameSessionCorrelationId()
			{
				return XblInterop.XblMultiplayerManagerGameSessionCorrelationId().GetString();
			}

			// Token: 0x06000F5C RID: 3932 RVA: 0x00014970 File Offset: 0x00012B70
			public unsafe static XblMultiplayerSessionConstants XblMultiplayerManagerGameSessionConstants()
			{
				XblMultiplayerSessionConstants* ptr = XblInterop.XblMultiplayerManagerGameSessionConstants();
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionConstants(*ptr);
			}

			// Token: 0x06000F5D RID: 3933 RVA: 0x00014998 File Offset: 0x00012B98
			public static int XblMultiplayerManagerGameSessionMembers(out XblMultiplayerManagerMember[] members)
			{
				members = null;
				SizeT membersCount = XblInterop.XblMultiplayerManagerGameSessionMembersCount();
				if (membersCount.IsZero)
				{
					return 0;
				}
				XblMultiplayerManagerMember[] array = new XblMultiplayerManagerMember[membersCount.ToInt32()];
				int num = XblInterop.XblMultiplayerManagerGameSessionMembers(membersCount, array);
				if (HR.SUCCEEDED(num))
				{
					members = Array.ConvertAll<XblMultiplayerManagerMember, XblMultiplayerManagerMember>(array, (XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
				}
				return num;
			}

			// Token: 0x06000F5E RID: 3934 RVA: 0x000149FC File Offset: 0x00012BFC
			public static string XblMultiplayerManagerGameSessionPropertiesJson()
			{
				return XblInterop.XblMultiplayerManagerGameSessionPropertiesJson().GetString();
			}

			// Token: 0x06000F5F RID: 3935 RVA: 0x00014A18 File Offset: 0x00012C18
			public static int XblMultiplayerManagerLobbySessionHost(out XblMultiplayerManagerMember hostMember)
			{
				hostMember = null;
				XblMultiplayerManagerMember interopStruct;
				int num = XblInterop.XblMultiplayerManagerLobbySessionHost(out interopStruct);
				if (HR.SUCCEEDED(num))
				{
					hostMember = new XblMultiplayerManagerMember(interopStruct);
				}
				return num;
			}

			// Token: 0x06000F60 RID: 3936 RVA: 0x00014A3F File Offset: 0x00012C3F
			public static int XblMultiplayerManagerLobbySessionInviteUsers(XUserHandle user, ulong[] xuids, string contextStringId, string customActivationContext)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerLobbySessionInviteUsers(user.Handle, xuids, new SizeT(xuids.Length), Converters.StringToNullTerminatedUTF8ByteArray(contextStringId), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
			}

			// Token: 0x06000F61 RID: 3937 RVA: 0x00014A70 File Offset: 0x00012C70
			public static int XblMultiplayerManagerLobbySessionInviteFriends(XUserHandle requestingUser, string contextStringId, string customActivationContext)
			{
				if (requestingUser == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerLobbySessionInviteFriends(requestingUser.Handle, Converters.StringToNullTerminatedUTF8ByteArray(contextStringId), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
			}

			// Token: 0x06000F62 RID: 3938 RVA: 0x00014A98 File Offset: 0x00012C98
			public static int XblMultiplayerManagerLobbySessionAddLocalUser(XUserHandle user)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerLobbySessionAddLocalUser(user.Handle);
			}

			// Token: 0x06000F63 RID: 3939 RVA: 0x00014AB4 File Offset: 0x00012CB4
			public static int XblMultiplayerManagerLobbySessionMembers(out XblMultiplayerManagerMember[] members)
			{
				members = null;
				SizeT membersCount = XblInterop.XblMultiplayerManagerLobbySessionMembersCount();
				if (membersCount.IsZero)
				{
					return 0;
				}
				XblMultiplayerManagerMember[] array = new XblMultiplayerManagerMember[membersCount.ToInt32()];
				int num = XblInterop.XblMultiplayerManagerLobbySessionMembers(membersCount, array);
				if (HR.SUCCEEDED(num))
				{
					members = Array.ConvertAll<XblMultiplayerManagerMember, XblMultiplayerManagerMember>(array, (XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
				}
				return num;
			}

			// Token: 0x06000F64 RID: 3940 RVA: 0x00014B18 File Offset: 0x00012D18
			public static string XblMultiplayerManagerLobbySessionPropertiesJson()
			{
				return XblInterop.XblMultiplayerManagerLobbySessionPropertiesJson().GetString();
			}

			// Token: 0x06000F65 RID: 3941 RVA: 0x00014B34 File Offset: 0x00012D34
			public unsafe static XblMultiplayerSessionConstants XblMultiplayerManagerLobbySessionConstants()
			{
				XblMultiplayerSessionConstants* ptr = XblInterop.XblMultiplayerManagerLobbySessionConstants();
				if (ptr == null)
				{
					return null;
				}
				return new XblMultiplayerSessionConstants(*ptr);
			}

			// Token: 0x06000F66 RID: 3942 RVA: 0x00014B5C File Offset: 0x00012D5C
			public static int XblMultiplayerManagerLobbySessionLocalMembers(out XblMultiplayerManagerMember[] localMembers)
			{
				localMembers = null;
				SizeT localMembersCount = XblInterop.XblMultiplayerManagerLobbySessionLocalMembersCount();
				if (localMembersCount.IsZero)
				{
					return 0;
				}
				XblMultiplayerManagerMember[] array = new XblMultiplayerManagerMember[localMembersCount.ToInt32()];
				int num = XblInterop.XblMultiplayerManagerLobbySessionLocalMembers(localMembersCount, array);
				if (HR.SUCCEEDED(num))
				{
					localMembers = Array.ConvertAll<XblMultiplayerManagerMember, XblMultiplayerManagerMember>(array, (XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
				}
				return num;
			}

			// Token: 0x06000F67 RID: 3943 RVA: 0x00014BC0 File Offset: 0x00012DC0
			public static int XblMultiplayerManagerLobbySessionRemoveLocalUser(XUserHandle user)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblMultiplayerManagerLobbySessionRemoveLocalUser(user.Handle);
			}

			// Token: 0x06000F68 RID: 3944 RVA: 0x00014BDC File Offset: 0x00012DDC
			public unsafe static XblTournamentTeamResult XblMultiplayerManagerLobbySessionLastTournamentTeamResult()
			{
				XblTournamentTeamResult* ptr = XblInterop.XblMultiplayerManagerLobbySessionLastTournamentTeamResult();
				if (ptr == null)
				{
					return null;
				}
				return new XblTournamentTeamResult(*ptr);
			}

			// Token: 0x06000F69 RID: 3945 RVA: 0x00014C04 File Offset: 0x00012E04
			public static bool XblMultiplayerManagerLobbySessionIsHost(ulong xuid)
			{
				return XblInterop.XblMultiplayerManagerLobbySessionIsHost(xuid).Value;
			}

			// Token: 0x06000F6A RID: 3946 RVA: 0x00014C20 File Offset: 0x00012E20
			public static int XblMultiplayerManagerLobbySessionCorrelationId(out XblGuid correlationId)
			{
				correlationId = null;
				XblGuid interopStruct;
				int num = XblInterop.XblMultiplayerManagerLobbySessionCorrelationId(out interopStruct);
				if (HR.SUCCEEDED(num))
				{
					correlationId = new XblGuid(interopStruct);
				}
				return num;
			}

			// Token: 0x06000F6B RID: 3947 RVA: 0x00014C47 File Offset: 0x00012E47
			public static int XblMultiplayerManagerLobbySessionSetSynchronizedHost(string deviceToken, object context)
			{
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetSynchronizedHost(Converters.StringToNullTerminatedUTF8ByteArray(deviceToken), ctx), context);
			}

			// Token: 0x06000F6C RID: 3948 RVA: 0x00014C66 File Offset: 0x00012E66
			public static int XblMultiplayerManagerLobbySessionSetProperties(string name, string valueJson, object context)
			{
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			// Token: 0x06000F6D RID: 3949 RVA: 0x00014C8C File Offset: 0x00012E8C
			public static int XblMultiplayerManagerLobbySessionSetLocalMemberProperties(XUserHandle user, string name, string valueJson, object context)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetLocalMemberProperties(user.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			// Token: 0x06000F6E RID: 3950 RVA: 0x00014CDA File Offset: 0x00012EDA
			public static int XblMultiplayerManagerLobbySessionSetSynchronizedProperties(string name, string valueJson, object context)
			{
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetSynchronizedProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
			}

			// Token: 0x06000F6F RID: 3951 RVA: 0x00014D00 File Offset: 0x00012F00
			public static int XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(XUserHandle user, string connectionAddress, object context)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(user.Handle, Converters.StringToNullTerminatedUTF8ByteArray(connectionAddress), ctx), context);
			}

			// Token: 0x06000F70 RID: 3952 RVA: 0x00014D48 File Offset: 0x00012F48
			public static int XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(XUserHandle user, string name, object context)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return SDK.XBL.SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(user.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name), ctx), context);
			}

			// Token: 0x06000F71 RID: 3953 RVA: 0x00014D8F File Offset: 0x00012F8F
			public static int XblPresenceRecordGetXuid(XblPresenceRecordHandle handle, out ulong xuid)
			{
				if (handle == null)
				{
					xuid = 0UL;
					return -2147024809;
				}
				return XblInterop.XblPresenceRecordGetXuid(handle.Handle, out xuid);
			}

			// Token: 0x06000F72 RID: 3954 RVA: 0x00014DB0 File Offset: 0x00012FB0
			public static int XblPresenceRecordGetUserState(XblPresenceRecordHandle handle, out XblPresenceUserState userState)
			{
				if (handle == null)
				{
					userState = XblPresenceUserState.Unknown;
					return -2147024809;
				}
				return XblInterop.XblPresenceRecordGetUserState(handle.Handle, out userState);
			}

			// Token: 0x06000F73 RID: 3955 RVA: 0x00014DD0 File Offset: 0x00012FD0
			public static int XblPresenceRecordGetDeviceRecords(XblPresenceRecordHandle handle, out XblPresenceDeviceRecord[] deviceRecords)
			{
				if (handle == null)
				{
					deviceRecords = null;
					return -2147024809;
				}
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblPresenceRecordGetDeviceRecords(handle.Handle, out rawPtr, out count);
				if (HR.FAILED(num))
				{
					deviceRecords = null;
					return num;
				}
				deviceRecords = Converters.PtrToClassArray<XblPresenceDeviceRecord, XblPresenceDeviceRecord>(rawPtr, count, (XblPresenceDeviceRecord dr) => new XblPresenceDeviceRecord(dr));
				return num;
			}

			// Token: 0x06000F74 RID: 3956 RVA: 0x00014E38 File Offset: 0x00013038
			public static int XblPresenceRecordDuplicateHandle(XblPresenceRecordHandle handle, out XblPresenceRecordHandle duplicatedHandle)
			{
				if (handle == null)
				{
					duplicatedHandle = null;
					return -2147024809;
				}
				XblPresenceRecordHandle interopHandle;
				return XblPresenceRecordHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblPresenceRecordDuplicateHandle(handle.Handle, out interopHandle), interopHandle, out duplicatedHandle);
			}

			// Token: 0x06000F75 RID: 3957 RVA: 0x00014E6B File Offset: 0x0001306B
			public static void XblPresenceRecordCloseHandle(XblPresenceRecordHandle handle)
			{
				if (handle == null)
				{
					return;
				}
				handle.Close();
			}

			// Token: 0x06000F76 RID: 3958 RVA: 0x00014E80 File Offset: 0x00013080
			public static void XblPresenceSetPresenceAsync(XblContextHandle xblContextHandle, bool isUserActiveInTitle, XblPresenceRichPresenceIds richPresenceIds, XblPresenceSetPresenceCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					int num = XblInterop.XblPresenceSetPresenceAsync(xblContextHandle.Handle, isUserActiveInTitle, (richPresenceIds == null) ? null : new XblPresenceRichPresenceIdsRef(richPresenceIds, disposableCollection), block2);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(block2);
						completionRoutine(num);
					}
				}
			}

			// Token: 0x06000F77 RID: 3959 RVA: 0x00014F28 File Offset: 0x00013128
			public static void XblPresenceGetPresenceAsync(XblContextHandle xblContextHandle, ulong xuid, XblPresenceGetPresenceCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblPresenceRecordHandle interopHandle;
					int hresult = XblInterop.XblPresenceGetPresenceResult(block, out interopHandle);
					XblPresenceRecordHandle presenceRecordHandle;
					XblPresenceRecordHandle.WrapInteropHandleAndReturnHResult(hresult, interopHandle, out presenceRecordHandle);
					completionRoutine(hresult, presenceRecordHandle);
				});
				int num = XblInterop.XblPresenceGetPresenceAsync(xblContextHandle.Handle, xuid, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F78 RID: 3960 RVA: 0x00014FA4 File Offset: 0x000131A4
			public static void XblPresenceGetPresenceForMultipleUsersAsync(XblContextHandle xblContextHandle, ulong[] xuids, XblPresenceQueryFilters filters, XblPresenceGetPresenceForMultipleUsersCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT presenceRecordHandlesCount;
					int num2 = XblInterop.XblPresenceGetPresenceForMultipleUsersResultCount(block, out presenceRecordHandlesCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					XblPresenceRecordHandle[] array = new XblPresenceRecordHandle[presenceRecordHandlesCount.ToInt32()];
					num2 = XblInterop.XblPresenceGetPresenceForMultipleUsersResult(block, array, presenceRecordHandlesCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, Array.ConvertAll<XblPresenceRecordHandle, XblPresenceRecordHandle>(array, (XblPresenceRecordHandle h) => new XblPresenceRecordHandle(h)));
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					int num = XblInterop.XblPresenceGetPresenceForMultipleUsersAsync(xblContextHandle.Handle, xuids, new SizeT((xuids != null) ? xuids.Length : 0), (filters == null) ? null : new XblPresenceQueryFiltersRef(filters, disposableCollection), block2);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(block2);
						completionRoutine(num, null);
					}
				}
			}

			// Token: 0x06000F79 RID: 3961 RVA: 0x0001505C File Offset: 0x0001325C
			public static void XblPresenceGetPresenceForSocialGroupAsync(XblContextHandle xblContextHandle, string socialGroupName, ulong? socialGroupOwnerXuid, XblPresenceQueryFilters filters, XblPresenceGetPresenceForSocialGroupCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT presenceRecordHandlesCount;
					int num2 = XblInterop.XblPresenceGetPresenceForSocialGroupResultCount(block, out presenceRecordHandlesCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					XblPresenceRecordHandle[] array = new XblPresenceRecordHandle[presenceRecordHandlesCount.ToInt32()];
					num2 = XblInterop.XblPresenceGetPresenceForSocialGroupResult(block, array, presenceRecordHandlesCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, Array.ConvertAll<XblPresenceRecordHandle, XblPresenceRecordHandle>(array, (XblPresenceRecordHandle h) => new XblPresenceRecordHandle(h)));
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					int num = XblInterop.XblPresenceGetPresenceForSocialGroupAsync(xblContextHandle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(socialGroupName), (socialGroupOwnerXuid == null) ? null : new UInt64Ref(socialGroupOwnerXuid.Value), (filters == null) ? null : new XblPresenceQueryFiltersRef(filters, disposableCollection), block2);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(block2);
						completionRoutine(num, null);
					}
				}
			}

			// Token: 0x06000F7A RID: 3962 RVA: 0x00015124 File Offset: 0x00013324
			public static void XblPrivacyGetAvoidListAsync(XblContextHandle xblContextHandle, XblPrivacyGetAvoidListCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT xuidCount;
					int num2 = XblInterop.XblPrivacyGetAvoidListResultCount(block, out xuidCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					ulong[] xuids = new ulong[xuidCount.ToInt32()];
					num2 = XblInterop.XblPrivacyGetAvoidListResult(block, xuidCount, xuids);
					completionRoutine(num2, xuids);
				});
				int num = XblInterop.XblPrivacyGetAvoidListAsync(xblContextHandle.Handle, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F7B RID: 3963 RVA: 0x000151A0 File Offset: 0x000133A0
			public static void XblPrivacyGetMuteListAsync(XblContextHandle xblContextHandle, XblPrivacyGetMuteListCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT xuidCount;
					int num2 = XblInterop.XblPrivacyGetMuteListResultCount(block, out xuidCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					ulong[] xuids = new ulong[xuidCount.ToInt32()];
					num2 = XblInterop.XblPrivacyGetMuteListResult(block, xuidCount, xuids);
					completionRoutine(num2, xuids);
				});
				int num = XblInterop.XblPrivacyGetMuteListAsync(xblContextHandle.Handle, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F7C RID: 3964 RVA: 0x0001521C File Offset: 0x0001341C
			public static void XblPrivacyCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission permissionToCheck, ulong targetXuid, XblPrivacyCheckPermissionCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblPrivacyCheckPermissionResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblPrivacyCheckPermissionResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass<XblPermissionCheckResult, XblPermissionCheckResult>(rawPtr, (XblPermissionCheckResult r) => new XblPermissionCheckResult(r)));
						}
					}
				});
				int num = XblInterop.XblPrivacyCheckPermissionAsync(xblContextHandle.Handle, permissionToCheck, targetXuid, block2);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F7D RID: 3965 RVA: 0x00015294 File Offset: 0x00013494
			public static void XblPrivacyCheckPermissionForAnonymousUserAsync(XblContextHandle xblContextHandle, XblPermission permissionToCheck, XblAnonymousUserType userType, XblPrivacyCheckPermissionCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblPrivacyCheckPermissionForAnonymousUserResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblPrivacyCheckPermissionForAnonymousUserResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass<XblPermissionCheckResult, XblPermissionCheckResult>(rawPtr, (XblPermissionCheckResult r) => new XblPermissionCheckResult(r)));
						}
					}
				});
				int num = XblInterop.XblPrivacyCheckPermissionForAnonymousUserAsync(xblContextHandle.Handle, permissionToCheck, userType, async);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F7E RID: 3966 RVA: 0x0001530C File Offset: 0x0001350C
			public static void XblPrivacyBatchCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission[] permissionsToCheck, ulong[] targetXuids, XblAnonymousUserType[] targetAnonymousUserTypes, XblPrivacyBatchCheckPermissionCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblPrivacyBatchCheckPermissionResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT count;
						SizeT sizeT;
						num2 = XblInterop.XblPrivacyBatchCheckPermissionResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out count, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClassArray<XblPermissionCheckResult, XblPermissionCheckResult>(rawPtr, count, (XblPermissionCheckResult r) => new XblPermissionCheckResult(r)));
						}
					}
				});
				int num = XblInterop.XblPrivacyBatchCheckPermissionAsync(xblContextHandle.Handle, permissionsToCheck, new SizeT((permissionsToCheck == null) ? 0 : permissionsToCheck.Length), targetXuids, new SizeT((targetXuids == null) ? 0 : targetXuids.Length), targetAnonymousUserTypes, new SizeT((targetAnonymousUserTypes == null) ? 0 : targetAnonymousUserTypes.Length), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F7F RID: 3967 RVA: 0x000153B4 File Offset: 0x000135B4
			public static void XblProfileGetUserProfileAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XblProfileGetUserProfileCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblUserProfile interopStruct;
					int num2 = XblInterop.XblProfileGetUserProfileResult(block, out interopStruct);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblUserProfile(interopStruct));
				});
				int num = XblInterop.XblProfileGetUserProfileAsync(xblContextHandle.Handle, xboxUserId, block2);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F80 RID: 3968 RVA: 0x0001542C File Offset: 0x0001362C
			public static void XblProfileGetUserProfilesAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, XblProfileGetUserProfilesCompleted completionRoutine)
			{
				if (xblContextHandle == null || xboxUserIds == null || xboxUserIds.Length == 0)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT profilesCount;
					int num2 = XblInterop.XblProfileGetUserProfilesResultCount(block, out profilesCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					XblUserProfile[] array = new XblUserProfile[profilesCount.ToInt32()];
					num2 = XblInterop.XblProfileGetUserProfilesResult(block, profilesCount, array);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, Array.ConvertAll<XblUserProfile, XblUserProfile>(array, (XblUserProfile x) => new XblUserProfile(x)));
				});
				int num = XblInterop.XblProfileGetUserProfilesAsync(xblContextHandle.Handle, xboxUserIds, new SizeT(xboxUserIds.Length), block2);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F81 RID: 3969 RVA: 0x000154B0 File Offset: 0x000136B0
			public static void XblProfileGetUserProfilesForSocialGroupAsync(XblContextHandle xblContextHandle, string socialGroup, XblProfileGetUserProfilesForSocialGroupCompleted completionRoutine)
			{
				if (xblContextHandle == null || socialGroup == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT profilesCount;
					int num2 = XblInterop.XblProfileGetUserProfilesForSocialGroupResultCount(block, out profilesCount);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					XblUserProfile[] array = new XblUserProfile[profilesCount.ToInt32()];
					num2 = XblInterop.XblProfileGetUserProfilesForSocialGroupResult(block, profilesCount, array);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, Array.ConvertAll<XblUserProfile, XblUserProfile>(array, (XblUserProfile x) => new XblUserProfile(x)));
				});
				int num = XblInterop.XblProfileGetUserProfilesForSocialGroupAsync(xblContextHandle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), block2);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F82 RID: 3970 RVA: 0x00015530 File Offset: 0x00013730
			public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddConnectionStateChangeHandler(XblContextHandle xboxLiveContext, XblConnectionStateChangeCallback callback)
			{
				int num = 0;
				if (callback != null)
				{
					IntPtr uniqueContext = SDK.XBL._connectionStateChangeCallbackManager.GetUniqueContext();
					num = RealTimeActivity.XblRealTimeActivityAddConnectionStateChangeHandler(xboxLiveContext.Handle, new RealTimeActivity.XblRealTimeActivityConnectionStateChangeHandler(SDK.XBL.ConnectionStateChangeCallbackManager.InteropPInvokeCallback), uniqueContext);
					if (XblRealTimeActivityCallbackToken.IsValid(num))
					{
						SDK.XBL._connectionStateChangeCallbackManager.AddCallbackForId(num, uniqueContext, callback);
					}
				}
				return new XblRealTimeActivityCallbackToken
				{
					InteropHandlerId = num
				};
			}

			// Token: 0x06000F83 RID: 3971 RVA: 0x0001558C File Offset: 0x0001378C
			public static int XblRealTimeActivityRemoveConnectionStateChangeHandler(XblContextHandle xboxLiveContext, ref XblRealTimeActivityCallbackToken connectionStateChangeCallbackToken)
			{
				int num = RealTimeActivity.XblRealTimeActivityRemoveConnectionStateChangeHandler(xboxLiveContext.Handle, connectionStateChangeCallbackToken.InteropHandlerId);
				if (HR.SUCCEEDED(num))
				{
					SDK.XBL._connectionStateChangeCallbackManager.RemoveCallbackForId(connectionStateChangeCallbackToken.InteropHandlerId);
					connectionStateChangeCallbackToken.Reset();
				}
				return num;
			}

			// Token: 0x06000F84 RID: 3972 RVA: 0x000155C0 File Offset: 0x000137C0
			public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddResyncHandler(XblContextHandle xboxLiveContext, XblConnectionResyncCallback callback)
			{
				int num = 0;
				if (callback != null)
				{
					IntPtr uniqueContext = SDK.XBL._connectionResyncCallbackManager.GetUniqueContext();
					num = RealTimeActivity.XblRealTimeActivityAddResyncHandler(xboxLiveContext.Handle, new RealTimeActivity.XblRealTimeActivityResyncHandler(SDK.XBL.ConnectionResyncCallbackManager.InteropPInvokeCallback), uniqueContext);
					if (XblRealTimeActivityCallbackToken.IsValid(num))
					{
						SDK.XBL._connectionResyncCallbackManager.AddCallbackForId(num, uniqueContext, callback);
					}
				}
				return new XblRealTimeActivityCallbackToken
				{
					InteropHandlerId = num
				};
			}

			// Token: 0x06000F85 RID: 3973 RVA: 0x0001561C File Offset: 0x0001381C
			public static int XblRealTimeActivityRemoveResyncHandler(XblContextHandle xboxLiveContext, ref XblRealTimeActivityCallbackToken connectionResyncCallbackToken)
			{
				int num = RealTimeActivity.XblRealTimeActivityRemoveResyncHandler(xboxLiveContext.Handle, connectionResyncCallbackToken.InteropHandlerId);
				if (HR.SUCCEEDED(num))
				{
					SDK.XBL._connectionResyncCallbackManager.RemoveCallbackForId(connectionResyncCallbackToken.InteropHandlerId);
					connectionResyncCallbackToken.Reset();
				}
				return num;
			}

			// Token: 0x06000F86 RID: 3974 RVA: 0x00015650 File Offset: 0x00013850
			public static void XblSocialGetSocialRelationshipsAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, XblSocialRelationshipFilter socialRelationshipFilter, uint startIndex, uint maxItems, XblSocialGetSocialRelationshipsResult completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblSocialRelationshipResultHandle interopHandle;
					int num2 = XblInterop.XblSocialGetSocialRelationshipsResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblSocialRelationshipResult(interopHandle));
				});
				int num = XblInterop.XblSocialGetSocialRelationshipsAsync(xboxLiveContext.Handle, xboxUserId, socialRelationshipFilter, new SizeT(startIndex), new SizeT(maxItems), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F87 RID: 3975 RVA: 0x000156DC File Offset: 0x000138DC
			public static int XblSocialRelationshipResultGetRelationships(XblSocialRelationshipResult resultHandle, out XblSocialRelationship[] relationships)
			{
				if (resultHandle == null)
				{
					relationships = null;
					return -2147024809;
				}
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblSocialRelationshipResultGetRelationships(resultHandle.InteropHandle, out rawPtr, out count);
				if (HR.FAILED(num))
				{
					relationships = null;
					return num;
				}
				relationships = Converters.PtrToClassArray<XblSocialRelationship, XblSocialRelationship>(rawPtr, count, (XblSocialRelationship c) => new XblSocialRelationship(c));
				return num;
			}

			// Token: 0x06000F88 RID: 3976 RVA: 0x0001573B File Offset: 0x0001393B
			public static int XblSocialRelationshipResultHasNext(XblSocialRelationshipResult result, out bool hasNext)
			{
				hasNext = false;
				if (result == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialRelationshipResultHasNext(result.InteropHandle, out hasNext);
			}

			// Token: 0x06000F89 RID: 3977 RVA: 0x00015758 File Offset: 0x00013958
			public static int XblSocialRelationshipResultGetTotalCount(XblSocialRelationshipResult result, out uint totalCount)
			{
				totalCount = 0U;
				if (result == null)
				{
					return -2147024809;
				}
				SizeT sizeT;
				int num = XblInterop.XblSocialRelationshipResultGetTotalCount(result.InteropHandle, out sizeT);
				if (HR.FAILED(num))
				{
					return num;
				}
				totalCount = sizeT.ToUInt32();
				return num;
			}

			// Token: 0x06000F8A RID: 3978 RVA: 0x00015794 File Offset: 0x00013994
			public static void XblSocialRelationshipResultGetNextAsync(XblContextHandle xboxLiveContext, XblSocialRelationshipResult result, uint maxItems, XblSocialRelationshipResultGetNextResult completionRoutine)
			{
				if (xboxLiveContext == null || result == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblSocialRelationshipResultHandle interopHandle;
					int num2 = XblInterop.XblSocialRelationshipResultGetNextResult(block, out interopHandle);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					completionRoutine(num2, new XblSocialRelationshipResult(interopHandle));
				});
				int num = XblInterop.XblSocialRelationshipResultGetNextAsync(xboxLiveContext.Handle, result.InteropHandle, new SizeT(maxItems), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000F8B RID: 3979 RVA: 0x0001581C File Offset: 0x00013A1C
			public static int XblSocialRelationshipResultDuplicateHandle(XblSocialRelationshipResult handle, out XblSocialRelationshipResult duplicatedHandle)
			{
				duplicatedHandle = null;
				if (handle == null)
				{
					return -2147024809;
				}
				XblSocialRelationshipResultHandle interopHandle;
				int num = XblInterop.XblSocialRelationshipResultDuplicateHandle(handle.InteropHandle, out interopHandle);
				if (HR.FAILED(num))
				{
					return num;
				}
				duplicatedHandle = new XblSocialRelationshipResult(interopHandle);
				return num;
			}

			// Token: 0x06000F8C RID: 3980 RVA: 0x00015856 File Offset: 0x00013A56
			public static void XblSocialRelationshipResultCloseHandle(XblSocialRelationshipResult handle)
			{
				handle.Dispose();
			}

			// Token: 0x06000F8D RID: 3981 RVA: 0x00015860 File Offset: 0x00013A60
			public static int XblSocialAddSocialRelationshipChangedHandler(XblContextHandle xboxLiveContext, XblSocialRelationshipChangedCallback eventCallback)
			{
				IntPtr uniqueContext = SDK.XBL._socialRelationshipChangeCallbackManager.GetUniqueContext();
				int num = XblInterop.XblSocialAddSocialRelationshipChangedHandler(xboxLiveContext.Handle, new XblSocialRelationshipChangedHandler(SDK.XBL.SocialRelationshipChangeCallbackManager.InteropPInvokeCallback), uniqueContext);
				if (num != 0)
				{
					SDK.XBL._socialRelationshipChangeCallbackManager.AddCallbackForId(num, uniqueContext, eventCallback);
				}
				return num;
			}

			// Token: 0x06000F8E RID: 3982 RVA: 0x000158A2 File Offset: 0x00013AA2
			public static int XblSocialRemoveSocialRelationshipChangedHandler(XblContextHandle xboxLiveContext, int callbackFunctionId)
			{
				int num = XblInterop.XblSocialRemoveSocialRelationshipChangedHandler(xboxLiveContext.Handle, callbackFunctionId);
				if (HR.SUCCEEDED(num))
				{
					SDK.XBL._socialRelationshipChangeCallbackManager.RemoveCallbackForId(callbackFunctionId);
				}
				return num;
			}

			// Token: 0x06000F8F RID: 3983 RVA: 0x000158C4 File Offset: 0x00013AC4
			public static bool XblSocialManagerPresenceRecordIsUserPlayingTitle(XblSocialManagerPresenceRecord presenceRecord, uint titleId)
			{
				XblSocialManagerPresenceRecord xblSocialManagerPresenceRecord = new XblSocialManagerPresenceRecord(presenceRecord);
				return XblInterop.XblSocialManagerPresenceRecordIsUserPlayingTitle(ref xblSocialManagerPresenceRecord, titleId);
			}

			// Token: 0x06000F90 RID: 3984 RVA: 0x000158E4 File Offset: 0x00013AE4
			public static int XblSocialManagerUserGroupGetUsers(XblSocialManagerUserGroupHandle group, out XblSocialManagerUser[] xboxSocialUsers)
			{
				xboxSocialUsers = null;
				if (group == null)
				{
					return -2147024809;
				}
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblSocialManagerUserGroupGetUsers(group.Handle, out rawPtr, out count);
				if (HR.FAILED(num))
				{
					return num;
				}
				xboxSocialUsers = Converters.PtrToClassArray<XblSocialManagerUser, IntPtr>(rawPtr, count, (IntPtr intPtr) => Converters.PtrToClass<XblSocialManagerUser, XblSocialManagerUser>(intPtr, (XblSocialManagerUser u) => new XblSocialManagerUser(u)));
				return num;
			}

			// Token: 0x06000F91 RID: 3985 RVA: 0x00015948 File Offset: 0x00013B48
			public static int XblSocialManagerUserGroupGetUsersTrackedByGroup(XblSocialManagerUserGroupHandle group, out ulong[] trackedUsers)
			{
				trackedUsers = null;
				if (group == null)
				{
					return -2147024809;
				}
				IntPtr rawPtr;
				SizeT sizeT;
				int num = XblInterop.XblSocialManagerUserGroupGetUsersTrackedByGroup(group.Handle, out rawPtr, out sizeT);
				if (!HR.FAILED(num))
				{
					trackedUsers = Converters.PtrToClassArray<ulong, ulong>(rawPtr, sizeT.ToUInt32(), (ulong x) => x);
				}
				return num;
			}

			// Token: 0x06000F92 RID: 3986 RVA: 0x000159AC File Offset: 0x00013BAC
			public static int XblSocialManagerAddLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerAddLocalUser(user.Handle, extraLevelDetail, SDK.defaultQueue);
			}

			// Token: 0x06000F93 RID: 3987 RVA: 0x000159CE File Offset: 0x00013BCE
			public static int XblSocialManagerRemoveLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerRemoveLocalUser(user.Handle);
			}

			// Token: 0x06000F94 RID: 3988 RVA: 0x000159EC File Offset: 0x00013BEC
			public static int XblSocialManagerDoWork(out XblSocialManagerEvent[] socialEvents)
			{
				IntPtr intPtr;
				SizeT count;
				int num = XblInterop.XblSocialManagerDoWork(out intPtr, out count);
				if (HR.FAILED(num))
				{
					socialEvents = null;
					return num;
				}
				if (intPtr == IntPtr.Zero)
				{
					socialEvents = null;
				}
				else
				{
					socialEvents = Converters.PtrToClassArray<XblSocialManagerEvent, XblSocialManagerEvent>(intPtr, count, (XblSocialManagerEvent e) => new XblSocialManagerEvent(e));
				}
				return num;
			}

			// Token: 0x06000F95 RID: 3989 RVA: 0x00015A4C File Offset: 0x00013C4C
			public static int XblSocialManagerCreateSocialUserGroupFromFilters(XUserHandle user, XblPresenceFilter presenceDetailLevel, XblRelationshipFilter filter, out XblSocialManagerUserGroupHandle group)
			{
				if (user == null)
				{
					group = null;
					return -2147024809;
				}
				XblSocialManagerUserGroupHandle interopHandle;
				return XblSocialManagerUserGroupHandle.WrapAndReturnHResult(XblInterop.XblSocialManagerCreateSocialUserGroupFromFilters(user.Handle, presenceDetailLevel, filter, out interopHandle), interopHandle, out group);
			}

			// Token: 0x06000F96 RID: 3990 RVA: 0x00015A84 File Offset: 0x00013C84
			public static int XblSocialManagerCreateSocialUserGroupFromList(XUserHandle user, ulong[] xboxUserIdList, out XblSocialManagerUserGroupHandle group)
			{
				if (user == null)
				{
					group = null;
					return -2147024809;
				}
				XblSocialManagerUserGroupHandle interopHandle;
				return XblSocialManagerUserGroupHandle.WrapAndReturnHResult(XblInterop.XblSocialManagerCreateSocialUserGroupFromList(user.Handle, xboxUserIdList, new SizeT((xboxUserIdList != null) ? xboxUserIdList.Length : 0), out interopHandle), interopHandle, out group);
			}

			// Token: 0x06000F97 RID: 3991 RVA: 0x00015AC6 File Offset: 0x00013CC6
			public static int XblSocialManagerDestroySocialUserGroup(XblSocialManagerUserGroupHandle group)
			{
				if (group == null)
				{
					return -2147024809;
				}
				int result = XblInterop.XblSocialManagerDestroySocialUserGroup(group.Handle);
				group.Close();
				return result;
			}

			// Token: 0x06000F98 RID: 3992 RVA: 0x00015AE8 File Offset: 0x00013CE8
			public static int XblSocialManagerGetLocalUsers(out XUserHandle[] users)
			{
				SizeT usersCount = XblInterop.XblSocialManagerGetLocalUserCount();
				IntPtr[] array = new IntPtr[usersCount.ToInt32()];
				int num = XblInterop.XblSocialManagerGetLocalUsers(usersCount, array);
				if (HR.FAILED(num))
				{
					users = null;
					return num;
				}
				users = Array.ConvertAll<IntPtr, XUserHandle>(array, (IntPtr u) => new XUserHandle(u, false));
				return num;
			}

			// Token: 0x06000F99 RID: 3993 RVA: 0x00015B45 File Offset: 0x00013D45
			public static int XblSocialManagerUpdateSocialUserGroup(XblSocialManagerUserGroupHandle group, ulong[] users)
			{
				if (group == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerUpdateSocialUserGroup(group.Handle, users, new SizeT((users != null) ? users.Length : 0));
			}

			// Token: 0x06000F9A RID: 3994 RVA: 0x00015B70 File Offset: 0x00013D70
			public static int XblSocialManagerSetRichPresencePollingStatus(XUserHandle user, bool shouldEnablePolling)
			{
				if (user == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerSetRichPresencePollingStatus(user.Handle, shouldEnablePolling);
			}

			// Token: 0x06000F9B RID: 3995 RVA: 0x00015B8D File Offset: 0x00013D8D
			public static int XblSocialManagerUserGroupGetType(XblSocialManagerUserGroupHandle group, out XblSocialUserGroupType type)
			{
				type = XblSocialUserGroupType.FilterType;
				if (group == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerUserGroupGetType(group.Handle, out type);
			}

			// Token: 0x06000F9C RID: 3996 RVA: 0x00015BB0 File Offset: 0x00013DB0
			public static int XblSocialManagerUserGroupGetLocalUser(XblSocialManagerUserGroupHandle group, out XUserHandle localUser)
			{
				localUser = null;
				if (group == null)
				{
					return -2147024809;
				}
				IntPtr intPtr;
				int num = XblInterop.XblSocialManagerUserGroupGetLocalUser(group.Handle, out intPtr);
				if (HR.SUCCEEDED(num) && intPtr != IntPtr.Zero)
				{
					localUser = new XUserHandle(intPtr, false);
					return num;
				}
				localUser = null;
				return num;
			}

			// Token: 0x06000F9D RID: 3997 RVA: 0x00015BFE File Offset: 0x00013DFE
			public static int XblSocialManagerUserGroupGetFilters(XblSocialManagerUserGroupHandle group, out XblPresenceFilter presenceFilter, out XblRelationshipFilter relationshipFilter)
			{
				presenceFilter = XblPresenceFilter.Unknown;
				relationshipFilter = XblRelationshipFilter.Unknown;
				if (group == null)
				{
					return -2147024809;
				}
				return XblInterop.XblSocialManagerUserGroupGetFilters(group.Handle, out presenceFilter, out relationshipFilter);
			}

			// Token: 0x06000F9E RID: 3998 RVA: 0x00015C24 File Offset: 0x00013E24
			public static void XblStringVerifyStringAsync(XblContextHandle xblContextHandle, string stringToVerify, XblStringVerifyStringCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblStringVerifyStringResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblStringVerifyStringResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClass<XblVerifyStringResult, XblVerifyStringResult>(rawPtr, (XblVerifyStringResult r) => new XblVerifyStringResult(r)));
						}
					}
				});
				int num = XblInterop.XblStringVerifyStringAsync(xblContextHandle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(stringToVerify), block2);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
					return;
				}
			}

			// Token: 0x06000F9F RID: 3999 RVA: 0x00015CA0 File Offset: 0x00013EA0
			public static void XblStringVerifyStringsAsync(XblContextHandle xblContextHandle, string[] stringsToVerify, XblStringVerifyStringsCompleted completionRoutine)
			{
				if (xblContextHandle == null || stringsToVerify == null || stringsToVerify.Length == 0)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblStringVerifyStringsResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer2 = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT count;
						SizeT sizeT;
						num2 = XblInterop.XblStringVerifyStringsResult(block, bufferSize, disposableBuffer2.IntPtr, out rawPtr, out count, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							completionRoutine(num2, Converters.PtrToClassArray<XblVerifyStringResult, XblVerifyStringResult>(rawPtr, count, (XblVerifyStringResult r) => new XblVerifyStringResult(r)));
						}
					}
				});
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(stringsToVerify))
				{
					int num = XblInterop.XblStringVerifyStringsAsync(xblContextHandle.Handle, disposableBuffer.IntPtr, Convert.ToUInt64(stringsToVerify.Length), block2);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			// Token: 0x06000FA0 RID: 4000 RVA: 0x00015D4C File Offset: 0x00013F4C
			public static void XblTitleManagedStatsWriteAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XblTitleManagedStatistic[] statistics, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, false);
					completionRoutine(hresult);
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XblTitleManagedStatistic[] array = Array.ConvertAll<XblTitleManagedStatistic, XblTitleManagedStatistic>(statistics, (XblTitleManagedStatistic s) => new XblTitleManagedStatistic(s, disposableCollection));
					int num = XblInterop.XblTitleManagedStatsWriteAsync(xblContextHandle.Handle, xboxUserId, array, new SizeT(array.Length), block2);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(block2);
						completionRoutine(num);
					}
				}
			}

			// Token: 0x06000FA1 RID: 4001 RVA: 0x00015E1C File Offset: 0x0001401C
			public static void XblTitleManagedStatsUpdateStatsAsync(XblContextHandle xblContextHandle, XblTitleManagedStatistic[] statistics, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, false);
					completionRoutine(hresult);
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					XblTitleManagedStatistic[] array = Array.ConvertAll<XblTitleManagedStatistic, XblTitleManagedStatistic>(statistics, (XblTitleManagedStatistic s) => new XblTitleManagedStatistic(s, disposableCollection));
					int num = XblInterop.XblTitleManagedStatsUpdateStatsAsync(xblContextHandle.Handle, array, new SizeT(array.Length), block2);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(block2);
						completionRoutine(num);
					}
				}
			}

			// Token: 0x06000FA2 RID: 4002 RVA: 0x00015EEC File Offset: 0x000140EC
			public static void XblTitleManagedStatsDeleteStatsAsync(XblContextHandle xblContextHandle, string[] statisticNames, XblTitleManagedStatsOperationCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, false);
					completionRoutine(hresult);
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					SizeT statisticNamesCount;
					IntPtr statisticNames2 = Converters.StringArrayToUTF8StringArray(statisticNames, disposableCollection, out statisticNamesCount);
					int num = XblInterop.XblTitleManagedStatsDeleteStatsAsync(xblContextHandle.Handle, statisticNames2, statisticNamesCount, block2);
					if (HR.FAILED(num))
					{
						AsyncHelpers.CleanupAsyncBlock(block2);
						completionRoutine(num);
					}
				}
			}

			// Token: 0x06000FA3 RID: 4003 RVA: 0x00015F98 File Offset: 0x00014198
			public static int XblTitleStorageBlobMetadataResultGetItems(XblTitleStorageBlobMetadataResultHandle resultHandle, out XblTitleStorageBlobMetadata[] items)
			{
				if (resultHandle == null)
				{
					items = null;
					return -2147024809;
				}
				IntPtr rawPtr;
				SizeT count;
				int num = XblInterop.XblTitleStorageBlobMetadataResultGetItems(resultHandle.Handle, out rawPtr, out count);
				if (HR.FAILED(num))
				{
					items = null;
					return num;
				}
				items = Converters.PtrToClassArray<XblTitleStorageBlobMetadata, XblTitleStorageBlobMetadata>(rawPtr, count, (XblTitleStorageBlobMetadata i) => new XblTitleStorageBlobMetadata(i));
				return num;
			}

			// Token: 0x06000FA4 RID: 4004 RVA: 0x00015FFD File Offset: 0x000141FD
			public static int XblTitleStorageBlobMetadataResultHasNext(XblTitleStorageBlobMetadataResultHandle result, out bool hasNext)
			{
				hasNext = false;
				if (result == null)
				{
					return -2147024809;
				}
				return XblInterop.XblTitleStorageBlobMetadataResultHasNext(result.Handle, out hasNext);
			}

			// Token: 0x06000FA5 RID: 4005 RVA: 0x00016020 File Offset: 0x00014220
			public static void XblTitleStorageBlobMetadataResultGetNextAsync(XblTitleStorageBlobMetadataResultHandle result, uint maxItems, XblTitleStorageBlobMetadataResultGetNextCompleted completionRoutine)
			{
				if (result == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblTitleStorageBlobMetadataResultHandle interopHandle;
					int num2 = XblInterop.XblTitleStorageBlobMetadataResultGetNextResult(block, out interopHandle);
					if (num2 == 0)
					{
						completionRoutine(num2, new XblTitleStorageBlobMetadataResultHandle(interopHandle));
						return;
					}
					completionRoutine(num2, null);
				});
				int num = XblInterop.XblTitleStorageBlobMetadataResultGetNextAsync(result.Handle, maxItems, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000FA6 RID: 4006 RVA: 0x0001609C File Offset: 0x0001429C
			public static int XblTitleStorageBlobMetadataResultDuplicateHandle(XblTitleStorageBlobMetadataResultHandle handle, out XblTitleStorageBlobMetadataResultHandle duplicatedHandle)
			{
				if (handle == null)
				{
					duplicatedHandle = null;
					return -2147024809;
				}
				XblTitleStorageBlobMetadataResultHandle interopHandle;
				int num = XblInterop.XblTitleStorageBlobMetadataResultDuplicateHandle(handle.Handle, out interopHandle);
				if (HR.SUCCEEDED(num))
				{
					duplicatedHandle = new XblTitleStorageBlobMetadataResultHandle(interopHandle);
					return num;
				}
				duplicatedHandle = null;
				return num;
			}

			// Token: 0x06000FA7 RID: 4007 RVA: 0x000160DC File Offset: 0x000142DC
			public static void XblTitleStorageBlobMetadataResultCloseHandle(XblTitleStorageBlobMetadataResultHandle handle)
			{
				if (handle == null)
				{
					return;
				}
				handle.Close();
			}

			// Token: 0x06000FA8 RID: 4008 RVA: 0x000160F0 File Offset: 0x000142F0
			public static void XblTitleStorageGetQuotaAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, XblTitleStorageType storageType, XblTitleStorageGetQuotaCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, 0UL, 0UL);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT sizeT;
					SizeT sizeT2;
					int num2 = XblInterop.XblTitleStorageGetQuotaResult(block, out sizeT, out sizeT2);
					if (num2 == 0)
					{
						completionRoutine(num2, sizeT.ToUInt64(), sizeT2.ToUInt64());
						return;
					}
					completionRoutine(num2, 0UL, 0UL);
				});
				int num = XblInterop.XblTitleStorageGetQuotaAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), storageType, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, 0UL, 0UL);
				}
			}

			// Token: 0x06000FA9 RID: 4009 RVA: 0x00016178 File Offset: 0x00014378
			public static void XblTitleStorageGetBlobMetadataAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, XblTitleStorageType storageType, string blobPath, ulong xboxUserId, uint skipItems, uint maxItems, XblTitleStorageGetBlobMetadataCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblTitleStorageBlobMetadataResultHandle interopHandle;
					int num2 = XblInterop.XblTitleStorageGetBlobMetadataResult(block, out interopHandle);
					if (num2 == 0)
					{
						completionRoutine(num2, new XblTitleStorageBlobMetadataResultHandle(interopHandle));
						return;
					}
					completionRoutine(num2, null);
				});
				int num = XblInterop.XblTitleStorageGetBlobMetadataAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), storageType, Converters.StringToNullTerminatedUTF8ByteArray(blobPath), xboxUserId, skipItems, maxItems, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000FAA RID: 4010 RVA: 0x00016208 File Offset: 0x00014408
			public static void XblTitleStorageDeleteBlobAsync(XblContextHandle xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, bool deleteOnlyIfEtagMatches, XblTitleStorageDeleteBlobCompleted completionRoutine)
			{
				if (xboxLiveContext == null)
				{
					completionRoutine(-2147024809);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, false));
				});
				int num = XblInterop.XblTitleStorageDeleteBlobAsync(xboxLiveContext.Handle, blobMetadata.interop, deleteOnlyIfEtagMatches, block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num);
				}
			}

			// Token: 0x06000FAB RID: 4011 RVA: 0x00016288 File Offset: 0x00014488
			public static void XblTitleStorageDownloadBlobAsync(XblContextHandle xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, XblTitleStorageETagMatchCondition etagMatchCondition, string selectQuery, ulong preferredDownloadBlockSize, XblTitleStorageDownloadBlobCompleted completionRoutine)
			{
				if (xboxLiveContext == null || blobMetadata.Length == 0UL)
				{
					completionRoutine(-2147024809, null, null);
				}
				int blobBufferCount = (int)blobMetadata.Length * Marshal.SizeOf<byte>(0);
				IntPtr blobBuffer = Marshal.AllocHGlobal(blobBufferCount);
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblTitleStorageBlobMetadata interopHandle;
					int num2 = XblInterop.XblTitleStorageDownloadBlobResult(block, out interopHandle);
					if (num2 == 0)
					{
						byte[] array = new byte[blobBufferCount];
						Marshal.Copy(blobBuffer, array, 0, array.Length);
						completionRoutine(num2, new XblTitleStorageBlobMetadata(interopHandle), array);
					}
					else
					{
						completionRoutine(num2, null, null);
					}
					Marshal.FreeHGlobal(blobBuffer);
				});
				int num = XblInterop.XblTitleStorageDownloadBlobAsync(xboxLiveContext.Handle, blobMetadata.interop, blobBuffer, new SizeT(blobBufferCount), etagMatchCondition, Converters.StringToNullTerminatedUTF8ByteArray(selectQuery), new SizeT(preferredDownloadBlockSize), block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num, null, null);
				}
			}

			// Token: 0x06000FAC RID: 4012 RVA: 0x00016358 File Offset: 0x00014558
			public static void XblTitleStorageUploadBlobAsync(XblContextHandle xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, byte[] blobBuffer, XblTitleStorageETagMatchCondition etagMatchCondition, ulong preferredDownloadBlockSize, XblTitleStorageUploadBlobCompleted completionRoutine)
			{
				if (xboxLiveContext == null || blobBuffer == null)
				{
					completionRoutine(-2147024809, null);
				}
				int num = blobBuffer.Length * Marshal.SizeOf<byte>(0);
				IntPtr blobBufferPtr = Marshal.AllocHGlobal(num);
				Marshal.Copy(blobBuffer, 0, blobBufferPtr, num);
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					XblTitleStorageBlobMetadata interopHandle;
					int num3 = XblInterop.XblTitleStorageUploadBlobResult(block, out interopHandle);
					if (num3 == 0)
					{
						completionRoutine(num3, new XblTitleStorageBlobMetadata(interopHandle));
					}
					else
					{
						completionRoutine(num3, null);
					}
					Marshal.FreeHGlobal(blobBufferPtr);
				});
				int num2 = XblInterop.XblTitleStorageUploadBlobAsync(xboxLiveContext.Handle, blobMetadata.interop, blobBufferPtr, new SizeT(num), etagMatchCondition, new SizeT(preferredDownloadBlockSize), block2);
				if (HR.FAILED(num2))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					completionRoutine(num2, null);
				}
			}

			// Token: 0x06000FAD RID: 4013 RVA: 0x00016414 File Offset: 0x00014614
			public static void XblUserStatisticsGetSingleUserStatisticAsync(XblContextHandle xblContextHandle, ulong xboxUserId, string serviceConfigurationId, string statisticName, XblUserStatisticsGetSingleUserStatisticCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblUserStatisticsResult result = Converters.PtrToClass<XblUserStatisticsResult, XblUserStatisticsResultInternal>(rawPtr, (XblUserStatisticsResultInternal r) => new XblUserStatisticsResult(r));
							completionRoutine(num2, result);
						}
					}
				});
				int num = XblInterop.XblUserStatisticsGetSingleUserStatisticAsync(xblContextHandle.Handle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(statisticName), block2);
				if (HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
			}

			// Token: 0x06000FAE RID: 4014 RVA: 0x00016498 File Offset: 0x00014698
			public static void XblUserStatisticsGetSingleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong xboxUserId, string serviceConfigurationId, string[] statisticNames, XblUserStatisticsGetSingleUserStatisticsCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticsResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer2 = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT sizeT;
						num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticsResult(block, bufferSize, disposableBuffer2.IntPtr, out rawPtr, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblUserStatisticsResult result = Converters.PtrToClass<XblUserStatisticsResult, XblUserStatisticsResultInternal>(rawPtr, (XblUserStatisticsResultInternal r) => new XblUserStatisticsResult(r));
							completionRoutine(num2, result);
						}
					}
				});
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
				{
					int num = XblInterop.XblUserStatisticsGetSingleUserStatisticsAsync(xblContextHandle.Handle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), disposableBuffer.IntPtr, new SizeT(statisticNames.Length), block2);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			// Token: 0x06000FAF RID: 4015 RVA: 0x00016544 File Offset: 0x00014744
			public static void XblUserStatisticsGetMultipleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, string serviceConfigurationId, string[] statisticNames, XblUserStatisticsGetMultipleUserStatisticsCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer2 = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT count;
						SizeT sizeT;
						num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsResult(block, bufferSize, disposableBuffer2.IntPtr, out rawPtr, out count, out sizeT);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblUserStatisticsResult[] results = Converters.PtrToClassArray<XblUserStatisticsResult, XblUserStatisticsResultInternal>(rawPtr, count, (XblUserStatisticsResultInternal r) => new XblUserStatisticsResult(r));
							completionRoutine(num2, results);
						}
					}
				});
				using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
				{
					int num = XblInterop.XblUserStatisticsGetMultipleUserStatisticsAsync(xblContextHandle.Handle, xboxUserIds, new SizeT(xboxUserIds.Length), Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), disposableBuffer.IntPtr, new SizeT(statisticNames.Length), block2);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			// Token: 0x06000FB0 RID: 4016 RVA: 0x000165F8 File Offset: 0x000147F8
			public static void XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, XblRequestedStatistics[] requestedServiceConfigurationStatisticsCollection, XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsCompleted completionRoutine)
			{
				if (xblContextHandle == null)
				{
					completionRoutine(-2147024809, null);
					return;
				}
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					SizeT bufferSize;
					int num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(block, out bufferSize);
					if (HR.FAILED(num2))
					{
						completionRoutine(num2, null);
						return;
					}
					using (DisposableBuffer disposableBuffer = new DisposableBuffer(bufferSize.ToInt32()))
					{
						IntPtr rawPtr;
						SizeT count;
						SizeT sizeT2;
						num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(block, bufferSize, disposableBuffer.IntPtr, out rawPtr, out count, out sizeT2);
						if (HR.FAILED(num2))
						{
							completionRoutine(num2, null);
						}
						else
						{
							XblUserStatisticsResult[] results = Converters.PtrToClassArray<XblUserStatisticsResult, XblUserStatisticsResultInternal>(rawPtr, count, (XblUserStatisticsResultInternal r) => new XblUserStatisticsResult(r));
							completionRoutine(num2, results);
						}
					}
				});
				using (DisposableCollection disposableCollection = new DisposableCollection())
				{
					SizeT sizeT;
					IntPtr requestedServiceConfigurationStatisticsCollection2 = Converters.ClassArrayToPtr<XblRequestedStatistics, XblRequestedStatisticsInternal>(requestedServiceConfigurationStatisticsCollection, (XblRequestedStatistics request, DisposableCollection disposables) => new XblRequestedStatisticsInternal(request, disposables), disposableCollection, out sizeT);
					int num = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(xblContextHandle.Handle, xboxUserIds, Convert.ToUInt32(xboxUserIds.Length), requestedServiceConfigurationStatisticsCollection2, sizeT.ToUInt32(), block2);
					if (HR.FAILED(num))
					{
						completionRoutine(num, null);
					}
				}
			}

			// Token: 0x06000FB1 RID: 4017 RVA: 0x000166CC File Offset: 0x000148CC
			public static int XblUserStatisticsAddStatisticChangedHandler(XblContextHandle xblContextHandle, XblStatisticChangedCallback eventCallback)
			{
				IntPtr uniqueContext = SDK.XBL._userStatisticsChangeCallbackManager.GetUniqueContext();
				int num = UserStatistics.XblUserStatisticsAddStatisticChangedHandler(xblContextHandle.Handle, new XblStatisticChangedHandler(SDK.XBL.UserStatisticsChangeCallbackManager.InteropPInvokeCallback), uniqueContext.ToPointer());
				if (num != 0)
				{
					SDK.XBL._userStatisticsChangeCallbackManager.AddCallbackForId(num, uniqueContext, eventCallback);
				}
				return num;
			}

			// Token: 0x06000FB2 RID: 4018 RVA: 0x00016714 File Offset: 0x00014914
			public static void XblUserStatisticsRemoveStatisticChangedHandler(XblContextHandle xblContextHandle, int callbackFunctionId)
			{
				UserStatistics.XblUserStatisticsRemoveStatisticChangedHandler(xblContextHandle.Handle, callbackFunctionId);
				SDK.XBL._userStatisticsChangeCallbackManager.RemoveCallbackForId(callbackFunctionId);
			}

			// Token: 0x06000FB3 RID: 4019 RVA: 0x00016730 File Offset: 0x00014930
			public unsafe static void XblUserStatisticsTrackStatistics(XblContextHandle xblContextHandle, ulong[] xuids, string serviceConfigurationId, string[] statisticNames)
			{
				sbyte[] array = new sbyte[Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId)];
				fixed (ulong* ptr = &xuids[0])
				{
					ulong* xboxUserIds = ptr;
					fixed (sbyte* ptr2 = ref array[0])
					{
						sbyte* ptr3 = ptr2;
						using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
						{
							Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)ptr3, serviceConfigurationId.Length);
							UserStatistics.XblUserStatisticsTrackStatistics(xblContextHandle.Handle, xboxUserIds, new UIntPtr((uint)xuids.Length), ptr3, (sbyte**)((void*)disposableBuffer.IntPtr), new UIntPtr((uint)statisticNames.Length));
						}
					}
				}
			}

			// Token: 0x06000FB4 RID: 4020 RVA: 0x000167C0 File Offset: 0x000149C0
			public unsafe static void XblUserStatisticsStopTrackingStatistics(XblContextHandle xblContextHandle, ulong[] xuids, string serviceConfigurationId, string[] statisticNames)
			{
				sbyte[] array = new sbyte[Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId)];
				fixed (ulong* ptr = &xuids[0])
				{
					ulong* xboxUserIds = ptr;
					fixed (sbyte* ptr2 = ref array[0])
					{
						sbyte* ptr3 = ptr2;
						using (DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
						{
							Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)ptr3, serviceConfigurationId.Length);
							UserStatistics.XblUserStatisticsStopTrackingStatistics(xblContextHandle.Handle, xboxUserIds, new UIntPtr((uint)xuids.Length), ptr3, (sbyte**)((void*)disposableBuffer.IntPtr), new UIntPtr((uint)statisticNames.Length));
						}
					}
				}
			}

			// Token: 0x06000FB5 RID: 4021 RVA: 0x00016850 File Offset: 0x00014A50
			public unsafe static void XblUserStatisticsStopTrackingUsers(XblContextHandle xblContextHandle, ulong[] xuids)
			{
				fixed (ulong* ptr = &xuids[0])
				{
					ulong* xboxUserIds = ptr;
					UserStatistics.XblUserStatisticsStopTrackingUsers(xblContextHandle.Handle, xboxUserIds, new UIntPtr((uint)xuids.Length));
				}
			}

			// Token: 0x06000FB6 RID: 4022 RVA: 0x00016880 File Offset: 0x00014A80
			public static int XblInitialize(string scid)
			{
				return XblInterop.XblWrapper_XblInitialize(Converters.StringToNullTerminatedUTF8ByteArray(scid), SDK.defaultQueue);
			}

			// Token: 0x06000FB7 RID: 4023 RVA: 0x00016894 File Offset: 0x00014A94
			public static void XblCleanup(SDK.XBL.XblCleanupResult completionRoutine)
			{
				XAsyncBlock block2 = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue, delegate(XAsyncBlock block)
				{
					int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, false);
					if (completionRoutine != null)
					{
						completionRoutine(hresult);
					}
				});
				int num = XblInterop.XblCleanupAsync(block2);
				if (HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(block2);
					if (completionRoutine != null)
					{
						completionRoutine(num);
					}
				}
			}

			// Token: 0x06000FB8 RID: 4024 RVA: 0x000168F4 File Offset: 0x00014AF4
			public static int XblContextCreateHandle(XUserHandle user, out XblContextHandle context)
			{
				if (user == null)
				{
					context = null;
					return -2147024809;
				}
				XblContextHandle interopHandle;
				int num = XblInterop.XblContextCreateHandle(user.Handle, out interopHandle);
				if (HR.SUCCEEDED(num))
				{
					context = new XblContextHandle(interopHandle);
					context.m_gCHandle = GCHandle.Alloc(context, GCHandleType.Normal);
					return num;
				}
				context = null;
				return num;
			}

			// Token: 0x06000FB9 RID: 4025 RVA: 0x00016943 File Offset: 0x00014B43
			public static void XblContextCloseHandle(XblContextHandle xboxLiveContextHandle)
			{
				xboxLiveContextHandle.Close();
			}

			// Token: 0x06000FBA RID: 4026 RVA: 0x0001694C File Offset: 0x00014B4C
			public static int XblContextDuplicateHandle(XblContextHandle srcXboxLiveContextHandle, out XblContextHandle dstXboxLiveContextHandle)
			{
				XblContextHandle interopHandle = default(XblContextHandle);
				int num = XboxLiveContext.XblContextDuplicateHandle(srcXboxLiveContextHandle.Handle, out interopHandle.handle);
				if (HR.SUCCEEDED(num))
				{
					dstXboxLiveContextHandle = new XblContextHandle(interopHandle);
					return num;
				}
				dstXboxLiveContextHandle = null;
				return num;
			}

			// Token: 0x06000FBB RID: 4027 RVA: 0x00016988 File Offset: 0x00014B88
			public static int XblContextGetUser(XblContextHandle xboxLiveContextHandle, out XUserHandle dstUserHandle)
			{
				IntPtr interopHandle = 0;
				int num = XboxLiveContext.XblContextGetUser(xboxLiveContextHandle.Handle, out interopHandle);
				if (HR.SUCCEEDED(num))
				{
					dstUserHandle = new XUserHandle(interopHandle);
					return num;
				}
				dstUserHandle = null;
				return num;
			}

			// Token: 0x06000FBC RID: 4028 RVA: 0x000169C0 File Offset: 0x00014BC0
			public static int XblContextGetXboxUserId(XblContextHandle xboxLiveContextHandle, ref ulong dstXboxUserId)
			{
				ulong num = 0UL;
				int num2 = XboxLiveContext.XblContextGetXboxUserId(xboxLiveContextHandle.Handle, out num);
				if (HR.SUCCEEDED(num2))
				{
					dstXboxUserId = num;
					return num2;
				}
				dstXboxUserId = 0UL;
				return num2;
			}

			// Token: 0x06000FBD RID: 4029 RVA: 0x000169F0 File Offset: 0x00014BF0
			public unsafe static int XblGetScid(ref string resultScid)
			{
				resultScid = string.Empty;
				sbyte* bytePointer;
				int num = XboxLiveGlobal.XblGetScid(&bytePointer);
				if (HR.SUCCEEDED(num))
				{
					resultScid = Converters.BytePointerToString((byte*)bytePointer, 36);
				}
				return num;
			}

			// Token: 0x040008F1 RID: 2289
			private static SDK.XBL.ConnectionStateChangeCallbackManager _connectionStateChangeCallbackManager = new SDK.XBL.ConnectionStateChangeCallbackManager();

			// Token: 0x040008F2 RID: 2290
			private static SDK.XBL.ConnectionResyncCallbackManager _connectionResyncCallbackManager = new SDK.XBL.ConnectionResyncCallbackManager();

			// Token: 0x040008F3 RID: 2291
			private static SDK.XBL.SocialRelationshipChangeCallbackManager _socialRelationshipChangeCallbackManager = new SDK.XBL.SocialRelationshipChangeCallbackManager();

			// Token: 0x040008F4 RID: 2292
			private static SDK.XBL.UserStatisticsChangeCallbackManager _userStatisticsChangeCallbackManager = new SDK.XBL.UserStatisticsChangeCallbackManager();

			// Token: 0x040008F5 RID: 2293
			public const int StandardScidLength = 36;

			// Token: 0x0200034D RID: 845
			// (Invoke) Token: 0x0600111C RID: 4380
			public delegate void XblAchievementsResultGetNextResult(int hresult, XblAchievementsResultHandle result);

			// Token: 0x0200034E RID: 846
			// (Invoke) Token: 0x06001120 RID: 4384
			public delegate void XblAchievementsGetAchievementsForTitleIdResult(int hresult, XblAchievementsResultHandle result);

			// Token: 0x0200034F RID: 847
			// (Invoke) Token: 0x06001124 RID: 4388
			public delegate void XblAchievementsUpdateAchievementResult(int hresult);

			// Token: 0x02000350 RID: 848
			// (Invoke) Token: 0x06001128 RID: 4392
			public delegate void XblAchievementsUpdateAchievementForTitleIdResult(int hresult);

			// Token: 0x02000351 RID: 849
			// (Invoke) Token: 0x0600112C RID: 4396
			public delegate void XblAchievementsGetAchievementResult(int hresult, XblAchievementsResultHandle result);

			// Token: 0x02000352 RID: 850
			// (Invoke) Token: 0x06001130 RID: 4400
			public delegate void XblAchievementsProgressChangeHandlerResult(int hresult, XblAchievementProgressChangeEventArgs eventArgs, IntPtr context);

			// Token: 0x02000353 RID: 851
			// (Invoke) Token: 0x06001134 RID: 4404
			public delegate void XblMatchmakingCreateMatchTicketHandleResult(int hresult, XblCreateMatchTicketResponse handle);

			// Token: 0x02000354 RID: 852
			// (Invoke) Token: 0x06001138 RID: 4408
			public delegate void XblMatchmakingDeleteMatchTicketHandleResult(int hresult);

			// Token: 0x02000355 RID: 853
			// (Invoke) Token: 0x0600113C RID: 4412
			public delegate void XblMatchmakingGetMatchTicketDetailsHandleResult(int hresult, XblMatchTicketDetailsResponse result);

			// Token: 0x02000356 RID: 854
			// (Invoke) Token: 0x06001140 RID: 4416
			public delegate void XblMatchmakingGetHopperStatisticsHandleResult(int hresult, XblHopperStatisticsResponse result);

			// Token: 0x02000357 RID: 855
			// (Invoke) Token: 0x06001144 RID: 4420
			public delegate void XblMultiplayerWriteSessionHandleResult(int hresult, XblMultiplayerSessionHandle handle);

			// Token: 0x02000358 RID: 856
			// (Invoke) Token: 0x06001148 RID: 4424
			public delegate void XblMultiplayerGetSessionHandleResult(int hresult, XblMultiplayerSessionHandle handle);

			// Token: 0x02000359 RID: 857
			// (Invoke) Token: 0x0600114C RID: 4428
			public delegate void XblMultiplayerSessionQueryHandleResult(int hresult, XblMultiplayerSessionQueryResult[] sessions);

			// Token: 0x0200035A RID: 858
			// (Invoke) Token: 0x06001150 RID: 4432
			public delegate void XblMultiplayerSetActivityHandleResult(int hresult);

			// Token: 0x0200035B RID: 859
			// (Invoke) Token: 0x06001154 RID: 4436
			public delegate void XblMultiplayerCreateSearchHandleResult(int hresult, XblMultiplayerSearchHandle handle);

			// Token: 0x0200035C RID: 860
			// (Invoke) Token: 0x06001158 RID: 4440
			public delegate void XblMultiplayerSetTransferHandleResult(int hresult, XblMultiplayerSessionHandleId handle);

			// Token: 0x0200035D RID: 861
			// (Invoke) Token: 0x0600115C RID: 4444
			public delegate void XblMultiplayerDeleteSearchHandleResult(int hresult);

			// Token: 0x0200035E RID: 862
			// (Invoke) Token: 0x06001160 RID: 4448
			public delegate void XblMultiplayerClearActivityHandleResult(int hresult);

			// Token: 0x0200035F RID: 863
			// (Invoke) Token: 0x06001164 RID: 4452
			public delegate void XblMultiplayerGetSearchHandlesResult(int hresult, XblMultiplayerSearchHandle[] searchHandles);

			// Token: 0x02000360 RID: 864
			// (Invoke) Token: 0x06001168 RID: 4456
			public delegate void XblMultiplayerSessionChangedHandler(XblMultiplayerSessionChangeEventArgs args);

			// Token: 0x02000361 RID: 865
			// (Invoke) Token: 0x0600116C RID: 4460
			public delegate void XblMultiplayerSessionSubscriptionLostHandler();

			// Token: 0x02000362 RID: 866
			// (Invoke) Token: 0x06001170 RID: 4464
			public delegate void XblMultiplayerConnectionIdChangedHandler();

			// Token: 0x02000363 RID: 867
			// (Invoke) Token: 0x06001174 RID: 4468
			public delegate void XblMultiplayerSendInvitesResult(int hresult, XblMultiplayerInviteHandle[] handles);

			// Token: 0x02000364 RID: 868
			// (Invoke) Token: 0x06001178 RID: 4472
			public delegate void XblMultiplayerGetActivitiesResult(int hresult, XblMultiplayerActivityDetails[] activities);

			// Token: 0x02000365 RID: 869
			// (Invoke) Token: 0x0600117C RID: 4476
			public delegate void XblMultiplayerActivityAsyncOperationCompleted(int hresult);

			// Token: 0x02000366 RID: 870
			// (Invoke) Token: 0x06001180 RID: 4480
			public delegate void XblMultiplayerGetActivityAsyncOperationCompleted(int hresult, XblMultiplayerActivityInfo[] results);

			// Token: 0x02000367 RID: 871
			private class ConnectionStateChangeCallbackManager : InteropCallbackManager<XblConnectionStateChangeCallback>
			{
				// Token: 0x06001183 RID: 4483 RVA: 0x00018168 File Offset: 0x00016368
				[MonoPInvokeCallback]
				internal static void InteropPInvokeCallback(IntPtr context, XblRealTimeActivityConnectionState newConnectionState)
				{
					if (!SDK.XBL._connectionStateChangeCallbackManager._contextToFunctionId.ContainsKey(context))
					{
						return;
					}
					int functionId = SDK.XBL._connectionStateChangeCallbackManager._contextToFunctionId[context];
					SDK.XBL._connectionStateChangeCallbackManager.IssueEventCallback(functionId, (XblRealTimeActivityConnectionState)newConnectionState);
				}

				// Token: 0x06001184 RID: 4484 RVA: 0x000181A8 File Offset: 0x000163A8
				private void IssueEventCallback(int functionId, XblRealTimeActivityConnectionState newConnectionState)
				{
					if (!this._functionIdToHandler.ContainsKey(functionId))
					{
						return;
					}
					InteropCallbackManager<XblConnectionStateChangeCallback>.HandlerContext handlerContext = this._functionIdToHandler[functionId];
					if (handlerContext.Callback != null)
					{
						handlerContext.Callback(newConnectionState);
					}
				}
			}

			// Token: 0x02000368 RID: 872
			private class ConnectionResyncCallbackManager : InteropCallbackManager<XblConnectionResyncCallback>
			{
				// Token: 0x06001186 RID: 4486 RVA: 0x000181F0 File Offset: 0x000163F0
				[MonoPInvokeCallback]
				internal static void InteropPInvokeCallback(IntPtr context)
				{
					if (!SDK.XBL._connectionResyncCallbackManager._contextToFunctionId.ContainsKey(context))
					{
						return;
					}
					int functionId = SDK.XBL._connectionResyncCallbackManager._contextToFunctionId[context];
					SDK.XBL._connectionResyncCallbackManager.IssueEventCallback(functionId);
				}

				// Token: 0x06001187 RID: 4487 RVA: 0x0001822C File Offset: 0x0001642C
				private void IssueEventCallback(int functionId)
				{
					if (!this._functionIdToHandler.ContainsKey(functionId))
					{
						return;
					}
					InteropCallbackManager<XblConnectionResyncCallback>.HandlerContext handlerContext = this._functionIdToHandler[functionId];
					if (handlerContext.Callback != null)
					{
						handlerContext.Callback();
					}
				}
			}

			// Token: 0x02000369 RID: 873
			private class SocialRelationshipChangeCallbackManager : InteropCallbackManager<XblSocialRelationshipChangedCallback>
			{
				// Token: 0x06001189 RID: 4489 RVA: 0x00018270 File Offset: 0x00016470
				[MonoPInvokeCallback]
				internal unsafe static void InteropPInvokeCallback(XblSocialRelationshipChangeEventArgs* eventArgs, IntPtr context)
				{
					if (!SDK.XBL._socialRelationshipChangeCallbackManager._contextToFunctionId.ContainsKey(context))
					{
						return;
					}
					int functionId = SDK.XBL._socialRelationshipChangeCallbackManager._contextToFunctionId[context];
					SDK.XBL._socialRelationshipChangeCallbackManager.IssueEventCallback(functionId, eventArgs);
				}

				// Token: 0x0600118A RID: 4490 RVA: 0x000182B0 File Offset: 0x000164B0
				private unsafe void IssueEventCallback(int functionId, XblSocialRelationshipChangeEventArgs* eventArgs)
				{
					if (!this._functionIdToHandler.ContainsKey(functionId))
					{
						return;
					}
					InteropCallbackManager<XblSocialRelationshipChangedCallback>.HandlerContext handlerContext = this._functionIdToHandler[functionId];
					XblSocialRelationshipChangeEventArgs xblSocialRelationshipChangeEventArgs = default(XblSocialRelationshipChangeEventArgs);
					xblSocialRelationshipChangeEventArgs.callerXboxUserId = eventArgs->callerXboxUserId;
					xblSocialRelationshipChangeEventArgs.socialNotification = eventArgs->socialNotification;
					xblSocialRelationshipChangeEventArgs.xboxUserIds = new ulong[eventArgs->xboxUserIdsCount.ToInt32()];
					ulong* ptr = eventArgs->xboxUserIds;
					for (int i = 0; i < eventArgs->xboxUserIdsCount.ToInt32(); i++)
					{
						xblSocialRelationshipChangeEventArgs.xboxUserIds[i] = *ptr;
						ptr++;
					}
					if (handlerContext.Callback != null)
					{
						handlerContext.Callback(xblSocialRelationshipChangeEventArgs);
					}
				}
			}

			// Token: 0x0200036A RID: 874
			// (Invoke) Token: 0x0600118D RID: 4493
			public delegate void XblUserStatisticsStatisticChangedHandler(XblStatisticChangeEventArgs args);

			// Token: 0x0200036B RID: 875
			private class UserStatisticsChangeCallbackManager : InteropCallbackManager<XblStatisticChangedCallback>
			{
				// Token: 0x06001190 RID: 4496 RVA: 0x0001835C File Offset: 0x0001655C
				[MonoPInvokeCallback]
				internal unsafe static void InteropPInvokeCallback(XblStatisticChangeEventArgs eventArgs, void* context)
				{
					if (!SDK.XBL._userStatisticsChangeCallbackManager._contextToFunctionId.ContainsKey(new IntPtr(context)))
					{
						return;
					}
					int functionId = SDK.XBL._userStatisticsChangeCallbackManager._contextToFunctionId[new IntPtr(context)];
					SDK.XBL._userStatisticsChangeCallbackManager.IssueEventCallback(functionId, eventArgs);
				}

				// Token: 0x06001191 RID: 4497 RVA: 0x000183A4 File Offset: 0x000165A4
				private unsafe void IssueEventCallback(int functionId, XblStatisticChangeEventArgs eventArgs)
				{
					if (!this._functionIdToHandler.ContainsKey(functionId))
					{
						return;
					}
					InteropCallbackManager<XblStatisticChangedCallback>.HandlerContext handlerContext = this._functionIdToHandler[functionId];
					XblStatisticChangeEventArgs statisticChangeEventArgs = new XblStatisticChangeEventArgs
					{
						latestStatistic = new XblStatistic(eventArgs.latestStatistic),
						serviceConfigurationId = Converters.NullTerminatedBytePointerToString((byte*)(&eventArgs.serviceConfigurationId.FixedElementField)),
						xboxUserId = eventArgs.xboxUserId
					};
					if (handlerContext.Callback != null)
					{
						handlerContext.Callback(statisticChangeEventArgs);
					}
				}
			}

			// Token: 0x0200036C RID: 876
			// (Invoke) Token: 0x06001194 RID: 4500
			public delegate void XblCleanupResult(int hresult);
		}
	}
}
