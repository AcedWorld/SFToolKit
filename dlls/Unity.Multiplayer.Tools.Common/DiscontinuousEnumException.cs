using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000013 RID: 19
	internal class DiscontinuousEnumException<[IsUnmanaged] TEnum, TValue> : Exception where TEnum : struct, ValueType, Enum
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000025B1 File Offset: 0x000007B1
		public DiscontinuousEnumException() : base("The enum TEnum cannot be used as a key in an EnumMap because it is discontinuous, and EnumMap requires continuous keys for storage in a fixed array. Consider using a dictionary instead.")
		{
		}
	}
}
