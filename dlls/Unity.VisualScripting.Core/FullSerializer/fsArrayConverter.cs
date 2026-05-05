using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000179 RID: 377
	public class fsArrayConverter : fsConverter
	{
		// Token: 0x06000A0E RID: 2574 RVA: 0x00029B50 File Offset: 0x00027D50
		public override bool CanProcess(Type type)
		{
			return type.IsArray;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00029B58 File Offset: 0x00027D58
		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00029B5B File Offset: 0x00027D5B
		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00029B60 File Offset: 0x00027D60
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			IList list = (Array)instance;
			Type elementType = storageType.GetElementType();
			fsResult success = fsResult.Success;
			serialized = fsData.CreateList(list.Count);
			List<fsData> asList = serialized.AsList;
			for (int i = 0; i < list.Count; i++)
			{
				object instance2 = list[i];
				fsData item;
				fsResult result = this.Serializer.TrySerialize(elementType, instance2, out item);
				success.AddMessages(result);
				if (!result.Failed)
				{
					asList.Add(item);
				}
			}
			return success;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00029BE4 File Offset: 0x00027DE4
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckType(data, fsDataType.Array));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			Type elementType = storageType.GetElementType();
			List<fsData> asList = data.AsList;
			ArrayList arrayList = new ArrayList(asList.Count);
			int count = arrayList.Count;
			for (int i = 0; i < asList.Count; i++)
			{
				fsData data2 = asList[i];
				object value = null;
				if (i < count)
				{
					value = arrayList[i];
				}
				fsResult result = this.Serializer.TryDeserialize(data2, elementType, ref value);
				fsResult.AddMessages(result);
				if (!result.Failed)
				{
					if (i < count)
					{
						arrayList[i] = value;
					}
					else
					{
						arrayList.Add(value);
					}
				}
			}
			instance = arrayList.ToArray(elementType);
			return fsResult;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00029CB1 File Offset: 0x00027EB1
		public override object CreateInstance(fsData data, Type storageType)
		{
			return fsMetaType.Get(this.Serializer.Config, storageType).CreateInstance();
		}
	}
}
