using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	// Token: 0x02000424 RID: 1060
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	public class CustomControllerElementTargetSetForBoolean : CustomControllerElementTargetSet
	{
		// Token: 0x17000A0E RID: 2574
		// (get) Token: 0x06002AAE RID: 10926 RVA: 0x00020BDE File Offset: 0x0001EDDE
		public CustomControllerElementTarget target
		{
			get
			{
				return this._target;
			}
		}

		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x06002AAF RID: 10927 RVA: 0x000042E2 File Offset: 0x000024E2
		internal override int targetCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000A10 RID: 2576
		internal override CustomControllerElementTarget this[int index]
		{
			get
			{
				if (index == 0)
				{
					return this._target;
				}
				throw new IndexOutOfRangeException();
			}
		}

		// Token: 0x06002AB1 RID: 10929 RVA: 0x00020BF7 File Offset: 0x0001EDF7
		internal CustomControllerElementTargetSetForBoolean()
		{
		}

		// Token: 0x06002AB2 RID: 10930 RVA: 0x00020C24 File Offset: 0x0001EE24
		internal CustomControllerElementTargetSetForBoolean(CustomControllerElementTarget A_1)
		{
			this._target = A_1;
		}

		// Token: 0x06002AB3 RID: 10931 RVA: 0x00020C58 File Offset: 0x0001EE58
		internal override void ClearElementCaches()
		{
			if (this._target == null)
			{
				return;
			}
			this._target.ClearElementCaches();
		}

		// Token: 0x0400187C RID: 6268
		private const int sDbsaHSRBVZYlIbJeJYLsaYFDBKe = 1;

		// Token: 0x0400187D RID: 6269
		[Tooltip("The target element.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _target = new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		})
		{
			valueRange = CustomControllerElementTarget.ValueRange.Positive,
			valueContribution = Pole.Positive
		};
	}
}
