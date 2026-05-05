using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000133 RID: 307
	public class UnityObjectConverter : fsConverter
	{
		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000853 RID: 2131 RVA: 0x00025733 File Offset: 0x00023933
		private List<Object> objectReferences
		{
			get
			{
				return this.Serializer.Context.Get<List<Object>>();
			}
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00025745 File Offset: 0x00023945
		public override bool CanProcess(Type type)
		{
			return typeof(Object).IsAssignableFrom(type);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00025757 File Offset: 0x00023957
		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0002575A File Offset: 0x0002395A
		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00025760 File Offset: 0x00023960
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			Object item = (Object)instance;
			int count = this.objectReferences.Count;
			serialized = new fsData((long)count);
			this.objectReferences.Add(item);
			return fsResult.Success;
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0002579C File Offset: 0x0002399C
		public override fsResult TryDeserialize(fsData storage, ref object instance, Type storageType)
		{
			int num = (int)storage.AsInt64;
			fsResult success = fsResult.Success;
			if (num >= 0 && num < this.objectReferences.Count)
			{
				Object @object = this.objectReferences[num];
				instance = @object;
				if (instance != null && !storageType.IsInstanceOfType(instance))
				{
					if (@object.GetHashCode() != 0)
					{
						success.AddMessage(string.Format("Object reference at index #{0} does not match target type ({1} != {2}). Defaulting to null.", num, instance.GetType(), storageType));
					}
					instance = null;
				}
			}
			else
			{
				success.AddMessage(string.Format("No object reference provided at index #{0}. Defaulting to null.", num));
				instance = null;
			}
			return success;
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0002582E File Offset: 0x00023A2E
		public override object CreateInstance(fsData data, Type storageType)
		{
			return storageType;
		}
	}
}
