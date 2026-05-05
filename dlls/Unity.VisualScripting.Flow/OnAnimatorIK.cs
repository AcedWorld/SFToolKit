using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000050 RID: 80
	[UnitCategory("Events/Animation")]
	public sealed class OnAnimatorIK : GameObjectEventUnit<int>
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000339 RID: 825 RVA: 0x00008851 File Offset: 0x00006A51
		public override Type MessageListenerType
		{
			get
			{
				return typeof(AnimatorMessageListener);
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600033A RID: 826 RVA: 0x0000885D File Offset: 0x00006A5D
		protected override string hookName
		{
			get
			{
				return "OnAnimatorIK";
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600033B RID: 827 RVA: 0x00008864 File Offset: 0x00006A64
		// (set) Token: 0x0600033C RID: 828 RVA: 0x0000886C File Offset: 0x00006A6C
		[DoNotSerialize]
		public ValueOutput layerIndex { get; private set; }

		// Token: 0x0600033D RID: 829 RVA: 0x00008875 File Offset: 0x00006A75
		protected override void Definition()
		{
			base.Definition();
			this.layerIndex = base.ValueOutput<int>("layerIndex");
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000888E File Offset: 0x00006A8E
		protected override void AssignArguments(Flow flow, int layerIndex)
		{
			flow.SetValue(this.layerIndex, layerIndex);
		}
	}
}
