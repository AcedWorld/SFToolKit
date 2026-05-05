using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200017A RID: 378
	public abstract class ValuePortDefinition : UnitPortDefinition, IUnitValuePortDefinition, IUnitPortDefinition
	{
		// Token: 0x17000374 RID: 884
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x00011AF1 File Offset: 0x0000FCF1
		// (set) Token: 0x060009E8 RID: 2536 RVA: 0x00011AF9 File Offset: 0x0000FCF9
		[SerializeAs("_type")]
		private Type _type { get; set; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x060009E9 RID: 2537 RVA: 0x00011B02 File Offset: 0x0000FD02
		// (set) Token: 0x060009EA RID: 2538 RVA: 0x00011B0A File Offset: 0x0000FD0A
		[Inspectable]
		[DoNotSerialize]
		public virtual Type type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x00011B13 File Offset: 0x0000FD13
		public override bool isValid
		{
			get
			{
				return base.isValid && this.type != null;
			}
		}
	}
}
