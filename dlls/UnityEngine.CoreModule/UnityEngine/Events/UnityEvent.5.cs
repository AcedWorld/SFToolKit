using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Scripting;

namespace UnityEngine.Events
{
	// Token: 0x0200030A RID: 778
	[Serializable]
	public class UnityEvent<T0, T1, T2, T3> : UnityEventBase
	{
		// Token: 0x06002001 RID: 8193 RVA: 0x00035343 File Offset: 0x00033543
		[RequiredByNativeCode]
		public UnityEvent()
		{
		}

		// Token: 0x06002002 RID: 8194 RVA: 0x00035354 File Offset: 0x00033554
		public void AddListener(UnityAction<T0, T1, T2, T3> call)
		{
			base.AddCall(UnityEvent<T0, T1, T2, T3>.GetDelegate(call));
		}

		// Token: 0x06002003 RID: 8195 RVA: 0x00034E1E File Offset: 0x0003301E
		public void RemoveListener(UnityAction<T0, T1, T2, T3> call)
		{
			base.RemoveListener(call.Target, call.Method);
		}

		// Token: 0x06002004 RID: 8196 RVA: 0x00035364 File Offset: 0x00033564
		protected override MethodInfo FindMethod_Impl(string name, Type targetObjType)
		{
			return UnityEventBase.GetValidMethodInfo(targetObjType, name, new Type[]
			{
				typeof(T0),
				typeof(T1),
				typeof(T2),
				typeof(T3)
			});
		}

		// Token: 0x06002005 RID: 8197 RVA: 0x000353B8 File Offset: 0x000335B8
		internal override BaseInvokableCall GetDelegate(object target, MethodInfo theFunction)
		{
			return new InvokableCall<T0, T1, T2, T3>(target, theFunction);
		}

		// Token: 0x06002006 RID: 8198 RVA: 0x000353D4 File Offset: 0x000335D4
		private static BaseInvokableCall GetDelegate(UnityAction<T0, T1, T2, T3> action)
		{
			return new InvokableCall<T0, T1, T2, T3>(action);
		}

		// Token: 0x06002007 RID: 8199 RVA: 0x000353EC File Offset: 0x000335EC
		public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			List<BaseInvokableCall> list = base.PrepareInvoke();
			for (int i = 0; i < list.Count; i++)
			{
				InvokableCall<T0, T1, T2, T3> invokableCall = list[i] as InvokableCall<T0, T1, T2, T3>;
				bool flag = invokableCall != null;
				if (flag)
				{
					invokableCall.Invoke(arg0, arg1, arg2, arg3);
				}
				else
				{
					InvokableCall invokableCall2 = list[i] as InvokableCall;
					bool flag2 = invokableCall2 != null;
					if (flag2)
					{
						invokableCall2.Invoke();
					}
					else
					{
						BaseInvokableCall baseInvokableCall = list[i];
						bool flag3 = this.m_InvokeArray == null;
						if (flag3)
						{
							this.m_InvokeArray = new object[4];
						}
						this.m_InvokeArray[0] = arg0;
						this.m_InvokeArray[1] = arg1;
						this.m_InvokeArray[2] = arg2;
						this.m_InvokeArray[3] = arg3;
						baseInvokableCall.Invoke(this.m_InvokeArray);
					}
				}
			}
		}

		// Token: 0x04000A7E RID: 2686
		private object[] m_InvokeArray = null;
	}
}
