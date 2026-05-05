using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	// Token: 0x02000421 RID: 1057
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	public class CustomControllerElementTarget
	{
		// Token: 0x17000A08 RID: 2568
		// (get) Token: 0x06002AA0 RID: 10912 RVA: 0x00020B52 File Offset: 0x0001ED52
		public CustomControllerElementSelector element
		{
			get
			{
				return this._element;
			}
		}

		// Token: 0x17000A09 RID: 2569
		// (get) Token: 0x06002AA1 RID: 10913 RVA: 0x00020B5A File Offset: 0x0001ED5A
		// (set) Token: 0x06002AA2 RID: 10914 RVA: 0x00020B62 File Offset: 0x0001ED62
		public Pole valueContribution
		{
			get
			{
				return this._valueContribution;
			}
			set
			{
				this._valueContribution = value;
			}
		}

		// Token: 0x17000A0A RID: 2570
		// (get) Token: 0x06002AA3 RID: 10915 RVA: 0x00020B6B File Offset: 0x0001ED6B
		// (set) Token: 0x06002AA4 RID: 10916 RVA: 0x00020B73 File Offset: 0x0001ED73
		internal CustomControllerElementTarget.ValueRange valueRange
		{
			get
			{
				return this._valueRange;
			}
			set
			{
				this._valueRange = value;
			}
		}

		// Token: 0x17000A0B RID: 2571
		// (get) Token: 0x06002AA5 RID: 10917 RVA: 0x00020B7C File Offset: 0x0001ED7C
		// (set) Token: 0x06002AA6 RID: 10918 RVA: 0x00020B84 File Offset: 0x0001ED84
		public bool invert
		{
			get
			{
				return this._invert;
			}
			set
			{
				this._invert = value;
			}
		}

		// Token: 0x06002AA7 RID: 10919 RVA: 0x00020B8D File Offset: 0x0001ED8D
		internal CustomControllerElementTarget()
		{
		}

		// Token: 0x06002AA8 RID: 10920 RVA: 0x00020BA7 File Offset: 0x0001EDA7
		internal CustomControllerElementTarget(CustomControllerElementSelector A_1)
		{
			this._element = A_1;
		}

		// Token: 0x06002AA9 RID: 10921 RVA: 0x00020BC8 File Offset: 0x0001EDC8
		internal void ClearElementCaches()
		{
			if (this._element == null)
			{
				return;
			}
			this._element.ClearCache();
		}

		// Token: 0x04001874 RID: 6260
		[Tooltip("The Custom Controller element.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementSelector _element = new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Axis
		};

		// Token: 0x04001875 RID: 6261
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget.ValueRange _valueRange;

		// Token: 0x04001876 RID: 6262
		[Tooltip("Should the final value be positive or negative?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Pole _valueContribution;

		// Token: 0x04001877 RID: 6263
		[Tooltip("Should the final value be inverted?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _invert;

		// Token: 0x02000422 RID: 1058
		[CustomObfuscation(rename = false)]
		internal enum ValueRange
		{
			// Token: 0x04001879 RID: 6265
			[CustomObfuscation(rename = false)]
			Full,
			// Token: 0x0400187A RID: 6266
			[CustomObfuscation(rename = false)]
			Positive,
			// Token: 0x0400187B RID: 6267
			[CustomObfuscation(rename = false)]
			Negative
		}
	}
}
