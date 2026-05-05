using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000099 RID: 153
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionNumberAttribute
	{
		// Token: 0x0600050E RID: 1294 RVA: 0x0000A9C0 File Offset: 0x00008BC0
		public XblMultiplayerSessionNumberAttribute(string name, double value)
		{
			this.Name = name;
			this.Value = value;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0000A9D6 File Offset: 0x00008BD6
		internal XblMultiplayerSessionNumberAttribute(XblMultiplayerSessionNumberAttribute interopStruct)
		{
			this.Name = interopStruct.GetName();
			this.Value = interopStruct.value;
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x0000A9F7 File Offset: 0x00008BF7
		public string Name { get; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x0000A9FF File Offset: 0x00008BFF
		public double Value { get; }
	}
}
