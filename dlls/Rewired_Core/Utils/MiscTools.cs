using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils
{
	// Token: 0x02000495 RID: 1173
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class MiscTools
	{
		// Token: 0x06002F0E RID: 12046 RVA: 0x00023F2C File Offset: 0x0002212C
		public static object Clone(object obj)
		{
			if (!(obj is ICloneable))
			{
				return null;
			}
			return (obj as ICloneable).Clone();
		}

		// Token: 0x06002F0F RID: 12047 RVA: 0x000A3BC8 File Offset: 0x000A1DC8
		public static T Clone<T>(T obj) where T : class, ICloneable
		{
			if (obj == null)
			{
				return default(T);
			}
			return obj.Clone() as T;
		}

		// Token: 0x06002F10 RID: 12048 RVA: 0x000A3BFC File Offset: 0x000A1DFC
		public static T DeepClone<T>(T obj) where T : class, IDeepCloneable
		{
			if (obj == null)
			{
				return default(T);
			}
			return obj.DeepClone() as T;
		}

		// Token: 0x06002F11 RID: 12049 RVA: 0x00023F43 File Offset: 0x00022143
		public static T DeepClone<T>(T obj, bool createIfNull) where T : class, IDeepCloneable, new()
		{
			if (obj == null)
			{
				return Activator.CreateInstance<T>();
			}
			return obj.DeepClone() as T;
		}

		// Token: 0x06002F12 RID: 12050 RVA: 0x000A3C30 File Offset: 0x000A1E30
		public static T[] DeepClone<T>(T[] obj) where T : class, IDeepCloneable
		{
			if (obj == null)
			{
				return null;
			}
			T[] array = new T[obj.Length];
			for (int i = 0; i < obj.Length; i++)
			{
				array[i] = MiscTools.DeepClone<T>(obj[i]);
			}
			return array;
		}

		// Token: 0x06002F13 RID: 12051 RVA: 0x000A3C70 File Offset: 0x000A1E70
		public static List<T> DeepClone<T>(List<T> obj) where T : class, IDeepCloneable
		{
			if (obj == null)
			{
				return null;
			}
			List<T> list = new List<T>(obj.Count);
			for (int i = 0; i < obj.Count; i++)
			{
				list.Add(MiscTools.DeepClone<T>(obj[i]));
			}
			return list;
		}

		// Token: 0x06002F14 RID: 12052 RVA: 0x000A3CB4 File Offset: 0x000A1EB4
		public static Dictionary<TKey, TValue> DeepClone<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TValue : class, IDeepCloneable
		{
			if (dictionary == null)
			{
				return null;
			}
			Dictionary<TKey, TValue> dictionary2 = new Dictionary<TKey, TValue>();
			foreach (KeyValuePair<TKey, TValue> keyValuePair in dictionary)
			{
				dictionary2.Add(keyValuePair.Key, MiscTools.DeepClone<TValue>(keyValuePair.Value));
			}
			return dictionary2;
		}

		// Token: 0x06002F15 RID: 12053 RVA: 0x000A3D20 File Offset: 0x000A1F20
		public static Guid CreateGuidHashSHA256(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return Guid.Empty;
			}
			Array sourceArray = new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(text));
			byte[] array = new byte[16];
			Array.Copy(sourceArray, array, 16);
			return new Guid(array);
		}

		// Token: 0x06002F16 RID: 12054 RVA: 0x000A3D68 File Offset: 0x000A1F68
		public static Guid CreateGuidHashSHA1(string text)
		{
			Guid result;
			using (SHA1 sha = SHA1.Create())
			{
				Array sourceArray = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
				byte[] array = new byte[16];
				Array.Copy(sourceArray, array, 16);
				result = new Guid(array);
			}
			return result;
		}

		// Token: 0x06002F17 RID: 12055 RVA: 0x000A3DC0 File Offset: 0x000A1FC0
		public static Bytes20 HashSHA1(string text)
		{
			Bytes20 result;
			if (string.IsNullOrEmpty(text))
			{
				result = default(Bytes20);
				return result;
			}
			using (SHA1 sha = SHA1.Create())
			{
				result = new Bytes20(sha.ComputeHash(Encoding.UTF8.GetBytes(text)));
			}
			return result;
		}

		// Token: 0x06002F18 RID: 12056 RVA: 0x000A3E1C File Offset: 0x000A201C
		public static Guid CreateHIDProductGuid(int vendorId, int productId)
		{
			return new Guid(((ushort)productId).ToString("x4") + ((ushort)vendorId).ToString("x4") + "-0000-0000-0000-504944564944");
		}

		// Token: 0x06002F19 RID: 12057 RVA: 0x00023F68 File Offset: 0x00022168
		public static uint Tick(uint counter)
		{
			if (counter == MiscTools.JCbuDqGLFduIsiHJcKldyGogercDA)
			{
				counter = MiscTools.DkQvnjgyRtFXTIruKbksIBowyiXR;
			}
			else
			{
				counter += 1U;
			}
			return counter;
		}

		// Token: 0x06002F1A RID: 12058 RVA: 0x00023F81 File Offset: 0x00022181
		public static int Tick(int counter)
		{
			if (counter == MiscTools.nWfYVVSUEqEOnmdzhSGcWJgfLbdL)
			{
				counter = MiscTools.BOHCUIfZRGUDHYZAjALsIslQsEOP;
			}
			else
			{
				counter++;
			}
			return counter;
		}

		// Token: 0x06002F1B RID: 12059 RVA: 0x00023F9A File Offset: 0x0002219A
		public static uint TickPrev(uint counter)
		{
			if (counter == MiscTools.DkQvnjgyRtFXTIruKbksIBowyiXR)
			{
				counter = MiscTools.JCbuDqGLFduIsiHJcKldyGogercDA;
			}
			else
			{
				counter -= 1U;
			}
			return counter;
		}

		// Token: 0x06002F1C RID: 12060 RVA: 0x00023FB3 File Offset: 0x000221B3
		public static int TickPrev(int counter)
		{
			if (counter <= MiscTools.pQdTQxdihhSUuNLDhxRQFpgawbWg)
			{
				return MiscTools.nWfYVVSUEqEOnmdzhSGcWJgfLbdL;
			}
			if (counter == MiscTools.BOHCUIfZRGUDHYZAjALsIslQsEOP)
			{
				counter = MiscTools.nWfYVVSUEqEOnmdzhSGcWJgfLbdL;
			}
			else
			{
				counter--;
			}
			return counter;
		}

		// Token: 0x06002F1D RID: 12061 RVA: 0x00023FDA File Offset: 0x000221DA
		public static bool IsTickValid(uint tick)
		{
			return tick != MiscTools.eHGnQeYeJlaUmqTOWAEtdTiKZGOsA;
		}

		// Token: 0x06002F1E RID: 12062 RVA: 0x00023FE7 File Offset: 0x000221E7
		public static bool IsTickValid(int tick)
		{
			return tick > MiscTools.pQdTQxdihhSUuNLDhxRQFpgawbWg;
		}

		// Token: 0x06002F1F RID: 12063 RVA: 0x00023FF1 File Offset: 0x000221F1
		public static bool IsTickNewer(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				return false;
			}
			if (tick1 == MiscTools.eHGnQeYeJlaUmqTOWAEtdTiKZGOsA)
			{
				return false;
			}
			if (tick2 == MiscTools.eHGnQeYeJlaUmqTOWAEtdTiKZGOsA)
			{
				return true;
			}
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 2147483648U)
				{
					return false;
				}
			}
			else if (tick1 > tick2 && tick1 - tick2 > 2147483648U)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06002F20 RID: 12064 RVA: 0x0002402E File Offset: 0x0002222E
		public static bool IsTickNewer(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return false;
			}
			if (tick1 <= MiscTools.pQdTQxdihhSUuNLDhxRQFpgawbWg)
			{
				return false;
			}
			if (tick2 <= MiscTools.pQdTQxdihhSUuNLDhxRQFpgawbWg)
			{
				return true;
			}
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 1073741823)
				{
					return false;
				}
			}
			else if (tick1 > tick2 && tick1 - tick2 > 1073741823)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06002F21 RID: 12065 RVA: 0x0002406B File Offset: 0x0002226B
		public static bool IsTickNewerOrEqualTo(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				return true;
			}
			if (tick1 == MiscTools.eHGnQeYeJlaUmqTOWAEtdTiKZGOsA)
			{
				return false;
			}
			if (tick2 == MiscTools.eHGnQeYeJlaUmqTOWAEtdTiKZGOsA)
			{
				return true;
			}
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 2147483648U)
				{
					return false;
				}
			}
			else if (tick1 > tick2 && tick1 - tick2 > 2147483648U)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06002F22 RID: 12066 RVA: 0x000240A8 File Offset: 0x000222A8
		public static bool IsTickNewerOrEqualTo(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return true;
			}
			if (tick1 <= MiscTools.pQdTQxdihhSUuNLDhxRQFpgawbWg)
			{
				return false;
			}
			if (tick2 <= MiscTools.pQdTQxdihhSUuNLDhxRQFpgawbWg)
			{
				return true;
			}
			if (tick1 < tick2)
			{
				if (tick2 - tick1 < 1073741823)
				{
					return false;
				}
			}
			else if (tick1 > tick2 && tick1 - tick2 > 1073741823)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06002F23 RID: 12067 RVA: 0x000A3E58 File Offset: 0x000A2058
		public static long TickDifference(uint tick1, uint tick2)
		{
			if (tick1 == tick2)
			{
				return 0L;
			}
			if (tick1 == MiscTools.eHGnQeYeJlaUmqTOWAEtdTiKZGOsA)
			{
				return 0L;
			}
			if (tick2 == MiscTools.eHGnQeYeJlaUmqTOWAEtdTiKZGOsA)
			{
				return 0L;
			}
			uint num;
			uint num2;
			if (tick1 < tick2)
			{
				num = tick2;
				num2 = tick1;
			}
			else
			{
				num = tick1;
				num2 = tick2;
			}
			if (num - num2 < 2147483648U)
			{
				return (long)((ulong)tick1 - (ulong)tick2);
			}
			uint num3 = MiscTools.JCbuDqGLFduIsiHJcKldyGogercDA - num + num2;
			uint dkQvnjgyRtFXTIruKbksIBowyiXR = MiscTools.DkQvnjgyRtFXTIruKbksIBowyiXR;
			uint num4 = num3 - dkQvnjgyRtFXTIruKbksIBowyiXR;
			if (tick1 >= tick2)
			{
				return (long)(-(long)((ulong)num4));
			}
			return (long)((ulong)num4);
		}

		// Token: 0x06002F24 RID: 12068 RVA: 0x000A3EBC File Offset: 0x000A20BC
		public static int TickDifference(int tick1, int tick2)
		{
			if (tick1 == tick2)
			{
				return 0;
			}
			if (tick1 <= MiscTools.pQdTQxdihhSUuNLDhxRQFpgawbWg)
			{
				return 0;
			}
			if (tick2 <= MiscTools.pQdTQxdihhSUuNLDhxRQFpgawbWg)
			{
				return 0;
			}
			int num;
			int num2;
			if (tick1 < tick2)
			{
				num = tick2;
				num2 = tick1;
			}
			else
			{
				num = tick1;
				num2 = tick2;
			}
			if (num - num2 < 1073741823)
			{
				return tick1 - tick2;
			}
			int num3 = MiscTools.nWfYVVSUEqEOnmdzhSGcWJgfLbdL - num + num2;
			int bohcuifZRGUDHYZAjALsIslQsEOP = MiscTools.BOHCUIfZRGUDHYZAjALsIslQsEOP;
			int num4 = num3 - bohcuifZRGUDHYZAjALsIslQsEOP;
			if (tick1 >= tick2)
			{
				return -num4;
			}
			return num4;
		}

		// Token: 0x06002F25 RID: 12069 RVA: 0x000A3F1C File Offset: 0x000A211C
		public static void Swap<T>(ref T a, ref T b)
		{
			T t = a;
			a = b;
			b = t;
		}

		// Token: 0x06002F26 RID: 12070 RVA: 0x000A3F44 File Offset: 0x000A2144
		public static long ToLongUnchecked(object value)
		{
			if (value is int)
			{
				return (long)((int)value);
			}
			if (value is uint)
			{
				return (long)((ulong)((uint)value));
			}
			if (value is byte)
			{
				return (long)((ulong)((byte)value));
			}
			if (value is sbyte)
			{
				return (long)((sbyte)value);
			}
			if (value is short)
			{
				return (long)((short)value);
			}
			if (value is ushort)
			{
				return (long)((ulong)((ushort)value));
			}
			if (value is long)
			{
				return (long)value;
			}
			if (value is ulong)
			{
				return (long)((ulong)value);
			}
			if (value is float)
			{
				return (long)((float)value);
			}
			if (value is double)
			{
				return (long)((double)value);
			}
			if (value is decimal)
			{
				return (long)((decimal)value);
			}
			throw new ArgumentException("value must be an integral type (excluding char).");
		}

		// Token: 0x06002F27 RID: 12071 RVA: 0x000A4010 File Offset: 0x000A2210
		public static bool IsValidGuid(string guid)
		{
			bool result;
			try
			{
				new Guid(guid);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x040019B8 RID: 6584
		private static uint eHGnQeYeJlaUmqTOWAEtdTiKZGOsA = 0U;

		// Token: 0x040019B9 RID: 6585
		private static uint DkQvnjgyRtFXTIruKbksIBowyiXR = 1U;

		// Token: 0x040019BA RID: 6586
		private static uint JCbuDqGLFduIsiHJcKldyGogercDA = uint.MaxValue;

		// Token: 0x040019BB RID: 6587
		private static int BOHCUIfZRGUDHYZAjALsIslQsEOP = 0;

		// Token: 0x040019BC RID: 6588
		private static int nWfYVVSUEqEOnmdzhSGcWJgfLbdL = int.MaxValue;

		// Token: 0x040019BD RID: 6589
		private static int pQdTQxdihhSUuNLDhxRQFpgawbWg = -1;
	}
}
