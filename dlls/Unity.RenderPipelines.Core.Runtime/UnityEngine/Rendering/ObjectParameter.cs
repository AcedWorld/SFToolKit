using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace UnityEngine.Rendering
{
	// Token: 0x02000114 RID: 276
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	[Serializable]
	public class ObjectParameter<T> : VolumeParameter<T>
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x00026F32 File Offset: 0x00025132
		// (set) Token: 0x0600084D RID: 2125 RVA: 0x00026F3A File Offset: 0x0002513A
		internal ReadOnlyCollection<VolumeParameter> parameters { get; private set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x00026F43 File Offset: 0x00025143
		// (set) Token: 0x0600084F RID: 2127 RVA: 0x00026F46 File Offset: 0x00025146
		public sealed override bool overrideState
		{
			get
			{
				return true;
			}
			set
			{
				this.m_OverrideState = true;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x00026F4F File Offset: 0x0002514F
		// (set) Token: 0x06000851 RID: 2129 RVA: 0x00026F58 File Offset: 0x00025158
		public sealed override T value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
				if (this.m_Value == null)
				{
					this.parameters = null;
					return;
				}
				this.parameters = (from t in this.m_Value.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
				where t.FieldType.IsSubclassOf(typeof(VolumeParameter))
				orderby t.MetadataToken
				select (VolumeParameter)t.GetValue(this.m_Value)).ToList<VolumeParameter>().AsReadOnly();
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00027002 File Offset: 0x00025202
		public ObjectParameter(T value)
		{
			this.m_OverrideState = true;
			this.value = value;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00027018 File Offset: 0x00025218
		internal override void Interp(VolumeParameter from, VolumeParameter to, float t)
		{
			if (this.m_Value == null)
			{
				return;
			}
			ReadOnlyCollection<VolumeParameter> parameters = this.parameters;
			ReadOnlyCollection<VolumeParameter> parameters2 = ((ObjectParameter<T>)from).parameters;
			ReadOnlyCollection<VolumeParameter> parameters3 = ((ObjectParameter<T>)to).parameters;
			for (int i = 0; i < parameters2.Count; i++)
			{
				parameters[i].overrideState = parameters3[i].overrideState;
				if (parameters3[i].overrideState)
				{
					parameters[i].Interp(parameters2[i], parameters3[i], t);
				}
			}
		}
	}
}
