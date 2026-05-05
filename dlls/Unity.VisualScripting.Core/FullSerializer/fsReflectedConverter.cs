using System;
using System.Collections;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000184 RID: 388
	public class fsReflectedConverter : fsConverter
	{
		// Token: 0x06000A57 RID: 2647 RVA: 0x0002B363 File Offset: 0x00029563
		public override bool CanProcess(Type type)
		{
			return !type.Resolve().IsArray && !typeof(ICollection).IsAssignableFrom(type);
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0002B388 File Offset: 0x00029588
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = fsData.CreateDictionary();
			fsResult success = fsResult.Success;
			fsMetaType fsMetaType = fsMetaType.Get(this.Serializer.Config, instance.GetType());
			fsMetaType.EmitAotData();
			for (int i = 0; i < fsMetaType.Properties.Length; i++)
			{
				fsMetaProperty fsMetaProperty = fsMetaType.Properties[i];
				if (fsMetaProperty.CanRead)
				{
					fsData value;
					fsResult result = this.Serializer.TrySerialize(fsMetaProperty.StorageType, fsMetaProperty.OverrideConverterType, fsMetaProperty.Read(instance), out value);
					success.AddMessages(result);
					if (!result.Failed)
					{
						serialized.AsDictionary[fsMetaProperty.JsonName] = value;
					}
				}
			}
			return success;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0002B430 File Offset: 0x00029630
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckType(data, fsDataType.Object));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			fsMetaType fsMetaType = fsMetaType.Get(this.Serializer.Config, storageType);
			fsMetaType.EmitAotData();
			for (int i = 0; i < fsMetaType.Properties.Length; i++)
			{
				fsMetaProperty fsMetaProperty = fsMetaType.Properties[i];
				fsData data2;
				if (fsMetaProperty.CanWrite && data.AsDictionary.TryGetValue(fsMetaProperty.JsonName, out data2))
				{
					object value = null;
					if (fsMetaProperty.CanRead)
					{
						value = fsMetaProperty.Read(instance);
					}
					fsResult result = this.Serializer.TryDeserialize(data2, fsMetaProperty.StorageType, fsMetaProperty.OverrideConverterType, ref value);
					fsResult.AddMessages(result);
					if (!result.Failed)
					{
						fsMetaProperty.Write(instance, value);
					}
				}
			}
			return fsResult;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0002B50E File Offset: 0x0002970E
		public override object CreateInstance(fsData data, Type storageType)
		{
			return fsMetaType.Get(this.Serializer.Config, storageType).CreateInstance();
		}
	}
}
