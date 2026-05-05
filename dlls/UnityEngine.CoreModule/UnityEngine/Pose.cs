using System;

namespace UnityEngine
{
	// Token: 0x02000298 RID: 664
	[Serializable]
	public struct Pose : IEquatable<Pose>
	{
		// Token: 0x06001C1E RID: 7198 RVA: 0x0002EAE0 File Offset: 0x0002CCE0
		public Pose(Vector3 position, Quaternion rotation)
		{
			this.position = position;
			this.rotation = rotation;
		}

		// Token: 0x06001C1F RID: 7199 RVA: 0x0002EAF4 File Offset: 0x0002CCF4
		public override string ToString()
		{
			return UnityString.Format("({0}, {1})", new object[]
			{
				this.position.ToString(),
				this.rotation.ToString()
			});
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x0002EB40 File Offset: 0x0002CD40
		public string ToString(string format)
		{
			return UnityString.Format("({0}, {1})", new object[]
			{
				this.position.ToString(format),
				this.rotation.ToString(format)
			});
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x0002EB80 File Offset: 0x0002CD80
		public Pose GetTransformedBy(Pose lhs)
		{
			return new Pose
			{
				position = lhs.position + lhs.rotation * this.position,
				rotation = lhs.rotation * this.rotation
			};
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x0002EBD8 File Offset: 0x0002CDD8
		public Pose GetTransformedBy(Transform lhs)
		{
			return new Pose
			{
				position = lhs.TransformPoint(this.position),
				rotation = lhs.rotation * this.rotation
			};
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06001C23 RID: 7203 RVA: 0x0002EC20 File Offset: 0x0002CE20
		public Vector3 forward
		{
			get
			{
				return this.rotation * Vector3.forward;
			}
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06001C24 RID: 7204 RVA: 0x0002EC44 File Offset: 0x0002CE44
		public Vector3 right
		{
			get
			{
				return this.rotation * Vector3.right;
			}
		}

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06001C25 RID: 7205 RVA: 0x0002EC68 File Offset: 0x0002CE68
		public Vector3 up
		{
			get
			{
				return this.rotation * Vector3.up;
			}
		}

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06001C26 RID: 7206 RVA: 0x0002EC8C File Offset: 0x0002CE8C
		public static Pose identity
		{
			get
			{
				return Pose.k_Identity;
			}
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x0002ECA4 File Offset: 0x0002CEA4
		public override bool Equals(object obj)
		{
			bool flag = !(obj is Pose);
			return !flag && this.Equals((Pose)obj);
		}

		// Token: 0x06001C28 RID: 7208 RVA: 0x0002ECD8 File Offset: 0x0002CED8
		public bool Equals(Pose other)
		{
			return this.position.Equals(other.position) && this.rotation.Equals(other.rotation);
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x0002ED14 File Offset: 0x0002CF14
		public override int GetHashCode()
		{
			return this.position.GetHashCode() ^ this.rotation.GetHashCode() << 1;
		}

		// Token: 0x06001C2A RID: 7210 RVA: 0x0002ED4C File Offset: 0x0002CF4C
		public static bool operator ==(Pose a, Pose b)
		{
			return a.position == b.position && a.rotation.Equals(b.rotation);
		}

		// Token: 0x06001C2B RID: 7211 RVA: 0x0002ED88 File Offset: 0x0002CF88
		public static bool operator !=(Pose a, Pose b)
		{
			return !(a == b);
		}

		// Token: 0x0400096C RID: 2412
		public Vector3 position;

		// Token: 0x0400096D RID: 2413
		public Quaternion rotation;

		// Token: 0x0400096E RID: 2414
		private static readonly Pose k_Identity = new Pose(Vector3.zero, Quaternion.identity);
	}
}
