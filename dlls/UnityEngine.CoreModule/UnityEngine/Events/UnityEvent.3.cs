using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Scripting;

namespace UnityEngine.Events
{
	// Token: 0x02000306 RID: 774
	[Serializable]
	public class UnityEvent<T0, T1> : UnityEventBase
	{
		// Token: 0x06001FEB RID: 8171 RVA: 0x0003506E File Offset: 0x0003326E
		[RequiredByNativeCode]
		public UnityEvent()
		{
		}

		// Token: 0x06001FEC RID: 8172 RVA: 0x0003507F File Offset: 0x0003327F
		public void AddListener(UnityAction<T0, T1> call)
		{
			base.AddCall(UnityEvent<T0, T1>.GetDelegate(call));
		}

		// Token: 0x06001FED RID: 8173 RVA: 0x00034E1E File Offset: 0x0003301E
		public void RemoveListener(UnityAction<T0, T1> call)
		{
			base.RemoveListener(call.Target, call.Method);
		}

		// Token: 0x06001FEE RID: 8174 RVA: 0x00035090 File Offset: 0x00033290
		protected override MethodInfo FindMethod_Impl(string name, Type targetObjType)
		{
			return UnityEventBase.GetValidMethodInfo(targetObjType, name, new Type[]
			{
				typeof(T0),
				typeof(T1)
			});
		}

		// Token: 0x06001FEF RID: 8175 RVA: 0x000350CC File Offset: 0x000332CC
		internal override BaseInvokableCall GetDelegate(object target, MethodInfo theFunction)
		{
			return new InvokableCall<T0, T1>(target, theFunction);
		}

		// Token: 0x06001FF0 RID: 8176 RVA: 0x000350E8 File Offset: 0x000332E8
		private static BaseInvokableCall GetDelegate(UnityAction<T0, T1> action)
		{
			return new InvokableCall<T0, T1>(action);
		}

		// Token: 0x06001FF1 RID: 8177 RVA: 0x00035100 File Offset: 0x00033300
		public void Invoke(T0 arg0, T1 arg1)
		{
			List<BaseInvokableCall> list = base.PrepareInvoke();
			for (int i = 0; i < list.Count; i++)
			{
				InvokableCall<T0, T1> invokableCall = list[i] as InvokableCall<T0, T1>;
				bool flag = invokableCall != null;
				if (flag)
				{
					invokableCall.Invoke(arg0, arg1);
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
							this.m_InvokeArray = new object[2];
						}
						this.m_InvokeArray[0] = arg0;
						this.m_InvokeArray[1] = arg1;
						baseInvokableCall.Invoke(this.m_InvokeArray);
					}
				}
			}
		}

		// Token: 0x04000A7C RID: 2684
		private object[] m_InvokeArray = null;
	}
}
