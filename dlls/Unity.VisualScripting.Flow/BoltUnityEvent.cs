using System;
using System.ComponentModel;

namespace Unity.VisualScripting
{
	// Token: 0x02000057 RID: 87
	[UnitCategory("Events")]
	[UnitTitle("UnityEvent")]
	[UnitOrder(2)]
	[DisplayName("Visual Scripting Unity Event")]
	public sealed class BoltUnityEvent : MachineEventUnit<string>
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00008910 File Offset: 0x00006B10
		protected override string hookName
		{
			get
			{
				return "UnityEvent";
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00008917 File Offset: 0x00006B17
		// (set) Token: 0x0600034F RID: 847 RVA: 0x0000891F File Offset: 0x00006B1F
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput name { get; private set; }

		// Token: 0x06000350 RID: 848 RVA: 0x00008928 File Offset: 0x00006B28
		protected override void Definition()
		{
			base.Definition();
			this.name = base.ValueInput<string>("name", string.Empty);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00008946 File Offset: 0x00006B46
		protected override bool ShouldTrigger(Flow flow, string name)
		{
			return EventUnit<string>.CompareNames(flow, this.name, name);
		}
	}
}
