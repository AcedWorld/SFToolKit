using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200008A RID: 138
	[UnitCategory("Events/Lifecycle")]
	[UnitOrder(7)]
	public sealed class OnDestroy : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x00009751 File Offset: 0x00007951
		protected override string hookName
		{
			get
			{
				return "OnDestroy";
			}
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00009758 File Offset: 0x00007958
		public override void StopListening(GraphStack stack)
		{
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0000975C File Offset: 0x0000795C
		private protected override void InternalTrigger(GraphReference reference, EmptyEventArgs args)
		{
			base.InternalTrigger(reference, args);
			using (GraphStack graphStack = reference.ToStackPooled())
			{
				base.StopListening(graphStack);
			}
		}
	}
}
