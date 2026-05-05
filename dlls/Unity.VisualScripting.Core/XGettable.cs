using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200015A RID: 346
	public static class XGettable
	{
		// Token: 0x0600092B RID: 2347 RVA: 0x00027DC3 File Offset: 0x00025FC3
		public static object GetValue(this IGettable gettable, Type type)
		{
			return ConversionUtility.Convert(gettable.GetValue(), type);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x00027DD1 File Offset: 0x00025FD1
		public static T GetValue<T>(this IGettable gettable)
		{
			return (T)((object)gettable.GetValue(typeof(T)));
		}
	}
}
