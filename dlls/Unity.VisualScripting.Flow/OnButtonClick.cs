using System;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x02000061 RID: 97
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(Button))]
	[UnitOrder(1)]
	public sealed class OnButtonClick : GameObjectEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00008F54 File Offset: 0x00007154
		protected override string hookName
		{
			get
			{
				return "OnButtonClick";
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000393 RID: 915 RVA: 0x00008F5B File Offset: 0x0000715B
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnButtonClickMessageListener);
			}
		}
	}
}
