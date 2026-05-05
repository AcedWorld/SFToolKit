using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	// Token: 0x02000425 RID: 1061
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	public class CustomControllerElementTargetSetForFloat : CustomControllerElementTargetSet
	{
		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x06002AB4 RID: 10932 RVA: 0x00020C6E File Offset: 0x0001EE6E
		// (set) Token: 0x06002AB5 RID: 10933 RVA: 0x00020C76 File Offset: 0x0001EE76
		public bool splitValue
		{
			get
			{
				return this._splitValue;
			}
			set
			{
				this._splitValue = value;
			}
		}

		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x06002AB6 RID: 10934 RVA: 0x00020C7F File Offset: 0x0001EE7F
		public CustomControllerElementTarget target
		{
			get
			{
				return this._target;
			}
		}

		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06002AB7 RID: 10935 RVA: 0x00020C87 File Offset: 0x0001EE87
		public CustomControllerElementTarget positiveTarget
		{
			get
			{
				return this._positiveTarget;
			}
		}

		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x06002AB8 RID: 10936 RVA: 0x00020C8F File Offset: 0x0001EE8F
		public CustomControllerElementTarget negativeTarget
		{
			get
			{
				return this._negativeTarget;
			}
		}

		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x06002AB9 RID: 10937 RVA: 0x00020C97 File Offset: 0x0001EE97
		internal override int targetCount
		{
			get
			{
				if (!this._splitValue)
				{
					return 1;
				}
				return 2;
			}
		}

		// Token: 0x17000A16 RID: 2582
		internal override CustomControllerElementTarget this[int index]
		{
			get
			{
				if (this._splitValue)
				{
					if (index == 0)
					{
						return this._positiveTarget;
					}
					if (index != 1)
					{
						throw new IndexOutOfRangeException();
					}
					return this._negativeTarget;
				}
				else
				{
					if (index == 0)
					{
						return this._target;
					}
					throw new IndexOutOfRangeException();
				}
			}
		}

		// Token: 0x06002ABB RID: 10939 RVA: 0x0009B748 File Offset: 0x00099948
		internal CustomControllerElementTargetSetForFloat()
		{
		}

		// Token: 0x06002ABC RID: 10940 RVA: 0x0009B7C4 File Offset: 0x000999C4
		internal CustomControllerElementTargetSetForFloat(CustomControllerElementTarget A_1)
		{
			this._splitValue = false;
			this._target = A_1;
		}

		// Token: 0x06002ABD RID: 10941 RVA: 0x0009B850 File Offset: 0x00099A50
		internal CustomControllerElementTargetSetForFloat(CustomControllerElementTarget A_1, CustomControllerElementTarget A_2)
		{
			this._splitValue = true;
			this._positiveTarget = A_1;
			this._negativeTarget = A_2;
		}

		// Token: 0x06002ABE RID: 10942 RVA: 0x00020CDA File Offset: 0x0001EEDA
		internal override void ClearElementCaches()
		{
			if (this._target == null)
			{
				return;
			}
			this._target.ClearElementCaches();
		}

		// Token: 0x0400187E RID: 6270
		[Tooltip("Splits the value into positive and negative sides which can be assigned to different Custom Controller elements.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _splitValue;

		// Token: 0x0400187F RID: 6271
		[Tooltip("The target element. This is unused if Split Value is enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _target = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Axis
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Full
		};

		// Token: 0x04001880 RID: 6272
		[Tooltip("The positive target element. This is unused if Split Value is not enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _positiveTarget = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Positive,
			valueContribution = Pole.Positive
		};

		// Token: 0x04001881 RID: 6273
		[Tooltip("The negative target element. This is unused if Split Value is not enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _negativeTarget = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Negative,
			valueContribution = Pole.Positive
		};
	}
}
