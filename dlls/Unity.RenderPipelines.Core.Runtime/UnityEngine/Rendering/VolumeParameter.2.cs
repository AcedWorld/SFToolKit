using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
	// Token: 0x020000EF RID: 239
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class VolumeParameter<T> : VolumeParameter, IEquatable<VolumeParameter<T>>
	{
		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x000264E9 File Offset: 0x000246E9
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x000264F1 File Offset: 0x000246F1
		public virtual T value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
			}
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x000264FC File Offset: 0x000246FC
		public VolumeParameter() : this(default(T), false)
		{
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00026519 File Offset: 0x00024719
		protected VolumeParameter(T value, bool overrideState)
		{
			this.m_Value = value;
			this.overrideState = overrideState;
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0002652F File Offset: 0x0002472F
		internal override void Interp(VolumeParameter from, VolumeParameter to, float t)
		{
			this.Interp((from as VolumeParameter<T>).value, (to as VolumeParameter<T>).value, t);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0002654E File Offset: 0x0002474E
		public virtual void Interp(T from, T to, float t)
		{
			this.m_Value = ((t > 0f) ? to : from);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x00026562 File Offset: 0x00024762
		public void Override(T x)
		{
			this.overrideState = true;
			this.m_Value = x;
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x00026572 File Offset: 0x00024772
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void SetValue(VolumeParameter parameter)
		{
			this.m_Value = ((VolumeParameter<T>)parameter).m_Value;
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00026588 File Offset: 0x00024788
		public override int GetHashCode()
		{
			int num = 17;
			num = num * 23 + this.overrideState.GetHashCode();
			if (!EqualityComparer<T>.Default.Equals(this.value, default(T)))
			{
				int num2 = num * 23;
				T value = this.value;
				num = num2 + value.GetHashCode();
			}
			return num;
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x000265E2 File Offset: 0x000247E2
		public override string ToString()
		{
			return string.Format("{0} ({1})", this.value, this.overrideState);
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00026604 File Offset: 0x00024804
		public static bool operator ==(VolumeParameter<T> lhs, T rhs)
		{
			if (lhs != null && lhs.value != null)
			{
				T value = lhs.value;
				return value.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0002663D File Offset: 0x0002483D
		public static bool operator !=(VolumeParameter<T> lhs, T rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00026649 File Offset: 0x00024849
		public bool Equals(VolumeParameter<T> other)
		{
			return other != null && (this == other || EqualityComparer<T>.Default.Equals(this.m_Value, other.m_Value));
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0002666C File Offset: 0x0002486C
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (!(obj.GetType() != base.GetType()) && this.Equals((VolumeParameter<T>)obj)));
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0002669A File Offset: 0x0002489A
		public override object Clone()
		{
			return new VolumeParameter<T>(base.GetValue<T>(), this.overrideState);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x000266AD File Offset: 0x000248AD
		public static explicit operator T(VolumeParameter<T> prop)
		{
			return prop.m_Value;
		}

		// Token: 0x040004DB RID: 1243
		[SerializeField]
		protected T m_Value;
	}
}
