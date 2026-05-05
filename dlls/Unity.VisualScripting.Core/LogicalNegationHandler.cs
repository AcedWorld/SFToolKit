using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000EB RID: 235
	public sealed class LogicalNegationHandler : UnaryOperatorHandler
	{
		// Token: 0x06000640 RID: 1600 RVA: 0x00019F3C File Offset: 0x0001813C
		public LogicalNegationHandler() : base("Logical Negation", "Not", "~", "op_OnesComplement")
		{
			base.Handle<bool>((bool a) => !a);
			base.Handle<byte>((byte a) => (int)(~(int)a));
			base.Handle<sbyte>((sbyte a) => (int)(~(int)a));
			base.Handle<short>((short a) => (int)(~(int)a));
			base.Handle<ushort>((ushort a) => (int)(~(int)a));
			base.Handle<int>((int a) => ~a);
			base.Handle<uint>((uint a) => ~a);
			base.Handle<long>((long a) => ~a);
			base.Handle<ulong>((ulong a) => ~a);
		}
	}
}
