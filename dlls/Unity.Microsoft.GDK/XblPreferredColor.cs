using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000F2 RID: 242
	[MovedFrom("Unity.GameCore")]
	public class XblPreferredColor
	{
		// Token: 0x06000666 RID: 1638 RVA: 0x0000BE80 File Offset: 0x0000A080
		internal XblPreferredColor(XblPreferredColor interopPreferredColor)
		{
			this.PrimaryColor = Converters.ByteArrayToString(interopPreferredColor.primaryColor);
			this.SecondaryColor = Converters.ByteArrayToString(interopPreferredColor.secondaryColor);
			this.TertiaryColor = Converters.ByteArrayToString(interopPreferredColor.tertiaryColor);
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x0000BEBB File Offset: 0x0000A0BB
		// (set) Token: 0x06000668 RID: 1640 RVA: 0x0000BEC3 File Offset: 0x0000A0C3
		public string PrimaryColor { get; private set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x0000BECC File Offset: 0x0000A0CC
		// (set) Token: 0x0600066A RID: 1642 RVA: 0x0000BED4 File Offset: 0x0000A0D4
		public string SecondaryColor { get; private set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x0000BEDD File Offset: 0x0000A0DD
		// (set) Token: 0x0600066C RID: 1644 RVA: 0x0000BEE5 File Offset: 0x0000A0E5
		public string TertiaryColor { get; private set; }
	}
}
