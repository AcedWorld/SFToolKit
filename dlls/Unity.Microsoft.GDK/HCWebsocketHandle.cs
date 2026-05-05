using System;
using System.Runtime.InteropServices;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000006 RID: 6
	[MovedFrom("Unity.GameCore")]
	public class HCWebsocketHandle
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002215 File Offset: 0x00000415
		internal HCWebsocketHandle(HCWebsocketHandle interopHandle)
		{
			this.InteropHandle = interopHandle;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002224 File Offset: 0x00000424
		internal static int WrapAndReturnHResult(int hresult, HCWebsocketHandle interopHandle, out HCWebsocketHandle handle, GCHandle callbackHandle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new HCWebsocketHandle(interopHandle);
				handle.cbHandle = callbackHandle;
			}
			else
			{
				if (callbackHandle.IsAllocated)
				{
					callbackHandle.Free();
				}
				handle = null;
			}
			return hresult;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002254 File Offset: 0x00000454
		internal void ClearInteropHandle()
		{
			this.InteropHandle = default(HCWebsocketHandle);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002270 File Offset: 0x00000470
		public override bool Equals(object obj)
		{
			HCWebsocketHandle hcwebsocketHandle = obj as HCWebsocketHandle;
			return hcwebsocketHandle != null && this.InteropHandle.Ptr == hcwebsocketHandle.InteropHandle.Ptr;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000022A4 File Offset: 0x000004A4
		public override int GetHashCode()
		{
			return this.InteropHandle.Ptr.GetHashCode();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000022C4 File Offset: 0x000004C4
		public static bool operator ==(HCWebsocketHandle handle1, HCWebsocketHandle handle2)
		{
			if (handle1 != null)
			{
				return handle1.Equals(handle2);
			}
			return handle2 == null;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000022D5 File Offset: 0x000004D5
		public static bool operator !=(HCWebsocketHandle handle1, HCWebsocketHandle handle2)
		{
			return !(handle1 == handle2);
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000022E1 File Offset: 0x000004E1
		public HCWebSocketMessageFunction MessageFunction
		{
			get
			{
				return this.messageCallback;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000022E9 File Offset: 0x000004E9
		public HCWebSocketBinaryMessageFunction BinaryMessageFunction
		{
			get
			{
				return this.binaryMessageCallback;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000022F1 File Offset: 0x000004F1
		public HCWebSocketCloseEventFunction CloseFunction
		{
			get
			{
				return this.closeCallback;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000022F9 File Offset: 0x000004F9
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002301 File Offset: 0x00000501
		internal HCWebsocketHandle InteropHandle { get; set; }

		// Token: 0x04000015 RID: 21
		internal HCWebSocketMessageFunction messageFunc;

		// Token: 0x04000016 RID: 22
		internal HCWebSocketBinaryMessageFunction binaryMessageFunc;

		// Token: 0x04000017 RID: 23
		internal HCWebSocketCloseEventFunction closeFunc;

		// Token: 0x04000018 RID: 24
		internal HCWebSocketMessageFunction messageCallback;

		// Token: 0x04000019 RID: 25
		internal HCWebSocketBinaryMessageFunction binaryMessageCallback;

		// Token: 0x0400001A RID: 26
		internal HCWebSocketCloseEventFunction closeCallback;

		// Token: 0x0400001B RID: 27
		internal GCHandle cbHandle;
	}
}
