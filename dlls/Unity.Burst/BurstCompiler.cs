using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using AOT;
using Unity.Burst.LowLevel;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Burst
{
	// Token: 0x02000009 RID: 9
	public static class BurstCompiler
	{
		// Token: 0x06000018 RID: 24 RVA: 0x000021E9 File Offset: 0x000003E9
		public static bool IsLoadAdditionalLibrarySupported()
		{
			return BurstCompiler.IsApiAvailable("LoadBurstLibrary");
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000021F5 File Offset: 0x000003F5
		private static BurstCompiler.CommandBuilder BeginCompilerCommand(string cmd)
		{
			if (BurstCompiler._cmdBuilder == null)
			{
				BurstCompiler._cmdBuilder = new BurstCompiler.CommandBuilder();
			}
			return BurstCompiler._cmdBuilder.Begin(cmd);
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002213 File Offset: 0x00000413
		public static bool IsEnabled
		{
			get
			{
				return BurstCompiler._IsEnabled && BurstCompiler.BurstCompilerHelper.IsBurstGenerated;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002223 File Offset: 0x00000423
		public static void SetExecutionMode(BurstExecutionEnvironment mode)
		{
			BurstCompilerService.SetCurrentExecutionMode((uint)mode);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000222B File Offset: 0x0000042B
		public static BurstExecutionEnvironment GetExecutionMode()
		{
			return (BurstExecutionEnvironment)BurstCompilerService.GetCurrentExecutionMode();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002232 File Offset: 0x00000432
		internal static T CompileDelegate<T>(T delegateMethod) where T : class
		{
			return (T)((object)Marshal.GetDelegateForFunctionPointer((IntPtr)BurstCompiler.Compile(delegateMethod, false), delegateMethod.GetType()));
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000225A File Offset: 0x0000045A
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void VerifyDelegateIsNotMulticast<T>(T delegateMethod) where T : class
		{
			if ((delegateMethod as Delegate).GetInvocationList().Length > 1)
			{
				throw new InvalidOperationException(string.Format("Burst does not support multicast delegates, please use a regular delegate for `{0}'", delegateMethod));
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002288 File Offset: 0x00000488
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void VerifyDelegateHasCorrectUnmanagedFunctionPointerAttribute<T>(T delegateMethod) where T : class
		{
			UnmanagedFunctionPointerAttribute customAttribute = delegateMethod.GetType().GetCustomAttribute<UnmanagedFunctionPointerAttribute>();
			if (customAttribute == null || customAttribute.CallingConvention != CallingConvention.Cdecl)
			{
				Debug.LogWarning("The delegate type " + delegateMethod.GetType().FullName + " should be decorated with [UnmanagedFunctionPointer(CallingConvention.Cdecl)] to ensure runtime interoperabilty between managed code and Burst-compiled code.");
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000022D6 File Offset: 0x000004D6
		[Obsolete("This method will be removed in a future version of Burst")]
		public static IntPtr CompileILPPMethod(RuntimeMethodHandle burstMethodHandle, RuntimeMethodHandle managedMethodHandle, RuntimeTypeHandle delegateTypeHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000022E0 File Offset: 0x000004E0
		public static IntPtr CompileILPPMethod2(RuntimeMethodHandle burstMethodHandle)
		{
			if (burstMethodHandle.Value == IntPtr.Zero)
			{
				throw new ArgumentNullException("burstMethodHandle");
			}
			Action onCompileILPPMethod = BurstCompiler.OnCompileILPPMethod2;
			if (onCompileILPPMethod != null)
			{
				onCompileILPPMethod();
			}
			MethodInfo methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle(burstMethodHandle);
			return (IntPtr)BurstCompiler.Compile(new BurstCompiler.FakeDelegate(methodInfo), methodInfo, true, true);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000233A File Offset: 0x0000053A
		[Obsolete("This method will be removed in a future version of Burst")]
		public unsafe static void* GetILPPMethodFunctionPointer(IntPtr ilppMethod)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002344 File Offset: 0x00000544
		public unsafe static void* GetILPPMethodFunctionPointer2(IntPtr ilppMethod, RuntimeMethodHandle managedMethodHandle, RuntimeTypeHandle delegateTypeHandle)
		{
			if (ilppMethod == IntPtr.Zero)
			{
				throw new ArgumentNullException("ilppMethod");
			}
			if (managedMethodHandle.Value == IntPtr.Zero)
			{
				throw new ArgumentNullException("managedMethodHandle");
			}
			if (delegateTypeHandle.Value == IntPtr.Zero)
			{
				throw new ArgumentNullException("delegateTypeHandle");
			}
			return ilppMethod.ToPointer();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000023AC File Offset: 0x000005AC
		[Obsolete("This method will be removed in a future version of Burst")]
		public unsafe static void* CompileUnsafeStaticMethod(RuntimeMethodHandle handle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000023B3 File Offset: 0x000005B3
		public static FunctionPointer<T> CompileFunctionPointer<T>(T delegateMethod) where T : class
		{
			return new FunctionPointer<T>(new IntPtr(BurstCompiler.Compile(delegateMethod, true)));
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000023CC File Offset: 0x000005CC
		private unsafe static void* Compile(object delegateObj, bool isFunctionPointer)
		{
			if (!(delegateObj is Delegate))
			{
				throw new ArgumentException("object instance must be a System.Delegate", "delegateObj");
			}
			Delegate @delegate = (Delegate)delegateObj;
			return BurstCompiler.Compile(@delegate, @delegate.Method, isFunctionPointer, false);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002408 File Offset: 0x00000608
		private unsafe static void* Compile(object delegateObj, MethodInfo methodInfo, bool isFunctionPointer, bool isILPostProcessing)
		{
			if (delegateObj == null)
			{
				throw new ArgumentNullException("delegateObj");
			}
			if (delegateObj.GetType().IsGenericType)
			{
				throw new InvalidOperationException(string.Format("The delegate type `{0}` must be a non-generic type", delegateObj.GetType()));
			}
			if (!methodInfo.IsStatic)
			{
				throw new InvalidOperationException(string.Format("The method `{0}` must be static. Instance methods are not supported", methodInfo));
			}
			if (methodInfo.IsGenericMethod)
			{
				throw new InvalidOperationException(string.Format("The method `{0}` must be a non-generic method", methodInfo));
			}
			Delegate @delegate = null;
			if (!isILPostProcessing)
			{
				@delegate = (delegateObj as Delegate);
			}
			if (!BurstCompilerOptions.HasBurstCompileAttribute(methodInfo))
			{
				throw new InvalidOperationException(string.Format("Burst cannot compile the function pointer `{0}` because the `[BurstCompile]` attribute is missing", methodInfo));
			}
			void* ptr;
			if (BurstCompiler.Options.EnableBurstCompilation && BurstCompiler.BurstCompilerHelper.IsBurstGenerated)
			{
				ptr = BurstCompilerService.GetAsyncCompiledAsyncDelegateMethod(BurstCompilerService.CompileAsyncDelegateMethod(delegateObj, string.Empty));
			}
			else
			{
				if (isILPostProcessing)
				{
					return null;
				}
				GCHandle.Alloc(@delegate);
				ptr = (void*)Marshal.GetFunctionPointerForDelegate(@delegate);
			}
			if (ptr == null)
			{
				throw new InvalidOperationException(string.Format("Burst failed to compile the function pointer `{0}`", methodInfo));
			}
			return ptr;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000024F5 File Offset: 0x000006F5
		internal static void Shutdown()
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000024F7 File Offset: 0x000006F7
		internal static void Cancel()
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000024F9 File Offset: 0x000006F9
		internal static bool IsCurrentCompilationDone()
		{
			return true;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000024FC File Offset: 0x000006FC
		internal static void Enable()
		{
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000024FE File Offset: 0x000006FE
		internal static void Disable()
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002500 File Offset: 0x00000700
		internal static bool IsHostEditorArm()
		{
			return false;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002504 File Offset: 0x00000704
		internal static void TriggerUnsafeStaticMethodRecompilation()
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				foreach (Attribute attribute in from x in assemblies[i].GetCustomAttributes()
				where x.GetType().FullName == "Unity.Burst.BurstCompiler+StaticTypeReinitAttribute"
				select x)
				{
					(attribute as BurstCompiler.StaticTypeReinitAttribute).reinitType.GetMethod("Constructor", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[0]);
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000025AC File Offset: 0x000007AC
		internal static void TriggerRecompilation()
		{
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000025AE File Offset: 0x000007AE
		internal static void UnloadAdditionalLibraries()
		{
			BurstCompiler.SendCommandToCompiler("$unload_burst_natives", null);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000025BC File Offset: 0x000007BC
		internal static void InitialiseDebuggerHooks()
		{
			if (BurstCompiler.IsApiAvailable("BurstManagedDebuggerPluginV1") && string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BURST_DISABLE_DEBUGGER_HOOKS")))
			{
				BurstCompiler.SendCommandToCompiler(BurstCompiler.SendCommandToCompiler("$request_debug_command", null), null);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000025ED File Offset: 0x000007ED
		internal static bool IsApiAvailable(string apiName)
		{
			return BurstCompiler.SendCommandToCompiler("$is_native_api_available", apiName) == "True";
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002604 File Offset: 0x00000804
		internal static int RequestSetProtocolVersion(int version)
		{
			string text = BurstCompiler.SendCommandToCompiler("$request_set_protocol_version_editor", string.Format("{0}", version));
			int num;
			if (string.IsNullOrEmpty(text) || !int.TryParse(text, out num))
			{
				num = 0;
			}
			BurstCompiler.SendCommandToCompiler("$set_protocol_version_burst", string.Format("{0}", num));
			return num;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000265C File Offset: 0x0000085C
		internal static void Initialize(string[] assemblyFolders, string[] ignoreAssemblies)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000265E File Offset: 0x0000085E
		internal static void NotifyCompilationStarted(string[] assemblyFolders, string[] ignoreAssemblies)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002660 File Offset: 0x00000860
		internal static void NotifyAssemblyCompilationNotRequired(string assemblyName)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002662 File Offset: 0x00000862
		internal static void NotifyAssemblyCompilationFinished(string assemblyName, string[] defines)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002664 File Offset: 0x00000864
		internal static void NotifyCompilationFinished()
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002666 File Offset: 0x00000866
		internal static string AotCompilation(string[] assemblyFolders, string[] assemblyRoots, string options)
		{
			return "failed";
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000266D File Offset: 0x0000086D
		internal static void SetProfilerCallbacks()
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002670 File Offset: 0x00000870
		private static string SendRawCommandToCompiler(string command)
		{
			string disassembly = BurstCompilerService.GetDisassembly(BurstCompiler.DummyMethodInfo, command);
			if (!string.IsNullOrEmpty(disassembly))
			{
				return disassembly.TrimStart('\n');
			}
			return "";
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000269F File Offset: 0x0000089F
		private static string SendCommandToCompiler(string commandName, string commandArgs = null)
		{
			if (commandName == null)
			{
				throw new ArgumentNullException("commandName");
			}
			if (commandArgs == null)
			{
				return BurstCompiler.SendRawCommandToCompiler(commandName);
			}
			return BurstCompiler.BeginCompilerCommand(commandName).With(commandArgs).SendToCompiler();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000026CA File Offset: 0x000008CA
		private static void DummyMethod()
		{
		}

		// Token: 0x04000019 RID: 25
		[ThreadStatic]
		private static BurstCompiler.CommandBuilder _cmdBuilder;

		// Token: 0x0400001A RID: 26
		internal static bool _IsEnabled;

		// Token: 0x0400001B RID: 27
		public static readonly BurstCompilerOptions Options = new BurstCompilerOptions(true);

		// Token: 0x0400001C RID: 28
		internal static Action OnCompileILPPMethod2;

		// Token: 0x0400001D RID: 29
		private static readonly MethodInfo DummyMethodInfo = typeof(BurstCompiler).GetMethod("DummyMethod", BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x0200002B RID: 43
		private class CommandBuilder
		{
			// Token: 0x0600013E RID: 318 RVA: 0x00007A38 File Offset: 0x00005C38
			public CommandBuilder()
			{
				this._builder = new StringBuilder();
				this._hasArgs = false;
			}

			// Token: 0x0600013F RID: 319 RVA: 0x00007A52 File Offset: 0x00005C52
			public BurstCompiler.CommandBuilder Begin(string cmd)
			{
				this._builder.Clear();
				this._hasArgs = false;
				this._builder.Append(cmd);
				return this;
			}

			// Token: 0x06000140 RID: 320 RVA: 0x00007A75 File Offset: 0x00005C75
			public BurstCompiler.CommandBuilder With(string arg)
			{
				if (!this._hasArgs)
				{
					this._builder.Append(' ');
				}
				this._hasArgs = true;
				this._builder.Append(arg);
				return this;
			}

			// Token: 0x06000141 RID: 321 RVA: 0x00007AA2 File Offset: 0x00005CA2
			public BurstCompiler.CommandBuilder With(IntPtr arg)
			{
				if (!this._hasArgs)
				{
					this._builder.Append(' ');
				}
				this._hasArgs = true;
				this._builder.AppendFormat("0x{0:X16}", arg.ToInt64());
				return this;
			}

			// Token: 0x06000142 RID: 322 RVA: 0x00007ADF File Offset: 0x00005CDF
			public BurstCompiler.CommandBuilder And(char sep = '|')
			{
				this._builder.Append(sep);
				return this;
			}

			// Token: 0x06000143 RID: 323 RVA: 0x00007AEF File Offset: 0x00005CEF
			public string SendToCompiler()
			{
				return BurstCompiler.SendRawCommandToCompiler(this._builder.ToString());
			}

			// Token: 0x04000243 RID: 579
			private StringBuilder _builder;

			// Token: 0x04000244 RID: 580
			private bool _hasArgs;
		}

		// Token: 0x0200002C RID: 44
		[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
		internal class StaticTypeReinitAttribute : Attribute
		{
			// Token: 0x06000144 RID: 324 RVA: 0x00007B01 File Offset: 0x00005D01
			public StaticTypeReinitAttribute(Type toReinit)
			{
				this.reinitType = toReinit;
			}

			// Token: 0x04000245 RID: 581
			public readonly Type reinitType;
		}

		// Token: 0x0200002D RID: 45
		[BurstCompile]
		internal static class BurstCompilerHelper
		{
			// Token: 0x06000145 RID: 325 RVA: 0x00007B10 File Offset: 0x00005D10
			[BurstCompile]
			[MonoPInvokeCallback(typeof(BurstCompiler.BurstCompilerHelper.IsBurstEnabledDelegate))]
			private static bool IsBurstEnabled()
			{
				bool result = true;
				BurstCompiler.BurstCompilerHelper.DiscardedMethod(ref result);
				return result;
			}

			// Token: 0x06000146 RID: 326 RVA: 0x00007B27 File Offset: 0x00005D27
			[BurstDiscard]
			private static void DiscardedMethod(ref bool value)
			{
				value = false;
			}

			// Token: 0x06000147 RID: 327 RVA: 0x00007B2C File Offset: 0x00005D2C
			private static bool IsCompiledByBurst(Delegate del)
			{
				return BurstCompilerService.GetAsyncCompiledAsyncDelegateMethod(BurstCompilerService.CompileAsyncDelegateMethod(del, string.Empty)) != null;
			}

			// Token: 0x04000246 RID: 582
			private static readonly BurstCompiler.BurstCompilerHelper.IsBurstEnabledDelegate IsBurstEnabledImpl = new BurstCompiler.BurstCompilerHelper.IsBurstEnabledDelegate(BurstCompiler.BurstCompilerHelper.IsBurstEnabled);

			// Token: 0x04000247 RID: 583
			public static readonly bool IsBurstGenerated = BurstCompiler.BurstCompilerHelper.IsCompiledByBurst(BurstCompiler.BurstCompilerHelper.IsBurstEnabledImpl);

			// Token: 0x02000056 RID: 86
			// (Invoke) Token: 0x06000E35 RID: 3637
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			private delegate bool IsBurstEnabledDelegate();
		}

		// Token: 0x0200002E RID: 46
		private class FakeDelegate
		{
			// Token: 0x06000149 RID: 329 RVA: 0x00007B67 File Offset: 0x00005D67
			public FakeDelegate(MethodInfo method)
			{
				this.Method = method;
			}

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x0600014A RID: 330 RVA: 0x00007B76 File Offset: 0x00005D76
			[Preserve]
			public MethodInfo Method { get; }
		}
	}
}
