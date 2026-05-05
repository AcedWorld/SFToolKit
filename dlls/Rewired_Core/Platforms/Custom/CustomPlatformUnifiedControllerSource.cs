using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired.Platforms.Custom
{
	// Token: 0x02000229 RID: 553
	public abstract class CustomPlatformUnifiedControllerSource : IDisposable
	{
		// Token: 0x060019B5 RID: 6581 RVA: 0x00071B24 File Offset: 0x0006FD24
		public CustomPlatformUnifiedControllerSource(int A_1, int A_2)
		{
			if (A_1 < 0)
			{
				A_1 = 0;
			}
			if (A_2 < 0)
			{
				A_2 = 0;
			}
			this.JFQKrdKMWbVoYTZnYdDeqGZEdOMbA = A_1;
			this.ESwgOusbyeGNdYgqffrFcabWHpOCb = A_2;
			this.ZHkEIbFCJAmpbuTaYUyneXTYaMvsA = new float[A_1];
			this.CDrCgObaGycdLCqgRMWrtApfCKPm = new bool[A_2];
			this.lMBBKbKwZqDLqXpRmHZfevAMvqEkA = new bool[A_2];
		}

		// Token: 0x060019B6 RID: 6582
		protected abstract void Update();

		// Token: 0x060019B7 RID: 6583 RVA: 0x00002FF9 File Offset: 0x000011F9
		internal virtual void xKzVJkKASxJwMuJCSdFUwhgAYzYN()
		{
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x060019B8 RID: 6584 RVA: 0x00015102 File Offset: 0x00013302
		public int axisCount
		{
			get
			{
				return this.JFQKrdKMWbVoYTZnYdDeqGZEdOMbA;
			}
		}

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x060019B9 RID: 6585 RVA: 0x0001510A File Offset: 0x0001330A
		public int buttonCount
		{
			get
			{
				return this.ESwgOusbyeGNdYgqffrFcabWHpOCb;
			}
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x060019BA RID: 6586 RVA: 0x000067FE File Offset: 0x000049FE
		public virtual Controller.Extension controllerExtension
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060019BB RID: 6587 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnInitialize()
		{
		}

		// Token: 0x060019BC RID: 6588 RVA: 0x00015112 File Offset: 0x00013312
		protected virtual void Clear()
		{
			Array.Clear(this.ZHkEIbFCJAmpbuTaYUyneXTYaMvsA, 0, this.JFQKrdKMWbVoYTZnYdDeqGZEdOMbA);
			Array.Clear(this.CDrCgObaGycdLCqgRMWrtApfCKPm, 0, this.ESwgOusbyeGNdYgqffrFcabWHpOCb);
			Array.Clear(this.lMBBKbKwZqDLqXpRmHZfevAMvqEkA, 0, this.ESwgOusbyeGNdYgqffrFcabWHpOCb);
		}

		// Token: 0x060019BD RID: 6589 RVA: 0x0001514A File Offset: 0x0001334A
		protected float GetAxisValue(int index)
		{
			if (index >= this.axisCount)
			{
				return 0f;
			}
			return this.ZHkEIbFCJAmpbuTaYUyneXTYaMvsA[index];
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x00015163 File Offset: 0x00013363
		protected bool GetButtonValue(int index)
		{
			return index < this.buttonCount && this.CDrCgObaGycdLCqgRMWrtApfCKPm[index];
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x00015178 File Offset: 0x00013378
		protected void SetAxisValue(int index, float value)
		{
			if (index >= this.axisCount)
			{
				return;
			}
			this.ZHkEIbFCJAmpbuTaYUyneXTYaMvsA[index] = value;
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x00071B78 File Offset: 0x0006FD78
		protected void SetAxisValues(IList<float> values)
		{
			if (values == null)
			{
				return;
			}
			int num = MathTools.Min(values.Count, this.axisCount);
			if (values is float[])
			{
				Array.Copy(values as float[], this.ZHkEIbFCJAmpbuTaYUyneXTYaMvsA, num);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				this.ZHkEIbFCJAmpbuTaYUyneXTYaMvsA[i] = values[i];
			}
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x0001518D File Offset: 0x0001338D
		protected void SetButtonValue(int index, bool value)
		{
			if (index >= this.buttonCount)
			{
				return;
			}
			if (!this.CDrCgObaGycdLCqgRMWrtApfCKPm[index] && value)
			{
				this.lMBBKbKwZqDLqXpRmHZfevAMvqEkA[index] = true;
			}
			this.CDrCgObaGycdLCqgRMWrtApfCKPm[index] = value;
		}

		// Token: 0x060019C2 RID: 6594 RVA: 0x00071BD4 File Offset: 0x0006FDD4
		protected void SetButtonValues(IList<bool> values)
		{
			if (values == null)
			{
				return;
			}
			int num = MathTools.Min(values.Count, this.buttonCount);
			if (values is bool[])
			{
				for (int i = 0; i < num; i++)
				{
					if (!this.CDrCgObaGycdLCqgRMWrtApfCKPm[i] && values[i])
					{
						this.lMBBKbKwZqDLqXpRmHZfevAMvqEkA[i] = true;
					}
				}
				Array.Copy(values as bool[], this.CDrCgObaGycdLCqgRMWrtApfCKPm, num);
				return;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag = values[j];
				if (!this.CDrCgObaGycdLCqgRMWrtApfCKPm[j] && flag)
				{
					this.lMBBKbKwZqDLqXpRmHZfevAMvqEkA[j] = true;
				}
				this.CDrCgObaGycdLCqgRMWrtApfCKPm[j] = flag;
			}
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x000151BA File Offset: 0x000133BA
		internal void luUCqwDxiPWMUkHqPIkyHphHcmjj()
		{
			this.OnInitialize();
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x000151C2 File Offset: 0x000133C2
		internal void qoqWwYtbzmvNYDwKOzCDSSNJRJvg()
		{
			this.Clear();
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x00071C70 File Offset: 0x0006FE70
		internal void DiokwKRKPsufUdtRbXpjKgStBxli(ControllerDataUpdater A_1)
		{
			this.WiEiwHAKVFjjeFVgmRmFsdrdvtBv();
			this.Update();
			this.xKzVJkKASxJwMuJCSdFUwhgAYzYN();
			Array.Copy(this.ZHkEIbFCJAmpbuTaYUyneXTYaMvsA, A_1.axisValues, this.JFQKrdKMWbVoYTZnYdDeqGZEdOMbA);
			for (int i = 0; i < this.JFQKrdKMWbVoYTZnYdDeqGZEdOMbA; i++)
			{
				if (this.ZHkEIbFCJAmpbuTaYUyneXTYaMvsA[i] != 0f && !A_1.hasReceivedInput)
				{
					A_1.hasReceivedInput = true;
				}
			}
			Array.Copy(this.CDrCgObaGycdLCqgRMWrtApfCKPm, A_1.buttonValues, this.ESwgOusbyeGNdYgqffrFcabWHpOCb);
			for (int j = 0; j < this.ESwgOusbyeGNdYgqffrFcabWHpOCb; j++)
			{
				if (this.CDrCgObaGycdLCqgRMWrtApfCKPm[j] && !A_1.hasReceivedInput)
				{
					A_1.hasReceivedInput = true;
				}
				if (this.lMBBKbKwZqDLqXpRmHZfevAMvqEkA[j] && !this.CDrCgObaGycdLCqgRMWrtApfCKPm[j])
				{
					this.CDrCgObaGycdLCqgRMWrtApfCKPm[j] = true;
				}
			}
		}

		// Token: 0x060019C6 RID: 6598 RVA: 0x000151CA File Offset: 0x000133CA
		private void WiEiwHAKVFjjeFVgmRmFsdrdvtBv()
		{
			Array.Clear(this.lMBBKbKwZqDLqXpRmHZfevAMvqEkA, 0, this.lMBBKbKwZqDLqXpRmHZfevAMvqEkA.Length);
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x000151E0 File Offset: 0x000133E0
		protected virtual void Dispose(bool disposing)
		{
			if (!this.ZawGYxgCgoNBvdsPOoomtTLPvUlN)
			{
				this.ZawGYxgCgoNBvdsPOoomtTLPvUlN = true;
			}
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x000151F3 File Offset: 0x000133F3
		void IDisposable.Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000EB4 RID: 3764
		private readonly int JFQKrdKMWbVoYTZnYdDeqGZEdOMbA;

		// Token: 0x04000EB5 RID: 3765
		private readonly int ESwgOusbyeGNdYgqffrFcabWHpOCb;

		// Token: 0x04000EB6 RID: 3766
		private readonly bool[] CDrCgObaGycdLCqgRMWrtApfCKPm;

		// Token: 0x04000EB7 RID: 3767
		private readonly bool[] lMBBKbKwZqDLqXpRmHZfevAMvqEkA;

		// Token: 0x04000EB8 RID: 3768
		private readonly float[] ZHkEIbFCJAmpbuTaYUyneXTYaMvsA;

		// Token: 0x04000EB9 RID: 3769
		private bool ZawGYxgCgoNBvdsPOoomtTLPvUlN;
	}
}
