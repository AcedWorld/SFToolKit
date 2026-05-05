using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000246 RID: 582
	internal class EnumInfo
	{
		// Token: 0x060018C1 RID: 6337 RVA: 0x00029904 File Offset: 0x00027B04
		[UsedByNativeCode]
		internal static EnumInfo CreateEnumInfoFromNativeEnum(string[] names, int[] values, string[] annotations, bool isFlags)
		{
			return new EnumInfo
			{
				names = names,
				values = values,
				annotations = annotations,
				isFlags = isFlags
			};
		}

		// Token: 0x040008BE RID: 2238
		public string[] names;

		// Token: 0x040008BF RID: 2239
		public int[] values;

		// Token: 0x040008C0 RID: 2240
		public string[] annotations;

		// Token: 0x040008C1 RID: 2241
		public bool isFlags;
	}
}
