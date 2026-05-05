using System;
using System.Collections.Generic;
using UnityEngine.UIElements.StyleSheets;
using UnityEngine.UIElements.StyleSheets.Syntax;

namespace UnityEngine.UIElements
{
	// Token: 0x02000361 RID: 865
	internal class StyleVariableResolver
	{
		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x06001CCA RID: 7370 RVA: 0x0006FB21 File Offset: 0x0006DD21
		private StyleSheet currentSheet
		{
			get
			{
				return this.m_CurrentContext.sheet;
			}
		}

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x06001CCB RID: 7371 RVA: 0x0006FB2E File Offset: 0x0006DD2E
		private StyleValueHandle[] currentHandles
		{
			get
			{
				return this.m_CurrentContext.handles;
			}
		}

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x06001CCC RID: 7372 RVA: 0x0006FB3B File Offset: 0x0006DD3B
		public List<StylePropertyValue> resolvedValues
		{
			get
			{
				return this.m_ResolvedValues;
			}
		}

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x06001CCD RID: 7373 RVA: 0x0006FB43 File Offset: 0x0006DD43
		// (set) Token: 0x06001CCE RID: 7374 RVA: 0x0006FB4B File Offset: 0x0006DD4B
		public StyleVariableContext variableContext { get; set; }

		// Token: 0x06001CCF RID: 7375 RVA: 0x0006FB54 File Offset: 0x0006DD54
		public void Init(StyleProperty property, StyleSheet sheet, StyleValueHandle[] handles)
		{
			this.m_ResolvedValues.Clear();
			this.m_ContextStack.Clear();
			this.m_Property = property;
			this.PushContext(sheet, handles);
		}

		// Token: 0x06001CD0 RID: 7376 RVA: 0x0006FB80 File Offset: 0x0006DD80
		private void PushContext(StyleSheet sheet, StyleValueHandle[] handles)
		{
			this.m_CurrentContext = new StyleVariableResolver.ResolveContext
			{
				sheet = sheet,
				handles = handles
			};
			this.m_ContextStack.Push(this.m_CurrentContext);
		}

		// Token: 0x06001CD1 RID: 7377 RVA: 0x0006FBBF File Offset: 0x0006DDBF
		private void PopContext()
		{
			this.m_ContextStack.Pop();
			this.m_CurrentContext = this.m_ContextStack.Peek();
		}

		// Token: 0x06001CD2 RID: 7378 RVA: 0x0006FBE0 File Offset: 0x0006DDE0
		public void AddValue(StyleValueHandle handle)
		{
			this.m_ResolvedValues.Add(new StylePropertyValue
			{
				sheet = this.currentSheet,
				handle = handle
			});
		}

		// Token: 0x06001CD3 RID: 7379 RVA: 0x0006FC18 File Offset: 0x0006DE18
		public bool ResolveVarFunction(ref int index)
		{
			this.m_ResolvedVarStack.Clear();
			int argc;
			string varName;
			StyleVariableResolver.ParseVarFunction(this.currentSheet, this.currentHandles, ref index, out argc, out varName);
			StyleVariableResolver.Result result = this.ResolveVarFunction(ref index, argc, varName);
			return result == StyleVariableResolver.Result.Valid;
		}

		// Token: 0x06001CD4 RID: 7380 RVA: 0x0006FC5C File Offset: 0x0006DE5C
		private StyleVariableResolver.Result ResolveVarFunction(ref int index, int argc, string varName)
		{
			StyleVariableResolver.Result result = this.ResolveVariable(varName);
			bool flag = result == StyleVariableResolver.Result.NotFound && argc > 1;
			if (flag)
			{
				StyleValueHandle[] currentHandles = this.currentHandles;
				int num = index + 1;
				index = num;
				StyleValueHandle styleValueHandle = currentHandles[num];
				Debug.Assert(styleValueHandle.valueType == StyleValueType.CommaSeparator, string.Format("Unexpected value type {0} in var function", styleValueHandle.valueType));
				bool flag2 = styleValueHandle.valueType == StyleValueType.CommaSeparator && index + 1 < this.currentHandles.Length;
				if (flag2)
				{
					index++;
					result = this.ResolveFallback(ref index);
				}
			}
			return result;
		}

		// Token: 0x06001CD5 RID: 7381 RVA: 0x0006FCF8 File Offset: 0x0006DEF8
		public bool ValidateResolvedValues()
		{
			bool isCustomProperty = this.m_Property.isCustomProperty;
			bool result;
			if (isCustomProperty)
			{
				result = true;
			}
			else
			{
				string syntax;
				bool flag = !StylePropertyCache.TryGetSyntax(this.m_Property.name, out syntax);
				if (flag)
				{
					Debug.LogAssertion("Unknown style property " + this.m_Property.name);
					result = false;
				}
				else
				{
					Expression exp = StyleVariableResolver.s_SyntaxParser.Parse(syntax);
					result = this.m_Matcher.Match(exp, this.m_ResolvedValues).success;
				}
			}
			return result;
		}

