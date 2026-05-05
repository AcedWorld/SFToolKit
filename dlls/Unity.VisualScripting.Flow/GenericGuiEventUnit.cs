using System;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x0200005F RID: 95
	public abstract class GenericGuiEventUnit : GameObjectEventUnit<BaseEventData>
	{
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00008EF8 File Offset: 0x000070F8
		// (set) Token: 0x0600038B RID: 907 RVA: 0x00008F00 File Offset: 0x00007100
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput data { get; private set; }

		// Token: 0x0600038C RID: 908 RVA: 0x00008F09 File Offset: 0x00007109
		protected override void Definition()
		{
			base.Definition();
			this.data = base.ValueOutput<BaseEventData>("data");
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00008F22 File Offset: 0x00007122
		protected override void AssignArguments(Flow flow, BaseEventData data)
		{
			flow.SetValue(this.data, data);
		}
	}
}
