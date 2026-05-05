using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002B4 RID: 692
	[Serializable]
	public sealed class CustomCalculation_FirstNonZero : CustomCalculation
	{
		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x06001ED4 RID: 7892 RVA: 0x00018100 File Offset: 0x00016300
		internal override TypeWrapper.DataType ResultType
		{
			get
			{
				return TypeWrapper.DataType.Single;
			}
		}

		// Token: 0x06001ED5 RID: 7893 RVA: 0x000812CC File Offset: 0x0007F4CC
		internal bool iFsXPcgDyyfHrUJloIooGteyheaW()
		{
			bool flag = false;
			base.ClearResult();
			if (base.DataCount >= 1)
			{
				this._result = this.ZXJRRxiSIxlXpuvoERoOktCZQXVl();
				flag = true;
			}
			base.ClearData();
			this._resultIsValid = flag;
			return flag;
		}

		// Token: 0x06001ED6 RID: 7894 RVA: 0x0008130C File Offset: 0x0007F50C
		private float ZXJRRxiSIxlXpuvoERoOktCZQXVl()
		{
			int dataCount = base.DataCount;
			if (dataCount == 0)
			{
				return 0f;
			}
			float result = 0f;
			for (int i = 0; i < dataCount; i++)
			{
				if (this._data[i].type != TypeWrapper.DataType.Single)
				{
					throw new Exception("Data type must be the same on all data fields!");
				}
				float num = this._data[i];
				if (num != 0f)
				{
					result = num;
					break;
				}
			}
			return result;
		}

		// Token: 0x0400115C RID: 4444
		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;
	}
}
