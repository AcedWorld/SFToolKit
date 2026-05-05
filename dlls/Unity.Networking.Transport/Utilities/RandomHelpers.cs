using System;
using System.Diagnostics;
using Unity.Mathematics;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000C9 RID: 201
	public static class RandomHelpers
	{
		// Token: 0x060002FD RID: 765 RVA: 0x000110F0 File Offset: 0x0000F2F0
		public static ushort GetRandomUShort()
		{
			Random random = new Random((uint)Stopwatch.GetTimestamp());
			return (ushort)random.NextUInt(1U, 65534U);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00011118 File Offset: 0x0000F318
		public static ulong GetRandomULong()
		{
			Random random = new Random((uint)Stopwatch.GetTimestamp());
			ulong num = (ulong)random.NextUInt(0U, 4294967294U);
			uint num2 = random.NextUInt(1U, 4294967294U);
			return num << 32 | (ulong)num2;
		}
	}
}
