using System;
using System.Reflection;
using UnityEngine.Serialization;

namespace UnityEngine.Events
{
	// Token: 0x020002FD RID: 765
	[Serializable]
	internal class PersistentCall : ISerializationCallbackReceiver
	{
		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06001F8E RID: 8078 RVA: 0x00033FF0 File Offset: 0x000321F0
		public Object target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06001F8F RID: 8079 RVA: 0x00034008 File Offset: 0x00032208
		public string targetAssemblyTypeName
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_TargetAssemblyTypeName) && this.m_Target != null;
				if (flag)
				{
					this.m_TargetAssemblyTypeName = UnityEventTools.TidyAssemblyTypeName(this.m_Target.GetType().AssemblyQualifiedName);
				}
				return this.m_TargetAssemblyTypeName;
			}
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06001F90 RID: 8080 RVA: 0x00034060 File Offset: 0x00032260
		public string methodName
		{
			get
			{
				return this.m_MethodName;
			}
		}

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06001F91 RID: 8081 RVA: 0x00034078 File Offset: 0x00032278
		// (set) Token: 0x06001F92 RID: 8082 RVA: 0x00034090 File Offset: 0x00032290
		public PersistentListenerMode mode
		{
			get
			{
				return this.m_Mode;
			}
			set
			{
				this.m_Mode = value;
			}
		}

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06001F93 RID: 8083 RVA: 0x0003409C File Offset: 0x0003229C
		public ArgumentCache arguments
		{
			get
			{
				return this.m_Arguments;
			}
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06001F94 RID: 8084 RVA: 0x000340B4 File Offset: 0x000322B4
		// (set) Token: 0x06001F95 RID: 8085 RVA: 0x000340CC File Offset: 0x000322CC
		public UnityEventCallState callState
		{
			get
			{
				return this.m_CallState;
			}
			set
			{
				this.m_CallState = value;
			}
		}

		// Token: 0x06001F96 RID: 8086 RVA: 0x000340D8 File Offset: 0x000322D8
		public bool IsValid()
		{
			return !string.IsNullOrEmpty(this.targetAssemblyTypeName) && !string.IsNullOrEmpty(this.methodName);
		}

		// Token: 0x06001F97 RID: 8087 RVA: 0x00034108 File Offset: 0x00032308
		public BaseInvokableCall GetRuntimeCall(UnityEventBase theEvent)
		{
			bool flag = this.m_CallState == UnityEventCallState.Off || theEvent == null;
			BaseInvokableCall result;
			if (flag)
			{
				result = null;
			}
			else
			{
				MethodInfo methodInfo = theEvent.FindMethod(this);
				bool flag2 = methodInfo == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					bool flag3 = !methodInfo.IsStatic && this.target == null;
					if (flag3)
					{
						result = null;
					}
					else
					{
						Object target = methodInfo.IsStatic ? null : this.target;
						switch (this.m_Mode)
						{
						case PersistentListenerMode.EventDefined:
							result = theEvent.GetDelegate(target, methodInfo);
							break;
						case PersistentListenerMode.Void:
							result = new InvokableCall(target, methodInfo);
							break;
						case PersistentListenerMode.Object:
							result = PersistentCall.GetObjectCall(target, methodInfo, this.m_Arguments);
							break;
						case PersistentListenerMode.Int:
							result = new CachedInvokableCall<int>(target, methodInfo, this.m_Arguments.intArgument);
							break;
						case PersistentListenerMode.Float:
							result = new CachedInvokableCall<float>(target, methodInfo, this.m_Arguments.floatArgument);
							break;
						case PersistentListenerMode.String:
							result = new CachedInvokableCall<string>(target, methodInfo, this.m_Arguments.stringArgument);
							break;
						case PersistentListenerMode.Bool:
							result = new CachedInvokableCall<bool>(target, methodInfo, this.m_Arguments.boolArgument);
							break;
						default:
							result = null;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06001F98 RID: 8088 RVA: 0x00034234 File Offset: 0x00032434
		private static BaseInvokableCall GetObjectCall(Object target, MethodInfo method, ArgumentCache arguments)
		{
			Type type = typeof(Object);
			bool flag = !string.IsNullOrEmpty(arguments.unityObjectArgumentAssemblyTypeName);
			if (flag)
			{
				type = (Type.GetType(arguments.unityObjectArgumentAssemblyTypeName, false) ?? typeof(Object));
			}
			Type typeFromHandle = typeof(CachedInvokableCall<>);
			Type type2 = typeFromHandle.MakeGenericType(new Type[]
			{
				type
			});
			ConstructorInfo constructor = type2.GetConstructor(new Type[]
			{
				typeof(Object),
				typeof(MethodInfo),
				type
			});
			Object @object = arguments.unityObjectArgument;
			bool flag2 = @object != null && !type.IsAssignableFrom(@object.GetType());
			if (flag2)
			{
				@object = null;
			}
			return constructor.Invoke(new object[]
			{
				target,
				method,
				@object
			}) as BaseInvokableCall;
		}

		// Token: 0x06001F99 RID: 8089 RVA: 0x00034315 File Offset: 0x00032515
		public void RegisterPersistentListener(Object ttarget, Type targetType, string mmethodName)
		{
			this.m_Target = ttarget;
			this.m_TargetAssemblyTypeName = UnityEventTools.TidyAssemblyTypeName(targetType.AssemblyQualifiedName);
			this.m_MethodName = mmethodName;
		}

		// Token: 0x06001F9A RID: 8090 RVA: 0x00034337 File Offset: 0x00032537
		public void UnregisterPersistentListener()
		{
			this.m_MethodName = string.Empty;
			this.m_Target = null;
			this.m_TargetAssemblyTypeName = string.Empty;
		}

		// Token: 0x06001F9B RID: 8091 RVA: 0x00034357 File Offset: 0x00032557
		public void OnBeforeSerialize()
		{
			this.m_TargetAssemblyTypeName = UnityEventTools.TidyAssemblyTypeName(this.m_TargetAssemblyTypeName);
		}

		// Token: 0x06001F9C RID: 8092 RVA: 0x00034357 File Offset: 0x00032557
		public void OnAfterDeserialize()
		{
			this.m_TargetAssemblyTypeName = UnityEventTools.TidyAssemblyTypeName(this.m_TargetAssemblyTypeName);
		}

		// Token: 0x04000A6C RID: 2668
		[SerializeField]
		[FormerlySerializedAs("instance")]
		private Object m_Target;

		// Token: 0x04000A6D RID: 2669
		[SerializeField]
		private string m_TargetAssemblyTypeName;

		// Token: 0x04000A6E RID: 2670
		[FormerlySerializedAs("methodName")]
		[SerializeField]
		private string m_MethodName;

		// Token: 0x04000A6F RID: 2671
		[SerializeField]
		[FormerlySerializedAs("mode")]
		private PersistentListenerMode m_Mode = PersistentListenerMode.EventDefined;

		// Token: 0x04000A70 RID: 2672
		[SerializeField]
		[FormerlySerializedAs("arguments")]
		private ArgumentCache m_Arguments = new ArgumentCache();

		// Token: 0x04000A71 RID: 2673
		[FormerlySerializedAs("m_Enabled")]
		[SerializeField]
		[FormerlySerializedAs("enabled")]
		private UnityEventCallState m_CallState = UnityEventCallState.RuntimeOnly;
	}
}
