using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000181 RID: 385
	public class fsKeyValuePairConverter : fsConverter
	{
		// Token: 0x06000A42 RID: 2626 RVA: 0x0002AC9F File Offset: 0x00028E9F
		public override bool CanProcess(Type type)
		{
			return type.Resolve().IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<, >);
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x0002ACC5 File Offset: 0x00028EC5
		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0002ACC8 File Offset: 0x00028EC8
		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0002ACCC File Offset: 0x00028ECC
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsData data2;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckKey(data, "Key", out data2));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			fsData data3;
			fsResult = (fsResult2 = fsResult + base.CheckKey(data, "Value", out data3));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			Type[] genericArguments = storageType.GetGenericArguments();
			Type storageType2 = genericArguments[0];
			Type storageType3 = genericArguments[1];
			object obj = null;
			object obj2 = null;
			fsResult.AddMessages(this.Serializer.TryDeserialize(data2, storageType2, ref obj));
			fsResult.AddMessages(this.Serializer.TryDeserialize(data3, storageType3, ref obj2));
			instance = Activator.CreateInstance(storageType, new object[]
			{
				obj,
				obj2
			});
			return fsResult;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x0002AD80 File Offset: 0x00028F80
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			PropertyInfo declaredProperty = storageType.GetDeclaredProperty("Key");
			PropertyInfo declaredProperty2 = storageType.GetDeclaredProperty("Value");
			object value = declaredProperty.GetValue(instance, null);
			object value2 = declaredProperty2.GetValue(instance, null);
			Type[] genericArguments = storageType.GetGenericArguments();
			Type storageType2 = genericArguments[0];
			Type storageType3 = genericArguments[1];
			fsResult success = fsResult.Success;
			fsData fsData;
			success.AddMessages(this.Serializer.TrySerialize(storageType2, value, out fsData));
			fsData fsData2;
			success.AddMessages(this.Serializer.TrySerialize(storageType3, value2, out fsData2));
			serialized = fsData.CreateDictionary();
			if (fsData != null)
			{
				serialized.AsDictionary["Key"] = fsData;
			}
			if (fsData2 != null)
			{
				serialized.AsDictionary["Value"] = fsData2;
			}
			return success;
		}
	}
}
