using System;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001AB RID: 427
	public static class fsReflectionUtility
	{
		// Token: 0x06000B6D RID: 2925 RVA: 0x00030A94 File Offset: 0x0002EC94
		public static Type GetInterface(Type type, Type interfaceType)
		{
			if (interfaceType.Resolve().IsGenericType && !interfaceType.Resolve().IsGenericTypeDefinition)
			{
				throw new ArgumentException("GetInterface requires that if the interface type is generic, then it must be the generic type definition, not a specific generic type instantiation");
			}
			while (type != null)
			{
				foreach (Type type2 in type.GetInterfaces())
				{
					if (type2.Resolve().IsGenericType)
					{
						if (interfaceType == type2.GetGenericTypeDefinition())
						{
							return type2;
						}
					}
					else if (interfaceType == type2)
					{
						return type2;
					}
				}
				type = type.Resolve().BaseType;
			}
			return null;
		}
	}
}
