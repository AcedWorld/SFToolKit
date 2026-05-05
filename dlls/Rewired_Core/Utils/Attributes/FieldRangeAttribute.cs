using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	// Token: 0x02000538 RID: 1336
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		// Token: 0x17000C23 RID: 3107
		// (get) Token: 0x06003666 RID: 13926 RVA: 0x0002A730 File Offset: 0x00028930
		public float minFloat
		{
			get
			{
				return this.SMlfOUJcpBMOTILyCqWRcTOXggQcB;
			}
		}

		// Token: 0x17000C24 RID: 3108
		// (get) Token: 0x06003667 RID: 13927 RVA: 0x0002A738 File Offset: 0x00028938
		public float maxFloat
		{
			get
			{
				return this.HeIHoQeDNtTnmMcjHhcIGkUhSlRNc;
			}
		}

		// Token: 0x17000C25 RID: 3109
		// (get) Token: 0x06003668 RID: 13928 RVA: 0x0002A740 File Offset: 0x00028940
		public int minInt
		{
			get
			{
				return this.sYVaRZTgGzGcmotmHzCJSvnkVFPH;
			}
		}

		// Token: 0x17000C26 RID: 3110
		// (get) Token: 0x06003669 RID: 13929 RVA: 0x0002A748 File Offset: 0x00028948
		public int maxInt
		{
			get
			{
				return this.YLEamsApSMAYurZaaYJjdtSFSAdy;
			}
		}

		// Token: 0x0600366A RID: 13930 RVA: 0x0002A750 File Offset: 0x00028950
		public FieldRangeAttribute(float A_1, float A_2)
		{
			this.SMlfOUJcpBMOTILyCqWRcTOXggQcB = A_1;
			this.HeIHoQeDNtTnmMcjHhcIGkUhSlRNc = A_2;
			this.sYVaRZTgGzGcmotmHzCJSvnkVFPH = (int)A_1;
			this.YLEamsApSMAYurZaaYJjdtSFSAdy = (int)A_2;
		}

		// Token: 0x0600366B RID: 13931 RVA: 0x0002A776 File Offset: 0x00028976
		public FieldRangeAttribute(int A_1, int A_2)
		{
			this.sYVaRZTgGzGcmotmHzCJSvnkVFPH = A_1;
			this.YLEamsApSMAYurZaaYJjdtSFSAdy = A_2;
			this.SMlfOUJcpBMOTILyCqWRcTOXggQcB = (float)A_1;
			this.HeIHoQeDNtTnmMcjHhcIGkUhSlRNc = (float)A_2;
		}

		// Token: 0x04001C90 RID: 7312
		private float SMlfOUJcpBMOTILyCqWRcTOXggQcB;

		// Token: 0x04001C91 RID: 7313
		private float HeIHoQeDNtTnmMcjHhcIGkUhSlRNc;

		// Token: 0x04001C92 RID: 7314
		private int sYVaRZTgGzGcmotmHzCJSvnkVFPH;

		// Token: 0x04001C93 RID: 7315
		private int YLEamsApSMAYurZaaYJjdtSFSAdy;
	}
}
