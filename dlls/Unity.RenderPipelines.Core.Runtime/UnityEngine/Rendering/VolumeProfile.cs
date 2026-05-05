using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x02000117 RID: 279
	public sealed class VolumeProfile : ScriptableObject
	{
		// Token: 0x0600085B RID: 2139 RVA: 0x00027148 File Offset: 0x00025348
		private void OnEnable()
		{
			this.components.RemoveAll((VolumeComponent x) => x == null);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00027178 File Offset: 0x00025378
		internal void OnDisable()
		{
			if (this.components == null)
			{
				return;
			}
			for (int i = 0; i < this.components.Count; i++)
			{
				if (this.components[i] != null)
				{
					this.components[i].Release();
				}
			}
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x000271C9 File Offset: 0x000253C9
		public void Reset()
		{
			this.isDirty = true;
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x000271D2 File Offset: 0x000253D2
		public T Add<T>(bool overrides = false) where T : VolumeComponent
		{
			return (T)((object)this.Add(typeof(T), overrides));
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x000271EC File Offset: 0x000253EC
		public VolumeComponent Add(Type type, bool overrides = false)
		{
			if (this.Has(type))
			{
				throw new InvalidOperationException("Component already exists in the volume");
			}
			VolumeComponent volumeComponent = (VolumeComponent)ScriptableObject.CreateInstance(type);
			volumeComponent.SetAllOverridesTo(overrides);
			this.components.Add(volumeComponent);
			this.isDirty = true;
			return volumeComponent;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00027234 File Offset: 0x00025434
		public void Remove<T>() where T : VolumeComponent
		{
			this.Remove(typeof(T));
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00027248 File Offset: 0x00025448
		public void Remove(Type type)
		{
			int num = -1;
			for (int i = 0; i < this.components.Count; i++)
			{
				if (this.components[i].GetType() == type)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				this.components.RemoveAt(num);
				this.isDirty = true;
			}
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x000272A1 File Offset: 0x000254A1
		public bool Has<T>() where T : VolumeComponent
		{
			return this.Has(typeof(T));
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x000272B4 File Offset: 0x000254B4
		public bool Has(Type type)
		{
			using (List<VolumeComponent>.Enumerator enumerator = this.components.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetType() == type)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x00027314 File Offset: 0x00025514
		public bool HasSubclassOf(Type type)
		{
			using (List<VolumeComponent>.Enumerator enumerator = this.components.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetType().IsSubclassOf(type))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x00027374 File Offset: 0x00025574
		public bool TryGet<T>(out T component) where T : VolumeComponent
		{
			return this.TryGet<T>(typeof(T), out component);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00027388 File Offset: 0x00025588
		public bool TryGet<T>(Type type, out T component) where T : VolumeComponent
		{
			component = default(T);
			foreach (VolumeComponent volumeComponent in this.components)
			{
				if (volumeComponent.GetType() == type)
				{
					component = (T)((object)volumeComponent);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x000273FC File Offset: 0x000255FC
		public bool TryGetSubclassOf<T>(Type type, out T component) where T : VolumeComponent
		{
			component = default(T);
			foreach (VolumeComponent volumeComponent in this.components)
			{
				if (volumeComponent.GetType().IsSubclassOf(type))
				{
					component = (T)((object)volumeComponent);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00027470 File Offset: 0x00025670
		public bool TryGetAllSubclassOf<T>(Type type, List<T> result) where T : VolumeComponent
		{
			int count = result.Count;
			foreach (VolumeComponent volumeComponent in this.components)
			{
				if (volumeComponent.GetType().IsSubclassOf(type))
				{
					result.Add((T)((object)volumeComponent));
				}
			}
			return count != result.Count;
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x000274EC File Offset: 0x000256EC
		public override int GetHashCode()
		{
			int num = 17;
			for (int i = 0; i < this.components.Count; i++)
			{
				num = num * 23 + this.components[i].GetHashCode();
			}
			return num;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0002752C File Offset: 0x0002572C
		internal int GetComponentListHashCode()
		{
			int num = 17;
			for (int i = 0; i < this.components.Count; i++)
			{
				num = num * 23 + this.components[i].GetType().GetHashCode();
			}
			return num;
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00027570 File Offset: 0x00025770
		internal void Sanitize()
		{
			for (int i = this.components.Count - 1; i >= 0; i--)
			{
				if (this.components[i] == null)
				{
					this.components.RemoveAt(i);
				}
			}
		}

		// Token: 0x040004F9 RID: 1273
		public List<VolumeComponent> components = new List<VolumeComponent>();

		// Token: 0x040004FA RID: 1274
		[NonSerialized]
		public bool isDirty = true;
	}
}
