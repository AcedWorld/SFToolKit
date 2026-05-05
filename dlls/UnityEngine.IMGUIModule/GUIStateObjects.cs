using System;
using System.Collections.Generic;
using System.Security;

namespace UnityEngine
{
	// Token: 0x02000029 RID: 41
	internal class GUIStateObjects
	{
		// Token: 0x060002DD RID: 733 RVA: 0x0000B5A4 File Offset: 0x000097A4
		[SecuritySafeCritical]
		internal static object GetStateObject(Type t, int controlID)
		{
			object obj;
			bool flag = !GUIStateObjects.s_StateCache.TryGetValue(controlID, out obj) || obj.GetType() != t;
			if (flag)
			{
				obj = Activator.CreateInstance(t);
				GUIStateObjects.s_StateCache[controlID] = obj;
			}
			return obj;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000B5F0 File Offset: 0x000097F0
		internal static object QueryStateObject(Type t, int controlID)
		{
			object obj = GUIStateObjects.s_StateCache[controlID];
			bool flag = t.IsInstanceOfType(obj);
			object result;
			if (flag)
			{
				result = obj;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000B61F File Offset: 0x0000981F
		internal static void Tests_ClearObjects()
		{
			GUIStateObjects.s_StateCache.Clear();
		}

		// Token: 0x040000C9 RID: 201
		private static Dictionary<int, object> s_StateCache = new Dictionary<int, object>();
	}
}
