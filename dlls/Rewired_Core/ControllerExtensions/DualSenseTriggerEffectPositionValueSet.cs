using System;
using System.Collections.Generic;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003AC RID: 940
	[Preserve]
	[Serializable]
	public struct DualSenseTriggerEffectPositionValueSet
	{
		// Token: 0x060025DF RID: 9695 RVA: 0x000936E4 File Offset: 0x000918E4
		public DualSenseTriggerEffectPositionValueSet(IList<byte> A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (A_1.Count != 10)
			{
				throw new ArgumentException("collection count must be " + 10.ToString());
			}
			this._position0 = A_1[0];
			this._position1 = A_1[1];
			this._position2 = A_1[2];
			this._position3 = A_1[3];
			this._position4 = A_1[4];
			this._position5 = A_1[5];
			this._position6 = A_1[6];
			this._position7 = A_1[7];
			this._position8 = A_1[8];
			this._position9 = A_1[9];
		}

		// Token: 0x170008D5 RID: 2261
		public byte this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this._position0;
				case 1:
					return this._position1;
				case 2:
					return this._position2;
				case 3:
					return this._position3;
				case 4:
					return this._position4;
				case 5:
					return this._position5;
				case 6:
					return this._position6;
				case 7:
					return this._position7;
				case 8:
					return this._position8;
				case 9:
					return this._position9;
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this._position0 = value;
					return;
				case 1:
					this._position1 = value;
					return;
				case 2:
					this._position2 = value;
					return;
				case 3:
					this._position3 = value;
					return;
				case 4:
					this._position4 = value;
					return;
				case 5:
					this._position5 = value;
					return;
				case 6:
					this._position6 = value;
					return;
				case 7:
					this._position7 = value;
					return;
				case 8:
					this._position8 = value;
					return;
				case 9:
					this._position9 = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index");
				}
			}
		}

		// Token: 0x060025E2 RID: 9698 RVA: 0x000938D0 File Offset: 0x00091AD0
		public byte[] ToArray()
		{
			byte[] array = new byte[10];
			this.CopyTo(array);
			return array;
		}

		// Token: 0x060025E3 RID: 9699 RVA: 0x000938F0 File Offset: 0x00091AF0
		public void CopyTo(byte[] destination)
		{
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (destination.Length < 10)
			{
				throw new ArgumentException("destination.Length must be " + 10.ToString() + "or greater.");
			}
			destination[0] = this._position0;
			destination[1] = this._position1;
			destination[2] = this._position2;
			destination[3] = this._position3;
			destination[4] = this._position4;
			destination[5] = this._position5;
			destination[6] = this._position6;
			destination[7] = this._position7;
			destination[8] = this._position8;
			destination[9] = this._position9;
		}

		// Token: 0x060025E4 RID: 9700 RVA: 0x0009398C File Offset: 0x00091B8C
		internal void nlhOrEBemyyCocIWqDinCxCLQCiZ(byte A_1, byte A_2)
		{
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				byte b = this[i];
				if (b < A_1)
				{
					this[i] = A_1;
					flag = true;
				}
				else if (b > A_2)
				{
					flag = true;
					this[i] = A_2;
				}
			}
			if (flag)
			{
				Logger.LogWarning("One or more values in trigger effect position value set was outside the allowed range and was clamped.", true);
			}
		}

		// Token: 0x040015B6 RID: 5558
		public const int Count = 10;

		// Token: 0x040015B7 RID: 5559
		[SerializeField]
		private byte _position0;

		// Token: 0x040015B8 RID: 5560
		[SerializeField]
		private byte _position1;

		// Token: 0x040015B9 RID: 5561
		[SerializeField]
		private byte _position2;

		// Token: 0x040015BA RID: 5562
		[SerializeField]
		private byte _position3;

		// Token: 0x040015BB RID: 5563
		[SerializeField]
		private byte _position4;

		// Token: 0x040015BC RID: 5564
		[SerializeField]
		private byte _position5;

		// Token: 0x040015BD RID: 5565
		[SerializeField]
		private byte _position6;

		// Token: 0x040015BE RID: 5566
		[SerializeField]
		private byte _position7;

		// Token: 0x040015BF RID: 5567
		[SerializeField]
		private byte _position8;

		// Token: 0x040015C0 RID: 5568
		[SerializeField]
		private byte _position9;
	}
}
