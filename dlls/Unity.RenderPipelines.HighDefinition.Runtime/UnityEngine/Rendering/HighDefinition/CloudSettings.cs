using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001DC RID: 476
	public abstract class CloudSettings : VolumeComponent
	{
		// Token: 0x06000E6D RID: 3693 RVA: 0x000729C3 File Offset: 0x00070BC3
		public virtual int GetHashCode(Camera camera)
		{
			return this.GetHashCode();
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x000729CB File Offset: 0x00070BCB
		public static int GetUniqueID<T>()
		{
			return CloudSettings.GetUniqueID(typeof(T));
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x000729DC File Offset: 0x00070BDC
		public static int GetUniqueID(Type type)
		{
			int num;
			if (!CloudSettings.cloudUniqueIDs.TryGetValue(type, out num))
			{
				object[] customAttributes = type.GetCustomAttributes(typeof(CloudUniqueID), false);
				num = ((customAttributes.Length == 0) ? -1 : ((CloudUniqueID)customAttributes[0]).uniqueID);
				CloudSettings.cloudUniqueIDs[type] = num;
			}
			return num;
		}

		// Token: 0x06000E70 RID: 3696
		public abstract Type GetCloudRendererType();

		// Token: 0x040016BF RID: 5823
		private static Dictionary<Type, int> cloudUniqueIDs = new Dictionary<Type, int>();
	}
}
