using System;

namespace UnityEngine.Playables
{
	// Token: 0x020004A9 RID: 1193
	public struct ScriptPlayable<T> : IPlayable, IEquatable<ScriptPlayable<T>> where T : class, IPlayableBehaviour, new()
	{
		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x060029B5 RID: 10677 RVA: 0x00046A44 File Offset: 0x00044C44
		public static ScriptPlayable<T> Null
		{
			get
			{
				return ScriptPlayable<T>.m_NullPlayable;
			}
		}

		// Token: 0x060029B6 RID: 10678 RVA: 0x00046A5C File Offset: 0x00044C5C
		public static ScriptPlayable<T> Create(PlayableGraph graph, int inputCount = 0)
		{
			PlayableHandle handle = ScriptPlayable<T>.CreateHandle(graph, default(T), inputCount);
			return new ScriptPlayable<T>(handle);
		}

		// Token: 0x060029B7 RID: 10679 RVA: 0x00046A88 File Offset: 0x00044C88
		public static ScriptPlayable<T> Create(PlayableGraph graph, T template, int inputCount = 0)
		{
			PlayableHandle handle = ScriptPlayable<T>.CreateHandle(graph, template, inputCount);
			return new ScriptPlayable<T>(handle);
		}

		// Token: 0x060029B8 RID: 10680 RVA: 0x00046AAC File Offset: 0x00044CAC
		private static PlayableHandle CreateHandle(PlayableGraph graph, T template, int inputCount)
		{
			bool flag = template == null;
			object obj;
			if (flag)
			{
				obj = ScriptPlayable<T>.CreateScriptInstance();
			}
			else
			{
				obj = ScriptPlayable<T>.CloneScriptInstance(template);
			}
			bool flag2 = obj == null;
			PlayableHandle result;
			if (flag2)
			{
				string str = "Could not create a ScriptPlayable of Type ";
				Type typeFromHandle = typeof(T);
				Debug.LogError(str + ((typeFromHandle != null) ? typeFromHandle.ToString() : null));
				result = PlayableHandle.Null;
			}
			else
			{
				PlayableHandle playableHandle = graph.CreatePlayableHandle();
				bool flag3 = !playableHandle.IsValid();
				if (flag3)
				{
					result = PlayableHandle.Null;
				}
				else
				{
					playableHandle.SetInputCount(inputCount);
					playableHandle.SetScriptInstance(obj);
					result = playableHandle;
				}
			}
			return result;
		}

		// Token: 0x060029B9 RID: 10681 RVA: 0x00046B54 File Offset: 0x00044D54
		private static object CreateScriptInstance()
		{
			bool flag = typeof(ScriptableObject).IsAssignableFrom(typeof(T));
			IPlayableBehaviour result;
			if (flag)
			{
				result = (ScriptableObject.CreateInstance(typeof(T)) as T);
			}
			else
			{
				result = Activator.CreateInstance<T>();
			}
			return result;
		}

		// Token: 0x060029BA RID: 10682 RVA: 0x00046BB4 File Offset: 0x00044DB4
		private static object CloneScriptInstance(IPlayableBehaviour source)
		{
			Object @object = source as Object;
			bool flag = @object != null;
			object result;
			if (flag)
			{
				result = ScriptPlayable<T>.CloneScriptInstanceFromEngineObject(@object);
			}
			else
			{
				ICloneable cloneable = source as ICloneable;
				bool flag2 = cloneable != null;
				if (flag2)
				{
					result = ScriptPlayable<T>.CloneScriptInstanceFromIClonable(cloneable);
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x060029BB RID: 10683 RVA: 0x00046BFC File Offset: 0x00044DFC
		private static object CloneScriptInstanceFromEngineObject(Object source)
		{
			Object @object = Object.Instantiate(source);
			bool flag = @object != null;
			if (flag)
			{
				@object.hideFlags |= HideFlags.DontSave;
			}
			return @object;
		}

		// Token: 0x060029BC RID: 10684 RVA: 0x00046C34 File Offset: 0x00044E34
		private static object CloneScriptInstanceFromIClonable(ICloneable source)
		{
			return source.Clone();
		}

		// Token: 0x060029BD RID: 10685 RVA: 0x00046C4C File Offset: 0x00044E4C
		internal ScriptPlayable(PlayableHandle handle)
		{
			bool flag = handle.IsValid();
			if (flag)
			{
				bool flag2 = !typeof(T).IsAssignableFrom(handle.GetPlayableType());
				if (flag2)
				{
					throw new InvalidCastException(string.Format("Incompatible handle: Trying to assign a playable data of type `{0}` that is not compatible with the PlayableBehaviour of type `{1}`.", handle.GetPlayableType(), typeof(T)));
				}
			}
			this.m_Handle = handle;
		}

		// Token: 0x060029BE RID: 10686 RVA: 0x00046CAC File Offset: 0x00044EAC
		public PlayableHandle GetHandle()
		{
			return this.m_Handle;
		}

		// Token: 0x060029BF RID: 10687 RVA: 0x00046CC4 File Offset: 0x00044EC4
		public T GetBehaviour()
		{
			return this.m_Handle.GetObject<T>();
		}

		// Token: 0x060029C0 RID: 10688 RVA: 0x00046CE4 File Offset: 0x00044EE4
		public static implicit operator Playable(ScriptPlayable<T> playable)
		{
			return new Playable(playable.GetHandle());
		}

		// Token: 0x060029C1 RID: 10689 RVA: 0x00046D04 File Offset: 0x00044F04
		public static explicit operator ScriptPlayable<T>(Playable playable)
		{
			return new ScriptPlayable<T>(playable.GetHandle());
		}

		// Token: 0x060029C2 RID: 10690 RVA: 0x00046D24 File Offset: 0x00044F24
		public bool Equals(ScriptPlayable<T> other)
		{
			return this.GetHandle() == other.GetHandle();
		}

		// Token: 0x04000F82 RID: 3970
		private PlayableHandle m_Handle;

		// Token: 0x04000F83 RID: 3971
		private static readonly ScriptPlayable<T> m_NullPlayable = new ScriptPlayable<T>(PlayableHandle.Null);
	}
}
