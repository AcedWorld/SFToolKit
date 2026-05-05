using System;
using System.Diagnostics;
using System.Reflection;

namespace UnityEngine.Events
{
	// Token: 0x020002F6 RID: 758
	internal class InvokableCall : BaseInvokableCall
	{
		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06001F68 RID: 8040 RVA: 0x000338C0 File Offset: 0x00031AC0
		// (remove) Token: 0x06001F69 RID: 8041 RVA: 0x000338F8 File Offset: 0x00031AF8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event UnityAction Delegate;

		// Token: 0x06001F6A RID: 8042 RVA: 0x0003392D File Offset: 0x00031B2D
		public InvokableCall(object target, MethodInfo theFunction) : base(target, theFunction)
		{
			this.Delegate += (UnityAction)System.Delegate.CreateDelegate(typeof(UnityAction), target, theFunction);
		}

		// Token: 0x06001F6B RID: 8043 RVA: 0x00033956 File Offset: 0x00031B56
		public InvokableCall(UnityAction action)
		{
			this.Delegate += action;
		}

		// Token: 0x06001F6C RID: 8044 RVA: 0x00033968 File Offset: 0x00031B68
		public override void Invoke(object[] args)
		{
			bool flag = BaseInvokableCall.AllowInvoke(this.Delegate);
			if (flag)
			{
				this.Delegate();
			}
		}

		// Token: 0x06001F6D RID: 8045 RVA: 0x00033994 File Offset: 0x00031B94
		public void Invoke()
		{
			bool flag = BaseInvokableCall.AllowInvoke(this.Delegate);
			if (flag)
			{
				this.Delegate();
			}
		}

		// Token: 0x06001F6E RID: 8046 RVA: 0x000339C0 File Offset: 0x00031BC0
		public override bool Find(object targetObj, MethodInfo method)
		{
			return this.Delegate.Target == targetObj && this.Delegate.Method.Equals(method);
		}
	}
}
