using System;
using Rewired.Utils.Attributes;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003BA RID: 954
	[Serializable]
	public struct NintendoSwitchGamepadVibration : IEquatable<NintendoSwitchGamepadVibration>
	{
		// Token: 0x06002661 RID: 9825 RVA: 0x000946AC File Offset: 0x000928AC
		internal NintendoSwitchGamepadVibration(float A_1, float A_2, float A_3, float A_4)
		{
			if (A_1 < 0f)
			{
				A_1 = 0f;
			}
			if (A_1 > 1f)
			{
				A_1 = 1f;
			}
			if (A_2 < 0f)
			{
				A_2 = 0f;
			}
			if (A_3 < 0f)
			{
				A_3 = 0f;
			}
			if (A_3 > 1f)
			{
				A_3 = 1f;
			}
			if (A_4 < 0f)
			{
				A_4 = 0f;
			}
			this.amplitudeLow = A_1;
			this.frequencyLow = A_2;
			this.amplitudeHigh = A_3;
			this.frequencyHigh = A_4;
		}

		// Token: 0x06002662 RID: 9826 RVA: 0x0001C39A File Offset: 0x0001A59A
		public bool Equals(NintendoSwitchGamepadVibration other)
		{
			return this.amplitudeLow == other.amplitudeLow && this.frequencyLow == other.frequencyLow && this.amplitudeHigh == other.amplitudeHigh && this.frequencyHigh == other.frequencyHigh;
		}

		// Token: 0x06002663 RID: 9827 RVA: 0x0001C3D6 File Offset: 0x0001A5D6
		public override bool Equals(object obj)
		{
			return obj != null && obj is NintendoSwitchGamepadVibration && this.Equals((NintendoSwitchGamepadVibration)obj);
		}

		// Token: 0x06002664 RID: 9828 RVA: 0x0001C3F1 File Offset: 0x0001A5F1
		public override int GetHashCode()
		{
			return (((17 * 29 + this.amplitudeLow.GetHashCode()) * 29 + this.frequencyLow.GetHashCode()) * 29 + this.amplitudeHigh.GetHashCode()) * 29 + this.frequencyHigh.GetHashCode();
		}

		// Token: 0x06002665 RID: 9829 RVA: 0x0001C39A File Offset: 0x0001A59A
		public static bool operator ==(NintendoSwitchGamepadVibration a, NintendoSwitchGamepadVibration b)
		{
			return a.amplitudeLow == b.amplitudeLow && a.frequencyLow == b.frequencyLow && a.amplitudeHigh == b.amplitudeHigh && a.frequencyHigh == b.frequencyHigh;
		}

		// Token: 0x06002666 RID: 9830 RVA: 0x0001C431 File Offset: 0x0001A631
		public static bool operator !=(NintendoSwitchGamepadVibration a, NintendoSwitchGamepadVibration b)
		{
			return !(a == b);
		}

		// Token: 0x06002667 RID: 9831 RVA: 0x00094734 File Offset: 0x00092934
		public override string ToString()
		{
			return string.Format("Low:{0}, {1}Hz, High:{2}, {3}Hz", new object[]
			{
				this.amplitudeLow.ToString("f3"),
				this.frequencyLow.ToString("f3"),
				this.amplitudeHigh.ToString("f3"),
				this.frequencyHigh.ToString("f3")
			});
		}

		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06002668 RID: 9832 RVA: 0x000947A0 File Offset: 0x000929A0
		internal static NintendoSwitchGamepadVibration KxaOiDOpcHZejzePlLdBIqvsCYsO
		{
			get
			{
				return default(NintendoSwitchGamepadVibration);
			}
		}

		// Token: 0x06002669 RID: 9833 RVA: 0x0001C43D File Offset: 0x0001A63D
		public static NintendoSwitchGamepadVibration Create()
		{
			return new NintendoSwitchGamepadVibration(0f, 160f, 0f, 320f);
		}

		// Token: 0x0600266A RID: 9834 RVA: 0x0001C458 File Offset: 0x0001A658
		public static NintendoSwitchGamepadVibration Create(float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			return new NintendoSwitchGamepadVibration(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
		}

		// Token: 0x0600266B RID: 9835 RVA: 0x0001C463 File Offset: 0x0001A663
		public static NintendoSwitchGamepadVibration Create(float amplitudeLow, float amplitudeHigh)
		{
			return new NintendoSwitchGamepadVibration(amplitudeLow, 160f, amplitudeHigh, 320f);
		}

		// Token: 0x040015DB RID: 5595
		internal const int frequencyLowDefault = 160;

		// Token: 0x040015DC RID: 5596
		internal const int frequencyHighDefault = 320;

		// Token: 0x040015DD RID: 5597
		public const float frequencyLowMin = 40.875885f;

		// Token: 0x040015DE RID: 5598
		public const float frequencyLowMax = 626.28613f;

		// Token: 0x040015DF RID: 5599
		public const float frequencyHighMin = 81.75177f;

		// Token: 0x040015E0 RID: 5600
		public const float frequencyHighMax = 1252.5723f;

		// Token: 0x040015E1 RID: 5601
		[FieldRange(0f, 1f)]
		public float amplitudeLow;

		// Token: 0x040015E2 RID: 5602
		[FieldRange(40.875885f, 626.28613f)]
		public float frequencyLow;

		// Token: 0x040015E3 RID: 5603
		[FieldRange(0f, 1f)]
		public float amplitudeHigh;

		// Token: 0x040015E4 RID: 5604
		[FieldRange(81.75177f, 1252.5723f)]
		public float frequencyHigh;
	}
}
