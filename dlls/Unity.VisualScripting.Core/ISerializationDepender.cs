using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000137 RID: 311
	public interface ISerializationDepender : ISerializationCallbackReceiver
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000875 RID: 2165
		IEnumerable<ISerializationDependency> deserializationDependencies { get; }

		// Token: 0x06000876 RID: 2166
		void OnAfterDependenciesDeserialized();
	}
}
