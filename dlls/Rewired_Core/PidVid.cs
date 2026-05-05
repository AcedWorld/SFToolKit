using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Rewired.Utils;

namespace Rewired
{
	// Token: 0x0200003B RID: 59
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct PidVid : IEquatable<PidVid>
	{
		// Token: 0x0600021D RID: 541 RVA: 0x00003D20 File Offset: 0x00001F20
		public PidVid(ushort A_1, ushort A_2)
		{
			this.productId = A_1;
			this.vendorId = A_2;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0002E6F0 File Offset: 0x0002C8F0
		public PidVid(string A_1)
		{
			if (string.IsNullOrEmpty(PidVid.hUtTbGNnpIALphgjKDxGMXjgoJfj(A_1)))
			{
				this.productId = 0;
				this.vendorId = 0;
				return;
			}
			try
			{
				this.productId = ushort.Parse(A_1.Substring(0, 4), NumberStyles.AllowHexSpecifier);
				this.vendorId = ushort.Parse(A_1.Substring(4, 4), NumberStyles.AllowHexSpecifier);
			}
			catch
			{
				this.productId = 0;
				this.vendorId = 0;
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00003D30 File Offset: 0x00001F30
		public PidVid(Guid A_1)
		{
			this = new PidVid(A_1.ToString().Substring(0, 8));
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000220 RID: 544 RVA: 0x00003D4C File Offset: 0x00001F4C
		public bool isZero
		{
			get
			{
				return this.vendorId == 0 && this.productId == 0;
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00003D61 File Offset: 0x00001F61
		public bool Equals(string pidVid)
		{
			return this.BieDBfAzZGrdGUENZAhhPdqIrPCl(PidVid.hUtTbGNnpIALphgjKDxGMXjgoJfj(pidVid));
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00003D6F File Offset: 0x00001F6F
		public Guid ToProductGuid()
		{
			return MiscTools.CreateHIDProductGuid((int)this.vendorId, (int)this.productId);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0002E770 File Offset: 0x0002C970
		private bool BieDBfAzZGrdGUENZAhhPdqIrPCl(string A_1)
		{
			if (string.IsNullOrEmpty(A_1) || A_1.Length < 8)
			{
				return false;
			}
			bool result;
			try
			{
				if (this.productId != ushort.Parse(A_1.Substring(0, 4), NumberStyles.AllowHexSpecifier))
				{
					result = false;
				}
				else
				{
					result = (this.vendorId == ushort.Parse(A_1.Substring(4, 4), NumberStyles.AllowHexSpecifier));
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0002E7E4 File Offset: 0x0002C9E4
		public override bool Equals(object obj)
		{
			if (!(obj is PidVid))
			{
				return false;
			}
			PidVid pidVid = (PidVid)obj;
			return pidVid.vendorId == this.vendorId && pidVid.productId == this.productId;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00003D82 File Offset: 0x00001F82
		public override int GetHashCode()
		{
			return (17 * 29 + this.vendorId.GetHashCode()) * 29 + this.productId.GetHashCode();
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00003DA4 File Offset: 0x00001FA4
		public bool Equals(PidVid other)
		{
			return this.vendorId == other.vendorId && this.productId == other.productId;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00003DA4 File Offset: 0x00001FA4
		public static bool operator ==(PidVid x, PidVid y)
		{
			return x.vendorId == y.vendorId && x.productId == y.productId;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00003DC4 File Offset: 0x00001FC4
		public static bool operator !=(PidVid x, PidVid y)
		{
			return !(x == y);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00003DD0 File Offset: 0x00001FD0
		public override string ToString()
		{
			return this.productId.ToString("x4") + this.vendorId.ToString("x4");
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0002E820 File Offset: 0x0002CA20
		public static bool ArrayContains(string[] pidVids, ref PidVid vidPid)
		{
			if (pidVids == null)
			{
				return false;
			}
			for (int i = 0; i < pidVids.Length; i++)
			{
				if (vidPid.Equals(pidVids[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0002E850 File Offset: 0x0002CA50
		private static string hUtTbGNnpIALphgjKDxGMXjgoJfj(string A_0)
		{
			if (string.IsNullOrEmpty(A_0))
			{
				return null;
			}
			if (Regex.IsMatch(A_0, "[^a-fA-F0-9]"))
			{
				A_0 = Regex.Replace(A_0, "[^a-fA-F0-9]", "");
			}
			if (string.IsNullOrEmpty(A_0))
			{
				return null;
			}
			if (A_0.Length < 8)
			{
				return null;
			}
			return A_0;
		}

		// Token: 0x04000100 RID: 256
		private const string tVdbRObHbcivFEehxVUxAFuRTfhV = "[^a-fA-F0-9]";

		// Token: 0x04000101 RID: 257
		public ushort productId;

		// Token: 0x04000102 RID: 258
		public ushort vendorId;
	}
}
