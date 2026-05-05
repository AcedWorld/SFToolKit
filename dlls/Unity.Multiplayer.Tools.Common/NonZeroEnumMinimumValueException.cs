using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000012 RID: 18
	internal class NonZeroEnumMinimumValueException<[IsUnmanaged] TEnum, TValue> : Exception where TEnum : struct, ValueType, Enum
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000025A4 File Offset: 0x000007A4
		public NonZeroEnumMinimumValueException() : base("The enum TEnum cannot be used as a key in an EnumMap because its minimum value is non-zero. Consider using a dictionary instead.")
		{
		}
	}
}
