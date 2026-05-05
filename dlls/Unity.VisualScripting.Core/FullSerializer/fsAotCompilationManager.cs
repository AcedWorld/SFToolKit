using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000191 RID: 401
	public class fsAotCompilationManager
	{
		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x0002C688 File Offset: 0x0002A888
		public static Dictionary<Type, string> AvailableAotCompilations
		{
			get
			{
				for (int i = 0; i < fsAotCompilationManager._uncomputedAotCompilations.Count; i++)
				{
					fsAotCompilationManager.AotCompilation aotCompilation = fsAotCompilationManager._uncomputedAotCompilations[i];
					fsAotCompilationManager._computedAotCompilations[aotCompilation.Type] = fsAotCompilationManager.GenerateDirectConverterForTypeInCSharp(aotCompilation.Type, aotCompilation.Members, aotCompilation.IsConstructorPublic);
				}
				fsAotCompilationManager._uncomputedAotCompilations.Clear();
				return fsAotCompilationManager._computedAotCompilations;
			}
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0002C6EC File Offset: 0x0002A8EC
		public static bool TryToPerformAotCompilation(fsConfig config, Type type, out string aotCompiledClassInCSharp)
		{
			if (fsMetaType.Get(config, type).EmitAotData())
			{
				aotCompiledClassInCSharp = fsAotCompilationManager.AvailableAotCompilations[type];
				return true;
			}
			aotCompiledClassInCSharp = null;
			return false;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0002C710 File Offset: 0x0002A910
		public static void AddAotCompilation(Type type, fsMetaProperty[] members, bool isConstructorPublic)
		{
			fsAotCompilationManager._uncomputedAotCompilations.Add(new fsAotCompilationManager.AotCompilation
			{
				Type = type,
				Members = members,
				IsConstructorPublic = isConstructorPublic
			});
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0002C748 File Offset: 0x0002A948
		private static string GetConverterString(fsMetaProperty member)
		{
			if (member.OverrideConverterType == null)
			{
				return "null";
			}
			return "typeof(" + member.OverrideConverterType.CSharpName(true) + ")";
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0002C77C File Offset: 0x0002A97C
		private static string GenerateDirectConverterForTypeInCSharp(Type type, fsMetaProperty[] members, bool isConstructorPublic)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = type.CSharpName(true);
			string text2 = type.CSharpName(true, true);
			stringBuilder.AppendLine("using System;");
			stringBuilder.AppendLine("using System.Collections.Generic;");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("namespace Unity.VisualScripting.Dependencies.FullSerializer {");
			stringBuilder.AppendLine("    partial class fsConverterRegistrar {");
			stringBuilder.AppendLine(string.Concat(new string[]
			{
				"        public static Speedup.",
				text2,
				"_DirectConverter Register_",
				text2,
				";"
			}));
			stringBuilder.AppendLine("    }");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("namespace Unity.VisualScripting.Dependencies.FullSerializer.Speedup {");
			stringBuilder.AppendLine(string.Concat(new string[]
			{
				"    public class ",
				text2,
				"_DirectConverter : fsDirectConverter<",
				text,
				"> {"
			}));
			stringBuilder.AppendLine("        protected override fsResult DoSerialize(" + text + " model, Dictionary<string, fsData> serialized) {");
			stringBuilder.AppendLine("            var result = fsResult.Success;");
			stringBuilder.AppendLine();
			foreach (fsMetaProperty fsMetaProperty in members)
			{
				stringBuilder.AppendLine(string.Concat(new string[]
				{
					"            result += SerializeMember(serialized, ",
					fsAotCompilationManager.GetConverterString(fsMetaProperty),
					", \"",
					fsMetaProperty.JsonName,
					"\", model.",
					fsMetaProperty.MemberName,
					");"
				}));
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("            return result;");
			stringBuilder.AppendLine("        }");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("        protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref " + text + " model) {");
			stringBuilder.AppendLine("            var result = fsResult.Success;");
			stringBuilder.AppendLine();
			for (int j = 0; j < members.Length; j++)
			{
				fsMetaProperty fsMetaProperty2 = members[j];
				stringBuilder.AppendLine(string.Concat(new string[]
				{
					"            var t",
					j.ToString(),
					" = model.",
					fsMetaProperty2.MemberName,
					";"
				}));
				stringBuilder.AppendLine(string.Concat(new string[]
				{
					"            result += DeserializeMember(data, ",
					fsAotCompilationManager.GetConverterString(fsMetaProperty2),
					", \"",
					fsMetaProperty2.JsonName,
					"\", out t",
					j.ToString(),
					");"
				}));
				stringBuilder.AppendLine(string.Concat(new string[]
				{
					"            model.",
					fsMetaProperty2.MemberName,
					" = t",
					j.ToString(),
					";"
				}));
				stringBuilder.AppendLine();
			}
			stringBuilder.AppendLine("            return result;");
			stringBuilder.AppendLine("        }");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("        public override object CreateInstance(fsData data, Type storageType) {");
			if (isConstructorPublic)
			{
				stringBuilder.AppendLine("            return new " + text + "();");
			}
			else
			{
				stringBuilder.AppendLine("            return Activator.CreateInstance(typeof(" + text + "), /*nonPublic:*/true);");
			}
			stringBuilder.AppendLine("        }");
			stringBuilder.AppendLine("    }");
			stringBuilder.AppendLine("}");
			return stringBuilder.ToString();
		}

		// Token: 0x0400026A RID: 618
		private static Dictionary<Type, string> _computedAotCompilations = new Dictionary<Type, string>();

		// Token: 0x0400026B RID: 619
		private static List<fsAotCompilationManager.AotCompilation> _uncomputedAotCompilations = new List<fsAotCompilationManager.AotCompilation>();

		// Token: 0x0200021D RID: 541
		private struct AotCompilation
		{
			// Token: 0x040009D9 RID: 2521
			public Type Type;

			// Token: 0x040009DA RID: 2522
			public fsMetaProperty[] Members;

			// Token: 0x040009DB RID: 2523
			public bool IsConstructorPublic;
		}
	}
}
