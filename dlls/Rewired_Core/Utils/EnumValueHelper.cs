using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	// Token: 0x020004B1 RID: 1201
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class EnumValueHelper<TEnum>
	{
		// Token: 0x17000B20 RID: 2848
		// (get) Token: 0x060030B7 RID: 12471 RVA: 0x00025466 File Offset: 0x00023666
		public static EnumValueHelper<TEnum> Default
		{
			get
			{
				EnumValueHelper<TEnum> result;
				if ((result = EnumValueHelper<TEnum>.XmRiWVkMQewsuxmVIZAmGFrqpqbL) == null)
				{
					result = (EnumValueHelper<TEnum>.XmRiWVkMQewsuxmVIZAmGFrqpqbL = new EnumValueHelper<TEnum>());
				}
				return result;
			}
		}

		// Token: 0x17000B21 RID: 2849
		// (get) Token: 0x060030B8 RID: 12472 RVA: 0x0002547C File Offset: 0x0002367C
		public IList<TEnum> values
		{
			get
			{
				return this.TfPPhjWpWYYhEJCXPTvcinFEnMJq;
			}
		}

		// Token: 0x17000B22 RID: 2850
		// (get) Token: 0x060030B9 RID: 12473 RVA: 0x00025484 File Offset: 0x00023684
		public IList<string> names
		{
			get
			{
				if (this.KiVTsDxFPqGAtmjHvnggHLAncVTB == null)
				{
					this.bQGgblOfKxAbidSjBKCHWkXZXNEvA = Enum.GetNames(typeof(TEnum));
					this.KiVTsDxFPqGAtmjHvnggHLAncVTB = new ReadOnlyCollection<string>(this.bQGgblOfKxAbidSjBKCHWkXZXNEvA);
				}
				return this.KiVTsDxFPqGAtmjHvnggHLAncVTB;
			}
		}

		// Token: 0x060030BA RID: 12474 RVA: 0x000A9398 File Offset: 0x000A7598
		public EnumValueHelper()
		{
			if (!EnumTools.IsEnum(typeof(TEnum)))
			{
				throw new ArgumentException("TEnum must be an enum type.");
			}
			this.hdLulhvTkqWvkgkbieGufYmdIuPFA = (TEnum[])Enum.GetValues(typeof(TEnum));
			this.TfPPhjWpWYYhEJCXPTvcinFEnMJq = new ReadOnlyCollection<TEnum>(this.hdLulhvTkqWvkgkbieGufYmdIuPFA);
		}

		// Token: 0x04001AA7 RID: 6823
		private static EnumValueHelper<TEnum> XmRiWVkMQewsuxmVIZAmGFrqpqbL;

		// Token: 0x04001AA8 RID: 6824
		private TEnum[] hdLulhvTkqWvkgkbieGufYmdIuPFA;

		// Token: 0x04001AA9 RID: 6825
		private ReadOnlyCollection<TEnum> TfPPhjWpWYYhEJCXPTvcinFEnMJq;

		// Token: 0x04001AAA RID: 6826
		private string[] bQGgblOfKxAbidSjBKCHWkXZXNEvA;

		// Token: 0x04001AAB RID: 6827
		private ReadOnlyCollection<string> KiVTsDxFPqGAtmjHvnggHLAncVTB;
	}
}
