using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Cinemachine.Utility
{
	// Token: 0x0200005F RID: 95
	public class CinemachineDebug
	{
		// Token: 0x060003B7 RID: 951 RVA: 0x00016FAD File Offset: 0x000151AD
		public static void ReleaseScreenPos(Object client)
		{
			if (CinemachineDebug.mClients != null && CinemachineDebug.mClients.Contains(client))
			{
				CinemachineDebug.mClients.Remove(client);
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00016FD0 File Offset: 0x000151D0
		public static Rect GetScreenPos(Object client, string text, GUIStyle style)
		{
			if (CinemachineDebug.mClients == null)
			{
				CinemachineDebug.mClients = new HashSet<Object>();
			}
			if (!CinemachineDebug.mClients.Contains(client))
			{
				CinemachineDebug.mClients.Add(client);
			}
			Vector2 zero = Vector2.zero;
			Vector2 vector = style.CalcSize(new GUIContent(text));
			if (CinemachineDebug.mClients != null)
			{
				using (HashSet<Object>.Enumerator enumerator = CinemachineDebug.mClients.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == client)
						{
							break;
						}
						zero.y += vector.y;
					}
				}
			}
			return new Rect(zero, vector);
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00017080 File Offset: 0x00015280
		public static StringBuilder SBFromPool()
		{
			if (CinemachineDebug.mAvailableStringBuilders == null || CinemachineDebug.mAvailableStringBuilders.Count == 0)
			{
				return new StringBuilder();
			}
			StringBuilder stringBuilder = CinemachineDebug.mAvailableStringBuilders[CinemachineDebug.mAvailableStringBuilders.Count - 1];
			CinemachineDebug.mAvailableStringBuilders.RemoveAt(CinemachineDebug.mAvailableStringBuilders.Count - 1);
			stringBuilder.Length = 0;
			return stringBuilder;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000170D9 File Offset: 0x000152D9
		public static void ReturnToPool(StringBuilder sb)
		{
			if (CinemachineDebug.mAvailableStringBuilders == null)
			{
				CinemachineDebug.mAvailableStringBuilders = new List<StringBuilder>();
			}
			CinemachineDebug.mAvailableStringBuilders.Add(sb);
		}

		// Token: 0x0400028C RID: 652
		private static HashSet<Object> mClients;

		// Token: 0x0400028D RID: 653
		public static CinemachineDebug.OnGUIDelegate OnGUIHandlers;

		// Token: 0x0400028E RID: 654
		private static List<StringBuilder> mAvailableStringBuilders;

		// Token: 0x020000E7 RID: 231
		// (Invoke) Token: 0x0600056F RID: 1391
		public delegate void OnGUIDelegate();
	}
}
