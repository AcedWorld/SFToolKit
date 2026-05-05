using System;
using System.Reflection;

namespace UnityEngine.Events
{
	// Token: 0x020002FB RID: 763
	internal class CachedInvokableCall<T> : InvokableCall<T>
	{
		// Token: 0x06001F8B RID: 8075 RVA: 0x00033FCC File Offset: 0x000321CC
		public CachedInvokableCall(Object target, MethodInfo theFunction, T argument) : base(target, theFunction)
		{
			this.m_Arg1 = argument;
		}

		// Token: 0x06001F8C RID: 8076 RVA: 0x00033FDF File Offset: 0x000321DF
		public override void Invoke(object[] args)
		{
			base.Invoke(this.m_Arg1);
		}

		// Token: 0x06001F8D RID: 8077 RVA: 0x00033FDF File Offset: 0x000321DF
		public override void Invoke(T arg0)
		{
			base.Invoke(this.m_Arg1);
		}

		// Token: 0x04000A67 RID: 2663
		private readonly T m_Arg1;
	}
}
