using System;

// Token: 0x0200002F RID: 47
public static class vBodyStructHelper
{
	// Token: 0x060000A7 RID: 167 RVA: 0x00007F9C File Offset: 0x0000619C
	public static bool ToEnum<T>(this string value, ref T enumTarget)
	{
		object obj = Enum.Parse(typeof(T), value);
		if (obj != null)
		{
			enumTarget = (T)((object)obj);
		}
		return obj != null;
	}
}
