using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000256 RID: 598
	[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
	[RequiredByNativeCode]
	[ExtensionOfNativeClass]
	[NativeClass(null)]
	[StructLayout(LayoutKind.Sequential)]
	public class ScriptableObject : Object
	{
		// Token: 0x06001969 RID: 6505 RVA: 0x0002A79E File Offset: 0x0002899E
		public ScriptableObject()
		{
			ScriptableObject.CreateScriptableObject(this);
		}

		// Token: 0x0600196A RID: 6506
		[Obsolete("Use EditorUtility.SetDirty instead")]
		[NativeConditional("ENABLE_MONO")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetDirty();

		// Token: 0x0600196B RID: 6507 RVA: 0x0002A7B0 File Offset: 0x000289B0
		public static ScriptableObject CreateInstance(string className)
		{
			return ScriptableObject.CreateScriptableObjectInstanceFromName(className);
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x0002A7C8 File Offset: 0x000289C8
		public static ScriptableObject CreateInstance(Type type)
		{
			return ScriptableObject.CreateScriptableObjectInstanceFromType(type, true);
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x0002A7E4 File Offset: 0x000289E4
		public static T CreateInstance<T>() where T : ScriptableObject
		{
			return (T)((object)ScriptableObject.CreateInstance(typeof(T)));
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x0002A80C File Offset: 0x00028A0C
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal static ScriptableObject CreateInstance(Type type, Action<ScriptableObject> initialize)
		{
			bool flag = !typeof(ScriptableObject).IsAssignableFrom(type);
			if (flag)
			{
				throw new ArgumentException("Type must inherit ScriptableObject.", "type");
			}
			ScriptableObject scriptableObject = ScriptableObject.CreateScriptableObjectInstanceFromType(type, false);
			try
			{
				initialize(scriptableObject);
			}
			finally
			{
				ScriptableObject.ResetAndApplyDefaultInstances(scriptableObject);
			}
			return scriptableObject;
		}

		// Token: 0x0600196F RID: 6511
		[NativeMethod(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateScriptableObject([Writable] ScriptableObject self);

		// Token: 0x06001970 RID: 6512
		[FreeFunction("Scripting::CreateScriptableObject")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ScriptableObject CreateScriptableObjectInstanceFromName(string className);

		// Token: 0x06001971 RID: 6513
		[NativeMethod(Name = "Scripting::CreateScriptableObjectWithType", IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern ScriptableObject CreateScriptableObjectInstanceFromType(Type type, bool applyDefaultsAndReset);

		// Token: 0x06001972 RID: 6514
		[FreeFunction("Scripting::ResetAndApplyDefaultInstances")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ResetAndApplyDefaultInstances([NotNull("NullExceptionObject")] Object obj);
	}
}
