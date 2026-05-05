using System;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x02000078 RID: 120
	public abstract class PointerEventUnit : GameObjectEventUnit<PointerEventData>
	{
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x000093E0 File Offset: 0x000075E0
		// (set) Token: 0x060003F9 RID: 1017 RVA: 0x000093E8 File Offset: 0x000075E8
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput data { get; private set; }

		// Token: 0x060003FA RID: 1018 RVA: 0x000093F1 File Offset: 0x000075F1
		protected override void Definition()
		{
			base.Definition();
			this.data = base.ValueOutput<PointerEventData>("data");
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000940A File Offset: 0x0000760A
		protected override void AssignArguments(Flow flow, PointerEventData data)
		{
			flow.SetValue(this.data, data);
		}
	}
}
