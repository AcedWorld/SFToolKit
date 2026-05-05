using System;

namespace Unity.Burst.CompilerServices
{
	// Token: 0x02000023 RID: 35
	public static class Aliasing
	{
		// Token: 0x0600012D RID: 301 RVA: 0x000079FA File Offset: 0x00005BFA
		public unsafe static void ExpectAliased(void* a, void* b)
		{
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000079FC File Offset: 0x00005BFC
		public static void ExpectAliased<A, B>(in A a, in B b) where A : struct where B : struct
		{
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000079FE File Offset: 0x00005BFE
		public unsafe static void ExpectAliased<B>(void* a, in B b) where B : struct
		{
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00007A00 File Offset: 0x00005C00
		public unsafe static void ExpectAliased<A>(in A a, void* b) where A : struct
		{
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00007A02 File Offset: 0x00005C02
		public unsafe static void ExpectNotAliased(void* a, void* b)
		{
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00007A04 File Offset: 0x00005C04
		public static void ExpectNotAliased<A, B>(in A a, in B b) where A : struct where B : struct
		{
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00007A06 File Offset: 0x00005C06
		public unsafe static void ExpectNotAliased<B>(void* a, in B b) where B : struct
		{
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00007A08 File Offset: 0x00005C08
		public unsafe static void ExpectNotAliased<A>(in A a, void* b) where A : struct
		{
		}
	}
}
