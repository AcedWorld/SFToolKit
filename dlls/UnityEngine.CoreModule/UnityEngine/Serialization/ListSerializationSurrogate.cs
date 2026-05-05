using System;
using System.Collections;
using System.Runtime.Serialization;

namespace UnityEngine.Serialization
{
	// Token: 0x0200030E RID: 782
	internal class ListSerializationSurrogate : ISerializationSurrogate
	{
		// Token: 0x06002017 RID: 8215 RVA: 0x00035648 File Offset: 0x00033848
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			IList list = (IList)obj;
			info.AddValue("_size", list.Count);
			info.AddValue("_items", ListSerializationSurrogate.ArrayFromGenericList(list));
			info.AddValue("_version", 0);
		}

		// Token: 0x06002018 RID: 8216 RVA: 0x00035690 File Offset: 0x00033890
		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			IList list = (IList)Activator.CreateInstance(obj.GetType());
			int @int = info.GetInt32("_size");
			bool flag = @int == 0;
			object result;
			if (flag)
			{
				result = list;
			}
			else
			{
				IEnumerator enumerator = ((IEnumerable)info.GetValue("_items", typeof(IEnumerable))).GetEnumerator();
				for (int i = 0; i < @int; i++)
				{
					bool flag2 = !enumerator.MoveNext();
					if (flag2)
					{
						throw new InvalidOperationException();
					}
					list.Add(enumerator.Current);
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06002019 RID: 8217 RVA: 0x0003572C File Offset: 0x0003392C
		private static Array ArrayFromGenericList(IList list)
		{
			Array array = Array.CreateInstance(list.GetType().GetGenericArguments()[0], list.Count);
			list.CopyTo(array, 0);
			return array;
		}

		// Token: 0x04000A82 RID: 2690
		public static readonly ISerializationSurrogate Default = new ListSerializationSurrogate();
	}
}
