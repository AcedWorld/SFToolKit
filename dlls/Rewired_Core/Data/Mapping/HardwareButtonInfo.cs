using System;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x02000395 RID: 917
	[Serializable]
	public class HardwareButtonInfo : IDeepCloneable
	{
		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x06002539 RID: 9529 RVA: 0x0001B556 File Offset: 0x00019756
		public bool excludeFromPolling
		{
			get
			{
				return this._excludeFromPolling;
			}
		}

		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x0600253A RID: 9530 RVA: 0x0001B55E File Offset: 0x0001975E
		public bool isPressureSensitive
		{
			get
			{
				return this._isPressureSensitive;
			}
		}

		// Token: 0x0600253B RID: 9531 RVA: 0x0001B566 File Offset: 0x00019766
		public HardwareButtonInfo()
		{
			this._excludeFromPolling = false;
			this._isPressureSensitive = false;
		}

		// Token: 0x0600253C RID: 9532 RVA: 0x0001B57C File Offset: 0x0001977C
		[CustomObfuscation(rename = false)]
		internal HardwareButtonInfo(bool A_1, bool A_2)
		{
			this._excludeFromPolling = A_1;
			this._isPressureSensitive = A_2;
		}

		// Token: 0x0600253D RID: 9533 RVA: 0x0001B592 File Offset: 0x00019792
		public object DeepClone()
		{
			return new HardwareButtonInfo(this._excludeFromPolling, this._isPressureSensitive);
		}

		// Token: 0x04001565 RID: 5477
		[SerializeField]
		internal bool _excludeFromPolling;

		// Token: 0x04001566 RID: 5478
		[SerializeField]
		internal bool _isPressureSensitive;
	}
}
