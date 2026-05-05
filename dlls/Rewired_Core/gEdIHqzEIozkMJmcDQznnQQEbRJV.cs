using System;
using Rewired;

// Token: 0x02000010 RID: 16
internal struct gEdIHqzEIozkMJmcDQznnQQEbRJV : IEquatable<gEdIHqzEIozkMJmcDQznnQQEbRJV>
{
	// Token: 0x06000127 RID: 295 RVA: 0x00003108 File Offset: 0x00001308
	public gEdIHqzEIozkMJmcDQznnQQEbRJV(KeyboardKeyCode A_1, ModifierKey A_2, ModifierKey A_3, ModifierKey A_4)
	{
		this.EfoQRJNUuJeUKhfmShwehIwMtBjiA = A_1;
		this.FKmJBiaaLhYbddCqqiXkDdQmFdNm = A_2;
		this.NGtrrHiclzuaMjbiauZkDWHXUxEQ = A_3;
		this.BJMqmqCEZpAukivFcfZJGFoaDqptA = A_4;
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00003127 File Offset: 0x00001327
	public void eYdPpZEUCflCptqgDBZlMXAFXwsT()
	{
		if (this.EfoQRJNUuJeUKhfmShwehIwMtBjiA != KeyboardKeyCode.None)
		{
			this.EfoQRJNUuJeUKhfmShwehIwMtBjiA = KeyboardKeyCode.None;
		}
		if (this.FKmJBiaaLhYbddCqqiXkDdQmFdNm != ModifierKey.None)
		{
			this.FKmJBiaaLhYbddCqqiXkDdQmFdNm = ModifierKey.None;
		}
		if (this.NGtrrHiclzuaMjbiauZkDWHXUxEQ != ModifierKey.None)
		{
			this.NGtrrHiclzuaMjbiauZkDWHXUxEQ = ModifierKey.None;
		}
		if (this.BJMqmqCEZpAukivFcfZJGFoaDqptA != ModifierKey.None)
		{
			this.BJMqmqCEZpAukivFcfZJGFoaDqptA = ModifierKey.None;
		}
	}

	// Token: 0x06000129 RID: 297 RVA: 0x00003165 File Offset: 0x00001365
	public bool Equals(gEdIHqzEIozkMJmcDQznnQQEbRJV other)
	{
		return this.EfoQRJNUuJeUKhfmShwehIwMtBjiA == other.EfoQRJNUuJeUKhfmShwehIwMtBjiA && this.FKmJBiaaLhYbddCqqiXkDdQmFdNm == other.FKmJBiaaLhYbddCqqiXkDdQmFdNm && this.NGtrrHiclzuaMjbiauZkDWHXUxEQ == other.NGtrrHiclzuaMjbiauZkDWHXUxEQ && this.BJMqmqCEZpAukivFcfZJGFoaDqptA == other.BJMqmqCEZpAukivFcfZJGFoaDqptA;
	}

	// Token: 0x0600012A RID: 298 RVA: 0x000031A1 File Offset: 0x000013A1
	public bool psbqGLHowpEEsRFXfEqJJDfsMlzU(object A_1)
	{
		return A_1 != null && A_1 is gEdIHqzEIozkMJmcDQznnQQEbRJV && this.Equals((gEdIHqzEIozkMJmcDQznnQQEbRJV)A_1);
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0002C0E0 File Offset: 0x0002A2E0
	public int yWRuuSNqGKHDcPzROiPwiAzSKxqV()
	{
		return (((17 * 29 + this.EfoQRJNUuJeUKhfmShwehIwMtBjiA.GetHashCode()) * 29 + this.FKmJBiaaLhYbddCqqiXkDdQmFdNm.GetHashCode()) * 29 + this.NGtrrHiclzuaMjbiauZkDWHXUxEQ.GetHashCode()) * 29 + this.BJMqmqCEZpAukivFcfZJGFoaDqptA.GetHashCode();
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00003165 File Offset: 0x00001365
	public static bool qrdSKqzpqdUHTzbLKfgCEFuuCzQU(gEdIHqzEIozkMJmcDQznnQQEbRJV A_0, gEdIHqzEIozkMJmcDQznnQQEbRJV A_1)
	{
		return A_0.EfoQRJNUuJeUKhfmShwehIwMtBjiA == A_1.EfoQRJNUuJeUKhfmShwehIwMtBjiA && A_0.FKmJBiaaLhYbddCqqiXkDdQmFdNm == A_1.FKmJBiaaLhYbddCqqiXkDdQmFdNm && A_0.NGtrrHiclzuaMjbiauZkDWHXUxEQ == A_1.NGtrrHiclzuaMjbiauZkDWHXUxEQ && A_0.BJMqmqCEZpAukivFcfZJGFoaDqptA == A_1.BJMqmqCEZpAukivFcfZJGFoaDqptA;
	}

	// Token: 0x0600012D RID: 301 RVA: 0x000031BC File Offset: 0x000013BC
	public static bool yZPeBGkCzSYJrboafOfjIKTmOHiUA(gEdIHqzEIozkMJmcDQznnQQEbRJV A_0, gEdIHqzEIozkMJmcDQznnQQEbRJV A_1)
	{
		return !gEdIHqzEIozkMJmcDQznnQQEbRJV.qrdSKqzpqdUHTzbLKfgCEFuuCzQU(A_0, A_1);
	}

	// Token: 0x0400005C RID: 92
	public KeyboardKeyCode EfoQRJNUuJeUKhfmShwehIwMtBjiA;

	// Token: 0x0400005D RID: 93
	public ModifierKey FKmJBiaaLhYbddCqqiXkDdQmFdNm;

	// Token: 0x0400005E RID: 94
	public ModifierKey NGtrrHiclzuaMjbiauZkDWHXUxEQ;

	// Token: 0x0400005F RID: 95
	public ModifierKey BJMqmqCEZpAukivFcfZJGFoaDqptA;
}
