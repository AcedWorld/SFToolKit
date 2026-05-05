using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	// Token: 0x02000489 RID: 1161
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class TempListPool
	{
		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x06002DDE RID: 11742 RVA: 0x00023517 File Offset: 0x00021717
		private static ADictionary<Type, List<IList>> lists
		{
			get
			{
				if (TempListPool.XtShnnciTAujvHvBegttjIGAWDgM == null)
				{
					return TempListPool.XtShnnciTAujvHvBegttjIGAWDgM = new ADictionary<Type, List<IList>>();
				}
				return TempListPool.XtShnnciTAujvHvBegttjIGAWDgM;
			}
		}

		// Token: 0x06002DDF RID: 11743 RVA: 0x00023531 File Offset: 0x00021731
		public static TempListPool.TList<T> GetTList<T>()
		{
			return TempListPool.GetTList<T>(0);
		}

		// Token: 0x06002DE0 RID: 11744 RVA: 0x00023539 File Offset: 0x00021739
		public static TempListPool.TList<T> GetTList<T>(int capacity)
		{
			return TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.tSpivnHtLhgAsUfqrjRzcaaYFDHP<T>(TempListPool.Get<T>(capacity));
		}

		// Token: 0x06002DE1 RID: 11745 RVA: 0x00023546 File Offset: 0x00021746
		public static void ReturnTList<T>(TempListPool.TList<T> tList)
		{
			if (tList == null)
			{
				return;
			}
			tList.Dispose();
		}

		// Token: 0x06002DE2 RID: 11746 RVA: 0x00023552 File Offset: 0x00021752
		public static List<T> Get<T>()
		{
			return TempListPool.Get<T>(0);
		}

		// Token: 0x06002DE3 RID: 11747 RVA: 0x000A098C File Offset: 0x0009EB8C
		public static List<T> Get<T>(int capacity)
		{
			if (capacity < 0)
			{
				capacity = 0;
			}
			if (!TempListPool.lists.ContainsKey(typeof(T)))
			{
				TempListPool.lists.Add(typeof(T), new List<IList>(3));
			}
			List<IList> list = TempListPool.lists[typeof(T)];
			if (list.Count == 0)
			{
				return new List<T>((capacity == 0) ? 10 : capacity);
			}
			if (capacity > 0)
			{
				int count = list.Count;
				int num = -1;
				int index = -1;
				List<T> list2;
				for (int i = 0; i < count; i++)
				{
					list2 = (list[i] as List<T>);
					int capacity2 = list2.Capacity;
					if (capacity2 > num)
					{
						num = capacity2;
						index = i;
					}
					if (capacity2 >= capacity)
					{
						list.RemoveAt(i);
						return list2;
					}
				}
				list2 = (list[index] as List<T>);
				list.RemoveAt(index);
				return list2;
			}
			int index2 = list.Count - 1;
			IList list3 = list[index2];
			list.RemoveAt(index2);
			return list3 as List<T>;
		}

		// Token: 0x06002DE4 RID: 11748 RVA: 0x000A0A88 File Offset: 0x0009EC88
		public static void Return<T>(List<T> list)
		{
			if (list == null)
			{
				return;
			}
			list.Clear();
			List<IList> list2;
			if (!TempListPool.lists.TryGetValue(typeof(T), out list2))
			{
				list2 = new List<IList>(3);
				TempListPool.lists.Add(typeof(T), list2);
			}
			if (list2.Count >= 3)
			{
				return;
			}
			ListTools.AddIfUnique<IList>(list2, list);
		}

		// Token: 0x06002DE5 RID: 11749 RVA: 0x0002355A File Offset: 0x0002175A
		public static void Return<T>(List<T> list1, List<T> list2)
		{
			TempListPool.Return<T>(list1);
			TempListPool.Return<T>(list2);
		}

		// Token: 0x06002DE6 RID: 11750 RVA: 0x00023568 File Offset: 0x00021768
		public static void Return<T>(List<T> list1, List<T> list2, List<T> list3)
		{
			TempListPool.Return<T>(list1);
			TempListPool.Return<T>(list2);
			TempListPool.Return<T>(list3);
		}

		// Token: 0x06002DE7 RID: 11751 RVA: 0x0002357C File Offset: 0x0002177C
		public static void Clear()
		{
			TempListPool.XtShnnciTAujvHvBegttjIGAWDgM = null;
			TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.SmjEzeRCJqKCVlOYsagmEUaqQCHAA();
		}

		// Token: 0x06002DE8 RID: 11752 RVA: 0x00023589 File Offset: 0x00021789
		public static void Clear(Type listType)
		{
			if (listType == null)
			{
				throw new ArgumentNullException("listType");
			}
			if (TempListPool.XtShnnciTAujvHvBegttjIGAWDgM == null)
			{
				return;
			}
			if (!TempListPool.XtShnnciTAujvHvBegttjIGAWDgM.ContainsKey(listType))
			{
				return;
			}
			TempListPool.XtShnnciTAujvHvBegttjIGAWDgM.Remove(listType);
			TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.scMPyWGtxzOnUqJbrzfNGddfRjVx(listType);
		}

		// Token: 0x040019A8 RID: 6568
		private const int GCSbhSkvmectgCLpsxehGDOibzPhA = 3;

		// Token: 0x040019A9 RID: 6569
		private const int JiPqByJRxXmqVPlRkERseGHInWPc = 10;

		// Token: 0x040019AA RID: 6570
		private static ADictionary<Type, List<IList>> XtShnnciTAujvHvBegttjIGAWDgM;

		// Token: 0x0200048A RID: 1162
		private static class BMnKwkarEdgsBuROdHFnOBgkjdZh
		{
			// Token: 0x17000AEC RID: 2796
			// (get) Token: 0x06002DE9 RID: 11753 RVA: 0x000235C7 File Offset: 0x000217C7
			private static ADictionary<Type, List<object>> ihUASOiFqCJohKEmTugkpPqtSjjX
			{
				get
				{
					if (TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.wnqdpPPqlwIhWTlTtqUnKftqsIeV == null)
					{
						return TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.wnqdpPPqlwIhWTlTtqUnKftqsIeV = new ADictionary<Type, List<object>>();
					}
					return TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.wnqdpPPqlwIhWTlTtqUnKftqsIeV;
				}
			}

			// Token: 0x06002DEA RID: 11754 RVA: 0x000A0AE8 File Offset: 0x0009ECE8
			public static TempListPool.TList<\u0001> tSpivnHtLhgAsUfqrjRzcaaYFDHP<\u0001>(List<\u0001> A_0)
			{
				if (A_0 == null)
				{
					throw new ArgumentNullException("list");
				}
				if (!TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.ihUASOiFqCJohKEmTugkpPqtSjjX.ContainsKey(typeof(\u0001)))
				{
					TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.ihUASOiFqCJohKEmTugkpPqtSjjX.Add(typeof(\u0001), new List<object>(3));
				}
				List<object> list = TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.ihUASOiFqCJohKEmTugkpPqtSjjX[typeof(\u0001)];
				if (list.Count == 0)
				{
					TempListPool.TList<\u0001> tlist = TempListPool.TList<\u0001>.Create();
					((TempListPool.ITListSetter<\u0001>)tlist).SetList(A_0);
					return tlist;
				}
				int index = list.Count - 1;
				TempListPool.TList<\u0001> tlist2 = list[index] as TempListPool.TList<\u0001>;
				list.RemoveAt(index);
				((TempListPool.ITListSetter<\u0001>)tlist2).SetList(A_0);
				return tlist2;
			}

			// Token: 0x06002DEB RID: 11755 RVA: 0x000A0B80 File Offset: 0x0009ED80
			public static void qTFBcOfmaUjMkztiESitfJFkGXTy<\u0001>(TempListPool.TList<\u0001> A_0)
			{
				if (A_0 == null)
				{
					return;
				}
				List<object> list;
				if (!TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.ihUASOiFqCJohKEmTugkpPqtSjjX.TryGetValue(typeof(\u0001), out list))
				{
					list = new List<object>(3);
					TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.ihUASOiFqCJohKEmTugkpPqtSjjX.Add(typeof(\u0001), list);
				}
				if (list.Count >= 3)
				{
					return;
				}
				ListTools.AddIfUnique<object>(list, A_0);
			}

			// Token: 0x06002DEC RID: 11756 RVA: 0x000235E1 File Offset: 0x000217E1
			public static void SmjEzeRCJqKCVlOYsagmEUaqQCHAA()
			{
				TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.wnqdpPPqlwIhWTlTtqUnKftqsIeV = null;
			}

			// Token: 0x06002DED RID: 11757 RVA: 0x000235E9 File Offset: 0x000217E9
			public static void scMPyWGtxzOnUqJbrzfNGddfRjVx(Type A_0)
			{
				if (A_0 == null)
				{
					throw new ArgumentNullException("listType");
				}
				if (TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.wnqdpPPqlwIhWTlTtqUnKftqsIeV == null)
				{
					return;
				}
				if (!TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.wnqdpPPqlwIhWTlTtqUnKftqsIeV.ContainsKey(A_0))
				{
					return;
				}
				TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.wnqdpPPqlwIhWTlTtqUnKftqsIeV.Remove(A_0);
			}

			// Token: 0x040019AB RID: 6571
			private static ADictionary<Type, List<object>> wnqdpPPqlwIhWTlTtqUnKftqsIeV;
		}

		// Token: 0x0200048B RID: 1163
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal sealed class TList<T> : TempListPool.ITListSetter<T>, IDisposable
		{
			// Token: 0x06002DEE RID: 11758 RVA: 0x00023621 File Offset: 0x00021821
			public static TempListPool.TList<T> Create()
			{
				return new TempListPool.TList<T>();
			}

			// Token: 0x17000AED RID: 2797
			// (get) Token: 0x06002DEF RID: 11759 RVA: 0x00023628 File Offset: 0x00021828
			public List<T> list
			{
				get
				{
					if (this.zOFmCiTdSAYqjcLANyrllLTHxevN)
					{
						TempListPool.TList<T>.gAaThAmEmPITAbczaYotegusPpaw();
					}
					return this.bvUEXFfXDtwfJaYEnglupmBnjBVDA;
				}
			}

			// Token: 0x06002DF0 RID: 11760 RVA: 0x000033F4 File Offset: 0x000015F4
			private TList()
			{
			}

			// Token: 0x06002DF1 RID: 11761 RVA: 0x0002363D File Offset: 0x0002183D
			public void Dispose()
			{
				if (this.zOFmCiTdSAYqjcLANyrllLTHxevN)
				{
					return;
				}
				this.HBOcdKYdcnKASJfAwiUYlfaWEpifA();
				this.zOFmCiTdSAYqjcLANyrllLTHxevN = true;
			}

			// Token: 0x06002DF2 RID: 11762 RVA: 0x00023655 File Offset: 0x00021855
			private void HBOcdKYdcnKASJfAwiUYlfaWEpifA()
			{
				if (this.bvUEXFfXDtwfJaYEnglupmBnjBVDA != null)
				{
					TempListPool.Return<T>(this.bvUEXFfXDtwfJaYEnglupmBnjBVDA);
				}
				this.bvUEXFfXDtwfJaYEnglupmBnjBVDA = null;
				TempListPool.BMnKwkarEdgsBuROdHFnOBgkjdZh.qTFBcOfmaUjMkztiESitfJFkGXTy<T>(this);
			}

			// Token: 0x06002DF3 RID: 11763 RVA: 0x00023677 File Offset: 0x00021877
			void TempListPool.ITListSetter<!0>.ZVnfagBXsjCnUBVWXqxyqtwisisgA(List<T> A_1)
			{
				this.bvUEXFfXDtwfJaYEnglupmBnjBVDA = A_1;
				this.zOFmCiTdSAYqjcLANyrllLTHxevN = false;
			}

			// Token: 0x06002DF4 RID: 11764 RVA: 0x00023687 File Offset: 0x00021887
			private static void gAaThAmEmPITAbczaYotegusPpaw()
			{
				throw new Exception("The TList has been disposed.");
			}

			// Token: 0x06002DF5 RID: 11765 RVA: 0x00023693 File Offset: 0x00021893
			public static implicit operator List<T>(TempListPool.TList<T> obj)
			{
				return obj.list;
			}

			// Token: 0x040019AC RID: 6572
			private List<T> bvUEXFfXDtwfJaYEnglupmBnjBVDA;

			// Token: 0x040019AD RID: 6573
			private bool zOFmCiTdSAYqjcLANyrllLTHxevN;
		}

		// Token: 0x0200048C RID: 1164
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface ITListSetter<T>
		{
			// Token: 0x06002DF6 RID: 11766
			void SetList(List<T> list);
		}
	}
}
