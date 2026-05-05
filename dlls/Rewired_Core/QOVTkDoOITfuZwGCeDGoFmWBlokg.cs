using System;
using System.Reflection;
using Rewired;

// Token: 0x02000011 RID: 17
[DefaultMember("Item")]
internal struct QOVTkDoOITfuZwGCeDGoFmWBlokg : IEquatable<QOVTkDoOITfuZwGCeDGoFmWBlokg>
{
	// Token: 0x1700005F RID: 95
	// (get) Token: 0x0600012E RID: 302 RVA: 0x000031C8 File Offset: 0x000013C8
	// (set) Token: 0x0600012F RID: 303 RVA: 0x000031F1 File Offset: 0x000013F1
	private ModifierKey OglpHDOEneUvmtPGYFaGxtpdbqdB
	{
		get
		{
			if (A_1 <= 0)
			{
				return this.VnWsvhRFHEHSdIxIrWgIdjRFuIrM;
			}
			if (A_1 == 1)
			{
				return this.kstazWnyJWSGCyysBrbkrVnXOThf;
			}
			if (A_1 >= 2)
			{
				return this.VNapKiuXDsKIQHBroBAQraNbUEMC;
			}
			return this.VnWsvhRFHEHSdIxIrWgIdjRFuIrM;
		}
		set
		{
			if (A_1 <= 0)
			{
				this.VnWsvhRFHEHSdIxIrWgIdjRFuIrM = value;
			}
			if (A_1 == 1)
			{
				this.kstazWnyJWSGCyysBrbkrVnXOThf = value;
			}
			if (A_1 >= 2)
			{
				this.VNapKiuXDsKIQHBroBAQraNbUEMC = value;
			}
		}
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00003214 File Offset: 0x00001414
	public QOVTkDoOITfuZwGCeDGoFmWBlokg(ModifierKey A_1, ModifierKey A_2, ModifierKey A_3)
	{
		this.VnWsvhRFHEHSdIxIrWgIdjRFuIrM = A_1;
		this.kstazWnyJWSGCyysBrbkrVnXOThf = A_2;
		this.VNapKiuXDsKIQHBroBAQraNbUEMC = A_3;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0000322B File Offset: 0x0000142B
	public void cntuSqvXtxoQKLoNddvycVXnCtXyA()
	{
		if (this.VnWsvhRFHEHSdIxIrWgIdjRFuIrM != ModifierKey.None)
		{
			this.VnWsvhRFHEHSdIxIrWgIdjRFuIrM = ModifierKey.None;
		}
		if (this.kstazWnyJWSGCyysBrbkrVnXOThf != ModifierKey.None)
		{
			this.kstazWnyJWSGCyysBrbkrVnXOThf = ModifierKey.None;
		}
		if (this.VNapKiuXDsKIQHBroBAQraNbUEMC != ModifierKey.None)
		{
			this.VNapKiuXDsKIQHBroBAQraNbUEMC = ModifierKey.None;
		}
	}

	// Token: 0x06000132 RID: 306 RVA: 0x0002C144 File Offset: 0x0002A344
	public static QOVTkDoOITfuZwGCeDGoFmWBlokg VyOkQKoXtMkwBhKlyQuVnnWLDOFU(ModifierKeyFlags A_0)
	{
		QOVTkDoOITfuZwGCeDGoFmWBlokg result = default(QOVTkDoOITfuZwGCeDGoFmWBlokg);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(A_0, ModifierKey.Control))
		{
			result.GOlFampIkXCxQGkSxHtHsvVjUzWz(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(A_0, ModifierKey.Command))
		{
			result.GOlFampIkXCxQGkSxHtHsvVjUzWz(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(A_0, ModifierKey.Alt))
		{
			result.GOlFampIkXCxQGkSxHtHsvVjUzWz(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(A_0, ModifierKey.Shift))
		{
			result.GOlFampIkXCxQGkSxHtHsvVjUzWz(num++, ModifierKey.Shift);
		}
		return result;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x0000325A File Offset: 0x0000145A
	public bool Equals(QOVTkDoOITfuZwGCeDGoFmWBlokg other)
	{
		return this.VnWsvhRFHEHSdIxIrWgIdjRFuIrM == other.VnWsvhRFHEHSdIxIrWgIdjRFuIrM && this.kstazWnyJWSGCyysBrbkrVnXOThf == other.kstazWnyJWSGCyysBrbkrVnXOThf && this.VNapKiuXDsKIQHBroBAQraNbUEMC == other.VNapKiuXDsKIQHBroBAQraNbUEMC;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x00003288 File Offset: 0x00001488
	public bool IVEdLROKbYCEzvepSfQECcmEtybR(object A_1)
	{
		return A_1 != null && A_1 is QOVTkDoOITfuZwGCeDGoFmWBlokg && this.Equals((QOVTkDoOITfuZwGCeDGoFmWBlokg)A_1);
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0002C1BC File Offset: 0x0002A3BC
	public int uAfvgawmLadLBCWxiRJrZoqTeioE()
	{
		return ((17 * 29 + this.VnWsvhRFHEHSdIxIrWgIdjRFuIrM.GetHashCode()) * 29 + this.kstazWnyJWSGCyysBrbkrVnXOThf.GetHashCode()) * 29 + this.VNapKiuXDsKIQHBroBAQraNbUEMC.GetHashCode();
	}

	// Token: 0x06000136 RID: 310 RVA: 0x0000325A File Offset: 0x0000145A
	public static bool QAhwXjkntvKxNwKPbnKVXgzLdOww(QOVTkDoOITfuZwGCeDGoFmWBlokg A_0, QOVTkDoOITfuZwGCeDGoFmWBlokg A_1)
	{
		return A_0.VnWsvhRFHEHSdIxIrWgIdjRFuIrM == A_1.VnWsvhRFHEHSdIxIrWgIdjRFuIrM && A_0.kstazWnyJWSGCyysBrbkrVnXOThf == A_1.kstazWnyJWSGCyysBrbkrVnXOThf && A_0.VNapKiuXDsKIQHBroBAQraNbUEMC == A_1.VNapKiuXDsKIQHBroBAQraNbUEMC;
	}

	// Token: 0x06000137 RID: 311 RVA: 0x000032A3 File Offset: 0x000014A3
	public static bool pdPefYyMCDwNgZmmaPldJxhFvndS(QOVTkDoOITfuZwGCeDGoFmWBlokg A_0, QOVTkDoOITfuZwGCeDGoFmWBlokg A_1)
	{
		return !QOVTkDoOITfuZwGCeDGoFmWBlokg.QAhwXjkntvKxNwKPbnKVXgzLdOww(A_0, A_1);
	}

	// Token: 0x04000060 RID: 96
	public ModifierKey VnWsvhRFHEHSdIxIrWgIdjRFuIrM;

	// Token: 0x04000061 RID: 97
	public ModifierKey kstazWnyJWSGCyysBrbkrVnXOThf;

	// Token: 0x04000062 RID: 98
	public ModifierKey VNapKiuXDsKIQHBroBAQraNbUEMC;
}
