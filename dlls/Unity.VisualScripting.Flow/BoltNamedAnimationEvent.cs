using System;
using System.ComponentModel;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200004F RID: 79
	[UnitCategory("Events/Animation")]
	[UnitShortTitle("Animation Event")]
	[UnitTitle("Named Animation Event")]
	[TypeIcon(typeof(AnimationClip))]
	[DisplayName("Visual Scripting Named Animation Event")]
	public sealed class BoltNamedAnimationEvent : MachineEventUnit<AnimationEvent>
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600032C RID: 812 RVA: 0x0000873F File Offset: 0x0000693F
		protected override string hookName
		{
			get
			{
				return "AnimationEvent";
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00008746 File Offset: 0x00006946
		// (set) Token: 0x0600032E RID: 814 RVA: 0x0000874E File Offset: 0x0000694E
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput name { get; private set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00008757 File Offset: 0x00006957
		// (set) Token: 0x06000330 RID: 816 RVA: 0x0000875F File Offset: 0x0000695F
		[DoNotSerialize]
		[PortLabel("Float")]
		public ValueOutput floatParameter { get; private set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00008768 File Offset: 0x00006968
		// (set) Token: 0x06000332 RID: 818 RVA: 0x00008770 File Offset: 0x00006970
		[DoNotSerialize]
		[PortLabel("Integer")]
		public ValueOutput intParameter { get; private set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00008779 File Offset: 0x00006979
		// (set) Token: 0x06000334 RID: 820 RVA: 0x00008781 File Offset: 0x00006981
		[DoNotSerialize]
		[PortLabel("Object")]
		public ValueOutput objectReferenceParameter { get; private set; }

		// Token: 0x06000335 RID: 821 RVA: 0x0000878C File Offset: 0x0000698C
		protected override void Definition()
		{
			base.Definition();
			this.name = base.ValueInput<string>("name", string.Empty);
			this.floatParameter = base.ValueOutput<float>("floatParameter");
			this.intParameter = base.ValueOutput<int>("intParameter");
			this.objectReferenceParameter = base.ValueOutput<GameObject>("objectReferenceParameter");
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000087E8 File Offset: 0x000069E8
		protected override bool ShouldTrigger(Flow flow, AnimationEvent animationEvent)
		{
			return EventUnit<AnimationEvent>.CompareNames(flow, this.name, animationEvent.stringParameter);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000087FC File Offset: 0x000069FC
		protected override void AssignArguments(Flow flow, AnimationEvent animationEvent)
		{
			flow.SetValue(this.floatParameter, animationEvent.floatParameter);
			flow.SetValue(this.intParameter, animationEvent.intParameter);
			flow.SetValue(this.objectReferenceParameter, animationEvent.objectReferenceParameter);
		}
	}
}
