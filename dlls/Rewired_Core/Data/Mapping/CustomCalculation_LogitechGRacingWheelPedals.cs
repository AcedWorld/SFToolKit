using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002B5 RID: 693
	[Serializable]
	public sealed class CustomCalculation_LogitechGRacingWheelPedals : CustomCalculation
	{
		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x06001ED8 RID: 7896 RVA: 0x00018100 File Offset: 0x00016300
		internal override TypeWrapper.DataType ResultType
		{
			get
			{
				return TypeWrapper.DataType.Single;
			}
		}

		// Token: 0x06001ED9 RID: 7897 RVA: 0x0008137C File Offset: 0x0007F57C
		internal bool ZHnpBrFTXmFCYLrNrCxPPLNhGNCV()
		{
			bool flag = false;
			base.ClearResult();
			if (base.DataCount >= 1)
			{
				this._result = this.oWwORUcHinVeGeilVXJFIPNcbITi();
				flag = true;
			}
			base.ClearData();
			this._resultIsValid = flag;
			return flag;
		}

		// Token: 0x06001EDA RID: 7898 RVA: 0x000813BC File Offset: 0x0007F5BC
		private float oWwORUcHinVeGeilVXJFIPNcbITi()
		{
			if (base.DataCount < 2)
			{
				return 0f;
			}
			float result = this._data[0];
			if (this._data[0].type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			if (this._data[1].type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			float num = this._data[0];
			float num2 = this._data[1];
			this.mBmbfLbyHhsIUUWBGeWZGTUljZZb(num, num2);
			if (this.YeTIWePKpEAttvFLzvZEDglzkVFF == CustomCalculation_LogitechGRacingWheelPedals.Mode.SharedAxis)
			{
				float num3 = num2;
				num3 = MathTools.ValueInNewRange(num3, 0f, 1f, 1f, -1f);
				if (num3 > 0f)
				{
					if (num3 > 1f || 1f - num3 <= 0.001f)
					{
						num3 = 1f;
					}
				}
				else if (num3 < 0f && (num3 < -1f || num3 + 1f <= 0.001f))
				{
					num3 = -1f;
				}
				result = num3;
			}
			else if (this.YeTIWePKpEAttvFLzvZEDglzkVFF == CustomCalculation_LogitechGRacingWheelPedals.Mode.SeparateAxes)
			{
				result = num;
			}
			return result;
		}

		// Token: 0x06001EDB RID: 7899 RVA: 0x000814CC File Offset: 0x0007F6CC
		private void mBmbfLbyHhsIUUWBGeWZGTUljZZb(float A_1, float A_2)
		{
			CustomCalculation_LogitechGRacingWheelPedals.Mode yeTIWePKpEAttvFLzvZEDglzkVFF = this.YeTIWePKpEAttvFLzvZEDglzkVFF;
			if (yeTIWePKpEAttvFLzvZEDglzkVFF != CustomCalculation_LogitechGRacingWheelPedals.Mode.SharedAxis)
			{
				if (yeTIWePKpEAttvFLzvZEDglzkVFF != CustomCalculation_LogitechGRacingWheelPedals.Mode.SeparateAxes)
				{
					return;
				}
				if (MathTools.Abs(A_2) >= 0.01f && MathTools.Abs(A_1) <= 0.01f)
				{
					this.YeTIWePKpEAttvFLzvZEDglzkVFF = CustomCalculation_LogitechGRacingWheelPedals.Mode.SharedAxis;
				}
			}
			else if (MathTools.Abs(A_1) >= 0.01f && MathTools.Abs(A_2) <= 0.01f)
			{
				this.YeTIWePKpEAttvFLzvZEDglzkVFF = CustomCalculation_LogitechGRacingWheelPedals.Mode.SeparateAxes;
				return;
			}
		}

		// Token: 0x0400115D RID: 4445
		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

		// Token: 0x0400115E RID: 4446
		private const float dead = 0.01f;

		// Token: 0x0400115F RID: 4447
		[NonSerialized]
		private CustomCalculation_LogitechGRacingWheelPedals.Mode YeTIWePKpEAttvFLzvZEDglzkVFF;

		// Token: 0x020002B6 RID: 694
		public enum Mode
		{
			// Token: 0x04001161 RID: 4449
			SharedAxis,
			// Token: 0x04001162 RID: 4450
			SeparateAxes
		}
	}
}
