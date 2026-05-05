using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000056 RID: 86
	[UnitCategory("Events/Application")]
	public sealed class OnApplicationResume : GlobalEventUnit<EmptyEventArgs>
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00008901 File Offset: 0x00006B01
		protected override string hookName
		{
			get
			{
				return "OnApplicationResume";
			}
		}
	}
}
