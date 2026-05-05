using System;

namespace Rewired.Utils
{
	// Token: 0x02000484 RID: 1156
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction<T> : SafeDelegate<Action<T>>
	{
		// Token: 0x06002DB1 RID: 11697 RVA: 0x00023300 File Offset: 0x00021500
		public SafeAction()
		{
		}

		// Token: 0x06002DB2 RID: 11698 RVA: 0x00023308 File Offset: 0x00021508
		public SafeAction(Action<Exception> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DB3 RID: 11699 RVA: 0x00023311 File Offset: 0x00021511
		protected SafeAction(SafeAction<T> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DB4 RID: 11700 RVA: 0x000A0748 File Offset: 0x0009E948
		public void Invoke(T arg0)
		{
			this.hkbuDmqzGdoBozDhWWSoZHjTdADt = arg0;
			try
			{
				base.Invoke(SafeAction<T>.invokeDelegate);
			}
			catch
			{
				Logger.LogError("Error invoking SafeAction base class.");
			}
			this.hkbuDmqzGdoBozDhWWSoZHjTdADt = default(T);
		}

		// Token: 0x06002DB5 RID: 11701 RVA: 0x0002331A File Offset: 0x0002151A
		public override object Clone()
		{
			return new SafeAction<T>(this);
		}

		// Token: 0x17000AE7 RID: 2791
		// (get) Token: 0x06002DB6 RID: 11702 RVA: 0x00023322 File Offset: 0x00021522
		private static Action<object, Action<T>> invokeDelegate
		{
			get
			{
				Action<object, Action<T>> result;
				if ((result = SafeAction<T>.NkVtRLFCzhETXxNpJMDEMKxxflDgA) == null)
				{
					result = (SafeAction<T>.NkVtRLFCzhETXxNpJMDEMKxxflDgA = new Action<object, Action<T>>(SafeAction<T>.VRgRHlmsATdQaRKPCmKuErHnFqVG));
				}
				return result;
			}
		}

		// Token: 0x06002DB7 RID: 11703 RVA: 0x000A0794 File Offset: 0x0009E994
		private static void VRgRHlmsATdQaRKPCmKuErHnFqVG(object A_0, Action<T> A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			SafeAction<T> safeAction = A_0 as SafeAction<T>;
			if (safeAction == null)
			{
				return;
			}
			A_1(safeAction.hkbuDmqzGdoBozDhWWSoZHjTdADt);
		}

		// Token: 0x06002DB8 RID: 11704 RVA: 0x0002333F File Offset: 0x0002153F
		public static SafeAction<T>operator +(SafeAction<T> eventList, Action<T> listener)
		{
			if (eventList == null)
			{
				eventList = new SafeAction<T>();
			}
			eventList.AddDelegate(listener);
			return eventList;
		}

		// Token: 0x06002DB9 RID: 11705 RVA: 0x00023353 File Offset: 0x00021553
		public static SafeAction<T>operator -(SafeAction<T> eventList, Action<T> listener)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(listener);
			return eventList;
		}

		// Token: 0x06002DBA RID: 11706 RVA: 0x00023362 File Offset: 0x00021562
		public static implicit operator Action<T>(SafeAction<T> obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		// Token: 0x06002DBB RID: 11707 RVA: 0x0002336F File Offset: 0x0002156F
		public static implicit operator SafeAction<T>(Action<T> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeAction<T> safeAction = new SafeAction<T>();
			safeAction.AddDelegate(obj);
			return safeAction;
		}

		// Token: 0x0400199C RID: 6556
		private T hkbuDmqzGdoBozDhWWSoZHjTdADt;

		// Token: 0x0400199D RID: 6557
		private static Action<object, Action<T>> NkVtRLFCzhETXxNpJMDEMKxxflDgA;
	}
}
