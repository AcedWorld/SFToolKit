using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001DA RID: 474
	[UsedByNativeCode]
	[NativeHeader("Runtime/Export/Hashing/Hash128.bindings.h")]
	[NativeHeader("Runtime/Utilities/Hash128.h")]
	[Serializable]
	public struct Hash128 : IComparable, IComparable<Hash128>, IEquatable<Hash128>
	{
		// Token: 0x0600146B RID: 5227 RVA: 0x0001CC89 File Offset: 0x0001AE89
		public Hash128(uint u32_0, uint u32_1, uint u32_2, uint u32_3)
		{
			this.u64_0 = ((ulong)u32_1 << 32 | (ulong)u32_0);
			this.u64_1 = ((ulong)u32_3 << 32 | (ulong)u32_2);
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x0001CCA9 File Offset: 0x0001AEA9
		public Hash128(ulong u64_0, ulong u64_1)
		{
			this.u64_0 = u64_0;
			this.u64_1 = u64_1;
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x0600146D RID: 5229 RVA: 0x0001CCBA File Offset: 0x0001AEBA
		public bool isValid
		{
			get
			{
				return this.u64_0 != 0UL || this.u64_1 > 0UL;
			}
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x0001CCD4 File Offset: 0x0001AED4
		public int CompareTo(Hash128 rhs)
		{
			bool flag = this < rhs;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = this > rhs;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x0001CD10 File Offset: 0x0001AF10
		public override string ToString()
		{
			return Hash128.Hash128ToStringImpl(this);
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x0001CD30 File Offset: 0x0001AF30
		[FreeFunction("StringToHash128", IsThreadSafe = true)]
		public static Hash128 Parse(string hashString)
		{
			Hash128 result;
			Hash128.Parse_Injected(hashString, out result);
			return result;
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x0001CD46 File Offset: 0x0001AF46
		[FreeFunction("Hash128ToString", IsThreadSafe = true)]
		private static string Hash128ToStringImpl(Hash128 hash)
		{
			return Hash128.Hash128ToStringImpl_Injected(ref hash);
		}

		// Token: 0x06001472 RID: 5234
		[FreeFunction("ComputeHash128FromScriptString", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ComputeFromString(string data, ref Hash128 hash);

		// Token: 0x06001473 RID: 5235
		[FreeFunction("ComputeHash128FromScriptPointer", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ComputeFromPtr(IntPtr data, int start, int count, int elemSize, ref Hash128 hash);

		// Token: 0x06001474 RID: 5236
		[FreeFunction("ComputeHash128FromScriptArray", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ComputeFromArray(Array data, int start, int count, int elemSize, ref Hash128 hash);

		// Token: 0x06001475 RID: 5237 RVA: 0x0001CD50 File Offset: 0x0001AF50
		public static Hash128 Compute(string data)
		{
			Hash128 result = default(Hash128);
			Hash128.ComputeFromString(data, ref result);
			return result;
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x0001CD74 File Offset: 0x0001AF74
		public static Hash128 Compute<T>(NativeArray<T> data) where T : struct
		{
			Hash128 result = default(Hash128);
			Hash128.ComputeFromPtr((IntPtr)data.GetUnsafeReadOnlyPtr<T>(), 0, data.Length, UnsafeUtility.SizeOf<T>(), ref result);
			return result;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x0001CDB0 File Offset: 0x0001AFB0
		public static Hash128 Compute<T>(NativeArray<T> data, int start, int count) where T : struct
		{
			bool flag = start < 0 || count < 0 || start + count > data.Length;
			if (flag)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (start:{0} count:{1})", start, count));
			}
			Hash128 result = default(Hash128);
			Hash128.ComputeFromPtr((IntPtr)data.GetUnsafeReadOnlyPtr<T>(), start, count, UnsafeUtility.SizeOf<T>(), ref result);
			return result;
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x0001CE1C File Offset: 0x0001B01C
		public static Hash128 Compute<T>(T[] data) where T : struct
		{
			bool flag = !UnsafeUtility.IsArrayBlittable(data);
			if (flag)
			{
				throw new ArgumentException("Array passed to Compute must be blittable.\n" + UnsafeUtility.GetReasonForArrayNonBlittable(data));
			}
			Hash128 result = default(Hash128);
			Hash128.ComputeFromArray(data, 0, data.Length, UnsafeUtility.SizeOf<T>(), ref result);
			return result;
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x0001CE6C File Offset: 0x0001B06C
		public static Hash128 Compute<T>(T[] data, int start, int count) where T : struct
		{
			bool flag = !UnsafeUtility.IsArrayBlittable(data);
			if (flag)
			{
				throw new ArgumentException("Array passed to Compute must be blittable.\n" + UnsafeUtility.GetReasonForArrayNonBlittable(data));
			}
			bool flag2 = start < 0 || count < 0 || start + count > data.Length;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (start:{0} count:{1})", start, count));
			}
			Hash128 result = default(Hash128);
			Hash128.ComputeFromArray(data, start, count, UnsafeUtility.SizeOf<T>(), ref result);
			return result;
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x0001CEF0 File Offset: 0x0001B0F0
		public static Hash128 Compute<T>(List<T> data) where T : struct
		{
			bool flag = !UnsafeUtility.IsGenericListBlittable<T>();
			if (flag)
			{
				throw new ArgumentException(string.Format("List<{0}> passed to {1} must be blittable.\n{2}", typeof(T), "Compute", UnsafeUtility.GetReasonForGenericListNonBlittable<T>()));
			}
			Hash128 result = default(Hash128);
			Hash128.ComputeFromArray(NoAllocHelpers.ExtractArrayFromList(data), 0, data.Count, UnsafeUtility.SizeOf<T>(), ref result);
			return result;
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x0001CF58 File Offset: 0x0001B158
		public static Hash128 Compute<T>(List<T> data, int start, int count) where T : struct
		{
			bool flag = !UnsafeUtility.IsGenericListBlittable<T>();
			if (flag)
			{
				throw new ArgumentException(string.Format("List<{0}> passed to {1} must be blittable.\n{2}", typeof(T), "Compute", UnsafeUtility.GetReasonForGenericListNonBlittable<T>()));
			}
			bool flag2 = start < 0 || count < 0 || start + count > data.Count;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (start:{0} count:{1})", start, count));
			}
			Hash128 result = default(Hash128);
			Hash128.ComputeFromArray(NoAllocHelpers.ExtractArrayFromList(data), start, count, UnsafeUtility.SizeOf<T>(), ref result);
			return result;
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x0001CFF0 File Offset: 0x0001B1F0
		public unsafe static Hash128 Compute<[IsUnmanaged] T>(ref T val) where T : struct, ValueType
		{
			fixed (T* ptr = &val)
			{
				void* value = (void*)ptr;
				Hash128 result = default(Hash128);
				Hash128.ComputeFromPtr((IntPtr)value, 0, 1, UnsafeUtility.SizeOf<T>(), ref result);
				return result;
			}
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x0001D028 File Offset: 0x0001B228
		public static Hash128 Compute(int val)
		{
			Hash128 result = default(Hash128);
			result.Append(val);
			return result;
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x0001D04C File Offset: 0x0001B24C
		public static Hash128 Compute(float val)
		{
			Hash128 result = default(Hash128);
			result.Append(val);
			return result;
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x0001D070 File Offset: 0x0001B270
		public unsafe static Hash128 Compute(void* data, ulong size)
		{
			Hash128 result = default(Hash128);
			Hash128.ComputeFromPtr(new IntPtr(data), 0, (int)size, 1, ref result);
			return result;
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x0001D09D File Offset: 0x0001B29D
		public void Append(string data)
		{
			Hash128.ComputeFromString(data, ref this);
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x0001D0A8 File Offset: 0x0001B2A8
		public void Append<T>(NativeArray<T> data) where T : struct
		{
			Hash128.ComputeFromPtr((IntPtr)data.GetUnsafeReadOnlyPtr<T>(), 0, data.Length, UnsafeUtility.SizeOf<T>(), ref this);
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x0001D0CC File Offset: 0x0001B2CC
		public void Append<T>(NativeArray<T> data, int start, int count) where T : struct
		{
			bool flag = start < 0 || count < 0 || start + count > data.Length;
			if (flag)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (start:{0} count:{1})", start, count));
			}
			Hash128.ComputeFromPtr((IntPtr)data.GetUnsafeReadOnlyPtr<T>(), start, count, UnsafeUtility.SizeOf<T>(), ref this);
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x0001D12C File Offset: 0x0001B32C
		public void Append<T>(T[] data) where T : struct
		{
			bool flag = !UnsafeUtility.IsArrayBlittable(data);
			if (flag)
			{
				throw new ArgumentException("Array passed to Append must be blittable.\n" + UnsafeUtility.GetReasonForArrayNonBlittable(data));
			}
			Hash128.ComputeFromArray(data, 0, data.Length, UnsafeUtility.SizeOf<T>(), ref this);
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x0001D170 File Offset: 0x0001B370
		public void Append<T>(T[] data, int start, int count) where T : struct
		{
			bool flag = !UnsafeUtility.IsArrayBlittable(data);
			if (flag)
			{
				throw new ArgumentException("Array passed to Append must be blittable.\n" + UnsafeUtility.GetReasonForArrayNonBlittable(data));
			}
			bool flag2 = start < 0 || count < 0 || start + count > data.Length;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (start:{0} count:{1})", start, count));
			}
			Hash128.ComputeFromArray(data, start, count, UnsafeUtility.SizeOf<T>(), ref this);
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		public void Append<T>(List<T> data) where T : struct
		{
			bool flag = !UnsafeUtility.IsGenericListBlittable<T>();
			if (flag)
			{
				throw new ArgumentException(string.Format("List<{0}> passed to {1} must be blittable.\n{2}", typeof(T), "Append", UnsafeUtility.GetReasonForGenericListNonBlittable<T>()));
			}
			Hash128.ComputeFromArray(NoAllocHelpers.ExtractArrayFromList(data), 0, data.Count, UnsafeUtility.SizeOf<T>(), ref this);
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x0001D23C File Offset: 0x0001B43C
		public void Append<T>(List<T> data, int start, int count) where T : struct
		{
			bool flag = !UnsafeUtility.IsGenericListBlittable<T>();
			if (flag)
			{
				throw new ArgumentException(string.Format("List<{0}> passed to {1} must be blittable.\n{2}", typeof(T), "Append", UnsafeUtility.GetReasonForGenericListNonBlittable<T>()));
			}
			bool flag2 = start < 0 || count < 0 || start + count > data.Count;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException(string.Format("Bad start/count arguments (start:{0} count:{1})", start, count));
			}
			Hash128.ComputeFromArray(NoAllocHelpers.ExtractArrayFromList(data), start, count, UnsafeUtility.SizeOf<T>(), ref this);
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x0001D2C4 File Offset: 0x0001B4C4
		public unsafe void Append<[IsUnmanaged] T>(ref T val) where T : struct, ValueType
		{
			fixed (T* ptr = &val)
			{
				void* value = (void*)ptr;
				Hash128.ComputeFromPtr((IntPtr)value, 0, 1, UnsafeUtility.SizeOf<T>(), ref this);
			}
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x0001D2F0 File Offset: 0x0001B4F0
		public void Append(int val)
		{
			this.ShortHash4((uint)val);
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x0001D2FB File Offset: 0x0001B4FB
		public unsafe void Append(float val)
		{
			this.ShortHash4(*(uint*)(&val));
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x0001D309 File Offset: 0x0001B509
		public unsafe void Append(void* data, ulong size)
		{
			Hash128.ComputeFromPtr(new IntPtr(data), 0, (int)size, 1, ref this);
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0001D320 File Offset: 0x0001B520
		public override bool Equals(object obj)
		{
			return obj is Hash128 && this == (Hash128)obj;
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x0001D350 File Offset: 0x0001B550
		public bool Equals(Hash128 obj)
		{
			return this == obj;
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0001D370 File Offset: 0x0001B570
		public override int GetHashCode()
		{
			return this.u64_0.GetHashCode() ^ this.u64_1.GetHashCode();
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x0001D39C File Offset: 0x0001B59C
		public int CompareTo(object obj)
		{
			bool flag = obj == null || !(obj is Hash128);
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				Hash128 rhs = (Hash128)obj;
				result = this.CompareTo(rhs);
			}
			return result;
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x0001D3D8 File Offset: 0x0001B5D8
		public static bool operator ==(Hash128 hash1, Hash128 hash2)
		{
			return hash1.u64_0 == hash2.u64_0 && hash1.u64_1 == hash2.u64_1;
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x0001D40C File Offset: 0x0001B60C
		public static bool operator !=(Hash128 hash1, Hash128 hash2)
		{
			return !(hash1 == hash2);
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x0001D428 File Offset: 0x0001B628
		public static bool operator <(Hash128 x, Hash128 y)
		{
			bool flag = x.u64_0 != y.u64_0;
			bool result;
			if (flag)
			{
				result = (x.u64_0 < y.u64_0);
			}
			else
			{
				result = (x.u64_1 < y.u64_1);
			}
			return result;
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x0001D470 File Offset: 0x0001B670
		public static bool operator >(Hash128 x, Hash128 y)
		{
			bool flag = x < y;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = x == y;
				result = !flag2;
			}
			return result;
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x0001D4A4 File Offset: 0x0001B6A4
		private void ShortHash4(uint data)
		{
			ulong num = this.u64_0;
			ulong num2 = this.u64_1;
			ulong num3 = 16045690984833335023UL;
			ulong num4 = 16045690984833335023UL;
			num4 += 288230376151711744UL;
			num3 += (ulong)data;
			Hash128.ShortEnd(ref num, ref num2, ref num3, ref num4);
			this.u64_0 = num;
			this.u64_1 = num2;
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0001D504 File Offset: 0x0001B704
		private static void ShortEnd(ref ulong h0, ref ulong h1, ref ulong h2, ref ulong h3)
		{
			h3 ^= h2;
			Hash128.Rot64(ref h2, 15);
			h3 += h2;
			h0 ^= h3;
			Hash128.Rot64(ref h3, 52);
			h0 += h3;
			h1 ^= h0;
			Hash128.Rot64(ref h0, 26);
			h1 += h0;
			h2 ^= h1;
			Hash128.Rot64(ref h1, 51);
			h2 += h1;
			h3 ^= h2;
			Hash128.Rot64(ref h2, 28);
			h3 += h2;
			h0 ^= h3;
			Hash128.Rot64(ref h3, 9);
			h0 += h3;
			h1 ^= h0;
			Hash128.Rot64(ref h0, 47);
			h1 += h0;
			h2 ^= h1;
			Hash128.Rot64(ref h1, 54);
			h2 += h1;
			h3 ^= h2;
			Hash128.Rot64(ref h2, 32);
			h3 += h2;
			h0 ^= h3;
			Hash128.Rot64(ref h3, 25);
			h0 += h3;
			h1 ^= h0;
			Hash128.Rot64(ref h0, 63);
			h1 += h0;
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x0001D60F File Offset: 0x0001B80F
		private static void Rot64(ref ulong x, int k)
		{
			x = (x << k | x >> 64 - k);
		}

		// Token: 0x06001496 RID: 5270
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Parse_Injected(string hashString, out Hash128 ret);

		// Token: 0x06001497 RID: 5271
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string Hash128ToStringImpl_Injected(ref Hash128 hash);

		// Token: 0x0400066F RID: 1647
		internal ulong u64_0;

		// Token: 0x04000670 RID: 1648
		internal ulong u64_1;

		// Token: 0x04000671 RID: 1649
		private const ulong kConst = 16045690984833335023UL;
	}
}
