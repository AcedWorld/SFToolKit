using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
	// Token: 0x020000AF RID: 175
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
	public class GenerateHLSL : Attribute
	{
		// Token: 0x06000556 RID: 1366 RVA: 0x0001B804 File Offset: 0x00019A04
		public GenerateHLSL(PackingRules rules = PackingRules.Exact, bool needAccessors = true, bool needSetters = false, bool needParamDebug = false, int paramDefinesStart = 1, bool omitStructDeclaration = false, bool containsPackedFields = false, bool generateCBuffer = false, int constantRegister = -1, [CallerFilePath] string sourcePath = null)
		{
			this.sourcePath = sourcePath;
			this.packingRules = rules;
			this.needAccessors = needAccessors;
			this.needSetters = needSetters;
			this.needParamDebug = needParamDebug;
			this.paramDefinesStart = paramDefinesStart;
			this.omitStructDeclaration = omitStructDeclaration;
			this.containsPackedFields = containsPackedFields;
			this.generateCBuffer = generateCBuffer;
			this.constantRegister = constantRegister;
		}

		// Token: 0x040003D8 RID: 984
		public PackingRules packingRules;

		// Token: 0x040003D9 RID: 985
		public bool containsPackedFields;

		// Token: 0x040003DA RID: 986
		public bool needAccessors;

		// Token: 0x040003DB RID: 987
		public bool needSetters;

		// Token: 0x040003DC RID: 988
		public bool needParamDebug;

		// Token: 0x040003DD RID: 989
		public int paramDefinesStart;

		// Token: 0x040003DE RID: 990
		public bool omitStructDeclaration;

		// Token: 0x040003DF RID: 991
		public bool generateCBuffer;

		// Token: 0x040003E0 RID: 992
		public int constantRegister;

		// Token: 0x040003E1 RID: 993
		public string sourcePath;
	}
}
