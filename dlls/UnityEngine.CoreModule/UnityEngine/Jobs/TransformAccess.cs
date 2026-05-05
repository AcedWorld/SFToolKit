using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Jobs
{
	// Token: 0x020002C3 RID: 707
	[NativeHeader("Runtime/Transform/ScriptBindings/TransformAccess.bindings.h")]
	public struct TransformAccess
	{
		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06001E1E RID: 7710 RVA: 0x00031CC4 File Offset: 0x0002FEC4
		// (set) Token: 0x06001E1F RID: 7711 RVA: 0x00031CE0 File Offset: 0x0002FEE0
		public Vector3 position
		{
			get
			{
				Vector3 result;
				TransformAccess.GetPosition(ref this, out result);
				return result;
			}
			set
			{
				TransformAccess.SetPosition(ref this, ref value);
			}
		}

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x06001E20 RID: 7712 RVA: 0x00031CEC File Offset: 0x0002FEEC
		// (set) Token: 0x06001E21 RID: 7713 RVA: 0x00031D08 File Offset: 0x0002FF08
		public Quaternion rotation
		{
			get
			{
				Quaternion result;
				TransformAccess.GetRotation(ref this, out result);
				return result;
			}
			set
			{
				TransformAccess.SetRotation(ref this, ref value);
			}
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06001E22 RID: 7714 RVA: 0x00031D14 File Offset: 0x0002FF14
		// (set) Token: 0x06001E23 RID: 7715 RVA: 0x00031D30 File Offset: 0x0002FF30
		public Vector3 localPosition
		{
			get
			{
				Vector3 result;
				TransformAccess.GetLocalPosition(ref this, out result);
				return result;
			}
			set
			{
				TransformAccess.SetLocalPosition(ref this, ref value);
			}
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06001E24 RID: 7716 RVA: 0x00031D3C File Offset: 0x0002FF3C
		// (set) Token: 0x06001E25 RID: 7717 RVA: 0x00031D58 File Offset: 0x0002FF58
		public Quaternion localRotation
		{
			get
			{
				Quaternion result;
				TransformAccess.GetLocalRotation(ref this, out result);
				return result;
			}
			set
			{
				TransformAccess.SetLocalRotation(ref this, ref value);
			}
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06001E26 RID: 7718 RVA: 0x00031D64 File Offset: 0x0002FF64
		// (set) Token: 0x06001E27 RID: 7719 RVA: 0x00031D80 File Offset: 0x0002FF80
		public Vector3 localScale
		{
			get
			{
				Vector3 result;
				TransformAccess.GetLocalScale(ref this, out result);
				return result;
			}
			set
			{
				TransformAccess.SetLocalScale(ref this, ref value);
			}
		}

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06001E28 RID: 7720 RVA: 0x00031D8C File Offset: 0x0002FF8C
		public Matrix4x4 localToWorldMatrix
		{
			get
			{
				Matrix4x4 result;
				TransformAccess.GetLocalToWorldMatrix(ref this, out result);
				return result;
			}
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06001E29 RID: 7721 RVA: 0x00031DA8 File Offset: 0x0002FFA8
		public Matrix4x4 worldToLocalMatrix
		{
			get
			{
				Matrix4x4 result;
				TransformAccess.GetWorldToLocalMatrix(ref this, out result);
				return result;
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x06001E2A RID: 7722 RVA: 0x00031DC4 File Offset: 0x0002FFC4
		public bool isValid
		{
			get
			{
				return this.hierarchy != IntPtr.Zero;
			}
		}

		// Token: 0x06001E2B RID: 7723 RVA: 0x00031DD6 File Offset: 0x0002FFD6
		public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
		{
			TransformAccess.SetPositionAndRotation_Internal(ref this, ref position, ref rotation);
		}

		// Token: 0x06001E2C RID: 7724 RVA: 0x00031DE4 File Offset: 0x0002FFE4
		public void SetLocalPositionAndRotation(Vector3 localPosition, Quaternion localRotation)
		{
			TransformAccess.SetLocalPositionAndRotation_Internal(ref this, ref localPosition, ref localRotation);
		}

		// Token: 0x06001E2D RID: 7725 RVA: 0x00031DF2 File Offset: 0x0002FFF2
		public void GetPositionAndRotation(out Vector3 position, out Quaternion rotation)
		{
			TransformAccess.GetPositionAndRotation_Internal(ref this, out position, out rotation);
		}

		// Token: 0x06001E2E RID: 7726 RVA: 0x00031DFE File Offset: 0x0002FFFE
		public void GetLocalPositionAndRotation(out Vector3 localPosition, out Quaternion localRotation)
		{
			TransformAccess.GetLocalPositionAndRotation_Internal(ref this, out localPosition, out localRotation);
		}

		// Token: 0x06001E2F RID: 7727
		[NativeMethod(Name = "TransformAccessBindings::SetPositionAndRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPositionAndRotation_Internal(ref TransformAccess access, ref Vector3 position, ref Quaternion rotation);

		// Token: 0x06001E30 RID: 7728
		[NativeMethod(Name = "TransformAccessBindings::SetLocalPositionAndRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLocalPositionAndRotation_Internal(ref TransformAccess access, ref Vector3 localPosition, ref Quaternion localRotation);

		// Token: 0x06001E31 RID: 7729
		[NativeMethod(Name = "TransformAccessBindings::GetPositionAndRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPositionAndRotation_Internal(ref TransformAccess access, out Vector3 position, out Quaternion rotation);

		// Token: 0x06001E32 RID: 7730
		[NativeMethod(Name = "TransformAccessBindings::GetLocalPositionAndRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalPositionAndRotation_Internal(ref TransformAccess access, out Vector3 localPosition, out Quaternion localRotation);

		// Token: 0x06001E33 RID: 7731
		[NativeMethod(Name = "TransformAccessBindings::GetPosition", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPosition(ref TransformAccess access, out Vector3 p);

		// Token: 0x06001E34 RID: 7732
		[NativeMethod(Name = "TransformAccessBindings::SetPosition", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPosition(ref TransformAccess access, ref Vector3 p);

		// Token: 0x06001E35 RID: 7733
		[NativeMethod(Name = "TransformAccessBindings::GetRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRotation(ref TransformAccess access, out Quaternion r);

		// Token: 0x06001E36 RID: 7734
		[NativeMethod(Name = "TransformAccessBindings::SetRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetRotation(ref TransformAccess access, ref Quaternion r);

		// Token: 0x06001E37 RID: 7735
		[NativeMethod(Name = "TransformAccessBindings::GetLocalPosition", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalPosition(ref TransformAccess access, out Vector3 p);

		// Token: 0x06001E38 RID: 7736
		[NativeMethod(Name = "TransformAccessBindings::SetLocalPosition", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLocalPosition(ref TransformAccess access, ref Vector3 p);

		// Token: 0x06001E39 RID: 7737
		[NativeMethod(Name = "TransformAccessBindings::GetLocalRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalRotation(ref TransformAccess access, out Quaternion r);

		// Token: 0x06001E3A RID: 7738
		[NativeMethod(Name = "TransformAccessBindings::SetLocalRotation", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLocalRotation(ref TransformAccess access, ref Quaternion r);

		// Token: 0x06001E3B RID: 7739
		[NativeMethod(Name = "TransformAccessBindings::GetLocalScale", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalScale(ref TransformAccess access, out Vector3 r);

		// Token: 0x06001E3C RID: 7740
		[NativeMethod(Name = "TransformAccessBindings::SetLocalScale", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLocalScale(ref TransformAccess access, ref Vector3 r);

		// Token: 0x06001E3D RID: 7741
		[NativeMethod(Name = "TransformAccessBindings::GetLocalToWorldMatrix", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalToWorldMatrix(ref TransformAccess access, out Matrix4x4 m);

		// Token: 0x06001E3E RID: 7742
		[NativeMethod(Name = "TransformAccessBindings::GetWorldToLocalMatrix", IsThreadSafe = true, IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetWorldToLocalMatrix(ref TransformAccess access, out Matrix4x4 m);

		// Token: 0x06001E3F RID: 7743 RVA: 0x00031E0C File Offset: 0x0003000C
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void CheckHierarchyValid()
		{
			bool flag = !this.isValid;
			if (flag)
			{
				throw new NullReferenceException("The TransformAccess is not valid and points to an invalid hierarchy");
			}
		}

		// Token: 0x06001E40 RID: 7744 RVA: 0x00002669 File Offset: 0x00000869
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void MarkReadWrite()
		{
		}

		// Token: 0x06001E41 RID: 7745 RVA: 0x00002669 File Offset: 0x00000869
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void MarkReadOnly()
		{
		}

		// Token: 0x06001E42 RID: 7746 RVA: 0x00002669 File Offset: 0x00000869
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckWriteAccess()
		{
		}

		// Token: 0x040009F0 RID: 2544
		private IntPtr hierarchy;

		// Token: 0x040009F1 RID: 2545
		private int index;
	}
}
