using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200003E RID: 62
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct RigidTransform
	{
		// Token: 0x06001E6C RID: 7788 RVA: 0x0005860B File Offset: 0x0005680B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public RigidTransform(quaternion rotation, float3 translation)
		{
			this.rot = rotation;
			this.pos = translation;
		}

		// Token: 0x06001E6D RID: 7789 RVA: 0x0005861B File Offset: 0x0005681B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public RigidTransform(float3x3 rotation, float3 translation)
		{
			this.rot = new quaternion(rotation);
			this.pos = translation;
		}

		// Token: 0x06001E6E RID: 7790 RVA: 0x00058630 File Offset: 0x00056830
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public RigidTransform(float4x4 transform)
		{
			this.rot = new quaternion(transform);
			this.pos = transform.c3.xyz;
		}

		// Token: 0x06001E6F RID: 7791 RVA: 0x00058650 File Offset: 0x00056850
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform AxisAngle(float3 axis, float angle)
		{
			return new RigidTransform(quaternion.AxisAngle(axis, angle), float3.zero);
		}

		// Token: 0x06001E70 RID: 7792 RVA: 0x00058663 File Offset: 0x00056863
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerXYZ(float3 xyz)
		{
			return new RigidTransform(quaternion.EulerXYZ(xyz), float3.zero);
		}

		// Token: 0x06001E71 RID: 7793 RVA: 0x00058675 File Offset: 0x00056875
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerXZY(float3 xyz)
		{
			return new RigidTransform(quaternion.EulerXZY(xyz), float3.zero);
		}

		// Token: 0x06001E72 RID: 7794 RVA: 0x00058687 File Offset: 0x00056887
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerYXZ(float3 xyz)
		{
			return new RigidTransform(quaternion.EulerYXZ(xyz), float3.zero);
		}

		// Token: 0x06001E73 RID: 7795 RVA: 0x00058699 File Offset: 0x00056899
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerYZX(float3 xyz)
		{
			return new RigidTransform(quaternion.EulerYZX(xyz), float3.zero);
		}

		// Token: 0x06001E74 RID: 7796 RVA: 0x000586AB File Offset: 0x000568AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerZXY(float3 xyz)
		{
			return new RigidTransform(quaternion.EulerZXY(xyz), float3.zero);
		}

		// Token: 0x06001E75 RID: 7797 RVA: 0x000586BD File Offset: 0x000568BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerZYX(float3 xyz)
		{
			return new RigidTransform(quaternion.EulerZYX(xyz), float3.zero);
		}

		// Token: 0x06001E76 RID: 7798 RVA: 0x000586CF File Offset: 0x000568CF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerXYZ(float x, float y, float z)
		{
			return RigidTransform.EulerXYZ(math.float3(x, y, z));
		}

		// Token: 0x06001E77 RID: 7799 RVA: 0x000586DE File Offset: 0x000568DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerXZY(float x, float y, float z)
		{
			return RigidTransform.EulerXZY(math.float3(x, y, z));
		}

		// Token: 0x06001E78 RID: 7800 RVA: 0x000586ED File Offset: 0x000568ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerYXZ(float x, float y, float z)
		{
			return RigidTransform.EulerYXZ(math.float3(x, y, z));
		}

		// Token: 0x06001E79 RID: 7801 RVA: 0x000586FC File Offset: 0x000568FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerYZX(float x, float y, float z)
		{
			return RigidTransform.EulerYZX(math.float3(x, y, z));
		}

		// Token: 0x06001E7A RID: 7802 RVA: 0x0005870B File Offset: 0x0005690B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerZXY(float x, float y, float z)
		{
			return RigidTransform.EulerZXY(math.float3(x, y, z));
		}

		// Token: 0x06001E7B RID: 7803 RVA: 0x0005871A File Offset: 0x0005691A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform EulerZYX(float x, float y, float z)
		{
			return RigidTransform.EulerZYX(math.float3(x, y, z));
		}

		// Token: 0x06001E7C RID: 7804 RVA: 0x0005872C File Offset: 0x0005692C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform Euler(float3 xyz, math.RotationOrder order = math.RotationOrder.ZXY)
		{
			switch (order)
			{
			case math.RotationOrder.XYZ:
				return RigidTransform.EulerXYZ(xyz);
			case math.RotationOrder.XZY:
				return RigidTransform.EulerXZY(xyz);
			case math.RotationOrder.YXZ:
				return RigidTransform.EulerYXZ(xyz);
			case math.RotationOrder.YZX:
				return RigidTransform.EulerYZX(xyz);
			case math.RotationOrder.ZXY:
				return RigidTransform.EulerZXY(xyz);
			case math.RotationOrder.ZYX:
				return RigidTransform.EulerZYX(xyz);
			default:
				return RigidTransform.identity;
			}
		}

		// Token: 0x06001E7D RID: 7805 RVA: 0x00058788 File Offset: 0x00056988
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform Euler(float x, float y, float z, math.RotationOrder order = math.RotationOrder.ZXY)
		{
			return RigidTransform.Euler(math.float3(x, y, z), order);
		}

		// Token: 0x06001E7E RID: 7806 RVA: 0x00058798 File Offset: 0x00056998
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform RotateX(float angle)
		{
			return new RigidTransform(quaternion.RotateX(angle), float3.zero);
		}

		// Token: 0x06001E7F RID: 7807 RVA: 0x000587AA File Offset: 0x000569AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform RotateY(float angle)
		{
			return new RigidTransform(quaternion.RotateY(angle), float3.zero);
		}

		// Token: 0x06001E80 RID: 7808 RVA: 0x000587BC File Offset: 0x000569BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform RotateZ(float angle)
		{
			return new RigidTransform(quaternion.RotateZ(angle), float3.zero);
		}

		// Token: 0x06001E81 RID: 7809 RVA: 0x000587CE File Offset: 0x000569CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform Translate(float3 vector)
		{
			return new RigidTransform(quaternion.identity, vector);
		}

		// Token: 0x06001E82 RID: 7810 RVA: 0x000587DB File Offset: 0x000569DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(RigidTransform x)
		{
			return this.rot.Equals(x.rot) && this.pos.Equals(x.pos);
		}

		// Token: 0x06001E83 RID: 7811 RVA: 0x00058804 File Offset: 0x00056A04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object x)
		{
			if (x is RigidTransform)
			{
				RigidTransform x2 = (RigidTransform)x;
				return this.Equals(x2);
			}
			return false;
		}

		// Token: 0x06001E84 RID: 7812 RVA: 0x00058829 File Offset: 0x00056A29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001E85 RID: 7813 RVA: 0x00058838 File Offset: 0x00056A38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("RigidTransform(({0}f, {1}f, {2}f, {3}f),  ({4}f, {5}f, {6}f))", new object[]
			{
				this.rot.value.x,
				this.rot.value.y,
				this.rot.value.z,
				this.rot.value.w,
				this.pos.x,
				this.pos.y,
				this.pos.z
			});
		}

		// Token: 0x06001E86 RID: 7814 RVA: 0x000588F0 File Offset: 0x00056AF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float4x4(({0}f, {1}f, {2}f, {3}f),  ({4}f, {5}f, {6}f))", new object[]
			{
				this.rot.value.x.ToString(format, formatProvider),
				this.rot.value.y.ToString(format, formatProvider),
				this.rot.value.z.ToString(format, formatProvider),
				this.rot.value.w.ToString(format, formatProvider),
				this.pos.x.ToString(format, formatProvider),
				this.pos.y.ToString(format, formatProvider),
				this.pos.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000E5 RID: 229
		public quaternion rot;

		// Token: 0x040000E6 RID: 230
		public float3 pos;

		// Token: 0x040000E7 RID: 231
		public static readonly RigidTransform identity = new RigidTransform(new quaternion(0f, 0f, 0f, 1f), new float3(0f, 0f, 0f));
	}
}
