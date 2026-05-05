using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200000A RID: 10
	public sealed class UnitRelation : IUnitRelation, IConnection<IUnitPort, IUnitPort>
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00002688 File Offset: 0x00000888
		public UnitRelation(IUnitPort source, IUnitPort destination)
		{
			Ensure.That("source").IsNotNull<IUnitPort>(source);
			Ensure.That("destination").IsNotNull<IUnitPort>(destination);
			if (source.unit != destination.unit)
			{
				throw new NotSupportedException("Cannot create relations across nodes.");
			}
			this.source = source;
			this.destination = destination;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000026E2 File Offset: 0x000008E2
		public IUnitPort source { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000026EA File Offset: 0x000008EA
		public IUnitPort destination { get; }
	}
}
