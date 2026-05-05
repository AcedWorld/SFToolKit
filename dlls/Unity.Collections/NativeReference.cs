using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Collections
{
	// Token: 0x020000AF RID: 175
	[NativeContainer]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct NativeReference<[IsUnmanaged] T> : INativeDisposable, IDisposable, IEquatable<NativeReference<T>> where T : struct, ValueType
	{
		// Token: 0x0600070A RID: 1802 RVA: 0x00016E7E File Offset: 0x0001507E
		public NativeReference(AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
		{
			NativeReference<T>.Allocate(allocator, out this);
			if (options == NativeArrayOptions.ClearMemory)
			{
				UnsafeUtility.MemClear(this.m_Data, (long)UnsafeUtility.SizeOf<T>());
			}
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00016E9C File Offset: 0x0001509C
		public unsafe NativeReference(T value, AllocatorManager.AllocatorHandle allocator)
		{
			NativeReference<T>.Allocate(allocator, out this);
			*(T*)this.m_Data = value;
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00016EB1 File Offset: 0x000150B1
		private static void Allocate(AllocatorManager.AllocatorHandle allocator, out NativeReference<T> reference)
		{
			reference = default(NativeReference<T>);
			reference.m_Data = Memory.Unmanaged.Allocate((long)UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), allocator);
			reference.m_AllocatorLabel = allocator;
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00016ED8 File Offset: 0x000150D8
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00016EE5 File Offset: 0x000150E5
		public unsafe T Value
		{
			get
			{
				return *(T*)this.m_Data;
			}
			set
			{
				*(T*)this.m_Data = value;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00016EF3 File Offset: 0x000150F3
		public bool IsCreated
		{
			get
			{
				return this.m_Data != null;
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00016F02 File Offset: 0x00015102
		public void Dispose()
		{
			if (CollectionHelper.ShouldDeallocate(this.m_AllocatorLabel))
			{
				Memory.Unmanaged.Free(this.m_Data, this.m_AllocatorLabel);
				this.m_AllocatorLabel = Allocator.Invalid;
			}
			this.m_Data = null;
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00016F38 File Offset: 0x00015138
		[NotBurstCompatible]
		public JobHandle Dispose(JobHandle inputDeps)
		{
			if (CollectionHelper.ShouldDeallocate(this.m_AllocatorLabel))
			{
				JobHandle result = new NativeReferenceDisposeJob
				{
					Data = new NativeReferenceDispose
					{
						m_Data = this.m_Data,
						m_AllocatorLabel = this.m_AllocatorLabel
					}
				}.Schedule(inputDeps);
				this.m_Data = null;
				this.m_AllocatorLabel = Allocator.Invalid;
				return result;
			}
			this.m_Data = null;
			return inputDeps;
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00016FA9 File Offset: 0x000151A9
		public void CopyFrom(NativeReference<T> reference)
		{
			NativeReference<T>.Copy(this, reference);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00016FB7 File Offset: 0x000151B7
		public void CopyTo(NativeReference<T> reference)
		{
			NativeReference<T>.Copy(reference, this);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00016FC8 File Offset: 0x000151C8
		[NotBurstCompatible]
		public bool Equals(NativeReference<T> other)
		{
			T value = this.Value;
			return value.Equals(other.Value);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00016FF5 File Offset: 0x000151F5
		[NotBurstCompatible]
		public override bool Equals(object obj)
		{
			return obj != null && obj is NativeReference<T> && this.Equals((NativeReference<T>)obj);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00017014 File Offset: 0x00015214
		public override int GetHashCode()
		{
			T value = this.Value;
			return value.GetHashCode();
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00017035 File Offset: 0x00015235
		public static bool operator ==(NativeReference<T> left, NativeReference<T> right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0001703F File Offset: 0x0001523F
		public static bool operator !=(NativeReference<T> left, NativeReference<T> right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0001704C File Offset: 0x0001524C
		public static void Copy(NativeReference<T> dst, NativeReference<T> src)
		{
			UnsafeUtility.MemCpy(dst.m_Data, src.m_Data, (long)UnsafeUtility.SizeOf<T>());
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00017065 File Offset: 0x00015265
		public NativeReference<T>.ReadOnly AsReadOnly()
		{
			return new NativeReference<T>.ReadOnly(this.m_Data);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00017072 File Offset: 0x00015272
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNotDisposed()
		{
			if (this.m_Data == null)
			{
				throw new ObjectDisposedException("The NativeReference is already disposed.");
			}
		}

		// Token: 0x0400029C RID: 668
		[NativeDisableUnsafePtrRestriction]
		internal unsafe void* m_Data;

		// Token: 0x0400029D RID: 669
		internal AllocatorManager.AllocatorHandle m_AllocatorLabel;

		// Token: 0x020000B0 RID: 176
		[NativeContainer]
		[NativeContainerIsReadOnly]
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(int)
		})]
		public struct ReadOnly
		{
			// Token: 0x0600071C RID: 1820 RVA: 0x00017089 File Offset: 0x00015289
			internal unsafe ReadOnly(void* data)
			{
				this.m_Data = data;
			}

			// Token: 0x170000C8 RID: 200
			// (get) Token: 0x0600071D RID: 1821 RVA: 0x00017092 File Offset: 0x00015292
			public unsafe T Value
			{
				get
				{
					return *(T*)this.m_Data;
				}
			}

			// Token: 0x0400029E RID: 670
			[NativeDisableUnsafePtrRestriction]
			private unsafe readonly void* m_Data;
		}
	}
}
