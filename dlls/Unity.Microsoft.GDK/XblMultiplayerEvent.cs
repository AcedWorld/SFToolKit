using System;
using System.Runtime.InteropServices;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000AD RID: 173
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerEvent
	{
		// Token: 0x06000564 RID: 1380 RVA: 0x0000AF48 File Offset: 0x00009148
		internal XblMultiplayerEvent(XblMultiplayerEvent interopStruct)
		{
			this.Result = interopStruct.Result;
			this.ErrorMessage = interopStruct.ErrorMessage.GetString();
			this.EventType = interopStruct.EventType;
			this.EventArgsHandle = new XblMultiplayerEventArgsHandle(interopStruct.EventArgsHandle);
			this.SessionType = interopStruct.SessionType;
			this.Context = null;
			if (interopStruct.Context != IntPtr.Zero)
			{
				GCHandle gchandle = GCHandle.FromIntPtr(interopStruct.Context);
				this.Context = gchandle.Target;
				gchandle.Free();
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x0000AFDD File Offset: 0x000091DD
		public int Result { get; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0000AFE5 File Offset: 0x000091E5
		public string ErrorMessage { get; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0000AFED File Offset: 0x000091ED
		public object Context { get; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0000AFF5 File Offset: 0x000091F5
		public XblMultiplayerEventType EventType { get; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x0000AFFD File Offset: 0x000091FD
		public XblMultiplayerEventArgsHandle EventArgsHandle { get; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0000B005 File Offset: 0x00009205
		public XblMultiplayerSessionType SessionType { get; }
	}
}
