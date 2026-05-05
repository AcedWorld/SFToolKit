using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000175 RID: 373
	public abstract class UnitPortDefinition : IUnitPortDefinition
	{
		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060009AA RID: 2474 RVA: 0x00011398 File Offset: 0x0000F598
		// (set) Token: 0x060009AB RID: 2475 RVA: 0x000113A0 File Offset: 0x0000F5A0
		[Serialize]
		[Inspectable]
		[InspectorDelayed]
		[WarnBeforeEditing("Edit Port Key", "Changing the key of this definition will break any existing connection to this port. Are you sure you want to continue?", new object[]
		{
			null,
			""
		})]
		public string key { get; set; }

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x000113A9 File Offset: 0x0000F5A9
		// (set) Token: 0x060009AD RID: 2477 RVA: 0x000113B1 File Offset: 0x0000F5B1
		[Serialize]
		[Inspectable]
		public string label { get; set; }

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x000113BA File Offset: 0x0000F5BA
		// (set) Token: 0x060009AF RID: 2479 RVA: 0x000113C2 File Offset: 0x0000F5C2
		[Serialize]
		[Inspectable]
		[InspectorTextArea]
		public string summary { get; set; }

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x000113CB File Offset: 0x0000F5CB
		// (set) Token: 0x060009B1 RID: 2481 RVA: 0x000113D3 File Offset: 0x0000F5D3
		[Serialize]
		[Inspectable]
		public bool hideLabel { get; set; }

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x000113DC File Offset: 0x0000F5DC
		[DoNotSerialize]
		public virtual bool isValid
		{
			get
			{
				return !string.IsNullOrEmpty(this.key);
			}
		}
	}
}
