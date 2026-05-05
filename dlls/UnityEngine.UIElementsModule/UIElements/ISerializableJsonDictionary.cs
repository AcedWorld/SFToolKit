using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200026E RID: 622
	internal interface ISerializableJsonDictionary
	{
		// Token: 0x060011AC RID: 4524
		void Set<T>(string key, T value) where T : class;

		// Token: 0x060011AD RID: 4525
		T Get<T>(string key) where T : class;

		// Token: 0x060011AE RID: 4526
		T GetScriptable<T>(string key) where T : ScriptableObject;

		// Token: 0x060011AF RID: 4527
		void Overwrite(object obj, string key);

		// Token: 0x060011B0 RID: 4528
		bool ContainsKey(string key);

		// Token: 0x060011B1 RID: 4529
		void OnBeforeSerialize();

		// Token: 0x060011B2 RID: 4530
		void OnAfterDeserialize();
	}
}
