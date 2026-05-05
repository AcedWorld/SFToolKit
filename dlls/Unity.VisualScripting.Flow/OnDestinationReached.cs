using System;
using UnityEngine.AI;

namespace Unity.VisualScripting
{
	// Token: 0x02000091 RID: 145
	[UnitCategory("Events/Navigation")]
	public sealed class OnDestinationReached : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x00009829 File Offset: 0x00007A29
		protected override string hookName
		{
			get
			{
				return "Update";
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00009830 File Offset: 0x00007A30
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00009838 File Offset: 0x00007A38
		[DoNotSerialize]
		public ValueInput threshold { get; private set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00009841 File Offset: 0x00007A41
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x00009849 File Offset: 0x00007A49
		[DoNotSerialize]
		public ValueInput requireSuccess { get; private set; }

		// Token: 0x0600044F RID: 1103 RVA: 0x00009852 File Offset: 0x00007A52
		protected override void Definition()
		{
			base.Definition();
			this.threshold = base.ValueInput<float>("threshold", 0.05f);
			this.requireSuccess = base.ValueInput<bool>("requireSuccess", true);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00009884 File Offset: 0x00007A84
		protected override bool ShouldTrigger(Flow flow, EmptyEventArgs args)
		{
			NavMeshAgent component = flow.stack.gameObject.GetComponent<NavMeshAgent>();
			return component != null && component.remainingDistance <= flow.GetValue<float>(this.threshold) && (component.pathStatus == NavMeshPathStatus.PathComplete || !flow.GetValue<bool>(this.requireSuccess));
		}
	}
}
