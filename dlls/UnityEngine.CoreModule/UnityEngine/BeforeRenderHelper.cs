using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityEngine
{
	// Token: 0x02000139 RID: 313
	internal static class BeforeRenderHelper
	{
		// Token: 0x060008A7 RID: 2215 RVA: 0x0000DEBC File Offset: 0x0000C0BC
		private static int GetUpdateOrder(UnityAction callback)
		{
			object[] customAttributes = callback.Method.GetCustomAttributes(typeof(BeforeRenderOrderAttribute), true);
			BeforeRenderOrderAttribute beforeRenderOrderAttribute = (customAttributes != null && customAttributes.Length != 0) ? (customAttributes[0] as BeforeRenderOrderAttribute) : null;
			return (beforeRenderOrderAttribute != null) ? beforeRenderOrderAttribute.order : 0;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0000DF04 File Offset: 0x0000C104
		public static void RegisterCallback(UnityAction callback)
		{
			int updateOrder = BeforeRenderHelper.GetUpdateOrder(callback);
			List<BeforeRenderHelper.OrderBlock> obj = BeforeRenderHelper.s_OrderBlocks;
			lock (obj)
			{
				int num = 0;
				while (num < BeforeRenderHelper.s_OrderBlocks.Count && BeforeRenderHelper.s_OrderBlocks[num].order <= updateOrder)
				{
					bool flag2 = BeforeRenderHelper.s_OrderBlocks[num].order == updateOrder;
					if (flag2)
					{
						BeforeRenderHelper.OrderBlock value = BeforeRenderHelper.s_OrderBlocks[num];
						value.callback = (UnityAction)Delegate.Combine(value.callback, callback);
						BeforeRenderHelper.s_OrderBlocks[num] = value;
						return;
					}
					num++;
				}
				BeforeRenderHelper.OrderBlock item = default(BeforeRenderHelper.OrderBlock);
				item.order = updateOrder;
				item.callback = (UnityAction)Delegate.Combine(item.callback, callback);
				BeforeRenderHelper.s_OrderBlocks.Insert(num, item);
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0000E000 File Offset: 0x0000C200
		public static void UnregisterCallback(UnityAction callback)
		{
			int updateOrder = BeforeRenderHelper.GetUpdateOrder(callback);
			List<BeforeRenderHelper.OrderBlock> obj = BeforeRenderHelper.s_OrderBlocks;
			lock (obj)
			{
				int num = 0;
				while (num < BeforeRenderHelper.s_OrderBlocks.Count && BeforeRenderHelper.s_OrderBlocks[num].order <= updateOrder)
				{
					bool flag2 = BeforeRenderHelper.s_OrderBlocks[num].order == updateOrder;
					if (flag2)
					{
						BeforeRenderHelper.OrderBlock orderBlock = BeforeRenderHelper.s_OrderBlocks[num];
						orderBlock.callback = (UnityAction)Delegate.Remove(orderBlock.callback, callback);
						BeforeRenderHelper.s_OrderBlocks[num] = orderBlock;
						bool flag3 = orderBlock.callback == null;
						if (flag3)
						{
							BeforeRenderHelper.s_OrderBlocks.RemoveAt(num);
						}
						break;
					}
					num++;
				}
			}
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0000E0E8 File Offset: 0x0000C2E8
		public static void Invoke()
		{
			List<BeforeRenderHelper.OrderBlock> obj = BeforeRenderHelper.s_OrderBlocks;
			lock (obj)
			{
				for (int i = 0; i < BeforeRenderHelper.s_OrderBlocks.Count; i++)
				{
					UnityAction callback = BeforeRenderHelper.s_OrderBlocks[i].callback;
					bool flag2 = callback != null;
					if (flag2)
					{
						callback();
					}
				}
			}
		}

		// Token: 0x040003FB RID: 1019
		private static List<BeforeRenderHelper.OrderBlock> s_OrderBlocks = new List<BeforeRenderHelper.OrderBlock>();

		// Token: 0x0200013A RID: 314
		private struct OrderBlock
		{
			// Token: 0x040003FC RID: 1020
			internal int order;

			// Token: 0x040003FD RID: 1021
			internal UnityAction callback;
		}
	}
}
