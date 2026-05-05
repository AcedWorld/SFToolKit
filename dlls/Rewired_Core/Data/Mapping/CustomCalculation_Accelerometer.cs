using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x020002AE RID: 686
	[Serializable]
	public sealed class CustomCalculation_Accelerometer : CustomCalculation
	{
		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x06001ECA RID: 7882 RVA: 0x00018100 File Offset: 0x00016300
		internal override TypeWrapper.DataType ResultType
		{
			get
			{
				return TypeWrapper.DataType.Single;
			}
		}

		// Token: 0x06001ECB RID: 7883 RVA: 0x00080FD8 File Offset: 0x0007F1D8
		internal bool gBgYYNLwiuKFsHHFZoqHnqEYiTsk()
		{
			bool flag = false;
			base.ClearResult();
			if (base.DataCount >= 1)
			{
				CustomCalculation_Accelerometer.CalculationType calculationType = this._calculationType;
				if (calculationType != CustomCalculation_Accelerometer.CalculationType.Pitch)
				{
					if (calculationType == CustomCalculation_Accelerometer.CalculationType.Roll)
					{
						this._result = this.zYadxgAJEoIoCPOERNVPGjwdiuNHc();
						flag = true;
					}
				}
				else
				{
					this._result = this.RGdPrcujoTgioFDywjncVrqJDLNk();
					flag = true;
				}
			}
			base.ClearData();
			this._resultIsValid = flag;
			return flag;
		}

		// Token: 0x06001ECC RID: 7884 RVA: 0x0008103C File Offset: 0x0007F23C
		private float RGdPrcujoTgioFDywjncVrqJDLNk()
		{
			Vector3 vector = default(Vector3);
			int num = MathTools.Min(base.DataCount, 3);
			for (int i = 0; i < num; i++)
			{
				if (this._data[i].type == TypeWrapper.DataType.Single)
				{
					vector[i] = this._data[i];
				}
			}
			float num2;
			if (this._inputType == CustomCalculation_Accelerometer.InputType.Gravity)
			{
				if (vector.x == 0f && vector.y == 0f && vector.z == 0f)
				{
					return 0f;
				}
				num2 = -MathTools.Atan2(-vector.z, -vector.y) * 57.29578f;
			}
			else
			{
				num2 = 0f;
			}
			CustomCalculation_Accelerometer.OutputType outputType = this._outputType;
			if (outputType == CustomCalculation_Accelerometer.OutputType.Axis)
			{
				return this.WRBeFYJFRKxbEUVHFrhejKysDUCu(num2);
			}
			if (outputType == CustomCalculation_Accelerometer.OutputType.Angle)
			{
				return num2;
			}
			return 0f;
		}

		// Token: 0x06001ECD RID: 7885 RVA: 0x00081114 File Offset: 0x0007F314
		private float zYadxgAJEoIoCPOERNVPGjwdiuNHc()
		{
			Vector3 vector = default(Vector3);
			int num = MathTools.Min(base.DataCount, 3);
			for (int i = 0; i < num; i++)
			{
				vector[i] = this._data[i];
			}
			float num2;
			if (this._inputType == CustomCalculation_Accelerometer.InputType.Gravity)
			{
				if (vector.x == 0f && vector.y == 0f && vector.z == 0f)
				{
					return 0f;
				}
				num2 = -MathTools.Atan2(vector.x, -vector.y) * 57.29578f;
			}
			else
			{
				num2 = 0f;
			}
			CustomCalculation_Accelerometer.OutputType outputType = this._outputType;
			if (outputType == CustomCalculation_Accelerometer.OutputType.Axis)
			{
				return this.WRBeFYJFRKxbEUVHFrhejKysDUCu(num2);
			}
			if (outputType == CustomCalculation_Accelerometer.OutputType.Angle)
			{
				return num2;
			}
			return 0f;
		}

		// Token: 0x06001ECE RID: 7886 RVA: 0x00018104 File Offset: 0x00016304
		private float WRBeFYJFRKxbEUVHFrhejKysDUCu(float A_1)
		{
			if (A_1 == 0f)
			{
				return 0f;
			}
			return MathTools.Abs(A_1) / 180f * MathTools.Sign(A_1);
		}

		// Token: 0x04001148 RID: 4424
		public CustomCalculation_Accelerometer.CalculationType _calculationType;

		// Token: 0x04001149 RID: 4425
		public CustomCalculation_Accelerometer.InputType _inputType;

		// Token: 0x0400114A RID: 4426
		public CustomCalculation_Accelerometer.OutputType _outputType;

		// Token: 0x020002AF RID: 687
		public enum CalculationType
		{
			// Token: 0x0400114C RID: 4428
			Pitch,
			// Token: 0x0400114D RID: 4429
			Roll
		}

		// Token: 0x020002B0 RID: 688
		public enum OutputType
		{
			// Token: 0x0400114F RID: 4431
			Axis,
			// Token: 0x04001150 RID: 4432
			Angle
		}

		// Token: 0x020002B1 RID: 689
		public enum InputType
		{
			// Token: 0x04001152 RID: 4434
			Acceleration,
			// Token: 0x04001153 RID: 4435
			UserAcceleration,
			// Token: 0x04001154 RID: 4436
			Gravity
		}
	}
}
