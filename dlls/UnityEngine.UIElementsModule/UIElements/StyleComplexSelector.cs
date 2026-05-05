using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x0200034C RID: 844
	[Serializable]
	internal class StyleComplexSelector : ISerializationCallbackReceiver
	{
		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x06001C5A RID: 7258 RVA: 0x0006E3B0 File Offset: 0x0006C5B0
		// (set) Token: 0x06001C5B RID: 7259 RVA: 0x0006E3C8 File Offset: 0x0006C5C8
		public int specificity
		{
			get
			{
				return this.m_Specificity;
			}
			internal set
			{
				this.m_Specificity = value;
			}
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06001C5C RID: 7260 RVA: 0x0006E3D2 File Offset: 0x0006C5D2
		// (set) Token: 0x06001C5D RID: 7261 RVA: 0x0006E3DA File Offset: 0x0006C5DA
		public StyleRule rule { get; internal set; }

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x06001C5E RID: 7262 RVA: 0x0006E3E4 File Offset: 0x0006C5E4
		public bool isSimple
		{
			get
			{
				return this.m_isSimple;
			}
		}

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x06001C5F RID: 7263 RVA: 0x0006E3FC File Offset: 0x0006C5FC
		// (set) Token: 0x06001C60 RID: 7264 RVA: 0x0006E414 File Offset: 0x0006C614
		public StyleSelector[] selectors
		{
			get
			{
				return this.m_Selectors;
			}
			internal set
			{
				this.m_Selectors = value;
				this.m_isSimple = (this.m_Selectors.Length == 1);
			}
		}

		// Token: 0x06001C61 RID: 7265 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void OnBeforeSerialize()
		{
		}

		// Token: 0x06001C62 RID: 7266 RVA: 0x0006E42F File Offset: 0x0006C62F
		public virtual void OnAfterDeserialize()
		{
			this.m_isSimple = (this.m_Selectors.Length == 1);
		}

		// Token: 0x06001C63 RID: 7267 RVA: 0x0006E444 File Offset: 0x0006C644
		internal void CachePseudoStateMasks()
		{
			bool flag = StyleComplexSelector.s_PseudoStates == null;
			if (flag)
			{
				StyleComplexSelector.s_PseudoStates = new Dictionary<string, StyleComplexSelector.PseudoStateData>();
				StyleComplexSelector.s_PseudoStates["active"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Active, false);
				StyleComplexSelector.s_PseudoStates["hover"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Hover, false);
				StyleComplexSelector.s_PseudoStates["checked"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Checked, false);
				StyleComplexSelector.s_PseudoStates["selected"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Checked, false);
				StyleComplexSelector.s_PseudoStates["disabled"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Disabled, false);
				StyleComplexSelector.s_PseudoStates["focus"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Focus, false);
				StyleComplexSelector.s_PseudoStates["root"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Root, false);
				StyleComplexSelector.s_PseudoStates["inactive"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Active, true);
				StyleComplexSelector.s_PseudoStates["enabled"] = new StyleComplexSelector.PseudoStateData(PseudoStates.Disabled, true);
			}
			int i = 0;
			int num = this.selectors.Length;
			while (i < num)
			{
				StyleSelector styleSelector = this.selectors[i];
				StyleSelectorPart[] parts = styleSelector.parts;
				PseudoStates pseudoStates = (PseudoStates)0;
				PseudoStates pseudoStates2 = (PseudoStates)0;
				for (int j = 0; j < styleSelector.parts.Length; j++)
				{
					bool flag2 = styleSelector.parts[j].type == StyleSelectorType.PseudoClass;
					if (flag2)
					{
						StyleComplexSelector.PseudoStateData pseudoStateData;
						bool flag3 = StyleComplexSelector.s_PseudoStates.TryGetValue(parts[j].value, out pseudoStateData);
						if (flag3)
						{
							bool flag4 = !pseudoStateData.negate;
							if (flag4)
							{
								pseudoStates |= pseudoStateData.state;
							}
							else
							{
								pseudoStates2 |= pseudoStateData.state;
							}
						}
						else
						{
							Debug.LogWarningFormat("Unknown pseudo class \"{0}\"", new object[]
							{
								parts[j].value
							});
						}
					}
				}
				styleSelector.pseudoStateMask = (int)pseudoStates;
				styleSelector.negatedPseudoStateMask = (int)pseudoStates2;
				i++;
			}
		}

		// Token: 0x06001C64 RID: 7268 RVA: 0x0006E644 File Offset: 0x0006C844
		public override string ToString()
		{
			return string.Format("[{0}]", string.Join(", ", (from x in this.m_Selectors
			select x.ToString()).ToArray<string>()));
		}

		// Token: 0x06001C65 RID: 7269 RVA: 0x0006E69C File Offset: 0x0006C89C
		private static int StyleSelectorPartCompare(StyleSelectorPart x, StyleSelectorPart y)
		{
			bool flag = y.type < x.type;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = y.type > x.type;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = y.value.CompareTo(x.value);
				}
			}
			return result;
		}

		// Token: 0x06001C66 RID: 7270 RVA: 0x0006E6F4 File Offset: 0x0006C8F4
		internal unsafe void CalculateHashes()
		{
			bool isSimple = this.isSimple;
			if (!isSimple)
			{
				for (int i = this.selectors.Length - 2; i > -1; i--)
				{
					StyleComplexSelector.m_HashList.AddRange(this.selectors[i].parts);
				}
				StyleComplexSelector.m_HashList.RemoveAll((StyleSelectorPart p) => p.type != StyleSelectorType.Class && p.type != StyleSelectorType.ID && p.type != StyleSelectorType.Type);
				StyleComplexSelector.m_HashList.Sort(new Comparison<StyleSelectorPart>(StyleComplexSelector.StyleSelectorPartCompare));
				bool flag = true;
				StyleSelectorType styleSelectorType = StyleSelectorType.Unknown;
				string text = "";
				int num = 0;
				int num2 = Math.Min(4, StyleComplexSelector.m_HashList.Count);
				for (int j = 0; j < num2; j++)
				{
					bool flag2 = flag;
					if (flag2)
					{
						flag = false;
					}
					else
					{
						while (num < StyleComplexSelector.m_HashList.Count && StyleComplexSelector.m_HashList[num].type == styleSelectorType && StyleComplexSelector.m_HashList[num].value == text)
						{
							num++;
						}
						bool flag3 = num == StyleComplexSelector.m_HashList.Count;
						if (flag3)
						{
							break;
						}
					}
					styleSelectorType = StyleComplexSelector.m_HashList[num].type;
					text = StyleComplexSelector.m_HashList[num].value;
					bool flag4 = styleSelectorType == StyleSelectorType.ID;
					Salt salt;
					if (flag4)
					{
						salt = Salt.IdSalt;
					}
					else
					{
						bool flag5 = styleSelectorType == StyleSelectorType.Class;
						if (flag5)
						{
							salt = Salt.ClassSalt;
						}
						else
						{
							salt = Salt.TagNameSalt;
						}
					}
					*(ref this.ancestorHashes.hashes.FixedElementField + (IntPtr)j * 4) = text.GetHashCode() * (int)salt;
				}
				StyleComplexSelector.m_HashList.Clear();
			}
		}

		// Token: 0x04000BAF RID: 2991
		[NonSerialized]
		public Hashes ancestorHashes;

		// Token: 0x04000BB0 RID: 2992
		[SerializeField]
		private int m_Specificity;

		// Token: 0x04000BB2 RID: 2994
		[NonSerialized]
		private bool m_isSimple;

		// Token: 0x04000BB3 RID: 2995
		[SerializeField]
		private StyleSelector[] m_Selectors;

		// Token: 0x04000BB4 RID: 2996
		[SerializeField]
		internal int ruleIndex;

		// Token: 0x04000BB5 RID: 2997
		[NonSerialized]
		internal StyleComplexSelector nextInTable;

		// Token: 0x04000BB6 RID: 2998
		[NonSerialized]
		internal int orderInStyleSheet;

		// Token: 0x04000BB7 RID: 2999
		private static Dictionary<string, StyleComplexSelector.PseudoStateData> s_PseudoStates;

		// Token: 0x04000BB8 RID: 3000
		private static List<StyleSelectorPart> m_HashList = new List<StyleSelectorPart>();

		// Token: 0x0200034D RID: 845
		private struct PseudoStateData
		{
			// Token: 0x06001C69 RID: 7273 RVA: 0x0006E8CC File Offset: 0x0006CACC
			public PseudoStateData(PseudoStates state, bool negate)
			{
				this.state = state;
				this.negate = negate;
			}

			// Token: 0x04000BB9 RID: 3001
			public readonly PseudoStates state;

			// Token: 0x04000BBA RID: 3002
			public readonly bool negate;
		}
	}
}
