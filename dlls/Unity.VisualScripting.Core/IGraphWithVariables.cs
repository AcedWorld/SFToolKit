using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200016B RID: 363
	public interface IGraphWithVariables : IGraph, IDisposable, IPrewarmable, IAotStubbable, ISerializationDepender, ISerializationCallbackReceiver
	{
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060009AD RID: 2477
		VariableDeclarations variables { get; }

		// Token: 0x060009AE RID: 2478
		IEnumerable<string> GetDynamicVariableNames(VariableKind kind, GraphReference reference);
	}
}
