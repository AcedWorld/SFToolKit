using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Scripting;

namespace UnityEngine.Events
{
	// Token: 0x02000302 RID: 770
	[Serializable]
	public class UnityEvent : UnityEventBase
	{
		// Token: 0x06001FD5 RID: 8149 RVA: 0x00034DFD File Offset: 0x00032FFD
		[RequiredByNativeCode]
		public UnityEvent()
		{
		}

		// Token: 0x06001FD6 RID: 8150 RVA: 0x00034E0E File Offset: 0x0003300E
		public void AddListener(UnityAction call)
		{
			base.AddCall(UnityEvent.GetDelegate(call));
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x00034E1E File Offset: 0x0003301E
		public void RemoveListener(UnityAction call)
		{
			base.RemoveListener(call.Target, call.Method);
		}

		// Token: 0x06001FD8 RID: 8152 RVA: 0x00034E34 File Offset: 0x00033034
		protected override MethodInfo FindMethod_Impl(string name, Type targetObjType)
		{
			return UnityEventBase.GetValidMethodInfo(targetObjType, name, new Type[0]);
		}

		// Token: 0x06001FD9 RID: 8153 RVA: 0x00034E54 File Offset: 0x00033054
		internal override BaseInvokableCall GetDelegate(object target, MethodInfo theFunction)
		{
			return new InvokableCall(target, theFunction);
		}

		// Token: 0x06001FDA RID: 8154 RVA: 0x00034E70 File Offset: 0x00033070
		private static BaseInvokableCall GetDelegate(UnityAction action)
		{
			return new InvokableCall(action);
		}

		// Token: 0x06001FDB RID: 8155 RVA: 0x00034E88 File Offset: 0x00033088
		public void Invoke()
		{
			List<BaseInvokableCall> list = base.PrepareInvoke();
			for (int i = 0; i < list.Count; i++)
			{
				InvokableCall invokableCall = list[i] as InvokableCall;
				bool flag = invokableCall != null;
				if (flag)
				{
					invokableCall.Invoke();
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
							this.m_InvokeArray = new object[0];
						}
						baseInvokableCall.Invoke(this.m_InvokeArray);
					}
				}
			}
		}

		// Token: 0x04000A7A RID: 2682
		private object[] m_InvokeArray = null;
	}
}
