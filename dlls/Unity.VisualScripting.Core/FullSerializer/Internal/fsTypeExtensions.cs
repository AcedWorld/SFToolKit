using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting.FullSerializer.Internal
{
	// Token: 0x020001B1 RID: 433
	public static class fsTypeExtensions
	{
		// Token: 0x06000B94 RID: 2964 RVA: 0x00031047 File Offset: 0x0002F247
		public static string CSharpName(this Type type)
		{
			return type.CSharpName(false);
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x00031050 File Offset: 0x0002F250
		public static string CSharpName(this Type type, bool includeNamespace, bool ensureSafeDeclarationName)
		{
			string text = type.CSharpName(includeNamespace);
			if (ensureSafeDeclarationName)
			{
				text = text.Replace('>', '_').Replace('<', '_').Replace('.', '_');
			}
			return text;
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x00031088 File Offset: 0x0002F288
		public static string CSharpName(this Type type, bool includeNamespace)
		{
			if (type == typeof(void))
			{
				return "void";
			}
			if (type == typeof(int))
			{
				return "int";
			}
			if (type == typeof(float))
			{
				return "float";
			}
			if (type == typeof(bool))
			{
				return "bool";
			}
			if (type == typeof(double))
			{
				return "double";
			}
			if (type == typeof(string))
			{
				return "string";
			}
			if (type.IsGenericParameter)
			{
				return type.ToString();
			}
			string text = "";
			IEnumerable<Type> source = type.GetGenericArguments();
			if (type.IsNested)
			{
				text = text + type.DeclaringType.CSharpName() + ".";
				if (type.DeclaringType.GetGenericArguments().Length != 0)
				{
					source = source.Skip(type.DeclaringType.GetGenericArguments().Length);
				}
			}
			if (!source.Any<Type>())
			{
				text += type.Name;
			}
			else
			{
				int num = type.Name.IndexOf('`');
				if (num > 0)
				{
					text += type.Name.Substring(0, num);
				}
				text = text + "<" + string.Join(",", (from t in source
				select t.CSharpName(includeNamespace)).ToArray<string>()) + ">";
			}
			if (includeNamespace && type.Namespace != null)
			{
				text = type.Namespace + "." + text;
			}
			return text;
		}
	}
}
