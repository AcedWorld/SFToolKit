using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Core.Telemetry.Internal;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000052 RID: 82
	internal class CoreDiagnostics
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00003AC1 File Offset: 0x00001CC1
		// (set) Token: 0x0600015E RID: 350 RVA: 0x00003AC8 File Offset: 0x00001CC8
		public static CoreDiagnostics Instance { get; internal set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00003AD0 File Offset: 0x00001CD0
		public IDictionary<string, string> CoreTags { get; } = new Dictionary<string, string>();

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00003AD8 File Offset: 0x00001CD8
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00003AE0 File Offset: 0x00001CE0
		internal IDiagnosticsComponentProvider DiagnosticsComponentProvider { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00003AE9 File Offset: 0x00001CE9
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00003AF1 File Offset: 0x00001CF1
		internal IDiagnostics Diagnostics { get; set; }

		// Token: 0x06000164 RID: 356 RVA: 0x00003AFA File Offset: 0x00001CFA
		public void SetProjectConfiguration(string serializedProjectConfig)
		{
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00003AFC File Offset: 0x00001CFC
		public void SendCircularDependencyDiagnostics(Exception exception)
		{
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00003AFE File Offset: 0x00001CFE
		public void SendCorePackageInitDiagnostics(Exception exception)
		{
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00003B00 File Offset: 0x00001D00
		public void SendOperateServicesInitDiagnostics(Exception exception)
		{
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00003B04 File Offset: 0x00001D04
		internal Task SendCoreDiagnosticsAsync(string diagnosticName, Exception exception)
		{
			CoreDiagnostics.<SendCoreDiagnosticsAsync>d__24 <SendCoreDiagnosticsAsync>d__;
			<SendCoreDiagnosticsAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SendCoreDiagnosticsAsync>d__.<>1__state = -1;
			<SendCoreDiagnosticsAsync>d__.<>t__builder.Start<CoreDiagnostics.<SendCoreDiagnosticsAsync>d__24>(ref <SendCoreDiagnosticsAsync>d__);
			return <SendCoreDiagnosticsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00003B3F File Offset: 0x00001D3F
		private static void OnSendFailed(Task failedSendTask)
		{
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00003B44 File Offset: 0x00001D44
		internal Task<IDiagnostics> GetOrCreateDiagnosticsAsync()
		{
			CoreDiagnostics.<GetOrCreateDiagnosticsAsync>d__26 <GetOrCreateDiagnosticsAsync>d__;
			<GetOrCreateDiagnosticsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<IDiagnostics>.Create();
			<GetOrCreateDiagnosticsAsync>d__.<>4__this = this;
			<GetOrCreateDiagnosticsAsync>d__.<>1__state = -1;
			<GetOrCreateDiagnosticsAsync>d__.<>t__builder.Start<CoreDiagnostics.<GetOrCreateDiagnosticsAsync>d__26>(ref <GetOrCreateDiagnosticsAsync>d__);
			return <GetOrCreateDiagnosticsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0400005B RID: 91
		internal const string CorePackageName = "com.unity.services.core";

		// Token: 0x0400005C RID: 92
		internal const string CircularDependencyDiagnosticName = "circular_dependency";

		// Token: 0x0400005D RID: 93
		internal const string CorePackageInitDiagnosticName = "core_package_init";

		// Token: 0x0400005E RID: 94
		internal const string OperateServicesInitDiagnosticName = "operate_services_init";

		// Token: 0x0400005F RID: 95
		internal const string ProjectConfigTagName = "project_config";
	}
}
