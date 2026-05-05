using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000F3 RID: 243
	internal sealed class UnsafeBitArrayDebugView
	{
		// Token: 0x0600098B RID: 2443 RVA: 0x0001E3D5 File Offset: 0x0001C5D5
		public UnsafeBitArrayDebugView(UnsafeBitArray data)
		{
			this.Data = data;
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x0001E3E4 File Offset: 0x0001C5E4
		public bool[] Bits
		{
			get
			{
				bool[] array = new bool[this.Data.Length];
				for (int i = 0; i < this.Data.Length; i++)
				{
					array[i] = this.Data.IsSet(i);
				}
				return array;
			}
		}

		// Token: 0x0400034D RID: 845
		private UnsafeBitArray Data;
	}
}
