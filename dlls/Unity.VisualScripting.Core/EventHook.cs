using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000053 RID: 83
	public struct EventHook
	{
		// Token: 0x06000267 RID: 615 RVA: 0x000061C7 File Offset: 0x000043C7
		public EventHook(string name, object target = null, object tag = null)
		{
			Ensure.That("name").IsNotNull(name);
			this.name = name;
			this.target = target;
			this.tag = tag;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x000061F0 File Offset: 0x000043F0
		public override bool Equals(object obj)
		{
			if (obj is EventHook)
			{
				EventHook other = (EventHook)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00006217 File Offset: 0x00004417
		public bool Equals(EventHook other)
		{
			return this.name == other.name && object.Equals(this.target, other.target) && object.Equals(this.tag, other.tag);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00006252 File Offset: 0x00004452
		public override int GetHashCode()
		{
			return HashUtility.GetHashCode<string, object, object>(this.name, this.target, this.tag);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000626B File Offset: 0x0000446B
		public static bool operator ==(EventHook a, EventHook b)
		{
			return a.Equals(b);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00006275 File Offset: 0x00004475
		public static bool operator !=(EventHook a, EventHook b)
		{
			return !(a == b);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00006281 File Offset: 0x00004481
		public static implicit operator EventHook(string name)
		{
			return new EventHook(name, null, null);
		}

		// Token: 0x04000070 RID: 112
		public readonly string name;

		// Token: 0x04000071 RID: 113
		public readonly object target;

		// Token: 0x04000072 RID: 114
		public readonly object tag;
	}
}
