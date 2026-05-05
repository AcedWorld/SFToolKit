using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000A8 RID: 168
	[UnitCategory("Events/Time")]
	[Obsolete("Use Wait For Seconds or Timer instead.")]
	public sealed class OnTimerElapsed : MachineEventUnit<EmptyEventArgs>
	{
		// Token: 0x060004D4 RID: 1236 RVA: 0x0000A190 File Offset: 0x00008390
		public override IGraphElementData CreateData()
		{
			return new OnTimerElapsed.Data();
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0000A197 File Offset: 0x00008397
		protected override string hookName
		{
			get
			{
				return "Update";
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0000A19E File Offset: 0x0000839E
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x0000A1A6 File Offset: 0x000083A6
		[DoNotSerialize]
		[PortLabel("Delay")]
		public ValueInput seconds { get; private set; }

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000A1AF File Offset: 0x000083AF
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x0000A1B7 File Offset: 0x000083B7
		[DoNotSerialize]
		[PortLabel("Unscaled")]
		public ValueInput unscaledTime { get; private set; }

		// Token: 0x060004DA RID: 1242 RVA: 0x0000A1C0 File Offset: 0x000083C0
		protected override void Definition()
		{
			base.Definition();
			this.seconds = base.ValueInput<float>("seconds", 0f);
			this.unscaledTime = base.ValueInput<bool>("unscaledTime", false);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0000A1F0 File Offset: 0x000083F0
		public override void StartListening(GraphStack stack)
		{
			base.StartListening(stack);
			OnTimerElapsed.Data elementData = stack.GetElementData<OnTimerElapsed.Data>(this);
			elementData.triggered = false;
			elementData.time = 0f;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000A214 File Offset: 0x00008414
		protected override bool ShouldTrigger(Flow flow, EmptyEventArgs args)
		{
			OnTimerElapsed.Data elementData = flow.stack.GetElementData<OnTimerElapsed.Data>(this);
			if (elementData.triggered)
			{
				return false;
			}
			float num = flow.GetValue<bool>(this.unscaledTime) ? Time.unscaledDeltaTime : Time.deltaTime;
			float value = flow.GetValue<float>(this.seconds);
			elementData.time += num;
			if (elementData.time >= value)
			{
				elementData.triggered = true;
				return true;
			}
			return false;
		}

		// Token: 0x020001B3 RID: 435
		public new class Data : EventUnit<EmptyEventArgs>.Data
		{
			// Token: 0x040003A3 RID: 931
			public float time;

			// Token: 0x040003A4 RID: 932
			public bool triggered;
		}
	}
}
