using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000068 RID: 104
	[UnitCategory("Events/GUI")]
	[TypeIcon(typeof(GUI))]
	[UnitOrder(0)]
	public sealed class OnGUI : GlobalEventUnit<EmptyEventArgs>
	{
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060003AD RID: 941 RVA: 0x00009099 File Offset: 0x00007299
		protected override string hookName
		{
			get
			{
				return "OnGUI";
			}
		}
	}
}
