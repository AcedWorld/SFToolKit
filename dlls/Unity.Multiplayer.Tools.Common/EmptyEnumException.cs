using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000011 RID: 17
	internal class EmptyEnumException<[IsUnmanaged] TEnum, TValue> : Exception where TEnum : struct, ValueType, Enum
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00002597 File Offset: 0x00000797
		public EmptyEnumException() : base("The enum TEnum cannot be used as a key in an EnumMap because it is empty and has no values.")
		{
		}
	}
}
