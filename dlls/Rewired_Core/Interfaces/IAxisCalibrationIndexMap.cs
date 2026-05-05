using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001F6 RID: 502
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface IAxisCalibrationIndexMap
	{
		// Token: 0x06001922 RID: 6434
		int GetMappedAxisIndex(int axisIndex);
	}
}
