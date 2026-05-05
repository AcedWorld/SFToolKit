using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000077 RID: 119
	internal class TProfilingSampler<TEnum> : ProfilingSampler where TEnum : Enum
	{
		// Token: 0x060003B4 RID: 948 RVA: 0x0001001C File Offset: 0x0000E21C
		static TProfilingSampler()
		{
			string[] names = Enum.GetNames(typeof(TEnum));
			Array values = Enum.GetValues(typeof(TEnum));
			for (int i = 0; i < names.Length; i++)
			{
				TProfilingSampler<TEnum> value = new TProfilingSampler<TEnum>(names[i]);
				TProfilingSampler<TEnum>.samples.Add((TEnum)((object)values.GetValue(i)), value);
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00010081 File Offset: 0x0000E281
		public TProfilingSampler(string name) : base(name)
		{
		}

		// Token: 0x04000216 RID: 534
		internal static Dictionary<TEnum, TProfilingSampler<TEnum>> samples = new Dictionary<TEnum, TProfilingSampler<TEnum>>();
	}
}
