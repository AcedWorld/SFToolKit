using System;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x02000254 RID: 596
	public class EditorSettings : ScriptableObject
	{
		// Token: 0x04000F91 RID: 3985
		[CustomObfuscation(rename = false)]
		public int programVersion1;

		// Token: 0x04000F92 RID: 3986
		[CustomObfuscation(rename = false)]
		public int programVersion2;

		// Token: 0x04000F93 RID: 3987
		[CustomObfuscation(rename = false)]
		public int programVersion3;

		// Token: 0x04000F94 RID: 3988
		[CustomObfuscation(rename = false)]
		public int programVersion4;

		// Token: 0x04000F95 RID: 3989
		[CustomObfuscation(rename = false)]
		public int dataVersion;
	}
}
