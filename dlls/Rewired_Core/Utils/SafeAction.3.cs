using System;

namespace Rewired.Utils
{
	// Token: 0x02000485 RID: 1157
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction<T, T2> : SafeDelegate<Action<T, T2>>
	{
		// Token: 0x06002DBC RID: 11708 RVA: 0x00023382 File Offset: 0x00021582
		public SafeAction()
		{
		}

		// Token: 0x06002DBD RID: 11709 RVA: 0x0002338A File Offset: 0x0002158A
		public SafeAction(Action<Exception> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DBE RID: 11710 RVA: 0x00023393 File Offset: 0x00021593
		protected SafeAction(SafeAction<T, T2> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DBF RID: 11711 RVA: 0x000A07BC File Offset: 0x0009E9BC
		public void Invoke(T arg0, T2 arg1)
		{
			this.hEyeSlkbIymAAShgKbtBeLoicUQnA = arg0;
			this.EoyuGARBQkwIDUiKSWxMUaAEGTJcA = arg1;
			try
			{
				base.Invoke(SafeAction<T, T2>.invokeDelegate);
			}
			catch
			{
				Logger.LogError("Error invoking SafeAction base class.");
			}
			this.hEyeSlkbIymAAShgKbtBeLoicUQnA = default(T);
			this.EoyuGARBQkwIDUiKSWxMUaAEGTJcA = default(T2);
		}

		// Token: 0x06002DC0 RID: 11712 RVA: 0x0002339C File Offset: 0x0002159C
		public override object Clone()
		{
			return new SafeAction<T, T2>(this);
		}

		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x06002DC1 RID: 11713 RVA: 0x000233A4 File Offset: 0x000215A4
		private static Action<object, Action<T, T2>> invokeDelegate
		{
			get
			{
				Action<object, Action<T, T2>> result;
				if ((result = SafeAction<T, T2>.TooMyaSUhrOHOGJdACnKXwvHnIQx) == null)
				{
					result = (SafeAction<T, T2>.TooMyaSUhrOHOGJdACnKXwvHnIQx = new Action<object, Action<T, T2>>(SafeAction<T, T2>.kNGdbJnOHSzBqFpUJPmNYjcVZDXV));
				}
				return result;
			}
		}

		// Token: 0x06002DC2 RID: 11714 RVA: 0x000A081C File Offset: 0x0009EA1C
		private static void kNGdbJnOHSzBqFpUJPmNYjcVZDXV(object A_0, Action<T, T2> A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			SafeAction<T, T2> safeAction = A_0 as SafeAction<T, T2>;
			if (safeAction == null)
			{
				return;
			}
			A_1(safeAction.hEyeSlkbIymAAShgKbtBeLoicUQnA, safeAction.EoyuGARBQkwIDUiKSWxMUaAEGTJcA);
		}

		// Token: 0x06002DC3 RID: 11715 RVA: 0x000233C1 File Offset: 0x000215C1
		public static SafeAction<T, T2>operator +(SafeAction<T, T2> eventList, Action<T, T2> listener)
		{
			if (eventList == null)
			{
				eventList = new SafeAction<T, T2>();
			}
			eventList.AddDelegate(listener);
			return eventList;
		}

		// Token: 0x06002DC4 RID: 11716 RVA: 0x000233D5 File Offset: 0x000215D5
		public static SafeAction<T, T2>operator -(SafeAction<T, T2> eventList, Action<T, T2> listener)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(listener);
			return eventList;
		}

		// Token: 0x06002DC5 RID: 11717 RVA: 0x000233E4 File Offset: 0x000215E4
		public static implicit operator Action<T, T2>(SafeAction<T, T2> obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		// Token: 0x06002DC6 RID: 11718 RVA: 0x000233F1 File Offset: 0x000215F1
		public static implicit operator SafeAction<T, T2>(Action<T, T2> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeAction<T, T2> safeAction = new SafeAction<T, T2>();
			safeAction.AddDelegate(obj);
			return safeAction;
		}

		// Token: 0x0400199E RID: 6558
		private T hEyeSlkbIymAAShgKbtBeLoicUQnA;

		// Token: 0x0400199F RID: 6559
		private T2 EoyuGARBQkwIDUiKSWxMUaAEGTJcA;

		// Token: 0x040019A0 RID: 6560
		private static Action<object, Action<T, T2>> TooMyaSUhrOHOGJdACnKXwvHnIQx;
	}
}
