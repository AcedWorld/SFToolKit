using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200009E RID: 158
	public sealed class OnCollisionEnter2D : CollisionEvent2DUnit
	{
		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00009EF0 File Offset: 0x000080F0
		public override Type MessageListenerType
		{
			get
			{
				return typeof(UnityOnCollisionEnter2DMessageListener);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x00009EFC File Offset: 0x000080FC
		protected override string hookName
		{
			get
			{
				return "OnCollisionEnter2D";
			}
		}
	}
}
