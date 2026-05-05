using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000010 RID: 16
	internal class UnhandledEnumBackingTypeException<[IsUnmanaged] TEnum, TValue> : Exception where TEnum : struct, ValueType, Enum
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00002562 File Offset: 0x00000762
		public UnhandledEnumBackingTypeException() : base("The enum TEnum cannot be used as a key in an EnumMap " + string.Format("because its backing type {0} is not {1}. ", Enum.GetUnderlyingType(typeof(TEnum)), "Int32") + "This constraint is required by EnumMap.CastEnumToInt.")
		{
		}
	}
}
