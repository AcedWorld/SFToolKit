using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000BA RID: 186
	public class RTHandle
	{
		// Token: 0x06000585 RID: 1413 RVA: 0x0001C526 File Offset: 0x0001A726
		public void SetCustomHandleProperties(in RTHandleProperties properties)
		{
			this.m_UseCustomHandleScales = true;
			this.m_CustomHandleProperties = properties;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0001C53B File Offset: 0x0001A73B
		public void ClearCustomHandleProperties()
		{
			this.m_UseCustomHandleScales = false;
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0001C544 File Offset: 0x0001A744
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x0001C54C File Offset: 0x0001A74C
		public Vector2 scaleFactor { get; internal set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0001C555 File Offset: 0x0001A755
		// (set) Token: 0x0600058A RID: 1418 RVA: 0x0001C55D File Offset: 0x0001A75D
		public bool useScaling { get; internal set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0001C566 File Offset: 0x0001A766
		// (set) Token: 0x0600058C RID: 1420 RVA: 0x0001C56E File Offset: 0x0001A76E
		public Vector2Int referenceSize { get; internal set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0001C577 File Offset: 0x0001A777
		public RTHandleProperties rtHandleProperties
		{
			get
			{
				if (!this.m_UseCustomHandleScales)
				{
					return this.m_Owner.rtHandleProperties;
				}
				return this.m_CustomHandleProperties;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x0001C593 File Offset: 0x0001A793
		public RenderTexture rt
		{
			get
			{
				return this.m_RT;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0001C59B File Offset: 0x0001A79B
		public RenderTargetIdentifier nameID
		{
			get
			{
				return this.m_NameID;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0001C5A3 File Offset: 0x0001A7A3
		public string name
		{
			get
			{
				return this.m_Name;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x0001C5AB File Offset: 0x0001A7AB
		public bool isMSAAEnabled
		{
			get
			{
				return this.m_EnableMSAA;
			}
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0001C5B3 File Offset: 0x0001A7B3
		internal RTHandle(RTHandleSystem owner)
		{
			this.m_Owner = owner;
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0001C5C4 File Offset: 0x0001A7C4
		public static implicit operator RenderTargetIdentifier(RTHandle handle)
		{
			if (handle == null)
			{
				return default(RenderTargetIdentifier);
			}
			return handle.nameID;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0001C5E4 File Offset: 0x0001A7E4
		public static implicit operator Texture(RTHandle handle)
		{
			if (handle == null)
			{
				return null;
			}
			if (!(handle.rt != null))
			{
				return handle.m_ExternalTexture;
			}
			return handle.rt;
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0001C606 File Offset: 0x0001A806
		public static implicit operator RenderTexture(RTHandle handle)
		{
			if (handle == null)
			{
				return null;
			}
			return handle.rt;
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0001C613 File Offset: 0x0001A813
		internal void SetRenderTexture(RenderTexture rt)
		{
			this.m_RT = rt;
			this.m_ExternalTexture = null;
			this.m_NameID = new RenderTargetIdentifier(rt);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0001C62F File Offset: 0x0001A82F
		internal void SetTexture(Texture tex)
		{
			this.m_RT = null;
			this.m_ExternalTexture = tex;
			this.m_NameID = new RenderTargetIdentifier(tex);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0001C64B File Offset: 0x0001A84B
		internal void SetTexture(RenderTargetIdentifier tex)
		{
			this.m_RT = null;
			this.m_ExternalTexture = null;
			this.m_NameID = tex;
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0001C664 File Offset: 0x0001A864
		public int GetInstanceID()
		{
			if (this.m_RT != null)
			{
				return this.m_RT.GetInstanceID();
			}
			if (this.m_ExternalTexture != null)
			{
				return this.m_ExternalTexture.GetInstanceID();
			}
			return this.m_NameID.GetHashCode();
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0001C6B6 File Offset: 0x0001A8B6
		public void Release()
		{
			this.m_Owner.Remove(this);
			CoreUtils.Destroy(this.m_RT);
			this.m_NameID = BuiltinRenderTextureType.None;
			this.m_RT = null;
			this.m_ExternalTexture = null;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0001C6EC File Offset: 0x0001A8EC
		public Vector2Int GetScaledSize(Vector2Int refSize)
		{
			if (!this.useScaling)
			{
				return refSize;
			}
			if (this.scaleFunc != null)
			{
				return this.scaleFunc(refSize);
			}
			return new Vector2Int(Mathf.RoundToInt(this.scaleFactor.x * (float)refSize.x), Mathf.RoundToInt(this.scaleFactor.y * (float)refSize.y));
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0001C750 File Offset: 0x0001A950
		public Vector2Int GetScaledSize()
		{
			if (!this.useScaling)
			{
				return this.referenceSize;
			}
			if (this.scaleFunc != null)
			{
				return this.scaleFunc(this.referenceSize);
			}
			return new Vector2Int(Mathf.RoundToInt(this.scaleFactor.x * (float)this.referenceSize.x), Mathf.RoundToInt(this.scaleFactor.y * (float)this.referenceSize.y));
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0001C7CB File Offset: 0x0001A9CB
		public void SwitchToFastMemory(CommandBuffer cmd, float residencyFraction = 1f, FastMemoryFlags flags = FastMemoryFlags.SpillTop, bool copyContents = false)
		{
			residencyFraction = Mathf.Clamp01(residencyFraction);
			cmd.SwitchIntoFastMemory(this.m_RT, flags, residencyFraction, copyContents);
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0001C7EA File Offset: 0x0001A9EA
		public void CopyToFastMemory(CommandBuffer cmd, float residencyFraction = 1f, FastMemoryFlags flags = FastMemoryFlags.SpillTop)
		{
			this.SwitchToFastMemory(cmd, residencyFraction, flags, true);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0001C7F6 File Offset: 0x0001A9F6
		public void SwitchOutFastMemory(CommandBuffer cmd, bool copyContents = true)
		{
			cmd.SwitchOutOfFastMemory(this.m_RT, copyContents);
		}

		// Token: 0x0400040D RID: 1037
		internal RTHandleSystem m_Owner;

		// Token: 0x0400040E RID: 1038
		internal RenderTexture m_RT;

		// Token: 0x0400040F RID: 1039
		internal Texture m_ExternalTexture;

		// Token: 0x04000410 RID: 1040
		internal RenderTargetIdentifier m_NameID;

		// Token: 0x04000411 RID: 1041
		internal bool m_EnableMSAA;

		// Token: 0x04000412 RID: 1042
		internal bool m_EnableRandomWrite;

		// Token: 0x04000413 RID: 1043
		internal bool m_EnableHWDynamicScale;

		// Token: 0x04000414 RID: 1044
		internal string m_Name;

		// Token: 0x04000415 RID: 1045
		internal bool m_UseCustomHandleScales;

		// Token: 0x04000416 RID: 1046
		internal RTHandleProperties m_CustomHandleProperties;

		// Token: 0x04000418 RID: 1048
		internal ScaleFunc scaleFunc;
	}
}
