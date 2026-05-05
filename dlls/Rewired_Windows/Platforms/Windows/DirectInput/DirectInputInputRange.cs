using System;

namespace Rewired.Platforms.Windows.DirectInput
{
	// Token: 0x02000090 RID: 144
	public struct DirectInputInputRange
	{
		// Token: 0x060004BE RID: 1214 RVA: 0x00013A73 File Offset: 0x00011C73
		public DirectInputInputRange(int A_1, int A_2)
		{
			this = default(DirectInputInputRange);
			this.Minimum = A_1;
			this.Maximum = A_2;
		}

		// Token: 0x0400060B RID: 1547
		public int Minimum;

		// Token: 0x0400060C RID: 1548
		public int Maximum;

		// Token: 0x0400060D RID: 1549
		public const int NoMinimum = -2147483648;

		// Token: 0x0400060E RID: 1550
		public const int NoMaximum = 2147483647;
	}
}
