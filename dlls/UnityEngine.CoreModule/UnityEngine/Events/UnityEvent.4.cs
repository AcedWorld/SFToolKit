using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Scripting;

namespace UnityEngine.Events
{
	// Token: 0x02000308 RID: 776
	[Serializable]
	public class UnityEvent<T0, T1, T2> : UnityEventBase
	{
		// Token: 0x06001FF6 RID: 8182 RVA: 0x000351C9 File Offset: 0x000333C9
		[RequiredByNativeCode]
		public UnityEvent()
		{
		}

		// Token: 0x06001FF7 RID: 8183 RVA: 0x000351DA File Offset: 0x000333DA
		public void AddListener(UnityAction<T0, T1, T2> call)
		{
			base.AddCall(UnityEvent<T0, T1, T2>.GetDelegate(call));
		}

		// Token: 0x06001FF8 RID: 8184 RVA: 0x00034E1E File Offset: 0x0003301E
		public void RemoveListener(UnityAction<T0, T1, T2> call)
		{
			base.RemoveListener(call.Target, call.Method);
		}

		// Token: 0x06001FF9 RID: 8185 RVA: 0x000351EC File Offset: 0x000333EC
		protected override MethodInfo FindMethod_Impl(string name, Type targetObjType)
		{
			return UnityEventBase.GetValidMethodInfo(targetObjType, name, new Type[]
			{
				typeof(T0),
				typeof(T1),
				typeof(T2)
			});
		}

		// Token: 0x06001FFA RID: 8186 RVA: 0x00035234 File Offset: 0x00033434
		internal override BaseInvokableCall GetDelegate(object target, MethodInfo theFunction)
		{
			return new InvokableCall<T0, T1, T2>(target, theFunction);
		}

		// Token: 0x06001FFB RID: 8187 RVA: 0x00035250 File Offset: 0x00033450
		private static BaseInvokableCall GetDelegate(UnityAction<T0, T1, T2> action)
		{
			return new InvokableCall<T0, T1, T2>(action);
		}

		// Token: 0x06001FFC RID: 8188 RVA: 0x00035268 File Offset: 0x00033468
		public void Invoke(T0 arg0, T1 arg1, T2 arg2)
		{
			List<BaseInvokableCall> list = base.PrepareInvoke();
			for (int i = 0; i < list.Count; i++)
			{
				InvokableCall<T0, T1, T2> invokableCall = list[i] as InvokableCall<T0, T1, T2>;
				bool flag = invokableCall != null;
				if (flag)
				{
					invokableCall.Invoke(arg0, arg1, arg2);
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
							this.m_InvokeArray = new object[3];
						}
						this.m_InvokeArray[0] = arg0;
						this.m_InvokeArray[1] = arg1;
						this.m_InvokeArray[2] = arg2;
						baseInvokableCall.Invoke(this.m_InvokeArray);
					}
				}
			}
		}

		// Token: 0x04000A7D RID: 2685
		private object[] m_InvokeArray = null;
	}
}
