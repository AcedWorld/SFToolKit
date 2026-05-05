using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.TestTools
{
	// Token: 0x020004B5 RID: 1205
	[NativeClass("ScriptingCoverage")]
	[NativeType("Runtime/Scripting/ScriptingCoverage.h")]
	public static class Coverage
	{
		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x06002AA3 RID: 10915
		// (set) Token: 0x06002AA4 RID: 10916
		public static extern bool enabled { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06002AA5 RID: 10917
		[FreeFunction("ScriptingCoverageGetCoverageForMethodInfoObject", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern CoveredSequencePoint[] GetSequencePointsFor_Internal(MethodBase method);

		// Token: 0x06002AA6 RID: 10918
		[FreeFunction("ScriptingCoverageResetForMethodInfoObject", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetFor_Internal(MethodBase method);

		// Token: 0x06002AA7 RID: 10919 RVA: 0x000478FC File Offset: 0x00045AFC
		[FreeFunction("ScriptingCoverageGetStatsForMethodInfoObject", ThrowsException = true)]
		private static CoveredMethodStats GetStatsFor_Internal(MethodBase method)
		{
			CoveredMethodStats result;
			Coverage.GetStatsFor_Internal_Injected(method, out result);
			return result;
		}

		// Token: 0x06002AA8 RID: 10920 RVA: 0x00047914 File Offset: 0x00045B14
		public static CoveredSequencePoint[] GetSequencePointsFor(MethodBase method)
		{
			bool flag = method == null;
			if (flag)
			{
				throw new ArgumentNullException("method");
			}
			return Coverage.GetSequencePointsFor_Internal(method);
		}

		// Token: 0x06002AA9 RID: 10921 RVA: 0x00047944 File Offset: 0x00045B44
		public static CoveredMethodStats GetStatsFor(MethodBase method)
		{
			bool flag = method == null;
			if (flag)
			{
				throw new ArgumentNullException("method");
			}
			return Coverage.GetStatsFor_Internal(method);
		}

		// Token: 0x06002AAA RID: 10922 RVA: 0x00047974 File Offset: 0x00045B74
		public static CoveredMethodStats[] GetStatsFor(MethodBase[] methods)
		{
			bool flag = methods == null;
			if (flag)
			{
				throw new ArgumentNullException("methods");
			}
			CoveredMethodStats[] array = new CoveredMethodStats[methods.Length];
			for (int i = 0; i < methods.Length; i++)
			{
				array[i] = Coverage.GetStatsFor(methods[i]);
			}
			return array;
		}

		// Token: 0x06002AAB RID: 10923 RVA: 0x000479C8 File Offset: 0x00045BC8
		public static CoveredMethodStats[] GetStatsFor(Type type)
		{
			bool flag = type == null;
			if (flag)
			{
				throw new ArgumentNullException("type");
			}
			return Coverage.GetStatsFor(type.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).OfType<MethodBase>().ToArray<MethodBase>());
		}

		// Token: 0x06002AAC RID: 10924
		[FreeFunction("ScriptingCoverageGetStatsForAllCoveredMethodsFromScripting", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern CoveredMethodStats[] GetStatsForAllCoveredMethods();

		// Token: 0x06002AAD RID: 10925 RVA: 0x00047A08 File Offset: 0x00045C08
		public static void ResetFor(MethodBase method)
		{
			bool flag = method == null;
			if (flag)
			{
				throw new ArgumentNullException("method");
			}
			Coverage.ResetFor_Internal(method);
		}

		// Token: 0x06002AAE RID: 10926
		[FreeFunction("ScriptingCoverageResetAllFromScripting", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ResetAll();

		// Token: 0x06002AAF RID: 10927
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetStatsFor_Internal_Injected(MethodBase method, out CoveredMethodStats ret);
	}
}
