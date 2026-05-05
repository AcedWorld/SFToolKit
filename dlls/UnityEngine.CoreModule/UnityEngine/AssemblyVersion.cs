using System;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200023A RID: 570
	[NativeHeader("Runtime/Mono/AssemblyFullName.h")]
	[RequiredByNativeCode(GenerateProxy = true)]
	internal struct AssemblyVersion
	{
		// Token: 0x06001867 RID: 6247 RVA: 0x000286DC File Offset: 0x000268DC
		public AssemblyVersion(ushort major, ushort minor, ushort build, ushort revision)
		{
			this.major = major;
			this.minor = minor;
			this.build = build;
			this.revision = revision;
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x000286FC File Offset: 0x000268FC
		public static bool operator ==(AssemblyVersion lhs, AssemblyVersion rhs)
		{
			return lhs.major == rhs.major && lhs.minor == rhs.minor && lhs.build == rhs.build && lhs.revision == rhs.revision;
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x0002874C File Offset: 0x0002694C
		public static bool operator !=(AssemblyVersion lhs, AssemblyVersion rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x00028768 File Offset: 0x00026968
		public static bool operator <(AssemblyVersion lhs, AssemblyVersion rhs)
		{
			bool flag = lhs.major != rhs.major;
			bool result;
			if (flag)
			{
				result = (lhs.major < rhs.major);
			}
			else
			{
				bool flag2 = lhs.minor != rhs.minor;
				if (flag2)
				{
					result = (lhs.minor < rhs.minor);
				}
				else
				{
					bool flag3 = lhs.build != rhs.build;
					if (flag3)
					{
						result = (lhs.build < rhs.build);
					}
					else
					{
						bool flag4 = lhs.revision != rhs.revision;
						result = (flag4 && lhs.revision < rhs.revision);
					}
				}
			}
			return result;
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x00028818 File Offset: 0x00026A18
		public static bool operator >(AssemblyVersion lhs, AssemblyVersion rhs)
		{
			bool flag = lhs.major != rhs.major;
			bool result;
			if (flag)
			{
				result = (lhs.major > rhs.major);
			}
			else
			{
				bool flag2 = lhs.minor != rhs.minor;
				if (flag2)
				{
					result = (lhs.minor > rhs.minor);
				}
				else
				{
					bool flag3 = lhs.build != rhs.build;
					if (flag3)
					{
						result = (lhs.build > rhs.build);
					}
					else
					{
						bool flag4 = lhs.revision != rhs.revision;
						result = (flag4 && lhs.revision > rhs.revision);
					}
				}
			}
			return result;
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x000288C8 File Offset: 0x00026AC8
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}.{3}", new object[]
			{
				this.major,
				this.minor,
				this.build,
				this.revision
			});
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x00028924 File Offset: 0x00026B24
		public override bool Equals(object other)
		{
			if (other is AssemblyVersion)
			{
				AssemblyVersion assemblyVersion = (AssemblyVersion)other;
				if (this.major == assemblyVersion.major && this.minor == assemblyVersion.minor && this.build == assemblyVersion.build)
				{
					return this.revision == assemblyVersion.revision;
				}
			}
			return false;
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x00028980 File Offset: 0x00026B80
		public override int GetHashCode()
		{
			return HashCode.Combine<ushort, ushort, ushort, ushort>(this.major, this.minor, this.build, this.revision);
		}

		// Token: 0x0400089E RID: 2206
		public ushort major;

		// Token: 0x0400089F RID: 2207
		public ushort minor;

		// Token: 0x040008A0 RID: 2208
		public ushort build;

		// Token: 0x040008A1 RID: 2209
		public ushort revision;
	}
}
