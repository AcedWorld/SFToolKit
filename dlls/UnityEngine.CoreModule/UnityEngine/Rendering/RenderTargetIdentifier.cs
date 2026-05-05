using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000409 RID: 1033
	public struct RenderTargetIdentifier : IEquatable<RenderTargetIdentifier>
	{
		// Token: 0x060021C8 RID: 8648 RVA: 0x000382F9 File Offset: 0x000364F9
		public RenderTargetIdentifier(BuiltinRenderTextureType type)
		{
			this.m_Type = type;
			this.m_NameID = -1;
			this.m_InstanceID = 0;
			this.m_BufferPointer = IntPtr.Zero;
			this.m_MipLevel = 0;
			this.m_CubeFace = CubemapFace.Unknown;
			this.m_DepthSlice = 0;
		}

		// Token: 0x060021C9 RID: 8649 RVA: 0x00038331 File Offset: 0x00036531
		public RenderTargetIdentifier(BuiltinRenderTextureType type, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0)
		{
			this.m_Type = type;
			this.m_NameID = -1;
			this.m_InstanceID = 0;
			this.m_BufferPointer = IntPtr.Zero;
			this.m_MipLevel = mipLevel;
			this.m_CubeFace = cubeFace;
			this.m_DepthSlice = depthSlice;
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x0003836A File Offset: 0x0003656A
		public RenderTargetIdentifier(string name)
		{
			this.m_Type = BuiltinRenderTextureType.PropertyName;
			this.m_NameID = Shader.PropertyToID(name);
			this.m_InstanceID = 0;
			this.m_BufferPointer = IntPtr.Zero;
			this.m_MipLevel = 0;
			this.m_CubeFace = CubemapFace.Unknown;
			this.m_DepthSlice = 0;
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x000383A8 File Offset: 0x000365A8
		public RenderTargetIdentifier(string name, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0)
		{
			this.m_Type = BuiltinRenderTextureType.PropertyName;
			this.m_NameID = Shader.PropertyToID(name);
			this.m_InstanceID = 0;
			this.m_BufferPointer = IntPtr.Zero;
			this.m_MipLevel = mipLevel;
			this.m_CubeFace = cubeFace;
			this.m_DepthSlice = depthSlice;
		}

		// Token: 0x060021CC RID: 8652 RVA: 0x000383E7 File Offset: 0x000365E7
		public RenderTargetIdentifier(int nameID)
		{
			this.m_Type = BuiltinRenderTextureType.PropertyName;
			this.m_NameID = nameID;
			this.m_InstanceID = 0;
			this.m_BufferPointer = IntPtr.Zero;
			this.m_MipLevel = 0;
			this.m_CubeFace = CubemapFace.Unknown;
			this.m_DepthSlice = 0;
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x00038420 File Offset: 0x00036620
		public RenderTargetIdentifier(int nameID, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0)
		{
			this.m_Type = BuiltinRenderTextureType.PropertyName;
			this.m_NameID = nameID;
			this.m_InstanceID = 0;
			this.m_BufferPointer = IntPtr.Zero;
			this.m_MipLevel = mipLevel;
			this.m_CubeFace = cubeFace;
			this.m_DepthSlice = depthSlice;
		}

		// Token: 0x060021CE RID: 8654 RVA: 0x0003845C File Offset: 0x0003665C
		public RenderTargetIdentifier(RenderTargetIdentifier renderTargetIdentifier, int mipLevel, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0)
		{
			this.m_Type = renderTargetIdentifier.m_Type;
			this.m_NameID = renderTargetIdentifier.m_NameID;
			this.m_InstanceID = renderTargetIdentifier.m_InstanceID;
			this.m_BufferPointer = renderTargetIdentifier.m_BufferPointer;
			this.m_MipLevel = mipLevel;
			this.m_CubeFace = cubeFace;
			this.m_DepthSlice = depthSlice;
		}

		// Token: 0x060021CF RID: 8655 RVA: 0x000384B0 File Offset: 0x000366B0
		public RenderTargetIdentifier(Texture tex)
		{
			bool flag = tex == null;
			if (flag)
			{
				this.m_Type = BuiltinRenderTextureType.None;
			}
			else
			{
				bool flag2 = tex is RenderTexture;
				if (flag2)
				{
					this.m_Type = BuiltinRenderTextureType.RenderTexture;
				}
				else
				{
					this.m_Type = BuiltinRenderTextureType.BindableTexture;
				}
			}
			this.m_BufferPointer = IntPtr.Zero;
			this.m_NameID = -1;
			this.m_InstanceID = (tex ? tex.GetInstanceID() : 0);
			this.m_MipLevel = 0;
			this.m_CubeFace = CubemapFace.Unknown;
			this.m_DepthSlice = 0;
		}

		// Token: 0x060021D0 RID: 8656 RVA: 0x00038534 File Offset: 0x00036734
		public RenderTargetIdentifier(Texture tex, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0)
		{
			bool flag = tex == null;
			if (flag)
			{
				this.m_Type = BuiltinRenderTextureType.None;
			}
			else
			{
				bool flag2 = tex is RenderTexture;
				if (flag2)
				{
					this.m_Type = BuiltinRenderTextureType.RenderTexture;
				}
				else
				{
					this.m_Type = BuiltinRenderTextureType.BindableTexture;
				}
			}
			this.m_BufferPointer = IntPtr.Zero;
			this.m_NameID = -1;
			this.m_InstanceID = (tex ? tex.GetInstanceID() : 0);
			this.m_MipLevel = mipLevel;
			this.m_CubeFace = cubeFace;
			this.m_DepthSlice = depthSlice;
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x000385B9 File Offset: 0x000367B9
		public RenderTargetIdentifier(RenderBuffer buf, int mipLevel = 0, CubemapFace cubeFace = CubemapFace.Unknown, int depthSlice = 0)
		{
			this.m_Type = BuiltinRenderTextureType.BufferPtr;
			this.m_NameID = -1;
			this.m_InstanceID = buf.m_RenderTextureInstanceID;
			this.m_BufferPointer = buf.m_BufferPtr;
			this.m_MipLevel = mipLevel;
			this.m_CubeFace = cubeFace;
			this.m_DepthSlice = depthSlice;
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x000385FC File Offset: 0x000367FC
		public static implicit operator RenderTargetIdentifier(BuiltinRenderTextureType type)
		{
			return new RenderTargetIdentifier(type);
		}

		// Token: 0x060021D3 RID: 8659 RVA: 0x00038614 File Offset: 0x00036814
		public static implicit operator RenderTargetIdentifier(string name)
		{
			return new RenderTargetIdentifier(name);
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x0003862C File Offset: 0x0003682C
		public static implicit operator RenderTargetIdentifier(int nameID)
		{
			return new RenderTargetIdentifier(nameID);
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x00038644 File Offset: 0x00036844
		public static implicit operator RenderTargetIdentifier(Texture tex)
		{
			return new RenderTargetIdentifier(tex);
		}

		// Token: 0x060021D6 RID: 8662 RVA: 0x0003865C File Offset: 0x0003685C
		public static implicit operator RenderTargetIdentifier(RenderBuffer buf)
		{
			return new RenderTargetIdentifier(buf, 0, CubemapFace.Unknown, 0);
		}

		// Token: 0x060021D7 RID: 8663 RVA: 0x00038678 File Offset: 0x00036878
		public override string ToString()
		{
			return UnityString.Format("Type {0} NameID {1} InstanceID {2} BufferPointer {3} MipLevel {4} CubeFace {5} DepthSlice {6}", new object[]
			{
				this.m_Type,
				this.m_NameID,
				this.m_InstanceID,
				this.m_BufferPointer,
				this.m_MipLevel,
				this.m_CubeFace,
				this.m_DepthSlice
			});
		}

		// Token: 0x060021D8 RID: 8664 RVA: 0x000386FC File Offset: 0x000368FC
		public override int GetHashCode()
		{
			return (this.m_Type.GetHashCode() * 23 + this.m_NameID.GetHashCode()) * 23 + this.m_InstanceID.GetHashCode();
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x00038740 File Offset: 0x00036940
		public bool Equals(RenderTargetIdentifier rhs)
		{
			return this.m_Type == rhs.m_Type && this.m_NameID == rhs.m_NameID && this.m_InstanceID == rhs.m_InstanceID && this.m_BufferPointer == rhs.m_BufferPointer && this.m_MipLevel == rhs.m_MipLevel && this.m_CubeFace == rhs.m_CubeFace && this.m_DepthSlice == rhs.m_DepthSlice;
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x000387BC File Offset: 0x000369BC
		public override bool Equals(object obj)
		{
			bool flag = !(obj is RenderTargetIdentifier);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				RenderTargetIdentifier rhs = (RenderTargetIdentifier)obj;
				result = this.Equals(rhs);
			}
			return result;
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x000387F0 File Offset: 0x000369F0
		public static bool operator ==(RenderTargetIdentifier lhs, RenderTargetIdentifier rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x0003880C File Offset: 0x00036A0C
		public static bool operator !=(RenderTargetIdentifier lhs, RenderTargetIdentifier rhs)
		{
			return !lhs.Equals(rhs);
		}

		// Token: 0x04000C4D RID: 3149
		public const int AllDepthSlices = -1;

		// Token: 0x04000C4E RID: 3150
		private BuiltinRenderTextureType m_Type;

		// Token: 0x04000C4F RID: 3151
		private int m_NameID;

		// Token: 0x04000C50 RID: 3152
		private int m_InstanceID;

		// Token: 0x04000C51 RID: 3153
		private IntPtr m_BufferPointer;

		// Token: 0x04000C52 RID: 3154
		private int m_MipLevel;

		// Token: 0x04000C53 RID: 3155
		private CubemapFace m_CubeFace;

		// Token: 0x04000C54 RID: 3156
		private int m_DepthSlice;
	}
}
