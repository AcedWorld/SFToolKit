using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x0200042B RID: 1067
	[NativeHeader("Runtime/Graphics/GPUFence.h")]
	[UsedByNativeCode]
	public struct GraphicsFence
	{
		// Token: 0x060021EE RID: 8686 RVA: 0x00038A54 File Offset: 0x00036C54
		internal static SynchronisationStageFlags TranslateSynchronizationStageToFlags(SynchronisationStage s)
		{
			return (s == SynchronisationStage.VertexProcessing) ? SynchronisationStageFlags.VertexProcessing : SynchronisationStageFlags.PixelProcessing;
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x060021EF RID: 8687 RVA: 0x00038A70 File Offset: 0x00036C70
		public bool passed
		{
			get
			{
				this.Validate();
				bool flag = !SystemInfo.supportsGraphicsFence;
				if (flag)
				{
					throw new NotSupportedException("Cannot determine if this GraphicsFence has passed as this platform has not implemented GraphicsFences.");
				}
				bool flag2 = this.m_FenceType == GraphicsFenceType.AsyncQueueSynchronisation && !SystemInfo.supportsAsyncCompute;
				if (flag2)
				{
					throw new NotSupportedException("Cannot determine if this AsyncQueueSynchronisation GraphicsFence has passed as this platform does not support async compute.");
				}
				bool flag3 = !this.IsFencePending();
				return flag3 || GraphicsFence.HasFencePassed_Internal(this.m_Ptr);
			}
		}

		// Token: 0x060021F0 RID: 8688
		[FreeFunction("GPUFenceInternals::HasFencePassed_Internal")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasFencePassed_Internal(IntPtr fencePtr);

		// Token: 0x060021F1 RID: 8689 RVA: 0x00038AE0 File Offset: 0x00036CE0
		internal void InitPostAllocation()
		{
			bool flag = this.m_Ptr == IntPtr.Zero;
			if (flag)
			{
				bool supportsGraphicsFence = SystemInfo.supportsGraphicsFence;
				if (supportsGraphicsFence)
				{
					throw new NullReferenceException("The internal fence ptr is null, this should not be possible for fences that have been correctly constructed using Graphics.CreateGraphicsFence() or CommandBuffer.CreateGraphicsFence()");
				}
				this.m_Version = this.GetPlatformNotSupportedVersion();
			}
			else
			{
				this.m_Version = GraphicsFence.GetVersionNumber(this.m_Ptr);
			}
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x00038B38 File Offset: 0x00036D38
		internal bool IsFencePending()
		{
			bool flag = this.m_Ptr == IntPtr.Zero;
			return !flag && this.m_Version == GraphicsFence.GetVersionNumber(this.m_Ptr);
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x00038B78 File Offset: 0x00036D78
		internal void Validate()
		{
			bool flag = this.m_Version == 0 || (SystemInfo.supportsGraphicsFence && this.m_Version == this.GetPlatformNotSupportedVersion());
			if (flag)
			{
				throw new InvalidOperationException("This GraphicsFence object has not been correctly constructed see Graphics.CreateGraphicsFence() or CommandBuffer.CreateGraphicsFence()");
			}
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x00038BB8 File Offset: 0x00036DB8
		private int GetPlatformNotSupportedVersion()
		{
			return -1;
		}

		// Token: 0x060021F5 RID: 8693
		[FreeFunction("GPUFenceInternals::GetVersionNumber")]
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetVersionNumber(IntPtr fencePtr);

		// Token: 0x04000D13 RID: 3347
		internal IntPtr m_Ptr;

		// Token: 0x04000D14 RID: 3348
		internal int m_Version;

		// Token: 0x04000D15 RID: 3349
		internal GraphicsFenceType m_FenceType;
	}
}
