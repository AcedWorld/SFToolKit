using System;
using Rewired;
using Rewired.Utils.Classes.Data;

// Token: 0x020002D7 RID: 727
internal abstract class zHTBvVyhFGDLpEJMFINchPNfqnfnb
{
	// Token: 0x0600158F RID: 5519 RVA: 0x0001C159 File Offset: 0x0001A359
	public zHTBvVyhFGDLpEJMFINchPNfqnfnb(byte A_1, zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo A_2)
	{
		this.ZEmAzjmzLpNGaBBQPUjRDHfQsujS = A_1;
		this.JxEelRRcOGggZXjfPscsdOyvCZGJ = A_2;
	}

	// Token: 0x06001590 RID: 5520
	public abstract void WMAwtKiWRygWRqyRkTqlMnhmDEdgA(NativeBuffer, double);

	// Token: 0x04002F17 RID: 12055
	public readonly byte ZEmAzjmzLpNGaBBQPUjRDHfQsujS;

	// Token: 0x04002F18 RID: 12056
	public readonly zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo JxEelRRcOGggZXjfPscsdOyvCZGJ;

	// Token: 0x020002D8 RID: 728
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDInfo
	{
		// Token: 0x04002F19 RID: 12057
		public ushort usagePage;

		// Token: 0x04002F1A RID: 12058
		public ushort usage;

		// Token: 0x04002F1B RID: 12059
		public int dataIndex;

		// Token: 0x04002F1C RID: 12060
		public int bitSize;

		// Token: 0x04002F1D RID: 12061
		public int logicalMin;

		// Token: 0x04002F1E RID: 12062
		public int logicalMax;

		// Token: 0x04002F1F RID: 12063
		public int physicalMin;

		// Token: 0x04002F20 RID: 12064
		public int physicalMax;

		// Token: 0x04002F21 RID: 12065
		public uint units;

		// Token: 0x04002F22 RID: 12066
		public uint unitsExp;
	}
}
