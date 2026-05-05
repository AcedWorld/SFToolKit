using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020002B5 RID: 693
	internal class TextureRegistry
	{
		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06001413 RID: 5139 RVA: 0x00047519 File Offset: 0x00045719
		public static TextureRegistry instance { get; } = new TextureRegistry();

		// Token: 0x06001414 RID: 5140 RVA: 0x00047520 File Offset: 0x00045720
		public Texture GetTexture(TextureId id)
		{
			bool flag = id.index < 0 || id.index >= this.m_Textures.Count;
			Texture result;
			if (flag)
			{
				Debug.LogError(string.Format("Attempted to get an invalid texture (index={0}).", id.index));
				result = null;
			}
			else
			{
				TextureRegistry.TextureInfo textureInfo = this.m_Textures[id.index];
				bool flag2 = textureInfo.refCount < 1;
				if (flag2)
				{
					Debug.LogError(string.Format("Attempted to get a texture (index={0}) that is not allocated.", id.index));
					result = null;
				}
				else
				{
					result = textureInfo.texture;
				}
			}
			return result;
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x000475C4 File Offset: 0x000457C4
		public TextureId AllocAndAcquireDynamic()
		{
			return this.AllocAndAcquire(null, true);
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x000475E0 File Offset: 0x000457E0
		public void UpdateDynamic(TextureId id, Texture texture)
		{
			bool flag = id.index < 0 || id.index >= this.m_Textures.Count;
			if (flag)
			{
				Debug.LogError(string.Format("Attempted to update an invalid dynamic texture (index={0}).", id.index));
			}
			else
			{
				TextureRegistry.TextureInfo textureInfo = this.m_Textures[id.index];
				bool flag2 = !textureInfo.dynamic;
				if (flag2)
				{
					Debug.LogError(string.Format("Attempted to update a texture (index={0}) that is not dynamic.", id.index));
				}
				else
				{
					bool flag3 = textureInfo.refCount < 1;
					if (flag3)
					{
						Debug.LogError(string.Format("Attempted to update a dynamic texture (index={0}) that is not allocated.", id.index));
					}
					else
					{
						textureInfo.texture = texture;
						this.m_Textures[id.index] = textureInfo;
					}
				}
			}
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x000476C0 File Offset: 0x000458C0
		private TextureId AllocAndAcquire(Texture texture, bool dynamic)
		{
			TextureRegistry.TextureInfo textureInfo = new TextureRegistry.TextureInfo
			{
				texture = texture,
				dynamic = dynamic,
				refCount = 1
			};
			bool flag = this.m_FreeIds.Count > 0;
			TextureId textureId;
			if (flag)
			{
				textureId = this.m_FreeIds.Pop();
				this.m_Textures[textureId.index] = textureInfo;
			}
			else
			{
				bool flag2 = this.m_Textures.Count == 2048;
				if (flag2)
				{
					Debug.LogError(string.Format("Failed to allocate a {0} because the limit of {1} textures is reached.", "TextureId", 2048));
					return TextureId.invalid;
				}
				textureId = new TextureId(this.m_Textures.Count);
				this.m_Textures.Add(textureInfo);
			}
			bool flag3 = !dynamic;
			if (flag3)
			{
				this.m_TextureToId[texture] = textureId;
			}
			return textureId;
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x000477A8 File Offset: 0x000459A8
		public TextureId Acquire(Texture tex)
		{
			TextureId textureId;
			bool flag = this.m_TextureToId.TryGetValue(tex, out textureId);
			TextureId result;
			if (flag)
			{
				TextureRegistry.TextureInfo textureInfo = this.m_Textures[textureId.index];
				Debug.Assert(textureInfo.refCount > 0);
				Debug.Assert(!textureInfo.dynamic);
				textureInfo.refCount++;
				this.m_Textures[textureId.index] = textureInfo;
				result = textureId;
			}
			else
			{
				result = this.AllocAndAcquire(tex, false);
			}
			return result;
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x0004782C File Offset: 0x00045A2C
		public void Acquire(TextureId id)
		{
			bool flag = id.index < 0 || id.index >= this.m_Textures.Count;
			if (flag)
			{
				Debug.LogError(string.Format("Attempted to acquire an invalid texture (index={0}).", id.index));
			}
			else
			{
				TextureRegistry.TextureInfo textureInfo = this.m_Textures[id.index];
				bool flag2 = textureInfo.refCount < 1;
				if (flag2)
				{
					Debug.LogError(string.Format("Attempted to acquire a texture (index={0}) that is not allocated.", id.index));
				}
				else
				{
					textureInfo.refCount++;
					this.m_Textures[id.index] = textureInfo;
				}
			}
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x000478E0 File Offset: 0x00045AE0
		public void Release(TextureId id)
		{
			bool flag = id.index < 0 || id.index >= this.m_Textures.Count;
			if (flag)
			{
				Debug.LogError(string.Format("Attempted to release an invalid texture (index={0}).", id.index));
			}
			else
			{
				TextureRegistry.TextureInfo textureInfo = this.m_Textures[id.index];
				bool flag2 = textureInfo.refCount < 1;
				if (flag2)
				{
					Debug.LogError(string.Format("Attempted to release a texture (index={0}) that is not allocated.", id.index));
				}
				else
				{
					textureInfo.refCount--;
					bool flag3 = textureInfo.refCount == 0;
					if (flag3)
					{
						bool flag4 = !textureInfo.dynamic;
						if (flag4)
						{
							this.m_TextureToId.Remove(textureInfo.texture);
						}
						textureInfo.texture = null;
						textureInfo.dynamic = false;
						this.m_FreeIds.Push(id);
					}
					this.m_Textures[id.index] = textureInfo;
				}
			}
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x000479E4 File Offset: 0x00045BE4
		public TextureId TextureToId(Texture texture)
		{
			TextureId textureId;
			bool flag = this.m_TextureToId.TryGetValue(texture, out textureId);
			TextureId result;
			if (flag)
			{
				result = textureId;
			}
			else
			{
				result = TextureId.invalid;
			}
			return result;
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x00047A14 File Offset: 0x00045C14
		public TextureRegistry.Statistics GatherStatistics()
		{
			TextureRegistry.Statistics statistics = default(TextureRegistry.Statistics);
			statistics.freeIdsCount = this.m_FreeIds.Count;
			statistics.createdIdsCount = this.m_Textures.Count;
			statistics.allocatedIdsTotalCount = this.m_Textures.Count - this.m_FreeIds.Count;
			statistics.allocatedIdsDynamicCount = statistics.allocatedIdsTotalCount - this.m_TextureToId.Count;
			statistics.allocatedIdsStaticCount = statistics.allocatedIdsTotalCount - statistics.allocatedIdsDynamicCount;
			statistics.availableIdsCount = 2048 - statistics.allocatedIdsTotalCount;
			return statistics;
		}

		// Token: 0x04000950 RID: 2384
		private List<TextureRegistry.TextureInfo> m_Textures = new List<TextureRegistry.TextureInfo>(128);

		// Token: 0x04000951 RID: 2385
		private Dictionary<Texture, TextureId> m_TextureToId = new Dictionary<Texture, TextureId>(128);

		// Token: 0x04000952 RID: 2386
		private Stack<TextureId> m_FreeIds = new Stack<TextureId>();

		// Token: 0x04000953 RID: 2387
		internal const int maxTextures = 2048;

		// Token: 0x020002B6 RID: 694
		private struct TextureInfo
		{
			// Token: 0x04000955 RID: 2389
			public Texture texture;

			// Token: 0x04000956 RID: 2390
			public bool dynamic;

			// Token: 0x04000957 RID: 2391
			public int refCount;
		}

		// Token: 0x020002B7 RID: 695
		public struct Statistics
		{
			// Token: 0x04000958 RID: 2392
			public int freeIdsCount;

			// Token: 0x04000959 RID: 2393
			public int createdIdsCount;

			// Token: 0x0400095A RID: 2394
			public int allocatedIdsTotalCount;

			// Token: 0x0400095B RID: 2395
			public int allocatedIdsDynamicCount;

			// Token: 0x0400095C RID: 2396
			public int allocatedIdsStaticCount;

			// Token: 0x0400095D RID: 2397
			public int availableIdsCount;
		}
	}
}
