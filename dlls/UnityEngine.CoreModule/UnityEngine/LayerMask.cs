using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200024E RID: 590
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	[NativeHeader("Runtime/BaseClasses/TagManager.h")]
	[NativeHeader("Runtime/BaseClasses/BitField.h")]
	[NativeClass("BitField", "struct BitField;")]
	public struct LayerMask
	{
		// Token: 0x06001926 RID: 6438 RVA: 0x0002A070 File Offset: 0x00028270
		public static implicit operator int(LayerMask mask)
		{
			return mask.m_Mask;
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x0002A088 File Offset: 0x00028288
		public static implicit operator LayerMask(int intVal)
		{
			LayerMask result;
			result.m_Mask = intVal;
			return result;
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06001928 RID: 6440 RVA: 0x0002A0A4 File Offset: 0x000282A4
		// (set) Token: 0x06001929 RID: 6441 RVA: 0x0002A0BC File Offset: 0x000282BC
		public int value
		{
			get
			{
				return this.m_Mask;
			}
			set
			{
				this.m_Mask = value;
			}
		}

		// Token: 0x0600192A RID: 6442
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		[NativeMethod("LayerToString")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string LayerToName(int layer);

		// Token: 0x0600192B RID: 6443
		[NativeMethod("StringToLayer")]
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int NameToLayer(string layerName);

		// Token: 0x0600192C RID: 6444 RVA: 0x0002A0C8 File Offset: 0x000282C8
		public static int GetMask(params string[] layerNames)
		{
			bool flag = layerNames == null;
			if (flag)
			{
				throw new ArgumentNullException("layerNames");
			}
			int num = 0;
			foreach (string layerName in layerNames)
			{
				int num2 = LayerMask.NameToLayer(layerName);
				bool flag2 = num2 != -1;
				if (flag2)
				{
					num |= 1 << num2;
				}
			}
			return num;
		}

		// Token: 0x040008CA RID: 2250
		[NativeName("m_Bits")]
		private int m_Mask;
	}
}