		// Token: 0x06001CD6 RID: 7382 RVA: 0x0006FD84 File Offset: 0x0006DF84
		private StyleVariableResolver.Result ResolveVariable(string variableName)
		{
			StyleVariable styleVariable;
			bool flag = !this.variableContext.TryFindVariable(variableName, out styleVariable);
			StyleVariableResolver.Result result;
			if (flag)
			{
				result = StyleVariableResolver.Result.NotFound;
			}
			else
			{
				bool flag2 = this.m_ResolvedVarStack.Contains(styleVariable.name);
				if (flag2)
				{
					result = StyleVariableResolver.Result.NotFound;
				}
				else
				{
					this.m_ResolvedVarStack.Push(styleVariable.name);
					StyleVariableResolver.Result result2 = StyleVariableResolver.Result.Valid;
					int num = 0;
					while (num < styleVariable.handles.Length && result2 == StyleVariableResolver.Result.Valid)
					{
						bool flag3 = this.m_ResolvedValues.Count + 1 > 100;
						if (flag3)
						{
							return StyleVariableResolver.Result.Invalid;
						}
						StyleValueHandle handle = styleVariable.handles[num];
						bool flag4 = handle.IsVarFunction();
						if (flag4)
						{
							this.PushContext(styleVariable.sheet, styleVariable.handles);
							int argc;
							string varName;
							StyleVariableResolver.ParseVarFunction(styleVariable.sheet, styleVariable.handles, ref num, out argc, out varName);
							result2 = this.ResolveVarFunction(ref num, argc, varName);
							this.PopContext();
						}
						else
						{
							this.m_ResolvedValues.Add(new StylePropertyValue
							{
								sheet = styleVariable.sheet,
								handle = handle
							});
						}
						num++;
					}
					this.m_ResolvedVarStack.Pop();
					result = result2;
				}
			}
			return result;
		}

		// Token: 0x06001CD7 RID: 7383 RVA: 0x0006FECC File Offset: 0x0006E0CC
		private StyleVariableResolver.Result ResolveFallback(ref int index)
		{
			StyleVariableResolver.Result result = StyleVariableResolver.Result.Valid;
			while (index < this.currentHandles.Length && result == StyleVariableResolver.Result.Valid)
			{
				StyleValueHandle handle = this.currentHandles[index];
				bool flag = handle.IsVarFunction();
				if (flag)
				{
					int num;
					string variableName;
					StyleVariableResolver.ParseVarFunction(this.currentSheet, this.currentHandles, ref index, out num, out variableName);
					result = this.ResolveVariable(variableName);
					bool flag2 = result == StyleVariableResolver.Result.NotFound;
					if (flag2)
					{
						bool flag3 = num > 1;
						if (flag3)
						{
							StyleValueHandle[] currentHandles = this.currentHandles;
							int num2 = index + 1;
							index = num2;
							handle = currentHandles[num2];
							Debug.Assert(handle.valueType == StyleValueType.CommaSeparator, string.Format("Unexpected value type {0} in var function", handle.valueType));
							bool flag4 = handle.valueType == StyleValueType.CommaSeparator && index + 1 < this.currentHandles.Length;
							if (flag4)
							{
								index++;
								result = this.ResolveFallback(ref index);
							}
						}
					}
				}
				else
				{
					this.m_ResolvedValues.Add(new StylePropertyValue
					{
						sheet = this.currentSheet,
						handle = handle
					});
				}
				index++;
			}
			return result;
		}

		// Token: 0x06001CD8 RID: 7384 RVA: 0x00070004 File Offset: 0x0006E204
		private static void ParseVarFunction(StyleSheet sheet, StyleValueHandle[] handles, ref int index, out int argCount, out string variableName)
		{
			int num = index + 1;
			index = num;
			argCount = (int)sheet.ReadFloat(handles[num]);
			num = index + 1;
			index = num;
			variableName = sheet.ReadVariable(handles[num]);
		}

		// Token: 0x04000C1A RID: 3098
		internal const int kMaxResolves = 100;

		// Token: 0x04000C1B RID: 3099
		private static StyleSyntaxParser s_SyntaxParser = new StyleSyntaxParser();

		// Token: 0x04000C1C RID: 3100
		private StylePropertyValueMatcher m_Matcher = new StylePropertyValueMatcher();

		// Token: 0x04000C1D RID: 3101
		private List<StylePropertyValue> m_ResolvedValues = new List<StylePropertyValue>();

		// Token: 0x04000C1E RID: 3102
		private Stack<string> m_ResolvedVarStack = new Stack<string>();

		// Token: 0x04000C1F RID: 3103
		private StyleProperty m_Property;

		// Token: 0x04000C20 RID: 3104
		private Stack<StyleVariableResolver.ResolveContext> m_ContextStack = new Stack<StyleVariableResolver.ResolveContext>();

		// Token: 0x04000C21 RID: 3105
		private StyleVariableResolver.ResolveContext m_CurrentContext;

		// Token: 0x02000362 RID: 866
		private enum Result
		{
			// Token: 0x04000C24 RID: 3108
			Valid,
			// Token: 0x04000C25 RID: 3109
			Invalid,
			// Token: 0x04000C26 RID: 3110
			NotFound
		}

		// Token: 0x02000363 RID: 867
		private struct ResolveContext
		{
			// Token: 0x04000C27 RID: 3111
			public StyleSheet sheet;

			// Token: 0x04000C28 RID: 3112
			public StyleValueHandle[] handles;
		}
	}
}
