using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000177 RID: 375
	public sealed class ValueInputDefinition : ValuePortDefinition, IUnitInputPortDefinition, IUnitPortDefinition
	{
		// Token: 0x1700036A RID: 874
		// (get) Token: 0x060009CE RID: 2510 RVA: 0x000117CC File Offset: 0x0000F9CC
		// (set) Token: 0x060009CF RID: 2511 RVA: 0x000117D4 File Offset: 0x0000F9D4
		[Inspectable]
		[DoNotSerialize]
		public override Type type
		{
			get
			{
				return base.type;
			}
			set
			{
				base.type = value;
				if (!this.type.IsAssignableFrom(this.defaultValue))
				{
					if (ValueInput.SupportsDefaultValue(this.type))
					{
						this._defaultvalue = this.type.PseudoDefault();
						return;
					}
					this.hasDefaultValue = false;
					this._defaultvalue = null;
				}
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x060009D0 RID: 2512 RVA: 0x00011828 File Offset: 0x0000FA28
		// (set) Token: 0x060009D1 RID: 2513 RVA: 0x00011830 File Offset: 0x0000FA30
		[Serialize]
		[Inspectable]
		public bool hasDefaultValue { get; set; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x060009D2 RID: 2514 RVA: 0x00011839 File Offset: 0x0000FA39
		// (set) Token: 0x060009D3 RID: 2515 RVA: 0x00011844 File Offset: 0x0000FA44
		[DoNotSerialize]
		[Inspectable]
		public object defaultValue
		{
			get
			{
				return this._defaultvalue;
			}
			set
			{
				if (this.type == null)
				{
					throw new InvalidOperationException("A type must be defined before setting the default value.");
				}
				if (!ValueInput.SupportsDefaultValue(this.type))
				{
					throw new InvalidOperationException("The selected type does not support default values.");
				}
				Ensure.That("value").IsOfType<object>(value, this.type);
				this._defaultvalue = value;
			}
		}

		// Token: 0x0400020C RID: 524
		[SerializeAs("defaultValue")]
		private object _defaultvalue;
	}
}
