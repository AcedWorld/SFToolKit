using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200035E RID: 862
	internal struct StyleVariable
	{
		// Token: 0x06001CBE RID: 7358 RVA: 0x0006F78D File Offset: 0x0006D98D
		public StyleVariable(string name, StyleSheet sheet, StyleValueHandle[] handles)
		{
			this.name = name;
			this.sheet = sheet;
			this.handles = handles;
		}

		// Token: 0x06001CBF RID: 7359 RVA: 0x0006F7A8 File Offset: 0x0006D9A8
		public override int GetHashCode()
		{
			int num = this.name.GetHashCode();
			num = (num * 397 ^ this.sheet.GetHashCode());
			return num * 397 ^ this.handles.GetHashCode();
		}

		// Token: 0x04000C11 RID: 3089
		public readonly string name;

		// Token: 0x04000C12 RID: 3090
		public readonly StyleSheet sheet;

		// Token: 0x04000C13 RID: 3091
		public readonly StyleValueHandle[] handles;
	}
}
