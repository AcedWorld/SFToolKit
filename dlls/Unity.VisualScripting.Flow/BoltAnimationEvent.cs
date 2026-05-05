using System;
using System.ComponentModel;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200004E RID: 78
	[UnitCategory("Events/Animation")]
	[UnitShortTitle("Animation Event")]
	[UnitTitle("Animation Event")]
	[TypeIcon(typeof(AnimationClip))]
	[DisplayName("Visual Scripting Animation Event")]
	public sealed class BoltAnimationEvent : MachineEventUnit<AnimationEvent>
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00008635 File Offset: 0x00006835
		protected override string hookName
		{
			get
			{
				return "AnimationEvent";
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000321 RID: 801 RVA: 0x0000863C File Offset: 0x0000683C
		// (set) Token: 0x06000322 RID: 802 RVA: 0x00008644 File Offset: 0x00006844
		[DoNotSerialize]
		[PortLabel("String")]
		public ValueOutput stringParameter { get; private set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0000864D File Offset: 0x0000684D
		// (set) Token: 0x06000324 RID: 804 RVA: 0x00008655 File Offset: 0x00006855
		[DoNotSerialize]
		[PortLabel("Float")]
		public ValueOutput floatParameter { get; private set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0000865E File Offset: 0x0000685E
		// (set) Token: 0x06000326 RID: 806 RVA: 0x00008666 File Offset: 0x00006866
		[DoNotSerialize]
		[PortLabel("Integer")]
		public ValueOutput intParameter { get; private set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000327 RID: 807 RVA: 0x0000866F File Offset: 0x0000686F
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00008677 File Offset: 0x00006877
		[DoNotSerialize]
		[PortLabel("Object")]
		public ValueOutput objectReferenceParameter { get; private set; }

		// Token: 0x06000329 RID: 809 RVA: 0x00008680 File Offset: 0x00006880
		protected override void Definition()
		{
			base.Definition();
			this.stringParameter = base.ValueOutput<string>("stringParameter");
			this.floatParameter = base.ValueOutput<float>("floatParameter");
			this.intParameter = base.ValueOutput<int>("intParameter");
			this.objectReferenceParameter = base.ValueOutput<Object>("objectReferenceParameter");
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000086D8 File Offset: 0x000068D8
		protected override void AssignArguments(Flow flow, AnimationEvent args)
		{
			flow.SetValue(this.stringParameter, args.stringParameter);
			flow.SetValue(this.floatParameter, args.floatParameter);
			flow.SetValue(this.intParameter, args.intParameter);
			flow.SetValue(this.objectReferenceParameter, args.objectReferenceParameter);
		}
	}
}
