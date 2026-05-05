using System;
using System.Collections.Generic;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x02000383 RID: 899
	public static class UQuery
	{
		// Token: 0x02000384 RID: 900
		internal interface IVisualPredicateWrapper
		{
			// Token: 0x06001E61 RID: 7777
			bool Predicate(object e);
		}

		// Token: 0x02000385 RID: 901
		internal class IsOfType<T> : UQuery.IVisualPredicateWrapper where T : VisualElement
		{
			// Token: 0x06001E62 RID: 7778 RVA: 0x00075788 File Offset: 0x00073988
			public bool Predicate(object e)
			{
				return e is T;
			}

			// Token: 0x04000CA1 RID: 3233
			public static UQuery.IsOfType<T> s_Instance = new UQuery.IsOfType<T>();
		}

		// Token: 0x02000386 RID: 902
		internal class PredicateWrapper<T> : UQuery.IVisualPredicateWrapper where T : VisualElement
		{
			// Token: 0x06001E65 RID: 7781 RVA: 0x000757AF File Offset: 0x000739AF
			public PredicateWrapper(Func<T, bool> p)
			{
				this.predicate = p;
			}

			// Token: 0x06001E66 RID: 7782 RVA: 0x000757C0 File Offset: 0x000739C0
			public bool Predicate(object e)
			{
				T t = e as T;
				bool flag = t != null;
				return flag && this.predicate(t);
			}

			// Token: 0x04000CA2 RID: 3234
			private Func<T, bool> predicate;
		}

		// Token: 0x02000387 RID: 903
		internal abstract class UQueryMatcher : HierarchyTraversal
		{
			// Token: 0x06001E68 RID: 7784 RVA: 0x00075806 File Offset: 0x00073A06
			public override void Traverse(VisualElement element)
			{
				base.Traverse(element);
			}

			// Token: 0x06001E69 RID: 7785 RVA: 0x00075814 File Offset: 0x00073A14
			protected virtual bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element)
			{
				return false;
			}

			// Token: 0x06001E6A RID: 7786 RVA: 0x00003CD2 File Offset: 0x00001ED2
			private static void NoProcessResult(VisualElement e, MatchResultInfo i)
			{
			}

			// Token: 0x06001E6B RID: 7787 RVA: 0x00075828 File Offset: 0x00073A28
			public override void TraverseRecursive(VisualElement element, int depth)
			{
				int count = this.m_Matchers.Count;
				int count2 = this.m_Matchers.Count;
				for (int j = 0; j < count2; j++)
				{
					RuleMatcher ruleMatcher = this.m_Matchers[j];
					bool flag = StyleSelectorHelper.MatchRightToLeft(element, ruleMatcher.complexSelector, delegate(VisualElement e, MatchResultInfo i)
					{
						UQuery.UQueryMatcher.NoProcessResult(e, i);
					});
					if (flag)
					{
						bool flag2 = this.OnRuleMatchedElement(ruleMatcher, element);
						if (flag2)
						{
							return;
						}
					}
				}
				base.Recurse(element, depth);
				bool flag3 = this.m_Matchers.Count > count;
				if (flag3)
				{
					this.m_Matchers.RemoveRange(count, this.m_Matchers.Count - count);
					return;
				}
			}

			// Token: 0x06001E6C RID: 7788 RVA: 0x000758EC File Offset: 0x00073AEC
			public virtual void Run(VisualElement root, List<RuleMatcher> matchers)
			{
				this.m_Matchers = matchers;
				this.Traverse(root);
			}

			// Token: 0x04000CA3 RID: 3235
			internal List<RuleMatcher> m_Matchers;
		}

		// Token: 0x02000389 RID: 905
		internal abstract class SingleQueryMatcher : UQuery.UQueryMatcher
		{
			// Token: 0x17000714 RID: 1812
			// (get) Token: 0x06001E70 RID: 7792 RVA: 0x00075914 File Offset: 0x00073B14
			// (set) Token: 0x06001E71 RID: 7793 RVA: 0x0007591C File Offset: 0x00073B1C
			public VisualElement match { get; set; }

			// Token: 0x06001E72 RID: 7794 RVA: 0x00075925 File Offset: 0x00073B25
			public override void Run(VisualElement root, List<RuleMatcher> matchers)
			{
				this.match = null;
				base.Run(root, matchers);
				this.m_Matchers = null;
			}

			// Token: 0x06001E73 RID: 7795 RVA: 0x00075940 File Offset: 0x00073B40
			public bool IsInUse()
			{
				return this.m_Matchers != null;
			}

			// Token: 0x06001E74 RID: 7796
			public abstract UQuery.SingleQueryMatcher CreateNew();
		}

		// Token: 0x0200038A RID: 906
		internal class FirstQueryMatcher : UQuery.SingleQueryMatcher
		{
			// Token: 0x06001E76 RID: 7798 RVA: 0x00075964 File Offset: 0x00073B64
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element)
			{
				bool flag = base.match == null;
				if (flag)
				{
					base.match = element;
				}
				return true;
			}

			// Token: 0x06001E77 RID: 7799 RVA: 0x0007598C File Offset: 0x00073B8C
			public override UQuery.SingleQueryMatcher CreateNew()
			{
				return new UQuery.FirstQueryMatcher();
			}

			// Token: 0x04000CA7 RID: 3239
			public static readonly UQuery.FirstQueryMatcher Instance = new UQuery.FirstQueryMatcher();
		}

		// Token: 0x0200038B RID: 907
		internal class LastQueryMatcher : UQuery.SingleQueryMatcher
		{
			// Token: 0x06001E7A RID: 7802 RVA: 0x000759A8 File Offset: 0x00073BA8
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element)
			{
				base.match = element;
				return false;
			}

			// Token: 0x06001E7B RID: 7803 RVA: 0x000759C3 File Offset: 0x00073BC3
			public override UQuery.SingleQueryMatcher CreateNew()
			{
				return new UQuery.LastQueryMatcher();
			}

			// Token: 0x04000CA8 RID: 3240
			public static readonly UQuery.LastQueryMatcher Instance = new UQuery.LastQueryMatcher();
		}

		// Token: 0x0200038C RID: 908
		internal class IndexQueryMatcher : UQuery.SingleQueryMatcher
		{
			// Token: 0x17000715 RID: 1813
			// (get) Token: 0x06001E7E RID: 7806 RVA: 0x000759D8 File Offset: 0x00073BD8
			// (set) Token: 0x06001E7F RID: 7807 RVA: 0x000759F0 File Offset: 0x00073BF0
			public int matchIndex
			{
				get
				{
					return this._matchIndex;
				}
				set
				{
					this.matchCount = -1;
					this._matchIndex = value;
				}
			}

			// Token: 0x06001E80 RID: 7808 RVA: 0x00075A01 File Offset: 0x00073C01
			public override void Run(VisualElement root, List<RuleMatcher> matchers)
			{
				this.matchCount = -1;
				base.Run(root, matchers);
			}

			// Token: 0x06001E81 RID: 7809 RVA: 0x00075A14 File Offset: 0x00073C14
			protected override bool OnRuleMatchedElement(RuleMatcher matcher, VisualElement element)
			{
				this.matchCount++;
				bool flag = this.matchCount == this._matchIndex;
				if (flag)
				{
					base.match = element;
				}
				return this.matchCount >= this._matchIndex;
			}

			// Token: 0x06001E82 RID: 7810 RVA: 0x00075A61 File Offset: 0x00073C61
			public override UQuery.SingleQueryMatcher CreateNew()
			{
				return new UQuery.IndexQueryMatcher();
			}

			// Token: 0x04000CA9 RID: 3241
			public static readonly UQuery.IndexQueryMatcher Instance = new UQuery.IndexQueryMatcher();

			// Token: 0x04000CAA RID: 3242
			private int matchCount = -1;

			// Token: 0x04000CAB RID: 3243
			private int _matchIndex;
		}
	}
}
