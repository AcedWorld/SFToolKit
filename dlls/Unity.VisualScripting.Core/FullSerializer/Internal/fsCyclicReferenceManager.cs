using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.VisualScripting.FullSerializer.Internal
{
	// Token: 0x020001AD RID: 429
	public class fsCyclicReferenceManager
	{
		// Token: 0x06000B6E RID: 2926 RVA: 0x00030B1E File Offset: 0x0002ED1E
		public void Enter()
		{
			this._depth++;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x00030B30 File Offset: 0x0002ED30
		public bool Exit()
		{
			this._depth--;
			if (this._depth == 0)
			{
				this._objectIds = new Dictionary<object, int>(fsCyclicReferenceManager.ObjectReferenceEqualityComparator.Instance);
				this._nextId = 0;
				this._marked = new Dictionary<int, object>();
			}
			if (this._depth < 0)
			{
				this._depth = 0;
				throw new InvalidOperationException("Internal Error - Mismatched Enter/Exit. Please report a bug at https://github.com/jacobdufault/fullserializer/issues with the serialization data.");
			}
			return this._depth == 0;
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x00030B99 File Offset: 0x0002ED99
		public object GetReferenceObject(int id)
		{
			if (!this._marked.ContainsKey(id))
			{
				throw new InvalidOperationException("Internal Deserialization Error - Object definition has not been encountered for object with id=" + id.ToString() + "; have you reordered or modified the serialized data? If this is an issue with an unmodified Full Serializer implementation and unmodified serialization data, please report an issue with an included test case.");
			}
			return this._marked[id];
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x00030BD1 File Offset: 0x0002EDD1
		public void AddReferenceWithId(int id, object reference)
		{
			this._marked[id] = reference;
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x00030BE0 File Offset: 0x0002EDE0
		public int GetReferenceId(object item)
		{
			int num;
			if (!this._objectIds.TryGetValue(item, out num))
			{
				int nextId = this._nextId;
				this._nextId = nextId + 1;
				num = nextId;
				this._objectIds[item] = num;
			}
			return num;
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x00030C1D File Offset: 0x0002EE1D
		public bool IsReference(object item)
		{
			return this._marked.ContainsKey(this.GetReferenceId(item));
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x00030C34 File Offset: 0x0002EE34
		public void MarkSerialized(object item)
		{
			int referenceId = this.GetReferenceId(item);
			if (this._marked.ContainsKey(referenceId))
			{
				throw new InvalidOperationException("Internal Error - " + ((item != null) ? item.ToString() : null) + " has already been marked as serialized");
			}
			this._marked[referenceId] = item;
		}

		// Token: 0x040002C2 RID: 706
		private Dictionary<object, int> _objectIds = new Dictionary<object, int>(fsCyclicReferenceManager.ObjectReferenceEqualityComparator.Instance);

		// Token: 0x040002C3 RID: 707
		private int _nextId;

		// Token: 0x040002C4 RID: 708
		private Dictionary<int, object> _marked = new Dictionary<int, object>();

		// Token: 0x040002C5 RID: 709
		private int _depth;

		// Token: 0x02000224 RID: 548
		private class ObjectReferenceEqualityComparator : IEqualityComparer<object>
		{
			// Token: 0x0600132B RID: 4907 RVA: 0x00039287 File Offset: 0x00037487
			bool IEqualityComparer<object>.Equals(object x, object y)
			{
				return x == y;
			}

			// Token: 0x0600132C RID: 4908 RVA: 0x0003928D File Offset: 0x0003748D
			int IEqualityComparer<object>.GetHashCode(object obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}

			// Token: 0x040009E5 RID: 2533
			public static readonly IEqualityComparer<object> Instance = new fsCyclicReferenceManager.ObjectReferenceEqualityComparator();
		}
	}
}
