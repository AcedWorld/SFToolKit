using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B8 RID: 184
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerPerformQoSMeasurementsArgs
	{
		// Token: 0x0600058A RID: 1418 RVA: 0x0000B2AF File Offset: 0x000094AF
		internal XblMultiplayerPerformQoSMeasurementsArgs(XblMultiplayerPerformQoSMeasurementsArgs interopStruct)
		{
			this.RemoteClients = interopStruct.GetRemoteClients<XblMultiplayerConnectionAddressDeviceTokenPair>((XblMultiplayerConnectionAddressDeviceTokenPair x) => new XblMultiplayerConnectionAddressDeviceTokenPair(x));
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0000B2E3 File Offset: 0x000094E3
		public XblMultiplayerConnectionAddressDeviceTokenPair[] RemoteClients { get; }
	}
}
