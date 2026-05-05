using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200008E RID: 142
	[AddComponentMenu("")]
	public sealed class UnityOnJointBreak2DMessageListener : MessageListener
	{
		// Token: 0x060003EB RID: 1003 RVA: 0x00009761 File Offset: 0x00007961
		private void OnJointBreak2D(Joint2D brokenJoint)
		{
			EventBus.Trigger<Joint2D>("OnJointBreak2D", base.gameObject, brokenJoint);
		}
	}
}
