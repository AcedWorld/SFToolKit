using System;
using System.Collections.Generic;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x02000356 RID: 854
	[HelpURL("UIE-USS")]
	[Serializable]
	public class StyleSheet : ScriptableObject
	{
		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06001C8D RID: 7309 RVA: 0x0006EC24 File Offset: 0x0006CE24
		// (set) Token: 0x06001C8E RID: 7310 RVA: 0x0006EC3C File Offset: 0x0006CE3C
		public bool importedWithErrors
		{
			get
			{
				return this.m_ImportedWithErrors;
			}
			internal set
			{
				this.m_ImportedWithErrors = value;
			}
		}

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x06001C8F RID: 7311 RVA: 0x0006EC48 File Offset: 0x0006CE48
		// (set) Token: 0x06001C90 RID: 7312 RVA: 0x0006EC60 File Offset: 0x0006CE60
		public bool importedWithWarnings
		{
			get
			{
				return this.m_ImportedWithWarnings;
			}
			internal set
			{
				this.m_ImportedWithWarnings = value;
			}
		}

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x06001C91 RID: 7313 RVA: 0x0006EC6C File Offset: 0x0006CE6C
		// (set) Token: 0x06001C92 RID: 7314 RVA: 0x0006EC84 File Offset: 0x0006CE84
		internal StyleRule[] rules
		{
			get
			{
				return this.m_Rules;
			}
			set
			{
				this.m_Rules = value;
				this.SetupReferences();
			}
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x06001C93 RID: 7315 RVA: 0x0006EC98 File Offset: 0x0006CE98
		// (set) Token: 0x06001C94 RID: 7316 RVA: 0x0006ECB0 File Offset: 0x0006CEB0
		internal StyleComplexSelector[] complexSelectors
		{
			get
			{
				return this.m_ComplexSelectors;
			}
			set
			{
				this.m_ComplexSelectors = value;
				this.SetupReferences();
			}
		}

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x06001C95 RID: 7317 RVA: 0x0006ECC4 File Offset: 0x0006CEC4
		internal List<StyleSheet> flattenedRecursiveImports
		{
			get
			{
				return this.m_FlattenedImportedStyleSheets;
			}
		}

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x06001C96 RID: 7318 RVA: 0x0006ECDC File Offset: 0x0006CEDC
		// (set) Token: 0x06001C97 RID: 7319 RVA: 0x0006ECF4 File Offset: 0x0006CEF4
		public int contentHash
		{
			get
			{
				return this.m_ContentHash;
			}
			set
			{
				this.m_ContentHash = value;
			}
		}

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06001C98 RID: 7320 RVA: 0x0006ED00 File Offset: 0x0006CF00
		// (set) Token: 0x06001C99 RID: 7321 RVA: 0x0006ED18 File Offset: 0x0006CF18
		internal bool isDefaultStyleSheet
		{
			get
			{
				return this.m_IsDefaultStyleSheet;
			}
			set
			{
				this.m_IsDefaultStyleSheet = value;
				bool flag = this.flattenedRecursiveImports != null;
				if (flag)
				{
					foreach (StyleSheet styleSheet in this.flattenedRecursiveImports)
					{
						styleSheet.isDefaultStyleSheet = value;
					}
				}
			}
		}

		// Token: 0x06001C9A RID: 7322 RVA: 0x0006ED88 File Offset: 0x0006CF88
		private bool TryCheckAccess<T>(T[] list, StyleValueType type, StyleValueHandle handle, out T value)
		{
			bool result = false;
			value = default(T);
			bool flag = handle.valueType == type && handle.valueIndex >= 0 && handle.valueIndex < list.Length;
			if (flag)
			{
				value = list[handle.valueIndex];
				result = true;
			}
			else
			{
				Debug.LogErrorFormat(this, "Trying to read value of type {0} while reading a value of type {1}", new object[]
				{
					type,
					handle.valueType
				});
			}
			return result;
		}

		// Token: 0x06001C9B RID: 7323 RVA: 0x0006EE10 File Offset: 0x0006D010
		private T CheckAccess<T>(T[] list, StyleValueType type, StyleValueHandle handle)
		{
			T result = default(T);
			bool flag = handle.valueType != type;
			if (flag)
			{
				Debug.LogErrorFormat(this, "Trying to read value of type {0} while reading a value of type {1}", new object[]
				{
					type,
					handle.valueType
				});
			}
			else
			{
				bool flag2 = list == null || handle.valueIndex < 0 || handle.valueIndex >= list.Length;
				if (flag2)
				{
					Debug.LogError("Accessing invalid property", this);
				}
				else
				{
					result = list[handle.valueIndex];
				}
			}
			return result;
		}

		// Token: 0x06001C9C RID: 7324 RVA: 0x0006EEAA File Offset: 0x0006D0AA
		internal virtual void OnEnable()
		{
			this.SetupReferences();
		}

		// Token: 0x06001C9D RID: 7325 RVA: 0x0006EEB4 File Offset: 0x0006D0B4
		internal void FlattenImportedStyleSheetsRecursive()
		{
			this.m_FlattenedImportedStyleSheets = new List<StyleSheet>();
			this.FlattenImportedStyleSheetsRecursive(this);
		}

		// Token: 0x06001C9E RID: 7326 RVA: 0x0006EECC File Offset: 0x0006D0CC
		private void FlattenImportedStyleSheetsRecursive(StyleSheet sheet)
		{
			bool flag = sheet.imports == null;
			if (!flag)
			{
				for (int i = 0; i < sheet.imports.Length; i++)
				{
					StyleSheet styleSheet = sheet.imports[i].styleSheet;
					bool flag2 = styleSheet == null;
					if (!flag2)
					{
						styleSheet.isDefaultStyleSheet = this.isDefaultStyleSheet;
						this.FlattenImportedStyleSheetsRecursive(styleSheet);
						this.m_FlattenedImportedStyleSheets.Add(styleSheet);
					}
				}
			}
		}

		// Token: 0x06001C9F RID: 7327 RVA: 0x0006EF48 File Offset: 0x0006D148
		private void SetupReferences()
		{
			bool flag = this.complexSelectors == null || this.rules == null;
			if (!flag)
			{
				foreach (StyleRule styleRule in this.rules)
				{
					foreach (StyleProperty styleProperty in styleRule.properties)
					{
						bool flag2 = StyleSheet.CustomStartsWith(styleProperty.name, StyleSheet.kCustomPropertyMarker);
						if (flag2)
						{
							styleRule.customPropertiesCount++;
							styleProperty.isCustomProperty = true;
						}
						foreach (StyleValueHandle handle in styleProperty.values)
						{
							bool flag3 = handle.IsVarFunction();
							if (flag3)
							{
								styleProperty.requireVariableResolve = true;
								break;
							}
						}
					}
				}
				int l = 0;
				int num = this.complexSelectors.Length;
				while (l < num)
				{
					this.complexSelectors[l].CachePseudoStateMasks();
					l++;
				}
				this.orderedClassSelectors = new Dictionary<string, StyleComplexSelector>(StringComparer.Ordinal);
				this.orderedNameSelectors = new Dictionary<string, StyleComplexSelector>(StringComparer.Ordinal);
				this.orderedTypeSelectors = new Dictionary<string, StyleComplexSelector>(StringComparer.Ordinal);
				int m = 0;
				while (m < this.complexSelectors.Length)
				{
					StyleComplexSelector styleComplexSelector = this.complexSelectors[m];
					bool flag4 = styleComplexSelector.ruleIndex < this.rules.Length;
					if (flag4)
					{
						styleComplexSelector.rule = this.rules[styleComplexSelector.ruleIndex];
					}
					styleComplexSelector.CalculateHashes();
					styleComplexSelector.orderInStyleSheet = m;
					StyleSelector styleSelector = styleComplexSelector.selectors[styleComplexSelector.selectors.Length - 1];
					StyleSelectorPart styleSelectorPart = styleSelector.parts[0];
					string key = styleSelectorPart.value;
					Dictionary<string, StyleComplexSelector> dictionary = null;
					switch (styleSelectorPart.type)
					{
					case StyleSelectorType.Wildcard:
					case StyleSelectorType.Type:
						key = (styleSelectorPart.value ?? "*");
						dictionary = this.orderedTypeSelectors;
						break;
					case StyleSelectorType.Class:
						dictionary = this.orderedClassSelectors;
						break;
					case StyleSelectorType.PseudoClass:
						key = "*";
						dictionary = this.orderedTypeSelectors;
						break;
					case StyleSelectorType.RecursivePseudoClass:
						goto IL_233;
					case StyleSelectorType.ID:
						dictionary = this.orderedNameSelectors;
						break;
					default:
						goto IL_233;
					}
					IL_252:
					bool flag5 = dictionary != null;
					if (flag5)
					{
						StyleComplexSelector nextInTable;
						bool flag6 = dictionary.TryGetValue(key, out nextInTable);
						if (flag6)
						{
							styleComplexSelector.nextInTable = nextInTable;
						}
						dictionary[key] = styleComplexSelector;
					}
					m++;
					continue;
					IL_233:
					Debug.LogError(string.Format("Invalid first part type {0}", styleSelectorPart.type), this);
					goto IL_252;
				}
			}
		}

		// Token: 0x06001CA0 RID: 7328 RVA: 0x0006F1F8 File Offset: 0x0006D3F8
		internal StyleValueKeyword ReadKeyword(StyleValueHandle handle)
		{
			return (StyleValueKeyword)handle.valueIndex;
		}

		// Token: 0x06001CA1 RID: 7329 RVA: 0x0006F210 File Offset: 0x0006D410
		internal float ReadFloat(StyleValueHandle handle)
		{
			bool flag = handle.valueType == StyleValueType.Dimension;
			float result;
			if (flag)
			{
				Dimension dimension = this.CheckAccess<Dimension>(this.dimensions, StyleValueType.Dimension, handle);
				result = dimension.value;
			}
			else
			{
				result = this.CheckAccess<float>(this.floats, StyleValueType.Float, handle);
			}
			return result;
		}

		// Token: 0x06001CA2 RID: 7330 RVA: 0x0006F258 File Offset: 0x0006D458
		internal bool TryReadFloat(StyleValueHandle handle, out float value)
		{
			bool flag = this.TryCheckAccess<float>(this.floats, StyleValueType.Float, handle, out value);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				Dimension dimension;
				bool flag2 = this.TryCheckAccess<Dimension>(this.dimensions, StyleValueType.Float, handle, out dimension);
				value = dimension.value;
				result = flag2;
			}
			return result;
		}

		// Token: 0x06001CA3 RID: 7331 RVA: 0x0006F29C File Offset: 0x0006D49C
		internal Dimension ReadDimension(StyleValueHandle handle)
		{
			bool flag = handle.valueType == StyleValueType.Float;
			Dimension result;
			if (flag)
			{
				float value = this.CheckAccess<float>(this.floats, StyleValueType.Float, handle);
				result = new Dimension(value, Dimension.Unit.Unitless);
			}
			else
			{
				result = this.CheckAccess<Dimension>(this.dimensions, StyleValueType.Dimension, handle);
			}
			return result;
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x0006F2E4 File Offset: 0x0006D4E4
		internal bool TryReadDimension(StyleValueHandle handle, out Dimension value)
		{
			bool flag = this.TryCheckAccess<Dimension>(this.dimensions, StyleValueType.Dimension, handle, out value);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				float value2 = 0f;
				bool flag2 = this.TryCheckAccess<float>(this.floats, StyleValueType.Float, handle, out value2);
				value = new Dimension(value2, Dimension.Unit.Unitless);
				result = flag2;
			}
			return result;
		}

		// Token: 0x06001CA5 RID: 7333 RVA: 0x0006F334 File Offset: 0x0006D534
		internal Color ReadColor(StyleValueHandle handle)
		{
			return this.CheckAccess<Color>(this.colors, StyleValueType.Color, handle);
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x0006F354 File Offset: 0x0006D554
		internal bool TryReadColor(StyleValueHandle handle, out Color value)
		{
			return this.TryCheckAccess<Color>(this.colors, StyleValueType.Color, handle, out value);
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x0006F378 File Offset: 0x0006D578
		internal string ReadString(StyleValueHandle handle)
		{
			return this.CheckAccess<string>(this.strings, StyleValueType.String, handle);
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x0006F39C File Offset: 0x0006D59C
		internal bool TryReadString(StyleValueHandle handle, out string value)
		{
			return this.TryCheckAccess<string>(this.strings, StyleValueType.String, handle, out value);
		}

		// Token: 0x06001CA9 RID: 7337 RVA: 0x0006F3C0 File Offset: 0x0006D5C0
		internal string ReadEnum(StyleValueHandle handle)
		{
			return this.CheckAccess<string>(this.strings, StyleValueType.Enum, handle);
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x0006F3E0 File Offset: 0x0006D5E0
		internal bool TryReadEnum(StyleValueHandle handle, out string value)
		{
			return this.TryCheckAccess<string>(this.strings, StyleValueType.Enum, handle, out value);
		}

		// Token: 0x06001CAB RID: 7339 RVA: 0x0006F404 File Offset: 0x0006D604
		internal string ReadVariable(StyleValueHandle handle)
		{
			return this.CheckAccess<string>(this.strings, StyleValueType.Variable, handle);
		}

		// Token: 0x06001CAC RID: 7340 RVA: 0x0006F424 File Offset: 0x0006D624
		internal bool TryReadVariable(StyleValueHandle handle, out string value)
		{
			return this.TryCheckAccess<string>(this.strings, StyleValueType.Variable, handle, out value);
		}

		// Token: 0x06001CAD RID: 7341 RVA: 0x0006F448 File Offset: 0x0006D648
		internal string ReadResourcePath(StyleValueHandle handle)
		{
			return this.CheckAccess<string>(this.strings, StyleValueType.ResourcePath, handle);
		}

		// Token: 0x06001CAE RID: 7342 RVA: 0x0006F468 File Offset: 0x0006D668
		internal bool TryReadResourcePath(StyleValueHandle handle, out string value)
		{
			return this.TryCheckAccess<string>(this.strings, StyleValueType.ResourcePath, handle, out value);
		}

		// Token: 0x06001CAF RID: 7343 RVA: 0x0006F48C File Offset: 0x0006D68C
		internal Object ReadAssetReference(StyleValueHandle handle)
		{
			return this.CheckAccess<Object>(this.assets, StyleValueType.AssetReference, handle);
		}

		// Token: 0x06001CB0 RID: 7344 RVA: 0x0006F4AC File Offset: 0x0006D6AC
		internal string ReadMissingAssetReferenceUrl(StyleValueHandle handle)
		{
			return this.CheckAccess<string>(this.strings, StyleValueType.MissingAssetReference, handle);
		}

		// Token: 0x06001CB1 RID: 7345 RVA: 0x0006F4D0 File Offset: 0x0006D6D0
		internal bool TryReadAssetReference(StyleValueHandle handle, out Object value)
		{
			return this.TryCheckAccess<Object>(this.assets, StyleValueType.AssetReference, handle, out value);
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x0006F4F4 File Offset: 0x0006D6F4
		internal StyleValueFunction ReadFunction(StyleValueHandle handle)
		{
			return (StyleValueFunction)handle.valueIndex;
		}

		// Token: 0x06001CB3 RID: 7347 RVA: 0x0006F50C File Offset: 0x0006D70C
		internal string ReadFunctionName(StyleValueHandle handle)
		{
			bool flag = handle.valueType != StyleValueType.Function;
			string result;
			if (flag)
			{
				Debug.LogErrorFormat(this, string.Format("Trying to read value of type {0} while reading a value of type {1}", StyleValueType.Function, handle.valueType), Array.Empty<object>());
				result = string.Empty;
			}
			else
			{
				StyleValueFunction valueIndex = (StyleValueFunction)handle.valueIndex;
				result = valueIndex.ToUssString();
			}
			return result;
		}

		// Token: 0x06001CB4 RID: 7348 RVA: 0x0006F570 File Offset: 0x0006D770
		internal ScalableImage ReadScalableImage(StyleValueHandle handle)
		{
			return this.CheckAccess<ScalableImage>(this.scalableImages, StyleValueType.ScalableImage, handle);
		}

		// Token: 0x06001CB5 RID: 7349 RVA: 0x0006F594 File Offset: 0x0006D794
		private static bool CustomStartsWith(string originalString, string pattern)
		{
			int length = originalString.Length;
			int length2 = pattern.Length;
			int num = 0;
			int num2 = 0;
			while (num < length && num2 < length2 && originalString[num] == pattern[num2])
			{
				num++;
				num2++;
			}
			return (num2 == length2 && length >= length2) || (num == length && length2 >= length);
		}

		// Token: 0x04000BDC RID: 3036
		[SerializeField]
		private bool m_ImportedWithErrors;

		// Token: 0x04000BDD RID: 3037
		[SerializeField]
		private bool m_ImportedWithWarnings;

		// Token: 0x04000BDE RID: 3038
		[SerializeField]
		private StyleRule[] m_Rules;

		// Token: 0x04000BDF RID: 3039
		[SerializeField]
		private StyleComplexSelector[] m_ComplexSelectors;

		// Token: 0x04000BE0 RID: 3040
		[SerializeField]
		internal float[] floats;

		// Token: 0x04000BE1 RID: 3041
		[SerializeField]
		internal Dimension[] dimensions;

		// Token: 0x04000BE2 RID: 3042
		[SerializeField]
		internal Color[] colors;

		// Token: 0x04000BE3 RID: 3043
		[SerializeField]
		internal string[] strings;

		// Token: 0x04000BE4 RID: 3044
		[SerializeField]
		internal Object[] assets;

		// Token: 0x04000BE5 RID: 3045
		[SerializeField]
		internal StyleSheet.ImportStruct[] imports;

		// Token: 0x04000BE6 RID: 3046
		[SerializeField]
		private List<StyleSheet> m_FlattenedImportedStyleSheets;

		// Token: 0x04000BE7 RID: 3047
		[SerializeField]
		private int m_ContentHash;

		// Token: 0x04000BE8 RID: 3048
		[SerializeField]
		internal ScalableImage[] scalableImages;

		// Token: 0x04000BE9 RID: 3049
		[NonSerialized]
		internal Dictionary<string, StyleComplexSelector> orderedNameSelectors;

		// Token: 0x04000BEA RID: 3050
		[NonSerialized]
		internal Dictionary<string, StyleComplexSelector> orderedTypeSelectors;

		// Token: 0x04000BEB RID: 3051
		[NonSerialized]
		internal Dictionary<string, StyleComplexSelector> orderedClassSelectors;

		// Token: 0x04000BEC RID: 3052
		[NonSerialized]
		private bool m_IsDefaultStyleSheet;

		// Token: 0x04000BED RID: 3053
		private static string kCustomPropertyMarker = "--";

		// Token: 0x02000357 RID: 855
		[Serializable]
		internal struct ImportStruct
		{
			// Token: 0x04000BEE RID: 3054
			public StyleSheet styleSheet;

			// Token: 0x04000BEF RID: 3055
			public string[] mediaQueries;
		}
	}
}
