using System;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.VisualScripting.FullSerializer.Internal.Converters
{
	// Token: 0x020001B4 RID: 436
	public class UnityEvent_Converter : fsConverter
	{
		// Token: 0x06000BA3 RID: 2979 RVA: 0x0003162E File Offset: 0x0002F82E
		public override bool CanProcess(Type type)
		{
			return typeof(UnityEvent).Resolve().IsAssignableFrom(type.Resolve()) && !type.Resolve().IsGenericType;
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0003165C File Offset: 0x0002F85C
		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00031660 File Offset: 0x0002F860
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			Type type = (Type)instance;
			fsResult success = fsResult.Success;
			instance = JsonUtility.FromJson(fsJsonPrinter.CompressedJson(data), type);
			return success;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x00031688 File Offset: 0x0002F888
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			fsResult success = fsResult.Success;
			serialized = fsJsonParser.Parse(JsonUtility.ToJson(instance));
			return success;
		}
	}
}
