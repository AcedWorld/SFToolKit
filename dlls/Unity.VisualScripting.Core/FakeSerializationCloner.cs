using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000009 RID: 9
	public sealed class FakeSerializationCloner : ReflectedCloner
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000023CD File Offset: 0x000005CD
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000023D5 File Offset: 0x000005D5
		public fsConfig config { get; set; } = new fsConfig();

		// Token: 0x0600001F RID: 31 RVA: 0x000023DE File Offset: 0x000005DE
		public override void BeforeClone(Type type, object original)
		{
			ISerializationCallbackReceiver serializationCallbackReceiver = original as ISerializationCallbackReceiver;
			if (serializationCallbackReceiver == null)
			{
				return;
			}
			serializationCallbackReceiver.OnBeforeSerialize();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000023F0 File Offset: 0x000005F0
		public override void AfterClone(Type type, object clone)
		{
			ISerializationCallbackReceiver serializationCallbackReceiver = clone as ISerializationCallbackReceiver;
			if (serializationCallbackReceiver == null)
			{
				return;
			}
			serializationCallbackReceiver.OnAfterDeserialize();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002402 File Offset: 0x00000602
		protected override IEnumerable<MemberInfo> GetMembers(Type type)
		{
			return from p in fsMetaType.Get(this.config, type).Properties
			select p._memberInfo;
		}
	}
}
