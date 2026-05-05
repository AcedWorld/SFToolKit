using System;
using System.Collections.Generic;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200019A RID: 410
	public abstract class fsDirectConverter<TModel> : fsDirectConverter
	{
		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x0002D423 File Offset: 0x0002B623
		public override Type ModelType
		{
			get
			{
				return typeof(TModel);
			}
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0002D430 File Offset: 0x0002B630
		public sealed override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
			fsResult result = this.DoSerialize((TModel)((object)instance), dictionary);
			serialized = new fsData(dictionary);
			return result;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0002D458 File Offset: 0x0002B658
		public sealed override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckType(data, fsDataType.Object));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			TModel tmodel = (TModel)((object)instance);
			fsResult += this.DoDeserialize(data.AsDictionary, ref tmodel);
			instance = tmodel;
			return fsResult;
		}

		// Token: 0x06000AD4 RID: 2772
		protected abstract fsResult DoSerialize(TModel model, Dictionary<string, fsData> serialized);

		// Token: 0x06000AD5 RID: 2773
		protected abstract fsResult DoDeserialize(Dictionary<string, fsData> data, ref TModel model);
	}
}
