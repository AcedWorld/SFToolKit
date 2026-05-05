using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020000CF RID: 207
	public class BaseFieldTraits<TValueType, TValueUxmlAttributeType> : BaseField<TValueType>.UxmlTraits where TValueUxmlAttributeType : TypedUxmlAttributeDescription<TValueType>, new()
	{
		// Token: 0x060006F7 RID: 1783 RVA: 0x0001A7D5 File Offset: 0x000189D5
		public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
		{
			base.Init(ve, bag, cc);
			((INotifyValueChanged<TValueType>)ve).SetValueWithoutNotify(this.m_Value.GetValueFromBag(bag, cc));
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0001A800 File Offset: 0x00018A00
		public BaseFieldTraits()
		{
			TValueUxmlAttributeType tvalueUxmlAttributeType = Activator.CreateInstance<TValueUxmlAttributeType>();
			tvalueUxmlAttributeType.name = "value";
			this.m_Value = tvalueUxmlAttributeType;
			base..ctor();
		}

		// Token: 0x04000314 RID: 788
		private TValueUxmlAttributeType m_Value;
	}
}
