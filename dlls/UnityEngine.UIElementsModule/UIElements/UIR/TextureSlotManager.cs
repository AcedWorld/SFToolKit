using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200046D RID: 1133
	internal class TextureSlotManager
	{
		// Token: 0x06002328 RID: 9000 RVA: 0x00088938 File Offset: 0x00086B38
		static TextureSlotManager()
		{
			TextureSlotManager.k_SlotCount = (UIRenderDevice.shaderModelIs35 ? 8 : 4);
			TextureSlotManager.slotIds = new int[TextureSlotManager.k_SlotCount];
			for (int i = 0; i < TextureSlotManager.k_SlotCount; i++)
			{
				TextureSlotManager.slotIds[i] = Shader.PropertyToID(string.Format("_Texture{0}", i));
			}
		}

		// Token: 0x06002329 RID: 9001 RVA: 0x000889AC File Offset: 0x00086BAC
		public TextureSlotManager()
		{
			this.m_Textures = new TextureId[TextureSlotManager.k_SlotCount];
			this.m_Tickets = new int[TextureSlotManager.k_SlotCount];
			this.m_GpuTextures = new Vector4[TextureSlotManager.k_SlotCount * TextureSlotManager.k_SlotSize];
			this.Reset();
		}

		// Token: 0x0600232A RID: 9002 RVA: 0x00088A14 File Offset: 0x00086C14
		public void Reset()
		{
			this.m_CurrentTicket = 0;
			this.m_FirstUsedTicket = 0;
			for (int i = 0; i < TextureSlotManager.k_SlotCount; i++)
			{
				this.m_Textures[i] = TextureId.invalid;
				this.m_Tickets[i] = -1;
				this.SetGpuData(i, TextureId.invalid, 1, 1, 0f);
			}
		}

		// Token: 0x0600232B RID: 9003 RVA: 0x00088A74 File Offset: 0x00086C74
		public void StartNewBatch()
		{
			int num = this.m_CurrentTicket + 1;
			this.m_CurrentTicket = num;
			this.m_FirstUsedTicket = num;
			this.FreeSlots = TextureSlotManager.k_SlotCount;
		}

		// Token: 0x0600232C RID: 9004 RVA: 0x00088AA8 File Offset: 0x00086CA8
		public int IndexOf(TextureId id)
		{
			for (int i = 0; i < TextureSlotManager.k_SlotCount; i++)
			{
				bool flag = this.m_Textures[i].index == id.index;
				if (flag)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600232D RID: 9005 RVA: 0x00088AF4 File Offset: 0x00086CF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void MarkUsed(int slotIndex)
		{
			int num = this.m_Tickets[slotIndex];
			bool flag = num < this.m_FirstUsedTicket;
			int num2;
			if (flag)
			{
				num2 = this.FreeSlots - 1;
				this.FreeSlots = num2;
			}
			int[] tickets = this.m_Tickets;
			num2 = this.m_CurrentTicket + 1;
			this.m_CurrentTicket = num2;
			tickets[slotIndex] = num2;
		}

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x0600232E RID: 9006 RVA: 0x00088B42 File Offset: 0x00086D42
		// (set) Token: 0x0600232F RID: 9007 RVA: 0x00088B4A File Offset: 0x00086D4A
		public int FreeSlots { get; private set; } = TextureSlotManager.k_SlotCount;

		// Token: 0x06002330 RID: 9008 RVA: 0x00088B54 File Offset: 0x00086D54
		public int FindOldestSlot()
		{
			int num = this.m_Tickets[0];
			int result = 0;
			for (int i = 1; i < TextureSlotManager.k_SlotCount; i++)
			{
				bool flag = this.m_Tickets[i] < num;
				if (flag)
				{
					num = this.m_Tickets[i];
					result = i;
				}
			}
			return result;
		}

		// Token: 0x06002331 RID: 9009 RVA: 0x00088BA8 File Offset: 0x00086DA8
		public void Bind(TextureId id, float sdfScale, int slot, MaterialPropertyBlock mat)
		{
			Texture texture = this.textureRegistry.GetTexture(id);
			bool flag = texture == null;
			if (flag)
			{
				texture = Texture2D.whiteTexture;
			}
			this.m_Textures[slot] = id;
			this.MarkUsed(slot);
			this.SetGpuData(slot, id, texture.width, texture.height, sdfScale);
			mat.SetTexture(TextureSlotManager.slotIds[slot], texture);
			mat.SetVectorArray(TextureSlotManager.textureTableId, this.m_GpuTextures);
		}

		// Token: 0x06002332 RID: 9010 RVA: 0x00088C24 File Offset: 0x00086E24
		public void SetGpuData(int slotIndex, TextureId id, int textureWidth, int textureHeight, float sdfScale)
		{
			int num = slotIndex * TextureSlotManager.k_SlotSize;
			float y = 1f / (float)textureWidth;
			float z = 1f / (float)textureHeight;
			this.m_GpuTextures[num] = new Vector4(id.ConvertToGpu(), y, z, sdfScale);
			this.m_GpuTextures[num + 1] = new Vector4((float)textureWidth, (float)textureHeight, 0f, 0f);
		}

		// Token: 0x0400104F RID: 4175
		internal static readonly int k_SlotCount;

		// Token: 0x04001050 RID: 4176
		internal static readonly int k_SlotSize = 2;

		// Token: 0x04001051 RID: 4177
		internal static readonly int[] slotIds;

		// Token: 0x04001052 RID: 4178
		internal static readonly int textureTableId = Shader.PropertyToID("_TextureInfo");

		// Token: 0x04001053 RID: 4179
		private TextureId[] m_Textures;

		// Token: 0x04001054 RID: 4180
		private int[] m_Tickets;

		// Token: 0x04001055 RID: 4181
		private int m_CurrentTicket;

		// Token: 0x04001056 RID: 4182
		private int m_FirstUsedTicket;

		// Token: 0x04001057 RID: 4183
		private Vector4[] m_GpuTextures;

		// Token: 0x04001059 RID: 4185
		internal TextureRegistry textureRegistry = TextureRegistry.instance;
	}
}
