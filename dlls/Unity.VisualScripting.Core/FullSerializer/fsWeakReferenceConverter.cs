using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x02000186 RID: 390
	public class fsWeakReferenceConverter : fsConverter
	{
		// Token: 0x06000A63 RID: 2659 RVA: 0x0002B5D8 File Offset: 0x000297D8
		public override bool CanProcess(Type type)
		{
			return type == typeof(WeakReference);
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0002B5EA File Offset: 0x000297EA
		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0002B5ED File Offset: 0x000297ED
		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0002B5F0 File Offset: 0x000297F0
		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			WeakReference weakReference = (WeakReference)instance;
			fsResult fsResult = fsResult.Success;
			serialized = fsData.CreateDictionary();
			if (weakReference.IsAlive)
			{
				fsData value;
				fsResult fsResult2;
				fsResult = (fsResult2 = fsResult + this.Serializer.TrySerialize<object>(weakReference.Target, out value));
				if (fsResult2.Failed)
				{
					return fsResult;
				}
				serialized.AsDictionary["Target"] = value;
				serialized.AsDictionary["TrackResurrection"] = new fsData(weakReference.TrackResurrection);
			}
			return fsResult;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0002B670 File Offset: 0x00029870
		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckType(data, fsDataType.Object));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			if (data.AsDictionary.ContainsKey("Target"))
			{
				fsData data2 = data.AsDictionary["Target"];
				object target = null;
				fsResult = (fsResult2 = fsResult + this.Serializer.TryDeserialize(data2, typeof(object), ref target));
				if (fsResult2.Failed)
				{
					return fsResult;
				}
				bool trackResurrection = false;
				if (data.AsDictionary.ContainsKey("TrackResurrection") && data.AsDictionary["TrackResurrection"].IsBool)
				{
					trackResurrection = data.AsDictionary["TrackResurrection"].AsBool;
				}
				instance = new WeakReference(target, trackResurrection);
			}
			return fsResult;
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0002B741 File Offset: 0x00029941
		public override object CreateInstance(fsData data, Type storageType)
		{
			return new WeakReference(null);
		}
	}
}
