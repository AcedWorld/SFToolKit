using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000392 RID: 914
	public struct UQueryBuilder<T> : IEquatable<UQueryBuilder<T>> where T : VisualElement
	{
		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x06001EAF RID: 7855 RVA: 0x00075FA8 File Offset: 0x000741A8
		private List<StyleSelector> styleSelectors
		{
			get
			{
				List<StyleSelector> result;
				if ((result = this.m_StyleSelectors) == null)
				{
					result = (this.m_StyleSelectors = new List<StyleSelector>());
				}
				return result;
			}
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x06001EB0 RID: 7856 RVA: 0x00075FD4 File Offset: 0x000741D4
		private List<StyleSelectorPart> parts
		{
			get
			{
				List<StyleSelectorPart> result;
				if ((result = this.m_Parts) == null)
				{
					result = (this.m_Parts = new List<StyleSelectorPart>());
				}
				return result;
			}
		}

		// Token: 0x06001EB1 RID: 7857 RVA: 0x00076000 File Offset: 0x00074200
		public UQueryBuilder(VisualElement visualElement)
		{
			this = default(UQueryBuilder<T>);
			this.m_Element = visualElement;
			this.m_Parts = null;
			this.m_StyleSelectors = null;
			this.m_Relationship = StyleSelectorRelationship.None;
			this.m_Matchers = new List<RuleMatcher>();
			this.pseudoStatesMask = (this.negatedPseudoStatesMask = 0);
		}

		// Token: 0x06001EB2 RID: 7858 RVA: 0x0007604C File Offset: 0x0007424C
		public UQueryBuilder<T> Class(string classname)
		{
			this.AddClass(classname);
			return this;
		}

		// Token: 0x06001EB3 RID: 7859 RVA: 0x0007606C File Offset: 0x0007426C
		public UQueryBuilder<T> Name(string id)
		{
			this.AddName(id);
			return this;
		}

		// Token: 0x06001EB4 RID: 7860 RVA: 0x0007608C File Offset: 0x0007428C
		public UQueryBuilder<T2> Descendents<T2>(string name = null, params string[] classNames) where T2 : VisualElement
		{
			this.FinishCurrentSelector();
			this.AddType<T2>();
			this.AddName(name);
			this.AddClasses(classNames);
			return this.AddRelationship<T2>(StyleSelectorRelationship.Descendent);
		}

		// Token: 0x06001EB5 RID: 7861 RVA: 0x000760C4 File Offset: 0x000742C4
		public UQueryBuilder<T2> Descendents<T2>(string name = null, string classname = null) where T2 : VisualElement
		{
			this.FinishCurrentSelector();
			this.AddType<T2>();
			this.AddName(name);
			this.AddClass(classname);
			return this.AddRelationship<T2>(StyleSelectorRelationship.Descendent);
		}

		// Token: 0x06001EB6 RID: 7862 RVA: 0x000760FC File Offset: 0x000742FC
		public UQueryBuilder<T2> Children<T2>(string name = null, params string[] classes) where T2 : VisualElement
		{
			this.FinishCurrentSelector();
			this.AddType<T2>();
			this.AddName(name);
			this.AddClasses(classes);
			return this.AddRelationship<T2>(StyleSelectorRelationship.Child);
		}

		// Token: 0x06001EB7 RID: 7863 RVA: 0x00076134 File Offset: 0x00074334
		public UQueryBuilder<T2> Children<T2>(string name = null, string className = null) where T2 : VisualElement
		{
			this.FinishCurrentSelector();
			this.AddType<T2>();
			this.AddName(name);
			this.AddClass(className);
			return this.AddRelationship<T2>(StyleSelectorRelationship.Child);
		}

		// Token: 0x06001EB8 RID: 7864 RVA: 0x0007616C File Offset: 0x0007436C
		public UQueryBuilder<T2> OfType<T2>(string name = null, params string[] classes) where T2 : VisualElement
		{
			this.AddType<T2>();
			this.AddName(name);
			this.AddClasses(classes);
			return this.AddRelationship<T2>(StyleSelectorRelationship.None);
		}

		// Token: 0x06001EB9 RID: 7865 RVA: 0x0007619C File Offset: 0x0007439C
		public UQueryBuilder<T2> OfType<T2>(string name = null, string className = null) where T2 : VisualElement
		{
			this.AddType<T2>();
			this.AddName(name);
			this.AddClass(className);
			return this.AddRelationship<T2>(StyleSelectorRelationship.None);
		}

		// Token: 0x06001EBA RID: 7866 RVA: 0x000761CC File Offset: 0x000743CC
		internal UQueryBuilder<T> SingleBaseType()
		{
			this.parts.Add(StyleSelectorPart.CreatePredicate(UQuery.IsOfType<T>.s_Instance));
			return this;
		}

		// Token: 0x06001EBB RID: 7867 RVA: 0x000761FC File Offset: 0x000743FC
		public UQueryBuilder<T> Where(Func<T, bool> selectorPredicate)
		{
			this.parts.Add(StyleSelectorPart.CreatePredicate(new UQuery.PredicateWrapper<T>(selectorPredicate)));
			return this;
		}

		// Token: 0x06001EBC RID: 7868 RVA: 0x0007622C File Offset: 0x0007442C
		private void AddClass(string c)
		{
			bool flag = c != null;
			if (flag)
			{
				this.parts.Add(StyleSelectorPart.CreateClass(c));
			}
		}

		// Token: 0x06001EBD RID: 7869 RVA: 0x00076254 File Offset: 0x00074454
		private void AddClasses(params string[] classes)
		{
			bool flag = classes != null;
			if (flag)
			{
				for (int i = 0; i < classes.Length; i++)
				{
					this.AddClass(classes[i]);
				}
			}
		}

		// Token: 0x06001EBE RID: 7870 RVA: 0x00076288 File Offset: 0x00074488
		private void AddName(string id)
		{
			bool flag = id != null;
			if (flag)
			{
				this.parts.Add(StyleSelectorPart.CreateId(id));
			}
		}

		// Token: 0x06001EBF RID: 7871 RVA: 0x000762B0 File Offset: 0x000744B0
		private void AddType<T2>() where T2 : VisualElement
		{
			bool flag = typeof(T2) != typeof(VisualElement);
			if (flag)
			{
				this.parts.Add(StyleSelectorPart.CreatePredicate(UQuery.IsOfType<T2>.s_Instance));
			}
		}

		// Token: 0x06001EC0 RID: 7872 RVA: 0x000762F4 File Offset: 0x000744F4
		private UQueryBuilder<T> AddPseudoState(PseudoStates s)
		{
			this.pseudoStatesMask |= (int)s;
			return this;
		}

		// Token: 0x06001EC1 RID: 7873 RVA: 0x0007631C File Offset: 0x0007451C
		private UQueryBuilder<T> AddNegativePseudoState(PseudoStates s)
		{
			this.negatedPseudoStatesMask |= (int)s;
			return this;
		}

		// Token: 0x06001EC2 RID: 7874 RVA: 0x00076344 File Offset: 0x00074544
		public UQueryBuilder<T> Active()
		{
			return this.AddPseudoState(PseudoStates.Active);
		}

		// Token: 0x06001EC3 RID: 7875 RVA: 0x00076360 File Offset: 0x00074560
		public UQueryBuilder<T> NotActive()
		{
			return this.AddNegativePseudoState(PseudoStates.Active);
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0007637C File Offset: 0x0007457C
		public UQueryBuilder<T> Visible()
		{
			return from e in this
			where e.visible
			select e;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x000763B4 File Offset: 0x000745B4
		public UQueryBuilder<T> NotVisible()
		{
			return from e in this
			where !e.visible
			select e;
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x000763EC File Offset: 0x000745EC
		public UQueryBuilder<T> Hovered()
		{
			return this.AddPseudoState(PseudoStates.Hover);
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x00076408 File Offset: 0x00074608
		public UQueryBuilder<T> NotHovered()
		{
			return this.AddNegativePseudoState(PseudoStates.Hover);
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x00076424 File Offset: 0x00074624
		public UQueryBuilder<T> Checked()
		{
			return this.AddPseudoState(PseudoStates.Checked);
		}

		// Token: 0x06001EC9 RID: 7881 RVA: 0x00076440 File Offset: 0x00074640
		public UQueryBuilder<T> NotChecked()
		{
			return this.AddNegativePseudoState(PseudoStates.Checked);
		}

		// Token: 0x06001ECA RID: 7882 RVA: 0x0007645C File Offset: 0x0007465C
		[Obsolete("Use Checked() instead")]
		public UQueryBuilder<T> Selected()
		{
			return this.AddPseudoState(PseudoStates.Checked);
		}

		// Token: 0x06001ECB RID: 7883 RVA: 0x00076478 File Offset: 0x00074678
		[Obsolete("Use NotChecked() instead")]
		public UQueryBuilder<T> NotSelected()
		{
			return this.AddNegativePseudoState(PseudoStates.Checked);
		}

		// Token: 0x06001ECC RID: 7884 RVA: 0x00076494 File Offset: 0x00074694
		public UQueryBuilder<T> Enabled()
		{
			return this.AddNegativePseudoState(PseudoStates.Disabled);
		}

		// Token: 0x06001ECD RID: 7885 RVA: 0x000764B0 File Offset: 0x000746B0
		public UQueryBuilder<T> NotEnabled()
		{
			return this.AddPseudoState(PseudoStates.Disabled);
		}

		// Token: 0x06001ECE RID: 7886 RVA: 0x000764CC File Offset: 0x000746CC
		public UQueryBuilder<T> Focused()
		{
			return this.AddPseudoState(PseudoStates.Focus);
		}

		// Token: 0x06001ECF RID: 7887 RVA: 0x000764E8 File Offset: 0x000746E8
		public UQueryBuilder<T> NotFocused()
		{
			return this.AddNegativePseudoState(PseudoStates.Focus);
		}

		// Token: 0x06001ED0 RID: 7888 RVA: 0x00076504 File Offset: 0x00074704
		private UQueryBuilder<T2> AddRelationship<T2>(StyleSelectorRelationship relationship) where T2 : VisualElement
		{
			return new UQueryBuilder<T2>(this.m_Element)
			{
				m_Matchers = this.m_Matchers,
				m_Parts = this.m_Parts,
				m_StyleSelectors = this.m_StyleSelectors,
				m_Relationship = ((relationship == StyleSelectorRelationship.None) ? this.m_Relationship : relationship),
				pseudoStatesMask = this.pseudoStatesMask,
				negatedPseudoStatesMask = this.negatedPseudoStatesMask
			};
		}

		// Token: 0x06001ED1 RID: 7889 RVA: 0x00076578 File Offset: 0x00074778
		private void AddPseudoStatesRuleIfNecessasy()
		{
			bool flag = this.pseudoStatesMask != 0 || this.negatedPseudoStatesMask != 0;
			if (flag)
			{
				this.parts.Add(new StyleSelectorPart
				{
					type = StyleSelectorType.PseudoClass
				});
			}
		}

		// Token: 0x06001ED2 RID: 7890 RVA: 0x000765C0 File Offset: 0x000747C0
		private void FinishSelector()
		{
			this.FinishCurrentSelector();
			bool flag = this.styleSelectors.Count > 0;
			if (flag)
			{
				StyleComplexSelector styleComplexSelector = new StyleComplexSelector();
				styleComplexSelector.selectors = this.styleSelectors.ToArray();
				this.styleSelectors.Clear();
				this.m_Matchers.Add(new RuleMatcher
				{
					complexSelector = styleComplexSelector
				});
			}
		}

		// Token: 0x06001ED3 RID: 7891 RVA: 0x0007662C File Offset: 0x0007482C
		private bool CurrentSelectorEmpty()
		{
			return this.parts.Count == 0 && this.m_Relationship == StyleSelectorRelationship.None && this.pseudoStatesMask == 0 && this.negatedPseudoStatesMask == 0;
		}

		// Token: 0x06001ED4 RID: 7892 RVA: 0x00076668 File Offset: 0x00074868
		private void FinishCurrentSelector()
		{
			bool flag = !this.CurrentSelectorEmpty();
			if (flag)
			{
				StyleSelector styleSelector = new StyleSelector();
				styleSelector.previousRelationship = this.m_Relationship;
				this.AddPseudoStatesRuleIfNecessasy();
				styleSelector.parts = this.m_Parts.ToArray();
				styleSelector.pseudoStateMask = this.pseudoStatesMask;
				styleSelector.negatedPseudoStateMask = this.negatedPseudoStatesMask;
				this.styleSelectors.Add(styleSelector);
				this.m_Parts.Clear();
				this.pseudoStatesMask = (this.negatedPseudoStatesMask = 0);
			}
		}

		// Token: 0x06001ED5 RID: 7893 RVA: 0x000766F4 File Offset: 0x000748F4
		public UQueryState<T> Build()
		{
			this.FinishSelector();
			bool flag = this.m_Matchers.Count == 0;
			if (flag)
			{
				this.parts.Add(new StyleSelectorPart
				{
					type = StyleSelectorType.Wildcard
				});
				this.FinishSelector();
			}
			return new UQueryState<T>(this.m_Element, this.m_Matchers);
		}

		// Token: 0x06001ED6 RID: 7894 RVA: 0x00076758 File Offset: 0x00074958
		public static implicit operator T(UQueryBuilder<T> s)
		{
			return s.First();
		}

		// Token: 0x06001ED7 RID: 7895 RVA: 0x00076774 File Offset: 0x00074974
		public static bool operator ==(UQueryBuilder<T> builder1, UQueryBuilder<T> builder2)
		{
			return builder1.Equals(builder2);
		}

		// Token: 0x06001ED8 RID: 7896 RVA: 0x00076790 File Offset: 0x00074990
		public static bool operator !=(UQueryBuilder<T> builder1, UQueryBuilder<T> builder2)
		{
			return !(builder1 == builder2);
		}

		// Token: 0x06001ED9 RID: 7897 RVA: 0x000767AC File Offset: 0x000749AC
		public T First()
		{
			return this.Build().First();
		}

		// Token: 0x06001EDA RID: 7898 RVA: 0x000767CC File Offset: 0x000749CC
		public T Last()
		{
			return this.Build().Last();
		}

		// Token: 0x06001EDB RID: 7899 RVA: 0x000767EC File Offset: 0x000749EC
		public List<T> ToList()
		{
			return this.Build().ToList();
		}

		// Token: 0x06001EDC RID: 7900 RVA: 0x0007680C File Offset: 0x00074A0C
		public void ToList(List<T> results)
		{
			this.Build().ToList(results);
		}

		// Token: 0x06001EDD RID: 7901 RVA: 0x0007682C File Offset: 0x00074A2C
		public T AtIndex(int index)
		{
			return this.Build().AtIndex(index);
		}

		// Token: 0x06001EDE RID: 7902 RVA: 0x00076850 File Offset: 0x00074A50
		public void ForEach<T2>(List<T2> result, Func<T, T2> funcCall)
		{
			this.Build().ForEach<T2>(result, funcCall);
		}

		// Token: 0x06001EDF RID: 7903 RVA: 0x00076870 File Offset: 0x00074A70
		public List<T2> ForEach<T2>(Func<T, T2> funcCall)
		{
			return this.Build().ForEach<T2>(funcCall);
		}

		// Token: 0x06001EE0 RID: 7904 RVA: 0x00076894 File Offset: 0x00074A94
		public void ForEach(Action<T> funcCall)
		{
			this.Build().ForEach(funcCall);
		}

		// Token: 0x06001EE1 RID: 7905 RVA: 0x000768B4 File Offset: 0x00074AB4
		public bool Equals(UQueryBuilder<T> other)
		{
			return EqualityComparer<List<StyleSelector>>.Default.Equals(this.m_StyleSelectors, other.m_StyleSelectors) && EqualityComparer<List<StyleSelector>>.Default.Equals(this.styleSelectors, other.styleSelectors) && EqualityComparer<List<StyleSelectorPart>>.Default.Equals(this.m_Parts, other.m_Parts) && EqualityComparer<List<StyleSelectorPart>>.Default.Equals(this.parts, other.parts) && this.m_Element == other.m_Element && EqualityComparer<List<RuleMatcher>>.Default.Equals(this.m_Matchers, other.m_Matchers) && this.m_Relationship == other.m_Relationship && this.pseudoStatesMask == other.pseudoStatesMask && this.negatedPseudoStatesMask == other.negatedPseudoStatesMask;
		}

		// Token: 0x06001EE2 RID: 7906 RVA: 0x00076984 File Offset: 0x00074B84
		public override bool Equals(object obj)
		{
			bool flag = !(obj is UQueryBuilder<T>);
			return !flag && this.Equals((UQueryBuilder<T>)obj);
		}

		// Token: 0x06001EE3 RID: 7907 RVA: 0x000769B8 File Offset: 0x00074BB8
		public override int GetHashCode()
		{
			int num = -949812380;
			num = num * -1521134295 + EqualityComparer<List<StyleSelector>>.Default.GetHashCode(this.m_StyleSelectors);
			num = num * -1521134295 + EqualityComparer<List<StyleSelector>>.Default.GetHashCode(this.styleSelectors);
			num = num * -1521134295 + EqualityComparer<List<StyleSelectorPart>>.Default.GetHashCode(this.m_Parts);
			num = num * -1521134295 + EqualityComparer<List<StyleSelectorPart>>.Default.GetHashCode(this.parts);
			num = num * -1521134295 + EqualityComparer<VisualElement>.Default.GetHashCode(this.m_Element);
			num = num * -1521134295 + EqualityComparer<List<RuleMatcher>>.Default.GetHashCode(this.m_Matchers);
			num = num * -1521134295 + this.m_Relationship.GetHashCode();
			num = num * -1521134295 + this.pseudoStatesMask.GetHashCode();
			return num * -1521134295 + this.negatedPseudoStatesMask.GetHashCode();
		}

		// Token: 0x04000CB8 RID: 3256
		private List<StyleSelector> m_StyleSelectors;

		// Token: 0x04000CB9 RID: 3257
		private List<StyleSelectorPart> m_Parts;

		// Token: 0x04000CBA RID: 3258
		private VisualElement m_Element;

		// Token: 0x04000CBB RID: 3259
		private List<RuleMatcher> m_Matchers;

		// Token: 0x04000CBC RID: 3260
		private StyleSelectorRelationship m_Relationship;

		// Token: 0x04000CBD RID: 3261
		private int pseudoStatesMask;

		// Token: 0x04000CBE RID: 3262
		private int negatedPseudoStatesMask;
	}
}
