using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000EE RID: 238
	public abstract class VolumeParameter : ICloneable
	{
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x0002647F File Offset: 0x0002467F
		// (set) Token: 0x060007DF RID: 2015 RVA: 0x00026487 File Offset: 0x00024687
		public virtual bool overrideState
		{
			get
			{
				return this.m_OverrideState;
			}
			set
			{
				this.m_OverrideState = value;
			}
		}

		// Token: 0x060007E0 RID: 2016
		internal abstract void Interp(VolumeParameter from, VolumeParameter to, float t);

		// Token: 0x060007E1 RID: 2017 RVA: 0x00026490 File Offset: 0x00024690
		public T GetValue<T>()
		{
			return ((VolumeParameter<T>)this).value;
		}

		// Token: 0x060007E2 RID: 2018
		public abstract void SetValue(VolumeParameter parameter);

		// Token: 0x060007E3 RID: 2019 RVA: 0x0002649D File Offset: 0x0002469D
		protected internal virtual void OnEnable()
		{
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0002649F File Offset: 0x0002469F
		protected internal virtual void OnDisable()
		{
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x000264A1 File Offset: 0x000246A1
		public static bool IsObjectParameter(Type type)
		{
			return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ObjectParameter<>)) || (type.BaseType != null && VolumeParameter.IsObjectParameter(type.BaseType));
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x000264DF File Offset: 0x000246DF
		public virtual void Release()
		{
		}

		// Token: 0x060007E7 RID: 2023
		public abstract object Clone();

		// Token: 0x040004D9 RID: 1241
		public const string k_DebuggerDisplay = "{m_Value} ({m_OverrideState})";

		// Token: 0x040004DA RID: 1242
		[SerializeField]
		protected bool m_OverrideState;
	}
}
