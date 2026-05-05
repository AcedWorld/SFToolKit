using System;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000036 RID: 54
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00003BB3 File Offset: 0x00001DB3
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00003BBB File Offset: 0x00001DBB
		public bool isValid
		{
			get
			{
				return this.QTTBEbHZwbKKEfNgrZewsquknOYcA;
			}
			internal set
			{
				this.QTTBEbHZwbKKEfNgrZewsquknOYcA = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00003BC4 File Offset: 0x00001DC4
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00003BCC File Offset: 0x00001DCC
		public int touchId
		{
			get
			{
				return this.OTsVolQuhQVXnSypZXTWuHidUwPD;
			}
			internal set
			{
				this.OTsVolQuhQVXnSypZXTWuHidUwPD = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00003BD5 File Offset: 0x00001DD5
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00003BDD File Offset: 0x00001DDD
		public Vector2 touchPos
		{
			get
			{
				return this.GqwyOxsFauzAYOJSlAdNavqZDlfRA;
			}
			internal set
			{
				this.GqwyOxsFauzAYOJSlAdNavqZDlfRA = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00003BE6 File Offset: 0x00001DE6
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00003BEE File Offset: 0x00001DEE
		public Vector2 touchPosRaw
		{
			get
			{
				return this.kqsdjhuHAxfdOViOgRSxcpynBBec;
			}
			internal set
			{
				this.kqsdjhuHAxfdOViOgRSxcpynBBec = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00003BF7 File Offset: 0x00001DF7
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00003BFF File Offset: 0x00001DFF
		public Vector2 deltaPos
		{
			get
			{
				return this.VeuUnepNQbMeisWYwOBFkEsZSJUS;
			}
			internal set
			{
				this.VeuUnepNQbMeisWYwOBFkEsZSJUS = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00003C08 File Offset: 0x00001E08
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00003C10 File Offset: 0x00001E10
		public Vector2 deltaPosRaw
		{
			get
			{
				return this.enGrSeDUgpROmfcqUFeFReqhMFtr;
			}
			internal set
			{
				this.enGrSeDUgpROmfcqUFeFReqhMFtr = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00003C19 File Offset: 0x00001E19
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00003C21 File Offset: 0x00001E21
		public float deltaTime
		{
			get
			{
				return this.fjxAdsKSbiASlDvKfHOWtdjfKXHTA;
			}
			internal set
			{
				this.fjxAdsKSbiASlDvKfHOWtdjfKXHTA = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600020B RID: 523 RVA: 0x00003C2A File Offset: 0x00001E2A
		// (set) Token: 0x0600020C RID: 524 RVA: 0x00003C32 File Offset: 0x00001E32
		public int tapCount
		{
			get
			{
				return this.mkAmrWbCXTyEqIvkMJLcMkUVzemd;
			}
			internal set
			{
				this.mkAmrWbCXTyEqIvkMJLcMkUVzemd = value;
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00003C3B File Offset: 0x00001E3B
		internal TouchInfo(bool A_1, int A_2, Vector2 A_3, Vector2 A_4, Vector2 A_5, Vector2 A_6, float A_7, int A_8)
		{
			this.QTTBEbHZwbKKEfNgrZewsquknOYcA = A_1;
			this.OTsVolQuhQVXnSypZXTWuHidUwPD = A_2;
			this.GqwyOxsFauzAYOJSlAdNavqZDlfRA = A_3;
			this.kqsdjhuHAxfdOViOgRSxcpynBBec = A_4;
			this.VeuUnepNQbMeisWYwOBFkEsZSJUS = A_5;
			this.enGrSeDUgpROmfcqUFeFReqhMFtr = A_6;
			this.fjxAdsKSbiASlDvKfHOWtdjfKXHTA = A_7;
			this.mkAmrWbCXTyEqIvkMJLcMkUVzemd = A_8;
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600020E RID: 526 RVA: 0x0002E32C File Offset: 0x0002C52C
		internal static TouchInfo Invalid
		{
			get
			{
				return new TouchInfo
				{
					QTTBEbHZwbKKEfNgrZewsquknOYcA = false
				};
			}
		}

		// Token: 0x040000EA RID: 234
		private bool QTTBEbHZwbKKEfNgrZewsquknOYcA;

		// Token: 0x040000EB RID: 235
		private int OTsVolQuhQVXnSypZXTWuHidUwPD;

		// Token: 0x040000EC RID: 236
		private Vector2 GqwyOxsFauzAYOJSlAdNavqZDlfRA;

		// Token: 0x040000ED RID: 237
		private Vector2 kqsdjhuHAxfdOViOgRSxcpynBBec;

		// Token: 0x040000EE RID: 238
		private Vector2 VeuUnepNQbMeisWYwOBFkEsZSJUS;

		// Token: 0x040000EF RID: 239
		private Vector2 enGrSeDUgpROmfcqUFeFReqhMFtr;

		// Token: 0x040000F0 RID: 240
		private float fjxAdsKSbiASlDvKfHOWtdjfKXHTA;

		// Token: 0x040000F1 RID: 241
		private int mkAmrWbCXTyEqIvkMJLcMkUVzemd;
	}
}
