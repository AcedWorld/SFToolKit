using System;

namespace Rewired.Utils
{
	// Token: 0x02000486 RID: 1158
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafeFunc<T, TResult> : SafeDelegate<Func<T, TResult>>
	{
		// Token: 0x06002DC7 RID: 11719 RVA: 0x00023404 File Offset: 0x00021604
		public SafeFunc()
		{
		}

		// Token: 0x06002DC8 RID: 11720 RVA: 0x0002340C File Offset: 0x0002160C
		public SafeFunc(Action<Exception> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DC9 RID: 11721 RVA: 0x00023415 File Offset: 0x00021615
		protected SafeFunc(SafeFunc<T, TResult> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DCA RID: 11722 RVA: 0x000A084C File Offset: 0x0009EA4C
		public TResult Invoke(T arg0)
		{
			this.azApWZZsUUhpDaIPxfzGiNaHGZctA = arg0;
			TResult result;
			try
			{
				base.Invoke(SafeFunc<T, TResult>.invokeDelegate);
				result = this.yevpxIKcaMgfgcYfqIlBTUwEiPpHA;
			}
			catch
			{
				Logger.LogError("Error invoking SafeFunc base class.");
				result = default(TResult);
			}
			finally
			{
				this.azApWZZsUUhpDaIPxfzGiNaHGZctA = default(T);
				this.yevpxIKcaMgfgcYfqIlBTUwEiPpHA = default(TResult);
			}
			return result;
		}

		// Token: 0x06002DCB RID: 11723 RVA: 0x0002341E File Offset: 0x0002161E
		public override object Clone()
		{
			return new SafeFunc<T, TResult>(this);
		}

		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x06002DCC RID: 11724 RVA: 0x00023426 File Offset: 0x00021626
		private static Action<object, Func<T, TResult>> invokeDelegate
		{
			get
			{
				Action<object, Func<T, TResult>> result;
				if ((result = SafeFunc<T, TResult>.meRkIgcqFaCsHRMwpCcQtJVLdQaT) == null)
				{
					result = (SafeFunc<T, TResult>.meRkIgcqFaCsHRMwpCcQtJVLdQaT = new Action<object, Func<T, TResult>>(SafeFunc<T, TResult>.uAChixGlajpkdOHoHBbQsNzkGzep));
				}
				return result;
			}
		}

		// Token: 0x06002DCD RID: 11725 RVA: 0x000A08C4 File Offset: 0x0009EAC4
		private static void uAChixGlajpkdOHoHBbQsNzkGzep(object A_0, Func<T, TResult> A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			SafeFunc<T, TResult> safeFunc = A_0 as SafeFunc<T, TResult>;
			if (safeFunc == null)
			{
				return;
			}
			safeFunc.yevpxIKcaMgfgcYfqIlBTUwEiPpHA = A_1(safeFunc.azApWZZsUUhpDaIPxfzGiNaHGZctA);
		}

		// Token: 0x06002DCE RID: 11726 RVA: 0x00023443 File Offset: 0x00021643
		public static SafeFunc<T, TResult>operator +(SafeFunc<T, TResult> eventList, Func<T, TResult> func)
		{
			if (eventList == null)
			{
				eventList = new SafeFunc<T, TResult>();
			}
			eventList.AddDelegate(func);
			return eventList;
		}

		// Token: 0x06002DCF RID: 11727 RVA: 0x00023457 File Offset: 0x00021657
		public static SafeFunc<T, TResult>operator -(SafeFunc<T, TResult> eventList, Func<T, TResult> func)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(func);
			return eventList;
		}

		// Token: 0x06002DD0 RID: 11728 RVA: 0x00023466 File Offset: 0x00021666
		public static implicit operator Func<T, TResult>(SafeFunc<T, TResult> obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		// Token: 0x06002DD1 RID: 11729 RVA: 0x00023473 File Offset: 0x00021673
		public static implicit operator SafeFunc<T, TResult>(Func<T, TResult> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeFunc<T, TResult> safeFunc = new SafeFunc<T, TResult>();
			safeFunc.AddDelegate(obj);
			return safeFunc;
		}

		// Token: 0x040019A1 RID: 6561
		private T azApWZZsUUhpDaIPxfzGiNaHGZctA;

		// Token: 0x040019A2 RID: 6562
		private TResult yevpxIKcaMgfgcYfqIlBTUwEiPpHA;

		// Token: 0x040019A3 RID: 6563
		private static Action<object, Func<T, TResult>> meRkIgcqFaCsHRMwpCcQtJVLdQaT;
	}
}
