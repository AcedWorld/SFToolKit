using System;

namespace Rewired.Utils
{
	// Token: 0x02000487 RID: 1159
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		// Token: 0x06002DD2 RID: 11730 RVA: 0x00023486 File Offset: 0x00021686
		public SafePredicate()
		{
		}

		// Token: 0x06002DD3 RID: 11731 RVA: 0x0002348E File Offset: 0x0002168E
		public SafePredicate(Action<Exception> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DD4 RID: 11732 RVA: 0x00023497 File Offset: 0x00021697
		protected SafePredicate(SafePredicate<T> A_1) : base(A_1)
		{
		}

		// Token: 0x06002DD5 RID: 11733 RVA: 0x000A08F4 File Offset: 0x0009EAF4
		public bool Invoke(T arg0)
		{
			this.MiQWDUUNvSeTNqyFTtKWOOPbAkWl = arg0;
			bool result;
			try
			{
				base.Invoke(SafePredicate<T>.invokeDelegate);
				result = this.QiWjQxEilGgQcHNPYhgtLzUtDEpXA;
			}
			catch
			{
				Logger.LogError("Error invoking SafeDelegate base class.");
				result = false;
			}
			finally
			{
				this.MiQWDUUNvSeTNqyFTtKWOOPbAkWl = default(T);
				this.QiWjQxEilGgQcHNPYhgtLzUtDEpXA = false;
			}
			return result;
		}

		// Token: 0x06002DD6 RID: 11734 RVA: 0x000234A0 File Offset: 0x000216A0
		public override object Clone()
		{
			return new SafePredicate<T>(this);
		}

		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x06002DD7 RID: 11735 RVA: 0x000234A8 File Offset: 0x000216A8
		private static Action<object, Predicate<T>> invokeDelegate
		{
			get
			{
				Action<object, Predicate<T>> result;
				if ((result = SafePredicate<T>.elZTLtlgSJEYTkpRmOaeOnoDATfn) == null)
				{
					result = (SafePredicate<T>.elZTLtlgSJEYTkpRmOaeOnoDATfn = new Action<object, Predicate<T>>(SafePredicate<T>.VisDqKsaGxdAoIcrFoEkEVbKgbwuA));
				}
				return result;
			}
		}

		// Token: 0x06002DD8 RID: 11736 RVA: 0x000A095C File Offset: 0x0009EB5C
		private static void VisDqKsaGxdAoIcrFoEkEVbKgbwuA(object A_0, Predicate<T> A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			SafePredicate<T> safePredicate = A_0 as SafePredicate<T>;
			if (safePredicate == null)
			{
				return;
			}
			safePredicate.QiWjQxEilGgQcHNPYhgtLzUtDEpXA = A_1(safePredicate.MiQWDUUNvSeTNqyFTtKWOOPbAkWl);
		}

		// Token: 0x06002DD9 RID: 11737 RVA: 0x000234C5 File Offset: 0x000216C5
		public static SafePredicate<T>operator +(SafePredicate<T> eventList, Predicate<T> predicate)
		{
			if (eventList == null)
			{
				eventList = new SafePredicate<T>();
			}
			eventList.AddDelegate(predicate);
			return eventList;
		}

		// Token: 0x06002DDA RID: 11738 RVA: 0x000234D9 File Offset: 0x000216D9
		public static SafePredicate<T>operator -(SafePredicate<T> eventList, Predicate<T> predicate)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(predicate);
			return eventList;
		}

		// Token: 0x06002DDB RID: 11739 RVA: 0x000234E8 File Offset: 0x000216E8
		public static implicit operator Predicate<T>(SafePredicate<T> obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		// Token: 0x06002DDC RID: 11740 RVA: 0x000234F5 File Offset: 0x000216F5
		public static implicit operator SafePredicate<T>(Predicate<T> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafePredicate<T> safePredicate = new SafePredicate<T>();
			safePredicate.AddDelegate(obj);
			return safePredicate;
		}

		// Token: 0x040019A4 RID: 6564
		private T MiQWDUUNvSeTNqyFTtKWOOPbAkWl;

		// Token: 0x040019A5 RID: 6565
		private bool QiWjQxEilGgQcHNPYhgtLzUtDEpXA;

		// Token: 0x040019A6 RID: 6566
		private static Action<object, Predicate<T>> elZTLtlgSJEYTkpRmOaeOnoDATfn;
	}
}
