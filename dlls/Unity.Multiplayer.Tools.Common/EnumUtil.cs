using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200001A RID: 26
	internal static class EnumUtil
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00002D89 File Offset: 0x00000F89
		public static T[] GetValues<T>()
		{
			return (T[])Enum.GetValues(typeof(T));
		}
	}
}
