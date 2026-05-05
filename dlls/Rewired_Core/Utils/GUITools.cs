using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x02000491 RID: 1169
	public static class GUITools
	{
		// Token: 0x06002E52 RID: 11858 RVA: 0x000A2454 File Offset: 0x000A0654
		public static GUIContent[] ToGUIContentArray(string[] items)
		{
			if (items == null)
			{
				return null;
			}
			GUIContent[] array = new GUIContent[items.Length];
			for (int i = 0; i < items.Length; i++)
			{
				array[i] = new GUIContent(items[i]);
			}
			return array;
		}

		// Token: 0x06002E53 RID: 11859 RVA: 0x000A248C File Offset: 0x000A068C
		public static GUIContent[] ToGUIContentArray(IList<string> items)
		{
			if (items == null)
			{
				return null;
			}
			GUIContent[] array = new GUIContent[items.Count];
			for (int i = 0; i < items.Count; i++)
			{
				array[i] = new GUIContent(items[i]);
			}
			return array;
		}
	}
}
