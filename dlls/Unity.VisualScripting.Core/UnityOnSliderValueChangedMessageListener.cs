using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000A6 RID: 166
	[AddComponentMenu("")]
	public sealed class UnityOnSliderValueChangedMessageListener : MessageListener
	{
		// Token: 0x06000421 RID: 1057 RVA: 0x00009ACF File Offset: 0x00007CCF
		private void Start()
		{
			Slider component = base.GetComponent<Slider>();
			if (component == null)
			{
				return;
			}
			Slider.SliderEvent onValueChanged = component.onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.AddListener(delegate(float value)
			{
				EventBus.Trigger<float>("OnSliderValueChanged", base.gameObject, value);
			});
		}
	}
}
