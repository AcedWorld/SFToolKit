using System;

namespace Rewired
{
	// Token: 0x0200003A RID: 58
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct RewiredVersion
	{
		// Token: 0x06000214 RID: 532 RVA: 0x00003CED File Offset: 0x00001EED
		public RewiredVersion(int A_1, int A_2, int A_3, int A_4, string A_5)
		{
			this.version1 = A_1;
			this.version2 = A_2;
			this.version3 = A_3;
			this.version4 = A_4;
			this.unityVersion = A_5;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0002E398 File Offset: 0x0002C598
		public RewiredVersion(string A_1)
		{
			if (!string.IsNullOrEmpty(A_1))
			{
				string[] array = A_1.Split('.', StringSplitOptions.None);
				if (array.Length >= 4 && int.TryParse(array[0], out this.version1) && int.TryParse(array[1], out this.version2) && int.TryParse(array[2], out this.version3) && int.TryParse(array[3], out this.version4))
				{
					if (array.Length > 4)
					{
						this.unityVersion = array[4];
						return;
					}
					this.unityVersion = string.Empty;
					return;
				}
			}
			this.version1 = 0;
			this.version2 = 0;
			this.version3 = 0;
			this.version4 = 0;
			this.unityVersion = string.Empty;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0002E440 File Offset: 0x0002C640
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is RewiredVersion))
			{
				return false;
			}
			RewiredVersion b = (RewiredVersion)obj;
			return this == b;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0002E470 File Offset: 0x0002C670
		public override int GetHashCode()
		{
			return ((((17 * 29 + this.version1.GetHashCode()) * 29 + this.version2.GetHashCode()) * 29 + this.version3.GetHashCode()) * 29 + this.version4.GetHashCode()) * 29 + this.unityVersion.GetHashCode();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0002E4CC File Offset: 0x0002C6CC
		public override string ToString()
		{
			string text = string.Concat(new string[]
			{
				this.version1.ToString(),
				".",
				this.version2.ToString(),
				".",
				this.version3.ToString(),
				".",
				this.version4.ToString()
			});
			if (!string.IsNullOrEmpty(this.unityVersion))
			{
				text = text + "." + this.unityVersion;
			}
			return text;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0002E558 File Offset: 0x0002C758
		public static bool operator ==(RewiredVersion a, RewiredVersion b)
		{
			return a == b || (a.version1 == b.version1 && a.version2 == b.version2 && a.version3 == b.version3 && a.version4 == b.version4 && string.Equals(a.unityVersion, b.unityVersion));
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00003D14 File Offset: 0x00001F14
		public static bool operator !=(RewiredVersion a, RewiredVersion b)
		{
			return !(a == b);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0002E5C0 File Offset: 0x0002C7C0
		public static bool operator >(RewiredVersion a, RewiredVersion b)
		{
			if (a == b)
			{
				return false;
			}
			if (a.version1 > b.version1)
			{
				return true;
			}
			if (a.version1 < b.version1)
			{
				return false;
			}
			if (a.version2 > b.version2)
			{
				return true;
			}
			if (a.version2 < b.version2)
			{
				return false;
			}
			if (a.version3 > b.version3)
			{
				return true;
			}
			if (a.version3 < b.version3)
			{
				return false;
			}
			if (a.version4 > b.version4)
			{
				return true;
			}
			int num = a.version4;
			int num2 = b.version4;
			return false;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0002E658 File Offset: 0x0002C858
		public static bool operator <(RewiredVersion a, RewiredVersion b)
		{
			if (a == b)
			{
				return false;
			}
			if (a.version1 < b.version1)
			{
				return true;
			}
			if (a.version1 > b.version1)
			{
				return false;
			}
			if (a.version2 < b.version2)
			{
				return true;
			}
			if (a.version2 > b.version2)
			{
				return false;
			}
			if (a.version3 < b.version3)
			{
				return true;
			}
			if (a.version3 > b.version3)
			{
				return false;
			}
			if (a.version4 < b.version4)
			{
				return true;
			}
			int num = a.version4;
			int num2 = b.version4;
			return false;
		}

		// Token: 0x040000FB RID: 251
		public int version1;

		// Token: 0x040000FC RID: 252
		public int version2;

		// Token: 0x040000FD RID: 253
		public int version3;

		// Token: 0x040000FE RID: 254
		public int version4;

		// Token: 0x040000FF RID: 255
		public string unityVersion;
	}
}
