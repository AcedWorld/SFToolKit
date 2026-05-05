using System;
using System.Text;

// Token: 0x02000238 RID: 568
internal static class aFdRcEOoMHiVKihyrXCXRSEwpzao
{
	// Token: 0x06000E50 RID: 3664 RVA: 0x000195D8 File Offset: 0x000177D8
	public static string vlbSaQsygymodllIHOXMIdnIDdRcA(this byte[] A_0)
	{
		string @string = Encoding.UTF8.GetString(A_0);
		return @string.Remove(@string.IndexOf('\0'));
	}

	// Token: 0x06000E51 RID: 3665 RVA: 0x000195F1 File Offset: 0x000177F1
	public static string ZFDewmHAAkQUVWehbGXHavXmphjC(this byte[] A_0)
	{
		string @string = Encoding.Unicode.GetString(A_0);
		return @string.Remove(@string.IndexOf('\0'));
	}
}
