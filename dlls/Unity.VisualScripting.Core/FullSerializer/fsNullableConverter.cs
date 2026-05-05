using System;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000182 RID: 386
	public class fsNullableConverter : fsConverter
	{
		// Token: 0x06000A48 RID: 2632 RVA: 0x0002AE42 File Offset: 0x00029042
		public override bool CanProcess(Type type)
		{
			return type.Resolve().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x0002AE68 File Offset: 0x00029068
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			return this.Serializer.TrySerialize(Nullable.GetUnderlyingType(storageType), instance, out serialized);
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x0002AE7D File Offset: 0x0002907D
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			return this.Serializer.TryDeserialize(data, Nullable.GetUnderlyingType(storageType), ref instance);
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0002AE92 File Offset: 0x00029092
		public override object CreateInstance(fsData data, Type storageType)
		{
			return storageType;
		}
	}
}
