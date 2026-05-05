using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine.Bindings;

namespace UnityEngine.TestTools
{
	// Token: 0x020004B4 RID: 1204
	[NativeType(CodegenOptions.Custom, "ManagedCoveredMethodStats", Header = "Runtime/Scripting/ScriptingCoverage.bindings.h")]
	public struct CoveredMethodStats
	{
		// Token: 0x06002AA1 RID: 10913 RVA: 0x000476B0 File Offset: 0x000458B0
		private string GetTypeDisplayName(Type t)
		{
			bool flag = t == typeof(int);
			string result;
			if (flag)
			{
				result = "int";
			}
			else
			{
				bool flag2 = t == typeof(bool);
				if (flag2)
				{
					result = "bool";
				}
				else
				{
					bool flag3 = t == typeof(float);
					if (flag3)
					{
						result = "float";
					}
					else
					{
						bool flag4 = t == typeof(double);
						if (flag4)
						{
							result = "double";
						}
						else
						{
							bool flag5 = t == typeof(void);
							if (flag5)
							{
								result = "void";
							}
							else
							{
								bool flag6 = t == typeof(string);
								if (flag6)
								{
									result = "string";
								}
								else
								{
									bool flag7 = t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>);
									if (flag7)
									{
										result = "System.Collections.Generic.List<" + this.GetTypeDisplayName(t.GetGenericArguments()[0]) + ">";
									}
									else
									{
										bool flag8 = t.IsArray && t.GetArrayRank() == 1;
										if (flag8)
										{
											result = this.GetTypeDisplayName(t.GetElementType()) + "[]";
										}
										else
										{
											result = t.FullName;
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06002AA2 RID: 10914 RVA: 0x00047804 File Offset: 0x00045A04
		public override string ToString()
		{
			bool flag = this.method == null;
			string result;
			if (flag)
			{
				result = "<no method>";
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.GetTypeDisplayName(this.method.DeclaringType));
				stringBuilder.Append(".");
				stringBuilder.Append(this.method.Name);
				stringBuilder.Append("(");
				bool flag2 = false;
				foreach (ParameterInfo parameterInfo in this.method.GetParameters())
				{
					bool flag3 = flag2;
					if (flag3)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(this.GetTypeDisplayName(parameterInfo.ParameterType));
					stringBuilder.Append(" ");
					stringBuilder.Append(parameterInfo.Name);
					flag2 = true;
				}
				stringBuilder.Append(")");
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x04000F92 RID: 3986
		public MethodBase method;

		// Token: 0x04000F93 RID: 3987
		public int totalSequencePoints;

		// Token: 0x04000F94 RID: 3988
		public int uncoveredSequencePoints;
	}
}
