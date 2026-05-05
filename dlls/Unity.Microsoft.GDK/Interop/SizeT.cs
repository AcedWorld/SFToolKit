using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C7 RID: 455
	[MovedFrom("Unity.GameCore.Interop")]
	public struct SizeT
	{
		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000A98 RID: 2712 RVA: 0x0000FFE3 File Offset: 0x0000E1E3
		public bool IsZero
		{
			get
			{
				return this.value == UIntPtr.Zero;
			}
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0000FFF5 File Offset: 0x0000E1F5
		public SizeT(int length)
		{
			this.value = new UIntPtr(Convert.ToUInt64(length));
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00010008 File Offset: 0x0000E208
		public SizeT(uint length)
		{
			this.value = new UIntPtr(Convert.ToUInt64(length));
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x0001001B File Offset: 0x0000E21B
		public SizeT(long length)
		{
			this.value = new UIntPtr(Convert.ToUInt64(length));
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0001002E File Offset: 0x0000E22E
		public SizeT(ulong length)
		{
			this.value = new UIntPtr(length);
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0001003C File Offset: 0x0000E23C
		public uint ToUInt32()
		{
			return Convert.ToUInt32(this.value.ToUInt64());
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0001004E File Offset: 0x0000E24E
		public int ToInt32()
		{
			return Convert.ToInt32(this.value.ToUInt64());
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00010060 File Offset: 0x0000E260
		public ulong ToUInt64()
		{
			return this.value.ToUInt64();
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x0001006D File Offset: 0x0000E26D
		public long ToInt64()
		{
			return Convert.ToInt64(this.value.ToUInt64());
		}

		// Token: 0x040005EE RID: 1518
		private readonly UIntPtr value;
	}
}
