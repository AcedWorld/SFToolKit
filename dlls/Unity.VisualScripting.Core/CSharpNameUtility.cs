using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000152 RID: 338
	public static class CSharpNameUtility
	{
		// Token: 0x06000916 RID: 2326 RVA: 0x00027394 File Offset: 0x00025594
		public static string CSharpName(this MemberInfo member, ActionDirection direction)
		{
			if (member is MethodInfo && ((MethodInfo)member).IsOperator())
			{
				return CSharpNameUtility.operators[member.Name] + " operator";
			}
			if (member is ConstructorInfo)
			{
				return "new " + member.DeclaringType.CSharpName(true);
			}
			if ((member is FieldInfo || member is PropertyInfo) && direction != ActionDirection.Any)
			{
				return member.Name + " (" + direction.ToString().ToLower() + ")";
			}
			return member.Name;
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00027431 File Offset: 0x00025631
		public static string CSharpName(this Type type, bool includeGenericParameters = true)
		{
			return type.CSharpName(TypeQualifier.Name, includeGenericParameters);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0002743B File Offset: 0x0002563B
		public static string CSharpFullName(this Type type, bool includeGenericParameters = true)
		{
			return type.CSharpName(TypeQualifier.Namespace, includeGenericParameters);
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00027445 File Offset: 0x00025645
		public static string CSharpUniqueName(this Type type, bool includeGenericParameters = true)
		{
			return type.CSharpName(TypeQualifier.GlobalNamespace, includeGenericParameters);
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00027450 File Offset: 0x00025650
		public static string CSharpFileName(this Type type, bool includeNamespace, bool includeGenericParameters = false)
		{
			string text = type.CSharpName(includeNamespace ? TypeQualifier.Namespace : TypeQualifier.Name, includeGenericParameters);
			if (!includeGenericParameters && type.IsGenericType && text.Contains('<'))
			{
				text = text.Substring(0, text.IndexOf('<'));
			}
			return text.ReplaceMultiple(CSharpNameUtility.illegalTypeFileNameCharacters, '_').Trim('_').RemoveConsecutiveCharacters('_');
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x000274B0 File Offset: 0x000256B0
		private static string CSharpName(this Type type, TypeQualifier qualifier, bool includeGenericParameters = true)
		{
			if (CSharpNameUtility.primitives.ContainsKey(type))
			{
				return CSharpNameUtility.primitives[type];
			}
			if (type.IsGenericParameter)
			{
				if (!includeGenericParameters)
				{
					return "";
				}
				return type.Name;
			}
			else
			{
				if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					return Nullable.GetUnderlyingType(type).CSharpName(qualifier, includeGenericParameters) + "?";
				}
				string text = type.Name;
				if (type.IsGenericType && text.Contains('`'))
				{
					text = text.Substring(0, text.IndexOf('`'));
				}
				IEnumerable<Type> genericArguments = type.GetGenericArguments();
				if (type.IsNested)
				{
					text = type.DeclaringType.CSharpName(qualifier, includeGenericParameters) + "." + text;
					if (type.DeclaringType.IsGenericType)
					{
						genericArguments.Skip(type.DeclaringType.GetGenericArguments().Length);
					}
				}
				if (!type.IsNested)
				{
					if ((qualifier == TypeQualifier.Namespace || qualifier == TypeQualifier.GlobalNamespace) && type.Namespace != null)
					{
						text = type.Namespace + "." + text;
					}
					if (qualifier == TypeQualifier.GlobalNamespace)
					{
						text = "global::" + text;
					}
				}
				if (genericArguments.Any<Type>())
				{
					text += "<";
					text += string.Join(includeGenericParameters ? ", " : ",", (from t in genericArguments
					select t.CSharpName(qualifier, includeGenericParameters)).ToArray<string>());
					text += ">";
				}
				return text;
			}
		}

		// Token: 0x04000228 RID: 552
		private static readonly Dictionary<Type, string> primitives = new Dictionary<Type, string>
		{
			{
				typeof(byte),
				"byte"
			},
			{
				typeof(sbyte),
				"sbyte"
			},
			{
				typeof(short),
				"short"
			},
			{
				typeof(ushort),
				"ushort"
			},
			{
				typeof(int),
				"int"
			},
			{
				typeof(uint),
				"uint"
			},
			{
				typeof(long),
				"long"
			},
			{
				typeof(ulong),
				"ulong"
			},
			{
				typeof(float),
				"float"
			},
			{
				typeof(double),
				"double"
			},
			{
				typeof(decimal),
				"decimal"
			},
			{
				typeof(string),
				"string"
			},
			{
				typeof(char),
				"char"
			},
			{
				typeof(bool),
				"bool"
			},
			{
				typeof(void),
				"void"
			},
			{
				typeof(object),
				"object"
			}
		};

		// Token: 0x04000229 RID: 553
		public static readonly Dictionary<string, string> operators = new Dictionary<string, string>
		{
			{
				"op_Addition",
				"+"
			},
			{
				"op_Subtraction",
				"-"
			},
			{
				"op_Multiply",
				"*"
			},
			{
				"op_Division",
				"/"
			},
			{
				"op_Modulus",
				"%"
			},
			{
				"op_ExclusiveOr",
				"^"
			},
			{
				"op_BitwiseAnd",
				"&"
			},
			{
				"op_BitwiseOr",
				"|"
			},
			{
				"op_LogicalAnd",
				"&&"
			},
			{
				"op_LogicalOr",
				"||"
			},
			{
				"op_Assign",
				"="
			},
			{
				"op_LeftShift",
				"<<"
			},
			{
				"op_RightShift",
				">>"
			},
			{
				"op_Equality",
				"=="
			},
			{
				"op_GreaterThan",
				">"
			},
			{
				"op_LessThan",
				"<"
			},
			{
				"op_Inequality",
				"!="
			},
			{
				"op_GreaterThanOrEqual",
				">="
			},
			{
				"op_LessThanOrEqual",
				"<="
			},
			{
				"op_MultiplicationAssignment",
				"*="
			},
			{
				"op_SubtractionAssignment",
				"-="
			},
			{
				"op_ExclusiveOrAssignment",
				"^="
			},
			{
				"op_LeftShiftAssignment",
				"<<="
			},
			{
				"op_ModulusAssignment",
				"%="
			},
			{
				"op_AdditionAssignment",
				"+="
			},
			{
				"op_BitwiseAndAssignment",
				"&="
			},
			{
				"op_BitwiseOrAssignment",
				"|="
			},
			{
				"op_Comma",
				","
			},
			{
				"op_DivisionAssignment",
				"/="
			},
			{
				"op_Decrement",
				"--"
			},
			{
				"op_Increment",
				"++"
			},
			{
				"op_UnaryNegation",
				"-"
			},
			{
				"op_UnaryPlus",
				"+"
			},
			{
				"op_OnesComplement",
				"~"
			}
		};

		// Token: 0x0400022A RID: 554
		private static readonly HashSet<char> illegalTypeFileNameCharacters = new HashSet<char>
		{
			'<',
			'>',
			'?',
			' ',
			',',
			':'
		};
	}
}
