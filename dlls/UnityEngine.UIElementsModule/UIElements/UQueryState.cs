using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200038D RID: 909
	public struct UQueryState<T> : IEnumerable<T>, IEnumerable, IEquatable<UQueryState<T>> where T : VisualElement
	{
		// Token: 0x06001E85 RID: 7813 RVA: 0x00075A84 File Offset: 0x00073C84
		internal UQueryState(VisualElement element, List<RuleMatcher> matchers)
		{
			this.m_Element = element;
			this.m_Matchers = matchers;
		}

		// Token: 0x06001E86 RID: 7814 RVA: 0x00075A98 File Offset: 0x00073C98
		public UQueryState<T> RebuildOn(VisualElement element)
		{
			return new UQueryState<T>(element, this.m_Matchers);
		}

		// Token: 0x06001E87 RID: 7815 RVA: 0x00075AB8 File Offset: 0x00073CB8
		private T Single(UQuery.SingleQueryMatcher matcher)
		{
			bool flag = matcher.IsInUse();
			if (flag)
			{
				matcher = matcher.CreateNew();
			}
			matcher.Run(this.m_Element, this.m_Matchers);
			T result = matcher.match as T;
			matcher.match = null;
			return result;
		}

		// Token: 0x06001E88 RID: 7816 RVA: 0x00075B0B File Offset: 0x00073D0B
		public T First()
		{
			return this.Single(UQuery.FirstQueryMatcher.Instance);
		}

		// Token: 0x06001E89 RID: 7817 RVA: 0x00075B18 File Offset: 0x00073D18
		public T Last()
		{
			return this.Single(UQuery.LastQueryMatcher.Instance);
		}

		// Token: 0x06001E8A RID: 7818 RVA: 0x00075B25 File Offset: 0x00073D25
		public void ToList(List<T> results)
		{
			UQueryState<T>.s_List.matches = results;
			UQueryState<T>.s_List.Run(this.m_Element, this.m_Matchers);
			UQueryState<T>.s_List.Reset();
		}

		// Token: 0x06001E8B RID: 7819 RVA: 0x00075B58 File Offset: 0x00073D58
		public List<T> ToList()
		{
			List<T> list = new List<T>();
			this.ToList(list);
			return list;
		}

		// Token: 0x06001E8C RID: 7820 RVA: 0x00075B7C File Offset: 0x00073D7C
		public T AtIndex(int index)
		{
			UQuery.IndexQueryMatcher instance = UQuery.IndexQueryMatcher.Instance;
			instance.matchIndex = index;
			return this.Single(instance);
		}

		// Token: 0x06001E8D RID: 7821 RVA: 0x00075BA4 File Offset: 0x00073DA4
		public void ForEach(Action<T> funcCall)
		{
			UQueryState<T>.ActionQueryMatcher actionQueryMatcher = UQueryState<T>.s_Action;
			bool flag = actionQueryMatcher.callBack != null;
			if (flag)
			{
				actionQueryMatcher = new UQueryState<T>.ActionQueryMatcher();
			}
			try
			{
				actionQueryMatcher.callBack = funcCall;
				actionQueryMatcher.Run(this.m_Element, this.m_Matchers);
			}
			finally
			{
				actionQueryMatcher.callBack = null;
			}
		}

		// Token: 0x06001E8E RID: 7822 RVA: 0x00075C08 File Offset: 0x00073E08
		public void ForEach<T2>(List<T2> result, Func<T, T2> funcCall)
		{
			UQueryState<T>.DelegateQueryMatcher<T2> delegateQueryMatcher = UQueryState<T>.DelegateQueryMatcher<T2>.s_Instance;
			bool flag = delegateQueryMatcher.callBack != null;
			if (flag)
			{
				delegateQueryMatcher = new UQueryState<T>.DelegateQueryMatcher<T2>();
			}
			try
			{
				delegateQueryMatcher.callBack = funcCall;
				delegateQueryMatcher.result = result;
				delegateQueryMatcher.Run(this.m_Element, this.m_Matchers);
			}
			finally
			{
				delegateQueryMatcher.callBack = null;
				delegateQueryMatcher.result = null;
			}
		}

		// Token: 0x06001E8F RID: 7823 RVA: 0x00075C7C File Offset: 0x00073E7C
		public List<T2> ForEach<T2>(Func<T, T2> funcCall)
		{
			List<T2> result = new List<T2>();
			this.ForEach<T2>(result, funcCall);
			return result;
		}

		// Token: 0x06001E90 RID: 7824 RVA: 0x00075C9E File Offset: 0x00073E9E
		public UQueryState<T>.Enumerator GetEnumerator()
		{
			return new UQueryState<T>.Enumerator(this);
		}

		// Token: 0x06001E91 RID: 7825 RVA: 0x00075CAB File Offset: 0x00073EAB
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06001E92 RID: 7826 RVA: 0x00075CAB File Offset: 0x00073EAB
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06001E93 RID: 7827 RVA: 0x00075CB8 File Offset: 0x00073EB8
		public bool Equals(UQueryState<T> other)
		{
			return this.m_Element == other.m_Element && EqualityComparer<List<RuleMatcher>>.Default.Equals(this.m_Matchers, other.m_Matchers);
		}

		// Token: 0x06001E94 RID: 7828 RVA: 0x00075CF4 File Offset: 0x00073EF4
		public override bool Equals(object obj)
		{
			bool flag = !(obj is UQueryState<T>);
			return !flag && this.Equals((UQueryState<T>)obj);
		}

		// Token: 0x06001E95 RID: 7829 RVA: 0x00075D28 File Offset: 0x00073F28
		public override int GetHashCode()
		{
			int num = 488160421;
			num = num * -1521134295 + EqualityComparer<VisualElement>.Default.GetHashCode(this.m_Element);
			return num * -1521134295 + EqualityComparer<List<RuleMatcher>>.Default.GetHashCode(this.m_Matchers);
		}

		// Token: 0x06001E96 RID: 7830 RVA: 0x00075D74 File Offset: 0x00073F74
		public static bool operator ==(UQueryState<T> state1, UQueryState<T> state2)
		{
			return state1.Equals(state2);
		}

		// Token: 0x06001E97 RID: 7831 RVA: 0x00075D90 File Offset: 0x00073F90
		public static bool operator !=(UQueryState<T> state1, UQueryState<T> state2)
		{
			return !(state1 == state2);
		}

		// Token: 0x04000CAC RID: 3244
		private static UQueryState<T>.ActionQueryMatcher s_Action = new UQueryState<T>.ActionQueryMatcher();

		// Token: 0x04000CAD RID: 3245
		private readonly VisualElement m_Element;

		// Token: 0x04000CAE RID: 3246
		internal readonly List<RuleMatcher> m_Matchers;

		// Token: 0x04000CAF RID: 3247
		private static readonly UQueryState<T>.ListQueryMatcher<T> s_List = new UQueryState<T>.ListQueryMatcher<T>();

		// Token: 0x04000CB0 RID: 3248
		private static readonly UQueryState<T>.ListQueryMatcher<VisualElement> s_EnumerationList = new UQueryState<T>.ListQueryMatcher<VisualElement>();

		// Token: 0x0200038E RID: 910
		private class ListQueryMatcher<TElement> : UQuery.UQueryMatcher where TElement : VisualElement
		{
			// Token: 0x17000716 RID: 1814
			// (get) Token: 0x06001E99 RID: 7833 RVA: 0x00075DCC File Offset: 0x00073FCC
			// (set) Token: 0x06001E9A RID: 7834 RVA: 0x00075DD4 File Offset: 0x00073FD4
			public List<TElement> matches { get; set; }

			// Token: 0x06001E9B RID: 7835 RVA: 0x00075DE0 File Offset: 0x00073FE0
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element)
			{
				this.matches.Add(element as TElement);
				return false;
			}

			// Token: 0x06001E9C RID: 7836 RVA: 0x00075E0A File Offset: 0x0007400A
			public void Reset()
			{
				this.matches = null;
			}
		}

		// Token: 0x0200038F RID: 911
		private class ActionQueryMatcher : UQuery.UQueryMatcher
		{
			// Token: 0x17000717 RID: 1815
			// (get) Token: 0x06001E9E RID: 7838 RVA: 0x00075E15 File Offset: 0x00074015
			// (set) Token: 0x06001E9F RID: 7839 RVA: 0x00075E1D File Offset: 0x0007401D
			internal Action<T> callBack { get; set; }

			// Token: 0x06001EA0 RID: 7840 RVA: 0x00075E28 File Offset: 0x00074028
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element)
			{
				T t = element as T;
				bool flag = t != null;
				if (flag)
				{
					this.callBack(t);
				}
				return false;
			}
		}

		// Token: 0x02000390 RID: 912
		private class DelegateQueryMatcher<TReturnType> : UQuery.UQueryMatcher
		{
			// Token: 0x17000718 RID: 1816
			// (get) Token: 0x06001EA2 RID: 7842 RVA: 0x00075E63 File Offset: 0x00074063
			// (set) Token: 0x06001EA3 RID: 7843 RVA: 0x00075E6B File Offset: 0x0007406B
			public Func<T, TReturnType> callBack { get; set; }

			// Token: 0x17000719 RID: 1817
			// (get) Token: 0x06001EA4 RID: 7844 RVA: 0x00075E74 File Offset: 0x00074074
			// (set) Token: 0x06001EA5 RID: 7845 RVA: 0x00075E7C File Offset: 0x0007407C
			public List<TReturnType> result { get; set; }

			// Token: 0x06001EA6 RID: 7846 RVA: 0x00075E88 File Offset: 0x00074088
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element)
			{
				T t = element as T;
				bool flag = t != null;
				if (flag)
				{
					this.result.Add(this.callBack(t));
				}
				return false;
			}

			// Token: 0x04000CB5 RID: 3253
			public static UQueryState<T>.DelegateQueryMatcher<TReturnType> s_Instance = new UQueryState<T>.DelegateQueryMatcher<TReturnType>();
		}

		// Token: 0x02000391 RID: 913
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x06001EA9 RID: 7849 RVA: 0x00075EDC File Offset: 0x000740DC
			internal Enumerator(UQueryState<T> queryState)
			{
				this.iterationList = VisualElementListPool.Get(0);
				UQueryState<T>.s_EnumerationList.matches = this.iterationList;
				UQueryState<T>.s_EnumerationList.Run(queryState.m_Element, queryState.m_Matchers);
				UQueryState<T>.s_EnumerationList.Reset();
				this.currentIndex = -1;
			}

			// Token: 0x1700071A RID: 1818
			// (get) Token: 0x06001EAA RID: 7850 RVA: 0x00075F30 File Offset: 0x00074130
			public T Current
			{
				get
				{
					return (T)((object)this.iterationList[this.currentIndex]);
				}
			}

			// Token: 0x1700071B RID: 1819
			// (get) Token: 0x06001EAB RID: 7851 RVA: 0x00075F48 File Offset: 0x00074148
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06001EAC RID: 7852 RVA: 0x00075F58 File Offset: 0x00074158
			public bool MoveNext()
			{
				int num = this.currentIndex + 1;
				this.currentIndex = num;
				return num < this.iterationList.Count;
			}

			// Token: 0x06001EAD RID: 7853 RVA: 0x00075F88 File Offset: 0x00074188
			public void Reset()
			{
				this.currentIndex = -1;
			}

			// Token: 0x06001EAE RID: 7854 RVA: 0x00075F92 File Offset: 0x00074192
			public void Dispose()
			{
				VisualElementListPool.Release(this.iterationList);
				this.iterationList = null;
			}

			// Token: 0x04000CB6 RID: 3254
			private List<VisualElement> iterationList;

			// Token: 0x04000CB7 RID: 3255
			private int currentIndex;
		}
	}
}
