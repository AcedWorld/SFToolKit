using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200002A RID: 42
	public struct MigrationStep<TVersion, TTarget> : IEquatable<MigrationStep<TVersion, TTarget>> where TVersion : struct, IConvertible where TTarget : class, IVersionable<TVersion>
	{
		// Token: 0x0600005A RID: 90 RVA: 0x000047A6 File Offset: 0x000029A6
		public MigrationStep(TVersion version, Action<TTarget> action)
		{
			this.Version = version;
			this.m_MigrationAction = action;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000047B8 File Offset: 0x000029B8
		public void Migrate(TTarget target)
		{
			if ((int)((object)target.version) >= (int)((object)this.Version))
			{
				return;
			}
			this.m_MigrationAction(target);
			target.version = this.Version;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000480C File Offset: 0x00002A0C
		public bool Equals(MigrationStep<TVersion, TTarget> other)
		{
			TVersion version = this.Version;
			return version.Equals(other.Version);
		}

		// Token: 0x040000AD RID: 173
		private readonly Action<TTarget> m_MigrationAction;

		// Token: 0x040000AE RID: 174
		public readonly TVersion Version;
	}
}
