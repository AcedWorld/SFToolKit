using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000029 RID: 41
	internal static class MigrationStep
	{
		// Token: 0x06000059 RID: 89 RVA: 0x0000479D File Offset: 0x0000299D
		public static MigrationStep<TVersion, TTarget> New<TVersion, TTarget>(TVersion version, Action<TTarget> action) where TVersion : struct, IConvertible where TTarget : class, IVersionable<TVersion>
		{
			return new MigrationStep<TVersion, TTarget>(version, action);
		}
	}
}
