using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000212 RID: 530
	internal class SceneObjectIDMapSceneAsset : MonoBehaviour, ISerializationCallbackReceiver
	{
		// Token: 0x06000FA7 RID: 4007 RVA: 0x00079BE8 File Offset: 0x00077DE8
		public void GetALLIDsFor<TCategory>(TCategory category, List<GameObject> outGameObjects, List<int> outIndices) where TCategory : struct, IConvertible
		{
			if (outGameObjects == null)
			{
				throw new ArgumentNullException("outGameObjects");
			}
			if (outIndices == null)
			{
				throw new ArgumentNullException("outIndices");
			}
			this.CleanDestroyedGameObjects();
			int num = Convert.ToInt32(category);
			for (int i = this.m_Entries.Count - 1; i >= 0; i--)
			{
				if (this.m_Entries[i].category == num)
				{
					outIndices.Add(this.m_Entries[i].id);
					outGameObjects.Add(this.m_Entries[i].gameObject);
				}
			}
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x00079C80 File Offset: 0x00077E80
		internal bool TryGetSceneIDFor<TCategory>(GameObject gameObject, out int index, out TCategory category) where TCategory : struct, IConvertible
		{
			this.Verify();
			if (!typeof(TCategory).IsEnum)
			{
				throw new ArgumentException("'TCategory' must be an Enum type.");
			}
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			int num;
			if (this.m_IndexByGameObject.TryGetValue(gameObject, out num))
			{
				if (num < this.m_Entries.Count)
				{
					category = (TCategory)((object)this.m_Entries[num].category);
					index = this.m_Entries[num].id;
					return true;
				}
				this.m_IndexByGameObject.Remove(gameObject);
			}
			category = default(TCategory);
			index = -1;
			return false;
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x00079D30 File Offset: 0x00077F30
		internal bool TryInsert<TCategory>(GameObject gameObject, TCategory category, out int index) where TCategory : struct, IConvertible
		{
			this.Verify();
			if (!typeof(TCategory).IsEnum)
			{
				throw new ArgumentException("'TCategory' must be an Enum type.");
			}
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (gameObject.scene != base.gameObject.scene)
			{
				index = -1;
				return false;
			}
			TCategory tcategory;
			if (this.TryGetSceneIDFor<TCategory>(gameObject, out index, out tcategory))
			{
				return false;
			}
			index = this.Insert<TCategory>(gameObject, category);
			return true;
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x00079DAC File Offset: 0x00077FAC
		private int Insert<TCategory>(GameObject gameObject, TCategory category) where TCategory : struct, IConvertible
		{
			this.Verify();
			SceneObjectIDMapSceneAsset.Entry item = new SceneObjectIDMapSceneAsset.Entry
			{
				gameObject = gameObject,
				category = Convert.ToInt32(category)
			};
			int num = -1;
			if (this.m_Entries.Count > 0 && this.m_Entries[0].id != 0)
			{
				num = 0;
				item.id = 0;
			}
			else
			{
				for (int i = 0; i < this.m_Entries.Count - 1; i++)
				{
					if (this.m_Entries[i].id + 1 != this.m_Entries[i + 1].id)
					{
						num = i + 1;
						item.id = this.m_Entries[i].id + 1;
						break;
					}
				}
			}
			if (num == -1)
			{
				num = this.m_Entries.Count;
				item.id = this.m_Entries.Count;
			}
			this.m_IndexByGameObject.Add(gameObject, num);
			this.m_Entries.Insert(num, item);
			for (int j = num + 1; j < this.m_Entries.Count; j++)
			{
				this.m_IndexByGameObject[this.m_Entries[j].gameObject] = j;
			}
			return this.m_Entries[num].id;
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x00079EFA File Offset: 0x000780FA
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			this.m_RebuildRequested = true;
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x00079F03 File Offset: 0x00078103
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			this.m_CleanDestroyedGameObjectsRequested = true;
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x00079F0C File Offset: 0x0007810C
		private void CleanDestroyedGameObjects()
		{
			this.m_CleanDestroyedGameObjectsRequested = false;
			bool flag = false;
			for (int i = this.m_Entries.Count - 1; i >= 0; i--)
			{
				if (this.m_Entries[i].gameObject == null)
				{
					this.m_Entries.RemoveAt(i);
					flag = true;
				}
			}
			if (flag)
			{
				this.BuildIndex();
			}
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x00079F6C File Offset: 0x0007816C
		private void BuildIndex()
		{
			this.m_RebuildRequested = false;
			this.m_IndexByGameObject.Clear();
			for (int i = 0; i < this.m_Entries.Count; i++)
			{
				this.m_IndexByGameObject[this.m_Entries[i].gameObject] = i;
			}
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x00079FBE File Offset: 0x000781BE
		private void Verify()
		{
			if (this.m_CleanDestroyedGameObjectsRequested)
			{
				this.CleanDestroyedGameObjects();
			}
			if (this.m_RebuildRequested)
			{
				this.BuildIndex();
			}
		}

		// Token: 0x0400183A RID: 6202
		internal const string k_GameObjectName = "SceneIDMap";

		// Token: 0x0400183B RID: 6203
		[SerializeField]
		private List<SceneObjectIDMapSceneAsset.Entry> m_Entries = new List<SceneObjectIDMapSceneAsset.Entry>();

		// Token: 0x0400183C RID: 6204
		private Dictionary<GameObject, int> m_IndexByGameObject = new Dictionary<GameObject, int>();

		// Token: 0x0400183D RID: 6205
		[NonSerialized]
		private bool m_RebuildRequested;

		// Token: 0x0400183E RID: 6206
		[NonSerialized]
		private bool m_CleanDestroyedGameObjectsRequested;

		// Token: 0x02000449 RID: 1097
		[Serializable]
		private struct Entry
		{
			// Token: 0x040029A2 RID: 10658
			public int id;

			// Token: 0x040029A3 RID: 10659
			public int category;

			// Token: 0x040029A4 RID: 10660
			public GameObject gameObject;
		}
	}
}
