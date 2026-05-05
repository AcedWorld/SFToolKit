using System;
using System.Diagnostics;
using System.Reflection;

namespace UnityEngine.Events
{
	// Token: 0x020002F8 RID: 760
	internal class InvokableCall<T1, T2> : BaseInvokableCall
	{
		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06001F76 RID: 8054 RVA: 0x00033B50 File Offset: 0x00031D50
		// (remove) Token: 0x06001F77 RID: 8055 RVA: 0x00033B88 File Offset: 0x00031D88
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected event UnityAction<T1, T2> Delegate;

		// Token: 0x06001F78 RID: 8056 RVA: 0x00033BBD File Offset: 0x00031DBD
		public InvokableCall(object target, MethodInfo theFunction) : base(target, theFunction)
		{
			this.Delegate = (UnityAction<T1, T2>)System.Delegate.CreateDelegate(typeof(UnityAction<T1, T2>), target, theFunction);
		}

		// Token: 0x06001F79 RID: 8057 RVA: 0x00033BE5 File Offset: 0x00031DE5
		public InvokableCall(UnityAction<T1, T2> action)
		{
			this.Delegate += action;
		}

		// Token: 0x06001F7A RID: 8058 RVA: 0x00033BF8 File Offset: 0x00031DF8
		public override void Invoke(object[] args)
		{
			bool flag = args.Length != 2;
			if (flag)
			{
				throw new ArgumentException("Passed argument 'args' is invalid size. Expected size is 1");
			}
			BaseInvokableCall.ThrowOnInvalidArg<T1>(args[0]);
			BaseInvokableCall.ThrowOnInvalidArg<T2>(args[1]);
			bool flag2 = BaseInvokableCall.AllowInvoke(this.Delegate);
			if (flag2)
			{
				this.Delegate((T1)((object)args[0]), (T2)((object)args[1]));
			}
		}

		// Token: 0x06001F7B RID: 8059 RVA: 0x00033C5C File Offset: 0x00031E5C
		public void Invoke(T1 args0, T2 args1)
		{
			bool flag = BaseInvokableCall.AllowInvoke(this.Delegate);
			if (flag)
			{
				this.Delegate(args0, args1);
			}
		}

		// Token: 0x06001F7C RID: 8060 RVA: 0x00033C88 File Offset: 0x00031E88
		public override bool Find(object targetObj, MethodInfo method)
		{
			return this.Delegate.Target == targetObj && this.Delegate.Method.Equals(method);
		}
	}
}
