using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000136 RID: 310
	public interface ISerializationDependency : ISerializationCallbackReceiver
	{
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000874 RID: 2164
		// (set) Token: 0x06000873 RID: 2163
		bool IsDeserialized { get; set; }
	}
}
