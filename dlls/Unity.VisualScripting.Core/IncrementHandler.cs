using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000E5 RID: 229
	public sealed class IncrementHandler : UnaryOperatorHandler
	{
		// Token: 0x06000636 RID: 1590 RVA: 0x00016574 File Offset: 0x00014774
		public IncrementHandler() : base("Increment", "Increment", "++", "op_Increment")
		{
			base.Handle<byte>((byte a) => a += 1);
			base.Handle<sbyte>((sbyte a) => a += 1);
			base.Handle<short>((short a) => a += 1);
			base.Handle<ushort>((ushort a) => a += 1);
			base.Handle<int>((int a) => ++a);
			base.Handle<uint>((uint a) => a += 1U);
			base.Handle<long>((long a) => a += 1L);
			base.Handle<ulong>((ulong a) => a += 1UL);
			base.Handle<float>((float a) => a += 1f);
			base.Handle<decimal>((decimal a) => a = ++a);
			base.Handle<double>((double a) => a += 1.0);
		}
	}
}
