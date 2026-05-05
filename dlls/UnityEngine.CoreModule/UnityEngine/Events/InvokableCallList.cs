using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnityEngine.Events
{
	// Token: 0x020002FF RID: 767
	internal class InvokableCallList
	{
		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x06001FB0 RID: 8112 RVA: 0x000346E0 File Offset: 0x000328E0
		public int Count
		{
			get
			{
				return this.m_PersistentCalls.Count + this.m_RuntimeCalls.Count;
			}
		}

		// Token: 0x06001FB1 RID: 8113 RVA: 0x00034709 File Offset: 0x00032909
		public void AddPersistentInvokableCall(BaseInvokableCall call)
		{
			this.m_PersistentCalls.Add(call);
			this.m_NeedsUpdate = true;
		}

		// Token: 0x06001FB2 RID: 8114 RVA: 0x00034720 File Offset: 0x00032920
		public void AddListener(BaseInvokableCall call)
		{
			this.m_RuntimeCalls.Add(call);
			this.m_NeedsUpdate = true;
		}

		// Token: 0x06001FB3 RID: 8115 RVA: 0x00034738 File Offset: 0x00032938
		public void RemoveListener(object targetObj, MethodInfo method)
		{
			List<BaseInvokableCall> list = new List<BaseInvokableCall>();
			for (int i = 0; i < this.m_RuntimeCalls.Count; i++)
			{
				bool flag = this.m_RuntimeCalls[i].Find(targetObj, method);
				if (flag)
				{
					list.Add(this.m_RuntimeCalls[i]);
				}
			}
			this.m_RuntimeCalls.RemoveAll(new Predicate<BaseInvokableCall>(list.Contains));
			List<BaseInvokableCall> list2 = new List<BaseInvokableCall>(this.m_PersistentCalls.Count + this.m_RuntimeCalls.Count);
			list2.AddRange(this.m_PersistentCalls);
			list2.AddRange(this.m_RuntimeCalls);
			this.m_ExecutingCalls = list2;
			this.m_NeedsUpdate = false;
		}

		// Token: 0x06001FB4 RID: 8116 RVA: 0x000347F4 File Offset: 0x000329F4
		public void Clear()
		{
			this.m_RuntimeCalls.Clear();
			List<BaseInvokableCall> executingCalls = new List<BaseInvokableCall>(this.m_PersistentCalls);
			this.m_ExecutingCalls = executingCalls;
			this.m_NeedsUpdate = false;
		}

		// Token: 0x06001FB5 RID: 8117 RVA: 0x00034828 File Offset: 0x00032A28
		public void ClearPersistent()
		{
			this.m_PersistentCalls.Clear();
			List<BaseInvokableCall> executingCalls = new List<BaseInvokableCall>(this.m_RuntimeCalls);
			this.m_ExecutingCalls = executingCalls;
			this.m_NeedsUpdate = false;
		}

		// Token: 0x06001FB6 RID: 8118 RVA: 0x0003485C File Offset: 0x00032A5C
		public List<BaseInvokableCall> PrepareInvoke()
		{
			bool needsUpdate = this.m_NeedsUpdate;
			if (needsUpdate)
			{
				this.m_ExecutingCalls.Clear();
				this.m_ExecutingCalls.AddRange(this.m_PersistentCalls);
				this.m_ExecutingCalls.AddRange(this.m_RuntimeCalls);
				this.m_NeedsUpdate = false;
			}
			return this.m_ExecutingCalls;
		}

		// Token: 0x04000A73 RID: 2675
		private readonly List<BaseInvokableCall> m_PersistentCalls = new List<BaseInvokableCall>();

		// Token: 0x04000A74 RID: 2676
		private readonly List<BaseInvokableCall> m_RuntimeCalls = new List<BaseInvokableCall>();

		// Token: 0x04000A75 RID: 2677
		private List<BaseInvokableCall> m_ExecutingCalls = new List<BaseInvokableCall>();

		// Token: 0x04000A76 RID: 2678
		private bool m_NeedsUpdate = true;
	}
}
