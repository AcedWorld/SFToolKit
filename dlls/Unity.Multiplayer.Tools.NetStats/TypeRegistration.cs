using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000027 RID: 39
	internal static class TypeRegistration
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x000032D0 File Offset: 0x000014D0
		public static void RunIfNeeded()
		{
			object obj = TypeRegistration.s_LockObject;
			lock (obj)
			{
				if (!TypeRegistration.s_TypeRegistrationComplete)
				{
					TypeRegistration.s_TypeRegistrationComplete = true;
					foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					{
						if (assembly.GetCustomAttributes<AssemblyRequiresTypeRegistrationAttribute>().Any<AssemblyRequiresTypeRegistrationAttribute>())
						{
							Type type = assembly.GetType("<NetStats_TypeRegistration>");
							MethodInfo methodInfo = (type != null) ? type.GetMethod("Run", BindingFlags.Static | BindingFlags.NonPublic) : null;
							if (methodInfo == null)
							{
								Debug.LogError("Failed to load type initialization for assembly " + assembly.GetName().Name);
							}
							else
							{
								methodInfo.Invoke(null, null);
							}
						}
					}
					MetricIdTypeLibrary.TypeRegistrationPostProcess();
				}
			}
		}

		// Token: 0x04000041 RID: 65
		public const string k_ClassName = "<NetStats_TypeRegistration>";

		// Token: 0x04000042 RID: 66
		public const string k_MethodName = "Run";

		// Token: 0x04000043 RID: 67
		private static bool s_TypeRegistrationComplete;

		// Token: 0x04000044 RID: 68
		private static readonly object s_LockObject = new object();
	}
}
