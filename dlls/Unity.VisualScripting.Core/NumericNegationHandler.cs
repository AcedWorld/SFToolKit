using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000EE RID: 238
	public sealed class NumericNegationHandler : UnaryOperatorHandler
	{
		// Token: 0x06000643 RID: 1603 RVA: 0x0001C160 File Offset: 0x0001A360
		public NumericNegationHandler() : base("Numeric Negation", "Negate", "-", "op_UnaryNegation")
		{
			base.Handle<byte>((byte a) => (int)(-(int)a));
			base.Handle<sbyte>((sbyte a) => (int)(-(int)a));
			base.Handle<short>((short a) => (int)(-(int)a));
			base.Handle<ushort>((ushort a) => (int)(-(int)a));
			base.Handle<int>((int a) => -a);
			base.Handle<uint>((uint a) => (long)(-(long)((ulong)a)));
			base.Handle<long>((long a) => -a);
			base.Handle<float>((float a) => -a);
			base.Handle<decimal>((decimal a) => -a);
			base.Handle<double>((double a) => -a);
		}
	}
}
