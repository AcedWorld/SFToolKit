using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Serialization
{
	// Token: 0x0200030C RID: 780
	[NativeHeader("Runtime/Serialize/ManagedReferenceUtility.h")]
	public sealed class ManagedReferenceUtility
	{
		// Token: 0x0600200A RID: 8202
		[NativeMethod("SetManagedReferenceIdForObject")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetManagedReferenceIdForObjectInternal(Object obj, object scriptObj, long refId);

		// Token: 0x0600200B RID: 8203 RVA: 0x00035504 File Offset: 0x00033704
		public static bool SetManagedReferenceIdForObject(Object obj, object scriptObj, long refId)
		{
			bool flag = scriptObj == null;
			bool result;
			if (flag)
			{
				result = (refId == -2L);
			}
			else
			{
				Type type = scriptObj.GetType();
				bool flag2 = type == typeof(Object) || type.IsSubclassOf(typeof(Object));
				if (flag2)
				{
					throw new InvalidOperationException("Cannot assign an object deriving from UnityEngine.Object to a managed reference. This is not supported.");
				}
				result = ManagedReferenceUtility.SetManagedReferenceIdForObjectInternal(obj, scriptObj, refId);
			}
			return result;
		}

		// Token: 0x0600200C RID: 8204
		[NativeMethod("GetManagedReferenceIdForObject")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern long GetManagedReferenceIdForObjectInternal(Object obj, object scriptObj);

		// Token: 0x0600200D RID: 8205 RVA: 0x0003556C File Offset: 0x0003376C
		public static long GetManagedReferenceIdForObject(Object obj, object scriptObj)
		{
			return ManagedReferenceUtility.GetManagedReferenceIdForObjectInternal(obj, scriptObj);
		}

		// Token: 0x0600200E RID: 8206
		[NativeMethod("GetManagedReference")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object GetManagedReferenceInternal(Object obj, long id);

		// Token: 0x0600200F RID: 8207 RVA: 0x00035588 File Offset: 0x00033788
		public static object GetManagedReference(Object obj, long id)
		{
			return ManagedReferenceUtility.GetManagedReferenceInternal(obj, id);
		}

		// Token: 0x06002010 RID: 8208
		[NativeMethod("GetManagedReferenceIds")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern long[] GetManagedReferenceIdsForObjectInternal(Object obj);

		// Token: 0x06002011 RID: 8209 RVA: 0x000355A4 File Offset: 0x000337A4
		public static long[] GetManagedReferenceIds(Object obj)
		{
			return ManagedReferenceUtility.GetManagedReferenceIdsForObjectInternal(obj);
		}

		// Token: 0x04000A80 RID: 2688
		public const long RefIdUnknown = -1L;

		// Token: 0x04000A81 RID: 2689
		public const long RefIdNull = -2L;
	}
}
