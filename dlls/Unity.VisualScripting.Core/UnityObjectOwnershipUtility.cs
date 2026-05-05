using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200014E RID: 334
	public static class UnityObjectOwnershipUtility
	{
		// Token: 0x060008FA RID: 2298 RVA: 0x00026FAC File Offset: 0x000251AC
		public static void CopyOwner(object source, object destination)
		{
			IUnityObjectOwnable unityObjectOwnable = destination as IUnityObjectOwnable;
			if (unityObjectOwnable != null)
			{
				unityObjectOwnable.owner = UnityObjectOwnershipUtility.GetOwner(source);
			}
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00026FD0 File Offset: 0x000251D0
		public static void RemoveOwner(object o)
		{
			IUnityObjectOwnable unityObjectOwnable = o as IUnityObjectOwnable;
			if (unityObjectOwnable != null)
			{
				unityObjectOwnable.owner = null;
			}
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00026FEE File Offset: 0x000251EE
		public static Object GetOwner(object o)
		{
			Component component = o as Component;
			GameObject result;
			if ((result = ((component != null) ? component.gameObject : null)) == null)
			{
				IUnityObjectOwnable unityObjectOwnable = o as IUnityObjectOwnable;
				if (unityObjectOwnable == null)
				{
					return null;
				}
				result = unityObjectOwnable.owner;
			}
			return result;
		}
	}
}
