using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200009F RID: 159
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionStringAttribute
	{
		// Token: 0x06000540 RID: 1344 RVA: 0x0000AD15 File Offset: 0x00008F15
		public XblMultiplayerSessionStringAttribute(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0000AD2B File Offset: 0x00008F2B
		internal XblMultiplayerSessionStringAttribute(XblMultiplayerSessionStringAttribute interopStruct)
		{
			this.Name = interopStruct.GetName();
			this.Value = interopStruct.GetValue();
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x0000AD4D File Offset: 0x00008F4D
		public string Name { get; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x0000AD55 File Offset: 0x00008F55
		public string Value { get; }
	}
}
