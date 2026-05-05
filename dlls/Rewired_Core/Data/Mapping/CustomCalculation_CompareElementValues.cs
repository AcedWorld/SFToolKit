using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002B2 RID: 690
	[Serializable]
	public sealed class CustomCalculation_CompareElementValues : CustomCalculation
	{
		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x06001ED0 RID: 7888 RVA: 0x00018100 File Offset: 0x00016300
		internal override TypeWrapper.DataType ResultType
		{
			get
			{
				return TypeWrapper.DataType.Single;
			}
		}

		// Token: 0x06001ED1 RID: 7889 RVA: 0x000811D4 File Offset: 0x0007F3D4
		internal bool BUznbHIwKrtJYamaXPuvgySNRKIy()
		{
			bool flag = false;
			base.ClearResult();
			if (base.DataCount >= 1)
			{
				this._result = this.zqXRaRaKlZMtbENsHbzkfZiEkXEq();
				flag = true;
			}
			base.ClearData();
			this._resultIsValid = flag;
			return flag;
		}

		// Token: 0x06001ED2 RID: 7890 RVA: 0x00081214 File Offset: 0x0007F414
		private float zqXRaRaKlZMtbENsHbzkfZiEkXEq()
		{
			int dataCount = base.DataCount;
			if (dataCount == 0)
			{
				return 0f;
			}
			float num = this._data[0];
			for (int i = 1; i < dataCount; i++)
			{
				if (this._data[i].type != TypeWrapper.DataType.Single)
				{
					throw new Exception("Data type must be the same on all data fields!");
				}
				float num2 = this._data[i];
				switch (this._comparisonType)
				{
				case CustomCalculation_CompareElementValues.ComparisonType.Min:
					num = Math.Min(num, num2);
					break;
				case CustomCalculation_CompareElementValues.ComparisonType.Max:
					num = Math.Max(num, num2);
					break;
				case CustomCalculation_CompareElementValues.ComparisonType.MinAbs:
					num = MathTools.MinMagnitude(num, num2);
					break;
				case CustomCalculation_CompareElementValues.ComparisonType.MaxAbs:
					num = MathTools.MaxMagnitude(num, num2);
					break;
				}
			}
			return num;
		}

		// Token: 0x04001155 RID: 4437
		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

		// Token: 0x04001156 RID: 4438
		[SerializeField]
		private CustomCalculation_CompareElementValues.ComparisonType _comparisonType;

		// Token: 0x020002B3 RID: 691
		public enum ComparisonType
		{
			// Token: 0x04001158 RID: 4440
			Min,
			// Token: 0x04001159 RID: 4441
			Max,
			// Token: 0x0400115A RID: 4442
			MinAbs,
			// Token: 0x0400115B RID: 4443
			MaxAbs
		}
	}
}
