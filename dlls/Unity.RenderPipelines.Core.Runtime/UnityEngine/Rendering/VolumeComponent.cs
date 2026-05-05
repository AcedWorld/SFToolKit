using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace UnityEngine.Rendering
{
	// Token: 0x020000EB RID: 235
	[Serializable]
	public class VolumeComponent : ScriptableObject
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x00025666 File Offset: 0x00023866
		// (set) Token: 0x060007AF RID: 1967 RVA: 0x0002566E File Offset: 0x0002386E
		public string displayName { get; protected set; } = "";

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x00025677 File Offset: 0x00023877
		public ReadOnlyCollection<VolumeParameter> parameters
		{
			get
			{
				if (this.m_ParameterReadOnlyCollection == null)
				{
					this.m_ParameterReadOnlyCollection = this.parameterList.AsReadOnly();
				}
				return this.m_ParameterReadOnlyCollection;
			}
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00025698 File Offset: 0x00023898
		internal static void FindParameters(object o, List<VolumeParameter> parameters, Func<FieldInfo, bool> filter = null)
		{
			if (o == null)
			{
				return;
			}
			foreach (FieldInfo fieldInfo in from t in o.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			orderby t.MetadataToken
			select t)
			{
				if (fieldInfo.FieldType.IsSubclassOf(typeof(VolumeParameter)))
				{
					if (filter == null || filter(fieldInfo))
					{
						VolumeParameter item = (VolumeParameter)fieldInfo.GetValue(o);
						parameters.Add(item);
					}
				}
				else if (!fieldInfo.FieldType.IsArray && fieldInfo.FieldType.IsClass)
				{
					VolumeComponent.FindParameters(fieldInfo.GetValue(o), parameters, filter);
				}
			}
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00025774 File Offset: 0x00023974
		protected virtual void OnEnable()
		{
			this.parameterList.Clear();
			VolumeComponent.FindParameters(this, this.parameterList, null);
			foreach (VolumeParameter volumeParameter in this.parameterList)
			{
				if (volumeParameter != null)
				{
					volumeParameter.OnEnable();
				}
				else
				{
					Debug.LogWarning("Volume Component " + base.GetType().Name + " contains a null parameter; please make sure all parameters are initialized to a default value. Until this is fixed the null parameters will not be considered by the system.");
				}
			}
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00025804 File Offset: 0x00023A04
		protected virtual void OnDisable()
		{
			foreach (VolumeParameter volumeParameter in this.parameterList)
			{
				if (volumeParameter != null)
				{
					volumeParameter.OnDisable();
				}
			}
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0002585C File Offset: 0x00023A5C
		public virtual void Override(VolumeComponent state, float interpFactor)
		{
			int count = this.parameterList.Count;
			for (int i = 0; i < count; i++)
			{
				VolumeParameter volumeParameter = state.parameterList[i];
				VolumeParameter volumeParameter2 = this.parameterList[i];
				if (volumeParameter2.overrideState)
				{
					volumeParameter.overrideState = volumeParameter2.overrideState;
					volumeParameter.Interp(volumeParameter, volumeParameter2, interpFactor);
				}
			}
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x000258B8 File Offset: 0x00023AB8
		public void SetAllOverridesTo(bool state)
		{
			this.SetOverridesTo(this.parameterList, state);
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x000258C8 File Offset: 0x00023AC8
		internal void SetOverridesTo(IEnumerable<VolumeParameter> enumerable, bool state)
		{
			foreach (VolumeParameter volumeParameter in enumerable)
			{
				volumeParameter.overrideState = state;
				Type type = volumeParameter.GetType();
				if (VolumeParameter.IsObjectParameter(type))
				{
					ReadOnlyCollection<VolumeParameter> readOnlyCollection = (ReadOnlyCollection<VolumeParameter>)type.GetProperty("parameters", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(volumeParameter, null);
					if (readOnlyCollection != null)
					{
						this.SetOverridesTo(readOnlyCollection, state);
					}
				}
			}
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00025944 File Offset: 0x00023B44
		public override int GetHashCode()
		{
			int num = 17;
			for (int i = 0; i < this.parameterList.Count; i++)
			{
				num = num * 23 + this.parameterList[i].GetHashCode();
			}
			return num;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00025984 File Offset: 0x00023B84
		public bool AnyPropertiesIsOverridden()
		{
			for (int i = 0; i < this.parameterList.Count; i++)
			{
				if (this.parameterList[i].overrideState)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x000259BD File Offset: 0x00023BBD
		protected virtual void OnDestroy()
		{
			this.Release();
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x000259C8 File Offset: 0x00023BC8
		public void Release()
		{
			if (this.parameterList == null)
			{
				return;
			}
			for (int i = 0; i < this.parameterList.Count; i++)
			{
				if (this.parameterList[i] != null)
				{
					this.parameterList[i].Release();
				}
			}
		}

		// Token: 0x040004CA RID: 1226
		public bool active = true;

		// Token: 0x040004CC RID: 1228
		internal readonly List<VolumeParameter> parameterList = new List<VolumeParameter>();

		// Token: 0x040004CD RID: 1229
		private ReadOnlyCollection<VolumeParameter> m_ParameterReadOnlyCollection;

		// Token: 0x020001D6 RID: 470
		public sealed class Indent : PropertyAttribute
		{
			// Token: 0x06000B68 RID: 2920 RVA: 0x0002FD38 File Offset: 0x0002DF38
			public Indent(int relativeAmount = 1)
			{
				this.relativeAmount = relativeAmount;
			}

			// Token: 0x040007A3 RID: 1955
			public readonly int relativeAmount;
		}
	}
}
