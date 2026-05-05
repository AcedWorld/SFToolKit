using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000027 RID: 39
	internal static class MigrationDescription
	{
		// Token: 0x06000051 RID: 81 RVA: 0x0000463C File Offset: 0x0000283C
		public static T LastVersion<T>() where T : struct, IConvertible
		{
			return TypeInfo.GetEnumLastValue<T>();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004643 File Offset: 0x00002843
		public static MigrationDescription<TVersion, TTarget> New<TVersion, TTarget>(params MigrationStep<TVersion, TTarget>[] steps) where TVersion : struct, IConvertible where TTarget : class, IVersionable<TVersion>
		{
			return new MigrationDescription<TVersion, TTarget>(steps);
		}
	}
}
