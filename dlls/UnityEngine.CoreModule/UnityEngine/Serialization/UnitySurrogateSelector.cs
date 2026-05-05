using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UnityEngine.Serialization
{
	// Token: 0x0200030D RID: 781
	public class UnitySurrogateSelector : ISurrogateSelector
	{
		// Token: 0x06002013 RID: 8211 RVA: 0x000355BC File Offset: 0x000337BC
		public ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector selector)
		{
			bool isGenericType = type.IsGenericType;
			if (isGenericType)
			{
				Type genericTypeDefinition = type.GetGenericTypeDefinition();
				bool flag = genericTypeDefinition == typeof(List<>);
				if (flag)
				{
					selector = this;
					return ListSerializationSurrogate.Default;
				}
				bool flag2 = genericTypeDefinition == typeof(Dictionary<, >);
				if (flag2)
				{
					selector = this;
					Type type2 = typeof(DictionarySerializationSurrogate<, >).MakeGenericType(type.GetGenericArguments());
					return (ISerializationSurrogate)Activator.CreateInstance(type2);
				}
			}
			selector = null;
			return null;
		}

		// Token: 0x06002014 RID: 8212 RVA: 0x0001940C File Offset: 0x0001760C
		public void ChainSelector(ISurrogateSelector selector)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06002015 RID: 8213 RVA: 0x0001940C File Offset: 0x0001760C
		public ISurrogateSelector GetNextSelector()
		{
			throw new NotImplementedException();
		}
	}
}
