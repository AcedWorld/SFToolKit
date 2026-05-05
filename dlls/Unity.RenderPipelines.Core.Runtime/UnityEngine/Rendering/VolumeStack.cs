using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
	// Token: 0x02000118 RID: 280
	public sealed class VolumeStack : IDisposable
	{
		// Token: 0x0600086D RID: 2157 RVA: 0x000275CF File Offset: 0x000257CF
		internal VolumeStack()
		{
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x000275EC File Offset: 0x000257EC
		internal void Clear()
		{
			foreach (KeyValuePair<Type, VolumeComponent> keyValuePair in this.components)
			{
				CoreUtils.Destroy(keyValuePair.Value);
			}
			this.components.Clear();
			if (this.defaultParameters != null)
			{
				ValueTuple<VolumeParameter, VolumeParameter>[] array = this.defaultParameters;
				for (int i = 0; i < array.Length; i++)
				{
					VolumeParameter item = array[i].Item2;
					if (item != null)
					{
						item.Release();
					}
				}
				this.defaultParameters = null;
			}
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x0002768C File Offset: 0x0002588C
		internal void Reload(List<VolumeComponent> componentDefaultStates)
		{
			this.Clear();
			this.requiresReset = true;
			List<ValueTuple<VolumeParameter, VolumeParameter>> list = new List<ValueTuple<VolumeParameter, VolumeParameter>>();
			foreach (VolumeComponent volumeComponent in componentDefaultStates)
			{
				Type type = volumeComponent.GetType();
				VolumeComponent volumeComponent2 = (VolumeComponent)ScriptableObject.CreateInstance(type);
				this.components.Add(type, volumeComponent2);
				for (int i = 0; i < volumeComponent2.parameterList.Count; i++)
				{
					list.Add(new ValueTuple<VolumeParameter, VolumeParameter>
					{
						Item1 = volumeComponent2.parameters[i],
						Item2 = (volumeComponent.parameterList[i].Clone() as VolumeParameter)
					});
				}
			}
			this.defaultParameters = list.ToArray();
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00027778 File Offset: 0x00025978
		public T GetComponent<T>() where T : VolumeComponent
		{
			return (T)((object)this.GetComponent(typeof(T)));
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00027790 File Offset: 0x00025990
		public VolumeComponent GetComponent(Type type)
		{
			VolumeComponent result;
			this.components.TryGetValue(type, out result);
			return result;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x000277AD File Offset: 0x000259AD
		public void Dispose()
		{
			this.Clear();
		}

		// Token: 0x040004FB RID: 1275
		internal readonly Dictionary<Type, VolumeComponent> components = new Dictionary<Type, VolumeComponent>();

		// Token: 0x040004FC RID: 1276
		[TupleElementNames(new string[]
		{
			"parameter",
			"defaultValue"
		})]
		internal ValueTuple<VolumeParameter, VolumeParameter>[] defaultParameters;

		// Token: 0x040004FD RID: 1277
		internal bool requiresReset = true;
	}
}
