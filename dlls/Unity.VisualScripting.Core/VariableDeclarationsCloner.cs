using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000173 RID: 371
	public sealed class VariableDeclarationsCloner : Cloner<VariableDeclarations>
	{
		// Token: 0x060009E7 RID: 2535 RVA: 0x00029909 File Offset: 0x00027B09
		public override bool Handles(Type type)
		{
			return type == typeof(VariableDeclarations);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0002991B File Offset: 0x00027B1B
		public override VariableDeclarations ConstructClone(Type type, VariableDeclarations original)
		{
			return new VariableDeclarations();
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00029924 File Offset: 0x00027B24
		public override void FillClone(Type type, ref VariableDeclarations clone, VariableDeclarations original, CloningContext context)
		{
			foreach (VariableDeclaration variableDeclaration in original)
			{
				clone[variableDeclaration.name] = variableDeclaration.value.CloneViaFakeSerialization();
			}
		}

		// Token: 0x04000251 RID: 593
		public static readonly VariableDeclarationsCloner instance = new VariableDeclarationsCloner();
	}
}
