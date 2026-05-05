using System;
using System.Runtime.InteropServices;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200011A RID: 282
	[MovedFrom("Unity.GameCore")]
	public class XblContextHandle : EquatableHandle
	{
		// Token: 0x06000730 RID: 1840 RVA: 0x0000C8DC File Offset: 0x0000AADC
		[MonoPInvokeCallback]
		private static void XblMultiplayerSessionChangedCallback(IntPtr context, XblMultiplayerSessionChangeEventArgs args)
		{
			SDK.XBL.XblMultiplayerSessionChangedHandler xblMultiplayerSessionChangedHandler = ((XblContextHandle)GCHandle.FromIntPtr(context).Target).sessionChangedCallback;
			if (xblMultiplayerSessionChangedHandler == null)
			{
				return;
			}
			xblMultiplayerSessionChangedHandler(new XblMultiplayerSessionChangeEventArgs(args));
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0000C914 File Offset: 0x0000AB14
		[MonoPInvokeCallback]
		private static void XblMultiplayerSessionSubscriptionLostCallback(IntPtr context)
		{
			SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler xblMultiplayerSessionSubscriptionLostHandler = ((XblContextHandle)GCHandle.FromIntPtr(context).Target).sessionSubscriptionLostCallback;
			if (xblMultiplayerSessionSubscriptionLostHandler == null)
			{
				return;
			}
			xblMultiplayerSessionSubscriptionLostHandler();
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0000C944 File Offset: 0x0000AB44
		[MonoPInvokeCallback]
		private static void XblMultiplayerConnectionIdChangedCallback(IntPtr context)
		{
			SDK.XBL.XblMultiplayerConnectionIdChangedHandler xblMultiplayerConnectionIdChangedHandler = ((XblContextHandle)GCHandle.FromIntPtr(context).Target).connectionIdChangedCallback;
			if (xblMultiplayerConnectionIdChangedHandler == null)
			{
				return;
			}
			xblMultiplayerConnectionIdChangedHandler();
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0000C974 File Offset: 0x0000AB74
		[MonoPInvokeCallback]
		private static void XblUserStatisticsAddChangedCallback(XblStatisticChangeEventArgs args, IntPtr context)
		{
			SDK.XBL.XblUserStatisticsStatisticChangedHandler xblUserStatisticsStatisticChangedHandler = ((XblContextHandle)GCHandle.FromIntPtr(context).Target).statisticChangedCallback;
			if (xblUserStatisticsStatisticChangedHandler == null)
			{
				return;
			}
			xblUserStatisticsStatisticChangedHandler(new XblStatisticChangeEventArgs(args));
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000734 RID: 1844 RVA: 0x0000C9AC File Offset: 0x0000ABAC
		// (remove) Token: 0x06000735 RID: 1845 RVA: 0x0000CA00 File Offset: 0x0000AC00
		public event SDK.XBL.XblMultiplayerSessionChangedHandler XblMultiplayerSessionChanged
		{
			add
			{
				if (this.sessionChangedCallback == null)
				{
					this.sessionChangedHandlerId = XblInterop.XblMultiplayerAddSessionChangedHandler(base.Handle, new XblInterop.XblMultiplayerSessionChangedHandler(XblContextHandle.XblMultiplayerSessionChangedCallback), GCHandle.ToIntPtr(this.m_gCHandle));
				}
				this.sessionChangedCallback = (SDK.XBL.XblMultiplayerSessionChangedHandler)Delegate.Combine(this.sessionChangedCallback, value);
			}
			remove
			{
				this.sessionChangedCallback = (SDK.XBL.XblMultiplayerSessionChangedHandler)Delegate.Remove(this.sessionChangedCallback, value);
				if (this.sessionChangedCallback == null)
				{
					XblInterop.XblMultiplayerRemoveSessionChangedHandler(base.Handle, this.sessionChangedHandlerId);
					this.sessionChangedHandlerId = default(XblFunctionContext);
				}
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000736 RID: 1846 RVA: 0x0000CA40 File Offset: 0x0000AC40
		// (remove) Token: 0x06000737 RID: 1847 RVA: 0x0000CA94 File Offset: 0x0000AC94
		public event SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler XblMultiplayerSessionSubscriptionLost
		{
			add
			{
				if (this.sessionSubscriptionLostCallback == null)
				{
					this.sessionSubscriptionLostId = XblInterop.XblMultiplayerAddSubscriptionLostHandler(base.Handle, new XblInterop.XblMultiplayerSessionSubscriptionLostHandler(XblContextHandle.XblMultiplayerSessionSubscriptionLostCallback), GCHandle.ToIntPtr(this.m_gCHandle));
				}
				this.sessionSubscriptionLostCallback = (SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler)Delegate.Combine(this.sessionSubscriptionLostCallback, value);
			}
			remove
			{
				this.sessionSubscriptionLostCallback = (SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler)Delegate.Remove(this.sessionSubscriptionLostCallback, value);
				if (this.sessionSubscriptionLostCallback == null)
				{
					XblInterop.XblMultiplayerRemoveSubscriptionLostHandler(base.Handle, this.sessionSubscriptionLostId);
					this.sessionSubscriptionLostId = default(XblFunctionContext);
				}
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000738 RID: 1848 RVA: 0x0000CAD4 File Offset: 0x0000ACD4
		// (remove) Token: 0x06000739 RID: 1849 RVA: 0x0000CB28 File Offset: 0x0000AD28
		public event SDK.XBL.XblMultiplayerConnectionIdChangedHandler XblMultiplayerConnectionIdChanged
		{
			add
			{
				if (this.connectionIdChangedCallback == null)
				{
					this.connectionIdChangedId = XblInterop.XblMultiplayerAddConnectionIdChangedHandler(base.Handle, new XblInterop.XblMultiplayerConnectionIdChangedHandler(XblContextHandle.XblMultiplayerConnectionIdChangedCallback), GCHandle.ToIntPtr(this.m_gCHandle));
				}
				this.connectionIdChangedCallback = (SDK.XBL.XblMultiplayerConnectionIdChangedHandler)Delegate.Combine(this.connectionIdChangedCallback, value);
			}
			remove
			{
				this.connectionIdChangedCallback = (SDK.XBL.XblMultiplayerConnectionIdChangedHandler)Delegate.Remove(this.connectionIdChangedCallback, value);
				if (this.connectionIdChangedCallback == null)
				{
					XblInterop.XblMultiplayerRemoveConnectionIdChangedHandler(base.Handle, this.connectionIdChangedId);
					this.connectionIdChangedId = default(XblFunctionContext);
				}
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600073A RID: 1850 RVA: 0x0000CB68 File Offset: 0x0000AD68
		// (remove) Token: 0x0600073B RID: 1851 RVA: 0x0000CBBC File Offset: 0x0000ADBC
		public event SDK.XBL.XblUserStatisticsStatisticChangedHandler XblUserStatisticsStatisticChanged
		{
			add
			{
				if (this.statisticChangedCallback == null)
				{
					this.statisiticsAddChangeId = XblInterop.XblUserStatisticsAddStatisticChangedHandler(base.Handle, new XblInterop.XblStatisticChangedHandler(XblContextHandle.XblUserStatisticsAddChangedCallback), GCHandle.ToIntPtr(this.m_gCHandle));
				}
				this.statisticChangedCallback = (SDK.XBL.XblUserStatisticsStatisticChangedHandler)Delegate.Combine(this.statisticChangedCallback, value);
			}
			remove
			{
				this.statisticChangedCallback = (SDK.XBL.XblUserStatisticsStatisticChangedHandler)Delegate.Remove(this.statisticChangedCallback, value);
				if (this.statisticChangedCallback == null)
				{
					XblInterop.XblUserStatisticsRemoveStatisticChangedHandler(base.Handle, GCHandle.ToIntPtr(this.m_gCHandle));
					this.statisiticsAddChangeId = default(XblFunctionContext);
				}
			}
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0000CC0A File Offset: 0x0000AE0A
		internal XblContextHandle(XblContextHandle interopHandle) : base(IntPtr.Zero, true, interopHandle.handle)
		{
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0000CC20 File Offset: 0x0000AE20
		protected override bool ReleaseHandle()
		{
			if (this.sessionChangedCallback != null)
			{
				foreach (Delegate @delegate in this.sessionChangedCallback.GetInvocationList())
				{
					this.sessionChangedCallback = (SDK.XBL.XblMultiplayerSessionChangedHandler)Delegate.Remove(this.sessionChangedCallback, (SDK.XBL.XblMultiplayerSessionChangedHandler)@delegate);
				}
			}
			if (this.sessionSubscriptionLostCallback != null)
			{
				foreach (Delegate delegate2 in this.sessionSubscriptionLostCallback.GetInvocationList())
				{
					this.sessionSubscriptionLostCallback = (SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler)Delegate.Remove(this.sessionSubscriptionLostCallback, (SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler)delegate2);
				}
			}
			if (this.connectionIdChangedCallback != null)
			{
				foreach (Delegate delegate3 in this.connectionIdChangedCallback.GetInvocationList())
				{
					this.connectionIdChangedCallback = (SDK.XBL.XblMultiplayerConnectionIdChangedHandler)Delegate.Remove(this.connectionIdChangedCallback, (SDK.XBL.XblMultiplayerConnectionIdChangedHandler)delegate3);
				}
			}
			if (this.statisticChangedCallback != null)
			{
				foreach (Delegate delegate4 in this.statisticChangedCallback.GetInvocationList())
				{
					this.statisticChangedCallback = (SDK.XBL.XblUserStatisticsStatisticChangedHandler)Delegate.Remove(this.statisticChangedCallback, (SDK.XBL.XblUserStatisticsStatisticChangedHandler)delegate4);
				}
			}
			GCHandle gCHandle = this.m_gCHandle;
			this.m_gCHandle.Free();
			XblInterop.XblContextCloseHandle(base.Handle);
			return true;
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x0000CD57 File Offset: 0x0000AF57
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}

		// Token: 0x0400042C RID: 1068
		internal GCHandle m_gCHandle;

		// Token: 0x0400042D RID: 1069
		internal SDK.XBL.XblMultiplayerSessionChangedHandler sessionChangedCallback;

		// Token: 0x0400042E RID: 1070
		internal XblFunctionContext sessionChangedHandlerId;

		// Token: 0x0400042F RID: 1071
		internal SDK.XBL.XblMultiplayerSessionSubscriptionLostHandler sessionSubscriptionLostCallback;

		// Token: 0x04000430 RID: 1072
		internal XblFunctionContext sessionSubscriptionLostId;

		// Token: 0x04000431 RID: 1073
		internal SDK.XBL.XblMultiplayerConnectionIdChangedHandler connectionIdChangedCallback;

		// Token: 0x04000432 RID: 1074
		internal XblFunctionContext connectionIdChangedId;

		// Token: 0x04000433 RID: 1075
		internal SDK.XBL.XblUserStatisticsStatisticChangedHandler statisticChangedCallback;

		// Token: 0x04000434 RID: 1076
		internal XblFunctionContext statisiticsAddChangeId;
	}
}
