using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x0200005B RID: 91
	public abstract class DebugDisplaySettings<T> : IDebugDisplaySettings, IDebugDisplaySettingsQuery where T : IDebugDisplaySettings, new()
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000C956 File Offset: 0x0000AB56
		public static T Instance
		{
			get
			{
				return DebugDisplaySettings<T>.s_Instance.Value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x0000C964 File Offset: 0x0000AB64
		public virtual bool AreAnySettingsActive
		{
			get
			{
				using (HashSet<IDebugDisplaySettingsData>.Enumerator enumerator = this.m_Settings.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.AreAnySettingsActive)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000C9C0 File Offset: 0x0000ABC0
		public virtual bool IsPostProcessingAllowed
		{
			get
			{
				bool flag = true;
				foreach (IDebugDisplaySettingsData debugDisplaySettingsData in this.m_Settings)
				{
					flag &= debugDisplaySettingsData.IsPostProcessingAllowed;
				}
				return flag;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x0000CA18 File Offset: 0x0000AC18
		public virtual bool IsLightingActive
		{
			get
			{
				bool flag = true;
				foreach (IDebugDisplaySettingsData debugDisplaySettingsData in this.m_Settings)
				{
					flag &= debugDisplaySettingsData.IsLightingActive;
				}
				return flag;
			}
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000CA70 File Offset: 0x0000AC70
		protected TData Add<TData>(TData newData) where TData : IDebugDisplaySettingsData
		{
			this.m_Settings.Add(newData);
			return newData;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000CA88 File Offset: 0x0000AC88
		public void ForEach(Action<IDebugDisplaySettingsData> onExecute)
		{
			foreach (IDebugDisplaySettingsData obj in this.m_Settings)
			{
				onExecute(obj);
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000CADC File Offset: 0x0000ACDC
		public virtual void Reset()
		{
			this.m_Settings.Clear();
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000CAEC File Offset: 0x0000ACEC
		public virtual bool TryGetScreenClearColor(ref Color color)
		{
			using (HashSet<IDebugDisplaySettingsData>.Enumerator enumerator = this.m_Settings.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.TryGetScreenClearColor(ref color))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x040001A7 RID: 423
		protected readonly HashSet<IDebugDisplaySettingsData> m_Settings = new HashSet<IDebugDisplaySettingsData>();

		// Token: 0x040001A8 RID: 424
		private static readonly Lazy<T> s_Instance = new Lazy<T>(delegate()
		{
			T result = Activator.CreateInstance<T>();
			result.Reset();
			return result;
		});
	}
}
