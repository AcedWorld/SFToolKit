using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32.SafeHandles;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000238 RID: 568
	internal static class ClassLibraryInitializer
	{
		// Token: 0x06001861 RID: 6241 RVA: 0x0002860C File Offset: 0x0002680C
		[RequiredByNativeCode]
		private static void Init()
		{
			UnityLogWriter.Init();
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x00028618 File Offset: 0x00026818
		[RequiredByNativeCode]
		private static void InitStdErrWithHandle(IntPtr fileHandle)
		{
			SafeFileHandle safeFileHandle = new SafeFileHandle(fileHandle, false);
			bool flag = !safeFileHandle.IsInvalid;
			if (flag)
			{
				StreamWriter error = new StreamWriter(new FileStream(safeFileHandle, FileAccess.Write))
				{
					AutoFlush = true
				};
				Console.SetError(error);
			}
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x00028659 File Offset: 0x00026859
		[RequiredByNativeCode]
		private static void InitAssemblyRedirections()
		{
			AppDomain.CurrentDomain.AssemblyResolve += delegate(object _, ResolveEventArgs args)
			{
				AssemblyName assemblyName = new AssemblyName(args.Name);
				Assembly result;
				try
				{
					Assembly assembly = AppDomain.CurrentDomain.Load(assemblyName.Name);
					result = assembly;
				}
				catch
				{
					result = null;
				}
				return result;
			};
		}
	}
}
