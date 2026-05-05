using System;

namespace UnityEngine
{
	// Token: 0x0200024F RID: 591
	[Serializable]
	public struct LazyLoadReference<T> where T : Object
	{
		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x0600192D RID: 6445 RVA: 0x0002A12B File Offset: 0x0002832B
		public bool isSet
		{
			get
			{
				return this.m_InstanceID != 0;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600192E RID: 6446 RVA: 0x0002A136 File Offset: 0x00028336
		public bool isBroken
		{
			get
			{
				return this.m_InstanceID != 0 && !Object.DoesObjectWithInstanceIDExist(this.m_InstanceID);
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600192F RID: 6447 RVA: 0x0002A154 File Offset: 0x00028354
		// (set) Token: 0x06001930 RID: 6448 RVA: 0x0002A194 File Offset: 0x00028394
		public T asset
		{
			get
			{
				bool flag = this.m_InstanceID == 0;
				T result;
				if (flag)
				{
					result = default(T);
				}
				else
				{
					result = (T)((object)Object.ForceLoadFromInstanceID(this.m_InstanceID));
				}
				return result;
			}
			set
			{
				bool flag = value == null;
				if (flag)
				{
					this.m_InstanceID = 0;
				}
				else
				{
					bool flag2 = !Object.IsPersistent(value);
					if (flag2)
					{
						throw new ArgumentException("Object that does not belong to a persisted asset cannot be set as the target of a LazyLoadReference.");
					}
					this.m_InstanceID = value.GetInstanceID();
				}
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06001931 RID: 6449 RVA: 0x0002A1EE File Offset: 0x000283EE
		// (set) Token: 0x06001932 RID: 6450 RVA: 0x0002A1F6 File Offset: 0x000283F6
		public int instanceID
		{
			get
			{
				return this.m_InstanceID;
			}
			set
			{
				this.m_InstanceID = value;
			}
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x0002A200 File Offset: 0x00028400
		public LazyLoadReference(T asset)
		{
			bool flag = asset == null;
			if (flag)
			{
				this.m_InstanceID = 0;
			}
			else
			{
				bool flag2 = !Object.IsPersistent(asset);
				if (flag2)
				{
					throw new ArgumentException("Object that does not belong to a persisted asset cannot be set as the target of a LazyLoadReference.");
				}
				this.m_InstanceID = asset.GetInstanceID();
			}
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x0002A25A File Offset: 0x0002845A
		public LazyLoadReference(int instanceID)
		{
			this.m_InstanceID = instanceID;
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x0002A264 File Offset: 0x00028464
		public static implicit operator LazyLoadReference<T>(T asset)
		{
			return new LazyLoadReference<T>
			{
				asset = asset
			};
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x0002A288 File Offset: 0x00028488
		public static implicit operator LazyLoadReference<T>(int instanceID)
		{
			return new LazyLoadReference<T>
			{
				instanceID = instanceID
			};
		}

		// Token: 0x040008CB RID: 2251
		private const int kInstanceID_None = 0;

		// Token: 0x040008CC RID: 2252
		[SerializeField]
		private int m_InstanceID;
	}
}
