using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

// Token: 0x02000479 RID: 1145
internal static class XrIMSkNxqAoGxuGHleqpKZoRJxbk
{
	// Token: 0x06002D78 RID: 11640 RVA: 0x0009FE20 File Offset: 0x0009E020
	public static void yoKRVoLfhjjbLpTVtWjsmMDIZEhs<\u0001, \u0002>(\u0001 A_0, \u0002 A_1, XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<\u0001, \u0002> A_2) where \u0001 : class
	{
		if (A_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (A_0 == null)
		{
			throw new ArgumentNullException("handler");
		}
		try
		{
			A_2(A_0, A_1);
		}
		catch (Exception ex)
		{
			string str = "Caught exception in event handler:\n";
			Exception ex2 = ex;
			Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
		}
	}

	// Token: 0x06002D79 RID: 11641 RVA: 0x0009FE88 File Offset: 0x0009E088
	public static void CYVvcDEQZQzsGMCwiVexbZbpZlwH<\u0001, \u0002>(IList<\u0001> A_0, \u0002 A_1, XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<\u0001, \u0002> A_2) where \u0001 : class
	{
		if (A_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (A_0 == null)
		{
			throw new ArgumentNullException("handlers");
		}
		int count = A_0.Count;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = A_0[i];
			if (u != null)
			{
				try
				{
					A_2(u, A_1);
				}
				catch (Exception ex)
				{
					string str = "Caught exception in event handler:\n";
					Exception ex2 = ex;
					Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
				}
			}
		}
	}

	// Token: 0x06002D7A RID: 11642 RVA: 0x0009FF10 File Offset: 0x0009E110
	public static void irjAxTccoJrvMOaJsezhzbhSTQAE<\u0001, \u0002>(IList<\u0001> A_0, \u0002 A_1, XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<\u0001, \u0002> A_2, bool A_3) where \u0001 : class
	{
		if (A_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (A_0 == null)
		{
			throw new ArgumentNullException("handlers");
		}
		int num = A_0.Count;
		for (int i = 0; i < num; i++)
		{
			\u0001 u = A_0[i];
			if (u as Component == null)
			{
				if (A_3)
				{
					A_0.RemoveAt(i);
					i--;
					num--;
				}
			}
			else
			{
				try
				{
					A_2(u, A_1);
				}
				catch (Exception ex)
				{
					string str = "Caught exception in event handler:\n";
					Exception ex2 = ex;
					Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
				}
			}
		}
	}

	// Token: 0x0200047A RID: 1146
	// (Invoke) Token: 0x06002D7C RID: 11644
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	// Token: 0x0200047B RID: 1147
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		// Token: 0x06002D7F RID: 11647 RVA: 0x0002310C File Offset: 0x0002130C
		public HierarchyEventHelper(XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<THandler, TValue> A_1) : this(A_1, XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.Self | XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.Children)
		{
		}

		// Token: 0x06002D80 RID: 11648 RVA: 0x00023116 File Offset: 0x00021316
		public HierarchyEventHelper(XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<THandler, TValue> A_1, XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("delegate");
			}
			this.bcFgtByNurxZZtqwoCqWdDDWfLgI = A_1;
			this.cqMvamvCNXXTJXrbLiuxuupOpKlC = new List<THandler>();
			this.hIqlEZKaIqNwDUfOWzkSUzCnBRPQ = A_2;
		}

		// Token: 0x06002D81 RID: 11649 RVA: 0x00023145 File Offset: 0x00021345
		public void ExecuteOnAll(TValue value)
		{
			XrIMSkNxqAoGxuGHleqpKZoRJxbk.irjAxTccoJrvMOaJsezhzbhSTQAE<THandler, TValue>(this.cqMvamvCNXXTJXrbLiuxuupOpKlC, value, this.bcFgtByNurxZZtqwoCqWdDDWfLgI, true);
		}

		// Token: 0x06002D82 RID: 11650 RVA: 0x0009FFB8 File Offset: 0x0009E1B8
		public void GetHandlers(Transform transform)
		{
			if ((this.hIqlEZKaIqNwDUfOWzkSUzCnBRPQ & XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.Self) != XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.None && (this.hIqlEZKaIqNwDUfOWzkSUzCnBRPQ & XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.Children) != XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.None && (this.hIqlEZKaIqNwDUfOWzkSUzCnBRPQ & XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.Parents) != XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.None)
			{
				UnityTools.GetComponentsInSelfAndChildren<THandler>(transform.root, this.cqMvamvCNXXTJXrbLiuxuupOpKlC, false);
				return;
			}
			if ((this.hIqlEZKaIqNwDUfOWzkSUzCnBRPQ & XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.Children) != XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.None)
			{
				if ((this.hIqlEZKaIqNwDUfOWzkSUzCnBRPQ & XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.Self) != XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.None)
				{
					UnityTools.GetComponentsInSelfAndChildren<THandler>(transform, this.cqMvamvCNXXTJXrbLiuxuupOpKlC, true);
				}
				else
				{
					UnityTools.GetComponents<THandler>(transform, this.cqMvamvCNXXTJXrbLiuxuupOpKlC, true);
				}
			}
			if ((this.hIqlEZKaIqNwDUfOWzkSUzCnBRPQ & XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.Parents) != XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB.None)
			{
				UnityTools.GetComponentsInParents<THandler>(transform, this.cqMvamvCNXXTJXrbLiuxuupOpKlC, true);
			}
		}

		// Token: 0x04001987 RID: 6535
		private readonly XrIMSkNxqAoGxuGHleqpKZoRJxbk.EventFunction<THandler, TValue> bcFgtByNurxZZtqwoCqWdDDWfLgI;

		// Token: 0x04001988 RID: 6536
		private readonly List<THandler> cqMvamvCNXXTJXrbLiuxuupOpKlC;

		// Token: 0x04001989 RID: 6537
		private readonly XrIMSkNxqAoGxuGHleqpKZoRJxbk.HierarchyEventHelper<THandler, TValue>.JYJEwlfLngAfvcKVHiyTMNbrmXsTB hIqlEZKaIqNwDUfOWzkSUzCnBRPQ;

		// Token: 0x0200047C RID: 1148
		[Flags]
		public enum JYJEwlfLngAfvcKVHiyTMNbrmXsTB
		{
			// Token: 0x0400198B RID: 6539
			None = 0,
			// Token: 0x0400198C RID: 6540
			Self = 1,
			// Token: 0x0400198D RID: 6541
			Children = 4,
			// Token: 0x0400198E RID: 6542
			Parents = 8,
			// Token: 0x0400198F RID: 6543
			All = -1
		}
	}
}
