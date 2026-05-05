using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x02000494 RID: 1172
	internal class StyleSheetBuilder
	{
		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x060024A7 RID: 9383 RVA: 0x00099C5C File Offset: 0x00097E5C
		public StyleProperty currentProperty
		{
			get
			{
				return this.m_CurrentProperty;
			}
		}

		// Token: 0x060024A8 RID: 9384 RVA: 0x00099C64 File Offset: 0x00097E64
		public StyleRule BeginRule(int ruleLine)
		{
			StyleSheetBuilder.Log("Beginning rule");
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.Init);
			this.m_BuilderState = StyleSheetBuilder.BuilderState.Rule;
			this.m_CurrentRule = new StyleRule
			{
				line = ruleLine
			};
			return this.m_CurrentRule;
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x00099CB0 File Offset: 0x00097EB0
		public StyleSheetBuilder.ComplexSelectorScope BeginComplexSelector(int specificity)
		{
			StyleSheetBuilder.Log("Begin complex selector with specificity " + specificity.ToString());
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.Rule);
			this.m_BuilderState = StyleSheetBuilder.BuilderState.ComplexSelector;
			this.m_CurrentComplexSelector = new StyleComplexSelector();
			this.m_CurrentComplexSelector.specificity = specificity;
			this.m_CurrentComplexSelector.ruleIndex = this.m_Rules.Count;
			return new StyleSheetBuilder.ComplexSelectorScope(this);
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x00099D24 File Offset: 0x00097F24
		public void AddSimpleSelector(StyleSelectorPart[] parts, StyleSelectorRelationship previousRelationsip)
		{
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.ComplexSelector);
			StyleSelector styleSelector = new StyleSelector();
			styleSelector.parts = parts;
			styleSelector.previousRelationship = previousRelationsip;
			string str = "Add simple selector ";
			StyleSelector styleSelector2 = styleSelector;
			StyleSheetBuilder.Log(str + ((styleSelector2 != null) ? styleSelector2.ToString() : null));
			this.m_CurrentSelectors.Add(styleSelector);
		}

		// Token: 0x060024AB RID: 9387 RVA: 0x00099D84 File Offset: 0x00097F84
		public void EndComplexSelector()
		{
			StyleSheetBuilder.Log("Ending complex selector");
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.ComplexSelector);
			this.m_BuilderState = StyleSheetBuilder.BuilderState.Rule;
			bool flag = this.m_CurrentSelectors.Count > 0;
			if (flag)
			{
				this.m_CurrentComplexSelector.selectors = this.m_CurrentSelectors.ToArray();
				this.m_ComplexSelectors.Add(this.m_CurrentComplexSelector);
				this.m_CurrentSelectors.Clear();
			}
			this.m_CurrentComplexSelector = null;
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x00099E04 File Offset: 0x00098004
		public StyleProperty BeginProperty(string name, int line = -1)
		{
			StyleSheetBuilder.Log("Begin property named " + name);
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.Rule);
			this.m_BuilderState = StyleSheetBuilder.BuilderState.Property;
			this.m_CurrentProperty = new StyleProperty
			{
				name = name,
				line = line
			};
			this.m_CurrentProperties.Add(this.m_CurrentProperty);
			return this.m_CurrentProperty;
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x00099E70 File Offset: 0x00098070
		public void AddImport(StyleSheet.ImportStruct importStruct)
		{
			this.m_Imports.Add(importStruct);
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x00099E80 File Offset: 0x00098080
		public void AddValue(float value)
		{
			this.RegisterValue<float>(this.m_Floats, StyleValueType.Float, value);
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x00099E92 File Offset: 0x00098092
		public void AddValue(Dimension value)
		{
			this.RegisterValue<Dimension>(this.m_Dimensions, StyleValueType.Dimension, value);
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x00099EA4 File Offset: 0x000980A4
		public void AddValue(StyleValueKeyword keyword)
		{
			this.m_CurrentValues.Add(new StyleValueHandle((int)keyword, StyleValueType.Keyword));
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x00099EBA File Offset: 0x000980BA
		public void AddValue(StyleValueFunction function)
		{
			this.m_CurrentValues.Add(new StyleValueHandle((int)function, StyleValueType.Function));
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x00099ED1 File Offset: 0x000980D1
		public void AddCommaSeparator()
		{
			this.m_CurrentValues.Add(new StyleValueHandle(0, StyleValueType.CommaSeparator));
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x00099EE8 File Offset: 0x000980E8
		public void AddValue(string value, StyleValueType type)
		{
			bool flag = type == StyleValueType.Variable;
			if (flag)
			{
				this.RegisterVariable(value);
			}
			else
			{
				this.RegisterValue<string>(this.m_Strings, type, value);
			}
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x00099F17 File Offset: 0x00098117
		public void AddValue(Color value)
		{
			this.RegisterValue<Color>(this.m_Colors, StyleValueType.Color, value);
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x00099F29 File Offset: 0x00098129
		public void AddValue(Object value)
		{
			this.RegisterValue<Object>(this.m_Assets, StyleValueType.AssetReference, value);
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x00099F3B File Offset: 0x0009813B
		public void AddValue(ScalableImage value)
		{
			this.RegisterValue<ScalableImage>(this.m_ScalableImages, StyleValueType.ScalableImage, value);
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x00099F50 File Offset: 0x00098150
		public void EndProperty()
		{
			StyleSheetBuilder.Log("Ending property");
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.Property);
			this.m_BuilderState = StyleSheetBuilder.BuilderState.Rule;
			this.m_CurrentProperty.values = this.m_CurrentValues.ToArray();
			this.m_CurrentProperty = null;
			this.m_CurrentValues.Clear();
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x00099FAC File Offset: 0x000981AC
		public int EndRule()
		{
			StyleSheetBuilder.Log("Ending rule");
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.Rule);
			this.m_BuilderState = StyleSheetBuilder.BuilderState.Init;
			this.m_CurrentRule.properties = this.m_CurrentProperties.ToArray();
			this.m_Rules.Add(this.m_CurrentRule);
			this.m_CurrentRule = null;
			this.m_CurrentProperties.Clear();
			return this.m_Rules.Count - 1;
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x0009A028 File Offset: 0x00098228
		public void BuildTo(StyleSheet writeTo)
		{
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.Init);
			writeTo.floats = this.m_Floats.ToArray();
			writeTo.dimensions = this.m_Dimensions.ToArray();
			writeTo.colors = this.m_Colors.ToArray();
			writeTo.strings = this.m_Strings.ToArray();
			writeTo.rules = this.m_Rules.ToArray();
			writeTo.assets = this.m_Assets.ToArray();
			writeTo.scalableImages = this.m_ScalableImages.ToArray();
			writeTo.complexSelectors = this.m_ComplexSelectors.ToArray();
			writeTo.imports = this.m_Imports.ToArray();
			bool flag = writeTo.imports.Length != 0;
			if (flag)
			{
				writeTo.FlattenImportedStyleSheetsRecursive();
			}
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x0009A0F8 File Offset: 0x000982F8
		private void RegisterVariable(string value)
		{
			StyleSheetBuilder.Log("Add variable : " + value);
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.Property);
			int num = this.m_Strings.IndexOf(value);
			bool flag = num < 0;
			if (flag)
			{
				this.m_Strings.Add(value);
				num = this.m_Strings.Count - 1;
			}
			this.m_CurrentValues.Add(new StyleValueHandle(num, StyleValueType.Variable));
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x0009A16C File Offset: 0x0009836C
		private void RegisterValue<T>(List<T> list, StyleValueType type, T value)
		{
			string str = "Add value of type ";
			string str2 = type.ToString();
			string str3 = " : ";
			T t = value;
			StyleSheetBuilder.Log(str + str2 + str3 + ((t != null) ? t.ToString() : null));
			Debug.Assert(this.m_BuilderState == StyleSheetBuilder.BuilderState.Property);
			list.Add(value);
			this.m_CurrentValues.Add(new StyleValueHandle(list.Count - 1, type));
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x00003CD2 File Offset: 0x00001ED2
		private static void Log(string msg)
		{
		}

		// Token: 0x04001194 RID: 4500
		private StyleSheetBuilder.BuilderState m_BuilderState;

		// Token: 0x04001195 RID: 4501
		private List<float> m_Floats = new List<float>();

		// Token: 0x04001196 RID: 4502
		private List<Dimension> m_Dimensions = new List<Dimension>();

		// Token: 0x04001197 RID: 4503
		private List<Color> m_Colors = new List<Color>();

		// Token: 0x04001198 RID: 4504
		private List<string> m_Strings = new List<string>();

		// Token: 0x04001199 RID: 4505
		private List<StyleRule> m_Rules = new List<StyleRule>();

		// Token: 0x0400119A RID: 4506
		private List<Object> m_Assets = new List<Object>();

		// Token: 0x0400119B RID: 4507
		private List<ScalableImage> m_ScalableImages = new List<ScalableImage>();

		// Token: 0x0400119C RID: 4508
		private List<StyleComplexSelector> m_ComplexSelectors = new List<StyleComplexSelector>();

		// Token: 0x0400119D RID: 4509
		private List<StyleProperty> m_CurrentProperties = new List<StyleProperty>();

		// Token: 0x0400119E RID: 4510
		private List<StyleValueHandle> m_CurrentValues = new List<StyleValueHandle>();

		// Token: 0x0400119F RID: 4511
		private StyleComplexSelector m_CurrentComplexSelector;

		// Token: 0x040011A0 RID: 4512
		private List<StyleSelector> m_CurrentSelectors = new List<StyleSelector>();

		// Token: 0x040011A1 RID: 4513
		private StyleProperty m_CurrentProperty;

		// Token: 0x040011A2 RID: 4514
		private StyleRule m_CurrentRule;

		// Token: 0x040011A3 RID: 4515
		private List<StyleSheet.ImportStruct> m_Imports = new List<StyleSheet.ImportStruct>();

		// Token: 0x02000495 RID: 1173
		public struct ComplexSelectorScope : IDisposable
		{
			// Token: 0x060024BE RID: 9406 RVA: 0x0009A280 File Offset: 0x00098480
			public ComplexSelectorScope(StyleSheetBuilder builder)
			{
				this.m_Builder = builder;
			}

			// Token: 0x060024BF RID: 9407 RVA: 0x0009A28A File Offset: 0x0009848A
			public void Dispose()
			{
				this.m_Builder.EndComplexSelector();
			}

			// Token: 0x040011A4 RID: 4516
			private StyleSheetBuilder m_Builder;
		}

		// Token: 0x02000496 RID: 1174
		private enum BuilderState
		{
			// Token: 0x040011A6 RID: 4518
			Init,
			// Token: 0x040011A7 RID: 4519
			Rule,
			// Token: 0x040011A8 RID: 4520
			ComplexSelector,
			// Token: 0x040011A9 RID: 4521
			Property
		}
	}
}
