using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200007C RID: 124
	[SerializationVersion("A", new Type[]
	{

	})]
	public sealed class GraphGroup : GraphElement<IGraph>
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003BC RID: 956 RVA: 0x000093CC File Offset: 0x000075CC
		// (set) Token: 0x060003BD RID: 957 RVA: 0x000093D4 File Offset: 0x000075D4
		[Serialize]
		public Rect position { get; set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003BE RID: 958 RVA: 0x000093DD File Offset: 0x000075DD
		// (set) Token: 0x060003BF RID: 959 RVA: 0x000093E5 File Offset: 0x000075E5
		[Serialize]
		public string label { get; set; } = "Group";

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x000093EE File Offset: 0x000075EE
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x000093F6 File Offset: 0x000075F6
		[Serialize]
		[InspectorTextArea(minLines = 1f, maxLines = 10f)]
		public string comment { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x000093FF File Offset: 0x000075FF
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x00009407 File Offset: 0x00007607
		[Serialize]
		[Inspectable]
		public Color color { get; set; } = GraphGroup.defaultColor;

		// Token: 0x040000EB RID: 235
		[DoNotSerialize]
		public static readonly Color defaultColor = new Color(0f, 0f, 0f);
	}
}
