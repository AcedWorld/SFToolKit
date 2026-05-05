using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000177 RID: 375
	[IncludeInSettings(false)]
	public sealed class VariablesAsset : LudiqScriptableObject
	{
		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x00029AE1 File Offset: 0x00027CE1
		// (set) Token: 0x06000A04 RID: 2564 RVA: 0x00029AE9 File Offset: 0x00027CE9
		[Serialize]
		[Inspectable]
		[InspectorWide(true)]
		public VariableDeclarations declarations { get; internal set; } = new VariableDeclarations();

		// Token: 0x06000A05 RID: 2565 RVA: 0x00029AF2 File Offset: 0x00027CF2
		[ContextMenu("Show Data...")]
		protected override void ShowData()
		{
			base.ShowData();
		}
	}
}
