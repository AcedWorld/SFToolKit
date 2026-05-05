using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer.Internal;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000192 RID: 402
	public abstract class fsBaseConverter
	{
		// Token: 0x06000A98 RID: 2712 RVA: 0x0002CAE4 File Offset: 0x0002ACE4
		public virtual object CreateInstance(fsData data, Type storageType)
		{
			if (this.RequestCycleSupport(storageType))
			{
				string[] array = new string[5];
				array[0] = "Please override CreateInstance for ";
				int num = 1;
				Type type = base.GetType();
				array[num] = ((type != null) ? type.ToString() : null);
				array[2] = "; the object graph for ";
				array[3] = ((storageType != null) ? storageType.ToString() : null);
				array[4] = " can contain potentially contain cycles, so separated instance creation is needed";
				throw new InvalidOperationException(string.Concat(array));
			}
			return storageType;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0002CB49 File Offset: 0x0002AD49
		public virtual bool RequestCycleSupport(Type storageType)
		{
			return !(storageType == typeof(string)) && (storageType.Resolve().IsClass || storageType.Resolve().IsInterface);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x0002CB79 File Offset: 0x0002AD79
		public virtual bool RequestInheritanceSupport(Type storageType)
		{
			return !storageType.Resolve().IsSealed;
		}

		// Token: 0x06000A9B RID: 2715
		public abstract fsResult TrySerialize(object instance, out fsData serialized, Type storageType);

		// Token: 0x06000A9C RID: 2716
		public abstract fsResult TryDeserialize(fsData data, ref object instance, Type storageType);

		// Token: 0x06000A9D RID: 2717 RVA: 0x0002CB8C File Offset: 0x0002AD8C
		protected fsResult FailExpectedType(fsData data, params fsDataType[] types)
		{
			string[] array = new string[7];
			array[0] = base.GetType().Name;
			array[1] = " expected one of ";
			array[2] = string.Join(", ", (from t in types
			select t.ToString()).ToArray<string>());
			array[3] = " but got ";
			array[4] = data.Type.ToString();
			array[5] = " in ";
			array[6] = ((data != null) ? data.ToString() : null);
			return fsResult.Fail(string.Concat(array));
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0002CC30 File Offset: 0x0002AE30
		protected fsResult CheckType(fsData data, fsDataType type)
		{
			if (data.Type != type)
			{
				return fsResult.Fail(string.Concat(new string[]
				{
					base.GetType().Name,
					" expected ",
					type.ToString(),
					" but got ",
					data.Type.ToString(),
					" in ",
					(data != null) ? data.ToString() : null
				}));
			}
			return fsResult.Success;
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0002CCB9 File Offset: 0x0002AEB9
		protected fsResult CheckKey(fsData data, string key, out fsData subitem)
		{
			return this.CheckKey(data.AsDictionary, key, out subitem);
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x0002CCCC File Offset: 0x0002AECC
		protected fsResult CheckKey(Dictionary<string, fsData> data, string key, out fsData subitem)
		{
			if (!data.TryGetValue(key, out subitem))
			{
				return fsResult.Fail(string.Concat(new string[]
				{
					base.GetType().Name,
					" requires a <",
					key,
					"> key in the data ",
					(data != null) ? data.ToString() : null
				}));
			}
			return fsResult.Success;
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x0002CD2C File Offset: 0x0002AF2C
		protected fsResult SerializeMember<T>(Dictionary<string, fsData> data, Type overrideConverterType, string name, T value)
		{
			fsData value2;
			fsResult result = this.Serializer.TrySerialize(typeof(T), overrideConverterType, value, out value2);
			if (result.Succeeded)
			{
				data[name] = value2;
			}
			return result;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0002CD6C File Offset: 0x0002AF6C
		protected fsResult DeserializeMember<T>(Dictionary<string, fsData> data, Type overrideConverterType, string name, out T value)
		{
			fsData data2;
			if (!data.TryGetValue(name, out data2))
			{
				value = default(T);
				return fsResult.Fail("Unable to find member \"" + name + "\"");
			}
			object obj = null;
			fsResult result = this.Serializer.TryDeserialize(data2, typeof(T), overrideConverterType, ref obj);
			value = (T)((object)obj);
			return result;
		}

		// Token: 0x0400026C RID: 620
		public fsSerializer Serializer;
	}
}
