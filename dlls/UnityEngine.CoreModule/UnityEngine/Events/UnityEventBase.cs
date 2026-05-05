using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

namespace UnityEngine.Events
{
	// Token: 0x02000300 RID: 768
	[UsedByNativeCode]
	[Serializable]
	public abstract class UnityEventBase : ISerializationCallbackReceiver
	{
		// Token: 0x06001FB8 RID: 8120 RVA: 0x000348E8 File Offset: 0x00032AE8
		protected UnityEventBase()
		{
			this.m_Calls = new InvokableCallList();
			this.m_PersistentCalls = new PersistentCallGroup();
		}

		// Token: 0x06001FB9 RID: 8121 RVA: 0x0003490F File Offset: 0x00032B0F
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			this.DirtyPersistentCalls();
		}

		// Token: 0x06001FBA RID: 8122 RVA: 0x0003490F File Offset: 0x00032B0F
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			this.DirtyPersistentCalls();
		}

		// Token: 0x06001FBB RID: 8123 RVA: 0x0003491C File Offset: 0x00032B1C
		protected MethodInfo FindMethod_Impl(string name, object targetObj)
		{
			return this.FindMethod_Impl(name, targetObj.GetType());
		}

		// Token: 0x06001FBC RID: 8124
		protected abstract MethodInfo FindMethod_Impl(string name, Type targetObjType);

		// Token: 0x06001FBD RID: 8125
		internal abstract BaseInvokableCall GetDelegate(object target, MethodInfo theFunction);

		// Token: 0x06001FBE RID: 8126 RVA: 0x0003493C File Offset: 0x00032B3C
		internal MethodInfo FindMethod(PersistentCall call)
		{
			Type argumentType = typeof(Object);
			bool flag = !string.IsNullOrEmpty(call.arguments.unityObjectArgumentAssemblyTypeName);
			if (flag)
			{
				argumentType = (Type.GetType(call.arguments.unityObjectArgumentAssemblyTypeName, false) ?? typeof(Object));
			}
			Type listenerType = (call.target != null) ? call.target.GetType() : Type.GetType(call.targetAssemblyTypeName, false);
			return this.FindMethod(call.methodName, listenerType, call.mode, argumentType);
		}

		// Token: 0x06001FBF RID: 8127 RVA: 0x000349CC File Offset: 0x00032BCC
		internal MethodInfo FindMethod(string name, Type listenerType, PersistentListenerMode mode, Type argumentType)
		{
			MethodInfo result;
			switch (mode)
			{
			case PersistentListenerMode.EventDefined:
				result = this.FindMethod_Impl(name, listenerType);
				break;
			case PersistentListenerMode.Void:
				result = UnityEventBase.GetValidMethodInfo(listenerType, name, new Type[0]);
				break;
			case PersistentListenerMode.Object:
				result = UnityEventBase.GetValidMethodInfo(listenerType, name, new Type[]
				{
					argumentType ?? typeof(Object)
				});
				break;
			case PersistentListenerMode.Int:
				result = UnityEventBase.GetValidMethodInfo(listenerType, name, new Type[]
				{
					typeof(int)
				});
				break;
			case PersistentListenerMode.Float:
				result = UnityEventBase.GetValidMethodInfo(listenerType, name, new Type[]
				{
					typeof(float)
				});
				break;
			case PersistentListenerMode.String:
				result = UnityEventBase.GetValidMethodInfo(listenerType, name, new Type[]
				{
					typeof(string)
				});
				break;
			case PersistentListenerMode.Bool:
				result = UnityEventBase.GetValidMethodInfo(listenerType, name, new Type[]
				{
					typeof(bool)
				});
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06001FC0 RID: 8128 RVA: 0x00034AC4 File Offset: 0x00032CC4
		internal int GetCallsCount()
		{
			return this.m_Calls.Count;
		}

		// Token: 0x06001FC1 RID: 8129 RVA: 0x00034AE4 File Offset: 0x00032CE4
		public int GetPersistentEventCount()
		{
			return this.m_PersistentCalls.Count;
		}

		// Token: 0x06001FC2 RID: 8130 RVA: 0x00034B04 File Offset: 0x00032D04
		public Object GetPersistentTarget(int index)
		{
			PersistentCall listener = this.m_PersistentCalls.GetListener(index);
			return (listener != null) ? listener.target : null;
		}

		// Token: 0x06001FC3 RID: 8131 RVA: 0x00034B30 File Offset: 0x00032D30
		public string GetPersistentMethodName(int index)
		{
			PersistentCall listener = this.m_PersistentCalls.GetListener(index);
			return (listener != null) ? listener.methodName : string.Empty;
		}

		// Token: 0x06001FC4 RID: 8132 RVA: 0x00034B5F File Offset: 0x00032D5F
		private void DirtyPersistentCalls()
		{
			this.m_Calls.ClearPersistent();
			this.m_CallsDirty = true;
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x00034B78 File Offset: 0x00032D78
		private void RebuildPersistentCallsIfNeeded()
		{
			bool callsDirty = this.m_CallsDirty;
			if (callsDirty)
			{
				this.m_PersistentCalls.Initialize(this.m_Calls, this);
				this.m_CallsDirty = false;
			}
		}

		// Token: 0x06001FC6 RID: 8134 RVA: 0x00034BAC File Offset: 0x00032DAC
		public void SetPersistentListenerState(int index, UnityEventCallState state)
		{
			PersistentCall listener = this.m_PersistentCalls.GetListener(index);
			bool flag = listener != null;
			if (flag)
			{
				listener.callState = state;
			}
			this.DirtyPersistentCalls();
		}

		// Token: 0x06001FC7 RID: 8135 RVA: 0x00034BE0 File Offset: 0x00032DE0
		public UnityEventCallState GetPersistentListenerState(int index)
		{
			bool flag = index < 0 || index > this.m_PersistentCalls.Count;
			if (flag)
			{
				throw new IndexOutOfRangeException(string.Format("Index {0} is out of range of the {1} persistent listeners.", index, this.GetPersistentEventCount()));
			}
			return this.m_PersistentCalls.GetListener(index).callState;
		}

		// Token: 0x06001FC8 RID: 8136 RVA: 0x00034C3D File Offset: 0x00032E3D
		protected void AddListener(object targetObj, MethodInfo method)
		{
			this.m_Calls.AddListener(this.GetDelegate(targetObj, method));
		}

		// Token: 0x06001FC9 RID: 8137 RVA: 0x00034C54 File Offset: 0x00032E54
		internal void AddCall(BaseInvokableCall call)
		{
			this.m_Calls.AddListener(call);
		}

		// Token: 0x06001FCA RID: 8138 RVA: 0x00034C64 File Offset: 0x00032E64
		protected void RemoveListener(object targetObj, MethodInfo method)
		{
			this.m_Calls.RemoveListener(targetObj, method);
		}

		// Token: 0x06001FCB RID: 8139 RVA: 0x00034C75 File Offset: 0x00032E75
		public void RemoveAllListeners()
		{
			this.m_Calls.Clear();
		}

		// Token: 0x06001FCC RID: 8140 RVA: 0x00034C84 File Offset: 0x00032E84
		internal List<BaseInvokableCall> PrepareInvoke()
		{
			this.RebuildPersistentCallsIfNeeded();
			return this.m_Calls.PrepareInvoke();
		}

		// Token: 0x06001FCD RID: 8141 RVA: 0x00034CA8 File Offset: 0x00032EA8
		protected void Invoke(object[] parameters)
		{
			List<BaseInvokableCall> list = this.PrepareInvoke();
			for (int i = 0; i < list.Count; i++)
			{
				list[i].Invoke(parameters);
			}
		}

		// Token: 0x06001FCE RID: 8142 RVA: 0x00034CE0 File Offset: 0x00032EE0
		public override string ToString()
		{
			return base.ToString() + " " + base.GetType().FullName;
		}

		// Token: 0x06001FCF RID: 8143 RVA: 0x00034D10 File Offset: 0x00032F10
		public static MethodInfo GetValidMethodInfo(object obj, string functionName, Type[] argumentTypes)
		{
			return UnityEventBase.GetValidMethodInfo(obj.GetType(), functionName, argumentTypes);
		}

		// Token: 0x06001FD0 RID: 8144 RVA: 0x00034D30 File Offset: 0x00032F30
		public static MethodInfo GetValidMethodInfo(Type objectType, string functionName, Type[] argumentTypes)
		{
			while (objectType != typeof(object) && objectType != null)
			{
				MethodInfo method = objectType.GetMethod(functionName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, argumentTypes, null);
				bool flag = method != null;
				if (flag)
				{
					ParameterInfo[] parameters = method.GetParameters();
					bool flag2 = true;
					int num = 0;
					foreach (ParameterInfo parameterInfo in parameters)
					{
						Type type = argumentTypes[num];
						Type parameterType = parameterInfo.ParameterType;
						flag2 = (type.IsPrimitive == parameterType.IsPrimitive);
						bool flag3 = !flag2;
						if (flag3)
						{
							break;
						}
						num++;
					}
					bool flag4 = flag2;
					if (flag4)
					{
						return method;
					}
				}
				objectType = objectType.BaseType;
			}
			return null;
		}

		// Token: 0x04000A77 RID: 2679
		private InvokableCallList m_Calls;

		// Token: 0x04000A78 RID: 2680
		[FormerlySerializedAs("m_PersistentListeners")]
		[SerializeField]
		private PersistentCallGroup m_PersistentCalls;

		// Token: 0x04000A79 RID: 2681
		private bool m_CallsDirty = true;
	}
}
