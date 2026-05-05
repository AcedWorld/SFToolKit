using System;
using System.Reflection;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200002E RID: 46
	[AttributeUsage(AttributeTargets.Method)]
	public class GUITargetAttribute : Attribute
	{
		// Token: 0x06000373 RID: 883 RVA: 0x0000C1B7 File Offset: 0x0000A3B7
		public GUITargetAttribute()
		{
			this.displayMask = -1;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000C1C8 File Offset: 0x0000A3C8
		public GUITargetAttribute(int displayIndex)
		{
			this.displayMask = 1 << displayIndex;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000C1DE File Offset: 0x0000A3DE
		public GUITargetAttribute(int displayIndex, int displayIndex1)
		{
			this.displayMask = (1 << displayIndex | 1 << displayIndex1);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000C1FC File Offset: 0x0000A3FC
		public GUITargetAttribute(int displayIndex, int displayIndex1, params int[] displayIndexList)
		{
			this.displayMask = (1 << displayIndex | 1 << displayIndex1);
			for (int i = 0; i < displayIndexList.Length; i++)
			{
				this.displayMask |= 1 << displayIndexList[i];
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000C24C File Offset: 0x0000A44C
		[RequiredByNativeCode]
		private static int GetGUITargetAttrValue(Type klass, string methodName)
		{
			MethodInfo method = klass.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			bool flag = method != null;
			if (flag)
			{
				object[] customAttributes = method.GetCustomAttributes(true);
				bool flag2 = customAttributes != null;
				if (flag2)
				{
					for (int i = 0; i < customAttributes.Length; i++)
					{
						bool flag3 = customAttributes[i].GetType() != typeof(GUITargetAttribute);
						if (!flag3)
						{
							GUITargetAttribute guitargetAttribute = customAttributes[i] as GUITargetAttribute;
							return guitargetAttribute.displayMask;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x040000E4 RID: 228
		internal int displayMask;
	}
}
