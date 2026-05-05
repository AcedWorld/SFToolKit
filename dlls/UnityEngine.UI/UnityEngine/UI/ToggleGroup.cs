using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	// Token: 0x0200003C RID: 60
	[AddComponentMenu("UI/Toggle Group", 31)]
	[DisallowMultipleComponent]
	public class ToggleGroup : UIBehaviour
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x00015C75 File Offset: 0x00013E75
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00015C7D File Offset: 0x00013E7D
		public bool allowSwitchOff
		{
			get
			{
				return this.m_AllowSwitchOff;
			}
			set
			{
				this.m_AllowSwitchOff = value;
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00015C86 File Offset: 0x00013E86
		protected ToggleGroup()
		{
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00015C99 File Offset: 0x00013E99
		protected override void Start()
		{
			this.EnsureValidState();
			base.Start();
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00015CA7 File Offset: 0x00013EA7
		protected override void OnEnable()
		{
			this.EnsureValidState();
			base.OnEnable();
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00015CB5 File Offset: 0x00013EB5
		private void ValidateToggleIsInGroup(Toggle toggle)
		{
			if (toggle == null || !this.m_Toggles.Contains(toggle))
			{
				throw new ArgumentException(string.Format("Toggle {0} is not part of ToggleGroup {1}", new object[]
				{
					toggle,
					this
				}));
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00015CEC File Offset: 0x00013EEC
		public void NotifyToggleOn(Toggle toggle, bool sendCallback = true)
		{
			this.ValidateToggleIsInGroup(toggle);
			for (int i = 0; i < this.m_Toggles.Count; i++)
			{
				if (!(this.m_Toggles[i] == toggle))
				{
					if (sendCallback)
					{
						this.m_Toggles[i].isOn = false;
					}
					else
					{
						this.m_Toggles[i].SetIsOnWithoutNotify(false);
					}
				}
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00015D53 File Offset: 0x00013F53
		public void UnregisterToggle(Toggle toggle)
		{
			if (this.m_Toggles.Contains(toggle))
			{
				this.m_Toggles.Remove(toggle);
			}
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00015D70 File Offset: 0x00013F70
		public void RegisterToggle(Toggle toggle)
		{
			if (!this.m_Toggles.Contains(toggle))
			{
				this.m_Toggles.Add(toggle);
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00015D8C File Offset: 0x00013F8C
		public void EnsureValidState()
		{
			if (!this.allowSwitchOff && !this.AnyTogglesOn() && this.m_Toggles.Count != 0)
			{
				this.m_Toggles[0].isOn = true;
				this.NotifyToggleOn(this.m_Toggles[0], true);
			}
			IEnumerable<Toggle> enumerable = this.ActiveToggles();
			if (enumerable.Count<Toggle>() > 1)
			{
				Toggle firstActiveToggle = this.GetFirstActiveToggle();
				foreach (Toggle toggle in enumerable)
				{
					if (!(toggle == firstActiveToggle))
					{
						toggle.isOn = false;
					}
				}
			}
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00015E38 File Offset: 0x00014038
		public bool AnyTogglesOn()
		{
			return this.m_Toggles.Find((Toggle x) => x.isOn) != null;
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00015E6A File Offset: 0x0001406A
		public IEnumerable<Toggle> ActiveToggles()
		{
			return from x in this.m_Toggles
			where x.isOn
			select x;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00015E98 File Offset: 0x00014098
		public Toggle GetFirstActiveToggle()
		{
			IEnumerable<Toggle> source = this.ActiveToggles();
			if (source.Count<Toggle>() <= 0)
			{
				return null;
			}
			return source.First<Toggle>();
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00015EC0 File Offset: 0x000140C0
		public void SetAllTogglesOff(bool sendCallback = true)
		{
			bool allowSwitchOff = this.m_AllowSwitchOff;
			this.m_AllowSwitchOff = true;
			if (sendCallback)
			{
				for (int i = 0; i < this.m_Toggles.Count; i++)
				{
					this.m_Toggles[i].isOn = false;
				}
			}
			else
			{
				for (int j = 0; j < this.m_Toggles.Count; j++)
				{
					this.m_Toggles[j].SetIsOnWithoutNotify(false);
				}
			}
			this.m_AllowSwitchOff = allowSwitchOff;
		}

		// Token: 0x0400017B RID: 379
		[SerializeField]
		private bool m_AllowSwitchOff;

		// Token: 0x0400017C RID: 380
		protected List<Toggle> m_Toggles = new List<Toggle>();
	}
}
