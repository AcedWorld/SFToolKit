using System;

namespace Steamworks
{
	// Token: 0x02000012 RID: 18
	public static class SteamHTTP
	{
		// Token: 0x0600022A RID: 554 RVA: 0x00006CCC File Offset: 0x00004ECC
		public static HTTPRequestHandle CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, string pchAbsoluteURL)
		{
			InteropHelp.TestIfAvailableClient();
			HTTPRequestHandle result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchAbsoluteURL))
			{
				result = (HTTPRequestHandle)NativeMethods.ISteamHTTP_CreateHTTPRequest(CSteamAPIContext.GetSteamHTTP(), eHTTPRequestMethod, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00006D14 File Offset: 0x00004F14
		public static bool SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestContextValue(CSteamAPIContext.GetSteamHTTP(), hRequest, ulContextValue);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00006D27 File Offset: 0x00004F27
		public static bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestNetworkActivityTimeout(CSteamAPIContext.GetSteamHTTP(), hRequest, unTimeoutSeconds);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00006D3C File Offset: 0x00004F3C
		public static bool SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, string pchHeaderValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHeaderName))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchHeaderValue))
				{
					result = NativeMethods.ISteamHTTP_SetHTTPRequestHeaderValue(CSteamAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00006DA0 File Offset: 0x00004FA0
		public static bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, string pchParamName, string pchParamValue)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchParamName))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchParamValue))
				{
					result = NativeMethods.ISteamHTTP_SetHTTPRequestGetOrPostParameter(CSteamAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, utf8StringHandle2);
				}
			}
			return result;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00006E04 File Offset: 0x00005004
		public static bool SendHTTPRequest(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SendHTTPRequest(CSteamAPIContext.GetSteamHTTP(), hRequest, out pCallHandle);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00006E17 File Offset: 0x00005017
		public static bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SendHTTPRequestAndStreamResponse(CSteamAPIContext.GetSteamHTTP(), hRequest, out pCallHandle);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00006E2A File Offset: 0x0000502A
		public static bool DeferHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_DeferHTTPRequest(CSteamAPIContext.GetSteamHTTP(), hRequest);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00006E3C File Offset: 0x0000503C
		public static bool PrioritizeHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_PrioritizeHTTPRequest(CSteamAPIContext.GetSteamHTTP(), hRequest);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00006E50 File Offset: 0x00005050
		public static bool GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, string pchHeaderName, out uint unResponseHeaderSize)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHeaderName))
			{
				result = NativeMethods.ISteamHTTP_GetHTTPResponseHeaderSize(CSteamAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, out unResponseHeaderSize);
			}
			return result;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00006E94 File Offset: 0x00005094
		public static bool GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, string pchHeaderName, byte[] pHeaderValueBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHeaderName))
			{
				result = NativeMethods.ISteamHTTP_GetHTTPResponseHeaderValue(CSteamAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, pHeaderValueBuffer, unBufferSize);
			}
			return result;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00006EDC File Offset: 0x000050DC
		public static bool GetHTTPResponseBodySize(HTTPRequestHandle hRequest, out uint unBodySize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPResponseBodySize(CSteamAPIContext.GetSteamHTTP(), hRequest, out unBodySize);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00006EEF File Offset: 0x000050EF
		public static bool GetHTTPResponseBodyData(HTTPRequestHandle hRequest, byte[] pBodyDataBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPResponseBodyData(CSteamAPIContext.GetSteamHTTP(), hRequest, pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00006F03 File Offset: 0x00005103
		public static bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, byte[] pBodyDataBuffer, uint unBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPStreamingResponseBodyData(CSteamAPIContext.GetSteamHTTP(), hRequest, cOffset, pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00006F18 File Offset: 0x00005118
		public static bool ReleaseHTTPRequest(HTTPRequestHandle hRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_ReleaseHTTPRequest(CSteamAPIContext.GetSteamHTTP(), hRequest);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00006F2A File Offset: 0x0000512A
		public static bool GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, out float pflPercentOut)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPDownloadProgressPct(CSteamAPIContext.GetSteamHTTP(), hRequest, out pflPercentOut);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00006F40 File Offset: 0x00005140
		public static bool SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, string pchContentType, byte[] pubBody, uint unBodyLen)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchContentType))
			{
				result = NativeMethods.ISteamHTTP_SetHTTPRequestRawPostBody(CSteamAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle, pubBody, unBodyLen);
			}
			return result;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00006F88 File Offset: 0x00005188
		public static HTTPCookieContainerHandle CreateCookieContainer(bool bAllowResponsesToModify)
		{
			InteropHelp.TestIfAvailableClient();
			return (HTTPCookieContainerHandle)NativeMethods.ISteamHTTP_CreateCookieContainer(CSteamAPIContext.GetSteamHTTP(), bAllowResponsesToModify);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00006F9F File Offset: 0x0000519F
		public static bool ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_ReleaseCookieContainer(CSteamAPIContext.GetSteamHTTP(), hCookieContainer);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00006FB4 File Offset: 0x000051B4
		public static bool SetCookie(HTTPCookieContainerHandle hCookieContainer, string pchHost, string pchUrl, string pchCookie)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchHost))
			{
				using (InteropHelp.UTF8StringHandle utf8StringHandle2 = new InteropHelp.UTF8StringHandle(pchUrl))
				{
					using (InteropHelp.UTF8StringHandle utf8StringHandle3 = new InteropHelp.UTF8StringHandle(pchCookie))
					{
						result = NativeMethods.ISteamHTTP_SetCookie(CSteamAPIContext.GetSteamHTTP(), hCookieContainer, utf8StringHandle, utf8StringHandle2, utf8StringHandle3);
					}
				}
			}
			return result;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00007034 File Offset: 0x00005234
		public static bool SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestCookieContainer(CSteamAPIContext.GetSteamHTTP(), hRequest, hCookieContainer);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00007048 File Offset: 0x00005248
		public static bool SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, string pchUserAgentInfo)
		{
			InteropHelp.TestIfAvailableClient();
			bool result;
			using (InteropHelp.UTF8StringHandle utf8StringHandle = new InteropHelp.UTF8StringHandle(pchUserAgentInfo))
			{
				result = NativeMethods.ISteamHTTP_SetHTTPRequestUserAgentInfo(CSteamAPIContext.GetSteamHTTP(), hRequest, utf8StringHandle);
			}
			return result;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000708C File Offset: 0x0000528C
		public static bool SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, bool bRequireVerifiedCertificate)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate(CSteamAPIContext.GetSteamHTTP(), hRequest, bRequireVerifiedCertificate);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000709F File Offset: 0x0000529F
		public static bool SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS(CSteamAPIContext.GetSteamHTTP(), hRequest, unMilliseconds);
		}

		// Token: 0x06000242 RID: 578 RVA: 0x000070B2 File Offset: 0x000052B2
		public static bool GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, out bool pbWasTimedOut)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamHTTP_GetHTTPRequestWasTimedOut(CSteamAPIContext.GetSteamHTTP(), hRequest, out pbWasTimedOut);
		}
	}
}
