using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Steamworks
{
	// Token: 0x02000177 RID: 375
	public static class CallbackDispatcher
	{
		// Token: 0x06000880 RID: 2176 RVA: 0x0000C18B File Offset: 0x0000A38B
		public static void ExceptionHandler(Exception e)
		{
			Debug.LogException(e);
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x0000C193 File Offset: 0x0000A393
		public static bool IsInitialized
		{
			get
			{
				return CallbackDispatcher.m_initCount > 0;
			}
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0000C1A0 File Offset: 0x0000A3A0
		internal static void Initialize()
		{
			object sync = CallbackDispatcher.m_sync;
			lock (sync)
			{
				if (CallbackDispatcher.m_initCount == 0)
				{
					NativeMethods.SteamAPI_ManualDispatch_Init();
					CallbackDispatcher.m_pCallbackMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CallbackMsg_t)));
				}
				CallbackDispatcher.m_initCount++;
			}
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0000C20C File Offset: 0x0000A40C
		internal static void Shutdown()
		{
			object sync = CallbackDispatcher.m_sync;
			lock (sync)
			{
				CallbackDispatcher.m_initCount--;
				if (CallbackDispatcher.m_initCount == 0)
				{
					CallbackDispatcher.UnregisterAll();
					Marshal.FreeHGlobal(CallbackDispatcher.m_pCallbackMsg);
					CallbackDispatcher.m_pCallbackMsg = IntPtr.Zero;
				}
			}
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0000C274 File Offset: 0x0000A474
		internal static void Register(Callback cb)
		{
			int callbackIdentity = CallbackIdentities.GetCallbackIdentity(cb.GetCallbackType());
			Dictionary<int, List<Callback>> dictionary = cb.IsGameServer ? CallbackDispatcher.m_registeredGameServerCallbacks : CallbackDispatcher.m_registeredCallbacks;
			object sync = CallbackDispatcher.m_sync;
			lock (sync)
			{
				List<Callback> list;
				if (!dictionary.TryGetValue(callbackIdentity, out list))
				{
					list = new List<Callback>();
					dictionary.Add(callbackIdentity, list);
				}
				list.Add(cb);
			}
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0000C2F4 File Offset: 0x0000A4F4
		internal static void Register(SteamAPICall_t asyncCall, CallResult cr)
		{
			object sync = CallbackDispatcher.m_sync;
			lock (sync)
			{
				List<CallResult> list;
				if (!CallbackDispatcher.m_registeredCallResults.TryGetValue((ulong)asyncCall, out list))
				{
					list = new List<CallResult>();
					CallbackDispatcher.m_registeredCallResults.Add((ulong)asyncCall, list);
				}
				list.Add(cr);
			}
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0000C360 File Offset: 0x0000A560
		internal static void Unregister(Callback cb)
		{
			int callbackIdentity = CallbackIdentities.GetCallbackIdentity(cb.GetCallbackType());
			Dictionary<int, List<Callback>> dictionary = cb.IsGameServer ? CallbackDispatcher.m_registeredGameServerCallbacks : CallbackDispatcher.m_registeredCallbacks;
			object sync = CallbackDispatcher.m_sync;
			lock (sync)
			{
				List<Callback> list;
				if (dictionary.TryGetValue(callbackIdentity, out list))
				{
					list.Remove(cb);
					if (list.Count == 0)
					{
						dictionary.Remove(callbackIdentity);
					}
				}
			}
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0000C3E0 File Offset: 0x0000A5E0
		internal static void Unregister(SteamAPICall_t asyncCall, CallResult cr)
		{
			object sync = CallbackDispatcher.m_sync;
			lock (sync)
			{
				List<CallResult> list;
				if (CallbackDispatcher.m_registeredCallResults.TryGetValue((ulong)asyncCall, out list))
				{
					list.Remove(cr);
					if (list.Count == 0)
					{
						CallbackDispatcher.m_registeredCallResults.Remove((ulong)asyncCall);
					}
				}
			}
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x0000C450 File Offset: 0x0000A650
		private static void UnregisterAll()
		{
			List<Callback> list = new List<Callback>();
			List<CallResult> list2 = new List<CallResult>();
			object sync = CallbackDispatcher.m_sync;
			lock (sync)
			{
				foreach (KeyValuePair<int, List<Callback>> keyValuePair in CallbackDispatcher.m_registeredCallbacks)
				{
					list.AddRange(keyValuePair.Value);
				}
				CallbackDispatcher.m_registeredCallbacks.Clear();
				foreach (KeyValuePair<int, List<Callback>> keyValuePair2 in CallbackDispatcher.m_registeredGameServerCallbacks)
				{
					list.AddRange(keyValuePair2.Value);
				}
				CallbackDispatcher.m_registeredGameServerCallbacks.Clear();
				foreach (KeyValuePair<ulong, List<CallResult>> keyValuePair3 in CallbackDispatcher.m_registeredCallResults)
				{
					list2.AddRange(keyValuePair3.Value);
				}
				CallbackDispatcher.m_registeredCallResults.Clear();
				foreach (Callback callback in list)
				{
					callback.SetUnregistered();
				}
				foreach (CallResult callResult in list2)
				{
					callResult.SetUnregistered();
				}
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x0000C64C File Offset: 0x0000A84C
		internal static void RunFrame(bool isGameServer)
		{
			if (!CallbackDispatcher.IsInitialized)
			{
				throw new InvalidOperationException("Callback dispatcher is not initialized.");
			}
			HSteamPipe hSteamPipe = (HSteamPipe)(isGameServer ? NativeMethods.SteamGameServer_GetHSteamPipe() : NativeMethods.SteamAPI_GetHSteamPipe());
			NativeMethods.SteamAPI_ManualDispatch_RunFrame(hSteamPipe);
			Dictionary<int, List<Callback>> dictionary = isGameServer ? CallbackDispatcher.m_registeredGameServerCallbacks : CallbackDispatcher.m_registeredCallbacks;
			while (NativeMethods.SteamAPI_ManualDispatch_GetNextCallback(hSteamPipe, CallbackDispatcher.m_pCallbackMsg))
			{
				CallbackMsg_t callbackMsg_t = (CallbackMsg_t)Marshal.PtrToStructure(CallbackDispatcher.m_pCallbackMsg, typeof(CallbackMsg_t));
				try
				{
					List<Callback> collection;
					if (callbackMsg_t.m_iCallback == 703)
					{
						SteamAPICallCompleted_t steamAPICallCompleted_t = (SteamAPICallCompleted_t)Marshal.PtrToStructure(callbackMsg_t.m_pubParam, typeof(SteamAPICallCompleted_t));
						IntPtr intPtr = Marshal.AllocHGlobal((int)steamAPICallCompleted_t.m_cubParam);
						bool bFailed;
						if (NativeMethods.SteamAPI_ManualDispatch_GetAPICallResult(hSteamPipe, steamAPICallCompleted_t.m_hAsyncCall, intPtr, (int)steamAPICallCompleted_t.m_cubParam, steamAPICallCompleted_t.m_iCallback, out bFailed))
						{
							object sync = CallbackDispatcher.m_sync;
							lock (sync)
							{
								List<CallResult> list;
								if (CallbackDispatcher.m_registeredCallResults.TryGetValue((ulong)steamAPICallCompleted_t.m_hAsyncCall, out list))
								{
									CallbackDispatcher.m_registeredCallResults.Remove((ulong)steamAPICallCompleted_t.m_hAsyncCall);
									foreach (CallResult callResult in list)
									{
										callResult.OnRunCallResult(intPtr, bFailed, (ulong)steamAPICallCompleted_t.m_hAsyncCall);
										callResult.SetUnregistered();
									}
								}
							}
						}
						Marshal.FreeHGlobal(intPtr);
					}
					else if (dictionary.TryGetValue(callbackMsg_t.m_iCallback, out collection))
					{
						object sync = CallbackDispatcher.m_sync;
						List<Callback> list2;
						lock (sync)
						{
							list2 = new List<Callback>(collection);
						}
						foreach (Callback callback in list2)
						{
							callback.OnRunCallback(callbackMsg_t.m_pubParam);
						}
					}
				}
				catch (Exception e)
				{
					CallbackDispatcher.ExceptionHandler(e);
				}
				finally
				{
					NativeMethods.SteamAPI_ManualDispatch_FreeLastCallback(hSteamPipe);
				}
			}
		}

		// Token: 0x040009E3 RID: 2531
		private static Dictionary<int, List<Callback>> m_registeredCallbacks = new Dictionary<int, List<Callback>>();

		// Token: 0x040009E4 RID: 2532
		private static Dictionary<int, List<Callback>> m_registeredGameServerCallbacks = new Dictionary<int, List<Callback>>();

		// Token: 0x040009E5 RID: 2533
		private static Dictionary<ulong, List<CallResult>> m_registeredCallResults = new Dictionary<ulong, List<CallResult>>();

		// Token: 0x040009E6 RID: 2534
		private static object m_sync = new object();

		// Token: 0x040009E7 RID: 2535
		private static IntPtr m_pCallbackMsg;

		// Token: 0x040009E8 RID: 2536
		private static int m_initCount;
	}
}
