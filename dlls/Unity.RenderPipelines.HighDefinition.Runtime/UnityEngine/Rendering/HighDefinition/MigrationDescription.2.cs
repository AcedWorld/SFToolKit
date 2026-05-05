using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000028 RID: 40
	public struct MigrationDescription<TVersion, TTarget> where TVersion : struct, IConvertible where TTarget : class, IVersionable<TVersion>
	{
		// Token: 0x06000053 RID: 83 RVA: 0x0000464B File Offset: 0x0000284B
		public MigrationDescription(params MigrationStep<TVersion, TTarget>[] steps)
		{
			Array.Sort<MigrationStep<TVersion, TTarget>>(steps, (MigrationStep<TVersion, TTarget> l, MigrationStep<TVersion, TTarget> r) => MigrationDescription<TVersion, TTarget>.Compare(l.Version, r.Version));
			this.Steps = steps;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000467C File Offset: 0x0000287C
		public bool Migrate(TTarget target)
		{
			if (this.IsLastVersionOrAbove(target.version))
			{
				return false;
			}
			for (int i = 0; i < this.Steps.Length; i++)
			{
				if (MigrationDescription<TVersion, TTarget>.Compare(target.version, this.Steps[i].Version) < 0)
				{
					this.Steps[i].Migrate(target);
					target.version = this.Steps[i].Version;
				}
			}
			return true;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004704 File Offset: 0x00002904
		public void ExecuteStep(TTarget target, TVersion stepVersion)
		{
			for (int i = 0; i < this.Steps.Length; i++)
			{
				if (MigrationDescription<TVersion, TTarget>.Equals(this.Steps[i].Version, stepVersion))
				{
					this.Steps[i].Migrate(target);
					return;
				}
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004750 File Offset: 0x00002950
		private static bool Equals(TVersion l, TVersion r)
		{
			return MigrationDescription<TVersion, TTarget>.Compare(l, r) == 0;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000475C File Offset: 0x0000295C
		private static int Compare(TVersion l, TVersion r)
		{
			return (int)((object)l) - (int)((object)r);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004775 File Offset: 0x00002975
		private bool IsLastVersionOrAbove(TVersion target)
		{
			return MigrationDescription<TVersion, TTarget>.Compare(target, this.Steps[this.Steps.Length - 1].Version) >= 0;
		}

		// Token: 0x040000AC RID: 172
		private readonly MigrationStep<TVersion, TTarget>[] Steps;
	}
}
