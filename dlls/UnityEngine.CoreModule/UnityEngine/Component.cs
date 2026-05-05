using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine
{
	// Token: 0x0200023C RID: 572
	[RequiredByNativeCode]
	[NativeHeader("Runtime/Export/Scripting/Component.bindings.h")]
	[NativeClass("Unity::Component")]
	public class Component : Object
	{
		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06001872 RID: 6258
		public extern Transform transform { [FreeFunction("GetTransform", HasExplicitThis = true, ThrowsException = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06001873 RID: 6259
		public extern GameObject gameObject { [FreeFunction("GetGameObject", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06001874 RID: 6260 RVA: 0x00028AB0 File Offset: 0x00026CB0
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponent(Type type)
		{
			return this.gameObject.GetComponent(type);
		}

		// Token: 0x06001875 RID: 6261
		[FreeFunction(HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void GetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue);

		// Token: 0x06001876 RID: 6262 RVA: 0x00028AD0 File Offset: 0x00026CD0
		[SecuritySafeCritical]
		public unsafe T GetComponent<T>()
		{
			CastHelper<T> castHelper = default(CastHelper<T>);
			this.GetComponentFastPath(typeof(T), new IntPtr((void*)(&castHelper.onePointerFurtherThanT)));
			return castHelper.t;
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x00028B10 File Offset: 0x00026D10
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public bool TryGetComponent(Type type, out Component component)
		{
			return this.gameObject.TryGetComponent(type, out component);
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x00028B30 File Offset: 0x00026D30
		[SecuritySafeCritical]
		public bool TryGetComponent<T>(out T component)
		{
			return this.gameObject.TryGetComponent<T>(out component);
		}

		// Token: 0x06001879 RID: 6265
		[FreeFunction(HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Component GetComponent(string type);

		// Token: 0x0600187A RID: 6266 RVA: 0x00028B50 File Offset: 0x00026D50
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInChildren(Type t, bool includeInactive)
		{
			return this.gameObject.GetComponentInChildren(t, includeInactive);
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x00028B70 File Offset: 0x00026D70
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInChildren(Type t)
		{
			return this.GetComponentInChildren(t, false);
		}

		// Token: 0x0600187C RID: 6268 RVA: 0x00028B8C File Offset: 0x00026D8C
		public T GetComponentInChildren<T>([DefaultValue("false")] bool includeInactive)
		{
			return (T)((object)this.GetComponentInChildren(typeof(T), includeInactive));
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x00028BB4 File Offset: 0x00026DB4
		[ExcludeFromDocs]
		public T GetComponentInChildren<T>()
		{
			return (T)((object)this.GetComponentInChildren(typeof(T), false));
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x00028BDC File Offset: 0x00026DDC
		public Component[] GetComponentsInChildren(Type t, bool includeInactive)
		{
			return this.gameObject.GetComponentsInChildren(t, includeInactive);
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x00028BFC File Offset: 0x00026DFC
		[ExcludeFromDocs]
		public Component[] GetComponentsInChildren(Type t)
		{
			return this.gameObject.GetComponentsInChildren(t, false);
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x00028C1C File Offset: 0x00026E1C
		public T[] GetComponentsInChildren<T>(bool includeInactive)
		{
			return this.gameObject.GetComponentsInChildren<T>(includeInactive);
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x00028C3A File Offset: 0x00026E3A
		public void GetComponentsInChildren<T>(bool includeInactive, List<T> result)
		{
			this.gameObject.GetComponentsInChildren<T>(includeInactive, result);
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x00028C4C File Offset: 0x00026E4C
		public T[] GetComponentsInChildren<T>()
		{
			return this.GetComponentsInChildren<T>(false);
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x00028C65 File Offset: 0x00026E65
		public void GetComponentsInChildren<T>(List<T> results)
		{
			this.GetComponentsInChildren<T>(false, results);
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x00028C74 File Offset: 0x00026E74
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInParent(Type t, bool includeInactive)
		{
			return this.gameObject.GetComponentInParent(t, includeInactive);
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x00028C94 File Offset: 0x00026E94
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInParent(Type t)
		{
			return this.gameObject.GetComponentInParent(t, false);
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x00028CB4 File Offset: 0x00026EB4
		public T GetComponentInParent<T>([DefaultValue("false")] bool includeInactive)
		{
			return (T)((object)this.GetComponentInParent(typeof(T), includeInactive));
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x00028CDC File Offset: 0x00026EDC
		public T GetComponentInParent<T>()
		{
			return (T)((object)this.GetComponentInParent(typeof(T), false));
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00028D04 File Offset: 0x00026F04
		public Component[] GetComponentsInParent(Type t, [DefaultValue("false")] bool includeInactive)
		{
			return this.gameObject.GetComponentsInParent(t, includeInactive);
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x00028D24 File Offset: 0x00026F24
		[ExcludeFromDocs]
		public Component[] GetComponentsInParent(Type t)
		{
			return this.GetComponentsInParent(t, false);
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x00028D40 File Offset: 0x00026F40
		public T[] GetComponentsInParent<T>(bool includeInactive)
		{
			return this.gameObject.GetComponentsInParent<T>(includeInactive);
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x00028D5E File Offset: 0x00026F5E
		public void GetComponentsInParent<T>(bool includeInactive, List<T> results)
		{
			this.gameObject.GetComponentsInParent<T>(includeInactive, results);
		}

		// Token: 0x0600188C RID: 6284 RVA: 0x00028D70 File Offset: 0x00026F70
		public T[] GetComponentsInParent<T>()
		{
			return this.GetComponentsInParent<T>(false);
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x00028D8C File Offset: 0x00026F8C
		public Component[] GetComponents(Type type)
		{
			return this.gameObject.GetComponents(type);
		}

		// Token: 0x0600188E RID: 6286
		[FreeFunction(HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetComponentsForListInternal(Type searchType, object resultList);

		// Token: 0x0600188F RID: 6287 RVA: 0x00028DAA File Offset: 0x00026FAA
		public void GetComponents(Type type, List<Component> results)
		{
			this.GetComponentsForListInternal(type, results);
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x00028DB6 File Offset: 0x00026FB6
		public void GetComponents<T>(List<T> results)
		{
			this.GetComponentsForListInternal(typeof(T), results);
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06001891 RID: 6289 RVA: 0x00028DCB File Offset: 0x00026FCB
		// (set) Token: 0x06001892 RID: 6290 RVA: 0x00028DD8 File Offset: 0x00026FD8
		public string tag
		{
			get
			{
				return this.gameObject.tag;
			}
			set
			{
				this.gameObject.tag = value;
			}
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x00028DE8 File Offset: 0x00026FE8
		public T[] GetComponents<T>()
		{
			return this.gameObject.GetComponents<T>();
		}

		// Token: 0x06001894 RID: 6292
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetComponentIndex();

		// Token: 0x06001895 RID: 6293 RVA: 0x00028E08 File Offset: 0x00027008
		public bool CompareTag(string tag)
		{
			return this.gameObject.CompareTag(tag);
		}

		// Token: 0x06001896 RID: 6294
		[FreeFunction(HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SendMessageUpwards(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

		// Token: 0x06001897 RID: 6295 RVA: 0x00028E26 File Offset: 0x00027026
		[ExcludeFromDocs]
		public void SendMessageUpwards(string methodName, object value)
		{
			this.SendMessageUpwards(methodName, value, SendMessageOptions.RequireReceiver);
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x00028E33 File Offset: 0x00027033
		[ExcludeFromDocs]
		public void SendMessageUpwards(string methodName)
		{
			this.SendMessageUpwards(methodName, null, SendMessageOptions.RequireReceiver);
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x00028E40 File Offset: 0x00027040
		public void SendMessageUpwards(string methodName, SendMessageOptions options)
		{
			this.SendMessageUpwards(methodName, null, options);
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x00028E4D File Offset: 0x0002704D
		public void SendMessage(string methodName, object value)
		{
			this.SendMessage(methodName, value, SendMessageOptions.RequireReceiver);
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x00028E5A File Offset: 0x0002705A
		public void SendMessage(string methodName)
		{
			this.SendMessage(methodName, null, SendMessageOptions.RequireReceiver);
		}

		// Token: 0x0600189C RID: 6300
		[FreeFunction("SendMessage", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SendMessage(string methodName, object value, SendMessageOptions options);

		// Token: 0x0600189D RID: 6301 RVA: 0x00028E67 File Offset: 0x00027067
		public void SendMessage(string methodName, SendMessageOptions options)
		{
			this.SendMessage(methodName, null, options);
		}

		// Token: 0x0600189E RID: 6302
		[FreeFunction("BroadcastMessage", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void BroadcastMessage(string methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

		// Token: 0x0600189F RID: 6303 RVA: 0x00028E74 File Offset: 0x00027074
		[ExcludeFromDocs]
		public void BroadcastMessage(string methodName, object parameter)
		{
			this.BroadcastMessage(methodName, parameter, SendMessageOptions.RequireReceiver);
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x00028E81 File Offset: 0x00027081
		[ExcludeFromDocs]
		public void BroadcastMessage(string methodName)
		{
			this.BroadcastMessage(methodName, null, SendMessageOptions.RequireReceiver);
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x00028E8E File Offset: 0x0002708E
		public void BroadcastMessage(string methodName, SendMessageOptions options)
		{
			this.BroadcastMessage(methodName, null, options);
		}
	}
}
