using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200004C RID: 76
	[UnitCategory("Control")]
	[UnitOrder(17)]
	[UnitFooterPorts(ControlOutputs = true)]
	public sealed class TryCatch : Unit
	{
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00008381 File Offset: 0x00006581
		// (set) Token: 0x06000309 RID: 777 RVA: 0x00008389 File Offset: 0x00006589
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600030A RID: 778 RVA: 0x00008392 File Offset: 0x00006592
		// (set) Token: 0x0600030B RID: 779 RVA: 0x0000839A File Offset: 0x0000659A
		[DoNotSerialize]
		public ControlOutput @try { get; private set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600030C RID: 780 RVA: 0x000083A3 File Offset: 0x000065A3
		// (set) Token: 0x0600030D RID: 781 RVA: 0x000083AB File Offset: 0x000065AB
		[DoNotSerialize]
		public ControlOutput @catch { get; private set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000083B4 File Offset: 0x000065B4
		// (set) Token: 0x0600030F RID: 783 RVA: 0x000083BC File Offset: 0x000065BC
		[DoNotSerialize]
		public ControlOutput @finally { get; private set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000310 RID: 784 RVA: 0x000083C5 File Offset: 0x000065C5
		// (set) Token: 0x06000311 RID: 785 RVA: 0x000083CD File Offset: 0x000065CD
		[DoNotSerialize]
		public ValueOutput exception { get; private set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000312 RID: 786 RVA: 0x000083D6 File Offset: 0x000065D6
		// (set) Token: 0x06000313 RID: 787 RVA: 0x000083DE File Offset: 0x000065DE
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable]
		[TypeFilter(new Type[]
		{
			typeof(Exception)
		}, Matching = TypesMatching.AssignableToAll)]
		[TypeSet(TypeSet.SettingsAssembliesTypes)]
		public Type exceptionType { get; set; } = typeof(Exception);

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000314 RID: 788 RVA: 0x000083E7 File Offset: 0x000065E7
		public override bool canDefine
		{
			get
			{
				return this.exceptionType != null && typeof(Exception).IsAssignableFrom(this.exceptionType);
			}
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00008410 File Offset: 0x00006610
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.@try = base.ControlOutput("try");
			this.@catch = base.ControlOutput("catch");
			this.@finally = base.ControlOutput("finally");
			this.exception = base.ValueOutput(this.exceptionType, "exception");
			base.Assignment(this.enter, this.exception);
			base.Succession(this.enter, this.@try);
			base.Succession(this.enter, this.@catch);
			base.Succession(this.enter, this.@finally);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000084CC File Offset: 0x000066CC
		public ControlOutput Enter(Flow flow)
		{
			if (flow.isCoroutine)
			{
				throw new NotSupportedException("Coroutines cannot catch exceptions.");
			}
			try
			{
				flow.Invoke(this.@try);
			}
			catch (Exception ex)
			{
				if (!this.exceptionType.IsInstanceOfType(ex))
				{
					throw;
				}
				flow.SetValue(this.exception, ex);
				flow.Invoke(this.@catch);
			}
			finally
			{
				flow.Invoke(this.@finally);
			}
			return null;
		}
	}
}
