using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

namespace UnityEngine
{
	// Token: 0x02000149 RID: 329
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	public struct RenderBuffer
	{
		// Token: 0x0600094B RID: 2379 RVA: 0x0000EF71 File Offset: 0x0000D171
		[FreeFunction(Name = "RenderBufferScripting::SetLoadAction", HasExplicitThis = true)]
		internal void SetLoadAction(RenderBufferLoadAction action)
		{
			RenderBuffer.SetLoadAction_Injected(ref this, action);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0000EF7A File Offset: 0x0000D17A
		[FreeFunction(Name = "RenderBufferScripting::SetStoreAction", HasExplicitThis = true)]
		internal void SetStoreAction(RenderBufferStoreAction action)
		{
			RenderBuffer.SetStoreAction_Injected(ref this, action);
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0000EF83 File Offset: 0x0000D183
		[FreeFunction(Name = "RenderBufferScripting::GetLoadAction", HasExplicitThis = true)]
		internal RenderBufferLoadAction GetLoadAction()
		{
			return RenderBuffer.GetLoadAction_Injected(ref this);
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0000EF8B File Offset: 0x0000D18B
		[FreeFunction(Name = "RenderBufferScripting::GetStoreAction", HasExplicitThis = true)]
		internal RenderBufferStoreAction GetStoreAction()
		{
			return RenderBuffer.GetStoreAction_Injected(ref this);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0000EF93 File Offset: 0x0000D193
		[FreeFunction(Name = "RenderBufferScripting::GetNativeRenderBufferPtr", HasExplicitThis = true)]
		public IntPtr GetNativeRenderBufferPtr()
		{
			return RenderBuffer.GetNativeRenderBufferPtr_Injected(ref this);
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x0000EF9C File Offset: 0x0000D19C
		// (set) Token: 0x06000951 RID: 2385 RVA: 0x0000EFB4 File Offset: 0x0000D1B4
		internal RenderBufferLoadAction loadAction
		{
			get
			{
				return this.GetLoadAction();
			}
			set
			{
				this.SetLoadAction(value);
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x0000EFC0 File Offset: 0x0000D1C0
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x0000EFD8 File Offset: 0x0000D1D8
		internal RenderBufferStoreAction storeAction
		{
			get
			{
				return this.GetStoreAction();
			}
			set
			{
				this.SetStoreAction(value);
			}
		}

		// Token: 0x06000954 RID: 2388
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLoadAction_Injected(ref RenderBuffer _unity_self, RenderBufferLoadAction action);

		// Token: 0x06000955 RID: 2389
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetStoreAction_Injected(ref RenderBuffer _unity_self, RenderBufferStoreAction action);

		// Token: 0x06000956 RID: 2390
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RenderBufferLoadAction GetLoadAction_Injected(ref RenderBuffer _unity_self);

		// Token: 0x06000957 RID: 2391
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern RenderBufferStoreAction GetStoreAction_Injected(ref RenderBuffer _unity_self);

		// Token: 0x06000958 RID: 2392
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetNativeRenderBufferPtr_Injected(ref RenderBuffer _unity_self);

		// Token: 0x0400041F RID: 1055
		internal int m_RenderTextureInstanceID;

		// Token: 0x04000420 RID: 1056
		internal IntPtr m_BufferPtr;
	}
}
