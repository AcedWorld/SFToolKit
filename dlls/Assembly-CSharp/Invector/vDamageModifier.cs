using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Invector
{
	// Token: 0x0200035C RID: 860
	[Serializable]
	public class vDamageModifier
	{
		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06001173 RID: 4467 RVA: 0x0005E2E6 File Offset: 0x0005C4E6
		public bool isBroken
		{
			get
			{
				return this.destructible && this.resistance <= 0f;
			}
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x0005E304 File Offset: 0x0005C504
		public virtual void ApplyModifier(vDamage damage)
		{
			if (damage.damageValue > 0f && this.CanFilterDamage(damage.damageType) && (!this.destructible || this.resistance > 0f))
			{
				float num;
				if (this.percentage)
				{
					num = damage.damageValue - damage.damageValue / 100f * (float)this.value;
				}
				else
				{
					num = (float)this.value;
				}
				if (this.destructible)
				{
					this.resistance -= damage.damageValue;
					this.onChangeResistance.Invoke(Mathf.Max(this.resistance, 0f));
					if (this.resistance <= 0f)
					{
						this.onBroken.Invoke(this);
					}
				}
				if (!this.destructible || this.resistance > 0f)
				{
					damage.damageValue -= num;
				}
			}
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x0005E3F4 File Offset: 0x0005C5F4
		protected virtual bool CanFilterDamage(string damageType)
		{
			switch (this.filterMethod)
			{
			case vDamageModifier.FilterMethod.ApplyToAll:
				return true;
			case vDamageModifier.FilterMethod.ApplyToAllInList:
				return damageType.Contains(damageType);
			case vDamageModifier.FilterMethod.ApplyToAllOutList:
				return !damageType.Contains(damageType);
			default:
				return true;
			}
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x0005E432 File Offset: 0x0005C632
		public virtual void ResetModifier()
		{
			if (this.destructible)
			{
				this.resistance = this.maxResistance;
				this.onChangeResistance.Invoke(Mathf.Max(this.resistance, 0f));
			}
		}

		// Token: 0x0400176F RID: 5999
		public string name = "MyModifier";

		// Token: 0x04001770 RID: 6000
		public vDamageModifier.FilterMethod filterMethod;

		// Token: 0x04001771 RID: 6001
		[Tooltip("List of Damage type that this can modify, keep empty if the filter will be applied to all types of damage")]
		public List<string> damageTypes = new List<string>();

		// Token: 0x04001772 RID: 6002
		[Tooltip("Modifier value")]
		public int value;

		// Token: 0x04001773 RID: 6003
		[Tooltip("true: Reduce a percentage of damage value\nfalse: Reduce da damage value directly")]
		public bool percentage;

		// Token: 0x04001774 RID: 6004
		[Tooltip("The Filter will receive all damage and decrease your self resistance")]
		public bool destructible = true;

		// Token: 0x04001775 RID: 6005
		public float resistance = 100f;

		// Token: 0x04001776 RID: 6006
		public float maxResistance = 100f;

		// Token: 0x04001777 RID: 6007
		public Slider.SliderEvent onChangeResistance;

		// Token: 0x04001778 RID: 6008
		public vDamageModifier.DamageModifierEvent onBroken;

		// Token: 0x0200035D RID: 861
		public enum FilterMethod
		{
			// Token: 0x0400177A RID: 6010
			ApplyToAll,
			// Token: 0x0400177B RID: 6011
			ApplyToAllInList,
			// Token: 0x0400177C RID: 6012
			ApplyToAllOutList
		}

		// Token: 0x0200035E RID: 862
		[Serializable]
		public class DamageModifierEvent : UnityEvent<vDamageModifier>
		{
		}
	}
}
