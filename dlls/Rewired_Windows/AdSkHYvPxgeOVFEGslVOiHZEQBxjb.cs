using System;

// Token: 0x02000051 RID: 81
internal static class AdSkHYvPxgeOVFEGslVOiHZEQBxjb
{
	// Token: 0x060002E6 RID: 742 RVA: 0x00029F04 File Offset: 0x00028104
	public static string zntnSUJJitVdtJJQJKoubsHXrwF(string A_0)
	{
		if (A_0 == null || A_0 == string.Empty)
		{
			return string.Empty;
		}
		int num = A_0.LastIndexOf('\\');
		if (num < 0 || num >= A_0.Length - 1)
		{
			return A_0;
		}
		return A_0.Substring(num + 1);
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x00012BA6 File Offset: 0x00010DA6
	public static TmQtHAjIIZspIrcxTKZYytluTRan wXbgBmLNQTEMXPeqzWQmgtMqAvwV(int A_0)
	{
		if (A_0 == 0)
		{
			return TmQtHAjIIZspIrcxTKZYytluTRan.LostFocus;
		}
		if (A_0 - 1 > 1)
		{
			return TmQtHAjIIZspIrcxTKZYytluTRan.None;
		}
		return TmQtHAjIIZspIrcxTKZYytluTRan.GainedFocus;
	}
}
