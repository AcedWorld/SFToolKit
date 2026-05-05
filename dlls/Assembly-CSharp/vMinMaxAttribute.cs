using System;
using UnityEngine;

// Token: 0x02000029 RID: 41
public class vMinMaxAttribute : PropertyAttribute
{
	// Token: 0x06000097 RID: 151 RVA: 0x00007D05 File Offset: 0x00005F05
	public vMinMaxAttribute()
	{
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00007D18 File Offset: 0x00005F18
	public vMinMaxAttribute(float min, float max)
	{
		this.minLimit = min;
		this.maxLimit = max;
	}

	// Token: 0x040000E1 RID: 225
	public float minLimit;

	// Token: 0x040000E2 RID: 226
	public float maxLimit = 1f;
}
