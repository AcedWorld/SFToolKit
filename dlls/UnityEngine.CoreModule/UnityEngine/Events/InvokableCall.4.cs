using System;
using System.Diagnostics;
using System.Reflection;

namespace UnityEngine.Events
{
	// Token: 0x020002F9 RID: 761
	internal class InvokableCall<T1, T2, T3> : BaseInvokableCall
	{
		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06001F7D RID: 8061 RVA: 0x00033CBC File Offset: 0x00031EBC
		// (remove) Token: 0x06001F7E RID: 8062 RVA: 0x00033CF4 File Offset: 0x00031EF4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected event UnityAction<T1, T2, T3> Delegate;

		// Token: 0x06001F7F RID: 8063 RVA: 0x00033D29 File Offset: 0x00031F29
		public InvokableCall(object target, MethodInfo theFunction) : base(target, theFunction)
		{
			this.Delegate = (UnityAction<T1, T2, T3>)System.Delegate.CreateDelegate(typeof(UnityAction<T1, T2, T3>), target, theFunction);
		}

		// Token: 0x06001F80 RID: 8064 RVA: 0x00033D51 File Offset: 0x00031F51
		public InvokableCall(UnityAction<T1, T2, T3> action)
		{
			this.Delegate += action;
		}

		// Token: 0x06001F81 RID: 8065 RVA: 0x00033D64 File Offset: 0x00031F64
		public override void Invoke(object[] args)
		{
			bool flag = args.Length != 3;
			if (flag)
			{
				throw new ArgumentException("Passed argument 'args' is invalid size. Expected size is 1");
			}
			BaseInvokableCall.ThrowOnInvalidArg<T1>(args[0]);
			BaseInvokableCall.ThrowOnInvalidArg<T2>(args[1]);
			BaseInvokableCall.ThrowOnInvalidArg<T3>(args[2]);
			bool flag2 = BaseInvokableCall.AllowInvoke(this.Delegate);
			if (flag2)
			{
				this.Delegate((T1)((object)args[0]), (T2)((object)args[1]), (T3)((object)args[2]));
			}
		}

		// Token: 0x06001F82 RID: 8066 RVA: 0x00033DD8 File Offset: 0x00031FD8
		public void Invoke(T1 args0, T2 args1, T3 args2)
		{
			bool flag = BaseInvokableCall.AllowInvoke(this.Delegate);
			if (flag)
			{
				this.Delegate(args0, args1, args2);
			}
		}

		// Token: 0x06001F83 RID: 8067 RVA: 0x00033E04 File Offset: 0x00032004
		public override bool Find(object targetObj, MethodInfo method)
		{
			return this.Delegate.Target == targetObj && this.Delegate.Method.Equals(method);
		}
	}
}
