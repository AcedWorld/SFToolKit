using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace UnityEngine.Events
{
	// Token: 0x020002FE RID: 766
	[Serializable]
	internal class PersistentCallGroup
	{
		// Token: 0x06001F9E RID: 8094 RVA: 0x0003438D File Offset: 0x0003258D
		public PersistentCallGroup()
		{
			this.m_Calls = new List<PersistentCall>();
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x06001F9F RID: 8095 RVA: 0x000343A4 File Offset: 0x000325A4
		public int Count
		{
			get
			{
				return this.m_Calls.Count;
			}
		}

		// Token: 0x06001FA0 RID: 8096 RVA: 0x000343C4 File Offset: 0x000325C4
		public PersistentCall GetListener(int index)
		{
			return this.m_Calls[index];
		}

		// Token: 0x06001FA1 RID: 8097 RVA: 0x000343E4 File Offset: 0x000325E4
		public IEnumerable<PersistentCall> GetListeners()
		{
			return this.m_Calls;
		}

		// Token: 0x06001FA2 RID: 8098 RVA: 0x000343FC File Offset: 0x000325FC
		public void AddListener()
		{
			this.m_Calls.Add(new PersistentCall());
		}

		// Token: 0x06001FA3 RID: 8099 RVA: 0x00034410 File Offset: 0x00032610
		public void AddListener(PersistentCall call)
		{
			this.m_Calls.Add(call);
		}

		// Token: 0x06001FA4 RID: 8100 RVA: 0x00034420 File Offset: 0x00032620
		public void RemoveListener(int index)
		{
			this.m_Calls.RemoveAt(index);
		}

		// Token: 0x06001FA5 RID: 8101 RVA: 0x00034430 File Offset: 0x00032630
		public void Clear()
		{
			this.m_Calls.Clear();
		}

		// Token: 0x06001FA6 RID: 8102 RVA: 0x00034440 File Offset: 0x00032640
		public void RegisterEventPersistentListener(int index, Object targetObj, Type targetObjType, string methodName)
		{
			PersistentCall listener = this.GetListener(index);
			listener.RegisterPersistentListener(targetObj, targetObjType, methodName);
			listener.mode = PersistentListenerMode.EventDefined;
		}

		// Token: 0x06001FA7 RID: 8103 RVA: 0x0003446C File Offset: 0x0003266C
		public void RegisterVoidPersistentListener(int index, Object targetObj, Type targetObjType, string methodName)
		{
			PersistentCall listener = this.GetListener(index);
			listener.RegisterPersistentListener(targetObj, targetObjType, methodName);
			listener.mode = PersistentListenerMode.Void;
		}

		// Token: 0x06001FA8 RID: 8104 RVA: 0x00034498 File Offset: 0x00032698
		public void RegisterObjectPersistentListener(int index, Object targetObj, Type targetObjType, Object argument, string methodName)
		{
			PersistentCall listener = this.GetListener(index);
			listener.RegisterPersistentListener(targetObj, targetObjType, methodName);
			listener.mode = PersistentListenerMode.Object;
			listener.arguments.unityObjectArgument = argument;
		}

		// Token: 0x06001FA9 RID: 8105 RVA: 0x000344D0 File Offset: 0x000326D0
		public void RegisterIntPersistentListener(int index, Object targetObj, Type targetObjType, int argument, string methodName)
		{
			PersistentCall listener = this.GetListener(index);
			listener.RegisterPersistentListener(targetObj, targetObjType, methodName);
			listener.mode = PersistentListenerMode.Int;
			listener.arguments.intArgument = argument;
		}

		// Token: 0x06001FAA RID: 8106 RVA: 0x00034508 File Offset: 0x00032708
		public void RegisterFloatPersistentListener(int index, Object targetObj, Type targetObjType, float argument, string methodName)
		{
			PersistentCall listener = this.GetListener(index);
			listener.RegisterPersistentListener(targetObj, targetObjType, methodName);
			listener.mode = PersistentListenerMode.Float;
			listener.arguments.floatArgument = argument;
		}

		// Token: 0x06001FAB RID: 8107 RVA: 0x00034540 File Offset: 0x00032740
		public void RegisterStringPersistentListener(int index, Object targetObj, Type targetObjType, string argument, string methodName)
		{
			PersistentCall listener = this.GetListener(index);
			listener.RegisterPersistentListener(targetObj, targetObjType, methodName);
			listener.mode = PersistentListenerMode.String;
			listener.arguments.stringArgument = argument;
		}

		// Token: 0x06001FAC RID: 8108 RVA: 0x00034578 File Offset: 0x00032778
		public void RegisterBoolPersistentListener(int index, Object targetObj, Type targetObjType, bool argument, string methodName)
		{
			PersistentCall listener = this.GetListener(index);
			listener.RegisterPersistentListener(targetObj, targetObjType, methodName);
			listener.mode = PersistentListenerMode.Bool;
			listener.arguments.boolArgument = argument;
		}

		// Token: 0x06001FAD RID: 8109 RVA: 0x000345B0 File Offset: 0x000327B0
		public void UnregisterPersistentListener(int index)
		{
			PersistentCall listener = this.GetListener(index);
			listener.UnregisterPersistentListener();
		}

		// Token: 0x06001FAE RID: 8110 RVA: 0x000345D0 File Offset: 0x000327D0
		public void RemoveListeners(Object target, string methodName)
		{
			List<PersistentCall> list = new List<PersistentCall>();
			for (int i = 0; i < this.m_Calls.Count; i++)
			{
				bool flag = this.m_Calls[i].target == target && this.m_Calls[i].methodName == methodName;
				if (flag)
				{
					list.Add(this.m_Calls[i]);
				}
			}
			this.m_Calls.RemoveAll(new Predicate<PersistentCall>(list.Contains));
		}

		// Token: 0x06001FAF RID: 8111 RVA: 0x00034664 File Offset: 0x00032864
		public void Initialize(InvokableCallList invokableList, UnityEventBase unityEventBase)
		{
			foreach (PersistentCall persistentCall in this.m_Calls)
			{
				bool flag = !persistentCall.IsValid();
				if (!flag)
				{
					BaseInvokableCall runtimeCall = persistentCall.GetRuntimeCall(unityEventBase);
					bool flag2 = runtimeCall != null;
					if (flag2)
					{
						invokableList.AddPersistentInvokableCall(runtimeCall);
					}
				}
			}
		}

		// Token: 0x04000A72 RID: 2674
		[FormerlySerializedAs("m_Listeners")]
		[SerializeField]
		private List<PersistentCall> m_Calls;
	}
}
