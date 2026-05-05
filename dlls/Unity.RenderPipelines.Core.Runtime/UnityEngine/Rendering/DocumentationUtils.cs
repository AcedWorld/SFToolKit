using System;
using System.Linq;
using System.Reflection;

namespace UnityEngine.Rendering
{
	// Token: 0x02000081 RID: 129
	public static class DocumentationUtils
	{
		// Token: 0x0600040B RID: 1035 RVA: 0x000113E4 File Offset: 0x0000F5E4
		public static string GetHelpURL<TEnum>(TEnum mask = default(TEnum)) where TEnum : struct, IConvertible
		{
			HelpURLAttribute helpURLAttribute = (HelpURLAttribute)mask.GetType().GetCustomAttributes(typeof(HelpURLAttribute), false).FirstOrDefault<object>();
			if (helpURLAttribute != null)
			{
				return string.Format("{0}#{1}", helpURLAttribute.URL, mask);
			}
			return string.Empty;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00011438 File Offset: 0x0000F638
		public static bool TryGetHelpURL(Type type, out string url)
		{
			HelpURLAttribute customAttribute = type.GetCustomAttribute(false);
			url = ((customAttribute != null) ? customAttribute.URL : null);
			return customAttribute != null;
		}
	}
}
