using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020002A6 RID: 678
	[RequireComponent(typeof(Transform))]
	[NativeType("Runtime/Graphics/Mesh/SpriteRenderer.h")]
	public sealed class SpriteRenderer : Renderer
	{
		// Token: 0x06001CFE RID: 7422 RVA: 0x0002FF1C File Offset: 0x0002E11C
		public void RegisterSpriteChangeCallback(UnityAction<SpriteRenderer> callback)
		{
			bool flag = this.m_SpriteChangeEvent == null;
			if (flag)
			{
				this.m_SpriteChangeEvent = new UnityEvent<SpriteRenderer>();
			}
			this.m_SpriteChangeEvent.AddListener(callback);
			this.hasSpriteChangeEvents = true;
		}

		// Token: 0x06001CFF RID: 7423 RVA: 0x0002FF58 File Offset: 0x0002E158
		public void UnregisterSpriteChangeCallback(UnityAction<SpriteRenderer> callback)
		{
			bool flag = this.m_SpriteChangeEvent != null;
			if (flag)
			{
				this.m_SpriteChangeEvent.RemoveListener(callback);
				bool flag2 = this.m_SpriteChangeEvent.GetCallsCount() == 0;
				if (flag2)
				{
					this.hasSpriteChangeEvents = false;
				}
			}
		}

		// Token: 0x06001D00 RID: 7424 RVA: 0x0002FF9C File Offset: 0x0002E19C
		[RequiredByNativeCode]
		private void InvokeSpriteChanged()
		{
			try
			{
				UnityEvent<SpriteRenderer> spriteChangeEvent = this.m_SpriteChangeEvent;
				if (spriteChangeEvent != null)
				{
					spriteChangeEvent.Invoke(this);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception, this);
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x06001D01 RID: 7425
		internal extern bool shouldSupportTiling { [NativeMethod("ShouldSupportTiling")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x06001D02 RID: 7426
		// (set) Token: 0x06001D03 RID: 7427
		internal extern bool hasSpriteChangeEvents { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06001D04 RID: 7428
		// (set) Token: 0x06001D05 RID: 7429
		public extern Sprite sprite { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06001D06 RID: 7430
		// (set) Token: 0x06001D07 RID: 7431
		public extern SpriteDrawMode drawMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06001D08 RID: 7432 RVA: 0x0002FFE0 File Offset: 0x0002E1E0
		// (set) Token: 0x06001D09 RID: 7433 RVA: 0x0002FFF6 File Offset: 0x0002E1F6
		public Vector2 size
		{
			get
			{
				Vector2 result;
				this.get_size_Injected(out result);
				return result;
			}
			set
			{
				this.set_size_Injected(ref value);
			}
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06001D0A RID: 7434
		// (set) Token: 0x06001D0B RID: 7435
		public extern float adaptiveModeThreshold { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06001D0C RID: 7436
		// (set) Token: 0x06001D0D RID: 7437
		public extern SpriteTileMode tileMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06001D0E RID: 7438 RVA: 0x00030000 File Offset: 0x0002E200
		// (set) Token: 0x06001D0F RID: 7439 RVA: 0x00030016 File Offset: 0x0002E216
		public Color color
		{
			get
			{
				Color result;
				this.get_color_Injected(out result);
				return result;
			}
			set
			{
				this.set_color_Injected(ref value);
			}
		}

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06001D10 RID: 7440
		// (set) Token: 0x06001D11 RID: 7441
		public extern SpriteMaskInteraction maskInteraction { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06001D12 RID: 7442
		// (set) Token: 0x06001D13 RID: 7443
		public extern bool flipX { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06001D14 RID: 7444
		// (set) Token: 0x06001D15 RID: 7445
		public extern bool flipY { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06001D16 RID: 7446
		// (set) Token: 0x06001D17 RID: 7447
		public extern SpriteSortPoint spriteSortPoint { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001D18 RID: 7448
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern IntPtr GetCurrentMeshDataPtr();

		// Token: 0x06001D19 RID: 7449 RVA: 0x00030020 File Offset: 0x0002E220
		internal unsafe Mesh.MeshDataArray GetCurrentMeshData()
		{
			IntPtr currentMeshDataPtr = this.GetCurrentMeshDataPtr();
			bool flag = currentMeshDataPtr == IntPtr.Zero;
			Mesh.MeshDataArray result;
			if (flag)
			{
				result = new Mesh.MeshDataArray(0);
			}
			else
			{
				Mesh.MeshDataArray meshDataArray = new Mesh.MeshDataArray(1);
				*meshDataArray.m_Ptrs = currentMeshDataPtr;
				result = meshDataArray;
			}
			return result;
		}

		// Token: 0x06001D1A RID: 7450 RVA: 0x00030064 File Offset: 0x0002E264
		[NativeMethod(Name = "GetSpriteBounds")]
		internal Bounds Internal_GetSpriteBounds(SpriteDrawMode mode)
		{
			Bounds result;
			this.Internal_GetSpriteBounds_Injected(mode, out result);
			return result;
		}

		// Token: 0x06001D1B RID: 7451
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void GetSecondaryTextureProperties([NotNull("ArgumentNullException")] MaterialPropertyBlock mbp);

		// Token: 0x06001D1C RID: 7452 RVA: 0x0003007C File Offset: 0x0002E27C
		internal Bounds GetSpriteBounds()
		{
			return this.Internal_GetSpriteBounds(this.drawMode);
		}

		// Token: 0x06001D1E RID: 7454
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_size_Injected(out Vector2 ret);

		// Token: 0x06001D1F RID: 7455
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_size_Injected(ref Vector2 value);

		// Token: 0x06001D20 RID: 7456
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_color_Injected(out Color ret);

		// Token: 0x06001D21 RID: 7457
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void set_color_Injected(ref Color value);

		// Token: 0x06001D22 RID: 7458
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_GetSpriteBounds_Injected(SpriteDrawMode mode, out Bounds ret);

		// Token: 0x040009A6 RID: 2470
		private UnityEvent<SpriteRenderer> m_SpriteChangeEvent;
	}
}
