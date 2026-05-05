using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002FF RID: 767
	internal struct StyleDataRef<T> : IEquatable<StyleDataRef<T>> where T : struct, IEquatable<T>, IStyleDataGroup<T>
	{
		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06001A31 RID: 6705 RVA: 0x000689C6 File Offset: 0x00066BC6
		public int refCount
		{
			get
			{
				StyleDataRef<T>.RefCounted @ref = this.m_Ref;
				return (@ref != null) ? @ref.refCount : 0;
			}
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06001A32 RID: 6706 RVA: 0x000689DA File Offset: 0x00066BDA
		public uint id
		{
			get
			{
				StyleDataRef<T>.RefCounted @ref = this.m_Ref;
				return (@ref != null) ? @ref.id : 0U;
			}
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x000689F0 File Offset: 0x00066BF0
		public StyleDataRef<T> Acquire()
		{
			this.m_Ref.Acquire();
			return this;
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x00068A14 File Offset: 0x00066C14
		public void Release()
		{
			this.m_Ref.Release();
			this.m_Ref = null;
		}

		// Token: 0x06001A35 RID: 6709 RVA: 0x00068A2C File Offset: 0x00066C2C
		public void CopyFrom(StyleDataRef<T> other)
		{
			bool flag = this.m_Ref.refCount == 1;
			if (flag)
			{
				this.m_Ref.value.CopyFrom(ref other.m_Ref.value);
			}
			else
			{
				this.m_Ref.Release();
				this.m_Ref = other.m_Ref;
				this.m_Ref.Acquire();
			}
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x00068A98 File Offset: 0x00066C98
		public ref readonly T Read()
		{
			return ref this.m_Ref.value;
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x00068AA8 File Offset: 0x00066CA8
		public ref T Write()
		{
			bool flag = this.m_Ref.refCount == 1;
			T result;
			if (flag)
			{
				result = ref this.m_Ref.value;
			}
			else
			{
				StyleDataRef<T>.RefCounted @ref = this.m_Ref;
				this.m_Ref = this.m_Ref.Copy();
				@ref.Release();
				result = ref this.m_Ref.value;
			}
			return ref result;
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x00068B04 File Offset: 0x00066D04
		public static StyleDataRef<T> Create()
		{
			return new StyleDataRef<T>
			{
				m_Ref = new StyleDataRef<T>.RefCounted()
			};
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x00068B2C File Offset: 0x00066D2C
		public override int GetHashCode()
		{
			return (this.m_Ref != null) ? this.m_Ref.value.GetHashCode() : 0;
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x00068B60 File Offset: 0x00066D60
		public static bool operator ==(StyleDataRef<T> lhs, StyleDataRef<T> rhs)
		{
			return lhs.m_Ref == rhs.m_Ref || lhs.m_Ref.value.Equals(rhs.m_Ref.value);
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x00068BA4 File Offset: 0x00066DA4
		public static bool operator !=(StyleDataRef<T> lhs, StyleDataRef<T> rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x00068BC0 File Offset: 0x00066DC0
		public bool Equals(StyleDataRef<T> other)
		{
			return other == this;
		}

		// Token: 0x06001A3D RID: 6717 RVA: 0x00068BE0 File Offset: 0x00066DE0
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleDataRef<T>)
			{
				StyleDataRef<T> other = (StyleDataRef<T>)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A3E RID: 6718 RVA: 0x00068C0C File Offset: 0x00066E0C
		public bool ReferenceEquals(StyleDataRef<T> other)
		{
			return this.m_Ref == other.m_Ref;
		}

		// Token: 0x04000ADF RID: 2783
		private StyleDataRef<T>.RefCounted m_Ref;

		// Token: 0x02000300 RID: 768
		private class RefCounted
		{
			// Token: 0x17000666 RID: 1638
			// (get) Token: 0x06001A3F RID: 6719 RVA: 0x00068C2C File Offset: 0x00066E2C
			public int refCount
			{
				get
				{
					return this.m_RefCount;
				}
			}

			// Token: 0x17000667 RID: 1639
			// (get) Token: 0x06001A40 RID: 6720 RVA: 0x00068C34 File Offset: 0x00066E34
			public uint id
			{
				get
				{
					return this.m_Id;
				}
			}

			// Token: 0x06001A41 RID: 6721 RVA: 0x00068C3C File Offset: 0x00066E3C
			public RefCounted()
			{
				this.m_RefCount = 1;
				this.m_Id = (StyleDataRef<T>.RefCounted.m_NextId += 1U);
			}

			// Token: 0x06001A42 RID: 6722 RVA: 0x00068C60 File Offset: 0x00066E60
			public void Acquire()
			{
				this.m_RefCount++;
			}

			// Token: 0x06001A43 RID: 6723 RVA: 0x00068C70 File Offset: 0x00066E70
			public void Release()
			{
				this.m_RefCount--;
			}

			// Token: 0x06001A44 RID: 6724 RVA: 0x00068C84 File Offset: 0x00066E84
			public StyleDataRef<T>.RefCounted Copy()
			{
				return new StyleDataRef<T>.RefCounted
				{
					value = this.value.Copy()
				};
			}

			// Token: 0x04000AE0 RID: 2784
			private static uint m_NextId = 1U;

			// Token: 0x04000AE1 RID: 2785
			private int m_RefCount;

			// Token: 0x04000AE2 RID: 2786
			private readonly uint m_Id;

			// Token: 0x04000AE3 RID: 2787
			public T value;
		}
	}
}
